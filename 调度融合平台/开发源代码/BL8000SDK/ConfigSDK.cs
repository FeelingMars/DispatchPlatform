using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;

namespace MBoxSDK
{
    public class ConfigSDK
    {
        #region 常量定义

        public const string DLLNAME = "NetManagement.dll";
        //public const string DLLNAME = "ntMgr.dll";  
        // public static int MAX_SUBNUM_LEN=10;       
        public const int MAX_NAME = 256;
        public const int MAX_IP4 = 16;
        public const int MAX_LOGIN_NAME = 16;
        public const int MAX_LOGIN_PWD = 16;
        public const int MAX_SERIALNO = 48;
        public const int MBOX_USR_LEN = 256;
        public const int MBOX_PASS_LEN = 64;
        public const int MBOX_ANSWER_LEN = 1024;

        public const int MAX_ROUTE_NAME = 20;
        public const int MAX_SUBNUM_LEN = 8;
        public const int MAX_PSNUM_LEN = 13;
        //public const int MAX_PSAUTH_LEN = 16;
        public const int MAX_SIPAUTH_LEN = 8;
        public const int MAX_SIPPWD_LEN = 12;
        public const int MAX_3GUMTSIMSI_LEN = 15;

        //public const int MAX_PSIDENTIFICATION_LEN = 7;
        public const int MAX_DID_LEN = 15;/*直播号码最大长度*/
        public const int MAX_PORTMODULE_LEN = 5;/*通信接口模块格式长度*/
        public const int MAX_USER_PASSWORD_LEN = 5;
        public const int MAX_PHONENUMER_LEN = 30;
        //public const int MAX_SIP_PWD_LEN = 16; 
        public const int MAX_USER_NUMBER_LEN = 8;
        public const int MAX_AUTH_KEY_LEN = 32;  //鉴权码长度
        public const int MAX_GROUP_LEN = 12;

      







        /* 增补服务类型 */
        public const uint SPM_SRV_NULL = 0x00000000;		/* 无服务服务 */
        public const uint SPM_DONOT_DISTURB = 0x00000001;		/* 免打扰 */
        public const uint SPM_CALL_WAITING = 0x00000002;      /* 呼叫等待 */
        public const uint SPM_CFW_UNCON = 0x00000004;      /* 无条件前转 */
        public const uint SPM_CFW_BUSY = 0x00000008;      /* 遇忙前转 */
        public const uint SPM_CFW_NO_REPLY = 0x00000010;      /* 无应答前转 */
        public const uint SPM_MISS_CALL = 0x00000020;      /* 丢话通知 */
        public const uint SPM_MISS_CALL_ON_BUSY = 0x00000040;      //遇忙通知
        public const uint SPM_CALL_TRANSFER = 0x00000080;      /* 呼叫转移 */
        public const uint SPM_THREE_PARTY = 0x00000100;      /* 三方通话 */
        public const uint SPM_SMS = 0x00000200;      /* 短信服务 */
        public const uint SPM_SMS_GROUP = 0x00000400;
        public const uint SPM_DDI = 0x00000800;      /* 直接拨入号码 */
        public const uint SPM_DISPLAY_NUM = 0x00001000;
        public const uint SPM_ASSO_NUM = 0x00002000;
        public const uint SPM_TELEPHONIST = 0x00004000;      /* 话务员服务 */
        public const uint SPM_CFVM = 0x00008000;
        public const uint SPM_CALL_PICKUP = 0x00010000;      //呼叫代答
        public const uint SPM_ALARM_CALL = 0x00020000;
        public const uint SPM_CFW_UNREACHABLE = 0x00040000;      /* 不可及前转 */
        public const uint SPM_PERMANENCE_LINE = 0x00080000;      /* 永久专线 */
        public const uint SPM_INUMBER = 0x00100000;      /* inumber服务 */
        public const uint SPM_PERSONAL_ACCOUNT = 0x00200000;
        public const uint SPM_TELEAGENT = 0x00400000;      /* 话务员代理 */
        public const uint SPM_ACCESSEXTENSION = 0x00800000;
        public const uint SPM_VM = 0x01000000;
        public const uint SPM_CF_POWEROFF = 0x02000000;      //关机前转
        public const uint SPM_ROAM = 0x04000000;
        public const uint SPM_SUB_GRP = 0x08000000;
        public const uint SPM_CONFERENCE_CALL = 0x10000000;
        public const uint SPM_DISPATCH = 0x20000000;      /* 调度 */
        public const uint SPM_INUM_ASSO = 0x40000000;
        public const uint SPM_AUTO_RECORDING = 0x80000000;      /* 自动录音 */

        #endregion

        #region 枚举定义

        //设备类型
        public enum EnumDeviceType
        {
            none = 0,
            T_HT8000B = 3,
            T_HT8000C = 4,
            T_HT8000D = 5,
            T_HT8000E = 6,
            T_HT8000_3G=7
            //8000B E1Max = 8,其他为2;
            //8000B 支持3G,其他不支持;
            //8000B 用户支持8000个,其他用户支持1000个

            //T_HT8000B = 8个E1,
            //T_HT8000C = 2个E1,
            //T_HT8000D = 2个E1,
            //T_HT8000E = 2个E1

        }

        /// <summary>
        /// 告警级别
        /// </summary>
        public enum EnumALARM_LEVEL
        {
            ALM_CRITICAL = 0,
            ALM_MAJOR = 1,
            ALM_MINOR = 2,
            ALM_WARNING = 3,
            ALM_CLEAR = 4
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

