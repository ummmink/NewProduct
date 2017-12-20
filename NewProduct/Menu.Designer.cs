namespace NewProduct
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.lbLogout = new System.Windows.Forms.Label();
            this.lbProjectName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbLogout
            // 
            this.lbLogout.BackColor = System.Drawing.Color.Black;
            this.lbLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLogout.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbLogout.ForeColor = System.Drawing.Color.White;
            this.lbLogout.Image = ((System.Drawing.Image)(resources.GetObject("lbLogout.Image")));
            this.lbLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbLogout.Location = new System.Drawing.Point(1176, 29);
            this.lbLogout.Name = "lbLogout";
            this.lbLogout.Size = new System.Drawing.Size(77, 35);
            this.lbLogout.TabIndex = 42;
            this.lbLogout.Text = "Exit";
            this.lbLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbLogout.Click += new System.EventHandler(this.lbLogout_Click);
            // 
            // lbProjectName
            // 
            this.lbProjectName.AutoSize = true;
            this.lbProjectName.BackColor = System.Drawing.Color.Black;
            this.lbProjectName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbProjectName.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbProjectName.ForeColor = System.Drawing.SystemColors.Window;
            this.lbProjectName.Location = new System.Drawing.Point(43, 34);
            this.lbProjectName.Name = "lbProjectName";
            this.lbProjectName.Size = new System.Drawing.Size(177, 25);
            this.lbProjectName.TabIndex = 43;
            this.lbProjectName.Text = "Product System";
            this.lbProjectName.Click += new System.EventHandler(this.lbProjectName_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.lbProjectName);
            this.Controls.Add(this.lbLogout);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Product System";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLogout;
        private System.Windows.Forms.Label lbProjectName;
    }
}

