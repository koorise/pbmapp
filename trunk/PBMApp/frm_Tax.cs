﻿using System;
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
    public partial class frm_Tax : Form
    {
        public frm_Tax()
        {
            InitializeComponent();
        }

        private void frm_Tax_Load(object sender, EventArgs e)
        {
           
        }
        BindingSource bs = new BindingSource();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int taxID = comboBox1.SelectedIndex + 1;
            using (var m = new Entities())
            {
                var tax = m.WH_Tax.FirstOrDefault(x => x.ID == taxID);
                int TaxTypeID = int.Parse(tax.TaxTypeID.ToString());
                comboBox2.SelectedIndex = TaxTypeID;

                //tax table
                if(TaxTypeID==0)
                {
                    dataGridView1.Columns.Clear();
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = true;
                    DataBind_Dvg(int.Parse(tax.ID.ToString()));
                }
                //tax straight
                if(TaxTypeID==1)
                {
                    dataGridView1.Columns.Clear();
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = false;
                    tbRate.Text = tax.Rate.ToString();
                    tbLimit.Text = tax.Limit.ToString();

                }
                
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int taxID = comboBox1.SelectedIndex + 1;
            using (var m = new Entities())
            {
                var tax = m.WH_Tax.FirstOrDefault(x => x.ID == taxID);
                int TaxTypeID = comboBox2.SelectedIndex;

                //tax table
                if (TaxTypeID == 0)
                {
                    dataGridView1.Columns.Clear();
                    groupBox1.Enabled = false;
                    groupBox2.Enabled = true;
                    DataBind_Dvg(int.Parse(tax.ID.ToString()));
                    var q = from c in m.WH_Tax_Table
                            where c.TaxID == tax.ID 
                            orderby c.isFlag descending 
                            select c.TaxB;
                    if(q.FirstOrDefault()!=null)
                    {
                        tbTaxA.Text = (decimal.Parse(q.First().Value.ToString()) + decimal.Parse("0.01")).ToString();
                    }
                    else
                    {
                        tbTaxA.Text = "0.00";
                    }
                    
                }
                //tax straight
                if (TaxTypeID == 1)
                {
                    dataGridView1.Columns.Clear();
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = false;
                    tbRate.Text = tax.Rate.ToString();
                    tbLimit.Text = tax.Limit.ToString();
                }

            }
        }

        private void DataBind_Dvg(int taxID)
        {
            using (var m = new Entities())
            {
                  
                DataTable dt = new DataTable("dt");
                dt.Clear();
                dataGridView1.Columns.Clear();
                DataColumn dc1 = new DataColumn("ID", typeof(int));
                dt.Columns.Add(dc1);
                DataColumn dc2 = new DataColumn("FlagID", typeof(int));
                dt.Columns.Add(dc2);
                DataColumn dc3 = new DataColumn("Range", typeof(string));
                dt.Columns.Add(dc3);
                DataColumn dc4 = new DataColumn("Tax Rate", typeof(string));
                dt.Columns.Add(dc4);

                var q = from c in m.WH_Tax_Table
                        where c.TaxID == taxID
                        orderby c.isFlag ascending 
                        select c;
                foreach (var w in q)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = int.Parse(w.ID.ToString());
                    dr[1] = int.Parse(w.isFlag.ToString());
                    dr[2] = w.TaxA.ToString() + "-" + w.TaxB.ToString();
                    dr[3] = w.TaxRate.ToString();
                    dt.Rows.Add(dr);
                }
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
                bindingNavigator1.BindingSource = bs;

            }
        } 

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = from c in m.WH_Tax_Table
                        where c.TaxID == comboBox1.SelectedIndex + 1
                        orderby c.isFlag descending
                        select c;
                m.DeleteObject(q.FirstOrDefault());
                m.SaveChanges();
                var qq = from c in m.WH_Tax_Table
                        where c.TaxID == comboBox1.SelectedIndex + 1
                        orderby c.isFlag descending
                        select c.TaxB;
                if(qq.FirstOrDefault()!=null)
                {
                    tbTaxA.Text = (decimal.Parse(qq.First().Value.ToString()) + decimal.Parse("0.01")).ToString();
                }
                else
                {
                    tbTaxA.Text = "0.00";
                }
                DataBind_Dvg(comboBox1.SelectedIndex + 1);
                MessageBox.Show("success!", "alert");
                m.Dispose();    
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    int q = (from c in m.WH_Tax_Table
                            where c.TaxID == comboBox1.SelectedIndex + 1
                            orderby c.isFlag descending
                            select c.isFlag).Count();
                    int isFlag = q + 1;
                     
                    if(decimal.Parse(tbTaxA.Text)<decimal.Parse(tbTaxB.Text))
                    {
                        WH_Tax wt= m.WH_Tax.FirstOrDefault(x => x.ID == comboBox1.SelectedIndex + 1);
                        wt.TaxTypeID = comboBox2.SelectedIndex;

                        WH_Tax_Table w = new WH_Tax_Table();
                        w.TaxID = comboBox1.SelectedIndex + 1;
                        w.TaxA = decimal.Parse(tbTaxA.Text);
                        w.TaxB = decimal.Parse(tbTaxB.Text);
                        w.TaxRate = decimal.Parse(tbTaxRate.Text);
                        w.isFlag = isFlag;
                        m.AddToWH_Tax_Table(w);
                        m.SaveChanges();
                        tbTaxA.Text = (decimal.Parse(tbTaxB.Text) + decimal.Parse("0.01")).ToString();
                        tbTaxB.Text = "";
                        tbTaxRate.Text = "";
                        DataBind_Dvg(comboBox1.SelectedIndex + 1);
                        MessageBox.Show("success", "alert");
                    }
                    else
                    {
                        MessageBox.Show("Err", "alert");
                    }
                }
                else
                {
                    if (comboBox2.SelectedIndex == 1)
                    {
                        WH_Tax w = m.WH_Tax.FirstOrDefault(x => x.ID == comboBox1.SelectedIndex + 1);
                        w.TaxTypeID = 1;
                        w.Rate = decimal.Parse(tbRate.Text);
                        w.Limit = decimal.Parse(tbLimit.Text);
                        m.SaveChanges();
                        MessageBox.Show("success", "alert");
                    }
                    else
                    {
                        MessageBox.Show("Err", "alert");
                    }
                }
            }
        }
    }
}
