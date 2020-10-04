using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobbersTransformation : MonoBehaviour
{
    Vector2 store_starting_point;
    float timer = 0f;
    bool start_finish_transformation = false;
    bool Begin = false;
    void Start()
    {
        
    }

    void Awake()
    {
        store_starting_point = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = this.gameObject;
        if(Input.GetKeyDown("t"))
        {
            Begin = true;
        }
        if (Begin)
        {
            timer += Time.deltaTime;
            Color player_obj = player.GetComponent<SpriteRenderer>().color;
            player.GetComponent<SpriteRenderer>().color = new Color(player_obj.r, player_obj.g, player_obj.b, player_obj.a - 0.05f);
            if (timer > 0.5f)
            {
                player.transform.position = new Vector2(Random.Range(-2, 12) + store_starting_point.x, Random.Range(-1, 5) + store_starting_point.y);
                player.GetComponent<SpriteRenderer>().color = new Color(player_obj.r, player_obj.g, player_obj.b, player_obj.maxColorComponent);
                Begin = false;
                timer = 0f;
            }       
        }
    }
}
