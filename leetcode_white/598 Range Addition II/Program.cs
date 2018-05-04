using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _598_Range_Addition_II
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] nums = new int[2, 3];
            nums[0, 0] = 1;
            nums[0, 1] = 2;
            nums[1, 0] = 3;
            nums[1, 1] = 4;
            Console.WriteLine(nums.Length); 
            //主要考验的是在这里面操作这个数组的能力
        }
    }
    public class Solution
    {
        public int MaxCount(int m, int n, int[,] ops)
        {
            int[,] matrix = new int[m, n];
            int minOpx = ops[0,0];
            int minOpy = ops[0,1];
            for(int i = 1; i < (ops.Length/2); i++)
            {
                int opx = ops[i, 0];
                int opy = ops[i, 1];
                minOpx = (opx > minOpx) ? minOpx : opx;
                minOpy = (opy > minOpy) ? minOpy : opy;
                //其实本质上，是比较这些操作数最小的是多少。
                //怎么这都超过memory了！！！
            }
            return minOpx*minOpy;
        }
    }
}
