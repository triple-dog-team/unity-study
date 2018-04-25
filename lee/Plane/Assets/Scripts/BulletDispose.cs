using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDispose : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > Camera.main.transform.position.y + Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }

    }
}
