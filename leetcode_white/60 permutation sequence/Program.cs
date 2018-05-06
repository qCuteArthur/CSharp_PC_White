using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _60_permutation_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            solution.GetPermutation(3,3);

            string s = "juwf";
            s.ToArray();
            Console.ReadLine();
            

        }
    }
    //使用仿照八皇后的方法写这个递归
    public class Solution
    {
        public  string GetPermutation(int n, int k)
        {
            if (factorial(n) < k) return "";
            //i表示的是当前遍历的index
            List<List<int>> ret = new List<List<int>>();
            List<int> array = new List<int>();
            //使用回溯法，在你做出了全部的枚举之前，k都是没啥卵用的
            func(n,ref array, ref ret);
            List<int> vs = ret.ElementAt(k);
            string S = "";
            foreach(var item in vs)
            {
                S += item;
            }
            return S;
        }
        public void func(int n,ref List<int> array, ref List<List<int>> ret)
        {
            if (ret.Count() == factorial(n)) return;
            if (array.Count() == n)
            {
                ret.Add(array);
                array = new List<int>(array);
                array.RemoveAt(array.Count() - 1);
                return;
            }
            for (int i = 0; i < n; i++)
            {
                if (!array.Contains(i))
                {
                    array.Add(i);
                    func(n,ref array,ref ret);  
                }
            }
            if (array.Count() == 0)
            {
                return;
            }
            array.RemoveAt(array.Count()-1);
            return;
        }
        public int factorial(int n)
        {
            int ret = 1;
            for (int i = 1; i <= n; i++)
            {
                ret *= i;
            }
            return ret;
        }
    }

    public class Solution2
    {
        public string GetPermutation(int n, int k)
        {
            if (factorial(n) < k) return "";
            //i表示的是当前遍历的index
            List<List<int>> ret = new List<List<int>>();
            List<int> array = new List<int>();
            //使用回溯法，在你做出了全部的枚举之前，k都是没啥卵用的
            func(n, ref array, ref ret);
            List<int> K_ret = ret.ElementAt(k);
            string S = "";
            foreach (var item in K_ret)
            {
                S += item;
            }
            return S;
        }
        public void func(int n, ref List<int> array, ref List<List<int>> ret)
        {
            if (ret.Count() == factorial(n)) return;
            if (array.Count() == n)
            {
                ret.Add(array);
                array = new List<int>(array);
                array.RemoveAt(array.Count() - 1);
                return;
            }
            for (int i = 0; i < n; i++)
            {
                if (!array.Contains(i))
                {
                    array.Add(i);
                    func(n, ref array, ref ret);
                }
                continue;
            }
            if (array.Count() == 0)
            {
                return;
            }
            array.RemoveAt(array.Count() - 1);
            return;
        }
        public int factorial(int n)
        {
            int ret = 1;
            for (int i = 1; i <= n; i++)
            {
                ret *= i;
            }
            return ret;
        }
    }
}
