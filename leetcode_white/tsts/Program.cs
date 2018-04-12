using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tsts
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(Animal myAnimal in animalArrayList)
            {
                Console.WriteLine("New {0} object added to ArrayList collection,"+  "Name = {1}",myAnimal.ToString(),myAnimal.Name);
            }
        }
    }
}
