using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Non_Decreasing_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 4, 5, 3 };
            Solution solution = new Solution();
            bool ret = solution.CheckPossibility(array);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public bool CheckPossibility(int[] nums)
        {
            if (nums.Length == 0) return false;

            List<int> item = new List<int>();

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    item.Add(i);
                }
            }

            if (item.Count() > 1) return false;
            else if (item.Count() == 1)
            {
                int j = item[0];
                if (j == 0 || j == (nums.Count() - 2)) return true;
                if ((nums[j + 1] >= nums[j - 1]) || (nums[j] <= nums[j + 2])) return true;
                return false;
            }
            else { return true; }
            return false;
        }
    }
}
