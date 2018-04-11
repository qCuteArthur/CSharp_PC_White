using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//也就是多播委托，一个委托自己会串上很多的东西。
//然后就是异步编程
namespace BS_高级委托
{
    class Program
    {
        static void Main(string[] args)
        {
            Student Student1 = new Student() { ID = 1,PenColor = ConsoleColor.Yellow};
            Student Student2 = new Student() { ID = 2, PenColor = ConsoleColor.Green};
            Student Student3 = new Student() { ID = 3, PenColor = ConsoleColor.Gray};
            //Student1.DoHomework();
            //Student2.DoHomework();
            //Student3.DoHomework();

            //直接调用和间接调用（函数指针调用）
            Action action1 = new Action(Student1.DoHomework);
            Action action2 = new Action(Student2.DoHomework);
            Action action3 = new Action(Student3.DoHomework);
            //使用委托，对于三个方法间接调用。
            //action1.Invoke();
            //action2.Invoke();
            //action3.Invoke();
            ////合并，并且执行顺序是完全按照封装的顺序实现的。
            //action1 += action2;
            //action1 += action3;
            //action1.Invoke();
            ////单线程，多播委托，直接调用，间接调用都是同步调用的。
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.ForegroundColor = ConsoleColor.Cyan;
            //    Console.WriteLine("the main thread is {0}",i);
            //}
            Console.WriteLine("++++++++++++++++++++++++++++++=");

            //Task task1 = new Task(new Action(Student1.DoHomework));
            //Task task2 = new Task(new Action(Student2.DoHomework));
            //Task task3 = new Task(new Action(Student3.DoHomework));

            //task1.Start();
            //task2.Start();
            //task3.Start();

            Console.WriteLine("++++++++++++++++++++++++++++++=");
            //使用委托进行异步调用
            action1.BeginInvoke(null,null);
            //第一个参数是异步调用的回调函数，也就是这个线程执行完之后我们要调用什么？》
            action2.BeginInvoke(null, null);
            action2.BeginInvoke(null, null);

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("the main thread is {0}", i);
            }

            Console.Read();

        }
    }
    //注意构造函数的声明方式——可以是自己定义构造函数，但是也同样可以使用直接定义的方式。
    class Student
    {
        //首先要明确，这样设计类本身就是不合理的。
        public int  ID { get; set; }
        public ConsoleColor PenColor { get; set; }
        public void DoHomework()
        {
            for(int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = this.PenColor;
                Console.WriteLine("Student {0} doing his homework {1} hours.",this.ID,i);
                Thread.Sleep(10);
            }
        }
    }
}
//多播委托，一个委托内部不仅仅包含着一个方法。
//ConsoleColor myColor = (ConsoleColor)obj; 同样可以进行强制类型转化
//应该说 as typeName也可以进行强制类型的转化、
//同样的Convert.ChangeType也可以进行类型转化。

//同步:我做完了，你接着做。（单线）
//异步：我们同步做。（多线程）（多线）
//每个程序都是内存中的一个进程，包含着若干线程。
//一个程序可以有主线程和分支线程。

//执行指针在主线程和子线程中进行来回的跳动。

//同步调用的方式——直接、单播委托的间接，多播委托的间接
//异步调用——
//隐式调用beginInvoke + 委托 （资源争抢）
//task显式多线程创建



    //为了避免多线程程序发生冲突，可以给线程加锁。

    //完全可以，使用接口取代委托