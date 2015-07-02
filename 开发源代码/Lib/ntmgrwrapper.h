#ifndef _ntmgrwrapper_h_
#define _ntmgrwrapper_h_

#include "../../common/mboxtypedef.h"

#define BL8000API extern "C" __declspec(dllexport) 


#ifndef BOOL
typedef int BOOL;
#define TRUE  1
#define FALSE 0
#endif

/*初始化*/
BL8000API BOOL MBOX_Initialize();
/*释放*/
BL8000API BOOL MBOX_Dispose();
/*获取错误码*/
BL8000API MBOX_ERRORCODE MBOX_GetLastError();
/*登录*/
BL8000API MBOX_HANDLE MBOX_Login(char *sMboxIp,char* sLocalIp, char *sUserName,char * sUserPassword);
/*登出*/
BL8000API BOOL MBOX_Logout(MBOX_HANDLE handle);
/*检测设备在线情况*/
BL8000API BOOL MBOX_IsDeviceOnline(char *sMboxIP);
/*检查用户是否存在*/
BL8000API BOOL MBOX_IsSubscriberExist(MBOX_HANDLE handle,uint32 subNumber);
/*创建用户*/
BL8000API BOOL MBOX_CreateSubscriber(MBOX_HANDLE handle,SUB_BASE_INFO);
/*批量创建用户*/
BL8000API int MBOX_BatchCreateSubscriber(MBOX_HANDLE handle,uint32 first,uint32 subCount);
/*查询用户*/
BL8000API BOOL MBOX_QuerySubscriber(MBOX_HANDLE handle,uint32 subNumber,SUB_DETAILED_INFO& ioService);
/*修改用户配置*/
BL8000API BOOL MBOX_ModifySubscriber(MBOX_HANDLE handle,uint32 subNumber,SUB_DETAILED_INFO& ioService);
/*删除用户*/
BL8000API BOOL MBOX_DeleteSubscriber(MBOX_HANDLE handle,uint32 subNumber);
/*创建路由组*/
BL8000API BOOL MBOX_CreateRouteGroup(MBOX_HANDLE handle,uint32 rteGrpID,const char * rteGrpName);
/*创建路由组*/
BL8000API BOOL MBOX_DeleteRouteGroup(MBOX_HANDLE handle,uint32 rteGrpID,const char * rteGrpName);
/*查询路由组*/
BL8000API BOOL MBOX_QueryRouteGroup(MBOX_HANDLE handle,RouteGroup &);
/*保存设置*/
BL8000API BOOL MBOX_SaveHaveDoneCfg(MBOX_HANDLE handle);
/*清除设置*/
BL8000API BOOL MBOX_ClearDeviceCfg(MBOX_HANDLE handle);
/*重启设备*/
BL8000API void MBOX_Restart(MBOX_HANDLE handle);



#endif