using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;

namespace PBMApp.Tools
{
    public class Fox 
    {
        public readonly StringBuilder builder = new StringBuilder(); //避免在事件处理方法中反复的创建，定义到外面。
        public long received_count; //接收计数
        public long send_count; //发送计数
        public SerialPort comm { get; set; }
        public bool isHex { get; set; }
        public ORB Orb { get; set; }
        /// <summary>
        /// 初始化、打开COM
        /// </summary>
        /// <param name="PortName"></param>
        /// <param name="Baudrate"></param>
        public void Open(string PortName,int Baudrate)
        {
            comm = new SerialPort();
            comm.PortName = PortName;
            comm.BaudRate = Baudrate;
            comm.Parity = Parity.None;
            comm.StopBits = StopBits.One;
            try
            {
                comm.Open();
                comm.DataReceived += comm_DataReceived;
            }
            catch (Exception ex)
            {
                //捕获到异常信息，创建一个新的comm对象，之前的不能用了。
                comm = new SerialPort();
                //现实异常信息给客户。
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 关闭COM
        /// </summary>
        public void Close()
        {
            if (comm.IsOpen)
            {
                //打开时点击，则关闭串口
                comm.Close();
            }
        }
        /// <summary>
        /// PC->ECR
        /// </summary>
        /// <param name="buf"></param>
        public void SendToECR(byte[] bytes)
        {
            comm.Write(bytes, 0, bytes.Length);
            //if (isHex)
            //{
            //    MatchCollection mc = Regex.Matches(str, @"(?i)[\da-f]{2}");
            //    List<byte> buf = new List<byte>();//填充到这个临时列表中
            //    //依次添加到列表中
            //    foreach (Match m in mc)
            //    {
            //        buf.Add(byte.Parse(m.Value, System.Globalization.NumberStyles.HexNumber));
            //    }
            //    //转换列表为数组后发送
            //    comm.Write(buf.ToArray(), 0, buf.Count);
            //}
            //else
            //{
            //    comm.Write(str);
            //}
        }
        /// <summary>
        /// 获取COM口列表
        /// </summary>
        /// <returns></returns>
        public Array Potrs()
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            return ports;
        }
        /// <summary>
        /// Baudrate数组
        /// </summary>
        /// <returns></returns>
        public Array Baudrate()
        {
            string[] strs = new string[7] { "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            return strs;
        }
        /// <summary>
        /// 启动COM监听事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void comm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int n = comm.BytesToRead; //先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
            var buf = new byte[n]; //声明一个临时数组存储当前来的串口数据
            received_count += n; //增加接收计数
            comm.Read(buf, 0, n); //读取缓冲数据
            builder.Clear(); //清除字符串构造器的内容
            Orb.Result = buf;
            //判断是否是显示为16禁止
            if (isHex)
            {
                //依次的拼接出16进制字符串
                foreach (byte b in buf)
                { 
                    builder.Append(b.ToString("X2") + " "); 
                    //MessageBox.Show(b.ToString("X2"), "a");
                }
                //MessageBox.Show(System.Text.Encoding.Default.GetString(buf),"AA");

            }
            else
            {
                //直接按ASCII规则转换成字符串
                builder.Append(Encoding.ASCII.GetString(buf));
            }
            //MessageBox.Show(Encoding.ASCII.GetString(buf), "AA");
        }
    }
}