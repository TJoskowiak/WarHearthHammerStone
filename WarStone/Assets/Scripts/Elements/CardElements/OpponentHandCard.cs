using UnityEngine;


namespace SA.GameElements
{
    [CreateAssetMenu(menuName = "Game Element/Opponent Hand Card")]
    public class OpponentHandCard : CardElementLogic
    {
        public SO.GameEvent onCurretCardSelected;
        public CardVariable currentCard;
        public GameStates.State holdingCard;

        public override void onClick(CardInstance instance) {

        }

        public override void onDrag(CardInstance instance) {
            if (!GameObject.Find("LocalPlayer").GetComponent<PlayerConnectionScript>().isServer) {
                currentCard.SetInstance(instance);
                Settings.gameManager.SetState(holdingCard);
                onCurretCardSelected.Raise();
            }
        }

        public override void onHighlight(CardInstance instance) {
        }
    }
}
