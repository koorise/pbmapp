using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBMApp.Tools
{
    public   class ORB
    {
        public  int Up { get; set; }
        public  int Down { get; set; } 
        public List<string> IDs { get; set; } 

        public ORB(int a,int b)
        {
            Up = a;
            Down = b; 
        }
        
        public ORB()
        {
        }

        public byte[] Result { get; set; }
        
        /// <summary>
        /// 命令：单条上载
        /// </summary>
        /// <returns></returns>
        public  byte[] UpSingleCMD()
        {
            ByteHelper t = new ByteHelper();
            t.BufCopyTo(ByteHelper.Buf(Up.ToString()));
            return t.SBytes();
        }
         
        /// <summary>
        /// 数据：单条上载
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public  byte[] UpSingleData(string id)
        {
            ByteHelper t = new ByteHelper();
            t.BufCopyTo(ByteHelper.Buf("Z"));
            t.BufCopyTo(ByteHelper.Buf(id));
            return t.SBytes();
        }

        /// <summary>
        /// 命令：单条下载
        /// </summary>
        /// <returns></returns>
        public  byte[] DownSingleCMD()
        {
            ByteHelper t = new ByteHelper();
            t.BufCopyTo(ByteHelper.Buf(Down.ToString()));
            return t.SBytes();
        }

        /// <summary>
        /// 数据：单条下载
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public byte[] DownSingleData(List<string> param)
        {
           ByteHelper t = new ByteHelper();
            t.BufCopyTo(ByteHelper.Buf("Z"));
            foreach (string s in param)
            {
                t.BufCopyTo(ByteHelper.Buf(s));
            }
            return t.SBytes();

        }

        /// <summary>
        /// ENQ Bytes 05
        /// </summary>
        /// <returns></returns>
        public static byte[] ENQBytes()
        {
            byte b = byte.Parse("05", System.Globalization.NumberStyles.HexNumber);
            byte[] bytes = new byte[1];
            bytes[0] = b;
            return bytes;
        }

        /// <summary>
        /// ACK Bytes 06
        /// </summary>
        /// <returns></returns>
        public static byte[] ACKBytes()
        {
            byte b = byte.Parse("06", System.Globalization.NumberStyles.HexNumber);
            byte[] bytes = new byte[1];
            bytes[0] = b;
            return bytes;
        }
        /// <summary>
        /// Bye-Bye 1A
        /// </summary>
        /// <returns></returns>
        public static byte[] ByeByeBytes()
        {
            byte b = byte.Parse("1A", System.Globalization.NumberStyles.HexNumber);
            byte[] bytes = new byte[1];
            bytes[0] = b;
            return bytes;
        }
         
       
    }
}
