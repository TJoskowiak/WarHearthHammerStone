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
            if (card.instance == null) return;

            //typ kartu
            //if(card.instance.cardViz.cardType == MinionCard)
            {
                card.instance.transform.SetParent(areaGrid.value.transform);
                card.instance.transform.localPosition = Vector3.zero;
                card.instance.transform.localScale = Vector3.one;

            }
            
            
            
        }
    }
}
