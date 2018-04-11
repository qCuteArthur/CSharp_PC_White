using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS_事件10
{
    public delegate void OrderEventHandler(Customer customer,OrderEventArgs e);

    public class OrderEventArgs:EventArgs
    {
        private string name;

        public string Name 
        {
            get { return name; }
            set { name = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            customer.Deciding();
            Console.ReadLine();
        }
    }
    public class Customer
    {
        private OrderEventHandler order;
        public event OrderEventHandler Order{
            add
            {
                order += value;
            }
            remove
            {

                order -= value;
            }
        }
        public void Deciding()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("let me have a think!");
            }
            OrderEventArgs e = new OrderEventArgs() { Name= "Fish!"};
            order.Invoke(this,e);
        }
    }
    public class Waiter
    {
        internal void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine(" I will server you {0}.",e.Name);
        }
    }
}
