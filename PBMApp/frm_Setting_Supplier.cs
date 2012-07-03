using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PBMApp.Model;

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
             
            int y = 10;
            for (int i = 1; i < 11; i++)
            {
                Point p = new Point(30 ,y+30);
                Label lb = new Label();
                Size size=new Size(70,20);
                lb.Location = p;
                lb.Size = size;
                lb.Text = "Supplier" + i.ToString().PadLeft(2, '0');
                lb.Visible = true;
                groupBox1.Controls.Add(lb);
                
                Point pp = new Point(100,y+28);
                TextBox tb = new TextBox();
                Size tbSize = new Size(100,20);
                tb.Location = pp;
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
        }
         

    }
}