        //1：none(-1)  2: internal(-2)  3: external(-3)	4: e1(-4)

        public enum EnumPriClockType
        {
            无 = -1,
            内部 = -2,
            外部 = -3,
            E1 = -4
        }

        #endregion

        #region 结构定义

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

        public enum EntityType
        {
            机架 = 1,
            槽位 = 2,
            端口 = 3,
            系统 = 4,
            E1端口 = 5,
            BRI端口 = 6,
            FXS端口 = 7,
            FXO端口 = 8,
            ENM端口 = 9

        }

        /// <summary>
        /// 路由类型
        /// </summary>
        public enum EnumRouteType
        {
            /// <summary>
            /// 双向（默认）
            /// </summary>
            btw = 1,
            /// <summary>
            /// 往外打
            /// </summary>
            ogt = 2,
            /// <summary>
            /// 往内打
            /// </summary>
            ict = 3,
            ret = 4,
            pl = 5,
            /// <summary>
            /// 发信息
            /// </summary>
            esme = 6,
            ecsc_uplk = 7,
            csc_uplk = 8

            //4: reg(4) 5: pl(5) 6: esme(6)发信息 7: ecsc-uplk(7) 8: csc-uplk(8) int routeType;
        }

        public enum Enum_ErrorCode
        {
            Error_Memory_Allocate = -1,              /**< 数据超时 */
            Error_TIMEOUT = -2,		                /**< 数据超时 */
            Error_NETWORK = -3,		               /**< 网络错误 */
            Error_Net_Protocol = -4,              /**< 协议错误 */
            Error_TargetHost_Not_EXIST = -5,		        /**< 目标主机错误 */
            Error_Buffer = -6,		              /**< 数据缓冲区错误 */
            Error_System_Init = -7,              /**< 未初始化 */
            Error_Undo = -15,                   /**< 在创建对象时，表示对象已存在 
														 **< 在删除对象时，表示被删除对象不存在*/
            Error_OVERLOAD = -16,              /**< 用户号码数量已达上限*/
            Error_PARAMETER = -8               /**< 用户参数错误*/

        }


        public enum CALLED_RULE_TransAct  //被叫分析规则变化动作
        {
            NONE = 0,                   //空值
            INSERT = 1,                 //插入
            DELETE = 2,                 //删除 
            REPLACE = 3                 //替换
        }


        public enum CALLED_RULE_TYPE  //被叫分析规则类型
        {
            //SERVICE = 1,                   //服务
            //SERVICE_CODE = 2,              //业务接入码
            //CALL_IN = 3,                   //入局，或者叫，呼入 
            //CALL_OUT = 4                    //出局，或者叫，呼出

            SERVICE = 1,                   //服务
            SERVICE_CODE = 2,              //业务接入码
            入局 = 3,                   //入局，或者叫，呼入 
            出局 = 4                    //出局，或者叫，呼出
        }

        public enum CALLED_SUB_RULE_TYPE  //被叫分析规则子类型
        {
            //PHOHONIST = 1,               //服务台(SERVICE)  话务员
            话务员 = 1,
            CPD = 2,                            //呼叫代答拨号(SERVICE)
            VM = 3,                             //语音信箱(SERVICE)
            EXCHG = 4,                          //总机
            CONF = 5,                           //会议电话
            SGI = 6,                            //短消息组标识(SERVICE)
            ESME = 7,                           //呼叫代答拨号
            ROAM = 8,                           //漫游(SERVICE)(CALL_OUT)
            CFB_REG = 9,                        //遇忙前转登记(SERVICE_CODE)
            CFB_CANC = 10,                      //遇忙前转取消(SERVICE_CODE)
            CFB_CONF = 11,                      //遇忙前转查询(SERVICE_CODE)
            CFNR_REG = 12,                      //呼叫转接取消(SERVICE_CODE)
            CT_CONF = 26,                       //呼叫转接查询(SERVICE_CODE)
            CW_REG = 27,                        //呼叫等待登记(SERVICE_CODE)
            CW_CANC = 28,                       //呼叫等待登记(SERVICE_CODE)
            CW_CONF = 29,                       //呼叫等待登记(SERVICE_CODE)
            DND_REG = 30,                       //免打扰登记(SERVICE_CODE)
            DND_CANC = 31,                      //免打扰登记(SERVICE_CODE)
            DND_CONF = 32,                      //免打扰登记(SERVICE_CODE)
            CP_REG = 33,                        //呼叫代答登记(SERVICE_CODE)
            CP_CANC = 34,                       //呼叫代答登记(SERVICE_CODE)
            CP_CONF = 35,                       //呼叫代答登记(SERVICE_CODE)
            CFTVM_REG = 36,                     //转语音信箱登记(SERVICE_CODE)
            CFTVM_CANC = 37,                    //转语音信箱取消(SERVICE_CODE)
            CFTVM_CONF = 38,                    //转语音信箱查询(SERVICE_CODE)
            CFTT_REG = 39,                      //转话务台登记(SERVICE_CODE)
            CFTT_CANC = 40,                     //转话务台查询(SERVICE_CODE)
            CFTT_CONF = 41,                     //转话务台登记(SERVICE_CODE)
            AC_REG = 42,                        //闹钟呼叫登记(SERVICE_CODE)
            AC_CANC = 43,                       //闹钟呼叫取消(SERVICE_CODE)
            AC_CONF = 44,                       //闹钟呼叫查询(SERVICE_CODE)
            SUB = 45,                   //用户(CALL_IN) 
            ECSC = 46,                          //外部短消息实体(CALL_OUT)
            CSC = 47,                           //(CALL_IN)(CALL_OUT)
            ANY = 48,                           //任何(CALL_IN)(CALL_OUT)
            INTRA = 49,                         //内联(CALL_OUT)
            市话 = 50,                         //本地(CALL_OUT)
            //TOLL = 51,                  //长途(CALL_OUT)
            长途 = 51,
            INTERNATIONAL = 52,                 //国际长途(CALL_OUT)
            ABSENT_REG = 53,                    //(SERVICE_CODE)
            ABSENT_CANC = 54,                   //(SERVICE_CODE)
            ABSENT_CONF = 55,                   //(SERVICE_CODE)
            EMC = 56,                   //紧急呼叫(CALL_IN)(CALL_OUT)
            ROAM_PL = 57,                       //(SERVICE)
            ROAM_SC = 58,                       //(SERVICE)
            ROAM_SMSG = 59,                     //(SERVICE)
            FD = 60,                            //(SERVICE)
            MON = 61,                           //(SERVICE)
            MULTICAST = 62,                     //组播(SERVICE)
            //LEMC = 63                           //(SERVICE)
            紧急呼叫 = 63                           //(SERVICE)

        }





