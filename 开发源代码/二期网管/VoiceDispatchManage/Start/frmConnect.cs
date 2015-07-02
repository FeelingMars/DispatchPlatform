using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VoiceDispatchManage.Start
{
    public partial class frmConnect : CommControl.frmBase
    {
        public frmConnect()
        {
            InitializeComponent();

        }
        bool IsShow = false;
        private void btnClose_Click(object sender, EventArgs e)
        {
            //tConnect.Enabled = false;
            IsExit = true;
            this.Close();
            Environment.Exit(0);
        }
        Timer tConnect = new Timer();
        bool IsExit = false;
        private void frmConnect_Load(object sender, EventArgs e)
        {
            IsShow = true;
            System.Threading.Thread th = new System.Threading.Thread(doMain);
            th.Start();
            //tConnect.Tick += new EventHandler(tConnect_Tick);
            //tConnect.Interval = 5000;
            //tConnect.Enabled = true;
            //tConnect_Tick(tConnect, null);
        }
        private void frmConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsExit==false) e.Cancel = true;
            //if (DialogResult.Yes != CommControl.MessageBoxEx.MessageBoxEx.Show("数据库未连接，是否退出系统?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            //{
                // e.Cancel = true;
                //return;
            //}
        }
        private void doMain()
        {
            try
            {
                while (true)
                {
                    if (!IsExit)
                    {
                        if (Program.OpenDataBase())
                        {
                            IsExit = true;
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new EventHandler(delegate(object obj, EventArgs e)
                                {
                                    this.Close();
                                }));
                            }
                            else
                            {
                                this.Close();
                            }
                            break;
                        }
                    }
                    System.Threading.Thread.Sleep(5000);
                }
            }
            catch
            {

            }
        }
        
        void tConnect_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Program.OpenDataBase())
                {
                    tConnect.Enabled = false;
                }
            }
            catch
            {
            }

           
        }

        

        
    }
}
