using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Variables/Card Variable")]
    public class CardVariable : ScriptableObject
    {
        public CardInstance instance;

        public void SetInstance(CardInstance instance)
        {
            this.instance = instance;
        }


    }
}
