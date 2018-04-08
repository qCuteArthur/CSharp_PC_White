using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//拒绝使用简略声明，反正事件简化声明根本让人看不懂。
namespace BS_事件_简略声明
{
    public delegate void ActionEventHandler(Customer customer, ActioneEventArgs e);

    public class ActioneEventArgs
    {
        public string DishName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer custumer = new Customer();
            Waiter waiter = new Waiter();
            custumer.Action += waiter.Action;
            custumer.OnAction();
            Console.ReadLine();
        }
    }

    public class Waiter
    {
        internal void Action(Customer customer, ActioneEventArgs e)
        {
            Console.WriteLine("---------------");
        }
    }

    public class Customer
    {
        public ActionEventHandler actionEventHandler;
        //事件要有自己对应的事件处理器
        public event ActionEventHandler Action{
            add {
                actionEventHandler += value;
            }
            remove
            {
                actionEventHandler -= value;
            }
        }
        //专门触发事件的方法，定义为OnEvent();
        public void OnAction()
        {
            //必须判断这个委托是不是为空。
            if(this.actionEventHandler != null)
            {
                Console.WriteLine("++++++++++++++");
                ActioneEventArgs e = new ActioneEventArgs() { DishName = "Chicken" };
                this.actionEventHandler.Invoke(this, e);
            }
        }
        //为什么不应该是public，而是继承类的protected。
        //应该说，就是防止外界触发这个事件，这个事件的拥有者才会触发这个事件，继承类，而不是一个命名空间。
    }
}
//event的本质就是委托字段的一个包装器，对于委托字段的访问起到了限制作用。事件对于外界隐藏了大多数的功能，仅仅暴露了添加和移除时间处理器的功能。

//用于声明事件的委托类型的命名约定
//一般就是FooEventHandler（object sender ，EventArgs e）
//触发时间的方法一般叫做On-event

//事件——限制了外界对代码的访问

//委托中的借刀杀人，访问级别要定义为protected而不是public。
//一个方法做了两件事情，就是借刀杀人。
//对于触发事件的方法，需要使用protected进行声明

//存储数据 做事情 通知别人
//例如：Form closing事件，可以实现对于是不是真的要关闭的确认。
//可以增加log进行记录。

//关于事件的误会，事件是一种以特殊方式声明的委托字段——主要是field-like简化声明的字段，坑人啊。所以，现在还是认真写全版。
//事件是不能比较是不是空的，而是事件处理器是不是为空。
//事件不是委托字段本身

    //用委托声明事件——source角度：表明source对外可以传递什么消息
    //在订阅者角度看、被通知者——是一种约定，约定了subscribe者可以处理的消息。
    //委托类型的实例来存储或者引用事件处理器。

    //对比事件和属性——字段包装器，很简单的保护字段。
    //事件——委托类型字段的包装器，保证这个EventHandler不要被外界随意调用，起码要满足object和eventArgs。防止被借刀杀人。
