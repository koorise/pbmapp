using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PBMApp.Model;
using PBMApp.Tools;

namespace PBMApp
{
    public partial class frm_Setting_PCASH_FCE : Form
    {
        public frm_Setting_PCASH_FCE()
        {
            InitializeComponent();
        }

        private void frm_Setting_PCASH_FCE_Load(object sender, EventArgs e)
        {
            frm_load();
        }
        public void frm_load()
        {
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_PCASH
                        orderby c.ID ascending
                        select c;
                int i = 1;
                foreach (var w in q)
                {
                    TextBox tb1 = this.groupBox1.Controls["textBoxa" + i] as TextBox;
                    tb1.KeyPress += (Tools.Validate.KeyPress);
                    TextBox tb2 = this.groupBox1.Controls["textBoxb" + i] as TextBox;

                    ComboBox cb1 = this.groupBox1.Controls["comboBox" + i] as ComboBox;
                    cb1.Items.Clear();
                    tb1.Text = w.Rate.ToString();
                    tb2.Text = w.description;
                    Combox_ItemBind(int.Parse(w.LinkPaymentID.ToString()) - 1, cb1);
                    i++;
                }
                int j = 1;
                var qq = from c in m.WH_Sys_FCE
                         orderby c.ID ascending
                         select c;
                foreach (var w in qq)
                {
                    if (j <= 4)
                    {
                        TextBox tb1 = this.groupBox2.Controls["textBoxc" + j] as TextBox;
                        TextBox tb2 = this.groupBox2.Controls["textBoxd" + j] as TextBox;
                        TextBox tb3 = this.groupBox2.Controls["textBoxe" + j] as TextBox;
                        ComboBox cb1 = this.groupBox2.Controls["comboBoxa" + j] as ComboBox;
                        ComboBox cb2 = this.groupBox2.Controls["comboBoxb" + j] as ComboBox;
                        cb2.Items.Clear();
                        ComboBox cbReturn = this.groupBox2.Controls["cbReturn" + j] as ComboBox;
                        tb1.Text = w.Local.ToString();
                        tb2.Text = w.FC.ToString();
                        cb1.SelectedIndex = int.Parse(w.Decimals.ToString());
                        ComboxB_ItemBind(int.Parse(w.SymbolID.ToString()) - 1, cb2);
                        tb3.Text = w.Description.ToString();
                        cbReturn.SelectedIndex = int.Parse(w.isFCE.ToString());
                    }
                    else
                    {
                        break;
                    }
                    j++;
                }
                m.Dispose();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                for (int i = 1; i < 11; i++)
                {
                    TextBox tb1 = this.groupBox1.Controls["textBoxa" + i] as TextBox;
                    TextBox tb2 = this.groupBox1.Controls["textBoxb" + i] as TextBox;
                    ComboBox cb1 = this.groupBox1.Controls["comboBox" + i] as ComboBox;

                    WH_Sys_PCASH w = m.WH_Sys_PCASH.FirstOrDefault(x => x.ID == i);
                    w.Rate = decimal.Parse(tb1.Text);
                    w.description = tb2.Text;
                    w.LinkPaymentID = cb1.SelectedIndex + 1;
                    w.LinkPaymentStr = cb1.SelectedText;
                }
                 
                m.SaveChanges();
                m.Dispose();
                MessageBox.Show("success！", "alert");
            }
            
             
        }

