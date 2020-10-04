using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D Player_Rigid;
    public float Speed;
    public GameObject Player;
    public RuntimeAnimatorController MoveSide;
    public Animator anim;
    Vector2 SavePlayerPosition;

    void Start()
    {
        SavePlayerPosition = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float Speed_Up = Input.GetAxisRaw("Vertical") * Speed;
        float Speed_Side = Input.GetAxisRaw("Horizontal") * Speed;
        if (ShootGun.StartAnimation == false)
        {
            if (Speed_Side < 0)
            {
                Player.GetComponent<SpriteRenderer>().flipX = true;
                AnimatePlayer();
            }
            else if (Speed_Side > 0)
            {
                Player.GetComponent<SpriteRenderer>().flipX = false;
                AnimatePlayer();
            }
            else
            {
                if (Speed_Up == 0)
                {                   
                    StopAnimation();
                }
                else
                {
                    AnimatePlayer();
                }
            }
            if(Speed_Up == 0 && Speed_Side == 0)
            {
                //Time.timeScale = 0.5f;
            }
            else
            {
                //Time.timeScale = 1f;
            }
        }
        if(Speed_Up > 0 && Player.transform.position.y > SavePlayerPosition.y + 4)
        {
            Speed_Up = 0;
        }
        if(Speed_Up < 0 && Player.transform.position.y < SavePlayerPosition.y - 2)
        {
            Speed_Up = 0;
        }
        if(Speed_Side < 0 && Player.transform.position.x < SavePlayerPosition.x - 2)
        {
            Speed_Side = 0;
        }
        if(Speed_Side > 0 && Player.transform.position.x > SavePlayerPosition.x + 12)
        {
            Speed_Side = 0;
        }
        Player_Rigid.velocity = new Vector2(Speed_Side, Speed_Up);
    }

    public void AnimatePlayer()
    {
        anim.runtimeAnimatorController = MoveSide;
    }

    public void StopAnimation()
    {
        anim.runtimeAnimatorController = null;
    }
}
