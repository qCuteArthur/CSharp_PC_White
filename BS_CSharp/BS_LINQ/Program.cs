using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_LINQ
{
    public delegate void MyDele();
    class Program
    {
        static void Main(string[] args)
        {
            M1 m1 = new M1();
            MyDele myDele = new MyDele(m1.Action);
            myDele += m1.Action;
            Console.ReadLine();
        }
    }
    public class M1
    {
        public void Action()
        {
            Console.WriteLine("+++++++++++++++");
        }
    }
}
//大纲+++++++++++++++++++++++++++++++++++++++++++
//委托一个是可以用事件，一个是可以用Lambda表达式。

//    委托是啥
//    委托声明
//    泛型委托
//    必须自己创建委托类型吗
//    泛型委托类型参数推断

//    方法和lambda之间的关系
//    把一个lambda表达式赋值给委托类型变量
//    把一个Lambda给一个委托类型的参数

//LINQ

//细节开始++++++++++++++++++++++++++++++++++++
//委托，其实是委托类型，是一种class类型。
//把引用类型声明的变量，声明给实例

//委托类型声明一个变量之后，可以创建一个委托实例或者直接给null

//功能特殊，看起来比较特殊。
//一般的类都是反映现实生活中的事物，委托类型是用来包裹方法，通过委托类型的实例来间接的调用方法，委托类型就是方法的实例。
//委托就是用来间接调用。


//委托的声明类似于一个函数的签名。
//delegate void MyDele();
//就是你使用的时候，需要进行实例化，也就是创建实际引用的变量。
//这种委托类型的参数，只要返回值是void，参数列表是空就行，不管你是实例方法还是静态方法，统统能应用。

//未来对于委托类型的变量的使用

