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

                q.OperateType_index = comboBox1.SelectedIndex;
                q.Position_index = comboBox2.SelectedIndex;
                q.widths = int.Parse(textBox1.Text);
                q.heights = int.Parse(textBox2.Text);
                q.HRI_index = comboBox4.SelectedIndex;
                q.Fonts_index = comboBox5.SelectedIndex;
                q.PrintList = checkBox1.Checked ? 1 : 0;
                q.suspendTable = checkBox2.Checked ? 1 : 0;
                q.TransferTable = checkBox3.Checked ? 1 : 0;
                q.OperateType = comboBox1.SelectedText;
                q.Position = comboBox2.SelectedText;
                q.HRI = comboBox4.SelectedText;
                q.Fonts = comboBox5.SelectedText;


                WH_Sys_mailer qq = m.WH_Sys_mailer.FirstOrDefault(); 
                qq.MailerName = textBox3.Text;
                qq.MailerCode = textBox4.Text;
                qq.TenantCode = textBox5.Text;

                WH_Sys_Ftp qqq = m.WH_Sys_Ftp.FirstOrDefault();
                qqq.IP = textBox6.Text;
                qqq.UserName = textBox7.Text;
                qqq.PassWord = textBox8.Text;
                m.SaveChanges();

                MessageBox.Show("success", "alert");
            }
        }

        private void frm_Setting_PageSeven_Load(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = m.WH_Sys_TableBarcode.FirstOrDefault();
                comboBox1.SelectedIndex = int.Parse(q.OperateType_index.ToString());
                comboBox2.SelectedIndex = int.Parse(q.Position_index.ToString());
                textBox1.Text = q.widths.ToString();
                textBox2.Text = q.heights.ToString();
                comboBox4.SelectedIndex = int.Parse(q.HRI_index.ToString());
                comboBox5.SelectedIndex = int.Parse(q.Fonts_index.ToString());
                checkBox1.Checked = int.Parse(q.PrintList.ToString()) == 1;
                checkBox2.Checked = int.Parse(q.suspendTable.ToString()) == 1;
                checkBox3.Checked = int.Parse(q.TransferTable.ToString()) == 1;

                var qq = m.WH_Sys_mailer.FirstOrDefault();
                textBox3.Text = qq.MailerName.ToString();
                textBox4.Text = qq.MailerCode.ToString();
                textBox5.Text = qq.TenantCode.ToString();

                var qqq = m.WH_Sys_Ftp.FirstOrDefault();
                textBox6.Text = qqq.IP.ToString();
                textBox7.Text = qqq.UserName.ToString();
                textBox8.Text = qqq.PassWord.ToString();
            }
        }
    }
}
