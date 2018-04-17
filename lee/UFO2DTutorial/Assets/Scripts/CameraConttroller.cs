using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConttroller : MonoBehaviour
{

    public GameObject player;

    private Vector3 vector;

    // Use this for initialization
    void Start()
    {
        // get player's position
        vector = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + vector;
        //Debug.Log(transform.position);
    }
}
