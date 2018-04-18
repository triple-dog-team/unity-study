# UFO游戏
主要目的了解以下几个概念：
* GameObject
游戏物体，游戏中的每一个有实际功能的对象都是一个GameObject
* sprite
2D的游戏中单位，几乎所有的游戏引擎都定义为sprite。对应到Unity界面中就是GameObject-2D Object-sprite。
  - Sprite 用于展示物体的图片
  - Color 物体颜色
  - Flip x，y  勾选则以某个轴翻转
  - Material 选择图片的材质
  - Draw model TODO
  - Sorting layer 设置物体在哪个层
  - Order in layer 层内排序，数字大的在前面
  - Mask Interaction 用于物体的隐藏
* rigidbody  
附加在GameObject上的刚体，附带真实物体的重力等属性。本质就是把对应的GameObject加上物理引擎。
    - Body Type
        - Dynamic 最常用的，包含重力、线性移动、角移动属性，对于这种类型的刚体最好不要直接修改位置一类的参数，而是给他force，效果就是模拟真实物体的运动。
        - Kinetic 用于单纯的运动，通过RigidBody2D.MovePosition和xxx.MoveRotation来改变位置和方向，吃资源比Dynamic少。
        - Static 不移动的物体
* collistion  
附加在GameObject上的碰撞器