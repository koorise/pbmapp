using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PBMApp.Model;

namespace PBMApp
{
    public partial class frm_Setting_PageSeven : Form
    {
        public frm_Setting_PageSeven()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                WH_Sys_TableBarcode q = m.WH_Sys_TableBarcode.FirstOrDefault(); 

                q.OperateType_index = comboBox1d.SelectedIndex;
                q.Position_index = comboBox2d.SelectedIndex;
                q.widths = int.Parse(textBox1d.Text);
                q.heights = int.Parse(textBox2d.Text);
                q.HRI_index = comboBox4d.SelectedIndex;
                q.Fonts_index = comboBox5d.SelectedIndex;
                q.PrintList = checkBox1d.Checked ? 1 : 0;
                q.suspendTable = checkBox2d.Checked ? 1 : 0;
                q.TransferTable = checkBox3d.Checked ? 1 : 0;
                q.OperateType = comboBox1d.SelectedText;
                q.Position = comboBox2d.SelectedText;
                q.HRI = comboBox4d.SelectedText;
                q.Fonts = comboBox5d.SelectedText;


                WH_Sys_mailer qq = m.WH_Sys_mailer.FirstOrDefault(); 
                qq.MailerName = textBox3d.Text;
                qq.MailerCode = textBox4d.Text;
                qq.TenantCode = textBox5d.Text;

                WH_Sys_Ftp qqq = m.WH_Sys_Ftp.FirstOrDefault();
                qqq.IP = textBox6d.Text;
                qqq.UserName = textBox7d.Text;
                qqq.PassWord = textBox8d.Text;
                m.SaveChanges();

                MessageBox.Show("success", "alert");
            }
        }

        private void frm_Setting_PageSeven_Load(object sender, EventArgs e)
        {
            textBox1d.KeyPress += (Tools.Validate.KeyPress);
            textBox2d.KeyPress += (Tools.Validate.KeyPress);
            using (var m = new Entities())
            {
                var q = m.WH_Sys_TableBarcode.FirstOrDefault();
                comboBox1d.SelectedIndex = int.Parse(q.OperateType_index.ToString());
                comboBox2d.SelectedIndex = int.Parse(q.Position_index.ToString());
                textBox1d.Text = q.widths.ToString();
                textBox2d.Text = q.heights.ToString();
                comboBox4d.SelectedIndex = int.Parse(q.HRI_index.ToString());
                comboBox5d.SelectedIndex = int.Parse(q.Fonts_index.ToString());
                checkBox1d.Checked = int.Parse(q.PrintList.ToString()) == 1;
                checkBox2d.Checked = int.Parse(q.suspendTable.ToString()) == 1;
                checkBox3d.Checked = int.Parse(q.TransferTable.ToString()) == 1;

                var qq = m.WH_Sys_mailer.FirstOrDefault();
                textBox3d.Text = qq.MailerName.ToString();
                textBox4d.Text = qq.MailerCode.ToString();
                textBox5d.Text = qq.TenantCode.ToString();

                var qqq = m.WH_Sys_Ftp.FirstOrDefault();
                textBox6d.Text = qqq.IP.ToString();
                textBox7d.Text = qqq.UserName.ToString();
                textBox8d.Text = qqq.PassWord.ToString();
            }
        }
    }
}
