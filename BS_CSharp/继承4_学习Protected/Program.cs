using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib_继承4;
namespace 继承4_学习Protected
{
    class Program
    {
        static void Main(string[] args)
        {
            SmallCar sm = new SmallCar("Audi");
            sm.Accelerate();
            Console.WriteLine(sm.Speed);
        }
    }
}
