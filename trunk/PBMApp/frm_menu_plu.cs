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
    public partial class frm_menu_plu : Form
    {
        public frm_menu_plu()
        {
            InitializeComponent();
        }
        public DataTable dtt = new DataTable("dtt");
        private void frm_menu_plu_Load(object sender, EventArgs e)
        {

            DataColumn dt11 = new DataColumn("ID", typeof(string));
            dtt.Columns.Add(dt11);
            DataColumn dt22 = new DataColumn("Bar Code", typeof(string));
            dtt.Columns.Add(dt22);
            DataColumn dt33 = new DataColumn("Description", typeof(string));
            dtt.Columns.Add(dt33);

            using (var m = new Entities())
            {
                var q = from c in m.WH_Menu
                        orderby c.ID ascending 
                        select c;
                foreach (var w in q)
                {
                    Tools.ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = "Menu-" + w.ID.ToString().PadLeft(2, '0');
                    cb.Value = w.ID.ToString();
                    comboBox1.Items.Add(cb);
                }
                DataTable dt = new DataTable("dt");

                dt.Clear();
                dataGridView1.Columns.Clear(); 

                DataColumn dt1= new DataColumn("ID",typeof(string));
                dt.Columns.Add(dt1);
                DataColumn dt2 = new DataColumn("Bar Code", typeof(string));
                dt.Columns.Add(dt2);
                DataColumn dt3 = new DataColumn("Description", typeof(string));
                dt.Columns.Add(dt3);

                var j = from c in m.WH_PLU
                        where c.isMenu == 1
                        orderby c.ID ascending
                        select new
                                   {
                                       c.ID,
                                       c.Bar_Code,
                                       c.Description
                                   };
                foreach (var w in j)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = w.ID;
                    dr[1] = w.Bar_Code;
                    dr[2] = w.Description;
                    dt.Rows.Add(dr);
                }

                dataGridView1.DataSource = dt;

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
               

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MenuID = comboBox1.SelectedIndex + 1;
            using (var m = new Entities())
            {
                var q = (from c in m.WH_Menu
                        where c.ID == MenuID
                        select c).FirstOrDefault();
                tbDesc.Text = q.Description;
                cbIsMode.SelectedIndex = int.Parse(q.isMode.ToString());
                tbPrice.Text = q.Price.ToString();
                cbVat.SelectedIndex = int.Parse(q.isTax.ToString());
                var p = from c in m.WH_Menu_List
                        where c.MenuID == MenuID
                        orderby c.isFlag ascending 
                        select c;
                comboBox3.Items.Clear();
                foreach (var w in p)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.ID;
                    comboBox3.Items.Add(cb);
                }
                comboBox3.SelectedIndex = 0;
            }

        }


        private  void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            foreach (DataGridViewRow  dvr in dataGridView1.SelectedRows)
            {
                DataRow dr = dtt.NewRow();
                dr[0] = dvr.Cells[0].Value.ToString();
                dr[1] = dvr.Cells[1].Value.ToString();
                dr[2] = dvr.Cells[2].Value.ToString();
                dtt.Rows.Add(dr);
            }
            dataGridView2.DataSource = dtt;
            for (int i = 0; i < dtt.Columns.Count; i++)
            {
                dataGridView2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                for (int i = 1; i < 26; i++)
                {
                    for (int j = 1; j < 13; j++)
                    {
                        WH_Menu_List wml = new WH_Menu_List();
                        wml.MenuID = i;
                        wml.Description = "Menu#" + i.ToString().PadLeft(2, '0') + "-Selection#" +
                                          j.ToString().PadLeft(2, '0');
                        wml.isFlag = j;
                        m.AddToWH_Menu_List(wml);
                    }
                }
                m.SaveChanges();
            }
        }
    }
}
