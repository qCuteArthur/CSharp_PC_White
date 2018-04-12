using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp中数组的传递
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 10, 20, 30 };
            ChangeValue(ref array);
            foreach(var item in array)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        static void ChangeValue(ref int []array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 100;
            }
        }
    }
}
