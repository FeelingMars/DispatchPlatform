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
    public partial class LemcMemberControl : UserControl
    {
        private long _number = 0;

        public long Number
        {
            get { return _number; }
            set
            {

                _number = value;
                lblNumber.Text = _number.ToString();
            }
        }

        /// <summary>
        /// 接听过
        /// </summary>
        public bool IsCalled { get; set; }

        /// <summary>
        /// 等待计时
        /// </summary>
        public int SleepCount { get; set; }

        public string MemberName
        {
            get { return lblName.Text; }
            set
            {
                //if (value.Length > 10)
                //{
                //    lblName.Font = SingleUserControl._peerNumberNameFontOutCall;
                //}
                //else
                //{
                //    lblName.Font = SingleUserControl._peerNumberNameFontNoraml;
                //}
                lblName.Text = value;
            }
        }

        public string ShowTime
        {
            get
            {
                return lblTime.Text;
            }
            set { lblTime.Text = value; }
        }

        public int LeveID { get; set; }

        private DispatchPlatform.TalkControl.EnumUserLineStatus _memberState = TalkControl.EnumUserLineStatus.None;

        private volatile string _showStateText = "";

        public DispatchPlatform.TalkControl.EnumUserLineStatus MemberState
        {
            get
            {
                return _memberState;
            }
            set
            {
                _memberState = value;
                switch (_memberState)
                {
                    case TalkControl.EnumUserLineStatus.None:
                        _showStateText = "等待中";
                        break;
                    case TalkControl.EnumUserLineStatus.Idle:
                        _showStateText = "空闲中";
                        break;
                    case TalkControl.EnumUserLineStatus.Busy:
                        _showStateText = "通话中";
                        break;
                    case TalkControl.EnumUserLineStatus.Ring:
                        break;
                    case TalkControl.EnumUserLineStatus.Paging:
                        break;
                    case TalkControl.EnumUserLineStatus.Poweroff:
                        break;
                    case TalkControl.EnumUserLineStatus.Outcalling:
                        _showStateText = "连接中";
                        break;
                    case TalkControl.EnumUserLineStatus.Holding:
                        break;
                    case TalkControl.EnumUserLineStatus.Blocked:
                        break;
                    case TalkControl.EnumUserLineStatus.Offline:
                        break;
                    case TalkControl.EnumUserLineStatus.Online:
                        break;
                    case TalkControl.EnumUserLineStatus.Insert:
                        break;
                    case TalkControl.EnumUserLineStatus.Listen:
                        break;
                    case TalkControl.EnumUserLineStatus.Record:
                        break;
                    case TalkControl.EnumUserLineStatus.Isolate:
                        break;
                    case TalkControl.EnumUserLineStatus.Forbid:
                        break;
                    case TalkControl.EnumUserLineStatus.HookOn:
                        break;
                    default:
                        break;
                }

                if (lblState.InvokeRequired)
                {
                    System.Console.WriteLine("开始：MemberState");
                    lblState.Invoke(new EventHandler(delegate(object o, EventArgs ee)
                    {
                        lblState.Visible = true;
                        lblState.Text = _showStateText;
                    }));
                    System.Console.WriteLine("结束：MemberState");
                }
                else
                {
                    lblState.Visible = true;
                    lblState.Text = _showStateText;
                }
            }
        }

        public LemcMemberControl()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
        }

        private void LemcMemberControl_Load(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }
    }
}
