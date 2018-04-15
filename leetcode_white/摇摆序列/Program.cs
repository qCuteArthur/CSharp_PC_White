using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//这里面就运用了自动机模型的一个想法，
//一共有三种状态以及4种相互之间的转化方式。
//其中，有Begin/Increase/Decrease,如果说是状态改变，其实就要加一。所以，从第一个元素开始是一定会增加1的。
//我自己是设置了一个flag判断当前的状态 和 previous_flag记录之前的状态。
//但是总是觉得不好啊。。。。。


namespace 摇摆序列
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = { 1, 3, 2, 5, 6, 7, 3, 4, 5, 2 ,10,1,-1,-5,3};
            Solution solution = new Solution();
            int ret = solution.Func2(sequence);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
    class Solution
    {
        public int Func(int[] nums)
        {
            if (nums.Length <= 2)
            {
                return nums.Length;
            }
            bool previous_flag = (nums[1] > nums[0]) ? true : false;
            int max_Length = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    max_Length++;
                    continue;
                }
                //默认是不会出现相等的情况的。。。出现了就麻烦了。。。。
                bool current_flag = (nums[i] > nums[i - 1]) ? true : false;
                if (current_flag == previous_flag)
                {
                    previous_flag = current_flag;
                    continue;
                }
                else
                {
                    previous_flag = current_flag;
                    max_Length++;
                    continue;
                }
            }
            return max_Length;
        }
        //使用自动机的思想进行操作。
        public int Func2(int[] nums)
        {
            if (nums.Length < 2)
            {
                return nums.Length;
            }
            const int BEGIN = 0;
            const int INCREASE = 1;
            const int DECREASE = -1;
            int STATE = BEGIN;
            int max = 0;
            for(int i = 1; i < nums.Length; i++)
            {
                switch (STATE)
                {
                    case BEGIN:
                        if (nums[i-1]<nums[i])
                        {
                            max++;
                            STATE = INCREASE;
                        }
                            else
                        {
                            max++;
                            STATE = DECREASE;
                        }
                        break;
                    case INCREASE:
                        if (nums[i -1] > nums[i])
                        {
                            max++;
                            STATE = DECREASE;
                        }
                        break;
                    case DECREASE:
                        if (nums[i - 1] < nums[i])
                        {
                            max++;
                            STATE = INCREASE;
                        }
                        break;
                }
            }
            return max;
        }
    }
}
