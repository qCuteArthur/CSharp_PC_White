using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 动态规划
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Solution
    {
        public int ClimbStairs(int n)
        {
            if (n == 0 || n == 1) return n;
            int[] dp = new int[n];
            dp[0] = 1;
            dp[1] = 2;
            //dp[1]表示爬2级楼梯的状态
            for (int i = 2; i < n; i++)
            {
                //dp[i-1]表示爬n级楼梯的状态
                dp[i] = dp[i - 2] + dp[i - 1];
            }
            return dp[n - 1];
        }
    }
}
