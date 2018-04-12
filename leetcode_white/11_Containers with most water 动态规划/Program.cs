using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//最简单的就是一个一个划分存储空间，而更加适合的情况就是从两边开始同时向中间进行
//其实这个并是动态规划，而是简单的搜索
namespace _11_Containers_with_most_water_动态规划
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = { 1, 2, 4, 3 };
            Solution solution = new Solution();
            int max = solution.MaxArea(size);
            Console.WriteLine(max);
        }
    }

    public class Solution
    {
        public int MaxArea(int[] height)
        {
            if (height.Length < 2)
            {
                return 0;
            }
            int leftBoundary = 0;
            int rightBoundary = height.Length-1;
            //注意是取小的
            int maxSize= (rightBoundary - leftBoundary) * Math.Min(height[leftBoundary], height[rightBoundary]);
            int currentSize = 0;
            //注意节制条件！！注意等号的方向！
            while (leftBoundary <= rightBoundary)
            {
                if (height[leftBoundary] > height[rightBoundary])
                {
                    currentSize = (rightBoundary - leftBoundary) * height[rightBoundary];
                    maxSize = (maxSize < currentSize) ? currentSize : maxSize;
                    rightBoundary--;
                }
                else
                {
                    currentSize = (rightBoundary - leftBoundary) * height[leftBoundary];
                    maxSize = (maxSize < currentSize) ? currentSize : maxSize;
                    leftBoundary++;
                }
            }
            return maxSize;
        }
    }

}
