using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {
        GameObject.Find("hero").transform.Translate(0.5f, 0, 0);
    }
}
