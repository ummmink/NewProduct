namespace NewProduct
{
    partial class Search
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSelectTableNPD = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbItem = new System.Windows.Forms.Label();
            this.lsbInProgressSearchItems = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnLineTop = new System.Windows.Forms.Panel();
            this.pnLineBottom = new System.Windows.Forms.Panel();
            this.lbItemHeader1 = new System.Windows.Forms.Label();
            this.lbItemHeader2 = new System.Windows.Forms.Label();
            this.lbItemHeader3 = new System.Windows.Forms.Label();
            this.pnSearchResult = new System.Windows.Forms.Panel();
            this.lbItemHeader4 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtSearchBox.Location = new System.Drawing.Point(237, 5);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(425, 27);
            this.txtSearchBox.TabIndex = 0;
            this.txtSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchBox_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Salmon;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.cbSelectTableNPD);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.lbItem);
            this.panel1.Controls.Add(this.txtSearchBox);
            this.panel1.Location = new System.Drawing.Point(44, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1273, 38);
            this.panel1.TabIndex = 47;
            // 
            // cbSelectTableNPD
            // 
            this.cbSelectTableNPD.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectTableNPD.FormattingEnabled = true;
            this.cbSelectTableNPD.Items.AddRange(new object[] {
            "In progress",
            "Approved"});
            this.cbSelectTableNPD.Location = new System.Drawing.Point(115, 5);
            this.cbSelectTableNPD.Name = "cbSelectTableNPD";
            this.cbSelectTableNPD.Size = new System.Drawing.Size(116, 27);
            this.cbSelectTableNPD.TabIndex = 74;
            this.cbSelectTableNPD.SelectedIndexChanged += new System.EventHandler(this.cbSelectTableNPD_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(35, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 18);
            this.label4.TabIndex = 73;
            this.label4.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Salmon;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Salmon;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(677, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(39, 35);
            this.btnSearch.TabIndex = 72;
            this.btnSearch.Tag = "";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnSearch, "Search");
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbItem
            // 
            this.lbItem.AutoSize = true;
            this.lbItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbItem.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbItem.ForeColor = System.Drawing.Color.White;
            this.lbItem.Location = new System.Drawing.Point(730, 9);
            this.lbItem.Name = "lbItem";
            this.lbItem.Size = new System.Drawing.Size(48, 18);
            this.lbItem.TabIndex = 1;
            this.lbItem.Text = "XXXX";
            this.toolTip1.SetToolTip(this.lbItem, "คลิ๊กเพื่อเลือกหัวข้อที่ต้องการค้นหา");
            this.lbItem.Click += new System.EventHandler(this.lbItem_Click);
            // 
            // lsbInProgressSearchItems
            // 
            this.lsbInProgressSearchItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lsbInProgressSearchItems.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lsbInProgressSearchItems.FormattingEnabled = true;
            this.lsbInProgressSearchItems.ItemHeight = 18;
            this.lsbInProgressSearchItems.Location = new System.Drawing.Point(774, 112);
            this.lsbInProgressSearchItems.Name = "lsbInProgressSearchItems";
            this.lsbInProgressSearchItems.Size = new System.Drawing.Size(332, 76);
            this.lsbInProgressSearchItems.TabIndex = 52;
            this.lsbInProgressSearchItems.Visible = false;
            this.lsbInProgressSearchItems.SelectedIndexChanged += new System.EventHandler(this.lsbSearchItems_SelectedIndexChanged);
            // 
            // pnLineTop
            // 
            this.pnLineTop.BackColor = System.Drawing.Color.Salmon;
            this.pnLineTop.Location = new System.Drawing.Point(44, 128);
            this.pnLineTop.Name = "pnLineTop";
            this.pnLineTop.Size = new System.Drawing.Size(1273, 1);
            this.pnLineTop.TabIndex = 48;
            this.pnLineTop.Visible = false;
            // 
            // pnLineBottom
            // 
            this.pnLineBottom.BackColor = System.Drawing.Color.Salmon;
            this.pnLineBottom.Location = new System.Drawing.Point(44, 159);
            this.pnLineBottom.Name = "pnLineBottom";
            this.pnLineBottom.Size = new System.Drawing.Size(1273, 1);
            this.pnLineBottom.TabIndex = 49;
            this.pnLineBottom.Visible = false;
            // 
            // lbItemHeader1
            // 
            this.lbItemHeader1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbItemHeader1.ForeColor = System.Drawing.Color.Salmon;
            this.lbItemHeader1.Location = new System.Drawing.Point(82, 135);
            this.lbItemHeader1.Name = "lbItemHeader1";
            this.lbItemHeader1.Size = new System.Drawing.Size(118, 16);
            this.lbItemHeader1.TabIndex = 2;
            this.lbItemHeader1.Text = "Reference No.";
            this.lbItemHeader1.Visible = false;
            // 
            // lbItemHeader2
            // 
            this.lbItemHeader2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbItemHeader2.ForeColor = System.Drawing.Color.Salmon;
            this.lbItemHeader2.Location = new System.Drawing.Point(205, 135);
            this.lbItemHeader2.Name = "lbItemHeader2";
            this.lbItemHeader2.Size = new System.Drawing.Size(118, 16);
            this.lbItemHeader2.TabIndex = 50;
            this.lbItemHeader2.Text = "Short Name";
            this.lbItemHeader2.Visible = false;
            // 
            // lbItemHeader3
            // 
            this.lbItemHeader3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbItemHeader3.ForeColor = System.Drawing.Color.Salmon;
            this.lbItemHeader3.Location = new System.Drawing.Point(328, 135);
            this.lbItemHeader3.Name = "lbItemHeader3";
            this.lbItemHeader3.Size = new System.Drawing.Size(360, 16);
            this.lbItemHeader3.TabIndex = 51;
            this.lbItemHeader3.Text = "Product Name TH";
            this.lbItemHeader3.Visible = false;
            // 
            // pnSearchResult
            // 
            this.pnSearchResult.AutoScroll = true;
            this.pnSearchResult.Location = new System.Drawing.Point(44, 162);
            this.pnSearchResult.Name = "pnSearchResult";
            this.pnSearchResult.Size = new System.Drawing.Size(1273, 547);
            this.pnSearchResult.TabIndex = 53;
            // 
            // lbItemHeader4
            // 
            this.lbItemHeader4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbItemHeader4.ForeColor = System.Drawing.Color.Salmon;
            this.lbItemHeader4.Location = new System.Drawing.Point(693, 135);
            this.lbItemHeader4.Name = "lbItemHeader4";
            this.lbItemHeader4.Size = new System.Drawing.Size(360, 16);
            this.lbItemHeader4.TabIndex = 54;
            this.lbItemHeader4.Text = "Product Name EN";
            this.lbItemHeader4.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Salmon;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Salmon;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(1230, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 35);
            this.btnExit.TabIndex = 75;
            this.btnExit.Tag = "";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnExit, "Close");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1366, 750);
            this.Controls.Add(this.lsbInProgressSearchItems);
            this.Controls.Add(this.pnSearchResult);
            this.Controls.Add(this.lbItemHeader3);
            this.Controls.Add(this.lbItemHeader2);
            this.Controls.Add(this.lbItemHeader1);
            this.Controls.Add(this.pnLineBottom);
            this.Controls.Add(this.pnLineTop);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbItemHeader4);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product";
            this.Load += new System.EventHandler(this.Product_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbItem;
        private System.Windows.Forms.ListBox lsbInProgressSearchItems;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnLineTop;
        private System.Windows.Forms.Panel pnLineBottom;
        private System.Windows.Forms.Label lbItemHeader1;
        private System.Windows.Forms.Label lbItemHeader2;
        private System.Windows.Forms.Label lbItemHeader3;
        private System.Windows.Forms.Panel pnSearchResult;
        private System.Windows.Forms.ComboBox cbSelectTableNPD;
        private System.Windows.Forms.Label lbItemHeader4;
        private System.Windows.Forms.Button btnExit;
    }
}