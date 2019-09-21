using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionScript : NetworkBehaviour
{

    public int firstCard = 0;
    public int secondCard = 0;

    private string Player1_Container = "Player1_Container";
    private string Player2_Container = "Player2_Container";


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

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.B))
        {
            var currentCard = GameObject.Find("Current Selected Card").GetComponent<SA.CurrentSelected>();

            if (currentCard.GraphicObject.activeSelf && name.Equals("LocalPlayer") && isServer)
            {
                Debug.Log("Serverside: " + name);
                currentCard.GraphicObject.SetActive(false);
                currentCard.currentCard.instance.gameObject.SetActive(true);
                CmdAddToContainer(true, currentCard.currentCard.instance.gameObject);
            }
            if(currentCard.GraphicObject.activeSelf && name.Equals("LocalPlayer") && !isServer)
            {
                Debug.Log("ClientSide: " + name);
                currentCard.GraphicObject.SetActive(false);
                currentCard.currentCard.instance.gameObject.SetActive(true);
                CmdAddToContainer(false, currentCard.currentCard.instance.gameObject);
            }
        }
            
    }
}
