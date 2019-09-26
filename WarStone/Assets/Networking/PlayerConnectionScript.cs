using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionScript : NetworkBehaviour
{

    public int firstCard = 0;
    public int secondCard = 0;

    // Start is called before the first frame update
    void Start() {
        if (isLocalPlayer)
        {
            this.name = "LocalPlayer";
            SA.Settings.gameManager.SetPlayerConnectionScript(this);
        }
        else
        {
            this.name = "RemotePlayer";
            SA.Settings.gameManager.StartGame();
        }


    }


    [Command]
    public void CmdSendMovement(int FirstCard, int SecondCard)
    {
        var Server = GameObject.Find("ServerObject");
        var ServerComp = Server.GetComponent<ServerScript>();

        if (FirstCard != 0 && SecondCard != 0)
        {


            var firstCardObj = GameObject.Find(FirstCard.ToString()) as GameObject;
            var secondCardObj = GameObject.Find(SecondCard.ToString()) as GameObject;
            RpcSetDMG(firstCardObj, secondCardObj);
            RpcSetDMG(secondCardObj, firstCardObj);

            ServerComp.RpcMoveCountIncrement();
            RpcMoveInfo(firstCard, secondCard);
        }

        

    }
    [Command]
    public void CmdRoundOver()
    {
        var Server = GameObject.Find("ServerObject");
        var ServerComp = Server.GetComponent<ServerScript>();
        ServerComp.RpcSwitchRounds();
    }

    [ClientRpc]
    public void RpcSetDMG(GameObject attacker, GameObject victim)
    {
        var attackerCard = attacker.GetComponent<SA.CardInstance>();
        var victimCard = victim.GetComponent<SA.CardInstance>();

        victimCard.takeDMG(attackerCard);

    }

    [ClientRpc]
    public void RpcMoveInfo(int FirstCard, int SecondCard)
    {
        var Player1CardComp = GameObject.Find(FirstCard.ToString()).GetComponent<SA.CardViz>();
        var Player2CardComp = GameObject.Find(SecondCard.ToString()).GetComponent<SA.CardViz>();

        string LogMesagge = "";
        if (SA.Settings.gameManager.currentState == SA.Settings.stateManager.PlayerControlState)
        {
            if(SA.Settings.gameManager.currentPlayer.PlayerID == 1)
            {
                LogMesagge = Player1CardComp.cardName.text + "has attacked " + Player2CardComp.cardName.text + "./n";
            }
            else
            {
                LogMesagge = Player2CardComp.cardName.text + "has attacked " + Player1CardComp.cardName.text + "./n";
            }
        }
        else
        {
            if (SA.Settings.gameManager.currentPlayer.PlayerID == 1)
            {
                LogMesagge = Player2CardComp.cardName.text + "has attacked " + Player1CardComp.cardName.text + "./n";
            }
            else
            {
                LogMesagge = Player1CardComp.cardName.text + "has attacked " + Player2CardComp.cardName.text + "./n";
            }
        }
        //TO IMPLEMENT ADDING TO OBJECT HERE


    }

    [Command]
    public void CmdEndGame(int LoserPlayerID)
    {
        RpcEndGame(LoserPlayerID);
    }

    [ClientRpc]
    public void RpcEndGame(int LoserPlayerID)
    {
        SA.Settings.gameManager.setEndScreen(LoserPlayerID);
    }

    [Command]
    public void CmdCardDeployed(GameObject card, int PlayerID)
    {
        var Server = GameObject.Find("ServerObject");
        var ServerComp = Server.GetComponent<ServerScript>();
        ServerComp.RpcCardDeployed(card, PlayerID);
        ServerComp.RpcMoveCountIncrement();
    }

    [Command]
    public void CmdSpawnCard(int PlayerID)
    {
        GameObject cardObj = Instantiate(SA.Settings.gameManager.CardPrefab) as GameObject;
        NetworkServer.Spawn(cardObj);
        SA.Settings.gameManager.GetPlayer(PlayerID).AssignParametersToCard(cardObj);
        SA.CardViz viz = cardObj.gameObject.GetComponentInParent<SA.CardViz>();
        RpcSetToHand(cardObj, viz.card_object_id , viz.card_json_id ,PlayerID);
        RpcPickCard(PlayerID);
        RpcCheckCardLeft(PlayerID);
    }

    [ClientRpc]
    public void RpcPickCard(int PlayerID)
    {
        SA.Settings.gameManager.GetPlayer(PlayerID).removeCardFromDeckCounter();
    }


    [ClientRpc]
    public void RpcCheckCardLeft(int PlayerID)
    {
        if (!SA.Settings.gameManager.GetPlayer(PlayerID).CheckIfAnyCardLeft())
            SA.Settings.gameManager.GetPlayer(PlayerID).hideDeck();
    }

    [ClientRpc]
    public void RpcSetToHand(GameObject card, int CardID, int CardJsonID, int PlayerID)
    {
        if (card == null) return;
        SA.CardViz viz = card.gameObject.GetComponentInParent<SA.CardViz>();
        viz.card_json_id = CardJsonID;
        viz.card_object_id = CardID;
        SA.Settings.gameManager.GetPlayer(PlayerID).SetPositonToHand(card);
    }





    // Update is called once per frame
    void Update()
    {
        if(firstCard != 0 && secondCard != 0)
        {
            CmdSendMovement(firstCard, secondCard);

            try
            {
                var firstViz = GameObject.Find(firstCard.ToString()).GetComponent<SA.CardViz>();
                var secondViz = GameObject.Find(secondCard.ToString()).GetComponent<SA.CardViz>();

                firstViz._highlight = false;
                secondViz._highlight = false;

                if(isServer)
                {
                    firstViz.cardMoved = true;
                }
                else
                {
                    secondViz.cardMoved = true;
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
            firstCard = 0;
            secondCard = 0;
        }
    }
}
