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
        public Player opponentPlayer;
        public SO.GameEvent onGameStart;
        public Player[] Players;
        public StateManager stateManager;

        public ResourceHolder myHolder;
        public ResourceHolder opponentHolder;

        private PlayerConnectionScript playerConObj;

        public HeroIconScript MyIconScript;
        public HeroIconScript OpponentIconScript;

        public GameObject Player1Deck;
        public GameObject Player2Deck;

        public int MoveCounter = 0;


        public void SetPlayerConnectionScript(PlayerConnectionScript script)
        {
            playerConObj = script;
        }


        private void Start()
        {
            Player Player1 = Resources.Load<Player>(@"Data/Variables/Player1");
            Player1.StartingCardID = 1; 
            Player1.setDeck(Player1Deck);

            Player Player2 = Resources.Load<Player>(@"Data/Variables/Player2");
            Player2.StartingCardID = 101;
            Player2.setDeck(Player2Deck);



            Settings.gameManager = this;
            if (!isServer)
            {
                //Set appropiate Player 1
                Player1.setResourceHolder(opponentHolder);
                Player1.setIconScript(OpponentIconScript);
                //Set appropiate Player 2
                Player2.setResourceHolder(myHolder);
                Player2.setIconScript(MyIconScript);

                SetState(Resources.Load<State>(@"Data/Game States/WaitingForPlayer2"));
                //Settings.ChangeStateToOpponentControlState();
                currentPlayer = Resources.Load<Player>(@"Data/Variables/Player2");
                opponentPlayer = Resources.Load<Player>(@"Data/Variables/Player1");
            }

            else
            {
                //Set appropiate Player 1
                Player1.setResourceHolder(myHolder);
                Player1.setIconScript(MyIconScript);
                //Set appropiate Player 2
                Player2.setResourceHolder(opponentHolder);
                Player2.setIconScript(OpponentIconScript);

                SetState(Resources.Load<State>(@"Data/Game States/WaitingForPlayer2"));

                currentPlayer = Resources.Load<Player>(@"Data/Variables/Player1");
                opponentPlayer = Resources.Load<Player>(@"Data/Variables/Player2");
            }


        }

        public void EndTurn()
        {
            if (currentState == stateManager.OpponentControlState)
            {
                if (MoveCounter == 0) opponentPlayer.hitPoints--;

                SetState(stateManager.PlayerControlState);
                opponentHolder.RestartResource();
            }
            else if (currentState == stateManager.PlayerControlState)
            {
                if (MoveCounter == 0) currentPlayer.hitPoints--;
     
                SetState(stateManager.OpponentControlState);
                myHolder.RestartResource();
            }
            MoveCounter = 0;
            
        }

        private void Update()
        {
            currentState.Tick(Time.deltaTime);
            GetPlayer(1).updateHPBar();
            GetPlayer(2).updateHPBar();
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
            GetPlayer(1).ShuffleCards();
            GetPlayer(1).RestartResource();
            GetPlayer(1).setStartedHitPoints();
            GetPlayer(2).ShuffleCards();
            GetPlayer(2).RestartResource();
            GetPlayer(2).setStartedHitPoints();
            onGameStart.Raise();
        }

        public Player GetPlayer(int ID)
        {
            return Players[ID - 1];
        }

        public int GetCurrentPlayerID()
        {
            return currentPlayer.PlayerID;
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
            if (currentPlayer.isDeskFreeSpace() && currentPlayer.ReserveResource(cardObj))
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
