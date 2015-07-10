using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl;
using DispatchPlatform.Data;
using System.Diagnostics;

namespace DispatchPlatform.Region
{
    /// <summary>单个普通用户</summary>
    [DefaultEvent("Click")]
    internal partial class RegionMemberControl : UserControl
    {
        public new RegionMemberInfo Tag { get; set; }

        public MemberAppearance Appearance { get; set; }

        private delegate void UpdatePropertyDelegate(int index);

        #region 变量

        /// <summary>是否选中</summary>
        private volatile bool _checked = false;

        /// <summary>状态显示字的背景色</summary>
        private volatile int _stateFontColor = Color.Gray.ToArgb();

        /// <summary>临时背景图片,点击鼠标效果用到</summary>
        private volatile Image _tmpBackImage = DispatchPlatform.Properties.Resources.MemberBackgound;

        /// <summary>通话计时的计数器</summary>
        private Stopwatch m_CallingCost = new Stopwatch();

        #endregion

        #region 属性

        /// <summary>True为主叫，False为被叫</summary>
        private bool IsCalling
        {
            get
            {
                if (Tag is RegionCallInfo)
                {
                    return (Tag as RegionCallInfo).IsCalling;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (Tag is RegionCallInfo)
                {
                    (Tag as RegionCallInfo).IsCalling = value;
                }
            }
        }

        /// <summary>姓名与自己号码的颜色</summary>
        private Color NameColor
        {
            set
            {
                lblSelfName.ForeColor = value;
                lblSelfNumber.ForeColor = value;
            }
        }

        #endregion

        public RegionMemberControl(RegionMemberInfo tag)
        {
            InitializeComponent();
            lblPeerNumber.Text = "";
            this.DoubleBuffered = true;
            Tag = tag;
            if (tag is RegionCallInfo)
            {
                tag.ProrertyChanged += new EventHandler<Event.PropertyChangedEventArgs>(PhoneControl_ProrertyChanged);
            }
            else if (tag is RegionCameraInfo)
            {
                tag.ProrertyChanged += new EventHandler<Event.PropertyChangedEventArgs>(CameraControl_ProrertyChanged);
            }
            this.Load += new EventHandler(SingleUserControl_Load);

            InitInnerControl();
        }

        void CameraControl_ProrertyChanged(object sender, Event.PropertyChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                UpdatePropertyDelegate del = UpdateCameraProperty;
                this.Invoke(del, new object[] { e.Index });
            }
            else
            {
                UpdateCameraProperty(e.Index);
            }
        }
        private void PhoneControl_ProrertyChanged(object sender, Event.PropertyChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                UpdatePropertyDelegate del = UpdatePhoneProperty;
                this.Invoke(del, new object[] { e.Index });
            }
            else
            {
                UpdatePhoneProperty(e.Index);
            }
        }

        private void UpdateCameraProperty(int index)
        {
            UpdateUserLineStatue((Tag as RegionCallInfo).UserLineStatus);
            InnerUpdateControlFont();
        }

        private void UpdatePhoneProperty(int index)
        {
            lblSelfName.Text = Tag.Name;
            if (index == 0)
            {
                UpdatePeerNumberStatue((Tag as RegionCallInfo).DestNumber);
            }
            else if (index == 1)
            {
                UpdateUserLineStatue((Tag as RegionCallInfo).UserLineStatus);
            }
            else if (index == 2)
            {
                lblState.Text = (Tag as RegionCallInfo).NumberStatus;
                lblState.ForeColor = Color.FromArgb(MemberAppearance.OutCallingFontColor);
            }
            InnerUpdateControlFont();
        }

