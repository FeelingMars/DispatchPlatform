/******************************************************************************
 *  版权所有（C）2012-2013，南京北路自动化系统有限责任公司                    *
 *  保留所有权利。                                                            *
 ******************************************************************************
 *  作者 : 周国祥
 *  功能 : 调度交换机数据结构定义
 *  版本 : 1.0
 *****************************************************************************/
/*  修改记录: 
      日期       版本    修改人             修改内容

******************************************************************************/

#ifndef _bl8000typedef_H
#define _bl8000typedef_H

#include "macrodef.h"
#include <map>
#include <windows.h>
#include <snmp_pp/snmp_pp.h>
using namespace std;

typedef enum{
	T_HT8000B = 3,
	T_HT8000C,
	T_HT8000D,
	T_HT8000E
};

/*设备能力*/
typedef struct
{
	int maxConferenceNum;
	int maxConferencePartNum;
	int maxGroupCallPartNum;
	int maxWaitingPartNum;
	int maxLemcWaitingPartNum;
	int maxAllConferencePartNum;
	int maxTotalCallPartNum;
	int E1_Num;
} DEVICE_CAPABILITY;



/*宏定义*/
#define MAX_NAME                  256
#define MAX_IP4			           16
#define MAX_MAC			           12
#define MAX_LOGIN_NAME             16
#define MAX_LOGIN_PWD	           16
#define MAX_SERIALNO	           48
#define MBOX_USR_LEN              256
#define MBOX_PASS_LEN              64
#define MBOX_ANSWER_LEN          1024

#define MAX_ROUTE_NAME             20
#define MAX_SUBNUM_LEN              8
#define MAX_PSNUM_LEN              13
#define MAX_SIPAUTH_LEN             8
#define MAX_SIPPWD_LEN             12
#define MAX_SIPPWD_LEN             12
#define MAX_3GUMTSIMSI_LEN         15
#define MAX_DID_LEN                15   /*直播号码最大长度*/
#define MAX_PORTMODULE_LEN          5   /*通信接口模块格式长度*/   
#define MAX_USER_PASSWORD_LEN       5
#define MAX_PHONENUMER_LEN         30 
#define MAX_USER_NUMBER_LEN         8
#define MAX_AUTH_KEY_LEN           32
#define MAX_GROUP_LEN              12

typedef int BOOL;
typedef int MBOX_HANDLE;        
typedef int MBOX_ERRORCODE;     
typedef unsigned int PHONE_NUMBER;              
typedef unsigned int USER_COUNT;               
typedef unsigned int CONF_MEMBER_NUMBER; 
typedef unsigned int CONFID;                    
typedef unsigned int USER_STATUS;         

/*用户类型*/
#define SIP                     4   //SIP手机
#define PS                      1   //小灵通
#define P3G                     6   //3G手机


/* 增补服务类型 */
#define SPM_SRV_NULL            0x00000000		/* 无服务服务 */
#define SPM_DONOT_DISTURB       0x00000001		/* 免打扰 */		
#define SPM_CALL_WAITING        0x00000002      /* 呼叫等待 */     
#define SPM_CFW_UNCON           0x00000004      /* 无条件前转 */	
#define SPM_CFW_BUSY            0x00000008      /* 遇忙前转 */	
#define SPM_CFW_NO_REPLY        0x00000010      /* 无应答前转 */	
#define SPM_MISS_CALL           0x00000020      /* 丢话通知 */	
#define SPM_MISS_CALL_ON_BUSY   0x00000040      
#define SPM_CALL_TRANSFER       0x00000080      /* 呼叫转移 */	
#define SPM_THREE_PARTY         0x00000100      /* 三方通话 */	
#define SPM_SMS                 0x00000200      /* 短信服务 */	
#define SPM_SMS_GROUP           0x00000400      
#define SPM_DDI                 0x00000800      /* 直接拨入号码 */	
#define SPM_DISPLAY_NUM         0x00001000      
#define SPM_ASSO_NUM            0x00002000      
#define SPM_TELEPHONIST         0x00004000      /* 话务员服务 */	
#define SPM_CFVM                0x00008000
#define SPM_CALL_PICKUP         0x00010000
#define SPM_ALARM_CALL          0x00020000     
#define SPM_CFW_UNREACHABLE     0x00040000      /* 不可及前转 */	
#define SPM_PERMANENCE_LINE     0x00080000      /* 永久专线 */	   
#define SPM_INUMBER             0x00100000      /* inumber服务 */	
#define SPM_PERSONAL_ACCOUNT    0x00200000      
#define SPM_TELEAGENT           0x00400000      /* 话务员代理 */	
#define SPM_ACCESSEXTENSION     0x00800000
#define SPM_VM                  0x01000000
#define SPM_CF_POWEROFF         0x02000000
#define SPM_ROAM                0x04000000    
#define SPM_SUB_GRP             0x08000000 
#define SPM_CONFERENCE_CALL     0x10000000
#define SPM_DISPATCH            0x20000000      /* 调度 */
#define SPM_INUM_ASSO           0x40000000  
#define SPM_AUTO_RECORDING      0x80000000      /* 自动录音 */


