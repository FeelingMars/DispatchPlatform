/******************************************************************************
 *  版权所有（C）2012-2013，南京北路自动化系统有限责任公司                    *
 *  保留所有权利。                                                            *
 ******************************************************************************
 *  作者 : 周国祥
 *  功能 : 调度交换机网管接口定义
 *  版本 : 1.0
 *****************************************************************************/
/*  修改记录: 
      日期       版本    修改人             修改内容

******************************************************************************/

#ifndef NETMANAMENT_H
#define NETMANAMENT_H

#include "mboxtypedef.h"

#define NETMGR_API extern "C" __declspec(dllexport) 

NETMGR_API BOOL MBOX_TEST(int [],int&);

/*初始化*/
NETMGR_API BOOL MBOX_Initialize();
/*释放*/
NETMGR_API BOOL MBOX_Dispose();
/*获取错误码*/
NETMGR_API MBOX_ERRORCODE MBOX_GetLastError();
/*获取设备型号*/
NETMGR_API BOOL MBOX_GetDeviceType(MBOX_HANDLE handle,int &);
//获取设备能力集
NETMGR_API BOOL MBOX_GetDeviceCapabilities(int type,DEVICE_CAPABILITY&);
/*登录*/
NETMGR_API MBOX_HANDLE MBOX_Login(char *sMboxIp,char* sLocalIp, char *sUserName,char * sUserPassword);
/*登出*/
NETMGR_API BOOL MBOX_Logout(MBOX_HANDLE handle);
/*检测设备在线情况*/
NETMGR_API BOOL MBOX_IsDeviceOnline(char *sMboxIP);
/*设置节点信息*/
NETMGR_API void MBOX_SetNodeInfo(MBOX_HANDLE handle,NODE_INFO);
/*获取节点信息*/
NETMGR_API BOOL MBOX_GetNodeInfo(MBOX_HANDLE handle,NODE_INFO& node);
/*设置DSP地址*/
NETMGR_API void MBOX_SetDspAddress(MBOX_HANDLE handle,const char *);
/*获取DSP地址*/
NETMGR_API BOOL MBOX_GetDspAddress(MBOX_HANDLE handle,char[],int size);
/*设置调度台地址*/
NETMGR_API BOOL MBOX_SetDispatcherAddress(MBOX_HANDLE handle,TRAP_SERVERS);
/*获取调度台地址*/
NETMGR_API BOOL MBOX_GetDispatcherAddress(MBOX_HANDLE handle,TRAP_SERVERS&);
/*设置调度台地址*/
NETMGR_API BOOL MBOX_SetNTPAddress(MBOX_HANDLE handle,const char *);
/*获取调度台地址*/
NETMGR_API BOOL MBOX_GetNTPAddress(MBOX_HANDLE handle,char[],int);
/*检查用户是否存在*/
NETMGR_API BOOL MBOX_IsSubscriberExist(MBOX_HANDLE handle,uint32 subNumber);
/*创建用户*/
NETMGR_API BOOL MBOX_CreateSubscriber(MBOX_HANDLE handle,SUB_BASE_INFO&);
/*批量创建用户*/
NETMGR_API int MBOX_BatchCreateSubscriber(MBOX_HANDLE handle,SUB_BASE_INFO&,uint32 subCount);
/*查询用户*/
NETMGR_API BOOL MBOX_QuerySubscriber(MBOX_HANDLE handle,uint32 subNumber,SUB_DETAILED_INFO& oService);
/*修改用户配置*/
NETMGR_API BOOL MBOX_ModifySubscriber(MBOX_HANDLE handle,uint32 subNumber,SUB_DETAILED_INFO& iService);
/*删除用户*/
NETMGR_API BOOL MBOX_DeleteSubscriber(MBOX_HANDLE handle,uint32 subNumber);
/*设置用户权限*/
NETMGR_API BOOL MBOX_SetSubscriberPriority(MBOX_HANDLE handle,uint32 subNumber,int priority);
/*获取用户权限*/
NETMGR_API BOOL MBOX_GetSubscriberPriority(MBOX_HANDLE handle,uint32 subNumber,int& priority);
/*创建路由组*/
NETMGR_API BOOL MBOX_CreateRouteGroup(MBOX_HANDLE handle,uint32 rteGrpID,const char *rteGrpName);
/*创建路由组*/
NETMGR_API BOOL MBOX_DeleteRouteGroup(MBOX_HANDLE handle,uint32 rteGrpID,const char *rteGrpName);
/*查询路由组*/
NETMGR_API BOOL MBOX_GetRouteGroup(MBOX_HANDLE handle,char[],uint32 bufferSize,uint32& ioRouteGroup);
/*保存设置*/
NETMGR_API BOOL MBOX_SaveHaveDoneCfg(MBOX_HANDLE handle);
/*清除设置*/
NETMGR_API BOOL MBOX_ClearDeviceCfg(MBOX_HANDLE handle);
/*重启设备*/
NETMGR_API void MBOX_Restart(MBOX_HANDLE handle);
/*设置呼叫中心号码*/
NETMGR_API BOOL MBOX_SetDispatchCenter(MBOX_HANDLE handle,const char *);
/*设置紧急号码*/
NETMGR_API BOOL MBOX_SetEmergencyNumber(MBOX_HANDLE handle,const char *);
/*设置SIP用户在线监测模式*/
NETMGR_API BOOL MBOX_SetSipOnlineDetectionMode(MBOX_HANDLE handle,int mode);//1: heartbeat 2:register 3: disable
/*获取用户在线监测模式*/
NETMGR_API BOOL MBOX_GetSipOnlineDetectionMode(MBOX_HANDLE handle,int& mode);
/*设置SIP用户注册时间间隔*/
NETMGR_API BOOL MBOX_SetSipRegisterCycleAndHeartBeatInterval(MBOX_HANDLE handle,int, int);
/*获取SIP用户注册时间间隔*/
NETMGR_API BOOL MBOX_GetSipRegisterCycleAndHeartBeatInterval(MBOX_HANDLE handle,int&, int&);
/*设置静态路由*/
NETMGR_API BOOL MBOX_SetStaticRouting(MBOX_HANDLE handle,STATIC_ROUTING_INFO);
/*获取静态路由*/
NETMGR_API BOOL MBOX_GetStaticRouting(MBOX_HANDLE handle,char[],uint32,int&);
/*设置CDR触发器*/
NETMGR_API BOOL MBOX_SetCdrTrigger(MBOX_HANDLE handle,int,int);
/*获取CDR触发器状态*/
NETMGR_API BOOL MBOX_GetCdrTrigger(MBOX_HANDLE handle,int&,int&);
/*设置录音服务器状态*/
NETMGR_API BOOL MBOX_SetRecordServer(MBOX_HANDLE handle,RECORD_SERVER_CONFIGURE);
/*获取录音服务器状态*/
NETMGR_API BOOL MBOX_GetRecordServer(MBOX_HANDLE handle,RECORD_SERVER_CONFIGURE&);
/*创建路由*/
NETMGR_API BOOL MBOX_CreateRouting(MBOX_HANDLE handle,ROUTE_CONFIG);
/*删除路由*/
NETMGR_API BOOL MBOX_DeleteRouting(MBOX_HANDLE handle,ROUTE_CONFIG);
/*获取路由*/
NETMGR_API BOOL MBOX_GetRouting(MBOX_HANDLE handle,char[],uint32,int&);
/*创建呼叫源*/
NETMGR_API BOOL MBOX_CreateCallSource(MBOX_HANDLE handle,CALLSOURCE );
/*删除呼叫源*/
NETMGR_API BOOL MBOX_DeleteCallSource(MBOX_HANDLE handle,CALLSOURCE);
/*获取呼叫源*/
NETMGR_API BOOL MBOX_GetCallSource(MBOX_HANDLE handle,char[],uint32,int&);
/*创建路由规则*/
NETMGR_API BOOL MBOX_CreateRoutingRule(MBOX_HANDLE handle,ROUTING_RULE);
/*删除路由规则*/
NETMGR_API BOOL MBOX_DeleteRoutingRule(MBOX_HANDLE handle,ROUTING_RULE);
/*获取路由规则*/
NETMGR_API BOOL MBOX_GetRoutingRule(MBOX_HANDLE handle,char[],uint32,int&);
/*创建呼叫源规则*/
NETMGR_API BOOL MBOX_CreateCallSourceRule(MBOX_HANDLE handle,CALLSOURCE_RULE);
/*删除呼叫源规则*/
NETMGR_API BOOL MBOX_DeleteCallSourceRule(MBOX_HANDLE handle,CALLSOURCE_RULE);
/*获取呼叫源规则*/
NETMGR_API BOOL MBOX_GetCallSourceRule(MBOX_HANDLE handle,char[],uint32,int&);
/*创建Sip访问点*/
NETMGR_API BOOL MBOX_CreateSipSap(MBOX_HANDLE handle,SIP_SAP_INFO);
/*删除Sip访问点*/
NETMGR_API BOOL MBOX_DeleteSipSap(MBOX_HANDLE handle,SIP_SAP_INFO);
/*获取Sip访问点*/
NETMGR_API BOOL MBOX_GetSipSap(MBOX_HANDLE handle,char[],uint32,int&);
/*创建PRI中继*/
NETMGR_API BOOL MBOX_CreatePriTrunk(MBOX_HANDLE handle,PRI_TRUNK_INFO&);
/*删除PRI中继*/
NETMGR_API BOOL MBOX_DeletePriTrunk(MBOX_HANDLE handle,PRI_TRUNK_INFO);
/*设置sip激活*/
NETMGR_API BOOL MBOX_SetSipTrunkAction(MBOX_HANDLE handle,int,int);
/*获取PRI中继*/
NETMGR_API BOOL MBOX_SetSipTrunkHeartBeatEnable(MBOX_HANDLE handle,int,int);
/*获取PRI中继*/
NETMGR_API BOOL MBOX_GetPriTrunk(MBOX_HANDLE handle,char[],uint32,int&);
/*设置PRI中继激活*/
NETMGR_API BOOL MBOX_SetPriTrunkAction(MBOX_HANDLE handle,int,int);
/*获取SIP中继*/
NETMGR_API BOOL MBOX_CreateSipTrunk(MBOX_HANDLE handle,SIP_TRUNK_INFO&);
/*删除SIP中继*/
NETMGR_API BOOL MBOX_DeleteSipTrunk(MBOX_HANDLE handle,SIP_TRUNK_INFO);
/*获取SIP中继*/
NETMGR_API BOOL MBOX_GetSipTrunk(MBOX_HANDLE handle,char[],uint32,int&);
/*创建PRI承载信道*/
NETMGR_API BOOL MBOX_CreateT1Channel(MBOX_HANDLE handle,T1_LINK);
/*删除PRI承载信道*/
NETMGR_API BOOL MBOX_DeleteT1Channel(MBOX_HANDLE handle,T1_LINK);
/*获取PRI承载信道*/
NETMGR_API BOOL MBOX_GetT1Channels(MBOX_HANDLE handle, char[],uint32,int &);
/*创建信令信道*/
NETMGR_API BOOL MBOX_CreateSigChannel(MBOX_HANDLE handle,SIG_LINK);
/*删除PRI信令信道*/
NETMGR_API BOOL MBOX_DeleteSigChannel(MBOX_HANDLE handle,SIG_LINK);
/*获取PRI信令信道*/
NETMGR_API BOOL MBOX_GetSigChannel(MBOX_HANDLE handle,char[],uint32,int &);
/*创建被叫号码规则*/
NETMGR_API BOOL MBOX_CreateCalledNumAnalysisRule(MBOX_HANDLE ,CALLED_ANALYSIS_RULE);
/*删除被叫号码规则*/
NETMGR_API BOOL MBOX_DeleteCalledNumAnalysisRule(MBOX_HANDLE ,CALLED_ANALYSIS_RULE);
/*获取被叫号码规则*/
NETMGR_API BOOL MBOX_GetCalledNumAnalysisRule(MBOX_HANDLE ,char[],uint32,int&);
/*设置时钟源*/
NETMGR_API BOOL MBOX_SetClockSource(MBOX_HANDLE ,CLOCKSOURCE);
/*获取时钟源*/
NETMGR_API BOOL MBOX_GetClockSource(MBOX_HANDLE ,char[],uint32,int&);
/*创建短消息实体*/
NETMGR_API BOOL MBOX_CreateShortMessageEntity(MBOX_HANDLE,SHORT_MESSAGE_ENTITY);
/*删除短消息实体*/
NETMGR_API BOOL MBOX_DeleteShortMessageEntity(MBOX_HANDLE,SHORT_MESSAGE_ENTITY);
/*查询短消息实体*/
NETMGR_API BOOL MBOX_GetShortMessageEntity(MBOX_HANDLE,char[],uint32,int&);
/*增加扩展短消息实体终端*/
NETMGR_API BOOL MBOX_AddEsmeTerminate(MBOX_HANDLE handle,char *);
/*移除扩展短消息实体终端*/
NETMGR_API BOOL MBOX_RemoveEsmeTerminate(MBOX_HANDLE handle,char *);
/*获取扩展短消息实体终端*/
NETMGR_API BOOL MBOX_GetEsmeTerminate(MBOX_HANDLE handle,char[],int);

