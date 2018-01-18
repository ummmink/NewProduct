using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewProduct
{
    public partial class New : Form
    {
        CultureInfo UsaCulture = new CultureInfo("en-US");

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

        private void ChangeVisibleByTag(string tag)
        {
            foreach (var c in this.Controls.OfType<Panel>())
            {
                if (c.Tag != null && c.Tag.Equals(tag))
                {
                    (c as Panel).Visible = true;
                    (c as Panel).Tag = "PanelHide";
                    (c as Panel).Location = new Point(46, 115);
                }
                else
                {
                    (c as Panel).Visible = false;
                }
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            //Change button color when click
            btnDetails.Tag = "Blue";
            ChangeColorByTag("Blue");

            //Change panel visible is true when click
            pnDetails.Tag = "PanelShow";
            ChangeVisibleByTag("PanelShow");
        }

        private void btnDimention_Click(object sender, EventArgs e)
        {
            //Change button color when click
            btnDimention.Tag = "Blue";
            ChangeColorByTag("Blue");

            //Change panel visible is true when click
            pnDimention.Tag = "PanelShow";
            ChangeVisibleByTag("PanelShow");
        }

        private void btnProductID_Click(object sender, EventArgs e)
        {
            //Change button color when click
            btnProductID.Tag = "Blue";
            ChangeColorByTag("Blue");

            //Change panel visible is true when click
            pnProductID.Tag = "PanelShow";
            ChangeVisibleByTag("PanelShow");
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            //Change button color when click
            btnBarcode.Tag = "Blue";
            ChangeColorByTag("Blue");

            //Change panel visible is true when click
            pnBarcode.Tag = "PanelShow";
            ChangeVisibleByTag("PanelShow");
        }

        private void btnShortName_Click(object sender, EventArgs e)
        {
            //Change button color when click
            btnShortName.Tag = "Blue";
            ChangeColorByTag("Blue");

            //Change panel visible is true when click
            pnShortName.Tag = "PanelShow";
            ChangeVisibleByTag("PanelShow");
        }

        private void btnMatCodeDK_Click(object sender, EventArgs e)
        {
            //Change button color when click
            btnMatCodeDK.Tag = "Blue";
            ChangeColorByTag("Blue");

            //Change panel visible is true when click
            pnMatCodeDK.Tag = "PanelShow";
            ChangeVisibleByTag("PanelShow");
        }

        private void New_Load(object sender, EventArgs e)
        {
            dtpSampleProductDate.Value = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy", UsaCulture), UsaCulture);
        }
    }
}
