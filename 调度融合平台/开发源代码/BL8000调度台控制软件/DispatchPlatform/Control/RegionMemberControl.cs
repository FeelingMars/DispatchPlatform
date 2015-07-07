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

        #region 变量
        /// <summary>自己的电话号码</summary>
        private string m_Number;//重大改变

        /// <summary>自己的姓名</summary>
        private volatile string m_MemberName;

        /// <summary>状态 </summary>
        private volatile DispatchPlatform.TalkControl.EnumUserLineStatus _userLineStatus = TalkControl.EnumUserLineStatus.None;

        /// <summary> 对方号码 </summary>
        private volatile string _peerNumber;

        /// <summary>是否选中</summary>
        private volatile bool _checked = false;

        /// <summary> 显示对方的名称(前面加注解的) </summary>
        private volatile string _showPeerName = "";

        /// <summary>自己的号码名称，前面可以加主被叫的</summary>
        private volatile string _showSelfNumberName = "";

        /// <summary>状态名称</summary>
        private volatile string _numberState = "";

        /// <summary>状态显示字的背景色</summary>
        private volatile int _stateFontColor = Color.Gray.ToArgb();

        /// <summary>临时背景图片,点击鼠标效果用到</summary>
        private volatile Image _tmpBackImage = DispatchPlatform.Properties.Resources.MemberBackgound;

        /// <summary>通话计时的计数器</summary>
        private Stopwatch m_CallingCost = new Stopwatch();

        /// <summary>姓名与自己号码的颜色</summary>
        private Color _nameColor = Color.FromArgb(MemberAppearance.NormalNameOnlineColor);

        #endregion

        #region 属性

        /// <summary>用户姓名</summary>
        public string MemberName
        {
            get { return m_MemberName; }
            set
            {
                m_MemberName = value;
                if (lblSelfName.InvokeRequired)
                {
                    lblSelfName.Invoke(new EventHandler(delegate(object o, EventArgs ee)
                    {
                        lblSelfName.Text = m_MemberName;
                    }));
                }
                else
                {
                    lblSelfName.Text = m_MemberName;
                }
            }
        }

        /// <summary>用户状态</summary>
        public DispatchPlatform.TalkControl.EnumUserLineStatus UserLineStatus
        {
            get { return _userLineStatus; }
            set
            {
                _userLineStatus = value;

                switch (_userLineStatus)
                {
                    #region None
                    case TalkControl.EnumUserLineStatus.None:
                        _numberState = "离线";
                        _stateFontColor = MemberAppearance.OffLineFontColor;
                        this.NameColor = Color.FromArgb(MemberAppearance.OffLineFontColor);
                        StopTimer();
                        break;
                    #endregion

                    #region Idel
                    case TalkControl.EnumUserLineStatus.Idle:
                        this.IsCalling = false;
                        _numberState = "空闲";
                        _stateFontColor = MemberAppearance.IdleFontColor;
                        this.NameColor = Color.FromArgb(MemberAppearance.NormalNameOnlineColor);
                        StopTimer();
                        break;
                    #endregion

                    #region Busy
                    case TalkControl.EnumUserLineStatus.Busy:
                        _numberState = "通话中";
                        _stateFontColor = MemberAppearance.BusyFontColor;
                        this.NameColor = Color.FromArgb(MemberAppearance.NormalNameOnlineColor);


                        StartTimer();
                        break;
                    #endregion

                    #region Ring
                    case TalkControl.EnumUserLineStatus.Ring:
                        _showPeerName = "";
                        _numberState = "振铃中";
                        _stateFontColor = MemberAppearance.RingFontColor;

                        break;
                    #endregion

                    #region Paging

                    case TalkControl.EnumUserLineStatus.Paging:
                        _showPeerName = "";
                        _numberState = "寻呼中";
                        _stateFontColor = MemberAppearance.PagingFontColor;

                        break;
                    #endregion

                    #region Outcalling


                    case TalkControl.EnumUserLineStatus.Outcalling:
                        _showPeerName = "";
                        this.IsCalling = true;
                        _numberState = "连接中";
                        _stateFontColor = MemberAppearance.OutCallingFontColor;
                        break;
                    #endregion

                    #region Holding
                    case TalkControl.EnumUserLineStatus.Holding:
                        _numberState = "保持中";
                        _stateFontColor = MemberAppearance.HoldingFontColor;

                        break;
                    #endregion

                    #region Offline
                    case TalkControl.EnumUserLineStatus.Offline:
                        _numberState = "离线";
                        _stateFontColor = MemberAppearance.OffLineFontColor;
                        this.NameColor = Color.FromArgb(MemberAppearance.OffLineFontColor);
                        StopTimer();
                        break;
                    #endregion

                    #region HookOn
                    case TalkControl.EnumUserLineStatus.HookOn:
                        if (lblState.Text != "通话中")
                        {
                            _numberState = "摘机";
                        }
                        else
                        {
                            _numberState = "通话中";
                        }
                        _stateFontColor = MemberAppearance.HookonFontColor;

                        StopTimer();
                        break;
                    #endregion
                    default:
                        break;
                }

                this.picTop.Image = Appearance.GetShowImageByState(_userLineStatus);

                lblState.Visible = true;
                lblState.Text = _numberState;
                lblState.ForeColor = Color.FromArgb(_stateFontColor);

                //不为忙和不为录音时显示原号码
                if (value != TalkControl.EnumUserLineStatus.Busy && value != TalkControl.EnumUserLineStatus.Record)
                {
                    lblSelfNumber.Text = this.Number.ToString();
                }
            }
        }

        /// <summary>True为主叫，False为被叫</summary>
        public bool IsCalling { get; set; }

        /// <summary>电话类型</summary>
        public CommControl.PublicEnums.EnumRegionMemberType MemberType
        {
            get
            {
                return Tag == null ? CommControl.PublicEnums.EnumRegionMemberType.WiFiPhone : Tag.MemberType;
            }
            set
            {
                lblPeerNumberName.Visible = false;
                if (Tag != null)
                {
                    Tag.MemberType = value;
                }
                if (Appearance != null)
                {
                    picTop.Image = Appearance.GetShowImageByState(TalkControl.EnumUserLineStatus.Offline);
                }
            }
        }

        /// <summary>控件的可用性</summary>
        public bool ControlEnable
        {
            get
            {
                return this.Enabled;
            }
            set
            {
                picTop.Visible = value;
                this.Enabled = value;
            }
        }

        /// <summary>对方号码</summary>
        public string PeerNumber
        {
            get { return _peerNumber; }
            set
            {
                // lblPeerNumber.SendToBack();
                _peerNumber = value;
                //   lblPeerNumber.Font = _peerNumberNameFontNoraml;
                if (_peerNumber == "0")//说明没有号码
                {

                }
                else
                {
                    #region 有号码时计算是外线还是会议

                    try
                    {
                        long n = long.Parse(value);
                        SingleUserControl sc = Pub._memberManage.GetSingleControl(long.Parse(value));
                        if (sc != null)
                        {
                            if (IsCalling)
                            {
                                _showPeerName = "被叫:" + value.ToString();
                                _showSelfNumberName = "主叫:" + this.m_Number;

                                if (n == Pub.manageModel.LeftDispatchNumber.Value)
                                {
                                    _showPeerName = "被叫:" + Pub.manageModel.LeftDispatchName;
                                }

                                if (n == Pub.manageModel.RightDispatchNumber.Value)
                                {
                                    _showPeerName = "被叫:" + Pub.manageModel.RightDispatchName;
                                }
                            }
                            else
                            {
                                _showPeerName = "主叫:" + value.ToString();
                                _showSelfNumberName = "被叫:" + this.m_Number;

                                if (n == Pub.manageModel.LeftDispatchNumber.Value)
                                {
                                    _showPeerName = "主叫:" + Pub.manageModel.LeftDispatchName;
                                }

                                if (n == Pub.manageModel.RightDispatchNumber.Value)
                                {
                                    _showPeerName = "主叫:" + Pub.manageModel.RightDispatchName;
                                }
                            }
                            //lblPeerNumber.SendToBack();
                        }
                        else//系统中没有算外线
                        {
                            _showPeerName = "外线:" + value.ToString();
                            if (IsCalling)
                            {
                                _showSelfNumberName = "主叫:" + this.m_Number;
                            }
                            else
                            {
                                _showSelfNumberName = "被叫:" + this.m_Number;
                            }
                            if (value.Length > Pub._configModel.OutsideNumberMaxLength)
                            {
                                lblPeerNumber.BringToFront();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        _showPeerName = "会议中";
                        _showSelfNumberName = this.m_Number.ToString();
                        _peerNumber = "会议中";
                    }

                    lblPeerNumber.Text = _showPeerName;
                    lblSelfNumber.Text = _showSelfNumberName;
                    #endregion
                }
            }
        }

        /// <summary>当前状态</summary>
        public string NumberState
        {
            get { return _numberState; }
            set
            {
                _numberState = value;
                if (lblState.InvokeRequired)
                {
                    lblState.Invoke(new EventHandler(delegate(object o, EventArgs ee)
                    {
                        lblState.Text = _numberState;
                        lblState.ForeColor = Color.FromArgb(MemberAppearance.OutCallingFontColor);
                    }));
                }
                else
                {
                    lblState.Text = _numberState;
                    lblState.ForeColor = Color.FromArgb(MemberAppearance.OutCallingFontColor);
                }
            }
        }

        /// <summary>用户号码</summary>
        public string Number
        {
            get { return m_Number; }
            set
            {
                m_Number = value;
                lblSelfNumber.Text = value;
            }
        }

        /// <summary>姓名与自己号码的颜色</summary>
        public Color NameColor
        {
            get { return _nameColor; }
            set
            {
                _nameColor = value;
                lblSelfName.ForeColor = _nameColor;
                lblSelfNumber.ForeColor = _nameColor;
            }
        }

        #endregion

        public RegionMemberControl(RegionMemberInfo tag)
        {
            InitializeComponent();
            lblPeerNumber.Text = "";
            this.DoubleBuffered = true;
            Tag = tag;

            this.Load += new EventHandler(SingleUserControl_Load);
            this.Click += new EventHandler(SingleUserControl_Click);

        }

        private void InitInnerControl()
        {
            lblSelfName.Text = Tag.Name;
            lblSelfNumber.Text = Tag.Number;
            lblPeerNumberName.Visible = false;
            if (Appearance != null)
            {
                picTop.Image = Appearance.GetShowImageByState(TalkControl.EnumUserLineStatus.Offline);
            }
        }

        #region 事件处理
        void SingleUserControl_Click(object sender, EventArgs e)
        {
            DoClick();
        }

        void All_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }

        private void DoClick()
        {
            if (CanSelect)
            {
                if (_checked == false)
                {
                    if (this._userLineStatus == TalkControl.EnumUserLineStatus.Idle)
                    {
                        _checked = true;
                    }
                }
                else
                {
                    if (this._userLineStatus == TalkControl.EnumUserLineStatus.Idle)
                    {
                        _checked = false;
                    }
                }
            }
        }

        private void SingleUserControl_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); //双缓冲
            lblTime.Text = "";
            _tmpBackImage = this.BackgroundImage; 
            InitInnerControl();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this._userLineStatus != TalkControl.EnumUserLineStatus.Offline && this._userLineStatus != TalkControl.EnumUserLineStatus.None)
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
            lblTime.Text = m_CallingCost.Elapsed.ToString("HH:mm:ss");
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

        /// <summary>根据过滤类型得到是否可以执行相应的操作</summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool GetCanDoByFilterType(EnumFilterType type)
        {
            switch (type)
            {
                case EnumFilterType.None:
                    return true;
                    break;
                case EnumFilterType.CanMakeCall:
                    if (this._userLineStatus == TalkControl.EnumUserLineStatus.Idle) return true;
                    break;
                case EnumFilterType.CanHandup:
                    if (this.UserLineStatus == TalkControl.EnumUserLineStatus.Busy
                        || this.UserLineStatus == TalkControl.EnumUserLineStatus.Holding
                        || this.UserLineStatus == TalkControl.EnumUserLineStatus.Listen
                        || this.UserLineStatus == TalkControl.EnumUserLineStatus.Record
                        || this.UserLineStatus == TalkControl.EnumUserLineStatus.Insert
                        || this.UserLineStatus == TalkControl.EnumUserLineStatus.Ring
                        || this.UserLineStatus == TalkControl.EnumUserLineStatus.Outcalling
                          ) return true;
                    break;
                case EnumFilterType.CanHolding:
                    if (this.UserLineStatus == TalkControl.EnumUserLineStatus.Busy
                       || this.UserLineStatus == TalkControl.EnumUserLineStatus.Holding
                           ) return true;
                    break;
                case EnumFilterType.CanTranfer:
                    if (this.UserLineStatus == TalkControl.EnumUserLineStatus.Idle) return true;
                    break;
                case EnumFilterType.CanInsteadAnswer:
                    if (this.UserLineStatus == TalkControl.EnumUserLineStatus.Ring) return true;
                    break;
                case EnumFilterType.CanInsert:
                    if (this.UserLineStatus == TalkControl.EnumUserLineStatus.Busy) return true;
                    break;
                case EnumFilterType.CanSnatch:
                    if (this.UserLineStatus == TalkControl.EnumUserLineStatus.Busy) return true;
                    break;
                case EnumFilterType.CanListen:
                    if (this.UserLineStatus == TalkControl.EnumUserLineStatus.Busy
                        || this.UserLineStatus == TalkControl.EnumUserLineStatus.Listen
                        ) return true;
                    break;
                case EnumFilterType.CanRecord:
                    if (this.UserLineStatus == TalkControl.EnumUserLineStatus.Busy
                        || this.UserLineStatus == TalkControl.EnumUserLineStatus.Record
                        || this.UserLineStatus == TalkControl.EnumUserLineStatus.Listen
                        ) return true;
                    break;
                case EnumFilterType.CanAddMeetingMember:
                    if (this.UserLineStatus == TalkControl.EnumUserLineStatus.Idle) return true;
                    break;
                default:
                    break;
            }
            return false;
        }

        #endregion
    }
}
