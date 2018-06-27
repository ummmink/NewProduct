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
using NewProduct.Utility;

namespace NewProduct
{
    public partial class New_Popup : Form
    {
        CultureInfo UsaCulture = new CultureInfo("en-US");

        CommonBiz commonBiz = new CommonBiz();

        public New_Popup()
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
            CommonDataSet dsProductChannel = commonBiz.npd_select_product_sell_all_active();
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

        private void btnMixProducts_Click(object sender, EventArgs e)
        {
            pnDetailsSub1.Visible = false;

            pnDetailsProductMix.Visible = true;
            lbProductDetails.Text = "รายละเอียดสินค้าประกอบ";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            pnDetailsProductMix.Visible = false;

            pnDetailsSub1.Visible = true;
            lbProductDetails.Text = "รายละเอียดผลิตภัณฑ์";
        }

        private void grdMainProduct_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            #region bindind product
            CommonDataSet dsPD = commonBiz.npd_select_main_product();
            grdMainProductList.AutoGenerateColumns = false;
            bindingProduct.DataSource = dsPD.NPD_SELECT_MAIN_PRODUCT;
            grdMainProductList.DataSource = bindingProduct;
            #endregion

            DataGridViewComboBoxColumn cboBoxColumn =
               (DataGridViewComboBoxColumn)grdMainProduct.Columns["Product_ID"];

            cboBoxColumn.DataSource = bindingProduct;
            cboBoxColumn.DisplayMember = "PRODUCT_ID";
            cboBoxColumn.ValueMember = "PRODUCT_ID";

            int x = grdMainProductList.Location.X;

            DataGridView dataGridView = (DataGridView)sender;
            int iScroll = dataGridView.FirstDisplayedScrollingRowIndex;

            int iFac = dataGridView.CurrentCell.RowIndex;

            if (dataGridView.CurrentCell.ColumnIndex == 0)
            {
                grdMainProductList.Visible = true;
                grdMainProductList.Location = new Point(x, (73 + (22 * (iFac - iScroll))));
            }
        }

        private void grdMainProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dataGridView = (DataGridView)sender;

                int colIndex;
                int rowIndex;

                colIndex = dataGridView.CurrentCell.ColumnIndex;
                rowIndex = dataGridView.CurrentCell.RowIndex;                

                if (colIndex == 0)
                {
                    dataGridView.Rows[rowIndex].Cells["Product_Name_TH"].Value =
                        grdMainProductList.Rows[bindingProduct.Position].Cells["productNameTH"].Value.ToString();

                    dataGridView.Rows[rowIndex].Cells["Size"].Value =
                        grdMainProductList.Rows[bindingProduct.Position].Cells["productSize"].Value.ToString();

                    dataGridView.Rows[rowIndex].Cells["UNIT_PRICE"].Value =
                        grdMainProductList.Rows[bindingProduct.Position].Cells["unitPrice"].Value.ToString();

                    dataGridView.Rows[rowIndex].Cells["INNER_BOX"].Value =
                        grdMainProductList.Rows[bindingProduct.Position].Cells["innerBox"].Value.ToString();

                    dataGridView.Rows[rowIndex].Cells["PACKING"].Value =
                        grdMainProductList.Rows[bindingProduct.Position].Cells["packingP"].Value.ToString();

                    dataGridView.Rows[rowIndex].Cells["BOTTLE"].Value =
                        grdMainProductList.Rows[bindingProduct.Position].Cells["bottleP"].Value.ToString();

                    SendKeys.Send("{up}");
                }

                else if (colIndex == 3) //Qty
                {
                    SendKeys.Send("{up}");
                    calPrice(dataGridView, rowIndex);
                }

                else if (colIndex == 4) //Unit
                {
                    //colName = dataGridView.Columns[colIndex].Name.ToString();
                    calPrice(dataGridView, rowIndex);
                }