        private void Combox_ItemBind(int sid,ComboBox cb)
        {
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_Payment
                        orderby c.ID ascending
                        select c;
                foreach (var w in q)
                {
                   Tools.ComboBoxItem cc = new ComboBoxItem();
                    cc.Text = w.Description;
                    cc.Value = w.ID;
                    cb.Items.Add(cc);
                }
                cb.SelectedIndex = sid;
                m.Dispose();
            }
        }

        private void ComboxB_ItemBind(int sid, ComboBox cb)
        {
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_Symbols
                        orderby c.ID ascending
                        select c;
                foreach (var w in q)
                {
                    Tools.ComboBoxItem c = new ComboBoxItem();
                    c.Text = w.title;
                    c.Value = w.ID;
                    cb.Items.Add(c);
                }
                cb.SelectedIndex = sid;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            { 
                for (int j = 1; j < 5; j++)
                {
                    TextBox tb1 = this.groupBox2.Controls["textBoxc" + j] as TextBox;
                    TextBox tb2 = this.groupBox2.Controls["textBoxd" + j] as TextBox;
                    TextBox tb3 = this.groupBox2.Controls["textBoxe" + j] as TextBox;
                    ComboBox cb1 = this.groupBox2.Controls["comboBoxa" + j] as ComboBox;
                    ComboBox cb2 = this.groupBox2.Controls["comboBoxb" + j] as ComboBox;
                    ComboBox cbReturn = this.groupBox2.Controls["cbReturn" + j] as ComboBox;
                    WH_Sys_FCE w = m.WH_Sys_FCE.FirstOrDefault(x => x.ID == j);
                    w.Local = decimal.Parse(tb1.Text);
                    w.FC = int.Parse(tb2.Text);
                    w.Decimals = cb1.SelectedIndex;
                    w.SymbolID = cb2.SelectedIndex + 1;
                    w.SymbolStr = cb2.SelectedText;
                    w.Description = tb3.Text;
                    w.isFCE = cbReturn.SelectedIndex;
                }
                m.SaveChanges();
                m.Dispose();
                MessageBox.Show("success！", "alert");
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
                bindData bind = frm_load;
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
            SendA();
            System.Threading.Thread.Sleep(1100);//没什么意思，单纯的执行延时
            SetTextMessage(50);
            SendB();
            System.Threading.Thread.Sleep(1100);//没什么意思，单纯的执行延时
            SetTextMessage(100);
        }
        private void SleepR()
        {
            RevA(); 
            System.Threading.Thread.Sleep(1100);//没什么意思，单纯的执行延时
            SetTextMessage(50);
            RevB();
            System.Threading.Thread.Sleep(1100);//没什么意思，单纯的执行延时
            SetTextMessage(100);
            
        }
        #endregion 

        private void btnReceive_Click(object sender, EventArgs e)
        {
            Thread fThread = new Thread(new ThreadStart(SleepT));//开辟一个新的线程 

            fThread.Start();
        }
        private void RevA()
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();

            ReceiveMessage rm = new ReceiveMessage();

            List<string> strs = new List<string>();
            for (int i = 1; i <= 4; i++)
            {
                strs.Add(i.ToString());
            }
            rm.GetUpArrayString(pIo, strs, 11, 111);
            using (var m = new Entities())
            {
                int count = 0;
                foreach (List<string> str in rm.List)
                {
                    count++;
                    //MessageBox.Show(str[0], "AA");
                    //int id = int.Parse(str[0].Substring(str[0].Length - 1, 1));
                    var q = m.WH_Sys_FCE.FirstOrDefault(x => x.ID == count);
                    string ab = str[1].ToString().PadLeft(3, '0');
                    q.Decimals = int.Parse(ab.Substring(0, 1));
                    q.SymbolID = int.Parse(ab.Substring(1, 1));
                    q.isFCE = int.Parse(ab.Substring(2, 1)) - 1;
                    q.Local = decimal.Parse(str[2] == "" ? "0" : str[2]);
                    q.FC = int.Parse(str[3] == "" ? "0" : str[3]);
                    q.Description = str[4];
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
            for (int i = 1; i <= 10; i++)
            {
                strs.Add(i.ToString());
            }
            rm.GetUpArrayString(pIo, strs, 24, 124);
            using (var m = new Entities())
            {
                int count = 0;
                foreach (List<string> str in rm.List)
                {
                    count++;
                    //MessageBox.Show(str[0], "AA");
                    //int id = int.Parse(str[0].Substring(str[0].Length - 1, 1));
                    var q = m.WH_Sys_PCASH.FirstOrDefault(x => x.ID == count);
                    q.Rate = decimal.Parse(str[1]==""?"0":str[1]);
                    q.LinkPaymentID = int.Parse(str[2] == "" ? "0" : str[2]) + 1;
                    q.description = str[3];
                }
                m.SaveChanges();
            }
            pIo.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Thread fThread = new Thread(new ThreadStart(SleepT));//开辟一个新的线程 

            fThread.Start();
        }
        private void SendA()
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();
            ReceiveMessage rm = new ReceiveMessage();
            List<List<string>> strs = new List<List<string>>();
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_FCE
                        where c.ID <= 4
                        orderby c.ID ascending
                        select c;
                foreach (WH_Sys_FCE w in q)
                {
                    List<string> s = new List<string>();
                    s.Add(w.ID.ToString());
                    s.Add(w.Decimals.ToString() + w.SymbolID.ToString() + (int.Parse(w.isFCE.ToString()) + 1));
                    s.Add(w.Local.ToString());
                    s.Add(w.FC.ToString());
                    s.Add(w.Description.ToString());
                    strs.Add(s);
                }
            }
            rm.GetDownArrayString(pIo, strs, 11, 111);
            pIo.Close(); 
        }
        private void SendB()
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();
            ReceiveMessage rm = new ReceiveMessage();
            List<List<string>> strs = new List<List<string>>();
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_PCASH 
                        orderby c.ID ascending
                        select c;
                foreach (WH_Sys_PCASH w in q)
                {
                    List<string> s = new List<string>();
                    s.Add(w.ID.ToString());
                    s.Add(w.Rate.ToString());
                    s.Add((w.LinkPaymentID-1).ToString());
                    s.Add(w.description);
                    strs.Add(s);
                }
            }
            rm.GetDownArrayString(pIo, strs, 24, 124);
            pIo.Close();
        }
    }
}
