using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoverText : MonoBehaviour
{
    float timer = 0f;
    float s_timer = 0f;
    int i = 0;
    public float TimeForText;
    List<string> sentences = new List<string>()
    {
        "Welcome New Player!"
        ,"Lets cover the basics"
        ,"Move with the arrows or with the wasd keys"
        ,"press T to teleport to random place on map"
        ,"press F to fire against ghost"
        ,"REMEMBER TO Avoid from ghosts! Good Luck!"
        ,""
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("NewPlayerTutorial5") == false)
        {
            Time.timeScale = 0f;
            timer += Time.fixedDeltaTime;
            if (timer < sentences.Count * TimeForText)
            {
                s_timer += Time.fixedDeltaTime;
                if(s_timer> TimeForText)
                {
                    this.gameObject.GetComponent<Text>().text = sentences[i];
                    i++;
                    s_timer = 0f;
                }
            }
            else
            {
                this.gameObject.GetComponent<Text>().text = "";
                Time.timeScale = 1f;
                PlayerPrefs.SetInt("NewPlayerTutorial5", 1);
            }           
        }
    }
}
