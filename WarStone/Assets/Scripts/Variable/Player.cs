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
        public GameElements.CardElementLogic HandLogic;
        public GameElements.CardElementLogic deskCardLogic;
        public int StartingCardID;

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

            cardObj.SetActive(true);
            Settings.SetParentToObject(cardObj, HandTransform);
        }


    }
}
