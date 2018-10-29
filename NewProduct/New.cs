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

using NewProduct.Business;
using NewProduct.Data;
using NewProduct.Entity;

namespace NewProduct
{
    public partial class New : Form
    {
        CultureInfo UsaCulture = new CultureInfo("en-US");

        CommonBiz commonBiz = new  CommonBiz();

        public New()
        {
            InitializeComponent();

            //Change button color when click
            btnDetails.Tag = "Blue";
            ChangeColorByTag("Blue");

            //Change panel visible is true when click
            pnDetails.Tag = "PanelShow";
            ChangeVisibleByTag("PanelShow");
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
            dtpSampleProductDate.Value = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy", UsaCulture), UsaCulture);
            dtpOrderDate.Value = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy", UsaCulture), UsaCulture);            
        }

        private void rdbNeedSample_Click(object sender, EventArgs e)
        {
            if (rdbNeedSample.Checked == true)
            {
                dtpSampleProductDate.Enabled = true;
                tbQtySample.Enabled = true;
                cbUnitSample.Enabled = true;
            }
            else
            {
                dtpSampleProductDate.Enabled = false;
                tbQtySample.Enabled = false;
                cbUnitSample.Enabled = false;
            }
        }

        private void rdbNoSample_Click(object sender, EventArgs e)
        {
            if (rdbNoSample.Checked == true)
            {              
                dtpSampleProductDate.Enabled = false;
                tbQtySample.Enabled = false;
                cbUnitSample.Enabled = false;
            }
            else
            {
                dtpSampleProductDate.Enabled = true;
                tbQtySample.Enabled = true;
                cbUnitSample.Enabled = true;
            }
        }

        private void cmbProductType_DropDown(object sender, EventArgs e)
        {
            cmbProductItemNo.Text = "";

            #region Binding Product Type
            CommonDataSet dsProductType = commonBiz.npd_select_product_type();
            cmbProductType.DisplayMember = "TYPE_DESC_ENG";
            cmbProductType.ValueMember = "TYPE_ID";
            cmbProductType.DataSource = dsProductType.NPD_SELECT_PRODUCT_TYPE;                 
            #endregion
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = new Bitmap(open.FileName);
                // image file path  
                textBox1.Text = open.FileName;
            }
        }

        private void cmbProductItemNo_DropDown(object sender, EventArgs e)
        {
            #region Binding Product Item_No
            CommonDataSet dsProductItemNo = commonBiz.npd_select_product_item_no_desc_item_name_code_by_type_id(variablePublic.type_id);
            cmbProductItemNo.DisplayMember = "ITEM_NAME".Substring("ITEM_NAME".IndexOf(":") + 1); ;
            cmbProductItemNo.ValueMember = "ITEM_NO";
            cmbProductItemNo.DataSource = dsProductItemNo.NPD_SELECT_PRODUCT_ITEM_NO_DESC_ITEM_NAME_CODE_BY_TYPE_ID;
            #endregion
        }

        private void cmbProductType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            variablePublic.type_id = Int32.Parse(cmbProductType.SelectedValue.ToString());
            variablePublic.item_no = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form f = new Home_Trade();
            f.MdiParent = this.ParentForm;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void tbCaseAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbInnerAmount.Focus();             
            }
        }

        private void tbCaseAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbInnerAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbPackAmount.Focus();
            }
        }

        private void tbInnerAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbPackAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbPackAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbBottleAmount.Focus();
            }
        }

        private void tbBottleAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbBottleAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                btnMixProducts.Focus();
            }
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbPrice_Leave(object sender, EventArgs e)
        {
            if (tbPrice.Text == "")
            {
                tbPrice.Text = "0";
                tbPrice.Text = string.Format("{0:#,##0.00}", double.Parse(tbPrice.Text));
            }
            else
            {
                tbPrice.Text = string.Format("{0:#,##0.00}", double.Parse(tbPrice.Text));
            }
        }

        private void cmbProductItemNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            variablePublic.productPrefix = cmbProductItemNo.SelectedValue.ToString().Substring(cmbProductItemNo.SelectedValue.ToString().LastIndexOf(':') + 1);
            variablePublic.item_no = cmbProductItemNo.SelectedValue.ToString().Substring(0, cmbProductItemNo.SelectedValue.ToString().IndexOf(':'));
            //MessageBox.Show(variablePublic.item_no);
        }

        private void cmbProductItemNo_Format(object sender, ListControlConvertEventArgs e)
        {
            //e.Value = e.Value.ToString().Substring(0, e.Value.ToString().Length - 4);
            //e.Value=e.Value.ToString().Substring(e.Value.ToString().LastIndexOf(':') + 1);
            //e.Value = e.Value.ToString().Substring(0, e.Value.ToString().IndexOf(':'));
        }

        private void cmbChannel_DropDown(object sender, EventArgs e)
        {
            #region Binding Channel
            CommonDataSet dsProductChannel = commonBiz.npd_select_product_sell_all_active(variablePublic.editPassing);
            cmbChannel.DisplayMember = "SELL_NAME";
            cmbChannel.ValueMember = "SELL_ID";
            cmbChannel.DataSource = dsProductChannel.NPD_SELECT_PRODUCT_SELL_ALL_ACTIVE;
            #endregion
        }

        private void cmbChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            variablePublic.sell_id = Int32.Parse(cmbChannel.SelectedValue.ToString().Substring(0, cmbChannel.SelectedValue.ToString().IndexOf(':')));
            variablePublic.channel = cmbChannel.SelectedValue.ToString().Substring(cmbChannel.SelectedValue.ToString().LastIndexOf(':') + 1);
        }
    }
}
