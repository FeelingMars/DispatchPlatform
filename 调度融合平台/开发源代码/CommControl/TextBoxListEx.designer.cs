namespace CommControl
{
    partial class TextBoxListEx
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
            this.txtValue = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.picDropList = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDropList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            // 
            // 
            // 
            this.txtValue.Border.Class = "TextBoxBorder";
            this.txtValue.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtValue.Location = new System.Drawing.Point(0, 0);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(136, 21);
            this.txtValue.TabIndex = 0;
            // 
            // picDropList
            // 
            this.picDropList.BackColor = System.Drawing.Color.Transparent;
            this.picDropList.Dock = System.Windows.Forms.DockStyle.Right;
            this.picDropList.Image = CommControl.Properties.Resources.NormalDown;
            this.picDropList.Location = new System.Drawing.Point(136, 0);
            this.picDropList.Name = "picDropList";
            this.picDropList.Size = new System.Drawing.Size(14, 21);
            this.picDropList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDropList.TabIndex = 1;
            this.picDropList.TabStop = false;
            
            this.picDropList.MouseEnter += new System.EventHandler(this.picDropList_MouseEnter);
            this.picDropList.MouseLeave += new System.EventHandler(this.picDropList_MouseLeave);
            // 
            // TextBoxListEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.picDropList);
            this.Name = "TextBoxListEx";
            this.Size = new System.Drawing.Size(150, 21);
            ((System.ComponentModel.ISupportInitialize)(this.picDropList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDropList;
        public DevComponents.DotNetBar.Controls.TextBoxX txtValue;
    }
}
