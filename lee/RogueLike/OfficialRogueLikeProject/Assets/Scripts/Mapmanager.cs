using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MapManager : MonoBehaviour
{
    //定义unity编辑器用属性集合，可以把prefab直接拖到里面作为随机池
    public GameObject[] outWall;
    public List<GameObject> floor;
    public List<GameObject> kernelObjects;
    public GameObject player;
    public GameObject exit;

    public int Rows = 10;
    public int Columns = 10;
    private void Start()
    {

    }

    // Start is called before the first frame update
    void Awake()
    {
    }

    //地图初始化
    public void InitMap(int level)
    {
        var walls = GameObject.Find("Walls");
        var floors = GameObject.Find("Floors");
        //遍历行x列个所有的格子
        //围墙算法：如果0列或0行，则肯定是围墙（左边和下边），同时如果最大行或者最大列也是围墙（上边和右边）
        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Columns; y++)
            {
                //墙和地板
                if (x == 0 || y == 0 || x == Columns - 1 || y == Rows - 1)
                {
                    var r = Random.Range(0, outWall.Length);
                    //构造围墙
                    var g = GameObject.Instantiate(outWall[r], new Vector3(x, y, 0), Quaternion.identity);
                    g.transform.SetParent(walls.transform);
                }
                else
                {
                    //构造地板
                    var r = Random.Range(0, floor.Count);
                    var g = GameObject.Instantiate(floor[r], new Vector3(x, y, 0), Quaternion.identity);
                    g.transform.SetParent(floors.transform);

                    //规则：主角放左下角，出口放右上角，同时用最简单的方式保证至少一条路径通向出口（主角直接上到顶往右，或者右到头往左）
                    //一层墙，所以位置1，1为主角
                    if (x == 1 && y == 1)
                    {
                        GameObject.Instantiate(player, new Vector3(x, y, 0), Quaternion.identity);
                    }

                    //同理设置出口，减的话考虑从0开始就得多-1
                    if (x == Columns - 2 && y == Rows - 2)
                    {
                        GameObject.Instantiate(exit, new Vector3(x, y, 0), Quaternion.identity);
                    }

                    //留路逻辑，列数-3或以上则为内圈的最后一列，所以是小于列-2
                    if (x > 1 && x < Columns - 2 && y > 1 && y < Rows - 2)
                    {
                        //首先随机生成or不生成
                        var generateR = Random.Range(0, 2);
                        if (generateR > 0)
                        {
                            //随机核心游戏内容，敌人、栅栏、汽水等，反正从kernel中随机取
                            var kernelR = Random.Range(0, kernelObjects.Count);
                            GameObject.Instantiate(kernelObjects[kernelR], new Vector3(x, y, 0), Quaternion.identity);
                        }
                    }
                }
            }
        }
    }
}