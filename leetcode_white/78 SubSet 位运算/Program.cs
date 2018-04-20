using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _78_SubSet_位运算
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            List<IList<int>> ret = new List<IList<int>>();
            int[] nums = { 1, 2, 3 };
            ret = solution.Subsets(nums) as List<IList<int>>;
            foreach(var item in ret)
            {
                foreach(var subitem in item)
                {
                    Console.WriteLine(subitem);
                }
                Console.WriteLine("_______________________");
            }
            Console.WriteLine("+++++++++++");
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> ret = new List<IList<int>>();

            double number = Math.Pow(2, nums.Length);

            for (int i = 0; i < number; i++)
            {
                List<int> item = new List<int>();
                for (int j =0; j <nums.Length; j++)
                {
                    int JudgingNumber = 1 << j;
                    if ((JudgingNumber&i)==(JudgingNumber))
                    {
                        item.Add(nums[j]);
                    }
                }
                ret.Add(item);
            }
            return ret;
        }
    }
}