typedef enum DispatchCmd  
{
	makeCall             = 1,   /**--呼叫，包括普通调度台呼叫用户，已经话务员呼叫用户。话务员可以在hold状态呼叫用户*/
	createConf           = 2,   /**--创建会议*/
	confAddPart          = 3,   /**--添加会议成员*/
	confDelPart          = 4,   /**--踢出会议成员*/
	confForbidPart       = 5,   /**--禁言*/
	confUnforbidPart     = 6,   /**--解除禁言*/
	confIsolatePart      = 7,   /**--隔离*/
	confUnisolatePart    = 8,   /**--解除隔离*/
	delConf              = 9,   /**--结束会议*/
	insertCall           = 10,  /**--强插*/
	monitorCall          = 11,  /**--监听*/
	recordCall           = 12,  /**--录音*/
	stopRecord           = 13,  /**--停止录音*/
	discCall             = 14,  /**--强挂*/
	deliverCall          = 15,  /**--转接*/
	insteadAnswer        = 16,  /**--代答*/
	snatchCall           = 17,  /**--强拆*/
	selectAnswer         = 18,  /**--应答，话务员应答等待队列里面的呼叫*/
	groupAnswer          = 19,  /**--群答，话务员群答等待队列里面的呼叫*/
	holdCall             = 20,  /**--保持呼叫，把话务员当前呼叫放入到等待队列里面*/
	groupCall            = 22,  /**--群呼*/          
	getConfList          = 29,  /**--获取调度台所管理的会议列表*/
	getConfPartList      = 30,  /**--获取会议成员列表*/
	getWaitingUserList   = 31,  /**--获取等待队列号码列表*/
	lemcGetCallList      = 40,  /**--获取内部紧急呼机主叫号码列表*/
	lemcSelectAnswer     = 41,   /**--应答，调度员应答内部紧急呼叫队列里面的呼叫*/
	GetDeviceStatus      = 80    /*--获取设备在线状态--自定义命令*/
}DispatchCmd;
typedef enum enDispatchTrapPrefixOid
{
	subStatusNotify = 0,
	waitingQueueStatusNotify = 1,
	dispatchStatusNotify = 2,
	lemcQueueStatusNotify = 3
};
typedef enum enDispatchOid
{
	mboxDispatchCmdHost          = 0,
	mboxDispatchCmdTransactionId = 1,
	mboxDispatchCmdType          = 2,
	mboxDispatchCmdDispatcher    = 3,
	mboxDispatchCmdUserCount     = 4,
	mboxDispatchCmdUserList      = 5,
	mboxDispatchCmdUserState     = 6,
	mboxDispatchCmdConfId        = 7,
	mboxDispatchCmdConfCount     = 8,
	mboxDispatchCmdConfList      = 9

};

typedef enum enUserStatusOid
{
	mboxSPMSubNumber             = 0,
	mboxSPMSubType               = 1,
	mboxSPMSubSuppService        = 2,
	mboxSPMSubStatus             = 3,
	mboxSPMSubBlockStatus        = 4,
	mboxSPMCallConfId            = 5,
	mboxSPMCallPeerNumber        = 6,
	mboxSPMRecordingStatus       = 7,
	mboxSPMHookOffStatus         = 8
};

