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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Export_button = new System.Windows.Forms.Button();
            this.Xval_label = new System.Windows.Forms.Label();
            this.Yval_label = new System.Windows.Forms.Label();
            this.Yvalue_label = new System.Windows.Forms.Label();
            this.Xvalue_label = new System.Windows.Forms.Label();
            this.RESET_button = new System.Windows.Forms.Button();
            this.ComboBox_Rows = new System.Windows.Forms.ComboBox();
            this.label_Rows = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Column_number_lable = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Infolabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Export_button
            // 
            this.Export_button.BackColor = System.Drawing.Color.Olive;
            this.Export_button.Location = new System.Drawing.Point(319, 141);
            this.Export_button.Name = "Export_button";
            this.Export_button.Size = new System.Drawing.Size(75, 76);
            this.Export_button.TabIndex = 30;
            this.Export_button.Text = "EXPORT";
            this.Export_button.UseVisualStyleBackColor = false;
            this.Export_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // Xval_label
            // 
            this.Xval_label.BackColor = System.Drawing.Color.ForestGreen;
            this.Xval_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Xval_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xval_label.ForeColor = System.Drawing.Color.Black;
            this.Xval_label.Location = new System.Drawing.Point(10, 66);
            this.Xval_label.Name = "Xval_label";
            this.Xval_label.Size = new System.Drawing.Size(219, 27);
            this.Xval_label.TabIndex = 29;
            this.Xval_label.Text = "X Axis";
            this.Xval_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Yval_label
            // 
            this.Yval_label.BackColor = System.Drawing.Color.ForestGreen;
            this.Yval_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Yval_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yval_label.ForeColor = System.Drawing.Color.Black;
            this.Yval_label.Location = new System.Drawing.Point(228, 66);
            this.Yval_label.Name = "Yval_label";
            this.Yval_label.Size = new System.Drawing.Size(226, 27);
            this.Yval_label.TabIndex = 28;
            this.Yval_label.Text = "Y Axis";
            this.Yval_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Yvalue_label
            // 
            this.Yvalue_label.BackColor = System.Drawing.Color.MintCream;
            this.Yvalue_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Yvalue_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yvalue_label.ForeColor = System.Drawing.Color.Black;
            this.Yvalue_label.Location = new System.Drawing.Point(228, 93);
            this.Yvalue_label.Name = "Yvalue_label";
            this.Yvalue_label.Size = new System.Drawing.Size(226, 27);
            this.Yvalue_label.TabIndex = 27;
            this.Yvalue_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Xvalue_label
            // 
            this.Xvalue_label.BackColor = System.Drawing.Color.MintCream;
            this.Xvalue_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Xvalue_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Xvalue_label.ForeColor = System.Drawing.Color.Black;
            this.Xvalue_label.Location = new System.Drawing.Point(10, 93);
            this.Xvalue_label.Name = "Xvalue_label";
            this.Xvalue_label.Size = new System.Drawing.Size(219, 27);
            this.Xvalue_label.TabIndex = 24;
            this.Xvalue_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RESET_button
            // 
            this.RESET_button.BackColor = System.Drawing.Color.Olive;
            this.RESET_button.Location = new System.Drawing.Point(319, 39);
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
            this.ComboBox_Rows.Location = new System.Drawing.Point(136, 9);
            this.ComboBox_Rows.Name = "ComboBox_Rows";
            this.ComboBox_Rows.Size = new System.Drawing.Size(58, 21);
            this.ComboBox_Rows.TabIndex = 31;
            this.ComboBox_Rows.SelectionChangeCommitted += new System.EventHandler(this.ComboBox_Rows_SelectionChangeCommitted);
            // 
            // label_Rows
            // 
            this.label_Rows.AutoSize = true;
            this.label_Rows.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rows.Location = new System.Drawing.Point(12, 14);
            this.label_Rows.Name = "label_Rows";
            this.label_Rows.Size = new System.Drawing.Size(101, 20);
            this.label_Rows.TabIndex = 33;
            this.label_Rows.Text = "No of Rows";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Location = new System.Drawing.Point(432, 319);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 124);
            this.button4.TabIndex = 37;
            this.button4.Text = "Simulate INDEX NEXT";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.ForestGreen;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(10, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 27);
            this.label7.TabIndex = 41;
            this.label7.Text = "Column Number";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Column_number_lable
            // 
            this.Column_number_lable.BackColor = System.Drawing.Color.MintCream;
            this.Column_number_lable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Column_number_lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column_number_lable.ForeColor = System.Drawing.Color.Black;
            this.Column_number_lable.Location = new System.Drawing.Point(10, 39);
            this.Column_number_lable.Name = "Column_number_lable";
            this.Column_number_lable.Size = new System.Drawing.Size(143, 27);
            this.Column_number_lable.TabIndex = 40;
            this.Column_number_lable.Text = "0";
            this.Column_number_lable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.ForestGreen;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(154, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(300, 27);
            this.label9.TabIndex = 45;
            this.label9.Text = "Measurment";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Infolabel
            // 
            this.Infolabel.BackColor = System.Drawing.Color.MintCream;
            this.Infolabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Infolabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Infolabel.ForeColor = System.Drawing.Color.Black;
            this.Infolabel.Location = new System.Drawing.Point(154, 39);
            this.Infolabel.Name = "Infolabel";
            this.Infolabel.Size = new System.Drawing.Size(300, 27);
            this.Infolabel.TabIndex = 44;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(199, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 20);
            this.label11.TabIndex = 37;
            this.label11.Text = "Measurment Type";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(225, 66);
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
            this.radioButton2.Location = new System.Drawing.Point(225, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(74, 17);
            this.radioButton2.TabIndex = 36;
            this.radioButton2.Text = "Chip Bond";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.ComboBox_Rows);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.label_Rows);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(405, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(372, 230);
            this.panel2.TabIndex = 48;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(151, 158);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(195, 20);
            this.textBox2.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Engineer";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(151, 129);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 20);
            this.textBox1.TabIndex = 37;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Serial Number";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2009 SSIE",
            "2009 fSE",
            "2100DS "});
            this.comboBox1.Location = new System.Drawing.Point(151, 99);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 21);
            this.comboBox1.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "M/C Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(631, 371);
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
            this.label13.Location = new System.Drawing.Point(627, 389);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 25);
            this.label13.TabIndex = 49;
            this.label13.Text = "0";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGreen;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.Xvalue_label);
            this.panel3.Controls.Add(this.Yvalue_label);
            this.panel3.Controls.Add(this.Yval_label);
            this.panel3.Controls.Add(this.Xval_label);
            this.panel3.Controls.Add(this.Column_number_lable);
            this.panel3.Controls.Add(this.Infolabel);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(319, 469);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(465, 132);
            this.panel3.TabIndex = 51;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem6});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 153;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripMenuItem5});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem2.Text = "&File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(89, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem5.Text = "E&xit";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem6.Text = "&Help";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem7.Text = "&About";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 602);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Export_button);
            this.Controls.Add(this.RESET_button);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 640);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 640);
            this.Name = "Form1";
            this.Text = "NIKON2018";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Export_button;
        private System.Windows.Forms.Label Xval_label;
        private System.Windows.Forms.Label Yval_label;
        private System.Windows.Forms.Label Yvalue_label;
        private System.Windows.Forms.Label Xvalue_label;
        private System.Windows.Forms.Button RESET_button;
        private System.Windows.Forms.ComboBox ComboBox_Rows;
        private System.Windows.Forms.Label label_Rows;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Column_number_lable;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Infolabel;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

