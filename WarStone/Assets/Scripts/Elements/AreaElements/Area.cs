using UnityEngine;

namespace SA.GameElements
{
    class Area : MonoBehaviour
    {
        public AreaLogic areaLogic;
        public void onDrop()
        {
            areaLogic.Exeute();
            
        }
    }
}