typedef enum enDispatchErrorCause
{
	noError = 0,
	errorParameter                     = 1,
	errorCmdType                       = 2,
	invalidInDispatcherCurrentState    = 3,
	invalidInTphistCurrentState        = 4,
	invalidInUserCurrentState          = 5,
	transactionIsReleased              = 6,
	memAllocFail                       = 7,
	memDeallocFail                     = 8,
	msgSendFail                        = 9,
	numberEmpty                        = 10,
	serviceNotSupport                  = 11,
	noPrivilege                        = 12,
	noMatchedUser                      = 13,
	insertCallFail                     = 14,
	monitorCallFail                    = 15,
	recordCallFail                     = 16,
	stopRecordFail                     = 17,
	stopMonitorFail                    = 18,
	tphistIsBusy                       = 19,
	noIdleTphist                       = 20,
	noIdleRecorder                     = 21,

	//dispatched user error cause
	userNotExist                       = 22,
	userNotIdle                        = 23,
	userNotConnected                   = 24,
	userNotRinging                     = 25,
	userNotBusy                        = 26,
	userIsIdle                         = 27,
	userIsConnected                    = 28,
	userIsRinging                      = 29,
	userIsBusy                         = 30,
	userIsDisconnected                 = 31,
	userIsPowerOff                     = 32,
	userIsOffLine                      = 33,
	userConnFail                       = 34,
	userNoRsp                          = 35,
	userNoAnswer                       = 36,

	//dispatch station error cause
	dispatcherNotIdle                  =37,
	dispatcherNotConnected             =38,
	dispatcherNotRinging               =39,
	dispatcherNotBusy                  =40,
	dispatcherIsIdle                   =41,
	dispatcherIsConnected              =42,
	dispatcherIsRinging                =43,
	dispatcherIsBusy                   =44,
	dispatcherIsDisconnected           =45,
	dispatcherIsPowerOff               =46,
	dispatcherIsOffLine                =47,
	dispatcherConnFail                 =48,
	dispatcherNoRsp                    =49,
	dispatcherNoAnswer                 =50,

	//conference operation error cause
	confNoEnoughPart                   =51,
	confFull                           =52,
	confNoMatchedPart                  =53,
	confCannotDelOwner                 =54,
	confNotExist                       =55,
	confAlreadyExist                   =56,
	confCreateFail                     =57,
	confDelFail                        =58,
	confAddPartFail                    =59,
	confDelPartFail                    =60,
	confInvalidOperation               =61,

	//waiting queue operation error cause
	waitQueueFull                      =62,
	waitQueueEmpty                     =63,
	waitQueueNoMatchedUser             =64,

	//default error cause
	unknown                            =255          
};
typedef enum enDispatchStatus
{
	Dispatch_Success           =   0,
	Dispatch_Released          = 254, 
	Dispatch_Failure           = 255,
	Dispatch_UserRinging       =  1,
	Dispatch_UserConnected     =  2,
	Dispatch_UserDisconnected  =  3,
	Dispatch_UserRedirected    =  4,  
	Dispatch_UserHold          =  5,   
	Dispatch_UserCallFail      =  6,
	Dispatch_ConfCreated       = 30, 
	Dispatch_ConfDeleted       = 31,
	Dispatch_ConfAddPart       = 32,  
	Dispatch_ConfDelPart       = 33,  
	Dispatch_ConfAddPartFail   = 34,  
	Dispatch_ConfAddMonitor    = 35,  
	Dispatch_ConfDelMonitor    = 36,
	Dispatch_ConfAddRecorder   = 37,
	Dispatch_ConfDelRecorder   = 38
}EnDispatchStatus;

typedef enum enLemcStatus
{
	Lemc_null   = 0,
	Lemc_add    = 1,
	Lemc_remove = 2
}EnLemcStatus;
typedef enum enWaitingUserStatus
{
	WaitingQueue_Null   = 0,
	WaitingQueue_Add    = 1,
	WaitingQueue_Remove = 2
}EnWaitingUserStatus;

typedef enum enHookOffStatus
{
	hookon    = 0,
	hookoff   = 1
}EnHookOffStatus;

typedef enum enRecordingStatus
{
	RecordingStop       = 0,
	RecordingOngoing    = 1
}EnRecordingStatus;

typedef enum enDispatchResult
{
	Disp_Init       = 0,
	Disp_Success    = 1,
	Disp_Failed     = 2
}EnDispatchResult;

typedef struct mboxLoginInfo
{
	char szMboxIP[MAX_IP4+1];                          //IP地址
	//保留
	char szMboxUserName[MBOX_USR_LEN+1];                //用户名
	char szMboxPassword[MBOX_PASS_LEN+1];               //密码
	mboxLoginInfo(){
		memset(szMboxUserName,0,MBOX_USR_LEN);
		memset(szMboxPassword,0,MBOX_PASS_LEN);
		memset(szMboxIP,0,MAX_IP4);
	}

} MBOX_LOGININFO, *PMBOX_LOGININFO;

class CTarget;
typedef struct snmpTargetInfo
{
	MBOX_LOGININFO loginInfo;
	char localIpAddr[MAX_IP4];
	CTarget target;
}MBOX_SNMPTARGETINFO,*PMBOX_SNMPTARGETINFO;

typedef struct DispatchTask
{
	char chHost[16];
	int iTransactionId;
	int iCmdType;
	int iDispatcher;
	int iUserCount;
	int iUserList[64];	
	int iConfId;
	int iConfCount;	
	
	int iConfList[64];
	int iUserState[64];
	int iStatus;	
	
}DispatchTask;

typedef struct DispatchResult
{
	unsigned int uStatus;
	unsigned int uTransactionId;
	unsigned long uTimeStamp;
} DispatchResult;
typedef pair<unsigned int, DispatchResult>  PairResultStatus;
typedef map<unsigned int,DispatchResult>::iterator IterResultStatus;

typedef struct UserStatus
{
	unsigned int uSubIndex;
	unsigned int uSubType;
	unsigned int uCallConfId;
	unsigned int uUserStatus;
	unsigned int uBlockStatus;
	unsigned int uHookOffStatus;
	unsigned int uRecordingStatus;
	unsigned int uSuppService;
	unsigned int uUserNumber;
	unsigned int uPeerNumber;
} UserStatus;
typedef pair<unsigned int, UserStatus>  PairUserStatus;
typedef map<unsigned int, UserStatus>::iterator  IterUserStatus;

