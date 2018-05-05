using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq分组
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 35, 43, 23, 42, 34, 234, 1, 23, 123 };
            var query = from number in numbers group number by number > 10;
            foreach(var group in query)
            {
                foreach(var item in group)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("_______");
            }
        }
    }
}
