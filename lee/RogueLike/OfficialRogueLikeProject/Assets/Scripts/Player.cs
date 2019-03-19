using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

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
        food = GameManager.instance.playerFoodPoints;
        base.Start();
    }

    void OnDisable()
    {
        //当主角被禁用时把food交给游戏管理器，没明白
        //已明白，这里的一套逻辑是在处理玩家和游戏控制器的food的交互，每一次场景切换都会把数据丢给管理器结束后再存放过去
        GameManager.instance.playerFoodPoints = food;
    }

    // Update is called once per frame
    void Update()
    {
        //如果不是玩家回合就不做事情
        if (!GameManager.instance.playersTurn)
        {
            return;
        }

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

        GameManager.instance.playersTurn = true;
    }

    void CheckIfGameOver()
    {
        if (food <= 0)
        {
            //调用管理器的游戏结束
            GameManager.instance.GameOver();
        }
    }

    protected override void AttemptMove<T>(int x, int y)
    {
        food--;
        base.AttemptMove<T>(x, y);
        RaycastHit2D hit;
        CheckIfGameOver();
        //移动后结束玩家回合
        GameManager.instance.playersTurn = false;
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
        animator.SetTrigger("Wounded");
        food -= count;
        CheckIfGameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //处理exit、food、soda
        if (other.tag == "Exit")
        {
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }
        else if (other.tag == "Food")
        {
            food += pointsPerFood;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Soda")
        {
            food += pointsPerSoda;
            other.gameObject.SetActive(false);
        }
    }
}