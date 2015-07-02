namespace VoiceDispatchManage.UI
{
    partial class frmPDSList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.dgvList = new CommControl.BaseDataGridViewEx();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barLeft = new DevComponents.DotNetBar.Bar();
            this.btnAdd = new DevComponents.DotNetBar.ButtonItem();
            this.btnDel = new DevComponents.DotNetBar.ButtonItem();
            this.btnModify = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.Refresh = new DevComponents.DotNetBar.ButtonItem();
            this.btnStyle = new DevComponents.DotNetBar.ButtonItem();
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            this.btnPreview = new DevComponents.DotNetBar.ButtonItem();
            this.btnDesigner = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderVisiblePrimary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dgvList);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.barLeft);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(734, 459);
            this.kryptonHeaderGroup1.StateNormal.HeaderPrimary.Content.ShortText.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonHeaderGroup1.StateNormal.HeaderSecondary.Content.ShortText.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.kryptonHeaderGroup1.TabIndex = 24;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "  用户列表";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "  共0条记录";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.AlternatingRowsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvList.ColumnHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvList.ColumnHeadersHeight = 25;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colCode,
            this.colIP});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvList.Location = new System.Drawing.Point(0, 43);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersDefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowsDefaultBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvList.RowsDefaultSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(41)))), ((int)(((byte)(80)))));
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(211)))), ((int)(((byte)(128)))));
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(732, 393);
            this.dgvList.TabIndex = 26;
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colCode
            // 
            this.colCode.HeaderText = "分组网关编号";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colIP
            // 
            this.colIP.HeaderText = "分组网关IP";
            this.colIP.Name = "colIP";
            this.colIP.ReadOnly = true;
            // 
            // barLeft
            // 
            this.barLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(232)))), ((int)(((byte)(243)))));
            this.barLeft.BarType = DevComponents.DotNetBar.eBarType.MenuBar;
            this.barLeft.ColorScheme.BarBackground = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.barLeft.ColorScheme.BarBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(206)))), ((int)(((byte)(235)))));
            this.barLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.barLeft.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnAdd,
            this.btnDel,
            this.btnModify,
            this.labelItem1,
            this.Refresh,
            this.btnStyle,
            this.btnPrint});
            this.barLeft.Location = new System.Drawing.Point(0, 0);
            this.barLeft.Name = "barLeft";
            this.barLeft.PaddingBottom = 10;
            this.barLeft.PaddingLeft = 100;
            this.barLeft.PaddingRight = 10;
            this.barLeft.PaddingTop = 10;
            this.barLeft.SingleLineColor = System.Drawing.Color.Transparent;
            this.barLeft.Size = new System.Drawing.Size(732, 43);
            this.barLeft.Stretch = true;
            this.barLeft.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.barLeft.TabIndex = 22;
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
            this.btnModify.Visible = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // labelItem1
            // 
            this.labelItem1.Image = global::VoiceDispatchManage.Properties.Resources.split;
            this.labelItem1.Name = "labelItem1";
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
            this.btnPrint.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Text = "打印预览";
            // 
            // btnDesigner
            // 
            this.btnDesigner.Name = "btnDesigner";
            this.btnDesigner.Text = "报表设计";
            // 
            // frmPDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Name = "frmPDS";
            this.Size = new System.Drawing.Size(734, 459);
            this.Load += new System.EventHandler(this.frmPDS_Load);
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private CommControl.BaseDataGridViewEx dgvList;
        private DevComponents.DotNetBar.Bar barLeft;
        private DevComponents.DotNetBar.ButtonItem btnAdd;
        private DevComponents.DotNetBar.ButtonItem btnDel;
        private DevComponents.DotNetBar.ButtonItem btnModify;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.ButtonItem Refresh;
        private DevComponents.DotNetBar.ButtonItem btnStyle;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
        private DevComponents.DotNetBar.ButtonItem btnPreview;
        private DevComponents.DotNetBar.ButtonItem btnDesigner;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIP;

    }
}
