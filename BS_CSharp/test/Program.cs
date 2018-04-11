using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用Lambda表达式简化类型的传递
            int ret = DoCalc((int x,int y )=> { return x + y; },100,200);//就是lambda表达式自己存在一个类型推断功能。
            Console.WriteLine(ret);
            Console.ReadLine();
        }
        //一个方法用泛型委托作为自己的形式参数，在实际传参的时候，选择使用Lambda表达式传递实际参数。
        static T DoCalc<T>(Func<T,T,T>myfunc,T a,T b)
        {
            T ret = myfunc(a,b);
            return ret;
            //注意，可以使用as typename 进行强制类型转换。
        }
    }
}
