using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Level = 1;

    public MapManager mm;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        instance.mm = GetComponent<MapManager>();
        InitGame();
    }

    void InitGame()
    {
        mm.InitMap(Level);
    }

    // Update is called once per frame
    void Update()
    { }
}