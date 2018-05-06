using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _828.Unique_Letter_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "ABA";
            Solution solution = new Solution();
            int ret = solution.UniqueLetterString(s);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public int UniqueLetterString(string S)
        {
            if (S.Length == 0) return 0;
            char[] words = S.ToCharArray();
            long cts = words.Length;
            Dictionary<string, int> keyValuePairs= new Dictionary<string, int>();
            //字典中增加单个元素
            for(int i = 0; i < words.Length; i++)
            {
                if (!keyValuePairs.ContainsKey(words[i].ToString()))
                {
                    keyValuePairs.Add(words[i].ToString(), 1);
                }
            }
            ////////////////////////////////////////////////////////
            //暴力法如下所示：
            for(int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i].ToString();
                int currentValue = keyValuePairs[currentWord];
                int CurrentUniq = currentValue;
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (!currentWord.Contains(words[j]))
                    {
                        CurrentUniq +=1;
                    }
                    currentWord += words[j].ToString();
                    KeyValuePair<string,int> keyValuePair =new KeyValuePair<string, int>(currentWord,CurrentUniq);
                    if (!keyValuePairs.Contains(keyValuePair))
                    {
                        keyValuePairs.Add(currentWord, CurrentUniq);
                    }
                    cts += CurrentUniq;
                }
            }
            ///////////////////////////////////////////////////////
            //var dicSql = from item in keyValuePairs select item.Value;
            //foreach(var item in dicSql)
            //{
            //    cts += item;
            //}
            return (Int32)(cts%(Math.Pow(10,9)+7));
        }
        //没必要使用这个函数,这个函数的作用是，在暴力枚举出所有的元素之后，逐个进行判断。
        public int Uniq(string S)
        {
            char[] ret = S.ToCharArray();
            HashSet<char> vs = new HashSet<char>(ret);
            return (vs.Count());
        }
    }
}
//字串和字串之间的关系 以及 一个合理的用于存储的数据结构
