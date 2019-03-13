using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameManager gm;

    // Start is called before the first frame update
    void Awake()
    {
        if (GameManager.instance == null)
        {
            Instantiate(gm);
        }
    }
}