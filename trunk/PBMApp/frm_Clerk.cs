using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PBM.DAL;
using SubSonic;
using SubSonic.Linq.Structure;
using SubSonic.Query;
using SubSonic.Repository;

namespace PBMApp
{
    public partial class frm_Clerk : Form
    {
        public frm_Clerk()
        {
            InitializeComponent();
        }

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
                wc.Save();
            }
            else
            {

                WH_Clerk wc = new WH_Clerk(); 
                wc.isNum = tbNo.Text;
                wc.SecretCode = tbSecretCode.Text;
                wc.Description = tbDesc.Text;
                wc.InterruptNo = tbInterrupt.Text;
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
                wc.Limitaions = limit;
                var repo = WH_Clerk.GetRepo().Find(x=>x.Description=="4");
                var qq = repo.SingleOrDefault();
                qq.Description = "AAAAAAA";
                var _repo = new SimpleRepository();
                _repo.Update(qq);
                MessageBox.Show(qq.isNum, "AAA");

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

            var q = from c in WH_Clerk.All()
                    select c;
            foreach (WH_Clerk c in q)
            {
                DataRow dr = dt.NewRow();
                dr[0] = c.isNum;
                dr[1] = c.SecretCode;
                dr[2] = c.Description;
                dr[3] = c.InterruptNo;
                dr[4] = c.Limitaions;
                dt.Rows.Add(dr);
            }

            dataGridView1.DataSource = dt;
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            var q = from c in WH_Clerk.All()
                    where c.isNum == dataGridView1.Rows[rowIndex].Cells[0].Value.ToString()
                    select c;
            foreach (var whClerk in q)
            {
                tbNo.Text = whClerk.isNum;
                tbDesc.Text = whClerk.Description;
                tbSecretCode.Text = whClerk.SecretCode;
                tbInterrupt.Text = whClerk.InterruptNo;
                string limit = whClerk.Limitaions;
                for (int i = 0; i < limit.Length; i++)
                {
                    if (limit.Substring(i, 1) == "1")
                    {
                        chkLimitList.SetItemChecked(i, true);
                    }
                    else
                    {
                        chkLimitList.SetItemChecked(i, false);
                    }
                }
            } 
        }

        
    }
}
