using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] height = { 0, 2,4,2,1,3,4,5,2,4,5,3,2 };
            int ret = Solution.MaxArea(height);
            Console.WriteLine(ret);
        }
    }
    //首先验证是不是都是正数。不要是空的。
    //注意：直线不一定相临近，并且要考虑X轴。
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            if(height.Length <2)
            {
                return 0;
            }
            //每个容器的最多的水量，由两边的大小决定
            //所以我们首先是判断各个容器的大小。
            //就是排序的一个应用
            //int number = (height.Length * (height.Length - 1)) / 2;

            int[,] array = new int[height.Length,height.Length];
            for(int i = 0; i < height.Length; i++)
            {
                for (int j = 0; j < height.Length; j++)
                {
                    if (height[i] < height[j]) array[i, j] = (height[i]) * (j - i);
                    else array[i, j] = (height[j]) * (j - i);
                }
            }
            //array(i,j) 表示直线i和直线j构成的面积
            int retX = 0;
            int retY = 0;
            
            int max = array[retX, retY];
            for (int positionX = 0; positionX < height.Length; positionX++)
            {
                for (int positionY = 0;positionY < height.Length; positionY++)
                {
                    if (array[positionX, positionY] == -1)
                    {
                        continue;
                    }

                    if(array[positionX, positionY] > max)
                    {
                        max = array[positionX, positionY];
                        retX = positionX;
                        retY = positionY;
                    }
                    else
                    {
                        array[positionX, positionY] = -1;
                    }
                }
            }
            return max;
        }
    }


}
//这里面需要使用的就是动态规划。。。。
//暴力法，结果很不理想。
