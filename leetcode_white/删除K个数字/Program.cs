using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 删除K个数字
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution2 solution2 = new Solution2();
            string nums = "1432219";
            int k = 3;
            string myNum = solution2.RemoveKdigits(nums, k);
            Console.WriteLine(myNum);
            Console.ReadLine();
        }
    }



    public class Solution
    {
        public string RemoveKdigits(string num, int k)
        {
            Stack<int> myStack = new Stack<int>();

            //注意：你这样直接push进去的话，结果会是一个
            foreach (var item in num)
            {
                //注意，0这个数字对应的ACSii码是30.
                myStack.Push(item-48);
                
            }
            //注意，子序列是不能改变原来元素的顺序的。所以要用Stack，就是为了保证元素的顺序不会改变。
            //所以我觉得可以尝试用两个Stack。
            int DeletedNumber = 0;
            while (DeletedNumber < k)
            {
                int currentMax = myStack.Max();
                StackDeleteNumber(myStack, currentMax);
                DeletedNumber++;
            }
            //保序删除K个元素。
            myStack.Reverse();
            int ret = 0;
            foreach(var item in myStack)
            {
                ret = ret * 10 + item;
            }
            return ret.ToString();
        }
        //从Stack中删除指定的元素。
        public void StackDeleteNumber(Stack<int> myStack,int currentMax)
        {
            Stack<int> tempStack = new Stack<int>();
            int item = 0;
            for (int i = 0; i < myStack.Count(); i++)
            {
                 item = myStack.Pop();
                if(item == currentMax)
                {
                    break;
                }
                else
                {
                    tempStack.Push(item);
                }
            }
            while (tempStack.Count != 0)
            {
                int item2 = tempStack.Pop();
                myStack.Push(item2);
            }
            //我觉得不用返回，因为Stack本身就是传递引用进来的。
        }
    }

    public class Solution2
    {
        public string RemoveKdigits(string num, int k)
        {
            Stack<int> tempStack = new Stack<int>();
            const int BEGIN = 0;
            const int USUAL = 1;
            int STATE = BEGIN;
            int cts =0;
            //尽可能保留小的元素，当你4想进来，先和1比较，比1大，进来，让你3想进来，比4小，4出去，3进来，当你2进来，比3小，2进来3出去，当你进来8,8比2大，8进来。

            //2018年4月16日04:11:09
            //首先把数字保存在数组中会比较好，因为你需要比较这个元素和下一个元素。
            //真的要用数组吗？用Stack不行么？

            foreach (var item in num)
            {
                if (cts == k)
                {
                    break;
                }
                switch (STATE)
                {
                    case BEGIN:
                        tempStack.Push(item - 48);
                        STATE = USUAL;
                        break;
                    case USUAL:
                        int TopNumber = tempStack.Pop();
                        if (TopNumber > item - 48)
                        {
                            tempStack.Push(TopNumber);
                            cts++;
                        }
                        else
                        {
                            tempStack.Push(item-48);
                        }
                        break;
                }
            }
            int retNumber = 0;
            foreach (var item in tempStack)
            {
                retNumber = retNumber * 10 + item;
            }
            return retNumber.ToString();
        }
    }

}
