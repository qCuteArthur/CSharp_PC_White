using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _78_SubSet
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IList<int>> ret = new List<IList<int>>();
            Solution3 solution = new Solution3();
            int[] nums = {1,2,3};
            ret = solution.Subsets(nums) as List<IList<int>>;
            Console.WriteLine(ret.Count());
            Console.WriteLine("++++++++++++");
            foreach(var item in ret)
            {
                foreach(var subItem in item)
                {
                    Console.WriteLine(subItem);
                }
                Console.WriteLine("——————————————————————————");
            }
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> ret = new List<IList<int>>();
            List<int> empty = new List<int>();
            ret.Add(empty);
            if (nums.Length == 0)
            {
                return ret;
            }
            //要求：必须按照升序 并且在一个subset里面的元素不可以包含重复的元素
            Array.Sort(nums);
            List<int> Cur = new List<int>();
            Generate(0, Cur, ret, nums);
            return ret;
        }
        //既然是递归，你需要告诉下面的就是你当前需要递归的东西
        //根据StartIndex在nums数组里面挑选元素
        //我们需要把什么输入这个递归函数？我觉得包括你当前层次的数组，总数组和当前层位进行判断的元素。
        //也就是说，你当前层位是1层，你需要进行下一层的2的判断，所以你要输入2 ，你当前的1的结果以及 总的数组ret
        public void Generate(int JudgingIndex, List<int> Cur, List<IList<int>> ret, int[] nums)
        {
            //如果你一共有三个元素，然后你当前判定的index是3，就要结束了。
            if(JudgingIndex > nums.Length-1)
            {
                return;
            }
            
            List<int> newCur = new List<int>(Cur);
            newCur.Add(nums[JudgingIndex]);
            List<int> newCur2 = new List<int>(Cur);
            //创两个副本，一个副本是增加了当前层次元素的东西，一个副本是原原本本的复制原来的东西。

            ret.Add(newCur);
            //一旦你把这个newCur传递进去，你就要知道，newCur已经被更改了，这以后就不能用newCur了。
            Generate(JudgingIndex + 1, newCur, ret, nums);
            //这样也保证了Cur的不改变，如果先remove后Add，恐会改变上次的东西。
            //我个人觉得没必要增加Add(Cur)，因为Cur在remove之后，跟传进来的时候一个样子，就好比[1,2]传进第三层，没必要再Add一次。除非你用HashSet
            Generate(JudgingIndex + 1, newCur2, ret, nums);
            //newCur是加的版本，newCur2是不加的版本，但是无论如何，都要创建副本。
            //创建副本，确保在更深层的循环中不会更改原来的Cur
            return;
        }
    }
    //不要出现重复的元素
    public class Solution2
    {
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            //相对于上一个题目，绝对不可以包含重复的元素。
            //如果下一层和当前这层元素相相同，应该想办法跳过
            List<IList<int>> ret = new List<IList<int>>();
            List<int> Cur = new List<int>();
            ret.Add(Cur);
            if (nums.Length == 0)
            {
                return ret;
            }
            if (nums.Length == 1)
            {
                ret.Add(new List<int>(nums[0]));
                return ret;
            }
            //其实就是如果下一层和上一层相同，就跳出循环，但是对于最后一层的判断要额外注意
            int JudgingNumber = 0;
            Generate(JudgingNumber, Cur, ret, nums);
            return ret;
        }
        public void Generate(int JudgingNumber, List<int> Cur, List<IList<int>> ret, int[] nums)
        {
            if (JudgingNumber > nums.Length - 1)
            {
                return;
            }
            List<int> newCur = new List<int>(Cur);
            newCur.Add(nums[JudgingNumber]);
            List<int> newCur2 = new List<int>(Cur);

            ret.Add(newCur);
            Generate(JudgingNumber + 1, newCur, ret, nums);
            //我的判断是，如果JudgingNumber和和nums.Length-1一样大，也就是JudgingNumber是最后一个元素了，就会退出了。

            if ((JudgingNumber != nums.Length - 1) && nums[JudgingNumber] == nums[JudgingNumber + 1])
            {
                return;
            }
            if ((JudgingNumber == nums.Length - 1) && nums[JudgingNumber] == nums[JudgingNumber - 1])
            {
                return;
            }
            Generate(JudgingNumber + 1, newCur2, ret, nums);
            return;
        }
    }
    //注意：统一使用绝对Index.
    public class Solution3 
    {
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> ret = new List<IList<int>>();
            List<int> cur = new List<int>();
            ret.Add(cur);
            if (nums.Length == 0)
            {
                return ret;
            }
            //增加一个空的数组
            Array.Sort(nums);
            //上面都是常规处理
            for(int index = 0; index < nums.Length; index++)
            {
                //由于我们需要对于每个数据来增加一个结尾,用foreach就行了
                //注意，C#中的集合修改之后，会被编译器认为是无法枚举
                List<IList<int>> CopyRet = new List<IList<int>> ();
                foreach(var item in ret)
                {
                    CopyRet.Add(item);
                }
                
                int CurrentLength = CopyRet.Count();
                for(int i = 0; i < CurrentLength; i++)
                {
                    //这一步，仍然会严重的修改原来的ret的东西。
                    CopyRet[i].Add(nums[index]);
                    ret.Add(CopyRet[i]);
                }
            }
            return ret;
        }
    }
}
