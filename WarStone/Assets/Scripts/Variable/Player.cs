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
        public SO.TransformVariable GraveyardTransform;
        public GameElements.CardElementLogic HandLogic;
        public GameElements.CardElementLogic deskCardLogic;
        public int StartingCardID;
        public ArrayList AvailableCards = new ArrayList(15) { 1, 1, 1, 2, 3, 3, 4, 4, 4, 5, 6, 9, 9, 14, 15 };
        public ArrayList ShuffledCards;


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
            CardInstance cardInstance = cardObj.AddComponent<CardInstance>();
            cardInstance.cardViz = viz;
            cardInstance.currentLogic = HandLogic;

            cardObj.gameObject.GetComponentInParent<CardInstance>().setOwner(this);

            cardObj.SetActive(true);
            Settings.SetParentToObject(cardObj, HandTransform);
        }

        public void KillUnit(GameObject cardObj)
        {
            Settings.SetParentToObject(cardObj, GraveyardTransform);
        }


    }
}