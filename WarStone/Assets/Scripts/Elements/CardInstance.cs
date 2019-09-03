using UnityEngine;

namespace SA
{
    public class CardInstance : MonoBehaviour, IClicable
    {
        public void onClick()
        {
            CardViz a = this.gameObject.GetComponentInParent<CardViz>();
            Debug.Log(a.cardName.text + " Ejj co tak klikasz?");

        }

        public void onHighlight()
        {
            CardViz a = this.gameObject.GetComponentInParent<CardViz>();
           // Debug.Log(a.cardName.text);
        }
    }
}
