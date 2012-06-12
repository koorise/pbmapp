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
            string newName = Tools.Config.GetAppConfig("newName");
            string newConString = string.Format(Tools.Config.GetAppConfig("newConString"), System.IO.Path.GetDirectoryName(openFileDialog1.FileName)+"\\"+System.IO.Path.GetFileName(openFileDialog1.FileName));
            string newProviderName = Tools.Config.GetAppConfig("newProviderName");
            //Tools.Config.UpdateConnectionStringsConfig(newName, newConString, newProviderName);

        } 

        private void deptSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_dept frm = new frm_dept();
            frm.ControlBox = false;
            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

        }

        private void clerkSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Clerk frm = new frm_Clerk();
            frm.ControlBox = false;
            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

        }

        private void pLUSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_PLU frm = new frm_PLU();
            frm.ControlBox = false;
            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void cookingMessageSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_CookInfo frm = new frm_CookInfo();
            frm.ControlBox = false;
            frm.ControlBox = false;
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        } 
    }
}
