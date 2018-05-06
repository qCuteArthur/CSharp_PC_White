
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _860_相邻数字
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int ret =solution.ConsecutiveNumbersSum(15);
            Console.WriteLine(ret);
        }
    }
    public class Solution
    {
        public int ConsecutiveNumbersSum(int N)
        {
            //首先使用int就够了
            //用二分查找
            if (N == 0) return 1;
            //相邻的数字，你使用对于456 12345 这种都是奇数的情况 而偶数情况，其实只有一种把
            //如果一个数是一个偶数，那么拆分的数组也都是偶数的 比如 2345=14 
            //如果一个数是奇数，那么拆分的数组有两种情况 比如 15 = 78 然后就是全奇数的情况比如 456=15%3 一共三个数字 然后中间的数字是 15/3 
            //15%5 一共5个数字，其中中间的数字是15/5 然后到了15%7！=0 也就不要拆分了

            //偶数 26 ==13*2== 5678==
            //13 有多少种？ 67 
            int ret = 0;
            if (N % 2 == 0)
            {
                if ((N / 2) % 2 == 0) return 1;
                if ((N / 2) % 2 != 0) return 2;
            }
            if (N % 2 != 0)
            {
                int operator= 1;
                while ((N - 1) / 2 >operator){
                    if (N %operator== 0)ret++;
                operator+= 2;
                }
            }
            return ret;
        }
    }
}
