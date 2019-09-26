using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ServerScript : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    [ClientRpc]
    public void RpcSwitchRounds() {
        SA.Settings.gameManager.EndTurn();
    }

    [ClientRpc]
    public void RpcCardDeployed(GameObject card, int PlayerID)
    {
        if (card == null) return;
        SA.Player player = SA.Settings.gameManager.GetPlayer(PlayerID);
        player.SetPositionToDesk(card);

        if(SA.Settings.gameManager.currentPlayer.PlayerID != player.PlayerID)
        {
            SA.Settings.gameManager.opponentHolder.ReserveResource(card.GetComponent<SA.CardViz>().strengthStat);
        }

    }

    [ClientRpc]
    public void RpcMoveCountIncrement()
    {
        SA.Settings.gameManager.MoveCounter++;
    }

}
