using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest_two_times_larger_than_second
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] nums = { 1, 2, 3, 4, 8 };
            int ret = solution.DominantIndex(nums);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public int DominantIndex(int[] nums)
        {
            Dictionary<int, int> keyvaluepairs = new Dictionary<int, int>();
            if (nums.Length < 2)
            {
                return -1;
            }
            Array.Sort(nums);
            int max = nums[nums.Length - 1];
            int secondmax = nums[nums.Length - 2];
            for (int i = 0; i < nums.Length; i++)
            {
                keyvaluepairs.Add(i, nums[i]);
            }
            //在字典中增加这个元素
            if (max >= secondmax * 2)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == max)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}
