using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using Yuan;
using PPG_debug_tool;

namespace Serial_Port
{
    public partial class Form1 : Form
    {
        string PkgStr = "";
        const int PkgL = 18;
        byte[] PkgH = { 0xaa, 0x55};
        byte[] PkgT = { 0x55, 0xaa};
        string DateNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
        PPG_debug_tool.WaveBitmap WaveBitmap;

        List<byte> RecBuffer = new List<byte>();
        public Form1()
        {
            InitializeComponent();
            WaveBitmap = new PPG_debug_tool.WaveBitmap(Color.Red, 0, 65535, 8, ref pictureBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string RecStr = "";
            int RecCnt = serialPort1.BytesToRead;
            byte[] ByteArray = new byte[RecCnt];

            serialPort1.Read(ByteArray, 0, RecCnt);
            RecBuffer.AddRange(ByteArray);

            foreach (byte RecTmp in ByteArray) {
                RecStr += RecTmp + " ";
            }

            System.IO.File.AppendAllText(DateNow + "_Raw.txt", RecStr);
        }

        /*private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (serialPort1.IsOpen) serialPort1.Close();
                serialPort1.PortName = textBox1.Text;
                serialPort1.Open();
                DateNow = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
            }
        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                while (RecBuffer.Count >= PkgL)
                {
                    bool isPkg = Yuan.Package.Check(RecBuffer, PkgH, PkgL, PkgT);
                    if (isPkg)
                    {
                        UInt16 RecData = (UInt16)(RecBuffer[2] << 8 | RecBuffer[3]);
                        //WaveBitmap.DrawPixel(RecData);
                        //int RecData = (int)((RecBuffer[2] & 0x0F) << 20 | RecBuffer[3] << 12 | RecBuffer[4] << 4 | RecBuffer[5]>>4);
                        //WaveBitmap.DrawPixel(RecData);
                        
                        for (int i = 0; i < PkgL; i++ )
                        {
                            PkgStr = PkgStr + " " + RecBuffer[i];
                        }
                        PkgStr = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff\t") + PkgStr + ",\t" + RecData + "\r\n";

                        textBox2.AppendText(PkgStr);
                        System.IO.File.AppendAllText(DateNow + ".txt", PkgStr, Encoding.UTF8);

                        PkgStr = "";
                        RecBuffer.RemoveRange(0, PkgL);
                    }
                    else
                    {
                        RecBuffer.RemoveAt(0);
                    }
                }
            }
        }

        private void COM_comboBox_Click(object sender, EventArgs e)
        {
            COM_comboBox.Items.Clear();
            COM_comboBox.Items.AddRange(Yuan.Package.GetCOMPorts());
        }

        private void COM_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
            serialPort1.BaudRate = int.Parse(BaudRate_textBox.Text);
            serialPort1.PortName = COM_comboBox.Text;
            serialPort1.Open();
            DateNow = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");

            WaveBitmap = new PPG_debug_tool.WaveBitmap(Color.Red, int.Parse(DrawMin_textBox.Text), int.Parse(DrawMax_textBox.Text), 8, ref pictureBox1);
        }
    }
}
