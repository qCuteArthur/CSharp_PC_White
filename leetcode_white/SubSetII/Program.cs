using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubSetII
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            List<IList<int>> ret = new List<IList<int>>();
            int[] nums = { 1, 2, 2 };
            ret = solution.SubsetsWithDup(nums) as List<IList<int>>;
            Console.WriteLine("_________");
            foreach(var item in ret)
            {
                foreach(var subitem in item)
                {
                    Console.WriteLine(subitem);
                }
                Console.WriteLine("+++++++++++++");
            }
            Console.WriteLine("_____________");
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            List<IList<int>> ret = new List<IList<int>>();
            HashSet<List<int>> myHashSet = new HashSet<List<int>>();
            List<int> Cur = new List<int>();
            ret.Add(Cur);
            if (nums.Length == 0)
            {
                return ret;
            }
            Array.Sort(nums);
            int JudgingIndex = 0;
            Generate(JudgingIndex,nums,Cur,myHashSet);
            foreach(var item in myHashSet)
            {
                ret.Add(item);
            }
            return ret;
        }
        public void  Generate(int JudgingIndex,int[] nums,List<int> cur,HashSet<List<int>> myHashSet)
        {
            if (JudgingIndex > nums.Length - 1)
            {
                return;
            }
            List<int> newCur = new List<int>(cur);
            List<int> newCur2 = new List<int>(cur);
            newCur.Add(nums[JudgingIndex]);
            newCur.Sort();
            myHashSet.Add(newCur);
            Generate(JudgingIndex + 1, nums, newCur, myHashSet);
            Generate(JudgingIndex +1,nums,newCur2,myHashSet);
            return;
        }
    }
}
