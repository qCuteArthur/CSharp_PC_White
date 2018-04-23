using FindGuitarTester_version2.主程序;
using FindGuitarTester_version2.枚举类;
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

        public void Add(string serialNumber, double price, Builder_Enum builder, string model, Type_Enum type,
            Wood_Enum backWood, Wood_Enum  topWood,String_Enum numString)
        {
            GuitarSpec guitarSpec = new GuitarSpec(builder, model, type, backWood, topWood, numString);
            Guitar guitar = new Guitar(serialNumber, price,guitarSpec);
            guitars.Add(guitar);
        }
        public Guitar GetGuitar(string serialNumber)
        {
            for(int i= 0;i<guitars.Count;i++)
            {
                Guitar guitar = guitars[i];
                if (guitar.SerialNumber.Equals(serialNumber))
                    return guitar;
            }
            return null;
        }

        public List<Guitar> Search(GuitarSpec searchSpec)
        {
            List<Guitar> matchGuitar = new List<Guitar>();
            for (int i=0;i<guitars.Count;i++)
            {
                Guitar guitar = guitars[i];
                Builder_Enum builder = searchSpec.Builder;
                if (builder != guitar.Spec.Builder)
                    continue;
                string model = searchSpec.Model.ToString();
                if ((model != null) && (!model.Equals("")) &&
                    (!model.Equals(guitar.Spec.Model.ToLower())))
                    continue;
                Type_Enum type = searchSpec.Type;
                if (type != guitar.Spec.Type)
                    continue;
                Wood_Enum backWood = searchSpec.BackWood;
                if (backWood != guitar.Spec.BackWood)
                    continue;
                Wood_Enum topWood = searchSpec.TopWood;
                if (topWood != guitar.Spec.TopWood)
                    continue;
                String_Enum numString = searchSpec.NumString;
                if (numString != guitar.Spec.NumString)
                    continue;
                matchGuitar.Add(guitar);
            }
            return matchGuitar;
        }
            //准备这个Inventory类的一个重载。声明一个InvenrotySpec类
    }
}