                grdMainProductList.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ข้อความแจ้งเตือน",
                        MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation);
            }
        }

        private void calPrice(DataGridView grd, int rowIndex)
        {
            try
            {
                #region declare variable
                float fBottle = ConvertUtil.parseFloat(grd.Rows[rowIndex].Cells["BOTTLE"].Value);
                float fPack = ConvertUtil.parseFloat(grd.Rows[rowIndex].Cells["PACKING"].Value);
                float fInner = ConvertUtil.parseFloat(grd.Rows[rowIndex].Cells["INNER_BOX"].Value);
                double fUnitPriceNew = ConvertUtil.parseDouble(grd.Rows[rowIndex].Cells["UNIT_PRICE"].Value);
                double iQuantity = ConvertUtil.parseFloat(grd.Rows[rowIndex].Cells["QTY"].Value);

                string strUnit = "ขวด";
                #endregion

                //แปลงราคาต่อหน่วย ให้เป็นตามหน่วยที่ขาย
                if (strUnit == "ขวด")
                {
                    fUnitPriceNew = (fUnitPriceNew / 12) * iQuantity;
                }
                else if ((strUnit == "แพ็ค") || (strUnit == "กระเช้า"))
                {
                    fUnitPriceNew = ((fUnitPriceNew / 12) * fBottle) * iQuantity;
                }

                else if (strUnit == "ลัง")
                {
                    fUnitPriceNew = ((fUnitPriceNew / 12) * fInner * fBottle * fPack) * iQuantity;
                }

                grd.Rows[rowIndex].Cells["LTP"].Value = ConvertUtil.parseFloat(fUnitPriceNew);

                ////หาส่วนลดก่อน
                //if (strUnit == "ขวด")
                //{
                //    if ((strUnitDiscBefore == "แพ็ค") || (strUnitDiscBefore == "กระเช้า"))
                //    {
                //        fDiscBefore = fDiscBefore / fBottle;
                //    }
                //    else if (strUnitDiscBefore == "ลัง")
                //    {
                //        fDiscBefore = fDiscBefore / (fBottle * fPack);
                //    }
                //}
                //else if ((strUnit == "แพ็ค") || (strUnit == "กระเช้า"))
                //{
                //    if (strUnitDiscBefore == "ขวด")
                //    {
                //        fDiscBefore = fDiscBefore / fBottle;
                //    }
                //    else if (strUnitDiscBefore == "ลัง")
                //    {
                //        fDiscBefore = fDiscBefore / fPack;
                //    }
                //}

                //else if (strUnit == "ลัง")
                //{
                //    if (strUnitDiscBefore == "ขวด")
                //    {
                //        fDiscBefore = fDiscBefore * fPack * fBottle;
                //    }
                //    else if ((strUnitDiscBefore == "แพ็ค") || (strUnitDiscBefore == "กระเช้า"))
                //    {
                //        fDiscBefore = fDiscBefore / fPack;
                //    }
                //}

                //double f1 = Math.Round((fUnitPriceNew - fDiscBefore), 2, MidpointRounding.AwayFromZero)
                //    * (fDiscount1 / 100);
                //f1 = Math.Round((fUnitPriceNew - fDiscBefore), 2, MidpointRounding.AwayFromZero)
                //    - Math.Round(f1, 2, MidpointRounding.AwayFromZero);

                //double f2 = Math.Round(f1, 2, MidpointRounding.AwayFromZero) * (fDiscount2 / 100);
                //f2 = Math.Round(f1, 2, MidpointRounding.AwayFromZero)
                //    - Math.Round(f2, 2, MidpointRounding.AwayFromZero);

                //double f3 = Math.Round(f2, 2, MidpointRounding.AwayFromZero) * (fDiscount3 / 100);
                //f3 = Math.Round(f2, 2, MidpointRounding.AwayFromZero)
                //    - Math.Round(f3, 2, MidpointRounding.AwayFromZero);

                ////Discount 4, 5 Oct 9, 2014
                //double f4 = Math.Round(f3, 2, MidpointRounding.AwayFromZero) * (fDiscount4 / 100);
                //f4 = Math.Round(f3, 2, MidpointRounding.AwayFromZero) - Math.Round(f4, 2, MidpointRounding.AwayFromZero);

                //double f5 = Math.Round(f4, 2, MidpointRounding.AwayFromZero) * (fDiscount5 / 100);
                //f5 = Math.Round(f4, 2, MidpointRounding.AwayFromZero) - Math.Round(f5, 2, MidpointRounding.AwayFromZero);

                //double f1o = Math.Round(((fUnitPriceOld * iQuantity) - fDiscBefore), 2, MidpointRounding.AwayFromZero) * (fDiscount1 / 100);
                //f1o = Math.Round(((fUnitPriceOld * iQuantity) - fDiscBefore), 2, MidpointRounding.AwayFromZero)
                //    - Math.Round(f1o, 2, MidpointRounding.AwayFromZero);

                //double f2o = Math.Round(f1o, 2, MidpointRounding.AwayFromZero) * (fDiscount2 / 100);
                //f2o = Math.Round(f1o, 2, MidpointRounding.AwayFromZero)
                //    - Math.Round(f2o, 2, MidpointRounding.AwayFromZero);

                //double f3o = Math.Round(f2o, 2, MidpointRounding.AwayFromZero) * (fDiscount3 / 100);
                //f3o = Math.Round(f2o, 2, MidpointRounding.AwayFromZero)
                //    - Math.Round(f3o, 2, MidpointRounding.AwayFromZero);

                ////Discount 4, 5 Oct 9, 2014
                //double f4o = Math.Round(f3o, 2, MidpointRounding.AwayFromZero) * (fDiscount4 / 100);
                //f4o = Math.Round(f3o, 2, MidpointRounding.AwayFromZero)
                //    - Math.Round(f4o, 2, MidpointRounding.AwayFromZero);

                //double f5o = Math.Round(f4o, 2, MidpointRounding.AwayFromZero) * (fDiscount5 / 100);
                //f5o = Math.Round(f4o, 2, MidpointRounding.AwayFromZero)
                //    - Math.Round(f5o, 2, MidpointRounding.AwayFromZero);

                //fUnitDiscNew = Math.Round(f5, 2, MidpointRounding.AwayFromZero);
                //fUnitDiscOld = Math.Round(f5o, 2, MidpointRounding.AwayFromZero);


                ////หาราคาลดเพิ่ม ลดหลัง
                //if (strUnit == "ขวด")
                //{
                //    if ((strUnitDisc == "แพ็ค") || (strUnitDisc == "กระเช้า"))
                //    {
                //        fDiscount = fDiscount / fBottle;
                //    }
                //    else if (strUnitDisc == "ลัง")
                //    {
                //        fDiscount = fDiscount / (fBottle * fPack);
                //    }
                //}
                //else if ((strUnit == "แพ็ค") || (strUnit == "กระเช้า"))
                //{
                //    if (strUnitDisc == "ขวด")
                //    {
                //        fDiscount = fDiscount / fBottle;
                //    }
                //    else if (strUnitDisc == "ลัง")
                //    {
                //        fDiscount = fDiscount / fPack;
                //    }
                //}

                //else if (strUnit == "ลัง")
                //{
                //    if (strUnitDisc == "ขวด")
                //    {
                //        fDiscount = fDiscount * fPack * fBottle;
                //    }
                //    else if ((strUnitDisc == "แพ็ค") || (strUnitDisc == "กระเช้า"))
                //    {
                //        fDiscount = fDiscount / fPack;
                //    }
                //}

                //if (grd.Rows[rowIndex].Cells["PriceNew"].Value.ToString() == "True")
                //{
                //    grd.Rows[rowIndex].Cells["PriceNew"].Value = true;

                //    grd.Rows[rowIndex].Cells["UnitPrice"].Value =
                //        ConvertUtil.parseFloat(fUnitPriceNew);
                //    grd.Rows[rowIndex].Cells["Amount"].Value = ((fUnitDiscNew - fDiscount) * iQuantity) - fDiscOther;
                //}
                //else
                //{
                //    grd.Rows[rowIndex].Cells["UnitPrice"].Value =
                //        ConvertUtil.parseFloat(fUnitPriceOld);
                //    grd.Rows[rowIndex].Cells["Amount"].Value = ((fUnitDiscOld - fDiscount) * iQuantity) - fDiscOther;
                //}


                //calculateNetPrice();
            }
            catch
            {
            }

        }

        private void grdMainProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void grdMainProduct_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            ComboBox cmbBox = new ComboBox();

            if (dataGridView.CurrentCell.ColumnIndex == 0) //Product_ID
            {
                if (e.Control is ComboBox)
                {
                    if (cmbBox is ComboBox)
                    {
                        if (cmbBox != null)
                        {
                            cmbBox.TextChanged += new EventHandler(cmbBox_TextChanged);
                            cmbBox.KeyDown += new KeyEventHandler(cmbBox_KeyDown);
                        }
                    }
                }
            }

            if (dataGridView.CurrentCell.ColumnIndex == 3) //Quantity
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPressInt);
            }
        }

        private void Control_KeyPressInt(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }
        }

        private void cmbBox_TextChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).Text.Length >= 1)
            {
                string searchValue = (sender as ComboBox).Text.ToString();
                int rowIndex = -1;

                foreach (DataGridViewRow row in grdMainProductList.Rows)
                {
                    if (row.Cells[0].Value.ToString().StartsWith(searchValue))
                    {
                        rowIndex = row.Index;
                        bindingProduct.Position = rowIndex;
                        grdMainProductList.Rows[rowIndex].Selected = true;
                        break;
                    }
                    else
                    {
                        grdMainProductList.Rows[0].Selected = true;
                    }
                }

            }
        }

        private void cmbBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;

                if (grdMainProductList.Rows.Count >= 1)
                {
                    int i = grdMainProductList.SelectedCells[0].RowIndex - 1;

                    if (i > -1 && i < grdMainProductList.Rows.Count)
                    {
                        grdMainProductList.Rows[i].Selected = true;
                        bindingProduct.Position = i;
                    }

                }

            }


            else if (e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;

                if (grdMainProductList.Rows.Count >= 1)
                {
                    int i = grdMainProductList.SelectedCells[0].RowIndex + 1;

                    if (i > -1 && i < grdMainProductList.Rows.Count)
                    {
                        grdMainProductList.Rows[i].Selected = true;
                        bindingProduct.Position = i;
                    }
                }
            }
        }

        private void grdFreeProduct_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            #region bindind free product
            CommonDataSet dsPD = commonBiz.npd_select_main_product();
            grdFreeProductList.AutoGenerateColumns = false;
            bindingFreeProduct.DataSource = dsPD.NPD_SELECT_MAIN_PRODUCT;
            grdFreeProductList.DataSource = bindingFreeProduct;
            #endregion

            DataGridViewComboBoxColumn cboBoxColumn =
               (DataGridViewComboBoxColumn)grdFreeProduct.Columns["FPRODUCT_ID"];

            cboBoxColumn.DataSource = bindingFreeProduct;
            cboBoxColumn.DisplayMember = "PRODUCT_ID";
            cboBoxColumn.ValueMember = "PRODUCT_ID";

            int x = grdFreeProductList.Location.X;

            DataGridView dataGridView = (DataGridView)sender;
            int iScroll = dataGridView.FirstDisplayedScrollingRowIndex;

            int iFac = dataGridView.CurrentCell.RowIndex;

            if (dataGridView.CurrentCell.ColumnIndex == 0)
            {
                grdFreeProductList.Visible = true;
                grdFreeProductList.Location = new Point(x, (279 + (22 * (iFac - iScroll))));
            }
        }

        private void grdFreeProduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dataGridView = (DataGridView)sender;

                int colIndex;
                int rowIndex;

                colIndex = dataGridView.CurrentCell.ColumnIndex;
                rowIndex = dataGridView.CurrentCell.RowIndex;

                if (colIndex == 0)
                {
                    dataGridView.Rows[rowIndex].Cells["FproductNameTHp"].Value =
                        grdFreeProductList.Rows[bindingFreeProduct.Position].Cells["FproductNameTH"].Value.ToString();

                    dataGridView.Rows[rowIndex].Cells["FSIZE"].Value =
                        grdFreeProductList.Rows[bindingFreeProduct.Position].Cells["fSizeP"].Value.ToString();

                    dataGridView.Rows[rowIndex].Cells["FUNIT_PRICE"].Value =
                        grdFreeProductList.Rows[bindingFreeProduct.Position].Cells["fUnitPrice"].Value.ToString();

                    dataGridView.Rows[rowIndex].Cells["FINNER_BOX"].Value =
                        grdFreeProductList.Rows[bindingFreeProduct.Position].Cells["fInnerBox"].Value.ToString();

                    dataGridView.Rows[rowIndex].Cells["FPACKING"].Value =
                        grdFreeProductList.Rows[bindingFreeProduct.Position].Cells["fPackingP"].Value.ToString();

                    dataGridView.Rows[rowIndex].Cells["FBOTTLE"].Value =
                        grdFreeProductList.Rows[bindingFreeProduct.Position].Cells["fBottleP"].Value.ToString();

                    SendKeys.Send("{up}");
                }

                else if (colIndex == 3) //Qty
                {
                    SendKeys.Send("{up}");
                    //colName = dataGridView.Columns[colIndex+2].Name.ToString();
                    //calPrice(dataGridView, rowIndex);
                }

                grdFreeProductList.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ข้อความแจ้งเตือน",
                        MessageBoxButtons.OK,
                         MessageBoxIcon.Exclamation);
            }
        }

        private void grdFreeProduct_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            ComboBox cmbBox = new ComboBox();

            if (dataGridView.CurrentCell.ColumnIndex == 0) //Product_ID
            {
                if (e.Control is ComboBox)
                {
                    if (cmbBox is ComboBox)
                    {
                        if (cmbBox != null)
                        {
                            cmbBox.TextChanged += new EventHandler(cmbBox_TextChanged);
                            cmbBox.KeyDown += new KeyEventHandler(cmbBox_KeyDown);
                        }
                    }
                }
            }

            if (dataGridView.CurrentCell.ColumnIndex == 3) //Quantity
            {
                e.Control.KeyPress += new KeyPressEventHandler(Control_KeyPressInt);
            }
        }

        private void grdFreeProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }
    }
}
