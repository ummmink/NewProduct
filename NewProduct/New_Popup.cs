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
using System.IO;
using System.Drawing.Imaging;

using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;

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
            if (variablePublic.editPassing == false) // New Case
            {
                if (rdbNoSample.Checked == true)
                {
                    dtpSampleProductDate.CustomFormat = " ";
                    dtpSampleProductDate.Format = DateTimePickerFormat.Custom;
                }

                dtpOrderDate.Value = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy", UsaCulture), UsaCulture);

                #region Binding Product Type
                CommonDataSet dsProductType = commonBiz.npd_select_product_type();
                cmbProductType.DisplayMember = "TYPE_DESC_ENG";
                cmbProductType.ValueMember = "TYPE_ID";
                cmbProductType.DataSource = dsProductType.NPD_SELECT_PRODUCT_TYPE;
                cmbProductType.Text = "";
                #endregion

                #region Binding Channel
                CommonDataSet dsProductChannel = commonBiz.npd_select_product_sell_all_active(variablePublic.editPassing);
                cmbChannel.DisplayMember = "SELL_NAME";
                cmbChannel.ValueMember = "SELL_ID";
                cmbChannel.DataSource = dsProductChannel.NPD_SELECT_PRODUCT_SELL_ALL_ACTIVE;
                cmbChannel.Text = "";
                #endregion

                #region Binding Product Other 
                CommonDataSet dsProductOther = commonBiz.npd_select_product_other(variablePublic.editPassing);
                cmbOther.DisplayMember = "OTHER_NAME";
                cmbOther.ValueMember = "OTHER_ID";
                cmbOther.DataSource = dsProductOther.NPD_SELECT_PRODUCT_OTHER;
                cmbOther.Text = "";
                #endregion
            }
            else if (variablePublic.editPassing == true)// Edit Case
            {
                if (variablePublic.referenceNO != "")
                {
                    CommonDataSet ds = commonBiz.npd_select_all_product_temp_by_reference_no(variablePublic.referenceNO);
                    bindingEditProduct.DataSource = ds.NPD_SELECT_ALL_PRODUCT_TEMP_BY_REFERENCE_NO;

                    #region Binding Product Type
                    CommonDataSet dsProductType = commonBiz.npd_select_product_type();
                    cmbProductType.DisplayMember = "TYPE_DESC_ENG";
                    cmbProductType.ValueMember = "TYPE_ID";
                    cmbProductType.DataSource = dsProductType.NPD_SELECT_PRODUCT_TYPE;
                    //cmbProductType.Text = "";
                    #endregion

                    #region Binding Item NO2
                    CommonDataSet dsItemNO2 = commonBiz.npd_select_product_item_no2();
                    cmbProductItemNo.DisplayMember = "ITEM_NAME";
                    cmbProductItemNo.ValueMember = "ITEM_NO";
                    cmbProductItemNo.DataSource = dsItemNO2.NPD_SELECT_PRODUCT_ITEM_NO2;
                    #endregion

                    #region Binding Channel
                    CommonDataSet dsProductChannel = commonBiz.npd_select_product_sell_all_active(variablePublic.editPassing);
                    cmbChannel.DisplayMember = "SELL_NAME";
                    cmbChannel.ValueMember = "SELL_ID";
                    cmbChannel.DataSource = dsProductChannel.NPD_SELECT_PRODUCT_SELL_ALL_ACTIVE;
                    #endregion

                    #region Binding Product Other 
                    CommonDataSet dsProductOther = commonBiz.npd_select_product_other(variablePublic.editPassing);
                    cmbOther.DisplayMember = "OTHER_NAME";
                    cmbOther.ValueMember = "OTHER_ID";
                    cmbOther.DataSource = dsProductOther.NPD_SELECT_PRODUCT_OTHER;
                    #endregion

                    #region Binding Edit Product
                    #region Details
                    tbReferenceNo.DataBindings.Add("Text", bindingEditProduct, "REFERENCE_NO");
                    cmbProductType.DataBindings.Add("SelectedValue", bindingEditProduct, "TYPE_ID");
                    cmbProductItemNo.DataBindings.Add("SelectedValue", bindingEditProduct, "ITEM_NO");
                    tbProductNameTH.DataBindings.Add("Text", bindingEditProduct, "PRODUCT_NAME_TH");
                    tbProductNameEN.DataBindings.Add("Text", bindingEditProduct, "PRODUCT_NAME_ENG");
                    tbProductNameInvTH.DataBindings.Add("Text", bindingEditProduct, "PRODUCT_NAME_TH_Invoice");
                    tbProductNameInvEN.DataBindings.Add("Text", bindingEditProduct, "PRODUCT_NAME_ENG_Invoice");
                    tbCaseQty.Text = "1"; // ลัง เป็น 1 เสมอ
                    tbInnerQty.DataBindings.Add("Text", bindingEditProduct, "INNER_BOX");
                    tbPackQty.DataBindings.Add("Text", bindingEditProduct, "PACKING");
                    tbBottleQty.DataBindings.Add("Text", bindingEditProduct, "BOTTLE");
                    tbPriceRecommend.DataBindings.Add("Text", bindingEditProduct, "PRICE_RECOMMEND", true);
                    tbPriceRecommend.DataBindings[0].FormatString = "c";
                    tbPrice.DataBindings.Add("Text", bindingEditProduct, "PRICE_PER_CASE", true);
                    tbPrice.DataBindings[0].FormatString = "c";
                    tbDecoration1.DataBindings.Add("Text", bindingEditProduct, "DECORATION1");
                    tbDecoratedArea1.DataBindings.Add("Text", bindingEditProduct, "DECORATED_AREA1");
                    tbDecoration2.DataBindings.Add("Text", bindingEditProduct, "DECORATION2");
                    tbDecoratedArea2.DataBindings.Add("Text", bindingEditProduct, "DECORATED_AREA2");
                    tbDecoration3.DataBindings.Add("Text", bindingEditProduct, "DECORATION3");
                    tbDecoratedArea3.DataBindings.Add("Text", bindingEditProduct, "DECORATED_AREA3");
                    tbDecorationRemarkableOfBox.DataBindings.Add("Text", bindingEditProduct, "DECORATION_REMARKABLE_OF_BOX");
                    tbDecorationOtherDetails.DataBindings.Add("Text", bindingEditProduct, "DECORATION_OTHER_DETAILS");
                    pbImageOfProduct.DataBindings.Add("ImageLocation", bindingEditProduct, "IMAGE_PATH");
                    cmbChannel.DataBindings.Add("SelectedValue", bindingEditProduct, "SELL_ID");
                    cmbOther.DataBindings.Add("SelectedValue", bindingEditProduct, "OTHER_ID");
                    tbScheduleDateAndDetails.DataBindings.Add("Text", bindingEditProduct, "SCHEDULE");

                    if (ds.NPD_SELECT_ALL_PRODUCT_TEMP_BY_REFERENCE_NO[0].SAMPLE_FLAG.ToString().Trim() == "0") // ไม่ต้องการตัวอย่าง
                    {
                        rdbNoSample.Checked = true;
                        dtpSampleProductDate.CustomFormat = " ";
                        dtpSampleProductDate.Format = DateTimePickerFormat.Custom;
                    }
                    else //ต้องการตัวอย่าง
                    {
                        rdbNeedSample.Checked = true;
                        dtpSampleProductDate.Enabled = true;
                        tbQtySamplePiece.Enabled = true;
                        tbQtySampleCase.Enabled = true;
                        dtpSampleProductDate.DataBindings.Add("Value", bindingEditProduct, "SAMPLE_DATE");
                    }

                    tbQtySamplePiece.DataBindings.Add("Text", bindingEditProduct, "SAMPLE_QTY_BOTTLE", true);
                    tbQtySamplePiece.DataBindings[0].FormatString = "c0";
                    tbQtySampleCase.DataBindings.Add("Text", bindingEditProduct, "SAMPLE_QTY_BOX", true);
                    tbQtySampleCase.DataBindings[0].FormatString = "c0";
                    dtpOrderDate.DataBindings.Add("Value", bindingEditProduct, "SELL_DATE");
                    tbQtyOrderPiece.DataBindings.Add("Text", bindingEditProduct, "SELL_QTY_BOTTLE", true);
                    tbQtyOrderPiece.DataBindings[0].FormatString = "c0";
                    tbQtyOrderCase.DataBindings.Add("Text", bindingEditProduct, "SELL_QTY_BOX", true);
                    tbQtyOrderCase.DataBindings[0].FormatString = "c0";

                    if (ds.NPD_SELECT_ALL_PRODUCT_TEMP_BY_REFERENCE_NO[0].SHIPPING_TERMS_ID == 1) // ทั้งปี
                    {
                        rdbWholeYear.Checked = true;
                    }
                    else if (ds.NPD_SELECT_ALL_PRODUCT_TEMP_BY_REFERENCE_NO[0].SHIPPING_TERMS_ID == 2) // One Lot
                    {
                        rdbOneLot.Checked = true;
                    }
                    else if (ds.NPD_SELECT_ALL_PRODUCT_TEMP_BY_REFERENCE_NO[0].SHIPPING_TERMS_ID == 3) //Until Out of Stock
                    {
                        rdbOutOfStock.Checked = true;
                    }

                    tbRemark.DataBindings.Add("Text", bindingEditProduct, "REMARK");
                    #endregion

                    #region Short Name
                    tbShortName.DataBindings.Add("Text", bindingEditProduct, "SHORT_NAME");
                    #endregion

                    #region Barcode

                    #endregion

                    #region Dimension
                    CommonDataSet dsDimension = commonBiz.npd_select_all_product_dimension_temp_by_reference_no(variablePublic.referenceNO);
                    bindingDimension.DataSource = dsDimension.NPD_SELECT_ALL_PRODUCT_DIMENSION_TEMP_BY_REFERENCE_NO;

                    // ขนาดผลิตภัณฑ์ กล่องเดี่ยว
                    tbBottleWidth.DataBindings.Add("Text", bindingDimension, "BOTTLE_WIDTH", true);
                    tbBottleWidth.DataBindings[0].FormatString = "c";
                    tbBottleLength.DataBindings.Add("Text", bindingDimension, "BOTTLE_LENGTH", true);
                    tbBottleLength.DataBindings[0].FormatString = "c";
                    tbBottleHeight.DataBindings.Add("Text", bindingDimension, "BOTTLE_HEIGHT", true);
                    tbBottleHeight.DataBindings[0].FormatString = "c";
                    // ขนาดผลิตภัณฑ์ กล่องแพ็ค
                    tbPackWidth.DataBindings.Add("Text", bindingDimension, "PACK_WIDTH", true);
                    tbPackWidth.DataBindings[0].FormatString = "c";
                    tbPackLength.DataBindings.Add("Text", bindingDimension, "PACK_LENGTH", true);
                    tbPackLength.DataBindings[0].FormatString = "c";
                    tbPackHeight.DataBindings.Add("Text", bindingDimension, "PACK_HEIGHT", true);
                    tbPackHeight.DataBindings[0].FormatString = "c";
                    // ขนาดผลิตภัณฑ์ Inner Box/ลังย่อย
                    tbInnerWidth.DataBindings.Add("Text", bindingDimension, "INNER_WIDTH", true);
                    tbInnerWidth.DataBindings[0].FormatString = "c";
                    tbInnerLength.DataBindings.Add("Text", bindingDimension, "INNER_LENGTH", true);
                    tbInnerLength.DataBindings[0].FormatString = "c";
                    tbInnerHeight.DataBindings.Add("Text", bindingDimension, "INNER_HEIGHT", true);
                    tbInnerHeight.DataBindings[0].FormatString = "c";
                    // ขนาดผลิตภัณฑ์ ลังลูกฟูก
                    tbCaseWidth.DataBindings.Add("Text", bindingDimension, "CASE_WIDTH", true);
                    tbCaseWidth.DataBindings[0].FormatString = "c";
                    tbCaseLength.DataBindings.Add("Text", bindingDimension, "CASE_LENGTH", true);
                    tbCaseLength.DataBindings[0].FormatString = "c";
                    tbCaseHeight.DataBindings.Add("Text", bindingDimension, "CASE_HEIGHT", true);
                    tbCaseHeight.DataBindings[0].FormatString = "c";

                    // น้ำหนักผลิตภัณฑ์ กล่องเดี่ยว
                    tbBottleNetWeight.DataBindings.Add("Text", bindingDimension, "BOTTLE_NETWEIGHT", true);
                    tbBottleNetWeight.DataBindings[0].FormatString = "c";
                    tbBottleGrossWeight.DataBindings.Add("Text", bindingDimension, "BOTTLE_GROSSWEIGHT", true);
                    tbBottleGrossWeight.DataBindings[0].FormatString = "c";

                    // น้ำหนักผลิตภัณฑ์ กล่องแพ็ค
                    tbPackNetWeight.DataBindings.Add("Text", bindingDimension, "PACK_NETWEIGHT", true);
                    tbPackNetWeight.DataBindings[0].FormatString = "c";
                    tbPackGrossWeight.DataBindings.Add("Text", bindingDimension, "PACK_GROSSWEIGHT", true);
                    tbPackGrossWeight.DataBindings[0].FormatString = "c";

                    // น้ำหนักผลิตภัณฑ์ Inner Box/ลังย่อย
                    tbInnerNetWeight.DataBindings.Add("Text", bindingDimension, "INNER_NETWEIGHT", true);
                    tbInnerNetWeight.DataBindings[0].FormatString = "c";
                    tbInnerGrossWeight.DataBindings.Add("Text", bindingDimension, "INNER_GROSSWEIGHT", true);
                    tbInnerGrossWeight.DataBindings[0].FormatString = "c";

                    // น้ำหนักผลิตภัณฑ์ ลังลูกฟูก
                    tbCaseNetWeight.DataBindings.Add("Text", bindingDimension, "CASE_NETWEIGHT", true);
                    tbCaseNetWeight.DataBindings[0].FormatString = "c";
                    tbCaseGrossWeight.DataBindings.Add("Text", bindingDimension, "CASE_GROSSWEIGHT", true);
                    tbCaseGrossWeight.DataBindings[0].FormatString = "c";

                    tbShortNameFactory.DataBindings.Add("Text", bindingDimension, "SHORT_NAME_FACTORY");
                    tbPackaging.DataBindings.Add("Text", bindingDimension, "PACKAGING");
                    tbTechPrintCreatedDate.DataBindings.Add("Text", bindingDimension, "TECHPRINT_CREATE_DATE");
                    tbPrintArea.DataBindings.Add("Text", bindingDimension, "PRINT_AREA");
                    tbBarcodeArea.DataBindings.Add("Text", bindingDimension, "BARCODE_AREA");
                    tbArranging.DataBindings.Add("Text", bindingDimension, "ARRANGING");
                    tbArrangingPallet.DataBindings.Add("Text", bindingDimension, "ARRANGING_PALLET");
                    tbCapacity.DataBindings.Add("Text", bindingDimension, "CAPACITY");
                    tbPackProduction.DataBindings.Add("Text", bindingDimension, "PACK_PRODUCTION_BY");
                    tbInnerProduction.DataBindings.Add("Text", bindingDimension, "INNER_PRODUCTION_BY");
                    tbCaseProduction.DataBindings.Add("Text", bindingDimension, "CASE_PRODUCTION_BY");
                    tbOtherProduction.DataBindings.Add("Text", bindingDimension, "OTHER_PRODUCTION_BY");
                    tbOther.DataBindings.Add("Text", bindingDimension, "OTHER");
                    #endregion

                    #region Product ID

                    #endregion

                    #region Mat Code

                    #endregion
                    #endregion

                    #region Show Product Mix on Panel
                    pnDetailsProductMix.Visible = false;

                    pnDetailsSub1.Visible = true;
                    lbProductDetails.Text = "รายละเอียดผลิตภัณฑ์";

                    //tbPriceRecommend.Text = (variablePublic.productTotalCasePrice).ToString("#,##0.00");

                    ClearPanel();

                    PreviewProductHamper();
                    #endregion

                    // Trade // Promotion Support
                    if (variablePublic.user_group_id == "TDU" || variablePublic.user_group_id == "TDA" || variablePublic.user_group_id == "PSU" || variablePublic.user_group_id == "PSA")
                    {
                        // Details
                        btnDetails.Tag = "Blue";
                        ChangeColorByTag("Blue");

                        pnDetails.Tag = "PanelShow";
                        ChangeVisibleByTag("PanelShow");

                        // Short Name
                        DisableShortNamePage();

                        // Barcode 
                        DisableBarcodePage();

                        // Dimension
                        DisableDimensionPage();

                        // Product_ID
                        DisableProductIDPage();
                    }
                    else if (variablePublic.user_group_id == "SAU" || variablePublic.user_group_id == "SAA") // Sales
                    {
                        // Details
                        DisableDetailsPage();

                        // Short Name
                        btnShortName.Tag = "Blue";
                        ChangeColorByTag("Blue");

                        //Change panel visible is true when click
                        pnShortName.Tag = "PanelShow";
                        ChangeVisibleByTag("PanelShow");

                        // Barcode 
                        DisableBarcodePage();

                        // Dimension
                        DisableDimensionPage();

                        // Product_ID
                        DisableProductIDPage();
                    }
                    else if (variablePublic.user_group_id == "MKU" || variablePublic.user_group_id == "MKA") // Marketing
                    {
                        // Details
                        DisableDetailsPage();

                        // Short Name
                        DisableShortNamePage();

                        // Barcode 
                        btnBarcode.Tag = "Blue";
                        ChangeColorByTag("Blue");

                        pnBarcode.Tag = "PanelShow";
                        ChangeVisibleByTag("PanelShow");

                        // Dimension
                        DisableDimensionPage();

                        // Product_ID
                        DisableProductIDPage();
                    }
                    else if (variablePublic.user_group_id == "ACU" || variablePublic.user_group_id == "ACA") // Accounting
                    {
                        // Details
                        DisableDetailsPage();

                        // Short Name
                        DisableShortNamePage();

                        // Barcode
                        DisableBarcodePage();

                        // Dimension
                        DisableDimensionPage();

                        // Product_ID
                        btnProductID.Tag = "Blue";
                        ChangeColorByTag("Blue");

                        pnProductID.Tag = "PanelShow";
                        ChangeVisibleByTag("PanelShow");
                    }
                    else if (variablePublic.user_group_id == "PDU" || variablePublic.user_group_id == "PDA") // Production
                    {
                        // Details
                        DisableDetailsPage();

                        // Short Name
                        DisableShortNamePage();

                        // Barcode
                        DisableBarcodePage();

                        // Dimension
                        btnDimension.Tag = "Blue";
                        ChangeColorByTag("Blue");

                        pnDimention.Tag = "PanelShow";
                        ChangeVisibleByTag("PanelShow");

                        // Product_ID
                        DisableProductIDPage();
                    }
                }
                else
                {

                }
            }
        }

        private void DisableDetailsPage()
        {
            foreach (var c in pnDetailsSub1.Controls.OfType<Button>())
            {
                (c as Button).Enabled = false;
            }

            pbImageOfProduct.Enabled = false;

            foreach (var c in pnChannel.Controls.OfType<Button>())
            {
                (c as Button).Enabled = false;
            }

            btnApproved.Visible = false;
            btnReject.Visible = false;
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnClose.Visible = false;
            btnComment.Visible = true;
            btnComment.Location = new Point(1159, 552);
        }

        private void DisableProductIDPage()
        {
            foreach (var c in pnProductDetails.Controls.OfType<Button>())
            {
                (c as Button).Enabled = false;
            }

            foreach (var c in pnProductChannel.Controls.OfType<Button>())
            {
                (c as Button).Enabled = false;
            }

            foreach (var c in pnProductProductID.Controls.OfType<Button>())
            {
                (c as Button).Enabled = false;
            }

            pbCostStructure.Enabled = false;

            btnProductSave.Visible = false;
            btnProductClose.Visible = false;
            btnProductComment.Visible = true;
            btnProductComment.Location = new Point(1097, 294);
        }

        private void DisableDimensionPage()
        {
            btnDimensionSave.Visible = false;
            btnDimensionClose.Visible = false;
            btnDimensionComment.Visible = true;
            btnDimensionComment.Location = new Point(1036, 511);
        }

        private void DisableBarcodePage()
        {
            foreach (var c in pnDuplicateData.Controls.OfType<Button>())
            {
                (c as Button).Enabled = false;
            }

            foreach (var c in pnNewBarcode.Controls.OfType<Button>())
            {
                (c as Button).Enabled = false;
            }

            btnBarcodeSave.Visible = false;
            btnBarcodeClose.Visible = false;
            btnBarcodeComment.Visible = true;
            btnBarcodeComment.Location = new Point(1156, 487);
        }

        private void DisableShortNamePage()
        {
            btnShortNameSave.Visible = false;
            btnShortNameClose.Visible = false;
            btnShortNameComment.Visible = true;
            btnShortNameComment.Location = new Point(435, 87);
        }

        private void rdbNeedSample_Click(object sender, EventArgs e)
        {
            if (rdbNeedSample.Checked == true)
            {
                dtpSampleProductDate.Enabled = true;
                dtpSampleProductDate.Format = DateTimePickerFormat.Custom;
                dtpSampleProductDate.CustomFormat = "dd/MM/yyyy";
                dtpSampleProductDate.Value = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy", UsaCulture), UsaCulture);
                tbQtySamplePiece.Enabled = true;
                tbQtySampleCase.Enabled = true;
            }
            else
            {
                dtpSampleProductDate.Enabled = false;
                dtpSampleProductDate.CustomFormat = " ";
                dtpSampleProductDate.Format = DateTimePickerFormat.Custom;
                tbQtySamplePiece.Enabled = false;
                tbQtySampleCase.Enabled = false;
            }
        }

        private void rdbNoSample_Click(object sender, EventArgs e)
        {
            if (rdbNoSample.Checked == true)
            {
                dtpSampleProductDate.Enabled = false;
                dtpSampleProductDate.CustomFormat = " ";
                dtpSampleProductDate.Format = DateTimePickerFormat.Custom;
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
        }

        private void cmbProductItemNo_DropDown(object sender, EventArgs e)
        {
            #region Binding Item No
            CommonDataSet dsItemNO = commonBiz.npd_select_product_item_no_desc_item_name_code_by_type_id(variablePublic.type_id);
            cmbProductItemNo.DisplayMember = "ITEM_NAME";
            cmbProductItemNo.ValueMember = "ITEM_NO";
            cmbProductItemNo.DataSource = dsItemNO.NPD_SELECT_PRODUCT_ITEM_NO_DESC_ITEM_NAME_CODE_BY_TYPE_ID;
            #endregion
        }

        private void cmbProductType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            variablePublic.type_id = Int32.Parse(cmbProductType.SelectedValue.ToString());
            variablePublic.item_no = "";
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
            variablePublic.productPrefix = cmbProductItemNo.SelectedValue.ToString().Substring(cmbProductItemNo.SelectedValue.ToString().LastIndexOf(':') + 1, 3);
            variablePublic.item_no = cmbProductItemNo.SelectedValue.ToString().Substring(0, cmbProductItemNo.SelectedValue.ToString().IndexOf(':'));
            variablePublic.item_no2 = ConvertUtil.parseInt(cmbProductItemNo.SelectedValue.ToString().Substring(cmbProductItemNo.SelectedValue.ToString().LastIndexOf(' ') + 1));
            //MessageBox.Show("Prefix : " + variablePublic.productPrefix + ", Item_no : " + variablePublic.item_no + ", Item_no2 : " + variablePublic.item_no2);
        }

        private void cmbProductItemNo_Format(object sender, ListControlConvertEventArgs e)
        {
            //e.Value = e.Value.ToString().Substring(0, e.Value.ToString().Length - 4);
            //e.Value=e.Value.ToString().Substring(e.Value.ToString().LastIndexOf(':') + 1);
            //e.Value = e.Value.ToString().Substring(0, e.Value.ToString().IndexOf(':'));
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
                if (tbCaseQty.Text == "")
                {
                    MessageBox.Show("กรุณาใส่ขนาดบรรจุ/ลัง ให้ครบก่อน!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbCaseQty.Focus();
                }
                else
                {
                    if (tbInnerQty.Text == "")
                    {
                        MessageBox.Show("กรุณาใส่ขนาดบรรจุ/ลัง ให้ครบก่อน!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbInnerQty.Focus();
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
                            if (tbBottleQty.Text == "")
                            {
                                MessageBox.Show("กรุณาใส่ขนาดบรรจุ/ลัง ให้ครบก่อน!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                tbBottleQty.Focus();
                            }
                            else
                            {
                                pnDetailsSub1.Visible = false;

                                pnDetailsProductMix.Visible = true;
                                lbProductDetails.Text = "รายละเอียดสินค้าประกอบ";
                            }
                        }
                    }
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
                variablePublic.productMainPrice = float.Parse(tbSumPrice.Text);

                //จำนวนสินค้าปกติ
                tbSumQty.Text = fSumQty.ToString();
                variablePublic.productMainQty = Int32.Parse(tbSumQty.Text);

                //จำนวนสินค้ารวม
                tbSumQtyTotal.Text = (ConvertUtil.parseInt(tbSumQty.Text) + ConvertUtil.parseInt(tbSumQtyFree.Text)).ToString();
                variablePublic.productTotalQty = Int32.Parse(tbSumQtyTotal.Text);

                //ราคาแนะนำ/แพ็ค
                tbSumPriceTotal.Text = tbSumPrice.Text;
                variablePublic.productTotalPackPrice = float.Parse(tbSumPriceTotal.Text);

                //ราคาแนะนำ/ลัง
                tbSumPriceCaseTotal.Text = (float.Parse(tbSumPrice.Text) * variablePublic.productPackQty).ToString("#,##0.00");
                variablePublic.productTotalCasePrice = float.Parse(tbSumPriceCaseTotal.Text);
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
                variablePublic.productFreePrice = float.Parse(tbSumPriceFree.Text);

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
            if (Int32.Parse(tbSumQtyTotal.Text) == variablePublic.productBottleQty)
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
            else if (Int32.Parse(tbSumQtyTotal.Text) < variablePublic.productBottleQty)
            {
                DialogResult dialogResult = MessageBox.Show("จำนวนขวดของสินค้าน้อยกว่าที่ระบุ!" + Environment.NewLine +
                    "คุณต้องการเปลี่ยนจำนวนตามที่เพิ่มในรายละเอียด?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    pnDetailsProductMix.Visible = false;

                    pnDetailsSub1.Visible = true;
                    lbProductDetails.Text = "รายละเอียดผลิตภัณฑ์";

                    tbPriceRecommend.Text = (variablePublic.productTotalCasePrice).ToString("#,##0.00");

                    ClearPanel();

                    SaveProductHamper();

                    PreviewProductHamper();

                    tbBottleQty.Text = tbSumQtyTotal.Text;
                    variablePublic.productBottleQty = Int32.Parse(tbBottleQty.Text);

                    tbPrice.Focus();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }

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
            DialogResult dialogResult = MessageBox.Show("คุณต้องการจะบันทึกข้อมูล?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                #region Upload Image               
                try
                {
                    using (var bitmap = new Bitmap(pbImageOfProduct.Width, pbImageOfProduct.Height))
                    {
                        //string sPath = @"E:\My Work\Programming\progress\NPD\NewProductSystem\NPD_Images";
                        pbImageOfProduct.DrawToBitmap(bitmap, pbImageOfProduct.ClientRectangle);
                        ImageFormat imageFormat = null;

                        var extension = Path.GetExtension(variablePublic.imagePath);
                        variablePublic.imagePath = variablePublic.saveImagePath + "\\" + tbReferenceNo.Text + extension;
                        switch (extension)
                        {
                            case ".bmp":
                                imageFormat = ImageFormat.Bmp;
                                break;
                            case ".png":
                                imageFormat = ImageFormat.Png;
                                break;
                            case ".jpeg":
                            case ".jpg":
                                imageFormat = ImageFormat.Jpeg;
                                break;
                            case ".gif":
                                imageFormat = ImageFormat.Gif;
                                break;
                            default:
                                throw new NotSupportedException("File extension is not supported");
                        }

                        bitmap.Save(variablePublic.imagePath, imageFormat);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                #endregion

                //#region Create PDF
                //Document document = new Document();
                //PdfWriter.GetInstance(document, new FileStream("E:/a.pdf", FileMode.Create));
                //document.Open();
                //Paragraph p = new Paragraph("Test");
                //document.Add(p);
                //document.Close();
                //#endregion

                #region Send Mail
                try
                {
                    //Create the msg object to be sent
                    MailMessage msg = new MailMessage();
                    //Add your email address to the recipients             
                    msg.To.Add("n.sarawana@gmail.com");
                    //Configure the address we are sending the mail from **- NOT SURE IF I NEED THIS OR NOT?**
                    MailAddress address = new MailAddress("noreply.scotch@gmail.com");
                    msg.From = address;
                    //Append their name in the beginning of the subject
                    msg.Subject = "NPD : Details of Reference No. " + tbReferenceNo.Text + " >> Waiting for approval!!";
                    msg.Body = "Reference No : " + tbReferenceNo.Text;

                    //Configure an SmtpClient to send the mail.
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true; //only enable this if your provider requires it
                                             //Setup credentials to login to our sender email address ("UserName", "Password")
                    NetworkCredential credentials = new NetworkCredential("noreply.scotch@gmail.com", "masterkey@noreply");

                    client.Credentials = credentials;

                    //Send the msg
                    client.Send(msg);

                    //Display some feedback to the user to let them know it was sent
                    MessageBox.Show("ส่ง Mail สำเร็จแล้ว", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    //If the message failed at some point, let the user know
                    MessageBox.Show("E-mail หรือ Password ไม่ถูกต้อง!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                #endregion

                // Status = 2 บันทึก : เพิ่มข้อมูลใหม่ รออนุมัติ : ขั้นตอน Details
                bool wantSample;

                if (rdbNeedSample.Checked == true)
                {
                    wantSample = true;
                }
                else
                {
                    wantSample = false;
                }

                CommonDataSet dsInsertMainProduct = commonBiz.npd_insert_product_temp(tbReferenceNo.Text, "12345678XXXX", ""
                , variablePublic.item_no, variablePublic.type_id, tbProductNameTH.Text, "", tbProductNameEN.Text
                , variablePublic.productPackQty, variablePublic.productBottleQty, 45, dtpOrderDate.Value
                , variablePublic.productInnerBoxQty, variablePublic.productFreeQty, "Mink", (variablePublic.item_no2).ToString()
                , tbProductNameInvEN.Text, tbProductNameInvTH.Text, tbDecoratedArea1.Text, tbDecoratedArea2.Text
                , tbDecoratedArea3.Text, tbDecorationOtherDetails.Text, tbDecorationRemarkableOfBox.Text, tbDecoration1.Text
                , tbDecoration2.Text, tbDecoration3.Text, variablePublic.imagePath, variablePublic.product_other_id
                , ConvertUtil.parseFloat(tbPrice.Text), variablePublic.productTotalCasePrice, variablePublic.productPrefix
                , dtpSampleProductDate.Value, ConvertUtil.parseInt(tbQtySamplePiece.Text)
                , ConvertUtil.parseInt(tbQtySampleCase.Text), tbScheduleDateAndDetails.Text, variablePublic.sell_id
                , ConvertUtil.parseInt(tbQtyOrderPiece.Text), ConvertUtil.parseInt(tbQtyOrderCase.Text), tbRemark.Text
                , rdbWholeYear.Checked == true ? 1 : rdbOneLot.Checked == true ? 2 : 3 
                , wantSample);

                MessageBox.Show("บันทึกสำเร็จ!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                lineNotify("มีการเพิ่ม NPD ใหม่" + Environment.NewLine + "Reference No : " + tbReferenceNo.Text);

                Form f = new Home_Trade();
                f.MdiParent = this.ParentForm;
                f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
                f.Dock = DockStyle.Fill; //set form's dock property to fill
                f.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void btnAddChennel_Click(object sender, EventArgs e)
        {
            txtRequestSubject.Text = "ช่องทางจัดจำหน่าย";
            PanelRequestFormShow();
        }

        private void cmbProductType_SelectedValueChanged(object sender, EventArgs e)
        {

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
                variablePublic.imagePath = open.FileName;
                //MessageBox.Show(variablePublic.imagePath);
            }
        }

        private void btnProductGroup_Click(object sender, EventArgs e)
        {
            txtRequestSubject.Text = "กลุ่มผลิตภัณฑ์";
            PanelRequestFormShow();
        }

        private void PanelRequestFormShow()
        {
            pnRequestForm.Visible = true;
            pnRequestForm.Location = new Point(488, 195);
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                //Create the msg object to be sent
                MailMessage msg = new MailMessage();
                //Add your email address to the recipients             
                msg.To.Add(cmbRequestRecipients.Text);
                //Configure the address we are sending the mail from **- NOT SURE IF I NEED THIS OR NOT?**
                MailAddress address = new MailAddress(txtRequestSender.Text);
                msg.From = address;
                //Append their name in the beginning of the subject
                //msg.Subject = txtName.Text + " :  " + ddlSubject.Text;
                //msg.Body = txtMessage.Text;
                msg.Subject = "NPD : " + txtRequestSubject.Text;
                msg.Body = txtRequestDescription.Text;


                //Configure an SmtpClient to send the mail.
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true; //only enable this if your provider requires it
                                         //Setup credentials to login to our sender email address ("UserName", "Password")
                NetworkCredential credentials = new NetworkCredential(txtRequestSender.Text, txtRequestPassword.Text);

                client.Credentials = credentials;

                //Send the msg
                client.Send(msg);

                //Display some feedback to the user to let them know it was sent
                MessageBox.Show("ส่ง Mail สำเร็จแล้ว", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearAllRequestTextbox();
                pnRequestForm.Visible = false;
            }
            catch
            {
                //If the message failed at some point, let the user know
                MessageBox.Show("E-mail หรือ Password ไม่ถูกต้อง!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearAllRequestTextbox()
        {
            txtRequestDescription.Text = "";
            txtRequestSender.Text = "";
            txtRequestPassword.Text = "";
        }

        private void btnCloseMail_Click(object sender, EventArgs e)
        {
            pnRequestForm.Visible = false;
        }

        private void btnProductType_Click(object sender, EventArgs e)
        {
            txtRequestSubject.Text = "ประเภทผลิตภัณฑ์";
            PanelRequestFormShow();
        }

        private void btnExtraPackaging_Click(object sender, EventArgs e)
        {
            txtRequestSubject.Text = "ส่วนเพิ่มเติมบรรจุภัณฑ์";
            PanelRequestFormShow();
        }

        private void tbPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbDecoration1.Focus();
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            txtRejectSubject.Text = "Disapproved/Reference No : " + tbReferenceNo.Text;
            PanelRejectFormShow();
        }

        private void PanelRejectFormShow()
        {
            pnRejectForm.Visible = true;
            pnRejectForm.Location = new Point(488, 195);
        }

        private void btnRejectCloseMail_Click(object sender, EventArgs e)
        {
            pnRejectForm.Visible = false;
        }

        private void btnRejectSendMail_Click(object sender, EventArgs e)
        {
            #region Update Temp Status
            int iUpdate = 0;
            // Status = 1 ไม่อนุมัติ : มีร้องขอให้แก้ไขข้อมูล : ขั้นตอน Details
            iUpdate = commonBiz.npd_update_temp_status_product_temp(tbReferenceNo.Text, 1);
            #endregion

            if (iUpdate != 0)
            {
                try
                {
                    //Create the msg object to be sent
                    MailMessage msg = new MailMessage();
                    //Add your email address to the recipients             
                    msg.To.Add(cmbRejectRecipients.Text);
                    //Configure the address we are sending the mail from **- NOT SURE IF I NEED THIS OR NOT?**
                    MailAddress address = new MailAddress(txtRejectSender.Text);
                    msg.From = address;
                    //Append their name in the beginning of the subject
                    //msg.Subject = txtName.Text + " :  " + ddlSubject.Text;
                    //msg.Body = txtMessage.Text;
                    msg.Subject = "NPD : " + txtRejectSubject.Text;
                    msg.Body = txtRejectDescription.Text;


                    //Configure an SmtpClient to send the mail.
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true; //only enable this if your provider requires it
                                             //Setup credentials to login to our sender email address ("UserName", "Password")
                    NetworkCredential credentials = new NetworkCredential(txtRejectSender.Text, txtRejectPassword.Text);

                    client.Credentials = credentials;

                    //Send the msg
                    client.Send(msg);

                    //Display some feedback to the user to let them know it was sent
                    MessageBox.Show("ส่ง Mail สำเร็จแล้ว", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearAllRejectTextbox();
                    pnRejectForm.Visible = false;
                }
                catch
                {
                    //If the message failed at some point, let the user know
                    MessageBox.Show("E-mail หรือ Password ไม่ถูกต้อง!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ClearAllRejectTextbox()
        {
            txtRejectDescription.Text = "";
            txtRejectSender.Text = "";
            txtRejectPassword.Text = "";
        }

        private void tbQtySamplePiece_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbQtySampleCase.Focus();
            }
        }

        private void tbQtySamplePiece_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void tbQtySampleCase_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void tbQtyOrderPiece_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void tbQtyOrderCase_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void btnApproved_Click(object sender, EventArgs e)
        {
            #region Update Temp Status
            int iUpdate = 0;
            // Status = 3 อนุมัติ : Details อนุมัติแล้ว รอเพิ่มชื่อย่อ : ขั้นตอน Short Name
            iUpdate = commonBiz.npd_update_temp_status_product_temp(tbReferenceNo.Text, 3);
            #endregion

            if (iUpdate != 0)
            {
                try
                {
                    //Create the msg object to be sent
                    MailMessage msg = new MailMessage();
                    //Add your email address to the recipients             
                    msg.To.Add("sarawana.n@scotch.co.th");
                    //Configure the address we are sending the mail from **- NOT SURE IF I NEED THIS OR NOT?**
                    MailAddress address = new MailAddress("npd.scotch@gmail.com");
                    msg.From = address;
                    //Append their name in the beginning of the subject
                    msg.Subject = "NPD : Approved";
                    msg.Body = "Reference No : " + tbReferenceNo.Text;


                    //Configure an SmtpClient to send the mail.
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true; //only enable this if your provider requires it
                                             //Setup credentials to login to our sender email address ("UserName", "Password")
                    NetworkCredential credentials = new NetworkCredential("npd.scotch@gmail.com", "masterkey@npd");

                    client.Credentials = credentials;

                    //Send the msg
                    client.Send(msg);

                    //Display some feedback to the user to let them know it was sent
                    MessageBox.Show("ส่ง Mail สำเร็จแล้ว", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    //If the message failed at some point, let the user know
                    MessageBox.Show("E-mail หรือ Password ไม่ถูกต้อง!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void PanelCancelFormShow()
        {
            pnCancelForm.Visible = true;
            pnCancelForm.Location = new Point(488, 195);
        }

        private void btnCancelCloseMail_Click(object sender, EventArgs e)
        {
            pnCancelForm.Visible = false;
        }

        private void btnCancelSendMail_Click(object sender, EventArgs e)
        {
            #region Update Temp Status
            int iUpdate = 0;
            // Status = 0 ยกเลิก : ยกเลิก : ขั้นตอน Details
            iUpdate = commonBiz.npd_update_temp_status_product_temp(tbReferenceNo.Text, 0);
            #endregion

            if (iUpdate != 0)
            {
                try
                {
                    //Create the msg object to be sent
                    MailMessage msg = new MailMessage();
                    //Add your email address to the recipients             
                    msg.To.Add(cmbCancelRecipients.Text);
                    //Configure the address we are sending the mail from **- NOT SURE IF I NEED THIS OR NOT?**
                    MailAddress address = new MailAddress(txtCancelSender.Text);
                    msg.From = address;
                    //Append their name in the beginning of the subject
                    //msg.Subject = txtName.Text + " :  " + ddlSubject.Text;
                    //msg.Body = txtMessage.Text;
                    msg.Subject = "NPD : " + txtCancelSubject.Text;
                    msg.Body = txtCancelDescription.Text;


                    //Configure an SmtpClient to send the mail.
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true; //only enable this if your provider requires it
                                             //Setup credentials to login to our sender email address ("UserName", "Password")
                    NetworkCredential credentials = new NetworkCredential(txtCancelSender.Text, txtCancelPassword.Text);

                    client.Credentials = credentials;

                    //Send the msg
                    client.Send(msg);

                    //Display some feedback to the user to let them know it was sent
                    MessageBox.Show("ส่ง Mail สำเร็จแล้ว", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearAllCancelTextbox();
                    pnCancelForm.Visible = false;
                }
                catch
                {
                    //If the message failed at some point, let the user know
                    MessageBox.Show("E-mail หรือ Password ไม่ถูกต้อง!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ClearAllCancelTextbox()
        {
            txtCancelDescription.Text = "";
            txtCancelSender.Text = "";
            txtCancelPassword.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Form f = new Home_Trade();
            f.MdiParent = this.ParentForm;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCancelSubject.Text = "Discard/Reference No : " + tbReferenceNo.Text;
            PanelCancelFormShow();
        }

        private void cmbChannel_DropDown(object sender, EventArgs e)
        {
            //#region Binding Channel
            //CommonDataSet dsProductChannel = commonBiz.npd_select_product_sell_all_active(false);
            //cmbChannel.DisplayMember = "SELL_NAME";
            //cmbChannel.ValueMember = "SELL_ID";
            //cmbChannel.DataSource = dsProductChannel.NPD_SELECT_PRODUCT_SELL_ALL_ACTIVE;
            //cmbChannel.Text = "";
            //#endregion
        }

        private void btnShortNameSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการจะบันทึกข้อมูล? ",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                #region Update Short Name
                int iUpdate = 0;
                iUpdate = commonBiz.npd_update_short_name_in_product_temp(tbReferenceNo.Text, tbShortName.Text);
                #endregion

                if (iUpdate != 0)
                {
                    try
                    {
                        //Create the msg object to be sent
                        MailMessage msg = new MailMessage();
                        //Add your email address to the recipients             
                        msg.To.Add("n.sarawana@gmail.com");
                        //Configure the address we are sending the mail from **- NOT SURE IF I NEED THIS OR NOT?**
                        MailAddress address = new MailAddress("noreply.scotch@gmail.com");
                        msg.From = address;
                        //Append their name in the beginning of the subject
                        msg.Subject = "NPD : Short Name of Reference No. " + tbReferenceNo.Text + " : Successfully updated >> Waiting for Barcode!!";
                        msg.Body = "Reference No : " + tbReferenceNo.Text;


                        //Configure an SmtpClient to send the mail.
                        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                        client.EnableSsl = true; //only enable this if your provider requires it
                                                 //Setup credentials to login to our sender email address ("UserName", "Password")
                        NetworkCredential credentials = new NetworkCredential("noreply.scotch@gmail.com", "masterkey@noreply");

                        client.Credentials = credentials;

                        //Send the msg
                        client.Send(msg);

                        //Display some feedback to the user to let them know it was sent
                        MessageBox.Show("ส่ง Mail สำเร็จแล้ว", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        //If the message failed at some point, let the user know
                        MessageBox.Show("E-mail หรือ Password ไม่ถูกต้อง!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                MessageBox.Show("บันทึกสำเร็จ!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                lineNotify("มีการเพิ่ม Short Name" + Environment.NewLine + "Reference No : " + tbReferenceNo.Text);

                Form f = new Home_Trade();
                f.MdiParent = this.ParentForm;
                f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
                f.Dock = DockStyle.Fill; //set form's dock property to fill
                f.Show();
            }            
        }

        private void btnShortNameClose_Click(object sender, EventArgs e)
        {
            Form f = new Home_Trade();
            f.MdiParent = this.ParentForm;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnMatCodeDKClose_Click(object sender, EventArgs e)
        {
            Form f = new Home_Trade();
            f.MdiParent = this.ParentForm;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnMatCodeDKSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการจะบันทึกข้อมูล? ",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                #region Send Mail
                try
                {
                    //Create the msg object to be sent
                    MailMessage msg = new MailMessage();
                    //Add your email address to the recipients             
                    msg.To.Add("sarawana.n@scotch.co.th");
                    //Configure the address we are sending the mail from **- NOT SURE IF I NEED THIS OR NOT?**
                    MailAddress address = new MailAddress("npd.scotch@gmail.com");
                    msg.From = address;
                    //Append their name in the beginning of the subject
                    msg.Subject = "NPD --> Mat Code DK : Successfully updated";
                    msg.Body = "Reference No : " + tbReferenceNo.Text;


                    //Configure an SmtpClient to send the mail.
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true; //only enable this if your provider requires it
                                             //Setup credentials to login to our sender email address ("UserName", "Password")
                    NetworkCredential credentials = new NetworkCredential("npd.scotch@gmail.com", "masterkey@npd");

                    client.Credentials = credentials;

                    //Send the msg
                    client.Send(msg);

                    //Display some feedback to the user to let them know it was sent
                    MessageBox.Show("ส่ง Mail สำเร็จแล้ว", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    //If the message failed at some point, let the user know
                    MessageBox.Show("E-mail หรือ Password ไม่ถูกต้อง!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                #endregion

                CommonDataSet dsInsertDKMatCode = commonBiz.npd_insert_dk_product_map_temp(tbReferenceNo.Text, tbMatCode.Text, tbProductID.Text);

                MessageBox.Show("บันทึกสำเร็จ!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                lineNotify("มีการเพิ่ม Mat Code DK" + Environment.NewLine + "Reference No : " + tbReferenceNo.Text);

                Form f = new Home_Trade();
                f.MdiParent = this.ParentForm;
                f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
                f.Dock = DockStyle.Fill; //set form's dock property to fill
                f.Show();
            }
        }

        private void textBox60_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDimensionSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการจะบันทึกข้อมูล? ",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                #region Send Mail
                try
                {
                    //Create the msg object to be sent
                    MailMessage msg = new MailMessage();
                    //Add your email address to the recipients             
                    msg.To.Add("n.sarawana@gmail.com");
                    //Configure the address we are sending the mail from **- NOT SURE IF I NEED THIS OR NOT?**
                    MailAddress address = new MailAddress("noreply.scotch@gmail.com");
                    msg.From = address;
                    //Append their name in the beginning of the subject
                    msg.Subject = "NPD : Dimension of Reference No. " + tbReferenceNo.Text + " : Successfully updated >> Waiting for Product ID!!";
                    msg.Body = "Reference No : " + tbReferenceNo.Text;


                    //Configure an SmtpClient to send the mail.
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true; //only enable this if your provider requires it
                                             //Setup credentials to login to our sender email address ("UserName", "Password")
                    NetworkCredential credentials = new NetworkCredential("noreply.scotch@gmail.com", "masterkey@noreply");

                    client.Credentials = credentials;

                    //Send the msg
                    client.Send(msg);

                    //Display some feedback to the user to let them know it was sent
                    MessageBox.Show("ส่ง Mail สำเร็จแล้ว", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    //If the message failed at some point, let the user know
                    MessageBox.Show("E-mail หรือ Password ไม่ถูกต้อง!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                #endregion

                CommonDataSet dsInsertDimension = commonBiz.npd_insert_product_dimension_temp(tbReferenceNo.Text, "12345678XXXX", decimal.Parse(tbBottleWidth.Text), decimal.Parse(tbBottleLength.Text),
                    decimal.Parse(tbBottleHeight.Text), decimal.Parse(tbPackWidth.Text), decimal.Parse(tbPackLength.Text), decimal.Parse(tbPackHeight.Text), decimal.Parse(tbInnerWidth.Text),
                    decimal.Parse(tbInnerLength.Text), decimal.Parse(tbInnerHeight.Text), decimal.Parse(tbCaseWidth.Text), decimal.Parse(tbCaseLength.Text), decimal.Parse(tbCaseHeight.Text),
                    decimal.Parse(tbBottleNetWeight.Text), decimal.Parse(tbBottleGrossWeight.Text), decimal.Parse(tbPackNetWeight.Text), decimal.Parse(tbPackGrossWeight.Text),
                    decimal.Parse(tbInnerNetWeight.Text), decimal.Parse(tbInnerGrossWeight.Text), decimal.Parse(tbCaseNetWeight.Text), decimal.Parse(tbCaseGrossWeight.Text),
                    tbShortNameFactory.Text, tbPackaging.Text, tbTechPrintCreatedDate.Text, tbPrintArea.Text, tbBarcodeArea.Text,
                    tbArranging.Text, tbArrangingPallet.Text, tbCapacity.Text, tbPackProduction.Text, tbInnerProduction.Text, tbCaseProduction.Text, tbOtherProduction.Text, tbOther.Text);

                MessageBox.Show("บันทึกสำเร็จ!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                lineNotify("มีการเพิ่ม Dimension" + Environment.NewLine + "Reference No : " + tbReferenceNo.Text);

                Form f = new Home_Trade();
                f.MdiParent = this.ParentForm;
                f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
                f.Dock = DockStyle.Fill; //set form's dock property to fill
                f.Show();
            }
        }

        private void btnDimension_Click(object sender, EventArgs e)
        {
            //Change button color when click
            btnDimension.Tag = "Blue";
            ChangeColorByTag("Blue");

            //Change panel visible is true when click
            pnDimention.Tag = "PanelShow";
            ChangeVisibleByTag("PanelShow");
        }

        private void btnComment_Click(object sender, EventArgs e)
        {

        }

        private void cmbOther_DropDown(object sender, EventArgs e)
        {
            //#region Binding Product Other 
            //CommonDataSet dsProductOther = commonBiz.npd_select_product_other(false);
            //cmbOther.DisplayMember = "OTHER_NAME";
            //cmbOther.ValueMember = "OTHER_ID";
            //cmbOther.DataSource = dsProductOther.NPD_SELECT_PRODUCT_OTHER;
            ////cmbOther.Text = "";
            //#endregion
        }

        private void tbBottleWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbBottleLength.Focus();
            }
        }

        private void tbBottleWidth_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbBottleLength_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbBottleHeight.Focus();
            }
        }

        private void tbBottleLength_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbBottleHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbPackWidth.Focus();
            }
        }

        private void tbBottleHeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbPackWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbPackLength.Focus();
            }
        }

        private void tbPackWidth_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbPackLength_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbPackLength_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbPackHeight.Focus();
            }
        }

        private void tbPackHeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbPackHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbInnerWidth.Focus();
            }
        }

        private void tbInnerWidth_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbInnerWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbInnerLength.Focus();
            }
        }

        private void tbInnerLength_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbInnerHeight.Focus();
            }
        }

        private void tbInnerLength_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbInnerHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbCaseWidth.Focus();
            }
        }

        private void tbInnerHeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbCaseWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbCaseLength.Focus();
            }
        }

        private void tbCaseWidth_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbCaseLength_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbCaseHeight.Focus();
            }
        }

        private void tbCaseLength_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbCaseHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbBottleNetWeight.Focus();
            }
        }

        private void tbCaseHeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbBottleNetWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbBottleGrossWeight.Focus();
            }
        }

        private void tbBottleNetWeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbBottleGrossWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbPackNetWeight.Focus();
            }
        }

        private void tbBottleGrossWeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbPackNetWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbPackGrossWeight.Focus();
            }
        }

        private void tbPackNetWeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbPackGrossWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbInnerNetWeight.Focus();
            }
        }

        private void tbPackGrossWeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbInnerNetWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbInnerGrossWeight.Focus();
            }
        }

        private void tbInnerNetWeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbInnerGrossWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbCaseNetWeight.Focus();
            }
        }

        private void tbInnerGrossWeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbCaseNetWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbCaseGrossWeight.Focus();
            }
        }

        private void tbCaseNetWeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbCaseGrossWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                tbShortNameFactory.Focus();
            }
        }

        private void tbCaseGrossWeight_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void btnBarcodeBoxCheck_Click(object sender, EventArgs e)
        {
            CommonDataSet dsBar = commonBiz.npd_select_all_barcode_by_barcode(txtNewBarcodeBox.Text, "ลัง");

            if (dsBar.NPD_SELECT_ALL_BARCODE_BY_BARCODE.Rows.Count > 0)
            {
                txtNewBarcodeBox.BackColor = Color.FromArgb(255, 128, 128);

                txtDupBarcodeBox.BackColor = Color.FromArgb(255, 128, 128);
                txtDupBarcodeBox.Text = "มีข้อมูลซ้ำ";
            }
            else
            {
                txtNewBarcodeBox.BackColor = Color.FromArgb(192, 255, 192);

                txtDupBarcodeBox.BackColor = Color.FromArgb(192, 255, 192);
                txtDupBarcodeBox.Text = "ไม่มีข้อมูลซ้ำ";
            }
        }

        private void btnBarcodeInnerBoxCheck_Click(object sender, EventArgs e)
        {
            CommonDataSet dsBar = commonBiz.npd_select_all_barcode_by_barcode(txtNewBarcodeInnerBox.Text, "ลังย่อย");

            if (dsBar.NPD_SELECT_ALL_BARCODE_BY_BARCODE.Rows.Count > 0)
            {
                txtNewBarcodeInnerBox.BackColor = Color.FromArgb(255, 128, 128);

                txtDupBarcodeInnerBox.BackColor = Color.FromArgb(255, 128, 128);
                txtDupBarcodeInnerBox.Text = "มีข้อมูลซ้ำ";
            }
            else
            {
                txtNewBarcodeInnerBox.BackColor = Color.FromArgb(192, 255, 192);

                txtDupBarcodeInnerBox.BackColor = Color.FromArgb(192, 255, 192);
                txtDupBarcodeInnerBox.Text = "ไม่มีข้อมูลซ้ำ";
            }
        }

        private void lineNotify(string msg)
        {
            string token = "pBdAZm9ZyK6dJU8SYKeeEWM3uAjceuN2SO9tzueZsaK";
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://notify-api.line.me/api/notify");
                var postData = string.Format("message={0}", msg);
                var data = Encoding.UTF8.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.Headers.Add("Authorization", "Bearer " + token);

                using (var stream = request.GetRequestStream()) stream.Write(data, 0, data.Length);
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
