using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 试制动物
{
    public abstract class Animal
    {
        protected string name;
        //可以从
        public string Name
        {
            get { return name;}
            set { name = value; }
        }
        public Animal()
        {
            name = "this animal has no name.";
        }
        public Animal(string newName)
        {
            name = newName;
        }
        public void Feed()
        {
            Console.WriteLine("{0} has been fed.",name);
        }
    }
}
