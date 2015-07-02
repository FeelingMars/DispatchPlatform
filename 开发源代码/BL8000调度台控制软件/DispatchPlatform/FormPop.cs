using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispatchPlatform
{
    /// <summary>
    /// 视频通话窗口
    /// </summary>
    public partial class FormPop : Form
    {
        public event EventHandler OnMin;

        private Panel _p = new Panel();
        private string _msg = "";

        public FormPop()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormPop_FormClosing);
        }

        void FormPop_FormClosing(object sender, FormClosingEventArgs e)
        {
            HideVideo();
            e.Cancel = true;
        }



        public void ShowVideo(Panel p,string msg)
        {
            _p = p;
            _msg = msg;
            this.Text = msg;
            p.Dock = DockStyle.Fill;
            this.Controls.Add(_p);
            timer1.Enabled = true;
            this.TopMost = true;
        }


        private void HideVideo()
        {
            if (OnMin != null)
            {
                OnMin(_p, null);
            }
            this.Visible = false;
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = _msg + " " + DateTime.Now.ToString();
        }
    }
}
