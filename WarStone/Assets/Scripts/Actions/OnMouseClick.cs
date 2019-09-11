﻿using System.Collections;
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
            if (Input.GetMouseButton(0))
            {
                List<RaycastResult> results = Settings.GetObjectUnderMouse();

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
