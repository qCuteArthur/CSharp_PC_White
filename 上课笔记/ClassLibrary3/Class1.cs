using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ClassLibrary3
{
    public class NumberTextBox:TextBox
    {
        protected override void WndProc(ref Message m)
        {
            if((m.Msg == 0x0102) && (!Char.IsControl((char)m.WParam)))
            {
                if (char.IsNumber((char)m.WParam)) base.WndProc(ref m);
                return;
            }
            base.WndProc(ref m);
        }
    }
}
