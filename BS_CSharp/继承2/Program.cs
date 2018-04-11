using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//类的继承仅仅包含了，字段属性方法字段
//但是类的继承不包括类构造器。
//调用子类的构造器会默认调用弗雷的构造器并且构造一个弗雷的对象。

//一个方法就是使用：base满足弗雷构造器的签名。另外一个方法就是在子类构造器声明一个参数，并且把这个参数传递给弗雷构造器。
//public Vehicle(string owner)
//public Car(string owner):base(owner)


//弗雷和子类都会有owner这个字段，但是在弗雷构造器构造出来的结果和子类构造器构造的结果是完全不一样的。
//弗雷构造器和子类构造器都是owner这个属性，但是这两个东西是两个内存地址
//弗雷构造器一定不能被子类继承。
namespace 继承2
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Audi");
            Console.WriteLine(car.Owner);
        }
    }
    public class Vehicle
    {
        public Vehicle(string name)
        {
            this.Owner = name;
        }
        public string  Owner { get; set; }
    }
    public class Car : Vehicle
    {
        public string Owner { get; set; }
        public Car(string Name) : base("N/A")
        {
            this.Owner = Name;
        }
    }
    public class RacingCar :Car
    {
        public RacingCar(string Name):base("N/A")
        {
            this.Owner = Name;
        }
        public string Owner { get; set; }
    }
}
