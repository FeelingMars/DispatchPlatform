namespace DispatchPlatform
{
    partial class FromRegionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FromRegionView));
            DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnRegionView = new DevComponents.DotNetBar.ButtonX();
            this.timeControl1 = new DispatchPlatform.Control.TimeControl();
            this.superTabControlRegion = new DevComponents.DotNetBar.SuperTabControl();
            this.panel2.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControlRegion)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::DispatchPlatform.Properties.Resources.TopBackGround;
            this.panel2.Controls.Add(this.buttonX1);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(994, 50);
            this.panel2.TabIndex = 2;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX1.FocusCuesEnabled = false;
            this.buttonX1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(150)))));
            this.buttonX1.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.buttonX1.Image = global::DispatchPlatform.Properties.Resources.btnExit;
            this.buttonX1.Location = new System.Drawing.Point(829, 10);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(78, 32);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 57;
            this.buttonX1.Text = "返回首页";
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnExit.FocusCuesEnabled = false;
            this.btnExit.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(150)))));
            this.btnExit.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
            this.btnExit.Image = global::DispatchPlatform.Properties.Resources.btnExit;
            this.btnExit.Location = new System.Drawing.Point(913, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(78, 32);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 56;
            this.btnExit.Text = "退出系统";
            // 
            // lblTitle
            // 
            // 
            // 
            // 
            this.lblTitle.BackgroundStyle.Class = "";
            this.lblTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTitle.Font = new System.Drawing.Font("黑体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(167)))));
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(424, 40);
            this.lblTitle.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.lblTitle.TabIndex = 55;
            this.lblTitle.Text = "语音调度系统";
            // 
            // panelRight
            // 
            this.panelRight.BackgroundImage = global::DispatchPlatform.Properties.Resources.MainBackGround;
            this.panelRight.Controls.Add(this.btnRegionView);
            this.panelRight.Controls.Add(this.timeControl1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(831, 50);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(163, 544);
            this.panelRight.TabIndex = 4;
            // 
            // btnRegionView
            // 
            this.btnRegionView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRegionView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegionView.AutoCheckOnClick = true;
            this.btnRegionView.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRegionView.HoverImage = global::DispatchPlatform.Properties.Resources.MeetingNorml;
            this.btnRegionView.Image = global::DispatchPlatform.Properties.Resources.MeetingNorml;
            this.btnRegionView.Location = new System.Drawing.Point(3, 303);
            this.btnRegionView.Name = "btnRegionView";
            this.btnRegionView.PressedImage = global::DispatchPlatform.Properties.Resources.MeetingSelect;
            this.btnRegionView.Size = new System.Drawing.Size(160, 110);
            this.btnRegionView.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRegionView.TabIndex = 54;
            this.btnRegionView.Click += new System.EventHandler(this.btnRegionView_Click);
            // 
            // timeControl1
            // 
            this.timeControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("timeControl1.BackgroundImage")));
            this.timeControl1.Location = new System.Drawing.Point(0, 422);
            this.timeControl1.Name = "timeControl1";
            this.timeControl1.Size = new System.Drawing.Size(163, 85);
            this.timeControl1.TabIndex = 0;
            // 
            // superTabControlRegion
            // 
            this.superTabControlRegion.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControlRegion.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControlRegion.ControlBox.MenuBox.Name = "";
            this.superTabControlRegion.ControlBox.Name = "";
            this.superTabControlRegion.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControlRegion.ControlBox.MenuBox,
            this.superTabControlRegion.ControlBox.CloseBox});
            this.superTabControlRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlRegion.Location = new System.Drawing.Point(0, 50);
            this.superTabControlRegion.Name = "superTabControlRegion";
            this.superTabControlRegion.ReorderTabsEnabled = false;
            this.superTabControlRegion.SelectedTabFont = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.superTabControlRegion.SelectedTabIndex = 0;
            this.superTabControlRegion.Size = new System.Drawing.Size(831, 544);
            this.superTabControlRegion.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom;
            this.superTabControlRegion.TabFont = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.superTabControlRegion.TabHorizontalSpacing = 10;
            this.superTabControlRegion.TabIndex = 5;
            superTabLinearGradientColorTable1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(48))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(48)))))};
            superTabColorTable1.Background = superTabLinearGradientColorTable1;
            this.superTabControlRegion.TabStripColor = superTabColorTable1;
            this.superTabControlRegion.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.OneNote2007;
            this.superTabControlRegion.Text = "superTabControl4";
            this.superTabControlRegion.SelectedTabChanging += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangingEventArgs>(this.superTabControlRegion_SelectedTabChanging);
            // 
            // FromRegionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(994, 594);
            this.Controls.Add(this.superTabControlRegion);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FromRegionView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FromRegionView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FromRegionView_Load);
            this.panel2.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControlRegion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelRight;
        private Control.TimeControl timeControl1;
        public DevComponents.DotNetBar.ButtonX btnRegionView;
        private DevComponents.DotNetBar.SuperTabControl superTabControlRegion;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}