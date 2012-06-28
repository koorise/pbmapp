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
                wp.ReportExportDevice = comboBox1c.SelectedText;
                wp.ReportExportDevice_index = comboBox1c.SelectedIndex;
                wp.ClerkPassCodeDigits = comboBox2c.SelectedText;
                wp.ClerkPassCodeDigits_index = comboBox2c.SelectedIndex;
                wp.OtherRoundingFactor = comboBox3c.SelectedText;
                wp.OtherRoundingFactor_index = comboBox3c.SelectedIndex;
                wp.TaxSystem = comboBox4c.SelectedText;
                wp.TaxSystem_index = comboBox4c.SelectedIndex;
                wp.AgeOne = int.Parse(textBox1c.Text);
                wp.AgeTwo = int.Parse(textBox2c.Text);
                wp.MachinNumPreset = textBox3c.Text;
                wp.ReceiptNumPreset = textBox4c.Text;
                wp.DailyZCounterPreset = int.Parse(textBox5c.Text);
                wp.PTDZCounterPreset = int.Parse(textBox6c.Text);
                wp.DuplicateReceiptCounter = textBox7c.Text;
                wp.LineFeedCount = textBox8c.Text;
                wp.PaymentInfoDisplayTime = int.Parse(textBox9c.Text);
                wp.ChangeInfoDisplayTime = int.Parse(textBox10c.Text);
                wp.TableColorChangeTime = int.Parse(textBox11c.Text);
                wp.TakeOutPrintTickets = int.Parse(textBox12c.Text);
                wp.MaxTipsAmount = int.Parse(textBox13c.Text);
                wp.TrainingModePassCode = int.Parse(textBox14c.Text);
                wp.HALO = decimal.Parse(textBox15c.Text);
                wp.TotalInDrawerLimit = decimal.Parse(textBox16c.Text);
                wp.VATNum = int.Parse(textBox17c.Text);
                m.AddToWH_Sys_PageFour(wp);
                m.SaveChanges();
            }
        }

        private void frm_Setting_PageFour_Load(object sender, EventArgs e)
        {
            textBox5c.KeyPress += (Tools.Validate.KeyPress);
            textBox6c.KeyPress += (Tools.Validate.KeyPress);
            textBox7c.KeyPress += (Tools.Validate.KeyPress);
            textBox8c.KeyPress += (Tools.Validate.KeyPress);
            textBox9c.KeyPress += (Tools.Validate.KeyPress);
            textBox10c.KeyPress += (Tools.Validate.KeyPress);
            textBox11c.KeyPress += (Tools.Validate.KeyPress);
            textBox12c.KeyPress += (Tools.Validate.KeyPress);
            textBox13c.KeyPress += (Tools.Validate.KeyPress);
            textBox14c.KeyPress += (Tools.Validate.KeyPress);
            textBox15c.KeyPress += (Tools.Validate.KeyPress);
            textBox16c.KeyPress += (Tools.Validate.KeyPress);
            using (var m = new Entities())
            {
                var q = (from c in m.WH_Sys_PageFour
                        orderby c.ID descending
                        select c).FirstOrDefault();
                comboBox1c.SelectedIndex = int.Parse(q.ReportExportDevice_index.ToString());
                comboBox2c.SelectedIndex = int.Parse(q.ClerkPassCodeDigits_index.ToString());
                comboBox3c.SelectedIndex = int.Parse(q.OtherRoundingFactor_index.ToString());
                comboBox4c.SelectedIndex = int.Parse(q.TaxSystem_index.ToString());
                textBox1c.Text = q.AgeOne.ToString();
                textBox2c.Text = q.AgeTwo.ToString();
                textBox3c.Text = q.MachinNumPreset.ToString();
                textBox4c.Text = q.ReceiptNumPreset.ToString();
                textBox5c.Text = q.DailyZCounterPreset.ToString();
                textBox6c.Text = q.PTDZCounterPreset.ToString();
                textBox7c.Text = q.DuplicateReceiptCounter.ToString();
                textBox8c.Text = q.LineFeedCount.ToString();
                textBox9c.Text = q.PaymentInfoDisplayTime.ToString();
                textBox10c.Text = q.ChangeInfoDisplayTime.ToString();
                textBox11c.Text = q.TableColorChangeTime.ToString();
                textBox12c.Text = q.TakeOutPrintTickets.ToString();
                textBox13c.Text = q.MaxTipsAmount.ToString();
                textBox14c.Text = q.TrainingModePassCode.ToString();
                textBox15c.Text = q.HALO.ToString();
                textBox16c.Text = q.TotalInDrawerLimit.ToString();
                textBox17c.Text = q.VATNum.ToString();

            }
        }
    }
}
