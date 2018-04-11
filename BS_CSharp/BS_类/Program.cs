using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib.MyNameSpace;

namespace BS_类
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLib.MyNameSpace.Calculator calculator= new MyLib.MyNameSpace.Calculator();
        }
    }
}
//类修饰符 modifier new private public (访问级别)internal protected static abstract（继承）
//关于类访问级别——public internal