#pragma warning disable 0618

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SA.GameStates;


namespace SA
{
    public class GameManager : NetworkBehaviour
    {
        public State currentState;

        private void Start()
        {
            Settings.gameManager = this;
            if (!isServer) {
                Settings.ChangeStateToOpponentControlState();


            } else {
                Settings.ChangeStateToPlayerControlState();

            }
        }

        private void Update()
        {
            currentState.Tick(Time.deltaTime);
        }

        public void SetState(State state)
        {
            currentState = state;
        }


    }
}
