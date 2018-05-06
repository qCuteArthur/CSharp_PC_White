using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _62_Unique_Path_I
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] memory = new int[10, 10];
            


            Solution solution = new Solution();
            int ret =solution.UniquePaths(3,2);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public int UniquePaths(int m, int n)
        {
            if (m == 0 && n == 0) return 0;
            if (m == 0) return n;
            if (n == 0) return m;
            int[,] memory = new int[m, n];
            //理论上应该是,这里面的所有的东西都已经被赋值为0了。
            memory[0, 0] = 1;
            int result = helper(m - 1, n - 1, ref memory);
            return result;
        }

        public int helper(int firstIndex, int secondIndex, ref int[,] memory)
        {
            if (firstIndex < 0 || secondIndex < 0) return 0;
            //if((firstIndex>memory.GetLength[0])&&(secondIndex>memory.GetLength[1])){
            //  return null;
            //}
            //应该没啥用吧。。。。我觉得first只可能小于0而不会出现越界的情况。。。。。
            if (memory[firstIndex, secondIndex] != 0) return memory[firstIndex, secondIndex];
            memory[firstIndex, secondIndex] = helper(firstIndex - 1, secondIndex, ref memory) + helper(firstIndex, secondIndex - 1, ref memory);
            return memory[firstIndex, secondIndex];
        }
    }
}
