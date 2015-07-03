using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using DispatchPlatform.Command;
using MBoxSDK;

namespace DispatchPlatform
{
    public class TalkControl
    {

       



        #region 变量

        /// <summary>
        /// 当前命令
        /// </summary>
        public CommControl.PublicEnums.EnumNormalCmd CurrentNormalCMD = new CommControl.PublicEnums.EnumNormalCmd();
        /// <summary>返回结果</summary>
        TalkSDK.OPERATE_RESULT t;
        public int handle = 0;
        
        #endregion

        #region 枚举

        //设备类型宏定义
        public enum EnumEquipmentType
        {
            T_HT8000B = 3,
            T_HT8000C=4,
            T_HT8000D=5,
            T_HT8000E=6,
            T_HT8000_3G=7
        }
      

        /// <summary>会议成员状态</summary>
        public enum EnumConfUserState
        {
            DU_ST_NULL = 0,     		//空闲，未加入用户号码
            DU_ST_WAIT_PROCESS = 1,		//尚未执行呼叫流程
            DU_ST_CALL_PROCEEDING = 2,	//呼叫过程中
            DU_ST_RINGING = 3,			//正在振铃
            /// <summary>建立连接，通话过程中</summary>
            DU_ST_CONNECTED = 4,		//建立连接，通话过程中
            DU_ST_DISCONNECTED = 5,		//断开连接或呼叫失败
            DU_ST_MONITORING = 6,			//监听台的状态
            DU_ST_RECORDING = 7,			//录音台的状态
            DU_ST_FORBIDED = 8,				//被禁言的会议成员
            DU_ST_ISOLATED = 9			   //被隔离的会议成员
        }

        /// <summary>表示用户进入和移出队列的状态</summary>
        public enum EnumWaitingUserStatus
        {
            //uLemcStatus表示用户进入和移出紧急呼叫队列的状态,
            //uWaitingUserStatus,
            //    0: 无状态
            // 1: 用户进入等待队列(add)
            // 2: 用户离开等待队列(remove)   
            /// <summary>
            /// 无状态
            /// </summary>
            None = 0,
            /// <summary>
            /// 用户进入等待队列(add)
            /// </summary>
            Add = 1,
            /// <summary>
            /// 用户离开等待队列(remove) 
            /// </summary>
            ReMove = 2
        }

        /// <summary>表示用户进入和移出紧急呼叫队列的状态</summary>
        public enum EnumLemcStatus
        {
            //uLemcStatus表示用户进入和移出紧急呼叫队列的状态,
            //uWaitingUserStatus表示用户进入和移出队列的状态,
            //    0: 无状态
            // 1: 用户进入等待队列(add)
            // 2: 用户离开等待队列(remove)   
            /// <summary>
            /// 无状态
            /// </summary>
            None = 0,
            /// <summary>
            /// 用户进入等待队列(add)
            /// </summary>
            Add = 1,
            /// <summary>
            /// 用户离开等待队列(remove) 
            /// </summary>
            ReMove = 2
        }

        /// <summary>用户线路状态</summary>
        public enum EnumUserLineStatus
        {
            None=-1,
            /// <summary>当前用户空闲</summary>
            Idle = 0,
            /// <summary>//忙</summary>
            Busy = 1,
            /// <summary>振铃</summary>
            Ring = 2,
            /// <summary>寻呼</summary>
            Paging = 3,
            /// <summary>//关机</summary>
            Poweroff = 4,
            /// <summary>//正在向外打电话</summary>
            Outcalling = 5,
            /// <summary>//保持通话</summary>
            Holding = 6,
            /// <summary>//正在等待队列中</summary>
            Blocked = 7,
            /// <summary>//不在线</summary>
            Offline = 8,
            /// <summary>// 在线 </summary>
            Online = 9,
            /// <summary>
            /// 强插程序显示用，与Mbox内部无关
            /// </summary>
            Insert=100,
            /// <summary>
            ///监听程序显示用，与Mbox内部无关
            /// </summary>
            Listen=101,
            /// <summary>
            /// 录音程序显示用，与Mbox内部无关
            /// </summary>
            Record=102,
            /// <summary>
            /// 隔离显示用，与Mbox内部无关
            /// </summary>
            Isolate= 103,
            /// <summary>
            /// 禁言显示用，与Mbox内部无关
            /// </summary>
            Forbid = 104,
            /// <summary>
            /// 摘机状态
            /// </summary>
            HookOn=105
        }

