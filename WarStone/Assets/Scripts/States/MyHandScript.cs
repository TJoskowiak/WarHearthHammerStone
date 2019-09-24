using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyHandScript : NetworkBehaviour
{
    public GameObject OpponentHand;


    // Start is called before the first frame update
    void Start()
    {
        if (isServer) {
            Debug.Log("MHS: I am a server");
            gameObject.SetActive(true);
            OpponentHand.SetActive(false);

        } else {
            Debug.Log("MHS: I am not a server");
            gameObject.SetActive(false);
            OpponentHand.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
