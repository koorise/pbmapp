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
    public partial class frm_HappyHour_ServiceTax : Form
    {
        public frm_HappyHour_ServiceTax()
        {
            InitializeComponent();
        }

        private void frm_HappyHour_ServiceTax_Load(object sender, EventArgs e)
        {
            List<Dog> dogs=new List<Dog>();
            using (var m = new Entities())
            {
                var q = from c in m.WH_Sys_happyHour_ServiceTax_Hours
                        orderby c.ID ascending
                        select c;
                foreach (var w in q)
                {
                    Dog d1 = new Dog();
                    d1.head = int.Parse(w.timeA.Split(':')[0]);
                    d1.body = int.Parse(w.timeA.Split(':')[1]);
                    d1.foot = int.Parse(w.timeA.Split(':')[2]);

                    Dog d2 = new Dog();
                    d2.head = int.Parse(w.timeB.Split(':')[0]);
                    d2.body = int.Parse(w.timeB.Split(':')[1]);
                    d2.foot = int.Parse(w.timeB.Split(':')[2]);

                    Dog d3 = new Dog();
                    d3.head = int.Parse(w.timeC.Split(':')[0]);
                    d3.body = int.Parse(w.timeC.Split(':')[1]);
                    d3.foot = int.Parse(w.timeC.Split(':')[2]);

                    Dog d4 = new Dog();
                    d4.head = int.Parse(w.timeD.Split(':')[0]);
                    d4.body = int.Parse(w.timeD.Split(':')[1]);
                    d4.foot = int.Parse(w.timeD.Split(':')[2]);

                    dogs.Add(d1);
                    dogs.Add(d2);
                    dogs.Add(d3);
                    dogs.Add(d4);
                }
                Bind_Combobox(dogs);
            }
        }

        private void Bind_Combobox(List<Dog> dog)
        {
            for (int i = 1; i < 5; i++)
            {
                ComboBox a = this.groupBox1.Controls["a" + i] as ComboBox;
                ComboBox b = this.groupBox1.Controls["b" + i] as ComboBox;
                ComboBox c = this.groupBox1.Controls["c" + i] as ComboBox;

                for (int j = 0; j < 25; j++)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = j.ToString().PadLeft(2, '0');
                    cb.Value = j.ToString().PadLeft(2, '0');
                    a.Items.Add(cb);
                   
                }
                for (int j = 0; j < 60; j++)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = j.ToString().PadLeft(2, '0');
                    cb.Value = j.ToString().PadLeft(2, '0');
                    b.Items.Add(cb);
                    c.Items.Add(cb);
                }
                a.SelectedIndex = dog[i-1].head;
                b.SelectedIndex = dog[i-1].body;
                c.SelectedIndex = dog[i-1].foot;
            }
            for (int i = 5; i < 9; i++)
            {
                ComboBox a = this.groupBox2.Controls["a" + i] as ComboBox;
                ComboBox b = this.groupBox2.Controls["b" + i] as ComboBox;
                ComboBox c = this.groupBox2.Controls["c" + i] as ComboBox;

                for (int j = 0; j < 25; j++)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = j.ToString().PadLeft(2, '0');
                    cb.Value = j.ToString().PadLeft(2, '0');
                    a.Items.Add(cb);

                }
                for (int j = 0; j < 60; j++)
                {
                    ComboBoxItem cb = new ComboBoxItem();
                    cb.Text = j.ToString().PadLeft(2, '0');
                    cb.Value = j.ToString().PadLeft(2, '0');
                    b.Items.Add(cb);
                    c.Items.Add(cb);
                }
                a.SelectedIndex = dog[i-1].head;
                b.SelectedIndex = dog[i-1].body;
                c.SelectedIndex = dog[i-1].foot;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    checkedListBox2.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    checkedListBox2.SetItemChecked(i, false);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = m.WH_Sys_happyHour_ServiceTax_Hours.FirstOrDefault(x => x.isHappyOrTax == 0);
                //WH_Sys_happyHour_ServiceTax_Hours q = new WH_Sys_happyHour_ServiceTax_Hours();
                q.timeA = a1.SelectedIndex + ":" + b1.SelectedIndex + ":" + c1.SelectedIndex;
                q.timeB = a2.SelectedIndex + ":" + b2.SelectedIndex + ":" + c2.SelectedIndex;
                q.timeC = a3.SelectedIndex + ":" + b3.SelectedIndex + ":" + c3.SelectedIndex;
                q.timeD = a4.SelectedIndex + ":" + b4.SelectedIndex + ":" + c4.SelectedIndex;
                string limit = "";
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        limit += "1";
                    }
                    else
                    {
                        limit += "0";
                    }
                }
                q.Weeks = limit;
                
                m.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var m = new Entities())
            {
                var q = m.WH_Sys_happyHour_ServiceTax_Hours.FirstOrDefault(x => x.isHappyOrTax == 1);
                //WH_Sys_happyHour_ServiceTax_Hours q = new WH_Sys_happyHour_ServiceTax_Hours();
                q.timeA = a5.SelectedIndex + ":" + b5.SelectedIndex + ":" + c5.SelectedIndex;
                q.timeB = a6.SelectedIndex + ":" + b6.SelectedIndex + ":" + c6.SelectedIndex;
                q.timeC = a7.SelectedIndex + ":" + b7.SelectedIndex + ":" + c7.SelectedIndex;
                q.timeD = a8.SelectedIndex + ":" + b8.SelectedIndex + ":" + c8.SelectedIndex;
                string limit = "";
                for (int i = 0; i < checkedListBox2.Items.Count; i++)
                {
                    if (checkedListBox2.GetItemChecked(i))
                    {
                        limit += "1";
                    }
                    else
                    {
                        limit += "0";
                    }
                }
                q.Weeks = limit;
                var p = m.WH_Sys_ServiceTax.FirstOrDefault();
                //WH_Sys_ServiceTax p = new WH_Sys_ServiceTax();
                p.Name = tbName.Text;
                p.RateAmount = decimal.Parse(tbRate.Text);
                p.Type = cbType.SelectedIndex;
                
                m.SaveChanges();
            }
        }
         
    }
    public class Dog
    { 
        public int head { get; set; }
        public int body { get; set; }
        public int foot { get; set; }
    }
}
