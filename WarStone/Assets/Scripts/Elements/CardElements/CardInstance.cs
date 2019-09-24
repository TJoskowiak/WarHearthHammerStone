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

        private Player owner;

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

        public void setOwner(Player owner)
        {
            this.owner = owner;
        }

        public void takeDMG(CardInstance opponent)
        {
            cardViz.healthStat -= opponent.cardViz.strengthStat;
            if (cardViz.healthStat <= 0)
                owner.KillUnit(this.gameObject);

        }
    }
}
