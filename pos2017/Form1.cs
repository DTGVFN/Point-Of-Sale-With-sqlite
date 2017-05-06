using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace pos2017
{
    public partial class POS : Form
    {

        // Detect Screen Resolution For Application Width And Height 
        POS_Screen.Main_WIndows_Size POS_SIZE = new POS_Screen.Main_WIndows_Size();
        //END


        // DataGridview Of Select Items.
        static POS_Screen.Object_Controls.POSGridview Dg_Items_List = new POS_Screen.Object_Controls.POSGridview();
        
        // Normal Textbox Show Total Price 
        POS_Screen.Object_Controls.CalculatorArea LEDCalculator = new POS_Screen.Object_Controls.CalculatorArea();

        // Button Manager And Button List Array To Button
        static POS_Screen.Object_Controls.ManagerButton[] BtnManager = new POS_Screen.Object_Controls.ManagerButton[10];
        static string[] BtnName = new string[] { "[F2]Payment", "[F3]New Bill", "[F4]Save Bill", "Staff", "Check Var", "Remove Bill", "Admin Menu" };


        /// This is FlowControl For POS Sell Screnn
        POS_Screen.Object_Controls.FlowRightMain FlowRightMain = new POS_Screen.Object_Controls.FlowRightMain();
        POS_Screen.Object_Controls.FlowFaviritorMain FlowFaviritor = new POS_Screen.Object_Controls.FlowFaviritorMain();
        POS_Screen.Object_Controls.FlowMainButtonManager FlowButtonManager = new POS_Screen.Object_Controls.FlowMainButtonManager();
        POS_Screen.Object_Controls.FlowStickyMain FlowSticky = new POS_Screen.Object_Controls.FlowStickyMain();



        /// This is FlowControl For Admin Manager
        //Admin.Object_Controls.FlowAdminMenu FlowAdmin = new Admin.Object_Controls.FlowAdminMenu();
        AdminManager AdminManagerx = new AdminManager();

         



        POS_Screen.Object_Controls.PolaroidButton[] PolaRoidBtn = new POS_Screen.Object_Controls.PolaroidButton[60];
        // POS_Screen.Object_Controls.ManagerButton FlowStick = new POS_Screen.Object_Controls.ManagerButton();


        int BuyItemID { get; set; }
        int BuyItemPrice { get; set; }
        string BuyItemName { get; set; }

        int GridviewTotal { get; set; }
        string GridviewHoldBillEditID { get; set; }
        string GridviewStatus { get; set; } // NEW - OPEN - UPDATE
        string GridviewSaved { get; set; }
        static int GridViewCurrentRow { get; set; }
        
        string[] AdminMenuBtn = new string[] { "Stock", "Report", "Sale Screen" };

        int ItemGroup = 5;


        public POS()
        {
            InitializeComponent();
            POS_SIZE.ReSize(this);
            //this.Controls.Add(Dg_Items_List);
            //this.Controls.Add(FlowRightMain);
            //this.Controls.Add(FlowFaviritor);
            //this.Controls.Add(FlowButtonManager);
            //this.Controls.Add(LEDCalculator);
            //this.Controls.Add(FlowSticky);
            //Create_Button_Layout();
            //GridviewStatus = "NEW";
            //GridviewHoldBillEditID = "NO";
            //GridviewClearData();
            //LoadButtonItemMenu(1);
            //StickyFlowView();

        }

        public void LoadButtonItemMenu(int id)
        {
            if (id != 0) ItemGroup = id;
            FlowRightMain.Controls.Clear();
            string sql = "SELECT it_id,it_name FROM fav_list INNER JOIN pos_items" +
                           " On fav_list.item_id=pos_items.it_id where fav_list.group_id=\"" + ItemGroup + "\"";
            DataTable dt = new DataTable();
            //dt = POS.SqlCommandToDataTable(sql);
            dt = DB.DB_Connect.SqlCommandToDataTable(sql);

            int numRows = dt.Rows.Count;
            int i = 0;
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                PolaRoidBtn[i] = new POS_Screen.Object_Controls.PolaroidButton();
                //MessageBox.Show();

                //PolaRoidBtn[i].Image = Image.FromFile("D:\\bartender\\img\\product\\" + row["it_id"].ToString() + ".png");
                PolaRoidBtn[i].Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory()+"\\bartender\\img\\product\\" + row["it_id"].ToString() + ".png");
                PolaRoidBtn[i].Text = row["it_name"].ToString();
                PolaRoidBtn[i].Tag = row["it_id"].ToString();
                int x = Int32.Parse(PolaRoidBtn[i].Tag.ToString());
                PolaRoidBtn[i].Click += (sender, e) => AddItemToGride(x);
                FlowRightMain.Controls.Add(PolaRoidBtn[i]);
                i++;
            }
            int Main_Area = (Screen.PrimaryScreen.Bounds.Width / 12) * 6;
            // int BtnFullSize = PolaRoidBtn[i].Width + PolaRoidBtn[i].Margin.Left + PolaRoidBtn[i].Margin.Right;
            //  int BtnInRows = Main_Area / BtnFullSize;
            //int xx = POS_Screen.Object_Controls.CountFavilatorBtn;
            AddBlankButton(i);
        }
        public void AddBlankButton(int x)
        {


            for (int i = x; i <= POS_Screen.Object_Controls.CountFavilatorBtn - 1; i++)
            {
                PolaRoidBtn[i] = new POS_Screen.Object_Controls.PolaroidButton();
                FlowRightMain.Controls.Add(PolaRoidBtn[i]);
            }
        }

        public void AddItemToGride(int ID)
        {
            string sql = "SELECT * FROM  `pos_items` where it_id='" + ID.ToString() + "'";
            DataTable dt = new DataTable();
            dt = DB.DB_Connect.SqlCommandToDataTable(sql);
            BuyItemID = Int32.Parse(dt.Rows[0][0].ToString());
            BuyItemName = dt.Rows[0][1].ToString();
            BuyItemPrice = Int32.Parse(dt.Rows[0][2].ToString());


            if (GridViewCurrentRow <= 19)
            {
                Dg_Items_List[1, GridViewCurrentRow].Value = BuyItemName;
                Dg_Items_List[2, GridViewCurrentRow].Value = 1;
                Dg_Items_List[3, GridViewCurrentRow].Value = BuyItemPrice;
                Dg_Items_List[4, GridViewCurrentRow].Value = BuyItemPrice * 1;
                Dg_Items_List[5, GridViewCurrentRow].Value = BuyItemID.ToString();
            }
            else
            {
                Dg_Items_List.Rows.Add(GridViewCurrentRow + 1, BuyItemName, 1, BuyItemPrice, BuyItemPrice * 1, BuyItemID.ToString());
            }

            Dg_Items_List.Rows[GridViewCurrentRow].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            GridViewCurrentRow++;
            CalculateGridView();
            BtnManager[1].Enabled = false;
            BtnManager[1].BackColor = System.Drawing.Color.Gray;
            BtnManager[2].Enabled = true;
            BtnManager[2].BackColor = System.Drawing.Color.LightGreen;
            FlowSticky.Enabled = false;
            GridviewStatus = "UPDATE";
            Dg_Items_List.FirstDisplayedScrollingRowIndex = Dg_Items_List.RowCount - 1;
        }
        public void CalculateGridView()
        {
            int x = 0;
            //MessageBox.Show("GridviewSaved : " + GridviewSaved);
            foreach (DataGridViewRow row in Dg_Items_List.Rows)
            {
                x++;
                if (row.Cells[2].Value.ToString() != "")
                {
                    GridviewTotal = GridviewTotal + Int32.Parse(row.Cells[4].Value.ToString());
                }
            }
            LEDCalculator.Text = GridviewTotal.ToString();
            GridviewTotal = 0;
        }
        public static void GridviewClearData()
        {
            Dg_Items_List.Rows.Clear();
            GridViewCurrentRow = 0;
            for (int x = 1; x <= 20; x++)
            {
                Dg_Items_List.Rows.Add(x, "", "", "");
            }
            BtnManager[0].Enabled = false;
            BtnManager[0].BackColor = System.Drawing.Color.Gray;
            BtnManager[2].Enabled = false;
            BtnManager[2].BackColor = System.Drawing.Color.Gray;
            BtnManager[5].Enabled = false;
            BtnManager[5].BackColor = System.Drawing.Color.Gray;
        }

        public void Create_Button_Layout()
        {
            int i = 0;

            ///////////  CREATE BUTTON MANAGER //////////////
            foreach (string st in BtnName)
            {
                BtnManager[i] = new POS_Screen.Object_Controls.ManagerButton();
                BtnManager[i].Text = st;
                BtnManager[i].Cursor = System.Windows.Forms.Cursors.Hand;
                //MessageBox.Show(st);
                FlowButtonManager.Controls.Add(BtnManager[i]);
                BtnManager[i].Click += new EventHandler(BtnManager_Click);
                BtnManager[i].BackColor = System.Drawing.Color.LightGreen;
                i++;

            }
            ///////////  END  //////////////////////////////////

            POS_Screen.Object_Controls.FavoritesButton[] bt = new POS_Screen.Object_Controls.FavoritesButton[20];
            string sql = "select * from st_group_item limit 0,6";
            //string sql = "select * from pos_group_item limit 0,6";
            DataTable dt = new DataTable();
            dt = DB.DB_Connect.SqlCommandToDataTable(sql);
            int numRows = dt.Rows.Count;
            i = 0;
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                bt[i] = new POS_Screen.Object_Controls.FavoritesButton();
                bt[i].Text = row["group_name"].ToString();
                int GroupID = Int32.Parse(row["group_id"].ToString());
                //MessageBox.Show(GroupID.ToString());
                FlowFaviritor.Controls.Add(bt[i]);
                //  bt[i].Click += (sender, e) => POS.ControlsFlowRightMain.LoadButtonItemMenu(GroupID);
                bt[i].Click += (sender, e) => LoadButtonItemMenu(GroupID);
                i++;
            }

            //StickyFlowView();
        }
        public void BtnManager_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Text)
            {
                case "[F2]Payment":
                    // POS.SaveOrderBill("C");
                    //MessageBox.Show("dddddd");
                    break;
                case "[F3]New Bill":
                    GridviewClearData();
                    //StickyFlowView();
                    break;
                case "[F4]Save Bill":
                    GridView2Data();
                    break;
                case "Check Var":
                    MessageBox.Show("GridviewStatus : " + GridviewStatus);
                    MessageBox.Show("GridviewHoldBillEditID : " + GridviewHoldBillEditID);
                    MessageBox.Show("GridViewCurrentRow" + GridViewCurrentRow);
                    //x.xxx(GridViewCurrentRow);
                    break;
                case "Remove Bill":
                    RemoveBill();
                    GridviewHoldBillEditID = "NO";
                    GridviewClearData();
                    FlowSticky.Enabled = true;
                    StickyFlowView();
                    LEDCalculator.Text = "0.00";
                    break;

                case "Admin Menu":
                    this.Controls.Remove(FlowRightMain);
                    this.Controls.Remove(FlowFaviritor);

                    //TODO
                    //this.Controls.Add(FlowAdmin);
                    FlowRightMain.Controls.Clear();
                    FlowButtonManager.Controls.Clear();
                    FlowFaviritor.Controls.Clear();
                    ShowAdminBtn();
                    AdminManagerx.Show(this);
                    //SetObjectStockAdmin();
                    break;
                case "Sale Screen":
                    AdminManagerx.Remove(this);
                    FlowRightMain.Controls.Clear();
                    this.Controls.Add(FlowRightMain);
                    this.Controls.Add(FlowFaviritor);

                    // TODO
                    //this.Controls.Remove(FlowAdmin);

                    FlowButtonManager.Controls.Clear();
                    //this.Controls.Add(FlowLayout);
                    //this.Controls.Add(Flow_Fav_Main);
                    Create_Button_Layout();
                    LoadButtonItemMenu(1);
                    break;
                case "Stock":
                    // SetObjectStockAdmin();
                    break;

                case "Report":
                    //SetObjectReportAdmin();

                    break;
            }
        }
        public void GridView2Data()
        {
            DateTime dt = DateTime.Now;
            MessageBox.Show("GridviewHoldBillEditID : " + GridviewHoldBillEditID);
            string time_id = dt.ToString("yyyyMMddHHmmFFFFFFF");

            if (GridviewHoldBillEditID != "NO") RemoveBill();

            String sql = "INSERT INTO `pos_bill` (`bill_id` ,`bill_time` ,`bill_status`)VALUES (NULL ,  '" + time_id + "',  'H');";
            SQLiteCommand command = new SQLiteCommand(sql, DB.DB_Connect.POSCONNECTMYSQL);
            command.ExecuteNonQuery();
            int list_id = 1;
            foreach (DataGridViewRow row in Dg_Items_List.Rows)
            {
                if (row.Cells[3].Value.ToString() != "")
                {
                    command.CommandText = "INSERT INTO `pos_bill_list` VALUES (NULL, " + list_id.ToString() + ", '" + time_id + "', '" + list_id.ToString() + "', " + row.Cells[5].Value.ToString() + ", " + row.Cells[2].Value.ToString() + ", 'Y', 1);";
                    command.ExecuteNonQuery();
                    list_id++;
                }
            }
            GridViewCurrentRow = 0;
            LEDCalculator.Text = "0.00";
            GridviewClearData();
            StickyFlowView();
            FlowSticky.Enabled = true;
            BtnManager[1].Enabled = true;
            BtnManager[1].BackColor = System.Drawing.Color.LightGreen;
            GridviewStatus = "NEW";
            GridviewHoldBillEditID = "NO";
        }
        public void StickyFlowView()
        {
            FlowSticky.Controls.Clear();
            string sql = "SELECT * FROM  `pos_bill` where bill_status ='H'";
            DataTable dt = new DataTable();
            dt = DB.DB_Connect.SqlCommandToDataTable(sql);
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                //POS_OBJ.StickyBillButton st = new POS_OBJ.StickyBillButton();
                POS_Screen.Object_Controls.StickyBillButton st = new POS_Screen.Object_Controls.StickyBillButton();
                st.Name = row[1].ToString();
                st.Click += new EventHandler(StickyLoadByID);
                st.Enabled = true;
                FlowSticky.Controls.Add(st);
            }
        }
        public void RemoveBill()
        {
            string sql = "DELETE FROM \"pos_bill\" WHERE (\"bill_time\"=" + GridviewHoldBillEditID + ")";
            SQLiteCommand command = new SQLiteCommand(sql, DB.DB_Connect.POSCONNECTMYSQL);
            command.ExecuteNonQuery();
            sql = "DELETE FROM \"pos_bill_list\" WHERE (\"pl_bill_time_id\"=" + GridviewHoldBillEditID + ")";
            command.CommandText = sql;
            command.ExecuteNonQuery();

        }



        public void ShowAdminBtn()
        {
            int i = 0;

            ///////////  CREATE BUTTON MANAGER //////////////
            foreach (string st in AdminMenuBtn)
            {
                BtnManager[i] = new POS_Screen.Object_Controls.ManagerButton();
                BtnManager[i].Text = st;
                //MessageBox.Show(st);
                FlowButtonManager.Controls.Add(BtnManager[i]);
                BtnManager[i].Click += new EventHandler(BtnManager_Click);
                //BtnManager[i].BackColor = System.Drawing.Color.LightGreen;
                i++;

            }

        }



        public void StickyLoadByID(object sender, EventArgs e)
        {
            GridviewClearData();
            ((Button)sender).BackgroundImage = global::pos2017.Properties.Resources.bill_active;
            foreach (Control x in FlowSticky.Controls)
            {
                if (x.Name.ToString() != ((Button)sender).Name.ToString())
                {
                    x.BackgroundImage = global::pos2017.Properties.Resources.bill;
                    x.Enabled = true;

                }
                else
                {
                    x.Enabled = false;
                }
            }

            string sql = "SELECT pos_items.it_name,pos_bill_list.pl_qty,pos_items.it_ss_price,pos_items.it_id " +
                         " FROM pos_bill " +
                         "INNER JOIN pos_bill_list ON pos_bill.bill_time = pos_bill_list.pl_bill_time_id " +
                         "INNER JOIN pos_items ON pos_bill_list.pl_item_id = pos_items.it_id " +
                         "WHERE  pos_bill_list.pl_bill_time_id ='" + ((Button)sender).Name.ToString() + "'";
            DataTable dt = DB.DB_Connect.SqlCommandToDataTable(sql);
            int count_row = 0;
            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                //MessageBox.Show(sql);

                if (count_row <= 19)
                {
                    Dg_Items_List[1, count_row].Value = row[0].ToString();
                    Dg_Items_List[2, count_row].Value = row[1].ToString();
                    Dg_Items_List[3, count_row].Value = row[2].ToString();
                    Dg_Items_List[4, count_row].Value = Int32.Parse(row[2].ToString()) * Int32.Parse(row[1].ToString());
                    Dg_Items_List[5, count_row].Value = row[3].ToString();
                    Dg_Items_List.Rows[count_row].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;

                }
                else
                {
                    Dg_Items_List.Rows.Add(count_row + 1, row[0].ToString(), row[1].ToString(), row[2].ToString(), Int32.Parse(row[2].ToString()) * Int32.Parse(row[1].ToString()), row[3].ToString());
                    Dg_Items_List.Rows[count_row].DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                }
                count_row++;
            }
            Dg_Items_List.FirstDisplayedScrollingRowIndex = Dg_Items_List.RowCount - 1;
            GridViewCurrentRow = count_row;
            GridviewStatus = "OPEN";
            GridviewHoldBillEditID = ((Button)sender).Name.ToString();
            CalculateGridView();
            BtnManager[5].Enabled = true;
            BtnManager[5].BackColor = System.Drawing.Color.LightGreen;
        }

        public void SetObjectStockAdmin() // User Interface For Admin Sections
        {
            //FlowAdmin.BackColor = System.Drawing.Color.Blue;

          //  FlowAdmin.Controls.Clear();
            //FlowAdmin.Controls.Add(TextQryStock);
            //FlowAdmin.Controls.Add(DataGridViewStock);
        }





    }
}
