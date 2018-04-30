using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N皇后
{
    class Program
    {
        static void Main(string[] args)
        {
            int Size = 8;
            //int[,] Array = new int[Size,Size];
            Solution solution = new Solution();
            solution.MainMethod(Size);
            //for (int i = 0; i < Size; i++)
            //{
            //    for (int j = 0; j < Size; j++)
            //    {
            //        if (Array[i, j] == -1) { Console.Write("."); }
            //        if (Array[i, j] == 0) { Console.Write("0"); }
            //    }
            //    Console.WriteLine();
            //}
            Console.ReadLine();
        }
    }
    //x表示的是行号，y表示的是列号。
    public class Solution
    {
        public int[,] MainMethod(int Size)
        {
            int[,] Array = new int[Size,Size];
            Generate(0,0,ref Array,Size);
            return Array;
        }


        public void Generate(int x ,int y,ref int[,] Array,int Size)
        {
            if(x >= Size)
            {
                return;
            }
            //一开始在0 0 位置放置元素，并且更改棋盘。
            //下一步是更改x和y的值。
            PlaceQueen(x, y, ref Array);
            if(Array[x,y]== -1)
            {
                if (y < Size) y = y + 1;
                //如果出现了else的情况，说明遍历了半天也没有遍历到合适的位置，返回上一行
                else
                {
                    x = x - 1;
                    y = 0;
                    //如果此时回到了 0 0，会陷入死循环。
                }
            }
            else if (Array[x,y]==0)
            {

            }
            else if(Array[x,y]== 1)
            {
                x = x + 1;
                y = 0;
                //将当前点移动到下一行
            }
        }
        //用于放置元素
        public void PlaceQueen(int x, int y, ref int[,] Array)
        {
            int[] dx = { 1, 1, 1, 0, 0, -1, -1, -1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int ArraySize = (Int32)Math.Sqrt(Array.Length);
            int OriginX = x;
            int OriginY = y;
            for (int i = 0; i < 8; i++)
            {
                Array[x, y] = -1;
                for (int j = 0; j < ArraySize; j++)
                {
                    x += dx[i];
                    y += dy[i];
                    if (x >= 0 && x < ArraySize && y >= 0 && y < ArraySize)
                    {
                        Array[x, y] = -1;
                    }
                    else
                        break;
                }
                x = OriginX;
                y = OriginY;
            }
        }
    }
   
}


namespace QueensSolution
{
    class Program
    {
        static int count = 0;
        static void Main(string[] args)
        {
            //卧槽，读取console的输入数字的神器！
            int n = Int32.Parse(Console.ReadLine());
            //其实只需要记录皇后的列号就行了。
            List<int> queen = new List<int>(n);
            for (int i = 1; i <= n; i++)
            {
                queen.Add(0);
            }
            PutQueen(n, queen, 0);
            Console.WriteLine(count);
            Console.ReadKey();
        }
        //n应该是总的大小，row是当前的列号，PutQueen就是用来防止皇后的
        private static void PutQueen(int n, List<int> queen, int row)
        {
            for (queen[row] = 1; queen[row] <= n; queen[row]++)
            {
                if (CheckQueens(queen, row))
                {
                    row++;
                    if (row < n)
                    {
                        PutQueen(n, queen, row);
                    }
                    else
                    {
                        count++;
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write(queen[i].ToString() + " ");
                        }
                        Console.WriteLine();
                    }
                    row--;
                }
            }
        }
        //检验当前的皇后放置方式是不是有问题 
        private static bool CheckQueens(List<int> queen, int row)
        {
            for (int i = 0; i < row; i++)
            {
                if (Math.Abs(queen[i] - queen[row]) == Math.Abs(i - row) || queen[i] == queen[row])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
