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
            Solution solution2 = new Solution();
            //string nums = "1432219";
            //int k = 3;

            //string nums = "10200";
            //int k = 1;

            //string nums = "9";
            //int k = 1;

            //string nums = "112";
            //int k = 1;

            //string nums = "10";
            //int k = 1;

            //string nums = "1111111";
            //int k = 3;

            string nums = "1234567890";
            int k = 9;

            //对于12345，但是必须要删除一个元素的情况。对于贪心不用更改，但是剩余的部分要增加判断条件。
            string myNum = solution2.RemoveKdigits(nums, k);
            Console.WriteLine(myNum);
            Console.ReadLine();
        }
    }

    //2018年4月16日13:17:06
    //我觉得目前代码的逻辑过于复杂，无法有效操作


    public class Solution2
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

    public class Solution
    {
        public string RemoveKdigits(string num, int k)
        {
            //首先判断是不是空的
            if (num.Length == 0 || num.Length<=k)
            {
                return "0";
            }
            //创建一个Stack来应该输出的东西，我们这个算法是只增加输出的元素。
            Stack<int> tempStack = new Stack<int>();
            //对于删除的元素的个数计数，统计还可以继续删除的元素的个数
            int cts = k;
            //如果当前字符串比栈顶元素小，并且还可以继续删除元素，那么就将栈顶元素删掉，这样可以保证将当前元素加进去一定可以得到一个较小的序列．也可以算是一个贪心思想．最后我们只取前len - k个元素构成一个序列即可，如果这样得到的是一个空串那就手动返回０．还有一个需要注意的是字符串首字符不为０
            int LeftNumber = num.Length;
            foreach (var item in num)
            {
                if (tempStack.Count() == 0)
                {
                    tempStack.Push(item - 48);
                }
                //一开始剩余元素肯定是比你要删除的元素个数多，等到后来，会有一个时间节点，剩余元素跟删除的元素个数一样多。这个时候，全部删除，直接break应对123456这种情况。但是不包括210这种情况
                else if (LeftNumber == cts &&  tempStack.Peek()<=(item-48))
                {
                    break;
                }
                //如果还可以继续删除元素，并且栈顶的元素大于当前的元素，就删除栈顶的元素，然后把当前的元素push进去。
                else if (cts > 0 && tempStack.Peek() > (item - 48))
                {
                    tempStack.Pop();
                    tempStack.Push(item - 48);
                    cts--;
                    //已经做了一次元素的删除
                }
                else if (tempStack.Peek() <= (item - 48) || cts==0)
                {
                    tempStack.Push(item - 48);
                }
                LeftNumber--;
            }
            Stack<int> retStack = new Stack<int>();
            while (tempStack.Count != 0)
            {
                retStack.Push(tempStack.Pop());
            }

            string ret = "";

            if (retStack.Peek() == 0)
            {
                retStack.Pop();
            }
            while (retStack.Count != 0)
            {
                ret = ret + retStack.Pop();
            }
            if (ret.Length == 0)
            {
                ret = "0";
            }
            return ret;
        }
    }

    public class Solution3
    {
        public string RemoveKdigits(string num, int k)
        {
            //首先判断是不是空的
            if (num.Length == 0 || num.Length <= k)
            {
                return "0";
            }
            //创建一个Stack来应该输出的东西，我们这个算法是只增加输出的元素。
            Stack<int> tempStack = new Stack<int>();
            //对于删除的元素的个数计数，统计还可以继续删除的元素的个数
            int cts = k;
            //如果当前字符串比栈顶元素小，并且还可以继续删除元素，那么就将栈顶元素删掉，这样可以保证将当前元素加进去一定可以得到一个较小的序列．也可以算是一个贪心思想．最后我们只取前len - k个元素构成一个序列即可，如果这样得到的是一个空串那就手动返回０．还有一个需要注意的是字符串首字符不为０
            int LeftNumber = num.Length;
            foreach (var item in num)
            {
                if (tempStack.Count() == 0)
                {
                    tempStack.Push(item - 48);
                }
                //一开始剩余元素肯定是比你要删除的元素个数多，等到后来，会有一个时间节点，剩余元素跟删除的元素个数一样多。这个时候，全部删除，直接break应对123456这种情况。但是不包括210这种情况
                else if (LeftNumber == cts && tempStack.Peek() <= (item - 48))
                {
                    break;
                }
                //如果还可以继续删除元素，并且栈顶的元素大于当前的元素，就删除栈顶的元素，然后把当前的元素push进去。
                else if (cts > 0 && tempStack.Peek() > (item - 48))
                {
                    tempStack.Pop();
                    tempStack.Push(item - 48);
                    cts--;
                    //已经做了一次元素的删除
                }
                else if (tempStack.Peek() <= (item - 48) || cts == 0)
                {
                    tempStack.Push(item - 48);
                }
                LeftNumber--;
            }
            Stack<int> retStack = new Stack<int>();
            while (tempStack.Count != 0)
            {
                retStack.Push(tempStack.Pop());
            }

            string ret = "";

            if (retStack.Peek() == 0)
            {
                retStack.Pop();
            }
            while (retStack.Count != 0)
            {
                ret = ret + retStack.Pop();
            }
            if (ret.Length == 0)
            {
                ret = "0";
            }
            return ret;
        }
    }
}

