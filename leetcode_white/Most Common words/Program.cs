using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Most_Common_words
{
    class Program
    {
        static void Main(string[] args)
        {
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            //处理除了字母之外的字符，包括常见标点符号，空格、换行符和EOF.
            


            foreach(var item in strs)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            //其实就是正则化的匹配，把你这个东西，分解成为数组
            //用正则表达式获取一个段落中的所有单词
            if(paragraph.Length == 0){
                return "";
            }
            string myString = "";
            for (int i = 0; i < paragraph.Length; i++)
            {
                if (((paragraph[i] <= 90) && (paragraph[i] >= 65)) || ((paragraph[i] >= 97) && (paragraph[i] <= 122)))
                {
                    myString+=paragraph[i];
                }
                else
                {
                    if (keyValuePairs.ContainsKey(myString))
                    {
                        keyValuePairs[myString]++;
                    }
                    else
                    {
                        keyValuePairs.Add(myString,1);
                    }
                    myString = "";
                }
            }

            //使用linq进行排序
        }
    }
    //使用String.ToLower和String.ToUpper可以改变元素的一个大小写情况。
    //65~90 97~122是大小写字母的一个范围。
}
