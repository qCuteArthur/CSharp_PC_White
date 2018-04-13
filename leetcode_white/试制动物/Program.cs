using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试制动物
{
    class Program
    {
        static void Main(string[] args)
        {
            Animals animalCollection = new Animals();
            animalCollection.Add("Jack",new Cow("Jack"));
            animalCollection.Add("Vera",new Chicken("Bera"));
            foreach(Animal myAnimal in animalCollection)
            {
                Console.WriteLine("New {0} object added to custom collections,"+"Name {1}.",myAnimal.ToString(),myAnimal.Name);
            }
        }
    }
}
