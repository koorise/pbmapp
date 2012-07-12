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
        private ORB o = new ORB(13, 113,"1");
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
           if(p.isNext)
           {
               sendACK();
           }
           else
           {

               p.isACK = e.Data[0] == ByteHelper.ACK;
               if (p.isACK)
               {
                   if (p.isData)
                   {
                       sendData();
                       p.isACK = false;
                       p.isData = false;
                       p.isNext = true;

                   }
                   else
                   {
                       sendCMD();
                       p.isACK = false;
                       p.isData = true;
                   }
               }
           }


           if(ByteHelper.Decode(e.Data)!=null)
           {

               foreach (byte b in ByteHelper.Decode(e.Data))
               {
                   result += b.ToString("X2") + "-";
               }
               this.Invoke((MethodInvoker)delegate { richTextBox1.AppendText(result + "\n\r"); });
               foreach (string c in ByteHelper.GetString(ByteHelper.Decode(e.Data).ToArray()))
               {
                   this.Invoke((MethodInvoker)delegate { richTextBox1.AppendText(c + "\n\r"); });
               }
               
           }
           
       } 
        public  void sendCMD()
        {
            p.SendData(o.UpSingleCMD()); 
        }
        public void sendData()
        {
            p.SendData(o.UpSingleData());
        }
        public void sendACK()
        {
            byte[] bytes=new byte[1024];
            p.SendCommand(Tools.ORB.ACKBytes(), ref bytes,300);
            sendByeBye();
        }
        public void sendByeBye()
        {
            byte[] bytes = new byte[1024];
            p.SendCommand(Tools.ORB.ByeByeBytes(), ref bytes, 300); 
        }
        private void button3_Click(object sender, EventArgs e)
        {  
            p.SendData(Tools.ORB.ENQBytes());
        }
    }
}
