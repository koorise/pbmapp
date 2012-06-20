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
    public partial class frm_Setting_ElectronicScale : Form
    {
        public frm_Setting_ElectronicScale()
        {
            InitializeComponent();
        }
         
        private void frm_Setting_ElectronicScale_Load(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                #region 部门绑定
                var q = from c in m.WH_Department
                        orderby c.ID ascending 
                        select new
                                   {
                                       c.ID,
                                       c.Description
                                   };
                foreach (var qq in q)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = qq.Description;
                    cb.Value = qq.ID;
                    cbDept1.Items.Add(cb);
                    cbDept2.Items.Add(cb);
                    cbDept3.Items.Add(cb);
                    cbDept4.Items.Add(cb);
                    cbDept5.Items.Add(cb);
                }
                var t = from c in m.WH_Sys_ElectronicScale
                        orderby c.ID ascending 
                        select c;
                foreach (var tt in t)
                {
                    switch (int.Parse(tt.ID.ToString()))
                    {
                        case 1:
                            cbDept1.SelectedIndex = int.Parse(tt.ScaleDeptID.ToString()) - 1;
                            break;
                        case 2:
                            cbDept2.SelectedIndex = int.Parse(tt.ScaleDeptID.ToString()) - 1;
                            break;
                        case 3:
                            cbDept3.SelectedIndex = int.Parse(tt.ScaleDeptID.ToString()) - 1;
                            break;
                        case 4:
                            cbDept4.SelectedIndex = int.Parse(tt.ScaleDeptID.ToString()) - 1;
                            break;
                        case 5:
                            cbDept5.SelectedIndex = int.Parse(tt.ScaleDeptID.ToString()) - 1;
                            break;
                    }
                }
                #endregion 

                //cbTare_Bind();

                var o = from c in m.WH_Sys_WeightingPLU
                        orderby c.ID ascending
                        select c;
                foreach (var oo in o)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = oo.WID.ToString();
                    cb.Value = oo.WID.ToString();
                    cbID.Items.Add(cb);
                }
            }
        }

        private void Bind_cbID()
        {
            using (var m = new Entities())
            {
                
            }
        }
        private void cbTare_Bind()
        {
            cbTare.Items.Clear();
            tbTare.Text = "";
            using (var m = new Entities())
            {  
                string unit = "lb";
                if (cbUnit.SelectedIndex == 1)
                {
                    unit = "oz";
                }
                var r = from c in m.WH_Sys_ElectronicScale_Tare
                        where c.awID ==  cbUnit.SelectedIndex 
                        select c;
                foreach (var rr in r)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = rr.tare + unit;
                    cb.Value = rr.ID;
                    cbTare.Items.Add(cb);
                }
            }
        }
        private void cbTare_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem cb = (ComboBoxItem) cbTare.SelectedItem;
            int TareID = int.Parse(cb.Value.ToString());
            using (var m = new Entities())
            {
                var q = (from c in m.WH_Sys_ElectronicScale_Tare
                        where c.ID == TareID
                        select c).FirstOrDefault();
                tbTare.Text = q.tare.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ComboBoxItem cb = (ComboBoxItem)cbTare.SelectedItem;
            int TareID = int.Parse(cb.Value.ToString());
            using (var m = new Entities())
            {
                var q = (from c in m.WH_Sys_ElectronicScale_Tare
                         where c.ID == TareID
                         select c).FirstOrDefault();
                q.tare = decimal.Parse(tbTare.Text);
                m.SaveChanges();
            }
            cbTare_Bind();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                for (int i = 1; i < 6; i++)
                {
                    ComboBox cb = this.groupBox1.Controls["cbDept" + i] as ComboBox;
                    var q = m.WH_Sys_ElectronicScale.FirstOrDefault(x => x.ID == i);
                    q.ScaleDeptID = int.Parse(((ComboBoxItem) cb.SelectedItem).Value.ToString());
                }
                var r =   m.WH_Sys_ElectronicScale_Setting.FirstOrDefault() ;
                r.Unit = cbUnit.SelectedIndex + 1;
                r.TareType = cbUnit.SelectedIndex + 1;
                m.SaveChanges();
            }
        }

        private void cbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string WID = ((ComboBoxItem) cbID.SelectedItem).Value.ToString();
            using (var m = new Entities())
            {
                var q = m.WH_Sys_WeightingPLU.FirstOrDefault(x => x.WID == WID);
                
                chkWA.Checked = int.Parse(q.TypeID.ToString()) == 1;
                tbBarcode.Text = q.BarCodeLength.ToString();
                cbWA.SelectedIndex = int.Parse(q.WAID.ToString());
                cbDots.SelectedIndex = int.Parse(q.Dots.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string WID = ((ComboBoxItem)cbID.SelectedItem).Value.ToString();
            using (var m = new Entities())
            {
                var q = m.WH_Sys_WeightingPLU.FirstOrDefault(x => x.WID == WID);
                q.TypeID = chkWA.Checked ? 1 : 0;
                q.BarCodeLength = int.Parse(tbBarcode.Text);
                q.WAID = cbWA.SelectedIndex;
                q.Dots = cbDots.SelectedIndex;
                m.SaveChanges();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using(var m = new Entities())
            {
                for (int i = 1; i < 6; i++)
                {
                    WH_Sys_ElectronicScale w = new WH_Sys_ElectronicScale();
                    w.ScaleDeptID = i;
                    m.AddToWH_Sys_ElectronicScale(w);
                }
                for (int i = 1; i < 11; i++)
                {
                    WH_Sys_ElectronicScale_Tare w = new WH_Sys_ElectronicScale_Tare();
                    w.awID = 1;
                    w.tare = 0;
                    m.AddToWH_Sys_ElectronicScale_Tare(w);
                    WH_Sys_ElectronicScale_Tare z = new WH_Sys_ElectronicScale_Tare();
                    z.awID = 0;
                    z.tare = 0;
                    m.AddToWH_Sys_ElectronicScale_Tare(z);
                }
                for (int i = 20; i < 31; i++)
                {
                    WH_Sys_WeightingPLU w = new WH_Sys_WeightingPLU();
                    w.WID = i.ToString();
                    w.TypeID = chkWA.Checked ? 1 : 0;
                    w.BarCodeLength = 5;
                    w.WAID = cbWA.SelectedIndex;
                    w.Dots = cbWA.SelectedIndex;
                    m.AddToWH_Sys_WeightingPLU(w);
                }
                m.SaveChanges();
            }
        }

        private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTare_Bind();
        }

        private void cbWA_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void chkWA_CheckedChanged(object sender, EventArgs e)
        {
            if(chkWA.Checked)
            {
                tbBarcode.Enabled = false;
                cbWA.Enabled = false;
                cbDots.Enabled = false;
            }
            else
            {
                tbBarcode.Enabled = true;
                cbWA.Enabled = true;
                cbDots.Enabled = true;
            }
        }
    }
}
