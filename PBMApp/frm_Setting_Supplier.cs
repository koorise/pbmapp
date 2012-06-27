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
    public partial class frm_Setting_Supplier : Form
    {
        public frm_Setting_Supplier()
        {
            InitializeComponent();
        }
        BindingSource bs = new BindingSource();
        private void frm_Setting_Supplier_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            using (var m = new Entities())
            {
                DataTable dt = new DataTable("dt");
                dt.Clear();
                dataGridView1.Columns.Clear();

                DataColumn dc0 = new DataColumn("NO.", typeof(int));
                dt.Columns.Add(dc0);
                DataColumn dc1 = new DataColumn("Description", typeof(string));
                dt.Columns.Add(dc1);

                var q = from c in m.WH_Sys_Supplier
                        orderby c.ID ascending 
                        select c;
                foreach (var w in q)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = int.Parse(w.ID.ToString());
                    dr[1] = w.Description;
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
        }
        private void BindDetail()
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            using (var m = new Entities())
            {
                var ctx = m.WH_Sys_Supplier.FirstOrDefault(x => x.ID == id);
                textBox1.Text = ctx.ID.ToString();
                textBox2.Text = ctx.Description.ToString(); 
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                if(textBox1.Text!="")
                {
                    int id;
                    int.TryParse(textBox1.Text, out id);
                    var ctx = m.WH_Sys_Supplier.FirstOrDefault(x => x.ID == id);
                    if(ctx==null)
                    {
                        return;
                    }
                    ctx.Description = textBox2.Text;
                    m.SaveChanges();
                }
                else
                {
                    WH_Sys_Supplier sp = new WH_Sys_Supplier();
                    sp.Description = textBox2.Text;
                    m.AddToWH_Sys_Supplier(sp);
                    m.SaveChanges();
                }
               
            }
            BindData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var m= new Entities())
            {
                WH_Sys_Supplier s = new WH_Sys_Supplier();
                s.Description = "New One";
                m.AddToWH_Sys_Supplier(s);
                m.SaveChanges();

                var q = m.WH_Sys_Supplier.FirstOrDefault(x => x.Description =="New One");
                textBox1.Text = q.ID.ToString();
                textBox2.Text = q.Description;

            }
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count!=0)
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                using (var m = new Entities())
                {
                    WH_Sys_Supplier w = m.WH_Sys_Supplier.FirstOrDefault(x => x.ID == id);
                    m.DeleteObject(w);
                    m.SaveChanges();
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            BindData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            using (var m = new Entities())
            {
                var ctx = m.WH_Sys_Supplier.FirstOrDefault(x => x.ID == id);
                textBox1.Text = ctx.ID.ToString();
                textBox2.Text = ctx.Description.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

    }
}
