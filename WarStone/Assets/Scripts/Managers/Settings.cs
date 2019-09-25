using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SA
{

    public static class Settings
    {
        public static GameManager gameManager;
        public static StateManager stateManager;
        private static ResourcesManager resourcesManager;

        public static List<RaycastResult> GetObjectUnderMouse() {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current) {
                position = Input.mousePosition
            };
            //Debug.Log("Goblin patrzy na: " + pointerEventData.position);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, results);

            return results;
        }

        public static void ChangeStateToPlayerControlState() {
            gameManager.SetState(stateManager.PlayerControlState);
        }
        public static void ChangeStateToOpponentControlState() {
            gameManager.SetState(stateManager.OpponentControlState);
        }

        public static void SwapState() {
            if (gameManager.currentState == stateManager.OpponentControlState) {
                ChangeStateToPlayerControlState();
            } else if (gameManager.currentState == stateManager.PlayerControlState) {
                ChangeStateToOpponentControlState();
            }
        }

        public static void SetParentToObject(GameObject child, SO.TransformVariable parent){
            child.transform.SetParent(parent.value.transform);
            child.transform.localPosition = Vector3.zero;
            child.transform.localScale = Vector3.one;
            child.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }



}
