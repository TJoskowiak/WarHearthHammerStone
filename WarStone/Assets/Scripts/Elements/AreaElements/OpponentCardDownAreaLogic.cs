using UnityEngine;

namespace SA.GameElements
{
    [CreateAssetMenu(menuName = "Areas/OpponentCardDownAreaWhenHoldingCard")]
    class OpponentCardDownAreaLogic : AreaLogic
    {
        public CardVariable card;
        public SO.TransformVariable areaGrid;

        public override void Exeute() {
            Debug.Log("Pl2 exeute");
            GameObject.Find("LocalPlayer").GetComponent<PlayerConnectionScript>().CmdCardDeployed(card.instance.gameObject,Settings.gameManager.currentPlayer.PlayerID);
        }

        public override bool IsMyArea()
        {
            return !GameObject.Find("ServerObject").GetComponent<ServerScript>().isServer;
        }
    }
}
