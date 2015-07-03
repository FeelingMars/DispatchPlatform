/******************************************************************************
 *  ��Ȩ���У�C��2012-2013���Ͼ���·�Զ���ϵͳ�������ι�˾                    *
 *  ��������Ȩ����                                                            *
 ******************************************************************************
 *  ���� : �ܹ���
 *  ���� : ���Ƚ��������ܽӿڶ���
 *  �汾 : 1.0
 *****************************************************************************/
/*  �޸ļ�¼: 
      ����       �汾    �޸���             �޸�����

******************************************************************************/

#ifndef NETMANAMENT_H
#define NETMANAMENT_H

#include "mboxtypedef.h"

#define NETMGR_API extern "C" __declspec(dllexport) 

NETMGR_API BOOL MBOX_TEST(int [],int&);

/*��ʼ��*/
NETMGR_API BOOL MBOX_Initialize();
/*�ͷ�*/
NETMGR_API BOOL MBOX_Dispose();
/*��ȡ������*/
NETMGR_API MBOX_ERRORCODE MBOX_GetLastError();
/*��ȡ�豸�ͺ�*/
NETMGR_API BOOL MBOX_GetDeviceType(MBOX_HANDLE handle,int &);
//��ȡ�豸������
NETMGR_API BOOL MBOX_GetDeviceCapabilities(int type,DEVICE_CAPABILITY&);
/*��¼*/
NETMGR_API MBOX_HANDLE MBOX_Login(char *sMboxIp,char* sLocalIp, char *sUserName,char * sUserPassword);
/*�ǳ�*/
NETMGR_API BOOL MBOX_Logout(MBOX_HANDLE handle);
/*����豸�������*/
NETMGR_API BOOL MBOX_IsDeviceOnline(char *sMboxIP);
/*���ýڵ���Ϣ*/
NETMGR_API void MBOX_SetNodeInfo(MBOX_HANDLE handle,NODE_INFO);
/*��ȡ�ڵ���Ϣ*/
NETMGR_API BOOL MBOX_GetNodeInfo(MBOX_HANDLE handle,NODE_INFO& node);
/*����DSP��ַ*/
NETMGR_API void MBOX_SetDspAddress(MBOX_HANDLE handle,const char *);
/*��ȡDSP��ַ*/
NETMGR_API BOOL MBOX_GetDspAddress(MBOX_HANDLE handle,char[],int size);
/*���õ���̨��ַ*/
NETMGR_API BOOL MBOX_SetDispatcherAddress(MBOX_HANDLE handle,TRAP_SERVERS);
/*��ȡ����̨��ַ*/
NETMGR_API BOOL MBOX_GetDispatcherAddress(MBOX_HANDLE handle,TRAP_SERVERS&);
/*���õ���̨��ַ*/
NETMGR_API BOOL MBOX_SetNTPAddress(MBOX_HANDLE handle,const char *);
/*��ȡ����̨��ַ*/
NETMGR_API BOOL MBOX_GetNTPAddress(MBOX_HANDLE handle,char[],int);
/*����û��Ƿ����*/
NETMGR_API BOOL MBOX_IsSubscriberExist(MBOX_HANDLE handle,uint32 subNumber);
/*�����û�*/
NETMGR_API BOOL MBOX_CreateSubscriber(MBOX_HANDLE handle,SUB_BASE_INFO&);
/*���������û�*/
NETMGR_API int MBOX_BatchCreateSubscriber(MBOX_HANDLE handle,SUB_BASE_INFO&,uint32 subCount);
/*��ѯ�û�*/
NETMGR_API BOOL MBOX_QuerySubscriber(MBOX_HANDLE handle,uint32 subNumber,SUB_DETAILED_INFO& oService);
/*�޸��û�����*/
NETMGR_API BOOL MBOX_ModifySubscriber(MBOX_HANDLE handle,uint32 subNumber,SUB_DETAILED_INFO& iService);
/*ɾ���û�*/
NETMGR_API BOOL MBOX_DeleteSubscriber(MBOX_HANDLE handle,uint32 subNumber);
/*�����û�Ȩ��*/
NETMGR_API BOOL MBOX_SetSubscriberPriority(MBOX_HANDLE handle,uint32 subNumber,int priority);
/*��ȡ�û�Ȩ��*/
NETMGR_API BOOL MBOX_GetSubscriberPriority(MBOX_HANDLE handle,uint32 subNumber,int& priority);
/*����·����*/
NETMGR_API BOOL MBOX_CreateRouteGroup(MBOX_HANDLE handle,uint32 rteGrpID,const char *rteGrpName);
/*����·����*/
NETMGR_API BOOL MBOX_DeleteRouteGroup(MBOX_HANDLE handle,uint32 rteGrpID,const char *rteGrpName);
/*��ѯ·����*/
NETMGR_API BOOL MBOX_GetRouteGroup(MBOX_HANDLE handle,char[],uint32 bufferSize,uint32& ioRouteGroup);
/*��������*/
NETMGR_API BOOL MBOX_SaveHaveDoneCfg(MBOX_HANDLE handle);
/*�������*/
NETMGR_API BOOL MBOX_ClearDeviceCfg(MBOX_HANDLE handle);
/*�����豸*/
NETMGR_API void MBOX_Restart(MBOX_HANDLE handle);
/*���ú������ĺ���*/
NETMGR_API BOOL MBOX_SetDispatchCenter(MBOX_HANDLE handle,const char *);
/*���ý�������*/
NETMGR_API BOOL MBOX_SetEmergencyNumber(MBOX_HANDLE handle,const char *);
/*����SIP�û����߼��ģʽ*/
NETMGR_API BOOL MBOX_SetSipOnlineDetectionMode(MBOX_HANDLE handle,int mode);//1: heartbeat 2:register 3: disable
/*��ȡ�û����߼��ģʽ*/
NETMGR_API BOOL MBOX_GetSipOnlineDetectionMode(MBOX_HANDLE handle,int& mode);
/*����SIP�û�ע��ʱ����*/
NETMGR_API BOOL MBOX_SetSipRegisterCycleAndHeartBeatInterval(MBOX_HANDLE handle,int, int);
/*��ȡSIP�û�ע��ʱ����*/
NETMGR_API BOOL MBOX_GetSipRegisterCycleAndHeartBeatInterval(MBOX_HANDLE handle,int&, int&);
/*���þ�̬·��*/
NETMGR_API BOOL MBOX_SetStaticRouting(MBOX_HANDLE handle,STATIC_ROUTING_INFO);
/*��ȡ��̬·��*/
NETMGR_API BOOL MBOX_GetStaticRouting(MBOX_HANDLE handle,char[],uint32,int&);
/*����CDR������*/
NETMGR_API BOOL MBOX_SetCdrTrigger(MBOX_HANDLE handle,int,int);
/*��ȡCDR������״̬*/
NETMGR_API BOOL MBOX_GetCdrTrigger(MBOX_HANDLE handle,int&,int&);
/*����¼��������״̬*/
NETMGR_API BOOL MBOX_SetRecordServer(MBOX_HANDLE handle,RECORD_SERVER_CONFIGURE);
/*��ȡ¼��������״̬*/
NETMGR_API BOOL MBOX_GetRecordServer(MBOX_HANDLE handle,RECORD_SERVER_CONFIGURE&);
/*����·��*/
NETMGR_API BOOL MBOX_CreateRouting(MBOX_HANDLE handle,ROUTE_CONFIG);
/*ɾ��·��*/
NETMGR_API BOOL MBOX_DeleteRouting(MBOX_HANDLE handle,ROUTE_CONFIG);
/*��ȡ·��*/
NETMGR_API BOOL MBOX_GetRouting(MBOX_HANDLE handle,char[],uint32,int&);
/*��������Դ*/
NETMGR_API BOOL MBOX_CreateCallSource(MBOX_HANDLE handle,CALLSOURCE );
/*ɾ������Դ*/
NETMGR_API BOOL MBOX_DeleteCallSource(MBOX_HANDLE handle,CALLSOURCE);
/*��ȡ����Դ*/
NETMGR_API BOOL MBOX_GetCallSource(MBOX_HANDLE handle,char[],uint32,int&);
/*����·�ɹ���*/
NETMGR_API BOOL MBOX_CreateRoutingRule(MBOX_HANDLE handle,ROUTING_RULE);
/*ɾ��·�ɹ���*/
NETMGR_API BOOL MBOX_DeleteRoutingRule(MBOX_HANDLE handle,ROUTING_RULE);
/*��ȡ·�ɹ���*/
NETMGR_API BOOL MBOX_GetRoutingRule(MBOX_HANDLE handle,char[],uint32,int&);
/*��������Դ����*/
NETMGR_API BOOL MBOX_CreateCallSourceRule(MBOX_HANDLE handle,CALLSOURCE_RULE);
/*ɾ������Դ����*/
NETMGR_API BOOL MBOX_DeleteCallSourceRule(MBOX_HANDLE handle,CALLSOURCE_RULE);
/*��ȡ����Դ����*/
NETMGR_API BOOL MBOX_GetCallSourceRule(MBOX_HANDLE handle,char[],uint32,int&);
/*����Sip���ʵ�*/
NETMGR_API BOOL MBOX_CreateSipSap(MBOX_HANDLE handle,SIP_SAP_INFO);
/*ɾ��Sip���ʵ�*/
NETMGR_API BOOL MBOX_DeleteSipSap(MBOX_HANDLE handle,SIP_SAP_INFO);
/*��ȡSip���ʵ�*/
NETMGR_API BOOL MBOX_GetSipSap(MBOX_HANDLE handle,char[],uint32,int&);
/*����PRI�м�*/
NETMGR_API BOOL MBOX_CreatePriTrunk(MBOX_HANDLE handle,PRI_TRUNK_INFO&);
/*ɾ��PRI�м�*/
NETMGR_API BOOL MBOX_DeletePriTrunk(MBOX_HANDLE handle,PRI_TRUNK_INFO);
/*����sip����*/
NETMGR_API BOOL MBOX_SetSipTrunkAction(MBOX_HANDLE handle,int,int);
/*��ȡPRI�м�*/
NETMGR_API BOOL MBOX_SetSipTrunkHeartBeatEnable(MBOX_HANDLE handle,int,int);
/*��ȡPRI�м�*/
NETMGR_API BOOL MBOX_GetPriTrunk(MBOX_HANDLE handle,char[],uint32,int&);
/*����PRI�м̼���*/
NETMGR_API BOOL MBOX_SetPriTrunkAction(MBOX_HANDLE handle,int,int);
/*��ȡSIP�м�*/
NETMGR_API BOOL MBOX_CreateSipTrunk(MBOX_HANDLE handle,SIP_TRUNK_INFO&);
/*ɾ��SIP�м�*/
NETMGR_API BOOL MBOX_DeleteSipTrunk(MBOX_HANDLE handle,SIP_TRUNK_INFO);
/*��ȡSIP�м�*/
NETMGR_API BOOL MBOX_GetSipTrunk(MBOX_HANDLE handle,char[],uint32,int&);
/*����PRI�����ŵ�*/
NETMGR_API BOOL MBOX_CreateT1Channel(MBOX_HANDLE handle,T1_LINK);
/*ɾ��PRI�����ŵ�*/
NETMGR_API BOOL MBOX_DeleteT1Channel(MBOX_HANDLE handle,T1_LINK);
/*��ȡPRI�����ŵ�*/
NETMGR_API BOOL MBOX_GetT1Channels(MBOX_HANDLE handle, char[],uint32,int &);
/*���������ŵ�*/
NETMGR_API BOOL MBOX_CreateSigChannel(MBOX_HANDLE handle,SIG_LINK);
/*ɾ��PRI�����ŵ�*/
NETMGR_API BOOL MBOX_DeleteSigChannel(MBOX_HANDLE handle,SIG_LINK);
/*��ȡPRI�����ŵ�*/
NETMGR_API BOOL MBOX_GetSigChannel(MBOX_HANDLE handle,char[],uint32,int &);
/*�������к������*/
NETMGR_API BOOL MBOX_CreateCalledNumAnalysisRule(MBOX_HANDLE ,CALLED_ANALYSIS_RULE);
/*ɾ�����к������*/
NETMGR_API BOOL MBOX_DeleteCalledNumAnalysisRule(MBOX_HANDLE ,CALLED_ANALYSIS_RULE);
/*��ȡ���к������*/
NETMGR_API BOOL MBOX_GetCalledNumAnalysisRule(MBOX_HANDLE ,char[],uint32,int&);
/*����ʱ��Դ*/
NETMGR_API BOOL MBOX_SetClockSource(MBOX_HANDLE ,CLOCKSOURCE);
/*��ȡʱ��Դ*/
NETMGR_API BOOL MBOX_GetClockSource(MBOX_HANDLE ,char[],uint32,int&);
/*��������Ϣʵ��*/
NETMGR_API BOOL MBOX_CreateShortMessageEntity(MBOX_HANDLE,SHORT_MESSAGE_ENTITY);
/*ɾ������Ϣʵ��*/
NETMGR_API BOOL MBOX_DeleteShortMessageEntity(MBOX_HANDLE,SHORT_MESSAGE_ENTITY);
/*��ѯ����Ϣʵ��*/
NETMGR_API BOOL MBOX_GetShortMessageEntity(MBOX_HANDLE,char[],uint32,int&);
/*������չ����Ϣʵ���ն�*/
NETMGR_API BOOL MBOX_AddEsmeTerminate(MBOX_HANDLE handle,char *);
/*�Ƴ���չ����Ϣʵ���ն�*/
NETMGR_API BOOL MBOX_RemoveEsmeTerminate(MBOX_HANDLE handle,char *);
/*��ȡ��չ����Ϣʵ���ն�*/
NETMGR_API BOOL MBOX_GetEsmeTerminate(MBOX_HANDLE handle,char[],int);

