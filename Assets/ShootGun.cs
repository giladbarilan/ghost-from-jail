using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    public Animator anim;
    public static bool StartAnimation = false;
    bool SetMagic;
    public GameObject Player;
    public RuntimeAnimatorController Animation;
    public GameObject Magic;
    float time_for_animation = 0f;
    float another_timer = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f"))
        {
            MakeMagic();
        }
        if (StartAnimation)
        {          
            anim.runtimeAnimatorController = Animation;
            time_for_animation += Time.fixedDeltaTime;
            if (time_for_animation > 0.6f)
            {                      
                //if (SetMagic)
                {
                    Magic.SetActive(true);
                    if (Player.GetComponent<SpriteRenderer>().flipX == false)
                    {
                        Magic.transform.position = new Vector2(Player.transform.position.x + 1, Player.transform.position.y);
                    }
                    else
                    {
                        Magic.transform.position = new Vector2(Player.transform.position.x - 1, Player.transform.position.y);                     
                    }                  
                    Magic.GetComponent<Rigidbody2D>().velocity = new Vector2(GupShoot().x, 0);                  
                    StartAnimation = false;
                    //SetMagic = false;
                }                
            }         
        }
        else
        {
            time_for_animation = 0f;
        }
    }


    public void AnimationInvoking()
    {
        StartAnimation = true;
    }

    public void MakeMagic()
    {
        StartAnimation = true;
       // SetMagic = true;
    }

    public Vector2 GupShoot()
    {
        if (Player.GetComponent<SpriteRenderer>().flipX)
        {
            Magic.GetComponent<SpriteRenderer>().flipX = true;
            return new Vector2(-20, 0);
        }
        else
        {
            Magic.GetComponent<SpriteRenderer>().flipX = false;
            return new Vector2(20, 0);
        }
    }

}
