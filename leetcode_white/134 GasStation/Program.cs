using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _134_GasStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] gas = { 1,2,3,3};
            int[] cost = { 2, 1, 5, 1 };
            int ret = solution.CanCompleteCircuit(gas,cost);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
    //这种方法超时了。
    public class Solution2
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            //gas Station的gas量是gas[i]
            //然后这些gas Station都是在一个circle上的
            //然后要花费cost[i]从gas[i]到gas[i+1]
            //BEGIN状态是空gas，在随机的一个站。
            //返回一个index，如果你从一个station开始可以环游这个大环。否则返回1.

            int totalGasGiven = 0;
            int totalCostGiven = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                totalGasGiven += gas[i];
                totalCostGiven += cost[i];
            }

            if (totalGasGiven < totalCostGiven)
            {
                return -1;     //对于所有的station进行遍历
            }
            //这怎么就变成贪心了呢？？？？？
            //绕一圈所要消耗的gas是一定的。
            for (int i = 0; i < gas.Length; i++)
            {
                //记录当前所经过的站的个数
                int MovingIndex = 0;
                int TotalFuel = 0;
                //在当前的始发站的情况下，如果我们没有说遇到index
                //当你的MovingIndex = gas.length的时候，说明你已经遍历了所有的站。
                while (TotalFuel >= 0)
                {
                    TotalFuel = TotalFuel + gas[i] - cost[i];
                    MovingIndex++;
                }
                if (MovingIndex == gas.Length)
                {
                    return i;
                }
                else
                {
                    continue;
                }
            }
            return -1;
        }
    }
    public class Solution
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            //第一点就是如果你总和的GAS小于综合的COST，是肯定不会到达的。
            //第二点就是如果当前的SUM+GAS-COST小于0，那么起点肯定在i之后。
            int InitialStation = 0;
            int Sum = 0;
            int Total = 0;
            //不断更换起始站
            for (int i = 0; i < gas.Length; i++)
            {
                Total += gas[i] - cost[i];
                Sum += gas[i] - cost[i];
                if (Sum < 0)
                {
                    //改变起始站，注意把起始的Sum变成0.
                    InitialStation = i+1;
                    Sum = 0;
                    continue;
                }
                else if (Sum >= 0)
                {
                    continue;
                }
            }
            if (Total < 0)
            {
                return -1;
            }
            else
            {
                return InitialStation;
            }
        }
    }
}
