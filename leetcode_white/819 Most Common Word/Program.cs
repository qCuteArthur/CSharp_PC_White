using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _819_Most_Common_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string paragraph = "Bob hit a ball, the ,hit, ,BALL flew far after it was hit.";
            string[] banned = { "hit" };
            Solution solution = new Solution();
            Dictionary<string, int> myDic = solution.MostCommonWord(paragraph,banned);
            Console.ReadLine();
        }
    }
    public class Solution
    {
        public Dictionary<string, int> MostCommonWord(string paragraph, string[] banned)
        {
            Dictionary<string, int> Times = new Dictionary<string, int>();
            string[] s = paragraph.Split(new char[] { ' ' });
            for (int i = 0; i < s.Length; i++)
            {
                if (Times.ContainsKey(s[i]))
                {
                    Times[s[i]]++;
                }
                else
                {
                    Times[s[i]] = 1;
                }
            }
            //根据键的顺序对于字典进行排序，并且在最后返回一个字典。
            return Times.OrderByDescending(r => r.Value).ToDictionary(r => r.Key, r => r.Value);

        }
    }
}
//目前会遇到的问题就是，单纯使用String.Split会导致和.或者,或者是？或者是！这种连接的字符串和字母一起分割，所以推荐的一种方式是正则表达式。
//此外，会出现一个大小的情况。也就是大小写进行转化的问题。
//目前我认为，肯定更可以通过一次循环来实现所有字符串的遍历，只需要进行比较苛刻的条件。

