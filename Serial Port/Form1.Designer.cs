namespace Serial_Port
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.DrawMax_textBox = new System.Windows.Forms.TextBox();
            this.DrawMin_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.COM_comboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BaudRate_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(527, 214);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(533, 56);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(274, 158);
            this.textBox2.TabIndex = 2;
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(534, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Max:";
            // 
            // DrawMax_textBox
            // 
            this.DrawMax_textBox.Location = new System.Drawing.Point(570, 25);
            this.DrawMax_textBox.Name = "DrawMax_textBox";
            this.DrawMax_textBox.Size = new System.Drawing.Size(38, 22);
            this.DrawMax_textBox.TabIndex = 4;
            this.DrawMax_textBox.Text = "4194303";
            // 
            // DrawMin_textBox
            // 
            this.DrawMin_textBox.Location = new System.Drawing.Point(642, 25);
            this.DrawMin_textBox.Name = "DrawMin_textBox";
            this.DrawMin_textBox.Size = new System.Drawing.Size(38, 22);
            this.DrawMin_textBox.TabIndex = 6;
            this.DrawMin_textBox.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(610, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Min:";
            // 
            // COM_comboBox
            // 
            this.COM_comboBox.FormattingEnabled = true;
            this.COM_comboBox.Location = new System.Drawing.Point(570, 0);
            this.COM_comboBox.Name = "COM_comboBox";
            this.COM_comboBox.Size = new System.Drawing.Size(110, 20);
            this.COM_comboBox.TabIndex = 7;
            this.COM_comboBox.SelectedIndexChanged += new System.EventHandler(this.COM_comboBox_SelectedIndexChanged);
            this.COM_comboBox.Click += new System.EventHandler(this.COM_comboBox_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "COM:";
            // 
            // BaudRate_textBox
            // 
            this.BaudRate_textBox.Location = new System.Drawing.Point(746, 25);
            this.BaudRate_textBox.Name = "BaudRate_textBox";
            this.BaudRate_textBox.Size = new System.Drawing.Size(53, 22);
            this.BaudRate_textBox.TabIndex = 10;
            this.BaudRate_textBox.Text = "115200";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(686, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "BaudRate:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 216);
            this.Controls.Add(this.BaudRate_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.COM_comboBox);
            this.Controls.Add(this.DrawMin_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DrawMax_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Serial Port";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DrawMax_textBox;
        private System.Windows.Forms.TextBox DrawMin_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox COM_comboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BaudRate_textBox;
        private System.Windows.Forms.Label label4;
    }
}

