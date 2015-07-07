namespace DispatchPlatform.Region
{
    partial class RegionMemberControl
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
            this.components = new System.ComponentModel.Container();
            this.lblSelfNumber = new System.Windows.Forms.Label();
            this.lblSelfName = new System.Windows.Forms.Label();
            this.picTop = new System.Windows.Forms.PictureBox();
            this.lblPeerNumber = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblState = new System.Windows.Forms.Label();
            this.lblPeerNumberName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelfNumber
            // 
            this.lblSelfNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelfNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblSelfNumber.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelfNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(65)))), ((int)(((byte)(100)))));
            this.lblSelfNumber.Location = new System.Drawing.Point(85, 24);
            this.lblSelfNumber.Name = "lblSelfNumber";
            this.lblSelfNumber.Size = new System.Drawing.Size(69, 13);
            this.lblSelfNumber.TabIndex = 0;
            this.lblSelfNumber.Text = "本机号码";
            this.lblSelfNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSelfNumber.Click += new System.EventHandler(this.All_Click);
            this.lblSelfNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.lblSelfNumber.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lblSelfName
            // 
            this.lblSelfName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelfName.BackColor = System.Drawing.Color.Transparent;
            this.lblSelfName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelfName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(65)))), ((int)(((byte)(100)))));
            this.lblSelfName.Location = new System.Drawing.Point(85, 9);
            this.lblSelfName.Name = "lblSelfName";
            this.lblSelfName.Size = new System.Drawing.Size(70, 13);
            this.lblSelfName.TabIndex = 1;
            this.lblSelfName.Text = "本机名称";
            this.lblSelfName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSelfName.Click += new System.EventHandler(this.All_Click);
            this.lblSelfName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.lblSelfName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // picTop
            // 
            this.picTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.picTop.BackColor = System.Drawing.Color.Transparent;
            this.picTop.Image = global::DispatchPlatform.Properties.Resources.n_OffLine;
            this.picTop.Location = new System.Drawing.Point(9, 21);
            this.picTop.Name = "picTop";
            this.picTop.Size = new System.Drawing.Size(48, 50);
            this.picTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTop.TabIndex = 4;
            this.picTop.TabStop = false;
            this.picTop.Click += new System.EventHandler(this.All_Click);
            this.picTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.picTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lblPeerNumber
            // 
            this.lblPeerNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeerNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblPeerNumber.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPeerNumber.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPeerNumber.Location = new System.Drawing.Point(87, 40);
            this.lblPeerNumber.Name = "lblPeerNumber";
            this.lblPeerNumber.Size = new System.Drawing.Size(67, 13);
            this.lblPeerNumber.TabIndex = 3;
            this.lblPeerNumber.Text = "对方号码";
            this.lblPeerNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPeerNumber.Click += new System.EventHandler(this.All_Click);
            this.lblPeerNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.lblPeerNumber.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTime.Location = new System.Drawing.Point(89, 74);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(65, 12);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "00:00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTime.Click += new System.EventHandler(this.All_Click);
            this.lblTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.lblTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblState.BackColor = System.Drawing.Color.Transparent;
            this.lblState.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.ForeColor = System.Drawing.Color.Gray;
            this.lblState.Location = new System.Drawing.Point(12, 74);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(45, 12);
            this.lblState.TabIndex = 7;
            this.lblState.Text = "离线";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblState.Click += new System.EventHandler(this.All_Click);
            this.lblState.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.lblState.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lblPeerNumberName
            // 
            this.lblPeerNumberName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeerNumberName.BackColor = System.Drawing.Color.Transparent;
            this.lblPeerNumberName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPeerNumberName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(65)))), ((int)(((byte)(100)))));
            this.lblPeerNumberName.Location = new System.Drawing.Point(63, 58);
            this.lblPeerNumberName.Name = "lblPeerNumberName";
            this.lblPeerNumberName.Size = new System.Drawing.Size(93, 13);
            this.lblPeerNumberName.TabIndex = 8;
            this.lblPeerNumberName.Text = "对方号码Name";
            this.lblPeerNumberName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RegionMemberControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DispatchPlatform.Properties.Resources.MemberBackgound;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblPeerNumberName);
            this.Controls.Add(this.lblSelfNumber);
            this.Controls.Add(this.lblPeerNumber);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.picTop);
            this.Controls.Add(this.lblSelfName);
            this.ForeColor = System.Drawing.Color.Navy;
            this.Name = "RegionMemberControl";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(160, 92);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.picTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picTop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblSelfName;
        private System.Windows.Forms.Label lblSelfNumber;
        private System.Windows.Forms.Label lblPeerNumber;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblPeerNumberName;
    }
}
