using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispatchPlatform.Control
{
    public partial class TimeControl : UserControl
    {
        public TimeControl()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //int hBig = 0;
            //int hSmall = 0;
            //int mBig = 0;
            //int mSmall = 0;

            //hBig = DateTime.Now.Hour / 10;
            //hSmall = DateTime.Now.Hour % 10;
            //mBig = DateTime.Now.Minute / 10;
            //mSmall = DateTime.Now.Minute % 10;

            //buttonX1.Text = hBig.ToString();
            //buttonX2.Text = hSmall.ToString();
            //buttonX3.Text = mBig.ToString();
            //buttonX4.Text = mSmall.ToString();

            //labelX1.Text = DateTime.Now.ToString("HH : mm");//DateTime.Now.Hour.ToString();
            //labelX2.Text = DateTime.Now.Minute.ToString("mm");

            labelX1.Text = DateTime.Now.ToString("HH");//DateTime.Now.Hour.ToString();
            labelX2.Text = DateTime.Now.ToString("mm");

        }
    }
}