        /// <summary>调度执行状态</summary>
        public enum EnumDispatchStatus
        {
            success = 0, // --Complete dispatch command, result is success 调度成功
            released = 254,// --Transaction is released.会议释放
            failure = 255,// --Complete dispatch command, result is failure.调度失败

            userRinging = 1,//  --User is ringing 用户正在振铃
            userConnected = 2,//  --Succeed to establish connection with the user 
            userDisconnected = 3,//  --User disconnected
            userRedirected = 4,//  --User is redirected to another number
            userHold = 5,//  --User is held and in holding state
            userCallFail = 6,//  --Failed to establish connection with the user.

            confCreated = 30,//  --Conference is created. 
            confDeleted = 31,//  --Conference is deleted. 
            confAddPart = 32,//  --A part is added to the conference
            confDelPart = 33,//  --A part is deleted from the conference
            confAddPartFail = 34,//  --Failed to add part to the conference. 增加会议成员失败
            confAddMonitor = 35,//  --A monitor is added to the conference  
            confDelMonitor = 36,//  --A monitor is deleted from the conference
            confAddRecorder = 37,//  --A recorder is added to the conference
            confDelRecorder = 38,//  --A recorder is deleted from the conference  
        }

        /// <summary>调度命令类型</summary>
        public enum EnumDispatchCmdType
        {
            makeCall = 1,//  --呼叫，包括普通调度台呼叫用户，已经话务员呼叫用户。话务员可以在hold状态呼叫用户
            createConf = 2,//  --创建会议
            confAddPart = 3,//  --添加会议成员
            confDelPart = 4,//  --踢出会议成员
            confForbidPart = 5,//  --禁言
            confUnforbidPart = 6,//  --解除禁言
            confIsolatePart = 7,//  --隔离
            confUnisolatePart = 8,//  --解除隔离
            delConf = 9,//  --结束会议
            insertCall = 10,//  --强插
            monitorCall = 11,//  --监听
            recordCall = 12,//  --录音
            stopRecord = 13,//  --停止录音
            discCall = 14,//  --强挂
            deliverCall = 15,//  --转接
            insteadAnswer = 16,//  --代答
            snatchCall = 17,//  --强拆
            selectAnswer = 18,//  --应答，话务员应答等待队列里面的呼叫
            groupAnswer = 19,//  --群答，话务员群答等待队列里面的呼叫 
            holdCall = 20,//  --保持呼叫，把话务员当前呼叫放入到等待队列里面
            groupCall = 22,//  --群呼          
            getConfList = 29,//  --获取调度台所管理的会议列表
            getConfPartList = 30,//  --获取会议成员列表
            getWaitingUserList = 31,//  --获取等待队列号码列表 
            lemcGetCallList = 40,//  --获取内部紧急呼机主叫号码列表 
            lemcSelectAnswer = 41,//  --应答，调度员应答内部紧急呼叫队列里面的呼叫
        }

        /// <summary>调度失败原因</summary>
        public enum EnumuDispatchErrorCause
        {
            noError = 0,

            //--common error cause               
            errorParameter = 1,
            errorCmdType = 2,
            invalidInDispatcherCurrentState = 3,
            invalidInTphistCurrentState = 4,
            invalidInUserCurrentState = 5,
            transactionIsReleased = 6,
            memAllocFail = 7,
            memDeallocFail = 8,
            msgSendFail = 9,
            numberEmpty = 10,
            serviceNotSupport = 11,
            noPrivilege = 12,
            noMatchedUser = 13,
            insertCallFail = 14,
            monitorCallFail = 15,
            recordCallFail = 16,
            stopRecordFail = 17,
            stopMonitorFail = 18,
            tphistIsBusy = 19,
            noIdleTphist = 20,
            noIdleRecorder = 21,

            //--dispatched user error cause      =
            userNotExist = 22,
            userNotIdle = 23,
            userNotConnected = 24,
            userNotRinging = 25,
            userNotBusy = 26,
            userIsIdle = 27,
            userIsConnected = 28,
            userIsRinging = 29,
            userIsBusy = 30,
            userIsDisconnected = 31,
            userIsPowerOff = 32,
            userIsOffLine = 33,
            userConnFail = 34,
            userNoRsp = 35,
            userNoAnswer = 36,

            //--dispatch station error cause     
            dispatcherNotIdle = 37,
            dispatcherNotConnected = 38,
            dispatcherNotRinging = 39,
            dispatcherNotBusy = 40,
            dispatcherIsIdle = 41,
            dispatcherIsConnected = 42,
            dispatcherIsRinging = 43,
            dispatcherIsBusy = 44,
            dispatcherIsDisconnected = 45,
            dispatcherIsPowerOff = 46,
            dispatcherIsOffLine = 47,
            dispatcherConnFail = 48,
            dispatcherNoRsp = 49,
            dispatcherNoAnswer = 50,

