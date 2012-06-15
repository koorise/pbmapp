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
            Tools.Config.UpdateConnectionStringsConfig(newName, newConString, newProviderName);

        } 

        private void deptSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_dept frm = new frm_dept();
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();

        }

        private void clerkSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Clerk frm = new frm_Clerk();
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void pLUSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_PLU frm = new frm_PLU();
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void cookingMessageSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
            frm_CookInfo frm = new frm_CookInfo();
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }
        /// <summary>
        /// 功能名称:查看MDI子窗体是否已经被打开
        /// 输入参数:MdiFather,Form,需要判断的父窗体对象
        ///          MdiChild,string,需要判断的子窗体控件名
        /// 返回结果:-1为没有被打开,正数为子窗体集的数组下标
        /// </summary>
        public static int HaveOpened(Form frmMdiFather, string strMdiChild)
        {
            int bReturn = -1;
            for (int i = 0; i < frmMdiFather.MdiChildren.Length; i++)
            {
                if (frmMdiFather.MdiChildren[i].Name == strMdiChild)
                {
                    frmMdiFather.MdiChildren[i].BringToFront();
                    bReturn = i;
                    break;
                }
            }
            return bReturn;
        }

        private void headerFooterSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setting_HeaderFooter frm = new frm_Setting_HeaderFooter();
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void supplierSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setting_Supplier frm = new frm_Setting_Supplier();
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void paymentRefundCouponToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_payment frm = new frm_payment();
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();

        }

        private void pCASHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setting_PCASH_FCE frm = new frm_Setting_PCASH_FCE();
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void taxSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Tax frm = new frm_Tax();
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void menuSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_menu_plu frm = new frm_menu_plu();
            frm.MdiParent = this;
            frm.ControlBox = false;
            frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }
    }
}
