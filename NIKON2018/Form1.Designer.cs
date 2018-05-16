﻿namespace NIKON2018
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
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 4800;
            this.serialPort1.PortName = "COM7";
            this.serialPort1.RtsEnable = true;
            this.serialPort1.StopBits = System.IO.Ports.StopBits.Two;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(31, 229);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 76);
            this.button3.TabIndex = 30;
            this.button3.Text = "EXPORT";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Xval_label
            // 
            this.Xval_label.AutoSize = true;
            this.Xval_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xval_label.ForeColor = System.Drawing.Color.DarkGreen;
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
            this.Yval_label.ForeColor = System.Drawing.Color.DarkGreen;
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
            this.Yvalue_label.ForeColor = System.Drawing.Color.Blue;
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
            this.Xvalue_label.ForeColor = System.Drawing.Color.Blue;
            this.Xvalue_label.Location = new System.Drawing.Point(19, 532);
            this.Xvalue_label.Name = "Xvalue_label";
            this.Xvalue_label.Size = new System.Drawing.Size(70, 25);
            this.Xvalue_label.TabIndex = 24;
            this.Xvalue_label.Text = "empty";
            // 
            // RESET_button
            // 
            this.RESET_button.Location = new System.Drawing.Point(31, 127);
            this.RESET_button.Name = "RESET_button";
            this.RESET_button.Size = new System.Drawing.Size(75, 76);
            this.RESET_button.TabIndex = 23;
            this.RESET_button.Text = "RESET";
            this.RESET_button.UseVisualStyleBackColor = true;
            this.RESET_button.Click += new System.EventHandler(this.RESET_button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(356, 60);
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
            this.button1.Location = new System.Drawing.Point(58, 60);
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
            this.ComboBox_Rows.Location = new System.Drawing.Point(619, 20);
            this.ComboBox_Rows.Name = "ComboBox_Rows";
            this.ComboBox_Rows.Size = new System.Drawing.Size(121, 21);
            this.ComboBox_Rows.TabIndex = 31;
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
            this.ComboBox_Columns.Location = new System.Drawing.Point(619, 47);
            this.ComboBox_Columns.Name = "ComboBox_Columns";
            this.ComboBox_Columns.Size = new System.Drawing.Size(121, 21);
            this.ComboBox_Columns.TabIndex = 32;
            // 
            // label_Rows
            // 
            this.label_Rows.AutoSize = true;
            this.label_Rows.Location = new System.Drawing.Point(563, 26);
            this.label_Rows.Name = "label_Rows";
            this.label_Rows.Size = new System.Drawing.Size(34, 13);
            this.label_Rows.TabIndex = 33;
            this.label_Rows.Text = "Rows";
            // 
            // label_Columns
            // 
            this.label_Columns.AutoSize = true;
            this.label_Columns.Location = new System.Drawing.Point(563, 50);
            this.label_Columns.Name = "label_Columns";
            this.label_Columns.Size = new System.Drawing.Size(47, 13);
            this.label_Columns.TabIndex = 34;
            this.label_Columns.Text = "Columns";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(587, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "Current Pad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(583, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 25);
            this.label4.TabIndex = 35;
            this.label4.Text = "0";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(566, 320);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 41);
            this.button4.TabIndex = 37;
            this.button4.Text = "INDEX NEXT";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGreen;
            this.label5.Location = new System.Drawing.Point(587, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 18);
            this.label5.TabIndex = 39;
            this.label5.Text = "Current Row";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(583, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 25);
            this.label6.TabIndex = 38;
            this.label6.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(587, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 18);
            this.label7.TabIndex = 41;
            this.label7.Text = "Current Column";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(583, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 25);
            this.label8.TabIndex = 40;
            this.label8.Text = "0";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(631, 430);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 43;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(785, 575);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_Columns);
            this.Controls.Add(this.label_Rows);
            this.Controls.Add(this.ComboBox_Columns);
            this.Controls.Add(this.ComboBox_Rows);
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
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button5;
    }
}