typedef struct ConferenceStatus
{
	unsigned int uStatus;
	unsigned int uConferenceId;
	unsigned int uUserCount;
	unsigned int uUserList[64];
	unsigned int uUserListStatus[64];
} ConferenceStatus;
typedef pair<unsigned int, ConferenceStatus>  PairConferenceStatus;
typedef map<unsigned int, ConferenceStatus>::iterator  IterConferenceStatus;

typedef enum ErrorCode
{	
	ERROR_NO_ERROR                   = 0,
	ERROR_UNINITIALIZED              = 19,
	ERROR_NETWORK                    = 20,		         /**< 网络错误 */
	ERROR_TARGET_NOT_EXIST           = 21,               /**< SNMP目标不存在 */
	ERROR_BUFFER_TOO_SMALL           = 22,		         /**< 数据缓冲区错误 */
    ERROR_OVERLOAD                   = 23,               /**< 用户号码数量已达上限*/ 
	ERROR_PARAMETER                  = 24,               /**< 用户参数错误*/ 
	ERROR_NUMBER_NOT_EXIST           = 25,               /**< 用户号码不存在*/ 
	ERROR_DEVICE_DOWN                = 26,               /**< 设备不在线或网络未连接*/ 
	ERROR_NUMBER_TYPE                = 27,               /**< 数据类型不正确*/ 
	ERROR_NUMBERICAL_OVERFLOW        = 28,               /**< 取值超出范围*/ 
	ERROR_UNDO_FAIL                  = 15                //被操作的数据不存在或者已存在
} ERRORCODE;


typedef enum enConferenceStatus
{
	set_up = 0,
	finish = 1
}enConferenceStatus;

typedef enum enUserStatus
{
	idle       = 0, 
	busy       = 1, 
	ring       = 2, 
	paging     = 3, 
	poweroff   = 4,
	outcalling = 5, 
	holding    = 6, 
	blocked    = 7, 
	offline    = 8, 
	online     = 9     
};

typedef enum enConfUserState
{                                //每一个字节表示一个会议成员状态，状态值的定义如下：
	DU_ST_NULL = 0,     		//空闲，未加入用户号码
	DU_ST_WAIT_PROCESS,			//尚未执行呼叫流程
	DU_ST_CALL_PROCEEDING,		//呼叫过程中
	DU_ST_RINGING,				//正在振铃
	DU_ST_CONNECTED,			//建立连接，通话过程中
	DU_ST_DISCONNECTED,			//断开连接或呼叫失败
	DU_ST_MONITORING,			//监听台的状态
	DU_ST_RECORDING,			//录音台的状态
	DU_ST_FORBIDED,				//被禁言的会议成员
	DU_ST_ISOLATED				//被隔离的会议成员
}enConfUserState;


typedef struct
{
	short int  confMode;   //0: floating conf    1: no-floating conf
	short int  confId;     //0: 尚未给会议分配conf id     >=1: 给会议分配的conf id
} mbox_dispatch_conf_info_t;
//每一个mbox_dispatch_conf_info_t占用4个字节，则mboxDispatchCmdConfList最长是4*16=64字节

typedef enum LINE_MESSAGE_CATEGORY
{
	CATEGORY_SUBSTATUS_NOTIFY = 0,	     /**用户状态消息*/
	CATEGORY_WAITINGQUEUESTATUS_NOTIFY,	 /**等待队列消息*/
	CATEGORY_DISPATCHSTATUS_NOTIFY,		 /**调度状态消息信息*/
	CATEGORY_LEMCQUEUESTATUS_NOTIFY	     /**紧急号码状态信息*/
} MBOX_MESSAGE_CATEGORY;

typedef struct MBox_Notify
{
	unsigned int   uSubscriberStatus;         //用户线路状态,用户状态通知有效
	unsigned int   uRecordingStatus;          //用户录音状态
	unsigned int   uHookOffStatus;            //用户摘机状态(保留)
	unsigned int   uDispatchStatus;           //调度执行状态
	unsigned int   uDispatchCmdType;          //调度类型，区分为用户状态、调度状态、等待队列状态和紧急状态
	unsigned int   uDispatchCmdSubType;       //调度命令子类型，调度状态通知有效
	unsigned int   uDispatchCmdTransactionId; //调度会话ID
	unsigned int   uUserCount;                //用户个数
	unsigned int   uDispatchConfId;           //调度会议ID
	unsigned int   uDispatchErrorCause;       //调度失败原因
	unsigned int   uWaitingUserStatus;        //用户等待队列状态
	unsigned int   uLemcStatus;               //紧急呼叫队列状态
	unsigned int   uSubscriberNumber;         //用户号码
	unsigned int   uPeerPartNumber;           //对方号码
	unsigned int   uDispatchCmdDispatcher;    //发起调度的用户号码
	unsigned int   uDispatchedUser;           //被调度的用户号码
	unsigned int   uDispatchedUserOld;
	unsigned int   uWaitingUserNumber;
	unsigned int   uLemcCallingNumber;        //拨打紧急呼叫的用户号码
	unsigned int   uLemcCalledNumber;         //紧急呼叫号码如1001
	unsigned int   uEventTimeStamp;
	char chDispatchCmdHost[32];               //调度主机IP
	char chEventAdditionalInfo[64];           //调度附加信息

}MBox_Notify;

