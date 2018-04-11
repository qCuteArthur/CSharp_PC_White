using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_面向对象
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = default(Student);

            Type t = typeof(Student);
            object a = Activator.CreateInstance(t,1,"Timothy");
            //反射机制
            Student stu = a as Student;


            //动态类型机制Dynamtic机制。
            Type m = typeof(Student);
            dynamic stu1 = Activator.CreateInstance(m,1,"hello");
            Console.WriteLine(stu1.Name);

            //
            Student stu2 = new Student(1,"jack");
            Student stu3 = new Student(2,"fucj");
            //这就是调用静态方法的结果。
            Console.WriteLine(Student.Amount);
        }
    }
    internal class Student
    {
        private static int amount;

        public static int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        //静态构造器，只能构造静态成员。
        static Student()
        {
            Amount = 100;
        }
        public Student(int id,String str)
        {
            this.ID = ID;
            this.Name = str;
        }
        //ctor可以直接创建构造器
        ~Student()
        {
            Console.WriteLine("Bye-bye");
        }//析构函数
        public int ID { get; set; }
        public string Name { get; set; }
        public void Report()
        {
            Console.WriteLine($"i am #{ID} studnet in my class ,my name is {Name}.");
        }
    }
}
//字段属性方法事件——都是从现实世界抽象出来的，用于封装的。
//继承
//多态

    //类——引入面向对象中是很早的。
    //类本身是一个数据结构，也是一个数据类型，代表现实世界中的种类。是计算机领域的一个独有的概念。

    //类是抽象数据结构，类本身是抽象的结果。Student类。类也是抽象结果的载体。类也是抽象结果和抽象行为的载体。类是一个枢纽和支点的感觉。
    //   类也是数据类型，Student class，一个自定义的类型。类是一个引用类型，每一个类都是一个自定义的类型。每一个类都是一个自定义的引用类型。可以用这个类去引用变量，声明实例。
    //类概念三，是现实世界中种类的代表，类代表现实世界的种类。

    //构造器和析钩器。——实例 静态。

    
