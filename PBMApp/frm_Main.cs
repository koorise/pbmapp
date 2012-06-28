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
        Point  p = new Point(0,0);
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
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
             
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
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
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
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
            frm.AutoScroll = true;
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
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
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
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
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
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
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
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
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
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
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
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
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
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void bundleSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frm_bundle frm = new frm_bundle();
            frm.MdiParent = this;
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }
        
        private void tableBarcodeMailerftpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frm_Setting_PageSeven frm = new frm_Setting_PageSeven();
            frm.MdiParent = this;
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void electronicScaleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frm_Setting_ElectronicScale frm = new frm_Setting_ElectronicScale();
            frm.MdiParent = this;
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void happyHourServiceTaxToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frm_HappyHour_ServiceTax frm = new frm_HappyHour_ServiceTax();
            frm.MdiParent = this;
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void pageFourToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frm_Setting_PageFour frm = new frm_Setting_PageFour();
            frm.MdiParent = this;
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void pageThreeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frm_Setting_PageThree frm = new frm_Setting_PageThree();
            frm.MdiParent = this;
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void pageTwoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frm_Setting_PageTwo frm = new frm_Setting_PageTwo();
            frm.MdiParent = this;
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void pageOneToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frm_Setting_PageOne frm = new frm_Setting_PageOne();
            frm.MdiParent = this;
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void flashReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setting_FlashReport frm = new frm_Setting_FlashReport();
            frm.MdiParent = this;
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void kPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setting_Port_KP frm = new frm_Setting_Port_KP();
            frm.MdiParent = this;
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();

        }

        private void keyDescriptorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setting_KeyDesc frm = new frm_Setting_KeyDesc();
            frm.MdiParent = this;
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
            foreach (Form f in this.MdiChildren)
            {
                if (f != frm)
                {
                    f.Dispose();
                }
            }
            frm.Show();
        }

        private void systemFlagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Setting_SystemFlag frm = new frm_Setting_SystemFlag();
            frm.MdiParent = this;
            frm.Location = p;
            //frm.ControlBox = false;
            //frm.WindowState = FormWindowState.Maximized;
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
