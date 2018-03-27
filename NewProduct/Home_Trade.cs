using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProduct
{
    public partial class Home_Trade : Form
    {
        public Home_Trade()
        {
            InitializeComponent();
        }

        private void lbOpenSearchForm_Click(object sender, EventArgs e)
        {
            Form f = new Search();
            f.MdiParent = this.ParentForm;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void lbOpenRenewForm_Click(object sender, EventArgs e)
        {
            Form f = new Renew();
            f.MdiParent = this.ParentForm;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void lbOpenNewForm_Click(object sender, EventArgs e)
        {
            Form f = new New();
            f.MdiParent = this.ParentForm;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void lbOpenStatusForm_Click(object sender, EventArgs e)
        {
            Form f = new Status();
            f.MdiParent = this.ParentForm;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void lbOpenRepeatForm_Click(object sender, EventArgs e)
        {
            Form f = new Repeat();
            f.MdiParent = this.ParentForm;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void lbOpenReportForm_Click(object sender, EventArgs e)
        {
            Form f = new Report();
            f.MdiParent = this.ParentForm;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }
    }
}
