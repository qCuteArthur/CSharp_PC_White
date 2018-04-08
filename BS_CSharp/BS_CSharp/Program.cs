using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//事件和委托之间的关系非常紧密 
//事件 订阅 事件处理器 分别属于事件所有者 和 事件相应者。
namespace BS_CSharp
{
    //事件处理器是必须的，而且必须用委托的形式进行声明，其实主要是因为他本身是个方法。
    public delegate void OrderEventHandler(Customer customer,OrderEventArgs e);

    //一个专门用于传递时间消息的类。
    //一定要派生自EventArgs
    public class OrderEventArgs:EventArgs
    {
        private string dishName;

        public string DishName
        {
            get { return dishName; }
            set { dishName = value; }
        }
        private double price;

        public double Price 
        {
            get { return price; }
            set { price = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            //服务员过来订阅点菜，本质是事件处理器来订阅点菜事件。
            customer.Think();
        }
    }

    public class Waiter
    {
        //这东西是一个方法
        internal void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("HELLO Sir！{0} for you !",e.DishName);
        }
    }
    //事件是基于委托的，一个是委托给事件一个约束，规定了事件能发送什么东西与接收什么东西。
    //也规定了事件的响应者能处理什么消息，也就是说，事件处理者的事件处理器需要可以和这个事件匹配上,他才可以订阅这个事件。

    //当事件响应者向事件拥有者提供了这个事件处理器之后，你需要一个地方来保存或者记录下来。
    //能够记录这种方法实例的东西，也只有委托能做到。
    public class Customer {
        private OrderEventHandler orderEventHandler;
        public event OrderEventHandler Order{
            add
            {
                orderEventHandler += value;
            }
            remove
            {
                orderEventHandler -= value;
            }
        }
        //事件作为一个字段，在发生之后，事件响应者是需要返回一个东西，Handler来·处理这个事件的。
        //你可以把处理事件理解为，返回一个Handler对象。
        public void Think()
        {
            Console.WriteLine("emmmmmmmmmmmm");
            System.Threading.Thread.Sleep(2000);

            //OrderEventArgs orderEventArgs = new OrderEventArgs() { DishName = "Hllo", Price = 10.00 };
            if(orderEventHandler != null)
            {
                orderEventHandler.Invoke(this, new OrderEventArgs() { DishName = "Hllo", Price = 10.00 });
            }
            //this表示是我自己来相应。
        }
    }

}
//首先是明确事件的五个模型，然后是明确如何使用厂商已经定义好的时间，比如说Button.click事件，Timer.Click事件。
//本节要学习的就是自定义这个事件。按照一个自己的需求，来定义事件。5个组成部分，委托必不可少。

