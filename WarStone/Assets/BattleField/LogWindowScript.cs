using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogWindowScript : MonoBehaviour
{
    public GameObject Content;
    public GameObject TextPrefab;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Log(string text) {
        GameObject newObject = GameObject.Instantiate(TextPrefab);
        newObject.GetComponent<Text>().text = text;

        newObject.transform.SetParent(Content.transform);

    }
}
