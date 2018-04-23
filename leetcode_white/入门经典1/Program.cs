using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 入门经典1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 2, 3, 4, 5 };
            IEnumerable<int> lowNums = from item in nums where item < 10 select item;
            foreach(var item in lowNums)
            {
                Console.WriteLine("{0}",item);
            }
        }
    }
}
