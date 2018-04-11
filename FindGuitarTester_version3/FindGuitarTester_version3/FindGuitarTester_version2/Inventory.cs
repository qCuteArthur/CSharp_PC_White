using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace FindGuitarTester_version2
{
    class Inventory
    {
        private List<Guitar> guitars;
        public Inventory()
        {
            guitars = new List<Guitar>();
        }

        public void addGuitar(string serialNumber, double price, GuitarSpec guitarSpec)
        {
            Guitar guitar = new Guitar(serialNumber, price, guitarSpec);
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
        //传进来的是对象
        public bool Match(object m,object n)
        {
            if (m.Equals(n)) return true;
            else return false;
        }

        public PropertyInfo[] GetProperties(GuitarSpec searchSpec)
        {
            Type t = searchSpec.GetType();

            PropertyInfo[] pis = t.GetProperties();
            //foreach (PropertyInfo pi in pis)
            //{
            //    object value1 = pi.GetValue(t, null);
            //    string name1 = pi.Name;
            //}
            if (pis == null)
            {
                Console.WriteLine("Failed to get Properties!");
                return null;
            }
            return pis;
        }


    public List<Guitar> search(GuitarSpec searchSpec)
        {
            List<Guitar> matchGuitar = new List<Guitar>();

            for (int i=0;i<guitars.Count;i++)
            {
                Guitar guitar = guitars[i];
                //使用反射获取所有的属性，分别进入这个match进行比较，最后得出结果。
                PropertyInfo[] pis = GetProperties(searchSpec);
                PropertyInfo[] pis2 = GetProperties(guitar.Spec);
                //反射比较所有的属性
                foreach (object item in pis)
                {
                    //这里还出现了大问题。。。。
                    Console.WriteLine(pis.GetValue());
                }

                //解决方法
                //1.泛型match + 委托
                //2.用反射获取所有的属性+委托构造一个方法的比较+获取一个类对象中的所有的属性的数值


                //Builder_Enum builder = searchSpec.Builder;
                //if (builder != guitar.Spec.Builder)
                //    continue;

                //string model = searchSpec.Model.ToLower();
                //if ((model != null) && (!model.Equals("")) &&
                //    (!model.Equals(guitar.Spec.Model.ToLower())))
                //    continue;

                //Type_Enum type = searchSpec.Type;
                //if (type != guitar.Spec.Type)
                //    continue;

                //Wood_Enum backWood = searchSpec.BackWood;
                //if (backWood != guitar.Spec.BackWood)
                //    continue;

                //Wood_Enum topWood = searchSpec.TopWood;
                //if (topWood != guitar.Spec.TopWood)
                //    continue;


            }
            return matchGuitar;
        }
    }
}


//可以用virtual 父类里面，注意从底开始全应该是override
// 和 override子类里面来进行类型的修改

//子类也可以覆盖父类和定义好的方法

   //只能要使用基类的地方，就能用子类。

    //如果基类有构造函数，子类也需要有构造函数，并且基类的构造函数的需要的参数也需要在子类的构造函数中声明。

    //作业：卖吉他，卖其他的乐器，
    //你可以尝试尝试接口