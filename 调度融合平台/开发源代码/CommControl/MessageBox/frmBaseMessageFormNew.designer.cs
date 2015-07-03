namespace Bestway.Windows.Controls
{
    partial class frmBaseMessageFormNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMessageFormNew));
            this.panelBackGround = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMessage = new System.Windows.Forms.Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.vPicBox = new System.Windows.Forms.PictureBox();
            this.panelButton = new System.Windows.Forms.Panel();
            this.panelButtonShow = new System.Windows.Forms.FlowLayoutPanel();
            this.vbutton1 = new Bestway.Windows.Controls.Button();
            this.vbutton2 = new Bestway.Windows.Controls.Button();
            this.vbutton3 = new Bestway.Windows.Controls.Button();
            this.panelBackGround.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelMessage.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vPicBox)).BeginInit();
            this.panelButton.SuspendLayout();
            this.panelButtonShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBackGround
            // 
            this.panelBackGround.AutoSize = true;
            this.panelBackGround.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(231)))), ((int)(((byte)(243)))));
            this.panelBackGround.Controls.Add(this.panelMain);
            this.panelBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackGround.Location = new System.Drawing.Point(3, 30);
            this.panelBackGround.Name = "panelBackGround";
            this.panelBackGround.Padding = new System.Windows.Forms.Padding(10);
            this.panelBackGround.Size = new System.Drawing.Size(294, 139);
            this.panelBackGround.TabIndex = 20;
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.Controls.Add(this.panelMessage);
            this.panelMain.Controls.Add(this.panelLeft);
            this.panelMain.Controls.Add(this.panelButton);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(10, 10);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(274, 119);
            this.panelMain.TabIndex = 0;
            // 
            // panelMessage
            // 
            this.panelMessage.AutoSize = true;
            this.panelMessage.BackColor = System.Drawing.Color.Transparent;
            this.panelMessage.Controls.Add(this.labelMessage);
            this.panelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessage.Location = new System.Drawing.Point(38, 0);
            this.panelMessage.Name = "panelMessage";
            this.panelMessage.Padding = new System.Windows.Forms.Padding(5);
            this.panelMessage.Size = new System.Drawing.Size(236, 81);
            this.panelMessage.TabIndex = 19;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.BackColor = System.Drawing.Color.Transparent;
            this.labelMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(93)))));
            this.labelMessage.Location = new System.Drawing.Point(8, 5);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(41, 12);
            this.labelMessage.TabIndex = 18;
            this.labelMessage.Text = "label1";
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.vPicBox);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(38, 81);
            this.panelLeft.TabIndex = 22;
            // 
            // vPicBox
            // 
            this.vPicBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.vPicBox.Location = new System.Drawing.Point(0, 0);
            this.vPicBox.Name = "vPicBox";
            this.vPicBox.Size = new System.Drawing.Size(38, 32);
            this.vPicBox.TabIndex = 23;
            this.vPicBox.TabStop = false;
            // 
            // panelButton
            // 
            this.panelButton.AutoSize = true;
            this.panelButton.Controls.Add(this.panelButtonShow);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 81);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(274, 38);
            this.panelButton.TabIndex = 21;
            // 
            // panelButtonShow
            // 
            this.panelButtonShow.AutoSize = true;
            this.panelButtonShow.Controls.Add(this.vbutton1);
            this.panelButtonShow.Controls.Add(this.vbutton2);
            this.panelButtonShow.Controls.Add(this.vbutton3);
            this.panelButtonShow.Location = new System.Drawing.Point(10, 6);
            this.panelButtonShow.Name = "panelButtonShow";
            this.panelButtonShow.Size = new System.Drawing.Size(257, 29);
            this.panelButtonShow.TabIndex = 19;
            // 
            // vbutton1
            // 
            this.vbutton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(231)))), ((int)(((byte)(243)))));
            this.vbutton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vbutton1.BackgroundImage")));
            this.vbutton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vbutton1.ButtonStyle = Bestway.Windows.Controls.ButtonStyle.Custom;
            this.vbutton1.FlatAppearance.BorderSize = 0;
            this.vbutton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbutton1.Location = new System.Drawing.Point(6, 3);
            this.vbutton1.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.vbutton1.Name = "vbutton1";
            this.vbutton1.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("vbutton1.Picture_MouseDown")));
            this.vbutton1.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("vbutton1.Picture_MouseMove")));
            this.vbutton1.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("vbutton1.Picture_Normal")));
            this.vbutton1.Size = new System.Drawing.Size(75, 23);
            this.vbutton1.TabIndex = 15;
            this.vbutton1.Text = "button1";
            this.vbutton1.UseVisualStyleBackColor = false;
            this.vbutton1.Visible = false;
            this.vbutton1.Click += new System.EventHandler(this.vbutton1_Click);
            // 
            // vbutton2
            // 
            this.vbutton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(231)))), ((int)(((byte)(243)))));
            this.vbutton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vbutton2.BackgroundImage")));
            this.vbutton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vbutton2.ButtonStyle = Bestway.Windows.Controls.ButtonStyle.Custom;
            this.vbutton2.FlatAppearance.BorderSize = 0;
            this.vbutton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbutton2.Location = new System.Drawing.Point(90, 3);
            this.vbutton2.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.vbutton2.Name = "vbutton2";
            this.vbutton2.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("vbutton2.Picture_MouseDown")));
            this.vbutton2.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("vbutton2.Picture_MouseMove")));
            this.vbutton2.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("vbutton2.Picture_Normal")));
            this.vbutton2.Size = new System.Drawing.Size(75, 23);
            this.vbutton2.TabIndex = 16;
            this.vbutton2.Text = "button2";
            this.vbutton2.UseVisualStyleBackColor = false;
            this.vbutton2.Visible = false;
            this.vbutton2.Click += new System.EventHandler(this.vbutton2_Click);
            // 
            // vbutton3
            // 
            this.vbutton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(231)))), ((int)(((byte)(243)))));
            this.vbutton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vbutton3.BackgroundImage")));
            this.vbutton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vbutton3.ButtonStyle = Bestway.Windows.Controls.ButtonStyle.Custom;
            this.vbutton3.FlatAppearance.BorderSize = 0;
            this.vbutton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vbutton3.Location = new System.Drawing.Point(174, 3);
            this.vbutton3.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.vbutton3.Name = "vbutton3";
            this.vbutton3.Picture_MouseDown = ((System.Drawing.Image)(resources.GetObject("vbutton3.Picture_MouseDown")));
            this.vbutton3.Picture_MouseMove = ((System.Drawing.Image)(resources.GetObject("vbutton3.Picture_MouseMove")));
            this.vbutton3.Picture_Normal = ((System.Drawing.Image)(resources.GetObject("vbutton3.Picture_Normal")));
            this.vbutton3.Size = new System.Drawing.Size(75, 23);
            this.vbutton3.TabIndex = 17;
            this.vbutton3.Text = "button3";
            this.vbutton3.UseVisualStyleBackColor = false;
            this.vbutton3.Visible = false;
            this.vbutton3.Click += new System.EventHandler(this.vbutton3_Click);
            // 
            // frmBaseMessageFormNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(300, 172);
            this.Controls.Add(this.panelBackGround);
            this.Enabled_CloseButton = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.FormStyle = Bestway.Windows.Forms.emFormStyle.Custom;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(213, 128);
            this.Name = "frmBaseMessageFormNew";
            this.Text = "Form2";
            this.Controls.SetChildIndex(this.panelBackGround, 0);
            this.panelBackGround.ResumeLayout(false);
            this.panelBackGround.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelMessage.ResumeLayout(false);
            this.panelMessage.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vPicBox)).EndInit();
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            this.panelButtonShow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBackGround;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Panel panelMessage;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.PictureBox vPicBox;
        private Bestway.Windows.Controls.Button vbutton2;
        private Bestway.Windows.Controls.Button vbutton3;
        private Bestway.Windows.Controls.Button vbutton1;
        private System.Windows.Forms.FlowLayoutPanel panelButtonShow;
        
    }
}