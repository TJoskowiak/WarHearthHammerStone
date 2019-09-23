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
        var firstViz = GameObject.Find(FirstCard.ToString()).GetComponent<SA.CardViz>();
        var secondViz = GameObject.Find(SecondCard.ToString()).GetComponent<SA.CardViz>();
        firstViz.healthStat -= secondViz.strengthStat;
        secondViz.healthStat -= firstViz.strengthStat;
        var Server = GameObject.Find("ServerObject");
        var ServerComp = Server.GetComponent<ServerScript>();

        ServerComp.RegisterMove(FirstCard, SecondCard);

    }


    // Update is called once per frame
    void Update() {

    }
}
