using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _213.House_Robber_II
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1,1,1};
            Solution solution = new Solution();
            int result = solution.Rob(array);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return Math.Max(nums[0], nums[1]);
            //////////////////////////////至少也是3以上的结果了。
            return Math.Max(Rob(nums, 0, nums.Length - 2), Rob(nums, 1, nums.Length - 1));
        }
        //真牛逼了你，还用上重载了你。Nubility啊。
        //{1,1,1}的传入方式

        public int Rob(int[] nums,int start,int end)
        {
            if (end - start == 0) return nums[start];
            if (end - start == 1) return Math.Max(nums[start],nums[start+1]);

            int[] Dp = new int[end-start+1];
            //创建一个多么多么大的一个数组
            //不管你的数组多大，都要重新确定边界条件
            Dp[start] = nums[start];//相当于Dp[0]
            Dp[start+1] = Math.Max(nums[start],nums[start+1]);//相当于Dp[1]

            //我发现{1,1,1}这种应该返回2的，结果却返回了1，主要是因为传统的i = start+2的思路的影响。因为start+2直接就是end了好不好啊。

            for(int i = start+2; i < end; i++)//相当于是Dp2了。。。。
            {
                //Dp[start+2] = Math.Max(Dp[start+1],Dp[start]); 
                Dp[i] = Math.Max(Dp[i-1],Dp[i-2]+nums[i]);
            }
            return Dp.Max();
        }
    }


}
