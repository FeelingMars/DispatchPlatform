namespace VoiceDispatchManage.UI
{
    partial class frmGroupManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroupManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panRightTop = new System.Windows.Forms.Panel();
            this.kryptonHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.dgvRight = new CommControl.BaseDataGridViewEx();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemebrMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barRight = new DevComponents.DotNetBar.Bar();
            this.btnAddRight = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelRight = new DevComponents.DotNetBar.ButtonItem();
            this.btnClearAll = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.btnRefushRight = new DevComponents.DotNetBar.ButtonItem();
            this.btnStyleRight = new DevComponents.DotNetBar.ButtonItem();
            this.panLeftTop = new System.Windows.Forms.Panel();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.dgvLeft = new CommControl.BaseDataGridViewEx();
            this.barLeft = new DevComponents.DotNetBar.Bar();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnDel = new DevComponents.DotNetBar.ButtonItem();
            this.btnModify = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.buttonItem9 = new DevComponents.DotNetBar.ButtonItem();
            this.Refresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnStyle = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.btnPreview = new DevComponents.DotNetBar.ButtonItem();
            this.btnDesigner = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMemberCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).BeginInit();
            this.kryptonHeaderGroup2.Panel.SuspendLayout();
            this.kryptonHeaderGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barRight)).BeginInit();
            this.panLeftTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panRightTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panLeftTop, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(883, 546);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // panRightTop
            // 
            this.panRightTop.Controls.Add(this.kryptonHeaderGroup2);
            this.panRightTop.Controls.Add(this.barRight);
            this.panRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRightTop.Location = new System.Drawing.Point(441, 0);
            this.panRightTop.Margin = new System.Windows.Forms.Padding(0);
            this.panRightTop.Name = "panRightTop";
            this.panRightTop.Size = new System.Drawing.Size(442, 546);
            this.panRightTop.TabIndex = 11;
            // 
            // kryptonHeaderGroup2
            // 
            this.kryptonHeaderGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup2.HeaderVisiblePrimary = false;
            this.kryptonHeaderGroup2.Location = new System.Drawing.Point(0, 43);
            this.kryptonHeaderGroup2.Name = "kryptonHeaderGroup2";
            // 
            // kryptonHeaderGroup2.Panel
            // 
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.dgvRight);
            this.kryptonHeaderGroup2.Size = new System.Drawing.Size(442, 503);
            this.kryptonHeaderGroup2.StateNormal.HeaderPrimary.Content.ShortText.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonHeaderGroup2.StateNormal.HeaderSecondary.Content.ShortText.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonHeaderGroup2.TabIndex = 35;
            this.kryptonHeaderGroup2.ValuesPrimary.Heading = "  用户列表";
            this.kryptonHeaderGroup2.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup2.ValuesSecondary.Heading = "  共0条记录";
            // 
            // dgvRight
            // 
            this.dgvRight.AllowUserToAddRows = false;
            this.dgvRight.AllowUserToDeleteRows = false;
            this.dgvRight.AllowUserToResizeRows = false;
            this.dgvRight.AlternatingRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvRight.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRight.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRight.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRight.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRight.ColumnHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRight.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRight.ColumnHeadersHeight = 25;
            this.dgvRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.colMemberName,
            this.colMemberNumber,
            this.colMemebrMemo,
            this.colMemberID});
            this.dgvRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRight.EnableHeadersVisualStyles = false;
            this.dgvRight.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvRight.Location = new System.Drawing.Point(0, 0);
            this.dgvRight.MultiSelect = false;
            this.dgvRight.Name = "dgvRight";
            this.dgvRight.ReadOnly = true;
            this.dgvRight.RowHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRight.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRight.RowHeadersVisible = false;
            this.dgvRight.RowsDefaultBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvRight.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRight.RowsDefaultSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvRight.RowTemplate.Height = 23;
            this.dgvRight.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvRight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRight.Size = new System.Drawing.Size(440, 480);
            this.dgvRight.TabIndex = 30;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "序号";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // colMemberName
            // 
            this.colMemberName.HeaderText = " 姓名";
            this.colMemberName.Name = "colMemberName";
            this.colMemberName.ReadOnly = true;
            // 
            // colMemberNumber
            // 
            this.colMemberNumber.HeaderText = "号码";
            this.colMemberNumber.Name = "colMemberNumber";
            this.colMemberNumber.ReadOnly = true;
            // 
            // colMemebrMemo
            // 
            this.colMemebrMemo.HeaderText = "备注";
            this.colMemebrMemo.Name = "colMemebrMemo";
            this.colMemebrMemo.ReadOnly = true;
            // 
            // colMemberID
            // 
            this.colMemberID.HeaderText = "ID";
            this.colMemberID.Name = "colMemberID";
            this.colMemberID.ReadOnly = true;
            this.colMemberID.Visible = false;
            // 
            // barRight
            // 
            this.barRight.BackColor = System.Drawing.Color.Transparent;
            this.barRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("barRight.BackgroundImage")));
            this.barRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barRight.BarType = DevComponents.DotNetBar.eBarType.MenuBar;
            this.barRight.ColorScheme.BarBackground = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.barRight.ColorScheme.BarBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(235)))));
            this.barRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.barRight.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.barRight.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAddRight,
            this.btnDelRight,
            this.btnClearAll,
            this.labelItem2,
            this.btnRefushRight,
            this.btnStyleRight});
            this.barRight.Location = new System.Drawing.Point(0, 0);
            this.barRight.Margin = new System.Windows.Forms.Padding(0);
            this.barRight.Name = "barRight";
            this.barRight.PaddingBottom = 10;
            this.barRight.PaddingLeft = 50;
            this.barRight.PaddingRight = 10;
            this.barRight.PaddingTop = 10;
            this.barRight.SingleLineColor = System.Drawing.Color.Transparent;
            this.barRight.Size = new System.Drawing.Size(442, 43);
            this.barRight.Stretch = true;
            this.barRight.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.barRight.TabIndex = 30;
            this.barRight.TabStop = false;
            this.barRight.Text = "bar1";
            // 
            // btnAddRight
            // 
            this.btnAddRight.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAddRight.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAddRight.Image = global::VoiceDispatchManage.Properties.Resources.Add;
            this.btnAddRight.Name = "btnAddRight";
            this.btnAddRight.Text = "新增";
            this.btnAddRight.Click += new System.EventHandler(this.btnAddRight_Click);
            // 
            // btnDelRight
            // 
            this.btnDelRight.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDelRight.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDelRight.Image = global::VoiceDispatchManage.Properties.Resources.Delete;
            this.btnDelRight.Name = "btnDelRight";
            this.btnDelRight.Text = "删除";
            this.btnDelRight.Click += new System.EventHandler(this.btnDelRight_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnClearAll.Image = global::VoiceDispatchManage.Properties.Resources.ClearAll;
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Text = "清空";
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // labelItem2
            // 
            this.labelItem2.Image = ((System.Drawing.Image)(resources.GetObject("labelItem2.Image")));
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem5});
            // 
            // buttonItem5
            // 
            this.buttonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonItem5.Image = global::VoiceDispatchManage.Properties.Resources.Modify;
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.Text = "修改";
            // 
            // btnRefushRight
            // 
            this.btnRefushRight.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnRefushRight.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRefushRight.Image = global::VoiceDispatchManage.Properties.Resources.Refresh;
            this.btnRefushRight.Name = "btnRefushRight";
            this.btnRefushRight.Text = "刷新";
            this.btnRefushRight.Click += new System.EventHandler(this.btnRefushRight_Click);
            // 
            // btnStyleRight
            // 
            this.btnStyleRight.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnStyleRight.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnStyleRight.Image = global::VoiceDispatchManage.Properties.Resources.GridStyle;
            this.btnStyleRight.Name = "btnStyleRight";
            this.btnStyleRight.Text = "样式";
            this.btnStyleRight.Click += new System.EventHandler(this.btnStyleRight_Click);
            // 
            // panLeftTop
            // 
            this.panLeftTop.BackColor = System.Drawing.SystemColors.Info;
            this.panLeftTop.Controls.Add(this.kryptonHeaderGroup1);
            this.panLeftTop.Controls.Add(this.barLeft);
            this.panLeftTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panLeftTop.Location = new System.Drawing.Point(0, 0);
            this.panLeftTop.Margin = new System.Windows.Forms.Padding(0);
            this.panLeftTop.Name = "panLeftTop";
            this.panLeftTop.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.panLeftTop.Size = new System.Drawing.Size(441, 546);
            this.panLeftTop.TabIndex = 10;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderVisiblePrimary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 43);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dgvLeft);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(436, 503);
            this.kryptonHeaderGroup1.StateNormal.HeaderPrimary.Content.ShortText.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonHeaderGroup1.StateNormal.HeaderSecondary.Content.ShortText.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonHeaderGroup1.TabIndex = 37;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "  用户列表";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "  共0条记录";
            // 
            // dgvLeft
            // 
            this.dgvLeft.AllowUserToAddRows = false;
            this.dgvLeft.AllowUserToDeleteRows = false;
            this.dgvLeft.AllowUserToResizeRows = false;
            this.dgvLeft.AlternatingRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvLeft.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLeft.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLeft.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLeft.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLeft.ColumnHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLeft.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLeft.ColumnHeadersHeight = 25;
            this.dgvLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLeft.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGroupNo,
            this.colName,
            this.colMemo,
            this.colMemberCount,
            this.colID});
            this.dgvLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLeft.EnableHeadersVisualStyles = false;
            this.dgvLeft.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvLeft.Location = new System.Drawing.Point(0, 0);
            this.dgvLeft.MultiSelect = false;
            this.dgvLeft.Name = "dgvLeft";
            this.dgvLeft.ReadOnly = true;
            this.dgvLeft.RowHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLeft.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLeft.RowHeadersVisible = false;
            this.dgvLeft.RowsDefaultBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvLeft.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLeft.RowsDefaultSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvLeft.RowTemplate.Height = 23;
            this.dgvLeft.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvLeft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLeft.Size = new System.Drawing.Size(434, 480);
            this.dgvLeft.TabIndex = 31;
            this.dgvLeft.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLeft_CellClick);
            this.dgvLeft.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLeft_RowEnter);
            this.dgvLeft.SelectionChanged += new System.EventHandler(this.dgvLeft_SelectionChanged);
            // 
            // barLeft
            // 
            this.barLeft.AccessibleDescription = "bar1 (barLeft)";
            this.barLeft.AccessibleName = "bar1";
            this.barLeft.AccessibleRole = System.Windows.Forms.AccessibleRole.RowHeader;
            this.barLeft.BackColor = System.Drawing.Color.Transparent;
            this.barLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("barLeft.BackgroundImage")));
            this.barLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barLeft.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.barLeft.ColorScheme.BarBackground = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.barLeft.ColorScheme.BarBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(235)))));
            this.barLeft.ColorScheme.BarDockedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.barLeft.ColorScheme.PanelBorder = System.Drawing.Color.Red;
            this.barLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.barLeft.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.barLeft.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barLeft.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAdd,
            this.btnDel,
            this.btnModify,
            this.labelItem1,
            this.Refresh,
            this.btnStyle,
            this.btnPrint});
            this.barLeft.Location = new System.Drawing.Point(0, 0);
            this.barLeft.Margin = new System.Windows.Forms.Padding(0);
            this.barLeft.Name = "barLeft";
            this.barLeft.PaddingBottom = 10;
            this.barLeft.PaddingLeft = 50;
            this.barLeft.PaddingRight = 10;
            this.barLeft.PaddingTop = 10;
            this.barLeft.SingleLineColor = System.Drawing.Color.Red;
            this.barLeft.Size = new System.Drawing.Size(436, 43);
            this.barLeft.Stretch = true;
            this.barLeft.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.barLeft.TabIndex = 29;
            this.barLeft.TabStop = false;
            this.barLeft.Text = "bar1";
            // 
            // btnAdd
            // 
            this.btnAdd.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnAdd.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnAdd.Image = global::VoiceDispatchManage.Properties.Resources.Add;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnDel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnDel.Image = global::VoiceDispatchManage.Properties.Resources.Delete;
            this.btnDel.Name = "btnDel";
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnModify
            // 
            this.btnModify.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnModify.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnModify.Image = global::VoiceDispatchManage.Properties.Resources.Modify;
            this.btnModify.Name = "btnModify";
            this.btnModify.Text = "修改";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // labelItem1
            // 
            this.labelItem1.Image = ((System.Drawing.Image)(resources.GetObject("labelItem1.Image")));
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem9});
            // 
            // buttonItem9
            // 
            this.buttonItem9.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonItem9.Image = global::VoiceDispatchManage.Properties.Resources.Modify;
            this.buttonItem9.Name = "buttonItem9";
            this.buttonItem9.Text = "修改";
            // 
            // Refresh
            // 
            this.Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Refresh.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Refresh.Image = global::VoiceDispatchManage.Properties.Resources.Refresh;
            this.Refresh.Name = "Refresh";
            this.Refresh.Text = "刷新";
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // btnStyle
            // 
            this.btnStyle.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnStyle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnStyle.Image = global::VoiceDispatchManage.Properties.Resources.GridStyle;
            this.btnStyle.Name = "btnStyle";
            this.btnStyle.Text = "样式";
            this.btnStyle.Click += new System.EventHandler(this.btnStyle_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrint.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnPrint.Image = global::VoiceDispatchManage.Properties.Resources.printer;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnPreview,
            this.btnDesigner});
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Text = "打印预览";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnDesigner
            // 
            this.btnDesigner.Name = "btnDesigner";
            this.btnDesigner.Text = "报表设计";
            this.btnDesigner.Click += new System.EventHandler(this.btnDesigner_Click);
            // 
            // buttonItem6
            // 
            this.buttonItem6.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonItem6.Image = global::VoiceDispatchManage.Properties.Resources.Modify;
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Text = "修改";
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonItem1.Image = global::VoiceDispatchManage.Properties.Resources.Modify;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "修改";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = " 姓名";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 135;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "  序号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 129;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = " 部门名称";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 128;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "备注";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 129;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "ID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "ID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // colGroupNo
            // 
            this.colGroupNo.HeaderText = "序号";
            this.colGroupNo.Name = "colGroupNo";
            this.colGroupNo.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.HeaderText = " 分组名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colMemo
            // 
            this.colMemo.HeaderText = "分组描述";
            this.colMemo.Name = "colMemo";
            this.colMemo.ReadOnly = true;
            // 
            // colMemberCount
            // 
            this.colMemberCount.HeaderText = "成员数";
            this.colMemberCount.Name = "colMemberCount";
            this.colMemberCount.ReadOnly = true;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // frmGroupManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmGroupManage";
            this.Size = new System.Drawing.Size(883, 546);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panRightTop.ResumeLayout(false);
            this.kryptonHeaderGroup2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).EndInit();
            this.kryptonHeaderGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barRight)).EndInit();
            this.panLeftTop.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem buttonItem6;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panRightTop;
        public ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup2;
        private CommControl.BaseDataGridViewEx dgvRight;
        private DevComponents.DotNetBar.Bar barRight;
        private DevComponents.DotNetBar.ButtonItem btnAddRight;
        private DevComponents.DotNetBar.ButtonItem btnDelRight;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.ButtonItem btnRefushRight;
        private DevComponents.DotNetBar.ButtonItem btnStyleRight;
        private System.Windows.Forms.Panel panLeftTop;
        public ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private CommControl.BaseDataGridViewEx dgvLeft;
        private DevComponents.DotNetBar.Bar barLeft;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnDel;
        private DevComponents.DotNetBar.ButtonItem btnModify;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem9;
        private DevComponents.DotNetBar.ButtonItem Refresh;
        private DevComponents.DotNetBar.ButtonItem btnStyle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DevComponents.DotNetBar.ButtonItem btnClearAll;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
        private DevComponents.DotNetBar.ButtonItem btnPreview;
        private DevComponents.DotNetBar.ButtonItem btnDesigner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemebrMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;

    }
}
