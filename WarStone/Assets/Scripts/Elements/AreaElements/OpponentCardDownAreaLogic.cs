using UnityEngine;

namespace SA.GameElements
{
    [CreateAssetMenu(menuName = "Areas/OpponentCardDownAreaWhenHoldingCard")]
    class OpponentCardDownAreaLogic : AreaLogic
    {
        public CardVariable card;
        public SO.TransformVariable areaGrid;

        public override void Exeute() {
            Settings.gameManager.AddCardToDesk(card.instance.gameObject);
        }

        public override bool IsMyArea()
        {
            return !GameObject.Find("ServerObject").GetComponent<ServerScript>().isServer;
        }
    }
}
