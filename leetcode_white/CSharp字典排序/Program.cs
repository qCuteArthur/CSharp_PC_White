using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp字典排序
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    private void DictionarySort(Dictionary<string, int> dic)
    {
        var disSort = from dicObject in dic orderby dicObject.Value descending select dicObject;
        foreach(KeyValuePair<string,int> kvp in disSort)
        {
            Console.WriteLine("key:{0},value:{1}",kvp.Key,kvp.Value);
        }
    }
}
