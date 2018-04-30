using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace N皇后_大佬作品
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Solution
    {
        public List<IList<int>> MainFunc(int Size)
        {
            List<IList<int>> ret = new List<IList<int>>();
            List<int> Queen = new List<int>(Size);
            PutQueen(Size, Queen, 0);
        }
    }
}
