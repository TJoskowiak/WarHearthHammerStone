using UnityEngine;


namespace SA.GameElements
{
    [CreateAssetMenu(menuName ="Game Element/My Hand Card")]
    public class MyHandCard : CardElementLogic
    {
        public SO.GameEvent onCurretCardSelected;
        public CardVariable currentCard;
        public GameStates.State holdingCard;

        public override void onClick(CardInstance instance)
        {
            currentCard.SetInstance(instance);
            Settings.gameManager.SetState(holdingCard);
            onCurretCardSelected.Raise();
        }

        public override void onHighlight(CardInstance instance)
        {
           // instance.PopupHandCard();
        }
    }
}
