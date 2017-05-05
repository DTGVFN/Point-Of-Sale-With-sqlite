namespace pos2017.UserControls
{
    partial class Admin_Stock
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GroupAddItems = new System.Windows.Forms.GroupBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GroupItemDetail = new System.Windows.Forms.GroupBox();
            this.GroupFindItems = new System.Windows.Forms.GroupBox();
            this.tb_query = new System.Windows.Forms.TextBox();
            this.DataGridViewFindItems = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.GroupFindItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewFindItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GroupAddItems);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1016, 735);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "New Items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupAddItems
            // 
            this.GroupAddItems.Location = new System.Drawing.Point(7, 8);
            this.GroupAddItems.Name = "GroupAddItems";
            this.GroupAddItems.Size = new System.Drawing.Size(1002, 219);
            this.GroupAddItems.TabIndex = 9;
            this.GroupAddItems.TabStop = false;
            this.GroupAddItems.Text = "Product Information";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GroupItemDetail);
            this.tabPage1.Controls.Add(this.GroupFindItems);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1016, 735);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stock Databases";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // GroupItemDetail
            // 
            this.GroupItemDetail.Location = new System.Drawing.Point(447, 73);
            this.GroupItemDetail.Name = "GroupItemDetail";
            this.GroupItemDetail.Size = new System.Drawing.Size(558, 252);
            this.GroupItemDetail.TabIndex = 6;
            this.GroupItemDetail.TabStop = false;
            this.GroupItemDetail.Text = "Items Detail";
            // 
            // GroupFindItems
            // 
            this.GroupFindItems.Controls.Add(this.tb_query);
            this.GroupFindItems.Controls.Add(this.DataGridViewFindItems);
            this.GroupFindItems.Location = new System.Drawing.Point(3, 73);
            this.GroupFindItems.Name = "GroupFindItems";
            this.GroupFindItems.Size = new System.Drawing.Size(435, 529);
            this.GroupFindItems.TabIndex = 5;
            this.GroupFindItems.TabStop = false;
            this.GroupFindItems.Text = "Find Items";
            // 
            // tb_query
            // 
            this.tb_query.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tb_query.Location = new System.Drawing.Point(91, 2);
            this.tb_query.Name = "tb_query";
            this.tb_query.Size = new System.Drawing.Size(220, 26);
            this.tb_query.TabIndex = 1;
            // 
            // DataGridViewFindItems
            // 
            this.DataGridViewFindItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewFindItems.Location = new System.Drawing.Point(5, 34);
            this.DataGridViewFindItems.Name = "DataGridViewFindItems";
            this.DataGridViewFindItems.Size = new System.Drawing.Size(417, 485);
            this.DataGridViewFindItems.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Pink;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 64);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Note By Manager:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1024, 768);
            this.tabControl1.TabIndex = 0;
            // 
            // Admin_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Admin_Stock";
            this.Size = new System.Drawing.Size(1024, 768);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.GroupFindItems.ResumeLayout(false);
            this.GroupFindItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewFindItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GroupFindItems;
        private System.Windows.Forms.TextBox tb_query;
        private System.Windows.Forms.DataGridView DataGridViewFindItems;
        private System.Windows.Forms.GroupBox GroupItemDetail;
        private System.Windows.Forms.GroupBox GroupAddItems;
    }
}
