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