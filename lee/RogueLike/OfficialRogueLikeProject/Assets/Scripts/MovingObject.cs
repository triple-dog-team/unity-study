using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
    public float moveSpeed = 10f;
    public LayerMask blockingLayer;

    BoxCollider2D boxCollider;
    Rigidbody2D rbd;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rbd = GetComponent<Rigidbody2D>();
    }

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        float sqrDistance = (transform.position - end).sqrMagnitude;

        //Epsilon是接近0的无限小值，也就意味着当距离为0时才停止移动
        //这里的逻辑就是通过调用平滑移动的函数，来把当前对象移动到end位置，并且使用moveSpeed的速度平滑移动过去。
        while (sqrDistance > float.Epsilon)
        {
            rbd.transform.localPosition = Vector3.MoveTowards(rbd.position, end, moveSpeed * Time.deltaTime);
            sqrDistance = (transform.position - end).sqrMagnitude;
            //TODO
            //在最后一帧重新判断循环条件，这里没看懂
            yield return null;
        }
    }

    /// <summary>
    /// 无法移动时的后续逻辑
    /// </summary>
    /// <param name="component">碰撞到的物体</param>
    /// <typeparam name="T"></typeparam>
    protected abstract void OnCantMove<T>(T component) where T : Component;

    protected bool Move(int x, int y, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        var end = start + new Vector2(x, y);
        //禁用碰撞器，防止射线碰撞自己，射线可能是由自身中心射出的，所以会让外围的碰撞器触发
        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;

        //检测如果hit命中的话，则认为目的地可以移动，否则不行
        if (hit.transform == null)
        {
            StartCoroutine(SmoothMovement(end));
            return true;
        }

        return false;
    }

    protected virtual void AttemptMove<T>(int x, int y) where T : Component
    {
        //尝试move会调用move并获取到结果，如果不可以move，则可能是在做攻击，或者是撞墙
        RaycastHit2D hit;
        var canMove = Move(x, y, out hit);

        //如果没碰到东西，则move本身就做了移动，没事做
        if (hit.transform == null)
        {
            return;
        }

        //碰到了就攻击
        T hitComponent = hit.transform.GetComponent<T>();

        if (!canMove && hitComponent != null)
        {
            //这里体现设计，当我们的移动对象无法移动的时候，传入导致我们无法移动的对象（也就是被碰撞的物体），由子类去判断无法移动时要做什么事情
            OnCantMove(hitComponent);
        }
    }
}