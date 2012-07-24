using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PBMApp.Model;
using PBMApp.Tools;

namespace PBMApp
{
    public partial class frm_payment : Form
    {
        public frm_payment()
        {
            InitializeComponent();
        }
         
        private void frm_payment_Load(object sender, EventArgs e)
        {
            tbPrice.KeyPress += (Tools.Validate.KeyPress);
            tbPrice.KeyUp += (Tools.Validate.Price_KepUp);
            tbHALO.KeyPress += (Tools.Validate.KeyPress);
            FrmLoad();
        }
        private void FrmLoad()
        {
            using (var m = new Entities())
            {
                //payment
                var q = from c in m.WH_Sys_Payment
                        orderby c.isFlag ascending
                        select c;
                int i = 1;
                foreach (var w in q)
                {
                    TextBox tb1 = this.groupBox1.Controls["textBox" + i] as TextBox;
                    tb1.Text = w.Description;
                    TextBox tb2 = this.groupBox1.Controls["textBoxd" + i] as TextBox;
                    tb2.Visible = false;
                    tb2.Text = w.DescriptionBlod;
                    ComboBox cba = this.groupBox1.Controls["comboBoxa" + i] as ComboBox;
                    cba.SelectedIndex = int.Parse(w.ChargeReturn.ToString());
                    ComboBox cbb = this.groupBox1.Controls["comboBoxb" + i] as ComboBox;
                    cbb.SelectedIndex = int.Parse(w.DuplicateNo.ToString());
                    CheckBox ck = this.groupBox1.Controls["checkBox" + i] as CheckBox;
                    ck.Checked = int.Parse(w.isTips.ToString()) == 1;
                    ComboBox cbType = this.groupBox1.Controls["comboBox" + i] as ComboBox;
                    cbType.SelectedIndex = int.Parse(w.TypeID.ToString());
                    i++;
                }
                //Refund
                var q1 = from c in m.WH_Sys_Refund
                         orderby c.isFlag ascending
                         select c;
                int i1 = 1;
                foreach (var w in q1)
                {
                    TextBox tb1 = this.groupBox2.Controls["textBoxa" + i1] as TextBox;
                    tb1.Text = w.Description;
                    TextBox tb2 = this.groupBox2.Controls["textBoxb" + i1] as TextBox;
                    tb2.Text = w.Price.ToString();
                    tb2.KeyPress += new KeyPressEventHandler(Tools.Validate.KeyPress);
                    TextBox tb3 = this.groupBox2.Controls["textBoxc" + i1] as TextBox;
                    tb3.Text = w.HALO.ToString();
                    tb3.KeyPress += new KeyPressEventHandler(Tools.Validate.KeyPress);
                    tb3.MaxLength = 7;
                    i1++;
                }
                //coupon
                var q2 = m.WH_Sys_CouponInformation.First();
                tbPrice.Text = q2.price.ToString();
                tbHALO.Text = q2.HALO.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                //payment 
                for (int j = 1; j < 11; j++)
                {
                    TextBox tb1 = this.groupBox1.Controls["textBox" + j] as TextBox;
                    TextBox tb2 = this.groupBox1.Controls["textBoxd" + j] as TextBox;
                    ComboBox cbb = this.groupBox1.Controls["comboBoxb" + j] as ComboBox;
                    ComboBox cba = this.groupBox1.Controls["comboBoxa" + j] as ComboBox;
                    CheckBox ck = this.groupBox1.Controls["checkBox" + j] as CheckBox;
                    ComboBox cbType = this.groupBox1.Controls["comboBox" + j] as ComboBox; 
                    var w = m.WH_Sys_Payment.FirstOrDefault(x => x.ID == j);
                    w.Description = tb1.Text;
                    w.DescriptionBlod = tb2.Text;
                    w.ChargeReturn = cba.SelectedIndex;
                    w.ChargeReturn_Str = cba.SelectedText;
                    w.DuplicateNo = cbb.SelectedIndex;
                    w.isTips = ck.Checked ? 1 : 0;
                    w.TypeID = cbType.SelectedIndex;
                } 
                //Refund
                for (int i = 1; i < 9; i++)
                {
                    TextBox tb1 = this.groupBox2.Controls["textBoxa" + i] as TextBox;
                    TextBox tb2 = this.groupBox2.Controls["textBoxb" + i] as TextBox;
                    TextBox tb3 = this.groupBox2.Controls["textBoxc" + i] as TextBox;
                    var p = m.WH_Sys_Refund.FirstOrDefault(x => x.ID == i);
                    p.Description = tb1.Text;
                    p.Price = decimal.Parse(tb2.Text);
                    p.HALO = decimal.Parse(tb3.Text);
                }
                 
                //coupon
                var q2 = m.WH_Sys_CouponInformation.First();
                q2.price= decimal.Parse(tbPrice.Text);
                q2.HALO = decimal.Parse(tbHALO.Text);
                m.SaveChanges();
                MessageBox.Show("success！", "alert");
            }
        }

        
        private void tbHALO_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (
                        ((TextBox)sender).Text.Trim().Substring(((TextBox)sender).Text.Trim().IndexOf('.') + 1).Length >=
                        4)
                        e.Handled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_Payment
                        select c;
                foreach (WH_Sys_Payment w in q)
                {
                    w.Description = "";
                    w.ChargeReturn = 0;
                    w.DuplicateNo = 0;
                    w.isTips = 0;
                    w.TypeID = 0;
                }
                var qq = from c in m.WH_Sys_Refund
                         select c;
                foreach (WH_Sys_Refund w in qq)
                {
                    w.Description = "";
                    w.Price = 0;
                    w.HALO = decimal.Parse("9999.99");
                }
                WH_Sys_CouponInformation qqq = m.WH_Sys_CouponInformation.FirstOrDefault();
                qqq.price = 0;
                qqq.HALO = 0;
                m.SaveChanges();
            }
            FrmLoad();
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
                bindData bind = FrmLoad;
                this.Invoke(bind);
            }
            else
            { 
                this.progressBar1.Value = Convert.ToInt32(ipos);
            }
        }
        private void SleepT()
        {

            SendA();
            System.Threading.Thread.Sleep(1100);//没什么意思，单纯的执行延时
            SetTextMessage(30);
            SendB();
            System.Threading.Thread.Sleep(1100);//没什么意思，单纯的执行延时
            SetTextMessage(60);
            SendC();
            System.Threading.Thread.Sleep(1100);//没什么意思，单纯的执行延时
            SetTextMessage(100);
             
        }
        private void SleepR()
        {
            RevA();
            System.Threading.Thread.Sleep(1100);//没什么意思，单纯的执行延时
            SetTextMessage(30);
            RevB();
            System.Threading.Thread.Sleep(1100);//没什么意思，单纯的执行延时
            SetTextMessage(60);
            RevC();
            System.Threading.Thread.Sleep(1100);//没什么意思，单纯的执行延时
            SetTextMessage(100);
        }
        #endregion 

        private void btnSend_Click(object sender, EventArgs e)
        {
            Thread fThread = new Thread(new ThreadStart(SleepT));//开辟一个新的线程 

            fThread.Start();
        }
        private void SendB()
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();
            ReceiveMessage rm = new ReceiveMessage();
            List<List<string>> strs = new List<List<string>>();
            using (var m = new Entities())
            {
                
                var qq = from c in m.WH_Sys_Payment
                         orderby c.ID ascending
                         select c;
                foreach (WH_Sys_Payment w in qq)
                {
                    List<string> s = new List<string>();
                    s.Add(w.ID.ToString());
                    s.Add(w.ChargeReturn.ToString());
                    s.Add(w.DuplicateNo.ToString());
                    s.Add(w.isTips.ToString());
                    s.Add(w.TypeID.ToString());
                    s.Add(w.Description.ToString());
                    strs.Add(s);
                }
                //MessageBox.Show(strs.Count.ToString(), "C");

                rm.GetDownArrayString(pIo, strs, 14, 114);
            }


            pIo.Close();
        }
        private void SendA()
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();
            ReceiveMessage rm = new ReceiveMessage();
            List<List<string>> strs = new List<List<string>>();
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_Refund
                        orderby c.ID ascending
                        select c;
                foreach (WH_Sys_Refund w in q)
                {
                    List<string> s = new List<string>();
                    s.Add(w.ID.ToString());
                    s.Add(w.Price.ToString());
                    s.Add(w.HALO.ToString());
                    s.Add(w.Description.ToString());
                    strs.Add(s);
                }
                rm.GetDownArrayString(pIo, strs, 13, 113);
 
            }
            pIo.Close();
        }
        private void SendC()
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();
            ReceiveMessage rm = new ReceiveMessage();
            List<List<string>> strs = new List<List<string>>();
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_CouponInformation
                        orderby c.ID ascending
                        select c;
                foreach (WH_Sys_CouponInformation w in q)
                {
                    List<string> s = new List<string>();
                    s.Add(w.ID.ToString());
                    s.Add(w.price.ToString());
                    s.Add(w.HALO.ToString()); 
                    strs.Add(s);
                }
                rm.GetDownArrayString(pIo, strs, 12, 112); 
            }
            pIo.Close();
            
        }
        private void btnReceive_Click(object sender, EventArgs e)
        {
            Thread fThread = new Thread(new ThreadStart(SleepR));//开辟一个新的线程 

            fThread.Start(); 
             
        }
        private void RevA()
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();

            ReceiveMessage rm = new ReceiveMessage();

            List<string> strs = new List<string>();
            for (int i = 1; i < 9; i++)
            {
                strs.Add(i.ToString());
            }
            rm.GetUpArrayString(pIo, strs, 13, 113);
            using (var m = new Entities())
            {
                foreach (List<string> str in rm.List)
                {
                    int id = int.Parse(str[0].Substring(str[0].Length - 1, 1));
                    var q = m.WH_Sys_Refund.FirstOrDefault(x => x.ID == id);
                    if (str[1] != null && str[1] != "")
                    {
                        q.Price = decimal.Parse(str[1]);
                    }
                    else
                    {
                        q.Price = 0;
                    }

                    q.HALO = decimal.Parse(str[2]);
                    q.Description = str[3];
                }
                m.SaveChanges();
            }
            pIo.Close();
        }
        private void RevB()
       {
           JustinIO.CommPort pIo = ReceiveMessage.sp();
           pIo.Open();

           ReceiveMessage rm = new ReceiveMessage();

           List<string> strs = new List<string>();
           for (int i = 1; i < 11; i++)
           {
               strs.Add(i.ToString());
           }
           rm.GetUpArrayString(pIo, strs, 14, 114);
           using (var m = new Entities())
           {
               int i = 1;
               foreach (List<string> str in rm.List)
               { 
                   var q = m.WH_Sys_Payment.FirstOrDefault(x => x.ID == i);
                   q.ChargeReturn = int.Parse(str[1]==""?"0":str[1]);
                   q.DuplicateNo = int.Parse(str[2] == "" ? "0" : str[2]);
                   q.isTips = int.Parse(str[3] == "" ? "0" : str[3]);
                   q.TypeID = int.Parse(str[4] == "" ? "0" : str[4]);
                   q.Description = str[5];
                   i++;
               }
               m.SaveChanges();
           }
           pIo.Close();
       }
        private void RevC()
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();
            ReceiveMessage rm = new ReceiveMessage();
            List<string> strs = new List<string>();
            strs.Add("1");
            rm.GetUpArrayString(pIo, strs, 12, 112);
            using (var m = new Entities())
            {
                foreach (List<string> str in rm.List)
                {
                    int id = int.Parse(str[0].Substring(str[0].Length - 1, 1));
                    var q = m.WH_Sys_CouponInformation.FirstOrDefault(x => x.ID == id);
                    q.price = decimal.Parse(str[1] == "" ? "0" : str[1]);
                    q.HALO = decimal.Parse(str[2] == "" ? "0" : str[2]);
                }
                m.SaveChanges();
            }
            pIo.Close();
        } 
    }
}
