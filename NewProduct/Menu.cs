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
            MdiClient ctlMDI;

            // Loop through all of the form's controls looking
            // for the control of type MdiClient.
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    // Attempt to cast the control to type MdiClient.
                    ctlMDI = (MdiClient)ctl;

                    // Set the BackColor of the MdiClient control.
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException exc)
                {
                    // Catch and ignore the error if casting failed.
                }
            }

            // Display a child form to show this is still an MDI application.

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

            Form f = new Home_Trade();
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

        private void lbLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากระบบ? ",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lbProjectName_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();

            Form f = new Home_Trade();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnTDO_Click(object sender, EventArgs e)
        {
            variablePublic.user_group_id = "TDO";

            CloseAllChildForm();

            Form f = new Home_Trade();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnTDA_Click(object sender, EventArgs e)
        {
            variablePublic.user_group_id = "TDA";

            CloseAllChildForm();

            Form f = new Home_Trade();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnPSO_Click(object sender, EventArgs e)
        {
            variablePublic.user_group_id = "PSO";

            CloseAllChildForm();

            Form f = new Home();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnPSA_Click(object sender, EventArgs e)
        {
            variablePublic.user_group_id = "PSA";

            CloseAllChildForm();

            Form f = new Home();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnSAO_Click(object sender, EventArgs e)
        {
            variablePublic.user_group_id = "SAO";

            CloseAllChildForm();

            Form f = new Home();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnSAA_Click(object sender, EventArgs e)
        {
            variablePublic.user_group_id = "SAA";

            CloseAllChildForm();

            Form f = new Home();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnMKO_Click(object sender, EventArgs e)
        {
            variablePublic.user_group_id = "MKO";

            CloseAllChildForm();

            Form f = new Home();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnMKA_Click(object sender, EventArgs e)
        {
            variablePublic.user_group_id = "MKA";

            CloseAllChildForm();

            Form f = new Home();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnACO_Click(object sender, EventArgs e)
        {
            variablePublic.user_group_id = "ACO";

            CloseAllChildForm();

            Form f = new Home();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnACA_Click(object sender, EventArgs e)
        {
            variablePublic.user_group_id = "ACA";

            CloseAllChildForm();

            Form f = new Home();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnPDO_Click(object sender, EventArgs e)
        {
            variablePublic.user_group_id = "PDO";

            CloseAllChildForm();

            Form f = new Home();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnPDA_Click(object sender, EventArgs e)
        {
            variablePublic.user_group_id = "PDA";

            CloseAllChildForm();

            Form f = new Home();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }

        private void btnPGM_Click(object sender, EventArgs e)
        {
            variablePublic.user_group_id = "PGM";

            CloseAllChildForm();

            Form f = new Home_Trade();
            f.MdiParent = this;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //set form without maximize,minimize and close button
            f.Dock = DockStyle.Fill; //set form's dock property to fill
            f.Show();
        }
    }
}
