using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace SA
{
    
    public static class Settings
    {
        public static GameManager gameManager;
        private static ResourcesManager resourcesManager;

        public static List<RaycastResult> GetObjectUnderMouse()
        {
            PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };
            //Debug.Log("Goblin patrzy na: " + pointerEventData.position);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, results);

            return results;
        }
        

    }

    

}
