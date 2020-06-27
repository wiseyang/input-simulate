# input-simulate
This is game input simulator in Chinese language. 模拟键盘鼠标输入

![主界面](https://user-images.githubusercontent.com/2831488/85922826-bfd32300-b8b8-11ea-800d-c945db65d89e.PNG)

程序主要用于给游戏应用程序发送模拟的键盘按键或者鼠标按键. 程序操作为:

1. 选择目标应用程序, 通常为游戏的主执行程序
2. 编辑键盘脚本和鼠标脚本
3. 点击**开始**按钮关联模拟到目标应用程序.

然后切换到游戏程序中通过点击绑定的**激活按钮**开启或者中止脚本的模拟.

程序有两种按键模拟方式: **直接按键**和**间隔按键**. 每一种模拟方式都可以依据编辑的脚本模拟键盘按键和鼠标左右键.

# 脚本编写
模拟脚本包含多行文本, 每一行文本可能是以下的集中情况:
* **注释**: 开始符号为分号 **;**
* **等待时间**: 开始符号为 **[**, 结束符号为 **]**. 中间为以毫秒为单位的等待时间. 程序模拟执行时等待这段时间. 用于**直接按键**方式中直接执行等待或者**间隔按键**方式中间隔检查频率.
* **键盘直接按键行**: 单个或多个字符. 程序模拟执行时会模拟这些字符的按键.
* **鼠标直接按键行**: **Left** 或者 **Right**. 程序模拟执行时会模拟对应的鼠标按键.
* **键盘间隔按键行**: 开始符号为 **(**, 结束符号为 **)**. 中间包含以分号 **,** 分开的两部分, 第一部分为单个或多个字符. 第二部分为模拟第一部分的时间间隔, 单位为毫秒.
* **鼠标间隔按键行**: 开始符号为 **(**, 结束符号为 **)**. 中间包含以分号 **,** 分开的两部分, 第一部分为鼠标按键 **Left** 或者 **Right**. 第二部分为模拟第一部分的时间间隔, 单位为毫秒.

# 直接按键方式
程序依次执行脚本中的每一行, 执行所有行后再循环从第一行开始模拟.

## 模拟键盘按键

>   [500]

>   asdf

说明: 每隔500毫秒模拟键盘按键asdf.

## 模拟鼠标按键

>   [500]

>   Left

说明: 每隔600毫秒模拟鼠标左键 (鼠标按键有内置的100毫秒)

# 间隔按键方式
程序按照**等待时间行**检测脚本中的每一行, 判断是否离上次模拟这一行已超过间隔时间. 如果超过, 则模拟这一行第一部分的按键; 如果未超过, 则不执行任何模拟.

## 模拟键盘按键

>   [100]

>   (as, 300)

>   (df, 1000)

说明: 每隔300毫秒模拟键盘按键as, 每隔1000毫秒模拟键盘按键df. 每100毫秒检测一次.

## 模拟鼠标按键

>   (Left, 500)

说明: 每隔500毫秒模拟鼠标左键. 每100毫秒检测一次. (鼠标按键有内置的100毫秒)

# 说明
* 建议不要在模拟脚本中同时使用这两种方式.
