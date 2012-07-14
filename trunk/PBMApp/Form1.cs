using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PBMApp.Model;
using PBMApp.Tools;
using System.Threading;
namespace PBMApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Tools.Fox f = new Fox();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            foreach (string s in f.Potrs())
            {
                comboBox1.Items.Add(s);
            }
            foreach (string s in f.Baudrate())
            {
                comboBox2.Items.Add(s);
            }
        }

        public JustinIO.CommPort pIo = new JustinIO.CommPort();
        private void button1_Click(object sender, EventArgs e)
        { 
            
             
            //JustinIO.CommPort pIo = new JustinIO.CommPort();
            pIo.PortNum = comboBox1.Text;
            pIo.BaudRate = int.Parse(comboBox2.Text);
            pIo.Parity = 0;
            pIo.StopBits = 0;
            pIo.ReadTimeout = 300000;
            pIo.Open();
            //p = new PortData(comboBox1.Text.ToString(), int.Parse(comboBox2.Text.ToString()), Parity.None);
            //p.Open();
            //p.Received += new PortDataReceivedEventHandle(p_Received);  
        }

       private string result = "";
      
       private void button3_Click(object sender, EventArgs e)
       {
           List<string> strs = new List<string>();
           strs.Add("1");
           strs.Add("2");
           strs.Add("3");
           ReceiveMessage rm = new ReceiveMessage();
           rm.GetUpArrayString(pIo,strs,13,113);
           foreach (List<string> str in rm.List)
           {
               richTextBox1.Text += "***************\n\r";
               foreach (string s in str)
               {
                   richTextBox1.Text += s + "@";
               }
               richTextBox1.Text += "\n\r";

           }
           //byte[] bytes = new byte[1];
           //bytes = pIo.Read(1);
           //foreach (byte b in bytes)
           //{
           //    richTextBox1.Text += b.ToString("X2") + "-";
           //    //MessageBox.Show("AA", "AA");
           //} 
        
           //List<string> strs=new List<string>();
           //for (int i = 1; i < 10; i++)
           //{
           //    strs.Add(i.ToString());
           //}
           //o.IDs=strs;
           //p.SendData(Tools.ORB.ENQBytes());
       }

       private void button2_Click(object sender, EventArgs e)
       {
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
           }
           rm.GetDownArrayString(pIo, strs, 13, 113);
       } 
    }
}
