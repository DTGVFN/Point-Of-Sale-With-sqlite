using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos2017.POS_Screen
{
    class Main_WIndows_Size
    {
        public void ReSize(object sender)
         {
            ((Form)sender).Width = Screen.PrimaryScreen.Bounds.Width;
            ((Form)sender).Height = Screen.PrimaryScreen.Bounds.Height;
            ((Form)sender).FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
    }
}
