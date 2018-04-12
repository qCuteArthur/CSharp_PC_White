using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//两个数的和，必须用二分查找才能做，但是似乎我这个二分查找的速度很慢。。。要不然就是个假的二分查找，，。。
namespace TwoSum0412
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 12,13, 71,867,7,42 ,11, 2,15 };
            int target = 9;
            Solution solution = new Solution();
            int[] result = solution.TwoSum(nums,target);
            Console.WriteLine(result[0]);
            Console.WriteLine(result[1]);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int[] ret = new int[2];
            List<int> data = new List<int>(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                //int SecondIndex = BinarySearch1(data,target- ret[0], 0,data.Count);
                int SecondIndex = BinarySearch2(data, target - data[i]);
                if (SecondIndex != -1)
                {
                    ret[0] = i;
                    ret[1] = SecondIndex;
                }
            }
            return ret;
        }
        //2分钟之内，快速的写完这个BinarySearch
        public int BinarySearch1(List<int> nums, int key, int start, int end)
        {
            int length = nums.Count();
            int mid = (start + end) / 2;
            if (nums[mid] == key)
            {
                return mid;
            }
            if (start >= end)
            {
                return -1;
            }
            else
            {
                if (key > nums[mid])
                {
                    return BinarySearch1(nums, key, mid + 1, end);
                }
                else
                {
                    return BinarySearch1(nums, key, start, mid - 1);
                }
            }
        }

        //二分查找还是不行吗。。。。那我就只能用system.Collections里面的末班了。
        public int BinarySearch2(List<int> array, int key)
        {
            //默认输入的是一个非空数组。
            int Length = array.Count;
            int start = 0;
            int end = Length - 1;
            //所以，非递归的二分查找根本就不难。
            while (start <= end)
            {
                //如果start = end，会出现end start mid都一样的情况，这个时候，肯定是会返回一个值。
                //如果这个时候还没有找到。

                //这里也可用——————   (end-start)/2+start 
                int mid = (start + end) / 2;
                if (array[mid] == key)
                {
                    return mid;
                    break;
                }
                else
                {
                    if (array[mid] > key)
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
            }
            return -1;
        }

    }

}


