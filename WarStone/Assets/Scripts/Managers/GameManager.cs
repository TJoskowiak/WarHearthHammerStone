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
        public Player currentPlayer;
        public Player[] Players;


        private void Start()
        {
            Resources.Load<Player>(@"Data/Variables/Player1").StartingCardID = 1;
            Resources.Load<Player>(@"Data/Variables/Player2").StartingCardID = 101;
            Settings.gameManager = this;


            if (!isServer) {
                Settings.ChangeStateToOpponentControlState();
                currentPlayer = Resources.Load<Player>(@"Data/Variables/Player2");
                


            } else {
                Settings.ChangeStateToPlayerControlState();
                currentPlayer = Resources.Load<Player>(@"Data/Variables/Player1");

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

        public Player GetPlayer(int ID)
        {
            return Players[ID - 1];
        }

        public void CreateHandCard()
        {            
            //Spawn object
            var playerConObj = GameObject.Find("LocalPlayer").GetComponent<PlayerConnectionScript>();
            playerConObj.CmdSpawnCard(currentPlayer.PlayerID);
        }


    }
}
