using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Longest_Palindromic_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = "Justinwillfinallymarryzhangxiao";
            Solution solution = new Solution();
            string retString = solution.LongestPalindrome(myString);
            
        }
    }
    public class Solution
    {
        public string BruteLongestPalindrome(string s)
        {
            List<char> array = s.ToList();
            char[] items = array.ToArray();
            //字串的长度最少也要是2
            List<List<char>> Ret = null;
            for (int start = 0; start < s.Length-1; start++)
            {
                for(int end = 1; end < s.Length; end++)
                {
                    //据说前两个是获取最大的字串？使用Stack进行验证
                    Stack<char> myStack = new Stack<char>();
                    List<char> myList = new List<char>();
                    //在当前的字串中，把所有的元素push到Stack里面，出现重复的情况，就输出到List<char>里面。然后输出到List<List<char>>里面。
                    myStack.Push(items[start]);
                    for(int index= start+1; index <= end; index++)
                    {
                        if (myStack.Peek() == items[index])
                        {
                            myList.Add(myStack.Pop());
                            myList.Add(items[index]);
                        }
                    }
                    Ret.Add(myList);
                }
                //这里我需要使用LINQ，所以暂时就不要深入下去了。
            }
        }
        public string LongestPalindrome(string s)
        {
            if(s.Length <=1) return s;
            List<char> array = s.ToList();
            char[] items = array.ToArray();
            for(int i = 1; i < s.Length-1; i++)
            {
                if (items[i] == items[i + 1])
                {
                    
                }
            }
            return s;
        }
    }
}
