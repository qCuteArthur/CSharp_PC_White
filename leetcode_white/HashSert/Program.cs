using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSert
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int[]> myHashSet = new HashSet<int[]>();
            HashSet<int[]> myHashSet2 = new HashSet<int[]>();
            int[] myList = { 1, 2 };
            int[] myList2 = new int[] { 1, 2 };
            myHashSet.Add(myList);
            myHashSet2.Add(myList2);



            foreach(var item in myHashSet)
            {
                foreach(var subitem in item)
                {
                    Console.WriteLine(subitem);
                }
                Console.WriteLine("_________");
            }
            Console.WriteLine("+++++++");
            Console.ReadLine();
        }
    }
}
