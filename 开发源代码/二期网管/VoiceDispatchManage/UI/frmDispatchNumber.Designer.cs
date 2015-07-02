namespace VoiceDispatchManage.UI
{
    partial class frmDispatchNumber
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labMes = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDispatchPassword = new CommControl.TextBoxEx();
            this.txtDispatch = new CommControl.TextBoxEx();
            this.labVideoPwd = new System.Windows.Forms.Label();
            this.labVideo = new System.Windows.Forms.Label();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtNumberLen = new CommControl.TextBoxEx();
            this.TxtEmergencyNumber = new CommControl.TextBoxEx();
            this.txtDispatchCenter = new CommControl.TextBoxEx();
            this.chkNumHead = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvList = new CommControl.BaseDataGridViewEx();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDispatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNumHead.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(874, 653);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labMes);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(90, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(693, 516);
            this.panel1.TabIndex = 1;
            // 
            // labMes
            // 
            this.labMes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labMes.AutoSize = true;
            this.labMes.Location = new System.Drawing.Point(71, 1);
            this.labMes.Name = "labMes";
            this.labMes.Size = new System.Drawing.Size(29, 12);
            this.labMes.TabIndex = 6;
            this.labMes.Text = "提示";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.txtDispatchPassword);
            this.groupBox2.Controls.Add(this.txtDispatch);
            this.groupBox2.Controls.Add(this.labVideoPwd);
            this.groupBox2.Controls.Add(this.labVideo);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtNumberLen);
            this.groupBox2.Controls.Add(this.TxtEmergencyNumber);
            this.groupBox2.Controls.Add(this.txtDispatchCenter);
            this.groupBox2.Controls.Add(this.chkNumHead);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(67, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 447);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本配置";
            // 
            // txtDispatchPassword
            // 
            // 
            // 
            // 
            this.txtDispatchPassword.Border.Class = "TextBoxBorder";
            this.txtDispatchPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDispatchPassword.IsNumber = true;
            this.txtDispatchPassword.Location = new System.Drawing.Point(366, 125);
            this.txtDispatchPassword.MaxLength = 10;
            this.txtDispatchPassword.Name = "txtDispatchPassword";
            this.txtDispatchPassword.Size = new System.Drawing.Size(133, 21);
            this.txtDispatchPassword.TabIndex = 104;
            // 
            // txtDispatch
            // 
            // 
            // 
            // 
            this.txtDispatch.Border.Class = "TextBoxBorder";
            this.txtDispatch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDispatch.IsNumber = true;
            this.txtDispatch.Location = new System.Drawing.Point(172, 125);
            this.txtDispatch.MaxLength = 10;
            this.txtDispatch.Name = "txtDispatch";
            this.txtDispatch.Size = new System.Drawing.Size(91, 21);
            this.txtDispatch.TabIndex = 103;
            // 
            // labVideoPwd
            // 
            this.labVideoPwd.AutoSize = true;
            this.labVideoPwd.Location = new System.Drawing.Point(282, 127);
            this.labVideoPwd.Name = "labVideoPwd";
            this.labVideoPwd.Size = new System.Drawing.Size(89, 12);
            this.labVideoPwd.TabIndex = 106;
            this.labVideoPwd.Text = "视频调度密码：";
            // 
            // labVideo
            // 
            this.labVideo.AutoSize = true;
            this.labVideo.Location = new System.Drawing.Point(85, 129);
            this.labVideo.Name = "labVideo";
            this.labVideo.Size = new System.Drawing.Size(89, 12);
            this.labVideo.TabIndex = 105;
            this.labVideo.Text = "视频调度号码：";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(246, 404);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 26);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 102;
            this.btnSave.Text = "保存";
           // this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNumberLen
            // 
            // 
            // 
            // 
            this.txtNumberLen.Border.Class = "TextBoxBorder";
            this.txtNumberLen.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNumberLen.IsNumber = false;
            this.txtNumberLen.Location = new System.Drawing.Point(366, 80);
            this.txtNumberLen.MaxLength = 1;
            this.txtNumberLen.Name = "txtNumberLen";
            this.txtNumberLen.Size = new System.Drawing.Size(133, 21);
            this.txtNumberLen.TabIndex = 4;
            this.txtNumberLen.TextChanged += new System.EventHandler(this.txtNumberLen_TextChanged);
            this.txtNumberLen.MouseEnter += new System.EventHandler(this.txtNumberLen_MouseEnter);
            this.txtNumberLen.MouseLeave += new System.EventHandler(this.txtNumberLen_MouseLeave);
            // 
            // TxtEmergencyNumber
            // 
            // 
            // 
            // 
            this.TxtEmergencyNumber.Border.Class = "TextBoxBorder";
            this.TxtEmergencyNumber.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TxtEmergencyNumber.IsNumber = false;
            this.TxtEmergencyNumber.Location = new System.Drawing.Point(172, 80);
            this.TxtEmergencyNumber.MaxLength = 10;
            this.TxtEmergencyNumber.Name = "TxtEmergencyNumber";
            this.TxtEmergencyNumber.Size = new System.Drawing.Size(91, 21);
            this.TxtEmergencyNumber.TabIndex = 3;
            this.TxtEmergencyNumber.TextChanged += new System.EventHandler(this.TxtEmergencyNumber_TextChanged);
            this.TxtEmergencyNumber.MouseEnter += new System.EventHandler(this.TxtEmergencyNumber_MouseEnter);
            this.TxtEmergencyNumber.MouseLeave += new System.EventHandler(this.TxtEmergencyNumber_MouseLeave);
            // 
            // txtDispatchCenter
            // 
            // 
            // 
            // 
            this.txtDispatchCenter.Border.Class = "TextBoxBorder";
            this.txtDispatchCenter.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDispatchCenter.IsNumber = false;
            this.txtDispatchCenter.Location = new System.Drawing.Point(172, 34);
            this.txtDispatchCenter.MaxLength = 10;
            this.txtDispatchCenter.Name = "txtDispatchCenter";
            this.txtDispatchCenter.Size = new System.Drawing.Size(91, 21);
            this.txtDispatchCenter.TabIndex = 1;
            this.txtDispatchCenter.TextChanged += new System.EventHandler(this.txtDispatchCenter_TextChanged);
            this.txtDispatchCenter.MouseEnter += new System.EventHandler(this.txtDispatchCenter_MouseEnter);
            this.txtDispatchCenter.MouseLeave += new System.EventHandler(this.txtDispatchCenter_MouseLeave);
            // 
            // chkNumHead
            // 
            this.chkNumHead.EditValue = "";
            this.chkNumHead.EnterMoveNextControl = true;
            this.chkNumHead.Location = new System.Drawing.Point(364, 34);
            this.chkNumHead.Name = "chkNumHead";
            this.chkNumHead.Properties.AllowMultiSelect = true;
            this.chkNumHead.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkNumHead.Properties.DropDownRows = 9;
            this.chkNumHead.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("1"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("2"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("3"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("4"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("5"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("6"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("7"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("8"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("9")});
            this.chkNumHead.Properties.PopupFormMinSize = new System.Drawing.Size(100, 0);
            this.chkNumHead.Properties.PopupFormSize = new System.Drawing.Size(155, 200);
            this.chkNumHead.Properties.PopupSizeable = false;
            this.chkNumHead.Properties.SelectAllItemCaption = "全选";
            this.chkNumHead.Properties.UsePopupControlMinSize = true;
            this.chkNumHead.Size = new System.Drawing.Size(155, 20);
            this.chkNumHead.TabIndex = 2;
            this.chkNumHead.MouseEnter += new System.EventHandler(this.chkNumHead_MouseEnter);
            this.chkNumHead.MouseLeave += new System.EventHandler(this.chkNumHead_MouseLeave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvList);
            this.groupBox1.Location = new System.Drawing.Point(67, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 233);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "调度员设置";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AlternatingRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvList.ColumnHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeight = 25;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.colDispatch,
            this.colName,
            this.colNumber});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvList.Location = new System.Drawing.Point(3, 17);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowsDefaultBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvList.RowsDefaultSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvList.Size = new System.Drawing.Size(446, 213);
            this.dgvList.TabIndex = 10018;
            this.dgvList.TabStop = false;
            this.dgvList.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellMouseEnter);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // colDispatch
            // 
            this.colDispatch.HeaderText = "调度员";
            this.colDispatch.Name = "colDispatch";
            this.colDispatch.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.HeaderText = "名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colNumber
            // 
            this.colNumber.HeaderText = "号码";
            this.colNumber.Name = "colNumber";
            this.colNumber.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "调度中心号码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(500, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "位";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(282, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "号码长度限制：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "紧急呼叫号码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "内部分机首位码：";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "位置";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "号码";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "号码";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // frmDispatchNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmDispatchNumber";
            this.Size = new System.Drawing.Size(874, 653);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNumHead.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkNumHead;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private CommControl.BaseDataGridViewEx dgvList;
        private CommControl.TextBoxEx txtNumberLen;
        private CommControl.TextBoxEx TxtEmergencyNumber;
        private CommControl.TextBoxEx txtDispatchCenter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDispatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumber;
        private System.Windows.Forms.Label labMes;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private CommControl.TextBoxEx txtDispatchPassword;
        private CommControl.TextBoxEx txtDispatch;
        private System.Windows.Forms.Label labVideoPwd;
        private System.Windows.Forms.Label labVideo;


    }
}
