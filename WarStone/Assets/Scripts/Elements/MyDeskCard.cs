using UnityEngine;

namespace SA.GameElements
{
    [CreateAssetMenu(menuName ="Game Element/My Desk Card")]
    public class MyDeskCard : CardElementLogic
    {
        public override void onClick(CardInstance instance)
        {
            Debug.Log("Nie klikaj na mnie tylko na nich");
            GameObject.Find("LocalPlayer").GetComponent<PlayerConnectionScript>().firstCard = instance.cardViz.card_object_id;
            instance.cardViz._highlight = !instance.cardViz._highlight;

        }

        public override void onHighlight(CardInstance instance)
        {
            
        }
    }
}
