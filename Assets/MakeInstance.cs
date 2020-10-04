using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInstance : MonoBehaviour
{
    public GameObject Guard;
    public GameObject Player;
    float time = 0f;
    public float ExecuteTime;
    public float HisHealth;
    public int TimeRangeMin;
    public int TimeRangeMax;
    void Start()
    {
        Guard.GetComponent<Life>().Health = HisHealth;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > ExecuteTime)
        {
            if (Random.Range(0, 2) == 1)
            {
                Instantiate(Guard, new Vector3(Player.transform.position.x - 10, Player.transform.position.y - 5, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(Guard, new Vector3(Player.transform.position.x + 10, Player.transform.position.y + 5, 0), Quaternion.identity);
            }
            time = 0;
            ExecuteTime = Random.Range(TimeRangeMin, TimeRangeMax);
        }
    }
}