            //--conference operation error cause 
            confNoEnoughPart = 51,
            confFull = 52,
            confNoMatchedPart = 53,
            confCannotDelOwner = 54,
            confNotExist = 55,
            confAlreadyExist = 56,
            confCreateFail = 57,
            confDelFail = 58,
            confAddPartFail = 59,
            confDelPartFail = 60,
            confInvalidOperation = 61,

            //--waiting queue operation error cause   
            waitQueueFull = 62,
            waitQueueEmpty = 63,
            waitQueueNoMatchedUser = 64,

            //--default error cause              
            unknown = 255
        }

        /// <summary>用户录音状态</summary>
        public enum EnumRecordStatus
        {
            //unsigned int uRecordingStatus;      //用户录音状态    0不在录音   
            //unsigned int uHookOffStatus;         //用户摘机状态(保留)
            ON = 1,
            OFF = 0
        }

        /// <summary> 用户摘机状态</summary>
        public enum EnumUserHookStatus
        {
            ON = 1,
            OFF = 0

        }
        #endregion

        #region 属性
     
        /// 当前调度号码</summary>
        public long CurrentDispatchNumber  { get; set; }

        /// <summary>当前会议ID</summary>
        public int CurrentMeetingID { get; set; }

        /// <summary>会议成员号码列表</summary>
        public List<DB_Talk.Model.m_Member> NumberList = new List<DB_Talk.Model.m_Member>();

        #endregion

        #region 事件

        /// <summary>用户状态事件参数</summary>
        public class UserStateArgs : EventArgs
        {
            //unsigned int uSubscriberNumber;     //用户号码
            //unsigned int uPeerPartNumber;      //对方号码
            //unsigned int uSubscriberStatus;       //用户线路状态
            //unsigned int uRecordingStatus;      //用户录音状态    0不在录音   
            //unsigned int uHookOffStatus;         //用户摘机状态(保留)
            //unsigned int uDispatchConfId;         //调度会议ID
            //unsigned int uEventTimeStamp;      //时间帧
            //Char chEventAdditionalInfo [64];      //调度附加信息

            /// <summary>用户摘机状态</summary>
            public EnumUserHookStatus UserHookStatus { get; set; }

            /// <summary>用户录音状态</summary>
            public EnumRecordStatus RecordStatus { get; set; }

            /// <summary>调度会议ID</summary>
            public int ConfID { get; set; }

            /// <summary>用户号码</summary>
            public long UserNumber { get; set; }

            /// <summary>对方号码</summary>
            public long PeerPartNumber { get; set; }

            /// <summary>用户线路状态</summary>
            public EnumUserLineStatus UserLineStatus { get; set; }

            /// <summary>调度附加信息</summary>
            public string EventAdditionalInfo  { get; set; }

            /// <summary>
            /// 基站IP地址
            /// </summary>
            public string FapIP { get; set; }

            public override string ToString()
            {
                return string.Format("用户状态事件->用户号码:{0} 被叫号码:{1} 线路状态:{2}",
                    UserNumber,
                    PeerPartNumber,
                    UserLineStatus.ToString());
            }
        }

        /// <summary>等待队列消息参数</summary>
        public class WaitingQueensAgs : EventArgs
        {
            //unsigned int uWaitingUserNumber;
            //unsigned int uWaitingUserStatus;        //用户等待队列状态
            //unsigned int uEventTimeStamp;         //时间帧
            //Char chEventAdditionalInfo [64];         //调度附加信息
            //uWaitingUserStatus表示用户进入和移出队列的状态,
            // 0: 无状态
            // 1: 用户进入等待队列(add)
            // 2: 用户离开等待队列(remove)   

            /// <summary>
            /// 等待用户号码
            /// </summary>
            public long WaitingUserNumber { get; set; }


            /// <summary>
            /// 用户等待队列状态
            /// uWaitingUserStatus表示用户进入和移出队列的状态,
            /// 0: 无状态
            /// 1: 用户进入等待队列(add)
            /// 2: 用户离开等待队列(remove)   
            /// </summary>
            public EnumWaitingUserStatus WaitingUserStatus { get; set; }

            /// <summary>调度附加信息</summary>
            public string EventAdditionalInfo { get; set; }

