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
        Boolean Debug_without_RS232 = true;//set to true to debug witout microscope connected 
        Boolean Index_changed = false;
        Boolean Measurment_started = false;
        Boolean DO_Referance = true;
        Boolean Pointmarks = true; //by default pointmarks radio button is set to checked on startup 
        Boolean Chipbond = false; //by default chipbond radio button is set to unchecked on startup 


        /// <Visualizer_definition_sizes / >

        int X_VIS_START = 50;//Start porition cordinate Top Left 
        int Y_VIS_START = 30;//Start porition cordinate Top Left 
        int VisualizerX_size = 120;//Size in X of Visualizer 
        int VisualizerY_size = 540;//Size in Y of Visualizer 
        int RECT_VIS_SIZE = 90;//size of PAD for Visualizer 
        int Vis_pitch_X = 0;//not used but future might need for multichip in X 
        int YP = 105;//note this has to be set bigger than RECT_VIS_SIZE
        int Circle_Size = 60;
        /// 
        int MEASURMENT_SEQUESNCE = 1;

        String FILE_name = "results.txt";
        String FILE_LOC = "test_folder\results.txt";
        String FILE_path;




        public Form1()
        {
            InitializeComponent();
            string path1 = "c:\\temp";
            string path2 = "subdir\\default.dat";

            FILE_path = Path.Combine(path1, path2);

            FOLDERS(); /// Create folders if not found




            COMport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

        }

        public void Visualizer_Border(int X, int Y)
        {
            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();
            Rectangle window = new Rectangle(X - 3, Y - 3, VisualizerX_size + 6, VisualizerY_size + 6);
            Pen myPen = new Pen(Color.Black, 3);

            graphicsObj.DrawRectangle(myPen, window);
            graphicsObj.Dispose();
        }
        public void Create_file()
        {


            if (System.IO.File.Exists(FILE_path))
            {
                System.IO.File.Delete(FILE_path);
            }

            System.IO.StreamWriter file2 = new System.IO.StreamWriter(FILE_path, true);

            file2.Write("NIKON 2018 FILE CREATED ON - ");
            file2.WriteLine("Date_Time_Processed" + ",");

            file2.Close();
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

                Index_changed = true;


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

                float floatValueX = float.Parse(X);
                float floatValueY = float.Parse(Y);


                Index_Register2(floatValueX, floatValueY);



                if (Debug_without_RS232 == false)
                {
                    REPLY_TO_NIKON();//lets reply SXY
                }







                Have_message = false;
                Index_changed = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void Serial_connect()
        {

            if (Debug_without_RS232 == false)
            {
                //Local Variables 

                //uncomment below to have selection 
                //   string Port_Name = ComboBox_Available_SerialPorts.SelectedItem.ToString();    // Store the selected COM port name to "Port_Name" varaiable
                //    int Baud_Rate = Convert.ToInt32(ComboBox_Standard_Baudrates.SelectedItem); // Convert the string "9600" to int32 9600
                //Store the string in Textbox to variable "Data"
                string Port_Name = "COM7";
                int Baud_Rate = 4800;
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
        }


        private void button2_Click(object sender, EventArgs e)
        {
            COMport.Close();
        }

        private void RESET_button_Click(object sender, EventArgs e)
        {
            Serial_connect();
            Create_file();
            REPLY_TO_NIKON();
            position_number = 0;
            column_number = 1;
            row_number = 0;
            Measurment_started = true;
            DO_Referance = true;
            MEASURMENT_SEQUESNCE = 0;
            Update_map22(0, 0, false);
        }

        private void REPLY_TO_NIKON()
        {
            //RESET_position_number();

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



        private void button4_Click(object sender, EventArgs e)//Only used for debugging 
        {

            if (Debug_without_RS232)
            {
                sRecv = "0.2003,0.1019";
                Index_changed = true;
                Have_message = true;
            }
        }



        public void RESET_position_number()
        {

            position_number = 0;
            column_number = 1;
            row_number = 0;
            Measurment_started = true;
            DO_Referance = true;
            MEASURMENT_SEQUESNCE = 0;
            Update_map22(0, 0, true);
        }



        private void Draw_pad_border(int X, int Y, int width, int height, Color colors)
        {
            int FDSX = (VisualizerX_size - RECT_VIS_SIZE) / 2 + X;
            X = FDSX;
            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();
            Rectangle window = new Rectangle(X, Y, width, height);
            Pen myPen = new Pen(colors, 5);

            graphicsObj.DrawRectangle(myPen, window);
            graphicsObj.Dispose();
        }

        private void MY_PAD_CB_FILL(int X, int Y, int width, int height, Color colors,int row_number )
        {
            int FDSX = (VisualizerX_size - RECT_VIS_SIZE) / 2 + X;

            int YYCALC = Y_VIS_START + (YP * row_number);

            X = FDSX;

            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Rectangle window = new Rectangle(X + 10, Y + 10, width - 20, height -20);
            int XTE = (width - 4) / 2;
            int YTE = (height - 4) / 2;
            graphicsObj.FillRectangle(Brushes.Orange, window);
            graphicsObj.Dispose();

            // lets draw Chip 
            int Chipsize = width - 50;
            int Chip_Start_Corner_X = X + 25;
            int Chip_Start_Corner_Y = Y + 25;

            graphicsObj = this.CreateGraphics();
            Rectangle Chipwindow = new Rectangle(Chip_Start_Corner_X, Chip_Start_Corner_Y, Chipsize, Chipsize);
         
            graphicsObj.FillRectangle(Brushes.LightSkyBlue, Chipwindow);
            graphicsObj.Dispose();
            ///

            
            graphicsObj = this.CreateGraphics();


            if (row_number == 1)
            {

                Pen GFD = new Pen(Color.Blue, 4);
                // graphicsObj.FillRectangle(Brushes.Blue, window2);//this is point mark 

                Point point1_A = new Point((Chip_Start_Corner_X - 8), (Chip_Start_Corner_Y));
                Point point2_A = new Point((Chip_Start_Corner_X + 8), (Chip_Start_Corner_Y));
                Point point3_A = new Point((Chip_Start_Corner_X), (Chip_Start_Corner_Y - 8));
                Point point4_A = new Point((Chip_Start_Corner_X), (Chip_Start_Corner_Y + 8));
                graphicsObj.DrawLine(GFD, point1_A, point2_A);
                graphicsObj.DrawLine(GFD, point3_A, point4_A);

            }

            else if (row_number == 99)
            {


                Pen ASDX = new Pen(Color.Blue, 4);
                Point point1 = new Point((Chip_Start_Corner_X - 8 + Chipsize), (Chip_Start_Corner_Y));
                Point point2 = new Point((Chip_Start_Corner_X + 8 + Chipsize), (Chip_Start_Corner_Y));
                Point point3 = new Point((Chip_Start_Corner_X + Chipsize), (Chip_Start_Corner_Y - 8));
                Point point4 = new Point((Chip_Start_Corner_X + Chipsize), (Chip_Start_Corner_Y + 8));
                graphicsObj.DrawLine(ASDX, point1, point2);
                graphicsObj.DrawLine(ASDX, point3, point4);
            }
            graphicsObj.Dispose();
    

        }

       


        private void MY_PAD1_FILL(int X, int Y, int width, int height, Color colors)
        {
            int FDSX = (VisualizerX_size - RECT_VIS_SIZE) / 2 + X;

            X = FDSX;
            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();
            Rectangle window = new Rectangle(X + 5, Y + 5, width - 10, height -10);
            int XTE = (width - 4) / 2;
            int YTE = (height - 4) / 2;



            graphicsObj.FillRectangle(Brushes.GreenYellow, window);

            graphicsObj.Dispose();



            graphicsObj = this.CreateGraphics();
            Rectangle window2 = new Rectangle(((X + 2 + XTE)), ((Y + 2 + YTE)), 5,5); //this is point mark 
            Pen GFD = new Pen(Color.Blue, 4);
            // graphicsObj.FillRectangle(Brushes.Blue, window2);//this is point mark 

            Point point1 = new Point((X + XTE + 2 - 10), (Y + 2 + YTE-2));
            Point point2 = new Point((X + XTE + 2 + 10), (Y + 2 + YTE-2));
            Point point3 = new Point((X + XTE + 2 ), (Y + 2 + YTE - 2 -10));
            Point point4 = new Point((X + XTE + 2 ), (Y + 2 + YTE - 2+10));
            graphicsObj.DrawLine(GFD, point1, point2);
            graphicsObj.DrawLine(GFD, point3, point4);
            graphicsObj.Dispose();

        }

        private void MY_REF_CRCL_FILL(int X, int Y, int width, int height, Boolean State)
        {
            if (State)
            {
                Graphics myGraphics = base.CreateGraphics();
                Pen h = new Pen(Color.Aqua, 2);
                myGraphics.FillEllipse(Brushes.Black, X, Y, width, height);
                myGraphics.Dispose();
            }

            else
            {
                Graphics myGraphics = base.CreateGraphics();
                myGraphics.FillEllipse(Brushes.GreenYellow, X, Y, width, height);
                myGraphics.Dispose();
            }
        }

        private void Small_circle(int Xstart, int Ystart, Boolean state)
        {

            if (state)
            {


                Graphics myGraphics = base.CreateGraphics();
                // Pen h = new Pen(Color.Aqua, 2);
                myGraphics.FillEllipse(Brushes.AliceBlue, Xstart - 5, Ystart - 5, 10, 10);
                // myGraphics.DrawEllipse(h, Xstart - 3, Ystart - 3, 6, 6);
                myGraphics.Dispose();
            }

            else
            {
                Graphics myGraphics = base.CreateGraphics();

                myGraphics.FillEllipse(Brushes.Blue, Xstart - 5, Ystart - 5, 10, 10);
                myGraphics.Dispose();
            }
        }

        private void MY_REF_POINT_FILL(int X, int Y, int width, int height, Boolean State)
        {
            if (State)
            {
                int STARTXofref = X;
                int STARTYofref = Y;
                int refwidth = width;
                int refheight = height;
                double radius = (refwidth / 2);
                int my_calculatedstart_Xref1 = ((STARTXofref + refwidth) - (refwidth / 2));
                int my_calculatedstart_Yref1 = ((STARTYofref + refheight) - (refheight / 2));

                double XX = radius * Math.Cos(45.00);
                double YY = radius * Math.Sin(45.00);

                int testx = (int)XX;
                int testy = (int)YY;


                int x1 = my_calculatedstart_Xref1 + testx;
                int y1 = my_calculatedstart_Yref1 + testy;


                switch (MEASURMENT_SEQUESNCE)
                {
                    case 0:
                        Small_circle(my_calculatedstart_Xref1 + testx, my_calculatedstart_Yref1 + testy, true);
                        return;
                    case 1:
                        Small_circle(my_calculatedstart_Xref1 + testx, my_calculatedstart_Yref1 + testy, false);
                        Small_circle(my_calculatedstart_Xref1 + testx, my_calculatedstart_Yref1 - testy, true);
                        return;


                    case 2:
                        Small_circle(my_calculatedstart_Xref1 + testx, my_calculatedstart_Yref1 + testy, false);
                        Small_circle(my_calculatedstart_Xref1 + testx, my_calculatedstart_Yref1 - testy, false);
                        Small_circle(my_calculatedstart_Xref1 - (int)radius, my_calculatedstart_Yref1, true);
                        return;
                    default:
                        Small_circle(my_calculatedstart_Xref1 + testx, my_calculatedstart_Yref1 + testy, false);
                        Small_circle(my_calculatedstart_Xref1 + testx, my_calculatedstart_Yref1 - testy, false);
                        Small_circle(my_calculatedstart_Xref1 - (int)radius, my_calculatedstart_Yref1, false);
                        return;
                }

            }

            else
            {
                Graphics myGraphics = base.CreateGraphics();
                myGraphics.FillEllipse(Brushes.GreenYellow, X, Y, 9, 9);
                myGraphics.Dispose();
            }
        }
        private void MY_PAD1_FILL_2(int X, int Y, int width, int height, Color colors)
        {
            int FDSX = (VisualizerX_size - RECT_VIS_SIZE) / 2 + X;

            X = FDSX;

            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();
            Rectangle window = new Rectangle(X + 2, Y + 2, width - 4, height - 4);
            Pen myPen = new Pen(colors, 3);

            graphicsObj.FillRectangle(Brushes.DarkGray, window);
            graphicsObj.Dispose();

        }
        private void timer3_Tick(object sender, EventArgs e)
        {

        }
        private void Reset_Visualizer(int X, int Y, int width, int height, Color colors)
        {

            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();
            Rectangle window = new Rectangle(X, Y, width, height);
            Pen myPen = new Pen(colors, 3);

            graphicsObj.FillRectangle(Brushes.DarkGreen, window);
            graphicsObj.DrawRectangle(myPen, window);
            graphicsObj.Dispose();

            Visualizer_Border(X, Y);

        }


        private void testwrite2(float X, float Y, int s)
        {
            StreamWriter file2 = new System.IO.StreamWriter(FILE_path, true);

            if (Pointmarks)
            {
                switch (s)
                {

                    case 1:

                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Ref1_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Ref1_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;

                    case 2:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Ref2_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Ref2_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 3:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Ref3_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Ref3_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 4:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Pt1_A_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Pt1_A_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 5:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Pt2_A_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Pt2_A_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 6:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Pt3_A_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Pt3_A_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 7:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Pt4_A_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Pt4_A_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    default:
                        file2.Close();
                        break;
                }

            }

            else if (Chipbond)
            {
                switch (s)
                {

                    case 1:

                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Ref1_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Ref1_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;

                    case 2:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Ref2_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Ref2_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 3:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Ref3_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Ref3_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 4:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Pt1_A_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Pt1_A_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 5:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Pt1_B_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Pt1_B_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 6:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Pt2_A_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Pt2_A_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 7:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Pt2_B_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Pt2_B_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 8:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Pt3_A_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Pt3_A_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 9:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Pt3_B_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Pt3_B_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 10:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Pt4_A_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Pt4_A_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    case 11:
                        file2.Write("Dev ");
                        file2.Write(column_number);
                        file2.Write(" , ");
                        file2.Write("Pt4_B_X");
                        file2.Write(" , ");
                        file2.Write(X);
                        file2.Write(" , ");
                        file2.Write("Pt4_B_Y");
                        file2.Write(" , ");
                        file2.WriteLine(Y);
                        file2.Close();
                        break;
                    default:
                        file2.Close();
                        break;
                }
            }

        }



        private void ComboBox_Rows_SelectionChangeCommitted(object sender, EventArgs e)
        {
            number_of_rows = int.Parse(ComboBox_Rows.SelectedItem.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (System.IO.File.Exists(FILE_path))
            {
                System.IO.StreamWriter file2 = new System.IO.StreamWriter(FILE_path, true);
                file2.Close();
            }


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (Pointmarks == true & Chipbond == false)
            {
                Pointmarks = false;
                Chipbond = true;
            }

            else if (Pointmarks == false & Chipbond == true)
            {
                Pointmarks = true;
                Chipbond = false;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

        }


        /*

        private void Update_map2(float x, float y, Boolean status)
        {


            if (Pointmarks && status)
            {

                Reset_Visualizer(X_VIS_START - 3, Y_VIS_START - 65, VisualizerX_size, VisualizerY_size, Color.Green);

                Column_number_lable.Text = column_number.ToString();

                switch (MEASURMENT_SEQUESNCE)
                {

               

                    case 0:

                        Infolabel.Text = "Referance Point 1";

                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MEASURMENT_SEQUESNCE++;

                        break;


                    case 1:
                        Infolabel.Text = "Referance Point 2";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;

                        break;
                    case 2:
                        Infolabel.Text = "Referance Point 3";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW

                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        DO_Referance = false;
                        break;


                    case 3:
                        Infolabel.Text = "Point Mark 1";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW

                        Draw_pad_border(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        MY_PAD1_FILL(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 195, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 4:
                        Infolabel.Text = "Point Mark 2";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        Draw_pad_border(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);


                        Draw_pad_border(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 5:
                        Infolabel.Text = "Point Mark 3";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        Draw_pad_border(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 6:


                        Infolabel.Text = "Point Mark 4";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW

                        Draw_pad_border(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 195, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL(X_VIS_START, Y_VIS_START + 195, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 7:



                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;


                    default:
                      
                        break;

                }
            }

            else if (Pointmarks && status == false)
            {

                Infolabel.Text = "Referance Point 1";
                Column_number_lable.Text = column_number.ToString();
                MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                //    testwrite2(x, y, MEASURMENT_SEQUESNCE ); 
                MEASURMENT_SEQUESNCE++;

            }



            if (Chipbond && status)
            {


                Reset_Visualizer(X_VIS_START - 3, Y_VIS_START - 65, VisualizerX_size, VisualizerY_size, Color.Green);

                Column_number_lable.Text = column_number.ToString();

                switch (MEASURMENT_SEQUESNCE)
                {

             

                    case 0:

                        Infolabel.Text = "Referance Point 1";

                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MEASURMENT_SEQUESNCE++;

                        break;


                    case 1:
                        Infolabel.Text = "Referance Point 2";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;

                        break;
                    case 2:
                        Infolabel.Text = "Referance Point 3";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW

                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        DO_Referance = false;
                        break;


                    case 3:
                        Infolabel.Text = "Chip 1 Top Left corner";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW

                        Draw_pad_border(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        MY_PAD1_FILL(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 195, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 4:
                        Infolabel.Text = "Chip 1 Top Right corner";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW

                        Draw_pad_border(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        MY_PAD1_FILL(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 195, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 5:
                        Infolabel.Text = "Chip 2 Top Left corner";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        Draw_pad_border(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);


                        Draw_pad_border(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;
                    case 6:
                        Infolabel.Text = "Chip 2 Top Right corner";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        Draw_pad_border(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);


                        Draw_pad_border(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;
                    case 7:
                        Infolabel.Text = "Chip 3 Top Left corner";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        Draw_pad_border(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 8:
                        Infolabel.Text = "Chip 3 Top Right corner";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        Draw_pad_border(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;
                    case 9:


                        Infolabel.Text = "Chip 4 Top Left corner";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW

                        Draw_pad_border(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 195, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL(X_VIS_START, Y_VIS_START + 195, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 10:


                        Infolabel.Text = "Chip 4 Top Right corner";
                        MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                        MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW

                        Draw_pad_border(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 65, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL_2(X_VIS_START, Y_VIS_START + 130, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        Draw_pad_border(X_VIS_START, Y_VIS_START + 195, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);

                        MY_PAD1_FILL(X_VIS_START, Y_VIS_START + 195, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;


                    case 11:



                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;


                    default:
                        //  MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, false); ///true set Black  77 false set YELLOW
                        break;

                }
            }

            else if (Chipbond && status == false)
            {

                Infolabel.Text = "Referance Point 1";
                Column_number_lable.Text = column_number.ToString();
                MY_REF_CRCL_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW
                MY_REF_POINT_FILL(X_VIS_START, Y_VIS_START - 65, 60, 60, true); ///true set Black  77 false set YELLOW 
                MEASURMENT_SEQUESNCE++;

            }

        }
        */
        public void Index_Register2(float x, float y)
        {




            if (Pointmarks && Index_changed)
            {
                Update_map22(x, y, true);

                if (number_of_rows == 1 && MEASURMENT_SEQUESNCE == 5)
                {
                    position_number = 0;
                    column_number++;
                    row_number = 0;
                    Measurment_started = true;
                    DO_Referance = true;
                    MEASURMENT_SEQUESNCE = 0;
                    Reset_Visualizer(X_VIS_START, Y_VIS_START, VisualizerX_size, VisualizerY_size, Color.Green);
                    Update_map22(0, 0, false);
                }

                if (number_of_rows == 2 && MEASURMENT_SEQUESNCE == 6)
                {
                    position_number = 0;
                    column_number++;
                    row_number = 0;
                    Measurment_started = true;
                    DO_Referance = true;
                    MEASURMENT_SEQUESNCE = 0;
                    Reset_Visualizer(X_VIS_START, Y_VIS_START, VisualizerX_size, VisualizerY_size, Color.Green);
                    Update_map22(0, 0, false);
                }


                if (number_of_rows == 3 && MEASURMENT_SEQUESNCE == 7)
                {
                    position_number = 0;
                    column_number++;
                    row_number = 0;
                    Measurment_started = true;
                    DO_Referance = true;
                    MEASURMENT_SEQUESNCE = 0;
                    Reset_Visualizer(X_VIS_START, Y_VIS_START, VisualizerX_size, VisualizerY_size, Color.Green);
                    Update_map22(0, 0, false);
                }


                if (number_of_rows == 4 && MEASURMENT_SEQUESNCE == 8)
                {
                    position_number = 0;
                    column_number++;
                    row_number = 0;
                    Measurment_started = true;
                    DO_Referance = true;
                    MEASURMENT_SEQUESNCE = 0;
                    Reset_Visualizer(X_VIS_START, Y_VIS_START, VisualizerX_size, VisualizerY_size, Color.Green);
                    Update_map22(0, 0, false);
                }




                Index_changed = false;

            }

            else if (Chipbond && Index_changed)
            {
                Update_map22(x, y, true);
                if (number_of_rows == 1 && MEASURMENT_SEQUESNCE == 6)
                {
                    position_number = 0;
                    column_number++;
                    row_number = 0;
                    Measurment_started = true;
                    DO_Referance = true;
                    MEASURMENT_SEQUESNCE = 0;
                    Reset_Visualizer(X_VIS_START, Y_VIS_START, VisualizerX_size, VisualizerY_size, Color.Green);
                    Update_map22(0, 0, false);
                }

                if (number_of_rows == 2 && MEASURMENT_SEQUESNCE == 8)
                {
                    position_number = 0;
                    column_number++;
                    row_number = 0;
                    Measurment_started = true;
                    DO_Referance = true;
                    MEASURMENT_SEQUESNCE = 0;
                    Reset_Visualizer(X_VIS_START, Y_VIS_START, VisualizerX_size, VisualizerY_size, Color.Green);
                    Update_map22(0, 0, false);
                }


                if (number_of_rows == 3 && MEASURMENT_SEQUESNCE == 10)
                {
                    position_number = 0;
                    column_number++;
                    row_number = 0;
                    Measurment_started = true;
                    DO_Referance = true;
                    MEASURMENT_SEQUESNCE = 0;
                    Reset_Visualizer(X_VIS_START, Y_VIS_START, VisualizerX_size, VisualizerY_size, Color.Green);
                    Update_map22(0, 0, false);
                }


                if (number_of_rows == 4 && MEASURMENT_SEQUESNCE == 12)
                {
                    position_number = 0;
                    column_number++;
                    row_number = 0;
                    Measurment_started = true;
                    DO_Referance = true;
                    MEASURMENT_SEQUESNCE = 0;
                    Reset_Visualizer(X_VIS_START, Y_VIS_START, VisualizerX_size, VisualizerY_size, Color.Green);
                    Update_map22(0, 0, false);
                }




                Index_changed = false;

            }
        }
        /// <summary>
        private void VIS_Referance_Circle(int number_of_rows)
        {
            int XSTART_VAL_REF_CRCL = (VisualizerX_size - Circle_Size) / 2 + X_VIS_START;

            MY_REF_CRCL_FILL(XSTART_VAL_REF_CRCL, Y_VIS_START +15, Circle_Size, Circle_Size, true); ///true set Black  77 false set YELLOW
            MY_REF_POINT_FILL(XSTART_VAL_REF_CRCL, Y_VIS_START+15, Circle_Size, Circle_Size, true); ///true set Black  77 false set YELLOW

        }
        ///////////////////
        private void Show_Pad(Boolean Current, int Temp)///used only for point marks
        {
            int YYCALC = Y_VIS_START + (YP * Temp);
            if (Current)
            {
                Draw_pad_border(X_VIS_START, YYCALC, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                MY_PAD1_FILL(X_VIS_START, YYCALC, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
            }

            else
            {
                Draw_pad_border(X_VIS_START, YYCALC, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                MY_PAD1_FILL_2(X_VIS_START, YYCALC, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
            }
        }
        ///////////////////
        private void Show_Pad_CB(Boolean Current, int Temp,int Which_corner)///used only for Chup Bond
        {
            int YYCALC = Y_VIS_START + (YP * Temp);

            if (Current)
            {
               
                Draw_pad_border(X_VIS_START, YYCALC, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red); // Draw border
                MY_PAD_CB_FILL(X_VIS_START, YYCALC, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red, Which_corner);//Draw pad and Chip
            }

            else

            {
                Draw_pad_border(X_VIS_START, YYCALC, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
                MY_PAD1_FILL_2(X_VIS_START, YYCALC, RECT_VIS_SIZE, RECT_VIS_SIZE, System.Drawing.Color.Red);
            }
        }
        private void VIS_TESTREW_POINTMARKS(int NUMber_ROWS, int Sequence)
        {
            
            if (number_of_rows == 1)
            {
                switch (MEASURMENT_SEQUESNCE) {

                    case 3:

                        Show_Pad(true, 1);//true = Current pad for measurment // false already measured 

                    break;

                   
                    default:
                        break;

                        }
            }

            if (number_of_rows == 2)
            {
                switch (MEASURMENT_SEQUESNCE)
                {

                    case 3:
                        Show_Pad(true,1);//true = Current pad for measurment // false already measured                   
                        Show_Pad(false,2);//true = Current pad for measurment // false already measured 
                        break;
                    case 4:
                        Show_Pad(false,1);//true = Current pad for measurment // false already measured 
                        Show_Pad(true,2);//true = Current pad for measurment // false already measured 
                        break;
                        
                    default:
                        break;

                }
            }

            //
            if (number_of_rows == 3)
            {
                switch (MEASURMENT_SEQUESNCE)
                {

                    case 3:
                        Show_Pad(true, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(false, 2);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(false, 3);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                      
                        break;


                    case 4:

                        Show_Pad(false, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4    
                        Show_Pad(true, 2);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(false, 3);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                    
                        break;

                    case 5:

                        Show_Pad(false, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(false, 2);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(true, 3);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        
                        break;
                    default:
                        break;

                }
            }

            //
            //
            if (number_of_rows == 4)
            {
            
            switch (MEASURMENT_SEQUESNCE)
            {

                case 3:
                        Show_Pad(true, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(false, 2);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(false, 3);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(false, 4);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        break;


                case 4:

                        Show_Pad(false, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(true, 2);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(false, 3);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(false, 4);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        break;

                case 5:

                        Show_Pad(false, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(false, 2);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(true, 3);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(false, 4);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 



                        break;
                case 6:
                        Show_Pad(false, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(false, 2);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(false, 3);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad(true, 4);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4

                        break;
                default:
                    break;

            }
        }

        //
    }

        private void Show_Chip_Right_Corner(Boolean state,int index)
        {



        }
        private void VIS_TESTREW_CHIPBOND(int NUMber_ROWS, int Sequence)
        {

            if (number_of_rows == 1)
            {
                switch (MEASURMENT_SEQUESNCE)
                {

                    case 3:
   
                        Show_Pad_CB(true, 1,1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                      
                        break;

                    case 4:
                       
                        Show_Pad_CB(true, 1,99);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 

                        break;
                    default:
                        break;

                }
            }

            if (number_of_rows == 2)
            {
                switch (MEASURMENT_SEQUESNCE)
                {
                    case 3:

                        Show_Pad_CB(true, 1, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 2, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;

                    case 4:

                        Show_Pad_CB(true, 1, 99);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 2, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;

                    case 5:

                        Show_Pad_CB(false, 1, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(true, 2, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 

                        break;

                    case 6:
                        Show_Pad_CB(false, 1, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(true, 2, 99);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 

                        break;

                    default:
                        break;

                }
            }

            //
            if (number_of_rows == 3)
            {
                switch (MEASURMENT_SEQUESNCE)
                {

                    case 3:

                        Show_Pad_CB(true, 1, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 2, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        Show_Pad_CB(false, 3, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;

                    case 4:

                        Show_Pad_CB(true, 1, 99);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 2, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        Show_Pad_CB(false, 3, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;

                    case 5:

                        Show_Pad_CB(false, 1, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(true, 2, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 3, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;

                    case 6:
                        Show_Pad_CB(false, 1, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(true, 2, 99);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 3, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;
                    case 7:

                        Show_Pad_CB(false, 1, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 2, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(true, 3, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;

                    case 8:
                        Show_Pad_CB(false, 1, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 2, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(true, 3, 99);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;
                    default:
                        break;

                }
            }

            //
            //
            if (number_of_rows == 4)
            {

                switch (MEASURMENT_SEQUESNCE)
                {

                    case 3:

                        Show_Pad_CB(true, 1, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 2, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        Show_Pad_CB(false, 3, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        Show_Pad_CB(false, 4, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;

                    case 4:

                        Show_Pad_CB(true, 1, 99);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 2, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        Show_Pad_CB(false, 3, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        Show_Pad_CB(false, 4, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;

                    case 5:

                        Show_Pad_CB(false, 1, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(true, 2, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 3, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        Show_Pad_CB(false, 4, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;

                    case 6:
                        Show_Pad_CB(false, 1, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(true, 2, 99);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 3, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        Show_Pad_CB(false, 4, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;
                    case 7:

                        Show_Pad_CB(false, 1, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 2, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(true, 3, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        Show_Pad_CB(false, 4, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;

                    case 8:
                        Show_Pad_CB(false, 1, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 2, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(true, 3, 99);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        Show_Pad_CB(false, 4, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;
                    case 9:

                        Show_Pad_CB(false, 1, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 2, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 3, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        Show_Pad_CB(true, 4, 1);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;

                    case 10:
                        Show_Pad_CB(false, 1, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 2, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4 
                        Show_Pad_CB(false, 3, 0);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        Show_Pad_CB(true, 4, 99);//true = Current pad for measurment // false already measured , Number represents pad number 1 -4
                        break;
                    default:
                        break;

                }
            }

            //
        }
        //
        private void Update_map22(float x, float y, Boolean status)
        {

            int XSTART_VAL_REF_CRCL = (VisualizerX_size - Circle_Size) / 2 + X_VIS_START;


            if (Pointmarks && status)
            {

                Reset_Visualizer(X_VIS_START, Y_VIS_START, VisualizerX_size, VisualizerY_size, Color.Green);

                Column_number_lable.Text = column_number.ToString();

                switch (MEASURMENT_SEQUESNCE)
                {



                    case 0:

                        Infolabel.Text = "Referance Point 1";
                        VIS_Referance_Circle(number_of_rows); //update referance circle colours state

                        MEASURMENT_SEQUESNCE++;

                        break;


                    case 1:
                        Infolabel.Text = "Referance Point 2";
                        VIS_Referance_Circle(number_of_rows); //update referance circle colours state

                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;

                        break;
                    case 2:
                        Infolabel.Text = "Referance Point 3";
                        VIS_Referance_Circle(number_of_rows); //update referance circle colours state

                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        DO_Referance = false;
                        break;


                    case 3:
                        Infolabel.Text = "Point Mark 1";


                        VIS_Referance_Circle(number_of_rows); //update referance circle colours state
                        VIS_TESTREW_POINTMARKS(number_of_rows, MEASURMENT_SEQUESNCE);
                       
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 4:
                        Infolabel.Text = "Point Mark 2";
                        VIS_Referance_Circle(number_of_rows); //update referance circle colours state
                        VIS_TESTREW_POINTMARKS(number_of_rows, MEASURMENT_SEQUESNCE);
                        
                    testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 5:
                        Infolabel.Text = "Point Mark 3";
                        VIS_Referance_Circle(number_of_rows); //update referance circle colours state
                        VIS_TESTREW_POINTMARKS(number_of_rows, MEASURMENT_SEQUESNCE);

                      
                    testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 6:


                        Infolabel.Text = "Point Mark 4";
                        VIS_Referance_Circle(number_of_rows); //update referance circle colours state
                        VIS_TESTREW_POINTMARKS(number_of_rows, MEASURMENT_SEQUESNCE);

                      
                    testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 7:



                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;


                    default:

                        break;

                }
            }

            else if (Pointmarks && status == false)
            {

                Infolabel.Text = "Referance Point 1";
                Column_number_lable.Text = column_number.ToString();
              
                VIS_Referance_Circle(number_of_rows); //update referance circle colours state


            }



            if (Chipbond && status)
            {


                Reset_Visualizer(X_VIS_START, Y_VIS_START, VisualizerX_size, VisualizerY_size, Color.Green);

                Column_number_lable.Text = column_number.ToString();

                switch (MEASURMENT_SEQUESNCE)
                {



                    case 0:

                        Infolabel.Text = "Referance Point 1";

                        VIS_Referance_Circle(number_of_rows); //update referance circle colours state

                        MEASURMENT_SEQUESNCE++;

                        break;


                    case 1:
                        Infolabel.Text = "Referance Point 2";
                        VIS_Referance_Circle(number_of_rows); //update referance circle colours state

                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;

                        break;
                    case 2:
                        Infolabel.Text = "Referance Point 3";
                        VIS_Referance_Circle(number_of_rows); //update referance circle colours state


                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        DO_Referance = false;
                        break;


                    case 3:
                        Infolabel.Text = "Chip 1 Top Left corner";
                        VIS_Referance_Circle(number_of_rows); //update referance circle colours state
                        VIS_TESTREW_CHIPBOND(number_of_rows, MEASURMENT_SEQUESNCE);

                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 4:
                        Infolabel.Text = "Chip 1 Top Right corner";
                        VIS_Referance_Circle(number_of_rows); //update referance circle colours state
                        VIS_TESTREW_CHIPBOND(number_of_rows, MEASURMENT_SEQUESNCE);
                       
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                        MEASURMENT_SEQUESNCE++;
                        break;

                    case 5:
                        Infolabel.Text = "Chip 2 Top Left corner";
                        VIS_Referance_Circle(number_of_rows); //update referance circle colours state
                        VIS_TESTREW_CHIPBOND(number_of_rows, MEASURMENT_SEQUESNCE);
                      
                       testwrite2(x, y, MEASURMENT_SEQUESNCE);
                       MEASURMENT_SEQUESNCE++;
                       break;
                   case 6:
                       Infolabel.Text = "Chip 2 Top Right corner";
                       VIS_Referance_Circle(number_of_rows); //update referance circle colours state
                        VIS_TESTREW_CHIPBOND(number_of_rows, MEASURMENT_SEQUESNCE);
                       
                        testwrite2(x, y, MEASURMENT_SEQUESNCE);
                       MEASURMENT_SEQUESNCE++;
                       break;
                   case 7:
                       Infolabel.Text = "Chip 3 Top Left corner";
                       VIS_Referance_Circle(number_of_rows); //update referance circle colours state
                        VIS_TESTREW_CHIPBOND(number_of_rows, MEASURMENT_SEQUESNCE);
                       
                       testwrite2(x, y, MEASURMENT_SEQUESNCE);
                       MEASURMENT_SEQUESNCE++;
                       break;

                   case 8:
                       Infolabel.Text = "Chip 3 Top Right corner";
                       VIS_Referance_Circle(number_of_rows); //update referance circle colours state
                        VIS_TESTREW_CHIPBOND(number_of_rows, MEASURMENT_SEQUESNCE);
                       
                       testwrite2(x, y, MEASURMENT_SEQUESNCE);
                       MEASURMENT_SEQUESNCE++;
                       break;
                   case 9:


                       Infolabel.Text = "Chip 4 Top Left corner";

                       VIS_Referance_Circle(number_of_rows); //update referance circle colours state
                        VIS_TESTREW_CHIPBOND(number_of_rows, MEASURMENT_SEQUESNCE);

                       
                       testwrite2(x, y, MEASURMENT_SEQUESNCE);
                       MEASURMENT_SEQUESNCE++;
                       break;

                   case 10:


                       Infolabel.Text = "Chip 4 Top Right corner";

                       VIS_Referance_Circle(number_of_rows); //update referance circle colours state
                        VIS_TESTREW_CHIPBOND(number_of_rows, MEASURMENT_SEQUESNCE);

                       
                       testwrite2(x, y, MEASURMENT_SEQUESNCE);
                       MEASURMENT_SEQUESNCE++;
                       break;


                   case 11:



                       testwrite2(x, y, MEASURMENT_SEQUESNCE);
                       MEASURMENT_SEQUESNCE++;
                       break;


                   default:
                       //  MY_REF_CRCL_FILL(XSTART_VAL_REF_CRCL, Y_VIS_START - 65, Circle_Size,Circle_Size, false); ///true set Black  77 false set YELLOW
                       break;

               }
           }

           else if (Chipbond && status == false)
           {

               Infolabel.Text = "Referance Point 1";
               Column_number_lable.Text = column_number.ToString();
               Reset_Visualizer(X_VIS_START, Y_VIS_START, VisualizerX_size, VisualizerY_size, Color.Green);
               VIS_Referance_Circle(number_of_rows); //update referance circle colours state

               MEASURMENT_SEQUESNCE++;

           }

       }



      
                        ////////////////////////
                }



            }

        
