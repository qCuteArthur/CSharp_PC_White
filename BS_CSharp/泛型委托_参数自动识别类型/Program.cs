using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//基于lambda表达式实现的通用计算器
namespace 泛型委托_参数自动识别类型
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int,int,int> func1 = new Func<int,int,int>((int x,int y)=> { return x + y; });
            var ret = DoCalculation<int>(func1,10,20);
            Console.WriteLine(ret);
            //
            var func2 = new Func<double, double, double>((x, y) => { return x * y; });
            var ret2 = DoCalculation(func2,10,20);
            //直接把lambda表达式作为委托类型
            var ret3 = DoCalculation(((x,y)=>{ return x - y; }),10,2);
            //
            Func<int, int, int> func4 = (int x,int y)=> { return x + y; };
            var ret4 = DoCalculation(func4,10,20);
        }
        static T DoCalculation<T>(Func<T, T, T> myfunc, T x, T y)
        {
            T ret = myfunc(x, y);
            return ret;
        }
    }
}
