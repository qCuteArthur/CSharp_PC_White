using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//泛型方法 泛型委托 泛型Lambda表达式。
namespace BS_泛型委托2
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> myfunc = new Func<int, int, int>((int x,int y)=> { return x + y; });
            myfunc = new Func<int, int, int>((int x,int y)=> { return x - y; });

            //lambda的语法糖
            var myfunc2 = new Func<int, int, int>((x,y)=> { return x + y; });
            Func<int, int, int> myfunc3 = (a, b) => { return a + b; };
            //这也太简化了吧。。。。
            //如果你这个func可以作为形式参数的话，那么如果真的涉及到了调用函数的时候，是不是可以用lambda直接作为实际参数呢？  
            DoCalculation<int>((int x, int y) => { return x + y; }, 100, 200);//泛型委托的自动类型推断//泛型委托的参数类型推断
            //把Lambda作为委托的实际参数传递进去。
        }
        //用委托作为函数的参数时，可以创建使用lambda表达式作为委托实例。
        static void DoCalculation<T>(Func<T,T,T>func,T x,T y)
        {
            T res = func(x,y);
            Console.WriteLine(res);
        }








        static void Sayhello(string contend , int round)
        {
            for(int i = 0; i < round; i++)
            {
                Console.WriteLine(contend);
            }
        }
    }
}
//lambda表达式——匿名函数（方法），inline方法（一般的方法都是要先声明再调用，我们这个可以直接调用）————inline的匿名方法。
//接口 抽象类 多态都是用到了很多基础知识。
//算法则是更高效的检验方式。所以，一定要多学习算法。