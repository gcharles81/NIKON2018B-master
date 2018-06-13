using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ini;
using System.IO.Ports;
using System.IO;


namespace NIKON2018
{
   

    class Comsettings
    {
        public static SerialPort _COMport = new SerialPort();

        string Read_String;
        public string _Port_Name;
        public string _parity;
        public int _baud;
        public int _stopbits;
        public int _DataBits;
       // public SerialPort _COMport = new SerialPort();




        private void TEST1(int controller)
        {

            
        }

        public void load_Settings(string controller_name)
        {
            IniFile ini = new IniFile("config/COMM_Settings.ini");

            _Port_Name = ini.IniReadValue(controller_name, "PORT_NUMBER");


            // load and set Baud Rate
            Read_String = ini.IniReadValue(controller_name, "BAUD_RATE");
            _baud = Convert.ToInt32(Read_String);// load and set Baud Rate
                                                     //

            // load and set Data Bits
            Read_String = ini.IniReadValue(controller_name, "DATA_BITS");
            _DataBits = Convert.ToInt32(Read_String);// load and set Baud Rate
                                                         //

            // load and set Parity
            Read_String = ini.IniReadValue(controller_name, "PARITY");

            if (Read_String == "Even")
            {
                _COMport.Parity = Parity.Even;
            }

            if (Read_String == "None")
            {
                _COMport.Parity = Parity.None;
            }

            if (Read_String == "Odd")
            {
                _COMport.Parity = Parity.Odd;
            }

            if (Read_String == "Mark")
            {
                _COMport.Parity = Parity.Mark;
            }

            if (Read_String == "Space")
            {
                _COMport.Parity = Parity.Space;
            }

        }



    }
}