            public override string ToString()
            {
                return string.Format("等待队列事件->号码:{0} 状态:{1}",
                    WaitingUserNumber,
                    WaitingUserStatus.ToString());
            }
        }

        /// <summary>紧急呼叫队列消息参数</summary>
        public class LemcQueensArgs : EventArgs
        {
            //unsigned int	uLemcCallingNumber;    //拨打紧急呼叫的用户号码
            //unsigned int	uLemcCalledNumber;     //紧急呼叫号码如1001
            //unsigned int  uLemcStatus;              //紧急呼叫队列状态
            //unsigned int  uEventTimeStamp;       //时间帧
            //Char  chEventAdditionalInfo [64];      //调度附加信息
            //uLemcStatus表示用户进入和移出紧急呼叫队列的状态,
            //    0: 无状态
            // 1: 用户进入紧急呼叫队列(add)
            // 2: 用户离开紧急呼叫队列(remove)   

            /// <summary>拨打紧急呼叫的用户号码</summary>
            public long UserNumber { get; set; }

            /// <summary>紧急呼叫号码如</summary>
            public long LemcNumber { get; set; }

            /// <summary>紧急呼叫队列状态</summary>
            public EnumLemcStatus LemcStatus { get; set; }

            /// <summary>调度附加信息 chEventAdditionalInfo [64];     </summary>
            public string EventAdditionalInfo { get; set; }

            public override string ToString()
            {
                return string.Format("紧急呼叫队列事件->用户号码:{0} 紧急呼叫号码:{1} 状态:{2} 附加信息:{3}",
                    UserNumber,
                    LemcNumber,
                    LemcStatus.ToString(),
                    EventAdditionalInfo);
            }
        }

        /// <summary>
        /// 双机热备参数
        /// </summary>
        public class HotStandbyArgs : EventArgs
        {
            /// <summary>
            /// 当前热备BOX的工作IP
            /// </summary>
            public string StandyHostActiveIP { get; set; }
            /// <summary>
            /// 当前热备的BOX的网管IP
            /// </summary>
            public string StandyHostNMSIP { get; set; }
            /// <summary>
            /// 工作模式1：Primary,2:standby
            /// </summary>
            public int RedUndancyWorkMode { get; set; }
            /// <summary>
            /// 网管口状态1:down,2:Up
            /// </summary>
            public int RedUndancyNMSStatus { get; set; }
        }

        /// <summary>调度事件参数</summary>
        public class DispatchArgs : EventArgs
        {
            /// <summary>发起调度的用户号码</summary>
            public long FromNumber { get; set; }
            
            /// <summary>被调度的用户号码</summary>
            public long ToNumber { get; set; }
            //unsigned int uDispatchedUserOld;         //保留
            //unsigned int uEventTimeStamp;           //时间帧

            /// <summary>调度执行状态</summary>
            public EnumDispatchStatus DispatchStatus { get; set; }
            

            /// <summary>调度命令类型</summary>
            public TalkSDK.LINE_MESSAGE_CATEGORY DispatchCmdType { get; set; }

            /// <summary>
            /// 调度命令子类型
            /// </summary>
            public EnumDispatchCmdType DispatchCmdSubType { get; set; }

            /// <summary>调度会话ID</summary>
            public int DispatchCmdTransactionId { get; set; }
            

            /// <summary>调度会议ID</summary>
            public int ConfID { get; set; }
            

            /// <summary>调度失败原因</summary>
            public EnumuDispatchErrorCause DispatchErrorCause { get; set; }
          
            /// <summary>调度主机IP</summary>
            public string MainIP { get; set; }

            
            /// <summary>调度附加信息</summary>
            public string EventAdditionalInfo { get; set; }

            public override string ToString()
            {
                //return string.Format("调度事件->用户号码:{0} 被叫号码:{1} 调度状态:{2} 调度命令类型:{3} 附加信息:{4} 调度主机IP:{5} 调度失败原因:{6}\r\n",
                //   FromNumber,
                //   ToNumber,
                //   DispatchStatus.ToString(),
                //   DispatchCmdType,
                //   EventAdditionalInfo,
                //   MainIP,
                //   DispatchErrorCause.ToString() );
                return string.Format("调度事件->用户号码:{0} 被叫号码:{1} 调度状态:{2} 调度命令类型:{3}会议ID:{4} ",
                   FromNumber,
                   ToNumber,
                   DispatchStatus.ToString(),
                   DispatchCmdSubType.ToString(),
                   ConfID
                  );
            }
        }


