namespace VoiceDispatchManage.UI
{
    partial class frmBox
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
            this.txtMemo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtName = new CommControl.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRecordServerIP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDispatchIP1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDispatchIP2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTimerIP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label8 = new System.Windows.Forms.Label();
            this.btnTest = new DevComponents.DotNetBar.ButtonX();
            this.txtMask = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNetIP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDNS1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtSecureIP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDNS2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPdsIP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelWorkArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.txtDNS1);
            this.panelWorkArea.Controls.Add(this.txtPdsIP);
            this.panelWorkArea.Controls.Add(this.txtSecureIP);
            this.panelWorkArea.Controls.Add(this.txtDNS2);
            this.panelWorkArea.Controls.Add(this.label13);
            this.panelWorkArea.Controls.Add(this.label10);
            this.panelWorkArea.Controls.Add(this.label11);
            this.panelWorkArea.Controls.Add(this.label12);
            this.panelWorkArea.Controls.Add(this.txtName);
            this.panelWorkArea.Controls.Add(this.txtMask);
            this.panelWorkArea.Controls.Add(this.txtDispatchIP2);
            this.panelWorkArea.Controls.Add(this.txtRecordServerIP);
            this.panelWorkArea.Controls.Add(this.txtDispatchIP1);
            this.panelWorkArea.Controls.Add(this.txtTimerIP);
            this.panelWorkArea.Controls.Add(this.txtMemo);
            this.panelWorkArea.Controls.Add(this.txtNetIP);
            this.panelWorkArea.Controls.Add(this.txtIP);
            this.panelWorkArea.Controls.Add(this.label8);
            this.panelWorkArea.Controls.Add(this.label7);
            this.panelWorkArea.Controls.Add(this.label5);
            this.panelWorkArea.Controls.Add(this.label6);
            this.panelWorkArea.Controls.Add(this.label9);
            this.panelWorkArea.Controls.Add(this.label2);
            this.panelWorkArea.Controls.Add(this.label1);
            this.panelWorkArea.Controls.Add(this.btnNo);
            this.panelWorkArea.Controls.Add(this.btnTest);
            this.panelWorkArea.Controls.Add(this.btnOK);
            this.panelWorkArea.Controls.Add(this.label3);
            this.panelWorkArea.Controls.Add(this.label4);
            this.panelWorkArea.Size = new System.Drawing.Size(461, 404);
            // 
            // panelTitle
            // 
            this.panelTitle.Size = new System.Drawing.Size(304, 28);
            // 
            // txtMemo
            // 
            // 
            // 
            // 
            this.txtMemo.Border.Class = "TextBoxBorder";
            this.txtMemo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMemo.Location = new System.Drawing.Point(114, 257);
            this.txtMemo.MaxLength = 50;
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(301, 50);
            this.txtMemo.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(29, 150);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 110;
            this.label2.Text = "录音服务器IP：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(54, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 104;
            this.label1.Text = "站点名称：";
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(344, 337);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(69, 26);
            this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNo.TabIndex = 103;
            this.btnNo.Text = "取消";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(246, 337);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(69, 26);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 102;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(239, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 107;
            this.label4.Text = "站点IP地址：";
            // 
            // txtIP
            // 
            // 
            // 
            // 
            this.txtIP.Border.Class = "TextBoxBorder";
            this.txtIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIP.Location = new System.Drawing.Point(312, 38);
            this.txtIP.MaxLength = 20;
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(103, 21);
            this.txtIP.TabIndex = 1;
            
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.IsNumber = false;
            this.txtName.Location = new System.Drawing.Point(114, 38);
            this.txtName.MaxLength = 10;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(102, 21);
            this.txtName.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(227, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 107;
            this.label3.Text = "站点子网掩码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(77, 259);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 110;
            this.label5.Text = "备注：";
            // 
            // txtRecordServerIP
            // 
            // 
            // 
            // 
            this.txtRecordServerIP.Border.Class = "TextBoxBorder";
            this.txtRecordServerIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRecordServerIP.Location = new System.Drawing.Point(115, 146);
            this.txtRecordServerIP.MaxLength = 50;
            this.txtRecordServerIP.Name = "txtRecordServerIP";
            this.txtRecordServerIP.Size = new System.Drawing.Size(103, 21);
            this.txtRecordServerIP.TabIndex = 6;
            
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(53, 116);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 110;
            this.label6.Text = "调度台IP：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(227, 116);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 110;
            this.label7.Text = "调度台调试IP：";
            // 
            // txtDispatchIP1
            // 
            // 
            // 
            // 
            this.txtDispatchIP1.Border.Class = "TextBoxBorder";
            this.txtDispatchIP1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDispatchIP1.Location = new System.Drawing.Point(114, 112);
            this.txtDispatchIP1.MaxLength = 50;
            this.txtDispatchIP1.Name = "txtDispatchIP1";
            this.txtDispatchIP1.Size = new System.Drawing.Size(103, 21);
            this.txtDispatchIP1.TabIndex = 4;
            
            // 
            // txtDispatchIP2
            // 
            // 
            // 
            // 
            this.txtDispatchIP2.Border.Class = "TextBoxBorder";
            this.txtDispatchIP2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDispatchIP2.Location = new System.Drawing.Point(312, 112);
            this.txtDispatchIP2.MaxLength = 50;
            this.txtDispatchIP2.Name = "txtDispatchIP2";
            this.txtDispatchIP2.Size = new System.Drawing.Size(103, 21);
            this.txtDispatchIP2.TabIndex = 5;
            
            // 
            // txtTimerIP
            // 
            // 
            // 
            // 
            this.txtTimerIP.Border.Class = "TextBoxBorder";
            this.txtTimerIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTimerIP.Location = new System.Drawing.Point(312, 146);
            this.txtTimerIP.MaxLength = 50;
            this.txtTimerIP.Name = "txtTimerIP";
            this.txtTimerIP.Size = new System.Drawing.Size(103, 21);
            this.txtTimerIP.TabIndex = 7;
            
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(227, 150);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 110;
            this.label8.Text = "时间服务器IP：";
            // 
            // btnTest
            // 
            this.btnTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTest.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTest.Location = new System.Drawing.Point(114, 337);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(69, 26);
            this.btnTest.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTest.TabIndex = 101;
            this.btnTest.Text = "测试";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtMask
            // 
            // 
            // 
            // 
            this.txtMask.Border.Class = "TextBoxBorder";
            this.txtMask.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMask.Location = new System.Drawing.Point(312, 75);
            this.txtMask.MaxLength = 50;
            this.txtMask.Name = "txtMask";
            this.txtMask.Size = new System.Drawing.Size(103, 21);
            this.txtMask.TabIndex = 3;
            
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(53, 79);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 104;
            this.label9.Text = "网管口IP：";
            // 
            // txtNetIP
            // 
            // 
            // 
            // 
            this.txtNetIP.Border.Class = "TextBoxBorder";
            this.txtNetIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNetIP.Location = new System.Drawing.Point(114, 75);
            this.txtNetIP.MaxLength = 20;
            this.txtNetIP.Name = "txtNetIP";
            this.txtNetIP.Size = new System.Drawing.Size(103, 21);
            this.txtNetIP.TabIndex = 2;
            
            // 
            // txtDNS1
            // 
            // 
            // 
            // 
            this.txtDNS1.Border.Class = "TextBoxBorder";
            this.txtDNS1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDNS1.Location = new System.Drawing.Point(115, 215);
            this.txtDNS1.MaxLength = 50;
            this.txtDNS1.Name = "txtDNS1";
            this.txtDNS1.Size = new System.Drawing.Size(103, 21);
            this.txtDNS1.TabIndex = 10;
            
            // 
            // txtSecureIP
            // 
            // 
            // 
            // 
            this.txtSecureIP.Border.Class = "TextBoxBorder";
            this.txtSecureIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSecureIP.Location = new System.Drawing.Point(115, 183);
            this.txtSecureIP.MaxLength = 50;
            this.txtSecureIP.Name = "txtSecureIP";
            this.txtSecureIP.Size = new System.Drawing.Size(103, 21);
            this.txtSecureIP.TabIndex = 8;
            
            // 
            // txtDNS2
            // 
            // 
            // 
            // 
            this.txtDNS2.Border.Class = "TextBoxBorder";
            this.txtDNS2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDNS2.Location = new System.Drawing.Point(312, 215);
            this.txtDNS2.MaxLength = 50;
            this.txtDNS2.Name = "txtDNS2";
            this.txtDNS2.Size = new System.Drawing.Size(103, 21);
            this.txtDNS2.TabIndex = 11;
            
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(42, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 111;
            this.label10.Text = "安全网关IP：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(221, 219);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 12);
            this.label11.TabIndex = 112;
            this.label11.Text = "备用DNS服务器：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(24, 219);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 12);
            this.label12.TabIndex = 113;
            this.label12.Text = "首选DNS服务器：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(239, 187);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 111;
            this.label13.Text = "分组网关IP：";
            // 
            // txtPdsIP
            // 
            // 
            // 
            // 
            this.txtPdsIP.Border.Class = "TextBoxBorder";
            this.txtPdsIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPdsIP.Location = new System.Drawing.Point(312, 183);
            this.txtPdsIP.MaxLength = 50;
            this.txtPdsIP.Name = "txtPdsIP";
            this.txtPdsIP.Size = new System.Drawing.Size(103, 21);
            this.txtPdsIP.TabIndex = 9;
            
            // 
            // frmBox
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(463, 434);
            this.Name = "frmBox";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBox";
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtMemo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIP;
        private CommControl.TextBoxEx txtName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDispatchIP2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRecordServerIP;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDispatchIP1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTimerIP;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.ButtonX btnTest;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMask;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNetIP;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDNS1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPdsIP;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSecureIP;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDNS2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}