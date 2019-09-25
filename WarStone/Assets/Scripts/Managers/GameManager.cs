#pragma warning disable 0618

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SA.GameStates;
using UnityEngine.UI;

namespace SA
{
    public class GameManager : NetworkBehaviour
    {
        public State currentState;
        public GameObject CardPrefab;
        public Player currentPlayer;
        public SO.GameEvent onGameStart;
        public Player[] Players;


        private PlayerConnectionScript playerConObj;

        public void SetPlayerConnectionScript(PlayerConnectionScript script)
        {
            playerConObj = script;
        }


        private void Start()
        {
            Resources.Load<Player>(@"Data/Variables/Player1").StartingCardID = 1;
            Resources.Load<Player>(@"Data/Variables/Player2").StartingCardID = 101;
            Settings.gameManager = this;
            if (!isServer)
            {
                SetState(Resources.Load<State>(@"Data/Game States/WaitingForPlayer2"));
                
                //Settings.ChangeStateToOpponentControlState();
                currentPlayer = Resources.Load<Player>(@"Data/Variables/Player2");
            }

            else
            {
                SetState(Resources.Load<State>(@"Data/Game States/WaitingForPlayer2"));
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
            var TurnTextbox = GameObject.Find("MyTurnTextbox");
            var TurnTextboxComp = TurnTextbox.GetComponent<Text>();
            if (currentState.StateName != "")
                TurnTextboxComp.text = currentState.StateName;
        }

        public void StartGame()
        {
            SetState(currentPlayer.getStaringState());
            onGameStart.Raise();
        }

        public Player GetPlayer(int ID)
        {
            return Players[ID - 1];
        }

        public void CreateHandCard()
        {
            if (!playerConObj) Debug.LogError("PlayerConnectionObject is not assign in Game Manager");
            if (currentPlayer.isHandFreeSapce())
            {
                playerConObj.CmdSpawnCard(currentPlayer.PlayerID);
            }
        }

        public void AddCardToDesk(GameObject cardObj)
        {
            if (!playerConObj) Debug.LogError("PlayerConnectionObject is not assign in Game Manager");
            if (currentPlayer.isDeskFreeSpace())
            {
                playerConObj.CmdCardDeployed(cardObj, currentPlayer.PlayerID);
            }
        }

        public void Disconnect() {
            NetworkManager.singleton.StopClient();
            NetworkManager.singleton.StopHost();
        }
    }
}
