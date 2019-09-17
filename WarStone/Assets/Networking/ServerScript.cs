using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerScript : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void RegisterMove(int FirstCard, int SecondCard) {
        if (!isServer) {
            return;
        }

        //server should calculate the damage and update syncvars here


        Debug.Log("Server: Registered the move " + FirstCard.ToString() + " " + SecondCard.ToString() + " , new turn");
        RpcSwitchRounds();
    }

    [ClientRpc]
    public void RpcSwitchRounds() {
        SA.Settings.SwapState();
    }

}
