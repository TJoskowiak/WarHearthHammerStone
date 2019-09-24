using UnityEngine;
using UnityEngine.Networking;

namespace SA.GameElements
{
    class Area : NetworkBehaviour
    {
        public AreaLogic areaLogic;


        public void Test(bool value) {
            if (areaLogic.IsMyArea())
            {
                gameObject.SetActive(value);
            }
        }

        public void onDrop() {
            areaLogic.Exeute();

        }
    }
}
