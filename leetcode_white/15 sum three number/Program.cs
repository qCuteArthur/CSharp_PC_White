using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_sum_three_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[]{ -1, 0, 1, 2, -1, -4};
            Solution solution = new Solution();
            List<List<int>> ret= solution.ThreeSum(array);
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
}
//首先要明确，数组这边的东西，都是和排序紧密相关的。

//分治法，二分查找法。

    //非常困哪

    //学习路线——二分查找的思想

    //基本思想，三个用一个做差，然后把其余的两个，做一下这个TwoSum的查找，然后返回这个东西里面，看看是不是出现了重复。用到一个函数叫做二分查找。
