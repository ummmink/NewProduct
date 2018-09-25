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
            this.button1 = new System.Windows.Forms.Button();
            this.lbItem = new System.Windows.Forms.Label();
            this.lsbInProgressSearchItems = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnLineTop = new System.Windows.Forms.Panel();
            this.pnLineBottom = new System.Windows.Forms.Panel();
            this.lbItemHeader1 = new System.Windows.Forms.Label();
            this.lbItemHeader2 = new System.Windows.Forms.Label();
            this.lbItemHeader3 = new System.Windows.Forms.Label();
            this.pnSearchResult = new System.Windows.Forms.Panel();
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
            this.txtSearchBox.Enter += new System.EventHandler(this.txtSearchBox_Enter);
            this.txtSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchBox_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Salmon;
            this.panel1.Controls.Add(this.cbSelectTableNPD);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Salmon;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Salmon;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(677, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 35);
            this.button1.TabIndex = 72;
            this.button1.Tag = "";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
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
            this.lbItemHeader1.Size = new System.Drawing.Size(126, 16);
            this.lbItemHeader1.TabIndex = 2;
            this.lbItemHeader1.Text = "Reference No.";
            this.lbItemHeader1.Visible = false;
            // 
            // lbItemHeader2
            // 
            this.lbItemHeader2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbItemHeader2.ForeColor = System.Drawing.Color.Salmon;
            this.lbItemHeader2.Location = new System.Drawing.Point(223, 135);
            this.lbItemHeader2.Name = "lbItemHeader2";
            this.lbItemHeader2.Size = new System.Drawing.Size(126, 16);
            this.lbItemHeader2.TabIndex = 50;
            this.lbItemHeader2.Text = "Product ID";
            this.lbItemHeader2.Visible = false;
            // 
            // lbItemHeader3
            // 
            this.lbItemHeader3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbItemHeader3.ForeColor = System.Drawing.Color.Salmon;
            this.lbItemHeader3.Location = new System.Drawing.Point(366, 135);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnLineTop;
        private System.Windows.Forms.Panel pnLineBottom;
        private System.Windows.Forms.Label lbItemHeader1;
        private System.Windows.Forms.Label lbItemHeader2;
        private System.Windows.Forms.Label lbItemHeader3;
        private System.Windows.Forms.Panel pnSearchResult;
        private System.Windows.Forms.ComboBox cbSelectTableNPD;
    }
}