using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_Search_Insert_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 3, 5, 6 };
            int target =4;
            Solution solution = new Solution();
            int ret = solution.SearchInsert(nums,target);
            Console.WriteLine(ret );
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            //如果可以找到，就返回idndex，如果找不到，就按照顺序插入，然后返回插入的位置。
            //我觉得可以用逻辑数组的一个思想做这件事情。
            int start = 0;
            int end = nums.Length - 1;
            int flag = 0;
            //我个人倾向于使用二分查找的方式来做
            while (start < end)
            {
                int middle = (end + start) / 2;
                if (nums[middle] < target)
                {
                    start++;
                    flag = 1;
                }
                else if (nums[middle] > target)
                {
                    end--;
                    flag = -1;
                }
                else if (nums[middle] == target)
                {
                    return middle;
                }
            }
            //如果到最后都没有找到的。就会运行下面的代码。
            int middle2 = (start + end) / 2;
            if (nums[middle2] < target)
            {
                return middle2 + 1;
            }
            else if(nums[middle2]>target)
            {
                return middle2 ;
            }
            return middle2;
        }
    }

}



//2018年4月16日13:04:13
//对于常数项剩余的情况
//我告诉你，你比别人多用时间在这上面，那你也要做的有结果，记住，只要不成功，之前花的时间都是白费的。
//只许成功不许失败