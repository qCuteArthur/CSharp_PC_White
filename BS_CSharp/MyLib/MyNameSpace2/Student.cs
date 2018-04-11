using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib.MyNameSpace2;

//编译结果很简单，一个是exe一个是lib类库。
namespace MyLib.MyNameSpace2
{
    class Student
    {
        MyNameSpace.Calculator calc = new MyNameSpace.Calculator();
        //internal是在项目中的访问。Assembly装配集或者叫做装配件。
        public MyNameSpace.Calculator Calc { get; set; }

    }
}
//常见的Assembly就两个，一个是exe，一个是lib。
