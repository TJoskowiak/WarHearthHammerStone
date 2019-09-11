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
        public SO.GameEvent onPlayerControlEvent;

        public override void Execute(float d)
        {
            bool mouseIsDown = Input.GetMouseButton(0);
            if (!mouseIsDown)
            {
                List<RaycastResult> results = Settings.GetObjectUnderMouse();

                foreach (RaycastResult res in results)
                {

                }

                Settings.gameManager.SetState(playerControlState);
                return;
            }
        }

    }
    
}
