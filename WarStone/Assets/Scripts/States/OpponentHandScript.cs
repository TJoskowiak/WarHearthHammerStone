using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class OpponentHandScript : NetworkBehaviour
{
    public GameObject MyHand;
    public GameObject Player1CardsDown;
    public GameObject Player2CardsDown;


    // Start is called before the first frame update
    void Start()
    {
        if (isServer) {
            //Debug.Log("OHS: I am a server");
            gameObject.SetActive(false);
            MyHand.SetActive(true);
        } else {
            //Debug.Log("OHS: I am not a server");
            gameObject.SetActive(true);
            MyHand.SetActive(false);
            transform.localPosition = MyHand.transform.localPosition;
            Player1CardsDown.transform.localRotation = Quaternion.Euler(0, 0, 180);
            Player2CardsDown.transform.localRotation = Quaternion.Euler(0, 0, 180);

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
