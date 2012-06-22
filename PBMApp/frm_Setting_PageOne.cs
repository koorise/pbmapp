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
    public partial class frm_Setting_PageOne : Form
    {
        public frm_Setting_PageOne()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                WH_Sys_PageOne wp = new WH_Sys_PageOne();
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
                m.AddToWH_Sys_PageOne(wp);
                m.SaveChanges();
            }
        }

        private void frm_Setting_PageOne_Load(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = (from c in m.WH_Sys_PageOne
                         orderby c.ID descending
                         select c).FirstOrDefault();
                string limit = q.Authority.ToString();
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
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
            }
        }
    }
}