//////////////////////////////////////////////////////////////////////////
/*����3G DNS������*/
NETMGR_API BOOL MBOX_3G_SetDNSServer(MBOX_HANDLE,const char * primaryDNS,const char *SecondDNS);
/*��ȡ3G DNS������*/
NETMGR_API BOOL MBOX_3G_GetDNSServer(MBOX_HANDLE,char[MAX_IP4],char[MAX_IP4]);
/*���ð�ȫ���ص�ַ*/
NETMGR_API BOOL MBOX_3G_SetSecureGatewayAddress(MBOX_HANDLE,const char *);
/*��ȡ��ȫ���ص�ַ*/
NETMGR_API BOOL MBOX_3G_GetSecureGatewayAddress(MBOX_HANDLE,char[MAX_IP4]);
/*��ȡ��ȫ����״̬*/
NETMGR_API BOOL MBOX_3G_GetSecureGatewayStatus(MBOX_HANDLE,int&/*1down,2up*/);
/*����PDS��ַ*/
NETMGR_API BOOL MBOX_3G_CreatePDS(MBOX_HANDLE,int,const char *);
/*ɾ��PDS��ַ*/
NETMGR_API BOOL MBOX_3G_DeletePDS(MBOX_HANDLE,int);
/*��ȡPDS��ַ*/
NETMGR_API BOOL MBOX_3G_GetPDS(MBOX_HANDLE,char[],uint32,int&);
/*����(ȥ����)PDS*/
NETMGR_API BOOL MBOX_3G_SetPDSActive(MBOX_HANDLE,int,int);
/*����FAP*/
NETMGR_API BOOL MBOX_3G_CreateFAP(MBOX_HANDLE,FEMTO_AP);
/*ɾ��FAP*/
NETMGR_API BOOL MBOX_3G_DeleteFAP(MBOX_HANDLE,FEMTO_AP);
/*��ȡFAP*/
NETMGR_API BOOL MBOX_3G_GetFAP(MBOX_HANDLE,char[],uint32,int&);
/*��ȡ��ȫ����Link*/
NETMGR_API BOOL MBOX_3G_GetSecureGatewayLink(MBOX_HANDLE,char[],uint32,int&);
/*��ȡGTPͨ����Ϣ*/
NETMGR_API BOOL MBOX_3G_GetGTPChannel(MBOX_HANDLE,char[],uint32,int&);
/*��ȡVIDEOͨ����Ϣ*/
NETMGR_API BOOL MBOX_3G_GetVideoChannel(MBOX_HANDLE,char[],uint32,int&);

#endif