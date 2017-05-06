using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos2017.UserControls
{

  
    public partial class Admin_Stock : UserControl
    {
        int Colume_Size = (((Screen.PrimaryScreen.Bounds.Width / 12) * 7) / 12) * 1;
        public Admin_Stock()
        {
            InitializeComponent();
        }
        public void InitSize()
        {
            //MessageBox.Show(x.ToString());
            this.Width = Colume_Size * 12;
            this.Height = Screen.PrimaryScreen.Bounds.Height- 10;
            tabControl1.Width = (Colume_Size * 12)- 5;
            tabControl1.Height = Screen.PrimaryScreen.Bounds.Height-20;

            panel1.Width = tabControl1.Width - 15;
            GroupFindItems.Width = (tabControl1.Width / 2)-10;
            GroupItemDetail.Width =(tabControl1.Width / 2)-10;
            GroupItemDetail.Location = new System.Drawing.Point(GroupFindItems.Width + 10, GroupFindItems.Location.Y);
            DataGridViewFindItems.Width = GroupFindItems.Width-10;

            // TaB Page 2 
            GroupAddItems.Width = tabControl1.Width - 20;

            //GroupAddItems.Location = new System.Drawing.Point(0, 0);
            //GroupAddItems.Width = (Colume_Size * 4)-10;

            // GroupSearchImage.Width = (Colume_Size * 8)-10;
            //GroupSearchImage.Location = new System.Drawing.Point(0, Colume_Size * 6);
            // string gg_url = "https://www.google.com/search?site=imghp&tbm=isch&source=hp&biw=1600&bih=775&q=pizza";
            //webBrowser1.Url = new System.Uri(gg_url, System.UriKind.Absolute);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void qry_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