        private void UpdateUserLineStatue(TalkControl.EnumUserLineStatus status)
        {
            string numberState = "";
            switch (status)
            {
                #region None
                case TalkControl.EnumUserLineStatus.None:
                    numberState = "离线";
                    _stateFontColor = MemberAppearance.OffLineFontColor;
                    this.NameColor = Color.FromArgb(MemberAppearance.OffLineFontColor);
                    StopTimer();
                    break;
                #endregion

                #region Idel
                case TalkControl.EnumUserLineStatus.Idle:
                    this.IsCalling = false;
                    numberState = "空闲";
                    _stateFontColor = MemberAppearance.IdleFontColor;
                    this.NameColor = Color.FromArgb(MemberAppearance.NormalNameOnlineColor);
                    StopTimer();
                    break;
                #endregion

                #region Busy
                case TalkControl.EnumUserLineStatus.Busy:
                    numberState = "通话中";
                    _stateFontColor = MemberAppearance.BusyFontColor;
                    this.NameColor = Color.FromArgb(MemberAppearance.NormalNameOnlineColor);


                    StartTimer();
                    break;
                #endregion

                #region Ring
                case TalkControl.EnumUserLineStatus.Ring:
                    numberState = "振铃中";
                    _stateFontColor = MemberAppearance.RingFontColor;

                    break;
                #endregion

                #region Paging

                case TalkControl.EnumUserLineStatus.Paging:
                    numberState = "寻呼中";
                    _stateFontColor = MemberAppearance.PagingFontColor;

                    break;
                #endregion

                #region Outcalling
                case TalkControl.EnumUserLineStatus.Outcalling:
                    this.IsCalling = true;
                    numberState = "连接中";
                    _stateFontColor = MemberAppearance.OutCallingFontColor;
                    break;
                #endregion

                #region Holding
                case TalkControl.EnumUserLineStatus.Holding:
                    numberState = "保持中";
                    _stateFontColor = MemberAppearance.HoldingFontColor;

                    break;
                #endregion

                #region Offline
                case TalkControl.EnumUserLineStatus.Offline:
                    numberState = "离线";
                    _stateFontColor = MemberAppearance.OffLineFontColor;
                    this.NameColor = Color.FromArgb(MemberAppearance.OffLineFontColor);
                    StopTimer();
                    break;
                #endregion

                #region Listen

                case TalkControl.EnumUserLineStatus.Listen:
                    numberState = "监听中";
                    _stateFontColor = MemberAppearance.ListenFontColor;
                    break;
                #endregion

                #region Record

                case TalkControl.EnumUserLineStatus.Record:
                    numberState = "录音中";
                    _stateFontColor = MemberAppearance.RecordFontColor;
                    break;
                #endregion

                #region Insert
                case TalkControl.EnumUserLineStatus.Insert:
                    numberState = "强插中";
                    _stateFontColor = MemberAppearance.InsertFontColor;
                    break;
                #endregion

                #region Isolate
                case TalkControl.EnumUserLineStatus.Isolate:
                    numberState = "隔离中";
                    _stateFontColor = MemberAppearance.IsolateFontColor;

                    break;

                #endregion

                #region Forbid

                case TalkControl.EnumUserLineStatus.Forbid:
                    numberState = "禁言中";
                    _stateFontColor = MemberAppearance.ForbidFontColor;

                    break;
                #endregion

                #region HookOn
                case TalkControl.EnumUserLineStatus.HookOn:
                    if (lblState.Text != "通话中")
                    {
                        numberState = "摘机";
                    }
                    else
                    {
                        numberState = "通话中";
                    }
                    _stateFontColor = MemberAppearance.HookonFontColor;

                    StopTimer();
                    break;
                #endregion
                default:
                    break;
            }

            this.picTop.Image = Appearance.GetShowImageByState((Tag as RegionCallInfo).UserLineStatus);

            lblState.Visible = true;
            (this.Tag as RegionCallInfo).NumberStatus = numberState;
            lblState.ForeColor = Color.FromArgb(_stateFontColor);
            lblSelfNumber.Text = this.Tag.Number;
        }

        private void UpdatePeerNumberStatue(string value)
        {
            string peerDespStr = "";
            string selfDespStr = "";
            if (value == null || value == "0")//说明没有号码
            {
                lblPeerNumber.Text = "";
            }
            else
            {
                if (RegionManage.GetInstance().ExistMember(value))
                {
                    peerDespStr = (IsCalling ? "被叫:" : "主叫:") + value;
                    selfDespStr = (IsCalling ? "主叫:" : "被叫:") + Tag.Number;

                    if (value == Pub.manageModel.LeftDispatchNumber.ToString())
                    {
                        peerDespStr = (IsCalling ? "被叫:" : "主叫:") + Pub.manageModel.LeftDispatchName;
                    }

                    if (value == Pub.manageModel.RightDispatchNumber.ToString())
                    {
                        peerDespStr = (IsCalling ? "被叫:" : "主叫:") + Pub.manageModel.RightDispatchName;
                    }
                }
                else//系统中没有算外线
                {
                    peerDespStr = "外线:" + value.ToString();
                    selfDespStr = (IsCalling ? "主叫:" : "被叫:") + Tag.Number;

                    if (value.Length > Pub._configModel.OutsideNumberMaxLength)
                    {
                        lblPeerNumber.BringToFront();
                    }
                }

                lblPeerNumber.Text = peerDespStr;
                lblSelfNumber.Text = selfDespStr;
            }
        }

