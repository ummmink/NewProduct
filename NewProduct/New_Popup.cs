using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net;
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

        int y, z = 2; // y = axis y of Main Product, z = axis y of Free Product 

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
            dtpSampleProductDate.Value = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy", UsaCulture), UsaCulture);
            dtpOrderDate.Value = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy", UsaCulture), UsaCulture);
        }

        private void rdbNeedSample_Click(object sender, EventArgs e)
        {
            if (rdbNeedSample.Checked == true)
            {
                dtpSampleProductDate.Enabled = true;
                tbQtySamplePiece.Enabled = true;
                tbQtySampleCase.Enabled = true;
            }
            else
            {
                dtpSampleProductDate.Enabled = false;
                tbQtySamplePiece.Enabled = false;
                tbQtySampleCase.Enabled = false;
            }
        }

        private void rdbNoSample_Click(object sender, EventArgs e)
        {
            if (rdbNoSample.Checked == true)
            {
                dtpSampleProductDate.Enabled = false;
                tbQtySamplePiece.Enabled = false;
                tbQtySampleCase.Enabled = false;
            }
            else
            {
                dtpSampleProductDate.Enabled = true;
                tbQtySamplePiece.Enabled = true;
                tbQtySampleCase.Enabled = true;
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
            if (tbPriceRecommend.Text == "")
            {
                tbPriceRecommend.Text = "0";
                tbPriceRecommend.Text = string.Format("{0:#,##0.00}", double.Parse(tbPriceRecommend.Text));
            }
            else
            {
                tbPriceRecommend.Text = string.Format("{0:#,##0.00}", double.Parse(tbPriceRecommend.Text));
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

        private void btnMixProducts_Click(object sender, EventArgs e)
        {
            if (tbReferenceNo.Text == "")
            {
                MessageBox.Show("กรุณาใส่เลขที่อ้างอิง!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbReferenceNo.Focus();
            }
            else
            {
                if (tbPackQty.Text == "")
                {
                    MessageBox.Show("กรุณาใส่ขนาดบรรจุ/ลัง ให้ครบก่อน!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbPackQty.Focus();
                }
                else
                {
                    pnDetailsSub1.Visible = false;

                    pnDetailsProductMix.Visible = true;
                    lbProductDetails.Text = "รายละเอียดสินค้าประกอบ";
                }
            }
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
                grdMainProductList.Location = new Point(x, (81 + (22 * (iFac - iScroll))));
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

                    if (ConvertUtil.parseFloat(dataGridView.Rows[rowIndex].Cells["QTY"].Value) > 0)
                    {
                        calPrice(dataGridView, rowIndex);
                    }

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

                calculateNetPrice();
            }
            catch
            {
            }
        }

        private void calPriceDetail(DataGridView grd, int rowIndex)
        {
            try
            {
                #region declare variable
                float fBottle = ConvertUtil.parseFloat(grd.Rows[rowIndex].Cells["FBOTTLE"].Value);
                float fPack = ConvertUtil.parseFloat(grd.Rows[rowIndex].Cells["FPACKING"].Value);
                float fInner = ConvertUtil.parseFloat(grd.Rows[rowIndex].Cells["FINNER_BOX"].Value);
                double fUnitPriceNew = ConvertUtil.parseDouble(grd.Rows[rowIndex].Cells["FUNIT_PRICE"].Value);
                double iQuantity = ConvertUtil.parseFloat(grd.Rows[rowIndex].Cells["FQTY"].Value);

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

                grd.Rows[rowIndex].Cells["FLTP"].Value = ConvertUtil.parseFloat(fUnitPriceNew);

                calculateNetPriceFree();
            }
            catch
            {
            }
        }

        private void calculateNetPrice()
        {
            //sum
            double fSumAmount = 0;
            int fSumQty = 0;

            for (int i = 0; i < grdMainProduct.Rows.Count - 1; i++)
            {
                fSumAmount += Math.Round(ConvertUtil.parseDouble(grdMainProduct.Rows[i].Cells["LTP"].Value), 2);
                fSumQty += ConvertUtil.parseInt(grdMainProduct.Rows[i].Cells["QTY"].Value);
            }

            if (fSumQty > variablePublic.productBottleQty)
            {
                MessageBox.Show("จำนวนขวดมากเกินกว่าที่ระบุ!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                foreach (DataGridViewRow item in this.grdMainProduct.SelectedRows)
                {
                    grdMainProduct.Rows.RemoveAt(item.Index);
                }
            }
            else
            {
                //ราคาสินค้าปกติ
                tbSumPrice.Text = fSumAmount.ToString("#,##0.00");
                variablePublic.productMainPrice = decimal.Parse(tbSumPrice.Text);

                //จำนวนสินค้าปกติ
                tbSumQty.Text = fSumQty.ToString();
                variablePublic.productMainQty = Int32.Parse(tbSumQty.Text);

                //จำนวนสินค้ารวม
                tbSumQtyTotal.Text = (ConvertUtil.parseInt(tbSumQty.Text) + ConvertUtil.parseInt(tbSumQtyFree.Text)).ToString();
                variablePublic.productTotalQty = Int32.Parse(tbSumQtyTotal.Text);

                //ราคาแนะนำ/แพ็ค
                tbSumPriceTotal.Text = tbSumPrice.Text;
                variablePublic.productTotalPackPrice = decimal.Parse(tbSumPriceTotal.Text);

                //ราคาแนะนำ/ลัง
                tbSumPriceCaseTotal.Text = (decimal.Parse(tbSumPrice.Text) * variablePublic.productPackQty).ToString("#,##0.00");
                variablePublic.productTotalCasePrice = decimal.Parse(tbSumPriceCaseTotal.Text);
            }
        }

        private void calculateNetPriceFree()
        {
            //sum
            double fSumAmount = 0;
            int fSumQty = 0;

            for (int i = 0; i < grdFreeProduct.Rows.Count - 1; i++)
            {
                fSumAmount += Math.Round(ConvertUtil.parseDouble(grdFreeProduct.Rows[i].Cells["FLTP"].Value), 2);
                fSumQty += ConvertUtil.parseInt(grdFreeProduct.Rows[i].Cells["FQTY"].Value);
            }

            if ((fSumQty + ConvertUtil.parseInt(tbSumQty.Text)) > variablePublic.productBottleQty)
            {
                MessageBox.Show("จำนวนขวดมากเกินกว่าที่ระบุ!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                foreach (DataGridViewRow item in this.grdFreeProduct.SelectedRows)
                {
                    grdFreeProduct.Rows.RemoveAt(item.Index);
                }
            }
            else
            {
                //ราคาสินค้าแถม
                tbSumPriceFree.Text = fSumAmount.ToString("#,##0.00");
                variablePublic.productFreePrice = decimal.Parse(tbSumPriceFree.Text);

                //จำนวนสินค้าแถม
                tbSumQtyFree.Text = fSumQty.ToString();
                variablePublic.productFreeQty = Int32.Parse(tbSumQtyFree.Text);

                //จำนวนสินค้ารวม
                tbSumQtyTotal.Text = (ConvertUtil.parseInt(tbSumQty.Text) + ConvertUtil.parseInt(tbSumQtyFree.Text)).ToString();
                variablePublic.productTotalQty = Int32.Parse(tbSumQtyTotal.Text);
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
                grdFreeProductList.Location = new Point(x, (331 + (22 * (iFac - iScroll))));
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

                    if (ConvertUtil.parseFloat(dataGridView.Rows[rowIndex].Cells["FQTY"].Value) > 0)
                    {
                        calPriceDetail(dataGridView, rowIndex);
                    }

                    SendKeys.Send("{up}");
                }

                //else if (colIndex == 3) //Qty
                //{
                //    SendKeys.Send("{up}");
                //    //colName = dataGridView.Columns[colIndex+2].Name.ToString();
                //    //calPrice(dataGridView, rowIndex);
                //}

                else if (colIndex == 3) //Qty
                {
                    SendKeys.Send("{up}");
                    calPriceDetail(dataGridView, rowIndex);
                }

                else if (colIndex == 4) //Unit
                {
                    //colName = dataGridView.Columns[colIndex].Name.ToString();
                    calPriceDetail(dataGridView, rowIndex);
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

        private void cmbChannel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            variablePublic.sell_id = Int32.Parse(cmbChannel.SelectedValue.ToString().Substring(0, cmbChannel.SelectedValue.ToString().IndexOf(':')));
            variablePublic.channel = cmbChannel.SelectedValue.ToString().Substring(cmbChannel.SelectedValue.ToString().LastIndexOf(':') + 1);
        }

        private void cmbOther_DropDown(object sender, EventArgs e)
        {
            #region Binding Product Other 
            CommonDataSet dsProductOther = commonBiz.npd_select_product_other();
            cmbOther.DisplayMember = "OTHER_NAME";
            cmbOther.ValueMember = "OTHER_ID";
            cmbOther.DataSource = dsProductOther.NPD_SELECT_PRODUCT_OTHER;
            #endregion
        }

        private void cmbOther_SelectionChangeCommitted(object sender, EventArgs e)
        {
            variablePublic.product_other_id = Int32.Parse(cmbOther.SelectedValue.ToString().Substring(0, cmbOther.SelectedValue.ToString().IndexOf(':')));
            variablePublic.product_other_name = cmbOther.SelectedValue.ToString().Substring(cmbOther.SelectedValue.ToString().LastIndexOf(':') + 1);
        }

        private void grdMainProduct_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calculateNetPrice();
        }

        private void grdFreeProduct_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calculateNetPriceFree();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnDetailsProductMix.Visible = false;

            pnDetailsSub1.Visible = true;
            lbProductDetails.Text = "รายละเอียดผลิตภัณฑ์";

            tbPriceRecommend.Text = (variablePublic.productTotalCasePrice).ToString("#,##0.00");

            ClearPanel();

            SaveProductHamper();

            PreviewProductHamper();

            tbPrice.Focus();
        }

        private void ClearPanel()
        {
            pnMainProduct.Controls.Clear();
            pnFreeProduct.Controls.Clear();
            y = 2;
            z = 2;
        }

        private void PreviewProductHamper()
        {
            CommonDataSet dsProductHamper = commonBiz.npd_select_product_hamper_temp_by_reference_no(tbReferenceNo.Text);

            for (int i = 0; i < dsProductHamper.NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO.Count; i++)
            {
                if (dsProductHamper.NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO[i].HAMPER_EXTRA == 0) //Main Product
                {
                    //Label Product_Id
                    Label dtProductId = new Label();
                    string headerProductId = dsProductHamper.NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO[i].PRODUCT_SUB_ID.ToString();
                    dtProductId.Text = headerProductId;
                    dtProductId.Location = new System.Drawing.Point(7, y);
                    dtProductId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                    dtProductId.Size = new System.Drawing.Size(91, 14);
                    dtProductId.AutoSize = true;
                    dtProductId.ForeColor = Color.White;
                    dtProductId.TextAlign = ContentAlignment.MiddleCenter;
                    pnMainProduct.Controls.Add(dtProductId);

                    //Label Product_Name_TH
                    CommonDataSet dsProductName = commonBiz.npd_select_product_name_th_by_product_id(dsProductHamper.NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO[i].PRODUCT_SUB_ID.ToString());
                    Label dtProductNameTH = new Label();
                    string headerProductNameTH = dsProductName.NPD_SELECT_PRODUCT_NAME_TH_BY_PRODUCT_ID[0].PRODUCT_NAME_TH.ToString();
                    dtProductNameTH.Text = headerProductNameTH;
                    dtProductNameTH.Location = new System.Drawing.Point(106, y);
                    dtProductNameTH.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                    dtProductNameTH.Size = new System.Drawing.Size(317, 14);
                    dtProductNameTH.AutoSize = true;
                    dtProductNameTH.ForeColor = Color.White;
                    dtProductNameTH.TextAlign = ContentAlignment.MiddleLeft;
                    dtProductNameTH.UseMnemonic = false;
                    pnMainProduct.Controls.Add(dtProductNameTH);

                    //Label Quantity
                    Label dtQuantity = new Label();
                    string headerQuantity = dsProductHamper.NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO[i].QUANTITY.ToString();
                    dtQuantity.Text = String.Format("{0:#,##0}", double.Parse(headerQuantity));
                    dtQuantity.Location = new System.Drawing.Point(430, y);
                    dtQuantity.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                    dtQuantity.Size = new System.Drawing.Size(76, 14);
                    dtQuantity.AutoSize = false;
                    dtQuantity.ForeColor = Color.White;
                    dtQuantity.TextAlign = ContentAlignment.MiddleRight;
                    pnMainProduct.Controls.Add(dtQuantity);

                    //Label Unit
                    Label dtUnit = new Label();
                    //string headerMedia = dsProductHamper.NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO[i].MEDIA_NAME.ToString();
                    dtUnit.Text = "ขวด";
                    dtUnit.Location = new System.Drawing.Point(510, y);
                    dtUnit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                    dtUnit.Size = new System.Drawing.Size(27, 14);
                    dtUnit.AutoSize = false;
                    dtUnit.ForeColor = Color.White;
                    dtUnit.TextAlign = ContentAlignment.MiddleLeft;
                    dtUnit.UseMnemonic = false;
                    pnMainProduct.Controls.Add(dtUnit);

                    y = dtProductId.Location.Y + 21;
                }
                else if (dsProductHamper.NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO[i].HAMPER_EXTRA == 1) //Free Product
                {
                    //Label Product_Id
                    Label dtProductId = new Label();
                    string headerProductId = dsProductHamper.NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO[i].PRODUCT_SUB_ID.ToString();
                    dtProductId.Text = headerProductId;
                    dtProductId.Location = new System.Drawing.Point(7, z);
                    dtProductId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                    dtProductId.Size = new System.Drawing.Size(91, 14);
                    dtProductId.AutoSize = true;
                    dtProductId.ForeColor = Color.FromArgb(255, 128, 0);
                    dtProductId.TextAlign = ContentAlignment.MiddleCenter;
                    pnFreeProduct.Controls.Add(dtProductId);

                    //Label Product_Name_TH
                    CommonDataSet dsProductName = commonBiz.npd_select_product_name_th_by_product_id(dsProductHamper.NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO[i].PRODUCT_SUB_ID.ToString());
                    Label dtProductNameTH = new Label();
                    string headerProductNameTH = dsProductName.NPD_SELECT_PRODUCT_NAME_TH_BY_PRODUCT_ID[0].PRODUCT_NAME_TH.ToString();
                    dtProductNameTH.Text = headerProductNameTH;
                    dtProductNameTH.Location = new System.Drawing.Point(106, z);
                    dtProductNameTH.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                    dtProductNameTH.Size = new System.Drawing.Size(317, 14);
                    dtProductNameTH.AutoSize = true;
                    dtProductNameTH.ForeColor = Color.FromArgb(255, 128, 0);
                    dtProductNameTH.TextAlign = ContentAlignment.MiddleLeft;
                    dtProductNameTH.UseMnemonic = false;
                    pnFreeProduct.Controls.Add(dtProductNameTH);

                    //Label Quantity
                    Label dtQuantity = new Label();
                    string headerQuantity = dsProductHamper.NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO[i].QUANTITY.ToString();
                    dtQuantity.Text = String.Format("{0:#,##0}", double.Parse(headerQuantity));
                    dtQuantity.Location = new System.Drawing.Point(430, z);
                    dtQuantity.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                    dtQuantity.Size = new System.Drawing.Size(76, 14);
                    dtQuantity.AutoSize = false;
                    dtQuantity.ForeColor = Color.FromArgb(255, 128, 0);
                    dtQuantity.TextAlign = ContentAlignment.MiddleRight;
                    pnFreeProduct.Controls.Add(dtQuantity);

                    //Label Unit
                    Label dtUnit = new Label();
                    //string headerMedia = dsProductHamper.NPD_SELECT_PRODUCT_HAMPER_TEMP_BY_REFERENCE_NO[i].MEDIA_NAME.ToString();
                    dtUnit.Text = "ขวด";
                    dtUnit.Location = new System.Drawing.Point(510, z);
                    dtUnit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                    dtUnit.Size = new System.Drawing.Size(27, 14);
                    dtUnit.AutoSize = false;
                    dtUnit.ForeColor = Color.FromArgb(255, 128, 0);
                    dtUnit.TextAlign = ContentAlignment.MiddleLeft;
                    dtUnit.UseMnemonic = false;
                    pnFreeProduct.Controls.Add(dtUnit);

                    z = dtProductId.Location.Y + 21;
                }
            }
        }

        private void SaveProductHamper()
        {
            #region Delete Old MainProduct and FreeProduct
            CommonDataSet dsDelete = commonBiz.npd_delete_all_product_hamper_temp_by_reference_no(tbReferenceNo.Text);
            #endregion

            #region Save MainProduct
            for (int i = 0; i < grdMainProduct.Rows.Count - 1; i++)
            {
                CommonDataSet dsInsertMainProduct = commonBiz.npd_insert_product_hamper_temp(tbReferenceNo.Text, "12345678XXXX",
                    grdMainProduct.Rows[i].Cells["PRODUCT_ID"].Value.ToString(),
                    ConvertUtil.parseInt(grdMainProduct.Rows[i].Cells["QTY"].Value),
                    0,
                    ConvertUtil.parseFloat(grdMainProduct.Rows[i].Cells["LTP"].Value));
            }
            #endregion

            #region Save FreeProduct
            for (int i = 0; i < grdFreeProduct.Rows.Count - 1; i++)
            {
                CommonDataSet dsInsertFreeProduct = commonBiz.npd_insert_product_hamper_temp(tbReferenceNo.Text, "12345678XXXX",
                    grdFreeProduct.Rows[i].Cells["FPRODUCT_ID"].Value.ToString(),
                    ConvertUtil.parseInt(grdFreeProduct.Rows[i].Cells["FQTY"].Value),
                    1,
                    ConvertUtil.parseFloat(grdFreeProduct.Rows[i].Cells["FLTP"].Value));
            }
            #endregion
        }

        private void tbCaseQty_Leave(object sender, EventArgs e)
        {
            if (tbCaseQty.Text != "")
            {
                variablePublic.productCaseQty = Int32.Parse(tbCaseQty.Text);
            }
        }

        private void tbInnerQty_Leave(object sender, EventArgs e)
        {
            if (tbInnerQty.Text != "")
            {
                variablePublic.productInnerBoxQty = Int32.Parse(tbInnerQty.Text);
            }
        }

        private void tbPackQty_Leave(object sender, EventArgs e)
        {
            if (tbPackQty.Text != "")
            {
                variablePublic.productPackQty = Int32.Parse(tbPackQty.Text);
            }
        }

        private void tbBottleQty_Leave(object sender, EventArgs e)
        {
            if (tbBottleQty.Text != "")
            {
                variablePublic.productBottleQty = Int32.Parse(tbBottleQty.Text);
            }
        }

        private void tbCaseQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbInnerQty.Focus();
            }
        }

        private void tbCaseQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbInnerQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbPackQty.Focus();
            }
        }

        private void tbInnerQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbPackQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbBottleQty.Focus();
            }
        }

        private void tbPackQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbBottleQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                btnMixProducts.Focus();
            }
        }

        private void tbBottleQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void pnBarcode_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void cbUnitSample_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pnDetailsSub1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddChennel_Click(object sender, EventArgs e)
        {
            PanelRequestFormShow();

            //try
            //{
            //    //Create the msg object to be sent
            //    MailMessage msg = new MailMessage();
            //    //Add your email address to the recipients             
            //    msg.To.Add(txtName.Text);
            //    //Configure the address we are sending the mail from **- NOT SURE IF I NEED THIS OR NOT?**
            //    MailAddress address = new MailAddress(txtName.Text);
            //    msg.From = address;
            //    //Append their name in the beginning of the subject
            //    //msg.Subject = txtName.Text + " :  " + ddlSubject.Text;
            //    //msg.Body = txtMessage.Text;
            //    msg.Subject = "NPD Test";
            //    msg.Body = "Test";


            //    //Configure an SmtpClient to send the mail.
            //    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            //    client.EnableSsl = true; //only enable this if your provider requires it
            //                             //Setup credentials to login to our sender email address ("UserName", "Password")
            //    NetworkCredential credentials = new NetworkCredential(txtName.Text, ddlSubject.Text);

            //    client.Credentials = credentials;

            //    //Send the msg
            //    client.Send(msg);

            //    //Display some feedback to the user to let them know it was sent
            //    lblResult.Text = "Your message was sent!";

            //    //Clear the form
            //    txtName.Text = "";
            //    txtMessage.Text = "";
            //    ddlSubject.Text = "";
            //}
            //catch
            //{
            //    //If the message failed at some point, let the user know
            //    lblResult.Text = "Your message failed to send, please try again.";
            //}
        }

        private void cmbProductType_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbProductItemNo.Focus();
        }

        private void cmbProductItemNo_SelectedValueChanged(object sender, EventArgs e)
        {
            tbProductNameTH.Focus();
        }

        private void pbImageOfProduct_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.png)|*.jpg; *.jpeg; *.gif; *.png";
            open.FilterIndex = 1;
            open.RestoreDirectory = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pbImageOfProduct.Image = new Bitmap(open.FileName);
                // image file path  
                variablePublic.picturePath = open.FileName;
                MessageBox.Show(variablePublic.picturePath);
            }
        }

        private void btnProductGroup_Click(object sender, EventArgs e)
        {
            PanelRequestFormShow();
        }

        private void PanelRequestFormShow()
        {
            pnRequestForm.Visible = true;
            pnRequestForm.Location = new Point(488, 195);
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            pnRequestForm.Visible = false;
        }

        private void btnCloseMail_Click(object sender, EventArgs e)
        {
            pnRequestForm.Visible = false;
        }

        private void btnProductType_Click(object sender, EventArgs e)
        {
            PanelRequestFormShow();
        }

        private void btnExtraPackaging_Click(object sender, EventArgs e)
        {
            PanelRequestFormShow();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form f = new Home_Trade();
            f.MdiParent = this.ParentForm;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }
    }
}
