using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace pos2017.POS_Screen
{
    class Object_Controls
    {
        public static int CountFavilatorBtn = 0;

        public class POSGridview : DataGridView
        {
            
            public POSGridview()
                : base()
            {
                /// DataGrid Item Size 4
                int x = (Screen.PrimaryScreen.Bounds.Width / 12) * 4;
                int Column_Width = (x / 12);
                Size = new System.Drawing.Size(x, 532);
                RowTemplate.Height = 25;
                ColumnHeadersHeight = 30;
                Location = new Point(0, 128);
                Columns.Add("no", "No.");
                Columns[0].Width = Column_Width * 1;

                Columns.Add("item_name", "Name");
                Columns[1].Width = (Column_Width * 6)-20;

                Columns.Add("qty", "Qty");
                Columns[2].Width = Column_Width * 1;

                Columns.Add("Price", "Price");
                Columns[3].Width = Column_Width * 2;

                Columns.Add("TPrice", "Total");
                Columns[4].Width = Column_Width * 2;

                Columns.Add("ITEMID", "ITEMID");
                Columns[5].Visible = false;
                ReadOnly = true;
                AllowUserToAddRows = false;
                AllowUserToResizeColumns = false;
                AllowUserToResizeRows = false;
                RowHeadersVisible = false;
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                AllowUserToResizeRows = false;
                Columns["no"].SortMode = DataGridViewColumnSortMode.NotSortable;
                Columns["item_name"].SortMode = DataGridViewColumnSortMode.NotSortable;
                Columns["qty"].SortMode = DataGridViewColumnSortMode.NotSortable;
                Columns["Price"].SortMode = DataGridViewColumnSortMode.NotSortable;
                Columns["TPrice"].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        public class FlowRightMain : FlowLayoutPanel
        {


            public FlowRightMain()
                : base()
            {
                int w = (Screen.PrimaryScreen.Bounds.Width / 12) * 6;
                int l = (Screen.PrimaryScreen.Bounds.Width / 12) * 6;
                Location = new System.Drawing.Point(l, 0);
                //  Name = "flowLayoutPanel1";
                Size = new System.Drawing.Size(w, Screen.PrimaryScreen.Bounds.Height);
                BackColor = System.Drawing.Color.SteelBlue;
            }
        }


        public class FlowFaviritorMain : FlowLayoutPanel
        {
            public FlowFaviritorMain()
                : base()
            {
                int w = (Screen.PrimaryScreen.Bounds.Width / 12) * 1;
                int l = (Screen.PrimaryScreen.Bounds.Width / 12) * 5;
                Location = new System.Drawing.Point(l, 0);
                //  Name = "flowLayoutPanel1";
                Size = new System.Drawing.Size(w,Screen.PrimaryScreen.Bounds.Height);
                BackColor = System.Drawing.Color.SteelBlue;
            }
        }

        public class FlowMainButtonManager : FlowLayoutPanel
        {
            public FlowMainButtonManager()
                : base()
            {
                int w = (Screen.PrimaryScreen.Bounds.Width / 12) * 1;
                int l = (Screen.PrimaryScreen.Bounds.Width / 12) * 4;
                Location = new System.Drawing.Point(l, 0);
                //  Name = "flowLayoutPanel1";
                Size = new System.Drawing.Size(w, Screen.PrimaryScreen.Bounds.Height);
                BackColor = System.Drawing.Color.SteelBlue;
            }
        }

        public class PolaroidButton : Button
        {
            public PolaroidButton()
                : base()
            {



                int Main_Area = (Screen.PrimaryScreen.Bounds.Width / 12) * 6;
                int Btn_Margin = ((Main_Area-((Main_Area / 120)*120)) / (Main_Area / 120)/2) ;
                //MessageBox.Show(Btn_Margin.ToString());
                BackColor = System.Drawing.Color.SteelBlue;
                BackgroundImage = global::pos2017.Properties.Resources.btn3;
                FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                ForeColor = System.Drawing.Color.Black;
                Size = new System.Drawing.Size(120, 125);
                TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
                Margin = new System.Windows.Forms.Padding(Btn_Margin, 0, Btn_Margin, 0);
                Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                FlatStyle = FlatStyle.Flat;
                Cursor = System.Windows.Forms.Cursors.Hand;
                FlatAppearance.BorderSize = 0;
                CountFavilatorBtn =(Main_Area/ (this.Size.Width + (Btn_Margin * 2)) * (Screen.PrimaryScreen.Bounds.Height /  this.Size.Height));
            }
        }
        public class CalculatorArea : TextBox
        {
            public CalculatorArea()
                : base()
            {
                int Btn_Size = (Screen.PrimaryScreen.Bounds.Width / 12) * 4;
                BackColor = System.Drawing.Color.PowderBlue;
                Enabled = false;
                Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                Location = new System.Drawing.Point(5, 1);
                Name = "lbl_price";
                RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                Size = new System.Drawing.Size(Btn_Size, 98);
                TabIndex = 0;
                Text = "0.00";
            }
        }

        public class ManagerButton : Button
        {
            public ManagerButton()
                : base()
            {
                //int Btn_Size = 85;
                int Btn_Size = (Screen.PrimaryScreen.Bounds.Width / 12) * 1;
                if (Btn_Size < 85) Btn_Size = 85;
                Size = new Size(Btn_Size, 64);
                Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
              //  Location = new System.Drawing.Point(509, 485);
                //Size = new System.Drawing.Size(46, 64);
                Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                //UseVisualStyleBackColor = true;
                //this.staff_btn.Click += new System.EventHandler(this.staff_btn_Click);
            }
        }
        public class FlowStickyMain : FlowLayoutPanel
        {
            public FlowStickyMain()
                : base()
            {
                Location = new System.Drawing.Point(5, 666);
                Size = new System.Drawing.Size(498, 54);
            }
        }

        public class FavoritesButton : Button
        {
            public FavoritesButton()
                : base()
            {

                int Btn_Size = (Screen.PrimaryScreen.Bounds.Width / 12) * 1;
                if (Btn_Size < 85) Btn_Size = 85;
                Size = new System.Drawing.Size(Btn_Size, 111);

                BackColor = System.Drawing.Color.SteelBlue;
                FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                ForeColor = System.Drawing.Color.Black;
                TextAlign = System.Drawing.ContentAlignment.BottomCenter;
                FlatStyle = FlatStyle.Flat;
                Cursor = System.Windows.Forms.Cursors.Hand;
                FlatAppearance.BorderSize = 0;
                BackgroundImage = global::pos2017.Properties.Resources.btn_fav1;
                BackgroundImageLayout = ImageLayout.Stretch;
                
                Padding = new System.Windows.Forms.Padding(0, 0, 0, 35);
                Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                Cursor = System.Windows.Forms.Cursors.Hand;
                Font = new System.Drawing.Font("Microsoft Sans Serif", 14.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                FlatAppearance.BorderSize = 0;
            }

        }

        public class FlowAdminMenu : FlowLayoutPanel
        {
            int Col = 7;
            int Start_Col = 5;
            public FlowAdminMenu()
                : base()
            {
                int w = (Screen.PrimaryScreen.Bounds.Width / 12) * Col;
                int l = (Screen.PrimaryScreen.Bounds.Width / 12) * Start_Col;
                Location = new System.Drawing.Point(l, 0);
                //  Name = "flowLayoutPanel1";
                Size = new System.Drawing.Size(w, Screen.PrimaryScreen.Bounds.Height);
                BackColor = System.Drawing.Color.SteelBlue;

            }
            
        }

        public class StickyBillButton : Button
        {
            public StickyBillButton()
                : base()
            {
                BackColor = System.Drawing.Color.Transparent;
                FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                ForeColor = System.Drawing.Color.Black;
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                FlatStyle = FlatStyle.Flat;
                Cursor = System.Windows.Forms.Cursors.Hand;
                FlatAppearance.BorderSize = 0;
                BackgroundImage = global::pos2017.Properties.Resources.bill;
                Size = new System.Drawing.Size(40, 40);
                Cursor = System.Windows.Forms.Cursors.Hand;
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                FlatAppearance.BorderSize = 0;
            }

        }

        public class AdminGroupbox : GroupBox
        {
            public AdminGroupbox()
               : base()
            {

            }
        }

    }
}
