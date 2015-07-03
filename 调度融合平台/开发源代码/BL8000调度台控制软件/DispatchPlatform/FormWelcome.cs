using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DispatchPlatform;

namespace DispatchPlatform
{
    public partial class FormWelcome :  Bestway.Windows.Forms.ProgressBarForm
    {
        public FormWelcome()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormWelcome_Load);
        }

        void FormWelcome_Load(object sender, EventArgs e)
        {
            lblTitle.Text = Pub._configModel.Title;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Pub.waitMsg;
        }
    }
}