        /// <summary>调度状态</summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public delegate void DispatchStateChanaged(object obj, DispatchArgs e);
        
        public delegate void MemberStateChanaged (object obj,UserStateArgs e);

        public delegate void WaitingQueensChaanged(object obj, WaitingQueensAgs e);

        public delegate void LemcQueensChaanged(object obj, LemcQueensArgs e);

        public delegate void HotStandbyChaanged(object obj, HotStandbyArgs e);

        /// <summary>用户状态改变事件</summary>
        public event MemberStateChanaged OnMemberStateChanged;

        /// <summary>等待队列</summary>
        public event WaitingQueensChaanged OnWaitingQueensChanged;

        /// <summary>调度状态改变</summary>
        public event DispatchStateChanaged OnDispatchStateChanged;

        /// <summary>紧急事件</summary>
        public event LemcQueensChaanged OnLemcQueensChanged;

        /// <summary>双机热备事件</summary>
        public event HotStandbyChaanged OnHotStandbyChanged;
        #endregion

        /// <summary>
        /// 回调委托
        /// </summary>
        public static TalkSDK.CallBackDelegate callBack;
        public static TalkSDK.AlarmCallBackDelegate cc;
        #region 公共方法


        class CallbackParams
        {
            public CallbackParams(TalkSDK.LINE_MESSAGE_CATEGORY nCategory, TalkSDK.MBox_Notify notify, IntPtr hInstance)
            {
                this.nCategory = nCategory;
                this.notify = notify;
                this.hInstance = hInstance;
            }
            public TalkSDK.LINE_MESSAGE_CATEGORY nCategory;
            public TalkSDK.MBox_Notify notify;
            public IntPtr hInstance;
        }

        List<CallbackParams> lstCallbackParams = null;
        System.Threading.Thread threadCallback = null;
        //System.Threading.Thread threadCallback2 = null;
        //System.Threading.Thread threadCallback3 = null;
        //System.Threading.Thread threadCallback4 = null;
        //System.Threading.Thread threadCallback5 = null;
        //System.Threading.Thread threadCallback6 = null;
        //System.Threading.Thread threadCallback7 = null;
        //System.Threading.Thread threadCallback8 = null;

        /// <summary>初始化</summary>
        /// <param name="serverIP"></param>
        /// <param name="localIP"></param>
        /// <returns></returns>
        public bool Init(string serverIP, string localIP)
        {
            bool b = false;
            //try
            //{
            lstCallbackParams = new List<CallbackParams>();
            threadCallback = new System.Threading.Thread(CallbackProc);
            threadCallback.IsBackground = true;
            threadCallback.Start();

        

                callBack = new TalkSDK.CallBackDelegate(cllBackEx);
                b = TalkSDK.MBOX_Initialize();
                b = TalkSDK.MBOX_RegisterCallBack(Marshal.GetFunctionPointerForDelegate(callBack));


                cc = new TalkSDK.AlarmCallBackDelegate(cllBackForAlarm);                
                b = TalkSDK.MBOX_RegisterAlarmCallBack(Marshal.GetFunctionPointerForDelegate(cc));//注册告警回调
                


                b = TalkSDK.MBOX_OutputLog(Pub._configModel.WriteSDKLog);
                handle = TalkSDK.MBOX_Login(serverIP, localIP, "", "");
                if (handle > 0)
                {
                    try
                    {
                        TalkSDK.MBOX_UpdateStatus(handle);
                    }
                    catch (Exception)
                    {
                        
                       // throw;
                    }
                    
                }
                else
                {
                    b = false;
                }
            //}
            //catch (Exception)
            //{

            //}
            return b;
        }

        private void CallbackProc(object obj)
        {
            CallbackParams cbp = null;
            while (true)
            {
                lock (lstCallbackParams)
                {
                    if (lstCallbackParams.Count > 0)
                    {
                        cbp = lstCallbackParams[0];
                        lstCallbackParams.RemoveAt(0);
                    }
                    else
                    {
                        cbp = null;
                    }
                }
                if (cbp != null)
                {
                    cllBack(cbp.nCategory, cbp.notify, cbp.hInstance);
                    cbp = null;
                }
                else
                {
                    System.Threading.Thread.Sleep(1);
                }
            }
        }

        /// <summary>获取会议列表</summary>
        /// <returns></returns>
        public List<long> GetMeetingList(long dispatchNumber)
        {
            List<long> lstMeeting = new List<long>();
            long[] meetingList = new long[64];
            uint meetingCount = 0;
            bool b = TalkSDK.MBOX_GetConfList(handle, dispatchNumber, meetingList, ref meetingCount);
            if (b==true)
            {
                for (int i = 0; i < meetingCount; i++)
                {
                    lstMeeting.Add(meetingList[i]);
                }
            }

            return lstMeeting;
        }

