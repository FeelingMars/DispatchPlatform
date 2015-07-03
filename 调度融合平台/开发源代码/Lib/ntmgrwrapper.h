#ifndef _ntmgrwrapper_h_
#define _ntmgrwrapper_h_

#include "../../common/mboxtypedef.h"

#define BL8000API extern "C" __declspec(dllexport) 


#ifndef BOOL
typedef int BOOL;
#define TRUE  1
#define FALSE 0
#endif

/*��ʼ��*/
BL8000API BOOL MBOX_Initialize();
/*�ͷ�*/
BL8000API BOOL MBOX_Dispose();
/*��ȡ������*/
BL8000API MBOX_ERRORCODE MBOX_GetLastError();
/*��¼*/
BL8000API MBOX_HANDLE MBOX_Login(char *sMboxIp,char* sLocalIp, char *sUserName,char * sUserPassword);
/*�ǳ�*/
BL8000API BOOL MBOX_Logout(MBOX_HANDLE handle);
/*����豸�������*/
BL8000API BOOL MBOX_IsDeviceOnline(char *sMboxIP);
/*����û��Ƿ����*/
BL8000API BOOL MBOX_IsSubscriberExist(MBOX_HANDLE handle,uint32 subNumber);
/*�����û�*/
BL8000API BOOL MBOX_CreateSubscriber(MBOX_HANDLE handle,SUB_BASE_INFO);
/*���������û�*/
BL8000API int MBOX_BatchCreateSubscriber(MBOX_HANDLE handle,uint32 first,uint32 subCount);
/*��ѯ�û�*/
BL8000API BOOL MBOX_QuerySubscriber(MBOX_HANDLE handle,uint32 subNumber,SUB_DETAILED_INFO& ioService);
/*�޸��û�����*/
BL8000API BOOL MBOX_ModifySubscriber(MBOX_HANDLE handle,uint32 subNumber,SUB_DETAILED_INFO& ioService);
/*ɾ���û�*/
BL8000API BOOL MBOX_DeleteSubscriber(MBOX_HANDLE handle,uint32 subNumber);
/*����·����*/
BL8000API BOOL MBOX_CreateRouteGroup(MBOX_HANDLE handle,uint32 rteGrpID,const char * rteGrpName);
/*����·����*/
BL8000API BOOL MBOX_DeleteRouteGroup(MBOX_HANDLE handle,uint32 rteGrpID,const char * rteGrpName);
/*��ѯ·����*/
BL8000API BOOL MBOX_QueryRouteGroup(MBOX_HANDLE handle,RouteGroup &);
/*��������*/
BL8000API BOOL MBOX_SaveHaveDoneCfg(MBOX_HANDLE handle);
/*�������*/
BL8000API BOOL MBOX_ClearDeviceCfg(MBOX_HANDLE handle);
/*�����豸*/
BL8000API void MBOX_Restart(MBOX_HANDLE handle);



#endif