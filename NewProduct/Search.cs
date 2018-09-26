﻿using System;
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
            AddListBoxInprogreddItems();
            lsbInProgressSearchItems.SelectedIndex = 0;
            lbItem.Text = lsbInProgressSearchItems.SelectedValue.ToString();
        }

        private void AddListBoxInprogreddItems()
        {
            lsbInProgressSearchItems.Items.Clear();
            lsbInProgressSearchItems.Items.Add("เลขที่อ้างอิง");
            lsbInProgressSearchItems.Items.Add("กลุ่มผลิตภัณฑ์");
            //lsbInProgressSearchItems.Items.Add("ประเภทผลิตภัณฑ์");
            lsbInProgressSearchItems.Items.Add("ชื่อผลิตภัณฑ์สำหรับแสดงบน Invoice (ไทย)");
            lsbInProgressSearchItems.Items.Add("ชื่อผลิตภัณฑ์สำหรับแสดงบน Invoice (English)");
        }

        private void AddListBoxApprovedItems()
        {
            lsbInProgressSearchItems.Items.Clear();
            lsbInProgressSearchItems.Items.Add("รหัสสินค้า");
            lsbInProgressSearchItems.Items.Add("กลุ่มผลิตภัณฑ์");
            //lsbInProgressSearchItems.Items.Add("ประเภทผลิตภัณฑ์");
            lsbInProgressSearchItems.Items.Add("ชื่อผลิตภัณฑ์สำหรับแสดงบน Invoice (ไทย)");
            lsbInProgressSearchItems.Items.Add("ชื่อผลิตภัณฑ์สำหรับแสดงบน Invoice (English)");
        }

        private void lsbSearchItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbItem.Text = lsbInProgressSearchItems.SelectedItem.ToString();
            lsbInProgressSearchItems.Visible = false;
        }

        private void lbItem_Click(object sender, EventArgs e)
        {
            if (lsbInProgressSearchItems.Visible == true)
            {
                lsbInProgressSearchItems.Visible = false;
            }
            else
            {
                lsbInProgressSearchItems.Visible = true;
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
                        lbItemHeader4.Text = "Product Name EH";

                        HeaderItemsVisible();

                        ClearPanel();

                        if (lbItem.Text == "เลขที่อ้างอิง")
                        {
                            #region Search Reference No.
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
                                dtProductName.Size = new System.Drawing.Size(360, 16);
                                dtProductName.AutoSize = false;
                                dtProductName.ForeColor = Color.White;
                                dtProductName.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductName);

                                //Label Product_Name_EN
                                Label dtProductNameEN = new Label();
                                string headerProductNameEN = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].PRODUCT_NAME_ENG.ToString();
                                dtProductNameEN.Text = headerProductNameEN;
                                dtProductNameEN.Location = new System.Drawing.Point(696, y);
                                dtProductNameEN.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductNameEN.Size = new System.Drawing.Size(360, 16);
                                dtProductNameEN.AutoSize = false;
                                dtProductNameEN.ForeColor = Color.White;
                                dtProductNameEN.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductNameEN);

                                //Button View
                                Button dtbtnView = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[i].REFERENCE_NO.ToString();
                                ToolTip tip = new ToolTip();
                                tip.SetToolTip(dtbtnView, "View Data");
                                dtbtnView.Text = "";
                                dtbtnView.Location = new System.Drawing.Point(1099, y - 9);
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
                                dtbtnEdit.Location = new System.Drawing.Point(1149, y - 9);
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
                                dtbtnPrint.Location = new System.Drawing.Point(1199, y - 9);
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
                            #endregion                            
                        }
                        else if (lbItem.Text == "กลุ่มผลิตภัณฑ์")
                        {
                            #region Search Product Type = Type ID
                            CommonDataSet dsSearch = commonBiz.npd_select_product_temp_by_product_type(txtSearchBox.Text);
                            //MessageBox.Show(dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[0].REFERENCE_NO.ToString());

                            for (int i = 0; i < dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_TYPE.Count; i++)
                            {
                                //Label Reference_No
                                Label dtReferenceNo = new Label();
                                string headerReferenceNo = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_TYPE[i].REFERENCE_NO.ToString();
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
                                string headerShortName = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_TYPE[i].SHORT_NAME.ToString();
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
                                string headerProductName = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_TYPE[i].PRODUCT_NAME_TH.ToString();
                                dtProductName.Text = headerProductName;
                                dtProductName.Location = new System.Drawing.Point(322, y);
                                dtProductName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductName.Size = new System.Drawing.Size(360, 16);
                                dtProductName.AutoSize = false;
                                dtProductName.ForeColor = Color.White;
                                dtProductName.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductName);

                                //Label Product_Name_EN
                                Label dtProductNameEN = new Label();
                                string headerProductNameEN = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_TYPE[i].PRODUCT_NAME_ENG.ToString();
                                dtProductNameEN.Text = headerProductNameEN;
                                dtProductNameEN.Location = new System.Drawing.Point(696, y);
                                dtProductNameEN.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductNameEN.Size = new System.Drawing.Size(360, 16);
                                dtProductNameEN.AutoSize = false;
                                dtProductNameEN.ForeColor = Color.White;
                                dtProductNameEN.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductNameEN);

                                //Button View
                                Button dtbtnView = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_TYPE[i].REFERENCE_NO.ToString();
                                ToolTip tip = new ToolTip();
                                tip.SetToolTip(dtbtnView, "View Data");
                                dtbtnView.Text = "";
                                dtbtnView.Location = new System.Drawing.Point(1099, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_TYPE[i].REFERENCE_NO.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnEdit, "Edit Data");
                                dtbtnEdit.Text = "";
                                dtbtnEdit.Location = new System.Drawing.Point(1149, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_TYPE[i].REFERENCE_NO.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnPrint, "Print");
                                dtbtnPrint.Text = "";
                                dtbtnPrint.Location = new System.Drawing.Point(1199, y - 9);
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
                            #endregion                            
                        }
                        else if (lbItem.Text == "ประเภทผลิตภัณฑ์")
                        {

                        }
                        else if (lbItem.Text == "ชื่อผลิตภัณฑ์สำหรับแสดงบน Invoice (ไทย)")
                        {
                            #region Search Product Name TH Invoice
                            CommonDataSet dsSearch = commonBiz.npd_select_product_temp_by_product_name_th_invoice(txtSearchBox.Text);
                            //MessageBox.Show(dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[0].REFERENCE_NO.ToString());

                            for (int i = 0; i < dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_TH_Invoice.Count; i++)
                            {
                                //Label Reference_No
                                Label dtReferenceNo = new Label();
                                string headerReferenceNo = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_TH_Invoice[i].REFERENCE_NO.ToString();
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
                                string headerShortName = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_TH_Invoice[i].SHORT_NAME.ToString();
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
                                string headerProductName = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_TH_Invoice[i].PRODUCT_NAME_TH.ToString();
                                dtProductName.Text = headerProductName;
                                dtProductName.Location = new System.Drawing.Point(322, y);
                                dtProductName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductName.Size = new System.Drawing.Size(360, 16);
                                dtProductName.AutoSize = false;
                                dtProductName.ForeColor = Color.White;
                                dtProductName.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductName);

                                //Label Product_Name_EN
                                Label dtProductNameEN = new Label();
                                string headerProductNameEN = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_TH_Invoice[i].PRODUCT_NAME_ENG.ToString();
                                dtProductNameEN.Text = headerProductNameEN;
                                dtProductNameEN.Location = new System.Drawing.Point(696, y);
                                dtProductNameEN.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductNameEN.Size = new System.Drawing.Size(360, 16);
                                dtProductNameEN.AutoSize = false;
                                dtProductNameEN.ForeColor = Color.White;
                                dtProductNameEN.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductNameEN);

                                //Button View
                                Button dtbtnView = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_TH_Invoice[i].REFERENCE_NO.ToString();
                                ToolTip tip = new ToolTip();
                                tip.SetToolTip(dtbtnView, "View Data");
                                dtbtnView.Text = "";
                                dtbtnView.Location = new System.Drawing.Point(1099, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_TH_Invoice[i].REFERENCE_NO.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnEdit, "Edit Data");
                                dtbtnEdit.Text = "";
                                dtbtnEdit.Location = new System.Drawing.Point(1149, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_TH_Invoice[i].REFERENCE_NO.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnPrint, "Print");
                                dtbtnPrint.Text = "";
                                dtbtnPrint.Location = new System.Drawing.Point(1199, y - 9);
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
                            #endregion                            
                        }
                        else if (lbItem.Text == "ชื่อผลิตภัณฑ์สำหรับแสดงบน Invoice (English)")
                        {
                            #region Search Product Name ENG Invoice
                            CommonDataSet dsSearch = commonBiz.npd_select_product_temp_by_product_name_eng_invoice(txtSearchBox.Text);
                            //MessageBox.Show(dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[0].REFERENCE_NO.ToString());

                            for (int i = 0; i < dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_ENG_Invoice.Count; i++)
                            {
                                //Label Reference_No
                                Label dtReferenceNo = new Label();
                                string headerReferenceNo = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_ENG_Invoice[i].REFERENCE_NO.ToString();
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
                                string headerShortName = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_ENG_Invoice[i].SHORT_NAME.ToString();
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
                                string headerProductName = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_ENG_Invoice[i].PRODUCT_NAME_TH.ToString();
                                dtProductName.Text = headerProductName;
                                dtProductName.Location = new System.Drawing.Point(322, y);
                                dtProductName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductName.Size = new System.Drawing.Size(360, 16);
                                dtProductName.AutoSize = false;
                                dtProductName.ForeColor = Color.White;
                                dtProductName.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductName);

                                //Label Product_Name_EN
                                Label dtProductNameEN = new Label();
                                string headerProductNameEN = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_ENG_Invoice[i].PRODUCT_NAME_ENG.ToString();
                                dtProductNameEN.Text = headerProductNameEN;
                                dtProductNameEN.Location = new System.Drawing.Point(696, y);
                                dtProductNameEN.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductNameEN.Size = new System.Drawing.Size(360, 16);
                                dtProductNameEN.AutoSize = false;
                                dtProductNameEN.ForeColor = Color.White;
                                dtProductNameEN.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductNameEN);

                                //Button View
                                Button dtbtnView = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_ENG_Invoice[i].REFERENCE_NO.ToString();
                                ToolTip tip = new ToolTip();
                                tip.SetToolTip(dtbtnView, "View Data");
                                dtbtnView.Text = "";
                                dtbtnView.Location = new System.Drawing.Point(1099, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_ENG_Invoice[i].REFERENCE_NO.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnEdit, "Edit Data");
                                dtbtnEdit.Text = "";
                                dtbtnEdit.Location = new System.Drawing.Point(1149, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_PRODUCT_NAME_ENG_Invoice[i].REFERENCE_NO.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnPrint, "Print");
                                dtbtnPrint.Text = "";
                                dtbtnPrint.Location = new System.Drawing.Point(1199, y - 9);
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
                            #endregion                            
                        }
                    }
                    else if (cbSelectTableNPD.SelectedIndex == 1) // Approved
                    {                       
                        //Change Item Header 
                        lbItemHeader1.Text = "Product ID";
                        lbItemHeader2.Text = "Short Name";
                        lbItemHeader3.Text = "Product Name TH";
                        lbItemHeader4.Text = "Product Name EH";

                        HeaderItemsVisible();

                        ClearPanel();

                        if (lbItem.Text == "รหัสสินค้า")
                        {
                            #region Search Reference No.
                            CommonDataSet dsSearch = commonBiz.npd_select_product_by_product_id(txtSearchBox.Text);

                            for (int i = 0; i < dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_ID.Count; i++)
                            {
                                //Label Product ID
                                Label dtProductID = new Label();
                                string headerProductID = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_ID[i].PRODUCT_ID.ToString();
                                dtProductID.Text = headerProductID;
                                dtProductID.Location = new System.Drawing.Point(38, y);
                                dtProductID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductID.Size = new System.Drawing.Size(126, 16);
                                dtProductID.AutoSize = false;
                                dtProductID.ForeColor = Color.White;
                                dtProductID.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductID);

                                //Label Short Name
                                Label dtShortName = new Label();
                                string headerShortName = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_ID[i].SHORT_NAME.ToString();
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
                                string headerProductName = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_ID[i].PRODUCT_NAME_TH.ToString();
                                dtProductName.Text = headerProductName;
                                dtProductName.Location = new System.Drawing.Point(322, y);
                                dtProductName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductName.Size = new System.Drawing.Size(360, 16);
                                dtProductName.AutoSize = false;
                                dtProductName.ForeColor = Color.White;
                                dtProductName.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductName);

                                //Label Product_Name_EN
                                Label dtProductNameEN = new Label();
                                string headerProductNameEN = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_ID[i].PRODUCT_NAME_ENG.ToString();
                                dtProductNameEN.Text = headerProductNameEN;
                                dtProductNameEN.Location = new System.Drawing.Point(696, y);
                                dtProductNameEN.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductNameEN.Size = new System.Drawing.Size(360, 16);
                                dtProductNameEN.AutoSize = false;
                                dtProductNameEN.ForeColor = Color.White;
                                dtProductNameEN.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductNameEN);

                                //Button View
                                Button dtbtnView = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_ID[i].PRODUCT_ID.ToString();
                                ToolTip tip = new ToolTip();
                                tip.SetToolTip(dtbtnView, "View Data");
                                dtbtnView.Text = "";
                                dtbtnView.Location = new System.Drawing.Point(1099, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_ID[i].PRODUCT_ID.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnEdit, "Edit Data");
                                dtbtnEdit.Text = "";
                                dtbtnEdit.Location = new System.Drawing.Point(1149, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_ID[i].PRODUCT_ID.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnPrint, "Print");
                                dtbtnPrint.Text = "";
                                dtbtnPrint.Location = new System.Drawing.Point(1199, y - 9);
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

                                y = dtProductID.Location.Y + 40;
                            }
                            #endregion                           
                        }
                        else if (lbItem.Text == "กลุ่มผลิตภัณฑ์")
                        {
                            #region Search Product Type = Type ID
                            CommonDataSet dsSearch = commonBiz.npd_select_product_by_product_type(txtSearchBox.Text);

                            for (int i = 0; i < dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_TYPE.Count; i++)
                            {
                                //Label Product ID
                                Label dtProductID = new Label();
                                string headerProductID = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_TYPE[i].PRODUCT_ID.ToString();
                                dtProductID.Text = headerProductID;
                                dtProductID.Location = new System.Drawing.Point(38, y);
                                dtProductID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductID.Size = new System.Drawing.Size(126, 16);
                                dtProductID.AutoSize = false;
                                dtProductID.ForeColor = Color.White;
                                dtProductID.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductID);

                                //Label Short Name
                                Label dtShortName = new Label();
                                string headerShortName = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_TYPE[i].SHORT_NAME.ToString();
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
                                string headerProductName = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_TYPE[i].PRODUCT_NAME_TH.ToString();
                                dtProductName.Text = headerProductName;
                                dtProductName.Location = new System.Drawing.Point(322, y);
                                dtProductName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductName.Size = new System.Drawing.Size(360, 16);
                                dtProductName.AutoSize = false;
                                dtProductName.ForeColor = Color.White;
                                dtProductName.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductName);

                                //Label Product_Name_EN
                                Label dtProductNameEN = new Label();
                                string headerProductNameEN = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_TYPE[i].PRODUCT_NAME_ENG.ToString();
                                dtProductNameEN.Text = headerProductNameEN;
                                dtProductNameEN.Location = new System.Drawing.Point(696, y);
                                dtProductNameEN.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductNameEN.Size = new System.Drawing.Size(360, 16);
                                dtProductNameEN.AutoSize = false;
                                dtProductNameEN.ForeColor = Color.White;
                                dtProductNameEN.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductNameEN);

                                //Button View
                                Button dtbtnView = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_TYPE[i].PRODUCT_ID.ToString();
                                ToolTip tip = new ToolTip();
                                tip.SetToolTip(dtbtnView, "View Data");
                                dtbtnView.Text = "";
                                dtbtnView.Location = new System.Drawing.Point(1099, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_TYPE[i].PRODUCT_ID.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnEdit, "Edit Data");
                                dtbtnEdit.Text = "";
                                dtbtnEdit.Location = new System.Drawing.Point(1149, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_TYPE[i].PRODUCT_ID.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnPrint, "Print");
                                dtbtnPrint.Text = "";
                                dtbtnPrint.Location = new System.Drawing.Point(1199, y - 9);
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

                                y = dtProductID.Location.Y + 40;
                            }
                            #endregion                           
                        }
                        else if (lbItem.Text == "ชื่อผลิตภัณฑ์สำหรับแสดงบน Invoice (ไทย)")
                        {
                            #region Search Product Name TH Invoice
                            CommonDataSet dsSearch = commonBiz.npd_select_product_by_product_name_th(txtSearchBox.Text);

                            for (int i = 0; i < dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_TH.Count; i++)
                            {
                                //Label Product ID
                                Label dtProductID = new Label();
                                string headerProductID = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_TH[i].PRODUCT_ID.ToString();
                                dtProductID.Text = headerProductID;
                                dtProductID.Location = new System.Drawing.Point(38, y);
                                dtProductID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductID.Size = new System.Drawing.Size(126, 16);
                                dtProductID.AutoSize = false;
                                dtProductID.ForeColor = Color.White;
                                dtProductID.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductID);

                                //Label Short Name
                                Label dtShortName = new Label();
                                string headerShortName = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_TH[i].SHORT_NAME.ToString();
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
                                string headerProductName = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_TH[i].PRODUCT_NAME_TH.ToString();
                                dtProductName.Text = headerProductName;
                                dtProductName.Location = new System.Drawing.Point(322, y);
                                dtProductName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductName.Size = new System.Drawing.Size(360, 16);
                                dtProductName.AutoSize = false;
                                dtProductName.ForeColor = Color.White;
                                dtProductName.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductName);

                                //Label Product_Name_EN
                                Label dtProductNameEN = new Label();
                                string headerProductNameEN = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_TH[i].PRODUCT_NAME_ENG.ToString();
                                dtProductNameEN.Text = headerProductNameEN;
                                dtProductNameEN.Location = new System.Drawing.Point(696, y);
                                dtProductNameEN.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductNameEN.Size = new System.Drawing.Size(360, 16);
                                dtProductNameEN.AutoSize = false;
                                dtProductNameEN.ForeColor = Color.White;
                                dtProductNameEN.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductNameEN);

                                //Button View
                                Button dtbtnView = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_TH[i].PRODUCT_ID.ToString();
                                ToolTip tip = new ToolTip();
                                tip.SetToolTip(dtbtnView, "View Data");
                                dtbtnView.Text = "";
                                dtbtnView.Location = new System.Drawing.Point(1099, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_TH[i].PRODUCT_ID.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnEdit, "Edit Data");
                                dtbtnEdit.Text = "";
                                dtbtnEdit.Location = new System.Drawing.Point(1149, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_TH[i].PRODUCT_ID.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnPrint, "Print");
                                dtbtnPrint.Text = "";
                                dtbtnPrint.Location = new System.Drawing.Point(1199, y - 9);
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

                                y = dtProductID.Location.Y + 40;
                            }
                            #endregion                           
                        }
                        else if (lbItem.Text == "ชื่อผลิตภัณฑ์สำหรับแสดงบน Invoice (English)")
                        {
                            #region Search Product Name ENG Invoice
                            CommonDataSet dsSearch = commonBiz.npd_select_product_by_product_name_eng(txtSearchBox.Text);

                            for (int i = 0; i < dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_ENG.Count; i++)
                            {
                                //Label Product ID
                                Label dtProductID = new Label();
                                string headerProductID = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_ENG[i].PRODUCT_ID.ToString();
                                dtProductID.Text = headerProductID;
                                dtProductID.Location = new System.Drawing.Point(38, y);
                                dtProductID.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductID.Size = new System.Drawing.Size(126, 16);
                                dtProductID.AutoSize = false;
                                dtProductID.ForeColor = Color.White;
                                dtProductID.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductID);

                                //Label Short Name
                                Label dtShortName = new Label();
                                string headerShortName = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_ENG[i].SHORT_NAME.ToString();
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
                                string headerProductName = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_ENG[i].PRODUCT_NAME_TH.ToString();
                                dtProductName.Text = headerProductName;
                                dtProductName.Location = new System.Drawing.Point(322, y);
                                dtProductName.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductName.Size = new System.Drawing.Size(360, 16);
                                dtProductName.AutoSize = false;
                                dtProductName.ForeColor = Color.White;
                                dtProductName.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductName);

                                //Label Product_Name_EN
                                Label dtProductNameEN = new Label();
                                string headerProductNameEN = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_ENG[i].PRODUCT_NAME_ENG.ToString();
                                dtProductNameEN.Text = headerProductNameEN;
                                dtProductNameEN.Location = new System.Drawing.Point(696, y);
                                dtProductNameEN.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
                                dtProductNameEN.Size = new System.Drawing.Size(360, 16);
                                dtProductNameEN.AutoSize = false;
                                dtProductNameEN.ForeColor = Color.White;
                                dtProductNameEN.TextAlign = ContentAlignment.MiddleLeft;
                                pnSearchResult.Controls.Add(dtProductNameEN);

                                //Button View
                                Button dtbtnView = new Button();
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_ENG[i].PRODUCT_ID.ToString();
                                ToolTip tip = new ToolTip();
                                tip.SetToolTip(dtbtnView, "View Data");
                                dtbtnView.Text = "";
                                dtbtnView.Location = new System.Drawing.Point(1099, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_ENG[i].PRODUCT_ID.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnEdit, "Edit Data");
                                dtbtnEdit.Text = "";
                                dtbtnEdit.Location = new System.Drawing.Point(1149, y - 9);
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
                                dtbtnView.Name = dsSearch.NPD_SELECT_PRODUCT_BY_PRODUCT_NAME_ENG[i].PRODUCT_ID.ToString();
                                //ToolTip tipEdit = new ToolTip();
                                tip.SetToolTip(dtbtnPrint, "Print");
                                dtbtnPrint.Text = "";
                                dtbtnPrint.Location = new System.Drawing.Point(1199, y - 9);
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

                                y = dtProductID.Location.Y + 40;
                            }
                            #endregion                           
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
            lbItemHeader4.Visible = true;
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

        private void cbSelectTableNPD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSelectTableNPD.SelectedIndex == 0) // In Progress
            {
                AddListBoxInprogreddItems();
                lsbInProgressSearchItems.SelectedIndex = 0;
                lbItem.Text = lsbInProgressSearchItems.SelectedValue.ToString();
            }
            else if (cbSelectTableNPD.SelectedIndex == 1) // Approved
            {
                AddListBoxApprovedItems();
                lsbInProgressSearchItems.SelectedIndex = 0;
                lbItem.Text = lsbInProgressSearchItems.SelectedValue.ToString();
            }
        }
    }
}
