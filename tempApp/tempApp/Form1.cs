using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace tempApp
{
    
    public partial class Form1 : Form
    {
        String str, strdata,senddata;
        String writetext1,writetext2,writetext3;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openbtn_Click(object sender, EventArgs e)
        {
            try {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                else
                {
                    serialPort1.PortName = comboBoxPort.SelectedItem + "";
                    serialPort1.Open();
                }
            }catch(Exception ex){
                MessageBox.Show("Port Not Connet");
            }
            
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Port Error");
            
            }
            
        }

        private void sendbtn_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("ข้อมูลไม่ครบ");
            }
            else {
                try
                {
                    serialPort1.Write("1");
                    serialPort1.Write("2");
                    serialPort1.Write("3");

                    try
                    {
                        writetext1 = "";
                        writetext2 = "";
                        writetext3 = "";
                        senddata = "";
                    }
                    catch (Exception ex2)
                    {
                        writetext1 = "";
                        writetext2 = "";
                        writetext3 = "";
                        senddata = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Port Not Open");
                }
 
            }            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxData_TextChanged(object sender, EventArgs e)
        {
            
     
    }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] strPortNames = SerialPort.GetPortNames();
            foreach (string n in strPortNames)
            {
                comboBoxPort.Items.Add(n);
            }
            comboBoxPort.SelectedIndex = 0;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string s = serialPort1.ReadLine();

            string[] sArray = s.Split('=');
            String[] readArry = sArray[0].Split('_');
            //MessageBox.Show(sArray[0] + " " + sArray[1] + Environment.NewLine + (sArray[0] == "ID_2") + Environment.NewLine + (sArray[0] == "ID_3"));

                if (sArray[0] == "ID_3")
                {
                    textBoxData.AppendText("Com Address" + textBox4.Text + "  " + s + " เวลา : " + DateTime.Now.ToString("HH:mm:ss") + "\n");
                    textBoxData.AppendText("\n");
                    writetext1 = sArray[1];
                }
                else if (sArray[0] == "ID_2")
                {
                    textBoxData.AppendText("Com Address" + textBox3.Text + "  " + s + " เวลา : " + DateTime.Now.ToString("HH:mm:ss") + "\n");
                    textBoxData.AppendText("\n");
                    writetext2 = sArray[1];
                }
                else if (sArray[0] == "ID_1")
                {
                    textBoxData.AppendText("Com Address" + textBox2.Text + "  " + s + " เวลา : " + DateTime.Now.ToString("HH:mm:ss") + "\n");
                    textBoxData.AppendText("\n");
                    writetext3 =sArray[1];
                }
                else
                {
                    MessageBox.Show("notdata");
                }
                senddata = "ID01(" + textBox2.Text + ")=" + writetext3 + ",ID02(" + textBox3.Text + ")=" + writetext2 + "," + "ID03(" + textBox4.Text + ")=" + writetext1+",";
        }
    }
   }
