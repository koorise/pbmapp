using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PBMApp.Model;
using PBMApp.Tools;

namespace PBMApp
{
    public partial class frm_Setting_FlashReport : Form
    {
        public frm_Setting_FlashReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            int ID = comboBox1.SelectedIndex + 1;
            using (var m = new Entities())
            {
                var q = m.WH_Sys_FlashReport.FirstOrDefault(x => x.ID == ID);
                if(textBox1.Text!="")
                {
                    q.Description = textBox1.Text;
                }
                string limit = "";
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if(checkedListBox1.GetItemChecked(i))
                    {
                        limit += "1";
                    }
                    else
                    {
                        limit += "0";
                    }
                }
                q.Authority = limit;
                m.SaveChanges();
                MessageBox.Show("success!", "alert");

            }
        }

        private void frm_Setting_FlashReport_Load(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_FlashReport
                        orderby c.ID ascending
                        select c;
                foreach (var qq in q)
                {
                    Tools.ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = qq.Description;
                    cb.Value = qq.ID;
                    comboBox1.Items.Add(cb);
                }
                comboBox1.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = comboBox1.SelectedIndex + 1;
            using (var m = new Entities())
            {
                var q = m.WH_Sys_FlashReport.FirstOrDefault(x => x.ID == ID);
                string limit = q.Authority;
                for (int i = 0; i < limit.Length; i++)
                {
                    string str = limit.Substring(i,1);
                    if(str=="1")
                    {
                        checkedListBox1.SetItemChecked(i,true);
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }


            }
        }
    }
}
