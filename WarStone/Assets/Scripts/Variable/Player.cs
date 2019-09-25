using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Payers/Player")]
    public class Player : ScriptableObject
    {
        public int PlayerID;
        public SA.Races.Race Player_Race;
        public SO.TransformVariable HandTransform;
        public SO.TransformVariable deskTransform;
        public SO.TransformVariable GraveyardTransform;
        public GameElements.CardElementLogic HandLogic;
        public GameElements.CardElementLogic deskCardLogic;
        public GameElements.CardElementLogic graveLogic;
        public GameStates.State StartingState;
        
        public int StartingCardID;

        public List<int> AvailableCards = new List<int>(15) { 1, 1, 1, 2, 3, 3, 4, 4, 4, 5, 6, 9, 9, 14, 15 };
        public List<int> ShuffledCards;

        private static int HAND_SIZE = 5;
        private static int DESK_SIZE = 6;
        private ResourceHolder resourceHolder;

        public void setResourceHolder(ResourceHolder holder)
        {
            resourceHolder = holder;
        }

        public bool isHandFreeSapce()
        {
            return HandTransform.value.childCount < HAND_SIZE;
        }

        public bool isDeskFreeSpace()
        {
            return deskTransform.value.childCount < DESK_SIZE;
        }

        public void RestartResource()
        {
            if(resourceHolder)
                resourceHolder.RestartResource();
        }

        public bool ReserveResource(GameObject cardObj)
        {
            CardViz cardViz = cardObj.GetComponent<CardViz>();
            return resourceHolder.ReserveResource(cardViz.strengthStat);
        }

        public GameStates.State getStaringState()
        {
            return StartingState;
        }


        public void ShuffleCards()
        {
            ShuffledCards = Player_Race.ShuffleCards();
        }
        public bool CheckIfAnyCardLeft()
        {
            return ShuffledCards.Count > 0;
        } 

        private int PickCard()
        {
            int cardJsonID = ShuffledCards[0];
            ShuffledCards.RemoveAt(0);
            return cardJsonID;
        }

        public void AssignParametersToCard(GameObject cardObj)
        {
            CardViz viz = cardObj.gameObject.GetComponentInParent<CardViz>();
            viz.card_json_id = PickCard();

            viz.card_object_id = StartingCardID++;
        }     

        public void SetPositonToHand(GameObject cardObj)
        {
            CardViz viz = cardObj.gameObject.GetComponentInParent<CardViz>();
            CardInstance cardInstance = cardObj.gameObject.GetComponentInParent<CardInstance>();
            cardInstance.cardViz = viz;
            cardInstance.currentLogic = HandLogic;

            cardObj.gameObject.GetComponentInParent<CardInstance>().setOwner(this);
            viz.CreateCard();

            cardObj.SetActive(true);
            Settings.SetParentToObject(cardObj, HandTransform);
        }

        public void SetPositionToDesk(GameObject cardObj)
        {
            CardInstance cardInstance = cardObj.GetComponent<SA.CardInstance>();          
            cardInstance.currentLogic = deskCardLogic;

            cardObj.SetActive(true);
            Settings.SetParentToObject(cardObj, deskTransform);
        }

        public void KillUnit(GameObject cardObj)
        {
            Settings.SetParentToObject(cardObj, GraveyardTransform);
            CardInstance cardInstance = cardObj.GetComponent<SA.CardInstance>();
            cardInstance.currentLogic = graveLogic;
        }


    }
}