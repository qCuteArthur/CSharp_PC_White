using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_泛型委托
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDele<int> deleAdd = new MyDele<int>(Program.Add);
            MyDele<double> deleMul = new MyDele<double>(Program.Mul);
            int ret = deleAdd(10,10);
            double ret2 = deleMul(20, 20);
        }
        static int Add(int x,int y)
        {
            return x + y;
        }
        static double Mul(double x,double y)
        {
            return x * y;
        }
    }
    //这里是声明泛型委托
    public delegate T MyDele<T>(T a, T b);
}
//泛型加委托会很强大
//对于没有返回值的委托，我们选择使用Action，而对于存在着返回值的委托，我们采用Func。这个是厂家内置的函数。
//似乎Action和Func之间的差别就是是不是存在着返回值
//有时候在明确类型的时候，可以用VAR关键字。比如说：var Student = new Student();

