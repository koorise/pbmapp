using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBMApp.Tools
{
    public class ByteHelper
    {

        public List<byte> Bytes =new List<byte>();
        
        public static readonly byte STX = 0x02; //数据包起始标识符
        public static readonly byte ETX = 0x03; //数据包结束标识符
        public static readonly byte FS = 0x1c;//数据分割标示符
        public static readonly byte ACK = 0x06;// ack标示符
        public static readonly byte NAK = 0x15;// NAK
        public static readonly byte bye = 0x1A;//结束命令
        public  int Status { get; set; }
         
        public byte[] RBytes { get; set; }

        public List<string> SList { get; set; }

        /// <summary>
        /// 将字符串转换成Byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Byte[] Buf(string str)
        {
            return System.Text.Encoding.Default.GetBytes(str);
        }

        /// <summary>
        /// 数组合并，带分隔符 0x1c
        /// </summary>
        /// <param name="b">需要加入的数组</param> 
        public void BufCopyTo(byte[] b)
        {
            foreach (var _b in b)
            {
                Bytes.Add(_b);
            }
            byte sp = byte.Parse("1C", System.Globalization.NumberStyles.HexNumber); //分隔符
            Bytes.Add(sp);

        }

        /// <summary>
        /// CS校验值
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte CheckSum(byte[] bytes)
        {
            byte checkSum = new byte();
            foreach (byte b in bytes)
            {
                checkSum += b;
            }
            return checkSum;
        }

        /// <summary>
        /// 待发送的Byte[]
        /// </summary>
        /// <returns></returns>
        public byte[] SBytes()
        {
            byte stx = byte.Parse("02", System.Globalization.NumberStyles.HexNumber);
            byte etx = byte.Parse("03", System.Globalization.NumberStyles.HexNumber);

            string _cs = CheckSum(Bytes.ToArray()).ToString();
            byte[] cs = new byte[2];
            if (_cs.Length > 2)
            {
                cs = Buf(_cs.Substring(_cs.Length - 2, 2));
                Bytes.Add(cs[0]);
                Bytes.Add(cs[1]);
            }
            else
            {
                cs = Buf(_cs);
                foreach (byte b in cs)
                {
                    Bytes.Add(b);
                }
            }



            Bytes.Insert(0, stx);
            Bytes.Add(etx);
            return Bytes.ToArray();
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <returns></returns>
        public static string DeBytes(byte[] bytes)
        {
            byte[] bs = new byte[bytes.Length - 5];
            int n = 0;
            for (int i = 1; i <= bytes.Length - 5; i++)
            {
                bs[n] = bytes[i];
            }

            return Encoding.ASCII.GetString(bs);
        }

        public static List<byte> Decode(byte[] bytes)
        {
            List<byte> receivedBytesList = new List<byte>();
            receivedBytesList.AddRange(bytes);
            int startIndex = receivedBytesList.FindIndex(delegate(byte t) { return t == STX; });
            if (startIndex == -1) return null;
            int endIndex = receivedBytesList.FindIndex(startIndex, delegate(byte t) { return t == ETX; });
            if (endIndex == -1) return null;
            receivedBytesList.Remove(ACK);
            receivedBytesList.Remove(STX);
            receivedBytesList.Remove(ETX);
            return receivedBytesList;

        }
        public static   List<string> GetString(byte[] bytes)
        {
            List<string> strs = new List<string>();
            string s = "";
            foreach (byte b in bytes)
            {
                byte[] _b = new byte[1]{b};
                s += Encoding.ASCII.GetString(_b);
                if(b==FS)
                {
                    strs.Add(s);
                    s = "";
                }

            }
            return strs;
        } 
        /// <summary>
        /// 测试状态
        /// </summary>
        /// <param name="bytes">e.Data</param>
        /// <returns>返回状态</returns>
        public static int GetStatus(byte[] bytes)
        {
            if(bytes.Length==1)
            {
                byte b = bytes[0];
                if (b == ACK) return 1;
                if (b == NAK) return 2;
                if (b == STX) return 3;
                return 0;
            } 
                return 0; 
        }

    }
}
