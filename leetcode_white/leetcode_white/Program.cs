using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace leetcode_white
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num1 = { 1, 3 };
            int[] num2 = { 2, 4 };
            double x = Solution.FindMedianSortedArrays(num1, num2);
            Console.WriteLine(x);
        }
    }


    public class Solution
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            List<int> retList = new List<int>(nums1);
            foreach (var item in nums2)
            {
                retList.Add(item);
            }

            if (retList.Count == 0)
            {
                return 0;
            }

            retList.Sort();
            

            if(retList.Count%2 == 0)
            {
                double x = ((double)(retList[(retList.Count) / 2 - 1]) + (double)retList[(retList.Count) / 2]) /2;
                return x ;
            }
            else
            {
                double x = (retList[(retList.Count + 1) / 2 - 1]);
                return x;
            }
        }
    }


}
