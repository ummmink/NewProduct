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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            
        }

        private void lsbSearchItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbItem.Text = lsbSearchItems.SelectedItem.ToString();
            lsbSearchItems.Visible = false;
        }

        private void lbItem_Click(object sender, EventArgs e)
        {
            if (lsbSearchItems.Visible == true)
            {
                lsbSearchItems.Visible = false;
            }
            else
            {
                lsbSearchItems.Visible = true;
            }
        }
    }
}