typedef enum GENERAL_MGMT_TRAPS
{
	ALARM_NOTITY,                  //告警通知
	EVENT_NOTITY                   //事件通知
}GENERAL_MGMT_TRAPS;

typedef enum ALARM_LEVEL
{
	ALM_CRITICAL,                  //紧急告警
	ALM_MAJOR,                     //主要告警
	ALM_MINOR,                     //次要告警
	ALM_WARNING,                   //一般告警
	ALM_CLEAR                      //清楚告警
}ALARM_LEVEL;

typedef struct MBox_AlarmNotify
{
	unsigned int alarmSeriesNumber;            //告警序列号
	unsigned int alarmInfo;                    //告警原因和具体的问题，高2字节表示原因代码，低2字节表示具体原因
	unsigned int alarmEntityType;              //告警实体，如E1、L2 PRI、时钟等
	unsigned int alarmEntityInstance;          //表示告警发生在实体的哪个位置，(机框ID-插槽ID-端口ID 分别减1）
	unsigned int alarmClass;                   //none(0),communication(1),qualityofservice(2),equipment(3),processingerror(4),environmental(5)
	int		  alarmSeverity;                //告警严重度
	unsigned int alarmAckFlag;                 //如果该告警被用户相应，则做出标记
	char         alarmTimeStamp[64];           //告警时间戳
	char         alarmAdditionalInfo[256];     //附加信息
	char         alarmHost[16];                //告警主机
}MBox_AlarmNotify;

typedef void* HUSERINSTANCE;
typedef LONG (CALLBACK * MBOX_CALLBACK)(
										int  nCategory,                         // 消息类型
										MBox_Notify           notify,           // 消息结构体
										HUSERINSTANCE         hInstance         // 保留参数
										);
typedef LONG (CALLBACK * MBOX_ALARMCALLBACK)(
										ALARM_LEVEL  level,                     // 告警类型
										MBox_AlarmNotify      notify,           // 消息结构体
										HUSERINSTANCE         hInstance         // 保留参数
										);
typedef int BOOL;                           //BOOL类型

/************************************************************************/
/* 网管类型定义                                                                 */
/************************************************************************/
 typedef enum{
	 active = 1,                                //表明状态行是可用的
	 notInService,                              //表明行存在但不可用
	 notReady,                                  //表明存在，但因为缺少必要的信息而不能用
	 createAndGo,                               //有管理者设置，表明希望创建一个概念行并设置该行的状态列对象为active
	 createAndWait,                             //有管理者设置，表明希望创建一个概念行，但不可用
	 destroy                                    //删除行
 };

 //节点信息
