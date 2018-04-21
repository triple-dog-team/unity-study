using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private const float w = 6.71f;
    private const float l = 9.15f;
    Rigidbody2D rigidbody;
    public float v;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(Utility.GetVector2() * v);
    }
}
