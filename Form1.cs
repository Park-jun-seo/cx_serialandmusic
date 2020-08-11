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
using System.Management;
using System.Threading;
using System.Media;

namespace ROFULA
{
    public partial class Form1 : Form
    {
        static string music = " ";
        static string musicname = " ";

        public Form1()
        {
            InitializeComponent();

            string[] PortNames = SerialPort.GetPortNames();

            checkedListBox1.Items.Clear();
            foreach (string portnumber in PortNames)
            {
                checkedListBox1.Items.Add(portnumber);
            }
            for (int i = 0; i < 10; i++)
            {
                listBox3.Items.Add(" ");
            }
            for (int i = 0; i < 10; i++)
            {
                listBox4.Items.Add(" ");
            }
            listBox5.Items.Clear();
            listBox5.Items.Add("노래를 선택하세요");

        }
        private async void wmi()
        {
            await Wmi();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async Task Wmi()
        {
            listBox1.Items.Clear();
            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_SerialPort");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    string collect = "PNPDeviceID";

                    if (queryObj[collect] != null)
                    {
                        string valu = queryObj[collect].ToString();
                        string add = valu.Split('&')[4].Split('_')[0];
                        string port = queryObj["DeviceID"].ToString();
                        if (add != "000000000000")
                        {
                            string adcomport = string.Format("{0} : {1}", port, add);
                            
                            listBox1.Items.Add(adcomport);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("포트 연결을 확인해 주세요");
            }
            await Task.Delay(1);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            string[] PortNames = SerialPort.GetPortNames();
            checkedListBox1.Items.Clear();
            foreach (string portnumber in PortNames)
            {
                checkedListBox1.Items.Add(portnumber);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                listBox3.Items.Add(" ");
            }
            for (int i = 0; i < 10; i++)
            {
                listBox4.Items.Add(" ");
            }

            allclose();
            foreach (object indexChecked in checkedListBox1.CheckedItems)
            {
                listBox2.Items.Add(indexChecked.ToString());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            wmi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (int indexChecked in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemChecked(indexChecked, false);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void button6_Click(object sender, EventArgs e)
        {
            int count = listBox2.Items.Count;
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                listBox3.Items.Add(" ");
            }
            for (int i = 0; i < 10; i++)
            {
                listBox4.Items.Add(" ");
            }

            for (int i = 0; i < count; i++)
            {
                if (serialPort1.IsOpen==true)
                {
                    listBox3.Items[0] = "연결됨";
                }
                if (serialPort2.IsOpen == true)
                {
                    listBox3.Items[1] = "연결됨";
                }
                if (serialPort3.IsOpen == true)
                {
                    listBox3.Items[2] = "연결됨";
                }
                if (serialPort4.IsOpen == true)
                {
                    listBox3.Items[3] = "연결됨";
                }
                if (serialPort5.IsOpen == true)
                {
                    listBox3.Items[4] = "연결됨";
                }
                if (serialPort6.IsOpen == true)
                {
                    listBox3.Items[5] = "연결됨";
                }
                if (serialPort7.IsOpen == true)
                {
                    listBox3.Items[6] = "연결됨";
                }
                if (serialPort8.IsOpen == true)
                {
                    listBox3.Items[7] = "연결됨";
                }
                if (serialPort9.IsOpen == true)
                {
                    listBox3.Items[8] = "연결됨";
                }
                if (serialPort10.IsOpen == true)
                {
                    listBox3.Items[9] = "연결됨";
                }

                
            }
           
            if (count == 0)
            {
                goto End1;
            }
            if(serialPort1.IsOpen==false)
            {
                serialPort1.PortName = listBox2.Items[0].ToString();
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.RtsEnable = true;
            }
            if (count <= 1)
            {
                goto End1;
            }
            if (serialPort2.IsOpen == false)
            {
                serialPort2.PortName = listBox2.Items[1].ToString();
                serialPort2.BaudRate = 9600;
                serialPort2.DataBits = 8;
                serialPort2.RtsEnable = true;
            }
            if (count <= 2)
            {
                goto End1;
            }
            if (serialPort3.IsOpen == false)
            {
                serialPort3.PortName = listBox2.Items[2].ToString();
                serialPort3.BaudRate = 9600;
                serialPort3.DataBits = 8;
                serialPort3.RtsEnable = true;
            }
            if (count <= 3)
            {
                goto End1;
            }
            if (serialPort4.IsOpen == false)
            {
                serialPort4.PortName = listBox2.Items[3].ToString();
                serialPort4.BaudRate = 9600;
                serialPort4.DataBits = 8;
                serialPort4.RtsEnable = true;
            }
            if (count <= 4)
            {
                goto End1;
            }
            if (serialPort5.IsOpen == false)
            {
                serialPort5.PortName = listBox2.Items[4].ToString();
                serialPort5.BaudRate = 9600;
                serialPort5.DataBits = 8;
                serialPort5.RtsEnable = true;
            }
            if (count <= 5)
            {
                goto End1;
            }
            if (serialPort6.IsOpen == false)
            {
                serialPort6.PortName = listBox2.Items[5].ToString();
                serialPort6.BaudRate = 9600;
                serialPort6.DataBits = 8;
                serialPort6.RtsEnable = true;
            }
            if (count <= 6)
            {
                goto End1;
            }
            if (serialPort7.IsOpen == false)
            {
                serialPort7.PortName = listBox2.Items[6].ToString();
                serialPort7.BaudRate = 9600;
                serialPort7.DataBits = 8;
                serialPort7.RtsEnable = true;
            }
            if (count <= 7)
            {
                goto End1;
            }
            if (serialPort8.IsOpen == false)
            {
                serialPort8.PortName = listBox2.Items[7].ToString();
                serialPort8.BaudRate = 9600;
                serialPort8.DataBits = 8;
                serialPort8.RtsEnable = true;
            }
            if (count <= 8)
            {
                goto End1;
            }
            if (serialPort9.IsOpen == false)
            {
                serialPort9.PortName = listBox2.Items[8].ToString();
                serialPort9.BaudRate = 9600;
                serialPort9.DataBits = 8;
                serialPort9.RtsEnable = true;
            }
            if (count <= 9)
            {
                goto End1;
            }
            if (serialPort10.IsOpen == false)
            {
                serialPort10.PortName = listBox2.Items[9].ToString();
                serialPort10.BaudRate = 9600;
                serialPort10.DataBits = 8;
                serialPort10.RtsEnable = true;
            }

        End1:;
            spconnect();

        }
        private async void spconnect()
        {
        
            int count = listBox2.Items.Count;
            if (count == 0)
            {
                goto End;
            }
            if (serialPort1.IsOpen == false)
            {
                await Sp0();
            }
            if (count <= 1)
            {
                goto End;
            }
            if (serialPort2.IsOpen == false)
            {
                await Sp1();
            }
            if (count <= 2)
            {
                goto End;
            }
            if (serialPort3.IsOpen == false)
            {
                await Sp2();
            }
            if (count <= 3)
            {
                goto End;
            }
            if (serialPort4.IsOpen == false)
            {
                await Sp3();
            }
            if (count <= 4)
            {
                goto End;
            }
            if (serialPort5.IsOpen == false)
            {
                await Sp4();
            }
            if (count <= 5)
            {
                goto End;
            }
            if (serialPort6.IsOpen == false)
            {
                await Sp5();
            }
            if (count <= 6)
            {
                goto End;
            }
            if (serialPort7.IsOpen == false)
            {
                await Sp6();
            }
            if (count <= 7)
            {
                goto End;
            }
            if (serialPort8.IsOpen == false)
            {
                await Sp7();
            }
            if (count <= 8)
            {
                goto End;
            }
            if (serialPort9.IsOpen == false)
            {
                await Sp8();
            }
            if (count <= 9)
            {
                goto End;
            }
            if (serialPort10.IsOpen == false)
            {
                await Sp9();
            }
            
            
        End:;

        }
        private async Task Sp0()
        {
            int a = 0;
            

            while (serialPort1.IsOpen == false)
            {
                serialPort1.Dispose();
                serialPort1.Close();
                try
                {
                    serialPort1.Open();

                }
                catch
                {
                    a += 1;
                    listBox3.Items[0] = $"연결중....... {a}회 시도중";
                    if (a >= trycount())
                    {
                        break;
                    }

                }
                await Task.Delay(1);
            }
            if (serialPort1.IsOpen == true)
            {
                listBox3.Items[0] = "연결됨";
                
            }
            else if (serialPort1.IsOpen == false)
            {
                listBox3.Items[0] = "연결실패";
                
            }
            listBox4.Items[0] = " ";
            listBox4.Items[0] = $"{a}회 시도";


        }
        private async Task Sp1()
        {
            int a = 0;
            
            while (serialPort2.IsOpen == false)
            {
                serialPort2.Dispose();
                serialPort2.Close();
                try
                {
                    serialPort2.Open();

                }
                catch
                {
                    a += 1;
                    listBox3.Items[1] = $"연결중....... {a}회 시도중".ToString();
                    if (a >= trycount())
                    {
                        break;
                    }

                }
                await Task.Delay(1);
            }
            if (serialPort2.IsOpen == true)
            {
                listBox3.Items[1] = "연결됨";
              
            }
            else if (serialPort2.IsOpen == false)
            {
                listBox3.Items[1] = "연결실패";

            }
            listBox4.Items[1] = " ";
            listBox4.Items[1] = $"{a}회 시도";


        }
        private async Task Sp2()
        {
            int a = 0;
            
            while (serialPort3.IsOpen == false)
            {
                serialPort3.Dispose();
                serialPort3.Close();
                try
                {
                    serialPort3.Open();

                }
                catch
                {
                    a += 1;
                    listBox3.Items[2] = $"연결중....... {a}회 시도중".ToString();
                    if (a >= trycount())
                    {
                        break;
                    }

                }
                await Task.Delay(1);
            }
            if (serialPort3.IsOpen == true)
            {
                listBox3.Items[2] = "연결됨";
                
            }
            else if (serialPort3.IsOpen == false)
            {
                listBox3.Items[2] = "연결실패";

            }
            listBox4.Items[2] = " ";
            listBox4.Items[2] = $"{a}회 시도";


        }
        private async Task Sp3()
        {
            int a = 0;
            
            while (serialPort4.IsOpen == false)
            {
                serialPort4.Dispose();
                serialPort4.Close();
                try
                {
                    serialPort4.Open();

                }
                catch
                {
                    a += 1;
                    listBox3.Items[3] = $"연결중....... {a}회 시도중".ToString();
                    if (a >= trycount())
                    {
                        break;
                    }

                }
                await Task.Delay(1);
            }
            if (serialPort4.IsOpen == true)
            {
                listBox3.Items[3] = "연결됨";
                
            }
            else if (serialPort4.IsOpen == false)
            {
                listBox3.Items[3] = "연결실패";

            }
            listBox4.Items[3] = " ";
            listBox4.Items[3] = $"{a}회 시도";


        }
        private async Task Sp4()
        {
            int a = 0;
            
            while (serialPort5.IsOpen == false)
            {
                serialPort5.Dispose();
                serialPort5.Close();
                try
                {
                    serialPort5.Open();

                }
                catch
                {
                    a += 1;
                    listBox3.Items[4] = $"연결중....... {a}회 시도중".ToString();
                    if (a >= trycount())
                    {
                        break;
                    }

                }
                await Task.Delay(1);
            }
            if (serialPort5.IsOpen == true)
            {
                listBox3.Items[4] = "연결됨";
                
            }
            else if (serialPort5.IsOpen == false)
            {
                listBox3.Items[4] = "연결실패";

            }
            listBox4.Items[4] = " ";
            listBox4.Items[4] = $"{a}회 시도";


        }
        private async Task Sp5()
        {
            int a = 0;
            
            while (serialPort6.IsOpen == false)
            {
                serialPort6.Dispose();
                serialPort6.Close();
                try
                {
                    serialPort6.Open();

                }
                catch
                {
                    a += 1;
                    listBox3.Items[5] = $"연결중....... {a}회 시도중".ToString();
                    if (a >= trycount())
                    {
                        break;
                    }

                }
                await Task.Delay(1);
            }
            if (serialPort6.IsOpen == true)
            {
                listBox3.Items[5] = "연결됨";
                
            }
            else if (serialPort6.IsOpen == false)
            {
                listBox3.Items[5] = "연결실패";

            }
            listBox4.Items[5] = " ";
            listBox4.Items[5] = $"{a}회 시도";


        }
        private async Task Sp6()
        {
            int a = 0;
            
            while (serialPort7.IsOpen == false)
            {
                serialPort7.Dispose();
                serialPort7.Close();
                try
                {
                    serialPort7.Open();

                }
                catch
                {
                    a += 1;
                    listBox3.Items[6] = $"연결중....... {a}회 시도중".ToString();
                    if (a >= trycount())
                    {
                        break;
                    }

                }
                await Task.Delay(1);
            }
            if (serialPort7.IsOpen == true)
            {
                listBox3.Items[6] = "연결됨";
                
            }
            else if (serialPort7.IsOpen == false)
            {
                listBox3.Items[6] = "연결실패";

            }
            listBox4.Items[6] = " ";
            listBox4.Items[6] = $"{a}회 시도";


        }
        private async Task Sp7()
        {
            int a = 0;
            
            while (serialPort8.IsOpen == false)
            {
                serialPort8.Dispose();
                serialPort8.Close();
                try
                {
                    serialPort8.Open();

                }
                catch
                {
                    a += 1;
                    listBox3.Items[7] = $"연결중....... {a}회 시도중".ToString();
                    if (a >= trycount())
                    {
                        break;
                    }

                }
                await Task.Delay(1);
            }
            if (serialPort8.IsOpen == true)
            {
                listBox3.Items[7] = "연결됨";
              
            }
            else if (serialPort8.IsOpen == false)
            {
                listBox3.Items[7] = "연결실패";

            }
            listBox4.Items[7] = " ";
            listBox4.Items[7] = $"{a}회 시도";


        }
        private async Task Sp8()
        {
            int a = 0;
            
            while (serialPort9.IsOpen == false)
            {
                serialPort9.Dispose();
                serialPort9.Close();
                try
                {
                    serialPort9.Open();

                }
                catch
                {
                    a += 1;
                    listBox3.Items[8] = $"연결중....... {a}회 시도중".ToString();
                    if (a >= trycount())
                    {
                        break;
                    }

                }
                await Task.Delay(1);
            }
            if (serialPort9.IsOpen == true)
            {
                listBox3.Items[8] = "연결됨";
                
            }
            else if (serialPort9.IsOpen == false)
            {
                listBox3.Items[8] = "연결실패";

            }
            listBox4.Items[8] = " ";
            listBox4.Items[8] = $"{a}회 시도";


        }
        private async Task Sp9()
        {
            int a = 0;
            
            while (serialPort10.IsOpen == false)
            {
                serialPort10.Dispose();
                serialPort10.Close();
                try
                {
                    serialPort10.Open();

                }
                catch
                {
                    a += 1;
                    listBox3.Items[9] = $"연결중....... {a}회 시도중".ToString();
                    if (a >= trycount())
                    {
                        break;
                    }

                }
                await Task.Delay(1);
            }
            if (serialPort10.IsOpen == true)
            {
                listBox3.Items[9] = "연결됨";
                
            }
            else if (serialPort10.IsOpen == false)
            {
                listBox3.Items[9] = "연결실패";

            }
            listBox4.Items[9] = " ";
            listBox4.Items[9] = $"{a}회 시도";


        }

        private int trycount()
        {
            string a = numericUpDown1.Value.ToString();
            int b = Int32.Parse(a);
            return b;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void allclose()
        {
            int count = listBox2.Items.Count;
           
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Close();
            }
          
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Close(); ;
            }
          
            if (serialPort3.IsOpen == true)
            {
                serialPort3.Close();
            }
           
            if (serialPort4.IsOpen == true)
            {
                serialPort4.Close();
            }
            
            if (serialPort5.IsOpen == true)
            {
                serialPort5.Close();
            }
            
            if (serialPort6.IsOpen == true)
            {
                serialPort6.Close();
            }
            
            if (serialPort7.IsOpen == true)
            {
                serialPort7.Close();
            }
           
            if (serialPort8.IsOpen == true)
            {
                serialPort8.Close();
            }
            
            if (serialPort9.IsOpen == true)
            {
                serialPort9.Close();
            }
            
            if (serialPort10.IsOpen == true)
            {
                serialPort10.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            byte[] packet= new byte[] { 0xff, 0x55, 0x01, 0xfe, 0x00, 0xff };
            byte[] packet0 = new byte[] { 0xff, 0x55, 0x00, 0xff, 0x00, 0xff };
            if (serialPort1.IsOpen==true)
            {
                serialPort1.Write(packet, 0, 6);
                serialPort1.Write(packet0, 0, 6);
            }
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Write(packet, 0, 6);
                serialPort2.Write(packet0, 0, 6);
            }
            if (serialPort3.IsOpen == true)
            {
                serialPort3.Write(packet, 0, 6);
                serialPort3.Write(packet0, 0, 6);
            }
            if (serialPort4.IsOpen == true)
            {
                serialPort4.Write(packet, 0, 6);
                serialPort4.Write(packet0, 0, 6);
            }
            if (serialPort5.IsOpen == true)
            {
                serialPort5.Write(packet, 0, 6);
                serialPort5.Write(packet0, 0, 6);
            }
            if (serialPort6.IsOpen == true)
            {
                serialPort6.Write(packet, 0, 6);
                serialPort6.Write(packet0, 0, 6);
            }
            if (serialPort7.IsOpen == true)
            {
                serialPort7.Write(packet, 0, 6);
                serialPort7.Write(packet0, 0, 6);
            }
            if (serialPort8.IsOpen == true)
            {
                serialPort8.Write(packet, 0, 6);
                serialPort8.Write(packet0, 0, 6);
            }
            if (serialPort9.IsOpen == true)
            {
                serialPort9.Write(packet, 0, 6);
                serialPort9.Write(packet0, 0, 6);
            }
            if (serialPort10.IsOpen == true)
            {
                serialPort10.Write(packet, 0, 6);
                serialPort10.Write(packet0, 0, 6);
            }
            if(checkBox1.Checked ==true)
            {
                playSimpleSound();
            }


        }

        private void button11_Click(object sender, EventArgs e)
        {
            byte[] packet = new byte[] { 0xff, 0x55, 0x08, 0xf7, 0x00, 0xff };
            byte[] packet0 = new byte[] { 0xff, 0x55, 0x00, 0xff, 0x00, 0xff };
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Write(packet, 0, 6);
                serialPort1.Write(packet0, 0, 6);
            }
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Write(packet, 0, 6);
                serialPort2.Write(packet0, 0, 6);
            }
            if (serialPort3.IsOpen == true)
            {
                serialPort3.Write(packet, 0, 6);
                serialPort3.Write(packet0, 0, 6);
            }
            if (serialPort4.IsOpen == true)
            {
                serialPort4.Write(packet, 0, 6);
                serialPort4.Write(packet0, 0, 6);
            }
            if (serialPort5.IsOpen == true)
            {
                serialPort5.Write(packet, 0, 6);
                serialPort5.Write(packet0, 0, 6);
            }
            if (serialPort6.IsOpen == true)
            {
                serialPort6.Write(packet, 0, 6);
                serialPort6.Write(packet0, 0, 6);
            }
            if (serialPort7.IsOpen == true)
            {
                serialPort7.Write(packet, 0, 6);
                serialPort7.Write(packet0, 0, 6);
            }
            if (serialPort8.IsOpen == true)
            {
                serialPort8.Write(packet, 0, 6);
                serialPort8.Write(packet0, 0, 6);
            }
            if (serialPort9.IsOpen == true)
            {
                serialPort9.Write(packet, 0, 6);
                serialPort9.Write(packet0, 0, 6);
            }
            if (serialPort10.IsOpen == true)
            {
                serialPort10.Write(packet, 0, 6);
                serialPort10.Write(packet0, 0, 6);
            }
            if (checkBox1.Checked == true)
            {
                playSimpleSound();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            byte[] packet = new byte[] { 0xff, 0x55, 0x04, 0xfb, 0x00, 0xff };
            byte[] packet0 = new byte[] { 0xff, 0x55, 0x00, 0xff, 0x00, 0xff };
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Write(packet, 0, 6);
                serialPort1.Write(packet0, 0, 6);
            }
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Write(packet, 0, 6);
                serialPort2.Write(packet0, 0, 6);
            }
            if (serialPort3.IsOpen == true)
            {
                serialPort3.Write(packet, 0, 6);
                serialPort3.Write(packet0, 0, 6);
            }
            if (serialPort4.IsOpen == true)
            {
                serialPort4.Write(packet, 0, 6);
                serialPort4.Write(packet0, 0, 6);
            }
            if (serialPort5.IsOpen == true)
            {
                serialPort5.Write(packet, 0, 6);
                serialPort5.Write(packet0, 0, 6);
            }
            if (serialPort6.IsOpen == true)
            {
                serialPort6.Write(packet, 0, 6);
                serialPort6.Write(packet0, 0, 6);
            }
            if (serialPort7.IsOpen == true)
            {
                serialPort7.Write(packet, 0, 6);
                serialPort7.Write(packet0, 0, 6);
            }
            if (serialPort8.IsOpen == true)
            {
                serialPort8.Write(packet, 0, 6);
                serialPort8.Write(packet0, 0, 6);
            }
            if (serialPort9.IsOpen == true)
            {
                serialPort9.Write(packet, 0, 6);
                serialPort9.Write(packet0, 0, 6);
            }
            if (serialPort10.IsOpen == true)
            {
                serialPort10.Write(packet, 0, 6);
                serialPort10.Write(packet0, 0, 6);
            }
            if (checkBox1.Checked == true)
            {
                playSimpleSound();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            byte[] packet = new byte[] { 0xff, 0x55, 0x02, 0xfd, 0x00, 0xff };
            byte[] packet0 = new byte[] { 0xff, 0x55, 0x00, 0xff, 0x00, 0xff };
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Write(packet, 0, 6);
                serialPort1.Write(packet0, 0, 6);
            }
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Write(packet, 0, 6);
                serialPort2.Write(packet0, 0, 6);
            }
            if (serialPort3.IsOpen == true)
            {
                serialPort3.Write(packet, 0, 6);
                serialPort3.Write(packet0, 0, 6);
            }
            if (serialPort4.IsOpen == true)
            {
                serialPort4.Write(packet, 0, 6);
                serialPort4.Write(packet0, 0, 6);
            }
            if (serialPort5.IsOpen == true)
            {
                serialPort5.Write(packet, 0, 6);
                serialPort5.Write(packet0, 0, 6);
            }
            if (serialPort6.IsOpen == true)
            {
                serialPort6.Write(packet, 0, 6);
                serialPort6.Write(packet0, 0, 6);
            }
            if (serialPort7.IsOpen == true)
            {
                serialPort7.Write(packet, 0, 6);
                serialPort7.Write(packet0, 0, 6);
            }
            if (serialPort8.IsOpen == true)
            {
                serialPort8.Write(packet, 0, 6);
                serialPort8.Write(packet0, 0, 6);
            }
            if (serialPort9.IsOpen == true)
            {
                serialPort9.Write(packet, 0, 6);
                serialPort9.Write(packet0, 0, 6);
            }
            if (serialPort10.IsOpen == true)
            {
                serialPort10.Write(packet, 0, 6);
                serialPort10.Write(packet0, 0, 6);
            }
            if (checkBox1.Checked == true)
            {
                playSimpleSound();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            byte[] packet = new byte[] { 0xff, 0x55, 0x10, 0xef, 0x00, 0xff };
            byte[] packet0 = new byte[] { 0xff, 0x55, 0x00, 0xff, 0x00, 0xff };
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Write(packet, 0, 6);
                serialPort1.Write(packet0, 0, 6);
            }
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Write(packet, 0, 6);
                serialPort2.Write(packet0, 0, 6);
            }
            if (serialPort3.IsOpen == true)
            {
                serialPort3.Write(packet, 0, 6);
                serialPort3.Write(packet0, 0, 6);
            }
            if (serialPort4.IsOpen == true)
            {
                serialPort4.Write(packet, 0, 6);
                serialPort4.Write(packet0, 0, 6);
            }
            if (serialPort5.IsOpen == true)
            {
                serialPort5.Write(packet, 0, 6);
                serialPort5.Write(packet0, 0, 6);
            }
            if (serialPort6.IsOpen == true)
            {
                serialPort6.Write(packet, 0, 6);
                serialPort6.Write(packet0, 0, 6);
            }
            if (serialPort7.IsOpen == true)
            {
                serialPort7.Write(packet, 0, 6);
                serialPort7.Write(packet0, 0, 6);
            }
            if (serialPort8.IsOpen == true)
            {
                serialPort8.Write(packet, 0, 6);
                serialPort8.Write(packet0, 0, 6);
            }
            if (serialPort9.IsOpen == true)
            {
                serialPort9.Write(packet, 0, 6);
                serialPort9.Write(packet0, 0, 6);
            }
            if (serialPort10.IsOpen == true)
            {
                serialPort10.Write(packet, 0, 6);
                serialPort10.Write(packet0, 0, 6);
            }
            if (checkBox1.Checked == true)
            {
                playSimpleSound();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            byte[] packet = new byte[] { 0xff, 0x55, 0x20, 0xdf, 0x00, 0xff };
            byte[] packet0 = new byte[] { 0xff, 0x55, 0x00, 0xff, 0x00, 0xff };
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Write(packet, 0, 6);
                serialPort1.Write(packet0, 0, 6);
            }
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Write(packet, 0, 6);
                serialPort2.Write(packet0, 0, 6);
            }
            if (serialPort3.IsOpen == true)
            {
                serialPort3.Write(packet, 0, 6);
                serialPort3.Write(packet0, 0, 6);
            }
            if (serialPort4.IsOpen == true)
            {
                serialPort4.Write(packet, 0, 6);
                serialPort4.Write(packet0, 0, 6);
            }
            if (serialPort5.IsOpen == true)
            {
                serialPort5.Write(packet, 0, 6);
                serialPort5.Write(packet0, 0, 6);
            }
            if (serialPort6.IsOpen == true)
            {
                serialPort6.Write(packet, 0, 6);
                serialPort6.Write(packet0, 0, 6);
            }
            if (serialPort7.IsOpen == true)
            {
                serialPort7.Write(packet, 0, 6);
                serialPort7.Write(packet0, 0, 6);
            }
            if (serialPort8.IsOpen == true)
            {
                serialPort8.Write(packet, 0, 6);
                serialPort8.Write(packet0, 0, 6);
            }
            if (serialPort9.IsOpen == true)
            {
                serialPort9.Write(packet, 0, 6);
                serialPort9.Write(packet0, 0, 6);
            }
            if (serialPort10.IsOpen == true)
            {
                serialPort10.Write(packet, 0, 6);
                serialPort10.Write(packet0, 0, 6);
            }
            if (checkBox1.Checked == true)
            {
                playSimpleSound();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            byte[] packet = new byte[] { 0xff, 0x55, 0x40, 0xbf, 0x00, 0xff };
            byte[] packet0 = new byte[] { 0xff, 0x55, 0x00, 0xff, 0x00, 0xff };
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Write(packet, 0, 6);
                serialPort1.Write(packet0, 0, 6);
            }
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Write(packet, 0, 6);
                serialPort2.Write(packet0, 0, 6);
            }
            if (serialPort3.IsOpen == true)
            {
                serialPort3.Write(packet, 0, 6);
                serialPort3.Write(packet0, 0, 6);
            }
            if (serialPort4.IsOpen == true)
            {
                serialPort4.Write(packet, 0, 6);
                serialPort4.Write(packet0, 0, 6);
            }
            if (serialPort5.IsOpen == true)
            {
                serialPort5.Write(packet, 0, 6);
                serialPort5.Write(packet0, 0, 6);
            }
            if (serialPort6.IsOpen == true)
            {
                serialPort6.Write(packet, 0, 6);
                serialPort6.Write(packet0, 0, 6);
            }
            if (serialPort7.IsOpen == true)
            {
                serialPort7.Write(packet, 0, 6);
                serialPort7.Write(packet0, 0, 6);
            }
            if (serialPort8.IsOpen == true)
            {
                serialPort8.Write(packet, 0, 6);
                serialPort8.Write(packet0, 0, 6);
            }
            if (serialPort9.IsOpen == true)
            {
                serialPort9.Write(packet, 0, 6);
                serialPort9.Write(packet0, 0, 6);
            }
            if (serialPort10.IsOpen == true)
            {
                serialPort10.Write(packet, 0, 6);
                serialPort10.Write(packet0, 0, 6);
            }
            if (checkBox1.Checked == true)
            {
                playSimpleSound();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            byte[] packet = new byte[] { 0xff, 0x55, 0x80, 0x7f, 0x00, 0xff };
            byte[] packet0 = new byte[] { 0xff, 0x55, 0x00, 0xff, 0x00, 0xff };
            if (serialPort1.IsOpen == true)
            {
                serialPort1.Write(packet, 0, 6);
                serialPort1.Write(packet0, 0, 6);
            }
            if (serialPort2.IsOpen == true)
            {
                serialPort2.Write(packet, 0, 6);
                serialPort2.Write(packet0, 0, 6);
            }
            if (serialPort3.IsOpen == true)
            {
                serialPort3.Write(packet, 0, 6);
                serialPort3.Write(packet0, 0, 6);
            }
            if (serialPort4.IsOpen == true)
            {
                serialPort4.Write(packet, 0, 6);
                serialPort4.Write(packet0, 0, 6);
            }
            if (serialPort5.IsOpen == true)
            {
                serialPort5.Write(packet, 0, 6);
                serialPort5.Write(packet0, 0, 6);
            }
            if (serialPort6.IsOpen == true)
            {
                serialPort6.Write(packet, 0, 6);
                serialPort6.Write(packet0, 0, 6);
            }
            if (serialPort7.IsOpen == true)
            {
                serialPort7.Write(packet, 0, 6);
                serialPort7.Write(packet0, 0, 6);
            }
            if (serialPort8.IsOpen == true)
            {
                serialPort8.Write(packet, 0, 6);
                serialPort8.Write(packet0, 0, 6);
            }
            if (serialPort9.IsOpen == true)
            {
                serialPort9.Write(packet, 0, 6);
                serialPort9.Write(packet0, 0, 6);
            }
            if (serialPort10.IsOpen == true)
            {
                serialPort10.Write(packet, 0, 6);
                serialPort10.Write(packet0, 0, 6);
            }
            if (checkBox1.Checked == true)
            {
                playSimpleSound();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            allclose();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                listBox3.Items.Add(" ");
            }
            for (int i = 0; i < 10; i++)
            {
                listBox4.Items.Add(" ");
            }
        }

        private void playSimpleSound()
        {
            try
            {
                if (music != " ")
                {
                    
                    SoundPlayer simpleSound = new SoundPlayer($@"{music}");
                    simpleSound.Play();

                }
                    
            }
            catch
            {
                MessageBox.Show("잘못된 접근 입니다.");
               
            }
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            playSimpleSound();
           
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                if (music != " ")
                {

                    SoundPlayer simpleSound = new SoundPlayer($@"{music}");
                    simpleSound.Stop();

                }

            }
            catch
            {
                MessageBox.Show("잘못된 접근 입니다.");

            }
            
        }

        private void button18_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            var fileContent = string.Empty;
            var filePath = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog1.FileName;
                //label1.Text = filePath.ToString();
                if (filePath.ToString().Split('.').Last() != "wav")
                {
                    MessageBox.Show("wav 파일을 선택해 주세요.");
                }
                else if (filePath.ToString().Split('.').Last() == "wav")
                {
                    music = filePath.ToString();
                    musicname = filePath.ToString().Split('\\').Last().Split('.')[0];
                    listBox5.Items.Clear();
                    listBox5.Items.Add(musicname);
                }

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            playSimpleSound();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
       
    }

   

}
/*
    ##로보티즈 조종기 패킷##
0xff,0x55,0x00,0xff,0x00,0xff #0
0xff,0x55,0x01,0xfe,0x00,0xff #U
0xff,0x55,0x02,0xfd,0x00,0xff #D
0xff,0x55,0x04,0xfb,0x00,0xff #L
0xff,0x55,0x08,0xf7,0x00,0xff #R
 */
