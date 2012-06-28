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
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    if(checkedListBox2.GetItemChecked(i))
                    {
                        limit += "1";
                    }
                    else
                    {
                        limit += "0";
                    }
                }
                wp.Authority = limit;
                wp.PositionOfReceipt_index = comboBox1a.SelectedIndex;
                wp.PositionOfReceipt = comboBox1a.SelectedText;
                wp.PositionOfLogo_index = comboBox2a.SelectedIndex;
                wp.PositionOfLogo = comboBox2a.SelectedText;
                wp.PrintItemsWhenCloseTable_index = comboBox3a.SelectedIndex;
                wp.PrintItemsWhenCloseTable = comboBox3a.SelectedText;
                wp.ItemDesc_RP_index = comboBox4a.SelectedIndex;
                wp.ItemDesc_RP = comboBox4a.SelectedText;
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
                        checkedListBox2.SetItemChecked(i,true);
                    }
                    else
                    {
                        checkedListBox2.SetItemChecked(i,false);
                    }
                }
                comboBox1a.SelectedIndex = int.Parse(q.PositionOfReceipt_index.ToString());
                comboBox2a.SelectedIndex = int.Parse(q.PositionOfLogo_index.ToString());
                comboBox3a.SelectedIndex = int.Parse(q.PrintItemsWhenCloseTable_index.ToString());
                comboBox4a.SelectedIndex = int.Parse(q.ItemDesc_RP_index.ToString());
            }
        }
    }
}
