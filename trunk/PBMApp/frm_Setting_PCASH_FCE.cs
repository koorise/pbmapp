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
    public partial class frm_Setting_PCASH_FCE : Form
    {
        public frm_Setting_PCASH_FCE()
        {
            InitializeComponent();
        }

        private void frm_Setting_PCASH_FCE_Load(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_PCASH
                        orderby c.ID ascending
                        select c;
                int i = 1;
                foreach (var w in q)
                {
                    TextBox tb1 = this.groupBox1.Controls["textBoxa" + i] as TextBox;
                    tb1.KeyPress += (Tools.Validate.KeyPress);
                    TextBox tb2 = this.groupBox1.Controls["textBoxb" + i] as TextBox;
                    ComboBox cb1 = this.groupBox1.Controls["comboBox" + i] as ComboBox;
                    tb1.Text = w.Rate.ToString();
                    tb2.Text = w.description;
                    Combox_ItemBind(int.Parse(w.LinkPaymentID.ToString()) - 1, cb1);
                    i++;
                }
                int j = 1;
                var qq = from c in m.WH_Sys_FCE
                         orderby c.ID ascending
                         select c;
                foreach (var w in qq)
                {
                    if (j <= 4)
                    {
                        TextBox tb1 = this.groupBox2.Controls["textBoxc" + j] as TextBox;
                        TextBox tb2 = this.groupBox2.Controls["textBoxd" + j] as TextBox;
                        TextBox tb3 = this.groupBox2.Controls["textBoxe" + j] as TextBox;
                        ComboBox cb1 = this.groupBox2.Controls["comboBoxa" + j] as ComboBox;
                        ComboBox cb2 = this.groupBox2.Controls["comboBoxb" + j] as ComboBox;
                        CheckBox ck = this.groupBox2.Controls["checkbox" + j] as CheckBox;
                        tb1.Text = w.Local.ToString();
                        tb2.Text = w.FC.ToString();
                        cb1.SelectedIndex = int.Parse(w.Decimals.ToString());
                        ComboxB_ItemBind(int.Parse(w.SymbolID.ToString()) - 1, cb2);
                        tb3.Text = w.Description.ToString();
                        ck.Checked = int.Parse(w.isFCE.ToString()) == 1;
                    }
                    else
                    {
                        break;
                    }
                    j++;
                }
                m.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                for (int i = 1; i < 11; i++)
                {
                    TextBox tb1 = this.groupBox1.Controls["textBoxa" + i] as TextBox;
                    TextBox tb2 = this.groupBox1.Controls["textBoxb" + i] as TextBox;
                    ComboBox cb1 = this.groupBox1.Controls["comboBox" + i] as ComboBox;

                    WH_Sys_PCASH w = m.WH_Sys_PCASH.FirstOrDefault(x => x.ID == i);
                    w.Rate = decimal.Parse(tb1.Text);
                    w.description = tb2.Text;
                    w.LinkPaymentID = cb1.SelectedIndex + 1;
                    w.LinkPaymentStr = cb1.SelectedText;
                }
                 
                m.SaveChanges();
                m.Dispose();
                MessageBox.Show("success！", "alert");
            }
            
             
        }

        private void Combox_ItemBind(int sid,ComboBox cb)
        {
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_Payment
                        orderby c.ID ascending
                        select c;
                foreach (var w in q)
                {
                   Tools.ComboBoxItem cc = new ComboBoxItem();
                    cc.Text = w.Description;
                    cc.Value = w.ID;
                    cb.Items.Add(cc);
                }
                cb.SelectedIndex = sid;
                m.Dispose();
            }
        }

        private void ComboxB_ItemBind(int sid, ComboBox cb)
        {
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_Symbols
                        orderby c.ID ascending
                        select c;
                foreach (var w in q)
                {
                    Tools.ComboBoxItem c = new ComboBoxItem();
                    c.Text = w.title;
                    c.Value = w.ID;
                    cb.Items.Add(c);
                }
                cb.SelectedIndex = sid;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            { 
                for (int j = 1; j < 5; j++)
                {
                    TextBox tb1 = this.groupBox2.Controls["textBoxc" + j] as TextBox;
                    TextBox tb2 = this.groupBox2.Controls["textBoxd" + j] as TextBox;
                    TextBox tb3 = this.groupBox2.Controls["textBoxe" + j] as TextBox;
                    ComboBox cb1 = this.groupBox2.Controls["comboBoxa" + j] as ComboBox;
                    ComboBox cb2 = this.groupBox2.Controls["comboBoxb" + j] as ComboBox;
                    CheckBox ck = this.groupBox2.Controls["checkbox" + j] as CheckBox;
                    WH_Sys_FCE w = m.WH_Sys_FCE.FirstOrDefault(x => x.ID == j);
                    w.Local = decimal.Parse(tb1.Text);
                    w.FC = int.Parse(tb2.Text);
                    w.Decimals = cb1.SelectedIndex;
                    w.SymbolID = cb2.SelectedIndex + 1;
                    w.SymbolStr = cb2.SelectedText;
                    w.Description = tb3.Text;
                    w.isFCE = ck.Checked ? 1 : 0;
                }
                m.SaveChanges();
                m.Dispose();
                MessageBox.Show("success！", "alert");
            }
        }
    }
}
