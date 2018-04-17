using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [Header("横向")]
    public float x;
    [Header("纵向")]
    public float y;
    [Header("推力")]
    public float push;
    [Header("碰撞器")]
    Rigidbody2D rigidbody;

    int score;

    public Text count;
    public Text win;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        win.text = string.Empty;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Vector2 v = new Vector2(x, y);

        rigidbody.AddForce(push * v);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter:" + collision.gameObject.name);
        if (collision.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            score++;
            setSocreText();
            judgeWin();
        }
    }

    private void judgeWin()
    {
        if(!GameObject.FindGameObjectsWithTag("PickUp").ToList().Any(p=>p.active))
        {
            win.text = "恭喜获胜";
        }
    }

    void setSocreText()
    {
        count.text = "分数：" + score;
    }
}
