using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SA.GameStates
{
    [CreateAssetMenu(menuName = "Action/OnMouseClick")]
    public class OnMouseClick : Action
    {
        public override void Execute(float d)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
                {
                    position = Input.mousePosition
                };
                //Debug.Log("Goblin patrzy na: " + pointerEventData.position);
                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerEventData, results);

                foreach (RaycastResult res in results)
                {
                    IClicable obj = res.gameObject.GetComponentInParent<IClicable>();
                    if (obj != null)
                    {
                        obj.onClick();
                        break;
                    }
                }
            }
        }
    }
}
