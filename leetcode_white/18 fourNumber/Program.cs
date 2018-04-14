using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_fourNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 0, -1, 0, -2, 2 };
            int target = 0;

            Solution solution5 = new Solution();
           
            IList<IList<int>> ret = solution5.FourSum(nums,target);
            if (ret != null)
            {
                Console.WriteLine("Comrade!!!For mother Russia!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
            Console.ReadLine();
        }
    }


    public class Solution
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> ret = new List<IList<int>>();
            Array.Sort(nums);
            if (nums.Length < 4)
            {
                return ret;
            }
            int previous_first = int.MinValue;
            int previous_second = int.MinValue;
            int previous_third = int.MinValue;
            int previous_fourth = int.MinValue;

            int FirstIndex = 0;
            int FourthIndex = nums.Length - 1;

            while (FirstIndex < FourthIndex)
            {
                if (previous_first == nums[FirstIndex])
                {
                    previous_first = nums[FirstIndex];
                    continue;
                }
                if (previous_fourth == nums[FourthIndex])
                {
                    previous_fourth = nums[FourthIndex];
                    continue;
                }

                int SecondIndex = FirstIndex + 1;
                int ThirdIndex = FourthIndex - 1;
                while (SecondIndex < ThirdIndex)
                {
                    if (nums[SecondIndex] == previous_second)
                    {
                        previous_second = nums[SecondIndex];
                        SecondIndex++;
                        continue;
                    }
                    if (nums[ThirdIndex] == previous_third)
                    {
                        previous_third = nums[ThirdIndex];
                        ThirdIndex--;
                        continue;
                    }
                    if (nums[SecondIndex] + nums[ThirdIndex] + nums[FirstIndex] + nums[FourthIndex] < target)
                    {
                        previous_second = nums[SecondIndex];
                        SecondIndex++;
                    }
                    else if (nums[SecondIndex] + nums[ThirdIndex] + nums[FirstIndex] + nums[FourthIndex] > target)
                    {
                        previous_third = nums[ThirdIndex];
                        ThirdIndex--;
                    }
                    else if (nums[SecondIndex] + nums[ThirdIndex] + nums[FirstIndex] + nums[FourthIndex] == target)
                    {
                        ret.Add(new List<int> { nums[FirstIndex], nums[SecondIndex], nums[ThirdIndex], nums[FourthIndex] });
                        //Critical!
                        previous_second = nums[SecondIndex];
                        SecondIndex++;
                    }
                }

                if (nums[FirstIndex] + nums[SecondIndex--] + nums[ThirdIndex] + nums[FourthIndex] < target)
                {
                    FourthIndex--;
                }
                else
                {
                    FirstIndex++;
                }
                previous_second = int.MinValue;
                previous_third = int.MinValue;
            }
            return ret;
        }
    }
    //目前问题就是4号指针很难移动的问题，与1号指针地位等同但是对于结果的贡献很差。


}



