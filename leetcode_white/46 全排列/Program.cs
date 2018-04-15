using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//深度优先搜索，首先应该在逻辑上把这个东西当做一个二叉树来对应。
namespace _46_全排列
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> ret = new List<IList<int>>();
            Array.Sort(nums);

            List<int> wpt = new List<int>();
            List<int> usedNumber = new List<int>();
            PermuteDFS(nums, 0, usedNumber, wpt, ret);
            return ret;
        }
        //需要遍历的数组，当前遍历的层次，已经遍历过的数，工作指针，输出的二维列表。
        void PermuteDFS(int[] nums,int level,List<int>usedNumber,List<int>wpt,List<IList<int>> ret)
        {
            if (level == nums.Length)
            {
                ret.Add(wpt);
            }
            else
            {
                for(int i = 0; i < nums.Length; ++i)
                {

                }
            }
        }
    }
}
