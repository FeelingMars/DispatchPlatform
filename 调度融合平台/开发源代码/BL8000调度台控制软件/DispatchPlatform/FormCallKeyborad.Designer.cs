namespace DispatchPlatform
{
    partial class FormCallKeyborad
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.lblNumber = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn3 = new DevComponents.DotNetBar.ButtonX();
            this.btn2 = new DevComponents.DotNetBar.ButtonX();
            this.btn1 = new DevComponents.DotNetBar.ButtonX();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btn6 = new DevComponents.DotNetBar.ButtonX();
            this.btn5 = new DevComponents.DotNetBar.ButtonX();
            this.btn4 = new DevComponents.DotNetBar.ButtonX();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn9 = new DevComponents.DotNetBar.ButtonX();
            this.btn8 = new DevComponents.DotNetBar.ButtonX();
            this.btn7 = new DevComponents.DotNetBar.ButtonX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnJing = new DevComponents.DotNetBar.ButtonX();
            this.btn0 = new DevComponents.DotNetBar.ButtonX();
            this.btnXing = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHandup = new DevComponents.DotNetBar.ButtonX();
            this.btnCall = new DevComponents.DotNetBar.ButtonX();
            this.btnTran = new DevComponents.DotNetBar.ButtonX();
            this.panel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::DispatchPlatform.Properties.Resources.CallKeyborad;
            this.panel1.Controls.Add(this.panelTop);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(7, 0, 7, 10);
            this.panel1.Size = new System.Drawing.Size(314, 376);
            this.panel1.TabIndex = 16;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTop.Location = new System.Drawing.Point(7, 7);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(300, 38);
            this.panelTop.TabIndex = 24;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.HoverImage = global::DispatchPlatform.Properties.Resources.cb_close_on;
            this.btnClose.Image = global::DispatchPlatform.Properties.Resources.cb_Close_normal;
            this.btnClose.Location = new System.Drawing.Point(220, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 38);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "拨打";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnClear);
            this.panel7.Controls.Add(this.lblNumber);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(7, 45);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(300, 56);
            this.panel7.TabIndex = 23;
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClear.HoverImage = global::DispatchPlatform.Properties.Resources.cb_clear_on;
            this.btnClear.Image = global::DispatchPlatform.Properties.Resources.cb_Clear_normal;
            this.btnClear.Location = new System.Drawing.Point(240, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(60, 56);
            this.btnClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "拨打";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.Font = new System.Drawing.Font("宋体", 21F, System.Drawing.FontStyle.Bold);
            this.lblNumber.ForeColor = System.Drawing.Color.White;
            this.lblNumber.Location = new System.Drawing.Point(30, 15);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(205, 29);
            this.lblNumber.TabIndex = 22;
            this.lblNumber.Text = "123456789";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn3);
            this.panel6.Controls.Add(this.btn2);
            this.panel6.Controls.Add(this.btn1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(7, 101);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(300, 53);
            this.panel6.TabIndex = 21;
            // 
            // btn3
            // 
            this.btn3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn3.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn3.HoverImage = global::DispatchPlatform.Properties.Resources.cb_3_on;
            this.btn3.Image = global::DispatchPlatform.Properties.Resources.cb_3_normal;
            this.btn3.Location = new System.Drawing.Point(200, 0);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(100, 53);
            this.btn3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn3.TabIndex = 15;
            this.btn3.Tag = "3";
            this.btn3.Text = "拨打";
            this.btn3.Click += new System.EventHandler(this.btn3_Click_1);
            // 
            // btn2
            // 
            this.btn2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn2.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn2.HoverImage = global::DispatchPlatform.Properties.Resources.cb_2_on;
            this.btn2.Image = global::DispatchPlatform.Properties.Resources.cb_2_normal;
            this.btn2.Location = new System.Drawing.Point(100, 0);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(100, 53);
            this.btn2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn2.TabIndex = 14;
            this.btn2.Tag = "2";
            this.btn2.Click += new System.EventHandler(this.btn3_Click_1);
            // 
            // btn1
            // 
            this.btn1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn1.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn1.HoverImage = global::DispatchPlatform.Properties.Resources.cb_1_on;
            this.btn1.Image = global::DispatchPlatform.Properties.Resources.cb_1_normal;
            this.btn1.Location = new System.Drawing.Point(0, 0);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(100, 53);
            this.btn1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn1.TabIndex = 13;
            this.btn1.Tag = "1";
            this.btn1.Click += new System.EventHandler(this.btn3_Click_1);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btn6);
            this.panel5.Controls.Add(this.btn5);
            this.panel5.Controls.Add(this.btn4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(7, 154);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(300, 53);
            this.panel5.TabIndex = 20;
            // 
            // btn6
            // 
            this.btn6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn6.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn6.HoverImage = global::DispatchPlatform.Properties.Resources.cb_6_on;
            this.btn6.Image = global::DispatchPlatform.Properties.Resources.cb_6_normal;
            this.btn6.Location = new System.Drawing.Point(200, 0);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(100, 53);
            this.btn6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn6.TabIndex = 15;
            this.btn6.Tag = "6";
            this.btn6.Text = "拨打";
            this.btn6.Click += new System.EventHandler(this.btn3_Click_1);
            // 
            // btn5
            // 
            this.btn5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn5.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn5.HoverImage = global::DispatchPlatform.Properties.Resources.cb_5_on;
            this.btn5.Image = global::DispatchPlatform.Properties.Resources.cb_5_normal;
            this.btn5.Location = new System.Drawing.Point(100, 0);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(100, 53);
            this.btn5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn5.TabIndex = 14;
            this.btn5.Tag = "5";
            this.btn5.Text = "拨打";
            this.btn5.Click += new System.EventHandler(this.btn3_Click_1);
            // 
            // btn4
            // 
            this.btn4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn4.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn4.HoverImage = global::DispatchPlatform.Properties.Resources.cb_4_on;
            this.btn4.Image = global::DispatchPlatform.Properties.Resources.cb_4_normal;
            this.btn4.Location = new System.Drawing.Point(0, 0);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(100, 53);
            this.btn4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn4.TabIndex = 13;
            this.btn4.Tag = "4";
            this.btn4.Text = "转接";
            this.btn4.Click += new System.EventHandler(this.btn3_Click_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn9);
            this.panel4.Controls.Add(this.btn8);
            this.panel4.Controls.Add(this.btn7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(7, 207);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 53);
            this.panel4.TabIndex = 19;
            // 
            // btn9
            // 
            this.btn9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn9.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn9.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn9.HoverImage = global::DispatchPlatform.Properties.Resources.cb_9_on;
            this.btn9.Image = global::DispatchPlatform.Properties.Resources.cb_9_normal;
            this.btn9.Location = new System.Drawing.Point(200, 0);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(100, 53);
            this.btn9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn9.TabIndex = 15;
            this.btn9.Tag = "9";
            this.btn9.Text = "拨打";
            this.btn9.Click += new System.EventHandler(this.btn3_Click_1);
            // 
            // btn8
            // 
            this.btn8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn8.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn8.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn8.HoverImage = global::DispatchPlatform.Properties.Resources.cb_8_on;
            this.btn8.Image = global::DispatchPlatform.Properties.Resources.cb_8_normal;
            this.btn8.Location = new System.Drawing.Point(100, 0);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(100, 53);
            this.btn8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn8.TabIndex = 14;
            this.btn8.Tag = "8";
            this.btn8.Text = "拨打";
            this.btn8.Click += new System.EventHandler(this.btn3_Click_1);
            // 
            // btn7
            // 
            this.btn7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn7.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn7.HoverImage = global::DispatchPlatform.Properties.Resources.cb_7_on;
            this.btn7.Image = global::DispatchPlatform.Properties.Resources.cb_7_normal;
            this.btn7.Location = new System.Drawing.Point(0, 0);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(100, 53);
            this.btn7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn7.TabIndex = 13;
            this.btn7.Tag = "7";
            this.btn7.Text = "转接";
            this.btn7.Click += new System.EventHandler(this.btn3_Click_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnJing);
            this.panel3.Controls.Add(this.btn0);
            this.panel3.Controls.Add(this.btnXing);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(7, 260);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 53);
            this.panel3.TabIndex = 18;
            // 
            // btnJing
            // 
            this.btnJing.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnJing.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnJing.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnJing.HoverImage = global::DispatchPlatform.Properties.Resources.cb_jing_on;
            this.btnJing.Image = global::DispatchPlatform.Properties.Resources.cb_jing_normal;
            this.btnJing.Location = new System.Drawing.Point(200, 0);
            this.btnJing.Name = "btnJing";
            this.btnJing.Size = new System.Drawing.Size(100, 53);
            this.btnJing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnJing.TabIndex = 15;
            this.btnJing.Tag = "#";
            this.btnJing.Text = "拨打";
            this.btnJing.Click += new System.EventHandler(this.btn3_Click_1);
            // 
            // btn0
            // 
            this.btn0.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn0.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn0.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn0.HoverImage = global::DispatchPlatform.Properties.Resources.cb_0_on;
            this.btn0.Image = global::DispatchPlatform.Properties.Resources.cb_0_normal;
            this.btn0.Location = new System.Drawing.Point(100, 0);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(100, 53);
            this.btn0.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn0.TabIndex = 14;
            this.btn0.Tag = "0";
            this.btn0.Text = "拨打";
            this.btn0.Click += new System.EventHandler(this.btn3_Click_1);
            // 
            // btnXing
            // 
            this.btnXing.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXing.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXing.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnXing.HoverImage = global::DispatchPlatform.Properties.Resources.cb_xing_on;
            this.btnXing.Image = global::DispatchPlatform.Properties.Resources.cb_xing_normal;
            this.btnXing.Location = new System.Drawing.Point(0, 0);
            this.btnXing.Name = "btnXing";
            this.btnXing.Size = new System.Drawing.Size(100, 53);
            this.btnXing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXing.TabIndex = 13;
            this.btnXing.Tag = "*";
            this.btnXing.Text = "转接";
            this.btnXing.Click += new System.EventHandler(this.btn3_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnHandup);
            this.panel2.Controls.Add(this.btnCall);
            this.panel2.Controls.Add(this.btnTran);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(7, 313);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 53);
            this.panel2.TabIndex = 16;
            // 
            // btnHandup
            // 
            this.btnHandup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHandup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnHandup.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHandup.HoverImage = global::DispatchPlatform.Properties.Resources.cb_handup_on;
            this.btnHandup.Image = global::DispatchPlatform.Properties.Resources.cb_handup_Normal;
            this.btnHandup.Location = new System.Drawing.Point(200, 0);
            this.btnHandup.Name = "btnHandup";
            this.btnHandup.Size = new System.Drawing.Size(100, 53);
            this.btnHandup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnHandup.TabIndex = 15;
            this.btnHandup.Tooltip = "挂断";
            this.btnHandup.Click += new System.EventHandler(this.btnHandup_Click);
            // 
            // btnCall
            // 
            this.btnCall.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCall.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCall.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCall.HoverImage = global::DispatchPlatform.Properties.Resources.cb_call_on;
            this.btnCall.Image = global::DispatchPlatform.Properties.Resources.cb_call_Normal;
            this.btnCall.Location = new System.Drawing.Point(100, 0);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(100, 53);
            this.btnCall.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCall.TabIndex = 14;
            this.btnCall.Text = "拨打";
            this.btnCall.Tooltip = "拨打";
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnTran
            // 
            this.btnTran.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTran.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTran.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTran.HoverImage = global::DispatchPlatform.Properties.Resources.cb_tran_On;
            this.btnTran.Image = global::DispatchPlatform.Properties.Resources.cb_tran_Normal;
            this.btnTran.Location = new System.Drawing.Point(0, 0);
            this.btnTran.Name = "btnTran";
            this.btnTran.Size = new System.Drawing.Size(100, 53);
            this.btnTran.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTran.TabIndex = 13;
            this.btnTran.Text = "转接";
            this.btnTran.Tooltip = "转接";
            this.btnTran.Click += new System.EventHandler(this.btnTran_Click);
            // 
            // FormCallKeyborad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 376);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCallKeyborad";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCallKeyborad";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.panel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCall;
        private DevComponents.DotNetBar.ButtonX btnTran;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnHandup;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.ButtonX btnJing;
        private DevComponents.DotNetBar.ButtonX btn0;
        private DevComponents.DotNetBar.ButtonX btnXing;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.ButtonX btn9;
        private DevComponents.DotNetBar.ButtonX btn8;
        private DevComponents.DotNetBar.ButtonX btn7;
        private System.Windows.Forms.Panel panel6;
        private DevComponents.DotNetBar.ButtonX btn3;
        private DevComponents.DotNetBar.ButtonX btn2;
        private DevComponents.DotNetBar.ButtonX btn1;
        private System.Windows.Forms.Panel panel5;
        private DevComponents.DotNetBar.ButtonX btn6;
        private DevComponents.DotNetBar.ButtonX btn5;
        private DevComponents.DotNetBar.ButtonX btn4;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Panel panel7;
        private DevComponents.DotNetBar.ButtonX btnClear;
        private System.Windows.Forms.Panel panelTop;
    }
}