        private void InitInnerControl()
        {
            lblSelfName.Text = Tag.Name;
            lblSelfNumber.Text = Tag.Number;
            lblPeerNumberName.Visible = false;
            Appearance = MemberAppearance.Create(Tag.MemberType);
            if (Appearance != null)
            {
                picTop.Image = Appearance.GetShowImageByState(TalkControl.EnumUserLineStatus.Offline);
            }
        }

        private void All_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }

        #region 事件处理

        private void SingleUserControl_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); //双缓冲
            lblTime.Text = "";
            _tmpBackImage = this.BackgroundImage;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Tag is RegionCallInfo && (Tag as RegionCallInfo).UserLineStatus != TalkControl.EnumUserLineStatus.Offline &&
                (Tag as RegionCallInfo).UserLineStatus != TalkControl.EnumUserLineStatus.None)
            {
                this.BackgroundImage = DispatchPlatform.Properties.Resources.MemberSlect;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = _tmpBackImage;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Visible = true;
            DateTime t = Convert.ToDateTime(m_CallingCost.Elapsed.ToString());
            lblTime.Text = t.ToString("HH:mm:ss");
        }
        #endregion

        #region 方法

        /// <summary>开始计时</summary>
        private void StartTimer()
        {
            lblTime.Visible = true;
            timer1.Enabled = true;
            m_CallingCost.Restart();
        }

        /// <summary>结束计时</summary>
        private void StopTimer()
        {
            lblTime.Visible = false;
            lblTime.Text = "";
            timer1.Enabled = false;
            m_CallingCost.Reset();
        }

        /// <summary>
        /// 根据列信息设置字体大小，行间距
        /// </summary>
        /// <param name="col"></param>
        private FontSizeConfig GetFontSizeConfig()
        {
            FontSizeConfig fontSize = new FontSizeConfig();
            Screen screen = Screen.PrimaryScreen;
            int width = screen.Bounds.Width;

            if (width == 1280)
            {
                fontSize.NumberNameFontSize = 10;
            }

            if (width == 1440)
            {
                fontSize.NumberNameFontSize = 12;
                fontSize.NumberNameTop = 8;
                fontSize.NumberNameInteval = 8;
            }

            if (width == 1920)
            {
                Pub.LableFontConfig.NumberNameFontSize = 16;
                Pub.LableFontConfig.NumberNameTop = 7;
                Pub.LableFontConfig.NumberNameInteval = 7;
            }
            return fontSize;
        }

        private void InnerUpdateControlFont()
        {
            if (this.IsHandleCreated && this.Visible)
            {
                FontSizeConfig size = GetFontSizeConfig();
                lblSelfName.AutoSize = true;
                lblSelfName.BringToFront();
                lblSelfName.Font = new System.Drawing.Font("宋体",
                    size.NumberNameFontSize,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point, ((byte)(134)));// new Font("宋体", fontSize, FontStyle.Bold);
                if (lblSelfName.Width > Width)
                {
                    lblSelfName.Left = 0;
                }
                else
                {
                    //居中显示 
                    lblSelfName.Left = (Width - lblSelfName.Width) / 2;
                }

                lblSelfNumber.AutoSize = true;
                lblSelfNumber.Font = new System.Drawing.Font("宋体", size.NumberNameFontSize,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point, ((byte)(134)));// new Font("宋体", fontSize, FontStyle.Bold);
                lblSelfNumber.Top = lblSelfName.Top + lblSelfName.Height + size.NumberNameInteval;
                lblSelfNumber.Left = (Width - lblSelfNumber.Width) / 2;

                lblPeerNumber.AutoSize = true;
                lblPeerNumber.Font = new System.Drawing.Font("宋体", size.NumberNameFontSize,
                    System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));// new Font("宋体", fontSize, FontStyle.Bold);
                lblPeerNumber.Top = lblSelfNumber.Top + lblSelfNumber.Height + size.NumberNameInteval;
                lblPeerNumber.Left = (Width - lblPeerNumber.Width) / 2;
            }
        }

        #endregion

        private void RegionMemberControl_SizeChanged(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.SuspendLayout();
                InnerUpdateControlFont();
                this.ResumeLayout();
            }
        }
    }
}
