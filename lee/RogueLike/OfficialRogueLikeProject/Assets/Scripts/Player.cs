using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MovingObject
{
    // 主角坐标
    int x = 1;
    int y = 1;

    public float smooth = 1;

    public int wallDamage = 1;
    public int pointsPerFood = 10;
    public int pointsPerSoda = 20;
    public float restartLevelDelay = 1f;

    Animator animator;
    int food;

    Vector2 targetPos = new Vector2(1, 1);

    private void Awake()
    { }

    // Start is called before the first frame update
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }

    void OnDisable()
    {
        //当主角被禁用时把food交给游戏管理器，没明白

    }

    // Update is called once per frame
    void Update()
    {
        //如果不是玩家回合就不做事情

        int h = 0;
        int v = 0;

        h = (int) Input.GetAxisRaw("Horizontal");
        v = (int) Input.GetAxisRaw("Vertical");
        if (h != 0)
        {
            v = 0;
        }

        if (h != 0 || v != 0)
        {
            //没有定义墙类
            AttemptMove<Wall>(h, v);
        }
    }

    void CheckIfGameOver()
    {
        if (food <= 0)
        {
            //调用管理器的游戏结束
        }
    }

    protected override void AttemptMove<T>(int x, int y)
    {
        food--;
        base.AttemptMove<T>(x, y);
        RaycastHit2D hit;
        CheckIfGameOver();
        //移动后结束玩家回合
    }

    protected override void OnCantMove<T>(T component)
    {
        Debug.Log("撞墙");
        Wall hitWall = component as Wall;
        hitWall.DamangeWall(wallDamage);
        animator.SetTrigger("Attack");
    }

    void Restart()
    {
        //场景加载，这个项目因为只有一个main场景所以利用它反复加载关卡，只需要变量++即可
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseFood(int count)
    {
        animator.SetTrigger("受伤触发器");
        food -= count;
        CheckIfGameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //处理exit、food、soda
    }
}