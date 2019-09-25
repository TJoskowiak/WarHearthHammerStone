using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Payers/Player")]
    public class Player : ScriptableObject
    {
        public int PlayerID;
        public SO.TransformVariable HandTransform;
        public SO.TransformVariable deskTransform;
        public SO.TransformVariable GraveyardTransform;
        public GameElements.CardElementLogic HandLogic;
        public GameElements.CardElementLogic deskCardLogic;
        public GameStates.State StartingState;
        public int StartingCardID;
        public ArrayList AvailableCards = new ArrayList(15) { 1, 1, 1, 2, 3, 3, 4, 4, 4, 5, 6, 9, 9, 14, 15 };
        public ArrayList ShuffledCards;

        private static int HAND_SIZE = 5;
        private static int DESK_SIZE = 6;

        public bool isHandFreeSapce()
        {
            return HandTransform.value.childCount < HAND_SIZE;
        }

        public bool isDeskFreeSpace()
        {
            return deskTransform.value.childCount < DESK_SIZE;
        }

        public GameStates.State getStaringState()
        {
            return StartingState;
        }


        private void ShuffleCards()
        {
            ArrayList source = new ArrayList(AvailableCards);
            ArrayList output = new ArrayList();
            System.Random generator = new System.Random();

            while (source.Count > 0)
            {
                int position = generator.Next(source.Count);
                output.Add(source[position]);
                source.RemoveAt(position);
            }
            ShuffledCards = output;
        }

        public void AssignParametersToCard(GameObject cardObj)
        {
            CardViz viz = cardObj.gameObject.GetComponentInParent<CardViz>();
            viz.card_json_id = Random.Range(0, 15);
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
        }


    }
}