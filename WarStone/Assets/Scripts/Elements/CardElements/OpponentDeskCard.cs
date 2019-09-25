using UnityEngine;

namespace SA.GameElements
{
    [CreateAssetMenu(menuName = "Game Element/Opponent Desk Card")]
    public class OpponentDeskCard : CardElementLogic
    {
        public override void onClick(CardInstance instance)
        {
            if (!instance.cardViz.cardMoved)
            {
                Debug.Log("Ought");
                if (instance.cardViz._highlight)
                {
                    GameObject.Find("LocalPlayer").GetComponent<PlayerConnectionScript>().secondCard = instance.cardViz.card_object_id;

                }
                else
                {
                    GameObject.Find("LocalPlayer").GetComponent<PlayerConnectionScript>().secondCard = instance.cardViz.card_object_id;
                }
                var tempState = instance.cardViz._highlight;

                var opponentDeskComp = GameObject.Find("Player2CardsDown");
                var children = opponentDeskComp.GetComponentsInChildren<CardViz>();
                foreach (var cardInstance in children)
                {
                    cardInstance.GetComponent<CardViz>()._highlight = false;
                }

                instance.cardViz._highlight = !tempState;
            }
        }

        public override void onDrag(CardInstance instance) {

        }

        public override void onHighlight(CardInstance instance) {

        }
    }
}