typedef struct _tagNode
{
	char nodeName[33];
	int nodeType;                                       //设备类型
	char netManegeInterfaceIP[MAX_IP4];                  //网管口地址
	char netManegeInterfaceMask[MAX_IP4];                //网管口掩码
	char trafficInterfaceIp[MAX_IP4];                    //业务口IP
	char trafficInterfaceMask[MAX_IP4];                  //业务口IP
	char dspSrcIP[MAX_IP4];                              //DSP地址	
	char versionInfo[512];                               //版本信息，用于获取
	char serialNumber[512];                              //节点序列号，用于获取
} NODE_INFO;


 //用户详细信息
 typedef struct SUB_DETAILED_INFO 
 {
	 int   subType;                             //用户类型
	 char  subNumber[MAX_SUBNUM_LEN+1];         //用户号码
	 char  authKey[MAX_AUTH_KEY_LEN+1];           //鉴权码，0-16，0-f的数字	
	 char  DIDNumber[MAX_DID_LEN+1];            //直播号码，最大15位
	 uint32   supplementSerive;                    //增补服务 
	 char  subGroup[MAX_GROUP_LEN+1];           //用户所属组
	 int   subPriority;                         //优先级
	 char  fxsPort[MAX_PORTMODULE_LEN+1];       //fxs
	 char  cfuNumber[MAX_PHONENUMER_LEN+1];     //无条件转接 号码
	 char  cfbNumber[MAX_PHONENUMER_LEN+1];     //遇忙转接 号码
	 char  cfnrNumber[MAX_PHONENUMER_LEN+1];    //无应答转接号码
	 char  cfurNumber[MAX_PHONENUMER_LEN+1];    //用户不可及转接号码
	 char  associationNum1[MAX_PHONENUMER_LEN+1];    //关联号码1，如打用户号码，该关联号码也振铃
	 char  associationNum2[MAX_PHONENUMER_LEN+1];    //关联号码2
	 char  subPassword[MAX_SIPPWD_LEN+1];       //用户密码
	 int   subPwdLevel;                         //用户密码级别
	 int   subPwdStatus;                        //密码状态，inservice outofService
	 char  fxoPort[MAX_PORTMODULE_LEN+1];       //"#-#-#"
	 int   acTimeHour;                          //告警闹钟，小时
	 int   acTimeMinute;                        //告警闹钟，分钟
	 int   subStatus;                           //用户状态
	 int   subBlockStatus;                      //normal(1)blocked(2),创建时默认为normal
	 //int   rowStatus;                         //创建用createAndGo或者createAndWait 删除用destroy 其余作为修改
	 char  cfpfNumber[MAX_PHONENUMER_LEN+1];    //关机转接号码
	 char  sIPSubPassword[MAX_SIPPWD_LEN+1];    //SIP密码（3..16）
	 char  umtsImsi[MAX_3GUMTSIMSI_LEN+1];      //3g号码标识
	 int   umtsRan;                             //UMTS RAN(Radio Access Network) type.1: wcdma(0) 2: td-scdma(1) 3: fdd-lte(2) 4: td-lte(3)
 }SUB_DETAILED_INFO;

 //用户号码基类型
 typedef struct tagBaseSubInfo 
 {
	 int  subType;                                //用户类型
	 uint32  supplementSerive;                       //增补服务,作为sip用户，只能是丢话、短信通知、遇忙通知三项的组合
	 int  userPriority;                           //表示可以拨打市话、长途等
	 int  umtsRan;                                //: ran_wcdma(0) 2: ran_td_scdma(1)3: ran_fdd_lte(2) 4: ran_td_lte(3)，默认为0
 	 char userNumber[MAX_USER_NUMBER_LEN+1];      //用户号码	 
	 char sipPassword[MAX_SIPPWD_LEN+1];          //sip密码
	 char p3gUmtsImsi[MAX_3GUMTSIMSI_LEN+1];
	 char authKey[MAX_AUTH_KEY_LEN+1];            //sip可以忽略，如果未设备默认与用户号码相同，3G必须是32个数字文本
 } SUB_BASE_INFO;

  /**
 * 批量增加用户结构
 */

 typedef enum ALARM_CLASS_CATEGORY
 {
	 ALM_NONE             = 0,    
	 ALM_COMMUNITCATION   = 1,       //通信告警 
     ALM_QUALITYOFSERVICE = 2,       //服务质量告警
	 ALM_EQUIPMENT        = 3,       //设备告警
	 ALM_PROCSSINGERROR   = 4,       
	 ALM_ENVIRONMENTAL    = 5        //环境告警
 }ALARM_CLASS_CATEGORY;


 typedef struct tagRouteGrp  
 {
	uint32 ID;
	char routeGroupName[MAX_NAME];
 } RouteGroup;

 //静态路由信息
 typedef struct tagStaticRoutingInfo
 {
	 char szNet[MAX_IP4];
	 char szMask[MAX_IP4];
	 char szGateWay[MAX_IP4];
 } STATIC_ROUTING_INFO;

 //录音服务器配置
 typedef struct tagRecordServerConf
 {
	 char szRecordServerIp[MAX_IP4];
	 BOOL bSupport; //no(1) yes(2)
	 int  status;   //down(1) up(2)
 } RECORD_SERVER_CONFIGURE;

  //路由配置信息
 typedef struct tagRouteConfig
 {
	 int routeID;
	 int routeGroupID;
	 int routeType;//1: btw(1) 2: ogt(2) 3: ict(3) 4: reg(4) 5: pl(5) 6: esme(6) 7: ecsc-uplk(7) 8: csc-uplk(8) int routeType;
	 char routeName[MAX_ROUTE_NAME+1];
 } ROUTE_CONFIG;

 //呼叫源
 typedef struct tagCallSource
 {
	 int callSourceID;
	 int callSourceMainType;
	 int callSourceSubType;
	 int callSourceValue;
 }CALLSOURCE;

 //路由规则
 typedef struct tagRoutingRule
 {
	 int sourceRuleSelectIndex;
	 int destRuleSelectIndex;
	 int routeGroupIndex;            //指的是路由组Index
 }ROUTING_RULE;

 //呼叫源规则
 typedef struct tagCallSourceRule
 {
	 int callSourceIndex;
	 int seviceType;                //any(1) voice(2) data(3) sms(4) slr(5)
	 int minReceiveNumLength;       //指的是路由组Index
 }CALLSOURCE_RULE;

 //Sip服务接入点信息
 typedef struct tagSipSap
 {
	 int sipSapID;
	 int sipSapPort;                 //默认5060
	 int netProtocal;                //udp:1,tcp:2
 } SIP_SAP_INFO;

 //SIP中继
 typedef struct tagSipTrunk
 {
	 int trunkID;
	 int trunkInterfaceType;         //接口类型,内部(1),外部(2)，默认外部
	 int trunkRoutingID;             //路由ID
	 int trunkPriority;              //优先级,主(1),从(2)，默认主
	 int trunkSipSapID;              //SIP接入点ID
	 int trunkMaxChannel;            //最大通道(1~128)
	 int trunkPlayTone;              //是否放音,是(1),否(2),默认1
	 char peerIpAddress[MAX_IP4];    //对端IP地址
	 int  peerPort;                  //对端端口号
	 int  configureStatus;           //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
	 int  operationStatus;           //up(2) down(1)
	 int  heartBeatSupport;          //yes(1) no(0)
 }SIP_TRUNK_INFO;

 //PRI中继
 typedef struct tagPriTrunk
 {
	 int trunkID;
	 int trunkInterfaceType;         //接口类型,内部(1),外部(2)，默认外部
	 int trunkRoutingID;             //路由ID
	 int trunkPriority;              //优先级,主(1),从(2)，默认主
	 int configureStatus;            //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
	 int operationStatus;            //up(2) down(1)
	 int linkCount;                  //最大通道(0~255)
	 int linkType;                   //链路类型 E1(1),T1(2)
	 int PbxType;                    //交换机类型1: unknown(1) 2: avaya(2)3: nortel(3)4: alcatel(4) 5: siemens(5) 6: oulian(6)7: shenou(7) 8: utstarcom(8) 9: microxel(9)
 }PRI_TRUNK_INFO;

 //PRI(T1)承载信道
