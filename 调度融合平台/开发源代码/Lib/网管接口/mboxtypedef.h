/******************************************************************************
 *  ��Ȩ���У�C��2012-2013���Ͼ���·�Զ���ϵͳ�������ι�˾                    *
 *  ��������Ȩ����                                                            *
 ******************************************************************************
 *  ���� : �ܹ���
 *  ���� : ���Ƚ��������ݽṹ����
 *  �汾 : 1.0
 *****************************************************************************/
/*  �޸ļ�¼: 
      ����       �汾    �޸���             �޸�����

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

/*�豸����*/
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



/*�궨��*/
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
#define MAX_DID_LEN                15   /*ֱ��������󳤶�*/
#define MAX_PORTMODULE_LEN          5   /*ͨ�Žӿ�ģ���ʽ����*/   
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

/*�û�����*/
#define SIP                     4   //SIP�ֻ�
#define PS                      1   //С��ͨ
#define P3G                     6   //3G�ֻ�


/* ������������ */
#define SPM_SRV_NULL            0x00000000		/* �޷������ */
#define SPM_DONOT_DISTURB       0x00000001		/* ����� */		
#define SPM_CALL_WAITING        0x00000002      /* ���еȴ� */     
#define SPM_CFW_UNCON           0x00000004      /* ������ǰת */	
#define SPM_CFW_BUSY            0x00000008      /* ��æǰת */	
#define SPM_CFW_NO_REPLY        0x00000010      /* ��Ӧ��ǰת */	
#define SPM_MISS_CALL           0x00000020      /* ����֪ͨ */	
#define SPM_MISS_CALL_ON_BUSY   0x00000040      
#define SPM_CALL_TRANSFER       0x00000080      /* ����ת�� */	
#define SPM_THREE_PARTY         0x00000100      /* ����ͨ�� */	
#define SPM_SMS                 0x00000200      /* ���ŷ��� */	
#define SPM_SMS_GROUP           0x00000400      
#define SPM_DDI                 0x00000800      /* ֱ�Ӳ������ */	
#define SPM_DISPLAY_NUM         0x00001000      
#define SPM_ASSO_NUM            0x00002000      
#define SPM_TELEPHONIST         0x00004000      /* ����Ա���� */	
#define SPM_CFVM                0x00008000
#define SPM_CALL_PICKUP         0x00010000
#define SPM_ALARM_CALL          0x00020000     
#define SPM_CFW_UNREACHABLE     0x00040000      /* ���ɼ�ǰת */	
#define SPM_PERMANENCE_LINE     0x00080000      /* ����ר�� */	   
#define SPM_INUMBER             0x00100000      /* inumber���� */	
#define SPM_PERSONAL_ACCOUNT    0x00200000      
#define SPM_TELEAGENT           0x00400000      /* ����Ա���� */	
#define SPM_ACCESSEXTENSION     0x00800000
#define SPM_VM                  0x01000000
#define SPM_CF_POWEROFF         0x02000000
#define SPM_ROAM                0x04000000    
#define SPM_SUB_GRP             0x08000000 
#define SPM_CONFERENCE_CALL     0x10000000
#define SPM_DISPATCH            0x20000000      /* ���� */
#define SPM_INUM_ASSO           0x40000000  
#define SPM_AUTO_RECORDING      0x80000000      /* �Զ�¼�� */


