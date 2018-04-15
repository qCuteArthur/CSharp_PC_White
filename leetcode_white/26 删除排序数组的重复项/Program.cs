using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//同样是基于逻辑数组的概念，一部分原因也是因为in place
namespace _26_删除排序数组的重复项
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array =new int[] {1,1, 2};
            Solution2 solution = new Solution2();
            int ret = solution.RemoveDuplicates(array);

            Console.WriteLine(ret);
            Console.WriteLine("+++++++++++++");

            foreach(var item in array)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0 || nums.Length ==1){
                return nums.Length;
            }
            int wpt = 0;
            int cts = 0;
            //-1
            for(int i = 0; i < nums.Length-1; i++)
            {
                if(nums[i] == nums[i+1])
                {
                }
                else
                {
                    cts++;
                }
                nums[cts] = nums[i + 1];
            }
            //+1
            return cts+1;
        }
    }
    //这种方法超过了空间复杂度。。。。因为原题要求你不能使用额外的空间。
    public class Solution2
    {
        //直接hashSet
        public int RemoveDuplicates(int[] nums)
        {
            HashSet<int> myHashSet = new HashSet<int>();
            foreach(var item in nums)
            {
                myHashSet.Add(item);
            }
            nums =new int[myHashSet.Count];
            int i = 0;
            foreach(var item in myHashSet.Take(myHashSet.Count))
            {
                nums[i] = item;
                i++;
            }
            return myHashSet.Count;
        }
        //最后的结果虽然对，虽然都很理想，但是有一个问题，这个东西，新创建的数组是一个局部变量。也就是说，你注定是返回不出来的，也就是你原来的东西，注定是不会改变的。
    }
}
