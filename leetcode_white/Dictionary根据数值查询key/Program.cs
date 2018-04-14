using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary根据数值查询key
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 12, 13, 71, 867, 7, 42, 11, 2, 15 };
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            int i = 0;
            foreach (var num in nums)
            {
                keyValuePairs.Add(i, num);
                i++;
            }
            //循环遍历keyAndValue对
            foreach(KeyValuePair<int,int> kvp in keyValuePairs)
            {
                if (kvp.Value.Equals(2))
                {
                    Console.WriteLine("the key is {0} ,the value is {1} ",kvp.Key,kvp.Value);
                }
            }
            //使用Linq来进行遍历
            Console.ReadKey();
        }
    }
}
