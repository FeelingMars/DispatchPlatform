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

namespace DispatchPlatform.Control
{
    /// <summary>单个普通用户</summary>
    [DefaultEvent("Click")]
    internal partial class RegionMemberControl<T> : UserControl where T : RegionMemberInfo
    {
        public new T Tag { get; set; }

        #region 常量
        /// <summary>正常显示的用户姓名颜色</summary>
        private static int _normalNameOnlineColor = Color.FromArgb(48, 65, 100).ToArgb();

        /// <summary>正常时对方号码显示的字体</summary>
        //   public static Font _peerNumberNameFontNoraml= new System.Drawing.Font("宋体", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

        /// <summary>外线时(长度长)时对方号码显示的字体</summary>
        //public static Font _peerNumberNameFontOutCall = new System.Drawing.Font("宋体", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

        private static int _offLineFontColor = Color.FromArgb(98, 98, 98).ToArgb();

        private static int _idleFontColor = Color.FromArgb(109, 150, 43).ToArgb();

        private static int _busyFontColor = Color.FromArgb(45, 120, 195).ToArgb();

        private static int _ringFontColor = Color.FromArgb(205, 52, 52).ToArgb();

        private static int _outCallingFontColor = Color.FromArgb(45, 120, 195).ToArgb();

        private static int _holdingFontColor = Color.FromArgb(56, 138, 121).ToArgb();

        private static int _listenFontColor = Color.FromArgb(180, 91, 147).ToArgb();

        private static int _recordFontColor = Color.FromArgb(219, 133, 49).ToArgb();

        private static int _insertFontColor = Color.FromArgb(121, 108, 164).ToArgb();

        private static int _isolateFontColor = Color.FromArgb(188, 91, 58).ToArgb();
        /// <summary>隔离中颜色</summary>
        private static int _forbidFontColor = Color.FromArgb(69, 91, 144).ToArgb();
        /// <summary>寻呼中颜色</summary>
        private static int _pagingFontColor = Color.FromArgb(45, 120, 195).ToArgb();

        private static int _hookonFontColor = Color.FromArgb(0, 90, 99).ToArgb();

        #endregion

        #region 变量
        /// <summary>自己的电话号码</summary>
        //private volatile int _number;
        private long _number;//重大改变

        /// <summary>自己的姓名</summary>
        private volatile string _memberName;

        /// <summary>当前号码的类型</summary>
        private CommControl.PublicEnums.EnumTelType _tellType = PublicEnums.EnumTelType.WiFi手机;

        /// <summary>状态 </summary>
        private volatile DispatchPlatform.TalkControl.EnumUserLineStatus _userLineStatus = TalkControl.EnumUserLineStatus.None;

        /// <summary> 对方号码 </summary>
        private volatile string _peerNumber;

        /// <summary>是否选中</summary>
        private volatile bool _checked = false;

        /// <summary>是否为拨打紧急的号码</summary>
        private volatile bool _isAlarm = false;

        /// <summary> 显示对方的名称(前面加注解的) </summary>
        private volatile string _showPeerName = "";

        /// <summary>自己的号码名称，前面可以加主被叫的</summary>
        private volatile string _showSelfNumberName = "";

        /// <summary>状态名称</summary>
        private volatile string _numberState = "";

        /// <summary>是否显示本机号码的主被叫状态</summary>
        private volatile bool _isShowLblCalling = false;

        /// <summary>状态显示字的背景色</summary>
        private volatile int _stateFontColor = Color.Gray.ToArgb();

        /// <summary>状态临时图片</summary>
        private volatile Image _imgTmp;

        /// <summary>临时背景图片,点击鼠标效果用到</summary>
        private volatile Image _tmpBackImage = DispatchPlatform.Properties.Resources.MemberBackgound;

        /// <summary>通话计时的计数器</summary>
        private volatile int t = 0;

        /// <summary>姓名与自己号码的颜色</summary>
        private Color _nameColor = Color.FromArgb(_normalNameOnlineColor);

        /// <summary>对方号码颜色</summary>
        private Color _peerNumberColor = SystemColors.ControlDarkDark;

        #endregion

        #region 属性