typedef struct tagT1
{
	int priID;                      //中继号
	int machineID;                  //机身号，必须是1
	int slotID;                     //槽位号,必须是3
	int e1Port;                     //E1口,从1开始
	int linkID;                     //链接ID，如果与对端的E1口的某条link进行通信，需要把linkID设置成和对端同样的ID
	int channelType;                //1: bothway(1)	2: outgoing(2) 3: incoming(3)
	int configureStatus;
	int operationStatus;
	int E1bundle;                   //表示第几个信道，第16个信道不作为承载信道
} T1_LINK;

#define  ACT_ACTIVE         1       //激活
#define  ACT_DEACTIVE       2       //去激活
//信令通道信道
typedef struct tagSigLink
{
	int priID;
	int machineID;                  //机身号
	int slotID;                     //槽位号
	int e1Port;                     //E1口
	int linkID;                     //和对端通信的逻辑链接
	int portType;                   //q931(1) qSIG(2),默认1
	int theEnd;                     //用户侧：1，网络侧：2，默认1
	int peerProvideVoicePrompt;     //是:1,否:2,默认否
	int sendVoicePrompt;            //是:1,否:2,默认是 
	int E1bundle;                   //表示第几个信道，默认为16
} SIG_LINK;
typedef enum{
	SERVICE       = 1,                   //服务
	SERVICE_CODE  = 2,                   //业务接入码
	CALL_IN       = 3,                   //入局，或者叫，呼入 
	CALL_OUT      = 4                    //出局，或者叫，呼出
} CALLED_ANA_RULE_TYPE;

