using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remove_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    //比较简单的一个题
    public class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            int start = 0;
            int end = nums.Length - 1;
            
            for(int i = 0; i < nums.Length; i++){
                if (nums[start] == val)
                {
                    nums[start] = nums[end];
                    end = end - 1;
                }
                else
                {
                    start = start + 1;
                }
            }
            //end+1就是当前元素的个数
            return end+1;
            //最差的情况，我要for循环length次。
         }
    }

    //这种逻辑上的新数组
    public class Solution2
    {
        public int RemoveElement(int[] nums,int val)
        {
            int j = 0;
            for(int i=0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[j] = nums[i];
                    j++;
                }
            }
            return j;
        }
    }
}
