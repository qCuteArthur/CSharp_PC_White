using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _54_Jump_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3,2,1,0,4 };
            Solution solution = new Solution();
            Console.WriteLine(solution.CanJump(nums));
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public bool CanJump(int[] nums)
        {
            int Length = nums.Length;
            int curPos = 0;
            while (curPos < Length-1)
            {

                curPos = curPos + nums[curPos];
                
            }
            return (curPos == (Length-1) ? true : false);
        }
    }
}
