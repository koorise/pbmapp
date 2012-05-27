using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PBMApp
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void openDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
            
        }

        private void pLUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dock=DockStyle.Fill;

            frm_PLU frm = new frm_PLU();

            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_dept frm = new frm_dept();
            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void portSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setting_port frm = new frm_Setting_port();
            frm.ControlBox = false;
            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void systemFlagSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setting_SystemFlag frm = new frm_Setting_SystemFlag();
            frm.ControlBox = false;
            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void clerkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Clerk frm = new frm_Clerk();
            frm.ControlBox = false;
            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

        }

        private void dPLUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DPLU frm = new frm_DPLU();
            frm.ControlBox = false;
            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }


    }
}
