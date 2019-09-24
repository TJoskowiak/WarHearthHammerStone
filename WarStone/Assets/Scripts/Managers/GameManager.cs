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
        public GameObject CardPrefab;
        public Player player1;
        public Player player2;


        private void Start()
        {
            player1.StartingCardID = 0;
            player2.StartingCardID = 100;
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

        public void CreateHandCard()
        {            
            GameObject obj = Instantiate(CardPrefab) as GameObject;            
            player1.CreateHandCard(obj);
            NetworkServer.Spawn(obj);
        }


    }
}
