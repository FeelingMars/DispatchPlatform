using DispatchPlatform.Data;
namespace DispatchPlatform.Region
{
    partial class SingleRegionControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleRegionControl));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.regionMemberPanelControlGW = new DispatchPlatform.Region.RegionMemberGroupControl();
            this.regionMemberPanelControlPhone = new DispatchPlatform.Region.RegionMemberGroupControl();
            this.regionMemberPanelControlRadio = new DispatchPlatform.Region.RegionMemberGroupControl();
            this.regionMemberPanelControlCamera = new DispatchPlatform.Region.RegionMemberGroupControl();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.regionMemberPanelControlGW);
            this.flowLayoutPanel1.Controls.Add(this.regionMemberPanelControlPhone);
            this.flowLayoutPanel1.Controls.Add(this.regionMemberPanelControlRadio);
            this.flowLayoutPanel1.Controls.Add(this.regionMemberPanelControlCamera);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(670, 414);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // regionMemberPanelControlGW
            // 
            this.regionMemberPanelControlGW.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("regionMemberPanelControlGW.BackgroundImage")));
            this.regionMemberPanelControlGW.Location = new System.Drawing.Point(3, 3);
            this.regionMemberPanelControlGW.Name = "regionMemberPanelControlGW";
            this.regionMemberPanelControlGW.Size = new System.Drawing.Size(347, 173);
            this.regionMemberPanelControlGW.TabIndex = 0;
            // 
            // regionMemberPanelControlPhone
            // 
            this.regionMemberPanelControlPhone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("regionMemberPanelControlPhone.BackgroundImage")));
            this.regionMemberPanelControlPhone.Location = new System.Drawing.Point(356, 3);
            this.regionMemberPanelControlPhone.Name = "regionMemberPanelControlPhone";
            this.regionMemberPanelControlPhone.Size = new System.Drawing.Size(311, 173);
            this.regionMemberPanelControlPhone.TabIndex = 2;
            this.regionMemberPanelControlPhone.Click += new System.EventHandler(this.regionMemberPanelControlPhone_Click);
            // 
            // regionMemberPanelControlRadio
            // 
            this.regionMemberPanelControlRadio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("regionMemberPanelControlRadio.BackgroundImage")));
            this.regionMemberPanelControlRadio.Location = new System.Drawing.Point(3, 182);
            this.regionMemberPanelControlRadio.Name = "regionMemberPanelControlRadio";
            this.regionMemberPanelControlRadio.Size = new System.Drawing.Size(347, 217);
            this.regionMemberPanelControlRadio.TabIndex = 1;
            // 
            // regionMemberPanelControlCamera
            // 
            this.regionMemberPanelControlCamera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("regionMemberPanelControlCamera.BackgroundImage")));
            this.regionMemberPanelControlCamera.Location = new System.Drawing.Point(356, 182);
            this.regionMemberPanelControlCamera.Name = "regionMemberPanelControlCamera";
            this.regionMemberPanelControlCamera.Size = new System.Drawing.Size(311, 217);
            this.regionMemberPanelControlCamera.TabIndex = 3;
            // 
            // SingleRegionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(48)))));
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "SingleRegionControl";
            this.Size = new System.Drawing.Size(670, 414);
            this.Load += new System.EventHandler(this.SingleRegionControl_Load);
            this.Resize += new System.EventHandler(this.SingleRegionControl_Resize);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private RegionMemberGroupControl regionMemberPanelControlGW;
        private RegionMemberGroupControl regionMemberPanelControlRadio;
        private RegionMemberGroupControl regionMemberPanelControlPhone;
        private RegionMemberGroupControl regionMemberPanelControlCamera;
    }
}
