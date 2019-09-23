using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    public class CurrentSelected : MonoBehaviour
    {
        public CardVariable currentCard;
        public SimplifiedCardViz cardViz;
        public GameObject GraphicObject;

        Transform mTransform;


        public void LoadCard()
        {
            if (currentCard.instance == null)
                return;
            currentCard.instance.gameObject.SetActive(false);
            Debug.Log(currentCard.instance.cardViz.currentCardID);
            cardViz.DeserializeCard(currentCard.instance.cardViz.currentCardID);
            GraphicObject.SetActive(true);
            //cardViz.gameObject.SetActive(true);
        }

        public void HideCard()
        {
            GraphicObject.SetActive(false);
        }
        
        private void Start()
        {
            HideCard();
            mTransform = this.transform;
        }

        void Update()
        {
            mTransform.position = Input.mousePosition;

        }
    }
}
