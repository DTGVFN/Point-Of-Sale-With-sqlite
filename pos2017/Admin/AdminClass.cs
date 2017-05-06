using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace pos2017
{
    public partial class POS
    {

        public class AdminManager
        {
            POS_Screen.Object_Controls.FlowAdminMenu Flow = new POS_Screen.Object_Controls.FlowAdminMenu();
            // POS_Screen.Object_Controls.AdminGroupbox AdminGroup = new POS_Screen.Object_Controls.AdminGroupbox();
            //public UserControl1 x = new UserControl1();
            public UserControls.Admin_Stock Adm_Stock = new UserControls.Admin_Stock();

            Button t = new Button();

            public AdminManager()
            {
                Adm_Stock.InitSize();
                Flow.Controls.Add(Adm_Stock);
            }
            public void Show(object sender)
            {
                ((Form)sender).Controls.Add(Flow);
            }
            public void Remove(object sender)
            {
                ((Form)sender).Controls.Remove(Flow);
            }
        }
    }
}