typedef enum{
	PHOHONIST    = 1,                 //服务台(SERVICE)
	CPD          = 2,                 //呼叫代答拨号(SERVICE)
	VM           = 3,                 //语音信箱(SERVICE)
	EXCHG        = 4,                 //总机
	CONF         = 5,                 //会议电话
	SGI          = 6,                 //短消息组标识(SERVICE)
	ESME         = 7,                 //呼叫代答拨号
	ROAM         = 8,                 //漫游(SERVICE)(CALL_OUT)
	CFB_REG      = 9,                 //遇忙前转登记(SERVICE_CODE)
	CFB_CANC     = 10,                //遇忙前转取消(SERVICE_CODE)
	CFB_CONF     = 11,                //遇忙前转查询(SERVICE_CODE)
	CFNR_REG     = 12,                //无应答前转登记(SERVICE_CODE)
	CFNR_CANC    = 13,                //无应答前转取消(SERVICE_CODE)
	CFNR_CONF    = 14,                //无应答前转查询(SERVICE_CODE)
	cfu_reg      = 15,                //无条件前转登记(SERVICE_CODE)
	CFU_CANC     = 16,                //无条件前转取消(SERVICE_CODE)
	CFU_CONF     = 17,                //无条件前转查询(SERVICE_CODE)
	CFUR_REG     = 18,                //不可及前转登记(SERVICE_CODE)
	CFUR_CANC    = 19,                //不可及前转取消(SERVICE_CODE)
	CFUR_CONF    = 20,                //不可及前转查询(SERVICE_CODE)
	CFPF_REG     = 21,                //关机前转登记(SERVICE_CODE)
	CFPF_CANC    = 22,                //关机前转取消(SERVICE_CODE)
	CFPF_CONF    = 23,                //关机前转查询(SERVICE_CODE)
	CT_REG       = 24,                //呼叫转接登记(SERVICE_CODE)
	CT_CANC      = 25,                //呼叫转接取消(SERVICE_CODE)
	CT_CONF      = 26,                //呼叫转接查询(SERVICE_CODE)
	CW_REG       = 27,                //呼叫等待登记(SERVICE_CODE)
	CW_CANC      = 28,                //呼叫等待登记(SERVICE_CODE)
	CW_CONF      = 29,                //呼叫等待登记(SERVICE_CODE)
	DND_REG      = 30,                //免打扰登记(SERVICE_CODE)
	DND_CANC     = 31,                //免打扰登记(SERVICE_CODE)
	DND_CONF     = 32,                //免打扰登记(SERVICE_CODE)
	CP_REG       = 33,                //呼叫代答登记(SERVICE_CODE)
	CP_CANC      = 34,                //呼叫代答登记(SERVICE_CODE)
	CP_CONF      = 35,                //呼叫代答登记(SERVICE_CODE)
	CFTVM_REG    = 36,                //转语音信箱登记(SERVICE_CODE)
	CFTVM_CANC   = 37,                //转语音信箱取消(SERVICE_CODE)
	CFTVM_CONF   = 38,                //转语音信箱查询(SERVICE_CODE)
	CFTT_REG     = 39,                //转话务台登记(SERVICE_CODE)
	CFTT_CANC    = 40,                //转话务台查询(SERVICE_CODE)
	CFTT_CONF    = 41,                //转话务台登记(SERVICE_CODE)
	AC_REG       = 42,                //闹钟呼叫登记(SERVICE_CODE)
	AC_CANC      = 43,                //闹钟呼叫取消(SERVICE_CODE)
	AC_CONF      = 44,                //闹钟呼叫查询(SERVICE_CODE)
	SUB          = 45,                //用户(CALL_IN)
	ECSC         = 46,                //外部短消息实体(CALL_OUT)
	CSC          = 47,                //(CALL_IN)(CALL_OUT)
	ANY          = 48,                //任何(CALL_IN)(CALL_OUT)
	INTRA        = 49,                //内联(CALL_OUT)
	LOCAL        = 50,                //本地(CALL_OUT)
	TOLL         = 51,                //长途(CALL_OUT)
	INTERNATIONAL = 52,               //国际长途(CALL_OUT)
	ABSENT_REG    = 53,               //(SERVICE_CODE)
	ABSENT_CANC   = 54,               //(SERVICE_CODE)
	ABSENT_CONF   = 55,               //(SERVICE_CODE)
	EMC           = 56,               //紧急呼叫(CALL_IN)(CALL_OUT)
	ROAM_PL       = 57,               //(SERVICE)
	ROAM_SC       = 58,               //(SERVICE)
	ROAM_SMSG     = 59,               //(SERVICE)
	FD            = 60,               //(SERVICE)
	MON           = 61,               //(SERVICE)
	MULTICAST     = 62,                 //组播(SERVICE)
	LEMC          = 63 //(SERVICE)
} CALLED_ANA_RULE_SUB_TYPE;

//被叫号码分析规则
typedef struct tagCalledAnalysisRule
{	
	int ruleID;
	int sourceId;
	char calledNum[5];                   //最大4位数字
	int calledNumDigitsCount;            //被叫号码位数
	int ruleType;                        //被叫分析规则类型1: any(1)	2: voice(2)	3: data(3)4:sms(4)5: slr(5)
	int ruleSubType;                     //被叫分析规则子类型
	int destRouteSelID;                  //路由选择索引，对应相应的路由组ID
	int calledNumTransAct;               //号码转换动作,插入1，删除2，替换3
	int calledTransPos;                  //变换位置
	int calledTransLen;                  //变换长度
	char calledTransTargetStr[5];        //变换目标字符串
}CALLED_ANALYSIS_RULE;

//Trap服务器地址
typedef struct tagTrapServer
{
	char trapServer1[MAX_IP4];
	char trapServer2[MAX_IP4];
	char trapServer3[MAX_IP4];
	char trapServer4[MAX_IP4];

}TRAP_SERVERS;
//时钟源
typedef struct tagClockSource
{
	int priority;
	int type; //none(-1)2: internal(-2)3: external(-3)	4: e1(-4)
	int port;
}CLOCKSOURCE;

//FAP
typedef struct tagFap
{
	int  fapID;                 //0~256
	int  fapRanType;            //UMTS RAN type
	char*  fapIdentify;           //0~255
	char* fapName;           //最大30
	int  fapStatus;             //输出
	char fapIpAddress[MAX_IP4];
	int  SctpPort;              //SCTP端口,输出
	int  SeGWLinkID;            //安全网关连接ID,输出
}FEMTO_AP;

typedef struct tagShortMessageEntity
{
	char * esmeSystemId;
	char * esmePassword;
	int  esmeId;
	int  esmeRouteId;
}SHORT_MESSAGE_ENTITY;




 //SMS
#endif