using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLayout_CardFlow : MonoBehaviour
{
   
    public string containerName = "The Container";

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = containerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddToGroup(GameObject card)
    {
        var grid = gameObject.GetComponent<GridLayoutGroup>();
        card.SetActive(true);
        card.transform.SetParent(grid.transform, false);
    }

}
