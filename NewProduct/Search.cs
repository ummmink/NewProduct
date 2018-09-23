using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class Search : Form
    {
        CommonBiz commonBiz = new CommonBiz();

        int y = 10;

        public Search()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            cbSelectTableNPD.SelectedIndex = 0;
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

        private void txtSearchBox_Enter(object sender, EventArgs e)
        {
                              
        }

        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearchBox.Text != "")
                {
                    if (cbSelectTableNPD.SelectedIndex == 0) // In progress
                    {
                        //Change Item Header 
                        lbItemHeader1.Text = "Reference No.";
                        lbItemHeader2.Text = "Short Name";
                        lbItemHeader3.Text = "Product Name TH";

                        HeaderItemsVisible();

                        ClearPanel();

                        if (lbItem.Text == "เลขที่อ้างอิง")
                        {
                            CommonDataSet dsSearch = commonBiz.npd_select_product_temp_by_reference_no(txtSearchBox.Text);
                            //MessageBox.Show(dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[0].REFERENCE_NO.ToString());

                            for (int i = 0; i < dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO.Count; i++)
                            {
                                //Label Reference_No
                                Label dtReferenceNo = new Label();
                                string headerReferenceNo = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].REFERENCE_NO.ToString();
                                dtReferenceNo.Text = headerReferenceNo;
                                dtReferenceNo.Location = new System.Drawing.Point(38, y);
                                dtReferenceNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtReferenceNo.Size = new System.Drawing.Size(126, 16);
                                dtReferenceNo.AutoSize = false;
                                dtReferenceNo.ForeColor = Color.White;
                                dtReferenceNo.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtReferenceNo);

                                //Label Short Name
                                Label dtShortName = new Label();
                                string headerShortName = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].SHORT_NAME.ToString();
                                dtShortName.Text = headerShortName;
                                dtShortName.Location = new System.Drawing.Point(179, y);
                                dtShortName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtShortName.Size = new System.Drawing.Size(126, 16);
                                dtShortName.AutoSize = false;
                                dtShortName.ForeColor = Color.White;
                                dtShortName.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtShortName);

                                //Label Product_Name_TH
                                Label dtProductName = new Label();
                                string headerProductName = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].PRODUCT_NAME_TH.ToString();
                                dtProductName.Text = headerProductName;
                                dtProductName.Location = new System.Drawing.Point(322, y);
                                dtProductName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductName.Size = new System.Drawing.Size(395, 16);
                                dtProductName.AutoSize = false;
                                dtProductName.ForeColor = Color.White;
                                dtProductName.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductName);

                                //Button View
                                Button dtbtnView = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].REFERENCE_NO.ToString();
                                ToolTip tip = new ToolTip();
                                tip.SetToolTip(dtbtnView, "View Data");
                                dtbtnView.Text = "";
                                dtbtnView.Location = new System.Drawing.Point(725, y - 9);
                                dtbtnView.Size = new System.Drawing.Size(39, 35);
                                dtbtnView.FlatStyle = FlatStyle.Flat;
                                dtbtnView.BackColor = Color.Black;
                                dtbtnView.Cursor = Cursors.Hand;
                                dtbtnView.FlatAppearance.BorderColor = Color.Black;
                                dtbtnView.FlatAppearance.BorderSize = 1;
                                dtbtnView.FlatAppearance.MouseDownBackColor = Color.Black;
                                dtbtnView.FlatAppearance.MouseOverBackColor = Color.Black;
                                dtbtnView.Image = new Bitmap(NewProduct.Properties.Resources.post_it);
                                dtbtnView.ImageAlign = ContentAlignment.MiddleCenter;
                                dtbtnView.Click += new EventHandler(dtbtnView_Click);
                                pnSearchResult.Controls.Add(dtbtnView);

                                //Button Edit
                                Button dtbtnEdit = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].REFERENCE_NO.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnEdit, "Edit Data");
                                dtbtnEdit.Text = "";
                                dtbtnEdit.Location = new System.Drawing.Point(775, y - 9);
                                dtbtnEdit.Size = new System.Drawing.Size(39, 35);
                                dtbtnEdit.FlatStyle = FlatStyle.Flat;
                                dtbtnEdit.BackColor = Color.Black;
                                dtbtnEdit.Cursor = Cursors.Hand;
                                dtbtnEdit.FlatAppearance.BorderColor = Color.Black;
                                dtbtnEdit.FlatAppearance.BorderSize = 1;
                                dtbtnEdit.FlatAppearance.MouseDownBackColor = Color.Black;
                                dtbtnEdit.FlatAppearance.MouseOverBackColor = Color.Black;
                                dtbtnEdit.Image = new Bitmap(NewProduct.Properties.Resources.eraser);
                                dtbtnEdit.ImageAlign = ContentAlignment.MiddleCenter;
                                dtbtnEdit.Click += new EventHandler(dtbtnEdit_Click);
                                pnSearchResult.Controls.Add(dtbtnEdit);

                                //Button Print
                                Button dtbtnPrint = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].REFERENCE_NO.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnPrint, "Print");
                                dtbtnPrint.Text = "";
                                dtbtnPrint.Location = new System.Drawing.Point(825, y - 9);
                                dtbtnPrint.Size = new System.Drawing.Size(39, 35);
                                dtbtnPrint.FlatStyle = FlatStyle.Flat;
                                dtbtnPrint.BackColor = Color.Black;
                                dtbtnPrint.Cursor = Cursors.Hand;
                                dtbtnPrint.FlatAppearance.BorderColor = Color.Black;
                                dtbtnPrint.FlatAppearance.BorderSize = 1;
                                dtbtnPrint.FlatAppearance.MouseDownBackColor = Color.Black;
                                dtbtnPrint.FlatAppearance.MouseOverBackColor = Color.Black;
                                dtbtnPrint.Image = new Bitmap(NewProduct.Properties.Resources.paper_printer);
                                dtbtnPrint.ImageAlign = ContentAlignment.MiddleCenter;
                                dtbtnPrint.Click += new EventHandler(dtbtnPrint_Click);
                                pnSearchResult.Controls.Add(dtbtnPrint);

                                y = dtReferenceNo.Location.Y + 40;
                            }
                        }
                        else if (lbItem.Text == "กลุ่มผลิตภัณฑ์")
                        {

                        }
                        else if (lbItem.Text == "ประเภทผลิตภัณฑ์")
                        {

                        }
                        else if (lbItem.Text == "ชื่อผลิตภัณฑ์สำหรับแสดงบนกล่องสินค้า(ไทย)")
                        {
                            CommonDataSet dsSearch = commonBiz.npd_select_product_temp_by_fieldname_and_fieldvalue("PRODUCT_NAME_TH", txtSearchBox.Text);
                            MessageBox.Show(dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_FIELDNAME_AND_FIELDVALUE[0].ToString());
                        }
                        else if (lbItem.Text == "ชื่อผลิตภัณฑ์สำหรับแสดงบนกล่องสินค้า(English)")
                        {
                            CommonDataSet dsSearch = commonBiz.npd_select_product_temp_by_fieldname_and_fieldvalue("PRODUCT_NAME_ENG", txtSearchBox.Text);
                            MessageBox.Show(dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_FIELDNAME_AND_FIELDVALUE[0].ToString());
                        }
                    }
                    else if (cbSelectTableNPD.SelectedIndex == 1) // Approved
                    {
                        //Change Item Header 
                        lbItemHeader1.Text = "Reference No.";
                        lbItemHeader2.Text = "Product ID";
                        lbItemHeader3.Text = "Product Name TH";

                        HeaderItemsVisible();

                        ClearPanel();

                        if (lbItem.Text == "เลขที่อ้างอิง")
                        {
                            CommonDataSet dsSearch = commonBiz.npd_select_product_temp_by_reference_no(txtSearchBox.Text);
                            //MessageBox.Show(dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[0].REFERENCE_NO.ToString());

                            for (int i = 0; i < dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO.Count; i++)
                            {
                                //Label Reference_No
                                Label dtReferenceNo = new Label();
                                string headerReferenceNo = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].REFERENCE_NO.ToString();
                                dtReferenceNo.Text = headerReferenceNo;
                                dtReferenceNo.Location = new System.Drawing.Point(38, y);
                                dtReferenceNo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtReferenceNo.Size = new System.Drawing.Size(126, 16);
                                dtReferenceNo.AutoSize = false;
                                dtReferenceNo.ForeColor = Color.White;
                                dtReferenceNo.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtReferenceNo);

                                //Label Product_Id
                                Label dtProductId = new Label();
                                string headerProductId = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].PRODUCT_ID.ToString();
                                dtProductId.Text = headerProductId;
                                dtProductId.Location = new System.Drawing.Point(179, y);
                                dtProductId.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductId.Size = new System.Drawing.Size(126, 16);
                                dtProductId.AutoSize = false;
                                dtProductId.ForeColor = Color.White;
                                dtProductId.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductId);

                                //Label Product_Name_TH
                                Label dtProductName = new Label();
                                string headerProductName = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].PRODUCT_NAME_TH.ToString();
                                dtProductName.Text = headerProductName;
                                dtProductName.Location = new System.Drawing.Point(322, y);
                                dtProductName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductName.Size = new System.Drawing.Size(395, 16);
                                dtProductName.AutoSize = false;
                                dtProductName.ForeColor = Color.White;
                                dtProductName.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductName);

                                //Button View
                                Button dtbtnView = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].REFERENCE_NO.ToString();
                                ToolTip tip = new ToolTip();
                                tip.SetToolTip(dtbtnView, "View Data");
                                dtbtnView.Text = "";
                                dtbtnView.Location = new System.Drawing.Point(725, y - 9);
                                dtbtnView.Size = new System.Drawing.Size(39, 35);
                                dtbtnView.FlatStyle = FlatStyle.Flat;
                                dtbtnView.BackColor = Color.Black;
                                dtbtnView.Cursor = Cursors.Hand;
                                dtbtnView.FlatAppearance.BorderColor = Color.Black;
                                dtbtnView.FlatAppearance.BorderSize = 1;
                                dtbtnView.FlatAppearance.MouseDownBackColor = Color.Black;
                                dtbtnView.FlatAppearance.MouseOverBackColor = Color.Black;
                                dtbtnView.Image = new Bitmap(NewProduct.Properties.Resources.post_it);
                                dtbtnView.ImageAlign = ContentAlignment.MiddleCenter;
                                dtbtnView.Click += new EventHandler(dtbtnView_Click);
                                pnSearchResult.Controls.Add(dtbtnView);

                                //Button Edit
                                Button dtbtnEdit = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].REFERENCE_NO.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnEdit, "Edit Data");
                                dtbtnEdit.Text = "";
                                dtbtnEdit.Location = new System.Drawing.Point(775, y - 9);
                                dtbtnEdit.Size = new System.Drawing.Size(39, 35);
                                dtbtnEdit.FlatStyle = FlatStyle.Flat;
                                dtbtnEdit.BackColor = Color.Black;
                                dtbtnEdit.Cursor = Cursors.Hand;
                                dtbtnEdit.FlatAppearance.BorderColor = Color.Black;
                                dtbtnEdit.FlatAppearance.BorderSize = 1;
                                dtbtnEdit.FlatAppearance.MouseDownBackColor = Color.Black;
                                dtbtnEdit.FlatAppearance.MouseOverBackColor = Color.Black;
                                dtbtnEdit.Image = new Bitmap(NewProduct.Properties.Resources.eraser);
                                dtbtnEdit.ImageAlign = ContentAlignment.MiddleCenter;
                                dtbtnEdit.Click += new EventHandler(dtbtnEdit_Click);
                                pnSearchResult.Controls.Add(dtbtnEdit);

                                //Button Print
                                Button dtbtnPrint = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].REFERENCE_NO.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnPrint, "Print");
                                dtbtnPrint.Text = "";
                                dtbtnPrint.Location = new System.Drawing.Point(825, y - 9);
                                dtbtnPrint.Size = new System.Drawing.Size(39, 35);
                                dtbtnPrint.FlatStyle = FlatStyle.Flat;
                                dtbtnPrint.BackColor = Color.Black;
                                dtbtnPrint.Cursor = Cursors.Hand;
                                dtbtnPrint.FlatAppearance.BorderColor = Color.Black;
                                dtbtnPrint.FlatAppearance.BorderSize = 1;
                                dtbtnPrint.FlatAppearance.MouseDownBackColor = Color.Black;
                                dtbtnPrint.FlatAppearance.MouseOverBackColor = Color.Black;
                                dtbtnPrint.Image = new Bitmap(NewProduct.Properties.Resources.paper_printer);
                                dtbtnPrint.ImageAlign = ContentAlignment.MiddleCenter;
                                dtbtnPrint.Click += new EventHandler(dtbtnPrint_Click);
                                pnSearchResult.Controls.Add(dtbtnPrint);

                                y = dtProductId.Location.Y + 40;
                            }
                        }
                    }                    
                }
            }
        }

        private void HeaderItemsVisible()
        {
            pnLineTop.Visible = true;
            pnLineBottom.Visible = true;
            lbItemHeader1.Visible = true;
            lbItemHeader2.Visible = true;
            lbItemHeader3.Visible = true;
        }

        private void ClearPanel()
        {
            pnSearchResult.Controls.Clear();
            y = 10;
        }

        private void dtbtnView_Click(object sender, EventArgs e)
        {
            
        }

        private void dtbtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void dtbtnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
