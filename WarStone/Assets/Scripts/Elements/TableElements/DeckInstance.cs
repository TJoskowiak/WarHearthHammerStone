using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class DeckInstance : MonoBehaviour, IClicable
    {

        // Start is called before the first frame update
        void Start()
        {
            

        }

        public void onClick()
        {
            Settings.gameManager.CreateHandCard();
        }

        public void onDrag()
        {
            
        }

        public void onHighlight()
        {
            
        }
    }
}