        /// <summary>获取会议成员列表</summary>
        /// <returns></returns>
        public List<MeetingMemberState> GetMeetingMember(int meetingID, long dispatchNumber)
        {
            List<MeetingMemberState> lstMember = new List<MeetingMemberState>();

            long[] meetingList = new long[64];
            int[] memberList = new int[64];
            int meetingCount = 0;
            bool b= TalkSDK.MBOX_GetConfPartList(handle, meetingID, dispatchNumber, meetingList, memberList, ref meetingCount);
            for (int i = 0; i < meetingCount; i++)
            {
                if (dispatchNumber != meetingList[i])
                {
                    EnumConfUserState ss = (EnumConfUserState)memberList[i];
                    EnumUserLineStatus uu = EnumUserLineStatus.Offline;
                    switch (ss)
                    {
                        case EnumConfUserState.DU_ST_NULL:
                            break;
                        case EnumConfUserState.DU_ST_WAIT_PROCESS:
                            break;
                        case EnumConfUserState.DU_ST_CALL_PROCEEDING:
                            break;
                        case EnumConfUserState.DU_ST_RINGING:
                            break;
                        case EnumConfUserState.DU_ST_CONNECTED:
                            uu = EnumUserLineStatus.Busy;
                            break;
                        case EnumConfUserState.DU_ST_DISCONNECTED:
                            break;
                        case EnumConfUserState.DU_ST_MONITORING:
                            break;
                        case EnumConfUserState.DU_ST_RECORDING:
                            break;
                        case EnumConfUserState.DU_ST_FORBIDED:
                            uu = EnumUserLineStatus.Forbid;
                            break;
                        case EnumConfUserState.DU_ST_ISOLATED:
                            uu = EnumUserLineStatus.Isolate;
                            break;
                        default:
                            break;
                    }
                    lstMember.Add(new MeetingMemberState()
                    {
                        Number = meetingList[i],
                        MeetingUserState = uu
                    });
                }
            }
            return lstMember;
        }

        /// <summary>获取等待用户列表</summary>
        /// <returns></returns>
        public List<long> GetWaitMemberList(long dispatchNumber)
        {
            List<long> lst = new List<long>();
            long[] meetingList = new long[64];
            int meetingCount = 0;
            bool b= TalkSDK.MBOX_GetWaitingUserList(handle, dispatchNumber, meetingList, ref meetingCount);
            if (b)
            {
                for (int i = 0; i < meetingCount; i++)
                {
                    lst.Add(meetingList[i]);
                }
            }
            return lst;
        }

        /// <summary>获取紧急呼叫用户列表</summary>
        /// <returns></returns>
        public List<long> GetLemcMemberList(long dispatchNumber)
        {
            //int[] meetingList = new int[64];
            //int meetingCount = 0;
            //return TalkSDK.MBOX_LemcGetCallList(handle,this.CurrentDispatchNumber, meetingList, ref meetingCount);

            List<long> lst = new List<long>();
            long[] meetingList = new long[64];
            int meetingCount = 0;
            bool b = TalkSDK.MBOX_LemcGetCallList(handle, dispatchNumber, meetingList, ref meetingCount);
            if (b)
            {
                for (int i = 0; i < meetingCount; i++)
                {
                    lst.Add(meetingList[i]);
                }
            }
            return lst;

        }

        /// <summary>
        /// 重新连接
        /// </summary>
        /// <returns></returns>
        public bool ReConnect()
        {
            return MBoxSDK.TalkSDK.MBOX_Reconnect(this.handle);
        }

        /// <summary>
        /// 当前设备是否在线
        /// </summary>
        /// <returns></returns>
        public bool GetBoxIsOnline()
        {
            return MBoxSDK.TalkSDK.MBOX_GetDeviceStatus(this.handle);
        }

        /// <summary>
        /// 设置调度号码，底层没实现
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public bool SetDispatchNumber(int left, int right)
        {
            return true;
            return MBoxSDK.TalkSDK.MBOX_SetSeatsUsers(this.handle,left,right);
        }

        /// <summary>
        /// 设置接听模式
        /// </summary>
        /// <param name="isAuto"></param>
        /// <returns></returns>
        public bool SetAnserType(bool isAuto)
        {
            uint t = 0;
            if (isAuto)
            {
                t = 0;
            }
            else
            {
                t = 1;
            }
            return MBoxSDK.TalkSDK.MBOX_SwitchAutoAndManualAnswer(this.handle, t);
        }

