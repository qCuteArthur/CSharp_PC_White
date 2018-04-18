using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface_0418A2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
// 接口不能实例化
// 一个子类可以继承一个基类和多个接口（同时继承）。
// 接口类型的是一种引用变量，把这个东西也可以指向实现这个接口的类。
// 可以使用一个接口引用变量指向实现该接口的一个对象。使用接口引用变量的时候，仅仅能访问接口里面定义的变量和类型。

// 接口引用变量和类引用变量都可以指向类或者实现接口的类。
// 判断是不是实现了接口，我们可以使用is进行判断

// 接口可以继承其他的接口，可以层层继承；也就是把这些属性和方法都继承了。
//任何类都可以实现任何的接口

// 向上类型转换——用子类代替基类，只能够使用基类的方法或者属性。
//类可以进行类型转换，但是说，你向上类型转换是比较保险的，可以使用的方法和属性越来越少。而使用向下类型转换，可以使用的方法和属性越来越多。

    //使用is 和 as进行强制类型转换
    //if(PowerConsumer is CoffeeMaker){
    //    CoffeeMaker java = PowerConsumer as CoffeeMaker;
    //java.CoffeeMaker;
    //}


    //隐式类型转换，编译器会帮助把关，而显示类型转换，编译器就不管了。
    //可以用try catch异常控制方法。或者在进行强制类型转换的时候，（先判断再转换）首先进行一个类型的判断。或者是as方法，如果转化失败，转换之后的对象应该是null。（先转换再判断）
    
    //接口是一种契约，是一个抽象类，但是和abstract可以部分实现，部分不实现，是一种彻彻底底的抽象。


    //继承两个接口，可以理解为，一个人有两个不同的身份。
    //抽象类和接口就是部分抽象和全部抽象的差别。


