using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Enemy : MovingObject
{
    public int playerDamage;

    private Animator animator;
    Transform target;
    bool skipMove;

    protected override void OnCantMove<T>(T component)
    {
        //敌人在尝试移动的时候泛型一定为玩家，根据本类的move函数逻辑，敌人是只会朝玩家的x，y轴移动的，玩家无法撞墙，敌人就不会尝试超过玩家的位置
        var player = component as Player;
        player.LoseFood(playerDamage);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
    }

    protected override void AttemptMove<T>(int x, int y)
    {
        //敌人的移动是每隔一回合移动一次，细节
        if (skipMove)
        {
            skipMove = false;
            return;
        }
        base.AttemptMove<T>(x, y);
        //敌人移动之后设置跳过一回合
        skipMove = true;
    }

    public void MoveEnemy()
    {
        int x = 0;
        int y = 0;

        //判断敌人是否在同一列上，由于当玩家和敌人在同一列上时x坐标相等，所以相当于判断x-x==0
        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
        {
            // 在同一列上就设置y的目标方向
            y = target.position.y > transform.position.y ? 1 : -1;

        }
        else
        {
            x = target.position.x > transform.position.x?1: -1;
        }

        AttemptMove<Player>(x, y);
    }
}