typedef enum DispatchCmd  
{
	makeCall             = 1,   /**--���У�������ͨ����̨�����û����Ѿ�����Ա�����û�������Ա������hold״̬�����û�*/
	createConf           = 2,   /**--��������*/
	confAddPart          = 3,   /**--��ӻ����Ա*/
	confDelPart          = 4,   /**--�߳������Ա*/
	confForbidPart       = 5,   /**--����*/
	confUnforbidPart     = 6,   /**--�������*/
	confIsolatePart      = 7,   /**--����*/
	confUnisolatePart    = 8,   /**--�������*/
	delConf              = 9,   /**--��������*/
	insertCall           = 10,  /**--ǿ��*/
	monitorCall          = 11,  /**--����*/
	recordCall           = 12,  /**--¼��*/
	stopRecord           = 13,  /**--ֹͣ¼��*/
	discCall             = 14,  /**--ǿ��*/
	deliverCall          = 15,  /**--ת��*/
	insteadAnswer        = 16,  /**--����*/
	snatchCall           = 17,  /**--ǿ��*/
	selectAnswer         = 18,  /**--Ӧ�𣬻���ԱӦ��ȴ���������ĺ���*/
	groupAnswer          = 19,  /**--Ⱥ�𣬻���ԱȺ��ȴ���������ĺ���*/
	holdCall             = 20,  /**--���ֺ��У��ѻ���Ա��ǰ���з��뵽�ȴ���������*/
	groupCall            = 22,  /**--Ⱥ��*/          
	getConfList          = 29,  /**--��ȡ����̨������Ļ����б�*/
	getConfPartList      = 30,  /**--��ȡ�����Ա�б�*/
	getWaitingUserList   = 31,  /**--��ȡ�ȴ����к����б�*/
	lemcGetCallList      = 40,  /**--��ȡ�ڲ������������к����б�*/
	lemcSelectAnswer     = 41,   /**--Ӧ�𣬵���ԱӦ���ڲ��������ж�������ĺ���*/
	GetDeviceStatus      = 80    /*--��ȡ�豸����״̬--�Զ�������*/
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
	char szMboxIP[MAX_IP4+1];                          //IP��ַ
	//����
	char szMboxUserName[MBOX_USR_LEN+1];                //�û���
	char szMboxPassword[MBOX_PASS_LEN+1];               //����
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
	ERROR_NETWORK                    = 20,		         /**< ������� */
	ERROR_TARGET_NOT_EXIST           = 21,               /**< SNMPĿ�겻���� */
	ERROR_BUFFER_TOO_SMALL           = 22,		         /**< ���ݻ��������� */
    ERROR_OVERLOAD                   = 23,               /**< �û����������Ѵ�����*/ 
	ERROR_PARAMETER                  = 24,               /**< �û���������*/ 
	ERROR_NUMBER_NOT_EXIST           = 25,               /**< �û����벻����*/ 
	ERROR_DEVICE_DOWN                = 26,               /**< �豸�����߻�����δ����*/ 
	ERROR_NUMBER_TYPE                = 27,               /**< �������Ͳ���ȷ*/ 
	ERROR_NUMBERICAL_OVERFLOW        = 28,               /**< ȡֵ������Χ*/ 
	ERROR_UNDO_FAIL                  = 15                //�����������ݲ����ڻ����Ѵ���
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
{                                //ÿһ���ֽڱ�ʾһ�������Ա״̬��״ֵ̬�Ķ������£�
	DU_ST_NULL = 0,     		//���У�δ�����û�����
	DU_ST_WAIT_PROCESS,			//��δִ�к�������
	DU_ST_CALL_PROCEEDING,		//���й�����
	DU_ST_RINGING,				//��������
	DU_ST_CONNECTED,			//�������ӣ�ͨ��������
	DU_ST_DISCONNECTED,			//�Ͽ����ӻ����ʧ��
	DU_ST_MONITORING,			//����̨��״̬
	DU_ST_RECORDING,			//¼��̨��״̬
	DU_ST_FORBIDED,				//�����ԵĻ����Ա
	DU_ST_ISOLATED				//������Ļ����Ա
}enConfUserState;


typedef struct
{
	short int  confMode;   //0: floating conf    1: no-floating conf
	short int  confId;     //0: ��δ���������conf id     >=1: ����������conf id
} mbox_dispatch_conf_info_t;
//ÿһ��mbox_dispatch_conf_info_tռ��4���ֽڣ���mboxDispatchCmdConfList���4*16=64�ֽ�

typedef enum LINE_MESSAGE_CATEGORY
{
	CATEGORY_SUBSTATUS_NOTIFY = 0,	     /**�û�״̬��Ϣ*/
	CATEGORY_WAITINGQUEUESTATUS_NOTIFY,	 /**�ȴ�������Ϣ*/
	CATEGORY_DISPATCHSTATUS_NOTIFY,		 /**����״̬��Ϣ��Ϣ*/
	CATEGORY_LEMCQUEUESTATUS_NOTIFY	     /**��������״̬��Ϣ*/
} MBOX_MESSAGE_CATEGORY;

typedef struct MBox_Notify
{
	unsigned int   uSubscriberStatus;         //�û���·״̬,�û�״̬֪ͨ��Ч
	unsigned int   uRecordingStatus;          //�û�¼��״̬
	unsigned int   uHookOffStatus;            //�û�ժ��״̬(����)
	unsigned int   uDispatchStatus;           //����ִ��״̬
	unsigned int   uDispatchCmdType;          //�������ͣ�����Ϊ�û�״̬������״̬���ȴ�����״̬�ͽ���״̬
	unsigned int   uDispatchCmdSubType;       //�������������ͣ�����״̬֪ͨ��Ч
	unsigned int   uDispatchCmdTransactionId; //���ȻỰID
	unsigned int   uUserCount;                //�û�����
	unsigned int   uDispatchConfId;           //���Ȼ���ID
	unsigned int   uDispatchErrorCause;       //����ʧ��ԭ��
	unsigned int   uWaitingUserStatus;        //�û��ȴ�����״̬
	unsigned int   uLemcStatus;               //�������ж���״̬
	unsigned int   uSubscriberNumber;         //�û�����
	unsigned int   uPeerPartNumber;           //�Է�����
	unsigned int   uDispatchCmdDispatcher;    //������ȵ��û�����
	unsigned int   uDispatchedUser;           //�����ȵ��û�����
	unsigned int   uDispatchedUserOld;
	unsigned int   uWaitingUserNumber;
	unsigned int   uLemcCallingNumber;        //����������е��û�����
	unsigned int   uLemcCalledNumber;         //�������к�����1001
	unsigned int   uEventTimeStamp;
	char chDispatchCmdHost[32];               //��������IP
	char chEventAdditionalInfo[64];           //���ȸ�����Ϣ

}MBox_Notify;

typedef enum GENERAL_MGMT_TRAPS
{
	ALARM_NOTITY,                  //�澯֪ͨ
	EVENT_NOTITY                   //�¼�֪ͨ
}GENERAL_MGMT_TRAPS;

typedef enum ALARM_LEVEL
{
	ALM_CRITICAL,                  //�����澯
	ALM_MAJOR,                     //��Ҫ�澯
	ALM_MINOR,                     //��Ҫ�澯
	ALM_WARNING,                   //һ��澯
	ALM_CLEAR                      //����澯
}ALARM_LEVEL;

typedef struct MBox_AlarmNotify
{
	unsigned int alarmSeriesNumber;            //�澯���к�
	unsigned int alarmInfo;                    //�澯ԭ��;�������⣬��2�ֽڱ�ʾԭ����룬��2�ֽڱ�ʾ����ԭ��
	unsigned int alarmEntityType;              //�澯ʵ�壬��E1��L2 PRI��ʱ�ӵ�
	unsigned int alarmEntityInstance;          //��ʾ�澯������ʵ����ĸ�λ�ã�(����ID-���ID-�˿�ID �ֱ��1��
	unsigned int alarmClass;                   //none(0),communication(1),qualityofservice(2),equipment(3),processingerror(4),environmental(5)
	int		  alarmSeverity;                //�澯���ض�
	unsigned int alarmAckFlag;                 //����ø澯���û���Ӧ�����������
	char         alarmTimeStamp[64];           //�澯ʱ���
	char         alarmAdditionalInfo[256];     //������Ϣ
	char         alarmHost[16];                //�澯����
}MBox_AlarmNotify;

typedef void* HUSERINSTANCE;
typedef LONG (CALLBACK * MBOX_CALLBACK)(
										int  nCategory,                         // ��Ϣ����
										MBox_Notify           notify,           // ��Ϣ�ṹ��
										HUSERINSTANCE         hInstance         // ��������
										);
typedef LONG (CALLBACK * MBOX_ALARMCALLBACK)(
										ALARM_LEVEL  level,                     // �澯����
										MBox_AlarmNotify      notify,           // ��Ϣ�ṹ��
										HUSERINSTANCE         hInstance         // ��������
										);
typedef int BOOL;                           //BOOL����

/************************************************************************/
/* �������Ͷ���                                                                 */
/************************************************************************/
 typedef enum{
	 active = 1,                                //����״̬���ǿ��õ�
	 notInService,                              //�����д��ڵ�������
	 notReady,                                  //�������ڣ�����Ϊȱ�ٱ�Ҫ����Ϣ��������
	 createAndGo,                               //�й��������ã�����ϣ������һ�������в����ø��е�״̬�ж���Ϊactive
	 createAndWait,                             //�й��������ã�����ϣ������һ�������У���������
	 destroy                                    //ɾ����
 };

 //�ڵ���Ϣ
typedef struct _tagNode
{
	char nodeName[33];
	int nodeType;                                       //�豸����
	char netManegeInterfaceIP[MAX_IP4];                  //���ܿڵ�ַ
	char netManegeInterfaceMask[MAX_IP4];                //���ܿ�����
	char trafficInterfaceIp[MAX_IP4];                    //ҵ���IP
	char trafficInterfaceMask[MAX_IP4];                  //ҵ���IP
	char dspSrcIP[MAX_IP4];                              //DSP��ַ	
	char versionInfo[512];                               //�汾��Ϣ�����ڻ�ȡ
	char serialNumber[512];                              //�ڵ����кţ����ڻ�ȡ
} NODE_INFO;


 //�û���ϸ��Ϣ
 typedef struct SUB_DETAILED_INFO 
 {
	 int   subType;                             //�û�����
	 char  subNumber[MAX_SUBNUM_LEN+1];         //�û�����
	 char  authKey[MAX_AUTH_KEY_LEN+1];           //��Ȩ�룬0-16��0-f������	
	 char  DIDNumber[MAX_DID_LEN+1];            //ֱ�����룬���15λ
	 uint32   supplementSerive;                    //�������� 
	 char  subGroup[MAX_GROUP_LEN+1];           //�û�������
	 int   subPriority;                         //���ȼ�
	 char  fxsPort[MAX_PORTMODULE_LEN+1];       //fxs
	 char  cfuNumber[MAX_PHONENUMER_LEN+1];     //������ת�� ����
	 char  cfbNumber[MAX_PHONENUMER_LEN+1];     //��æת�� ����
	 char  cfnrNumber[MAX_PHONENUMER_LEN+1];    //��Ӧ��ת�Ӻ���
	 char  cfurNumber[MAX_PHONENUMER_LEN+1];    //�û����ɼ�ת�Ӻ���
	 char  associationNum1[MAX_PHONENUMER_LEN+1];    //��������1������û����룬�ù�������Ҳ����
	 char  associationNum2[MAX_PHONENUMER_LEN+1];    //��������2
	 char  subPassword[MAX_SIPPWD_LEN+1];       //�û�����
	 int   subPwdLevel;                         //�û����뼶��
	 int   subPwdStatus;                        //����״̬��inservice outofService
	 char  fxoPort[MAX_PORTMODULE_LEN+1];       //"#-#-#"
	 int   acTimeHour;                          //�澯���ӣ�Сʱ
	 int   acTimeMinute;                        //�澯���ӣ�����
	 int   subStatus;                           //�û�״̬
	 int   subBlockStatus;                      //normal(1)blocked(2),����ʱĬ��Ϊnormal
	 //int   rowStatus;                         //������createAndGo����createAndWait ɾ����destroy ������Ϊ�޸�
	 char  cfpfNumber[MAX_PHONENUMER_LEN+1];    //�ػ�ת�Ӻ���
	 char  sIPSubPassword[MAX_SIPPWD_LEN+1];    //SIP���루3..16��
	 char  umtsImsi[MAX_3GUMTSIMSI_LEN+1];      //3g�����ʶ
	 int   umtsRan;                             //UMTS RAN(Radio Access Network) type.1: wcdma(0) 2: td-scdma(1) 3: fdd-lte(2) 4: td-lte(3)
 }SUB_DETAILED_INFO;

 //�û����������
 typedef struct tagBaseSubInfo 
 {
	 int  subType;                                //�û�����
	 uint32  supplementSerive;                       //��������,��Ϊsip�û���ֻ���Ƕ���������֪ͨ����æ֪ͨ��������
	 int  userPriority;                           //��ʾ���Բ����л�����;��
	 int  umtsRan;                                //: ran_wcdma(0) 2: ran_td_scdma(1)3: ran_fdd_lte(2) 4: ran_td_lte(3)��Ĭ��Ϊ0
 	 char userNumber[MAX_USER_NUMBER_LEN+1];      //�û�����	 
	 char sipPassword[MAX_SIPPWD_LEN+1];          //sip����
	 char p3gUmtsImsi[MAX_3GUMTSIMSI_LEN+1];
	 char authKey[MAX_AUTH_KEY_LEN+1];            //sip���Ժ��ԣ����δ�豸Ĭ�����û�������ͬ��3G������32�������ı�
 } SUB_BASE_INFO;

  /**
 * ���������û��ṹ
 */

 typedef enum ALARM_CLASS_CATEGORY
 {
	 ALM_NONE             = 0,    
	 ALM_COMMUNITCATION   = 1,       //ͨ�Ÿ澯 
     ALM_QUALITYOFSERVICE = 2,       //���������澯
	 ALM_EQUIPMENT        = 3,       //�豸�澯
	 ALM_PROCSSINGERROR   = 4,       
	 ALM_ENVIRONMENTAL    = 5        //�����澯
 }ALARM_CLASS_CATEGORY;


 typedef struct tagRouteGrp  
 {
	uint32 ID;
	char routeGroupName[MAX_NAME];
 } RouteGroup;

 //��̬·����Ϣ
 typedef struct tagStaticRoutingInfo
 {
	 char szNet[MAX_IP4];
	 char szMask[MAX_IP4];
	 char szGateWay[MAX_IP4];
 } STATIC_ROUTING_INFO;

 //¼������������
 typedef struct tagRecordServerConf
 {
	 char szRecordServerIp[MAX_IP4];
	 BOOL bSupport; //no(1) yes(2)
	 int  status;   //down(1) up(2)
 } RECORD_SERVER_CONFIGURE;

  //·��������Ϣ
 typedef struct tagRouteConfig
 {
	 int routeID;
	 int routeGroupID;
	 int routeType;//1: btw(1) 2: ogt(2) 3: ict(3) 4: reg(4) 5: pl(5) 6: esme(6) 7: ecsc-uplk(7) 8: csc-uplk(8) int routeType;
	 char routeName[MAX_ROUTE_NAME+1];
 } ROUTE_CONFIG;

 //����Դ
 typedef struct tagCallSource
 {
	 int callSourceID;
	 int callSourceMainType;
	 int callSourceSubType;
	 int callSourceValue;
 }CALLSOURCE;

 //·�ɹ���
 typedef struct tagRoutingRule
 {
	 int sourceRuleSelectIndex;
	 int destRuleSelectIndex;
	 int routeGroupIndex;            //ָ����·����Index
 }ROUTING_RULE;

 //����Դ����
 typedef struct tagCallSourceRule
 {
	 int callSourceIndex;
	 int seviceType;                //any(1) voice(2) data(3) sms(4) slr(5)
	 int minReceiveNumLength;       //ָ����·����Index
 }CALLSOURCE_RULE;

 //Sip����������Ϣ
 typedef struct tagSipSap
 {
	 int sipSapID;
	 int sipSapPort;                 //Ĭ��5060
	 int netProtocal;                //udp:1,tcp:2
 } SIP_SAP_INFO;

 //SIP�м�
 typedef struct tagSipTrunk
 {
	 int trunkID;
	 int trunkInterfaceType;         //�ӿ�����,�ڲ�(1),�ⲿ(2)��Ĭ���ⲿ
	 int trunkRoutingID;             //·��ID
	 int trunkPriority;              //���ȼ�,��(1),��(2)��Ĭ����
	 int trunkSipSapID;              //SIP�����ID
	 int trunkMaxChannel;            //���ͨ��(1~128)
	 int trunkPlayTone;              //�Ƿ����,��(1),��(2),Ĭ��1
	 char peerIpAddress[MAX_IP4];    //�Զ�IP��ַ
	 int  peerPort;                  //�Զ˶˿ں�
	 int  configureStatus;           //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
	 int  operationStatus;           //up(2) down(1)
	 int  heartBeatSupport;          //yes(1) no(0)
 }SIP_TRUNK_INFO;

 //PRI�м�
 typedef struct tagPriTrunk
 {
	 int trunkID;
	 int trunkInterfaceType;         //�ӿ�����,�ڲ�(1),�ⲿ(2)��Ĭ���ⲿ
	 int trunkRoutingID;             //·��ID
	 int trunkPriority;              //���ȼ�,��(1),��(2)��Ĭ����
	 int configureStatus;            //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
	 int operationStatus;            //up(2) down(1)
	 int linkCount;                  //���ͨ��(0~255)
	 int linkType;                   //��·���� E1(1),T1(2)
	 int PbxType;                    //����������1: unknown(1) 2: avaya(2)3: nortel(3)4: alcatel(4) 5: siemens(5) 6: oulian(6)7: shenou(7) 8: utstarcom(8) 9: microxel(9)
 }PRI_TRUNK_INFO;

 //PRI(T1)�����ŵ�
typedef struct tagT1
{
	int priID;                      //�м̺�
	int machineID;                  //����ţ�������1
	int slotID;                     //��λ��,������3
	int e1Port;                     //E1��,��1��ʼ
	int linkID;                     //����ID�������Զ˵�E1�ڵ�ĳ��link����ͨ�ţ���Ҫ��linkID���óɺͶԶ�ͬ����ID
	int channelType;                //1: bothway(1)	2: outgoing(2) 3: incoming(3)
	int configureStatus;
	int operationStatus;
	int E1bundle;                   //��ʾ�ڼ����ŵ�����16���ŵ�����Ϊ�����ŵ�
} T1_LINK;

#define  ACT_ACTIVE         1       //����
#define  ACT_DEACTIVE       2       //ȥ����
//����ͨ���ŵ�
typedef struct tagSigLink
{
	int priID;
	int machineID;                  //�����
	int slotID;                     //��λ��
	int e1Port;                     //E1��
	int linkID;                     //�ͶԶ�ͨ�ŵ��߼�����
	int portType;                   //q931(1) qSIG(2),Ĭ��1
	int theEnd;                     //�û��ࣺ1������ࣺ2��Ĭ��1
	int peerProvideVoicePrompt;     //��:1,��:2,Ĭ�Ϸ�
	int sendVoicePrompt;            //��:1,��:2,Ĭ���� 
	int E1bundle;                   //��ʾ�ڼ����ŵ���Ĭ��Ϊ16
} SIG_LINK;
typedef enum{
	SERVICE       = 1,                   //����
	SERVICE_CODE  = 2,                   //ҵ�������
	CALL_IN       = 3,                   //��֣����߽У����� 
	CALL_OUT      = 4                    //���֣����߽У�����
} CALLED_ANA_RULE_TYPE;

typedef enum{
	PHOHONIST    = 1,                 //����̨(SERVICE)
	CPD          = 2,                 //���д��𲦺�(SERVICE)
	VM           = 3,                 //��������(SERVICE)
	EXCHG        = 4,                 //�ܻ�
	CONF         = 5,                 //����绰
	SGI          = 6,                 //����Ϣ���ʶ(SERVICE)
	ESME         = 7,                 //���д��𲦺�
	ROAM         = 8,                 //����(SERVICE)(CALL_OUT)
	CFB_REG      = 9,                 //��æǰת�Ǽ�(SERVICE_CODE)
	CFB_CANC     = 10,                //��æǰתȡ��(SERVICE_CODE)
	CFB_CONF     = 11,                //��æǰת��ѯ(SERVICE_CODE)
	CFNR_REG     = 12,                //��Ӧ��ǰת�Ǽ�(SERVICE_CODE)
	CFNR_CANC    = 13,                //��Ӧ��ǰתȡ��(SERVICE_CODE)
	CFNR_CONF    = 14,                //��Ӧ��ǰת��ѯ(SERVICE_CODE)
	cfu_reg      = 15,                //������ǰת�Ǽ�(SERVICE_CODE)
	CFU_CANC     = 16,                //������ǰתȡ��(SERVICE_CODE)
	CFU_CONF     = 17,                //������ǰת��ѯ(SERVICE_CODE)
	CFUR_REG     = 18,                //���ɼ�ǰת�Ǽ�(SERVICE_CODE)
	CFUR_CANC    = 19,                //���ɼ�ǰתȡ��(SERVICE_CODE)
	CFUR_CONF    = 20,                //���ɼ�ǰת��ѯ(SERVICE_CODE)
	CFPF_REG     = 21,                //�ػ�ǰת�Ǽ�(SERVICE_CODE)
	CFPF_CANC    = 22,                //�ػ�ǰתȡ��(SERVICE_CODE)
	CFPF_CONF    = 23,                //�ػ�ǰת��ѯ(SERVICE_CODE)
	CT_REG       = 24,                //����ת�ӵǼ�(SERVICE_CODE)
	CT_CANC      = 25,                //����ת��ȡ��(SERVICE_CODE)
	CT_CONF      = 26,                //����ת�Ӳ�ѯ(SERVICE_CODE)
	CW_REG       = 27,                //���еȴ��Ǽ�(SERVICE_CODE)
	CW_CANC      = 28,                //���еȴ��Ǽ�(SERVICE_CODE)
	CW_CONF      = 29,                //���еȴ��Ǽ�(SERVICE_CODE)
	DND_REG      = 30,                //����ŵǼ�(SERVICE_CODE)
	DND_CANC     = 31,                //����ŵǼ�(SERVICE_CODE)
	DND_CONF     = 32,                //����ŵǼ�(SERVICE_CODE)
	CP_REG       = 33,                //���д���Ǽ�(SERVICE_CODE)
	CP_CANC      = 34,                //���д���Ǽ�(SERVICE_CODE)
	CP_CONF      = 35,                //���д���Ǽ�(SERVICE_CODE)
	CFTVM_REG    = 36,                //ת��������Ǽ�(SERVICE_CODE)
	CFTVM_CANC   = 37,                //ת��������ȡ��(SERVICE_CODE)
	CFTVM_CONF   = 38,                //ת���������ѯ(SERVICE_CODE)
	CFTT_REG     = 39,                //ת����̨�Ǽ�(SERVICE_CODE)
	CFTT_CANC    = 40,                //ת����̨��ѯ(SERVICE_CODE)
	CFTT_CONF    = 41,                //ת����̨�Ǽ�(SERVICE_CODE)
	AC_REG       = 42,                //���Ӻ��еǼ�(SERVICE_CODE)
	AC_CANC      = 43,                //���Ӻ���ȡ��(SERVICE_CODE)
	AC_CONF      = 44,                //���Ӻ��в�ѯ(SERVICE_CODE)
	SUB          = 45,                //�û�(CALL_IN)
	ECSC         = 46,                //�ⲿ����Ϣʵ��(CALL_OUT)
	CSC          = 47,                //(CALL_IN)(CALL_OUT)
	ANY          = 48,                //�κ�(CALL_IN)(CALL_OUT)
	INTRA        = 49,                //����(CALL_OUT)
	LOCAL        = 50,                //����(CALL_OUT)
	TOLL         = 51,                //��;(CALL_OUT)
	INTERNATIONAL = 52,               //���ʳ�;(CALL_OUT)
	ABSENT_REG    = 53,               //(SERVICE_CODE)
	ABSENT_CANC   = 54,               //(SERVICE_CODE)
	ABSENT_CONF   = 55,               //(SERVICE_CODE)
	EMC           = 56,               //��������(CALL_IN)(CALL_OUT)
	ROAM_PL       = 57,               //(SERVICE)
	ROAM_SC       = 58,               //(SERVICE)
	ROAM_SMSG     = 59,               //(SERVICE)
	FD            = 60,               //(SERVICE)
	MON           = 61,               //(SERVICE)
	MULTICAST     = 62,                 //�鲥(SERVICE)
	LEMC          = 63 //(SERVICE)
} CALLED_ANA_RULE_SUB_TYPE;

//���к����������
typedef struct tagCalledAnalysisRule
{	
	int ruleID;
	int sourceId;
	char calledNum[5];                   //���4λ����
	int calledNumDigitsCount;            //���к���λ��
	int ruleType;                        //���з�����������1: any(1)	2: voice(2)	3: data(3)4:sms(4)5: slr(5)
	int ruleSubType;                     //���з�������������
	int destRouteSelID;                  //·��ѡ����������Ӧ��Ӧ��·����ID
	int calledNumTransAct;               //����ת������,����1��ɾ��2���滻3
	int calledTransPos;                  //�任λ��
	int calledTransLen;                  //�任����
	char calledTransTargetStr[5];        //�任Ŀ���ַ���
}CALLED_ANALYSIS_RULE;

//Trap��������ַ
typedef struct tagTrapServer
{
	char trapServer1[MAX_IP4];
	char trapServer2[MAX_IP4];
	char trapServer3[MAX_IP4];
	char trapServer4[MAX_IP4];

}TRAP_SERVERS;
//ʱ��Դ
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
	char* fapName;           //���30
	int  fapStatus;             //���
	char fapIpAddress[MAX_IP4];
	int  SctpPort;              //SCTP�˿�,���
	int  SeGWLinkID;            //��ȫ��������ID,���
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