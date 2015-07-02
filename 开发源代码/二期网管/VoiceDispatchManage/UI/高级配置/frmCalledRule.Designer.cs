namespace VoiceDispatchManage.UI
{
    partial class frmCalledRule
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
            this.txtNumber = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCallType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCallSubType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.txtListSip = new CommControl.TextBoxListEx();
            this.txtListPri = new CommControl.TextBoxListEx();
            this.txtDele = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.panelWorkArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.txtDele);
            this.panelWorkArea.Controls.Add(this.label5);
            this.panelWorkArea.Controls.Add(this.txtListPri);
            this.panelWorkArea.Controls.Add(this.txtListSip);
            this.panelWorkArea.Controls.Add(this.btnNo);
            this.panelWorkArea.Controls.Add(this.btnOK);
            this.panelWorkArea.Controls.Add(this.label2);
            this.panelWorkArea.Controls.Add(this.label3);
            this.panelWorkArea.Controls.Add(this.cmbCallSubType);
            this.panelWorkArea.Controls.Add(this.label1);
            this.panelWorkArea.Controls.Add(this.cmbCallType);
            this.panelWorkArea.Controls.Add(this.label6);
            this.panelWorkArea.Controls.Add(this.txtNumber);
            this.panelWorkArea.Controls.Add(this.label4);
            this.panelWorkArea.Size = new System.Drawing.Size(340, 324);
            // 
            // panelTitle
            // 
            this.panelTitle.Location = new System.Drawing.Point(59, 0);
            this.panelTitle.Size = new System.Drawing.Size(189, 28);
            // 
            // txtNumber
            // 
            // 
            // 
            // 
            this.txtNumber.Border.Class = "TextBoxBorder";
            this.txtNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNumber.Location = new System.Drawing.Point(142, 102);
            this.txtNumber.MaxLength = 5;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(146, 21);
            this.txtNumber.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(79, 104);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 109;
            this.label4.Text = "号码前缀：";
            // 
            // cmbCallType
            // 
            this.cmbCallType.DisplayMember = "Text";
            this.cmbCallType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCallType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCallType.FormattingEnabled = true;
            this.cmbCallType.ItemHeight = 15;
            this.cmbCallType.Location = new System.Drawing.Point(143, 30);
            this.cmbCallType.Name = "cmbCallType";
            this.cmbCallType.Size = new System.Drawing.Size(146, 21);
            this.cmbCallType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCallType.TabIndex = 0;
            this.cmbCallType.SelectedIndexChanged += new System.EventHandler(this.cmbCallType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(80, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 110;
            this.label6.Text = "呼叫类型：";
            // 
            // cmbCallSubType
            // 
            this.cmbCallSubType.DisplayMember = "Text";
            this.cmbCallSubType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCallSubType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCallSubType.FormattingEnabled = true;
            this.cmbCallSubType.ItemHeight = 15;
            this.cmbCallSubType.Location = new System.Drawing.Point(143, 66);
            this.cmbCallSubType.Name = "cmbCallSubType";
            this.cmbCallSubType.Size = new System.Drawing.Size(146, 21);
            this.cmbCallSubType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbCallSubType.TabIndex = 1;
            this.cmbCallSubType.TabStop = false;
            this.cmbCallSubType.SelectedIndexChanged += new System.EventHandler(this.cmbCallSubType_SelectedIndexChanged);
            this.cmbCallSubType.Click += new System.EventHandler(this.cmbCallSubType_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(68, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 112;
            this.label1.Text = "呼叫子类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(61, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 116;
            this.label2.Text = "PRI中继编号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(61, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 114;
            this.label3.Text = "SIP中继编号：";
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(204, 267);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 26);
            this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNo.TabIndex = 119;
            this.btnNo.Text = "取消";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(89, 267);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 118;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtListSip
            // 
            this.txtListSip.Enabled = false;
            this.txtListSip.Location = new System.Drawing.Point(142, 173);
            this.txtListSip.Name = "txtListSip";
            this.txtListSip.Size = new System.Drawing.Size(146, 21);
            this.txtListSip.TabIndex = 4;
            // 
            // txtListPri
            // 
            this.txtListPri.Enabled = false;
            this.txtListPri.Location = new System.Drawing.Point(142, 209);
            this.txtListPri.Name = "txtListPri";
            this.txtListPri.Size = new System.Drawing.Size(146, 21);
            this.txtListPri.TabIndex = 5;
            // 
            // txtDele
            // 
            // 
            // 
            // 
            this.txtDele.Border.Class = "TextBoxBorder";
            this.txtDele.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDele.Location = new System.Drawing.Point(142, 138);
            this.txtDele.MaxLength = 1;
            this.txtDele.Name = "txtDele";
            this.txtDele.Size = new System.Drawing.Size(146, 21);
            this.txtDele.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(55, 141);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 121;
            this.label5.Text = "删除号码位数：";
            // 
            // frmCalledRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 354);
            this.FormTitle = "增加";
            this.Name = "frmCalledRule";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "增加";
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtNumber;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCallSubType;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCallType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnNo;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private CommControl.TextBoxListEx txtListPri;
        private CommControl.TextBoxListEx txtListSip;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDele;
        private System.Windows.Forms.Label label5;
    }
}