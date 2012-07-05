using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PBMApp.Model;

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
                t.Name = "headfeed" + i;
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

         
    }
}