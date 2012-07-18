using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PBMApp.Model;
using PBMApp.Tools;

namespace PBMApp
{
    public partial class frm_Setting_Port_KP : Form
    {
        public frm_Setting_Port_KP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                for (int i = 1; i <= 5; i++)
                {
                    WH_Sys_Port qq = m.WH_Sys_Port.FirstOrDefault(x => x.ID == i);
                    var cb = groupBox1.Controls["a" + i] as ComboBox;
                    qq.PortIndex = cb.SelectedIndex;
                    qq.Port = cb.SelectedText;
                    var cbb = groupBox1.Controls["b" + i] as ComboBox;
                    qq.BaudIndex = cbb.SelectedIndex;
                    qq.BaudRate = cbb.SelectedText;
                }
                WH_Sys_RP q = m.WH_Sys_RP.FirstOrDefault();
                q.DeviceIndex = cbRP.SelectedIndex;
                q.Device = cbRP.SelectedText;

                for (int count = 1; count < 14; count++)
                {
                    WH_Sys_KP whSysKp = m.WH_Sys_KP.FirstOrDefault(x => x.ID == count);
                    var cb = groupBox3.Controls["cb" + count] as ComboBox;
                    whSysKp.TypeIndex = cb.SelectedIndex;
                    var hBox = groupBox3.Controls["headfeed" + count] as TextBox;
                    whSysKp.HeadFeed = int.Parse(hBox.Text);
                    var fBox = groupBox3.Controls["footfeed" + count] as TextBox;
                    whSysKp.FootFeed = int.Parse(fBox.Text);
                    var ck = groupBox3.Controls["ck" + count] as CheckBox;
                    whSysKp.isCutPaper = ck.Checked ? 1 : 0;
                    var ipBox = groupBox3.Controls["ip" + count] as TextBox;
                    whSysKp.IP_Addr = ipBox.Text;
                    var portBox = groupBox3.Controls["port" + count] as TextBox;
                    whSysKp.Port = int.Parse(portBox.Text);
                }

                m.SaveChanges();

