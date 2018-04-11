using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//我们不仅仅想调用这个Form被触发的东西，还想再Form类里面进行处理
//这时候，单纯的Form.Load += form就不行，需要对于MS定义的原来的Form进行改写。也就是派生类。


    //派生与集成

    //事件类型2：事件响应者同时也是事件拥有者。

namespace BS_事件4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyForm myForm1 = new MyForm();
            myForm1.Click += myForm1.formClicked;
            myForm1.ShowDialog();
        }
    }
    //使用派生类，对于原来的类进行改写，包括dll里面的。
    public class MyForm : Form
    {
        internal void formClicked(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }
    }


}
