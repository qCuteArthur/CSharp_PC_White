using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 贪心入门
{
    class Program
    {
        //贪心法进行求解。
        static void Main(string[] args)
        {
            int[] RMB = { 200, 100, 20, 10, 5, 1 };
            int NUM = 6;
            int sum = 628;
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            //总共需要多少张不同面额的钞票
            int count = 0;
            //用不同的面额的钞票进行循环遍历。
            for(int i = 0; i < NUM; i++)
            {
                //表示需要当前面额的钞票多少张。
                int use = sum / RMB[i];
                //表示需要总共面额的钞票多少张。
                count += use;
                //剩余的需要支付的面额。
                sum = sum - RMB[i] * use;
                //向字典中增加这个键值对，来记录到底应该输入什么输出什么。
                keyValuePairs.Add(RMB[i],use);
                //进行输出操作了。
                Console.WriteLine("总共需要支付面额{0}的钞票{1}张",RMB[i],use);
                Console.WriteLine("剩余需要支付的面额{0}",sum);
            }
            Console.WriteLine("++++++结束++++++");

            foreach (var item in keyValuePairs)
            {
                Console.WriteLine("{0}_{1}",item.Key,item.Value);
            }
            Console.WriteLine("++++++结束++++++");

            Console.ReadLine();
        }
    }
}
