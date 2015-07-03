namespace VoiceDispatchManage
{
    partial class frmWelcome
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
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBackGround.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Size = new System.Drawing.Size(403, 16);
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("宋体", 12F);
            this.lblMsg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMsg.Location = new System.Drawing.Point(94, 169);
            this.lblMsg.Size = new System.Drawing.Size(192, 16);
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(35, 112);
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = global::VoiceDispatchManage.Properties.Resources.page_login_21;
            this.pnlTop.Size = new System.Drawing.Size(471, 231);
            // 
            // pnlBackGround
            // 
            this.pnlBackGround.Size = new System.Drawing.Size(471, 268);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 231);
            this.pnlBottom.Size = new System.Drawing.Size(471, 37);
            // 
            // frmWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 270);
            this.Name = "frmWelcome";
            this.Text = "frmWelcome";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBackGround.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}