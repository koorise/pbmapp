﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        BindingSource bs = new BindingSource();
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int id = e.RowIndex;
            if(id==-1)
            {
                return;
            }
            tbPrice1.KeyPress += (Tools.Validate.KeyPress);
            tbPrice2.KeyPress += (Tools.Validate.KeyPress);
            tbPrice3.KeyPress += (Tools.Validate.KeyPress);
            tbInventory.KeyPress += (Tools.Validate.KeyPress);
            tbInventoryStock.KeyPress += (Tools.Validate.KeyPress);
            tbModifierPrice.KeyPress += (Tools.Validate.KeyPress);
            tbModifierUnitQuantity.KeyPress += (Tools.Validate.KeyPress);
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
                chkMenu.Checked = int.Parse(ctx.isMenu.ToString()) == 1;
                rbPriceMat0.Checked = int.Parse(ctx.PriceMat.ToString()) == 0;
                rbPriceMat1.Checked = int.Parse(ctx.PriceMat.ToString()) == 1;
                rbMode0.Checked = int.Parse(ctx.isMode.ToString()) == 0;
                rbMode1.Checked = int.Parse(ctx.isMode.ToString()) == 1;
                ckCondiment.Checked = int.Parse(ctx.isCondiment.ToString()) == 1;
                chkFS.Checked = int.Parse(ctx.FS_Tenderable.ToString()) == 1;
                chkES.Checked = int.Parse(ctx.ExemptServTax.ToString()) == 1;
                Combox_dept_No(int.Parse(ctx.Dept_No.ToString()));
                Combox_PLU_Modifier(id);
                Combox_Condiment_Selected(id);
                Combox_Condiment_ALL();
                ListBox_Cooking_ALL();
                comboBox1.SelectedIndex = 0;
                ListBox_Cooking_Selected(id,1);


            }
        }
        /// <summary>
        /// 已选口味信息
        /// </summary>
        /// <param name="pluid"></param>
        private void ListBox_Cooking_Selected(int pluid,int isflag)
        {
            listBox2_Cook_Selected.Items.Clear();
            using (var m=new Entities())
            {
                var q = from c in m.WH_Relation_Cook_PLU
                        from b in m.WH_CookInformation
                        where c.PLUID == pluid && c.CookID==b.ID && c.isFlag==isflag
                        select new
                                   {
                                       c.CookID,b.Description
                                   };
                foreach (var w in q)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.CookID;
                    listBox2_Cook_Selected.Items.Add(cb);
                }
            }
        }
        /// <summary>
        /// Cooking MSG all
        /// </summary>
        private void ListBox_Cooking_ALL()
        {
            listbox1_Cook_ALL.Items.Clear();
            using (var m=new Entities())
            {
                var q = from c in m.WH_CookInformation
                        select c;
                foreach (var w in q)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = w.Description;
                    cb.Value = w.ID;
                    listbox1_Cook_ALL.Items.Add(cb);
                }
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
        /// <summary>
        /// 数据绑定
        /// </summary>
        private void BindData()
        {
            DataTable dt = new DataTable("dt");
            dt.Clear();
            dataGridView1.Columns.Clear();
            DataColumn dc1 = new DataColumn("ID", typeof(string));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("Barcode", typeof(string));
            dt.Columns.Add(dc2);
            //DataColumn dc3 = new DataColumn("Description", typeof(string));
            //dt.Columns.Add(dc3);
            //DataColumn dc4 = new DataColumn("Price 1", typeof(string));
            //dt.Columns.Add(dc4);
            //DataColumn dc5 = new DataColumn("Price 2", typeof(string));
            //dt.Columns.Add(dc5);
            //DataColumn dc6 = new DataColumn("Price 3", typeof(string));
            //dt.Columns.Add(dc6); 
            DataColumn dc7 = new DataColumn("Status", typeof(string));
            dt.Columns.Add(dc7);

            var m = new Entities();
            var q = from c in m.WH_PLU
                    orderby c.Bar_Code ascending 
                    select c;
            foreach (WH_PLU c in q)
            {
                DataRow dr = dt.NewRow();
                dr[0] = c.ID;
                dr[1] = c.Bar_Code;
                //dr[2] = c.Description;
                //dr[3] = c.Price1;
                //dr[4] = c.Price2;
                //dr[5] = c.Price3;
                if(c.isStatus==0)
                {
                    dr[2] = "ON";
                }
                else
                {
                    dr[2] = "OFF";
                }
                dt.Rows.Add(dr);
            }


            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            bindingNavigator1.BindingSource = bs;
             

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            groupBox5.Enabled = false;
        }

        private void frm_PLU_Load(object sender, EventArgs e)
        {
            tbBarcode.KeyPress += (Tools.Validate.KeyPressNum);
            tbPrice1.KeyPress += (Tools.Validate.KeyPress);
            tbPrice2.KeyPress += (Tools.Validate.KeyPress);
            tbPrice3.KeyPress += (Tools.Validate.KeyPress);
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
                ctx.FS_Tenderable = chkFS.Checked ? 1 : 0;
                ctx.ExemptServTax = chkES.Checked ? 1 : 0;
                ctx.isMenu = chkMenu.Checked ? 1 : 0;
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
                ctx.isStatus = 0;
                ctx.isCondiment = ckCondiment.Checked ? 1 : 0;
                ctx.isCondimentNums = cbIsCondimentSelectableNum.SelectedIndex;
                var q = m.WH_Relation_PLU_Condiment.Count(x => x.PLUID == id);
                for (int i = 0; i < int.Parse(q.ToString()); i++)
                {
                    WH_Relation_PLU_Condiment wp = m.WH_Relation_PLU_Condiment.FirstOrDefault(x => x.PLUID == id);
                    m.DeleteObject(wp);
                }
            
                foreach (ComboBoxItem cb in listBox2_Condiment.Items)
                {
                    WH_Relation_PLU_Condiment wp=new WH_Relation_PLU_Condiment();
                    wp.PLUID = id;
                    wp.condimentPLUID = int.Parse(cb.Value.ToString());
                    m.AddToWH_Relation_PLU_Condiment(wp);
                    m.SaveChanges();
                }

               
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

        private void button12_Click(object sender, EventArgs e)
        {
            foreach (ComboBoxItem cb in listBox1_Condiment.SelectedItems)
            {
                listBox2_Condiment.Items.Add(cb);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            List<int> ints1= new List<int>();
            foreach (ComboBoxItem cb in listBox2_Condiment.SelectedItems)
            {
                ints1.Add(int.Parse(cb.Value.ToString()));
            }
            List<int> ints=new List<int>();
            for (int i = 0; i < listBox2_Condiment.Items.Count; i++)
            {
                ComboBoxItem cb = (ComboBoxItem) listBox2_Condiment.Items[i];
                if(ints1.Contains(int.Parse(cb.Value.ToString())))
                {
                    ints.Add(i);
                }
            }
            int t = 0;
            foreach (int i in ints)
            {
                int m = i - t;
                listBox2_Condiment.Items.RemoveAt(m);
                t++;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int pluid = int.Parse(tbID.Text);
            using (var m = new Entities())
            {
                foreach (ComboBoxItem cb in listbox1_Cook_ALL.SelectedItems)
                {
                    if (listBox2_Cook_Selected.Items.Count < 6)
                    {
                        listBox2_Cook_Selected.Items.Add(cb);
                        WH_Relation_Cook_PLU wp = new WH_Relation_Cook_PLU();
                        wp.PLUID = pluid;
                        wp.CookID = int.Parse(cb.Value.ToString());
                        wp.isFlag = comboBox1.SelectedIndex + 1;
                        m.AddToWH_Relation_Cook_PLU(wp);
                    }
                }
                m.SaveChanges();
            }
            
             
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<int> ints1 = new List<int>();
            foreach (ComboBoxItem cb in listBox2_Cook_Selected.SelectedItems)
            {
                int pluid = int.Parse(tbID.Text);
                int isFlag = comboBox1.SelectedIndex + 1;
                int cookID = int.Parse(cb.Value.ToString());
                ints1.Add(cookID);
                using (var m = new Entities())
                {
                    WH_Relation_Cook_PLU q = (from c in m.WH_Relation_Cook_PLU
                            where c.PLUID == pluid && c.isFlag == isFlag && c.CookID ==cookID
                            select c).FirstOrDefault();
                    m.DeleteObject(q);
                    m.SaveChanges();
                }
            }
            List<int> ints = new List<int>();
            for (int i = 0; i < listBox2_Cook_Selected.Items.Count; i++)
            {
                ComboBoxItem cb = (ComboBoxItem)listBox2_Cook_Selected.Items[i];
                if (ints1.Contains(int.Parse(cb.Value.ToString())))
                {
                    ints.Add(i);
                }
            }
            int t = 0;
            foreach (int i in ints)
            {
                int m = i - t;
                listBox2_Cook_Selected.Items.RemoveAt(m);
                t++;
            }
        }
         

        private void BindDetail()
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            tbID.Text = id.ToString();
            using (var m = new Entities())
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
                chkFS.Checked = int.Parse(ctx.FS_Tenderable.ToString()) == 1;
                chkES.Checked = int.Parse(ctx.ExemptServTax.ToString()) == 1;
                Combox_dept_No(int.Parse(ctx.Dept_No.ToString()));
                cbIsCondimentSelectableNum.SelectedIndex = int.Parse(ctx.isCondimentNums.ToString());
                Combox_PLU_Modifier(id);
                Combox_Condiment_Selected(id);
                Combox_Condiment_ALL();
                ListBox_Cooking_ALL();
                ListBox_Cooking_Selected(id,1); 
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

        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                int ID = int.Parse((from c in m.WH_PLU
                                    orderby c.ID descending
                                    select c.ID).FirstOrDefault().ToString()) + 1;
                WH_PLU p = new WH_PLU();
                p.Bar_Code = ID.ToString().PadLeft(13, '0');
                p.Description = "PLU#" + p.Bar_Code;
                p.Dept_No = 1;
                p.Price1 = 0;
                p.Price2 = 0;
                p.Price3 = 0;
                p.PriceMat = 0;
                p.isMode = 0;
                p.isMenu = 0;
                p.isCondiment = 0;
                p.FS_Tenderable = 0;
                p.ExemptServTax = 0;
                m.AddToWH_PLU(p);
                m.SaveChanges();
            }
            BindData();
            using (var m = new Entities())
            {
                int index = (from c in m.WH_PLU
                             select c).Count() - 1;
                dataGridView1.Rows[index].Selected = true;
            }
            
            BindDetail();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            using (var m = new Entities())
            {
                var q = m.WH_PLU.FirstOrDefault(x => x.ID == id);
                q.isStatus = 1;
                //m.DeleteObject(q);
                m.SaveChanges();
            }
            BindData();
            BindDetail();
        }

        private void ckCondiment_CheckedChanged(object sender, EventArgs e)
        {
            if(ckCondiment.Checked)
            {
                groupBox6.Enabled = false;
            }
            else
            {
                groupBox6.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pluid = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            ListBox_Cooking_Selected(pluid, comboBox1.SelectedIndex + 1);

        }

        private void ckIsInventoryActive_CheckedChanged(object sender, EventArgs e)
        {
            if(ckIsInventoryActive.Checked)
            {
                groupBox5.Enabled = true;

            }
            else
            {
                groupBox5.Enabled = false;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                for (int i = 1; i < 3001; i++)
                {
                    WH_PLU w = m.WH_PLU.FirstOrDefault(x=>x.ID==i);
                    w.isMode = 0;
                    //w.Bar_Code = i.ToString().PadLeft(13, '0');
                    //w.Price1 = 0;
                    //w.Price2 = 0;
                    //w.Price3 = 0;
                    //w.Dept_No = 1;
                    //w.Description = "";
                    //w.Description2 = "";
                    //w.PriceMat = 0;
                    //w.isMenu = 0;
                    ////w.stock active
                    //w.isCondiment = 0;
                    //w.ExemptServTax = 0;
                    //w.FS_Tenderable = 0;
                    //w.Modifier = 0;
                    //w.isCondimentNums = 0;
                    //w.isStatus = 1;
                    //m.AddToWH_PLU(w);
                }
                m.SaveChanges();
            }
        }

        #region 进度条
        private delegate void SetPos(int ipos);
        private delegate void bindData();
        private void SetTextMessage(int ipos)
        {
            if (this.InvokeRequired)
            {
                SetPos setpos = new SetPos(SetTextMessage);
                this.Invoke(setpos, new object[] { ipos });
                bindData bind = BindData;
                this.Invoke(bind);
            }
            else
            {
                this.label21.Text = ipos.ToString() + "/30000";
                this.progressBar1.Value = Convert.ToInt32(ipos);
            }
        }
         
        private void SleepT()
        { 
            for (int i = 1; i < 101; i++)
            {
                System.Threading.Thread.Sleep(10);//没什么意思，单纯的执行延时
                SetTextMessage(i);
            }
        }
        private void SleepR()
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();
            ReceiveMessage rm = new ReceiveMessage();


            List<List<string>> sList = new List<List<string>>();
            for (int i = 1; i < 30001; i++)
            {
                List<string> strs = new List<string>();
                strs.Add("0");
                strs.Add(i.ToString());
                sList.Add(strs);
                System.Threading.Thread.Sleep(2); 
                SetTextMessage(i);
                
                
            }

            rm.GetUpPLU(pIo, sList, 2, 102); 

            foreach (List<string> str in rm.List)
            {
                foreach (string s in str)
                {
                    richTextBox1.Text += s + "+";
                }
                richTextBox1.Text += "\n";
            } 
            pIo.Close();
             
        }
        #endregion

        private void btnRecieve_Click(object sender, EventArgs e)
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();
            
            pIo.Close(); 
        }
        private List<WH_PLU> list=new List<WH_PLU>();
        private void RevPLU(JustinIO.CommPort pIo,int index)
        {
            ReceiveMessage rm = new ReceiveMessage();
            List<List<string>> sList = new List<List<string>>();
             
            List<string> strs = new List<string>();
            strs.Add("0");
            strs.Add(index.ToString());
            sList.Add(strs); 
            rm.GetUpPLU(pIo, sList, 2, 102); 
            foreach (List<string> str in rm.List)
            {
                if(str.Count<=2)
                {
                    if (index < 30000)
                    {
                        RevPLU(pIo, index + 1);
                    }
                }
                else
                {
                    foreach (string s in str)
                    {
                        WH_PLU w = new WH_PLU();
                        w.ID = index;
                        w.Bar_Code = str[1];
                        list.Add(w);
                    }
                    if(index<30000)
                    {
                        RevPLU(pIo, index + 1);
                    } 
                } 
            }
        } 
    }
}
