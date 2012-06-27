using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PBMApp.HeaderFooterPreview;
using PBMApp.Model;

namespace PBMApp
{
    public partial class frm_Setting_HeaderFooter : Form
    {
        public frm_Setting_HeaderFooter()
        {
            InitializeComponent();
        }

        public int pageLoad = 0;
        private void frm_Setting_HeaderFooter_Load(object sender, EventArgs e)
        { 
            using (var m = new Entities())
            {
                #region header footer init
                var q = from c in m.WH_Sys_Header_Footer
                        orderby c.ID ascending
                        select c;
                for (int i = 0; i < 10; i++)
                {
                    var qq = q.Skip(i);
                    var qqq = qq.FirstOrDefault();
                    switch (i)
                    {
                        case 0:
                            textBox1.Text = qqq.title;
                            comboBox1.SelectedIndex = int.Parse(qqq.DoubleWidth.ToString());
                            comboBox2.SelectedIndex = int.Parse(qqq.PositionID.ToString());
                            break;
                        case 1:
                            textBox2.Text = qqq.title;
                            comboBox4.SelectedIndex = int.Parse(qqq.DoubleWidth.ToString());
                            comboBox3.SelectedIndex = int.Parse(qqq.PositionID.ToString());
                            break;
                        case 2:
                            textBox3.Text = qqq.title;
                            comboBox6.SelectedIndex = int.Parse(qqq.DoubleWidth.ToString());
                            comboBox5.SelectedIndex = int.Parse(qqq.PositionID.ToString());
                            break;
                        case 3:
                            textBox4.Text = qqq.title;
                            comboBox8.SelectedIndex = int.Parse(qqq.DoubleWidth.ToString());
                            comboBox7.SelectedIndex = int.Parse(qqq.PositionID.ToString());
                            break;
                        case 4:
                            textBox5.Text = qqq.title;
                            comboBox10.SelectedIndex = int.Parse(qqq.DoubleWidth.ToString());
                            comboBox9.SelectedIndex = int.Parse(qqq.PositionID.ToString());
                            break;
                        case 5:
                            textBox6.Text = qqq.title;
                            comboBox12.SelectedIndex = int.Parse(qqq.DoubleWidth.ToString());
                            comboBox11.SelectedIndex = int.Parse(qqq.PositionID.ToString());
                            break;
                        case 6:
                            textBox7.Text = qqq.title;
                            comboBox14.SelectedIndex = int.Parse(qqq.DoubleWidth.ToString());
                            comboBox13.SelectedIndex = int.Parse(qqq.PositionID.ToString());
                            break;
                        case 7:
                            textBox8.Text = qqq.title;
                            comboBox16.SelectedIndex = int.Parse(qqq.DoubleWidth.ToString());
                            comboBox15.SelectedIndex = int.Parse(qqq.PositionID.ToString());
                            break;
                        case 8:
                            textBox9.Text = qqq.title;
                            comboBox18.SelectedIndex = int.Parse(qqq.DoubleWidth.ToString());
                            comboBox17.SelectedIndex = int.Parse(qqq.PositionID.ToString());
                            break;
                        case 9:
                            textBox10.Text = qqq.title;
                            comboBox20.SelectedIndex = int.Parse(qqq.DoubleWidth.ToString());
                            comboBox19.SelectedIndex = int.Parse(qqq.PositionID.ToString());
                            break;
                    }
                }
            #endregion

                pageLoad++;

                #region BundelSaving ReceiptNum
                var br = from c in m.WH_Sys_BundleSaving_ReceiptNumber
                         orderby c.ID ascending 
                         select c;
                var b = br.First();
                textBox11.Text = b.title;
                var r = br.Skip(1);
                var _r = r.First();
                textBox12.Text = _r.title;
                #endregion
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            using (var m = new Entities())
            {  
                #region header footer更新
                var q = from c in m.WH_Sys_Header_Footer
                        orderby c.ID ascending
                        select c;
                for (int i = 0; i < 10; i++)
                {
                    var qq = q.Skip(i);
                    var qqq = qq.FirstOrDefault();
                    var w = m.WH_Sys_Header_Footer.FirstOrDefault(x => x.ID == (i + 1));
                    switch (i)
                    {
                        case 0:
                            w.title = textBox1.Text;
                            w.DoubleWidth = comboBox1.SelectedIndex;
                            w.PositionID = comboBox2.SelectedIndex;
                            break;
                        case 1:
                            w.title = textBox2.Text;
                            w.DoubleWidth = comboBox4.SelectedIndex;
                            w.PositionID = comboBox3.SelectedIndex;

                            break;
                        case 2:
                            w.title = textBox3.Text;
                            w.DoubleWidth = comboBox6.SelectedIndex;
                            w.PositionID = comboBox5.SelectedIndex;

                            break;
                        case 3:
                            w.title = textBox4.Text;
                            w.DoubleWidth = comboBox8.SelectedIndex;
                            w.PositionID = comboBox7.SelectedIndex;

                            break;
                        case 4:
                            w.title = textBox5.Text;
                            w.DoubleWidth = comboBox10.SelectedIndex;
                            w.PositionID = comboBox9.SelectedIndex;

                            break;
                        case 5:
                            w.title = textBox6.Text;
                            w.DoubleWidth = comboBox12.SelectedIndex;
                            w.PositionID = comboBox11.SelectedIndex;

                            break;
                        case 6:
                            w.title = textBox7.Text;
                            w.DoubleWidth = comboBox14.SelectedIndex;
                            w.PositionID = comboBox13.SelectedIndex;

                            break;
                        case 7:
                            w.title = textBox8.Text;
                            w.DoubleWidth = comboBox16.SelectedIndex;
                            w.PositionID = comboBox15.SelectedIndex;

                            break;
                        case 8:
                            w.title = textBox9.Text;
                            w.DoubleWidth = comboBox18.SelectedIndex;
                            w.PositionID = comboBox17.SelectedIndex;

                            break;
                        case 9:
                            w.title = textBox10.Text;
                            w.DoubleWidth = comboBox20.SelectedIndex;
                            w.PositionID = comboBox19.SelectedIndex;

                            break;
                    }
                }
                #endregion

                #region BundleSaving ReceiptNumber
                var br = from c in m.WH_Sys_BundleSaving_ReceiptNumber
                         orderby c.ID ascending
                         select c;
                var b = br.First();
                b.title = textBox11.Text;
                var r = br.Skip(1).First();
                r.title = textBox12.Text;
                #endregion
                m.SaveChanges();
                MessageBox.Show("success！", "alert");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(pageLoad==0)
            {
                return;
            }

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    frm_a frma = new frm_a();
                    frma.ShowDialog();
                    break;
                case 3:
                    frm_b frmb = new frm_b();
                    frmb.ShowDialog();
                    break;
                case 1:
                    frm_c frmC=new frm_c();
                    frmC.ShowDialog();
                    break;
                case 2:
                    frm_d frmD=new frm_d();
                    frmD.ShowDialog();
                    break;
                default: break;
                    
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageLoad == 0)
            {
                return;
            }
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    frm_e frme = new frm_e();
                    frme.ShowDialog();
                    break;
                
                case 2:
                    frm_f frmf = new frm_f();
                    frmf.ShowDialog();
                    break;
                
                default: break;

            }
        }
    }
}
