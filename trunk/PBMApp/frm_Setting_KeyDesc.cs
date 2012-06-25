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
    public partial class frm_Setting_KeyDesc : Form
    {
        public frm_Setting_KeyDesc()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int KeyTypeID = int.Parse(((ComboBoxItem) comboBox1.SelectedItem).Value.ToString());
            DataBind(KeyTypeID);

        }
        private void DataBind(int KeyTypeID)
        {
            DataTable dt = new DataTable("dt");
            dt.Clear();
            dataGridView1.Columns.Clear();
            DataColumn dc1 = new DataColumn("No.", typeof(string));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("Standard", typeof(string));
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn("Constom", typeof(string));
            dt.Columns.Add(dc3);
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_KeyDesc
                        where c.KeyTypeID == KeyTypeID
                        select c;
                foreach (var w in q)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = w.ID;
                    dr[1] = w.EnStr.ToString();
                    dr[2] = w.CNStr.ToString();
                    dt.Rows.Add(dr);
                }
                dataGridView1.DataSource = dt;
            }
        }
        private void frm_Setting_KeyDesc_Load(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_KeyType
                        select c;
                foreach (var w in q)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Descs;
                    cb.Value = w.ID;
                    comboBox1.Items.Add(cb);
                }
                comboBox1.SelectedIndex = 0;
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
                var q = m.WH_Sys_KeyDesc.FirstOrDefault(x => x.ID == id);
                textBox1.Text = q.CNStr.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            using (var m = new Entities())
            {
                var q = m.WH_Sys_KeyDesc.FirstOrDefault(x => x.ID == id);
                q.CNStr = textBox1.Text;
                m.SaveChanges();
            }
            int KeyTypeID = int.Parse(((ComboBoxItem)comboBox1.SelectedItem).Value.ToString());
            DataBind(KeyTypeID);
        }

       
    }
}
