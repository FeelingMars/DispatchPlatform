using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DispatchPlatform;

namespace DispatchPlatform
{
    public partial class FormCallKeyborad : Form
    {
        // private int _dispatchNumber = 0;

        public event MsgDelegate OnMsg;

        public delegate void MsgDelegate(string msg);


        private DispatchPlatform.TalkControl _tc = null;
        public FormCallKeyborad(DispatchPlatform.TalkControl tc)
        {
            _tc = tc;
            InitializeComponent();
            lblNumber.Text = "";
        }

        private void btn3_Click_1(object sender, EventArgs e)
        {
            if (lblNumber.Text.Length > 11)
            {
                return;
            }
            ButtonX b = (ButtonX)sender;
            lblNumber.Text = lblNumber.Text + (string)b.Tag;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lblNumber.Text.Length > 0)
            {
                lblNumber.Text = lblNumber.Text.Substring(0, lblNumber.Text.Length - 1);
            }
        }

        /// <summary>
        /// 验证号码
        /// </summary>
        /// <returns></returns>
        private bool CheckNumber()
        {
            int number = 0;

            
            try
            {
                number = int.Parse(lblNumber.Text);
            }
            catch (Exception)
            {
                if (OnMsg != null)
                {
                    OnMsg("呼叫失败");
                }
                return false;
            }

            DispatchPlatform.Command.BaseCommand bc = new DispatchPlatform.Command.MakeCallCommand();

            if (number == Pub.manageModel.LeftDispatchNumber || number == Pub.manageModel.RightDispatchNumber )
            {
                OnMsg("不可以拨打调度号码");
                return false;
            }

            //bc.MemberControl = Pub._memberManage.GetSingleControl(number);
            //if (bc.MemberControl == null)
            //{
            //    if (OnMsg != null)
            //    {
            //        OnMsg("系统中没有此号码");
            //    }
            //    return false;
            //}

            return true;
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            if (CheckNumber() == false)
            {
                return;
            }

            DispatchPlatform.Command.BaseCommand bc = new DispatchPlatform.Command.MakeCallCommand();

            SingleUserControl sc= Pub._memberManage.GetSingleControl(int.Parse(lblNumber.Text));
            if (sc != null)
            {
                if (sc.UserLineStatus!= TalkControl.EnumUserLineStatus.Idle)
                {
                    OnMsg("呼叫失败");
                    return;
                }
                bc.MemberControl = sc;
            }
            else
            {
                bc.MemberControl = new SingleUserControl() {
                    Number = int.Parse(lblNumber.Text)
                };
            }
            

            bc.talkControl = _tc;
            bc.OnMsg += new DispatchPlatform.Command.BaseCommand.MsgDelegate(bc_OnMsg);
            bc.Begin();
        }

        void bc_OnMsg(string msg)
        {
            this.OnMsg(msg);
        }

        private void btnTran_Click(object sender, EventArgs e)
        {
            if (CheckNumber() == false)
            {
                return;
            }
            DispatchPlatform.Command.BaseCommand bc = new DispatchPlatform.Command.TransferCommand();
            bc.MemberControl = Pub._memberManage.GetSingleControl(int.Parse(lblNumber.Text));
            bc.talkControl = _tc;
            bc.Begin();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHandup_Click(object sender, EventArgs e)
        {
            if (CheckNumber() == false)
            {
                return;
            }
            DispatchPlatform.Command.BaseCommand bc = new DispatchPlatform.Command.HandupCommand();
            bc.MemberControl = Pub._memberManage.GetSingleControl(int.Parse(lblNumber.Text));
            bc.talkControl = _tc;
            bc.Begin();
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CommControl.Win32.ReleaseCapture();
                CommControl.Win32.SendMessage(Handle, 274, 61440 + 9, 0);
            }
        }
    }
}
