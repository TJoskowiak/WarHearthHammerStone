using UnityEngine;

namespace SA.GameElements
{
    [CreateAssetMenu(menuName ="Game Element/My Desk Card")]
    public class MyDeskCard : CardElementLogic
    {
        public override void onClick(CardInstance instance)
        {
            Debug.Log("Nie klikaj na mnie tylko na nich");
        }

        public override void onHighlight(CardInstance instance)
        {
            
        }
    }
}
