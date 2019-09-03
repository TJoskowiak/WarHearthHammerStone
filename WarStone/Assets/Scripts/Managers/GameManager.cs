using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA.GameStates;

namespace SA
{
    public class GameManager : MonoBehaviour
    {
        public State currentState;

        private void Update()
        {
            currentState.Tick(Time.deltaTime);
        }


    }
}
