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


            var firstCard = GameObject.Find(FirstCard.ToString()) as GameObject;
            var secondCard = GameObject.Find(SecondCard.ToString()) as GameObject;
            RpcSetDMG(firstCard, secondCard);
            RpcSetDMG(secondCard, firstCard);
        }

        var Server = GameObject.Find("ServerObject");
        var ServerComp = Server.GetComponent<ServerScript>();
        ServerComp.RegisterMove(FirstCard, SecondCard);

    }


    [ClientRpc]
    public void RpcSetDMG(GameObject attacker, GameObject victim)
    {
        var attackerCard = attacker.GetComponent<SA.CardInstance>();
        var victimCard = victim.GetComponent<SA.CardInstance>();

        victimCard.takeDMG(attackerCard);

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
    public void CmdSpawnCard(int PlayerID)
    {
        GameObject cardObj = Instantiate(SA.Settings.gameManager.CardPrefab) as GameObject;
        NetworkServer.Spawn(cardObj);
        SA.Settings.gameManager.GetPlayer(PlayerID).AssignParametersToCard(cardObj);
        SA.CardViz viz = cardObj.gameObject.GetComponentInParent<SA.CardViz>();
        RpcSetToHand(cardObj, viz.card_object_id , viz.card_json_id ,PlayerID);
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
    void Update() {

    }
}
