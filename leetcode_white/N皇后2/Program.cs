using System;
using System.Collections.Generic;
using System.Linq;

namespace N皇后2
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution2 solution2 = new Solution2();
            List<IList<int>> ret = new List<IList<int>>();
            ret = solution2.MainFunc(8);
            foreach(var item in ret)
            {
                Console.WriteLine(ret);
            }
            Console.WriteLine("____________");
            Console.ReadLine();
        }
    }
    //主循环没有任何问题，但是就是如何从最后的情况退出循环。。。。。我们还停留在用return的情况，这个有点尴尬。。。
    public class Solution2
    {
        static int cts = 1;
        //这一点很重要，因为不同的putQueen里面的cts不一样
        public List<IList<int>> MainFunc(int Size)
        {

            List<int> Queen = new List<int>();
            List<IList<int>> ret = new List<IList<int>>();
            //处理一下特殊情况
            if (Size>1 && Size < 4)
            {
                return ret;
            }
            if(Size == 1)
            {
                List<int> QueenSp = new List<int>();
                QueenSp.Add(0);
                ret.Add(QueenSp);
                return ret;
            }

            Queen.Add(0);
            //如果是Queen满了，就进行一个输出
            PlaceQueen(ret, Queen, 0, ref cts, Size);
            ret.Add(Queen);
            int FirstQueen = Queen[0];
            FirstQueen++;
            Queen = new List<int>();
            cts = 0;

            while (FirstQueen!=Size-1)
            {      
                PlaceQueen(ret, Queen, FirstQueen, ref cts, Size);
                ret.Add(Queen);
                FirstQueen = Queen[0];
                FirstQueen++;
                Queen = new List<int>();
                cts = 0;
            }

            return ret;
        }
        public void PlaceQueen(List<IList<int>> ret ,List<int> Queen, int row, ref int cts, int Size)
        {
            //最终极的判断条件
            if (cts >= Size)
            {
                return;
            }
            if (row >= Size)
            {
                row = Queen.Last();
                row++;
                //删除最后一个元素，不知道能不能这样做。
                Queen.RemoveAt(Queen.Count-1);
                cts--;
                PlaceQueen(ret,Queen, row, ref cts, Size);
            }
            if (cts >= Size)
            {
                return;
            }
            //如果当前元素和以前的元素不会冲突 
            if (CheckQueen(Queen, row))
            {
                Queen.Add(row);
                cts++;
                row = 0;
                //如果成功的插入，就把row归零。cts++；
                PlaceQueen(ret,Queen, row, ref cts, Size);
            }
            else
            {
                row++;
                PlaceQueen(ret, Queen, row, ref cts, Size);
            }
        }
        //判断row位置的皇后是不是和其余的皇后位置发生冲突,true表示不冲突 
        public bool CheckQueen(List<int> Queen, int row)
        {
            //当前元素是Queen.Count的index
            //要检验行的情况和列的情况，以及斜的行的情况
            int CurrentColumnIndex = Queen.Count;
            for (int i = 0; i < Queen.Count; i++)
            {
                //默认的行的情况是不需要进行检验的。
                if (Queen[i] == row)
                {
                    return false;
                }
                if (Math.Abs(row - Queen[i]) == Math.Abs(CurrentColumnIndex - i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
