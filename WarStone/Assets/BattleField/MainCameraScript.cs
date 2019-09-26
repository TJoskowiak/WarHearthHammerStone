using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MainCameraScript : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start() {
        this.GetComponent<Animator>().Play("test");
        if (!isServer) {
            transform.Rotate(new Vector3(0, 0, 180));
        }

        var netHandler = GameObject.Find("NetworkHandler");
        netHandler.GetComponent<NetworkManagerHUD>().offsetX = 0;
        netHandler.GetComponent<NetworkManagerHUD>().offsetY = 0;
        netHandler.GetComponent<NetworkManagerHUD>().showGUI = false;

        //netHandler.GetComponent<NetworkManager>().StopHost();
        //NetworkManager.singleton.StopClient();
        //NetworkManager.singleton.StopHost();

    }

    // Update is called once per frame
    void Update() {

    }
}
