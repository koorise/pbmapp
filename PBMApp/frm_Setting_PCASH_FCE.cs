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
                    TextBox tb2 = this.groupBox1.Controls["textBoxb" + i] as TextBox;
                    ComboBox cb1 = this.groupBox1.Controls["comboBox" + i] as ComboBox;
                    tb1.Text = w.Rate.ToString();
                    tb2.Text = w.description;
                    cb1.SelectedIndex = int.Parse(w.LinkPaymentID.ToString()) - 1;
                    i++;
                }
                int j = 1;
                var qq = from c in m.WH_Sys_FCE
                         orderby c.ID ascending
                         select c;
                foreach (var w in qq)
                {
                    TextBox tb1 = this.groupBox2.Controls["textBoxc" + j] as TextBox;
                    TextBox tb2 = this.groupBox2.Controls["textBoxd" + j] as TextBox;
                    TextBox tb3 = this.groupBox2.Controls["textBoxe" + j] as TextBox;
                    ComboBox cb1 = this.groupBox2.Controls["comboBoxa" + j] as ComboBox;
                    ComboBox cb2 = this.groupBox2.Controls["comboBoxb" + j] as ComboBox;
                    tb1.Text = w.Local.ToString();
                    tb2.Text = w.FC.ToString();
                    cb1.SelectedIndex = int.Parse(w.Decimals.ToString());
                    cb2.SelectedIndex = int.Parse(w.SymbolID.ToString()) - 1;
                    tb3.Text = w.Description.ToString();
                    j++;
                }
            }
        }
    }
}
