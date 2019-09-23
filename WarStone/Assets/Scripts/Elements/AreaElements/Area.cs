using UnityEngine;
using UnityEngine.Networking;

namespace SA.GameElements
{
    class Area : NetworkBehaviour
    {
        public AreaLogic areaLogic;


        public void Test(bool value) {
            var xyz = GameObject.Find("ServerObject").GetComponent<ServerScript>();
            if (xyz.isServer) {
                if (this.name == "My Card Down Area") {
                    gameObject.SetActive(value);
                }

            } else {
                if (this.name == "Opponent Card Down Area") {
                    gameObject.SetActive(value);
                }
            }
        }

        public void onDrop() {
            areaLogic.Exeute();

        }
    }
}
