using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version1
{
    //枚举类型应该声明在和类相同
    public enum Builder { FENDER,MARTIN,GIBSON,COLLINGS,OLSON,RYAN,PRS,ANY};
    public enum Model : Byte { JUSTIN,ZOE}
    public enum Type_enum { ACOUSTIC,ELETRIC};
    public enum Wood_enum { INDIAN,CHINESE,WESTERN};
    public enum TopWoodEnum:Byte{ WOOD1=1,WOOD2,WOOD3};
    public enum Back_WoodEnum { INDIAN, CHINESE, WESTERN };

    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            InitializeInventory(inventory);    

            Guitar whatErinLikes = new Guitar(SerialNumberEnum.NUMBER1, 1499.95, Builder.ANY, Model.JUSTIN,
                Type_enum.ACOUSTIC, Back_WoodEnum.CHINESE, TopWoodEnum.WOOD1);

            Guitar guitar = inventory.Search(whatErinLikes);
            if(guitar != null)
            {
                Console.WriteLine("Erin, you might like this" +
                    guitar.Builder + " " + guitar.Model + " " +
                    guitar.Type + "guitar:\n  " +
                    guitar.BackWood + " back and sides,\n  " +
                    guitar.TopWood + " top.\nYou can have it for you $" +
                    guitar.Price + "!");
            }
            else
            {
                Console.WriteLine("Sorry, Erin, we have nothing for you.");
            }
            Console.ReadKey();
        }

        private static void InitializeInventory(Inventory inventory)
        {
            inventory.AddGuitar(SerialNumberEnum.NUMBER1, 1499.95, Builder.ANY,Model.JUSTIN,
                Type_enum.ACOUSTIC,Back_WoodEnum.CHINESE,TopWoodEnum.WOOD1);
        }
    }
}
