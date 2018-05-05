using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _746.Min_Cost_Climbing_Stairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] costs = { 0, 1, 1, 0 };
            Solution solution = new Solution();
            int ret = solution.MinCostClimbingStairs(costs);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            //这个东西是这样的，你可以选择从index0或者index1开始，但是你要付出代价
            if (cost.Length == 0) return 0;
            if (cost.Length == 1) return cost[0];
            if (cost.Length == 2) return Math.Min(cost[0], cost[1]);

            int[] dp = new int[cost.Length];
            //处理好边界条件
            dp[0] = cost[0];
            dp[1] = Math.Min(cost[0], cost[1]);
            for (int i = 2; i < cost.Length; i++)
            {
                //想到达当前的位置，你需要两种方式，要不就是从i-2上来，要不就是从i-1上来。
                dp[i] = Math.Min(dp[i - 2] + cost[i], dp[i - 1] + cost[i]);
            }
            //最后退出的时候，已经到达了最高的台阶,但是可以走i-1也可以走i-2上去
            return Math.Min(dp[cost.Length - 1], dp[cost.Length - 2]);
        }
    }
}
