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
    public class Solution
    {
        public int[,] MainMethod(int Size)
        {
            int[,] Array = new int[Size,Size];
            Generate(0,0,ref Array);
            return Array;
        }


        public void Generate(int x ,int y,ref int[,] Array)
        {
            PlaceQueen(x, y, ref Array);

            if(Array[x,y]== -1)
            {

            }
            else if (Array[x,y]==0)
            {

            }
            else if(Array[x,y]== 1)
            {

            }

            Generate(x+1,y+1,ref Array);
            Generate(x - 1, y - 1, ref Array);
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
