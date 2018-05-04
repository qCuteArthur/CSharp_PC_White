using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _565.Array_Nesting
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int ArrayNesting(int[] nums)
        {

        }
    }
    public class Solution2
    {
        public int ArrayNesting(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1) return nums.Length;
            //这个字典用于快速的，根据index就可以寻找到对应的value，初始化完成
            //一开始肯定是暴力搜索啊，因为你不知道自己的S的第一个元素到底是谁更合适，然后题目要求返回最长的数组。
            //已经排除了只有一个点的情况，nums数组中至少会有两个元素。
            List<int> array_length = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                HashSet<int> temp = new HashSet<int>();
                int currentIndex = i;
                temp.Add(currentIndex);
                int cts = 1;//temp.Count
                while (cts<nums.Length && (!temp.Contains(nums[currentIndex])))
                {
                    temp.Add(nums[currentIndex]);
                    currentIndex = nums[currentIndex];
                    cts++;
                }
                array_length.Add(cts);
                //其实你hashSet里面可以添加index，也可以添加index对应的value，都是可以的。
                //其实也可以无限添加，然后如果这一次的添加之后的hashSet的长度和上一次的HashSet相同，但是一个ContainsKey的判断会更加的简单。
            }
            return array_length.Max();
        }
    }
    public class Solution3
    {
        public int ArrayNesting(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1) return nums.Length;
            List<int> length = new List<int>();
            for(int i = 0; i < nums.Length; i++)
            {
                int[] cloneNums = new int[nums.Length];
                nums.CopyTo(cloneNums,0);
                int CurrentIndex = i;
                int cts = 0;
                while (cts < nums.Length && cloneNums[CurrentIndex] != -1)
                {
                    cloneNums[CurrentIndex] = -1;
                    CurrentIndex = nums[CurrentIndex];
                    cts++;
                }
                length.Add(cts);
            }
            return length.Max();
        }
    }
   //目前的最简化的方法，即使是那种swap的方法，由于需要创建新的数组，一样是非常的不方便。（慢）
    public class Solution4
    {
        public int ArrayNesting(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1) return nums.Length;
            int Max_Length = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int curentIndex = i;
                int cts = 1;
                while (nums[curentIndex] != i)
                {
                    curentIndex = nums[curentIndex];
                    cts++;
                }
                Max_Length = (Max_Length > cts) ? Max_Length : cts;
            }
            return Max_Length;
        }
    }
