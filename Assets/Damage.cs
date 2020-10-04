using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float TakeDamage;
    public GameObject FireBall;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Guard" || collision.collider.gameObject.tag == "FireBall")
        {
            collision.collider.gameObject.GetComponent<Life>().Health -= TakeDamage;
            FireBall.SetActive(false);
        }
    }
}