        /// <summary>
        /// 获取设备类型
        /// </summary>
        /// <returns></returns>
        public EnumEquipmentType GetEquipmentType()
        {
            EnumEquipmentType et = new EnumEquipmentType();
            int t = 0;
            if (MBoxSDK.TalkSDK.MBOX_GetDeviceType(this.handle, ref t))
            {
                try
                {
                    et = (EnumEquipmentType)t;
                }
                catch (Exception)
                {
                    et = EnumEquipmentType.T_HT8000C;
                }
            }
            return et;
        }

        #endregion

        /// <summary>
        /// 重新获取所有用户状态
        /// </summary>
        public void ReGetState()
        {
            TalkSDK.MBOX_UpdateStatus(handle);
        }

        private void cllBackEx(TalkSDK.LINE_MESSAGE_CATEGORY nCategory, TalkSDK.MBox_Notify notify, IntPtr hInstance)
        {
            lock (lstCallbackParams)
            {
                lstCallbackParams.Add(new CallbackParams(nCategory, notify, hInstance));
            }
        }

        /// <summary>底层回调函数</summary>
        /// <param name="nCategory"></param>
        /// <param name="notify"></param>
        /// <param name="hInstance"></param>
        private void cllBack(TalkSDK.LINE_MESSAGE_CATEGORY nCategory, TalkSDK.MBox_Notify notify, IntPtr hInstance)
        {
            //System.Console.WriteLine("开始-----------------------------");
            lock (this)
            {
                #region MyRegion

                switch (nCategory)
                {
                    case TalkSDK.LINE_MESSAGE_CATEGORY.CATEGORY_SUBSTATUS_NOTIFY:
                        //unsigned int uEventTimeStamp;      //时间帧未实现

                        UserStateArgs ua = new UserStateArgs();
                        ua.UserNumber = notify.lSubscriberNumber;
                        ua.PeerPartNumber = notify.lPeerPartNumber;
                        ua.UserLineStatus = (EnumUserLineStatus)notify.uSubscriberStatus;
                        ua.RecordStatus = (EnumRecordStatus)notify.uRecordingStatus;
                        ua.UserHookStatus = (EnumUserHookStatus)notify.uHookOffStatus;
                        ua.ConfID = notify.uDispatchConfId;
                        ua.EventAdditionalInfo = Encoding.Default.GetString(notify.chEventAdditionalInfo);
                        ua.FapIP = Encoding.Default.GetString(notify.chfapIpAddr);

                        int i = ua.FapIP.IndexOf("\0");
                        if (i>0)
                        {
                            ua.FapIP = ua.FapIP.Substring(0, i); 
                        }
                        
                        //  Console.WriteLine(ua.ToString());
                        if (OnMemberStateChanged != null)
                        {
                            if (ua.UserLineStatus == EnumUserLineStatus.Busy && ua.PeerPartNumber == 0 && ua.ConfID == 0)//防止没用的信息
                            {
                                return;
                            }

                            //if (ua.UserLineStatus == EnumUserLineStatus.Busy && ua.PeerPartNumber == 0 && ua.RecordStatus== EnumRecordStatus.ON)//防止没用的信息
                            //{
                            //    return;
                            //}

                            OnMemberStateChanged(this, ua);
                        }
                        break;
                    case TalkSDK.LINE_MESSAGE_CATEGORY.CATEGORY_WAITINGQUEUESTATUS_NOTIFY:

                        //unsigned int uEventTimeStamp;         //时间帧
                        WaitingQueensAgs args = new WaitingQueensAgs();
                        args.WaitingUserNumber = notify.lWaitingUserNumber;
                        args.WaitingUserStatus = (EnumWaitingUserStatus)notify.uWaitingUserStatus;
                        args.EventAdditionalInfo = Encoding.Default.GetString(notify.chEventAdditionalInfo);

                        // Console.WriteLine(args.ToString());
                        if (OnWaitingQueensChanged != null)
                        {
                            OnWaitingQueensChanged(this, args);
                        }
                        break;
                    case TalkSDK.LINE_MESSAGE_CATEGORY.CATEGORY_DISPATCHSTATUS_NOTIFY:
                        DispatchArgs ss = new DispatchArgs();
                        ss.DispatchStatus = (EnumDispatchStatus)notify.uDispatchStatus;
                        CurrentMeetingID = notify.uDispatchConfId;
                        ss.MainIP = Encoding.Default.GetString(notify.chDispatchCmdHost);
                        ss.EventAdditionalInfo = Encoding.Default.GetString(notify.chEventAdditionalInfo);

                        //ss.FromNumber = notify.lDispatchedUser;
                        //ss.ToNumber = notify.lPeerPartNumber;

                        ss.FromNumber = notify.lDispatchCmdDispatcher;
                        ss.ToNumber = notify.lDispatchedUser;

                        ss.DispatchCmdType = (TalkSDK.LINE_MESSAGE_CATEGORY)notify.uDispatchCmdType;
                        ss.DispatchCmdSubType = (EnumDispatchCmdType)notify.uDispatchCmdSubType;
                        ss.DispatchCmdTransactionId = notify.uDispatchCmdTransactionId;
                        ss.DispatchErrorCause = (EnumuDispatchErrorCause)notify.uDispatchErrorCause;
                        ss.ConfID = notify.uDispatchConfId;

                        if (OnDispatchStateChanged != null)
                        {
                            OnDispatchStateChanged(this, ss);
                        }
                        // Console.WriteLine(ss.ToString());
                        //unsigned int uDispatchedUserOld;         //保留
                        //unsigned int uEventTimeStamp;           //时间帧
                        break;
                    case TalkSDK.LINE_MESSAGE_CATEGORY.CATEGORY_LEMCQUEUESTATUS_NOTIFY:
                        //unsigned int  uEventTimeStamp;       //时间帧
                        LemcQueensArgs a = new LemcQueensArgs();
                        a.UserNumber = notify.lLemcCallingNumber;
                        a.LemcNumber = notify.lLemcCalledNumber;
                        a.LemcStatus = (EnumLemcStatus)notify.uLemcStatus;
                        int not = notify.lEventTimeStamp;
                        a.EventAdditionalInfo = Encoding.Default.GetString(notify.chEventAdditionalInfo);

                        if (OnLemcQueensChanged != null)
                        {
                            OnLemcQueensChanged(this, a);
                        }
                        // Console.WriteLine(a.ToString());
                        break;
                    case  TalkSDK.LINE_MESSAGE_CATEGORY.CATEGORY_REDUNDANCYSTATUS_NOTIFY:
                        HotStandbyArgs arg = new HotStandbyArgs();
                        arg.StandyHostActiveIP = Encoding.Default.GetString(notify.chStandyHostActiveIP);
                        arg.StandyHostNMSIP = Encoding.Default.GetString(notify.chStandyHostNMSIP);
                        arg.RedUndancyWorkMode = notify.RedUndancyWorkMode;
                        arg.RedUndancyNMSStatus = notify.RedUndancyNMSStatus;
                        if (OnHotStandbyChanged!=null)
                        {
                            OnHotStandbyChanged(this, arg);
                        }
                        break;
                    default:
                        break;
                }
                #endregion
            }
            //System.Console.WriteLine("结束-----------------------------");
        }

