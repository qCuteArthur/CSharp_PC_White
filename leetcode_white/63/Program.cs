using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _63
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
        public class Solution
        {
            public int UniquePathsWithObstacles(int[,] obstacleGrid)
            {
                //参数：int[,]中的1表示这个点是障碍物
                if (obstacleGrid.Length == 0) return 0;
                int FirstDimention = obstacleGrid.GetLength(0);
                int SecondDimention = obstacleGrid.GetLength(1);
                List<List<int>> memory = new List<List<int>>();
                //////////////////////////////////////////
                for (int first = 0; first < FirstDimention; first++)
                {
                    for (int second = 0; second < SecondDimention; second++)
                    {
                        memory[first][second] = -1;
                    }
                }
                memory[0][0] = 1;
                int ret = UniquePathsWithObstacles(obstacleGrid, FirstDimention - 1, SecondDimention - 1, ref memory);
                /////////////////////将memory矩阵全部设置为-1//////////////////////
                return ret;
            }
            //函数重载
            //论到达first second的位置，要多长。
            public int UniquePathsWithObstacles(int[,] obstacleGrid, int first, int second, ref List<List<int>> memory)
            {
                if (first < 0 || second < 0) return 0;
                if (first > (obstacleGrid.GetLength(0) - 1) && (second > (obstacleGrid.GetLength(1) - 1)))
                {
                    return 0;
                }
                if (memory[first][second] != -1)
                {
                    return memory[first][second];
                }
                else
                {
                    memory[first][second] = UniquePathsWithObstacles(obstacleGrid, first - 1, second,ref memory) + UniquePathsWithObstacles(obstacleGrid, first, second - 1, ref memory);
                }
                return memory[first][second];
            }
        }
}
