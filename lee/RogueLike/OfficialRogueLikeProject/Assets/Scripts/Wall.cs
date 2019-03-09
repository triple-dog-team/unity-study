using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Wall : MonoBehaviour
{
    public Sprite dmgSprite;
    public int hp = 4;

    private SpriteRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void DamangeWall(int loss)
    {
        renderer.sprite = dmgSprite;
        hp -= loss;
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}