                MessageBox.Show("success", "alert");
            }
        }

        private void frm_Setting_Port_KP_Load(object sender, EventArgs e)
        {
            #region 控件初始化

            int y = 40;
            int x = 20;
            for (int i = 1; i < 14; i++)
            {
                var p = new Point(x, y);
                var s = new Size(50, 21);
                var t = new TextBox();
                t.Location = p;
                t.Size = s;
                t.Name = "kp" + i;
                t.ReadOnly = true;
                t.Text = "KP" + i;
                groupBox3.Controls.Add(t);
                y += 26;
            }
            x = 20 + 60;
            y = 40;
            for (int i = 1; i < 14; i++)
            {
                var p = new Point(x, y);
                var s = new Size(90, 21);
                var comboBox = new ComboBox();
                comboBox.Location = p;
                comboBox.Size = s;
                comboBox.Name = "cb" + i;
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Items.Add("TM-88III");
                comboBox.Items.Add("TM-U220");
                comboBox.Items.Add("58mm printer");
                comboBox.Items.Add("80mm printer");
                groupBox3.Controls.Add(comboBox);
                y += 26;
            }
            x = 80 + 100;
            y = 40;
            for (int i = 1; i < 14; i++)
            {
                var p = new Point(x, y);
                var s = new Size(80, 21);
                var t = new TextBox();
                t.Location = p;
                t.Size = s;
                t.MaxLength = 2;
                t.Name = "headfeed" + i;
                t.KeyPress += (Tools.Validate.KeyPressNum);
                //t.ReadOnly = true;
                //t.Text = "KP" + i;
                groupBox3.Controls.Add(t);
                y += 26;
            }
            x = 180 + 90;
            y = 40;
            for (int i = 1; i < 14; i++)
            {
                var p = new Point(x, y);
                var s = new Size(80, 21);
                var t = new TextBox();
                t.Location = p;
                t.Size = s;
                t.MaxLength = 2;
                t.KeyPress += (Tools.Validate.KeyPressNum);
                t.Name = "footfeed" + i;
                //t.ReadOnly = true;
                //t.Text = "KP" + i;
                groupBox3.Controls.Add(t);
                y += 26;
            }
            x = 360;
            y = 40;
            for (int i = 1; i < 14; i++)
            {
                var p = new Point(x, y);
                var s = new Size(80, 21);
                var t = new CheckBox();
                t.Location = p;
                t.Size = s;
                t.Name = "ck" + i;
                t.Text = "Cut Paper";
                //t.ReadOnly = true;
                //t.Text = "KP" + i;
                groupBox3.Controls.Add(t);
                y += 26;
            }
            x = 450;
            y = 40;
            for (int i = 1; i < 14; i++)
            {
                var p = new Point(x, y);
                var s = new Size(80, 21);
                var t = new TextBox();
                t.Location = p;
                t.Size = s;
                t.MaxLength = 15;
                //t.KeyPress += (Tools.Validate.KeyPress);
                t.Name = "ip" + i;
                //t.ReadOnly = true;
                //t.Text = "KP" + i;
                if (i <= 5)
                {
                    t.Visible = false;
                }
                groupBox3.Controls.Add(t);
                y += 26;
            }
            x = 540;
            y = 40;
            for (int i = 1; i < 14; i++)
            {
                var p = new Point(x, y);
                var s = new Size(80, 21);
                var t = new TextBox();
                t.Location = p;
                t.Size = s;
                t.Name = "port" + i;
                t.MaxLength = 4;
                t.KeyPress += (Tools.Validate.KeyPressNum);
                //t.ReadOnly = true;
                //t.Text = "KP" + i;
                if (i <= 5)
                {
                    t.Visible = false;
                }
                groupBox3.Controls.Add(t);
                y += 26;
            }

            #endregion

            using (var m = new Entities())
            {
                IOrderedQueryable<WH_Sys_Port> q = from c in m.WH_Sys_Port
                                                   orderby c.ID ascending
                                                   select c;
                int i = 1;
                foreach (WH_Sys_Port qq in q)
                {
                    var cb = groupBox1.Controls["a" + i] as ComboBox;
                    cb.SelectedIndex = int.Parse(qq.PortIndex.ToString());
                    var cbb = groupBox1.Controls["b" + i] as ComboBox;
                    cbb.SelectedIndex = int.Parse(qq.BaudIndex.ToString());
                    i++;
                }

                WH_Sys_RP o = m.WH_Sys_RP.FirstOrDefault();
                cbRP.SelectedIndex = int.Parse(o.DeviceIndex.ToString());


                IOrderedQueryable<WH_Sys_KP> qqq = from c in m.WH_Sys_KP
                                                   orderby c.ID ascending
                                                   select c;
                int count = 1;
                foreach (WH_Sys_KP whSysKp in qqq)
                {
                    var cb = groupBox3.Controls["cb" + count] as ComboBox;
                    cb.SelectedIndex = int.Parse(whSysKp.TypeIndex.ToString());
                    var hBox = groupBox3.Controls["headfeed" + count] as TextBox;
                    hBox.Text = whSysKp.HeadFeed.ToString();
                    var fBox = groupBox3.Controls["footfeed" + count] as TextBox;
                    fBox.Text = whSysKp.FootFeed.ToString();
                    var ck = groupBox3.Controls["ck" + count] as CheckBox;
                    ck.Checked = int.Parse(whSysKp.isCutPaper.ToString()) == 1;
                    var ipBox = groupBox3.Controls["ip" + count] as TextBox;
                    ipBox.Text = whSysKp.IP_Addr;
                    var portBox = groupBox3.Controls["port" + count] as TextBox;
                    portBox.Text = whSysKp.Port.ToString();
                    count++;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //SendA();
            //MessageBox.Show("Ports Setting has been Sent!", "Alert");
            SendB();
            MessageBox.Show("KP Setting has been Sent!", "Alert");
            SendC();
            MessageBox.Show("RP has been Recieved", "Alert");
        }
        private void SendA()
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();
            ReceiveMessage rm = new ReceiveMessage();
            List<List<string>> strs = new List<List<string>>();
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_Port 
                        orderby c.ID ascending
                        select c;
                int i = 1;
                foreach (WH_Sys_Port w in q)
                {
                    List<string> s = new List<string>();
                    s.Add(i.ToString());
                    s.Add(w.PortIndex.ToString());
                    s.Add(w.BaudIndex.ToString());
                    strs.Add(s);
                    i++;
                }
                rm.GetDownArrayString(pIo, strs, 17, 117);

            }
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
                var q = from c in m.WH_Sys_KP
                        orderby c.ID ascending
                        select c;
                int i = 1;
                foreach (WH_Sys_KP w in q)
                {
                    List<string> s = new List<string>();
                    s.Add(i.ToString());
                    s.Add(w.TypeIndex.ToString());
                    s.Add(w.HeadFeed.ToString());
                    s.Add(w.FootFeed.ToString());
                    s.Add(w.isCutPaper.ToString());
                    if (w.IP_Addr.ToString() != ""&&w.IP_Addr.ToString().Split('.').Length==4&&w.Port.ToString()!="")
                    {
                        s.Add(w.IP_Addr.Split('.')[0]);
                        s.Add(w.IP_Addr.Split('.')[1]);
                        s.Add(w.IP_Addr.Split('.')[2]);
                        s.Add(w.IP_Addr.Split('.')[3]);
                        s.Add(w.Port.ToString());
                    }
                    else
                    {
                        s.Add("0");
                        s.Add("0");
                        s.Add("0");
                        s.Add("0");
                        s.Add("0");
                        s.Add("0");
                    }
                    i++;
                    strs.Add(s);
                }
                rm.GetDownArrayString(pIo, strs, 18, 118);
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
                var q = from c in m.WH_Sys_RP
                        orderby c.ID ascending
                        select c;
                int i = 1;
                foreach (WH_Sys_RP w in q)
                {
                    List<string> s = new List<string>();
                    s.Add(i.ToString());
                    s.Add(w.DeviceIndex.ToString()); 
                    strs.Add(s);
                }
                rm.GetDownArrayString(pIo, strs, 19, 119);

            }
            pIo.Close();
        }
        private void btnRev_Click(object sender, EventArgs e)
        {
            //RevA();
            //MessageBox.Show("Ports Setting has been Recieved.", "Alert");
            RevB();
            MessageBox.Show("KP Setting has been Recieved.", "Alert");
            RevC();
            MessageBox.Show("RP Setting has been Recieved", "Alert");
        }
        private void RevA()
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();

            ReceiveMessage rm = new ReceiveMessage();

            List<string> strs = new List<string>();
            for (int i = 1; i < 6; i++)
            {
                strs.Add(i.ToString());
            }
            rm.GetUpArrayString(pIo, strs, 17, 117);
            using (var m = new Entities())
            {
                int i = 0;
                foreach (List<string> str in rm.List)
                {
                    i++;
                    var q = m.WH_Sys_Port.FirstOrDefault(x => x.ID == i);
                    q.PortIndex = int.Parse(str[1]==""?"0":str[1]);
                    q.BaudIndex = int.Parse(str[2] == "" ? "0" : str[2]); 
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
            for (int i = 1; i < 14; i++)
            {
                strs.Add(i.ToString());
            }
            rm.GetUpArrayString(pIo, strs, 18, 118);
            using (var m = new Entities())
            {
                int i = 0;
                foreach (List<string> str in rm.List)
                {
                    i++;
                    var q = m.WH_Sys_KP.FirstOrDefault(x => x.ID == i);
                    q.TypeIndex = int.Parse(str[1] == "" ? "0" : str[1]);
                    q.HeadFeed = int.Parse(str[2] == "" ? "0" : str[2]);
                    q.FootFeed = int.Parse(str[3] == "" ? "0" : str[3]);
                    q.isCutPaper = int.Parse(str[4] == "" ? "0" : str[4]);
                    q.IP_Addr = (str[5] == "" ? "0" : str[5]) + "." + (str[6] == "" ? "0" : str[6]) + "." +
                                (str[7] == "" ? "0" : str[7]) + "." + (str[8] == "" ? "0" : str[8]);
                    q.Port = int.Parse(str[9] == "" ? "0" : str[9]); 
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
            rm.GetUpArrayString(pIo, strs, 19, 119);
            using (var m = new Entities())
            {
                int i = 0;
                foreach (List<string> str in rm.List)
                {
                    i++;
                    var q = m.WH_Sys_RP.FirstOrDefault(x => x.ID == i);
                    q.DeviceIndex = int.Parse(str[1] == "" ? "0" : str[1]); 
                }
                m.SaveChanges();
            }
            pIo.Close(); 
        }
    }
}