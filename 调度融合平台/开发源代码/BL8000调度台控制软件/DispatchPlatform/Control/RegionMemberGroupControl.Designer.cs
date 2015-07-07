
namespace DispatchPlatform.Control
{
    partial class RegionMemberGroupControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegionMemberGroupControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGroupCall = new DevComponents.DotNetBar.ButtonX();
            this.indexControl = new DispatchPlatform.Control.IndexControl();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::DispatchPlatform.Properties.Resources.MainBackGround;
            this.panel1.Controls.Add(this.btnGroupCall);
            this.panel1.Controls.Add(this.indexControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 316);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 38);
            this.panel1.TabIndex = 0;
            // 
            // btnGroupCall
            // 
            this.btnGroupCall.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGroupCall.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGroupCall.Location = new System.Drawing.Point(8, 4);
            this.btnGroupCall.Name = "btnGroupCall";
            this.btnGroupCall.Size = new System.Drawing.Size(110, 32);
            this.btnGroupCall.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGroupCall.TabIndex = 1;
            this.btnGroupCall.Text = "群呼";
            // 
            // indexControl
            // 
            this.indexControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.indexControl.BackColor = System.Drawing.Color.Transparent;
            this.indexControl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("indexControl.BackgroundImage")));
            this.indexControl.Location = new System.Drawing.Point(375, 6);
            this.indexControl.Name = "indexControl";
            this.indexControl.Size = new System.Drawing.Size(222, 28);
            this.indexControl.TabIndex = 0;
            this.indexControl.SelectIndexChanged += new System.EventHandler<DispatchPlatform.Event.SelectIndexChangeEventArgs>(this.indexControl_SelectIndexChanged);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(601, 316);
            this.flowLayoutPanel.TabIndex = 1;
            this.flowLayoutPanel.Resize += new System.EventHandler(this.flowLayoutPanel_Resize);
            // 
            // RegionMemberGroupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DispatchPlatform.Properties.Resources.MainBackGround;
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.panel1);
            this.Name = "RegionMemberGroupControl";
            this.Size = new System.Drawing.Size(601, 354);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnGroupCall;
        private IndexControl indexControl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}
