using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PBMApp.Model;
using PBMApp.Tools;

namespace PBMApp
{
    public partial class frm_dept : Form
    {
        public frm_dept()
        {
            InitializeComponent();
        }
        BindingSource bs = new BindingSource();
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seletedIndex = cbisVat.SelectedIndex;
            switch (seletedIndex)
            {
                case 0:
                    groupBox6.Enabled = true;
                    groupBox7.Enabled = false;
                    groupBox8.Enabled = false;
                    break;
                case 1:
                    groupBox6.Enabled = false;
                    groupBox7.Enabled = true;
                    groupBox8.Enabled = false;
                    break;
                case 2:
                    groupBox6.Enabled = false;
                    groupBox7.Enabled = false;
                    groupBox8.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void frm_dept_Load(object sender, EventArgs e)
        {
            ComboBoxItem cb = new ComboBoxItem();
            cb.Text = "None";
            cb.Value = "0";
            cbKP.Items.Add(cb);
            cbKP2.Items.Add(cb);

            for (int i = 1; i < 14; i++)
            {
                ComboBoxItem c = new ComboBoxItem();
                c.Text = "KP" + i;
                c.Value = i;
                cbKP.Items.Add(c);
                cbKP2.Items.Add(c);
            }
            ComboBoxItem cc = new ComboBoxItem();
            cc.Text = "RP";
            cc.Value = "14";
            cbKP.Items.Add(cc);
            cbKP2.Items.Add(cc);

            cbHDLO.SelectedIndex = 0;
            BindData();
        }
        private void BindData()
        {
            DataTable dt = new DataTable("dt");
            dt.Clear();
            dataGridView1.Columns.Clear(); 
            DataColumn dc1 = new DataColumn("No.", typeof(string));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("Description", typeof(string));
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn("Price", typeof(string));
            dt.Columns.Add(dc3);
            DataColumn dc4 = new DataColumn("HDLO", typeof(string));
            dt.Columns.Add(dc4);
            //DataColumn dc5 = new DataColumn("Limitaions", typeof(string));
            //dt.Columns.Add(dc5);


            var m = new Entities();
            var q = from c in m.WH_Department

                    select c;
            foreach (WH_Department c in q)
            {
                DataRow dr = dt.NewRow();
                dr[0] = c.ID;
                dr[1] = c.Description;
                dr[2] = c.isPrice;
                dr[3] = c.High_Digit_LockOut; 
                dt.Rows.Add(dr);
            }

            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            bindingNavigator1.BindingSource = bs;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == -1)
            {
                return;
            }
            int id = int.Parse(dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());

            using (var m = new Entities())
            {
                var ctx = m.WH_Department.First(x => x.ID == id);
                tbID.Text = ctx.ID.ToString();
                tbDesc.Text = ctx.Description.ToString();
                cbHDLO.SelectedIndex = int.Parse(ctx.High_Digit_LockOut.ToString())-1;
                cbisAge.SelectedIndex = int.Parse(ctx.isAge.ToString());
                tbisPrice.Text = ctx.isPrice.ToString();
                cbGroup.SelectedIndex = int.Parse(ctx.DepartmentGroup.ToString());
                cbKP.SelectedIndex = int.Parse(ctx.KP.ToString())-1;
                cbMode.SelectedIndex = int.Parse(ctx.isMode.ToString());

                Combox_KP1(int.Parse(ctx.KP.ToString()));
                Combox_KP2(int.Parse(ctx.KP2.ToString()));

                int isPriceFormat = int.Parse(ctx.isPriceFormat.ToString());
                if (isPriceFormat == 0)
                {
                    rbPriceFormat0.Checked = true;
                     rbPriceFormat1.Checked = false;
                }
                else
                {
                    rbPriceFormat1.Checked = true;
                    rbPriceFormat0.Checked = false;
                }
                int isType = int.Parse(ctx.isType.ToString());
                if(isType ==0)
                {
                    rbType0.Checked = true;
                    rbType1.Checked = false;
                }
                else
                {
                    rbType0.Checked = false;
                    rbType1.Checked = true;
                }
                int kp_receipt = int.Parse(ctx.KP_receipt.ToString());
                if(kp_receipt==0)
                {
                    rbKP0.Checked = true;
                    rbKP1.Checked = false;
                }
                else
                {
                    rbKP0.Checked = false;
                    rbKP1.Checked = true;
                }
                cbKP.SelectedIndex = int.Parse(ctx.KP.ToString());
                cbKP2.SelectedIndex = int.Parse(ctx.KP2.ToString());
                chkFS.Checked = int.Parse(ctx.FS_Tenderable.ToString()) == 1;
                cbisVat.SelectedIndex = int.Parse(ctx.isVat_Tax_GST.ToString());
                string str_vat_tax_gst = ctx.str_Vat_Tax_GST.ToString();
                char[] chars = str_vat_tax_gst.ToCharArray();
                switch (int.Parse(ctx.isVat_Tax_GST.ToString()))
                {
                    case 0:
                        switch (int.Parse(str_vat_tax_gst))
                        {
                            case 0:
                                rbVat0.Checked = true;
                                rbVat1.Checked = false;
                                rbVat2.Checked = false;
                                rbVat3.Checked = false;
                                rbVat4.Checked = false;
                                break;
                            case 1:
                                rbVat0.Checked = false;
                                rbVat1.Checked = true;
                                rbVat2.Checked = false;
                                rbVat3.Checked = false;
                                rbVat4.Checked = false;
                                break;
                            case 2:
                                rbVat0.Checked = false;
                                rbVat1.Checked = false;
                                rbVat2.Checked = true;
                                rbVat3.Checked = false;
                                rbVat4.Checked = false;
                                break;
                            case 3:
                                rbVat0.Checked = false;
                                rbVat1.Checked = false;
                                rbVat2.Checked = false;
                                rbVat3.Checked = true;
                                rbVat4.Checked = false;
                                break;
                            case 4:
                                rbVat0.Checked = false;
                                rbVat1.Checked = false;
                                rbVat2.Checked = false;
                                rbVat3.Checked = false;
                                rbVat4.Checked = true;
                                break;
                            default:
                                break;
                        }
                        for (int i = 0; i < chkGST.Items.Count; i++)
                        {
                            chkGST.SetItemChecked(i,false);
                        }
                        for (int i = 0; i < chkTax.Items.Count; i++)
                        {
                            chkTax.SetItemChecked(i, false);
                        }
                        groupBox6.Enabled = true;
                        groupBox7.Enabled = false;
                        groupBox8.Enabled = false;
                        break;
                    case 1:
                        
                        for (int i = 0; i < chkTax.Items.Count; i++)
                        {
                            if(str_vat_tax_gst.IndexOf(i.ToString())!=-1)
                            {
                                chkTax.SetItemChecked(i,true);
                            }
                            else
                            {
                                chkTax.SetItemChecked(i, false);
                            }
                        }
                        for (int i = 0; i < chkGST.Items.Count; i++)
                        {
                            chkGST.SetItemChecked(i, false);
                        }
                        groupBox6.Enabled = false;
                        groupBox7.Enabled = true;
                        groupBox8.Enabled = false;
                        break;
                    case 2:
                        for (int i = 0; i < chkGST.Items.Count; i++)
                        {
                            if (str_vat_tax_gst.IndexOf(i.ToString()) != -1)
                            {
                                chkGST.SetItemChecked(i, true);
                            }
                            else
                            {
                                chkGST.SetItemChecked(i, false);
                            }
                        }
                        for (int i = 0; i < chkTax.Items.Count; i++)
                        {
                            chkTax.SetItemChecked(i, false);
                        }
                        groupBox6.Enabled = false;
                        groupBox7.Enabled = false;
                        groupBox8.Enabled = true;
                        break;
                    default:break;
                }
                

            }
             
        }
        /// <summary>
        /// KP2
        /// </summary>
        /// <param name="selected"></param>
        private void Combox_KP2(int selected)
        {
            //cbKP2.Items.Clear();
            //using (var m = new Entities())
            //{
            //    var q = from c in m.WH_Sys_KP
            //            orderby c.ID ascending
            //            select c;
            //    ComboBoxItem cbNone=new ComboBoxItem();
            //    cbNone.Text = "None";
            //    cbNone.Value = "0";
            //    cbKP2.Items.Add(cbNone);

            //    foreach (var w in q)
            //    {
            //        Tools.ComboBoxItem cb = new ComboBoxItem();
            //        cb.Text = "KP" + w.ID;
            //        cb.Value = w.ID;
            //        cbKP2.Items.Add(cb);
            //    }
            //    ComboBoxItem cbRP = new ComboBoxItem();
            //    cbRP.Text = "RP";
            //    cbRP.Value = "14";
            //    cbKP2.Items.Add(cbRP);
            //}
            cbKP2.SelectedIndex = selected;
        }
        /// <summary>
        /// KP1
        /// </summary>
        /// <param name="selected"></param>
        private void Combox_KP1(int selected)
        {
            //cbKP.Items.Clear();
            //using (var m=new Entities())
            //{
            //    var q = from c in m.WH_Sys_KP
            //            orderby c.ID ascending
            //            select c;
            //    ComboBoxItem cbNone = new ComboBoxItem();
            //    cbNone.Text = "None";
            //    cbNone.Value = "0";
            //    cbKP.Items.Add(cbNone);
            //    foreach (var w in q)
            //    {
            //        Tools.ComboBoxItem cb = new ComboBoxItem();
            //        cb.Text = "KP" + w.ID;
            //        cb.Value = w.ID;
            //        cbKP.Items.Add(cb);
            //    }
            //    ComboBoxItem cbRP = new ComboBoxItem();
            //    cbRP.Text = "RP";
            //    cbRP.Value = "14";
            //    cbKP.Items.Add(cbRP);
            //} 
            cbKP.SelectedIndex = selected;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (var m=new Entities())
            {
                int id = int.Parse(tbID.Text);
                WH_Department wd = m.WH_Department.FirstOrDefault(x => x.ID == id);

                wd.Description = tbDesc.Text;
                wd.High_Digit_LockOut = cbHDLO.SelectedIndex+1;
                wd.isAge = cbisAge.SelectedIndex;
                wd.isPrice = int.Parse(tbisPrice.Text);
                wd.DepartmentGroup = cbGroup.SelectedIndex;
                wd.KP = cbKP.SelectedIndex;
                wd.isMode = cbMode.SelectedIndex;
                wd.isPriceFormat = rbPriceFormat0.Checked ? 0 : 1;
                wd.KP_receipt = rbKP0.Checked ? 0 : 1;
                wd.isType = rbType0.Checked ? 0 : 1;
                wd.isVat_Tax_GST = cbisVat.SelectedIndex;
                wd.FS_Tenderable = chkFS.Checked ? 1 : 0;
                wd.KP = int.Parse(cbKP.SelectedIndex.ToString());
                wd.KP2 = int.Parse(cbKP2.SelectedIndex.ToString());

                switch (cbisVat.SelectedIndex)
                {
                    case 0:
                       if(rbVat0.Checked)
                       {
                           wd.str_Vat_Tax_GST = "0";
                       }
                       if (rbVat1.Checked)
                       {
                           wd.str_Vat_Tax_GST = "1";
                       }
                       if (rbVat2.Checked)
                       {
                           wd.str_Vat_Tax_GST = "2";
                       }
                       if (rbVat3.Checked)
                       {
                           wd.str_Vat_Tax_GST = "3";
                       }
                       if (rbVat4.Checked)
                       {
                           wd.str_Vat_Tax_GST = "4";
                       }
                        break;
                    case 1:
                        for (int i = 0; i < chkTax.Items.Count; i++)
                        {
                            if(chkTax.GetItemChecked(i))
                            {
                                wd.str_Vat_Tax_GST += i.ToString();
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < chkGST.Items.Count; i++)
                        {
                            if (chkGST.GetItemChecked(i))
                            {
                                wd.str_Vat_Tax_GST += i.ToString();
                            }
                        }
                        break;
                }
                m.SaveChanges();

            }
            BindData();
            MessageBox.Show("Success!", "alert");
        }

        private void tbisPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Convert.ToInt32(e.KeyChar) == 8))
            {
                e.Handled = false;
            }
            else
            {
                Regex numRegex = new Regex(@"^(-?[0-9]*[.]*[0-9]*)$");
                Match Result = numRegex.Match(Convert.ToString(e.KeyChar));
                if (Result.Success)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void BindDetail()
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            using (var m = new Entities())
            {
                var ctx = m.WH_Department.First(x => x.ID == id);
                tbID.Text = ctx.ID.ToString();
                tbDesc.Text = ctx.Description.ToString();
                cbHDLO.SelectedIndex = int.Parse(ctx.High_Digit_LockOut.ToString()) - 1;
                cbisAge.SelectedIndex = int.Parse(ctx.isAge.ToString());
                tbisPrice.Text = ctx.isPrice.ToString();
                cbGroup.SelectedIndex = int.Parse(ctx.DepartmentGroup.ToString());
                cbKP.SelectedIndex = int.Parse(ctx.KP.ToString()) - 1;
                cbMode.SelectedIndex = int.Parse(ctx.isMode.ToString());

                Combox_KP1(int.Parse(ctx.KP.ToString()));
                Combox_KP2(int.Parse(ctx.KP2.ToString()));

                int isPriceFormat = int.Parse(ctx.isPriceFormat.ToString());
                if (isPriceFormat == 0)
                {
                    rbPriceFormat0.Checked = true;
                    rbPriceFormat1.Checked = false;
                }
                else
                {
                    rbPriceFormat1.Checked = true;
                    rbPriceFormat0.Checked = false;
                }
                int isType = int.Parse(ctx.isType.ToString());
                if (isType == 0)
                {
                    rbType0.Checked = true;
                    rbType1.Checked = false;
                }
                else
                {
                    rbType0.Checked = false;
                    rbType1.Checked = true;
                }
                int kp_receipt = int.Parse(ctx.KP_receipt.ToString());
                if (kp_receipt == 0)
                {
                    rbKP0.Checked = true;
                    rbKP1.Checked = false;
                }
                else
                {
                    rbKP0.Checked = false;
                    rbKP1.Checked = true;
                }
                cbisVat.SelectedIndex = int.Parse(ctx.isVat_Tax_GST.ToString());
                string str_vat_tax_gst = ctx.str_Vat_Tax_GST.ToString();
                char[] chars = str_vat_tax_gst.ToCharArray();
                switch (int.Parse(ctx.isVat_Tax_GST.ToString()))
                {
                    case 0:
                        switch (int.Parse(str_vat_tax_gst))
                        {
                            case 0:
                                rbVat0.Checked = true;
                                rbVat1.Checked = false;
                                rbVat2.Checked = false;
                                rbVat3.Checked = false;
                                rbVat4.Checked = false;
                                break;
                            case 1:
                                rbVat0.Checked = false;
                                rbVat1.Checked = true;
                                rbVat2.Checked = false;
                                rbVat3.Checked = false;
                                rbVat4.Checked = false;
                                break;
                            case 2:
                                rbVat0.Checked = false;
                                rbVat1.Checked = false;
                                rbVat2.Checked = true;
                                rbVat3.Checked = false;
                                rbVat4.Checked = false;
                                break;
                            case 3:
                                rbVat0.Checked = false;
                                rbVat1.Checked = false;
                                rbVat2.Checked = false;
                                rbVat3.Checked = true;
                                rbVat4.Checked = false;
                                break;
                            case 4:
                                rbVat0.Checked = false;
                                rbVat1.Checked = false;
                                rbVat2.Checked = false;
                                rbVat3.Checked = false;
                                rbVat4.Checked = true;
                                break;
                            default:
                                break;
                        }
                        for (int i = 0; i < chkGST.Items.Count; i++)
                        {
                            chkGST.SetItemChecked(i, false);
                        }
                        for (int i = 0; i < chkTax.Items.Count; i++)
                        {
                            chkTax.SetItemChecked(i, false);
                        }
                        groupBox6.Enabled = true;
                        groupBox7.Enabled = false;
                        groupBox8.Enabled = false;
                        break;
                    case 1:

                        for (int i = 0; i < chkTax.Items.Count; i++)
                        {
                            if (str_vat_tax_gst.IndexOf(i.ToString()) != -1)
                            {
                                chkTax.SetItemChecked(i, true);
                            }
                            else
                            {
                                chkTax.SetItemChecked(i, false);
                            }
                        }
                        for (int i = 0; i < chkGST.Items.Count; i++)
                        {
                            chkGST.SetItemChecked(i, false);
                        }
                        groupBox6.Enabled = false;
                        groupBox7.Enabled = true;
                        groupBox8.Enabled = false;
                        break;
                    case 2:
                        for (int i = 0; i < chkGST.Items.Count; i++)
                        {
                            if (str_vat_tax_gst.IndexOf(i.ToString()) != -1)
                            {
                                chkGST.SetItemChecked(i, true);
                            }
                            else
                            {
                                chkGST.SetItemChecked(i, false);
                            }
                        }
                        for (int i = 0; i < chkTax.Items.Count; i++)
                        {
                            chkTax.SetItemChecked(i, false);
                        }
                        groupBox6.Enabled = false;
                        groupBox7.Enabled = false;
                        groupBox8.Enabled = true;
                        break;
                    default: break;
                }


            }
             
        }
        
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            BindDetail();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            BindDetail();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            BindDetail();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            BindDetail();
        }
    }
}
