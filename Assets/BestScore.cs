using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Text>().text = PlayerPrefs.HasKey("Score") ? "BEST ESCAPE - " + PlayerPrefs.GetInt("Score") : "BEST ESCAPE - " + 0;
    }
}
