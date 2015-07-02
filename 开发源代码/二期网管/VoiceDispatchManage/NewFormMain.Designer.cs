namespace VoiceDispatchManage
{
    partial class NewFormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFormMain));
            this.node1 = new DevComponents.AdvTree.Node();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panRight = new System.Windows.Forms.Panel();
            this.panelTip = new System.Windows.Forms.Panel();
            this.labTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslState = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelToolBar = new System.Windows.Forms.Panel();
            this.panelToolBarMid = new System.Windows.Forms.Panel();
            this.panelToolBarRight = new System.Windows.Forms.Panel();
            this.panelToolBarLeft = new System.Windows.Forms.Panel();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnLogManage = new DevComponents.DotNetBar.ButtonX();
            this.btnOperateLog = new DevComponents.DotNetBar.ButtonItem();
            this.btnCallLog = new DevComponents.DotNetBar.ButtonItem();
            this.btnAlarmLog = new DevComponents.DotNetBar.ButtonItem();
            this.btnAdminManage = new DevComponents.DotNetBar.ButtonX();
            this.btnDepManage = new DevComponents.DotNetBar.ButtonX();
            this.btnSiteManage = new DevComponents.DotNetBar.ButtonX();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.panLeft = new System.Windows.Forms.Panel();
            this.tvTree = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelTip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelToolBar.SuspendLayout();
            this.panelToolBarLeft.SuspendLayout();
            this.panLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvTree)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // node1
            // 
            this.node1.Name = "node1";
            this.node1.Text = "panRight";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            this.panelMain.Controls.Add(this.panRight);
            this.panelMain.Controls.Add(this.panelTip);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 95);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(796, 394);
            this.panelMain.TabIndex = 0;
            // 
            // panRight
            // 
            this.panRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panRight.Location = new System.Drawing.Point(0, 30);
            this.panRight.Name = "panRight";
            this.panRight.Size = new System.Drawing.Size(796, 364);
            this.panRight.TabIndex = 10021;
            // 
            // panelTip
            // 
            this.panelTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.panelTip.BackgroundImage = global::VoiceDispatchManage.Properties.Resources.TipBacekGround;
            this.panelTip.Controls.Add(this.labTitle);
            this.panelTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTip.Location = new System.Drawing.Point(0, 0);
            this.panelTip.Name = "panelTip";
            this.panelTip.Size = new System.Drawing.Size(796, 30);
            this.panelTip.TabIndex = 10024;
            // 
            // labTitle
            // 
            this.labTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labTitle.BackColor = System.Drawing.Color.Transparent;
            this.labTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.Location = new System.Drawing.Point(387, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(409, 30);
            this.labTitle.TabIndex = 1;
            this.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(226)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(211, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(474, 253);
            this.panel2.TabIndex = 10023;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(174)))), ((int)(((byte)(209)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslState});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 489);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(996, 30);
            this.statusStrip1.TabIndex = 10014;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslState
            // 
            this.tslState.BackColor = System.Drawing.Color.Transparent;
            this.tslState.ForeColor = System.Drawing.Color.White;
            this.tslState.Margin = new System.Windows.Forms.Padding(6, 3, 0, 2);
            this.tslState.Name = "tslState";
            this.tslState.Size = new System.Drawing.Size(43, 25);
            this.tslState.Text = "就绪...";
            // 
            // panelToolBar
            // 
            this.panelToolBar.Controls.Add(this.panelToolBarMid);
            this.panelToolBar.Controls.Add(this.panelToolBarRight);
            this.panelToolBar.Controls.Add(this.panelToolBarLeft);
            this.panelToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolBar.Location = new System.Drawing.Point(0, 30);
            this.panelToolBar.Name = "panelToolBar";
            this.panelToolBar.Size = new System.Drawing.Size(996, 65);
            this.panelToolBar.TabIndex = 10016;
            // 
            // panelToolBarMid
            // 
            this.panelToolBarMid.BackgroundImage = global::VoiceDispatchManage.Properties.Resources.ToolBarMid;
            this.panelToolBarMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelToolBarMid.Location = new System.Drawing.Point(420, 0);
            this.panelToolBarMid.Name = "panelToolBarMid";
            this.panelToolBarMid.Size = new System.Drawing.Size(26, 65);
            this.panelToolBarMid.TabIndex = 2;
            // 
            // panelToolBarRight
            // 
            this.panelToolBarRight.BackgroundImage = global::VoiceDispatchManage.Properties.Resources.ToolBarRigth;
            this.panelToolBarRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelToolBarRight.Location = new System.Drawing.Point(446, 0);
            this.panelToolBarRight.Name = "panelToolBarRight";
            this.panelToolBarRight.Size = new System.Drawing.Size(550, 65);
            this.panelToolBarRight.TabIndex = 1;
            // 
            // panelToolBarLeft
            // 
            this.panelToolBarLeft.BackgroundImage = global::VoiceDispatchManage.Properties.Resources.ToolBarLeft;
            this.panelToolBarLeft.Controls.Add(this.btnExit);
            this.panelToolBarLeft.Controls.Add(this.btnLogManage);
            this.panelToolBarLeft.Controls.Add(this.btnAdminManage);
            this.panelToolBarLeft.Controls.Add(this.btnDepManage);
            this.panelToolBarLeft.Controls.Add(this.btnSiteManage);
            this.panelToolBarLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelToolBarLeft.Location = new System.Drawing.Point(0, 0);
            this.panelToolBarLeft.Name = "panelToolBarLeft";
            this.panelToolBarLeft.Size = new System.Drawing.Size(420, 65);
            this.panelToolBarLeft.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnExit.FocusCuesEnabled = false;
            this.btnExit.Image = global::VoiceDispatchManage.Properties.Resources.btnExit;
            this.btnExit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnExit.Location = new System.Drawing.Point(351, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 62);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogManage
            // 
            this.btnLogManage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogManage.BackColor = System.Drawing.Color.Transparent;
            this.btnLogManage.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnLogManage.FocusCuesEnabled = false;
            this.btnLogManage.Image = global::VoiceDispatchManage.Properties.Resources.日志管理;
            this.btnLogManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLogManage.Location = new System.Drawing.Point(262, 3);
            this.btnLogManage.Name = "btnLogManage";
            this.btnLogManage.Size = new System.Drawing.Size(83, 62);
            this.btnLogManage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLogManage.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnOperateLog,
            this.btnCallLog,
            this.btnAlarmLog});
            this.btnLogManage.TabIndex = 0;
            this.btnLogManage.Text = "日志管理";
            this.btnLogManage.Click += new System.EventHandler(this.btnLogManage_Click);
            // 
            // btnOperateLog
            // 
            this.btnOperateLog.GlobalItem = false;
            this.btnOperateLog.Name = "btnOperateLog";
            this.btnOperateLog.Text = "操作日志";
            this.btnOperateLog.Click += new System.EventHandler(this.tsOperateLog_Click);
            // 
            // btnCallLog
            // 
            this.btnCallLog.GlobalItem = false;
            this.btnCallLog.Name = "btnCallLog";
            this.btnCallLog.Text = "调度日志";
            this.btnCallLog.Click += new System.EventHandler(this.tsDispatchLog_Click_1);
            // 
            // btnAlarmLog
            // 
            this.btnAlarmLog.GlobalItem = false;
            this.btnAlarmLog.Name = "btnAlarmLog";
            this.btnAlarmLog.Text = "告警日志";
            this.btnAlarmLog.Click += new System.EventHandler(this.tsAlarmLog_Click);
            // 
            // btnAdminManage
            // 
            this.btnAdminManage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdminManage.BackColor = System.Drawing.Color.Transparent;
            this.btnAdminManage.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnAdminManage.FocusCuesEnabled = false;
            this.btnAdminManage.Image = global::VoiceDispatchManage.Properties.Resources.系统用户管理;
            this.btnAdminManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnAdminManage.Location = new System.Drawing.Point(173, 3);
            this.btnAdminManage.Name = "btnAdminManage";
            this.btnAdminManage.Size = new System.Drawing.Size(89, 62);
            this.btnAdminManage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdminManage.TabIndex = 0;
            this.btnAdminManage.Text = "系统用户管理";
            this.btnAdminManage.Click += new System.EventHandler(this.tsUserManage_Click);
            // 
            // btnDepManage
            // 
            this.btnDepManage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDepManage.BackColor = System.Drawing.Color.Transparent;
            this.btnDepManage.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnDepManage.FocusCuesEnabled = false;
            this.btnDepManage.Image = global::VoiceDispatchManage.Properties.Resources.部门管理;
            this.btnDepManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnDepManage.Location = new System.Drawing.Point(98, 3);
            this.btnDepManage.Name = "btnDepManage";
            this.btnDepManage.Size = new System.Drawing.Size(75, 62);
            this.btnDepManage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDepManage.TabIndex = 0;
            this.btnDepManage.Text = "部门管理";
            this.btnDepManage.Click += new System.EventHandler(this.tsDepartmentManage_Click);
            // 
            // btnSiteManage
            // 
            this.btnSiteManage.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSiteManage.BackColor = System.Drawing.Color.Transparent;
            this.btnSiteManage.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSiteManage.FocusCuesEnabled = false;
            this.btnSiteManage.Image = global::VoiceDispatchManage.Properties.Resources.站点管理;
            this.btnSiteManage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnSiteManage.Location = new System.Drawing.Point(23, 3);
            this.btnSiteManage.Name = "btnSiteManage";
            this.btnSiteManage.Size = new System.Drawing.Size(75, 62);
            this.btnSiteManage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSiteManage.TabIndex = 0;
            this.btnSiteManage.Text = "站点管理";
            this.btnSiteManage.Click += new System.EventHandler(this.tsBoxManage_Click);
            // 
            // elementStyle1
            // 
            this.elementStyle1.Class = "";
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // panLeft
            // 
            this.panLeft.Controls.Add(this.tvTree);
            this.panLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panLeft.Location = new System.Drawing.Point(0, 95);
            this.panLeft.Name = "panLeft";
            this.panLeft.Size = new System.Drawing.Size(195, 394);
            this.panLeft.TabIndex = 10017;
            // 
            // tvTree
            // 
            this.tvTree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.tvTree.AllowDrop = true;
            this.tvTree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.tvTree.BackgroundStyle.Class = "TreeBorderKey";
            this.tvTree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tvTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTree.GridColumnLines = false;
            this.tvTree.Location = new System.Drawing.Point(0, 0);
            this.tvTree.Name = "tvTree";
            this.tvTree.NodesConnector = this.nodeConnector1;
            this.tvTree.NodeStyle = this.elementStyle1;
            this.tvTree.PathSeparator = ";";
            this.tvTree.Size = new System.Drawing.Size(195, 394);
            this.tvTree.TabIndex = 3;
            this.tvTree.Text = "advTree1";
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(195, 95);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(5, 394);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 10019;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.BackgroundImage = global::VoiceDispatchManage.Properties.Resources.TopBackGround;
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(996, 30);
            this.panelTop.TabIndex = 10015;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnClose.FocusCuesEnabled = false;
            this.btnClose.Image = global::VoiceDispatchManage.Properties.Resources.close;
            this.btnClose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClose.Location = new System.Drawing.Point(963, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 24);
            this.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnClose.TabIndex = 1;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::VoiceDispatchManage.Properties.Resources.manage;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(30, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "网管软件";
            // 
            // NewFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 519);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.panLeft);
            this.Controls.Add(this.panelToolBar);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewFormMain";
            this.Text = "网管软件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMain.ResumeLayout(false);
            this.panelTip.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelToolBar.ResumeLayout(false);
            this.panelToolBarLeft.ResumeLayout(false);
            this.panLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvTree)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       // private System.Windows.Forms.Panel panRight;
        private DevComponents.AdvTree.Node node1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelTip;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslState;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelToolBar;
        private System.Windows.Forms.Panel panelToolBarRight;
        private System.Windows.Forms.Panel panelToolBarLeft;
        private System.Windows.Forms.Panel panelToolBarMid;
        private DevComponents.DotNetBar.ButtonX btnSiteManage;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX btnLogManage;
        private DevComponents.DotNetBar.ButtonX btnAdminManage;
        private DevComponents.DotNetBar.ButtonX btnDepManage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private System.Windows.Forms.Panel panLeft;
        private DevComponents.AdvTree.AdvTree tvTree;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
       // private System.Windows.Forms.Panel panRight;
        private DevComponents.DotNetBar.ButtonItem btnOperateLog;
        private DevComponents.DotNetBar.ButtonItem btnCallLog;
        private DevComponents.DotNetBar.ButtonItem btnAlarmLog;
        //private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panRight;
        private DevComponents.DotNetBar.ButtonX btnClose;

    }
}