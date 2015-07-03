using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;
using System.IO;

using System.Threading;

namespace MBoxSDK
{
    /// <summary>
    /// 底层DLL接口声明
    /// </summary>
    public static class TalkSDK
    {
        /// <summary>回调委托</summary>
        /// <param name="nCategory">回调</param>
        /// <param name="notify">消息结构体</param>
        /// <param name="hInstance"></param>
        public delegate void CallBackDelegate(LINE_MESSAGE_CATEGORY nCategory, MBox_Notify notify, IntPtr hInstance);


        /// <summary>
        /// 告警回调
        /// </summary>
        /// <param name="alarmLevel"></param>
        /// <param name="notify"></param>
        /// <param name="hInstance"></param>
        public delegate void AlarmCallBackDelegate(EnumALARM_LEVEL alarmLevel, MBox_AlarmNotify notify, IntPtr hInstance);

        #region 结构定义

        /// <summary>
        /// 告警级别
        /// </summary>
        public enum EnumALARM_LEVEL
        {
            ALM_CRITICAL=0,
            ALM_MAJOR=1,
            ALM_MINOR=2,
            ALM_WARNING=3,
            ALM_CLEAR=4
        }

        public enum EnumGENERAL_MGMT_TRAPS
        {
            ALARM_NOTITY,
            EVENT_NOTITY
        }

        public enum EnumALARM_CLASS_CATEGORY
        {
            ALM_NONE = 0,
            ALM_COMMUNITCATION = 1,
            ALM_QUALITYOFSERVICE = 2,
            ALM_EQUIPMENT = 3,
            ALM_PROCSSINGERROR = 4,
            ALM_ENVIRONMENTAL = 5,
        }


        /// <summary>
        /// 四种调度消息类型
        /// </summary>
        public enum LINE_MESSAGE_CATEGORY
        {
            /// <summary> /**用户状态消息*/</summary>
            CATEGORY_SUBSTATUS_NOTIFY = 0,
            /// <summary> /**等待队列消息*/</summary>
            CATEGORY_WAITINGQUEUESTATUS_NOTIFY=1,
            /// <summary> /**调度状态消息信息*/</summary>
            CATEGORY_DISPATCHSTATUS_NOTIFY=2,
            /// <summary> /**紧急号码状态信息*/</summary>
            CATEGORY_LEMCQUEUESTATUS_NOTIFY=3,	
            /// <summary>
            /// 双机热备状态
            /// </summary>
            CATEGORY_REDUNDANCYSTATUS_NOTIFY=4
        }

        /// <summary>
        /// 调度执行状态
        /// </summary>
        public enum EnumDisState
        {
            success = 0,//  --Complete dispatch command, result is success
            released = 254,//, --Transaction is released.
            failure = 255,//, --Complete dispatch command, result is failure.
            //
            userRinging = 1,//  --User is ringing
            userConnected = 2,//  --Succeed to establish connection with the user
            userDisconnected = 3,//  --User disconnected
            userRedirected = 4,//  --User is redirected to another number
            userHold = 5,//  --User is held and in holding state
            userCallFail = 6,//  --Failed to establish connection with the user.
            //
            confCreated = 30,//  --Conference is created. 
            confDeleted = 31,//  --Conference is deleted. 
            confAddPart = 32,//  --A part is added to the conference
            confDelPart = 33,//  --A part is deleted from the conference
            confAddPartFail = 34,//  --Failed to add part to the conference. 
            confAddMonitor = 35,//  --A monitor is added to the conference
            confDelMonitor = 36,//  --A monitor is deleted from the conference
            confAddRecorder = 37,//  --A recorder is added to the conference
            confDelRecorder = 38//  --A recorder is deleted from the conference  
        }

        /// <summary>
        /// 会议成员状态
        /// </summary>
        public enum enConfUserState
        {   //每一个字节表示一个会议成员状态，状态值的定义如下：
            DU_ST_NULL = 0,     			   //空闲，未加入用户号码
            DU_ST_WAIT_PROCESS = 1,		//尚未执行呼叫流程
            DU_ST_CALL_PROCEEDING = 2,	//呼叫过程中
            DU_ST_RINGING = 3,				   //正在振铃
            DU_ST_CONNECTED = 4,			//建立连接，通话过程中
            DU_ST_DISCONNECTED = 5,		//断开连接或呼叫失败
            DU_ST_MONITORING = 6,			//监听台的状态
            DU_ST_RECORDING = 7,			//录音台的状态
            DU_ST_FORBIDED = 8,				//被禁言的会议成员
            DU_ST_ISOLATED = 9			   //被隔离的会议成员
        }

