using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//类继承和接口还是有差别的，但是现在主流使用的还是接口。
namespace MyLib_继承4
{
    public class Vehicle
    {
        protected int  Rpm { get; set; }
        protected int  Fuel { get; set; }
        protected int Speed { get; set; }
        protected void Burn(int fuel)
        {
            Fuel -= fuel;            
        }
        protected void DisplaySpeed()
        {
            Console.WriteLine($"currentSpeed is #{Speed}.");
        }
    }

    public class SmallCar : Vehicle
    {
        public SmallCar(string brand)
        {
            type = brand;
        }
        public void Accelerate()
        {
            Burn(1);
            Rpm += 100;
        }
        private string type;
        public string Type
        {
            get { return type; }
        }
        public void DisplaySpeed()
        {
            Console.WriteLine("this car`s brand is :{0}.", type);
        }
        public int Speed{ get {return Rpm/10; }}
    }
    public class Bus : Vehicle
    {
        protected void Acclerate()
        {
            Burn(2);
            Rpm += 50;
        }
        public Bus(string brand)
        {
            type = brand;
        }
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public void DisplaySpeed()
        {
            Console.WriteLine("this car`s brand is :{0}.",type);
        }
        public int Speed { get { return Rpm / 20; } }
    }
}
//这样的继承还不如直接声明一个interface完事得了呢。
//如果这是个dll，那里面的成员声明为public就会非常的麻烦了。


    //反正就是要说明白这个internal 和 protected之间的访问性的差别。

    //面向对象的代码实现风格——class-based 和 prototype-based 

    //面向对象的功能——派生和继承之基于class的风格。
    //此外还有基于原型的封装继承多态。