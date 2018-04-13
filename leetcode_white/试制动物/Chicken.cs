using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试制动物
{
    class Chicken:Animal
    {
        public Chicken(string animalName):base(animalName)
        {
            Name = animalName;
        }
        public void LayEgg()
        {
            Console.WriteLine("{0} can lay eggs.",Name);
        }
    }
}
