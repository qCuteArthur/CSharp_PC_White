using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//只要是类，就会从object类里面继承一些东西。
//类默认是internal
namespace MyLib.MyNameSpace
{
    //这个public是文件外边并且没有继承关系。
    //internal是在mylib中可以自由访问。
    public class Calculator
    {
        public double  Add(double a,double b)
        {
            return a + b;
        }
    }
}
