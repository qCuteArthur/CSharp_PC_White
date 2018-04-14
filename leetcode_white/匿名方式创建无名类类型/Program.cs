using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 匿名方式创建无名类类型
{
    class Program
    {
        static void Main(string[] args)
        {
            string Major = "History";
            var Student = new { Age = 19, Other.Name, Major };
            Console.WriteLine("{0}",Student.Major);
        }
    }
    class Other
    {
        static public string Name = "Justin";
    }
}
