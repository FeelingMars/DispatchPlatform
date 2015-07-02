namespace VoiceDispatchManage.UI
{
    partial class frmStaticRoute
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
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.txtMask = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGatewayIP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtIP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelWorkArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.btnNo);
            this.panelWorkArea.Controls.Add(this.btnOK);
            this.panelWorkArea.Controls.Add(this.txtGatewayIP);
            this.panelWorkArea.Controls.Add(this.txtIP);
            this.panelWorkArea.Controls.Add(this.txtMask);
            this.panelWorkArea.Controls.Add(this.label3);
            this.panelWorkArea.Controls.Add(this.label2);
            this.panelWorkArea.Controls.Add(this.label1);
            this.panelWorkArea.Size = new System.Drawing.Size(327, 278);
            // 
            // panelTitle
            // 
            this.panelTitle.Size = new System.Drawing.Size(170, 28);
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(182, 196);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(69, 26);
            this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNo.TabIndex = 120;
            this.btnNo.Text = "取消";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(84, 196);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(69, 26);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 119;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtMask
            // 
            // 
            // 
            // 
            this.txtMask.Border.Class = "";
            this.txtMask.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMask.Location = new System.Drawing.Point(139, 93);
            this.txtMask.MaxLength = 50;
            this.txtMask.Name = "txtMask";
            this.txtMask.Size = new System.Drawing.Size(118, 21);
            this.txtMask.TabIndex = 1;
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(28, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 118;
            this.label2.Text = "静态路由子网掩码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(64, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 116;
            this.label1.Text = "静态路由IP：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(40, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 118;
            this.label3.Text = "静态路由网关IP：";
            // 
            // txtGatewayIP
            // 
            // 
            // 
            // 
            this.txtGatewayIP.Border.Class = "TextBoxBorder";
            this.txtGatewayIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtGatewayIP.Location = new System.Drawing.Point(139, 135);
            this.txtGatewayIP.MaxLength = 50;
            this.txtGatewayIP.Name = "txtGatewayIP";
            this.txtGatewayIP.Size = new System.Drawing.Size(118, 21);
            this.txtGatewayIP.TabIndex = 2;
            
            // 
            // txtIP
            // 
            // 
            // 
            // 
            this.txtIP.Border.Class = "TextBoxBorder";
            this.txtIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIP.Location = new System.Drawing.Point(139, 51);
            this.txtIP.MaxLength = 50;
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(118, 21);
            this.txtIP.TabIndex = 0;
            this.txtIP.Leave += new System.EventHandler(this.txtIP_Leave);
            // 
            // frmStaticRoute
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(329, 308);
            this.Name = "frmStaticRoute";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStaticRoute";
            
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.Controls.TextBoxX txtGatewayIP;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIP;
    }
}