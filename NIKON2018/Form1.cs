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
using Ini;
using System.IO;

namespace NIKON2018
{
    public partial class Form1 : Form
    {
        string Selected_Port_Baudrate;    //used for storing selected Baudrate and COMport,for displaying purposes 
        SerialPort COMport = new SerialPort();
        Boolean Have_message = false;
        String sRecv;

        int measurment_number = 0;
        int position_number = 0;
        int number_of_col = 1;
        int number_of_rows = 1;
        int column_number = 1;
        int row_number = 0;
        Boolean Index_changed = false;
        Boolean Measurment_started = false;





        public Form1()
        {
            InitializeComponent();

            FOLDERS(); /// Create folders if not found

            //Populate the Combobox with SerialPorts on the System
            ComboBox_Available_SerialPorts.Items.AddRange(SerialPort.GetPortNames());

            // Disable Baudrate Selection also
            ComboBox_Standard_Baudrates.Enabled = false;

            COMport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

        }

        public void FOLDERS()
        {

            String path18 = "test_folder";

            if (Directory.Exists(path18))
            {

            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(path18);
            }


            String path19 = "config";

            if (Directory.Exists(path19))
            {

            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(path19);
            }


            path18 = "config/COM_Settings.ini";

            if (File.Exists(path18))
            {


            }

            else//create it 
            {

                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////		
                IniFile ini = new IniFile("config/COM_Settings.ini");

                ini.IniWriteValue("Info Serial", "File info ", "//File format created by Charles Galea 2018.");
                ini.IniWriteValue("Info Serial", "File Created ", DateTime.Now.ToString());

                ini.IniWriteValue("COMM SETTINGS", "PORT_NUMBER", "COM1");
                ini.IniWriteValue("COMM SETTINGS", "BAUD_RATE", "4800");
                ini.IniWriteValue("COMM SETTINGS", "PARITY", "None");
                ini.IniWriteValue("COMM SETTINGS", "DATA_BITS", "8");


                MessageBox.Show("Please make sure you setup COM Port for the first time");
            }
        }
        private void port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (COMport.BytesToRead == 23) //i need only byte 113 so i use '==3'
            {


                sRecv = COMport.ReadExisting();
                Have_message = true;
                //   label1.Text = sRecv.ToString();
            }


        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Have_message)
            {
                string phrase = sRecv.ToString();



                string[] words = phrase.Split(',');



                String X = words[0].ToString();
                String Y = words[1].ToString();



                Xvalue_label.Text = X;
                Yvalue_label.Text = Y;



                Have_message = false;
                Send_CMD_SXY();//lets reply SXY

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Local Variables
            string Port_Name = ComboBox_Available_SerialPorts.SelectedItem.ToString();    // Store the selected COM port name to "Port_Name" varaiable
            int Baud_Rate = Convert.ToInt32(ComboBox_Standard_Baudrates.SelectedItem); // Convert the string "9600" to int32 9600
                                                                                       //Store the string in Textbox to variable "Data"

            //SerialPort COMport = new SerialPort(Port_Name, Baud_Rate, Parity.None, 8, StopBits.Two); //Create a new  SerialPort Object (defaullt setting -> 8N1)
            COMport.Encoding = Encoding.ASCII;
            COMport.PortName = Port_Name;
            COMport.BaudRate = Baud_Rate;
            COMport.Parity = Parity.None;
            COMport.DataBits = 8;
            COMport.StopBits = StopBits.Two;
            COMport.DtrEnable = true;
            COMport.RtsEnable = true;

            try
            {

                COMport.Open();
            }
            #region  
            catch (UnauthorizedAccessException SerialException) //exception that is thrown when the operating system denies access 
            {
                MessageBox.Show(SerialException.ToString());

                COMport.Close();
            }

            catch (System.IO.IOException SerialException)     // An attempt to set the state of the underlying port failed
            {
                MessageBox.Show(SerialException.ToString());

                COMport.Close();
            }

            catch (InvalidOperationException SerialException) // The specified port on the current instance of the SerialPort is already open
            {
                MessageBox.Show(SerialException.ToString());

                COMport.Close();
            }

            catch //Any other ERROR
            {
                MessageBox.Show("ERROR in Opening Serial PORT -- UnKnown ERROR");
                COMport.Close();
            }
            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {
            COMport.Close();
        }

        private void RESET_button_Click(object sender, EventArgs e)
        {
            Send_CMD_SXY();
        }

        private void Send_CMD_SXY()
        {
            RESET_position_number();

            if (COMport.IsOpen == true)
            {
                String testStr = "SXY\r\n"; // Ascii "53 58 59 0D 0A"
                byte[] buf = System.Text.Encoding.UTF8.GetBytes(testStr);
                COMport.Write(buf, 0, buf.Length);
            }

            else
            {
                //Do nothng
            }
        }

        private void ComboBox_Standard_Baudrates_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Selected_Port_Baudrate = Selected_Port_Baudrate + Environment.NewLine;
            Selected_Port_Baudrate = Selected_Port_Baudrate + ComboBox_Standard_Baudrates.SelectedItem.ToString() + " bps selected";
        }


