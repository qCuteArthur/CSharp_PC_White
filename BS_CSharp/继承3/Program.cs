using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 继承3
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
//类成员的级别是以类的访问级别为上限的。
//默认的访问级别是internal
//类是internal的，但是类成员是public

//一个文件就是一个internal部分
//public是整个sln，internal是一个project程序集。
//当你对象访问不了的时候，注意规定好这个访问级别的情况。

//访问最低的几倍是private，限制在类的类体里面。继承集成了，但是访问不能访问。private继承下来，但是没有访问权限。（封装和隐藏）

//protected会把这个访问级别限制在这个继承链上面。
//类设计的时候，访问级别是很重要的。
//internal就是相同的一个程序集里面。protected就是在继承类里面的，是跨程序集的。

    //protected更多应用在override上面，更多引用于这个方法方面。
