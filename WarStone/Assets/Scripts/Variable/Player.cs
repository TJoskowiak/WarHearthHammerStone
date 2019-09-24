using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Payers/Player")]
    public class Player : ScriptableObject
    {
        public SO.TransformVariable HandTransform;
        public GameElements.CardElementLogic HandLogic;
        public GameElements.CardElementLogic deskCardLogic;
        public int StartingCardID;

        public void CreateHandCard(GameObject cardObj)
        {
           

            CardViz viz = cardObj.gameObject.GetComponentInParent<CardViz>();
            viz.card_json_id = Random.Range(1, 6);
            viz.card_object_id = StartingCardID++;

            CardInstance cardInstance = cardObj.AddComponent<CardInstance>();
            cardInstance.cardViz = viz;
            cardInstance.currentLogic = HandLogic;

            cardObj.SetActive(true);
            Settings.SetParentToObject(cardObj, HandTransform);
            Debug.Log("Stworzylem");
        }


    }
}
