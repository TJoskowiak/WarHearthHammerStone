using UnityEngine;

namespace SA.GameElements
{
    [CreateAssetMenu(menuName = "Game Element/Opponent Desk Card")]
    public class OpponentDeskCard : CardElementLogic
    {
        public override void onClick(CardInstance instance)
        {
            Debug.Log("Ought");
            GameObject.Find("LocalPlayer").GetComponent<PlayerConnectionScript>().secondCard = instance.cardViz.card_object_id;
            instance.cardViz._highlight = !instance.cardViz._highlight;

        }

        public override void onHighlight(CardInstance instance)
        {

        }
    }
}
