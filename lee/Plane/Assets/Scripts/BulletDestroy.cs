using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > Camera.current.transform.position.y+Camera.current.orthographicSize)
        {
            Destroy(gameObject);
        }

    }
}
