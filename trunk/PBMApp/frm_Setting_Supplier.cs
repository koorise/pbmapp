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
    public partial class frm_Setting_Supplier : Form
    {
        public frm_Setting_Supplier()
        {
            InitializeComponent();
        }
         
        private void frm_Setting_Supplier_Load(object sender, EventArgs e)
        {
            Frm_Load();
        }
        private void Frm_Load()
        {
            int y = 10;
            for (int i = 1; i < 11; i++)
            {
                Point p = new Point(30, y + 30);
                Label lb = new Label();
                Size size = new Size(70, 20);
                lb.Location = p;
                lb.Size = size;
                lb.Text = "Supplier" + i.ToString().PadLeft(2, '0');
                lb.Visible = true;
                groupBox1.Controls.Add(lb);

                Point pp = new Point(100, y + 28);
                TextBox tb = new TextBox();
                Size tbSize = new Size(100, 20);
                tb.Location = pp;
                tb.MaxLength = 30;
                tb.Size = tbSize;
                tb.Visible = true;
                tb.Name = "tb" + i;
                groupBox1.Controls.Add(tb);
                y += 30;
            }
            y = 10;
            for (int i = 11; i < 21; i++)
            {
                Point p = new Point(230, y + 30);
                Label lb = new Label();
                Size size = new Size(70, 20);
                lb.Location = p;
                lb.Size = size;
                lb.Text = "Supplier" + i.ToString().PadLeft(2, '0');
                lb.Visible = true;
                groupBox1.Controls.Add(lb);

                Point pp = new Point(300, y + 28);
                TextBox tb = new TextBox();
                Size tbSize = new Size(100, 20);
                tb.Location = pp;
                tb.Size = tbSize;
                tb.Visible = true;
                tb.Name = "tb" + i;
                tb.MaxLength = 30;
                groupBox1.Controls.Add(tb);
                y += 30;
            }
            using (var m = new Entities())
            {
                for (int i = 1; i < 21; i++)
                {
                    TextBox tb = this.groupBox1.Controls["tb" + i] as TextBox;
                    WH_Sys_Supplier w = m.WH_Sys_Supplier.FirstOrDefault(x => x.ID == i);
                    tb.Text = w.Description;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                for (int i = 1; i < 21; i++)
                {
                    TextBox tb = this.groupBox1.Controls["tb" + i] as TextBox;
                    WH_Sys_Supplier w = m.WH_Sys_Supplier.FirstOrDefault(x => x.ID == i);
                    w.Description = tb.Text;
                }
                m.SaveChanges();
            }
            
            //Frm_Load();
            MessageBox.Show("Success", "Alert");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                for (int i = 1; i < 21; i++)
                {
                    TextBox tb = this.groupBox1.Controls["tb" + i] as TextBox;
                    WH_Sys_Supplier w = m.WH_Sys_Supplier.FirstOrDefault(x => x.ID == i);
                    w.Description = "Supplier"+i;
                }
                m.SaveChanges();
            }
            groupBox1.Controls.Clear();
            Frm_Load();

            MessageBox.Show("Success", "Alert");
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();
            ReceiveMessage rm = new ReceiveMessage();
            List<List<string>> strs = new List<List<string>>();
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_Supplier
                        orderby c.ID ascending
                        select c;
                foreach (WH_Sys_Supplier w in q)
                {
                    List<string> s = new List<string>();
                    s.Add(w.ID.ToString()); 
                    s.Add(w.Description.ToString()); 
                    strs.Add(s);
                }
            }
            rm.GetDownArrayString(pIo, strs, 28, 128);
            pIo.Close();
            MessageBox.Show("Success", "Alert");
        }

        private void btnRev_Click(object sender, EventArgs e)
        {
            JustinIO.CommPort pIo = ReceiveMessage.sp();
            pIo.Open();

            ReceiveMessage rm = new ReceiveMessage();

            List<string> strs = new List<string>();
            for (int i = 1; i < 21; i++)
            {
                strs.Add(i.ToString());
            }
            rm.GetUpArrayString(pIo, strs, 28, 128);
            using (var m = new Entities())
            {
                int count = 0;
                foreach (List<string> str in rm.List)
                {
                    count++;
                    //MessageBox.Show(str[0], "AA");

                    var q = m.WH_Sys_Supplier.FirstOrDefault(x => x.ID == count); 
                    
                    q.Description = str[1];
                }
                m.SaveChanges();
            }
            pIo.Close();

            groupBox1.Controls.Clear();
            Frm_Load();
            MessageBox.Show("Success", "Alert");
        }
         

    }
}
