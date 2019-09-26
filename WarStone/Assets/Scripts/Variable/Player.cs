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

        public List<int> ShuffledCards;
        private int ShuffledCardsCounter;

        private static int HAND_SIZE = 5;
        private static int DESK_SIZE = 6;
        private ResourceHolder resourceHolder;
        private HeroIconScript IconScript;
        private GameObject deck;

        public int hitPoints;
        public int maxHitPoints;

        public void setDeck(GameObject deck)
        {
            this.deck = deck;
        }

        public void hideDeck()
        {
            deck.SetActive(false);
        }

        public void setIconScript(HeroIconScript icon)
        {
            IconScript = icon;
        }

        public void updateHPBar()
        {
            if(maxHitPoints != 0)
                IconScript.ChangePercentage((hitPoints * 100 )/ maxHitPoints );

        }

        public void setStartedHitPoints()
        {
            hitPoints = ShuffledCards.Count;
            maxHitPoints = hitPoints;
        }
        
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
            ShuffledCardsCounter = ShuffledCards.Count;
        }
        public bool CheckIfAnyCardLeft()
        {
            return ShuffledCardsCounter > 0;
        } 

        public void removeCardFromDeckCounter()
        {
            ShuffledCardsCounter--;
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

        public void TakeDMG()
        {
            hitPoints--;
            if(hitPoints == 0)
            {
                Settings.gameManager.EndGame(this);               
            }
        }

        public void KillUnit(GameObject cardObj)
        {
            Settings.SetParentToObject(cardObj, GraveyardTransform);
            CardInstance cardInstance = cardObj.GetComponent<SA.CardInstance>();
            cardInstance.currentLogic = graveLogic;
            TakeDMG();
        }


    }
}