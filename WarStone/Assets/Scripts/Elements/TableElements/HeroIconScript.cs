using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroIconScript : MonoBehaviour
{
    public GameObject hitpointsText;
    public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePercentage(int value) {
        hitpointsText.GetComponent<TextMeshProUGUI>().text = value.ToString();
        healthBar.transform.localScale = new Vector3(value, healthBar.transform.localScale.y);

    }
}
