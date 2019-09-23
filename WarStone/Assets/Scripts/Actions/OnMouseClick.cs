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
                var Player = GameObject.Find("LocalPlayer");
                var PlayerComp = Player.GetComponent<PlayerConnectionScript>();
                PlayerComp.CmdSendMovement(PlayerComp.firstCard, PlayerComp.secondCard);

                try {
                    var firstViz = GameObject.Find(PlayerComp.firstCard.ToString()).GetComponent<SA.CardViz>();
                    var secondViz = GameObject.Find(PlayerComp.secondCard.ToString()).GetComponent<SA.CardViz>();

                    firstViz._highlight = false;
                    secondViz._highlight = false;
                } catch (Exception e) {
                    Debug.Log(e);
                }
                PlayerComp.firstCard = 0;
                PlayerComp.secondCard = 0;

            }
        }
    }
}
