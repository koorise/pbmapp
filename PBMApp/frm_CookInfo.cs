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
    public partial class frm_CookInfo : Form
    {
        public frm_CookInfo()
        {
            InitializeComponent();
        }

        private void frm_CookInfo_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            DataTable dt = new DataTable("dt");
            dt.Clear();
            dataGridView1.Columns.Clear();
            DataColumn dc1 = new DataColumn("ID", typeof(string));
            dt.Columns.Add(dc1);
            //DataColumn dc2 = new DataColumn("Num", typeof(string));
            //dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn("Description", typeof(string));
            dt.Columns.Add(dc3);
            DataColumn dc4 = new DataColumn("Price", typeof(string));
            dt.Columns.Add(dc4);
            //DataColumn dc5 = new DataColumn("Limitaions", typeof(string));
            //dt.Columns.Add(dc5);


            var m = new Entities();
            var q = from c in m.WH_CookInformation

                    select c;
            foreach (WH_CookInformation c in q)
            {
                DataRow dr = dt.NewRow();
                dr[0] = c.ID;
                //dr[1] = c.Num;
                dr[1] = c.Description;
                dr[2] = c.price;
                dt.Rows.Add(dr);
            }

            dataGridView1.DataSource = dt;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            int id = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
            using (var m=new Entities())
            {
                var ctx = m.WH_CookInformation.FirstOrDefault(x => x.ID == id);
                tbDesc.Text = ctx.Description;
                tbNo.Text = ctx.ID.ToString();
                tbPrice.Text = ctx.price.ToString();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var m=new Entities())
            {
                int id = int.Parse(tbNo.Text);
                WH_CookInformation w = m.WH_CookInformation.FirstOrDefault(x => x.ID == id);
                w.price = decimal.Parse(tbPrice.Text);
                w.Description = tbDesc.Text;
                m.SaveChanges();
            }
            BindData();
        }
    }
}
