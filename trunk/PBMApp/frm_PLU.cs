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
    public partial class frm_PLU : Form
    {
        public frm_PLU()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
             
        }

        private void button5_Click(object sender, EventArgs e)
        {
             
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            id = int.Parse(dataGridView1.Rows[id].Cells[0].Value.ToString());
            tbID.Text = id.ToString();
            using (var m=new Entities())
            {
                var ctx = m.WH_PLU.FirstOrDefault(x => x.ID == id);
                tbBarcode.Text = ctx.Bar_Code;
                tbDesc.Text = ctx.Description;
                tbPrice1.Text = ctx.Price1.ToString();
                tbPrice2.Text = ctx.Price2.ToString();
                tbPrice3.Text = ctx.Price3.ToString();
                rbPriceMat0.Checked = int.Parse(ctx.PriceMat.ToString()) == 0;
                rbPriceMat1.Checked = int.Parse(ctx.PriceMat.ToString()) == 1;
                rbMode0.Checked = int.Parse(ctx.isMode.ToString()) == 0;
                rbMode1.Checked = int.Parse(ctx.isMode.ToString()) == 1;
                ckCondiment.Checked = int.Parse(ctx.isCondiment.ToString()) == 1;
                
                Combox_dept_No(int.Parse(ctx.Dept_No.ToString()));
                Combox_PLU_Modifier(id);
                Combox_Condiment_Selected(id);
                Combox_Condiment_ALL();


            }
        }
        /// <summary>
        /// Condiment_Selected
        /// </summary>
        /// <param name="pluid"></param>
        private void Combox_Condiment_Selected(int pluid)
        {
            listBox2_Condiment.Items.Clear();
            using (var m = new Entities())
            {
                var q = from c in m.WH_Relation_PLU_Condiment
                        from b in m.WH_PLU
                        where c.PLUID == pluid && c.condimentPLUID ==b.ID
                        select new
                                   {
                                       c.condimentPLUID ,
                                       b.Description
                                   };
                foreach (var w in q)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.condimentPLUID;
                    listBox2_Condiment.Items.Add(cb);
                }
            }
            tbModifierDesc.Text = "";
            tbModifierPrice.Text = "";
            tbModifierUnitQuantity.Text = "";

        }
        /// <summary>
        /// Condiment_ALL
        /// </summary>
        private void Combox_Condiment_ALL()
        {
            listBox1_Condiment.Items.Clear();
            using (var m=new Entities())
            {
                var q = from c in m.WH_PLU
                        where c.isCondiment == 1
                        select c;
                foreach (var w in q)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.ID;
                    listBox1_Condiment.Items.Add(cb);
                }

            }
        }

        /// <summary>
        /// Modifer更新
        /// </summary>
        /// <param name="PLUID"></param>
        private void Combox_PLU_Modifier(int PLUID)
        {
            cbModifiers.Items.Clear();
            using (var m=new Entities())
            {
                var q = from c in m.WH_PLU_Modifier
                        where c.PLUID == PLUID
                        select c;
                int i = 1;
                foreach (var w in q)
                {
                    ComboBoxItem cb=new ComboBoxItem();
                    cb.Text = i.ToString();
                    cb.Value = w.ID;
                    cbModifiers.Items.Add(cb);
                    i++;
                }
            }
        }
        /// <summary>
        /// 部门更新
        /// </summary>
        /// <param name="deptid"></param>
        private void Combox_dept_No(int deptid)
        {
            using (var m=new Entities())
            {
                var q = from c in m.WH_Department
                        select c;
                int i = 0;
                foreach (var w in q)
                {
                    Tools.ComboBoxItem combo = new ComboBoxItem();
                    combo.Text = w.Description;
                    combo.Value = w.ID;
                    cbDeptID.Items.Add(combo);
                    if(w.ID==deptid)
                    {
                        cbDeptID.SelectedIndex = i;  
                    }
                    i++;
                }
            }
        }
        private void BindData()
        {
            DataTable dt = new DataTable("dt");
            dt.Clear();
            dataGridView1.Columns.Clear();
            DataColumn dc1 = new DataColumn("ID", typeof(string));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("Barcode", typeof(string));
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn("Description", typeof(string));
            dt.Columns.Add(dc3);
            DataColumn dc4 = new DataColumn("Price 1", typeof(string));
            dt.Columns.Add(dc4);
            DataColumn dc5 = new DataColumn("Price 2", typeof(string));
            dt.Columns.Add(dc5);
            DataColumn dc6 = new DataColumn("Price 3", typeof(string));
            dt.Columns.Add(dc6); 


            var m = new Entities();
            var q = from c in m.WH_PLU
                    select c;
            foreach (WH_PLU c in q)
            {
                DataRow dr = dt.NewRow();
                dr[0] = c.ID;
                dr[1] = c.Bar_Code;
                dr[2] = c.Description;
                dr[3] = c.Price1;
                dr[4] = c.Price2;
                dr[5] = c.Price3;
                dt.Rows.Add(dr);
            }

            dataGridView1.DataSource = dt;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }

        private void frm_PLU_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tbID.Text);
            using (var m = new Entities())
            {
                var ctx = m.WH_PLU.FirstOrDefault(x => x.ID == id);
                ctx.Bar_Code = tbBarcode.Text.PadLeft(13,'0');
                ctx.Description = tbDesc.Text;
                ctx.Dept_No = int.Parse(((ComboBoxItem) cbDeptID.SelectedItem).Value.ToString());
                ctx.Price1 = decimal.Parse(tbPrice1.Text);
                ctx.Price2 = decimal.Parse(tbPrice2.Text);
                ctx.Price3 = decimal.Parse(tbPrice3.Text);
                if(rbPriceMat0.Checked)
                {
                    ctx.PriceMat = 0;
                }
                if(rbPriceMat1.Checked)
                {
                    ctx.PriceMat = 1;
                }
                if(rbMode0.Checked)
                {
                    ctx.isMode = 0;
                }
                if(rbPriceMat1.Checked)
                {
                    ctx.isMode = 1;
                }
                ctx.isCondiment = ckCondiment.Checked ? 1 : 0;
                m.SaveChanges();
            }
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var m=new Entities())
            {
                WH_PLU_Modifier wp=new WH_PLU_Modifier();
                wp.PLUID = int.Parse(tbID.Text);
                wp.Modifier_Price = decimal.Parse(tbModifierPrice.Text);
                wp.Modifier_desc = tbModifierDesc.Text;
                wp.Modifier_Unit_Quantity = int.Parse(tbModifierUnitQuantity.Text);
                m.AddToWH_PLU_Modifier(wp);
                m.SaveChanges();
            }
            Combox_PLU_Modifier(int.Parse(tbID.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                int id = int.Parse(((ComboBoxItem) cbModifiers.SelectedItem).Value.ToString());
                WH_PLU_Modifier wp = m.WH_PLU_Modifier.FirstOrDefault(x => x.ID == id);
                m.DeleteObject(wp);
                m.SaveChanges();
            }
            Combox_PLU_Modifier(int.Parse(tbID.Text));
        }

        private void cbModifiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                int id = int.Parse(((ComboBoxItem)cbModifiers.SelectedItem).Value.ToString());
                WH_PLU_Modifier wp = m.WH_PLU_Modifier.FirstOrDefault(x => x.ID == id);
                tbModifierDesc.Text = wp.Modifier_desc;
                tbModifierPrice.Text = wp.Modifier_Price.ToString();
                tbModifierUnitQuantity.Text = wp.Modifier_Unit_Quantity.ToString();
                
            }
        }

    }
}
