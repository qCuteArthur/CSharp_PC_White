using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq排序
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "the", "jsutin", "loves", "neverletyougo", "zhangxiao" };
            //按照长度升序
            IEnumerable<string> query = from word in words orderby word.Length descending select word;
            IEnumerable<string> query2 = from word in words orderby word.Length descending, word.Substring(0, 1) descending select word;
        }
    }
}
