using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//用糖果去满足孩子，一个孩子只能用一个糖果，不可以两个糖果拼起来。使用size这些糖果，最多可以满足多少个孩子。
namespace 糖果满足孩子
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] need = {10,9,8,7};
            int[] size = { 10,9,8,7};
            Solution solution = new Solution();
            int ret = solution.FindContentChildren(need,size);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
    //当一个孩子可以被很多个糖果果满足，是不是应该优先照顾这个孩子。
    //当一个糖果可以满足多个孩子的时候，是不是应该首先使用这个糖果？
    class Solution
    {

        //s是size，g是需求
        public int FindContentChildren2(int[] g, int[] s)
        {
            if (g.Length == 0 || s.Length == 0)
            {
                return 0;
            }
            List<int> G = new List<int>(g);
            List<int> S = new List<int>(s);
            G.Sort();
            S.Sort();

            int cts = 0;
            for (int i = 0; i < G.Count(); i++)
            {
                for (int j = 0; j < S.Count(); j++)
                {
                    if (S[j] >= G[i])
                    {
                        cts++;
                        S[j] = -1;
                        S.Sort();
                        break;
                    }
                }
            }
            return cts;
        }
        public int FindContentChildren(int[] g, int[] s)
        {
            if (g.Length == 0 || s.Length == 0)
            {
                return 0;
            }
            List<int> G = new List<int>(g);
            List<int> S = new List<int>(s);
            G.Sort();
            S.Sort();

            int max = 0;
            int Gpointer = 0;
            //遍历每一个size
            for (int i = 0; i < S.Count(); i++)
            {
                if (S[i] >= G[Gpointer])
                {
                    max++;
                    Gpointer++;
                    if (Gpointer > G.Count() - 1)
                    {
                        break;
                    }
                }
            }
            return max;
        }
    }
}
//核心目标——用糖果满足更多的孩子。
//原则
//1. 如果糖果不能满足某个孩子，则这个糖果也不可以满足需要因子更大的孩子。
//2. 如果孩子可以被小糖果满足，就不要用大的。
//孩子的需求更小，更容易被满足，优先从需求小的孩子入手尝试，得到正确的结果。

    //所以算法应该是，小孩子，用小糖。
