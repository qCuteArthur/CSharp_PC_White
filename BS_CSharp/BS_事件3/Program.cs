using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//事件类型2：事件响应者同时也是事件拥有者。

namespace BS_事件3
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form1 = new Form();
            Controller CT = new Controller(form1);
            //上面完成的是初始化
            form1.ShowDialog();
        }
    }
    public class Controller
    {
        private Form form1;
        public Controller(Form form1)
        {
            if (form1 != null)
            {
                this.form1 = form1;
            }
            //事件模型的确5个部分！
            this.form1.Click += this.FormClicked;
        }

        private void FormClicked(object sender, EventArgs e)
        {
            this.form1.Text = DateTime.Now.ToString();
            MessageBox.Show("Test");
        }
    }
}
