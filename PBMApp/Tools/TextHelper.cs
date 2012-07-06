using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PBMApp.Tools
{
    public  class TextHelper
    {

        public   List<byte> Bytes = new List<byte>(); 
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
            byte sp = byte.Parse("1C", System.Globalization.NumberStyles.HexNumber);//分隔符
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
            
            byte[] cs = Buf(_cs.Substring(_cs.Length - 2, 2));
             
            Bytes.Add(cs[0]);
            Bytes.Add(cs[1]);
            Bytes.Insert(0,stx);
            Bytes.Add(etx); 
            return Bytes.ToArray();
        }
         
    }
}
