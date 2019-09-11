using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SA.GameStates
{
    [CreateAssetMenu(menuName = "Action/MouseOverDetection")]
    public class MouseOverDetection : Action
    {
        public override void Execute(float d)
        {
            List<RaycastResult> results = Settings.GetObjectUnderMouse();
            IClicable obj = null;
            foreach (RaycastResult res in results)
            {
                obj = res.gameObject.GetComponentInParent<IClicable>();
                if (obj != null)
                {
                    obj.onHighlight();
                    break;
                }
            }
        }
    }
}
