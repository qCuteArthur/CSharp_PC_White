using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindGuitarTester_version1
{
    class Inventory
    {
        private List<Guitar> guitars;
        public Inventory()
        {
            guitars = new List<Guitar>();
        }

        public void AddGuitar(SerialNumberEnum serialNumber, double price, Builder builder, Model model, Type_enum type,
            Back_WoodEnum backWood,TopWoodEnum topWood)
        {
            Guitar guitar = new Guitar(serialNumber,price,builder,model,type,backWood,topWood);
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

        public Guitar Search(Guitar searchGuitar)
        {
            for(int i=0;i<guitars.Count;i++)
            {
                Guitar guitar = guitars[i];
                string builder = searchGuitar.Builder.ToString();
                if ((builder != null) && (!builder.Equals("")) &&
                    (!builder.Equals(guitar.Builder)))
                    continue;
                string model = searchGuitar.Model.ToString();
                if ((model != null) && (!model.Equals("")) &&
                    (!model.Equals(guitar.Model)))
                    continue;
                string type = searchGuitar.Type.ToString();
                if ((type != null) && (!type.Equals("")) &&
                    (!type.Equals(guitar.Type)))
                    continue;
                string backWood = searchGuitar.BackWood.ToString();
                if ((backWood != null) && (!backWood.Equals("")) &&
                    (!backWood.Equals(guitar.BackWood)))
                    continue;
                string topWood = searchGuitar.TopWood.ToString();
                if ((topWood != null) && (!topWood.Equals("")) &&
                    (!topWood.Equals(guitar.TopWood)))
                    continue;

                return guitar;
            }
            return null;
        }
    }
}

//问题就是需要把所有的东西转变为全都是小写string.ToLowerCase 或者ToUpperCase
//或者使用enum与类似一个级别的一个enum类型。
//枚举类型
    //enum Day { Sat，Sun，Mon，Tue，Wed，Thu，Fri};
    //int x = (int)Day.Sun;
    //enum Day : byte { Sat,};
//不会因为拼错字或者打错字防止被编译器指出
//并且是类ing安全的，防止输入坏的数据。
//可以使用枚举类型+句点运算符的操作方式实现这个东西
