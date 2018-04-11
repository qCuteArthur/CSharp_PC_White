using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 继承
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type t = typeof(Car);
            //Type tb = t.BaseType;
            //Console.WriteLine(tb.Name);
            //Console.WriteLine(t.Name);
            //Console.ReadLine();

            //Donet都是单根的，都是衍生自System.Object
            //Car car = new Car();
            //Console.WriteLine(car is Vehical);
            //Console.WriteLine(car is Object);


            RaceCar raceCar = new RaceCar("Justin.J.J");
            //raceCar.Owner;子类对于弗雷全部继承。
            //raceCar.GetType继承自Object
            Car car = new Car("Audi");
            Console.WriteLine(car.Owner);

        }
    }
    //sealed是将一个类一个封闭
    //一个类最多允许一个基类。但是可以继承自很多个接口（虚接口）
    //继承自类 实现了接口
    class Manual
    {
        //ctor
        public Manual()
        {

        }
    }
    class Vehicle: Manual
    {
        //this这个关键字指的就是用这个类构建的对象他自身。
        //假如你更改了Vehical这个构造器，比如增加了一个字段成员string Name，而子类仍然是不带参数的构造器。这样就没办法构造基类对象了。
        //应该怎么办？ 
        public Vehicle(string name)
        {
            this.Owner= name;
        }
        public string Owner { get; set; }
        //有一点要注意：在多重继承类上构造最底层的类，构造是从最顶层开始的。也就是从Object开始的。
    }
    //子类的访问级别不可以超过父类。
    class Car : Vehicle
    {
        public Car(string owner):base("N/A") 
        {
            this.Owner = owner;
        }
        public void ShowOwner()
        {
            //base表示的是基类，是由基类的构造器构造出来的。只能向上访问一层。
            //在这个里面，this.Owner和base.owner是一个东西。
            Console.WriteLine(this.Owner);
            Console.WriteLine(base.Owner);

        }
    }
    class RaceCar : Car
    {
        //类虽然有很强的继承，但是弗雷的实例构造器却不可以被继承。
        public RaceCar(string owner):base("Justin")
        {
            this.Owner = owner;
        }
        public string Owner { get; set; }
    }
}
//类的继承——鸡肋派生类 
//car的实例也是vehicle的实例
//可以用爸爸类类型的变量，引用子类类型的实例。

    //继承的本质就是——代码重用。派生类在基类已有的成员的基础之上，对于基类做的一个横向和纵向的扩展。

    //类的继承
    //成员的继承和访问——谨慎继承 
    //动态类型的JS可以随时或者删减类中的字段。

    //特点：1，子类对于父类是全盘继承，并且子类相比于父类是只能增加，不能减少。

    //横向扩展——类成员越来越多。
    //纵向扩展——不增加类成员的个数，但是对于类成员的版本进行更新。override。

    
