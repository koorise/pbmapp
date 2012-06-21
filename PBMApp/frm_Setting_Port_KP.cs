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
    public partial class frm_Setting_Port_KP : Form
    {
        public frm_Setting_Port_KP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            { 
                for (int i = 1; i <= 5;i++ )
                {
                    var qq = m.WH_Sys_Port.FirstOrDefault(x=>x.ID==i);
                    ComboBox cb = this.groupBox1.Controls["a" + i] as ComboBox; 
                    qq.PortIndex = cb.SelectedIndex;
                    qq.Port = cb.SelectedText;
                    ComboBox cbb = this.groupBox1.Controls["b" + i] as ComboBox; 
                    qq.BaudIndex = cbb.SelectedIndex;
                    qq.BaudRate = cbb.SelectedText;
                    m.SaveChanges();
                }
                var q = m.WH_Sys_RP.FirstOrDefault();
                q.DeviceIndex = cbRP.SelectedIndex;
                q.Device = cbRP.SelectedText;
                m.SaveChanges();
                if (cbKP.SelectedIndex != -1)
                {
                    int kpID = cbKP.SelectedIndex + 1;
                    var p = m.WH_Sys_KP.FirstOrDefault(x => x.ID == kpID);
                    p.TypeIndex = cbKPType.SelectedIndex;
                    p.TypeStr = cbKPType.SelectedText;
                    p.HeadFeed = int.Parse(tbHead.Text);
                    p.FootFeed = int.Parse(tbFoot.Text);
                    p.isCutPaper = chkCutPaper.Checked ? 1 : 0;
                    p.IP_Addr = tbIP.Text;
                    p.Port = int.Parse(tbPort.Text);
                    m.SaveChanges();
                }
                MessageBox.Show("success", "alert");
            } 
        }

        private void frm_Setting_Port_KP_Load(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_Port
                        orderby c.ID ascending
                        select c;
                int i = 1;
                foreach (var qq in q)
                {
                    ComboBox cb = this.groupBox1.Controls["a" + i] as ComboBox;
                    cb.SelectedIndex = int.Parse(qq.PortIndex.ToString());
                    ComboBox cbb = this.groupBox1.Controls["b" + i] as ComboBox;
                    cbb.SelectedIndex = int.Parse(qq.BaudIndex.ToString());
                    i++;
                }

                var o = m.WH_Sys_RP.FirstOrDefault();
                cbRP.SelectedIndex = int.Parse(o.DeviceIndex.ToString());

                for (int j = 1; j < 14; j++)
                {
                    ComboBoxItem combo = new ComboBoxItem();
                    combo.Text = "KP" + j;
                    combo.Value = j;
                    cbKP.Items.Add(combo);
                }
                
            }
        }

        private void cbKP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int kpID = cbKP.SelectedIndex + 1;
            using (var m = new Entities() )
            {
                var q = m.WH_Sys_KP.FirstOrDefault(x => x.ID == kpID);
                cbKPType.SelectedIndex = int.Parse(q.TypeIndex.ToString());
                tbHead.Text = q.HeadFeed.ToString();
                tbFoot.Text = q.FootFeed.ToString();
                chkCutPaper.Checked = int.Parse(q.isCutPaper.ToString()) == 1;
                tbIP.Text = q.IP_Addr.ToString();
                tbPort.Text = q.Port.ToString(); 
                if(kpID>=6)
                {
                    tbIP.Enabled = true;
                    tbPort.Enabled = true;
                }
                else
                {
                    tbIP.Enabled = false;
                    tbPort.Enabled = false;
                }
            }
        }
    }
}
