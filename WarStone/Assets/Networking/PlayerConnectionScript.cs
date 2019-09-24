using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionScript : NetworkBehaviour
{

    public int firstCard = 0;
    public int secondCard = 0;

    // Start is called before the first frame update
    void Start() {
        if (isLocalPlayer)
            this.name = "LocalPlayer";
        else
            this.name = "RemotePlayer";
    }


    [Command]
    public void CmdSendMovement(int FirstCard, int SecondCard) {
        if (FirstCard != 0 && SecondCard != 0) {
            var firstViz = GameObject.Find(FirstCard.ToString()).GetComponent<SA.CardViz>();
            var secondViz = GameObject.Find(SecondCard.ToString()).GetComponent<SA.CardViz>();
            firstViz.healthStat -= secondViz.strengthStat;
            secondViz.healthStat -= firstViz.strengthStat;
        }

        var Server = GameObject.Find("ServerObject");
        var ServerComp = Server.GetComponent<ServerScript>();
        ServerComp.RegisterMove(FirstCard, SecondCard);

    }

    [Command]
    public void CmdPlayer1CardDeployed(GameObject card) {
        var Server = GameObject.Find("ServerObject");
        var ServerComp = Server.GetComponent<ServerScript>();
        ServerComp.RpcPlayer1CardDeployed(card);
    }

    [Command]
    public void CmdPlayer2CardDeployed(GameObject card) {
        var Server = GameObject.Find("ServerObject");
        var ServerComp = Server.GetComponent<ServerScript>();
        ServerComp.RpcPlayer2CardDeployed(card);
    }

    [Command]
    public void CmdSpawnCard(GameObject card)
    {
        NetworkServer.Spawn(card);
    }

    // Update is called once per frame
    void Update() {

    }
}
