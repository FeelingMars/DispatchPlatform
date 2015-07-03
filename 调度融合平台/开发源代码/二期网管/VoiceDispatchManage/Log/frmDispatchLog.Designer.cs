namespace VoiceDispatchManage.UI
{
    partial class frmDispatchLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRefreash = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbStyle = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelX19 = new DevComponents.DotNetBar.LabelX();
            this.dtTelStart = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX20 = new DevComponents.DotNetBar.LabelX();
            this.dtTelEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslState = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvLog = new CommControl.BaseDataGridViewEx();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDispatchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDispatchNumbers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelWorkArea.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTelStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTelEnd)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWorkArea
            // 
            this.panelWorkArea.Controls.Add(this.dgvLog);
            this.panelWorkArea.Controls.Add(this.statusStrip1);
            this.panelWorkArea.Controls.Add(this.flowLayoutPanel2);
            this.panelWorkArea.Controls.Add(this.toolStrip1);
            this.panelWorkArea.Size = new System.Drawing.Size(822, 516);
            // 
            // panelTitle
            // 
            this.panelTitle.Size = new System.Drawing.Size(665, 28);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefreash,
            this.toolStripSeparator1,
            this.tsbStyle,
            this.tsbExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(822, 25);
            this.toolStrip1.TabIndex = 10011;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRefreash
            // 
            this.tsbRefreash.Image = global::VoiceDispatchManage.Properties.Resources.Refresh;
            this.tsbRefreash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreash.Name = "tsbRefreash";
            this.tsbRefreash.Size = new System.Drawing.Size(51, 22);
            this.tsbRefreash.Text = "刷新";
            this.tsbRefreash.Click += new System.EventHandler(this.tsbRefreash_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbStyle
            // 
            this.tsbStyle.Image = global::VoiceDispatchManage.Properties.Resources.GridStyle;
            this.tsbStyle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStyle.Name = "tsbStyle";
            this.tsbStyle.Size = new System.Drawing.Size(51, 22);
            this.tsbStyle.Text = "样式";
            this.tsbStyle.Click += new System.EventHandler(this.tsbStyle_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::VoiceDispatchManage.Properties.Resources.Exit1;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(51, 22);
            this.tsbExit.Text = "退出";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel2.Controls.Add(this.labelX19);
            this.flowLayoutPanel2.Controls.Add(this.dtTelStart);
            this.flowLayoutPanel2.Controls.Add(this.labelX20);
            this.flowLayoutPanel2.Controls.Add(this.dtTelEnd);
            this.flowLayoutPanel2.Controls.Add(this.btnQuery);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(822, 40);
            this.flowLayoutPanel2.TabIndex = 10012;
            // 
            // labelX19
            // 
            this.labelX19.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX19.BackgroundStyle.Class = "";
            this.labelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX19.Location = new System.Drawing.Point(6, 8);
            this.labelX19.Margin = new System.Windows.Forms.Padding(6, 8, 3, 3);
            this.labelX19.Name = "labelX19";
            this.labelX19.Size = new System.Drawing.Size(103, 23);
            this.labelX19.TabIndex = 15;
            this.labelX19.Text = "时间范围：（从）";
            // 
            // dtTelStart
            // 
            // 
            // 
            // 
            this.dtTelStart.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtTelStart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtTelStart.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtTelStart.ButtonDropDown.Visible = true;
            this.dtTelStart.IsPopupCalendarOpen = false;
            this.dtTelStart.Location = new System.Drawing.Point(115, 8);
            this.dtTelStart.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            // 
            // 
            // 
            this.dtTelStart.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtTelStart.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtTelStart.MonthCalendar.BackgroundStyle.Class = "";
            this.dtTelStart.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtTelStart.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtTelStart.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtTelStart.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtTelStart.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtTelStart.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtTelStart.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtTelStart.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtTelStart.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtTelStart.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtTelStart.MonthCalendar.DisplayMonth = new System.DateTime(2011, 3, 1, 0, 0, 0, 0);
            this.dtTelStart.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtTelStart.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtTelStart.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtTelStart.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtTelStart.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtTelStart.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtTelStart.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtTelStart.MonthCalendar.TodayButtonVisible = true;
            this.dtTelStart.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtTelStart.Name = "dtTelStart";
            this.dtTelStart.Size = new System.Drawing.Size(133, 21);
            this.dtTelStart.TabIndex = 2;
            // 
            // labelX20
            // 
            this.labelX20.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX20.BackgroundStyle.Class = "";
            this.labelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX20.Location = new System.Drawing.Point(254, 8);
            this.labelX20.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.labelX20.Name = "labelX20";
            this.labelX20.Size = new System.Drawing.Size(42, 23);
            this.labelX20.TabIndex = 17;
            this.labelX20.Text = "（到）";
            // 
            // dtTelEnd
            // 
            // 
            // 
            // 
            this.dtTelEnd.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtTelEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtTelEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtTelEnd.ButtonDropDown.Visible = true;
            this.dtTelEnd.IsPopupCalendarOpen = false;
            this.dtTelEnd.Location = new System.Drawing.Point(302, 8);
            this.dtTelEnd.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            // 
            // 
            // 
            this.dtTelEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtTelEnd.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.dtTelEnd.MonthCalendar.BackgroundStyle.Class = "";
            this.dtTelEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtTelEnd.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtTelEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtTelEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtTelEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtTelEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtTelEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtTelEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtTelEnd.MonthCalendar.CommandsBackgroundStyle.Class = "";
            this.dtTelEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtTelEnd.MonthCalendar.DisplayMonth = new System.DateTime(2011, 3, 1, 0, 0, 0, 0);
            this.dtTelEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtTelEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtTelEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtTelEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtTelEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtTelEnd.MonthCalendar.NavigationBackgroundStyle.Class = "";
            this.dtTelEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtTelEnd.MonthCalendar.TodayButtonVisible = true;
            this.dtTelEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtTelEnd.Name = "dtTelEnd";
            this.dtTelEnd.Size = new System.Drawing.Size(133, 21);
            this.dtTelEnd.TabIndex = 3;
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(441, 8);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(174)))), ((int)(((byte)(209)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslState});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(822, 22);
            this.statusStrip1.TabIndex = 10020;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslState
            // 
            this.tslState.BackColor = System.Drawing.Color.Transparent;
            this.tslState.ForeColor = System.Drawing.Color.White;
            this.tslState.Margin = new System.Windows.Forms.Padding(6, 3, 0, 2);
            this.tslState.Name = "tslState";
            this.tslState.Size = new System.Drawing.Size(43, 17);
            this.tslState.Text = "就绪...";
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AllowUserToResizeRows = false;
            this.dgvLog.AlternatingRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLog.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLog.ColumnHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLog.ColumnHeadersHeight = 25;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column7,
            this.Column1,
            this.Column3,
            this.colDispatchNumber,
            this.colDispatchNumbers,
            this.Column4,
            this.Column5});
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.EnableHeadersVisualStyles = false;
            this.dgvLog.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvLog.Location = new System.Drawing.Point(0, 65);
            this.dgvLog.MultiSelect = false;
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.RowsDefaultBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvLog.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLog.RowsDefaultSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvLog.RowTemplate.Height = 23;
            this.dgvLog.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(822, 429);
            this.dgvLog.TabIndex = 10021;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "dt_DateTime";
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "时间";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "BoxName";
            this.Column7.HeaderText = "站点名称";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "UserName";
            this.Column1.HeaderText = "操作者";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ActionType";
            this.Column3.HeaderText = "动作";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // colDispatchNumber
            // 
            this.colDispatchNumber.DataPropertyName = "DispatchNumber";
            this.colDispatchNumber.HeaderText = "调度号码";
            this.colDispatchNumber.Name = "colDispatchNumber";
            this.colDispatchNumber.ReadOnly = true;
            // 
            // colDispatchNumbers
            // 
            this.colDispatchNumbers.DataPropertyName = "DispatchedNumbers";
            this.colDispatchNumbers.HeaderText = "被调度号码";
            this.colDispatchNumbers.Name = "colDispatchNumbers";
            this.colDispatchNumbers.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Result";
            this.Column4.HeaderText = "操作结果";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "vc_Memo";
            this.Column5.HeaderText = "备注";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // frmDispatchLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 546);
            this.Name = "frmDispatchLog";
            this.NeedMax = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDispatchLog";
            this.panelWorkArea.ResumeLayout(false);
            this.panelWorkArea.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtTelStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTelEnd)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRefreash;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbStyle;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private DevComponents.DotNetBar.LabelX labelX19;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtTelStart;
        private DevComponents.DotNetBar.LabelX labelX20;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtTelEnd;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslState;
        private CommControl.BaseDataGridViewEx dgvLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDispatchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDispatchNumbers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}