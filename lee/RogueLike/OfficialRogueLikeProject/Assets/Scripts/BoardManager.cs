using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    [Serializable]
    public class Count
    {
        public int min;
        public int max;

        public Count(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
    }

    public int Rows = 10;
    public int Columns = 10;

    public Count wallCount = new Count(5, 9);
    public Count foodCount = new Count(1, 5);
    public GameObject exit;
    public List<GameObject> floor;
    public GameObject[] outWall;
    public GameObject player;
    public List<GameObject> kernelObjects;

    List<Vector3> gridPositions = new List<Vector3>();
    private Transform boradHodler;

    void InitializeList()
    {
        gridPositions.Clear();

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

                    //这里可以根据gm的属性来做处理，也可以直接把核心对象丢到gm里
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

    public void SetupScene(int level)
    {
        InitializeList();
    }
}