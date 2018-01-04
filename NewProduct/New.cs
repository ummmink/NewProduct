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
    public partial class New : Form
    {
        public New()
        {
            InitializeComponent();
        }

        private void ChangeColorByTag(string tag)
        {
            foreach (var c in this.Controls.OfType<Button>())
            {
                if (c.Tag != null && c.Tag.Equals(tag))
                {
                    (c as Button).BackColor = Color.FromArgb(189, 189, 255);
                    (c as Button).ForeColor = Color.Black;
                    (c as Button).Tag = "Black";
                }
                else
                {
                    (c as Button).BackColor = Color.Black;
                    (c as Button).ForeColor = Color.FromArgb(189, 189, 255);
                }                    
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            btnDetails.Tag = "Blue";

            ChangeColorByTag("Blue");
        }

        private void btnDimention_Click(object sender, EventArgs e)
        {
            btnDimention.Tag = "Blue";

            ChangeColorByTag("Blue");
        }

        private void btnProductID_Click(object sender, EventArgs e)
        {
            btnProductID.Tag = "Blue";

            ChangeColorByTag("Blue");
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            btnBarcode.Tag = "Blue";

            ChangeColorByTag("Blue");
        }

        private void btnShortName_Click(object sender, EventArgs e)
        {
            btnShortName.Tag = "Blue";

            ChangeColorByTag("Blue");
        }

        private void btnMatCodeDK_Click(object sender, EventArgs e)
        {
            btnMatCodeDK.Tag = "Blue";

            ChangeColorByTag("Blue");
        }
    }
}
