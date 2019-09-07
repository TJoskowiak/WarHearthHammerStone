using UnityEngine;
using UnityEngine.UI;
namespace SA
{
    public class CardInstance : MonoBehaviour, IClicable
    {
        public SA.GameElements.CardElementLogic currentLogic;

        static CardInstance CardShowed = null; 

        public void onClick()
        {
            currentLogic.onClick(this);

        }

        public void onHighlight()
        {
            currentLogic.onHighlight(this);
        }

        public void PopupHandCard()
        {
            Debug.Log("Powieksz");
            GameObject obj = gameObject.transform.parent.gameObject;
            if(CardShowed == null)
            {
                CardShowed = this;
                gameObject.GetComponentInParent<RectTransform>().Translate(0, 40, 0);
            }
            else if(CardShowed != this)
            {
                CardInstance.PopdownHandCard();
                gameObject.GetComponentInParent<RectTransform>().Translate(0, 40, 0);
                CardShowed = this;
            }
        }
        public static void PopdownHandCard()
        {
            if (CardShowed != null)
            {
                CardShowed.gameObject.GetComponentInParent<RectTransform>().Translate(0, -40, 00);
                CardShowed = null;
            }

        }
    }
}
