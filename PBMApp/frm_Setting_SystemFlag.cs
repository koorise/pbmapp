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
    public partial class frm_Setting_SystemFlag : Form
    {
        public frm_Setting_SystemFlag()
        {
            InitializeComponent();
        }

        private void frm_Setting_SystemFlag_Load(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                #region Page 1
                
                
                //page 1
                var pageOne = (from c in m.WH_Sys_PageOne
                         orderby c.ID descending
                         select c).FirstOrDefault();
                string s = pageOne.Authority.ToString();
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (s.Substring(i, 1) == "1")
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
                #endregion

                #region Page 2
                
                
                //page 2
                var pageTwo = (from c in m.WH_Sys_PageTwo
                         orderby c.ID descending
                         select c).FirstOrDefault();
                string authority = pageTwo.Authority;
                for (int i = 0; i < authority.Length; i++)
                {
                    if (authority.Substring(i, 1) == "1")
                    {
                        checkedListBox2.SetItemChecked(i, true);
                    }
                    else
                    {
                        checkedListBox2.SetItemChecked(i, false);
                    }
                }
                comboBox1a.SelectedIndex = int.Parse(pageTwo.PositionOfReceipt_index.ToString());
                comboBox2a.SelectedIndex = int.Parse(pageTwo.PositionOfLogo_index.ToString());
                comboBox3a.SelectedIndex = int.Parse(pageTwo.PrintItemsWhenCloseTable_index.ToString());
                comboBox4a.SelectedIndex = int.Parse(pageTwo.ItemDesc_RP_index.ToString());
                #endregion

                #region Page 3
                
                
                //page 3
                var pageTree = (from c in m.WH_Sys_PageTree
                         orderby c.ID descending
                         select c).FirstOrDefault();
                string authority1 = pageTree.Authority;
                for (int i = 0; i < authority1.Length; i++)
                {
                    if (authority1.Substring(i, 1) == "1")
                    {
                        checkedListBox3.SetItemChecked(i, true);
                    }
                    else
                    {
                        checkedListBox3.SetItemChecked(i, false);
                    }
                }
                comboBox1b.SelectedIndex = int.Parse(pageTree.FootStampRule_index.ToString());
                comboBox2b.SelectedIndex = int.Parse(pageTree.GiftVoucherChange_index.ToString());
                comboBox3b.SelectedIndex = int.Parse(pageTree.VATRateForTakeAway_index.ToString());
                comboBox4b.SelectedIndex = int.Parse(pageTree.VATRateForInHouse_index.ToString());
                comboBox5b.SelectedIndex = int.Parse(pageTree.VATRateForOutHouse_index.ToString());
                comboBox6b.SelectedIndex = int.Parse(pageTree.PLUPriceForTakeAway_index.ToString());
                comboBox7b.SelectedIndex = int.Parse(pageTree.KPPrintSetting_index.ToString());
                comboBox8b.SelectedIndex = int.Parse(pageTree.CompReport_index.ToString());
                #endregion

                #region Page 4
                
               
                //page 4
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

                var pageFour = (from c in m.WH_Sys_PageFour
                         orderby c.ID descending
                         select c).FirstOrDefault();
                comboBox1c.SelectedIndex = int.Parse(pageFour.ReportExportDevice_index.ToString());
                comboBox2c.SelectedIndex = int.Parse(pageFour.ClerkPassCodeDigits_index.ToString());
                comboBox3c.SelectedIndex = int.Parse(pageFour.OtherRoundingFactor_index.ToString());
                comboBox4c.SelectedIndex = int.Parse(pageFour.TaxSystem_index.ToString());
                textBox1c.Text = pageFour.AgeOne.ToString();
                textBox2c.Text = pageFour.AgeTwo.ToString();
                textBox3c.Text = pageFour.MachinNumPreset.ToString();
                textBox4c.Text = pageFour.ReceiptNumPreset.ToString();
                textBox5c.Text = pageFour.DailyZCounterPreset.ToString();
                textBox6c.Text = pageFour.PTDZCounterPreset.ToString();
                textBox7c.Text = pageFour.DuplicateReceiptCounter.ToString();
                textBox8c.Text = pageFour.LineFeedCount.ToString();
                textBox9c.Text = pageFour.PaymentInfoDisplayTime.ToString();
                textBox10c.Text = pageFour.ChangeInfoDisplayTime.ToString();
                textBox11c.Text = pageFour.TableColorChangeTime.ToString();
                textBox12c.Text = pageFour.TakeOutPrintTickets.ToString();
                textBox13c.Text = pageFour.MaxTipsAmount.ToString();
                textBox14c.Text = pageFour.TrainingModePassCode.ToString();
                textBox15c.Text = pageFour.HALO.ToString();
                textBox16c.Text = pageFour.TotalInDrawerLimit.ToString();
                textBox17c.Text = pageFour.VATNum.ToString();
                #endregion

                #region Page 5
                 
                //page 5
                List<Dog> dogs = new List<Dog>();
                var hourServiceTaxHourses = from c in m.WH_Sys_happyHour_ServiceTax_Hours
                        orderby c.ID ascending
                        select c;
                
                foreach (var w in hourServiceTaxHourses)
                {
                    Dog d1 = new Dog();
                    d1.head = int.Parse(w.timeA.Split(':')[0]);
                    d1.body = int.Parse(w.timeA.Split(':')[1]);
                    d1.foot = int.Parse(w.timeA.Split(':')[2]);

                    Dog d2 = new Dog();
                    d2.head = int.Parse(w.timeB.Split(':')[0]);
                    d2.body = int.Parse(w.timeB.Split(':')[1]);
                    d2.foot = int.Parse(w.timeB.Split(':')[2]);

                    Dog d3 = new Dog();
                    d3.head = int.Parse(w.timeC.Split(':')[0]);
                    d3.body = int.Parse(w.timeC.Split(':')[1]);
                    d3.foot = int.Parse(w.timeC.Split(':')[2]);

                    Dog d4 = new Dog();
                    d4.head = int.Parse(w.timeD.Split(':')[0]);
                    d4.body = int.Parse(w.timeD.Split(':')[1]);
                    d4.foot = int.Parse(w.timeD.Split(':')[2]);

                    dogs.Add(d1);
                    dogs.Add(d2);
                    dogs.Add(d3);
                    dogs.Add(d4);
                    if(w.isHappyOrTax.ToString()=="0")
                    {
                        string authoritys = w.Weeks;
                        for (int i = 0; i < authoritys.Length; i++)
                        {
                            if (authoritys.Substring(i, 1) == "1")
                            {
                                checkedListBox5.SetItemChecked(i, true);
                            }
                            else
                            {
                                checkedListBox5.SetItemChecked(i, false);
                            }
                        }
                    }
                    else
                    {
                        string authoritys = w.Weeks;
                        for (int i = 0; i < authoritys.Length; i++)
                        {
                            if (authoritys.Substring(i, 1) == "1")
                            {
                                checkedListBox4.SetItemChecked(i, true);
                            }
                            else
                            {
                                checkedListBox4.SetItemChecked(i, false);
                            }
                        }
                        
                    }
                    
                }
                Bind_Combobox(dogs);

                var serviceTax = m.WH_Sys_ServiceTax.FirstOrDefault();
                tbName.Text = serviceTax.Name.ToString();
                cbType.SelectedIndex = int.Parse(serviceTax.Type.ToString());
                tbRate.Text = serviceTax.RateAmount.ToString();
                #endregion

                #region page 6
                
                //page 6
                #region 部门绑定
                var qqs = from c in m.WH_Department
                        orderby c.ID ascending
                        select new
                        {
                            c.ID,
                            c.Description
                        };
                foreach (var qq in qqs)
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
                var electronicScales = from c in m.WH_Sys_ElectronicScale
                        orderby c.ID ascending
                        select c;
                foreach (var tt in electronicScales)
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

                var weightingPlus = from c in m.WH_Sys_WeightingPLU
                        orderby c.ID ascending
                        select c;
                int count = 0;
                foreach (var oo in weightingPlus)
                {
                    count++;
                    TextBox t = this.groupBox3.Controls["t" + count] as TextBox;
                    CheckBox u = this.groupBox3.Controls["u" + count] as CheckBox;
                    TextBox v = this.groupBox3.Controls["v" + count] as TextBox;
                    ComboBox w = this.groupBox3.Controls["w" + count] as ComboBox;
                    ComboBox x = this.groupBox3.Controls["x" + count] as ComboBox;
                    t.Text = oo.WID.ToString();

                    u.CheckedChanged += (Weighing_CheckedChanged);
                    v.KeyPress += (Tools.Validate.KeyPressNum);
                    v.MaxLength = 1;
                    w.SelectedIndexChanged += (w_SelectedIndexChanged);

                    
                    u.Checked = int.Parse(oo.TypeID.ToString()) == 1;
                    if (u.Checked)
                    {
                        v.Enabled = true;
                        w.Enabled = true; 
                    }
                    else
                    { 
                        v.Enabled = false;
                        w.Enabled = false;
                        x.Enabled = false;
                    }
                    if(count<=10)
                    {
                        t.ReadOnly = true;
                    }
                    v.Text = oo.BarCodeLength.ToString();
                    w.SelectedIndex = int.Parse(oo.WAID.ToString());
                    x.SelectedIndex = int.Parse(oo.Dots.ToString());
                   
                }
                t11.KeyPress += (Tools.Validate.KeyPressNum);
                cbUnit.SelectedIndex = 0;
                #endregion

                #region Page 7
                
                
                //page 7
                textBox1d.KeyPress += (Tools.Validate.KeyPress);
                textBox2d.KeyPress += (Tools.Validate.KeyPress);

                var tableBarcode = m.WH_Sys_TableBarcode.FirstOrDefault();
                comboBox1d.SelectedIndex = int.Parse(tableBarcode.OperateType_index.ToString());
                comboBox2d.SelectedIndex = int.Parse(tableBarcode.Position_index.ToString());
                textBox1d.Text = tableBarcode.widths.ToString();
                textBox2d.Text = tableBarcode.heights.ToString();
                comboBox4d.SelectedIndex = int.Parse(tableBarcode.HRI_index.ToString());
                comboBox5d.SelectedIndex = int.Parse(tableBarcode.Fonts_index.ToString());
                checkBox1d.Checked = int.Parse(tableBarcode.PrintList.ToString()) == 1;
                checkBox2d.Checked = int.Parse(tableBarcode.suspendTable.ToString()) == 1;
                checkBox3d.Checked = int.Parse(tableBarcode.TransferTable.ToString()) == 1;

                var mailer = m.WH_Sys_mailer.FirstOrDefault();
                textBox3d.Text = mailer.MailerName.ToString();
                textBox4d.Text = mailer.MailerCode.ToString();
                textBox5d.Text = mailer.TenantCode.ToString();

                var ftp = m.WH_Sys_Ftp.FirstOrDefault();
                textBox6d.Text = ftp.IP.ToString();
                textBox7d.Text = ftp.UserName.ToString();
                textBox8d.Text = ftp.PassWord.ToString();
                #endregion
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                #region Page 1
                //page 1
                WH_Sys_PageOne pageOne = new WH_Sys_PageOne();
                string authority = "";
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        authority += "1";
                    }
                    else
                    {
                        authority += "0";
                    }
                }
                pageOne.Authority = authority;
                m.AddToWH_Sys_PageOne(pageOne); 
                #endregion

                #region Page 2 
                // page 2
                WH_Sys_PageTwo pageTwo = new WH_Sys_PageTwo();
                string empty = "";
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    if (checkedListBox2.GetItemChecked(i))
                    {
                        empty += "1";
                    }
                    else
                    {
                        empty += "0";
                    }
                }
                pageTwo.Authority = empty;
                pageTwo.PositionOfReceipt_index = comboBox1a.SelectedIndex;
                pageTwo.PositionOfReceipt = comboBox1a.SelectedText;
                pageTwo.PositionOfLogo_index = comboBox2a.SelectedIndex;
                pageTwo.PositionOfLogo = comboBox2a.SelectedText;
                pageTwo.PrintItemsWhenCloseTable_index = comboBox3a.SelectedIndex;
                pageTwo.PrintItemsWhenCloseTable = comboBox3a.SelectedText;
                pageTwo.ItemDesc_RP_index = comboBox4a.SelectedIndex;
                pageTwo.ItemDesc_RP = comboBox4a.SelectedText;
                m.AddToWH_Sys_PageTwo(pageTwo);
                #endregion

                #region Page 3
                WH_Sys_PageTree pageTree = new WH_Sys_PageTree();
                string s = "";
                for (int i = 0; i < checkedListBox3.Items.Count; i++)
                {
                    if (checkedListBox3.GetItemChecked(i))
                    {
                        s += "1";
                    }
                    else
                    {
                        s += "0";
                    }
                }
                pageTree.Authority = s;
                pageTree.FootStampRule = comboBox1b.SelectedText;
                pageTree.FootStampRule_index = comboBox1b.SelectedIndex;
                pageTree.GiftVoucherChange = comboBox2b.SelectedText;
                pageTree.GiftVoucherChange_index = comboBox2b.SelectedIndex;
                pageTree.VATRateForTakeAway = comboBox3b.SelectedText;
                pageTree.VATRateForTakeAway_index = comboBox3b.SelectedIndex;
                pageTree.VATRateForInHouse = comboBox4b.SelectedText;
                pageTree.VATRateForInHouse_index = comboBox4b.SelectedIndex;
                pageTree.VATRateForOutHouse = comboBox5b.SelectedText;
                pageTree.VATRateForOutHouse_index = comboBox5b.SelectedIndex;
                pageTree.PLUPriceForTakeAway = comboBox6b.SelectedText;
                pageTree.PLUPriceForTakeAway_index = comboBox6b.SelectedIndex;
                pageTree.KPPrintSetting = comboBox7b.SelectedText;
                pageTree.KPPrintSetting_index = comboBox7b.SelectedIndex;
                pageTree.CompReport = comboBox8b.SelectedText;
                pageTree.CompReport_index = comboBox8b.SelectedIndex;
                m.AddToWH_Sys_PageTree(pageTree);
                #endregion

                #region Page 4
                //page 4
                WH_Sys_PageFour pageFour = new WH_Sys_PageFour();
                pageFour.ReportExportDevice = comboBox1c.SelectedText;
                pageFour.ReportExportDevice_index = comboBox1c.SelectedIndex;
                pageFour.ClerkPassCodeDigits = comboBox2c.SelectedText;
                pageFour.ClerkPassCodeDigits_index = comboBox2c.SelectedIndex;
                pageFour.OtherRoundingFactor = comboBox3c.SelectedText;
                pageFour.OtherRoundingFactor_index = comboBox3c.SelectedIndex;
                pageFour.TaxSystem = comboBox4c.SelectedText;
                pageFour.TaxSystem_index = comboBox4c.SelectedIndex;
                pageFour.AgeOne = int.Parse(textBox1c.Text);
                pageFour.AgeTwo = int.Parse(textBox2c.Text);
                pageFour.MachinNumPreset = textBox3c.Text;
                pageFour.ReceiptNumPreset = textBox4c.Text;
                pageFour.DailyZCounterPreset = int.Parse(textBox5c.Text);
                pageFour.PTDZCounterPreset = int.Parse(textBox6c.Text);
                pageFour.DuplicateReceiptCounter = textBox7c.Text;
                pageFour.LineFeedCount = textBox8c.Text;
                pageFour.PaymentInfoDisplayTime = int.Parse(textBox9c.Text);
                pageFour.ChangeInfoDisplayTime = int.Parse(textBox10c.Text);
                pageFour.TableColorChangeTime = int.Parse(textBox11c.Text);
                pageFour.TakeOutPrintTickets = int.Parse(textBox12c.Text);
                pageFour.MaxTipsAmount = int.Parse(textBox13c.Text);
                pageFour.TrainingModePassCode = int.Parse(textBox14c.Text);
                pageFour.HALO = decimal.Parse(textBox15c.Text);
                pageFour.TotalInDrawerLimit = decimal.Parse(textBox16c.Text);
                pageFour.VATNum = int.Parse(textBox17c.Text);
                m.AddToWH_Sys_PageFour(pageFour);
                #endregion

                #region Page 5
                //page 5
                WH_Sys_happyHour_ServiceTax_Hours hours = m.WH_Sys_happyHour_ServiceTax_Hours.FirstOrDefault(x => x.isHappyOrTax == 0);
                //WH_Sys_happyHour_ServiceTax_Hours q = new WH_Sys_happyHour_ServiceTax_Hours();
                hours.timeA = a1.SelectedIndex + ":" + b1.SelectedIndex + ":" + c1.SelectedIndex;
                hours.timeB = a2.SelectedIndex + ":" + b2.SelectedIndex + ":" + c2.SelectedIndex;
                hours.timeC = a3.SelectedIndex + ":" + b3.SelectedIndex + ":" + c3.SelectedIndex;
                hours.timeD = a4.SelectedIndex + ":" + b4.SelectedIndex + ":" + c4.SelectedIndex;
                string weeks = "";
                for (int i = 0; i < checkedListBox5.Items.Count; i++)
                {
                    if (checkedListBox5.GetItemChecked(i))
                    {
                        weeks += "1";
                    }
                    else
                    {
                        weeks += "0";
                    }
                }
                hours.Weeks = weeks;

                var taxHours = m.WH_Sys_happyHour_ServiceTax_Hours.FirstOrDefault(x => x.isHappyOrTax == 1);
                //WH_Sys_happyHour_ServiceTax_Hours q = new WH_Sys_happyHour_ServiceTax_Hours();
                taxHours.timeA = a5.SelectedIndex + ":" + b5.SelectedIndex + ":" + c5.SelectedIndex;
                taxHours.timeB = a6.SelectedIndex + ":" + b6.SelectedIndex + ":" + c6.SelectedIndex;
                taxHours.timeC = a7.SelectedIndex + ":" + b7.SelectedIndex + ":" + c7.SelectedIndex;
                taxHours.timeD = a8.SelectedIndex + ":" + b8.SelectedIndex + ":" + c8.SelectedIndex;
                string limit1 = "";
                for (int i = 0; i < checkedListBox4.Items.Count; i++)
                {
                    if (checkedListBox4.GetItemChecked(i))
                    {
                        limit1 += "1";
                    }
                    else
                    {
                        limit1 += "0";
                    }
                }
                taxHours.Weeks = limit1;
                WH_Sys_ServiceTax serviceTax = m.WH_Sys_ServiceTax.FirstOrDefault();
                //WH_Sys_ServiceTax p = new WH_Sys_ServiceTax();
                serviceTax.Name = tbName.Text;
                serviceTax.RateAmount = decimal.Parse(tbRate.Text);
                serviceTax.Type = cbType.SelectedIndex;
                #endregion

                #region Page 6

                for (int i = 1; i < 11; i++)
                {
                    TextBox t = this.groupBox3.Controls["t" + i] as TextBox;
                    CheckBox u = this.groupBox3.Controls["u" + i] as CheckBox;
                    TextBox v = this.groupBox3.Controls["v" + i] as TextBox;
                    ComboBox w = this.groupBox3.Controls["w" + i] as ComboBox;
                    ComboBox x = this.groupBox3.Controls["x" + i] as ComboBox;
                    string id = t.Text;
                    WH_Sys_WeightingPLU sysWeightingPlu = m.WH_Sys_WeightingPLU.FirstOrDefault(z => z.WID == id);
                    sysWeightingPlu.TypeID = u.Checked ? 1 : 0;
                    sysWeightingPlu.BarCodeLength = int.Parse(v.Text);
                    sysWeightingPlu.WAID = w.SelectedIndex;
                    sysWeightingPlu.Dots = x.SelectedIndex;
                }

                WH_Sys_WeightingPLU weightingPlu = m.WH_Sys_WeightingPLU.FirstOrDefault(o => o.ID == 11);
                weightingPlu.WID = t11.Text;
                weightingPlu.TypeID = u11.Checked ? 1 : 0;
                weightingPlu.BarCodeLength = int.Parse(v11.Text);
                weightingPlu.WAID = w11.SelectedIndex;
                weightingPlu.Dots = x11.SelectedIndex;

                var tares = from c in m.WH_Sys_ElectronicScale_Tare
                        where c.awID == cbUnit.SelectedIndex
                        select c;
                foreach (var w in tares)
                {
                    m.DeleteObject(w);
                }

                for (int i = 1; i < 11; i++)
                {
                    WH_Sys_ElectronicScale_Tare w = new WH_Sys_ElectronicScale_Tare();
                    w.awID = cbUnit.SelectedIndex;
                    TextBox t = this.groupBox4.Controls["z" + i] as TextBox;
                    w.tare = decimal.Parse(t.Text);
                    m.AddToWH_Sys_ElectronicScale_Tare(w);
                }
                
                //page 6 
                #endregion

                #region Page 7
                //page 7
                WH_Sys_TableBarcode barcode = m.WH_Sys_TableBarcode.FirstOrDefault();

                barcode.OperateType_index = comboBox1d.SelectedIndex;
                barcode.Position_index = comboBox2d.SelectedIndex;
                barcode.widths = int.Parse(textBox1d.Text);
                barcode.heights = int.Parse(textBox2d.Text);
                barcode.HRI_index = comboBox4d.SelectedIndex;
                barcode.Fonts_index = comboBox5d.SelectedIndex;
                barcode.PrintList = checkBox1d.Checked ? 1 : 0;
                barcode.suspendTable = checkBox2d.Checked ? 1 : 0;
                barcode.TransferTable = checkBox3d.Checked ? 1 : 0;
                barcode.OperateType = comboBox1d.SelectedText;
                barcode.Position = comboBox2d.SelectedText;
                barcode.HRI = comboBox4d.SelectedText;
                barcode.Fonts = comboBox5d.SelectedText;


                WH_Sys_mailer mailer = m.WH_Sys_mailer.FirstOrDefault();
                mailer.MailerName = textBox3d.Text;
                mailer.MailerCode = textBox4d.Text;
                mailer.TenantCode = textBox5d.Text;

                WH_Sys_Ftp ftp = m.WH_Sys_Ftp.FirstOrDefault();
                ftp.IP = textBox6d.Text;
                ftp.UserName = textBox7d.Text;
                ftp.PassWord = textBox8d.Text;
                #endregion
                

                m.SaveChanges();

            }
        }
        private void Bind_Combobox(List<Dog> dog)
        {
            for (int i = 1; i < 5; i++)
            {
                ComboBox a = this.groupBox1.Controls["a" + i] as ComboBox;
                ComboBox b = this.groupBox1.Controls["b" + i] as ComboBox;
                ComboBox c = this.groupBox1.Controls["c" + i] as ComboBox;
                c.Visible = false;
                for (int j = 0; j < 25; j++)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = j.ToString().PadLeft(2, '0');
                    cb.Value = j.ToString().PadLeft(2, '0');
                    a.Items.Add(cb);

                }
                for (int j = 0; j < 60; j++)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = j.ToString().PadLeft(2, '0');
                    cb.Value = j.ToString().PadLeft(2, '0');
                    b.Items.Add(cb);
                    c.Items.Add(cb);
                }
                a.SelectedIndex = dog[i - 1].head;
                b.SelectedIndex = dog[i - 1].body;
                c.SelectedIndex = dog[i - 1].foot;
            }
            for (int i = 5; i < 9; i++)
            {
                ComboBox a = this.groupBox2.Controls["a" + i] as ComboBox;
                ComboBox b = this.groupBox2.Controls["b" + i] as ComboBox;
                ComboBox c = this.groupBox2.Controls["c" + i] as ComboBox;
                c.Visible = false;
                for (int j = 0; j < 25; j++)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = j.ToString().PadLeft(2, '0');
                    cb.Value = j.ToString().PadLeft(2, '0');
                    a.Items.Add(cb);

                }
                for (int j = 0; j < 60; j++)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = j.ToString().PadLeft(2, '0');
                    cb.Value = j.ToString().PadLeft(2, '0');
                    b.Items.Add(cb);
                    c.Items.Add(cb);
                }
                a.SelectedIndex = dog[i - 1].head;
                b.SelectedIndex = dog[i - 1].body;
                c.SelectedIndex = dog[i - 1].foot;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                for (int i = 0; i < checkedListBox4.Items.Count; i++)
                {
                    checkedListBox4.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox4.Items.Count; i++)
                {
                    checkedListBox4.SetItemChecked(i, false);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < checkedListBox5.Items.Count; i++)
                {
                    checkedListBox5.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox5.Items.Count; i++)
                {
                    checkedListBox5.SetItemChecked(i, false);
                }
            }
        }

         
        private void Weighing_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox) sender;
            int count = int.Parse(cb.Name.ToString().Replace("u",""));
            TextBox v = this.groupBox3.Controls["v" + count] as TextBox;
            ComboBox w = this.groupBox3.Controls["w" + count] as ComboBox;
            ComboBox x = this.groupBox3.Controls["x" + count] as ComboBox;
            if(cb.Checked)
            {   
                v.Enabled = true;
                w.Enabled = true; 
            }
            else
            { 
                v.Enabled = false;
                w.Enabled = false;
                x.Enabled = false;
            }
            
           
        }

        private void w_SelectedIndexChanged(object sender, EventArgs e)
        {
            int w = ((ComboBox) sender).SelectedIndex;
            int xI = int.Parse(((ComboBox) sender).Name.ToString().Replace("w",""));
            ComboBox x = this.groupBox3.Controls["x" + xI] as ComboBox;
            if(w==1)
            {
                x.Enabled = true;
            }
            else
            {
                x.Enabled = false; 
            }
        }

        private void t11_KeyUp(object sender, KeyEventArgs e)
        {
            bool isOK = true;
            if((int.Parse(t11.Text)>=20)&&(int.Parse(t11.Text)<=30))
            {
                isOK = false;
            }
            if(int.Parse(t11.Text)>99)
            {
                isOK = false;
            }
            if(!isOK)
            {
                t11.Text = "";
            }
        }

        private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int awid = cbUnit.SelectedIndex; 
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_ElectronicScale_Tare
                        where c.awID == awid
                        select c;
                int i = 1;
                foreach (var w in q)
                {
                    TextBox z = this.groupBox4.Controls["z" + i] as TextBox;
                    z.KeyPress += (Tools.Validate.KeyPress);
                    z.Text = w.tare.ToString();
                    i++;
                }
            }
        }

         
    }
    public class Dog
    {
        public int head { get; set; }
        public int body { get; set; }
        public int foot { get; set; }
    }
}
