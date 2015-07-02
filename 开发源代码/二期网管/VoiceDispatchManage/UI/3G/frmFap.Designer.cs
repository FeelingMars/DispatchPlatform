namespace VoiceDispatchManage.UI
{
    partial class frmFap
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
            this.txtCode = new CommControl.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new CommControl.TextBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdentify = new CommControl.TextBoxEx();
            this.txtV = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFapIP = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panelWorkArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.txtFapIP);
            this.panelWorkArea.Controls.Add(this.txtV);
            this.panelWorkArea.Controls.Add(this.btnNo);
            this.panelWorkArea.Controls.Add(this.btnOK);
            this.panelWorkArea.Controls.Add(this.txtIdentify);
            this.panelWorkArea.Controls.Add(this.txtName);
            this.panelWorkArea.Controls.Add(this.label2);
            this.panelWorkArea.Controls.Add(this.label4);
            this.panelWorkArea.Controls.Add(this.label3);
            this.panelWorkArea.Controls.Add(this.txtCode);
            this.panelWorkArea.Controls.Add(this.label1);
            this.panelWorkArea.Size = new System.Drawing.Size(363, 268);
            // 
            // panelTitle
            // 
            this.panelTitle.Size = new System.Drawing.Size(206, 28);
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(207, 201);
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
            this.btnOK.Location = new System.Drawing.Point(109, 201);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(69, 26);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 119;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtCode
            // 
            // 
            // 
            // 
            this.txtCode.Border.Class = "TextBoxBorder";
            this.txtCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCode.IsNumber = true;
            this.txtCode.Location = new System.Drawing.Point(109, 39);
            this.txtCode.MaxLength = 3;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(205, 21);
            this.txtCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(46, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 117;
            this.label1.Text = "基站编号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(46, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 117;
            this.label3.Text = "基站名称：";
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.IsNumber = false;
            this.txtName.Location = new System.Drawing.Point(109, 82);
            this.txtName.MaxLength = 10;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(205, 21);
            this.txtName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(35, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 117;
            this.label4.Text = "基站标示码：";
            // 
            // txtIdentify
            // 
            // 
            // 
            // 
            this.txtIdentify.Border.Class = "TextBoxBorder";
            this.txtIdentify.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIdentify.IsNumber = true;
            this.txtIdentify.Location = new System.Drawing.Point(109, 125);
            this.txtIdentify.MaxLength = 15;
            this.txtIdentify.Name = "txtIdentify";
            this.txtIdentify.Size = new System.Drawing.Size(102, 21);
            this.txtIdentify.TabIndex = 3;
            // 
            // txtV
            // 
            // 
            // 
            // 
            this.txtV.Border.Class = "TextBoxBorder";
            this.txtV.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtV.Location = new System.Drawing.Point(211, 125);
            this.txtV.MaxLength = 50;
            this.txtV.Name = "txtV";
            this.txtV.ReadOnly = true;
            this.txtV.Size = new System.Drawing.Size(103, 21);
            this.txtV.TabIndex = 121;
            this.txtV.TabStop = false;
            this.txtV.Text = "@strongswan.org";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(46, 167);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 117;
            this.label2.Text = "基站IP：";
            
            // 
            // txtFapIP
            // 
            // 
            // 
            // 
            this.txtFapIP.Border.Class = "TextBoxBorder";
            this.txtFapIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtFapIP.Location = new System.Drawing.Point(109, 162);
            this.txtFapIP.Name = "txtFapIP";
            this.txtFapIP.Size = new System.Drawing.Size(205, 21);
            this.txtFapIP.TabIndex = 4;
            
            // 
            // frmFap
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(365, 298);
            this.Name = "frmFap";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFap";
            this.Load += new System.EventHandler(this.frmFap_Load);
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private CommControl.TextBoxEx txtCode;
        private System.Windows.Forms.Label label1;
        private CommControl.TextBoxEx txtIdentify;
        private CommControl.TextBoxEx txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtV;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtFapIP;
    }
}