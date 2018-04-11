using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Do net Intergrated Query 把这个C#翻译成SQL语言。。。。。
//但是SQL还是要学习 = = 看家本事，主要是影响性能。
//还可以查询集合等等

//Linq TO SQL 是一个内置的小类
//而更加强大的是Entity FrameWork，EF。

namespace BS_LINQ
{
    public delegate void MyDele();
    public delegate int MyDele2(int x ,int y);

    class Program
    {
        static void Main(string[] args)
        {
            M1 m1 = new M1();
            MyDele myDele = new MyDele(m1.Action);
            myDele += m1.Action;
            Console.WriteLine("++++++");

            MyDele2 myDele2 = new MyDele2(M2.Add);
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
    public class M2
    {
        public static int Add(int x,int y)
        {
            return x + y;
        }
    }
}
//大纲+++++++++++++++++++++++++++++++++++++++++++
//委托一个是可以用事件，一个是可以用Lambda表达式。

//    委托是啥
//    委托声明
//    泛型委托  <T>
//    必须自己创建委托类型吗 Action 和 Func两个东西。
//    泛型委托类型参数推断 有自动的推断功能 

//    方法和lambda之间的关系——其实lambda表达式就是一个简化的匿名方法
//    把一个lambda表达式赋值给委托类型变量——》》》
//    把一个Lambda给一个委托类型的参数——就是函数的参数如果涉及到了委托形参，我们可以用lambda表达式作为实际参数。

//LINQ

//细节开始++++++++++++++++++++++++++++++++++++
//委托，其实是委托类型，是一种class类型。是一种数据类型（函数指针）。
//把引用类型声明的变量，声明给实例

//委托类型声明一个变量之后，可以创建一个委托实例或者直接给null

//一般的类都是反映现实生活中的事物，委托类型是用来包裹方法，通过委托类型的实例来间接的调用方法，委托类型就是方法的实例。
//委托就是用来间接调用类的方法和类的对象。


//委托的声明类似于一个函数的签名。
//delegate void MyDele();
//就是你使用的时候，需要进行实例化，也就是创建实际引用的变量。
//这种委托类型的参数，只要返回值是void，参数列表是空就行，不管你是实例方法还是静态方法，统统能应用。也就是不管方法的类修饰符，只需要考虑方法的签名是不是一致。

//未来对于委托类型的变量的使用，大多数还是按照函数那样去调用。
//也就是模板方法或者是回调方法。

