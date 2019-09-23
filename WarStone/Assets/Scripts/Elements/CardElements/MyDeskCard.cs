using UnityEngine;

namespace SA.GameElements
{
    [CreateAssetMenu(menuName = "Game Element/My Desk Card")]
    public class MyDeskCard : CardElementLogic
    {
        public override void onClick(CardInstance instance) {
            Debug.Log("Nie klikaj na mnie tylko na nich");
            if (instance.cardViz._highlight) {
                GameObject.Find("LocalPlayer").GetComponent<PlayerConnectionScript>().firstCard = 0;

            } else {
                GameObject.Find("LocalPlayer").GetComponent<PlayerConnectionScript>().firstCard = instance.cardViz.card_object_id;
            }
            var tempState = instance.cardViz._highlight;

            var myDeskComp = GameObject.Find("Player1CardsDown");
            var children = myDeskComp.GetComponentsInChildren<CardViz>();
            foreach (var cardInstance in children) {
                cardInstance.GetComponent<CardViz>()._highlight = false;
            }
            instance.cardViz._highlight = !tempState;

        }

        public override void onDrag(CardInstance instance)
        {
            
        }

        public override void onHighlight(CardInstance instance) {

        }
    }
}
