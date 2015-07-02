namespace DispatchPlatform.Control
{
    partial class LemcMemberControl
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
            this.lblName = new DevComponents.DotNetBar.LabelX();
            this.lblNumber = new DevComponents.DotNetBar.LabelX();
            this.lblState = new DevComponents.DotNetBar.LabelX();
            this.lblTime = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // lblName
            // 
            // 
            // 
            // 
            this.lblName.BackgroundStyle.Class = "";
            this.lblName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(7)))), ((int)(((byte)(5)))));
            this.lblName.Location = new System.Drawing.Point(40, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(66, 31);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "李先生在";
            this.lblName.WordWrap = true;
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblNumber
            // 
            // 
            // 
            // 
            this.lblNumber.BackgroundStyle.Class = "";
            this.lblNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNumber.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(7)))), ((int)(((byte)(5)))));
            this.lblNumber.Location = new System.Drawing.Point(98, 12);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(42, 26);
            this.lblNumber.TabIndex = 1;
            this.lblNumber.Text = "193521230213";
            this.lblNumber.WordWrap = true;
            this.lblNumber.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblState
            // 
            // 
            // 
            // 
            this.lblState.BackgroundStyle.Class = "";
            this.lblState.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblState.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.ForeColor = System.Drawing.Color.Blue;
            this.lblState.Location = new System.Drawing.Point(141, 16);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(43, 23);
            this.lblState.TabIndex = 2;
            this.lblState.Text = "通话中";
            this.lblState.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblTime
            // 
            // 
            // 
            // 
            this.lblTime.BackgroundStyle.Class = "";
            this.lblTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(193, 15);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(61, 23);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "00:00:00";
            this.lblTime.Click += new System.EventHandler(this.lblName_Click);
            // 
            // LemcMemberControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::DispatchPlatform.Properties.Resources.LemcButtonBackground;
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblName);
            this.Name = "LemcMemberControl";
            this.Size = new System.Drawing.Size(274, 48);
            this.Load += new System.EventHandler(this.LemcMemberControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblName;
        private DevComponents.DotNetBar.LabelX lblNumber;
        private DevComponents.DotNetBar.LabelX lblState;
        private DevComponents.DotNetBar.LabelX lblTime;

    }
}
