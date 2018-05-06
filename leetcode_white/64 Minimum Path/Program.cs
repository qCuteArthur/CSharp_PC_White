using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64_Minimum_Path
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] input = { { 1, 3, 1 }, { 1, 5, 1 }, { 4, 2, 1 } };
            int[,] input = { { 0, 0 }, { 0, 0 } };
            Solution solution = new Solution();
            int ret = solution.MinPathSum(input);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public int MinPathSum(int[,] grid)
        {
            if (grid.Length == 0) return 0;
            if (grid.Length == 1) return grid[0, 0];
            int firstDim = grid.GetLength(0);
            int secondDim = grid.GetLength(1);
            int[,] memory = new int[firstDim, secondDim];
            memory[0, 0] = grid[0, 0];
            int ret = helper(grid, firstDim - 1, secondDim - 1, ref memory);
            return ret;
        }
        public int helper(int[,] grid, int x, int y, ref int[,] memory)
        {
            if (x < 0 || y < 0) return Int32.MaxValue;
            if (memory[x, y] != 0) return memory[x, y];
            else
            {
                memory[x, y] = grid[x, y] + Math.Min(helper(grid, x - 1, y, ref memory), helper(grid, x, y - 1, ref memory));
            }
            return memory[x, y];
        }
    }
}
