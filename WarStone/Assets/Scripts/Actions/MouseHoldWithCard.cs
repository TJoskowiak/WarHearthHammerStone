using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SA.GameStates
{
    [CreateAssetMenu(menuName = "Action/MouseHoldWithCard")]
    public class MouseHoldWithCard : Action
    {
        public State playerControlState;
        public CardVariable currentCard;
        public SO.GameEvent onPlayerControlEvent;

        public override void Execute(float d)
        {
            bool mouseIsDown = Input.GetMouseButton(0);
            if (!mouseIsDown)
            {

                List<RaycastResult> results = Settings.GetObjectUnderMouse();            

                foreach (RaycastResult res in results)
                {
                    GameElements.Area area = res.gameObject.GetComponentInParent<GameElements.Area>();
                    if(area!= null)
                    {
                        area.onDrop();
                        break;
                    }
                }

                currentCard.instance.gameObject.SetActive(true);
                currentCard.instance = null;

                Settings.gameManager.SetState(playerControlState);
                onPlayerControlEvent.Raise();
                return;
            }
        }

    }
    
}
