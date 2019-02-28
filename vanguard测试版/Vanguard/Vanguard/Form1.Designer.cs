namespace Vanguard
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnconnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstResult = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSpendtime = new System.Windows.Forms.TextBox();
            this.BtnTest = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumOK = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lisReceiveMsg = new System.Windows.Forms.ListBox();
            this.txrealTurn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txRealpow = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txwaveform = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSave = new System.Windows.Forms.CheckBox();
            this.TimeWhole = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LstWrongmsg = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.RunState = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txsetpow = new System.Windows.Forms.TextBox();
            this.btntestcom = new System.Windows.Forms.Button();
            this.txtrobot = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnconnect
            // 
            this.btnconnect.Location = new System.Drawing.Point(4, 417);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(99, 49);
            this.btnconnect.TabIndex = 0;
            this.btnconnect.Text = "电批连接";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "螺丝结果";
            // 
            // lstResult
            // 
            this.lstResult.BackColor = System.Drawing.SystemColors.MenuBar;
            this.lstResult.FormattingEnabled = true;
            this.lstResult.ItemHeight = 12;
            this.lstResult.Location = new System.Drawing.Point(352, 12);
            this.lstResult.Name = "lstResult";
            this.lstResult.Size = new System.Drawing.Size(242, 184);
            this.lstResult.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(484, 202);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(110, 49);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清除结果";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "加工总数";
            // 
            // txtSum
            // 
            this.txtSum.Location = new System.Drawing.Point(102, 16);
            this.txtSum.Name = "txtSum";
            this.txtSum.ReadOnly = true;
            this.txtSum.Size = new System.Drawing.Size(155, 21);
            this.txtSum.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "加工良率";
            // 
            // txtOK
            // 
            this.txtOK.Location = new System.Drawing.Point(102, 70);
            this.txtOK.Name = "txtOK";
            this.txtOK.ReadOnly = true;
            this.txtOK.Size = new System.Drawing.Size(155, 21);
            this.txtOK.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "消耗时间";
            // 
            // txtSpendtime
            // 
            this.txtSpendtime.Location = new System.Drawing.Point(102, 103);
            this.txtSpendtime.Name = "txtSpendtime";
            this.txtSpendtime.ReadOnly = true;
            this.txtSpendtime.Size = new System.Drawing.Size(155, 21);
            this.txtSpendtime.TabIndex = 9;
            // 
            // BtnTest
            // 
            this.BtnTest.Location = new System.Drawing.Point(128, 417);
            this.BtnTest.Name = "BtnTest";
            this.BtnTest.Size = new System.Drawing.Size(95, 49);
            this.BtnTest.TabIndex = 10;
            this.BtnTest.Text = "电批测试";
            this.BtnTest.UseVisualStyleBackColor = true;
            this.BtnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "加工OK";
            // 
            // txtNumOK
            // 
            this.txtNumOK.Location = new System.Drawing.Point(102, 42);
            this.txtNumOK.Name = "txtNumOK";
            this.txtNumOK.ReadOnly = true;
            this.txtNumOK.Size = new System.Drawing.Size(155, 21);
            this.txtNumOK.TabIndex = 12;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(128, 320);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(95, 49);
            this.btnStop.TabIndex = 20;
            this.btnStop.Text = "断开连接";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(4, 320);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(99, 49);
            this.btnStart.TabIndex = 19;
            this.btnStart.Text = "建立机器人连接";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(257, 274);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "接受机器人消息";
            // 
            // lisReceiveMsg
            // 
            this.lisReceiveMsg.BackColor = System.Drawing.SystemColors.Menu;
            this.lisReceiveMsg.FormattingEnabled = true;
            this.lisReceiveMsg.ItemHeight = 12;
            this.lisReceiveMsg.Location = new System.Drawing.Point(352, 257);
            this.lisReceiveMsg.Name = "lisReceiveMsg";
            this.lisReceiveMsg.Size = new System.Drawing.Size(242, 112);
            this.lisReceiveMsg.TabIndex = 13;
            // 
            // txrealTurn
            // 
            this.txrealTurn.Location = new System.Drawing.Point(102, 135);
            this.txrealTurn.Name = "txrealTurn";
            this.txrealTurn.ReadOnly = true;
            this.txrealTurn.Size = new System.Drawing.Size(155, 21);
            this.txrealTurn.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 21;
            this.label6.Text = "实际圈数";
            // 
            // txRealpow
            // 
            this.txRealpow.Location = new System.Drawing.Point(102, 172);
            this.txRealpow.Name = "txRealpow";
            this.txRealpow.ReadOnly = true;
            this.txRealpow.Size = new System.Drawing.Size(155, 21);
            this.txRealpow.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "实际扭力";
            // 
            // txwaveform
            // 
            this.txwaveform.Location = new System.Drawing.Point(102, 211);
            this.txwaveform.Name = "txwaveform";
            this.txwaveform.ReadOnly = true;
            this.txwaveform.Size = new System.Drawing.Size(155, 21);
            this.txwaveform.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "波形数";
            // 
            // cbSave
            // 
            this.cbSave.AutoSize = true;
            this.cbSave.Location = new System.Drawing.Point(7, 298);
            this.cbSave.Name = "cbSave";
            this.cbSave.Size = new System.Drawing.Size(96, 16);
            this.cbSave.TabIndex = 27;
            this.cbSave.Text = "保存波形数据";
            this.cbSave.UseVisualStyleBackColor = true;
            // 
            // TimeWhole
            // 
            this.TimeWhole.BackColor = System.Drawing.SystemColors.Menu;
            this.TimeWhole.FormattingEnabled = true;
            this.TimeWhole.ItemHeight = 12;
            this.TimeWhole.Location = new System.Drawing.Point(352, 390);
            this.TimeWhole.Name = "TimeWhole";
            this.TimeWhole.Size = new System.Drawing.Size(242, 88);
            this.TimeWhole.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(293, 393);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "节拍时间";
            // 
            // LstWrongmsg
            // 
            this.LstWrongmsg.BackColor = System.Drawing.SystemColors.Menu;
            this.LstWrongmsg.FormattingEnabled = true;
            this.LstWrongmsg.ItemHeight = 12;
            this.LstWrongmsg.Location = new System.Drawing.Point(678, 97);
            this.LstWrongmsg.Name = "LstWrongmsg";
            this.LstWrongmsg.Size = new System.Drawing.Size(230, 220);
            this.LstWrongmsg.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(600, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "错误报告";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(600, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 33;
            this.label13.Text = "运行状态";
            // 
            // RunState
            // 
            this.RunState.Location = new System.Drawing.Point(678, 16);
            this.RunState.Name = "RunState";
            this.RunState.Size = new System.Drawing.Size(230, 21);
            this.RunState.TabIndex = 34;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 257);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 37;
            this.label14.Text = "设置目标扭力";
            // 
            // txsetpow
            // 
            this.txsetpow.Location = new System.Drawing.Point(102, 248);
            this.txsetpow.Name = "txsetpow";
            this.txsetpow.Size = new System.Drawing.Size(155, 21);
            this.txsetpow.TabIndex = 38;
            this.txsetpow.Text = "200";
            // 
            // btntestcom
            // 
            this.btntestcom.Location = new System.Drawing.Point(678, 453);
            this.btntestcom.Name = "btntestcom";
            this.btntestcom.Size = new System.Drawing.Size(142, 25);
            this.btntestcom.TabIndex = 39;
            this.btntestcom.Text = "与机器人通讯测试";
            this.btntestcom.UseVisualStyleBackColor = true;
            this.btntestcom.Click += new System.EventHandler(this.btntestcom_Click);
            // 
            // txtrobot
            // 
            this.txtrobot.Location = new System.Drawing.Point(678, 417);
            this.txtrobot.Name = "txtrobot";
            this.txtrobot.Size = new System.Drawing.Size(183, 21);
            this.txtrobot.TabIndex = 40;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(600, 420);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 41;
            this.label15.Text = "发送消息";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(678, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 21);
            this.textBox1.TabIndex = 42;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(595, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 43;
            this.label16.Text = "实时扭力值";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(920, 514);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtrobot);
            this.Controls.Add(this.btntestcom);
            this.Controls.Add(this.txsetpow);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.RunState);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LstWrongmsg);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TimeWhole);
            this.Controls.Add(this.cbSave);
            this.Controls.Add(this.txwaveform);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txRealpow);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txrealTurn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lisReceiveMsg);
            this.Controls.Add(this.txtNumOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnTest);
            this.Controls.Add(this.txtSpendtime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnconnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Vanguard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstResult;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSpendtime;
        private System.Windows.Forms.Button BtnTest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumOK;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lisReceiveMsg;
        private System.Windows.Forms.TextBox txrealTurn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txRealpow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txwaveform;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbSave;
        private System.Windows.Forms.ListBox TimeWhole;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox LstWrongmsg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox RunState;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txsetpow;
        private System.Windows.Forms.Button btntestcom;
        private System.Windows.Forms.TextBox txtrobot;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label16;
    }
}

