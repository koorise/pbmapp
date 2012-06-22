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
    public partial class frm_Setting_PageTwo : Form
    {
        public frm_Setting_PageTwo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                WH_Sys_PageTwo wp = new WH_Sys_PageTwo();
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
                wp.Authority = limit;
                wp.PositionOfReceipt_index = comboBox1.SelectedIndex;
                wp.PositionOfReceipt = comboBox1.SelectedText;
                wp.PositionOfLogo_index = comboBox2.SelectedIndex;
                wp.PositionOfLogo = comboBox2.SelectedText;
                wp.PrintItemsWhenCloseTable_index = comboBox3.SelectedIndex;
                wp.PrintItemsWhenCloseTable = comboBox3.SelectedText;
                wp.ItemDesc_RP_index = comboBox4.SelectedIndex;
                wp.ItemDesc_RP = comboBox4.SelectedText;
                m.AddToWH_Sys_PageTwo(wp);
                m.SaveChanges();
            }
        }

        private void frm_Setting_PageTwo_Load(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = (from c in m.WH_Sys_PageTwo
                        orderby c.ID descending
                        select c).FirstOrDefault();
                string limit = q.Authority;
                for (int i = 0; i < limit.Length; i++)
                {
                    if(limit.Substring(i,1)=="1")
                    {
                        checkedListBox1.SetItemChecked(i,true);
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i,false);
                    }
                }
                comboBox1.SelectedIndex = int.Parse(q.PositionOfReceipt_index.ToString());
                comboBox2.SelectedIndex = int.Parse(q.PositionOfLogo_index.ToString());
                comboBox3.SelectedIndex = int.Parse(q.PrintItemsWhenCloseTable_index.ToString());
                comboBox4.SelectedIndex = int.Parse(q.ItemDesc_RP_index.ToString());
            }
        }
    }
}
