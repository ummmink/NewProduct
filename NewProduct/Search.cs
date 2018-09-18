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

        private void txtSearchBox_Enter(object sender, EventArgs e)
        {
                              
        }

        private void txtSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearchBox.Text != "")
                {
                    if (lbItem.Text == "เลขที่อ้างอิง")
                    {
                        CommonDataSet dsSearch = commonBiz.npd_select_product_temp_by_reference_no(txtSearchBox.Text);
                        MessageBox.Show(dsSearch.NPD_SELECT_PRODUCT_TEMP_BY_REFERENCE_NO[0].PRODUCT_ID.ToString());
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
            }
        }
    }
}
