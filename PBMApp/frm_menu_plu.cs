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
        
        private void frm_menu_plu_Load(object sender, EventArgs e)
        { 
            using (var m = new Entities())
            {
                var menus = from c in m.WH_Menu
                        orderby c.ID ascending 
                        select c;
                foreach (var w in menus)
                {
                    Tools.ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.ID.ToString();
                    comboBox1.Items.Add(cb);
                }
                DataTable dataTable = new DataTable("dt");

                dataTable.Clear();
                dataGridView1.Columns.Clear(); 

                DataColumn dt1= new DataColumn("ID",typeof(string));
                dataTable.Columns.Add(dt1);
                DataColumn dt2 = new DataColumn("Bar Code", typeof(string));
                dataTable.Columns.Add(dt2);
                DataColumn dt3 = new DataColumn("Description", typeof(string));
                dataTable.Columns.Add(dt3);

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
                    DataRow dr = dataTable.NewRow();
                    dr[0] = w.ID;
                    dr[1] = w.Bar_Code;
                    dr[2] = w.Description;
                    dataTable.Rows.Add(dr);
                }

                dataGridView1.DataSource = dataTable;

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                dataGridView1.Enabled = false;
                dataGridView2.Enabled = false;
                if (cbIsMode.SelectedIndex == 1)
                {
                    panel1.Enabled = true;
                }
                else
                {
                    panel1.Enabled = false;
                }
                //系统税表
                var q = (from c in m.WH_Sys_PageFour
                         orderby c.ID descending
                         select c.TaxSystem_index).FirstOrDefault();
               
                switch (int.Parse(q.Value.ToString()))
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    default:
                        break;
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
                numMember.Value = decimal.Parse(q.isCount.ToString());
                //var whMenuLists = from c in m.WH_Menu_List
                //        where c.MenuID == MenuID
                //        orderby c.isFlag ascending 
                //        select c;
                //cbMenuSelection.Items.Clear();
                //foreach (var w in whMenuLists)
                //{
                //    ComboBoxItem cb = new ComboBoxItem();
                //    cb.Text = w.Description;
                //    cb.Value = w.ID;
                //    cbMenuSelection.Items.Add(cb);
                //}
                //cbMenuSelection.SelectedIndex = 0;

                Dgv2_DataBind();

            }
            
            dataGridView1.Enabled = true;
            dataGridView2.Enabled = true;

        }

        private  void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            using (var m = new Entities())
            {
                foreach (DataGridViewRow dvr in dataGridView1.SelectedRows)
                {
                    int pluid = int.Parse(dvr.Cells[0].Value.ToString());
                    int MenuListID = int.Parse(((ComboBoxItem)cbMenuSelection.SelectedItem).Value.ToString());
                    int MenuID = comboBox1.SelectedIndex + 1;
                    var q = from c in m.WH_Menu_Details
                            where c.MenuID == MenuID && c.MenuListID == MenuListID
                            orderby c.isFlag descending 
                            select c.isFlag;
                    int isFlag = 1;
                    if(q.Count()>=18)
                    {
                        MessageBox.Show("Less than 18 PLUs setting", "alert");
                        
                        return;
                    }
                    if(q.FirstOrDefault()!=null)
                    {
                        isFlag = int.Parse(q.FirstOrDefault().Value.ToString()) + 1;
                    }
                   
                    WH_Menu_Details w = new WH_Menu_Details();
                    w.MenuID = MenuID;
                    w.MenuListID = MenuListID;
                    w.isFlag = isFlag;
                    w.PLUID = pluid;
                    w.KeyPosition = 0;
                    m.AddToWH_Menu_Details(w);
                }
                m.SaveChanges();
            }
            Dgv2_DataBind();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var ctx = m.WH_Menu.FirstOrDefault(x => x.ID == (comboBox1.SelectedIndex + 1));
                ctx.isMode = cbIsMode.SelectedIndex;
                ctx.Price = decimal.Parse(tbPrice.Text);
                ctx.Description = tbDesc.Text;
                ctx.isTax = cbVat.SelectedIndex;
                ctx.isCount = int.Parse(numMember.Value.ToString());
                m.SaveChanges();
                if(cbIsMode.SelectedIndex==1)
                {
                    panel1.Enabled = true;
                }
                else
                {
                    panel1.Enabled = false;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dgv2_DataBind();
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            using (var m = new Entities())
            {
                int MenuDetailsID = int.Parse(dataGridView2.SelectedRows[0].Cells[0].Value.ToString());
                var q = m.WH_Menu_Details.FirstOrDefault(x => x.ID == MenuDetailsID);
                int delFlag = int.Parse(q.isFlag.ToString());
                m.DeleteObject(q);
                m.SaveChanges();
                var p = from c in m.WH_Menu_Details
                        where c.isFlag > delFlag
                        select c;
                foreach (var w in p)
                {
                    w.isFlag = w.isFlag - 1;
                }
                m.SaveChanges();
            }
            Dgv2_DataBind();
        }

        private void Dgv2_DataBind()
        {
            DataTable dtt = new DataTable("dtt");
            dtt.Clear();
            dataGridView2.Columns.Clear();
            DataColumn dt11 = new DataColumn("ID", typeof(string));
            dtt.Columns.Add(dt11);
            DataColumn dt55 = new DataColumn("No.", typeof(string));
            dtt.Columns.Add(dt55);
            DataColumn dt22 = new DataColumn("Bar Code", typeof(string));
            dtt.Columns.Add(dt22);
            DataColumn dt33 = new DataColumn("Description", typeof(string));
            dtt.Columns.Add(dt33); 

            using (var m = new Entities())
            {
                int MenuListID = int.Parse(((ComboBoxItem)cbMenuSelection.SelectedItem).Value.ToString());
                var r = from c in m.WH_Menu_Details
                        from b in m.WH_Menu_List
                        from d in m.WH_Menu
                        from f in m.WH_PLU
                        where c.MenuID == comboBox1.SelectedIndex + 1 && c.MenuListID == MenuListID
                              && c.MenuID == d.ID && c.MenuListID == b.ID && f.ID == c.PLUID
                        select new
                        {
                            c.ID,
                            c.isFlag,
                            f.Bar_Code,
                            f.Description,
                            c.KeyPosition
                        }; 
                foreach (var w in r)
                {
                    DataRow dr = dtt.NewRow();
                    dr[0] = w.ID;
                    dr[1] = w.isFlag;
                    dr[2] = w.Bar_Code;
                    dr[3] = w.Description; 
                    dtt.Rows.Add(dr); 
                }
            }
            dataGridView2.DataSource = dtt;
            for (int i = 0; i < dtt.Columns.Count; i++)
            {
                dataGridView2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int MenuID = comboBox1.SelectedIndex + 1;

            using (var m = new Entities())
            {
                int index = cbMenuSelection.SelectedIndex;
                int MenuListID = int.Parse(((ComboBoxItem)cbMenuSelection.SelectedItem).Value.ToString());
                var q = m.WH_Menu_List.FirstOrDefault(x => x.ID == MenuListID);
                q.Description = textBox3.Text;
                m.SaveChanges();

                var p = from c in m.WH_Menu_List
                        where c.MenuID == MenuID
                        orderby c.isFlag ascending
                        select c;
                cbMenuSelection.Items.Clear();
                foreach (var w in p)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.ID;
                    cbMenuSelection.Items.Add(cb);
                }
                cbMenuSelection.SelectedIndex = index;
                textBox3.Text = "";
            }
        }

        private void cbIsMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            int MenuID = comboBox1.SelectedIndex + 1;
            using (var m = new Entities())
            {
                var q = (from c in m.WH_Menu
                         where c.ID == MenuID
                         select c).FirstOrDefault();
                tbDesc.Text = q.Description;
                //cbIsMode.SelectedIndex = int.Parse(q.isMode.ToString());
                if (cbIsMode.SelectedIndex == 1)
                {
                    panel1.Enabled = true ;
                }
                else
                {
                    panel1.Enabled = false;
                }
                tbPrice.Text = q.Price.ToString();
                cbVat.SelectedIndex = int.Parse(q.isTax.ToString());
                var p = from c in m.WH_Menu_List
                        where c.MenuID == MenuID
                        orderby c.isFlag ascending
                        select c;
                cbMenuSelection.Items.Clear();
                foreach (var w in p)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.ID;
                    cbMenuSelection.Items.Add(cb);
                }
                cbMenuSelection.SelectedIndex = 0;

                Dgv2_DataBind();

            }

            dataGridView1.Enabled = true;
            dataGridView2.Enabled = true;
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >= 4)
                        e.Handled = true;
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int MenuID = comboBox1.SelectedIndex + 1;
            using (var m = new Entities())
            {
                var whMenuLists = from c in m.WH_Menu_List
                                  where c.MenuID == MenuID && c.isFlag<=numMember.Value
                                  orderby c.isFlag ascending
                                  select c;
                cbMenuSelection.Items.Clear();
                
                foreach (var w in whMenuLists)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.ID;
                    cbMenuSelection.Items.Add(cb);
                }
                cbMenuSelection.SelectedIndex = 0;
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = m.WH_Menu;
                foreach (var w in q)
                {
                    w.Description = "Menu#" + w.ID.ToString().PadLeft(2, '0');
                    w.isMode = 0;
                    w.Price = 0;
                    w.isTax = 0;
                    w.isCount = 12;
                }
                var qq = m.WH_Menu_List;
                foreach (var w in qq)
                {
                    w.Description = "Menu#" + w.MenuID.ToString().PadLeft(2, '0') + "-Selection#" +
                                    w.isFlag.ToString().PadLeft(2, '0');
                }
                var qqq = m.WH_Menu_Details;
                foreach (var w in qqq)
                {
                    m.DeleteObject(w);
                }
                m.SaveChanges();
                comboBox1.SelectedIndex = 0;
                MessageBox.Show("Success", "Alert");
            }
        }
    }
}
