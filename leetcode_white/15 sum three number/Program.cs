using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//{ -1, 0, 1, 2, -1, -4 }
//输入[]
//输入{0,0,0,0}------增加一个previous number进行判断
//[3,0,-2,-1,1,2]--------增加结尾对于previous_number清空的判断

namespace _15_sum_three_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 3, 0, -2, -1, 1, 2 };
            Solution5 solution5 = new Solution5();
            IList<IList<int>> ret = solution5.ThreeSum(nums);
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
        //本质上还是做差，然后找
        public List<List<int>> ThreeSum(int [] nums)
        {
            //用var真的是再好不过了！！！
            var Indexes = new List<List<int>>();
            if (nums.Length < 3)
            {
                return null;
            }
            List<int> array = new List<int>(nums);
            array.Sort();
            //可不可以在你找完第一个数之后，来做将剩下的东西映射到hashMap里面呢？？？
            for(int i = 0; i < array.Count; i++)
            {
                int FirstNumber = array[i];
                int FirstIndex = i;
                int target= array[i] * (-1);
                int SecondIndex = -1;
                int ThirdIndex = -1;
                List<int> Index = new List<int>();
                List<List<int>> SecondThirds = TwoSum(array,target);
                for(int j = 0; j < SecondThirds.Count; j++)
                {
                    List<int> SecondThird = SecondThirds[j];
                    SecondIndex = SecondThird[0];
                    ThirdIndex = SecondThird[1];
                    if ((FirstIndex != SecondIndex) && (SecondIndex != ThirdIndex) && (ThirdIndex != FirstIndex))
                    {
                        Index.Add(FirstIndex);
                        Index.Add(SecondIndex);
                        Index.Add(ThirdIndex);
                        Indexes.Add(Index);
                    }
                }
            }
            return Indexes;
            //一个排序好的列表
        }
        public List<List<int>> TwoSum(List<int>array,int target)
        {
            var ret = new List<List<int>>(); 
            for(int i = 0; i < array.Count; i++)
            {
                int SecondNumber = array[i];
                int SecondIndex = i;
                int ThirdNumber = target - array[i];
                int ThirdIndex = BinarySearch(array, ThirdNumber, 0, array.Count - 1);
                if (ThirdIndex != -1)
                {
                    List<int> retB = new List<int>();
                    retB.Add(SecondIndex);
                    retB.Add(ThirdIndex);
                    ret.Add(retB);
                }
            }
            return ret;
        }
        //2分钟之内，快速的写完这个BinarySearch
        public int BinarySearch(List<int>nums,int key,int start,int end)
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
                    return BinarySearch(nums,key,mid+1,end);
                }
                else
                {
                    return BinarySearch(nums,key,start,mid-1);
                }
            }
        }
        //public IList<IList<int>> ThreeSum(int[] nums)
        //{
        //    //本身就是接口，似乎根本就是无法创建实例的样子。
        //    IList<IList<int>> ret = default(IList<IList<int>>);
        //    if (nums.Length < 3)
        //    {
        //        return null;
        //    }
        //    //三重嵌套肯定能做，但是有没有更好的结果呢？？

        //    List<int> myList = new List<int>(nums);
        //    myList.Sort();

        //    int Count = nums.Length;
        //    for (int i = 0; i < Count; i++)
        //    {
        //        int firstNumber = myList[i];
        //        int midNumber = myList[Count/2];
        //        for (int j = 0; j < Count; j++)
        //        {

        //        }
        //    }
        //}
    }
    public class Solution2
    {
        public IList<IList<int>> ThreeSum(int [] nums)
        {
            List<IList<int>> ret = new List<IList<int>>();
            for(int i = 0; i < nums.Length; i++)
            {
                int complement = nums[i] * (-1);
                int[] SecondThird = TwoSum(nums,complement);
                if ( i !=SecondThird[0] && i!=SecondThird[1])
                {
                    ret.Add(new List<int> { SecondThird[0], SecondThird[1] });
                }
            }
            return ret;
        }
        //twoSum缺少一种根据value查找key的方法，可以用for循环keyValuePair或者是Linq，但是我觉得应该还有更好的方法。
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> myDictionary = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                myDictionary.Add(i, nums[i]);
            }

            //字典中会出现多个key对应一个value的情况吗？如果会，那么我使用Dictionary.Length是很危险的。
            for (int i = 0; i < nums.Length; i++)
            {
                //出现的一个情况就是，我们存在一个3，然后目标是6，我们要找的也是3，所以就崩溃了。。。。。
                if (myDictionary.ContainsValue(target - nums[i]))
                {
                    int secondIndex = FindKey(target - nums[i], myDictionary);
                    if (secondIndex == i)
                        continue;
                    else
                    {
                        return new int[] { i, secondIndex };
                    }
                }
            }
            return new int[2];
        }
        public int FindKey(int value, Dictionary<int, int> keyValuePairs)
        {
            foreach (KeyValuePair<int, int> kvp in keyValuePairs)
            {
                if (kvp.Value.Equals(value))
                {
                    return kvp.Key;
                }
            }
            return -1;
        }
    }

    public class Solution3
    {
        //出现了大量的重复的情况
        //但是2-1-1这种情况是被允许的，
        //突然有一个想法是不是用二分查找会更好？就是一个从左边找一个从右边找。。。
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<int> data = new List<int>(nums);
            data.Sort();

            List<IList<int>> ret = new List<IList<int>>();
            Dictionary<int, int> keyValuePairs = new Dictionary<int,int>();
            HashSet<List<int>> hashSet = new HashSet<List<int>>();

            //Dictionary<int, int> keyValuePairsReverse = new Dictionary<int, int>();
            for(int i = 0; i < data.Count; i++)
            {
                keyValuePairs.Add(i,data[i]);
                //keyValuePairsReverse.Add(nums[i],i);
            }

            for(int i = 0; i < data.Count; i++)
            {
                for(int j = 0; j <data.Count; j++)
                {
                    int complement = (-1) * data[i] - data[j];  
                    foreach(KeyValuePair<int,int> kvp in keyValuePairs)
                    {
                        if((kvp.Value== complement)&&(kvp.Key != j) && (j != i) && (kvp.Key != i))
                        {
                           hashSet.Add(new List<int> { i,j, kvp.Key});
                        }
                    }
                }
            }
            //但是现在出来的这个东西，重复性很大。。。。如何尽可能的消除重复呢？？？HashSet并不是一个良好的解决办法。
            //也就是说，我们虽然不能用hashSet存储这个value，但是可以用hashSet存储key啊。然后输出hashset不就行了吗。。。。
            foreach(var item in hashSet)
            {
                ret.Add(new List<int> { data[item[0]], data[item[1]], data[item[2]] });
            }
            return ret;
        }
     }
    public class Solution4
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> ret = new List<IList<int>>();
            Array.Sort(nums);

            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            //Dictionary<int, int> keyValuePairsReverse = new Dictionary<int, int>();
            int i = 0;
            foreach(var item in nums)
            {
                keyValuePairs.Add(i,item);
                //如果你的value相同而key不同就会很麻烦了。。。
                //keyValuePairsReverse.Add(item,i);
                i++;
            }
            //初始化完毕，增加一个ret nums keyValuePairs
            for(int First = 0; First < nums.Length; First++)
            {
                for(int Second =First+1;Second < nums.Length; Second++)
                {
                    int complement = (-1) * (nums[First] + nums[Second]);
                    int Third = Second + 1;
                    int number3 = 0;
                    //if (keyValuePairs.ContainsValue(complement)&&((number3 = keyValuePairsReverse[complement])>=Second+1))
                    //{
                    //    ret.Add(new List<int> { nums[First], nums[Second], nums[Third]});
                    //}
                }
            }
            return ret;
        }
    }

    //上面的全是基于这个Array暴力从头开始找的。。。
    //基于二分查找思想的查找。
    public class Solution5
    {

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> ret = new List<IList<int>>();
            Array.Sort(nums);
            if (nums.Length < 3)
            {
                return ret;
            }
            int previous_first = int.MinValue;
            int previous_second = int.MinValue;
            int previous_third = int.MinValue;

            for (int FirstIndex = 0; FirstIndex<nums.Length-2; FirstIndex++)
            {
                if (previous_first == nums[FirstIndex])
                {
                    previous_first = nums[FirstIndex];
                    continue ;
                }
                //注意是+1不是++
                int ThirdIndex = nums.Length - 1;
                int SecondIndex = FirstIndex + 1;
                while (SecondIndex < ThirdIndex)
                {
                    if(nums[SecondIndex] == previous_second)
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
                    if (nums[SecondIndex] + nums[ThirdIndex] + nums[FirstIndex] < 0)
                    {
                        previous_second = nums[SecondIndex];
                        SecondIndex++;
                    }
                    else if (nums[SecondIndex] + nums[ThirdIndex] + nums[FirstIndex] > 0)
                    {
                        previous_third = nums[ThirdIndex];
                        ThirdIndex--;
                    }
                    else if(nums[SecondIndex] + nums[ThirdIndex] + nums[FirstIndex]==0)
                    {
                        ret.Add(new List<int>{ nums[FirstIndex], nums[SecondIndex], nums[ThirdIndex]});
                        //Critical!
                        previous_second = nums[SecondIndex];
                        SecondIndex++;
                     }
                }
                previous_first = nums[FirstIndex];
                previous_second = int.MinValue;
                previous_third = int.MinValue;
            }
            return ret;
        }
        
    }
}
//首先进行一个排序
//动用二分查找的思想，一开始是左边一个右边一个指针，如果二者的


    //log:
    //2018年4月13日17:07:32
    //使用HashSet还是无法有效解决重复的问题