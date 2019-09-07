using UnityEngine;


namespace SA.GameElements
{
    [CreateAssetMenu(menuName ="Game Element/My Hand Card")]
    public class MyHandCard : CardElementLogic
    { 
        public override void onClick(CardInstance instance)
        {
            Debug.Log("Reka");
        }

        public override void onHighlight(CardInstance instance)
        {
            instance.PopupHandCard();
        }
    }
}
