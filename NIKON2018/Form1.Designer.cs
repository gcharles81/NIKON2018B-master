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
            this.ComboBox_Rows = new System.Windows.Forms.ComboBox();
            this.label_Rows = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Infolabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
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
            this.button3.Location = new System.Drawing.Point(114, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 76);
            this.button3.TabIndex = 30;
            this.button3.Text = "EXPORT";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Xval_label
            // 
            this.Xval_label.BackColor = System.Drawing.Color.DarkGray;
            this.Xval_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Xval_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xval_label.ForeColor = System.Drawing.Color.Black;
            this.Xval_label.Location = new System.Drawing.Point(473, 257);
            this.Xval_label.Name = "Xval_label";
            this.Xval_label.Size = new System.Drawing.Size(150, 27);
            this.Xval_label.TabIndex = 29;
            this.Xval_label.Text = "X Axis";
            this.Xval_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Yval_label
            // 
            this.Yval_label.BackColor = System.Drawing.Color.DarkGray;
            this.Yval_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Yval_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yval_label.ForeColor = System.Drawing.Color.Black;
            this.Yval_label.Location = new System.Drawing.Point(622, 257);
            this.Yval_label.Name = "Yval_label";
            this.Yval_label.Size = new System.Drawing.Size(150, 27);
            this.Yval_label.TabIndex = 28;
            this.Yval_label.Text = "Y Axis";
            this.Yval_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Yvalue_label
            // 
            this.Yvalue_label.BackColor = System.Drawing.Color.Silver;
            this.Yvalue_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Yvalue_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yvalue_label.ForeColor = System.Drawing.Color.Black;
            this.Yvalue_label.Location = new System.Drawing.Point(622, 284);
            this.Yvalue_label.Name = "Yvalue_label";
            this.Yvalue_label.Size = new System.Drawing.Size(150, 27);
            this.Yvalue_label.TabIndex = 27;
            this.Yvalue_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Xvalue_label
            // 
            this.Xvalue_label.BackColor = System.Drawing.Color.Silver;
            this.Xvalue_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Xvalue_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xvalue_label.ForeColor = System.Drawing.Color.Black;
            this.Xvalue_label.Location = new System.Drawing.Point(473, 284);
            this.Xvalue_label.Name = "Xvalue_label";
            this.Xvalue_label.Size = new System.Drawing.Size(150, 27);
            this.Xvalue_label.TabIndex = 24;
            this.Xvalue_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RESET_button
            // 
            this.RESET_button.BackColor = System.Drawing.Color.Olive;
            this.RESET_button.Location = new System.Drawing.Point(12, 26);
            this.RESET_button.Name = "RESET_button";
            this.RESET_button.Size = new System.Drawing.Size(75, 76);
            this.RESET_button.TabIndex = 23;
            this.RESET_button.Text = "RESET";
            this.RESET_button.UseVisualStyleBackColor = false;
            this.RESET_button.Click += new System.EventHandler(this.RESET_button_Click);
            // 
            // ComboBox_Rows
            // 
            this.ComboBox_Rows.FormattingEnabled = true;
            this.ComboBox_Rows.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.ComboBox_Rows.Location = new System.Drawing.Point(132, 14);
            this.ComboBox_Rows.Name = "ComboBox_Rows";
            this.ComboBox_Rows.Size = new System.Drawing.Size(58, 21);
            this.ComboBox_Rows.TabIndex = 31;
            this.ComboBox_Rows.SelectionChangeCommitted += new System.EventHandler(this.ComboBox_Rows_SelectionChangeCommitted);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(12, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 18);
            this.label7.TabIndex = 41;
            this.label7.Text = "Column Number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(8, 136);
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
            this.label9.Location = new System.Drawing.Point(570, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 18);
            this.label9.TabIndex = 45;
            this.label9.Text = "Measurment";
            // 
            // Infolabel
            // 
            this.Infolabel.BackColor = System.Drawing.Color.LightGray;
            this.Infolabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Infolabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Infolabel.ForeColor = System.Drawing.Color.Black;
            this.Infolabel.Location = new System.Drawing.Point(473, 230);
            this.Infolabel.Name = "Infolabel";
            this.Infolabel.Size = new System.Drawing.Size(300, 27);
            this.Infolabel.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.ComboBox_Rows);
            this.panel1.Controls.Add(this.label_Rows);
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
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Location = new System.Drawing.Point(573, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 91);
            this.panel2.TabIndex = 48;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(12, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 18);
            this.label12.TabIndex = 50;
            this.label12.Text = "Seq Number";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label13.Location = new System.Drawing.Point(8, 189);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 25);
            this.label13.TabIndex = 49;
            this.label13.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(785, 575);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Infolabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Xval_label);
            this.Controls.Add(this.Yval_label);
            this.Controls.Add(this.Yvalue_label);
            this.Controls.Add(this.Xvalue_label);
            this.Controls.Add(this.RESET_button);
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
        private System.Windows.Forms.ComboBox ComboBox_Rows;
        private System.Windows.Forms.Label label_Rows;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Infolabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

