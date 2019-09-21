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
        Debug.Log("Server: Registered the move " + FirstCard.ToString() + " " + SecondCard.ToString() + " , new turn");
        RpcSwitchRounds();
    }

    [ClientRpc]
    public void RpcSwitchRounds() {
        SA.Settings.SwapState();
    }

    [ClientRpc]
    public void RpcSetCardActive(string cardName)
    {
        GameObject.Find(cardName).SetActive(true);
    }
    
    [ClientRpc]
    public void RpcBindToContainer(string cardName, string containerName)
    {
        var card = GameObject.Find(cardName);

        GameObject.Find(containerName).GetComponent<GridLayout_CardFlow>().AddToGroup(card);
    }

    [ClientRpc]
    public void RpcLogicChange(string cardName, string containerName)
    {

        //This part of code is painful. But... I couldn't bother really.
        Debug.Log(cardName);
        var cardc = GameObject.Find(cardName);
        var card = cardc.GetComponent<SA.CardInstance>();
        Debug.Log(card.cardViz.cardName.text);
        if (isServer)
        {
            
            if (containerName.Equals("Player1_Container"))
                card.currentLogic = ScriptableObject.CreateInstance<SA.GameElements.MyDeskCard>();
            else
                card.currentLogic = ScriptableObject.CreateInstance<SA.GameElements.OpponentDeskCard>();
        }
        else
        {
           
            if (containerName.Equals("Player2_Container"))
                card.currentLogic = ScriptableObject.CreateInstance<SA.GameElements.MyDeskCard>();
            else
                card.currentLogic = ScriptableObject.CreateInstance<SA.GameElements.OpponentDeskCard>();
        }

        
    }

}
