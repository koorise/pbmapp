using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PBMApp.Tools
{
    public class ReceiveMessage
    {
        public List<string> Data { get; set; }
        private string str = ""; 
        public   List<List<string>> List = new List<List<string>>();
        public   int Steps { get; set; }
        public static JustinIO.CommPort sp()
        {
            JustinIO.CommPort pIo = new JustinIO.CommPort();
            pIo.PortNum = Tools.Config.GetAppConfig("PortName");
            pIo.BaudRate = int.Parse(Tools.Config.GetAppConfig("BaudRate"));
            pIo.Parity = 0;
            pIo.StopBits = 0;
            pIo.ReadTimeout = int.Parse(Tools.Config.GetAppConfig("ReadTimeOut"));
             
            return pIo;
        }
        
        public bool ReadOne(JustinIO.CommPort pio)
        { 
            return ByteHelper.ACK == pio.Read(1)[0];
        }
        public bool ReadTwo(JustinIO.CommPort pio)
        {
            return ByteHelper.ACK == pio.Read(1)[0];
        }
        public void ReadThree(JustinIO.CommPort pio)
        {
                byte b = pio.Read(1)[0];
                
                if (b != ByteHelper.ETX)
                {
                    if (b == ByteHelper.STX || b == ByteHelper.ACK)
                    {
                        ReadThree(pio);
                    }
                    else
                    {
                        if (b == ByteHelper.FS)
                        {
                            Data.Add(str);
                            str = "";
                        }
                        else
                        {
                            byte[] bytes = new byte[1] {b};
                            str += Encoding.ASCII.GetString(bytes);
                        }
                        ReadThree(pio);
                    }
                }
           

        }
        
        public   void GetUpArrayString(JustinIO.CommPort pIo,List<string> strs,int up,int down)
        {
            ORB orb = new ORB(up, down);  

            ReceiveMessage rm = new ReceiveMessage();

            pIo.Write(ByteHelper.oneCmd(ByteHelper.ENQ));//询问
            if (rm.ReadOne(pIo))
            {
                pIo.Write(orb.UpSingleCMD()); //命令
                if (rm.ReadTwo(pIo))
                {
                    int i = 0;
                    foreach (string s in strs) //循环发送数据包
                    {
                        rm.Data = new List<string>();
                        if (i != 0)
                        {
                            pIo.Write(Tools.ByteHelper.oneCmd(ByteHelper.ACK));
                        }
                        pIo.Write(orb.UpSingleData(s));
                        rm.ReadThree(pIo);
                        List.Add(rm.Data);
                        i++;
                    }
                    pIo.Write(Tools.ByteHelper.oneCmd(ByteHelper.bye)); 
                }
            }
            else
            {
                pIo.Read(2);
                GetUpArrayString(pIo, strs, up, down);
            }
        }
        public void GetDownArrayString(JustinIO.CommPort pIo, List<List<string>> strs, int up, int down  )
        {
            ORB orb = new ORB(up, down);
            
            ReceiveMessage rm = new ReceiveMessage();

            pIo.Write(ByteHelper.oneCmd(ByteHelper.ENQ));//询问
            if (rm.ReadOne(pIo))
            {
                pIo.Write(orb.DownSingleCMD()); //命令
                if (rm.ReadTwo(pIo))
                {
                    Steps = 0;
                    foreach (List<string> s in strs) //循环发送数据包
                    {
                        rm.Data = new List<string>();
                        if (Steps != 0)
                        {
                            pIo.Write(Tools.ByteHelper.oneCmd(ByteHelper.ACK));
                        }
                        pIo.Write(orb.DownSingleData(s));
                        if (!rm.ReadOne(pIo))
                        {
                            List.Add(s);
                        } 
                        Application.DoEvents();
                        Steps++;
                    }
                    pIo.Write(Tools.ByteHelper.oneCmd(ByteHelper.bye));
                }
            }
            else
            {
                pIo.Read(3);
                GetDownArrayString(pIo, strs, up, down);
            }
        }
    }
}
