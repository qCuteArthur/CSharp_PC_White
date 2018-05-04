using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _825.Friends_Of_Appropriate_Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ages = { 16, 17,18};
            Solution solution = new Solution();
            int result = solution.NumFriendRequests(ages);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public int NumFriendRequests(int[] ages)
        {
            if (ages.Length == 0 || ages.Length ==1) return ages.Length; 
            Array.Sort(ages);
            int cts = 0;
            //注意：如果三个条件满足一个就行了
            for(int i = 0; i < ages.Length-1; i++)
            {
                for(int j = i + 1; j < ages.Length; j++)
                {
                    if (ages[j] < 0.5 * ages[i] + 7)
                    {
                        cts++; continue;
                    }
                    if (ages[j] > ages[i])
                    {
                        cts++;continue;
                    }
                    if (ages[j]>100 && ages[i] < 100)
                    {
                        cts++;continue;
                    }
                }
            }
            return cts;
        }
    }


}
