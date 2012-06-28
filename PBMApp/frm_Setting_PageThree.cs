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
    public partial class frm_Setting_PageThree : Form
    {
        public frm_Setting_PageThree()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                WH_Sys_PageTree wp = new WH_Sys_PageTree();
                string limit = "";
                for (int i = 0; i < checkedListBox3.Items.Count; i++)
                {
                    if(checkedListBox3.GetItemChecked(i))
                    {
                        limit += "1";
                    }
                    else
                    {
                        limit += "0";
                    }
                }
                wp.Authority = limit;
                wp.FootStampRule = comboBox1b.SelectedText;
                wp.FootStampRule_index = comboBox1b.SelectedIndex;
                wp.GiftVoucherChange = comboBox2b.SelectedText;
                wp.GiftVoucherChange_index = comboBox2b.SelectedIndex;
                wp.VATRateForTakeAway = comboBox3b.SelectedText;
                wp.VATRateForTakeAway_index = comboBox3b.SelectedIndex;
                wp.VATRateForInHouse = comboBox4b.SelectedText;
                wp.VATRateForInHouse_index = comboBox4b.SelectedIndex;
                wp.VATRateForOutHouse = comboBox5b.SelectedText;
                wp.VATRateForOutHouse_index = comboBox5b.SelectedIndex;
                wp.PLUPriceForTakeAway = comboBox6b.SelectedText;
                wp.PLUPriceForTakeAway_index = comboBox6b.SelectedIndex;
                wp.KPPrintSetting = comboBox7b.SelectedText;
                wp.KPPrintSetting_index = comboBox7b.SelectedIndex;
                wp.CompReport = comboBox8b.SelectedText;
                wp.CompReport_index = comboBox8b.SelectedIndex;
                m.AddToWH_Sys_PageTree(wp);
                m.SaveChanges();
            }
        }

        private void frm_Setting_PageThree_Load(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = (from c in m.WH_Sys_PageTree
                        orderby c.ID descending
                        select c).FirstOrDefault();
                string limit = q.Authority;
                for (int i = 0; i < limit.Length; i++)
                {
                    if(limit.Substring(i,1)=="1")
                    {
                        checkedListBox3.SetItemChecked(i,true);
                    }
                    else
                    {
                        checkedListBox3.SetItemChecked(i,false);
                    }
                }
                comboBox1b.SelectedIndex = int.Parse(q.FootStampRule_index.ToString());
                comboBox2b.SelectedIndex = int.Parse(q.GiftVoucherChange_index.ToString());
                comboBox3b.SelectedIndex = int.Parse(q.VATRateForTakeAway_index.ToString());
                comboBox4b.SelectedIndex = int.Parse(q.VATRateForInHouse_index.ToString());
                comboBox5b.SelectedIndex = int.Parse(q.VATRateForOutHouse_index.ToString());
                comboBox6b.SelectedIndex = int.Parse(q.PLUPriceForTakeAway_index.ToString());
                comboBox7b.SelectedIndex = int.Parse(q.KPPrintSetting_index.ToString());
                comboBox8b.SelectedIndex = int.Parse(q.CompReport_index.ToString());

            }
        }
    }
}