        /// <summary>
        /// 告警回调函数
        /// </summary>
        /// <param name="alarmLevel"></param>
        /// <param name="notify"></param>
        /// <param name="hInstance"></param>
        private void cllBackForAlarm(MBoxSDK.TalkSDK.EnumALARM_LEVEL alarmLevel, MBoxSDK.TalkSDK.MBox_AlarmNotify notify, IntPtr hInstance)
        {
            DB_Talk.Model.Data_Alarm alarmModel = new DB_Talk.Model.Data_Alarm();
            alarmModel.AlarmTypeID = alarmLevel.GetHashCode();
            alarmModel.i_AlarmAckFlag = notify.alarmAckFlag;
            alarmModel.i_AlarmClass = notify.alarmClass;
            alarmModel.i_AlarmEntityInstance = notify.alarmEntityInstance;
            alarmModel.i_AlarmEntityType = notify.alarmEntityType;
            alarmModel.i_AlarmInfo = notify.alarmInfo;
            alarmModel.i_AlarmSeriesNumber = notify.alarmSeriesNumber;
            alarmModel.i_AlarmSeverity = notify.alarmSeverity;
            alarmModel.dt_DateTime = DateTime.Now;
            new DB_Talk.BLL.Data_Alarm().Add(alarmModel);
        }
        /// <summary>
        /// 会议成员状态
        /// </summary>
        public class MeetingMemberState
        {
            public long Number { get; set; }

            public EnumUserLineStatus MeetingUserState { get; set; }
        }
    }
}
