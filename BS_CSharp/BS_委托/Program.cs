using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_委托
{
    class Program
    {
        //委托可是类级别的，包含了构造函数和类对象以及invoke方法，所以，对于委托的声明需要在外边进行。
        public delegate int Calc(int x, int y);

        static void Main(string[] args)
        {
            Calculator cat = new Calculator();
            Action _action = new Action(cat.Report);
            //这里仅仅是需要这个方法名，而不是调用方法。
            cat.Report();//直接调用
            _action.Invoke();//间接调用

            //Function委托是泛型委托 
            //Func _func1 = new Func(cat.Report);
            Func<int, int, int> func1 = new Func<int, int, int>(cat.Add);
            Func<int, int, int> func2 = new Func<int, int, int>(cat.Sub);
            Func<int, int, int> func3 = new Func<int, int, int>(cat.Mul);
            //上面声明了三种方法的委托。
            int x = 100;
            int y = 200;
            int z = 0;
            z = func1.Invoke(x,y);
            z = func2.Invoke(x,y);
            z = func3(x,y);//z的类型直接就是返回的结果了。 
            //委托可以按照一定的原则指向目标方法，在方法中可以对于函数进行调用。

            //上面两个委托已经是封装好的类库，直接用就行了。
            //委托也是一种class ，也是一种数据类型。
            //声明委托其实就是在函数声明的基础上增加一个delegate。
            Type t = typeof(Action);
            Console.WriteLine(t);//可以查看类型

            //使用委托来间接的调用方法
            Calculator cat2 = new Calculator();
            //委托是一种类，所以我们提前在类层进行了定义操作。
            //然后下面是创建委托的实例     
            Calc delegate_cat3 = new Calc (cat2.Add);
            Calc delegate_cat4 = new Calc (cat2.Sub);
            Calc delegate_cat5 = new Calc (cat.Mul);
            //委托的使用和类的使用是类似的，委托也是类，委托需要在声明时，与方法相对应，需要在初始化时，用声明的对象的方法作为引用参数。
            //最简单的用法——给类的方法或者对象创建别名。
            int a = 100;
            int b = 20;
            int ret = 0;
            ret = delegate_cat3.Invoke(a,b);
            ret = delegate_cat4.Invoke(a,b);
            ret = delegate_cat5.Invoke(a,b);
            //然后委托对象的使用就是委托类对象里面的invoke方法，包括了使用的对象和调用的对象。
            ret = delegate_cat3(a,b);
            ret = delegate_cat4(a, b);
            ret = delegate_cat5(a, b);
            //委托调用的两种方式。
        }
    }

    public class Calculator
    {
        public void Report()
        {
            Console.WriteLine("there are 3 methods.");
        }
        public int Add(int x,int y)
        {
            int ret = x + y;
            return ret;
        }
        public int Sub(int x,int y)
        {
            int ret = x - y;
            return ret;
        }
        public int Mul(int x,int y)
        {
            int ret = x * y;
            return ret;
        }
    }
}
//函数指针的实例
//C++中的函数指针 
//typedef int (*Calc)(int a,int b);
//Calc funcPointer1 =&funcName;
//Calc funcPointer2 = &funcName2;
//int z = funcPointer1(x,y);
//直接调用就是传递数值，间接调用就是传递引用。

//一切都是地址——数据和算法都是存储在地址中的东西。
//直接调用——就是用函数名来调用函数。
//间接调用就是——用函数指针来调用函数。
//函数指针就是指向对象的地址。

    //Action Func这两种简化的委托
     
    //委托日常使用方面——一方面是将方法作为参数传递给另外一个方法。
    //一般有返回值，可以理解为自定义的func类型。
    //另外一个使用方面——就是回调方法，调用指定的外部方法。//相当于是流水线，位于代码的尾巴，委托不需要返回值。
    

    //模板方法（这个不确定的方法就要依靠回调来传进来） 和 回调方法。

    //小结：
    //委托 ——Action Func 自定义 ————作为模板方法，作为回调方法（其实都是函数对象的直接调用，本质一样！）
    //委托第二个用处之——多线程
    //委托居然是可以被接口代替使用的！！！！！