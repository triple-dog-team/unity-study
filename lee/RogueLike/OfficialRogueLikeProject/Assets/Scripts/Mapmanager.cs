using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapmanager : MonoBehaviour
{
    //定义unity编辑器用属性集合，可以把prefab直接拖到里面作为随机池
    public GameObject[] outWall;
    public List<GameObject> floor;

    public int Rows = 10;
    public int Columns = 10;

    // Start is called before the first frame update
    void Start()
    {
        InitMap();
    }

    // Update is called once per frame
    void Update()
    {

    }


    //地图初始化
    void InitMap()
    {
        var walls = GameObject.Find("Walls");
        var floors = GameObject.Find("Floors");
        //遍历行x列个所有的格子
        //围墙算法：如果0列或0行，则肯定是围墙（左边和下边），同时如果最大行或者最大列也是围墙（上边和右边）
        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Columns; y++)
            {
                if (x == 0 || y == 0 || x == Columns - 1 || y == Rows - 1)
                {
                    var r = Random.Range(0, outWall.Length);
                    //构造围墙
                    var g = GameObject.Instantiate(outWall[r], new Vector3(x, y, 0), Quaternion.identity);
                    g.transform.SetParent(walls.transform);
                }
                else
                {
                    var r = Random.Range(0, floor.Count);
                    //构造围墙
                    var g = GameObject.Instantiate(floor[r], new Vector3(x, y, 0), Quaternion.identity);
                    g.transform.SetParent(floors.transform);
                }
            }
        }
    }
}
