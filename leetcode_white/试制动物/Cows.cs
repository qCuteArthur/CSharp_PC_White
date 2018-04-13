using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试制动物
{
    class Cow:Animal
    {
        public Cow(string animalName):base(animalName)
        {
            Name = animalName;
        }
        public void Milk()
        {
            Console.WriteLine("{0} can produce milk.",Name);
        }
    }
}
