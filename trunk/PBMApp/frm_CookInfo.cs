using System;
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
    public partial class frm_CookInfo : Form
    {
        public frm_CookInfo()
        {
            InitializeComponent();
        }
        BindingSource bs = new BindingSource();
        private void frm_CookInfo_Load(object sender, EventArgs e)
        {
            tbPrice.KeyPress += (Tools.Validate.KeyPress);
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
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            this.bindingNavigator1.BindingSource = bs;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int  i= e.RowIndex;
            if (i == -1)
            {
                return;
            }
            int id = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
            using (var m=new Entities())
            {
                var ctx = m.WH_CookInformation.FirstOrDefault(x => x.ID == id);
                tbDesc.Text = ctx.Description;
                tbNo.Text = ctx.ID.ToString();
                tbPrice.Text = ctx.price.ToString();

            }
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

         

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

            BindDetail();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            using (var m = new Entities())
            {
                var ctx = m.WH_CookInformation.FirstOrDefault(x => x.ID == id);
                m.DeleteObject(ctx);
                m.SaveChanges();
            }
            BindData();
        }

        private void BindDetail()
        {
            int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            using (var m = new Entities())
            {
                var ctx = m.WH_CookInformation.FirstOrDefault(x => x.ID == id);
                tbDesc.Text = ctx.Description;
                tbNo.Text = ctx.ID.ToString();
                tbPrice.Text = ctx.price.ToString();

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
                //this.label1.Text = ipos.ToString() + "/100";
                this.progressBar1.Value = Convert.ToInt32(ipos);
            }
        }
        private void SleepT()
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();
            ReceiveMessage rm = new ReceiveMessage();
            List<List<string>> strs = new List<List<string>>();
            using (var m = new Entities())
            {
                var q = from c in m.WH_CookInformation
                        orderby c.ID ascending
                        select c;
                foreach (WH_CookInformation w in q)
                {
                    List<string> s = new List<string>();
                    s.Add(w.ID.ToString());
                    s.Add(w.price.ToString().Replace(".", ""));
                    s.Add(w.Description.ToString());
                    //s.Add(w.Description.ToString());
                    strs.Add(s);
                }
            }
            rm.GetDownArrayString(pIo, strs, 8, 108);
            pIo.Close();
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

            List<string> strs = new List<string>();
            for (int i = 1; i < 9; i++)
            {
                strs.Add(i.ToString());
            }
            rm.GetUpArrayString(pIo, strs, 8, 108);
            using (var m = new Entities())
            {
                int count = 0;
                foreach (List<string> str in rm.List)
                {
                    count++;
                    //MessageBox.Show(str[0], "AA");

                    var q = m.WH_CookInformation.FirstOrDefault(x => x.ID == count);
                    if (str[1] != null && str[1] != "")
                    {
                        q.price = decimal.Parse(str[1]);
                    }
                    else
                    {
                        q.price = 0;
                    }
                    q.Description = str[2];
                }
                m.SaveChanges();
            }
            pIo.Close();
            for (int i = 1; i < 101; i++)
            { 
                System.Threading.Thread.Sleep(5);//没什么意思，单纯的执行延时
                SetTextMessage(i);
            }
        }
        #endregion 
        private void btnReset_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = from c in m.WH_CookInformation
                        select c;
                foreach (var w in q)
                {
                    w.Description = "CookMsg" + w.ID.ToString().PadLeft(3, '0');
                    w.price = 0;
                }
                m.SaveChanges();
            }
            BindData();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Thread fThread = new Thread(new ThreadStart(SleepT));//开辟一个新的线程 

            fThread.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread fThread = new Thread(new ThreadStart(SleepR));//开辟一个新的线程 

            fThread.Start();
            BindData();
        }
        
    }
}
