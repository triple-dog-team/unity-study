using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour
{
    // 主角坐标
    int x = 1;
    int y = 1;

    public float smooth = 1;

    Vector2 targetPos = new Vector2(1, 1);
    Rigidbody2D rbd;

    private void Awake()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        //控制一次只会像一个轴移动，z轴在2d项目中忽略
        if (h > 0)
        {
            v = 0;
        }

        targetPos += new Vector2(h, v);
        rbd.MovePosition(Vector2.Lerp(transform.position, targetPos, smooth * Time.deltaTime));
    }
}