        /// <summary>
        /// 电话用户相关信息
        /// </summary>
        public struct subscriberServiceDetail
        {
            /*
            /// <summary>
            /// 用户类型
            /// </summary>
            public int subType;

            /// <summary>
            /// 用户号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_SUBNUM_LEN + 1)]
            public byte[] subNumber;

            /// <summary>
            /// PS号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PSNUM_LEN + 1)]
            public byte[] PSNumber;

            /// <summary>
            /// 鉴权码，0-16，0-f的数字
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PSAUTH_LEN + 1)]
            public byte[] authKey;
            

            /// <summary>
            /// PS标识符，7位，0-f的数字
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PSIDENTIFICATION_LEN + 1)]
            public byte[] PSID;

            /// <summary>
            /// 直播号码，最大15位
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_DID_LEN + 1)]
            public byte[] DIDNumber;

            /// <summary>
            /// 增补服务
            /// </summary>
            public int supplementSerive;                    //增补服务 

            /// <summary>
            /// 用户所属组
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_GROUP_LEN + 1)]
            public byte[] subGroup;

            /// <summary>
            /// 优先级
            /// </summary>
            public int subPriority;                         //优先级

            /// <summary>
            /// fxs
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PORTMODULE_LEN + 1)]
            public byte[] fxsPort;

            /// <summary>
            /// 无条件转接 号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] cfuNumber;

            /// <summary>
            /// 遇忙转接 号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] cfbNumber;

            /// <summary>
            /// 无应答转接号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] cfnrNumber;

            /// <summary>
            /// 用户不可及转接号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] cfurNumber;

            /// <summary>
            /// 关联号码1，如打用户号码，该关联号码也振铃
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] associationNum1;

            /// <summary>
            /// 关联号码2
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] associationNum2;

            /// <summary>
            /// 用户密码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_USER_PASSWORD_LEN + 1)]
            public byte[] subPassword;

            /// <summary>
            /// 用户密码级别
            /// </summary>
            public int subPwdLevel;
            /// <summary>
            /// 密码状态，inservice outofService
            /// </summary>
            public int subPwdStatus;

            /// <summary>
            /// "#-#-#"
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PORTMODULE_LEN + 1)]
            public byte[] fxoPort;
            /// <summary>
            /// 告警闹钟，小时
            /// </summary>
            public int acTimeHour;
            /// 告警闹钟，分钟
            /// </summary>
            public int acTimeMinute;
            /// <summary>
            /// 用户状态
            /// </summary>
            public int subStatus;
            /// <summary>
            /// normal(1)blocked(2),创建时默认为normal
            /// </summary>
            public int subBlockStatus;

            /// <summary>
            /// 关机转接号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] subCfpfNumber;



            /// <summary>
            /// SIP密码（3..16）
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_SIPPWD_LEN + 1)]
            public byte[] sIPSubPassword;
            */


            /// <summary>
            /// 用户类型
            /// </summary>
            public int subType;

            

	

            /// <summary>
            /// 用户号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_SUBNUM_LEN + 1)]
            public byte[] subNumber;


            /// <summary>
            /// 鉴权码，0-16，0-f的数字
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_AUTH_KEY_LEN + 1)]
            public byte[] authKey;


           
	
	
	
	
	
	
	
	
	
	

