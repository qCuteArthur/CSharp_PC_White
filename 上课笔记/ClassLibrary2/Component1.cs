using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary2
{
    public partial class Component1 : Component
    {
        private string message;
        [Category("Message")]
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
        public void ShowMessage()
        {
            MessageBox.Show(message);
        }

        public Component1()
        {
            InitializeComponent();
        }

        public Component1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
