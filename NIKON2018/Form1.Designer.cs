namespace NIKON2018
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.Xval_label = new System.Windows.Forms.Label();
            this.Yval_label = new System.Windows.Forms.Label();
            this.Yvalue_label = new System.Windows.Forms.Label();
            this.Xvalue_label = new System.Windows.Forms.Label();
            this.RESET_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBox_Standard_Baudrates = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ComboBox_Available_SerialPorts = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ComboBox_Rows = new System.Windows.Forms.ComboBox();
            this.ComboBox_Columns = new System.Windows.Forms.ComboBox();
            this.label_Rows = new System.Windows.Forms.Label();
            this.label_Columns = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 4800;
            this.serialPort1.PortName = "COM7";
            this.serialPort1.RtsEnable = true;
            this.serialPort1.StopBits = System.IO.Ports.StopBits.Two;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Olive;
            this.button3.Location = new System.Drawing.Point(31, 229);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 76);
            this.button3.TabIndex = 30;
            this.button3.Text = "EXPORT";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Xval_label
            // 
            this.Xval_label.AutoSize = true;
            this.Xval_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xval_label.ForeColor = System.Drawing.Color.Black;
            this.Xval_label.Location = new System.Drawing.Point(35, 514);
            this.Xval_label.Name = "Xval_label";
            this.Xval_label.Size = new System.Drawing.Size(55, 18);
            this.Xval_label.TabIndex = 29;
            this.Xval_label.Text = "X Axis";
            // 
            // Yval_label
            // 
            this.Yval_label.AutoSize = true;
            this.Yval_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yval_label.ForeColor = System.Drawing.Color.Black;
            this.Yval_label.Location = new System.Drawing.Point(195, 514);
            this.Yval_label.Name = "Yval_label";
            this.Yval_label.Size = new System.Drawing.Size(54, 18);
            this.Yval_label.TabIndex = 28;
            this.Yval_label.Text = "Y Axis";
            // 
            // Yvalue_label
            // 
            this.Yvalue_label.AutoSize = true;
            this.Yvalue_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yvalue_label.ForeColor = System.Drawing.Color.White;
            this.Yvalue_label.Location = new System.Drawing.Point(191, 532);
            this.Yvalue_label.Name = "Yvalue_label";
            this.Yvalue_label.Size = new System.Drawing.Size(70, 25);
            this.Yvalue_label.TabIndex = 27;
            this.Yvalue_label.Text = "empty";
            // 
            // Xvalue_label
            // 
            this.Xvalue_label.AutoSize = true;
            this.Xvalue_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xvalue_label.ForeColor = System.Drawing.Color.White;
            this.Xvalue_label.Location = new System.Drawing.Point(26, 532);
            this.Xvalue_label.Name = "Xvalue_label";
            this.Xvalue_label.Size = new System.Drawing.Size(70, 25);
            this.Xvalue_label.TabIndex = 24;
            this.Xvalue_label.Text = "empty";
            // 
            // RESET_button
            // 
            this.RESET_button.BackColor = System.Drawing.Color.Olive;
            this.RESET_button.Location = new System.Drawing.Point(31, 127);
            this.RESET_button.Name = "RESET_button";
            this.RESET_button.Size = new System.Drawing.Size(75, 76);
            this.RESET_button.TabIndex = 23;
            this.RESET_button.Text = "RESET";
            this.RESET_button.UseVisualStyleBackColor = false;
            this.RESET_button.Click += new System.EventHandler(this.RESET_button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(96, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Baudrate";
            // 
            // ComboBox_Standard_Baudrates
            // 
            this.ComboBox_Standard_Baudrates.FormattingEnabled = true;
            this.ComboBox_Standard_Baudrates.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400"});
            this.ComboBox_Standard_Baudrates.Location = new System.Drawing.Point(319, 22);
            this.ComboBox_Standard_Baudrates.Name = "ComboBox_Standard_Baudrates";
            this.ComboBox_Standard_Baudrates.Size = new System.Drawing.Size(121, 21);
            this.ComboBox_Standard_Baudrates.TabIndex = 20;
            this.ComboBox_Standard_Baudrates.SelectionChangeCommitted += new System.EventHandler(this.ComboBox_Standard_Baudrates_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Available Ports";
            // 
            // ComboBox_Available_SerialPorts
            // 
            this.ComboBox_Available_SerialPorts.FormattingEnabled = true;
            this.ComboBox_Available_SerialPorts.Location = new System.Drawing.Point(111, 22);
            this.ComboBox_Available_SerialPorts.Name = "ComboBox_Available_SerialPorts";
            this.ComboBox_Available_SerialPorts.Size = new System.Drawing.Size(121, 21);
            this.ComboBox_Available_SerialPorts.Sorted = true;
            this.ComboBox_Available_SerialPorts.TabIndex = 18;
            this.ComboBox_Available_SerialPorts.SelectionChangeCommitted += new System.EventHandler(this.ComboBox_Available_SerialPorts_SelectionChangeCommitted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ComboBox_Rows
            // 
            this.ComboBox_Rows.FormattingEnabled = true;
            this.ComboBox_Rows.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.ComboBox_Rows.Location = new System.Drawing.Point(139, 13);
            this.ComboBox_Rows.Name = "ComboBox_Rows";
            this.ComboBox_Rows.Size = new System.Drawing.Size(58, 21);
            this.ComboBox_Rows.TabIndex = 31;
            this.ComboBox_Rows.SelectionChangeCommitted += new System.EventHandler(this.ComboBox_Rows_SelectionChangeCommitted);
            // 
            // ComboBox_Columns
            // 
            this.ComboBox_Columns.FormattingEnabled = true;
            this.ComboBox_Columns.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.ComboBox_Columns.Location = new System.Drawing.Point(137, 40);
            this.ComboBox_Columns.Name = "ComboBox_Columns";
            this.ComboBox_Columns.Size = new System.Drawing.Size(60, 21);
            this.ComboBox_Columns.TabIndex = 32;
            this.ComboBox_Columns.SelectionChangeCommitted += new System.EventHandler(this.ComboBox_Columns_SelectionChangeCommitted);
            // 
            // label_Rows
            // 
            this.label_Rows.AutoSize = true;
            this.label_Rows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rows.Location = new System.Drawing.Point(8, 19);
            this.label_Rows.Name = "label_Rows";
            this.label_Rows.Size = new System.Drawing.Size(101, 20);
            this.label_Rows.TabIndex = 33;
            this.label_Rows.Text = "No of Rows";
            // 
            // label_Columns
            // 
            this.label_Columns.AutoSize = true;
            this.label_Columns.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Columns.Location = new System.Drawing.Point(8, 43);
            this.label_Columns.Name = "label_Columns";
            this.label_Columns.Size = new System.Drawing.Size(126, 20);
            this.label_Columns.TabIndex = 34;
            this.label_Columns.Text = "No of Columns";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(587, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "Current Pad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(583, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 25);
            this.label4.TabIndex = 35;
            this.label4.Text = "0";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button4.Location = new System.Drawing.Point(577, 514);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 41);
            this.button4.TabIndex = 37;
            this.button4.Text = "Simulate INDEX NEXT";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(587, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 18);
            this.label5.TabIndex = 39;
            this.label5.Text = "Current Row";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(583, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 25);
            this.label6.TabIndex = 38;
            this.label6.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(587, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 18);
            this.label7.TabIndex = 41;
            this.label7.Text = "Current Column";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(583, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 25);
            this.label8.TabIndex = 40;
            this.label8.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(377, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 18);
            this.label9.TabIndex = 45;
            this.label9.Text = "Measurment";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(373, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 25);
            this.label10.TabIndex = 44;
            this.label10.Text = "__________";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(608, 457);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 46;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ComboBox_Rows);
            this.panel1.Controls.Add(this.ComboBox_Columns);
            this.panel1.Controls.Add(this.label_Rows);
            this.panel1.Controls.Add(this.label_Columns);
            this.panel1.Location = new System.Drawing.Point(573, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 82);
            this.panel1.TabIndex = 47;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(35, 61);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(81, 17);
            this.radioButton1.TabIndex = 35;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Point Marks";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(35, 38);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(74, 17);
            this.radioButton2.TabIndex = 36;
            this.radioButton2.Text = "Chip Bond";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(27, 2);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 20);
            this.label11.TabIndex = 37;
            this.label11.Text = "Measurment Type";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Location = new System.Drawing.Point(573, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 91);
            this.panel2.TabIndex = 48;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(785, 575);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Xval_label);
            this.Controls.Add(this.Yval_label);
            this.Controls.Add(this.Yvalue_label);
            this.Controls.Add(this.Xvalue_label);
            this.Controls.Add(this.RESET_button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ComboBox_Standard_Baudrates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComboBox_Available_SerialPorts);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "NIKON2018";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label Xval_label;
        private System.Windows.Forms.Label Yval_label;
        private System.Windows.Forms.Label Yvalue_label;
        private System.Windows.Forms.Label Xvalue_label;
        private System.Windows.Forms.Button RESET_button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ComboBox_Standard_Baudrates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ComboBox_Available_SerialPorts;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ComboBox_Rows;
        private System.Windows.Forms.ComboBox ComboBox_Columns;
        private System.Windows.Forms.Label label_Rows;
        private System.Windows.Forms.Label label_Columns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
    }
}

