using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _29_不使用乘号_除号和取模符号将两数相除
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    //    不使用乘号，除号和取模符号将两数相除。
    //如果溢出返回 MAX_INT。

        //位操作符，位操作方式
    //二进制位移，左移一位乘以2，右移一位处以2。
    public class Solution
    {
        //public int Divide(int dividend, int divisor)
        //{
        //    long longdividend = (long)(Math.Abs(dividend));
        //    long longdivisor = (long)(Math.Abs(divisor));
            
        //}
    }
        //Solution 思路有错
    public class Solution2
    {
        public int Divide(int dividend, int divisor)
        {
            int flag = 1;
            //除完了，会出现小数或者说是除法完了，除数为0
            if (divisor == 1)
            {
                return dividend;
            }
            if (dividend == divisor)
            {
                return 1;
            }
            if (divisor==0)
            {
                return int.MaxValue;
            }
            if ((dividend == 0)||((Math.Abs(dividend) < Math.Abs(divisor))))
            {
                return 0;
            }
            //判断是不是同号
            if(((dividend > 0) && (divisor < 0)) || (dividend < 0) && (divisor > 0))
            {
                flag = -1;
            }
            //统一规定到正数,并且把数字转化为long类型的数字。
            long newdivisor = Math.Abs(divisor);
            long newdividend = Math.Abs(dividend);
            //数据预处理
            long[] array = new long[newdividend];
            for (int i =0; i < newdividend; i++)
            {
                array[i] = i;
            }
            //乘2是不符合规则的，应该用二分查找。。。。。
            long start = 0;
            long end = array.Length - 1;
            while (start < end)
            {
                long middle = (start + end) / 2;
                if (middle * newdivisor < newdividend)
                {
                    start = middle + 1;
                }
                else if (middle * newdivisor > newdividend)
                {
                    end = middle - 1;
                }
                else
                {
                    if(middle > int.MaxValue)
                    {
                        return (int.MaxValue*flag);
                    }
                    else
                    {
                        return (int)(middle * flag);
                    }
                }
            }
            return int.MaxValue;
        }
    }

}
//尝试尝试用乘以2的方法
