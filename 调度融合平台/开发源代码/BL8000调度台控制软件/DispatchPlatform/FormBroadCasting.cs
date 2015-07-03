using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;

namespace DispatchPlatform
{
    public partial class FormBroadCasting : Form
    {
        private int _t = 0;

        public FormBroadCasting()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Load += new EventHandler(FormBroadCasting_Load);
            this.FormClosing += new FormClosingEventHandler(FormBroadCasting_FormClosing);
        }

        void FormBroadCasting_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            _t = 0;
        }

        void FormBroadCasting_Load(object sender, EventArgs e)
        {
            _t = 0;
            timer1.Enabled = true;
        }

   

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        public string GetAllTime(int time)
        {
            TimeSpan ts = new TimeSpan(0, 0, time);
            string h = ts.Hours >= 10 ? ts.Hours.ToString() : "0" + ts.Hours.ToString();
            string m = ts.Minutes >= 10 ? ts.Minutes.ToString() : "0" + ts.Minutes.ToString();
            string s = ts.Seconds >= 10 ? ts.Seconds.ToString() : "0" + ts.Seconds.ToString();

            return h + ":" + m + ":" + s;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _t++;
            lblTime.Text = GetAllTime(_t);
        }
    }
}
