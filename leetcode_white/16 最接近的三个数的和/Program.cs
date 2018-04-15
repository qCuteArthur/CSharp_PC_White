using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_最接近的三个数的和
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = 1;
            int[] nums = new int[] { -1, 2, 1, -4 };
            Solution solution = new Solution();
            int ret = solution.ThreeSumClosest(nums,target);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        //
        public int ThreeSumClosest(int[] nums, int target)
        {
            //注意，每组输入仅仅有一个答案。
            Array.Sort(nums);
            
            bool flag = false;
            int gap = 0;
            int Sum = 0;
            while (!flag)
            {
                for(int FirstNumber = 0; FirstNumber < nums.Length-1; FirstNumber++)
                {
                    int SecondNumber = FirstNumber+1;
                    int ThirdNumber = nums.Length - 1;
                    while (SecondNumber < ThirdNumber)
                    {
                        Sum = nums[FirstNumber] + nums[SecondNumber] + nums[ThirdNumber];
                        if (Sum < target-gap)
                        {
                            SecondNumber++;
                        }
                        else if (Sum > target + gap)
                        {
                            ThirdNumber--;
                        }
                        else if (Math.Abs(Sum - target) == gap)
                        {
                            flag =true;
                            return Sum;
                        }
                    }
                }
                gap++;
            }
            return Sum;
        }

    }
}
