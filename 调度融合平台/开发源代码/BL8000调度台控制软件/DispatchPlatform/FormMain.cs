using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DispatchPlatform.Command;
using Bestway.Windows.Tools.XML;
using CommControl;
using DevComponents.DotNetBar;
using DispatchPlatform;
using MBoxSDK;


namespace DispatchPlatform
{
    public partial class FormMain : Form
    {
        #region 变量
        private HTPhoneSDK.HTphoneRegistrationStateChangedCb registerCallBack;
        private HTPhoneSDK.HTphoneCallStateChangedCb callStateCallBack;
        private FormPop _popVideoForm = new FormPop();

        /// <summary>是否为第一次连接不上</summary>
        private bool _isBreakNet = false;

        /// <summary>
        /// 普通分组的Index
        /// </summary>
        private int _memberGroupIndex = 0;

        private Tools.CheckDBOnlineThread _checkDbThread = new Tools.CheckDBOnlineThread();

        //是否第一次设置调度号码选中
        private bool _isFirstSetDispatch = true;

        /// <summary>
        /// 用于接收视频号码的来电号码
        /// </summary>
        private string _fromNumberForVideo;

        /// <summary>临时会议计数</summary>
        private int _tmpMeetingCount = 0;

        /// <summary>操作数据库</summary>
        private DB_Talk.BLL.m_Manager _memberBLL = new DB_Talk.BLL.m_Manager();

        /// <summary>记录菜单显示状态的</summary>
        private bool _popMenuShow = false;

        /// <summary>
        /// 视频设置菜单显示
        /// </summary>
        private bool _popMenuVideShow = false;
        /// <summary>锁定窗体</summary>
        private FormLogin _lockForm = new FormLogin(FormLogin.EnumLoginType.Lock);

        /// <summary>box是否在线</summary>
        private bool _isBoxOnline = false;



        /// <summary>所有用户,用来判断所有用户第一次都上报过消息</summary>
        public static List<DB_Talk.Model.m_Member> _lstMember = new List<DB_Talk.Model.m_Member>();

        /// <summary>被保持的号码，为了不在右边队列里显示过滤用的</summary>
        // private int _keepedNumber = 0;

        /// <summary>是否点击时直接可以邀请用户,为True时说明会议已经开始，直接邀请</summary>
        private bool _isCanAddMember = true;

        /// <summary>选会议人窗体</summary>
        private FormSelectMeetingMember _selectMemberForm = null;
        //= new FormSelectMeetingMember();

        /// <summary>操作命令</summary>
        private BaseCommand _baseCommand = null;

        /// <summary>调度交换机基本信息</summary>
        private DB_Talk.Model.m_Box _boxModel;

        /// <summary>当前选中的会议分组，绑定在每个Tab页上</summary>
        private MeetingGroupModel _currentSelectedMeetingModel = new MeetingGroupModel();

        /// <summary>调度命令条</summary>
        private DispatchPlatform.Control.DispatchCommandBar _dispatchCommand = new DispatchPlatform.Control.DispatchCommandBar();

        /// <summary>会议命令条</summary>
        private DispatchPlatform.Control.MeetingCommandBar _meetingCommand = new DispatchPlatform.Control.MeetingCommandBar();

        /// <summary>是否是选中的调度页</summary>
        private bool _isDispatchTabPage = true;

        /// <summary>当前创建的会议类型</summary>
        private MeetingGroupModel.EnumMeetingType _createMeetingType = MeetingGroupModel.EnumMeetingType.Temp;

        #endregion

