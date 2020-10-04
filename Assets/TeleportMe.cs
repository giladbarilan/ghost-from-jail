using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class TeleportMe : MonoBehaviour
{
    public GameObject PowerUp;
    public GameObject Player;
    Vector2 PlayerStartingTransforming;
    public float TeleportTime = 0f;
    float timer = 0f;
    void Start()
    {
        PlayerStartingTransforming = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Player.GetComponent<PolygonCollider2D>().IsTouching(PowerUp.GetComponent<CircleCollider2D>()))
        {
            Life.Power_Up_Used = true;
            PowerUp.transform.position = new Vector2(1000000, 0);
        }
        if(timer>TeleportTime)
        {
            PowerUp.transform.position = new Vector2(PlayerStartingTransforming.x+Random.Range(-1,8),PlayerStartingTransforming.y+Random.Range(-1,3));
            timer = 0f;
        }
    }
}
