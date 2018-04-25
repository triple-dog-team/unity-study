## 要点：
- Input.GetKey  
参数为KeyCode类型的枚举，获取键盘的输入
- Input.GetButton  
这个方法获取的是工程中定义的Button，Button的信息可以在edit-project settings里面的axes中自定义，unity有一些预设值也可以考虑拿来直接用，这个东西的好处是在编译不同平台的应用时可以调整不同的按键设置
- Camera  
在获取使用Camera最顶端时，因为想使用计算的方式动态获取，使用的是Camera.current。这个获取方式在子弹超出摄像机时能够正常获取和判断，但是在子弹还在当前的可视范围内时它是null，根据[官方说明](https://docs.unity3d.com/ScriptReference/Camera-current.html)，一般使用Camera.main来获取主摄像机即可，只有要用MonoBehaviour.OnRenderImage, MonoBehaviour.OnPreRender, MonoBehaviour.OnPostRender几个事件的时候才用得到。
- Destroy  
    - 在消灭某物体时尽量使用明确的标签，否则容易出现问题
    - 消灭物体必须消灭object，因为传入的时候仅仅传入了collision，消灭它仅仅消除了碰撞效果
    - 消灭物体先后顺序需要考虑清楚，比如先消灭对方，再消灭自己（子弹效果），比如地方飞机消灭碰到的物体，如果不做tag区分则有可能直接把子弹先给消灭了。另外有可能飞机发射（生成）子弹时直接和自己碰撞（触发）了，不区分tag直接把自己消灭了，囧。