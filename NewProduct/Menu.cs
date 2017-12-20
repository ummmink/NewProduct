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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            CloseAllChildForm();

            //try
            //{
            //    //gen EMP_ID
            //    CommonDataSet dsP = commonBiz.select_program_path(variablePublic.program_id);
            //    IniFile iniEmp = new IniFile(dsP.select_program_path[0].program_path_target.ToString() +
            //        "\\Setting.ini");
            //    variablePublic.emp_id = iniEmp.IniReadValue("EMPLOYEE", "EMP_ID");

            //    //gen EMP_NAME and permission
            //    CommonDataSet dsN = commonBiz.select_emp_uid_and_permission(
            //        variablePublic.program_id, variablePublic.emp_id);

            //    if (dsN.SELECT_EMP_UID_AND_PERMISSION.Rows.Count > 0)
            //    {
            //        variablePublic.emp_name =
            //            dsN.SELECT_EMP_UID_AND_PERMISSION[0].EMP_NAME.ToString();
            //        variablePublic.program_value =
            //            ConvertUtil.parseInt(dsN.SELECT_EMP_UID_AND_PERMISSION[0].PROGRAM_VALUE);

            //        lbHello.Text = "Hello, " + variablePublic.emp_name + "!";
            //    }
            //    else
            //    {
            //        MessageBox.Show("กรุณาตรวจสอบสิทธิ์การใช้งานโปรแกรม",
            //                    "ข้อความแจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }

            //}
            //catch
            //{
            //    MessageBox.Show("กรุณาตรวจสอบสิทธิ์การใช้งานโปรแกรม",
            //                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            Form f = new Product();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void CloseAllChildForm()
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close(); 
            }
        }

        private void lbProduct_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();

            Form f = new Product();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();

            Form f = new Product();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }
    }
}
