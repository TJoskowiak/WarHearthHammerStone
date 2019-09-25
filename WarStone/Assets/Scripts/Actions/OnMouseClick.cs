using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace SA.GameStates
{
    [CreateAssetMenu(menuName = "Action/OnMouseClick")]
    public class OnMouseClick : Action
    {
        public override void Execute(float d) {
            if (Input.GetMouseButton(0)) {
                List<RaycastResult> results = Settings.GetObjectUnderMouse();

                foreach (RaycastResult res in results) {
                    IClicable obj = res.gameObject.GetComponentInParent<IClicable>();
                    if (obj != null) {
                        if (Input.GetMouseButtonDown(0))
                            obj.onClick();
                        else
                            obj.onDrag();
                        break;
                    }
                }
            } else if (Input.GetMouseButtonDown(1)) {
               
                //var Player = GameObject.Find("LocalPlayer");
                //var PlayerComp = Player.GetComponent<PlayerConnectionScript>();
                //PlayerComp.CmdRoundOver();

                //if(PlayerComp.isServer)
                //{
                //    var opponentDeskComp = GameObject.Find("Player1CardsDown");
                //    var children = opponentDeskComp.GetComponentsInChildren<CardViz>();
                //    foreach (var cardInstance in children)
                //    {
                //        cardInstance.GetComponent<CardViz>().cardMoved = false;
                //    }
                //}
                //else
                //{
                //    var opponentDeskComp = GameObject.Find("Player2CardsDown");
                //    var children = opponentDeskComp.GetComponentsInChildren<CardViz>();
                //    foreach (var cardInstance in children)
                //    {
                //        cardInstance.GetComponent<CardViz>().cardMoved = false;
                //    }
                //}
                
            }
        }
    }
}
