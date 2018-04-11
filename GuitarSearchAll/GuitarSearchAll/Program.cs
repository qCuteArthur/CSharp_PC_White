using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace FindGuitarTester_version2
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            InitializeInventory(inventory);    

            GuitarSpec whatErinLikes = new GuitarSpec( Builder_Enum.FENDER, "Stratocastor", Type_Enum. ACOUSTIC, Wood_Enum.ALDER,  Wood_Enum.ALDER);


            //Type t = whatErinLikes.GetType();
            //PropertyInfo[] propertyInfos = t.GetProperties(whatErinLikes);
            //foreach (var prop in propertyInfos)
            //{
            //    Console.WriteLine("   {0} ({1}): {2}", prop.Name,
            //      prop.PropertyType.Name,
            //      prop.GetValue(whatErinLikes));
            //}


            inventory.GetProperties(whatErinLikes);
            //List<Guitar> matchingGuitar = inventory.Search(whatErinLikes);



            //if (matchingGuitar.Count != 0)
            //{
            //    Console.WriteLine("Erin, you might like these guitar:");
            //    for (int i = 0; i < matchingGuitar.Count; i++)
            //    {
            //        Guitar guitar = matchingGuitar[i];
            //        Console.WriteLine(" We have a " +
            //            guitar.Spec.Builder + " " + guitar.Spec.Model + " " +
            //        guitar.Spec.Type + " guitar:\n  " +
            //        guitar.Spec.BackWood + " back and sides,\n  " +
            //        guitar.Spec.TopWood + " top.\n You can have it for only $" +
            //        guitar.Price + "!\n ----");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Sorry, Erin, we have nothing for you.");
            //}
            Console.ReadKey();
        }

        private static void InitializeInventory(Inventory inventory)
        {
            GuitarSpec guitarSpec1 = new GuitarSpec(Builder_Enum.FENDER, "Stratocastor",
                                              Type_Enum.ACOUSTIC, Wood_Enum.ALDER, Wood_Enum.ALDER);
            inventory.AddGuitar("V95693", 1499.95,guitarSpec1);
            GuitarSpec guitarSpec2 = new GuitarSpec(Builder_Enum.FENDER, "Stratocastor",
                                              Type_Enum.ACOUSTIC, Wood_Enum.ALDER, Wood_Enum.ALDER);
            inventory.AddGuitar("V9512", 1549.95, guitarSpec2);
        }
    }
}
