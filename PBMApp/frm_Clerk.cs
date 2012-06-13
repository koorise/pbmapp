using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
 
using PBMApp.Model;
 
namespace PBMApp
{
    public partial class frm_Clerk : Form
    {
        public frm_Clerk()
        {
            InitializeComponent();
        }
        BindingSource bs = new BindingSource();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(ckAll.Checked)
            {
                for (int i = 0; i < chkLimitList.Items.Count; i++)
                {
                    chkLimitList.SetItemChecked(i,true);
                }
            }
            else
            {
                for (int i = 0; i < chkLimitList.Items.Count; i++)
                {
                    chkLimitList.SetItemChecked(i, false);
                }
            }
        }

        private   void button3_Click(object sender, EventArgs e)
        {
            var m = new Entities();
            if(dataGridView1.SelectedRows.Count==0)
            {
                WH_Clerk wc  = new WH_Clerk();
                wc.isNum = tbNo.Text;
                wc.SecretCode = tbSecretCode.Text;
                wc.Description = tbDesc.Text;
                wc.InterruptNo = tbInterrupt.Text;
                string limit = "";
                for (int i = 0; i < chkLimitList.Items.Count; i++)
                {
                    if(chkLimitList.GetItemChecked(i))
                    {
                        limit += "1";
                    }
                    else
                    {
                        limit += "0";
                    }
                }
                wc.Limitaions = limit;
                m.AddToWH_Clerk(wc);
                m.SaveChanges();
            }
            else
            { 
                string limit = "";
                for (int i = 0; i < chkLimitList.Items.Count; i++)
                {
                    if (chkLimitList.GetItemChecked(i))
                    {
                        limit += "1";
                    }
                    else
                    {
                        limit += "0";
                    }
                }

                int id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
                var ctx =
                    m.WH_Clerk.First(
                        x =>
                        x.ID == id);
                ctx.InterruptNo = tbInterrupt.Text;
                ctx.Limitaions = limit;
                ctx.Description = tbDesc.Text;
                ctx.SecretCode = tbSecretCode.Text;
                ctx.isNum = tbNo.Text;
                m.SaveChanges();

            }

            BindData();
        }

        private void frm_Clerk_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            DataTable dt = new DataTable("dt");
            dt.Clear();
            dataGridView1.Columns.Clear();
            DataColumn dc0 = new DataColumn("ID", typeof(string));
             
            dt.Columns.Add(dc0);
            DataColumn dc1 = new DataColumn("No.", typeof(string)); 
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("Secret Code", typeof(string));
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn("Description", typeof(string));
            dt.Columns.Add(dc3);
            DataColumn dc4 = new DataColumn("Interrupt No.", typeof(string));
            dt.Columns.Add(dc4);
            DataColumn dc5 = new DataColumn("Limitaions", typeof(string));
            dt.Columns.Add(dc5);


            var m = new Entities();
            var q = from c in m.WH_Clerk
                    
                    select c;
            foreach (WH_Clerk c in q)
            {
                DataRow dr = dt.NewRow();
                dr[0] = c.ID;
                dr[1] = c.isNum;
                dr[2] = c.SecretCode;
                dr[3] = c.Description;
                dr[4] = c.InterruptNo;
                dr[5] = c.Limitaions;
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
            if(id==50)
            {
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = true;
            }
            var ctx = new Entities();
            var clerk = ctx.WH_Clerk.First(x => x.ID == id);
            tbDesc.Text = clerk.Description;
            tbInterrupt.Text = clerk.InterruptNo;
            tbNo.Text = clerk.isNum;
            tbSecretCode.Text = clerk.SecretCode;
            for (int i = 0; i < clerk.Limitaions.Length; i++)
            {

                if (clerk.Limitaions.Substring(i, 1)=="0")
                {
                    chkLimitList.SetItemChecked(i, false); 
                }
                else
                {
                    chkLimitList.SetItemChecked(i, true);
                }
                
            }


        }

         

        private void tbSecretCode_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbInterrupt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            BindDetail();
        }
        private void BindDetail()
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            if (id == 50)
            {
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = true;
            }
            var ctx = new Entities();
            var clerk = ctx.WH_Clerk.First(x => x.ID == id);
            tbDesc.Text = clerk.Description;
            tbInterrupt.Text = clerk.InterruptNo;
            tbNo.Text = clerk.isNum;
            tbSecretCode.Text = clerk.SecretCode;
            for (int i = 0; i < clerk.Limitaions.Length; i++)
            {

                if (clerk.Limitaions.Substring(i, 1) == "0")
                {
                    chkLimitList.SetItemChecked(i, false);
                }
                else
                {
                    chkLimitList.SetItemChecked(i, true);
                }

            }
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

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    for (int i = 7; i <= 50; i++)
        //    {
        //        using (var m=new pbmEntities() )
        //        {
        //            WH_Clerk wh= new WH_Clerk();
        //            wh.isNum = "Clerk" + i.ToString().PadLeft(3, '0');
        //            wh.SecretCode = "000";
        //            wh.Description="Clerk" + i.ToString().PadLeft(3, '0');
        //            wh.Limitaions = "11111111111111111";
        //            wh.InterruptNo = "12345";
        //            m.AddToWH_Clerk(wh);
        //            m.SaveChanges();
        //        }
        //    }
        //}

        
    }
}
