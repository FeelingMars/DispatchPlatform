#ifndef _bl8000typedef_H
#define _bl8000typedef_H
#include "macrodef.h"
#include <map>
#include <windows.h>
#include <snmp_pp/snmp_pp.h>
using namespace std;

/*宏定义*/
#define MAX_NAME        256
#define MAX_IP4			16
#define MAX_LOGIN_NAME  16
#define MAX_LOGIN_PWD	16
#define MAX_SERIALNO	48
#define MBOX_USR_LEN    256
#define MBOX_PASS_LEN   64
#define MBOX_ANSWER_LEN 1024

#define MAX_SUBNUM_LEN             8
#define MAX_PSNUM_LEN              13
#define MAX_PSAUTH_LEN             16
#define MAX_SIPAUTH_LEN            8
#define MAX_SIPPWD_LEN             12
#define MAX_PSIDENTIFICATION_LEN   7
#define MAX_DID_LEN                15   /*直播号码最大长度*/
#define MAX_PORTMODULE_LEN         5    /*通信接口模块格式长度*/   
#define MAX_USER_PASSWORD_LEN      5
#define MAX_PHONENUMER_LEN         30 
#define MAX_SIP_PWD_LEN            16
#define MAX_GROUP_LEN              32

#define MBOX_HANDLE        int
#define MBOX_ERRORCODE     int
#define PHONE_NUMBER       unsigned int       
#define USER_COUNT         unsigned int      
#define CONF_MEMBER_NUMBER unsigned int
#define CONFID             unsigned int       
#define USER_STATUS        unsigned int 

/*用户类型*/
#define SIP         0x0100
#define PS          0x0001

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
	mboxDispatchCmdHost = 0,
	mboxDispatchCmdTransactionId = 1,
	mboxDispatchCmdType = 2,
	mboxDispatchCmdDispatcher = 3,
	mboxDispatchCmdUserCount = 4,
	mboxDispatchCmdUserList = 5,
	mboxDispatchCmdUserState = 6,
	mboxDispatchCmdConfId = 7,
	mboxDispatchCmdConfCount = 8,
	mboxDispatchCmdConfList =9

};

typedef enum enUserStatusOid
{
	mboxSPMSubNumber = 0,
	mboxSPMSubType = 1,
	mboxSPMSubSuppService = 2,
	mboxSPMSubStatus = 3,
	mboxSPMSubBlockStatus = 4,
	mboxSPMCallConfId = 5,
	mboxSPMCallPeerNumber = 6,
	mboxSPMRecordingStatus = 7,
	mboxSPMHookOffStatus = 8
};