        /// <summary>用户姓名</summary>
        public string MemberName
        {
            get { return _memberName; }
            set
            {
                _memberName = value;
                if (lblSelfName.InvokeRequired)
                {
                    System.Console.WriteLine("开始：lblSelfName.InvokeRequired");
                    lblSelfName.Invoke(new EventHandler(delegate(object o, EventArgs ee)
                    {
                        lblSelfName.Text = _memberName;
                    }));
                    System.Console.WriteLine("结束：lblSelfName.InvokeRequired");
                }
                else
                {
                    lblSelfName.Text = _memberName;
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
                if (_userLineStatus == TalkControl.EnumUserLineStatus.Busy && UserRecordStatus == TalkControl.EnumRecordStatus.ON)
                {
                    _userLineStatus = TalkControl.EnumUserLineStatus.Record;
                }

                switch (_userLineStatus)
                {
                    #region None
                    case TalkControl.EnumUserLineStatus.None:
                        _numberState = "离线";
                        _stateFontColor = _offLineFontColor;
                        this.NameColor = Color.FromArgb(_offLineFontColor);
                        StopTimer();
                        break;
                    #endregion

                    #region Idel
                    case TalkControl.EnumUserLineStatus.Idle:
                        this.IsCalling = false;
                        _numberState = "空闲";
                        _stateFontColor = _idleFontColor;
                        this.NameColor = Color.FromArgb(_normalNameOnlineColor);
                        switch (_tellType)
                        {
                            case PublicEnums.EnumTelType.WiFi手机:
                                _imgTmp = DispatchPlatform.Properties.Resources.n_OnLine;
                                break;
                            case PublicEnums.EnumTelType.固话:
                                _imgTmp = DispatchPlatform.Properties.Resources.telephone_n_OnLine;
                                break;
                            case PublicEnums.EnumTelType.广播:
                                _imgTmp = DispatchPlatform.Properties.Resources.b_n_OnLine;
                                break;
                            default:
                                break;
                        }
                        StopTimer();
                        break;
                    #endregion

                    #region Busy
                    case TalkControl.EnumUserLineStatus.Busy:
                        _numberState = "通话中";
                        _stateFontColor = _busyFontColor;
                        this.NameColor = Color.FromArgb(_normalNameOnlineColor);
                        switch (_tellType)
                        {
                            case PublicEnums.EnumTelType.WiFi手机:
                                _imgTmp = DispatchPlatform.Properties.Resources.n_Busy;
                                break;
                            case PublicEnums.EnumTelType.固话:

                                _imgTmp = DispatchPlatform.Properties.Resources.telephone_n_Busy;
                                break;
                            case PublicEnums.EnumTelType.广播:
                                _imgTmp = DispatchPlatform.Properties.Resources.b_n_Busy;
                                break;
                            default:
                                break;
                        }

                        StartTimer();
                        break;
                    #endregion

                    #region Ring
                    case TalkControl.EnumUserLineStatus.Ring:
                        _showPeerName = "";
                        _numberState = "振铃中";
                        _stateFontColor = _ringFontColor;
                        switch (_tellType)
                        {
                            case PublicEnums.EnumTelType.WiFi手机:
                                _imgTmp = DispatchPlatform.Properties.Resources.n_Ring;
                                break;
                            case PublicEnums.EnumTelType.固话:
                                _imgTmp = DispatchPlatform.Properties.Resources.telephone_m_Ring;
                                break;
                            case PublicEnums.EnumTelType.广播:
                                _imgTmp = DispatchPlatform.Properties.Resources.b_m_Ring;
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region Paging

                    case TalkControl.EnumUserLineStatus.Paging:
                        _showPeerName = "";
                        _numberState = "寻呼中";
                        _stateFontColor = _pagingFontColor;
                        switch (_tellType)
                        {
                            case PublicEnums.EnumTelType.WiFi手机:
                                _imgTmp = DispatchPlatform.Properties.Resources.n_OnLine;
                                break;
                            case PublicEnums.EnumTelType.固话:
                                _imgTmp = DispatchPlatform.Properties.Resources.telephone_n_OnLine;
                                break;
                            case PublicEnums.EnumTelType.调度席话机:
                                _imgTmp = DispatchPlatform.Properties.Resources.D_Online;
                                break;
                            case PublicEnums.EnumTelType.G3G手机:
                                _imgTmp = DispatchPlatform.Properties.Resources.n_OnLine;
                                break;
                            case PublicEnums.EnumTelType.广播:
                                _imgTmp = DispatchPlatform.Properties.Resources.b_n_OnLine;
                                break;
                            default:
                                break;
                        }
                        //_imgTmp = DispatchPlatform.Properties.Resources.n_OnLine;
                        break;
                    #endregion

                    #region Outcalling


                    case TalkControl.EnumUserLineStatus.Outcalling:
                        _showPeerName = "";
                        this.IsCalling = true;
                        _numberState = "连接中";
                        _stateFontColor = _outCallingFontColor;

                        switch (_tellType)
                        {
                            case PublicEnums.EnumTelType.WiFi手机:
                                _imgTmp = DispatchPlatform.Properties.Resources.n_OnLine;
                                break;
                            case PublicEnums.EnumTelType.固话:
                                _imgTmp = DispatchPlatform.Properties.Resources.telephone_n_OnLine;
                                break;
                            case PublicEnums.EnumTelType.调度席话机:
                                _imgTmp = DispatchPlatform.Properties.Resources.D_Online;
                                break;
                            case PublicEnums.EnumTelType.G3G手机:
                                _imgTmp = DispatchPlatform.Properties.Resources.n_OnLine;
                                break;
                            case PublicEnums.EnumTelType.广播:
                                _imgTmp = DispatchPlatform.Properties.Resources.b_n_OnLine;
                                break;
                            default:
                                break;
                        }
                        //_imgTmp = DispatchPlatform.Properties.Resources.n_Busy;
                        break;
                    #endregion

                    #region Holding


                    case TalkControl.EnumUserLineStatus.Holding:
                        // if (_numberState != "等待中")
                        //{
                        _numberState = "保持中";
                        //}

                        _stateFontColor = _holdingFontColor;
                        switch (_tellType)
                        {
                            case PublicEnums.EnumTelType.WiFi手机:
                                _imgTmp = DispatchPlatform.Properties.Resources.n_Keep;
                                break;
                            case PublicEnums.EnumTelType.固话:
                                _imgTmp = DispatchPlatform.Properties.Resources.telephone_n_Keep;
                                break;
                            case PublicEnums.EnumTelType.调度席话机:
                                //有问题
                                _imgTmp = DispatchPlatform.Properties.Resources.D_Keep;
                                break;
                            case PublicEnums.EnumTelType.G3G手机:
                                _imgTmp = DispatchPlatform.Properties.Resources.n_Keep;
                                break;
                            case PublicEnums.EnumTelType.广播:
                                _imgTmp = DispatchPlatform.Properties.Resources.b_n_Keep;
                                break;
                            default:
                                break;
                        }
                        // _imgTmp = DispatchPlatform.Properties.Resources.n_Keep;
                        break;
                    #endregion

                    #region Offline


                    case TalkControl.EnumUserLineStatus.Offline:
                        _numberState = "离线";
                        _stateFontColor = _offLineFontColor;
                        this.NameColor = Color.FromArgb(_offLineFontColor);
                        switch (_tellType)
                        {
                            case PublicEnums.EnumTelType.WiFi手机:
                                _imgTmp = DispatchPlatform.Properties.Resources.n_OffLine;
                                break;
                            case PublicEnums.EnumTelType.固话:
                                _imgTmp = DispatchPlatform.Properties.Resources.telephone_n_OffLine;
                                break;
                            case PublicEnums.EnumTelType.调度席话机:
                                _imgTmp = DispatchPlatform.Properties.Resources.D_Offline;
                                break;
                            case PublicEnums.EnumTelType.G3G手机:
                                _imgTmp = DispatchPlatform.Properties.Resources.n_OffLine;
                                break;
                            case PublicEnums.EnumTelType.广播:
                                _imgTmp = DispatchPlatform.Properties.Resources.b_n_OffLine;
                                break;
                            default:
                                break;
                        }

                        //_imgTmp = DispatchPlatform.Properties.Resources.n_OffLine;
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
                        _stateFontColor = _hookonFontColor;
                        switch (_tellType)
                        {
                            case PublicEnums.EnumTelType.WiFi手机:
                                _imgTmp = DispatchPlatform.Properties.Resources.n_Busy;
                                break;
                            case PublicEnums.EnumTelType.固话:
                                _imgTmp = DispatchPlatform.Properties.Resources.telephone_n_Busy;
                                break;
                            case PublicEnums.EnumTelType.调度席话机:
                                _imgTmp = DispatchPlatform.Properties.Resources.D_Hookon;
                                break;
                            case PublicEnums.EnumTelType.G3G手机:
                                _imgTmp = DispatchPlatform.Properties.Resources.n_Busy;
                                break;
                            case PublicEnums.EnumTelType.广播:
                                _imgTmp = DispatchPlatform.Properties.Resources.b_n_Busy;
                                break;
                            default:
                                break;
                        }

                        StopTimer();
                        break;
                    #endregion
                    default:
                        break;
                }

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
        public CommControl.PublicEnums.EnumTelType TellType
        {
            get
            {
                return _tellType;
            }
            set
            {
                lblPeerNumberName.Visible = false;
                _tellType = value;
                switch (_tellType)
                {
                    case PublicEnums.EnumTelType.WiFi手机:
                        picTop.Image = DispatchPlatform.Properties.Resources.n_OffLine;
                        break;
                    case PublicEnums.EnumTelType.固话:
                        picTop.Image = DispatchPlatform.Properties.Resources.telephone_n_OffLine;
                        break;
                    case PublicEnums.EnumTelType.G3G手机:
                        picTop.Image = DispatchPlatform.Properties.Resources.n_OffLine;
                        break;
                    case PublicEnums.EnumTelType.广播:
                        picTop.Image = DispatchPlatform.Properties.Resources.b_n_OffLine;
                        break;
                    default:
                        break;
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
                                _showSelfNumberName = "主叫:" + this._number;

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
                                _showSelfNumberName = "被叫:" + this._number;

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
                                _showSelfNumberName = "主叫:" + this._number;
                            }
                            else
                            {
                                _showSelfNumberName = "被叫:" + this._number;
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
                        _showSelfNumberName = this._number.ToString();
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
                        lblState.ForeColor = Color.FromArgb(_outCallingFontColor);
                    }));
                }
                else
                {
                    lblState.Text = _numberState;
                    lblState.ForeColor = Color.FromArgb(_outCallingFontColor);
                }
            }
        }

        /// <summary>用户录音状态</summary>
        public TalkControl.EnumRecordStatus UserRecordStatus { get; set; }

        /// <summary>用户号码</summary>
        public long Number
        {
            get { return _number; }
            set
            {
                _number = value;

                lblSelfNumber.Text = value.ToString();
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

        public RegionMemberControl()
        {
            InitializeComponent();
            lblPeerNumber.Text = "";
            this.DoubleBuffered = true;
            this.Load += new EventHandler(SingleUserControl_Load);
            this.Click += new EventHandler(SingleUserControl_Click);
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

        void SingleUserControl_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); //双缓冲
            lblTime.Text = "";
            _tmpBackImage = this.BackgroundImage;
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
            t = t + 1;
            lblTime.Visible = true;
            lblTime.Text = GetAllTime(t);
        }
        #endregion

        #region 方法
        public string GetAllTime(int time)
        {
            TimeSpan ts = new TimeSpan(0, 0, time);
            string h = ts.Hours >= 10 ? ts.Hours.ToString() : "0" + ts.Hours.ToString();
            string m = ts.Minutes >= 10 ? ts.Minutes.ToString() : "0" + ts.Minutes.ToString();
            string s = ts.Seconds >= 10 ? ts.Seconds.ToString() : "0" + ts.Seconds.ToString();

            return h + ":" + m + ":" + s;
        }

        /// <summary>开始计时</summary>
        public void StartTimer()
        {
            lblTime.Visible = true;
            timer1.Enabled = true;
            t = 0;
        }

        /// <summary>结束计时</summary>
        public void StopTimer()
        {
            lblTime.Visible = false;
            lblTime.Text = "";
            timer1.Enabled = false;
        }

        /// <summary>根据过滤类型得到是否可以执行相应的操作</summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// 


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
