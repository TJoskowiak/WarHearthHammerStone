using UnityEngine;

namespace SA.GameElements
{
    [CreateAssetMenu(menuName = "Areas/MyCardDownAreaWhenHoldingCard")]
    class MyCardDownAreaLogic : AreaLogic
    {
        public CardVariable card;
        public SO.TransformVariable areaGrid;
        //public CardType MinionCard;



        public override void Exeute()
        {
            GameObject.Find("LocalPlayer").GetComponent<PlayerConnectionScript>().CmdPlayer1CardDeployed(card.instance.gameObject);
        }
    }
}
