using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PBMApp.Tools;

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

        private void button1_Click(object sender, EventArgs e)
        {
            
            f.isHex = true;
            f.Open(comboBox1.Text.ToString(),int.Parse(comboBox2.Text.ToString()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
             
            richTextBox1.Text = f.builder.ToString();
            byte[] b1 = TextHelper.Buf("2");//命令 
            TextHelper t = new TextHelper();
            
            t.BufCopyTo(b1);
            foreach (var bb in t.SBytes())
            {
                richTextBox1.Text += bb.ToString("X2") + " ";
                
            }
            richTextBox1.Text += "\n\r";
            //textBox1.Text = TextHelper.CheckSum(t.Bytes.ToArray()).ToString();
            //int checksum = TextHelper.CheckSum(t.Bytes.ToArray());
            //string cs = checksum.ToString().Substring(checksum.ToString().Length - 2, 2);
            //textBox1.Text = cs;
            //f.SendToECR(t.SBytes());


        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte b = byte.Parse("05", System.Globalization.NumberStyles.HexNumber);
            byte[] bytes = new byte[1];
            bytes[0] = b;
            
            //f.SendToECR(bytes);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextHelper t = new TextHelper();
            t.Bytes.Clear();
            byte[] b1 = TextHelper.Buf("Z");//命令 
            t.BufCopyTo(b1);
            byte[] b2 = TextHelper.Buf("1000000000001");//命令 
            t.BufCopyTo(b2);
            textBox1.Text = TextHelper.CheckSum(t.Bytes.ToArray()).ToString();
            //foreach (var bbb in t.SBytes())
            //{
            //    richTextBox1.Text += bbb.ToString("X2") + " ";

            //}
            //f.SendToECR(t.SBytes());
        }
    }
}
