using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp随机数的生成
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            //不指定种子，会使用当前时间作为种子

            int Seed = 6;
            Random random2 = new Random(Seed);
            //指定种子

            for (int i = 0; i < 10; i++)
            {
                int number = random.Next(1,9999);
                Console.WriteLine(number);
            }
            Console.ReadLine();
        }
    }
}
