using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Vector2 v = new Vector2(x, y);

        rigidbody.AddForce(push * v);
    }
}
