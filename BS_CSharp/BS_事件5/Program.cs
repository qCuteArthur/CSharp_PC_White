using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_事件5
{
    class Program
    {
        static void Main(string[] args)
        {
            MyForm myForm = new MyForm();
            myForm.ShowDialog();
        }
    }
    class MyForm:Form
    {
        private TextBox textBox;
        private Button button;

        public MyForm()
        {
            this.textBox = new TextBox();
            this.button = new Button();
            //用label比用textBox更好啊。
            this.Controls.Add(this.button);
            this.Controls.Add(this.textBox);
            //事件模型
            this.button.Click += this.ButtonClicked;
        }
        //我们无法做到，在触发了Button之后，用textbox进行相应，因为textBox自己是MS自己定义的，但是WinForm是我们自己定义的，也就是说，我们可以用Winform来自己定义对象。
        //类似于Winform里面对于这个ButtonClicked的相应操作。
        private void ButtonClicked(object sender, EventArgs e)
        {
            this.textBox.Text = "Be Tough to the Fucking Idoit!！！！！！！！！！！！";
        }
    }
}
//事件拥有者是事件响应者的一个嵌套类。
//事件响应者有自己的方法订阅了事件拥有者。事件拥有者是事件响应者的一个部分。也就是winform里面常见的东西。


//事件拥有者是事件相应着的一个成员字段，最典型的就是Winform中的相应，同时由于winform自身是无法做到改写MS dll的，所以我们选择使用自己定义的winform进行操作。

//其实你winform里面的那些个Button.Click的最后的逻辑块，就是对于这个Click进行处理，也就是相当于
//Button button3 = new Button();
//button3.click()+= button_handleObject;

//可以用匿名方法或者是Lambda表达是进行操作。
//Button new_button = new Button();
//new_button.Click += (object sender,EventArgs e)=>{
//    this.TextBox.Text = "HOHO!";
//    }

    //事件可以挂接多个事件处理器，一个事件处理器可以处理多个事件
    //事件是专门用于桌面开发的，而你这个桌面开发包括Winform开发和WPF开发。
