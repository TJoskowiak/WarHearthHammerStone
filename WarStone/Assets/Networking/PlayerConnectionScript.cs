using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionScript : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.GetComponent<NetworkIdentity>().connectionToClient.address);
        Debug.Log(this.GetComponent<NetworkIdentity>().connectionToClient.connectionId);
        Debug.Log(this.GetComponent<NetworkIdentity>().connectionToClient.hostId);
        //if (isLocalPlayer) {
        //    Debug.Log(this.GetComponent<NetworkIdentity>().netId.ToString() + "I am yours");
        //}
    }
}
