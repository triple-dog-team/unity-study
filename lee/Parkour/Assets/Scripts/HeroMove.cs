using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public float MoveSpeed;

    private void FixedUpdate()
    {
        var rigidbody2DObj = GetComponent<Rigidbody2D>();
        //x轴为移动速度，这里是移动啊
        rigidbody2DObj.velocity = new Vector2(MoveSpeed, rigidbody2DObj.velocity.y);
    }
}