        public FormMain()
        {
            //this.DoubleBuffered = true;
            InitializeComponent();
            imgBtnBroadcast.Tag = 0;
            this.Load += new EventHandler(Form1_Load);

            _dispatchCommand.OnButtonClick += new DispatchPlatform.Control.DispatchCommandBar.ButtonClick(command_OnButtonClick);
            _meetingCommand.OnButtonClick += new DispatchPlatform.Control.MeetingCommandBar.ButtonClick(command_OnButtonClick);
            panelCommand.Controls.Add(_dispatchCommand);
            _dispatchCommand.btnVideoCall.Visible = Pub._configModel.IsVideoCall;
            this.FormClosing += new FormClosingEventHandler(FormMain_FormClosing);
            _dispatchCommand.Dock = DockStyle.Fill;
            //Pub._talkControl.OnMeetingStateChaanged += new TalkControl.MeetingStateChanaged(Pub._talkControl_OnMeetingStateChaanged);
            //stBox2.Items.Clear();
            //this.TopMost = true;
            this.Left = -1000;
            this.Height = -1000;
            this.Width = 1;
            this.Height = 1;
            this.WindowState = FormWindowState.Normal;
            DB_Talk.DB.OleDbHelper.StateChanged += new StateChangeEventHandler(OleDbHelper_StateChanged);
            //  this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }



        #region 事件

        #region 重要处理事件

        /// <summary>点击号码事件,重要</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void single_Click(object sender, EventArgs e)
        {
            if (_isBoxOnline == false)
            {
                bc_OnMsg("连接设备失败");
                return;
            }
            _dispatchCommand.ClearSelect();
            _meetingCommand.ClearSelect();

            //if (Pub._talkControl.CurrentNormalCMD == CommControl.PublicEnums.EnumNormalCmd.None)
            //{
            //    bc_OnMsg("请先选择命令");
            //}

            if (Pub._talkControl.CurrentDispatchNumber == 0)
            {
                bc_OnMsg("请选择调度号码");
            }

            SingleUserControl control = (SingleUserControl)sender;

            if (control.UserLineStatus == TalkControl.EnumUserLineStatus.Holding
                && Pub._talkControl.CurrentNormalCMD == PublicEnums.EnumNormalCmd.None
                )//如果当前为保持状态，就执行应答
            {
                Pub._talkControl.CurrentNormalCMD = PublicEnums.EnumNormalCmd.SelectAnser;
            }


            if (control.UserLineStatus == TalkControl.EnumUserLineStatus.Idle
                && Pub._talkControl.CurrentNormalCMD == PublicEnums.EnumNormalCmd.None
                && _isDispatchTabPage == false)//如果当前为会议，默认为邀请用户
            {
                Pub._talkControl.CurrentNormalCMD = PublicEnums.EnumNormalCmd.AddMeetingMember;
            }

            switch (Pub._talkControl.CurrentNormalCMD)
            {
                case PublicEnums.EnumNormalCmd.None:

                case CommControl.PublicEnums.EnumNormalCmd.Call:
                    if (_isDispatchTabPage == true)
                    {
                        if (control.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                        {
                            _baseCommand = new MakeCallCommand();
                            _baseCommand.MemberControl = control;
                            _baseCommand.talkControl = Pub._talkControl;
                            _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                            if (_baseCommand.Begin() == true && Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                            {
                                Pub._memberManage.SetMemberState(control.Number, "连接中");
                            }
                        }
                    }
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.MakeLemcMeeting:
                    //if (control.Checked == true)
                    //{
                    //    if (Pub._talkControl.NumberList.Exists(delegate(DB_Talk.Model.m_Member s) { return s.i_Number == control.Number; }) == false)
                    //    {
                    //        if (Pub._talkControl.NumberList.Count >= Pub._configModel.MaxMeetingMember)
                    //        {
                    //            CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("选择会议成员失败,成员最大数为：{0}", Pub._configModel.MaxMeetingMember),"紧急会议提示");
                    //            control.Checked = false;
                    //        }
                    //        else
                    //        {
                    //            Pub._talkControl.NumberList.Add(new DB_Talk.Model.m_Member() { i_Number = control.Number, vc_Name = control.MemberName });
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    DB_Talk.Model.m_Member m = Pub._talkControl.NumberList.Find(delegate(DB_Talk.Model.m_Member s) { return s.i_Number == control.Number; });
                    //    if (m != null)
                    //    {
                    //        Pub._talkControl.NumberList.Remove(m);
                    //    }
                    //}
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.Handup:
                    _baseCommand = new HandupCommand();
                    _baseCommand.MemberControl = control;
                    _baseCommand.talkControl = Pub._talkControl;
                    _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                    _baseCommand.Begin();
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.Insert:
                    _baseCommand = new InsertCommand();
                    _baseCommand.MemberControl = control;
                    _baseCommand.talkControl = Pub._talkControl;
                    _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                    if (_baseCommand.Begin())
                    {
                        int number = 0;
                        try
                        {
                            number = int.Parse(control.PeerNumber);
                            if (number != 0)
                            {
                                Pub.WriteMemberState(Pub._talkControl.CurrentDispatchNumber, control.Number, number, TalkControl.EnumUserLineStatus.Insert);
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.InsteadAnswer:
                    _baseCommand = new InsteadAnswerCommand();
                    _baseCommand.MemberControl = control;
                    _baseCommand.talkControl = Pub._talkControl;
                    _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                    _baseCommand.Begin();
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.Keep:
                    _baseCommand = new KeepCommand();
                    _baseCommand.MemberControl = control;
                    _baseCommand.talkControl = Pub._talkControl;
                    _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                    _baseCommand.Begin();
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.Transfer:
                    _baseCommand = new TransferCommand();
                    _baseCommand.MemberControl = control;
                    _baseCommand.talkControl = Pub._talkControl;
                    _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                    _baseCommand.Begin();
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.SnatchCall:
                    _baseCommand = new SnatchCommand();
                    _baseCommand.MemberControl = control;
                    _baseCommand.talkControl = Pub._talkControl;
                    _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                    _baseCommand.Begin();
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.Listen:
                    _baseCommand = new ListenCommand();
                    _baseCommand.MemberControl = control;
                    _baseCommand.talkControl = Pub._talkControl;
                    _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);

                    try
                    {
                        if (_baseCommand.Begin() == true)
                        {
                            Pub.WriteMemberState(Pub._talkControl.CurrentDispatchNumber, control.Number, int.Parse(control.PeerNumber), TalkControl.EnumUserLineStatus.Listen);
                        }
                    }
                    catch (Exception)
                    {

                    }
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.AddMeetingMember:
                    if (_currentSelectedMeetingModel.MeetingState == MeetingGroupModel.EnumMeetingState.Running && this._isCanAddMember == true)
                    {
                        _baseCommand = new AddMeetingMemberCommand();
                        _baseCommand.MemberControl = control;
                        _baseCommand.talkControl = Pub._talkControl;
                        _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);

                        //GetCurrentMeetingModel();
                        Pub._talkControl.NumberList.Clear();
                        Pub._talkControl.NumberList.Add(new DB_Talk.Model.m_Member() { i_Number = control.Number, vc_Name = control.MemberName });
                        if (_currentSelectedMeetingModel != null)
                        {
                            if (_baseCommand.Begin() == true)
                            {
                                Pub._meetingManage.AddMeetingMember(_currentSelectedMeetingModel.GroupID, Pub._talkControl.CurrentMeetingID, control.Number, _currentSelectedMeetingModel.GroupName);
                            }
                            imgBtnMeeting_Click(null, null);
                        }
                        else
                        {
                            bc_OnMsg("邀请失败");
                        }
                    }
                    else
                    {
                        if (control.Checked == true)
                        {
                            if (Pub._talkControl.NumberList.Exists(delegate(DB_Talk.Model.m_Member s) { return s.i_Number == control.Number; }) == false)
                            {
                                if (Pub._talkControl.NumberList.Count + Pub._currentSelectMeetingMemberCount >= Pub._maxMeetingMemberCount)
                                {
                                    CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("选择会议成员失败,成员最大数为：{0}", Pub._maxMeetingMemberCount), "会议提示");
                                    control.Checked = false;
                                }
                                else
                                {
                                    Pub._talkControl.NumberList.Add(new DB_Talk.Model.m_Member() { i_Number = control.Number, vc_Name = control.MemberName });
                                }
                            }
                        }
                        else
                        {
                            DB_Talk.Model.m_Member m = Pub._talkControl.NumberList.Find(delegate(DB_Talk.Model.m_Member s) { return s.i_Number == control.Number; });
                            if (m != null)
                            {
                                Pub._talkControl.NumberList.Remove(m);
                            }
                        }
                    }

                    break;
                case CommControl.PublicEnums.EnumNormalCmd.DeleteMeetingMember:
                    if (control.UserLineStatus != TalkControl.EnumUserLineStatus.Busy
                        && control.UserLineStatus != TalkControl.EnumUserLineStatus.Forbid
                        && control.UserLineStatus != TalkControl.EnumUserLineStatus.Isolate
                        && control.UserLineStatus != TalkControl.EnumUserLineStatus.Ring
                        && control.UserLineStatus != TalkControl.EnumUserLineStatus.Record
                        )
                    {
                        Pub._meetingManage.DeleteMeetingMemberByName(_currentSelectedMeetingModel.GroupName, control.Number);
                    }
                    else
                    {
                        if (_currentSelectedMeetingModel.MeetingState == MeetingGroupModel.EnumMeetingState.Running)
                        {
                            _baseCommand = new DeleteMeetingMemberCommand();
                            _baseCommand.MemberControl = control;
                            _baseCommand.talkControl = Pub._talkControl;
                            _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                            _baseCommand.Begin();
                        }

                        if (control.UserLineStatus == TalkControl.EnumUserLineStatus.Ring)
                        {
                            _baseCommand = new HandupCommand();
                            _baseCommand.MemberControl = control;
                            _baseCommand.talkControl = Pub._talkControl;
                            _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                            _baseCommand.Begin();
                        }
                        if (control.PeerNumber == "会议中")
                        {
                            control.IsMeeting = false;
                            _baseCommand = new HandupCommand();
                            _baseCommand.MemberControl = control;
                            _baseCommand.talkControl = Pub._talkControl;
                            _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                            _baseCommand.Begin();
                        }
                        Pub._meetingManage.DeleteMeetingMemberByName(_currentSelectedMeetingModel.GroupName, control.Number);
                    }
                    superTabControlMeeting.SelectedTab.RaiseClick();
                    Pub._memberManage.SetControlIsCanSelect(false);
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.NoSpeekMeeting:
                    AutoSelectDispatchNumber();
                    _baseCommand = new NoSpeekMeetingMemberCommand();
                    _baseCommand.MemberControl = control;
                    _baseCommand.talkControl = Pub._talkControl;
                    _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                    _baseCommand.Begin();
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.OkSpeekMeeting:
                    AutoSelectDispatchNumber();
                    _baseCommand = new OkSpeekMeetingMemberCommand();
                    _baseCommand.MemberControl = control;
                    _baseCommand.talkControl = Pub._talkControl;
                    _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                    _baseCommand.Begin();
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.IsolateMeeting:
                    AutoSelectDispatchNumber();
                    _baseCommand = new IsolateMeetingMemberCommand();
                    _baseCommand.MemberControl = control;
                    _baseCommand.talkControl = Pub._talkControl;
                    _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                    _baseCommand.Begin();
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.UnIsolateMeeting:
                    AutoSelectDispatchNumber();
                    _baseCommand = new UnIsolateMeetingMemberCommand();
                    _baseCommand.MemberControl = control;
                    _baseCommand.talkControl = Pub._talkControl;
                    _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                    _baseCommand.Begin();
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.EndMeeting:
                    _baseCommand = new EndMeetingCommand();
                    _baseCommand.MemberControl = control;
                    _baseCommand.talkControl = Pub._talkControl;
                    _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                    _baseCommand.Begin();
                    break;
                case PublicEnums.EnumNormalCmd.SelectAnser:
                    _baseCommand = new SelectAnswerCommand();
                    _baseCommand.MemberControl = control;
                    _baseCommand.talkControl = Pub._talkControl;
                    _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                    _baseCommand.Begin();
                    break;
                case PublicEnums.EnumNormalCmd.RecordOperate:
                    if (control.UserLineStatus != TalkControl.EnumUserLineStatus.Record)
                    {
                        _baseCommand = new BeginRecordCommand();
                        _baseCommand.MemberControl = control;
                        _baseCommand.talkControl = Pub._talkControl;
                        _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                        _baseCommand.Begin();
                    }
                    if (control.UserLineStatus == TalkControl.EnumUserLineStatus.Record)
                    {
                        if (CommControl.MessageBoxEx.MessageBoxEx.Show("请确认是否要停止录音？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                          MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        {
                            return;
                        }
                        _baseCommand = new EndRecordCommand();

                        _baseCommand.talkControl = Pub._talkControl;
                        _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);

                        try
                        {
                            _baseCommand.MemberControl = new SingleUserControl()
                            {
                                Number = int.Parse(control.PeerNumber)//停止对方的
                            };
                            SingleUserControl sc = Pub._memberManage.GetSingleControl(int.Parse(control.PeerNumber));
                            if (sc.UserLineStatus == TalkControl.EnumUserLineStatus.Record)
                            {
                                _baseCommand.Begin();
                            }
                        }
                        catch (Exception)
                        {

                        }

                        _baseCommand.MemberControl = control;
                        _baseCommand.Begin();
                    }
                    break;
               
                default:
                    break;
            }
            if (Pub._talkControl.CurrentNormalCMD != CommControl.PublicEnums.EnumNormalCmd.MakeLemcMeeting)
            {
                Pub._talkControl.CurrentNormalCMD = CommControl.PublicEnums.EnumNormalCmd.None;
            }
            if (Pub._talkControl.CurrentNormalCMD != CommControl.PublicEnums.EnumNormalCmd.AddMeetingMember)
            {
                Pub._memberManage.ShowAllMember();
            }
        }

        /// <summary>命令条 点击按钮处理事件</summary>
        /// <param name="sender"></param>
        /// <param name="cmd"></param>
        void command_OnButtonClick(object sender, CommControl.PublicEnums.EnumNormalCmd cmd)
        {
            Pub._meetingManage.SetControlIsCanSelect(false);
            //if (cmd!= PublicEnums.EnumNormalCmd.MeetingGroupOperate)
            //{
            //    Pub._talkControl.NumberList.Clear();    
            //}

            Pub._talkControl.CurrentNormalCMD = cmd;
            if (_isDispatchTabPage == false)//为会议页
            {
                GetCurrentMeetingModel();
            }

            switch (cmd)
            {
                case CommControl.PublicEnums.EnumNormalCmd.None:
                    Pub._memberManage.ShowAllMember();
                    break;
                case PublicEnums.EnumNormalCmd.GroupCall:

                    if (_dispatchCommand.btnGroupCall.Image != null)
                    {
                        bc_OnMsg("组呼失败");
                    }
                    else
                    {
                        #region 开始组呼
                        _baseCommand = new GroupCallCommand();

                        Pub._talkControl.NumberList.Clear();

                        //自动获取类型设置不同的个数
                        TalkControl.EnumEquipmentType et = Pub._talkControl.GetEquipmentType();
                        int count = 16;
                        switch (et)
                        {
                            case TalkControl.EnumEquipmentType.T_HT8000B:
                                count = 32;
                                break;
                            case TalkControl.EnumEquipmentType.T_HT8000C:
                                count = 16;
                                break;
                            case TalkControl.EnumEquipmentType.T_HT8000D:
                                count = 16;
                                break;
                            case TalkControl.EnumEquipmentType.T_HT8000E:
                                count = 16;
                                break;
                            default:
                                break;
                        }

                        int i = 0;
                        foreach (SingleUserControl item in Pub._memberManage._lstGroup[_memberGroupIndex].lstControl)
                        {
                            if (item.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                            {
                                i++;
                                if (i > count)
                                {
                                    break;
                                }
                                Pub._talkControl.NumberList.Add(new DB_Talk.Model.m_Member() { i_Number = item.Number, vc_Name = item.MemberName });
                            }
                        }





                        _baseCommand.talkControl = Pub._talkControl;
                        _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);

                        _currentSelectedMeetingModel.DispatchNumber = Pub._talkControl.CurrentDispatchNumber;
                        _currentSelectedMeetingModel.MeetingID = 0;
                        if (_baseCommand.Begin() == false)
                        {

                        }
                        else
                        {

                        }
                        Pub._talkControl.NumberList.Clear();
                        Pub._talkControl.CurrentNormalCMD = PublicEnums.EnumNormalCmd.None;
                        #endregion
                    }
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.Call:
                    Pub._memberManage.SetFilterType(EnumFilterType.CanMakeCall);
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.MakeLemcMeeting:
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.Handup:
                    Pub._memberManage.SetFilterType(EnumFilterType.CanHandup);
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.Insert:
                    Pub._memberManage.SetFilterType(EnumFilterType.CanInsert);
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.InsteadAnswer:
                    Pub._memberManage.SetFilterType(EnumFilterType.CanInsteadAnswer);
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.Keep:
                    Pub._memberManage.SetFilterType(EnumFilterType.CanHolding);
                    if (_dispatchCommand.btnKeep.Image != null)
                    {
                        superTabControlDispatch.SelectedTab = stiAllMember;
                    }
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.SelectAnser:
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.Transfer:
                    Pub._memberManage.SetFilterType(EnumFilterType.CanTranfer);
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.SnatchCall:
                    Pub._memberManage.SetFilterType(EnumFilterType.CanSnatch);
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.Listen:
                    Pub._memberManage.SetFilterType(EnumFilterType.CanListen);
                    if (_dispatchCommand.btnListen.Image != null)
                    {
                        superTabControlDispatch.SelectedTab = stiAllMember;
                    }
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.AddMeetingMember://邀请会议成员
                    Pub.CanDestroyControl = false;
                    this._isCanAddMember = false;
                    Pub._pageControl._columnCount = 4;
                    Pub._pageControl._rowCount = 5;
                    Pub._pageControl.GetSingleControlSize();
                    _selectMemberForm = new FormSelectMeetingMember(this, _currentSelectedMeetingModel.MeetingState == MeetingGroupModel.EnumMeetingState.Running);
                    _selectMemberForm.AddPageControl(Pub._pageControl);

                    Pub._pageControl.LoadData();

                    Pub._talkControl.NumberList.Clear();

                    foreach (SingleUserControl item in _currentSelectedMeetingModel.lstControl)
                    {
                        if (item.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                        {
                            Pub._talkControl.NumberList.Add(new DB_Talk.Model.m_Member() { i_Number = item.Number, vc_Name = item.MemberName });
                        }
                    }

                    if (_currentSelectedMeetingModel.MeetingState == MeetingGroupModel.EnumMeetingState.Running)
                    {
                        Pub._talkControl.NumberList.Clear();
                    }

                    Pub._meetingManage.SetControlIsCanSelect(true);

                    Pub._currentSelectMeetingMemberCount = _currentSelectedMeetingModel.lstControl.Count;

                    if (Pub._currentSelectMeetingMemberCount >= Pub._maxMeetingMemberCount)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("当前会议内成员数已达到上限{0}个", Pub._maxMeetingMemberCount), "会议提示");
                    }
                    else
                    {
                        if (_selectMemberForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            foreach (DB_Talk.Model.m_Member item in Pub._talkControl.NumberList)
                            {
                                #region 手动增加空闲的手柄进待选的成员里

                                if (cLeft.Number != item.i_Number && cRight.Number != item.i_Number)
                                {
                                    Pub._meetingManage.AddMeetingMember(0, _currentSelectedMeetingModel.MeetingID, item.i_Number.Value, _currentSelectedMeetingModel.GroupName);
                                }

                                #endregion
                            }

                            //会议开始的进行邀请命令
                            if (_currentSelectedMeetingModel.MeetingState == MeetingGroupModel.EnumMeetingState.Running)
                            {
                                //foreach (DB_Talk.Model.m_Member item in Pub._talkControl.NumberList)
                                //{
                                //    SingleUserControl sc = Pub._memberManage.GetSingleControl(item.i_Number.Value);
                                //    if (sc != null)
                                //    {
                                //        _baseCommand = new AddMeetingMemberCommand();
                                //        _baseCommand.MemberControl = sc;
                                //        _baseCommand.talkControl = Pub._talkControl;
                                //        _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                                //        _baseCommand.Begin();
                                //    }
                                //}

                                ////////////////////
                                _baseCommand = new AddMeetingMemberCommand();

                                _baseCommand.talkControl = Pub._talkControl;
                                _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                                _baseCommand.Begin();
                            }
                        }
                    }
                    Pub._pageControl.ShowAllMember();
                    Pub._meetingManage.SetControlIsCanSelect(false);
                    Pub._meetingManage.SetControlChecked(false);
                    this._isCanAddMember = true;
                    Pub.CanDestroyControl = true;
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.NoSpeekMeeting:
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.OkSpeekMeeting:
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.IsolateMeeting:
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.UnIsolateMeeting:
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.DeleteMeetingMember:
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.EndMeeting:
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.BeginRecord:
                    if (_dispatchCommand.btnRecord.Image != null)
                    {
                        superTabControlDispatch.SelectedTab = stiAllMember;
                    }
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.EndRecord:
                    break;
                case CommControl.PublicEnums.EnumNormalCmd.MeetingGroupOperate:
                    #region 会议操作

                    #region 初始操作

                    _meetingCommand.btnMeetingBeginEnd.Checked = false;

                    if (_currentSelectedMeetingModel == null)
                    {
                        bc_OnMsg("当前没有可用的会议分组");
                        return;
                    }
                    Pub._talkControl.CurrentMeetingID = _currentSelectedMeetingModel.MeetingID;
                    #endregion

                    if (_meetingCommand.btnMeetingBeginEnd.Text == "开始会议")
                    {
                        if (Pub.CurrentDispatchControl.UserLineStatus != TalkControl.EnumUserLineStatus.Idle
                            && Pub.CurrentDispatchControl.UserLineStatus != TalkControl.EnumUserLineStatus.HookOn)
                        {
                            bc_OnMsg(string.Format("创建会议失败,手柄为非空闲", cLeft.Number));
                            return;
                        }

                        if (_currentSelectedMeetingModel.MeetingType == MeetingGroupModel.EnumMeetingType.Formal)
                        {
                            #region 开始正式会议


                            _baseCommand = new MakeMeetingCommand();

                            Pub._talkControl.NumberList.Clear();

                            foreach (SingleUserControl item in _currentSelectedMeetingModel.lstControl)
                            {
                                if (item.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                                {
                                    Pub._talkControl.NumberList.Add(new DB_Talk.Model.m_Member() { i_Number = item.Number, vc_Name = item.MemberName });
                                }
                            }


                            _createMeetingType = MeetingGroupModel.EnumMeetingType.Formal;

                            Pub._talkControl.CurrentNormalCMD = CommControl.PublicEnums.EnumNormalCmd.MakeLemcMeeting;
                            _currentSelectedMeetingModel.MeetingState = MeetingGroupModel.EnumMeetingState.Ready;
                            //  bc_OnMsg("正在创建会议");
                            _meetingCommand.btnMeetingBeginEnd.Text = "结束会议";
                            _meetingCommand.btnAddMeetingMember.Enabled = false;
                            _baseCommand.talkControl = Pub._talkControl;
                            _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);

                            _currentSelectedMeetingModel.DispatchNumber = Pub._talkControl.CurrentDispatchNumber;
                            _currentSelectedMeetingModel.MeetingID = 0;
                            if (_baseCommand.Begin() == false)
                            {
                                _currentSelectedMeetingModel.MeetingState = MeetingGroupModel.EnumMeetingState.Off;
                                _meetingCommand.btnMeetingBeginEnd.Text = "开始会议";
                                _meetingCommand.btnMeetingBeginEnd.Enabled = true;
                                _dispatchCommand.btnMeeting.Enabled = true;
                                _meetingCommand.btnAddMeetingMember.Enabled = true;
                            }
                            else
                            {
                                _meetingCommand.btnMeetingBeginEnd.Enabled = false;
                                _dispatchCommand.btnMeeting.Enabled = false;
                            }
                            Pub._talkControl.NumberList.Clear();
                            Pub._talkControl.CurrentNormalCMD = PublicEnums.EnumNormalCmd.None;
                            #endregion
                        }
                        if (_currentSelectedMeetingModel.MeetingType == MeetingGroupModel.EnumMeetingType.Lemc)
                        {
                            #region 开始紧急会议

                            Pub._talkControl.NumberList.Clear();

                            foreach (SingleUserControl item in _currentSelectedMeetingModel.lstControl)
                            {
                                if (item.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                                {
                                    Pub._talkControl.NumberList.Add(new DB_Talk.Model.m_Member() { i_Number = item.Number, vc_Name = item.MemberName });
                                }
                            }

                            if (Pub._talkControl.NumberList.Count > 0)
                            {
                                _createMeetingType = MeetingGroupModel.EnumMeetingType.Temp;
                                _baseCommand.OnMsg += new Command.BaseCommand.MsgDelegate(bc_OnMsg);

                                Pub._talkControl.CurrentNormalCMD = PublicEnums.EnumNormalCmd.None;
                                _meetingCommand.btnMeetingBeginEnd.Enabled = false;
                                _meetingCommand.btnMeetingBeginEnd.Text = "结束会议";
                                _meetingCommand.btnAddMeetingMember.Enabled = false;
                                _currentSelectedMeetingModel.MeetingState = MeetingGroupModel.EnumMeetingState.Ready;
                                _currentSelectedMeetingModel.DispatchNumber = Pub._talkControl.CurrentDispatchNumber;
                                _currentSelectedMeetingModel.MeetingID = 0;
                                _baseCommand.Begin();
                                //  Pub._meetingManage.AddMeetingGroup(MeetingGroupModel.EnumMeetingState.Ready, MeetingGroupModel.EnumMeetingType.Temp, -1, Pub._talkControl.CurrentMeetingID, GetTempMeetingName(), Pub._talkControl.NumberList, Pub._talkControl.CurrentDispatchNumber, true);
                                Pub._talkControl.NumberList.Clear();
                                Pub._memberManage.SetControlChecked(false);
                                Pub._meetingManage.SetControlChecked(false);
                            }
                            else
                            {
                                bc_OnMsg("请先选择会议的成员");
                            }
                            return;
                            #endregion
                        }
                    }
                    else
                    {
                        #region 结束会议


                        AutoSelectDispatchNumber();

                        if (CommControl.MessageBoxEx.MessageBoxEx.Show("请确认是否要结束此会议？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                        {
                            return;
                        }


                        _baseCommand = new EndMeetingCommand();
                        Pub._talkControl.CurrentNormalCMD = CommControl.PublicEnums.EnumNormalCmd.EndMeeting;

                        _baseCommand.talkControl = Pub._talkControl;
                        _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);


                        if (_baseCommand.Begin() == false)
                        {
                            //  _currentSelectedMeetingModel.MeetingState = MeetingGroupModel.EnumMeetingState.Off;
                        }
                        Pub._talkControl.NumberList.Clear();
                        Pub._meetingManage.DeleteMeeting(_currentSelectedMeetingModel.GroupName);
                        _meetingCommand.btnMeetingBeginEnd.Text = "开始会议";
                        _meetingCommand.btnAddMeetingMember.Enabled = true;

                        Pub._meetingManage.DeleteMeeting(_currentSelectedMeetingModel.MeetingID);
                        _currentSelectedMeetingModel.MeetingState = MeetingGroupModel.EnumMeetingState.Off;
                        _currentSelectedMeetingModel.MeetingID = 0;
                        // superTabControlMeeting.SelectedTab = (SuperTabItem)superTabControlMeeting.Tabs[0];
                        //  ((SuperTabItem)superTabControlMeeting.Tabs[0]).RaiseClick();
                        bc_OnMsg("结束会议成功");
                        #endregion
                    }


                    #endregion
                    break;
                case PublicEnums.EnumNormalCmd.RecordOperate:
                    Pub._memberManage.SetFilterType(EnumFilterType.CanRecord);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 窗体事件处理

        void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1;
            this.Height = 1;
            this.DoubleBuffered = true;
            this.Invalidate();

            CommControl.Resolution.ChangeRes();
            Pub._memberManage = new MemberManage(this);
            Pub._meetingManage = new MeetingManage(this, Pub._talkControl);

            Pub._memberManage.Init();
            Pub._memberManage.LoadFap();

            Pub._meetingManage.Init();

            LoadAllUser();

            if (superTabControlMeeting.Tabs.Count > 0)
            {
                _currentSelectedMeetingModel = (MeetingGroupModel)superTabControlMeeting.Tabs[0].Tag;
                superTabControlMeeting.SelectedTab = (SuperTabItem)superTabControlMeeting.Tabs[0];
            }

            Pub._talkControl.OnMemberStateChanged += new TalkControl.MemberStateChanaged(_talkControl_OnMemberStateChanged);
            Pub._talkControl.OnWaitingQueensChanged += new TalkControl.WaitingQueensChaanged(_talkControl_OnWaitingQueensChanged);
            Pub._talkControl.OnDispatchStateChanged += new TalkControl.DispatchStateChanaged(_talkControl_OnDispatchStateChanged);
            Pub._talkControl.OnLemcQueensChanged += new TalkControl.LemcQueensChaanged(_talkControl_OnLemcQueensChanged);
            Pub._talkControl.OnHotStandbyChanged += new TalkControl.HotStandbyChaanged(_talkControl_OnHotStandbyChanged);
            //  dgvWait.CellClick += new DataGridViewCellEventHandler(dgvWait_CellClick);

            waitControl1.OnSelect += new DispatchPlatform.Control.WaitControl.SelectWaitDelgate(waitControl1_OnSelect);
            _boxModel = new DB_Talk.BLL.m_Box().GetModel(Pub.manageModel.BoxID.Value);
            stiAllMember.Click += new EventHandler(MemberTabItem_Click);


            lblTitle.Text = Pub._configModel.Title;
            this.Text = Pub._configModel.Title;

            DB_Talk.Model.m_Box box = new DB_Talk.BLL.m_Box().GetModel(Pub.manageModel.BoxID.Value);
            if (box != null)
            {
                Pub.BoxName = box.vc_Name;
            }
            imgBtnDispatch.Checked = true;
            superTabControlMain.SelectedTab = superTabItemDispatch;


            superTabItemDispatch.Tag = CommControl.PublicEnums.EnumGroupType.Normal;
            superTabItemMeeting.Tag = CommControl.PublicEnums.EnumGroupType.Meeting;


            Pub._meetingManage.SetControlIsCanSelect(false);

            // lblUserName.Text = Pub.manageModel.vc_UserName;
            timer1.Enabled = true;
            timer1.Interval = Pub._configModel.CheckBoxOnLineInterval * 1000;
            // this.WindowState = FormWindowState.Maximized;

            Pub.SetAutoRun(Pub._configModel.IsAutoStartBySystem);

            Pub.CanDeleteMemberState = true;
            Pub.CanSort = true;


            _memberGroupIndex = 0;



        }


        void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (new FormLogin(FormLogin.EnumLoginType.Out).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CommControl.Resolution.FuYuan();
                Pub._talkControl.SetAnserType(true);
                _checkDbThread.Stop();
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region 队列处理事件

        void _lemcWaitForm_OnSelect(object obj, FormLemcWait.SelectEventArgs e)
        {
            waitControl1_OnSelect(obj, new Control.WaitControl.SelectEventArgs()
            {
                Number = e.Number,
                Type = CommControl.PublicEnums.EnumWaitType.Lemc
            });
        }

        void waitControl1_OnSelect(object obj, DispatchPlatform.Control.WaitControl.SelectEventArgs e)
        {
            BaseCommand bc = null;
            switch (e.Type)
            {
                case CommControl.PublicEnums.EnumWaitType.Normal:
                    bc = new SelectAnswerCommand();
                    break;
                case CommControl.PublicEnums.EnumWaitType.Lemc:
                    bc = new SelectLemcAnswerCommand();
                    break;
                default:
                    break;
            }
            AutoSelectIdelDispatch();

            if (_isBoxOnline)
            {
                if (Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.Idle
                    || Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.HookOn
                    || Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.Holding
                    )
                {
                    bc.MemberControl = new SingleUserControl()
                    {
                        Number = e.Number
                    };
                    bc.talkControl = Pub._talkControl;
                    bc.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);

                    bc.Begin();
                }
            }
        }

        #endregion

        #region 回调消息处理

        void _talkControl_OnDispatchStateChanged(object obj, TalkControl.DispatchArgs e)
        {
            //  System.Console.WriteLine("开始：_talkControl_OnDispatchStateChaanged");
            this.Invoke(new EventHandler(delegate(object o, EventArgs ee)
            {
                SetCommandState();
                switch (e.DispatchCmdSubType)
                {
                    #region 呼叫
                    case TalkControl.EnumDispatchCmdType.makeCall:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                bc_OnMsg(string.Format("{0}呼叫{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                                DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.Call, e.FromNumber, e.ToNumber.ToString(), true);
                                SingleUserControl scc = Pub._memberManage.GetSingleControl(e.FromNumber);
                                if (scc != null)
                                {
                                    Pub._memberManage.UpdateMemberState(scc.Number, TalkControl.EnumUserLineStatus.Busy);
                                }
                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                // bc_OnMsg(string.Format("呼叫释放"));
                                DB_Talk.Model.Data_DispatchLog log = DispatchLogBLL.GetDispatchLog(PublicEnums.EnumNormalCmd.Call, e.FromNumber);
                                if (log != null)
                                {
                                    SingleUserControl sc = Pub._memberManage.GetSingleControl(int.Parse(log.DispatchedNumbers));
                                    if (sc != null)
                                    {
                                        Pub._memberManage.UpdateMemberState(sc.Number, sc.UserLineStatus);
                                    }
                                }
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                DB_Talk.Model.Data_DispatchLog logF = DispatchLogBLL.GetDispatchLog(PublicEnums.EnumNormalCmd.Call, e.FromNumber);
                                if (logF != null)
                                {
                                    SingleUserControl sc = Pub._memberManage.GetSingleControl(int.Parse(logF.DispatchedNumbers));
                                    if (sc != null)
                                    {
                                        Pub._memberManage.UpdateMemberState(sc.Number, sc.UserLineStatus);
                                    }
                                }
                                bc_OnMsg(string.Format("呼叫失败"));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                if (e.ToNumber != 0)
                                {
                                    bc_OnMsg(string.Format("用户{0}振铃", e.ToNumber));
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 创建会议

                    case TalkControl.EnumDispatchCmdType.createConf:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.confCreated://会议创建
                                if (e.ConfID > 0)
                                {
                                    RestoreMeetingButtonState();
                                    Pub._meetingManage.SetTempGroupState(e.FromNumber, e.ConfID);
                                }
                                break;
                            case TalkControl.EnumDispatchStatus.success://创建成功
                                bc_OnMsg(string.Format("创建会议成功", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                _meetingCommand.btnMeetingBeginEnd.Text = "结束会议";
                                superTabControlMeeting.SelectedTab.RaiseClick();
                                _meetingCommand.btnAddMeetingMember.Enabled = true;
                                Pub._meetingManage.SetMeetingGroupState(e.FromNumber, e.ConfID);
                                RestoreMeetingButtonState();
                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                bc_OnMsg(string.Format("会议释放", e.ToNumber));
                                RestoreMeetingButtonState();
                                _meetingCommand.btnMeetingBeginEnd.Text = "开始会议";
                                Pub._meetingManage.SetTempGroupStateOff(e.FromNumber, e.ConfID);
                                superTabControlMeeting.SelectedTab.RaiseClick();
                                _meetingCommand.btnAddMeetingMember.Enabled = true;
                                Pub._meetingManage.DeleteMeeting(e.ConfID);
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("{0}创建会议失败", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                _meetingCommand.btnMeetingBeginEnd.Text = "开始会议";
                                Pub._meetingManage.SetTempGroupStateOff(e.FromNumber, e.ConfID);
                                superTabControlMeeting.SelectedTab.RaiseClick();
                                _meetingCommand.btnAddMeetingMember.Enabled = true;
                                Pub._meetingManage.DeleteMeeting(e.ConfID);
                                RestoreMeetingButtonState();
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                break;
                            case TalkControl.EnumDispatchStatus.confDelPart:

                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 增加会议成员

                    case TalkControl.EnumDispatchCmdType.confAddPart:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                bc_OnMsg(string.Format("{0}增加会议成员成功", Pub.GetDispatchNameByNumber(e.FromNumber)));

                                //  Pub._meetingManage.SetMeetingGroupState(e.ConfID);
                                //  Pub._meetingManage.UpdateMeetingMemberState(e.ToNumber, TalkControl.EnumConfUserState.DU_ST_ISOLATED);
                                break;
                            case TalkControl.EnumDispatchStatus.released:

                                ////没有会议成员时显示为开始状态,因为SDK没有给消息，所以用软件处理
                                //List<SingleUserControl> lstC = _currentSelectedMeetingModel.lstControl.FindAll(p => p.UserLineStatus == TalkControl.EnumUserLineStatus.Busy
                                //    && p.Number != e.ToNumber
                                //    );

                                bc_OnMsg(string.Format("会议释放", e.ToNumber));
                                RestoreMeetingButtonState();
                                _meetingCommand.btnMeetingBeginEnd.Text = "开始会议";
                                Pub._meetingManage.SetTempGroupStateOff(e.FromNumber, e.ConfID);
                                superTabControlMeeting.SelectedTab.RaiseClick();
                                _meetingCommand.btnAddMeetingMember.Enabled = true;
                                Pub._meetingManage.DeleteMeeting(e.ConfID);
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("{0}增加会议成员失败", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.confAddPart:
                                //Pub._memberManage.GetSingleControl(e.ToNumber).PeerNumber = _currentSelectedMeetingModel.GroupName;
                                Pub._memberManage.SetMemberPeeName(e.ToNumber, _currentSelectedMeetingModel.GroupName, true);
                                Pub._meetingManage.SetMeetingMemberPeeName(e.ToNumber, _currentSelectedMeetingModel.GroupName, true);
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 删除会议成员

                    case TalkControl.EnumDispatchCmdType.confDelPart:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                bc_OnMsg(string.Format("{0}踢出会议成员成功", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                //  Pub._meetingManage.UpdateMeetingMemberState(e.ToNumber, TalkControl.EnumConfUserState.DU_ST_ISOLATED);

                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                bc_OnMsg(string.Format("{0}踢出会议成员成功", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                ////没有会议成员时显示为开始状态,因为SDK没有给消息，所以用软件处理
                                //List<SingleUserControl> lstCs = _currentSelectedMeetingModel.lstControl.FindAll(p => p.UserLineStatus == TalkControl.EnumUserLineStatus.Busy
                                //    && p.Number != e.ToNumber
                                //    );

                                //if ((lstCs != null && lstCs.Count == 0))
                                //{
                                //    _currentSelectedMeetingModel.MeetingState = MeetingGroupModel.EnumMeetingState.Off;
                                //    _meetingCommand.btnMeetingBeginEnd.Text = "开始会议";
                                //}
                                bc_OnMsg(string.Format("会议释放", e.ToNumber));
                                RestoreMeetingButtonState();
                                _meetingCommand.btnMeetingBeginEnd.Text = "开始会议";
                                Pub._meetingManage.SetTempGroupStateOff(e.FromNumber, e.ConfID);
                                superTabControlMeeting.SelectedTab.RaiseClick();
                                _meetingCommand.btnAddMeetingMember.Enabled = true;
                                Pub._meetingManage.DeleteMeeting(e.ConfID);
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("{0}踢出会议成员失败", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.confDelPart:
                                Pub._meetingManage.DeleteMeetingMember(e.ConfID, e.ToNumber);
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 禁言


                    case TalkControl.EnumDispatchCmdType.confForbidPart:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                bc_OnMsg(string.Format("{0}禁言{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                                Pub._meetingManage.UpdateMeetingMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Forbid);
                                Pub._memberManage.UpdateMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Forbid);
                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("{0}禁言失败", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 解除禁言


                    case TalkControl.EnumDispatchCmdType.confUnforbidPart:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                //bc_OnMsg(string.Format("{0}呼叫{1}成功", e.FromNumber, e.ToNumber));
                                bc_OnMsg(string.Format("{0}解除禁言{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                                Pub._meetingManage.UpdateMeetingMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Busy);
                                Pub._memberManage.UpdateMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Busy);
                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("{0}解除禁言失败", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 隔离


                    case TalkControl.EnumDispatchCmdType.confIsolatePart:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                //bc_OnMsg(string.Format("{0}呼叫{1}成功", e.FromNumber, e.ToNumber));
                                bc_OnMsg(string.Format("{0}隔离{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                                Pub._meetingManage.UpdateMeetingMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Isolate);
                                Pub._memberManage.UpdateMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Isolate);
                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("{0}隔离失败", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 解除隔离


                    case TalkControl.EnumDispatchCmdType.confUnisolatePart:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                //bc_OnMsg(string.Format("{0}呼叫{1}成功", e.FromNumber, e.ToNumber));
                                bc_OnMsg(string.Format("{0}解除隔离{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                                Pub._meetingManage.UpdateMeetingMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Busy);
                                Pub._memberManage.UpdateMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Busy);
                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("{0}解除隔离失败", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 结束会议


                    case TalkControl.EnumDispatchCmdType.delConf:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                bc_OnMsg(string.Format("{0}结束会议成功", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                Pub._meetingManage.DeleteMeeting(e.ConfID);
                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("{0}结束会议失败", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.confDeleted:
                                bc_OnMsg(string.Format("{0}结束会议成功", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                //  Pub._meetingManage.DeleteMeeting(e.ConfID);
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 强插


                    case TalkControl.EnumDispatchCmdType.insertCall:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                //bc_OnMsg(string.Format("{0}呼叫{1}成功", e.FromNumber, e.ToNumber));
                                bc_OnMsg(string.Format("{0}强插{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                                Pub._memberManage.UpdateMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Insert);
                                Pub._meetingManage.UpdateMeetingMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Insert);
                                DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.Insert, e.FromNumber, e.ToNumber.ToString(), true);


                                DB_Talk.Model.Data_MemberState mstate = Pub.GetMemberModel(e.FromNumber, e.ToNumber, TalkControl.EnumUserLineStatus.Insert);

                                if (mstate != null)
                                {
                                    Pub._memberManage.UpdateMemberState(mstate.i_PeerNumber, TalkControl.EnumUserLineStatus.Insert);
                                    Pub._meetingManage.UpdateMeetingMemberState(mstate.i_PeerNumber, TalkControl.EnumUserLineStatus.Insert);
                                }

                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                bc_OnMsg(string.Format("强插释放"));
                                Pub._memberManage.UpdateMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Busy);
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("{0}强插失败", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                Pub.DeleteMemberStateByDispatchNumber(e.FromNumber, TalkControl.EnumUserLineStatus.Insert);
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 监听


                    case TalkControl.EnumDispatchCmdType.monitorCall:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                bc_OnMsg(string.Format("{0}监听{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                                Pub._memberManage.UpdateMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Listen);
                                Pub._meetingManage.UpdateMeetingMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Listen);
                                DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.Listen, e.FromNumber, e.ToNumber.ToString(), true);
                                DB_Talk.Model.Data_MemberState mstate = Pub.GetMemberModel(e.FromNumber, e.ToNumber, TalkControl.EnumUserLineStatus.Listen);
                                _dispatchCommand.btnListen.Image = DispatchPlatform.Properties.Resources.ListenIco;
                                if (mstate != null)
                                {
                                    Pub._memberManage.UpdateMemberState(mstate.i_PeerNumber, TalkControl.EnumUserLineStatus.Listen);
                                    Pub._meetingManage.UpdateMeetingMemberState(mstate.i_PeerNumber, TalkControl.EnumUserLineStatus.Listen);
                                }
                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                bc_OnMsg(string.Format("监听释放"));



                                //DB_Talk.BLL.Data_MemberState memberBLL = new DB_Talk.BLL.Data_MemberState();

                                //List<DB_Talk.Model.Data_MemberState> lstMember = new List<DB_Talk.Model.Data_MemberState>();

                                //lstMember = memberBLL.GetModelList("i_State=" + TalkControl.EnumUserLineStatus.Record.GetHashCode());

                                //foreach (DB_Talk.Model.Data_MemberState item in lstMember)
                                //{
                                //    if (item.i_DispatchNumber == e.FromNumber)
                                //    {
                                //        Pub._meetingManage.UpdateMeetingMemberState(item.i_Number.Value, TalkControl.EnumUserLineStatus.Record);
                                //        Pub._memberManage.UpdateMemberState(item.i_Number.Value, TalkControl.EnumUserLineStatus.Record);

                                //        Pub._meetingManage.UpdateMeetingMemberState(item.i_PeerNumber, TalkControl.EnumUserLineStatus.Record);
                                //        Pub._memberManage.UpdateMemberState(item.i_PeerNumber, TalkControl.EnumUserLineStatus.Record);
                                //        break;
                                //    }
                                //}

                                Pub.DeleteMemberStateByDispatchNumber(e.FromNumber, TalkControl.EnumUserLineStatus.Listen);
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("{0}监听失败", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                Pub.DeleteMemberStateByDispatchNumber(e.FromNumber, TalkControl.EnumUserLineStatus.Listen);
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 录音


                    case TalkControl.EnumDispatchCmdType.recordCall:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                bc_OnMsg(string.Format("{0}录音{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                                DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.BeginRecord, e.FromNumber, e.ToNumber.ToString(), true);

                                DB_Talk.Model.Data_MemberState mstate = Pub.GetMemberModelBySelf(e.ToNumber, TalkControl.EnumUserLineStatus.Listen);

                                if (mstate != null)
                                {
                                    Pub._memberManage.SetMemberPeeName(mstate.i_Number.Value, mstate.i_PeerNumber.ToString(), false);
                                    Pub._meetingManage.SetMeetingMemberPeeName(mstate.i_Number.Value, mstate.i_PeerNumber.ToString(), false);

                                    Pub._memberManage.SetMemberPeeName(mstate.i_PeerNumber, mstate.i_Number.Value.ToString(), false);
                                    Pub._meetingManage.SetMeetingMemberPeeName(mstate.i_PeerNumber, mstate.i_Number.Value.ToString(), false);
                                }

                                Pub._memberManage.UpdateMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Record);

                                Pub._meetingManage.UpdateMeetingMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Record);

                                SingleUserControl sc = Pub._memberManage.GetSingleControl(e.ToNumber);
                                _dispatchCommand.btnRecord.Image = DispatchPlatform.Properties.Resources.RecordIco;
                                if (sc != null)
                                {
                                    try
                                    {
                                        int.Parse(sc.PeerNumber);
                                        Pub._meetingManage.UpdateMeetingMemberState(int.Parse(sc.PeerNumber), TalkControl.EnumUserLineStatus.Record);
                                        Pub._memberManage.UpdateMemberState(int.Parse(sc.PeerNumber), TalkControl.EnumUserLineStatus.Record);
                                        Pub.WriteMemberState(e.FromNumber, e.ToNumber, long.Parse(sc.PeerNumber), TalkControl.EnumUserLineStatus.Record);
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                                else//手柄设为录音状态,外线打进来时
                                {
                                    Pub._meetingManage.UpdateMeetingMemberState(e.FromNumber, TalkControl.EnumUserLineStatus.Record);
                                    Pub._memberManage.UpdateMemberState(e.FromNumber, TalkControl.EnumUserLineStatus.Record);
                                }

                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("{0}录音失败", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 停止录音

                    case TalkControl.EnumDispatchCmdType.stopRecord:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                bc_OnMsg(string.Format("{0}停止录音{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                                DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.EndRecord, e.FromNumber, e.ToNumber.ToString(), true);




                                DB_Talk.Model.Data_MemberState mstate = Pub.GetMemberModelBySelf(e.ToNumber, TalkControl.EnumUserLineStatus.Listen);

                                if (mstate != null)
                                {
                                    Pub._meetingManage.UpdateMeetingMemberState(mstate.i_Number.Value, TalkControl.EnumUserLineStatus.Listen);
                                    Pub._memberManage.UpdateMemberState(mstate.i_Number.Value, TalkControl.EnumUserLineStatus.Listen);

                                    Pub._meetingManage.UpdateMeetingMemberState(mstate.i_PeerNumber, TalkControl.EnumUserLineStatus.Listen);
                                    Pub._memberManage.UpdateMemberState(mstate.i_PeerNumber, TalkControl.EnumUserLineStatus.Listen);
                                }
                                else
                                {
                                    mstate = Pub.GetMemberModelBySelf(e.ToNumber, TalkControl.EnumUserLineStatus.Insert);

                                    if (mstate != null)
                                    {
                                        if (Pub._memberManage.GetMemberState(mstate.i_Number.Value) == TalkControl.EnumUserLineStatus.Idle ||
                                             Pub._memberManage.GetMemberState(mstate.i_PeerNumber) == TalkControl.EnumUserLineStatus.Idle)
                                        {

                                        }
                                        else
                                        {
                                            DB_Talk.Model.Data_MemberState ms = Pub.GetMemberModelBySelf(e.ToNumber, TalkControl.EnumUserLineStatus.Record);
                                            if (ms == null)
                                            {
                                                Pub._meetingManage.UpdateMeetingMemberState(mstate.i_Number.Value, TalkControl.EnumUserLineStatus.Insert);
                                                Pub._memberManage.UpdateMemberState(mstate.i_Number.Value, TalkControl.EnumUserLineStatus.Insert);

                                                Pub._meetingManage.UpdateMeetingMemberState(mstate.i_PeerNumber, TalkControl.EnumUserLineStatus.Insert);
                                                Pub._memberManage.UpdateMemberState(mstate.i_PeerNumber, TalkControl.EnumUserLineStatus.Insert);
                                            }
                                            else
                                            {
                                                if (ms.i_PeerNumber == 0)//录音对方为空时
                                                {
                                                    Pub._meetingManage.UpdateMeetingMemberState(ms.i_Number.Value, TalkControl.EnumUserLineStatus.Insert);
                                                    Pub._memberManage.UpdateMemberState(ms.i_Number.Value, TalkControl.EnumUserLineStatus.Insert);
                                                }
                                                else
                                                {
                                                    Pub._meetingManage.UpdateMeetingMemberState(ms.i_Number.Value, TalkControl.EnumUserLineStatus.Insert);
                                                    Pub._memberManage.UpdateMemberState(ms.i_Number.Value, TalkControl.EnumUserLineStatus.Insert);

                                                    Pub._meetingManage.UpdateMeetingMemberState(ms.i_PeerNumber, TalkControl.EnumUserLineStatus.Insert);
                                                    Pub._memberManage.UpdateMemberState(ms.i_PeerNumber, TalkControl.EnumUserLineStatus.Insert);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        SingleUserControl sc = Pub._memberManage.GetSingleControl(e.ToNumber);
                                        if (sc != null)
                                        {
                                            Pub._meetingManage.UpdateMeetingMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Busy);
                                            Pub._memberManage.UpdateMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Busy);

                                            Pub._memberManage.UpdateMemberState(int.Parse(sc.PeerNumber), TalkControl.EnumUserLineStatus.Busy);
                                            Pub._meetingManage.UpdateMeetingMemberState(int.Parse(sc.PeerNumber), TalkControl.EnumUserLineStatus.Busy);
                                        }
                                    }
                                }

                                Pub.DeleteMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Record);

                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("{0}停止录音失败", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 挂断


                    case TalkControl.EnumDispatchCmdType.discCall:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                //bc_OnMsg(string.Format("{0}呼叫{1}成功", e.FromNumber, e.ToNumber));
                                bc_OnMsg(string.Format("挂断{0}成功", e.ToNumber));
                                DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.Handup, e.FromNumber, e.ToNumber.ToString(), true);
                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("挂断失败", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 转接


                    case TalkControl.EnumDispatchCmdType.deliverCall:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:

                                bc_OnMsg(string.Format("转接{0}成功", e.ToNumber));
                                SingleUserControl sc = Pub._memberManage.GetSingleControl(e.ToNumber);
                                if (sc != null)
                                {
                                    sc = Pub._memberManage.GetSingleControl(int.Parse(sc.PeerNumber));
                                    if (sc != null)
                                    {
                                        sc.IsCalling = true;
                                        sc.PeerNumber = sc.PeerNumber;
                                    }
                                }
                                DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.Transfer, e.FromNumber, e.ToNumber.ToString(), true);

                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("转接失败"));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 代答


                    case TalkControl.EnumDispatchCmdType.insteadAnswer:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                bc_OnMsg(string.Format("{0}代答{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                                // bc_OnMsg(string.Format("转接{0}成功", e.ToNumber));
                                DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.InsteadAnswer, e.FromNumber, e.ToNumber.ToString(), true);
                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("代答失败"));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 强拆


                    case TalkControl.EnumDispatchCmdType.snatchCall:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                bc_OnMsg(string.Format("{0}强拆{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                                DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.SnatchCall, e.FromNumber, e.ToNumber.ToString(), true);

                                SingleUserControl sc = Pub._memberManage.GetSingleControl(e.ToNumber);
                                if (sc != null)
                                {
                                    sc.IsCalling = false;
                                    sc.PeerNumber = e.FromNumber.ToString();
                                }

                                sc = Pub._memberManage.GetSingleControl(e.FromNumber);
                                if (sc != null)
                                {
                                    sc.IsCalling = true;
                                    sc.PeerNumber = e.ToNumber.ToString();
                                }

                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("{0}强拆失败", Pub.GetDispatchNameByNumber(e.FromNumber)));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 接听


                    case TalkControl.EnumDispatchCmdType.selectAnswer:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                //bc_OnMsg(string.Format("{0}接听{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                                // DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.SelectAnser, e.FromNumber, e.ToNumber.ToString(), true);

                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                // bc_OnMsg(string.Format("呼叫{0}失败", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }

                        break;
                    #endregion

                    #region 群答


                    case TalkControl.EnumDispatchCmdType.groupAnswer:
                        break;
                    #endregion

                    #region 保持呼叫
                    case TalkControl.EnumDispatchCmdType.holdCall:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                bc_OnMsg(string.Format("{0}保持呼叫成功", e.ToNumber));
                                DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.Keep, e.FromNumber, e.ToNumber.ToString(), true);
                                _dispatchCommand.btnKeep.Image = DispatchPlatform.Properties.Resources.KeepIco;
                                //  this._keepedNumber = e.ToNumber;
                                waitControl1.DeleteWait(e.ToNumber);
                                Pub._memberManage.UpdateMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Holding);
                                Pub._meetingManage.UpdateMeetingMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Holding);
                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));

                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("保持呼叫失败"));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 组呼


                    case TalkControl.EnumDispatchCmdType.groupCall:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                bc_OnMsg(string.Format("组呼成功"));
                                //DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.Keep, e.FromNumber, e.ToNumber.ToString(), true);
                                //_dispatchCommand.btnKeep.Image = DispatchPlatform.Properties.Resources.KeepIco;
                                ////  this._keepedNumber = e.ToNumber;
                                //waitControl1.DeleteWait(e.ToNumber);
                                //Pub._memberManage.UpdateMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Holding);
                                //Pub._meetingManage.UpdateMeetingMemberState(e.ToNumber, TalkControl.EnumUserLineStatus.Holding);
                                _dispatchCommand.btnGroupCall.Image = DispatchPlatform.Properties.Resources.icoGroupCall;
                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                bc_OnMsg(string.Format("组呼释放"));
                                _dispatchCommand.btnGroupCall.Image = null;
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                bc_OnMsg(string.Format("组呼失败"));
                                //  _dispatchCommand.btnRecord.Image = null;
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    #region 得到会议分组


                    case TalkControl.EnumDispatchCmdType.getConfList:
                        break;
                    #endregion

                    #region 得到会议成员


                    case TalkControl.EnumDispatchCmdType.getConfPartList:
                        break;
                    #endregion

                    #region 等待列表

                    case TalkControl.EnumDispatchCmdType.getWaitingUserList:
                        break;
                    #endregion

                    #region 紧急列表


                    case TalkControl.EnumDispatchCmdType.lemcGetCallList:
                        break;
                    #endregion

                    #region 接听紧急呼叫


                    case TalkControl.EnumDispatchCmdType.lemcSelectAnswer:
                        switch (e.DispatchStatus)
                        {
                            case TalkControl.EnumDispatchStatus.success:
                                bc_OnMsg(string.Format("{0}接听紧急呼叫{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                                DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.SelectLemcAnser, e.FromNumber, e.ToNumber.ToString(), true);

                                ////自启动录音
                                _baseCommand = new BeginRecordCommand();
                                SingleUserControl sc = Pub._memberManage.GetSingleControl(e.ToNumber);
                                if (sc != null)
                                {
                                    _baseCommand.MemberControl = sc;
                                }
                                else
                                {
                                    _baseCommand.MemberControl = new SingleUserControl()
                                    {
                                        Number = e.ToNumber
                                    };
                                }
                                _baseCommand.talkControl = Pub._talkControl;
                                _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                                _baseCommand.Begin();
                                break;
                            case TalkControl.EnumDispatchStatus.released:
                                break;
                            case TalkControl.EnumDispatchStatus.failure:
                                // bc_OnMsg(string.Format("接听紧急呼叫{0}失败", e.ToNumber));
                                break;
                            case TalkControl.EnumDispatchStatus.userRinging:
                                break;
                            default:
                                break;
                        }
                        break;
                    #endregion

                    default:
                        break;
                }
            }));

            // System.Console.WriteLine("结束：_talkControl_OnDispatchStateChaanged");
        }

        void _talkControl_OnLemcQueensChanged(object obj, TalkControl.LemcQueensArgs e)
        {
            //  System.Console.WriteLine("开始：_talkControl_OnLemcQueensChaanged");


            this.Invoke(new EventHandler(delegate(object o, EventArgs ee)
            {
                if (e.LemcStatus == TalkControl.EnumLemcStatus.Add)
                {
                    _lockForm.Hide();
                    Pub._lemcWaitForm.AddLemcWait(e.UserNumber);

                    if (Pub._lemcWaitForm.Visible == false)
                    {
                        Pub._lemcWaitForm.Show();
                    }
                }
            }));

            // System.Console.WriteLine("结束：_talkControl_OnLemcQueensChaanged");
        }

        void _talkControl_OnWaitingQueensChanged(object obj, TalkControl.WaitingQueensAgs e)
        {
            //   System.Console.WriteLine("开始：_talkControl_OnWaitingQueensChaanged");
            waitControl1.Invoke(new EventHandler(delegate(object o, EventArgs ee)
            {
                if (e.WaitingUserStatus == TalkControl.EnumWaitingUserStatus.Add)
                {
                    waitControl1.AddNormalWait(e.WaitingUserNumber);

                    Pub._memberManage.SetMemberState(e.WaitingUserNumber, "等待中");
                }
                else
                {
                    waitControl1.DeleteWait(e.WaitingUserNumber);
                }
            }));
            //    System.Console.WriteLine("结束：_talkControl_OnWaitingQueensChaanged");
        }

        void _talkControl_OnMemberStateChanged(object obj, TalkControl.UserStateArgs e)
        {
            System.Console.WriteLine("开始：_talkControl_OnMemberStateChanaged");
            //IntPtr i = this.Handle;

            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new EventHandler(delegate(object o, EventArgs ee)
            {
                Pub._memberManage.UpdateState(obj, e);
                Pub._meetingManage.UpdateMeeting(obj, e);
                //  Console.Write(e.ToString());
                if (waitControl1.NumberIsExits(e.UserNumber) == true
                    && e.UserLineStatus != TalkControl.EnumUserLineStatus.Idle
                    && e.UserLineStatus != TalkControl.EnumUserLineStatus.Offline
                    )
                {
                    Pub._memberManage.SetMemberState(e.UserNumber, "等待中");
                    Pub._meetingManage.SetMemberState(e.UserNumber, "等待中");
                }

                if (waitControl1.NumberIsExits(e.UserNumber) == true
                   && (e.UserLineStatus == TalkControl.EnumUserLineStatus.Idle
                   || e.UserLineStatus == TalkControl.EnumUserLineStatus.Offline)
                   )
                {
                    waitControl1.DeleteWait(e.UserNumber);
                    Pub._lemcWaitForm.DeleteWait(e.UserNumber);
                }

                if (Pub._lemcWaitForm != null)
                {
                    if ((e.UserNumber == cLeft.Number || e.UserNumber == cRight.Number) && e.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                    {
                        if (Pub._lemcWaitForm.WaitUserCount > 0)
                        {
                            Pub._lemcWaitForm.ResetCallState();
                        }
                        else
                        {
                            if (waitControl1.WaitUserCount > 0)
                            {
                                waitControl1.ResetCallState();
                            }
                        }
                    }
                    Pub._lemcWaitForm.UpdateMemberState(obj, e);
                }

                if (e.UserHookStatus == TalkControl.EnumUserHookStatus.ON && e.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)//手柄 摘机状态
                {
                    SetDispatchButtonState(e.UserNumber);
                }
                Pub.waitMsg = string.Format("正在获取号码【{0}】的状态信息", e.UserNumber);
                //   System.Console.WriteLine("Ab");

                DB_Talk.Model.m_Member model = _lstMember.Find(p => p.i_Number == e.UserNumber);
                if (model != null)
                {
                    _lstMember.Remove(model);
                }

                //为了解决Box在接队列时返回不正使用的补救方法
                if ((e.UserNumber == cLeft.Number || e.UserNumber == cRight.Number) && e.UserLineStatus == TalkControl.EnumUserLineStatus.Busy)
                {
                    DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.SelectAnser, e.UserNumber, e.PeerPartNumber.ToString(), true);
                }

                if (e.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                {
                    Pub.DeleteMemberState(e.UserNumber);
                    try
                    {
                        if (e.UserNumber == Convert.ToInt32(panelVideoBox.Tag))
                        {
                            lblVideoNumber.Text = "";//清除号码信息
                            panelVideoBox.Visible = false;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

                //将当前号码属于那个基站记录在号码表中
                //System.Console.WriteLine("sdf" + e.FapIP);
                // DispatchPlatform.TalkControl.EnumEquipmentType type=    Pub._talkControl.GetEquipmentType();
                SingleUserControl sc = Pub._memberManage.GetSingleControl(e.UserNumber);
                if (sc != null && e.FapIP != "0.0.0.0")
                {
                    //if (sc.FapIP != e.FapIP || e.UserLineStatus == TalkControl.EnumUserLineStatus.Offline)
                    //{
                    sc.FapIP = e.FapIP;

                    if (Pub.DicFap.ContainsKey(e.FapIP))
                    {
                        int fapID = Pub.DicFap[e.FapIP];
                        DB_Talk.Model.m_Member mem = new DB_Talk.BLL.m_Member().GetModel(sc.ID);
                        if (mem != null)
                        {

                            if (e.UserLineStatus == TalkControl.EnumUserLineStatus.Offline)
                            {
                                mem.FapID = 0;
                            }
                            else
                            {
                                mem.FapID = fapID;
                            }

                            new DB_Talk.BLL.m_Member().Update(mem);
                        }
                    }
                    //  }
                }
                //
                ////if (Pub.CanSort)//定时刷新在线的
                ////{
                ////    Pub._meetingManage.Sort();
                ////    Pub._memberManage.Sort();
                ////}


                SetCommandState();
            }));
            // System.Console.WriteLine("结束：_talkControl_OnMemberStateChanaged");

        }


        void _talkControl_OnHotStandbyChanged(object obj, TalkControl.HotStandbyArgs e)
        {
            this.Invoke(new EventHandler(delegate(object o, EventArgs ee)
          {
              //lblTitle.Text = e.RedUndancyWorkMode.ToString()+"_"+ e.StandyHostActiveIP ;
              CommControl.Tools.WriteLog.AppendLog(e.RedUndancyWorkMode.ToString() + "_" + e.StandyHostActiveIP + "\n\r");
              if (e.RedUndancyWorkMode == 1)
              {
                  Pub._talkControl.ReGetState();
              }
          }));
        }
        #endregion

        #region 定时器处理
        int ttt = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            _isBoxOnline = Pub._talkControl.GetBoxIsOnline();

            //不在线多判断两次
            if (_isBoxOnline == false)
            {
                System.Threading.Thread.Sleep(1000);
                _isBoxOnline = Pub._talkControl.GetBoxIsOnline();
            }

            if (_isBoxOnline == false)
            {
                System.Threading.Thread.Sleep(1000);
                _isBoxOnline = Pub._talkControl.GetBoxIsOnline();
            }

            if (_isBoxOnline)
            {
                picBoxState.Visible = true;
                picBoxState.Image = DispatchPlatform.Properties.Resources.BottomBoxOnLIne;
                lblBoxState.Text = Pub.BoxName + "连接成功";
            }
            else
            {
                picBoxState.Image = DispatchPlatform.Properties.Resources.BottomBoxOffLine;
                lblBoxState.Text = Pub.BoxName + "连接失败";

                if (Pub._lemcWaitForm != null)
                {
                    Pub._lemcWaitForm.Hide();
                }

                //  bool b = Pub._talkControl.Init(_boxModel.vc_IP, Pub._configModel.LocalIP);
                // Console.WriteLine(DateTime.Now.ToString() + "___"+ttt++);
            }

            if (_isBoxOnline == true && Pub._isDBOnline == true)
            {
                if (_isBreakNet == true)//从不在线变成在线的
                {
                    Pub._memberManage.SetAllMemberEnable(true);
                    Pub._meetingManage.SetAllMemberEnable(true);
                    bool b = Pub._talkControl.ReConnect();
                    _isBreakNet = false;
                    LoadWaitMember();
                    if (Pub._lemcWaitForm.WaitUserCount > 0)
                    {
                        Pub._lemcWaitForm.Show();
                    }
                    Pub._meetingManage.LoadTempMeeting();//加载临时的会议
                }
            }
            else
            {
                if (_isBreakNet == false)
                {
                    Pub._memberManage.SetAllMemberEnable(false);
                    Pub._meetingManage.SetAllMemberEnable(false);
                    _isBreakNet = true;
                }
            }
        }


        /// <summary>
        /// 显示时间和判断统计个数用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (_isBoxOnline)
            {
                lblIdelCount.Text = Pub._memberManage.GetMemberCountByLineState(
              _isBoxOnline, TalkControl.EnumUserLineStatus.Idle).ToString();
                lblBusyCount.Text = (Pub._memberManage.GetMemberCountByLineState(_isBoxOnline, TalkControl.EnumUserLineStatus.Busy)
                  + Pub._memberManage.GetMemberCountByLineState(_isBoxOnline, TalkControl.EnumUserLineStatus.Insert)
                  ).ToString();//摘机不算为通话

                lblHoldingCount.Text = Pub._memberManage.GetMemberCountByLineState(_isBoxOnline, TalkControl.EnumUserLineStatus.Holding).ToString();
                lblIsfordCount.Text = Pub._memberManage.GetMemberCountByLineState(_isBoxOnline, TalkControl.EnumUserLineStatus.Isolate).ToString();
                lblNoSpeekCount.Text = Pub._memberManage.GetMemberCountByLineState(_isBoxOnline, TalkControl.EnumUserLineStatus.Forbid).ToString();
                lblRecordCount.Text = Pub._memberManage.GetMemberCountByLineState(_isBoxOnline, TalkControl.EnumUserLineStatus.Record).ToString();
                lblListenCount.Text = Pub._memberManage.GetMemberCountByLineState(_isBoxOnline, TalkControl.EnumUserLineStatus.Listen).ToString();
                lblAllCount.Text = Pub._memberManage.GetAllMemberCount().ToString();
            }
            else
            {
                lblIdelCount.Text = "0";
                lblBusyCount.Text = "0";
                lblHoldingCount.Text = "0";
                lblIsfordCount.Text = "0";
                lblNoSpeekCount.Text = "0";
                lblRecordCount.Text = "0";
                lblListenCount.Text = "0";
            }


            //////没有会议成员时显示为开始状态,因为SDK没有给消息，所以用软件处理,没有正常的会议结束消息
            ////List<SingleUserControl> lstC = _currentSelectedMeetingModel.lstControl.FindAll(
            ////    p => (p.UserLineStatus == TalkControl.EnumUserLineStatus.Busy 
            ////        || p.UserLineStatus == TalkControl.EnumUserLineStatus.Forbid
            ////        || p.UserLineStatus== TalkControl.EnumUserLineStatus.Isolate
            ////        || p.UserLineStatus == TalkControl.EnumUserLineStatus.Record)
            ////        && p.IsMeeting==true
            ////        );

            ////if ((lstC != null && lstC.Count == 0) && _currentSelectedMeetingModel.MeetingState== MeetingGroupModel.EnumMeetingState.Running)
            ////{
            ////    _currentSelectedMeetingModel.MeetingState = MeetingGroupModel.EnumMeetingState.Off;
            ////    _meetingCommand.btnMeetingBeginEnd.Text = "开始会议";
            ////}
            SetCommandState();
        }
        #endregion

        #region 窗体内控件事件处理

        void OleDbHelper_StateChanged(object sender, StateChangeEventArgs e)
        {
            if (IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(new EventHandler(delegate(object o, EventArgs ee)
            {
                if (e.CurrentState == ConnectionState.Open)
                {
                    picDb.Image = DispatchPlatform.Properties.Resources.BottomDBOnLine;
                    lblDBState.Text = "数据库连接成功";
                    Pub._isDBOnline = true;
                }
                else
                {
                    picDb.Image = DispatchPlatform.Properties.Resources.BottomDBOffLine;
                    lblDBState.Text = "数据库连接失败";
                    Pub._isDBOnline = false;
                }
            }));
        }

        private void btnTelLog_Click(object sender, EventArgs e)
        {
            new TalkLog().ShowDialog();
        }

        /// <summary>调度</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void imgBtnDispatch_Click(object sender, EventArgs e)
        {
            imgBtnDispatch.FocusCuesEnabled = false;
            imgBtnDispatch.Checked = true;
            superTabControlMain.SelectedTab = superTabItemDispatch;
            imgBtnMeeting.Checked = false;
            panelCommand.Controls.Clear();
            panelCommand.Controls.Add(_dispatchCommand);
            _dispatchCommand.Dock = DockStyle.Fill;
            Pub._talkControl.CurrentNormalCMD = PublicEnums.EnumNormalCmd.None;
            _dispatchCommand.ClearSelect();
            _isDispatchTabPage = true;
            Pub._memberManage.ShowAllMember();
        }

        public void imgBtnMeeting_Click(object sender, EventArgs e)
        {
            Pub._memberManage.ShowAllMember();
            imgBtnMeeting.FocusCuesEnabled = false;
            imgBtnMeeting.Checked = true;
            superTabControlMain.SelectedTab = superTabItemMeeting;
            imgBtnDispatch.Checked = false;

            panelCommand.Controls.Clear();
            panelCommand.Controls.Add(_meetingCommand);
            _meetingCommand.Dock = DockStyle.Fill;
            _isDispatchTabPage = false;
            superTabControlMeeting.SelectedTab.RaiseClick();
            // _memberGroupIndex = 0;
        }

        /// <summary>
        /// 普通分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MemberTabItem_Click(object sender, EventArgs e)
        {
            SuperTabItem sti = sender as SuperTabItem;
            _memberGroupIndex = Convert.ToInt32(sti.Tag.ToString());
        }

        /// <summary>
        /// 设置默认的分组为第一个选中
        /// </summary>
        public void SetDefaultMemberGroupIndex()
        {
            _memberGroupIndex = 0;
        }

        /// <summary>会议TabItem点击事件</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MeetingTabItem_Click(object sender, EventArgs e)
        {
            GetCurrentMeetingModel();
            if (_currentSelectedMeetingModel.MeetingType == MeetingGroupModel.EnumMeetingType.Lemc)
            {
                // Pub._talkControl.CurrentNormalCMD = PublicEnums.EnumNormalCmd.MakeLemcMeeting;
                _baseCommand = new MakeMeetingCommand();
                _baseCommand.talkControl = Pub._talkControl;
                Pub._meetingManage.SetControlIsCanSelect(true);
            }
            else
            {
                Pub._meetingManage.SetControlIsCanSelect(false);
            }

            Pub._talkControl.CurrentMeetingID = _currentSelectedMeetingModel.MeetingID;
            switch (_currentSelectedMeetingModel.MeetingState)
            {
                case MeetingGroupModel.EnumMeetingState.Running:
                    _meetingCommand.btnMeetingBeginEnd.Text = "结束会议";
                    break;
                case MeetingGroupModel.EnumMeetingState.Off:
                    _meetingCommand.btnMeetingBeginEnd.Text = "开始会议";
                    break;
                case MeetingGroupModel.EnumMeetingState.Ready:
                    _meetingCommand.btnMeetingBeginEnd.Text = "结束会议";
                    break;
                default:
                    break;
            }

            switch (_currentSelectedMeetingModel.MeetingType)
            {
                case MeetingGroupModel.EnumMeetingType.Formal:
                    _meetingCommand.btnDeleteMeetingMember.Text = "挂断";

                    break;
                case MeetingGroupModel.EnumMeetingType.Temp:
                    _meetingCommand.btnMeetingBeginEnd.Text = "结束会议";
                    break;
                case MeetingGroupModel.EnumMeetingType.Lemc:

                    //if (_currentSelectedMeetingModel.MeetingState == MeetingGroupModel.EnumMeetingState.Running)
                    //{
                    //    _meetingCommand.btnDeleteMeetingMember.Text = "挂断";
                    //}
                    _meetingCommand.btnDeleteMeetingMember.Text = "踢出";
                    break;
                default:
                    break;
            }


        }

        /// <summary>退出</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cLeft_Click(object sender, EventArgs e)
        {
            SingleUserControl ss = (SingleUserControl)sender;

            if (Pub._talkControl.CurrentNormalCMD == PublicEnums.EnumNormalCmd.Handup || Pub._talkControl.CurrentNormalCMD == PublicEnums.EnumNormalCmd.DeleteMeetingMember)
            {
                _dispatchCommand.ClearSelect();
                _meetingCommand.ClearSelect();

                _baseCommand = new HandupCommand();
                _baseCommand.MemberControl = ss;
                _baseCommand.talkControl = Pub._talkControl;
                _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                _baseCommand.Begin();
                if (Pub._talkControl.CurrentNormalCMD != CommControl.PublicEnums.EnumNormalCmd.MakeLemcMeeting)
                {
                    Pub._talkControl.CurrentNormalCMD = CommControl.PublicEnums.EnumNormalCmd.None;
                }
                Pub._memberManage.ShowAllMember();
            }
            else
            {
                if (cLeft.UserLineStatus != TalkControl.EnumUserLineStatus.Offline)
                {
                    Pub._talkControl.CurrentDispatchNumber = ss.Number;
                    cLeft.Checked = true;
                    cRight.Checked = false;
                }
                Pub.CurrentDispatchControl = ss;
            }
        }

        private void cRight_Click(object sender, EventArgs e)
        {
            SingleUserControl ss = (SingleUserControl)sender;
            if (Pub._talkControl.CurrentNormalCMD == PublicEnums.EnumNormalCmd.Handup || Pub._talkControl.CurrentNormalCMD == PublicEnums.EnumNormalCmd.DeleteMeetingMember)
            {
                _dispatchCommand.ClearSelect();
                _meetingCommand.ClearSelect();

                _baseCommand = new HandupCommand();
                _baseCommand.MemberControl = ss;
                _baseCommand.talkControl = Pub._talkControl;
                _baseCommand.OnMsg += new BaseCommand.MsgDelegate(bc_OnMsg);
                _baseCommand.Begin();
                if (Pub._talkControl.CurrentNormalCMD != CommControl.PublicEnums.EnumNormalCmd.MakeLemcMeeting)
                {
                    Pub._talkControl.CurrentNormalCMD = CommControl.PublicEnums.EnumNormalCmd.None;
                }
                Pub._memberManage.ShowAllMember();
            }
            else
            {
                if (cRight.UserLineStatus != TalkControl.EnumUserLineStatus.Offline)
                {
                    Pub._talkControl.CurrentDispatchNumber = ss.Number;
                    cLeft.Checked = false;
                    cRight.Checked = true;
                }
                Pub.CurrentDispatchControl = ss;
            }
        }

        /// <summary>锁定</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            // this.Visible = false;
            if (_lockForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //this.Visible = true;
            }
        }

        private void btnSortByName_Click(object sender, EventArgs e)
        {
            Pub._configModel.SortByName = btnSortByName.Checked;
            Config.WriteModel(Pub._configModel);
            Pub._meetingManage.Sort();
            Pub._memberManage.Sort();
        }

        private void btnSortByDepartment_Click(object sender, EventArgs e)
        {
            Pub._configModel.SortByDepartment = btnSortByDepartment.Checked;
            Config.WriteModel(Pub._configModel);
            Pub._meetingManage.Sort();
            Pub._memberManage.Sort();
        }

        private void 行3列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in contextMenuStrip1.Items)
            {
                item.Checked = false;
            }
            ToolStripMenuItem tmi = (ToolStripMenuItem)sender;
            tmi.Checked = true;
            string[] strS = tmi.Tag.ToString().Split(',');
            int col = 0;
            int row = 0;
            if (strS.Length == 2)
            {
                row = int.Parse(strS[0]);
                col = int.Parse(strS[1]);
                Pub.GetFontSizeConfig(col);


                Pub._memberManage.SetPageSize(col, row);
                Pub._meetingManage.SetPageSize(col, row);
                Pub._configModel.ShowRows = row;
                Pub._configModel.ShowColums = col;
                Config.WriteModel(Pub._configModel);
            }
            _popMenuShow = false;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            Point p = btnSet.Location;
            p.Y = p.Y + btnSet.Height;
            if (_popMenuShow == false)
            {
                contextMenuStrip1.Show(p);
                _popMenuShow = true;
            }
            else
            {
                contextMenuStrip1.Hide();
                _popMenuShow = false;
            }

        }

        private void btnClallKeyborad_Click(object sender, EventArgs e)
        {
            FormCallKeyborad kb = new FormCallKeyborad(Pub._talkControl);
            kb.OnMsg += new FormCallKeyborad.MsgDelegate(bc_OnMsg);
            kb.ShowDialog();
        }

        private void chkSortByNumber_CheckedChanged(object sender, EventArgs e)
        {
            Pub._configModel.SortByNumber = chkSortByNumber.Checked;
            Config.WriteModel(Pub._configModel);
            Pub._meetingManage.Sort();
            Pub._memberManage.Sort();
        }

        private void chkSortByOnline_CheckedChanged(object sender, EventArgs e)
        {
            Pub._configModel.SortByOnline = chkSortByOnline.Checked;
            Config.WriteModel(Pub._configModel);
            Pub._meetingManage.Sort();
            Pub._memberManage.Sort();
        }

        private void chkSortByName_CheckedChanged(object sender, EventArgs e)
        {
            Pub._configModel.SortByName = chkSortByName.Checked;
            Config.WriteModel(Pub._configModel);
            Pub._meetingManage.Sort();
            Pub._memberManage.Sort();
        }
        #endregion

        #region 视频事件
        void HTphoneRegistrationStateChangedCb(HTPhoneSDK.HTphoneRegistrationState cstate, string message)
        {
            this.Invoke(new EventHandler(delegate(object o, EventArgs ee)
            {
                //lblRegisterState.Text = cstate.ToString();
                switch (cstate)
                {
                    case HTPhoneSDK.HTphoneRegistrationState.HTphoneRegistrationNone:
                        //bc_OnMsg(string.Format("{0}呼叫{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                        break;
                    case HTPhoneSDK.HTphoneRegistrationState.HTphoneRegistrationProgress:
                        bc_OnMsg("视频号码注册中");
                        break;
                    case HTPhoneSDK.HTphoneRegistrationState.HTphoneRegistrationOk:
                        bc_OnMsg("视频号码注册成功");
                        break;
                    case HTPhoneSDK.HTphoneRegistrationState.HTphoneRegistrationCleared:
                        break;
                    case HTPhoneSDK.HTphoneRegistrationState.HTphoneRegistrationFailed:
                        bc_OnMsg("视频号码注册失败");
                        break;
                    default:
                        break;
                }

            }));

        }

        void HTphoneCallStateChangedCb(HTPhoneSDK.HTphoneCallState cstate, string from, string message)
        {
            _fromNumberForVideo = from;
            this.Invoke(new EventHandler(delegate(object o, EventArgs ee)
            {
                switch (cstate)
                {
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallIdle:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallIncomingReceived:
                        // int i = HTPhoneSDK.htphone_accept_call();
                        if (MessageBoxEx.Show(string.Format("{0}来电，是否接听？", _fromNumberForVideo), "来电通知", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            int i = HTPhoneSDK.htphone_accept_call();

                        }
                        else
                        {
                            int j = HTPhoneSDK.htphone_reject_call();
                        }
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallOutgoingInit:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallOutgoingProgress:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallOutgoingRinging:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallOutgoingEarlyMedia:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallStreamsRunning:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallPausing:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallPaused:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallResuming:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallRefered:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallError:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallEnd:
                        panelVideoBox.Visible = false;
                        _popVideoForm.Hide();
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallPausedByRemote:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallUpdatedByRemote:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallIncomingEarlyMedia:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallUpdating:
                        break;
                    case HTPhoneSDK.HTphoneCallState.HTphoneCallReleased:
                        break;
                    default:
                        break;
                }

            }));

        }
        #endregion
        #endregion

        #region 公共方法
        /// <summary>
        /// 窗体显示完执行
        /// </summary>
        public void ShowLoadOk()
        {
            bool b = Pub._talkControl.Init(_boxModel.vc_IP, Pub._configModel.LocalIP);



            //设置为不自动接听普通队列  用软件来接听
            b = Pub._talkControl.SetAnserType(false);
            timer1_Tick(null, null);

            SetCommandState();
            // SetMenuSelect();


            Pub._pageControl = Pub._meetingManage.GetToSelectPageControl();

            Pub._lemcWaitForm = new FormLemcWait();
            Pub._lemcWaitForm.OnSelect += new FormLemcWait.SelectWaitDelgate(_lemcWaitForm_OnSelect);
            Pub._lemcWaitForm.Show();
            Pub._lemcWaitForm.Hide();
            _checkDbThread.Run();

            #region IPBorcast
            if (Pub._configModel.IsIpBrocast)
            {
                imgBtnBroadcast.Visible = true;
            }
            else
            {
                imgBtnBroadcast.Visible = false;
            }
            #endregion
        }

        /// <summary>
        /// 设置选中左右席和加载状态
        /// </summary>
        public void SetDispatchAndLoadState()
        {
            ///这里只执行一次
            if (_isFirstSetDispatch == true)
            {
                if (cLeft.UserLineStatus != TalkControl.EnumUserLineStatus.Offline)
                {
                    cLeft.Checked = true;
                    Pub._talkControl.CurrentDispatchNumber = cLeft.Number;
                    Pub.CurrentDispatchControl = cLeft;
                }
                else
                {
                    if (cRight.UserLineStatus != TalkControl.EnumUserLineStatus.Offline)
                    {
                        cRight.Checked = true;
                        Pub._talkControl.CurrentDispatchNumber = cRight.Number;
                        Pub.CurrentDispatchControl = cRight;
                    }
                    else
                    {
                        cLeft.Checked = true;
                        Pub._talkControl.CurrentDispatchNumber = cLeft.Number;
                        Pub.CurrentDispatchControl = cLeft;
                    }
                }
                Pub._meetingManage.LoadTempMeeting();//加载临时的会议
                LoadWaitMember();
                RestoreMemberState();
                _isFirstSetDispatch = false;
            }
        }

        /// <summary>设置排序Button</summary>
        public void SetSortButton()
        {
            if (Pub._configModel.SortByDepartment)
            {
                btnSortByDepartment.Checked = true;
                btnSortByDepartment_Click(null, null);
            }
            if (Pub._configModel.SortByName)
            {
                chkSortByName.Checked = true;
                chkSortByName_CheckedChanged(null, null);
            }
            if (Pub._configModel.SortByNumber)
            {
                chkSortByNumber.Checked = true;
                chkSortByNumber_CheckedChanged(null, null);
            }
            if (Pub._configModel.SortByOnline)
            {
                chkSortByOnline.Checked = true;
                chkSortByOnline_CheckedChanged(null, null);
            }
        }
        #endregion

        #region 私有方法

        private string GetDispatchNameByNumber(int number)
        {
            if (number == Pub.manageModel.LeftDispatchNumber)
            {
                return Pub.manageModel.LeftDispatchName;
            }
            if (number == Pub.manageModel.RightDispatchNumber)
            {
                return Pub.manageModel.RightDispatchName;
            }
            return "";
        }



        /// <summary>
        /// 自动选择需要的调度手柄
        /// </summary>
        private void AutoSelectDispatchNumber()
        {
            if (_currentSelectedMeetingModel.DispatchNumber == cLeft.Number)
            {
                cLeft_Click(cLeft, null);
            }

            if (_currentSelectedMeetingModel.DispatchNumber == cRight.Number)
            {
                cRight_Click(cRight, null);
            }
        }



        /// <summary>
        /// 获取要创建的临时会议名称
        /// </summary>
        /// <returns></returns>
        private string GetTempMeetingName()
        {
            _tmpMeetingCount++;
            if (_tmpMeetingCount >= 9)
            {
                _tmpMeetingCount = 1;
            }
            return string.Format("临时会议{0}", _tmpMeetingCount);
        }

        /// <summary>操作命令返回消息</summary>
        /// <param name="msg"></param>
        void bc_OnMsg(string msg)
        {
            //  Console.WriteLine(DateTime.Now.ToString());
            System.Console.WriteLine("开始：bc_OnMsg");
            operateLog1.Invoke(new EventHandler(delegate(object o, EventArgs e)
            {
                operateLog1.AddMsgAutoAddDateTime(msg);
            }));
            System.Console.WriteLine("结束：bc_OnMsg");
        }

        /// <summary>设置菜单选中状态 </summary>
        public void SetMenuSelect()
        {
            foreach (ToolStripMenuItem item in contextMenuStrip1.Items)
            {
                if (item.Tag.ToString() == Pub._configModel.ShowRows + "," + Pub._configModel.ShowColums)
                {
                    item.Checked = true;
                    item.PerformClick();
                }
                else
                {
                    item.Checked = false;
                }
            }

            foreach (ToolStripMenuItem item in popMenuVideo.Items)
            {
                if (item.Tag.ToString() == Pub._configModel.VideoSize.ToString())
                {
                    item.Checked = true;
                    //item.PerformClick();
                }
                else
                {
                    item.Checked = false;
                }
            }
        }

        /// <summary>从Mbox获取等待用户</summary>
        private void LoadWaitMember()
        {
            List<long> lst = Pub._talkControl.GetWaitMemberList(Pub.manageModel.LeftDispatchNumber.Value);
            waitControl1.DeleteAllMember();
            foreach (int item in lst)
            {
                waitControl1.AddNormalWait(item);
            }

            lst = Pub._talkControl.GetLemcMemberList(Pub.manageModel.LeftDispatchNumber.Value);
            foreach (int item in lst)
            {
                Pub._lemcWaitForm.AddLemcWait(item);
                Pub._lemcWaitForm.Show();
            }
        }

        /// <summary>恢复用户状态</summary>
        private void RestoreMemberState()
        {

            ///从数据库读取上次的状态信息
            List<DB_Talk.Model.Data_MemberState> lstMember = new DB_Talk.BLL.Data_MemberState().GetModelList("");
            foreach (DB_Talk.Model.Data_MemberState item in lstMember)
            {

                TalkControl.EnumUserLineStatus state = (TalkControl.EnumUserLineStatus)item.i_State;
                if (state == TalkControl.EnumUserLineStatus.Insert)
                {
                    Pub.DeleteMemberState(item.i_Number.Value, state);
                }

                if (state == TalkControl.EnumUserLineStatus.Listen)
                {
                    if (Pub._memberManage.GetMemberState(item.i_Number.Value) == TalkControl.EnumUserLineStatus.Busy &&
                        (Pub._memberManage.GetMemberState(item.i_DispatchNumber.Value) == TalkControl.EnumUserLineStatus.Busy
                        || Pub._memberManage.GetMemberState(item.i_DispatchNumber.Value) == TalkControl.EnumUserLineStatus.HookOn)
                        )
                    {
                        Pub._memberManage.UpdateMemberState(item.i_Number.Value, state);
                        Pub._meetingManage.UpdateMeetingMemberState(item.i_Number.Value, state);

                        Pub._memberManage.UpdateMemberState(item.i_PeerNumber, state);
                        Pub._meetingManage.UpdateMeetingMemberState(item.i_PeerNumber, state);
                    }
                    else
                    {
                        Pub.DeleteMemberState(item.i_Number.Value);
                    }
                }

                if (state == TalkControl.EnumUserLineStatus.Record)
                {
                    SingleUserControl sc = Pub._memberManage.GetSingleControl(item.i_Number.Value);
                    if (sc != null)
                    {
                        if (sc.UserLineStatus == TalkControl.EnumUserLineStatus.Busy && sc.UserRecordStatus == TalkControl.EnumRecordStatus.ON)
                        {
                            Pub._memberManage.UpdateMemberState(item.i_Number.Value, state);
                            Pub._meetingManage.UpdateMeetingMemberState(item.i_Number.Value, state);

                            Pub._memberManage.UpdateMemberState(item.i_PeerNumber, state);
                            Pub._meetingManage.UpdateMeetingMemberState(item.i_PeerNumber, state);
                        }
                        else
                        {
                            Pub.DeleteMemberState(item.i_Number.Value);
                        }
                    }
                }

            }
        }

        /// <summary>设置调度摘机状态</summary>
        /// <param name="number"></param>
        private void SetDispatchButtonState(long number)
        {
            if (cLeft.Number == number)
            {
                cLeft_Click(cLeft, null);
                cLeft.UserLineStatus = TalkControl.EnumUserLineStatus.HookOn;
            }

            if (cRight.Number == number)
            {
                cRight_Click(cRight, null);
                cRight.UserLineStatus = TalkControl.EnumUserLineStatus.HookOn;
            }

        }

        /// <summary>从当前选中的Tab页面上获取，会议分组信息</summary>
        private void GetCurrentMeetingModel()
        {

            if (superTabControlMeeting.SelectedTab != null)
            {
                superTabControlMeeting.SelectedTab.RaiseClick();
                _currentSelectedMeetingModel = (MeetingGroupModel)superTabControlMeeting.SelectedTab.Tag;
            }
            else
            {
                _currentSelectedMeetingModel = null;
            }
        }

        /// <summary>恢复会议操作按钮</summary>
        private void RestoreMeetingButtonState()
        {
            _meetingCommand.btnMeetingBeginEnd.Enabled = true;
            _dispatchCommand.btnMeeting.Enabled = true;
        }

        /// <summary>为了验证所有消息收到</summary>
        private void LoadAllUser()
        {
            _lstMember = new DB_Talk.BLL.m_Member().GetModelList(string.Format("i_Flag=0 and BoxID={0}", Pub.manageModel.BoxID.Value));
        }

        /// <summary>清除保持，录音，监听的按钮状态</summary>
        private void SetCommandState()
        {
            if (Pub._memberManage.GetMemberCountByLineState(_isBoxOnline, TalkControl.EnumUserLineStatus.Holding) == 0)
            {
                _dispatchCommand.btnKeep.Image = null;
            }
            else
            {
                _dispatchCommand.btnKeep.Image = DispatchPlatform.Properties.Resources.KeepIco;
            }

            if (Pub._memberManage.GetMemberCountByLineState(_isBoxOnline, TalkControl.EnumUserLineStatus.Listen) == 0)
            {
                _dispatchCommand.btnListen.Image = null;
            }
            else
            {
                _dispatchCommand.btnListen.Image = DispatchPlatform.Properties.Resources.ListenIco;
            }


            if (Pub._memberManage.GetMemberCountByLineState(_isBoxOnline, TalkControl.EnumUserLineStatus.Record) == 0)
            {
                _dispatchCommand.btnRecord.Image = null;
            }
            else
            {
                _dispatchCommand.btnRecord.Image = DispatchPlatform.Properties.Resources.RecordIco;
            }

        }

        /// <summary>找到可接听的调度号码</summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private void AutoSelectIdelDispatch()
        {
            //先判断选的的优先接听

            if (cRight.Checked)
            {
                if (cRight.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                {
                    cRight_Click(cRight, null);
                    return;
                }

                if (cLeft.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                {
                    cLeft_Click(cLeft, null);
                    return;
                }

                if (cRight.UserLineStatus == TalkControl.EnumUserLineStatus.HookOn)
                {
                    cRight_Click(cRight, null);
                    return;
                }

                if (cLeft.UserLineStatus == TalkControl.EnumUserLineStatus.HookOn)
                {
                    cLeft_Click(cLeft, null);
                    return;
                }
            }
            else
            {
                if (cLeft.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                {
                    cLeft_Click(cLeft, null);
                    return;
                }

                if (cRight.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                {
                    cRight_Click(cRight, null);
                    return;
                }

                if (cLeft.UserLineStatus == TalkControl.EnumUserLineStatus.HookOn)
                {
                    cLeft_Click(cLeft, null);
                    return;
                }

                if (cRight.UserLineStatus == TalkControl.EnumUserLineStatus.HookOn)
                {
                    cRight_Click(cRight, null);
                    return;
                }
            }
        }
        #endregion

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnVideoSize_Click(object sender, EventArgs e)
        {
            Point p = btnVideoSize.Location;
            p.Y = p.Y + btnVideoSize.Height;
            if (_popMenuVideShow == false)
            {
                popMenuVideo.Show(p);
                _popMenuVideShow = true;
            }
            else
            {
                popMenuVideo.Hide();
                _popMenuVideShow = false;
            }

        }

        /// <summary>
        /// 设置视频大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in popMenuVideo.Items)
            {
                item.Checked = false;
            }

            ToolStripMenuItem tmi = (ToolStripMenuItem)sender;
            int i = Convert.ToInt32(tmi.Tag);


            int r = HTPhoneSDK.htphone_set_preferred_video_size(i);
            Pub._configModel.VideoSize = i;
            Config.WriteModel(Pub._configModel);
            tmi.Checked = true;
            _popMenuVideShow = false;
        }

  
   

    }

    /// <summary>
    /// 文字大小设置
    /// </summary>
    public class FontSizeConfig
    {
        /// <summary>
        /// 字体大小
        /// </summary>
        public float NumberNameFontSize { get; set; }

        //public int NumberNameLeft { get; set; }
        public int NumberNameTop { get; set; }

        /// <summary>
        /// 间距
        /// </summary>
        public int NumberNameInteval { get; set; }

        ////调度字体大小
        //public float DisPatchFontSize { get; set; }

        //public int DisPatchControlWidth { get; set; }

        //public int DisPathcControlHeight { get; set; }
    }
}
