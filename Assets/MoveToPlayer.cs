using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToPlayer : MonoBehaviour
{
    public Rigidbody2D Guard;
    public GameObject Player;
    public GameObject MoveToNewScene;
    public GameObject Unenable_This_Scene;
    public GameObject ObjectToChange;
    public Text Score;
    static bool Died = false;
    public float Speed = 1f;
    void Awake()
    {
        Died = false;
    }

    // Update is called once per frame
    void Update()
    {
        Guard.velocity = FindGup();
        if(Guard.GetComponent<PolygonCollider2D>().IsTouching(Player.GetComponent<PolygonCollider2D>()))
        {
            PlayerPrefs.SetInt("Score", Math.Max(int.Parse(Score.text), PlayerPrefs.GetInt("Score")));
            //SceneManager.LoadScene(0);
            MoveToNewScene.SetActive(true);
            ObjectToChange.GetComponent<SpriteRenderer>().sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
            ObjectToChange.GetComponent<Animator>().runtimeAnimatorController = this.gameObject.GetComponent<Animator>().runtimeAnimatorController;
            Died = true;
            Unenable_This_Scene.SetActive(false);
        }
        if(Died)
        {
            Destroy(Guard.gameObject);
        }
    }

    public Vector2 FindGup()
    {
        Vector2 player_pos = Player.transform.position;
        Vector2 Currect_Player_Position = Guard.transform.position;
        Vector2 move = new Vector2();
        move = new Vector2(player_pos.x > Currect_Player_Position.x ? Speed : -Speed, player_pos.y > Currect_Player_Position.y ? Speed : -Speed);
        if (move.x < 0)
        {
            Guard.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            Guard.GetComponent<SpriteRenderer>().flipX = true;
        }
        return move;
    }

}
