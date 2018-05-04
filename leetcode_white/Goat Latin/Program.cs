using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goat_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence =  "I speak Justin, zhang xiao ,of course,Goat Latin." ;
            string sentence2 = "I speak Goat Latin";
            //将string分割为string[]
            //string[] array = sentence.Split(new char[] { ' '  ,  ','  ,  '.'},StringSplitOptions.RemoveEmptyEntries);

            //string item = "apple";
            //string subString = item.Substring(1);
            //string newSentence = item.Remove(1);
            //item = subString + newSentence;
            //Console.WriteLine(item);

            Solution solution = new Solution();
            string ret =solution.ToGoatLatin(sentence2);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
    /// <summary>
    /// 首先要处理的就是标点符号，如何按照一个字母分割一个句子。
    /// </summary>
    public class Solution
    {
        public string ToGoatLatin(string S)
        {
            string ret = null;
            string[] array = S.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            //原题不要求大小写的改变
            for (int i = 0; i < array.Length; i++)
            {
                char item = array[i].First();
                if (item == 'a' || item == 'e' || item == 'i' || item == 'o' || item == 'u' || item == 'A' || item == 'E' || item == 'I' || item == 'O' || item == 'U')
                {
                    array[i] += "ma";
                }
                else if (array[i].Count() == 1)
                {
                    array[i] += "ma";
                }
                else
                {
                    string SubString = array[i].Substring(1);
                    string firstLetter = array[i].Remove(1);
                    array[i] = SubString + firstLetter + "ma";
                }
                for (int k = 0; k < i + 1; k++)
                {
                    array[i] += "a";
                }
            }
            ret = null;
            int m = 0;
            for (; m < array.Length; m++)
            {
                ret += array[m];
                if (m != array.Length - 1)
                {
                    ret += " ";
                }
            }
            return ret;
        }
    }
}
