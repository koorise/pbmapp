using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
        private ORB o = new ORB(13, 113);
        private PortData p;
        private void button1_Click(object sender, EventArgs e)
        {

            p = new PortData(comboBox1.Text.ToString(), int.Parse(comboBox2.Text.ToString()), Parity.None);
            p.Open();
            p.Received += new PortDataReceivedEventHandle(p_Received);  
        }

       private string result = "";
       private  void p_Received(object sender, PortDataReciveEventArgs e)
       {
           result = "";
           p.isACK = ORB.IsACK(e.Data[0]);
            if(p.isACK)
            {
                if(p.isData)
                {
                    sendData();
                    p.isACK = false;
                    p.isData = false;
                   
                    
                }
                else
                {
                    sendCMD();
                    p.isACK = false;
                    p.isData = true;
                } 
            } 
            
           if(ByteHelper.Decode(e.Data)!=null)
           {
               foreach (byte b in ByteHelper.Decode(e.Data))
               {
                   result += b.ToString("X2") + "-";
               }
               this.Invoke((MethodInvoker)delegate { richTextBox1.AppendText(result + "\n\r"); });
           }
           
       } 
        public  void sendCMD()
        {
            o.ID = "1"; 
            p.SendData(o.UpSingleCMD()); 
        }
        public void sendData()
        {
            o.ID = "1"; 
            p.SendData(o.UpSingleData());
        }
        public void sendACK()
        {
            p.SendData(Tools.ORB.ACKBytes());
        }
        public void sendByeBye()
        {
            p.SendData(Tools.ORB.ByeByeBytes());
        }
        private void button3_Click(object sender, EventArgs e)
        {  
            p.SendData(Tools.ORB.ENQBytes());
        }
    }
}
