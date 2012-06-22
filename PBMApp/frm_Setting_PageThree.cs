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
                wp.FootStampRule = comboBox1.SelectedText;
                wp.FootStampRule_index = comboBox1.SelectedIndex;
                wp.GiftVoucherChange = comboBox2.SelectedText;
                wp.GiftVoucherChange_index = comboBox2.SelectedIndex;
                wp.VATRateForTakeAway = comboBox3.SelectedText;
                wp.VATRateForTakeAway_index = comboBox3.SelectedIndex;
                wp.VATRateForInHouse = comboBox4.SelectedText;
                wp.VATRateForInHouse_index = comboBox4.SelectedIndex;
                wp.VATRateForOutHouse = comboBox5.SelectedText;
                wp.VATRateForOutHouse_index = comboBox5.SelectedIndex;
                wp.PLUPriceForTakeAway = comboBox6.SelectedText;
                wp.PLUPriceForTakeAway_index = comboBox6.SelectedIndex;
                wp.KPPrintSetting = comboBox7.SelectedText;
                wp.KPPrintSetting_index = comboBox7.SelectedIndex;
                wp.CompReport = comboBox8.SelectedText;
                wp.CompReport_index = comboBox8.SelectedIndex;
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
                        checkedListBox1.SetItemChecked(i,true);
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i,false);
                    }
                }
                comboBox1.SelectedIndex = int.Parse(q.FootStampRule_index.ToString());
                comboBox2.SelectedIndex = int.Parse(q.GiftVoucherChange_index.ToString());
                comboBox3.SelectedIndex = int.Parse(q.VATRateForTakeAway_index.ToString());
                comboBox4.SelectedIndex = int.Parse(q.VATRateForInHouse_index.ToString());
                comboBox5.SelectedIndex = int.Parse(q.VATRateForOutHouse_index.ToString());
                comboBox6.SelectedIndex = int.Parse(q.PLUPriceForTakeAway_index.ToString());
                comboBox7.SelectedIndex = int.Parse(q.KPPrintSetting_index.ToString());
                comboBox8.SelectedIndex = int.Parse(q.CompReport_index.ToString());

            }
        }
    }
}
