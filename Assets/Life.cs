using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public float Health = 100f;
    public GameObject Guard;
    public static bool Power_Up_Used;
    float SaveHealth = 0f;
    public Text Score;
    float timer = 0f;
    void Start()
    {
        SaveHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        if(Power_Up_Used)
        {
            if (Guard.name.Contains("(Clone)"))
            {
                Health = 0f;
            }
            Power_Up_Used = false;
        }
        if (Guard.gameObject.name.Contains("(Clone)"))
        {          
            if (Health <= 0)
            {
                timer += Time.deltaTime;
                Color color = Guard.GetComponent<SpriteRenderer>().color;
                Guard.GetComponent<PolygonCollider2D>().enabled = false;
                //Guard.GetComponent<MoveToPlayer>().enabled = false;
                Guard.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, color.a - 0.05f);
                if (timer > 0.5f)
                {
                    ManageScores();
                    Destroy(Guard);
                }             
            }
        }
        else if (Health <= 0)
        {
            ManageScores();
            Guard.transform.position = new Vector2(-10000000, -1000000000);
            Health = SaveHealth;
        }
    }


    public void ManageScores()
    {
        if (Guard.name.Contains("Guard_Green"))
        {
            Score.text = int.Parse(Score.text) + 5 + "";
        }
        else if (Guard.name.Contains("Golden_Ghost"))
        {
            Score.text = int.Parse(Score.text) + 15 + "";
        }
        else if (Guard.name.Contains("Blue_Ghost"))
        {
            Score.text = int.Parse(Score.text) + 10 + "";
        }
        else
        {
            Score.text = int.Parse(Score.text) + 2 + "";
        }
    }
}
