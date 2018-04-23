using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 接口实现小丑
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TallGuy tallGuy = new TallGuy(19,"Justin");
            tallGuy.IntroduceYourSelf();
            tallGuy.Honk();
        }
    }
    class TallGuy:IClown
    {
        private string name;
        private int height;
        public TallGuy(int height,string name)
        {
            this.name = name;
            this.height = height;
        }
        //注意这个接口所实现的属性的声明
        public string FunnnyThingIHave => "BIG SHOES";

        public void Honk()
        {
            MessageBox.Show("I have "+FunnnyThingIHave.ToString());
        }

        public void IntroduceYourSelf()
        {
            Console.WriteLine("My name is {0},and  I am {1} inches tall.",name,height);
        }
    }
    interface IClown
    {
        void Honk();
        //一个只能访问的对象
        string FunnnyThingIHave { get; }
    }
    interface IScaryClown : IClown
    {
        string 
    }
}
