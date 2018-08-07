namespace NewProduct
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.lbOpenStatusForm = new System.Windows.Forms.Label();
            this.lbOpenReportForm = new System.Windows.Forms.Label();
            this.lbOpenSearchForm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbOpenStatusForm
            // 
            this.lbOpenStatusForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbOpenStatusForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbOpenStatusForm.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbOpenStatusForm.ForeColor = System.Drawing.Color.White;
            this.lbOpenStatusForm.Image = ((System.Drawing.Image)(resources.GetObject("lbOpenStatusForm.Image")));
            this.lbOpenStatusForm.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbOpenStatusForm.Location = new System.Drawing.Point(543, 251);
            this.lbOpenStatusForm.Margin = new System.Windows.Forms.Padding(0);
            this.lbOpenStatusForm.Name = "lbOpenStatusForm";
            this.lbOpenStatusForm.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.lbOpenStatusForm.Size = new System.Drawing.Size(272, 198);
            this.lbOpenStatusForm.TabIndex = 59;
            this.lbOpenStatusForm.Text = "Status";
            this.lbOpenStatusForm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbOpenStatusForm.Click += new System.EventHandler(this.lbOpenStatusForm_Click);
            // 
            // lbOpenReportForm
            // 
            this.lbOpenReportForm.BackColor = System.Drawing.Color.LightGreen;
            this.lbOpenReportForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbOpenReportForm.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbOpenReportForm.ForeColor = System.Drawing.Color.White;
            this.lbOpenReportForm.Image = ((System.Drawing.Image)(resources.GetObject("lbOpenReportForm.Image")));
            this.lbOpenReportForm.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbOpenReportForm.Location = new System.Drawing.Point(821, 251);
            this.lbOpenReportForm.Margin = new System.Windows.Forms.Padding(0);
            this.lbOpenReportForm.Name = "lbOpenReportForm";
            this.lbOpenReportForm.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.lbOpenReportForm.Size = new System.Drawing.Size(272, 198);
            this.lbOpenReportForm.TabIndex = 60;
            this.lbOpenReportForm.Text = "Report";
            this.lbOpenReportForm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbOpenReportForm.Click += new System.EventHandler(this.lbOpenReportForm_Click);
            // 
            // lbOpenSearchForm
            // 
            this.lbOpenSearchForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.lbOpenSearchForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbOpenSearchForm.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbOpenSearchForm.ForeColor = System.Drawing.Color.White;
            this.lbOpenSearchForm.Image = ((System.Drawing.Image)(resources.GetObject("lbOpenSearchForm.Image")));
            this.lbOpenSearchForm.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbOpenSearchForm.Location = new System.Drawing.Point(264, 251);
            this.lbOpenSearchForm.Margin = new System.Windows.Forms.Padding(0);
            this.lbOpenSearchForm.Name = "lbOpenSearchForm";
            this.lbOpenSearchForm.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.lbOpenSearchForm.Size = new System.Drawing.Size(272, 198);
            this.lbOpenSearchForm.TabIndex = 61;
            this.lbOpenSearchForm.Text = "Search";
            this.lbOpenSearchForm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbOpenSearchForm.Click += new System.EventHandler(this.lbOpenSearchForm_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1366, 750);
            this.Controls.Add(this.lbOpenSearchForm);
            this.Controls.Add(this.lbOpenReportForm);
            this.Controls.Add(this.lbOpenStatusForm);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbOpenStatusForm;
        private System.Windows.Forms.Label lbOpenReportForm;
        private System.Windows.Forms.Label lbOpenSearchForm;
    }
}