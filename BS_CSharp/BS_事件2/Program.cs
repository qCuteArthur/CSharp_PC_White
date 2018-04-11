using System;
using System.Timers;

//事件类型1，事件响应者订阅了事件拥有者。


/// <summary>
/// 事件模型必备的五个部分——拥有者 事件 响应者 处理器 订阅
/// </summary>
namespace BS_事件2
{
    class Program
    {
        static void Main(string[] args)
        {
            //拥有者
            Timer timer1 = new Timer();
            timer1.Interval = 1000;
            //响应者
            Boy boy1 = new Boy();
            Girl girl1 = new Girl();
            //表示订阅事件和事件本身，表示timer1一旦Elapse，就会有Action。
            //浓缩的5大部分。

            //一个事件同时有两个事件处理器。
            timer1.Elapsed += boy1.BoyAction;
            timer1.Elapsed += girl1.GirlAction;

            //
            timer1.Start();
            Console.ReadLine();
        }
    }
    class Boy
    {
        //处理器
        internal void BoyAction(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Jump!");
        }
    }
    class Girl
    {
        internal void GirlAction(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Sit!");
        }
    }

}
//类或者对象最重要的三个功能，就是状态 做事情 通知别人。
//事件模型的五个部分
//EventOwner.Event +=EventHandleObject.EventHandler;