            /// <summary>
            /// 直播号码，最大15位
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_DID_LEN + 1)]
            public byte[] DIDNumber;

            /// <summary>
            /// 增补服务
            /// </summary>
            public uint supplementSerive;                    //增补服务 

            /// <summary>
            /// 用户所属组
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_GROUP_LEN + 1)]
            public byte[] subGroup;

            /// <summary>
            /// 优先级  //表示可以拨打市话、长途等, 国际长途 = 0, 国内长途 = 1,   市话 = 2,   内部分机 = 3,  禁止主叫 = 4,
            /// </summary>
            public int subPriority;                         //优先级,即市话、内线等等权限

            /// <summary>
            /// fxs
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PORTMODULE_LEN + 1)]
            public byte[] fxsPort;

            /// <summary>
            /// 无条件转接 号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] cfuNumber;

            /// <summary>
            /// 遇忙转接 号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] cfbNumber;

            /// <summary>
            /// 无应答转接号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] cfnrNumber;

            /// <summary>
            /// 用户不可及转接号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] cfurNumber;

            /// <summary>
            /// 关联号码1，如打用户号码，该关联号码也振铃
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] associationNum1;

            /// <summary>
            /// 关联号码2
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] associationNum2;

            /// <summary>
            /// 用户密码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_SIPPWD_LEN + 1)]
            public byte[] subPassword;

            /// <summary>
            /// 用户密码级别
            /// </summary>
            public int subPwdLevel;
            /// <summary>
            /// 密码状态，inservice outofService
            /// </summary>
            public int subPwdStatus;

            /// <summary>
            /// "#-#-#"
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PORTMODULE_LEN + 1)]
            public byte[] fxoPort;
            /// <summary>
            /// 告警闹钟，小时
            /// </summary>
            public int acTimeHour;
            /// 告警闹钟，分钟
            /// </summary>
            public int acTimeMinute;
            /// <summary>
            /// 用户状态
            /// </summary>
            public int subStatus;
            /// <summary>
            /// normal(1)blocked(2),创建时默认为normal
            /// </summary>
            public int subBlockStatus;

            /// <summary>
            /// 关机转接号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PHONENUMER_LEN + 1)]
            public byte[] subCfpfNumber;



            /// <summary>
            /// SIP密码（3..16）
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_SIPPWD_LEN + 1)]
            public byte[] sIPSubPassword;


            //char  umtsImsi[MAX_3GUMTSIMSI_LEN+1];      //3g号码标识
            //int   umtsRan;                             //UMTS RAN(Radio Access Network) type.1: wcdma(0) 2: td-scdma(1) 3: fdd-lte(2) 4: td-lte(3)
            //char  fapIpAddress[MAX_IP4];               //基站ip

            /// <summary>
            /// 3g号码标识
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_3GUMTSIMSI_LEN + 1)]
            public byte[] umtsImsi;
            
            /// <summary>
            /// //UMTS RAN(Radio Access Network) type.1: wcdma(0) 2: td-scdma(1) 3: fdd-lte(2) 4: td-lte(3)
            /// </summary>
            public int umtsRan;

            /// <summary>
            /// //char  fapIpAddress[MAX_IP4];               //基站ip
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] fapIpAddress;


    
        }


        /// <summary>
        /// 电话用户相关信息
        /// </summary>
        public struct subscriberServiceBase
        {
            /*  
            /// <summary>
            /// 用户号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_SUBNUM_LEN + 1)]
            public byte[] subNumber;

            /// <summary>
            /// PS号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PSNUM_LEN + 1)]
            public byte[] PSNumber;

            /// <summary>
            /// 鉴权码，0-16，0-f的数字
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PSAUTH_LEN + 1)]
            public byte[] authKey;
            /// <summary>
            /// 用户类型
            /// </summary>
            public int subType;

            /// <summary>
            /// PS标识符，7位，0-f的数字
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PSIDENTIFICATION_LEN + 1)]
            public byte[] PSID;

            /// <summary>
            /// 增补服务
            /// </summary>
            public int supplementSerive;                    //增补服务 

            */

            //二期网管
            /// <summary>
            /// 用户类型
            /// </summary>
            public int subType;   //sip：手机Wifi = 4,固话=4 ；  //3G： 手机3G = 6
            /// <summary>
            /// 增补服务
            /// </summary>
            public UInt32 supplementSerive;                   //增补服务,作为sip用户，只能是丢话、短信通知、遇忙通知三项的组合

            //表示可以拨打市话、长途等, 国际长途 = 0, 国内长途 = 1,   市话 = 2,   内部分机 = 3,  禁止主叫 = 4,
            public int userPriority;


            public int umtsRan;           //: ran_wcdma(0) 2: ran_td_scdma(1)3: ran_fdd_lte(2) 4: ran_td_lte(3)，默认为0        

            /// <summary>
            /// 用户号码
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_SUBNUM_LEN + 1)]
            public byte[] userNumber; //= new byte[MAX_SUBNUM_LEN + 1];

            //sip用户密码
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_SIPPWD_LEN + 1)]
            public byte[] sipPassword;

            //3g用户UmtsImsi码
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_3GUMTSIMSI_LEN + 1)]
            public byte[] p3gUmtsImsi;

            /// <summary>
            /// 鉴权码，0-16，0-f的数字
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_AUTH_KEY_LEN + 1)]
            public byte[] authKey;                         //sip可以忽略，如果未设备默认与用户号码相同，3G必须是32个数字文本
        }

        //路由组
        public struct tagRouteGrp
        {
            public UInt32 ID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_NAME)]
            public byte[] routeGroupName;
        }
        //路由
        public struct tagRouteConfig
        {
            public int routeID;
            public int routeGroupID;
            public int routeType;   //1: btw(1)双向（默认） 2: ogt(2)往外打 3: ict(3)往内打 4: reg(4) 5: pl(5) 6: esme(6)发信息 7: ecsc-uplk(7) 8: csc-uplk(8) int routeType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ROUTE_NAME + 1)]
            public byte[] routeName;

        }

        public class clsTagRouteConfig
        {
            public int routeID;
            public int routeGroupID;
            public int routeType;   //1: btw(1)双向（默认） 2: ogt(2)往外打 3: ict(3)往内打 4: reg(4) 5: pl(5) 6: esme(6)发信息 7: ecsc-uplk(7) 8: csc-uplk(8) int routeType;

            public string routeName;

        }
        //节点
        public struct tagNode
        {

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
            public byte[] nodeName;
            public int nodeType;   //设备类型
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] netManegeInterfaceIP;   //网管口地址
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] netManegeInterfaceMask;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] trafficInterfaceIp;   //业务口IP,即站点IP
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] trafficInterfaceMask;   //业务口MAS
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] dspSrcIP;      //dsp地址，默认站点IP+1
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
            public byte[] versionInfo;   //版本信息，用于获取
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
            public byte[] serialNumber;   //节点序列号，用于获取


        }

        //录音服务器配置
        public struct tagRecordServerConf
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] szRecordServerIp;
            public bool bSupport;
            public int status;

        }

        //Trap服务器地址
        public struct tagTrapServer
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] trapServer1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] trapServer2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] trapServer3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] trapServer4;

        }




        //呼叫源
        public struct tagCallSource
        {
            public int callSourceID;
            public int callSourceMainType;
            public int callSourceSubType;
            public int callSourceValue;
        }

        //路由规则
        public struct tagRoutingRule
        {
            public int sourceRuleSelectIndex;  //源路由索引
            public int destRuleSelectIndex;    //目的路由索引
            public int routeGroupIndex;       //指的是路由组Index
        }

        //呼叫源规则
        public struct tagCallSourceRule
        {
            public int callSourceIndex;
            public int seviceType; //any(1) voice(2) data(3) sms(4) slr(5) 服务类型
            public int minReceiveNumLength;       //指的是路由组Index
        }

        //被叫号码分析规则
        public struct tagCalledAnalysisRule
        {
            public int ruleID;
            public int sourceId;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] calledNum;                    //最大4位数字
            public int calledNumDigitsCount;            //被叫号码位数
            public int ruleType;                        //被叫分析规则类型
            public int ruleSubType;                     //被叫分析规则子类型
            public int destRouteSelID;                  //路由选择索引，对应相应的路由组ID
            public int calledNumTransAct;               //号码转换动作
            public int calledTransPos;                  //变换位置
            public int calledTransLen;                  //变换长度
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] calledTransTargetStr;        //变换目标字符串
        }

        //时钟源
        public struct tagClockSource
        {
            public int priority;
            public int type; //1：none(-1)  2: internal(-2)  3: external(-3)	4: e1(-4)
            public int port;
        }

        //PRI中继
        public struct tagPriTrunk
        {
            public int trunkID;
            public int trunkInterfaceType;         //接口类型,内部(1),外部(2)，默认外部
            public int trunkRoutingID;             //路由ID
            public int trunkPriority;              //优先级,主(1),从(2)，默认主
            public int configureStatus;            //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
            public int operationStatus;            //up(2) down(1)
            public int linkCount;                  //最大通道(0~255)
            public int linkType;                   //链路类型 E1(1),T1(2)
            public int PbxType;                    //交换机类型1: unknown(1) 2: avaya(2)3: nortel(3)4: alcatel(4) 5: siemens(5) 6: oulian(6)7: shenou(7) 8: utstarcom(8) 9: microxel(9)

        }


        //PRI(T1)承载信道
        public struct tagT1
        {
            public int priID;                      //中继号
            public int machineID;                  //机身号，必须是1
            public int slotID;                     //槽位号,必须是3
            public int e1Port;                     //E1口,从1开始
            public int linkID;                     //链接ID，如果与对端的E1口的某条link进行通信，需要把linkID设置成和对端同样的ID
            public int channelType;                //1: bothway(1)	2: outgoing(2) 3: incoming(3)
            public int configureStatus;
            public int operationStatus;
            public int E1bundle;                   //表示第几个信道，第16个信道不作为承载信道
        }


        //信令通道信道
        public struct tagSigLink
        {
            public int priID;
            public int machineID;                  //机身号
            public int slotID;                     //槽位号
            public int e1Port;                     //E1口
            public int linkID;                     //和对端通信的逻辑链接
            public int portType;                   //q931(1) qSIG(2),默认1
            public int theEnd;                     //用户侧：1，网络侧：2，默认1
            public int peerProvideVoicePrompt;     //是:1,否:2,默认否
            public int sendVoicePrompt;            //是:1,否:2,默认是 
            public int E1bundle;                   //表示第几个信道，默认为16
        }


        //Sip服务接入点信息
        public struct tagSipSap
        {
            public int sipSapID;
            public int sipSapPort;                 //默认5060
            public int netProtocal;                //udp:1,tcp:2
        }

        //SIP中继
        public struct tagSipTrunk
        {
            public int trunkID;
            public int trunkInterfaceType;         //接口类型,内部(1),外部(2)，默认外部
            public int trunkRoutingID;             //路由ID
            public int trunkPriority;              //优先级,主(1),从(2)，默认主
            public int trunkSipSapID;              //SIP接入点ID
            public int trunkMaxChannel;            //最大通道(1~128)
            public int trunkPlayTone;              //是否放音,是(1),否(2),默认1
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] peerIpAddress;          //对端IP地址
            public int peerPort;                  //对端端口号
            public int configureStatus;           //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
            public int operationStatus;           //up(2) down(1)
            public int heartBeatSupport;          //yes(1) no(0)
        }


       /// <summary>
       /// 短信
       /// </summary>
        public struct tagShortMessageEntity
        {

	        public string esmeSystemId;
	        public string esmePassword;
	        public int  esmeId;
	        public int  esmeRouteId;

        }


        //静态路由信息
        public struct tagStaticRoutingInfo
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] szNet;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] szMask;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] szGateWay;
        }

        //FAP  3G基站
        public struct tagFap
        {
            public int fapID;                 //0~256
            public int fapRanType;            //UMTS RAN type
            public string fapIdentify;           //0~255
            public string fapName;           //最大30
            public int fapStatus;             //输出
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP4)]
            public byte[] fapIpAddress;
            public int SctpPort;              //SCTP端口,输出
            public int SeGWLinkID;            //安全网关连接ID,输出
        }




        #endregion

        #region  公用方法
        public void Receive(byte[] byteArray)
        {
            List<int> IDs = new List<int>();
            List<string> Names = new List<string>();
            string str = System.Text.Encoding.Default.GetString(byteArray);
            str = str.Replace("\0", "");
            string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strArray.Length; i++)
            {
                string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                IDs.Add(int.Parse(strArray2[0]));
                Names.Add(strArray2[1]);
            }
        }


        public MBoxSDK.ConfigSDK.subscriberServiceDetail newSubscriberServiceDetail()
        {
            MBoxSDK.ConfigSDK.subscriberServiceDetail subServiceDetail = new MBoxSDK.ConfigSDK.subscriberServiceDetail();
            subServiceDetail.associationNum1 = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
            subServiceDetail.associationNum2 = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
            subServiceDetail.authKey = new byte[MBoxSDK.ConfigSDK.MAX_AUTH_KEY_LEN + 1];
            subServiceDetail.cfbNumber = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
            subServiceDetail.cfnrNumber = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
            subServiceDetail.cfuNumber = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
            subServiceDetail.cfurNumber = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
            subServiceDetail.DIDNumber = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
            subServiceDetail.fxoPort = new byte[MBoxSDK.ConfigSDK.MAX_PORTMODULE_LEN + 1];
            subServiceDetail.fxsPort = new byte[MBoxSDK.ConfigSDK.MAX_PORTMODULE_LEN + 1];
            subServiceDetail.sIPSubPassword = new byte[MBoxSDK.ConfigSDK.MAX_SIPPWD_LEN + 1];
            subServiceDetail.subCfpfNumber = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
            subServiceDetail.subGroup = new byte[MBoxSDK.ConfigSDK.MAX_GROUP_LEN + 1];
            subServiceDetail.subNumber = new byte[MBoxSDK.ConfigSDK.MAX_SUBNUM_LEN + 1];
            subServiceDetail.subPassword = new byte[MBoxSDK.ConfigSDK.MAX_SIPPWD_LEN + 1];
            return subServiceDetail;
        }

        public MBoxSDK.ConfigSDK.subscriberServiceBase newSubscriberServiceBase()
        {
            MBoxSDK.ConfigSDK.subscriberServiceBase subServiceBase = new MBoxSDK.ConfigSDK.subscriberServiceBase();
            subServiceBase.authKey = new byte[MBoxSDK.ConfigSDK.MAX_AUTH_KEY_LEN + 1];
            subServiceBase.p3gUmtsImsi = new byte[MBoxSDK.ConfigSDK.MAX_3GUMTSIMSI_LEN + 1];
            subServiceBase.sipPassword = new byte[MBoxSDK.ConfigSDK.MAX_SIPPWD_LEN + 1];
            subServiceBase.userNumber = new byte[MBoxSDK.ConfigSDK.MAX_SUBNUM_LEN + 1];
            return subServiceBase;
        }

        public MBoxSDK.ConfigSDK.tagNode newTagNode()
        {
            MBoxSDK.ConfigSDK.tagNode node = new MBoxSDK.ConfigSDK.tagNode();
            node.dspSrcIP = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            node.netManegeInterfaceIP = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            node.netManegeInterfaceMask = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            node.nodeName = new byte[33];
            node.serialNumber = new byte[512];
            node.trafficInterfaceIp = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            node.trafficInterfaceMask = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            node.versionInfo = new byte[512];
            return node;
        }



        #endregion

        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_TEST(int[] arr, ref int j);

        #region 基本配置

        /// <summary>初始化</summary>
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_Initialize();

        /// <summary>逆初始化</summary>
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_Dispose();

        /// <summary>登录</summary>
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int MBOX_Login(string sMboxIp, string sLocalIp, string sUserName, string sUserPassword);
        // 登出
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_Logout(int handle);

        //保存配置
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SaveHaveDoneCfg(int handle);
        //清除设置
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_ClearDeviceCfg(int handle);
        //重启设备
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MBOX_Restart(int handle);

        /// <summary>判断设备在线状态 </summary>
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_IsDeviceOnline(string IP);

        //获取错误信息
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern Enum_ErrorCode MBOX_GetLastError();

        //获取设备型号T_HT8000B = 3,T_HT8000C=4,T_HT8000D=5,T_HT8000E=6
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetDeviceType(int handle, ref int type);

        // <summary>设置节点信息 </summary>
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MBOX_SetNodeInfo(int handle, tagNode tagNode);

        // <summary>设置节点信息 </summary>
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetNodeInfo(int handle, ref tagNode tagNode);

        /*设置呼叫中心号码*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SetDispatchCenter(int handle, string callCenterNum);

        /*设置紧急呼叫号码*/
        //目前暂未成功
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SetEmergencyNumber(int handle, string callEmergencyNum);

        // <summary>设置录音服务器 </summary>
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SetRecordServer(int handle, tagRecordServerConf tagRecordServerConf);

        // <summary>查询录音服务器 </summary>
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetRecordServer(int handle, ref tagRecordServerConf tagRecordServerConf);

        // <summary>设置调度台IP </summary>
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SetDispatcherAddress(int handle, tagTrapServer tagTrapServer);

        // <summary>查询调度台IP </summary>
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetDispatcherAddress(int handle, ref tagTrapServer tagTrapServer);


        /*设置DSP地址*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern void MBOX_SetDspAddress(int handle, string strIP);

        /*获取DSP地址*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetDspAddress(int handle, byte[] bIP, int buffersize);

        /*设置时间服务器IP*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SetNTPAddress(int handle, string strIP);

        /*获取时间服务器IP*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetNTPAddress(int handle, byte[] bIP, int buffersize);



        /*设置CDR触发器*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SetCdrTrigger(int handle, int open, int openReal);   //1打开，2关闭

        /*获取CDR触发器状态*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetCdrTrigger(int handle, ref int open, ref int openReal);

        /*设置SIP用户注册时间间隔*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SetSipRegisterCycleAndHeartBeatInterval(int handle, int RegistSecond, int HeartSecond);

        /*获取SIP用户注册时间间隔*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetSipRegisterCycleAndHeartBeatInterval(int handle, ref int RegistSecond, ref int HeartSecond);

        /*获取用户在线监测模式*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetSipOnlineDetectionMode(int handle, ref int mode);

        /*设置时钟源*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SetClockSource(int handle, tagClockSource tagClockSource);

        /*获取时钟源*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetClockSource(int handle, byte[] buffer, uint buffersize, ref int count);


        #endregion

        #region 用户
        // 增加电话用户
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        //public static extern bool MBOX_CreateSubscriber(int handle, int subNumber);
        public static extern bool MBOX_CreateSubscriber(int handle, ref subscriberServiceBase subServiceBase);

        // 批量增加电话用户
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_BatchCreateSubscriber(int handle, ref subscriberServiceBase subServiceBase, uint subCount);

        // 修改用户
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_ModifySubscriber(int handle, int subNumber, ref subscriberServiceDetail subService);
        public static bool MBOX_ModifySubscriber(int handle, long subNumber, ref subscriberServiceDetail subService)
        {
            return MBOX_ModifySubscriber(handle, Convert.ToInt32(subNumber), ref subService);
        }

        // 电话号码是否存在
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_IsSubscriberExist(int handle, int subNumber);
        public static bool MBOX_IsSubscriberExist(int handle, long subNumber)
        {
            return MBOX_IsSubscriberExist(handle, Convert.ToInt32(subNumber));
        }

        // 删除用户
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeleteSubscriber(int handle, int subNumber);
        public static bool MBOX_DeleteSubscriber(int handle, long subNumber)
        {
            return MBOX_DeleteSubscriber(handle, Convert.ToInt32(subNumber));
        }

        // 查询用户
        [DllImport(DLLNAME, ExactSpelling = false, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_QuerySubscriber(int handle, int subNumber, ref subscriberServiceDetail subService);
        public static bool MBOX_QuerySubscriber(int handle, long subNumber, ref subscriberServiceDetail subService)
        {
            return MBOX_QuerySubscriber(handle, Convert.ToInt32(subNumber),ref subService);
        }

        // 设置用户权限
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SetSubscriberPriority(int handle, uint subNumber, int priority);
        public static bool MBOX_SetSubscriberPriority(int handle, long subNumber, int priority)
        {
            return MBOX_SetSubscriberPriority(handle, Convert.ToUInt32(subNumber),priority);
        }


        // 获取用户权限
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetSubscriberPriority(int handle, uint subNumber, ref int priority);
        public static bool MBOX_GetSubscriberPriority(int handle, long subNumber, ref int priority)
        {
            return MBOX_GetSubscriberPriority(handle, Convert.ToUInt32(subNumber), ref priority);
        }

        #endregion

        #region  路由 路由组
        //创建路由组
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_CreateRouteGroup(int handle, UInt32 rteGrpID, string rteGrpName);
        //删除路由组
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeleteRouteGroup(int handle, UInt32 rteGrpID, string rteGrpName);
        //查询路由组，ref int ioRouteGroup为tagRouteGrp数组的大小
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        //public static extern bool MBOX_QueryRouteGroup(int handle,  tagRouteGrp[] tagRouteGrp, ref int ioRouteGroup);
        public static extern bool MBOX_GetRouteGroup(int handle, byte[] tagRouteGrp, int buffersize, ref int ioRouteGroup);

        /*创建路由*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_CreateRouting(int handle, tagRouteConfig tagRouteConfig);

        /*删除路由*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeleteRouting(int handle, tagRouteConfig tagRouteConfig);

        /*获取路由*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetRouting(int handle, byte[] tagRoute, uint buffersize, ref int ioRouteCount);

        #endregion

        #region  呼叫规则
        /*创建呼叫源*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_CreateCallSource(int handle, tagCallSource tagCallSource);

        /*删除呼叫源*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeleteCallSource(int handle, tagCallSource tagCallSource);

        /*获取呼叫源*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetCallSource(int handle, byte[] callSourceRule, uint buffersize, ref int ioCount);


        /*创建呼叫源规则*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_CreateCallSourceRule(int handle, tagCallSourceRule tagCallSourceRule);

        /*删除呼叫源规则*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeleteCallSourceRule(int handle, tagCallSourceRule tagCallSourceRule);

        /*获取呼叫源规则*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetCallSourceRule(int handle, byte[] callSourceRule, uint buffersize, ref int ioCount);


        /*创建路由规则*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_CreateRoutingRule(int handle, tagRoutingRule tagRoutingRule);

        /*删除路由规则*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeleteRoutingRule(int handle, tagRoutingRule tagRoutingRule);


        /*获取路由规则*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetRoutingRule(int handle, byte[] RoutingRule, uint buffersize, ref int ioCount);

        /*创建被叫号码规则*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_CreateCalledNumAnalysisRule(int handle, tagCalledAnalysisRule tagCalledAnalysisRule);

        /*删除被叫号码规则*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeleteCalledNumAnalysisRule(int handle, tagCalledAnalysisRule tagCalledAnalysisRule);

        /*获取被叫号码分析规则*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetCalledNumAnalysisRule(int handle, byte[] CalledNumAnalysisRule, uint buffersize, ref int ioCount);

        #endregion

        #region PRI

        /*创建PRI中继*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_CreatePriTrunk(int handle, ref tagPriTrunk tagPriTrunk);

        /*删除PRI中继*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeletePriTrunk(int handle, tagPriTrunk tagPriTrunk);

        /*获取PRI中继*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetPriTrunk(int handle, byte[] byteArray, uint buffersize, ref int ioCount);


        /*创建PRI承载信道*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_CreateT1Channel(int handle, tagT1 tagT1);


        /*删除PRI承载信道*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeleteT1Channel(int handle, tagT1 tagT1);


        /*获取PRI承载信道*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetT1Channels(int handle, byte[] byteArray, uint buffersize, ref int ioCount);


        /*创建信令信道*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_CreateSigChannel(int handle, tagSigLink tagSigLink);

        /*删除PRI信令信道*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeleteSigChannel(int handle, tagSigLink tagSigLink);

        /*获取PRI信令信道*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetSigChannel(int handle, byte[] byteArray, uint buffersize, ref int ioCount);


        /*设置PRI中继激活*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SetPriTrunkAction(int handle, int ID, int state);
        //参数1：输入参数，表示PriTrunk的标识
        //参数2：输入参数，表示激活(1)或去激活(2)






        #endregion

        #region  SIP

        /*创建SIP中继*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_CreateSipTrunk(int handle, ref tagSipTrunk tagSipTrunk);

        /*删除SIP中继*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeleteSipTrunk(int handle, tagSipTrunk tagSipTrunk);

        /*获取SIP中继*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetSipTrunk(int handle, byte[] byteArray, uint buffersize, ref int ioCount);

        /*创建SAP接入点*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_CreateSipSap(int handle, tagSipSap tagSipSap);

        /*删除SAP接入点*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeleteSipSap(int handle, tagSipSap tagSipSap);

        /*获取SAP接入点*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetSipSap(int handle, byte[] byteArray, uint buffersize, ref int ioCount);


        /*设置sip激活*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SetSipTrunkAction(int handle, int ID, int state);
        //参数1：输入参数，表示SipTrunk的标识
        //参数2：输入参数，表示激活(1)或去激活(2)


        #endregion

        #region 短信


        /*创建短消息实体*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_CreateShortMessageEntity(int handle, tagShortMessageEntity tagSMS);

        
        /*删除短消息实体*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeleteShortMessageEntity(int handle,  tagShortMessageEntity tagSMS);
        

       
        /*查询短消息实体*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetShortMessageEntity(int handle,byte[] bIP, uint ii,ref int tt);




        /*增加扩展短消息实体终端*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_AddEsmeTerminate(int handle, string IP);


        /*移除扩展短消息实体终端*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_RemoveEsmeTerminate(int handle, string IP);

        /*获取扩展短消息实体终端*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetEsmeTerminate(int handle, byte[] bIP, int buffersize);

        #endregion

        #region 3G
        /*设置安全网关地址*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_3G_SetSecureGatewayAddress(int handle, string strIP);
        /*获取安全网关地址*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_3G_GetSecureGatewayAddress(int handle, byte[] byteArray); //MAX_IP4
        /*获取安全网关状态*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_3G_GetSecureGatewayStatus(int handle, ref int state); ///*1down,2up*/

        /*创建PDS地址*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_3G_CreatePDS(int handle, int ID, string strIP);
        /*获取PDS地址*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_3G_GetPDS(int handle, byte[] byteArray, UInt32 byteArraySize, ref int count); //MAX_IP4
        /*删除PDS地址*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_3G_DeletePDS(int handle, int ID);
        /*激活(去激活)PDS*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_3G_SetPDSActive(int handle, int ID, int state);  ///*1up,*2down/

        /*设置3G DNS服务器*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_3G_SetDNSServer(int handle, string primaryDNS, string SecondDNS);

        /*获取3G DNS服务器*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_3G_GetDNSServer(int handle, byte[] byteArrayDNS1, byte[] byteArrayDNS2); //MAX_IP4

        /*添加静态路由*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_SetStaticRouting(int handle, tagStaticRoutingInfo tagStaticRoutingInfo);

        /*删除静态路由*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_DeleteStaticRouting(int handle, tagStaticRoutingInfo tagStaticRoutingInfo);



        /*获取静态路由*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_GetStaticRouting(int handle, byte[] byteArray, UInt32 byteArraySize, ref int count); 

        /*创建FAP 3G基站*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_3G_CreateFAP(int handle, tagFap tagFap);
        /*删除FAP 3G基站*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_3G_DeleteFAP(int handle, tagFap tagFap);
        /*获取FAP 3G基站*/
        [DllImport(DLLNAME, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MBOX_3G_GetFAP(int handle, byte[] byteArray, UInt32 byteArraySize, ref int count); 

        #endregion

    }
}
