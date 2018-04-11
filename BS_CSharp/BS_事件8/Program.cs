using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_事件8
{
    public delegate void OrderEventHandler(Customer customer,OrderEventArgs e);
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += Waiter.Action;
            customer.Think();
            Console.ReadLine();
        }
    }
    //注意派生
    public class OrderEventArgs:EventArgs
    {
        private string dishName;
        public string DishName
        {
            get { return dishName; }
            set { dishName = value; }
        }
    }
    public class Customer
    {
        private OrderEventHandler orderEventHandler;
        public event OrderEventHandler Order
        {
            add
            {
                orderEventHandler += value;
            }
            remove
            {
                orderEventHandler -= value;
            }
        }
        public void Think()
        {
            if (this.orderEventHandler!=null)
            {
                OrderEventArgs e = new OrderEventArgs() { DishName = "fuck!"};
                orderEventHandler.Invoke(this,e);
            }
        }
    }
    public class Waiter
    {
        internal static void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("I WILL SERVER YOU {0}.",e.DishName);
        }
    }
}
