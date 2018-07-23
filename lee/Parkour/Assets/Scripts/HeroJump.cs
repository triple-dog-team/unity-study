using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroJump : MonoBehaviour
{
    public static bool grounded = false;
    private bool jump;
    public float JumpForce = 10f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
        print("落地");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && grounded)
        {
            var hero = GetComponent<Rigidbody2D>();
            hero.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            grounded = false;
            animator.SetTrigger("jump");
            print("jump triggered");
        }
    }
}