        /// <summary>
        /// 告警消息解析
        /// </summary>
        public struct MBox_AlarmNotify
        {
            public int alarmSeriesNumber;    //告警序列号
            public int alarmInfo;            //告警原因和具体的问题，高字节表示原因代码，低字节表示具体原因
            public int alarmEntityType;      //告警实体，如E1、L2 PRI、时钟等
            public int alarmEntityInstance;  //表示告警发生在实体的哪个位置，(机框ID-插槽ID-端口ID 分别减）
            public int alarmClass;           //none(0),communication(1),qualityofservice(2),equipment(3),processingerror(4),environmental(5)
            public int alarmSeverity;                 //告警严重度
            public int alarmAckFlag;         //如果该告警被用户相应，则做出标记
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] alarmTimeStamp;           //告警时间戳
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] alarmAdditionalInfo;     //附加信息
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] alarmHost;                //告警主机
        }

        /// <summary>
        /// 调度消息解析
        /// </summary>
        public struct MBox_Notify
        {
           public int uSubscriberStatus;        //用户线路状态
           public int uRecordingStatus;       //用户录音状态     
           public int uHookOffStatus;          //用户摘机状态(保留)
           public int uDispatchStatus;          //调度执行状态
           public int uDispatchCmdType;      //调度命令类型
           public int uDispatchCmdSubType;       //调度命令子类型，调度状态通知有效
           public int uDispatchCmdTransactionId; //调度会话ID
           public int uUserCount;                 //用户个数
           public int uDispatchConfId;            //调度会议ID
           public int uDispatchErrorCause;        //调度失败原因
           public int uWaitingUserStatus;        //用户等待队列状态
           public int uLemcStatus;                 //紧急呼叫队列状态
           public long lSubscriberNumber;           //用户号码
           public long lPeerPartNumber;           //对方号码
           public long lDispatchCmdDispatcher;      //发起调度的用户号码
           public long lDispatchedUser;               //被调度的用户号码
           public long lDispatchedUserOld;
           public long lWaitingUserNumber;
           public long lLemcCallingNumber;          //拨打紧急呼叫的用户号码
           public long lLemcCalledNumber;           //紧急呼叫号码如1001
           public int lEventTimeStamp;           //时间帧
           [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
           public byte[] chDispatchCmdHost;       //调度主机IP   32
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
           public byte[] chEventAdditionalInfo;     //调度附加信息 64
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] chfapIpAddr;       //基站IP   32

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] chStandyHostActiveIP;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] chStandyHostNMSIP;
            public int RedUndancyWorkMode;
            public int RedUndancyNMSStatus;

        }

        public enum OPERATE_RESULT
        {
            OPERR_SUCCESS = 0,			/**< 调用成功 */
            OPERR_TIMEOUT,		        /**< 数据超时 */
            OPERR_NETERROR,		        /**< 网络错误 */
            OPERR_FAILED		        /**< 调用失败 */
        }

        
        #endregion

        /// <summary>注册回调</summary>
        /// <param name="pCallBack"></param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_RegisterCallBack(IntPtr pCallBack);
        //private static extern bool MBOX_RegisterCallBack(IntPtr pCallBack);
        //public static bool MBOX_RegisterCallBackEx(IntPtr pCallBack)
        //{
        //    return MBOX_RegisterCallBack(pCallBack);
        //}

        /// <summary>
        /// 开启打印日志
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_OutputLog(bool b);

        /// <summary>
        /// 注册告警回调,该回调函数用有接收来自Mbox传回的实时的号码状态及调度状态，用户需对这些通知进行分析
        /// </summary>
        /// <param name="pCallBack"></param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_RegisterAlarmCallBack(IntPtr pCallBack);
        //private static extern bool MBOX_RegisterAlarmCallBack(IntPtr pCallBack);
        //public static  bool MBOX_RegisterAlarmCallBackEx(IntPtr pCallBack)
        //{
        //    return MBOX_RegisterAlarmCallBack(pCallBack);
        //}

        /// <summary>初始化</summary>
        /// <param name="callBack"></param>
        /// <param name="lpszServerIP"></param>
        /// <param name="lpszLocalIP"></param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_Initialize();
        //private static extern bool MBOX_Initialize();
        //public static bool MBOX_InitializeEx()
        //{
        //    return MBOX_Initialize();
        //}

        /// <summary>重新连接</summary>
        /// <param name="callBack"></param>
        /// <param name="lpszServerIP"></param>
        /// <param name="lpszLocalIP"></param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_Reconnect(int handel);
        //private static extern bool MBOX_Reconnect(int handel);
        //public static bool MBOX_ReconnectEx(int handel)
        //{
        //    return MBOX_Reconnect(handel);
        //}

        /// <summary>逆初始化</summary>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_Dispose();
        //private static extern bool MBOX_Dispose();
        //public static bool MBOX_DisposeEx()
        //{
        //    return MBOX_Dispose();
        //}

        /// <summary>登录</summary>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MBOX_Login(string sMboxIp, string sLocalIp, string sUserName, string sUserPassword);
        //private static extern int MBOX_Login(string sMboxIp, string sLocalIp, string sUserName, string sUserPassword);
        //public static int MBOX_LoginEx(string sMboxIp, string sLocalIp, string sUserName, string sUserPassword)
        //{
        //    return MBOX_LoginEx(sMboxIp, sLocalIp, sUserName, sUserPassword);
        //}

        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MBOX_UpdateStatus(int handle);

        /// <summary>判断设备在线状态 </summary>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetDeviceStatus(int handele);
        //private static extern bool MBOX_GetDeviceStatus(int handele);
        //public static bool MBOX_GetDeviceStatusEx(int handele)
        //{
        //    return MBOX_GetDeviceStatus(handele);
        //}

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_Logout(int handle);
        //private static extern bool MBOX_Logout(int handle);
        //public static bool MBOX_LogoutEx(int handle)
        //{
        //    return MBOX_Logout(handle);
        //}

        /// <summary>发起呼叫</summary>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">被叫号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_MakeCall(int handel, long iDispatcherNum, long iDispatchedNum);
        //private static extern bool MBOX_MakeCall(int handel, long iDispatcherNum, long iDispatchedNum);
        //public static bool MBOX_MakeCallEx(int handel, long iDispatcherNum, long iDispatchedNum)
        //{
        //    return MBOX_MakeCall(handel, iDispatcherNum, iDispatchedNum);
        //}

        /// <summary>创建会议</summary>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iUserList"></param>
        /// <param name="iUserCnt"></param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_CreateConf(int handel, long iDispatcherNum, [MarshalAs(UnmanagedType.LPArray, SizeConst = 64)]long[] iUserList, int iUserCnt);
        //private static extern bool MBOX_CreateConf(int handel, long iDispatcherNum, [MarshalAs(UnmanagedType.LPArray, SizeConst = 64)]int[] iUserList, int iUserCnt);
        //public static bool MBOX_CreateConfEx(int handel, long iDispatcherNum, [MarshalAs(UnmanagedType.LPArray, SizeConst = 64)]int[] iUserList, int iUserCnt)
        //{
        //    return MBOX_CreateConf(handel, iDispatcherNum, iUserList, iUserCnt);
        //}

        /// <summary>设置左右席号码</summary>
        /// <param name="iLeftSeatNum"></param>
        /// <param name="iRightSeatNum"></param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SetSeatsUsers(int handel, long iLeftSeatNum, long iRightSeatNum);

        //添加会议成员(老接口)
        ///// <summary>添加会议成员(老接口)</summary>
        ///// <param name="iConferenceID">为会议的ID号码</param>
        ///// <param name="iDispatcherNum">为调度用户的号码</param>
        ///// <param name="iDispatchedNum">为将要添加的会议成员号码</param>
        ///// <returns></returns>
        //[DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        //public static extern bool MBOX_ConfAddPart(int handel, int iConferenceID, long iDispatcherNum, long iDispatchedNum);
    
        /// <summary>
        /// 添加会议成员
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="iConferenceID"></param>
        /// <param name="iDispatcherNum"></param>
        /// <param name="?"></param>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_ConfAddPart(int handle,int iConferenceID, long iDispatcherNum, [MarshalAs(UnmanagedType.LPArray, SizeConst = 64)]long[] iUserList,int iUserCnt);

        //public static extern bool MBOX_CreateConf(int handel, long iDispatcherNum, [MarshalAs(UnmanagedType.LPArray, SizeConst = 64)]int[] iUserList, int iUserCnt);
        //BL8000API BOOL MBOX_ConfAddPart(MBOX_HANDLE handle,CONFID iConferenceID, PHONE_NUMBER iDispatcherNum, PHONE_NUMBER newConfPartList[64],USER_COUNT);


        /// <summary>踢出会议成员</summary>
        /// <param name="iConferenceID"></param>
        /// <param name="iDispatcherNum">为调度用户的号码</param>
        /// <param name="iDispatchedNum">为将要踢出的会议成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_ConfDelPart(int handel, int iConferenceID, long iDispatcherNum, long iDispatchedNum);
  

        /// <summary>设置会议禁言</summary>
        /// <param name="iConferenceID"></param>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">为将要禁言的会议成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_ConfForbidPart(int handel, int iConferenceID, long iDispatcherNum, long iDispatchedNum);

        /// <summary>解除会议禁言 </summary>
        /// <param name="iConferenceID"></param>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">为将要解除禁言的会议成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_ConfUnforbidPart(int handel, int iConferenceID, long iDispatcherNum, long iDispatchedNum);

        /// <summary> 设置会议隔离 </summary>
        /// <param name="iConferenceID"></param>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">为将要隔离的会议成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_ConfIsolatePart(int handel, int iConferenceID, long iDispatcherNum, long iDispatchedNum);

        /// <summary>解除会议隔离 </summary>
        /// <param name="iConferenceID"></param>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">为将要解除隔离的会议成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_ConfUnisolatePart(int handel, int iConferenceID, long iDispatcherNum, long iDispatchedNum);

        /// <summary> 结束电话会议</summary>
        /// <param name="?"></param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DelConf(int handel, int iConferenceID, long iDispatcherNum);


        /// <summary> 强插 </summary>
        /// <param name="iConferenceID"></param>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">为将要插入的成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_InsertCall(int handel, long iDispatcherNum, long iDispatchedNum);

        /// <summary> 监听 </summary>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">为将要监听的成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_MonitorCall(int handel, long iDispatcherNum, long iDispatchedNum);

        /// <summary> 录音 </summary>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">为将要录音的成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_StartRecordCall(int handel, long iDispatcherNum, long iDispatchedNum);
        
        /// <summary> 停止录音 </summary>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">为将要停止录音的成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_StopRecordCall(int handel, long iDispatcherNum, long iDispatchedNum);

        /// <summary> 强挂 </summary>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">为将要强挂的成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DisconnectCall(int handel, long iDispatcherNum, long iDispatchedNum);

        /// <summary> 转接 </summary>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">为将要转接的成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeliverCall(int handel, long iDispatcherNum, long iDispatchedNum);

        /// <summary> 代答 </summary>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">为将要带答的成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_InsteadAnswer(int handel, long iDispatcherNum, long iDispatchedNum);

        /// <summary> 强拆 </summary>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">为将要强拆的成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SnatchCall(int handel, long iDispatcherNum, long iDispatchedNum);

        /// <summary> 应答</summary>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">为将要应答的成员号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SelectAnswer(int handel, long iDispatcherNum, long iDispatchedNum);

        /// <summary> 群答 </summary>
        /// <param name="iDispatcherNum">调度用户的号码</param>
        /// <param name="iUserList">为群答号码列表</param>
        /// <param name="iUserCnt">群答号码个数</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GroupAnswer(int handel, long iDispatcherNum, [MarshalAs(UnmanagedType.LPArray, SizeConst = 64)]int[] iUserList, int iUserCnt);

        /// <summary> 保持呼叫 </summary>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum">将要保持呼叫的用户号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_HoldCall(int handel, long iDispatcherNum, long iDispatchedNum);

        /// <summary> 群呼</summary>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iUserList">iUserList为指定呼叫号码列表</param>
        /// <param name="iUserCnt">指定呼叫号码的个数</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GroupCall(int handel, long iDispatcherNum, [MarshalAs(UnmanagedType.LPArray, SizeConst = 64)]long[] iUserList, int iUserCnt);

        /// <summary>获取会议列表</summary>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iConfNum">返回的指定会议列表</param>
        /// <param name="?">返回会议列表的个数</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetConfList(int handel, long iDispatcherNum, [MarshalAs(UnmanagedType.LPArray, SizeConst = 64)]long[] iConfNum, ref uint iConfCnt);
        
        /// <summary>获取会议成员列表</summary>
        /// <param name="iConferenceID">为所查询会议的ID号码</param>
        /// <param name="iDispatcherNum">调度用户的号码</param>
        /// <param name="iUserList">返回的指定会议用户号码列表</param>
        /// <param name="iUserStatus">返回的指定会议用户号码状态列表</param>
        /// <param name="iUserCnt">返回号码和状态的个数</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetConfPartList(int handel, int iConferenceID, long iDispatcherNum, [MarshalAs(UnmanagedType.LPArray, SizeConst = 64)]long[] iUserList, [MarshalAs(UnmanagedType.LPArray, SizeConst = 64)]int[] iUserStatus, ref int iUserCnt);



        //Typedef enum enConfUserState
        //{   //每一个字节表示一个会议成员状态，状态值的定义如下：
        //    DU_ST_NULL = 0,     			   //空闲，未加入用户号码
        //    DU_ST_WAIT_PROCESS = 1,		//尚未执行呼叫流程
        //    DU_ST_CALL_PROCEEDING = 2,	//呼叫过程中
        //    DU_ST_RINGING = 3,				   //正在振铃
        //    DU_ST_CONNECTED = 4,			//建立连接，通话过程中
        //    DU_ST_DISCONNECTED = 5,		//断开连接或呼叫失败
        //    DU_ST_MONITORING = 6,			//监听台的状态
        //    DU_ST_RECORDING = 7,			//录音台的状态
        //    DU_ST_FORBIDED = 8,				//被禁言的会议成员
        //    DU_ST_ISOLATED = 9			   //被隔离的会议成员
        //} enConfUserState;

        /// <summary>获取等待号码列表</summary>
        /// <param name="iDispatcherNum">iDispatcherNum为调度用户的号码</param>
        /// <param name="iUserList">iUserList为返回的等待号码列表</param>
        /// <param name="iUserCnt">返回号码的个数</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetWaitingUserList(int handel, long iDispatcherNum, [MarshalAs(UnmanagedType.LPArray, SizeConst = 64)]long[] iUserList, ref int iUserCnt);


        /// <summary>获取内部紧急呼机主叫号码列表</summary>
        /// <param name="iDispatcherNum">iDispatcherNum为调度用户的号码</param>
        /// <param name="iUserList">iUserList为返回的紧急呼叫号码列表</param>
        /// <param name="iUserCnt">为返回号码的个数</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_LemcGetCallList(int handel, long iDispatcherNum, [MarshalAs(UnmanagedType.LPArray, SizeConst = 64)]long[] iUserList, ref int iUserCnt);

        /// <summary>紧急呼叫应答 </summary>
        /// <param name="iDispatcherNum">iDispatcherNum为调度用户的号码</param>
        /// <param name="iDispatchedNum">iDispatchedNum为被调度用户号码</param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_LemcSelectAnswer(int handel, long iDispatcherNum, long iDispatchedNum);

        /// <summary>
        /// 设置等待的接听方式
        /// </summary>
        /// <param name="handel"></param>
        /// <param name="iDispatcherNum"></param>
        /// <param name="iDispatchedNum"></param>
        /// <returns></returns>
        [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SwitchAutoAndManualAnswer(int handel, uint type);

        /// <summary>
        /// 获取设备类型
        /// </summary>
        /// <param name="handel"></param>
        /// <param name="type"></param>
        /// <returns></returns>
         [DllImport("BL8000SDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetDeviceType(int handel, ref int type);

    }
}
