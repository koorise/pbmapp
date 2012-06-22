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
    public partial class frm_Setting_PageFour : Form
    {
        public frm_Setting_PageFour()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                WH_Sys_PageFour wp = new WH_Sys_PageFour();
                wp.ReportExportDevice = comboBox1.SelectedText;
                wp.ReportExportDevice_index = comboBox1.SelectedIndex;
                wp.ClerkPassCodeDigits = comboBox2.SelectedText;
                wp.ClerkPassCodeDigits_index = comboBox2.SelectedIndex;
                wp.OtherRoundingFactor = comboBox3.SelectedText;
                wp.OtherRoundingFactor_index = comboBox3.SelectedIndex;
                wp.TaxSystem = comboBox4.SelectedText;
                wp.TaxSystem_index = comboBox4.SelectedIndex;
                wp.AgeOne = int.Parse(textBox1.Text);
                wp.AgeTwo = int.Parse(textBox2.Text);
                wp.MachinNumPreset = textBox3.Text;
                wp.ReceiptNumPreset = textBox4.Text;
                wp.DailyZCounterPreset = int.Parse(textBox5.Text);
                wp.PTDZCounterPreset = int.Parse(textBox6.Text);
                wp.DuplicateReceiptCounter = textBox7.Text;
                wp.LineFeedCount = textBox8.Text;
                wp.PaymentInfoDisplayTime = int.Parse(textBox9.Text);
                wp.ChangeInfoDisplayTime = int.Parse(textBox10.Text);
                wp.TableColorChangeTime = int.Parse(textBox11.Text);
                wp.TakeOutPrintTickets = int.Parse(textBox12.Text);
                wp.MaxTipsAmount = int.Parse(textBox13.Text);
                wp.TrainingModePassCode = int.Parse(textBox14.Text);
                wp.HALO = decimal.Parse(textBox15.Text);
                wp.TotalInDrawerLimit = decimal.Parse(textBox16.Text);
                wp.VATNum = int.Parse(textBox17.Text);
                m.AddToWH_Sys_PageFour(wp);
                m.SaveChanges();
            }
        }

        private void frm_Setting_PageFour_Load(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = (from c in m.WH_Sys_PageFour
                        orderby c.ID descending
                        select c).FirstOrDefault();
                comboBox1.SelectedIndex = int.Parse(q.ReportExportDevice_index.ToString());
                comboBox2.SelectedIndex = int.Parse(q.ClerkPassCodeDigits_index.ToString());
                comboBox3.SelectedIndex = int.Parse(q.OtherRoundingFactor_index.ToString());
                comboBox4.SelectedIndex = int.Parse(q.TaxSystem_index.ToString());
                textBox1.Text = q.AgeOne.ToString();
                textBox2.Text = q.AgeTwo.ToString();
                textBox3.Text = q.MachinNumPreset.ToString();
                textBox4.Text = q.ReceiptNumPreset.ToString();
                textBox5.Text = q.DailyZCounterPreset.ToString();
                textBox6.Text = q.PTDZCounterPreset.ToString();
                textBox7.Text = q.DuplicateReceiptCounter.ToString();
                textBox8.Text = q.LineFeedCount.ToString();
                textBox9.Text = q.PaymentInfoDisplayTime.ToString();
                textBox10.Text = q.ChangeInfoDisplayTime.ToString();
                textBox11.Text = q.TableColorChangeTime.ToString();
                textBox12.Text = q.TakeOutPrintTickets.ToString();
                textBox13.Text = q.MaxTipsAmount.ToString();
                textBox14.Text = q.TrainingModePassCode.ToString();
                textBox15.Text = q.HALO.ToString();
                textBox16.Text = q.TotalInDrawerLimit.ToString();
                textBox17.Text = q.VATNum.ToString();

            }
        }
    }
}
