using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Sort;


namespace Ado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool boo = false;
        int tim;
        int T;
        int len;
        string abb;
        readonly Feedback aas = new Feedback();
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.ForeColor = Color.FromArgb(255, 255, 128);
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    comboBox1.BackColor = Color.White;
                    comboBox2.BackColor = Color.White;
                    richTextBox2.Text = comboBox1.Text.ToString() + " Disconnect";
                }
                else
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.Open();


                    if (serialPort1.IsOpen)
                    {
                       
                        comboBox1.BackColor = Color.GreenYellow;
                        comboBox2.BackColor = Color.GreenYellow;
                        richTextBox2.Text = comboBox1.Text.ToString() + "  Connect Success";
                    }
                    else
                    {
                        MessageBox.Show("Fail");
                    }
                }
             
            }
            catch (Exception)
            {
                MessageBox.Show("Fail");
          
            }


            //read
            richTextBox2.Text += "\r\nLoading...";
            tim = 0;
            timer2.Enabled = true;
            boo = true;
        }

     
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text += "\r\nLoading...";
            tim = 0;
            timer2.Enabled = true;
            boo = true;
            //serialPort1.DiscardOutBuffer();

            //    //Thread.Sleep(100);
            //    int readbytesMEMSX;
            //readbytesMEMSX = serialPort1.BytesToRead;
            //if (readbytesMEMSX != 0)
            //{

            //    char[] readCharMEMSX = new char[readbytesMEMSX];
            //    //_ = readCharMEMSX[readbytesMEMSX];
            //    serialPort1.Read(readCharMEMSX, 0, readbytesMEMSX);
            //    richTextBox2.Text = aas.feedbackString(readCharMEMSX, readbytesMEMSX);
            //    abb = aas.feedbackString(readCharMEMSX, readbytesMEMSX);
            //}



        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] bufferData = new byte[serialPort1.BytesToRead];
          
            serialPort1.Read(bufferData, 0, bufferData.Length);
         
            abb = serialPort1.Read(bufferData, 0, bufferData.Length).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int i;
            string[] COMPort = System.IO.Ports.SerialPort.GetPortNames();
            string[] baud = { "57600","115200" };
            comboBox2.Items.AddRange(baud);
            comboBox2.Text = "57600";

            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            i = COMPort.Length - 1;
            comboBox1.Text = COMPort[i];
            Console.WriteLine();
            T = COMPort.Length;
        }


        //string[] testNew = new string[bytes - 1];

       // to
        // testNew[i] = Convert.ToString(text[i]);
       
        //string result = string.Join("", testNew);

        //return result;
        public void RR()
        {

            string st = abb;
            string[] sArray = st.Split('#');
            int n = sArray.Length;
            string[] AsArray = new string[n];

            for (int i = 0; i < n; i++)
            {

                switch (sArray[i])
                {
                    case "A":
                        sArray[i] = "LD Current";
                        break;
                    case "C":
                        sArray[i] = "˚C";
                        break;
                    case "N":
                        sArray[i] = "PD A out Volt ";
                        break;
                    case "P":
                        sArray[i] = "PD B out Volt ";
                        break;
                    case "S":
                        sArray[i] = "S8 Connect state";
                        break;
                    case "T":
                        sArray[i] = "TM3 Connection status";
                        break;
                    case " \n1":
                        sArray[i] = "Message=>";
                        break;
                    case " \r\n1":
                        sArray[i] = "Message=>";
                        break;
                    case "\n \n1":
                        sArray[i] = "Message=>";
                        break;
                    case "V":
                        sArray[i] = "PD data adjust result";
                        break;
                    default:
                        break;
                }

            }



            for (int i = 0; i < n; i++)
            {
                AsArray[i] = sArray[i];
            }

            if (AsArray[0] == "Message=>")
            {

                richTextBox2.Text += ("\r\n" + AsArray[0] + "\r\n" + AsArray[2] + AsArray[1] + "\r\n" + AsArray[3] + ": " + AsArray[4] + "\r\n" + AsArray[5] + ": " + AsArray[6] + "\r\n" + AsArray[7] + ": " + AsArray[8] + "\r\n" + AsArray[9] + ": " + AsArray[10] + AsArray[11] + "\r\n" + AsArray[12] + ": " + AsArray[13] + "\r\n" + AsArray[15] + ": " + AsArray[16] + " mA");

            }



        }
            
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string st = abb;
                string[] sArray = st.Split('#');
                int n = sArray.Length;
                string[] AsArray = new string[n];

                for (int i = 0; i < n; i++)
                {

                    switch (sArray[i])
                    {
                        case "A":
                        sArray[i] = "LD Current";
                        break;
                    case "C":
                        sArray[i] = "˚C";
                        break;
                    case "N":
                        sArray[i] = "PD A out Volt ";
                        break;
                    case "P":
                        sArray[i] = "PD B out Volt ";
                        break;
                    case "S":
                        sArray[i] = "S8 Connect state";
                        break;
                    case "T":
                        sArray[i] = "TM3 Connection status";
                        break;
                    case " \n1":
                        sArray[i] = "Message=>";
                        break;
                    case " \r\n1":
                        sArray[i] = "Message=>";
                        break;
                    case "\n \n1":
                        sArray[i] = "Message=>";
                        break;
                    case "V":
                        sArray[i] = "PD data adjust result";
                        break;
                    default:
                        break;
                    }

                }



                for (int i = 0; i < n; i++)
                {
                    AsArray[i] = sArray[i];
                }

                if (AsArray[0] == "Message >>")
                {

                    richTextBox2.Text += ("\r\n" + AsArray[0] + "\r\n" + AsArray[2] + AsArray[1] + "\r\n" + AsArray[3] + ": " + AsArray[4] + "\r\n" + AsArray[5] + ": " + AsArray[6] + "\r\n" + AsArray[7] + ": " + AsArray[8] + "\r\n" + AsArray[9] + ": " + AsArray[10] + AsArray[11] + "\r\n" + AsArray[12] + ": " + AsArray[13] + "\r\n" + AsArray[15] + ": " + AsArray[16] + " mA");

                }
            }
            catch (Exception)
            {

         
            }
            





        }

        private void button6_Click(object sender, EventArgs e)
        {
          
            richTextBox2.Text = "";
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] COMPort = System.IO.Ports.SerialPort.GetPortNames();
           
            if (T != len)
            {

                int i = COMPort.Length - 1;
                T = COMPort.Length;
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                i = COMPort.Length - 1;
                comboBox1.Text = COMPort[i];
                Console.WriteLine();
                T = COMPort.Length;
                len = COMPort.Length;
                comboBox1.BackColor = Color.White;
                comboBox2.BackColor = Color.White;
            }
            else
            {
                len = COMPort.Length;
            }

           
          
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                serialPort1.DiscardOutBuffer();

                if (boo == true)
                {
                    tim += 1;
                }

                //Thread.Sleep(100);
                int readbytesMEMSX;
                readbytesMEMSX = serialPort1.BytesToRead;
                if (readbytesMEMSX != 0)
                {

                    char[] readCharMEMSX = new char[readbytesMEMSX];
                    //_ = readCharMEMSX[readbytesMEMSX];
                    serialPort1.Read(readCharMEMSX, 0, readbytesMEMSX);
                    richTextBox2.Text = aas.feedbackString(readCharMEMSX, readbytesMEMSX);




                    abb = aas.feedbackString(readCharMEMSX, readbytesMEMSX);
                    boo = false;

                    //----------------------------------
                    try
                    {
                        string Str_BsArray = "";
                        string Str_BsArray2 = "";
                        string st = abb;
                        string[] sArray = st.Split('#');
                        int n = sArray.Length;
                        string[] AsArray = new string[n];

                        for (int i = 0; i < n; i++)
                        {

                            switch (sArray[i])
                            {
                                case "A":
                                    sArray[i] = "LD Current";
                                    break;
                                case "C":
                                    sArray[i] = "˚C";
                                    break;
                                case "N":
                                    sArray[i] = "PD A out Volt ";
                                    break;
                                case "P":
                                    sArray[i] = "PD B out Volt ";
                                    break;
                                case "S":
                                    sArray[i] = "S8 Connect state";
                                    break;
                                case "T":
                                    sArray[i] = "TM3 Connection status";
                                    break;
                                case " \n1":
                                    sArray[i] = "Message >>";
                                    break;
                                case " \r\n1":
                                    sArray[i] = "Message >>";
                                    break;
                                case "\n \n1":
                                    sArray[i] = "Message >>";
                                    break;
                                case "V":
                                    sArray[i] = "PD data adjust result";
                                    break;
                                default:
                                    break;
                            }

                        }



                        for (int i = 0; i < n; i++)
                        {
                            AsArray[i] = sArray[i];
                        }

                        if (AsArray[0] == "Message >>")
                        {
                            double BsArray = int.Parse(AsArray[6]) / 100.00;
                            double BsArray2 = int.Parse(AsArray[8]) / 100.00;
                            richTextBox2.Text += ("\r\n" + AsArray[0] + "\r\n" + "\r\n" + AsArray[2] + AsArray[1] + "\r\n" + AsArray[3] + ": " + AsArray[4] + "\r\n" + AsArray[5] + ": " + BsArray + " V" + "\r\n" + AsArray[7] + ": " + BsArray2 + " V" + "\r\n" + AsArray[9] + ": " + AsArray[10] + AsArray[11] + "\r\n" + AsArray[12] + ": " + AsArray[13] + "\r\n" + AsArray[15] + ": " + AsArray[16] + " mA" + "\r\n");
                            Str_BsArray = BsArray.ToString();
                            Str_BsArray2 = BsArray2.ToString();

                        }

                        ///11/22
                        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string strFilePath = desktop + "\\Lucio.csv";
                        //string strFilePath = @"D:\YongWei Gao\Desktop\3121.csv";
                        string strSeperator = ",";
                        StringBuilder sbOutput = new StringBuilder();

                        string[][] inaOutput = new string[][]{
                          new string[]{ AsArray[2], AsArray[4], Str_BsArray, Str_BsArray2, AsArray[10], AsArray[13], AsArray[16] }
                    };

                        sbOutput.AppendLine(string.Join(strSeperator, inaOutput[0]));


                        File.AppendAllText(strFilePath, sbOutput.ToString());



                    }
                    catch (Exception)
                    {


                    }
                    richTextBox2.Text += "\r\nLoading...\r\n";
                }
                if (tim >= 6)
                {
                    timer2.Enabled = false;
                    richTextBox2.ForeColor = Color.Red;
                    richTextBox2.Text = "Timeout";

                }
            }
            catch (Exception)
            {

                serialPort1.Close();
            }
           

        
            //--------------------------------------


        }


    }
}