        private void ComboBox_Available_SerialPorts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Selected_Port_Baudrate = ComboBox_Available_SerialPorts.SelectedItem.ToString() + " Selected"; // Store the Selected COM port

                          

            ComboBox_Standard_Baudrates.Enabled = true;       // Enable Baudrate Selection after COM port is Selected
        }

        private void button4_Click(object sender, EventArgs e)
        {
            INC_position_number();
        }

        public void INC_position_number()
        {
            /*
            position_number++;

            label4.Text = position_number.ToString();
            */
            Index_changed = true;    

    }

        public void RESET_position_number()
        { 
            position_number = 0;
            column_number = 1;
            row_number = 0;

            label4.Text = position_number.ToString();
            label6.Text = row_number.ToString();
            label8.Text = column_number.ToString();
            Index_changed = true;
            Measurment_started = true;
        }

        public void Index_Register()
        {
            
            if (Index_changed)
            {
                int temp = position_number;

                position_number++;

                label4.Text = position_number.ToString();


                if (row_number < ComboBox_Rows.SelectedIndex +2)
                {
                    
                    row_number++;
                   // label6.Text = row_number.ToString();
                    // column_number = column_number;
                }

                if (row_number <= ComboBox_Rows.SelectedIndex + 1 )
                {
                    label6.Text = row_number.ToString();
                }

                if (row_number == ComboBox_Rows.SelectedIndex + 2 && column_number < ComboBox_Columns.SelectedIndex + 1)
                {

                    row_number = 1;
                    label6.Text = row_number.ToString();
                    column_number++;
                    label8.Text = column_number.ToString();
                    // label6.Text = row_number.ToString();
                    // column_number = column_number;
                }
                else if (row_number == ComboBox_Rows.SelectedIndex + 2 && column_number == ComboBox_Columns.SelectedIndex + 1)
                {
                    Send_CMD_SXY(); 

                }


            }

            else
            {
                //nothing 
            }

            Update_map();
            Index_changed = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Index_Register();
        }


 
        private void button5_Click(object sender, EventArgs e)
        {
            MY_PAD1_DRAW(200, 200,45,45, System.Drawing.Color.Red);
            MY_PAD1_DRAW(200, 250, 45, 45, System.Drawing.Color.Red);
            MY_PAD1_DRAW(200, 300, 45, 45, System.Drawing.Color.Red);
            MY_PAD1_DRAW(200, 350, 45, 45, System.Drawing.Color.Red);


            MY_PAD1_FILL(200, 250, 45, 45, System.Drawing.Color.Red);
        }


        private void MY_PAD1_DRAW (int X ,int Y , int width , int height , Color colors)
        {
            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();
            Rectangle window = new Rectangle(X, Y, width, height);
            Pen myPen = new Pen(colors, 3);

            graphicsObj.DrawRectangle(myPen, window);

        }

        private void MY_PAD1_FILL(int X, int Y, int width, int height, Color colors)
        {
            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();
            Rectangle window = new Rectangle(X, Y, width, height);
            Pen myPen = new Pen(colors, 3);
            
            graphicsObj.FillRectangle(Brushes.Green, window);
            graphicsObj.DrawRectangle(myPen, window);

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
        }

        private void Update_map()
        {
            if (Measurment_started )
            {
                MY_PAD1_DRAW(200, 200, 45, 45, System.Drawing.Color.Red);
                MY_PAD1_DRAW(200, 250, 45, 45, System.Drawing.Color.Red);
                MY_PAD1_DRAW(200, 300, 45, 45, System.Drawing.Color.Red);
                MY_PAD1_DRAW(200, 350, 45, 45, System.Drawing.Color.Red);


                if (row_number == 1 && number_of_rows >= 1)
                {
                    MY_PAD1_FILL(200, 200, 45, 45, System.Drawing.Color.Red);
                }

                if (row_number == 2 && number_of_rows >= 2)
                {
                    MY_PAD1_FILL(200, 250, 45, 45, System.Drawing.Color.Red);
                }

                if (row_number == 3 && number_of_rows >= 4)
                {
                    MY_PAD1_FILL(200, 300, 45, 45, System.Drawing.Color.Red);
                }

                if (row_number == 4 && number_of_rows == 4)
                {
                    MY_PAD1_FILL(200, 350, 45, 45, System.Drawing.Color.Red);
                }
            }
        }
    }
}