typedef enum enDispatchErrorCause
{
	noError = 0,
	//common error cause
	errorParameter                     =1,
	errorCmdType                       =2,
	invalidInDispatcherCurrentState    =3,
	invalidInTphistCurrentState        =4,
	invalidInUserCurrentState          =5,
	transactionIsReleased              =6,
	memAllocFail                       =7,
	memDeallocFail                     =8,
	msgSendFail                        =9,
	numberEmpty                        =10,
	serviceNotSupport                  =11,
	noPrivilege                        =12,
	noMatchedUser                      =13,
	insertCallFail                     =14,
	monitorCallFail                    =15,
	recordCallFail                     =16,
	stopRecordFail                     =17,
	stopMonitorFail                    =18,
	tphistIsBusy                       =19,
	noIdleTphist                       =20,
	noIdleRecorder                     =21,

	//dispatched user error cause
	userNotExist                       =22,
	userNotIdle                        =23,
	userNotConnected                   =24,
	userNotRinging                     =25,
	userNotBusy                        =26,
	userIsIdle                         =27,
	userIsConnected                    =28,
	userIsRinging                      =29,
	userIsBusy                         =30,
	userIsDisconnected                 =31,
	userIsPowerOff                     =32,
	userIsOffLine                      =33,
	userConnFail                       =34,
	userNoRsp                          =35,
	userNoAnswer                       =36,

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
	Dispatch_Success           = 0,
	Dispatch_Released          = 254, 
	Dispatch_Failure           = 255,
	Dispatch_UserRinging       = 1,
	Dispatch_UserConnected     = 2,
	Dispatch_UserDisconnected  = 3,
	Dispatch_UserRedirected    = 4,  
	Dispatch_UserHold          = 5,   
	Dispatch_UserCallFail      = 6,
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
	int iUserList[2112];	
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
	Error_Memory_Allocate            = -1,              /**< 数据超时 */
	Error_TIMEOUT                    = -2,		        /**< 数据超时 */
	Error_NETWORK                    = -3,		        /**< 网络错误 */
	Error_Net_Protocol               = -4,              /**< 协议错误 */
	Error_TargetHost_Not_EXIST       = -5,		        /**< 目标主机错误 */
	Error_Buffer                     = -6,		        /**< 数据缓冲区错误 */
	Error_System_Init                = -7,              /**< 未初始化 */
	Error_Undo                       = -15,             /**< 在创建对象时，表示对象已存在 
														 **< 在删除对象时，表示被删除对象不存在*/
    Error_OVERLOAD                   = -16,             /**< 用户号码数量已达上限*/ 
	Error_PARAMETER                  = -8,              /**< 用户参数错误*/ 
	Error_Pdu                        = -9               /**< 协议数据单元非法 */

}ERRORCODE;


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


 /**
 * 批量增加用户结构
 */

 typedef struct  BatchCrteSub
 {
	int	  action;
	int	  subscriberType;                       //so-ps(1) or sip(4)	
	char  firstNumber[ MAX_SUBNUM_LEN+1 ];      //第一个用户号码
	int   subscriberCount;                      //批量创建用户数量,(1-1000)
	char  firstPSNumber[ MAX_PSNUM_LEN+1 ];     //第一个小灵通用户号码
	char  PSAuthKey[ MAX_PSAUTH_LEN+1 ];        //ps鉴权码
    char  sipAuthName[MAX_SIPAUTH_LEN+1];       //First sip sub auth number, 2~8 digits.
	char  sipPassword[MAX_SIPPWD_LEN+1];        //sip密码 3-12 digits.
	int   sipPwdMode;                           //密码模式
	int   createSuccessCount;                   //返回成功创建用户的数量
	int   SupplementaryService;                 //增补服务，丢号服务（0x00000020），遇忙通知(0x00000040),短信服务(0x00000200)
 }BatchCreateSubscriberInfo;

 typedef enum{
	 active = 1,                                //表明状态行是可用的
	 notInService,                              //表明行存在但不可用
	 notReady,                                  //表明存在，但因为缺少必要的信息而不能用
	 createAndGo,                               //有管理者设置，表明希望创建一个概念行并设置该行的状态列对象为active
	 createAndWait,                             //有管理者设置，表明希望创建一个概念行，但不可用
	 destroy                                    //删除行
 };

 typedef struct SUB_DETAILED_INFO 
 {
	 char  subNumber[MAX_SUBNUM_LEN+1];         //用户号码
	 char  PSNumber[MAX_PSNUM_LEN+1];           //PS号码
	 char  authKey[MAX_PSAUTH_LEN+1];           //鉴权码，0-16，0-f的数字
	 int   subType;                             //用户类型
	 char  PSID[MAX_PSIDENTIFICATION_LEN+1];    //PS标识符，7位，0-f的数字
	 char  DIDNumber[MAX_DID_LEN+1];            //直播号码，最大15位
	 int   supplementSerive;                    //增补服务 
	 char  subGroup[MAX_GROUP_LEN+1];           //用户所属组
	 int   subPriority;                         //优先级
	 char  fxsPort[MAX_PORTMODULE_LEN+1];       //fxs
	 char  cfuNumber[MAX_PHONENUMER_LEN+1];     //无条件转接 号码
	 char  cfbNumber[MAX_PHONENUMER_LEN+1];     //遇忙转接 号码
	 char  cfnrNumber[MAX_PHONENUMER_LEN+1];    //无应答转接号码
	 char  cfurNumber[MAX_PHONENUMER_LEN+1];    //用户不可及转接号码
	 char  associationNum1[MAX_PHONENUMER_LEN+1];    //关联号码1，如打用户号码，该关联号码也振铃
	 char  associationNum2[MAX_PHONENUMER_LEN+1];    //关联号码2
	 char  subPassword[MAX_USER_PASSWORD_LEN+1];//用户密码
	 int   subPwdLevel;                         //用户密码级别
	 int   subPwdStatus;                        //密码状态，inservice outofService
	 char  fxoPort[MAX_PORTMODULE_LEN+1];       //"#-#-#"
	 int   acTimeHour;                          //告警闹钟，小时
	 int   acTimeMinute;                        //告警闹钟，分钟
	 int   subStatus;                           //用户状态
	 int   subBlockStatus;                      //normal(1)blocked(2),创建时默认为normal
	 //int   rowStatus;                         //创建用createAndGo或者createAndWait 删除用destroy 其余作为修改
	 char  cfpfNumber[MAX_PHONENUMER_LEN+1]; //关机转接号码
	 char  sIPSubPassword[MAX_SIP_PWD_LEN+1];   //SIP密码（3..16）
 }SUB_DETAILED_INFO;

 typedef struct SubscriberBaseInfo 
 {
	 char  subNumber[MAX_SUBNUM_LEN+1];         //用户号码
	 char  PSNumber[MAX_PSNUM_LEN+1];           //PS号码
	 char  authKey[MAX_PSAUTH_LEN+1];           //鉴权码，0-16，0-f的数字
	 int   subType;                             //用户类型
	 char  PSID[MAX_PSIDENTIFICATION_LEN+1];    //PS标识符，7位，0-f的数字
	 int   supplementSerive;                    //增补服务,作为sip用户，只能是丢话、短信通知、遇忙通知三项的组合 	
 }SUB_BASE_INFO;



 typedef enum ALARM_CLASS_CATEGORY
 {
	 ALM_NONE             = 0,    
	 ALM_COMMUNITCATION   = 1,       //通信告警 
     ALM_QUALITYOFSERVICE = 2,       //服务质量告警
	 ALM_EQUIPMENT        = 3,       //设备告警
	 ALM_PROCSSINGERROR   = 4,       
	 ALM_ENVIRONMENTAL    = 5        //环境告警
 }ALARM_CLASS_CATEGORY;


 typedef struct _tagRouteGrp  
 {
	uint32 ID;
	char routeGroupName[MAX_NAME];
 }RouteGroup;



#endif