//////////////////////////////////////////////////////////////////////////
/*设置3G DNS服务器*/
NETMGR_API BOOL MBOX_3G_SetDNSServer(MBOX_HANDLE,const char * primaryDNS,const char *SecondDNS);
/*获取3G DNS服务器*/
NETMGR_API BOOL MBOX_3G_GetDNSServer(MBOX_HANDLE,char[MAX_IP4],char[MAX_IP4]);
/*设置安全网关地址*/
NETMGR_API BOOL MBOX_3G_SetSecureGatewayAddress(MBOX_HANDLE,const char *);
/*获取安全网关地址*/
NETMGR_API BOOL MBOX_3G_GetSecureGatewayAddress(MBOX_HANDLE,char[MAX_IP4]);
/*获取安全网关状态*/
NETMGR_API BOOL MBOX_3G_GetSecureGatewayStatus(MBOX_HANDLE,int&/*1down,2up*/);
/*创建PDS地址*/
NETMGR_API BOOL MBOX_3G_CreatePDS(MBOX_HANDLE,int,const char *);
/*删除PDS地址*/
NETMGR_API BOOL MBOX_3G_DeletePDS(MBOX_HANDLE,int);
/*获取PDS地址*/
NETMGR_API BOOL MBOX_3G_GetPDS(MBOX_HANDLE,char[],uint32,int&);
/*激活(去激活)PDS*/
NETMGR_API BOOL MBOX_3G_SetPDSActive(MBOX_HANDLE,int,int);
/*创建FAP*/
NETMGR_API BOOL MBOX_3G_CreateFAP(MBOX_HANDLE,FEMTO_AP);
/*删除FAP*/
NETMGR_API BOOL MBOX_3G_DeleteFAP(MBOX_HANDLE,FEMTO_AP);
/*获取FAP*/
NETMGR_API BOOL MBOX_3G_GetFAP(MBOX_HANDLE,char[],uint32,int&);
/*获取安全网关Link*/
NETMGR_API BOOL MBOX_3G_GetSecureGatewayLink(MBOX_HANDLE,char[],uint32,int&);
/*获取GTP通道信息*/
NETMGR_API BOOL MBOX_3G_GetGTPChannel(MBOX_HANDLE,char[],uint32,int&);
/*获取VIDEO通道信息*/
NETMGR_API BOOL MBOX_3G_GetVideoChannel(MBOX_HANDLE,char[],uint32,int&);

#endif