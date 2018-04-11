using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version2
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            initializeInventory(inventory);    

            Guitar whatErinLikes = new Guitar("", 0, Builder_Enum.FENDER, "Stratocastor", 
                                              Type_Enum. ACOUSTIC, Wood_Enum.ALDER,  Wood_Enum.ALDER);

            List<Guitar> matchingGuitar = inventory.search(whatErinLikes);

            if (matchingGuitar.Count != 0)
            {
                Console.WriteLine("Erin, you might like these guitar:");
                for (int i = 0; i < matchingGuitar.Count; i++)
                {
                    Guitar guitar = matchingGuitar[i];
                    Console.WriteLine(" We have a " +
                        guitar.Builder + " " + guitar.Model + " " +
                    guitar.Type + " guitar:\n  " +
                    guitar.BackWood + " back and sides,\n  " +
                    guitar.TopWood + " top.\n You can have it for only $" +
                    guitar.Price + "!\n ----");
                }
            }
            else
            {
                Console.WriteLine("Sorry, Erin, we have nothing for you.");
            }
            Console.ReadKey();

        }

        private static void initializeInventory(Inventory inventory)
        {
            inventory.addGuitar("V95693", 1499.95, Builder_Enum.FENDER, "Stratocastor",
                Type_Enum. ACOUSTIC, Wood_Enum.ALDER, Wood_Enum.ALDER);
            inventory.addGuitar("V9512", 1549.95, Builder_Enum.FENDER, "Stratocastor",
                Type_Enum. ACOUSTIC, Wood_Enum.ALDER, Wood_Enum.ALDER);
        }
    }
}
