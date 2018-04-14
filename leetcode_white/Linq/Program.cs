using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers=new int[]{ 2,3,4,14};
            //查询语法
            var numsQuery = from n in numbers where n < 20 select n;
            //方法语法
            //匿名方法Lambda表达式
            var numsMethod = numbers.Where(x => x < 20);
            //对于查询出来的结果，Count其个数
            int numsCount = (from n in numbers where n < 20 select n).Count();
            //
        }
    }
}
