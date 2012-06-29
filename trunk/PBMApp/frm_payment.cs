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
    public partial class frm_payment : Form
    {
        public frm_payment()
        {
            InitializeComponent();
        }
         
        private void frm_payment_Load(object sender, EventArgs e)
        {
            tbPrice.KeyPress += (Tools.Validate.KeyPress);
            tbPrice.KeyUp += (Tools.Validate.Price_KepUp);
            tbHALO.KeyPress += (Tools.Validate.KeyPress);
            using (var m = new Entities())
            {
                //payment
                var q = from c in m.WH_Sys_Payment
                        orderby c.isFlag ascending
                        select c;
                int i = 1;
                foreach (var w in q)
                {
                    TextBox tb1 = this.groupBox1.Controls["textBox" + i] as TextBox;
                    tb1.Text = w.Description;
                    TextBox tb2= this.groupBox1.Controls["textBoxd" + i] as TextBox;
                    tb2.Text = w.DescriptionBlod;
                    ComboBox cba = this.groupBox1.Controls["comboBoxa" + i] as ComboBox;
                    cba.SelectedIndex = int.Parse(w.ChargeReturn.ToString());
                    ComboBox cbb = this.groupBox1.Controls["comboBoxb" + i] as ComboBox;
                    cbb.SelectedIndex = int.Parse(w.DuplicateNo.ToString());
                    CheckBox ck = this.groupBox1.Controls["checkBox" + i] as CheckBox;
                    ck.Checked = int.Parse(w.isTips.ToString()) == 1;
                    i++;
                }
                //Refund
                var q1 = from c in m.WH_Sys_Refund
                         orderby c.isFlag ascending
                         select c;
                int i1 = 1;
                foreach (var w in q1)
                {
                    TextBox tb1 = this.groupBox2.Controls["textBoxa" + i1] as TextBox;
                    tb1.Text = w.Description;
                    TextBox tb2 = this.groupBox2.Controls["textBoxb" + i1] as TextBox;
                    tb2.Text = w.Price.ToString();
                    tb2.KeyPress+=new KeyPressEventHandler(Tools.Validate.KeyPress);
                    TextBox tb3 = this.groupBox2.Controls["textBoxc" + i1] as TextBox;
                    tb3.Text = w.HALO.ToString();
                    tb3.KeyPress += new KeyPressEventHandler(Tools.Validate.KeyPress);
                    tb3.MaxLength = 7;
                    i1++;
                }
                //coupon
                var q2 = m.WH_Sys_CouponInformation.First();
                tbPrice.Text = q2.price.ToString();
                tbHALO.Text = q2.HALO.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                //payment 
                for (int j = 1; j < 11; j++)
                {
                    TextBox tb1 = this.groupBox1.Controls["textBox" + j] as TextBox;
                    TextBox tb2 = this.groupBox1.Controls["textBoxd" + j] as TextBox;
                    ComboBox cbb = this.groupBox1.Controls["comboBoxb" + j] as ComboBox;
                    ComboBox cba = this.groupBox1.Controls["comboBoxa" + j] as ComboBox;
                    CheckBox ck = this.groupBox1.Controls["checkBox" + j] as CheckBox;

                    var w = m.WH_Sys_Payment.FirstOrDefault(x => x.ID == j);
                    w.Description = tb1.Text;
                    w.DescriptionBlod = tb2.Text;
                    w.ChargeReturn = cba.SelectedIndex;
                    w.ChargeReturn_Str = cba.SelectedText;
                    w.DuplicateNo = cbb.SelectedIndex;
                    w.isTips = ck.Checked ? 1 : 0; 
                } 
                //Refund
                for (int i = 1; i < 9; i++)
                {
                    TextBox tb1 = this.groupBox2.Controls["textBoxa" + i] as TextBox;
                    TextBox tb2 = this.groupBox2.Controls["textBoxb" + i] as TextBox;
                    TextBox tb3 = this.groupBox2.Controls["textBoxc" + i] as TextBox;
                    var p = m.WH_Sys_Refund.FirstOrDefault(x => x.ID == i);
                    p.Description = tb1.Text;
                    p.Price = decimal.Parse(tb2.Text);
                    p.HALO = decimal.Parse(tb3.Text);
                }
                 
                //coupon
                var q2 = m.WH_Sys_CouponInformation.First();
                q2.price= decimal.Parse(tbPrice.Text);
                q2.HALO = decimal.Parse(tbHALO.Text);
                m.SaveChanges();
                MessageBox.Show("success！", "alert");
            }
        }

        
        private void tbHALO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(((e.KeyChar >= '0') && (e.KeyChar <= '9')) || e.KeyChar <= 31))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar <= 31)
                {
                    e.Handled = false;
                }
                else if (((TextBox)sender).Text.Trim().IndexOf('.') > -1)
                {
                    if (
                        ((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >=
                        4)
                        e.Handled = true;
                }
            }
        }

        
    }
}
