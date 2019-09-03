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
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };
            //Debug.Log("Goblin patrzy na: " + pointerEventData.position);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, results);

            IClicable obj = null;
            foreach (RaycastResult res in results)
            {
                obj = res.gameObject.GetComponentInParent<IClicable>();
                if ( obj  != null)
                {
                    obj.onHighlight();
                    break;
                }
            }

            if (obj != null)
            {

                if (Input.GetMouseButton(0))
                {

                    obj.onClick();
                }
            }

        }
    }
}
