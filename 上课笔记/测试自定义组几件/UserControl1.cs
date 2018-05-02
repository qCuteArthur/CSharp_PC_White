using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 测试自定义组件和控件
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private string oldString;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string input = this.textBox1.Text;
            int result;
            if(!Int32.TryParse(input,out result))
            {
                MessageBox.Show("请输入数字");
                this.textBox1.Text = oldString;
            }
            else
            {
                oldString = input;
            }
        }
    }
}
