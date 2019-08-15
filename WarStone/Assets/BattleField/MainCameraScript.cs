using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MainCameraScript : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!isServer) {
            transform.Rotate(new Vector3(0, 0, 180));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
