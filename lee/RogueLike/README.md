# Unity官网的拾荒者样例项目，用于熟悉Unity的开发

[拾荒者](https://unity3d.com/learn/tutorials/s/2d-roguelike-tutorial)

拾荒者游戏开发要点记录：

1. 学习官网的文档组织结构，按照类别来做区分，非常熟练之后再制定自己的文档结构。
	- Animations 动画   动画本身是关键帧的组合，unity可以根据多张图片进行自动生成动画，但动画的速度需要手动调整，速度在状态机图（也就是动画控制器)中调整speed属性改变。
	- AnimatorController 动画控制器
	- Audio 音视屏
	- Fonts 字体
	- Scences 场景，游戏本质上由多个场景组成，这里可以看作切画面（因为不是所有画面都能放在一个文件里，会显得凌乱)
	- Sprites 精灵，沿用了几乎所有游戏object的命名，大量的游戏引擎或者框架都会把游戏中的物体叫做sprite
	- Prefab 预制件
2. 同一物体的动画不要直接拖到scene中，生成物体后往物体里面拖也可以生成动画相关anmi文件
3. Controller（状态机）如果功能相似或者重复应该通过创建override（子类）来实现，重写的内容要定义在被重写的controller里面，共享Controller逻辑（但其实还是多出一个文件），绑定不同状态变化后的动画
4. prefab创建好之后scence中的对应文件可以删除掉，以后仅用prefab即可
5. 在Scence中创建了GameObject之后，无论它是否有图片或者效果，它的脚本都会被执行，所以这里创建了一个空的对象并把空对象作为了初始化地图的管理器。
6. 脚本中定义public的GameObject属性可以直接装载从prefab中拖入的控件，然后直接被初始化或者update调用，这点很好用
7. 定义InitMap()方法给start调用，并在该方法中用简单算法判断调用GameObject.Instantiate的实例化游戏对象方法，随机从集合中构造出围墙对象，坐标根据循环中的行列即可，但这里默认会拼接上图片的大小，这点不知道怎么做到的；同时GameObject.Instantiate第三个参数可以提供对游戏对象的旋转Quaternion.identity（不旋转）。
8. unity中，坐标的1单位是1米，如果我们使用默认用图片构造出的prefab的话它的scale也是1，1，1，所以按如下代码可以正确的生成出大小为1的一圈墙壁

```

        for (int x = 0; x < Rows; x++)
        {
            for (int y = 0; y < Columns; y++)
            {
                if (x == 0 || y == 0 || x == Columns - 1 || y == Rows - 1)
                {
                    var r = Random.Range(0, outWall.Length);
                    //构造围墙
                    GameObject.Instantiate(outWall[r], new Vector3(x, y, 0), Quaternion.identity);
                }
            }
        }
```

9. if判断围墙之后，else部分生成地板就行
10. 在使用GameObject.Instantiate静态函数创造游戏对象的时候，是创建在unity当前场景下的根目录，会导致运行后左侧动态产生的游戏对象大量的平铺，造成使用不便。可以把相应对象创建到单独的gameobject对象下面，效果相同，但利用gameobject进行了对象分组。
11. Transform是在场景中所有对象的基础属性，它负责物体的变换（如移动，旋转，缩放等）
12. 脚本设置父组件的方式是通过Gameobject的transform属性的setParent函数进行，这里需要关注的是setParent或者Parent属性并不在一般认为的object本身，而是放在了transform属性中。相似的setParent的参数也要求是要挂载父对象的transform属性。