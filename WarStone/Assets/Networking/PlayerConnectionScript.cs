using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionScript : NetworkBehaviour
{

    public int firstCard = 0;
    public int secondCard = 0;

    private readonly string Player1_Container = "Player1_Container";
    private readonly string Player2_Container = "Player2_Container";
    private readonly string Player1_Graveyard = "Player1_CardsGraveyard";
    private readonly string Player2_Graveyard = "Player2_CardsGraveyard";
    private readonly string Player1_NotDeployed = "Player1_CardsNotDeployed";
    private readonly string Player2_NotDeployed = "Player2_CardsNotDeployed";
    private readonly string Player1_Hand = "Player1_Hand";
    private readonly string Player2_Hand = "Player2_Hand";


    // Start is called before the first frame update
    void Start() {
        if (isLocalPlayer)
            this.name = "LocalPlayer";
        else
            this.name = "RemotePlayer";
    }


    [Command]
    public void CmdSendMovement(int FirstCard, int SecondCard) {
        var firstViz = GameObject.Find(FirstCard.ToString()).GetComponent<SA.CardViz>();
        var secondViz = GameObject.Find(SecondCard.ToString()).GetComponent<SA.CardViz>();
        firstViz.healthStat -= secondViz.strengthStat;
        secondViz.healthStat -= firstViz.strengthStat;
        var Server = GameObject.Find("ServerObject");
        var ServerComp = Server.GetComponent<ServerScript>();

        ServerComp.RegisterMove(FirstCard, SecondCard);

    }

    [Command]
    public void CmdAddToContainer(bool isPlayer1Board, GameObject card)
    {
        string containerName;

        if (isPlayer1Board)
        {
            containerName = Player1_Container;       
        }
        else
        {
            containerName = Player2_Container;
        }


        var container = GameObject.Find(containerName);    
        container.GetComponent<GridLayout_CardFlow>().AddToGroup(card);

        var Server = GameObject.Find("ServerObject");
        var ServerComp = Server.GetComponent<ServerScript>();

        ServerComp.RpcSetCardActive(card.name);
        ServerComp.RpcLogicChange(card.name, containerName);
        ServerComp.RpcBindToContainer(card.name, containerName);
    }

    [Command]
    public void CmdEndTurn(bool IsPlayer1)
    {
        var Server = GameObject.Find("ServerObject");
        var ServerComp = Server.GetComponent<ServerScript>();
        ServerComp.RpcSwitchRounds();

        string containerToDetachFrom;
        string containerToAttachTo;
        if (IsPlayer1)
        {
            Debug.Log("Here");
            containerToDetachFrom = Player1_NotDeployed;
            containerToAttachTo = Player1_Hand;
        }
        else
        {
            Debug.Log("there");
            containerToDetachFrom = Player2_NotDeployed;
            containerToAttachTo = Player2_Hand;
        }

        var sendContainer = GameObject.Find(containerToDetachFrom);
        Debug.Log("Number of children: " + sendContainer.transform.childCount);
        var childCount = sendContainer.transform.childCount;
        if (childCount > 1)
        {
            var card = sendContainer.transform.GetChild(childCount-1).gameObject;
            var receiveContainer = GameObject.Find(containerToAttachTo);

            receiveContainer.GetComponent<GridLayout_CardFlow>().AddToGroup(card);
            ServerComp.RpcBindToContainer(card.name, containerToAttachTo);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (SA.Settings.gameManager.currentState == SA.Settings.stateManager.PlayerControlState)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                var currentCard = GameObject.Find("Current Selected Card").GetComponent<SA.CurrentSelected>();

                if (currentCard.GraphicObject.activeSelf && name.Equals("LocalPlayer"))
                {
                    currentCard.GraphicObject.SetActive(false);
                    currentCard.currentCard.instance.gameObject.SetActive(true);
                    CmdAddToContainer(isServer, currentCard.currentCard.instance.gameObject);
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && name.Equals("LocalPlayer"))
            {
                CmdEndTurn(isServer);
            }
        }
    }
}
