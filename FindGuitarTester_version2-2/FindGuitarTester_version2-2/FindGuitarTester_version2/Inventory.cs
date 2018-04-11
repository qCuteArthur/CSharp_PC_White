using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version2
{
    class Inventory
    {
        private List<Guitar> guitars;
        public Inventory()
        {
            guitars = new List<Guitar>();
        }

        public void addGuitar(string serialNumber, double price, Builder_Enum builder, string model, Type_Enum type,
            Wood_Enum backWood, Wood_Enum  topWood)
        {
            Guitar guitar = new Guitar(serialNumber, price, builder, model, type, backWood, topWood);
            guitars.Add(guitar);
        }
        public Guitar getGuitar(string serialNumber)
        {
            for(int i= 0;i<guitars.Count;i++)
            {
                Guitar guitar = guitars[i];
                if (guitar.SerialNumber.Equals(serialNumber))
                    return guitar;
            }
            return null;
        }

        public List<Guitar> search(Guitar searchGuitar)
        {
            List<Guitar> matchGuitar = new List<Guitar>();
            for (int i=0;i<guitars.Count;i++)
            {
                Guitar guitar = guitars[i];
                Builder_Enum builder = searchGuitar.Builder;
                if (builder != guitar.Builder)
                    continue;
                string model = searchGuitar.Model.ToLower();
                if ((model != null) && (!model.Equals("")) &&
                    (!model.Equals(guitar.Model.ToLower())))
                    continue;
                Type_Enum type = searchGuitar.Type;
                if (type != guitar.Type)
                    continue;
                Wood_Enum backWood = searchGuitar.BackWood;
                if (backWood != guitar.BackWood)
                    continue;
                Wood_Enum topWood = searchGuitar.TopWood;
                if (topWood != guitar.TopWood)
                    continue;

                matchGuitar.Add(guitar);
            }
            return matchGuitar;
        }
    }
}
