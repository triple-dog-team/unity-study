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
    - Simulated 勾选时刚体有以下效果，取消勾选提高性能
    	- 通过物理引擎模拟重力和受力运动
    	-  与关联的碰撞器产生相互作用
    	-  绑定的2D物体产生模拟物理效果
    	-  所有全局的物理对象都在内存中维持
   	- use automass 由系统自动设置质量
   	- mass 质量，模拟现实就设置0.1-1之间
   	- linear drag 线阻力，就是xyz轴移动的阻力
   	- angular drag 角阻力
   	- gravity scale 重力
   	- cllision detection 碰撞检测形式，只总结使用方法，具体效果差异在于运动表现和性能，按照规范用就好了：  
   	 	1. Discrete适用于大部分刚体
   	  	2. Continuous适用于将有可能会被高速移动物体撞上的物体
   	  	3. Continuous Dynamic适用于高速移动的物体
   	- sleeping mode 定义了刚体sleep的模式，sleep时减少消耗，几种类型不解释，看着设
   	- interpolate 定义如何调整物理变化时的GameObject，包含None，前一帧，后一帧三个选项，效果是假设连续的物理运动是0.0s,0.1s,0.2s,0.3s的话，当游戏处于0.15s时渲染引擎会取哪一帧，如果选择none则会在0.1的基础上进行计算形成0.15s的效果，如果选择前一帧或者后一帧则会显示相应帧的效果。
   	- constraints 设置刚体只能沿某个轴进行旋转，可选xyz。
* collistion  
附加在GameObject上的碰撞器，按形状在菜单中列出