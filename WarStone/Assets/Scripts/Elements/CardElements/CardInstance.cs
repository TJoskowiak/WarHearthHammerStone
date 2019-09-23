using UnityEngine;
using UnityEngine.UI;
namespace SA
{
    public class CardInstance : MonoBehaviour, IClicable
    {
        public SA.GameElements.CardElementLogic currentLogic;
        public CardViz cardViz;
        static CardInstance CardShowed = null; 

        void Start()
        {
            cardViz = GetComponent<CardViz>();
        }

        public void onClick()
        {
            currentLogic.onClick(this);

        }

        public void onHighlight()
        {
            currentLogic.onHighlight(this);
        }

        public void onDrag()
        {
            currentLogic.onDrag(this);
        }

        /*public void PopupHandCard()
        {
            Debug.Log("Powieksz");
            GameObject obj = gameObject.transform.parent.gameObject;
            if(CardShowed == null)
            {
                GridLayoutGroup layout = GameObject.Find("My Hand").GetComponentInParent<GridLayoutGroup>();

                if (layout != null)
                {
                    Debug.Log("JestLayot");
                    layout.enabled = false;
                    CardShowed = this;
                    gameObject.GetComponentInParent<RectTransform>().Translate(0, 40, 0);
                }
            }
            else if(CardShowed != this)
            {
                GridLayoutGroup layout = GameObject.Find("My Hand").GetComponentInParent<GridLayoutGroup>();
                layout.enabled = true;
                
                layout.enabled = false;
                gameObject.GetComponentInParent<RectTransform>().Translate(0, 40, 0);
                CardShowed = this;
            }
        }
        */
    }
}
