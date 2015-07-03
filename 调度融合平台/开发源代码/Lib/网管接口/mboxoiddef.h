#ifndef _bl8000_oid_H
#define _bl8000_oid_H

#include "basic_macro.h"
#define BATCHCREATESUB_OID_COUNT     11
#define BATCH_CREATE_P3G_OID_COUNT   9
#define MODIFY_OID_COUNT             17
#define ALARMNOTIFY_OID_COUNT        8
#define SUB_SCRIBER_PROFILE_ITEM_CNT  28

#define P3G_PROFILE_WRITE_ITEM_CNT   8        //增加3g用户的oid的数量
#define SIP_PROFILE_WRITE_ITEM_CNT   6        //增加wifi用户的oid的数量
#define PS_PROFILE_WRITE_ITEM_CNT    7        //增加小灵通用户的oid的数量

#define SUB_PROFILE_DEL_ITEM_CNT     18
#define ROUTE_GROUP_CFG_CNT          2 
#define ROUTE_CFG_ITEM_CNT           15
#define CALLSOURCE_RULE_ITEM_COUNT   7
#define SIP_TRUNK_ITEM_COUNT         13
#define PRI_TRUNK_ITEM_COUNT         10

NS_BEGIN(MBOX_OID)

extern const char * strNodeName; //asepGenNodeInfoNodeName

extern const char * strSubNumberCommonPart;//asepEprtSPMSubNumber 1.3.6.1.4.1.38108.3.1.2.2.1.1.1.1.2

extern const char * strDispatchTrapPrefixOid[4];

extern const char * strAlarmTrapPrefixOid[2];

extern const char * strDispatchOid[10];

extern const char * strDispatchTphistWorkMode; //enable auto answer

extern const char * strUserStatusOid[10];

extern const char * strAlarmNotifyOid[ALARMNOTIFY_OID_COUNT];

extern const char * strBatchCreateSubscriberOid[BATCHCREATESUB_OID_COUNT];

extern const char * strBatchCreateP3gOid[BATCH_CREATE_P3G_OID_COUNT];

extern const char * strSubscriberProfileManagementQueryOid[SUB_SCRIBER_PROFILE_ITEM_CNT];

extern const char * str3GSubscriberProfileManagementWriteOid[P3G_PROFILE_WRITE_ITEM_CNT];

extern const char * strSipSubscriberProfileManagementWriteOid[SIP_PROFILE_WRITE_ITEM_CNT];

extern const char * strPsSubscriberProfileManagementWriteOid[PS_PROFILE_WRITE_ITEM_CNT];

extern const char * strSubscriberProfileManagementModifyOid[MODIFY_OID_COUNT];

extern const char * strSubscriberProfileManagementDeleteOid[SUB_PROFILE_DEL_ITEM_CNT];

extern const char * strSubscriberGroupNameOid;

extern const char * strRouteGroupCfgEntryOid[ROUTE_GROUP_CFG_CNT];

extern const char * strRouteCfgEntryOid[ROUTE_CFG_ITEM_CNT];

extern const char * strSaveAllCfgOid;

extern const char * strCleanCfgOid;

extern const char * strResetNodeActionOid;

extern const char * strSetCallCenterOid;

extern const char * strSetSipOnlineDetectedOid[2];

extern const char * strSipConnectStatusCheckOid[2];

extern const char * strCdrconfigureOid[2];

extern const char * strStaticRoutingOid[4];

extern const char * strRecordServerConfigOid[3];

extern const char * strCallSourceOid[5];

extern const char * strRoutingRuleOid[4];

extern const char * strCallSourceRuleOid[CALLSOURCE_RULE_ITEM_COUNT];

extern const char * strSipSapOid[4];

extern const char * strSipTrunkOid[SIP_TRUNK_ITEM_COUNT];

extern const char * strPriTrunkOid[PRI_TRUNK_ITEM_COUNT];


NS_END
#endif