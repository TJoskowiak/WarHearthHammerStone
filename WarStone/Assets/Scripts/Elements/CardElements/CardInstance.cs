using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
namespace SA
{
    public class CardInstance : NetworkBehaviour, IClicable
    {
        public SA.GameElements.CardElementLogic currentLogic;
        public CardViz cardViz;
        static CardInstance CardShowed = null; 

        void Start()
        {
            cardViz = GetComponent<CardViz>();

            if(!isServer) {

            }
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
    }
}
