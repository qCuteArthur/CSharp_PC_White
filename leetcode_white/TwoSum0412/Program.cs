using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum0412
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] {3,3};
            int target = 6;

            //Solution solution = new Solution();
            //int[] result = solution.TwoSum(nums, target);

            //Solution2 solution2 = new Solution2();
            //int[] result_1 = solution2.TwoSum(nums, target);

            Solution3 solution3 = new Solution3();
            int[] result2 = solution3.TwoSum(nums,target);

            Console.WriteLine(result2[0]);
            Console.WriteLine(result2[1]);
            Console.ReadLine();
        }
    }
    //根据最牛逼的代码，使用Dictionary所改写完毕的代码。
    public class Solution2
    {
        public int[] TwoSum(int [] nums,int target)
        {
            Dictionary<int, int> myDictionary = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                myDictionary.Add(i,nums[i]);
            }

            //字典中会出现多个key对应一个value的情况吗？如果会，那么我使用Dictionary.Length是很危险的。
            for(int i = 0; i < nums.Length; i++)
            {
                //出现的一个情况就是，我们存在一个3，然后目标是6，我们要找的也是3，所以就崩溃了。。。。。
                if (myDictionary.ContainsValue(target - nums[i]))
                {
                    int secondIndex = FindKey(target - nums[i], myDictionary);
                    if ( secondIndex== i)
                        continue;
                    else
                    {
                        return new int[] { i, secondIndex };
                    }
                }
            }
            return new int[2];
        }
        public int FindKey(int value,Dictionary<int,int> keyValuePairs)
        {
            foreach (KeyValuePair<int,int> kvp in keyValuePairs)
            {
                if (kvp.Value.Equals(value))
                {
                    return kvp.Key;
                }
            }
            return -1;
        }
    }
    
    class Solution1
    {
        public int[] TwoSum(int[] nums, int target)
        {
            //首先创建一个字典，key为int，value也是int
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                //使用Dictionary进行快速的查找
                if (map.ContainsKey(complement))
                {
                    //直接初始化一个数组，输出两个index。
                    //其中值得注意的是，map[complement]是可以根据value寻找key的。
                    return new int[] { map[complement], i };
                }
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], i);
                }
            }
            return new int[] { };
        }
    }
    
    //基于二分查找的方法
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

    //首先，用字典是最快的，但是不是万能的。

    //基于二分查找的思想而不是用二分查找找元素。

    //三个数可以调用这个二分查找，但是不如基于二分查找的思想。
    public class Solution3
    {
        //直接返回两个位置，而三个数那里是返回数值。
        public int[] TwoSum(int [] nums,int target)
        {
            int []nums2 = new int[nums.Length];
            nums2 = nums.Clone() as int[];

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                keyValuePairs.Add(i,nums[i]);
            }
            int[] ret = new int[2] { -1, -1 };
            //////  
            if (nums.Length <2)
            {
                return new int[0];
            }
            /////
            Array.Sort(nums);
            int start = 0;
            int end = nums.Length- 1;
            while (start <= end)
            {
                int sum = nums[start] + nums[end];
                if (sum > target)
                {
                    end = end - 1; 
                }
                else if (sum < target)
                {
                    start = start + 1; 
                }
                else
                {
                    //就是这种情况下，我已经找到了对应的实际的value，但是让我返回的是一个key。。。。mmp。。而且这个key是原来数组的key。。。
                    //如何根据一个key来寻找一个值。。。。。
                    int FirstPosition = Array.IndexOf<int>(nums2, nums[start]);
                    int SecondPosition = Array.IndexOf(nums2, nums[end]);
                    //对于3 3 这种还是无能为力，曹尼玛
                    return new int[] { FirstPosition,SecondPosition};
                }
            }
            return new int[0];
        }
    }
}

//数组两大考点——快速·排序  快速寻找 


