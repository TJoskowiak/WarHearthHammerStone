using UnityEngine;

namespace SA.GameElements
{
    [CreateAssetMenu(menuName = "Areas/OpponentCardDownAreaWhenHoldingCard")]
    class OpponentCardDownAreaLogic : AreaLogic
    {
        public CardVariable card;
        public SO.TransformVariable areaGrid;
        public Area area;


        public override void Exeute() {
            Debug.Log("Pl2 exeute");
            GameObject.Find("LocalPlayer").GetComponent<PlayerConnectionScript>().CmdPlayer2CardDeployed(card.instance.gameObject);
        }

        public override bool IsMyArea()
        {
            return !GameObject.Find("ServerObject").GetComponent<ServerScript>().isServer;
        }
    }
}
