using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoiceDispatchManage.Tools
{
    public class MBoxOperate
    {
        static int ArraySize = 500;
        static int ArraySizeBig = 1024;


        #region 路由路由组
        //创建路由组
        private static bool CreateRouteGroup(DB_Talk.Model.m_RouteGroup model,out int RouteGroupID)
        {
            //创建路由组只传入名称，没有ID
            bool b = false;
            RouteGroupID = 0;
            List<DB_Talk.Model.m_RouteGroup> lst = new List<DB_Talk.Model.m_RouteGroup>();
            QueryRouteGroup(out lst);
            if (lst != null && lst.Count > 0)
            {
                DB_Talk.Model.m_RouteGroup temp = lst.Find(item => item.vc_Name == model.vc_Name);
                if (temp != null) //存在相同名称的,直接返回相同名称的路由组ID
                {
                    RouteGroupID = temp.ID;
                    return true;  //存在的不再添加
                }
                else
                {
                    model.ID = lst[lst.Count - 1].ID +1;  //不存在相同名称的，需要新建，ID为目前最大ID+1
                }
            }
            else
            {
                model.ID = 1; //没有路由的情况下ID从1开始
            }
            if (model.ID > 0 && model.vc_Name != "")
            {
                RouteGroupID = model.ID;
                b = MBoxSDK.ConfigSDK.MBOX_CreateRouteGroup(Global.Params.BoxHandle, (uint)model.ID, model.vc_Name);
            }
            return b;

            /*
            bool b = false;
            List<DB_Talk.Model.m_RouteGroup> lst = new List<DB_Talk.Model.m_RouteGroup>();
            QueryRouteGroup(out lst);
            if (lst != null && lst.Count > 0)
            {
                    if (lst.Contains(model))
                    {
                        return true;  //存在的不再添加
                    }
            }
            if (model.ID > 0 && model.vc_Name != "")
            {
                b = MBoxSDK.ConfigSDK.MBOX_CreateRouteGroup(Global.Params.BoxHandle, (uint)model.ID, model.vc_Name);
            }
            return b;
             */
        }
        //删除路由组
        private static bool DeleteRouteGroup(DB_Talk.Model.m_RouteGroup model)
        {
            bool b = false;
            if (!IsBoxExitRouteGroup(model)) return true;
            if (model.ID > 0 && model.vc_Name != "")
            {
                b = MBoxSDK.ConfigSDK.MBOX_DeleteRouteGroup(Global.Params.BoxHandle, (uint)model.ID, model.vc_Name);
            }
            return b;
        }
        //查询路由组
        private static bool QueryRouteGroup(out List<DB_Talk.Model.m_RouteGroup> lstRGroup)
        {
            bool b = false;
            lstRGroup = new List<DB_Talk.Model.m_RouteGroup>();
            byte[] byteArray = new byte[ArraySizeBig];
            int len = ArraySizeBig;
            b = MBoxSDK.ConfigSDK.MBOX_GetRouteGroup(Global.Params.BoxHandle, byteArray, byteArray.Length, ref len);
            //if (b)
            {
                string str = System.Text.Encoding.Default.GetString(byteArray);
                str = str.Replace("\0", "");
                string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    DB_Talk.Model.m_RouteGroup m = new DB_Talk.Model.m_RouteGroup();
                    string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    m.ID = int.Parse(strArray2[0]);
                    m.vc_Name = strArray2[1];
                    m.BoxID = Global.Params.BoxID;
                    lstRGroup.Add(m);
                }
            }
            return b;
        }

        private static bool IsBoxExitRouteGroup(DB_Talk.Model.m_RouteGroup model)
        {
            List<DB_Talk.Model.m_RouteGroup> lst = new List<DB_Talk.Model.m_RouteGroup>();
            QueryRouteGroup(out lst);
            if (lst != null && lst.Count > 0)
            {
                DB_Talk.Model.m_RouteGroup temp = lst.Find(item => item.vc_Name == model.vc_Name);
                if (temp != null) //存在相同名称的,直接返回相同名称的路由组ID
                {
                    return true;  //存在的不再添加
                }
            }
            return false;
              
        }
        //创建路由
        private static bool CreateRoute(DB_Talk.Model.m_Route model)
        {
            bool b = false;
            if (IsBoxExitRoute(model)) return true;
            if (model.ID > 0 && model.RouteGroupID > 0 && model.vc_Name != "")
            {
                MBoxSDK.ConfigSDK.tagRouteConfig RouteConf = new MBoxSDK.ConfigSDK.tagRouteConfig();
                RouteConf.routeID = model.ID;
                RouteConf.routeGroupID = model.RouteGroupID;
                RouteConf.routeType =  model.i_RouteType; //1: btw(1)双向（默认）
                RouteConf.routeName = new byte[MBoxSDK.ConfigSDK.MAX_ROUTE_NAME + 1];
                byte[] byteName = System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_Name);
                byteName.CopyTo(RouteConf.routeName, 0);
                b = MBoxSDK.ConfigSDK.MBOX_CreateRouting(Global.Params.BoxHandle, RouteConf);
            }
            return b;

        }
        //删除路由
        private static bool DeleteRoute(DB_Talk.Model.m_Route model)
        {
            bool b = false;
            if (!IsBoxExitRoute(model)) return true;
            if (model.ID > 0 && model.RouteGroupID > 0 && model.vc_Name != "")
            {
                MBoxSDK.ConfigSDK.tagRouteConfig RouteConf = new MBoxSDK.ConfigSDK.tagRouteConfig();
                RouteConf.routeID = model.ID;
                RouteConf.routeGroupID = model.RouteGroupID;
                RouteConf.routeType = model.i_RouteType; //1: btw(1)双向（默认）
                RouteConf.routeName = new byte[MBoxSDK.ConfigSDK.MAX_ROUTE_NAME + 1];
                byte[] byteName = System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_Name);
                byteName.CopyTo(RouteConf.routeName, 0);
                b = MBoxSDK.ConfigSDK.MBOX_DeleteRouting(Global.Params.BoxHandle, RouteConf);
            }
            return b;
        }
        //查询路由
        private static bool QueryRoute(out List<DB_Talk.Model.m_Route> lstRoute)
        {
            bool b = false;
            lstRoute = new List<DB_Talk.Model.m_Route>();
            byte[] byteArray = new byte[ArraySizeBig];
            int len = ArraySizeBig;
            b = MBoxSDK.ConfigSDK.MBOX_GetRouting(Global.Params.BoxHandle, byteArray, (uint)byteArray.Length, ref len);
            //if (b)
            {
                string str = System.Text.Encoding.Default.GetString(byteArray);
                str = str.Replace("\0", "");
                string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    DB_Talk.Model.m_Route m = new DB_Talk.Model.m_Route();
                    string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    m.ID = (int.Parse(strArray2[0]));
                    m.i_RouteType = (int.Parse(strArray2[1]));
                    m.RouteGroupID = (int.Parse(strArray2[2]));
                    m.vc_Name = strArray2[3];
                    m.BoxID = Global.Params.BoxID;
                    lstRoute.Add(m);
                    //"路由ID,路由类型,路由组ID,路由名称"
                }
            }
            return b;
        }


        private static bool IsBoxExitRoute(DB_Talk.Model.m_Route model)
        {
            List<DB_Talk.Model.m_Route> lst = new List<DB_Talk.Model.m_Route>();
            QueryRoute(out lst);
            if (lst != null && lst.Count > 0)
            {
                if (lst.Contains(model))
                {
                    return true;  //存在的不再添加
                }
            }
            return false;

        }

        #endregion

        #region  呼叫规则
        //创建呼叫源
        private static bool CreateCallSource(DB_Talk.Model.m_CallingSource model)
        {
            bool b = false;
            List<DB_Talk.Model.m_CallingSource> lst = new List<DB_Talk.Model.m_CallingSource>();
            QueryCallSource(out lst);
            if (lst != null && lst.Count > 0)
            {
                if (lst.Contains(model))
                {
                    List<DB_Talk.Model.m_CallingSource> list = new DB_Talk.BLL.m_CallingSource().GetModelList(
                               string.Format(" i_Flag=0 and ID='{0}' and i_MainType='{1}' and i_SubType='{2}' and BoxID='{3}'",
                               model.ID,model.i_MainType,model.i_SubType,model.BoxID));
                    if (model.BoxID>0 && list.Count == 0)  //box中存在，数据库中不存在的，自动添加到数据库
                    {
                        new DB_Talk.BLL.m_CallingSource().Add(model);
                    }
                    return true;  //存在的不再添加
                }
            }
            MBoxSDK.ConfigSDK.tagCallSource CallSource = new MBoxSDK.ConfigSDK.tagCallSource();
            CallSource.callSourceID = model.ID;
            CallSource.callSourceMainType = model.i_MainType;  //默认6任何类型
            CallSource.callSourceSubType = model.i_SubType;    //1;   //默认任何类型
            // CallSource.callSourceValue =0;
            b = MBoxSDK.ConfigSDK.MBOX_CreateCallSource(Global.Params.BoxHandle, CallSource);
            if(b) new DB_Talk.BLL.m_CallingSource().Add(model);
            return b;

        }
        //删除呼叫源
        private static bool DeleteCallSource(DB_Talk.Model.m_CallingSource model)
        {
            bool b = false;
            MBoxSDK.ConfigSDK.tagCallSource CallSource = new MBoxSDK.ConfigSDK.tagCallSource();
            CallSource.callSourceID = model.ID;
            CallSource.callSourceMainType = model.i_MainType;  //默认6任何类型
            CallSource.callSourceSubType = model.i_SubType;    //1;   //默认任何类型
            b = MBoxSDK.ConfigSDK.MBOX_DeleteCallSource(Global.Params.BoxHandle, CallSource);
            return b;
        }
        //查询呼叫源
        private static bool QueryCallSource(out List<DB_Talk.Model.m_CallingSource> lst)
        {
            bool b = false;
            lst = new List<DB_Talk.Model.m_CallingSource>();
            byte[] byteArray = new byte[ArraySize];
            int len = ArraySize;
            b = MBoxSDK.ConfigSDK.MBOX_GetCallSource(Global.Params.BoxHandle, byteArray, (uint)byteArray.Length, ref len);
            //if (b)
            {
                string str = System.Text.Encoding.Default.GetString(byteArray);
                str = str.Replace("\0", "");
                string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    DB_Talk.Model.m_CallingSource m = new DB_Talk.Model.m_CallingSource();
                    string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    m.ID = (int.Parse(strArray2[0]));
                    m.i_MainType = (int.Parse(strArray2[1]));
                    m.i_SubType = (int.Parse(strArray2[2]));
                    m.BoxID = Global.Params.BoxID;
                    lst.Add(m);
                }
            }
            return b;
        }
        //创建呼叫源规则
        private static bool CreateCallSourceRule(DB_Talk.Model.m_CalinglSourceRule model)
        {
            bool b = false;
            List<DB_Talk.Model.m_CalinglSourceRule> lst = new List<DB_Talk.Model.m_CalinglSourceRule>();
            QueryCallSourceRule(out lst);
            if (lst != null && lst.Count > 0)
            {
                if (lst.Contains(model))
                {
                    List<DB_Talk.Model.m_CalinglSourceRule> listCallingSource = new DB_Talk.BLL.m_CalinglSourceRule().GetModelList(
                         string.Format(" i_Flag=0 and CallingOrigID='{0}' and CalledRuleID='{1}' and i_ServerType='{2}' and OriRouteID='{3}' and BoxID='{4}'",
                         model.CallingOrigID, model.CalledRuleID, model.i_ServerType, model.OriRouteID, model.BoxID));
                    if (listCallingSource.Count==0) new DB_Talk.BLL.m_CalinglSourceRule().Add(model);
                    return true;  //存在的不再添加
                }
            }
            MBoxSDK.ConfigSDK.tagCallSourceRule CallSourceRule = new MBoxSDK.ConfigSDK.tagCallSourceRule();
            CallSourceRule.callSourceIndex = model.CallingOrigID;
            CallSourceRule.seviceType = model.i_ServerType;  //默认1不限
            CallSourceRule.minReceiveNumLength = model.i_MinReLength;  //0;
            b = MBoxSDK.ConfigSDK.MBOX_CreateCallSourceRule(Global.Params.BoxHandle, CallSourceRule);
            if (b) new DB_Talk.BLL.m_CalinglSourceRule().Add(model);
            return b;

        }
        //删除呼叫源规则
        private static bool DeleteCallSourceRule(DB_Talk.Model.m_CalinglSourceRule model)
        {
            bool b = false;
            MBoxSDK.ConfigSDK.tagCallSourceRule CallSourceRule = new MBoxSDK.ConfigSDK.tagCallSourceRule();
            CallSourceRule.callSourceIndex = model.CallingOrigID;
            CallSourceRule.seviceType = model.i_ServerType;  //默认1不限
            CallSourceRule.minReceiveNumLength = model.i_MinReLength;  //0;
            b = MBoxSDK.ConfigSDK.MBOX_DeleteCallSourceRule(Global.Params.BoxHandle, CallSourceRule);
            return b;
        }
        //查询呼叫源规则
        private static bool QueryCallSourceRule(out List<DB_Talk.Model.m_CalinglSourceRule> lst)
        {
            bool b = false;
            lst = new List<DB_Talk.Model.m_CalinglSourceRule>();
            byte[] byteArray = new byte[ArraySize];
            int len = ArraySize;
            b = MBoxSDK.ConfigSDK.MBOX_GetCallSourceRule(Global.Params.BoxHandle, byteArray, (uint)byteArray.Length, ref len);
            //if (b)
            {
                string str = System.Text.Encoding.Default.GetString(byteArray);
                str = str.Replace("\0", "");
                string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    DB_Talk.Model.m_CalinglSourceRule m = new DB_Talk.Model.m_CalinglSourceRule();
                    string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    m.CallingOrigID = (int.Parse(strArray2[0]));
                    m.i_ServerType = (int.Parse(strArray2[1]));
                    m.i_MinReLength = (int.Parse(strArray2[2]));
                    m.BoxID = Global.Params.BoxID;
                    lst.Add(m);
                }
            }
            return b;
        }

        //创建路由规则
        private static bool CreateRoutingRule(DB_Talk.Model.m_RouteRule model)
        {
            bool b = false;
            List<DB_Talk.Model.m_RouteRule> lst = new List<DB_Talk.Model.m_RouteRule>();
            QueryRoutingRule(out lst);
            if (lst != null && lst.Count > 0)
            {
                if (lst.Contains(model))
                {
                    List<DB_Talk.Model.m_RouteRule> listModelRRule = new DB_Talk.BLL.m_RouteRule().GetModelList(
                            string.Format(" i_Flag=0 and ID='{0}' and OriRouteID='{1}' and DestRouteID='{2}' and BoxID='{3}'",
                            model.ID, model.OriRouteID, model.DestRouteID, model.BoxID));
                    if (listModelRRule.Count == 0) new DB_Talk.BLL.m_RouteRule().Add(model);
                    return true;  //存在的不再添加
                }
            }
            MBoxSDK.ConfigSDK.tagRoutingRule RoutingRule = new MBoxSDK.ConfigSDK.tagRoutingRule();
            RoutingRule.sourceRuleSelectIndex = model.OriRouteID;
            RoutingRule.destRuleSelectIndex = model.DestRouteID;
            RoutingRule.routeGroupIndex = model.ID;
            b = MBoxSDK.ConfigSDK.MBOX_CreateRoutingRule(Global.Params.BoxHandle, RoutingRule);
            if (b) new DB_Talk.BLL.m_RouteRule().Add(model);
            return b;

        }
        //删除路由规则
        private static bool DeleteRoutingRule(DB_Talk.Model.m_RouteRule model)
        {
            bool b = false;
            List<DB_Talk.Model.m_RouteRule> lst = new List<DB_Talk.Model.m_RouteRule>();
            QueryRoutingRule(out lst);
            lst=lst.Where(w => w.DestRouteID == model.DestRouteID && w.ID == model.ID).ToList();
            foreach (DB_Talk.Model.m_RouteRule m in lst)
            {
                MBoxSDK.ConfigSDK.tagRoutingRule RoutingRule = new MBoxSDK.ConfigSDK.tagRoutingRule();
                RoutingRule.sourceRuleSelectIndex = m.OriRouteID;
                RoutingRule.destRuleSelectIndex = m.DestRouteID;
                RoutingRule.routeGroupIndex = m.ID;
                b = MBoxSDK.ConfigSDK.MBOX_DeleteRoutingRule(Global.Params.BoxHandle, RoutingRule);
                if (!b)
                    return false;
            }
            return true;
        }
        //查询路由规则
        private static bool QueryRoutingRule(out List<DB_Talk.Model.m_RouteRule> lst)
        {
            bool b = false;
            lst = new List<DB_Talk.Model.m_RouteRule>();
            byte[] byteArray = new byte[ArraySizeBig];
            int len = ArraySizeBig;
            b = MBoxSDK.ConfigSDK.MBOX_GetRoutingRule(Global.Params.BoxHandle, byteArray, (uint)byteArray.Length, ref len);
            //if (b)
            {
                string str = System.Text.Encoding.Default.GetString(byteArray);
                str = str.Replace("\0", "");
                string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    DB_Talk.Model.m_RouteRule m = new DB_Talk.Model.m_RouteRule();
                    string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    m.OriRouteID = (int.Parse(strArray2[0]));
                    m.DestRouteID = (int.Parse(strArray2[1]));
                    m.ID = (int.Parse(strArray2[2]));
                    m.BoxID = Global.Params.BoxID;
                    lst.Add(m);
                }
            }
            return b;
        }

        //创建被叫分析规则
        public static bool CreateCalledRule(DB_Talk.Model.m_CalledRule model)
        {
            bool b = false;
            //if (IsBoxExitCalledRule(model)) return true;
            DeleteCalledRuleByNum(model);
            MBoxSDK.ConfigSDK.tagCalledAnalysisRule CalledAnalysisRule = new MBoxSDK.ConfigSDK.tagCalledAnalysisRule();
            CalledAnalysisRule.ruleID = model.CalledID;
            CalledAnalysisRule.sourceId = model.CallingOriID;
            CalledAnalysisRule.calledNum = new byte[5];
            System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_CalledNumber.ToString().Trim()).CopyTo(CalledAnalysisRule.calledNum, 0);
            CalledAnalysisRule.calledNumDigitsCount = model.vc_CalledNumber.ToString().Trim().Length;
            CalledAnalysisRule.ruleType = model.i_CalledType;        // service=1，入局=3，出局=4
            CalledAnalysisRule.ruleSubType = model.i_CalledSubType;    // 1话务员，56紧急呼叫，SUB=45；TOLL=51
            CalledAnalysisRule.destRouteSelID = model.DestRouteID;  //1
            CalledAnalysisRule.calledNumTransAct = model.i_CalledChangeType; //空值0，插入1，删除2，替换3
            CalledAnalysisRule.calledTransLen = model.i_CalledChangeLength;
            b = MBoxSDK.ConfigSDK.MBOX_CreateCalledNumAnalysisRule(Global.Params.BoxHandle, CalledAnalysisRule);
            return b;

        }
        //删除被叫分析规则
        public static bool DeleteCalledRule(DB_Talk.Model.m_CalledRule model)
        {
            bool b = false;
            //if (!IsBoxExitCalledRule(model)) return true;
            MBoxSDK.ConfigSDK.tagCalledAnalysisRule CalledAnalysisRule = new MBoxSDK.ConfigSDK.tagCalledAnalysisRule();
            CalledAnalysisRule.ruleID = model.CalledID;
            CalledAnalysisRule.sourceId = model.CallingOriID;
            CalledAnalysisRule.calledNum = new byte[5];
            System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_CalledNumber.ToString()).CopyTo(CalledAnalysisRule.calledNum, 0);
            CalledAnalysisRule.calledNumDigitsCount = model.vc_CalledNumber.ToString().Length;
            CalledAnalysisRule.ruleType = model.i_CalledType;        // service=1，入局=3，出局=4
            CalledAnalysisRule.ruleSubType = model.i_CalledSubType;    // 1话务员，56紧急呼叫，SUB=45；TOLL=51
            CalledAnalysisRule.destRouteSelID = model.DestRouteID;  //1
            CalledAnalysisRule.calledNumTransAct = model.i_CalledChangeType; //空值0，插入1，删除2，替换3
            CalledAnalysisRule.calledTransLen = model.i_CalledChangeLength;
            b = MBoxSDK.ConfigSDK.MBOX_DeleteCalledNumAnalysisRule(Global.Params.BoxHandle, CalledAnalysisRule);
            return b;
        }
        
        public static bool DeleteCalledRuleByNum(DB_Talk.Model.m_CalledRule model)
        {
           
            List<DB_Talk.Model.m_CalledRule> lst = new List<DB_Talk.Model.m_CalledRule>();
            QueryCalledRule(out lst);
            lst = lst.Where(w => w.vc_CalledNumber == model.vc_CalledNumber).ToList();
            foreach (DB_Talk.Model.m_CalledRule m in lst)
            {
                if(!DeleteCalledRule(m))
                    return false ;
            }
            return true;

           
        }


        //查询被叫分析规则
        private static bool QueryCalledRule(out List<DB_Talk.Model.m_CalledRule> lst)
        {
            lst = new List<DB_Talk.Model.m_CalledRule>();
            try
            {
                bool b = false;
                byte[] byteArray = new byte[ArraySizeBig];
                int len = ArraySizeBig;
                b = MBoxSDK.ConfigSDK.MBOX_GetCalledNumAnalysisRule(Global.Params.BoxHandle, byteArray, (uint)byteArray.Length, ref len);
                //if (b)
                {
                    string strR = System.Text.Encoding.Default.GetString(byteArray);
                    strR = strR.Replace("\0", "");
                    string[] strArrayS = strR.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < strArrayS.Length; i++)
                    {
                        DB_Talk.Model.m_CalledRule m = new DB_Talk.Model.m_CalledRule();
                        //string[] strArrayS2 = strArrayS[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        string[] strArrayS2 = strArrayS[i].Split(',');  //目标字符串是空的，所有不能去掉空串
                        m.CalledID = (int.Parse(strArrayS2[0]));
                        m.CallingOriID = (int.Parse(strArrayS2[1]));
                        m.vc_CalledNumber = ((strArrayS2[2]));
                        m.i_CalledType = (int.Parse(strArrayS2[3]));
                        m.i_CalledSubType = (int.Parse(strArrayS2[4]));
                        m.DestRouteID = (int.Parse(strArrayS2[5]));
                        m.i_CalledChangeType = (int.Parse(strArrayS2[6]));
                        m.i_CalledChangePosition = (int.Parse(strArrayS2[7]));
                        m.i_CalledChangeLength = (int.Parse(strArrayS2[8]));
                        m.vc_CalledChangeTarget = strArrayS2[9];
                        m.BoxID = Global.Params.BoxID;
                        lst.Add(m);
                    }
                }
                return b;
            }
            catch(Exception ex)
            {
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
                return false;
            }
        }


        private static bool IsBoxExitCalledRule(DB_Talk.Model.m_CalledRule model)
        {
            List<DB_Talk.Model.m_CalledRule> lst = new List<DB_Talk.Model.m_CalledRule>();
            QueryCalledRule(out lst);
            if (lst != null && lst.Count > 0)
            {
                if (lst.Contains(model))
                {
                    return true;  //存在的不再添加
                }
            }
            return false;

        }

        #endregion

        #region 创建呼叫规则
        //创建基础的 呼叫源，路由规则，呼叫源规则,*000的被叫规则
        public static bool CreateCalinglSourceRule()
        {
            
            //创建呼叫源，1，任何类型，任何类型
            DB_Talk.Model.m_CallingSource modelCs = new DB_Talk.Model.m_CallingSource();
            modelCs.ID = 1;
            modelCs.i_MainType = 6;   //任何类型
            modelCs.i_SubType = 1;    //任何类型
            modelCs.BoxID=Global.Params.BoxID;
            List<DB_Talk.Model.m_CallingSource> list = new DB_Talk.BLL.m_CallingSource().GetModelList(
                string.Format(" i_Flag=0 and ID='{0}' and i_MainType='{1}' and i_SubType='{2}' and BoxID='{3}'",
                               modelCs.ID, modelCs.i_MainType, modelCs.i_SubType, modelCs.BoxID));
            if (list.Count == 0) //不存在才创建
            {
                if (!CreateCallSource(modelCs)) 
                    return false;
            }
          

            //创建路由规则0,0,0
            DB_Talk.Model.m_RouteRule modelRRule = new DB_Talk.Model.m_RouteRule();
            modelRRule.ID = 0;
            modelRRule.OriRouteID = 0;
            modelRRule.DestRouteID = 0;
            modelRRule.BoxID = Global.Params.BoxID;
            List<DB_Talk.Model.m_RouteRule> listModelRRule = new DB_Talk.BLL.m_RouteRule().GetModelList(
               string.Format(" i_Flag=0 and ID='{0}' and OriRouteID='{1}' and DestRouteID='{2}' and BoxID='{3}'",
                              modelRRule.ID, modelRRule.OriRouteID, modelRRule.DestRouteID, modelRRule.BoxID));
            if (listModelRRule.Count == 0)
            {
                if (!CreateRoutingRule(modelRRule))
                    return false;
            }
           
            //创建呼叫源规则，1，不限，0,1,0
            DB_Talk.Model.m_CalinglSourceRule CalinglSourceRule = new DB_Talk.Model.m_CalinglSourceRule();
            CalinglSourceRule.CallingOrigID = 1;  //呼叫源索引1
            CalinglSourceRule.i_ServerType = 1;   //服务类型不限
            CalinglSourceRule.i_MinReLength = 0;   //最小收号长度0
            CalinglSourceRule.CalledRuleID = 1;   //被叫分析规则索引1
            CalinglSourceRule.OriRouteID = 0;     //目的路由索引
            CalinglSourceRule.BoxID = Global.Params.BoxID;
            List<DB_Talk.Model.m_CalinglSourceRule> listCallingSource = new DB_Talk.BLL.m_CalinglSourceRule().GetModelList(
              string.Format(" i_Flag=0 and CallingOrigID='{0}' and CalledRuleID='{1}' and i_ServerType='{2}' and OriRouteID='{3}' and BoxID='{4}'",
              CalinglSourceRule.CallingOrigID, CalinglSourceRule.CalledRuleID,CalinglSourceRule.i_ServerType, CalinglSourceRule.OriRouteID, CalinglSourceRule.BoxID));
            if (listCallingSource.Count == 0)
            {
                if (!CreateCallSourceRule(CalinglSourceRule))
                    return false;
            }
           


            //设置默认的被叫规则

            DB_Talk.Model.m_CalledRule CalledRule = new DB_Talk.Model.m_CalledRule();
            CalledRule.BoxID = Global.Params.BoxID;
            CalledRule.CalledID = 1;
            CalledRule.CallingOriID = 1;
            CalledRule.DestRouteID = 0;
            CalledRule.vc_CalledNumber = "*000";
            CalledRule.i_CalledType = MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.SERVICE.GetHashCode();
            CalledRule.i_CalledSubType = MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.话务员.GetHashCode();

            List<DB_Talk.Model.m_CalledRule> listCall = new DB_Talk.BLL.m_CalledRule().GetModelList(
                 string.Format(" i_Flag=0 and vc_CalledNumber='{0}' and BoxID='{1}'",
                        CalledRule.vc_CalledNumber, CalledRule.BoxID));
            if (listCall.Count == 0)
            {
                if (CreateCalledRule(CalledRule))
                    new DB_Talk.BLL.m_CalledRule().Add(CalledRule);
                else
                    return false;
            }
            //默认400的规则

            DB_Talk.Model.m_CalledRule CalledRule400 = new DB_Talk.Model.m_CalledRule();
            CalledRule400.BoxID = Global.Params.BoxID;
            CalledRule400.CalledID = 1;
            CalledRule400.CallingOriID = 1;
            CalledRule400.DestRouteID = 0;
            CalledRule400.vc_CalledNumber = "400";
            CalledRule400.i_CalledType = MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.SERVICE.GetHashCode();
            CalledRule400.i_CalledSubType = MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.FD.GetHashCode();
            CalledRule400.i_CalledChangeType = 2;
            CalledRule400.i_CalledChangeLength = 3;
            List<DB_Talk.Model.m_CalledRule> listCall400 = new DB_Talk.BLL.m_CalledRule().GetModelList(
                 string.Format(" i_Flag=0 and vc_CalledNumber='{0}' and BoxID='{1}'",
                        CalledRule400.vc_CalledNumber, CalledRule400.BoxID));
            if (listCall400.Count == 0)
            {
                if (CreateCalledRule(CalledRule400))
                    new DB_Talk.BLL.m_CalledRule().Add(CalledRule400);
                else
                    return false;
            }  

            return true;
        }
       
        //删除被叫规则
        public static bool Delete_Rule(List<DB_Talk.Model.m_CalledRule> lstCalledRuleAdd,List<DB_Talk.Model.m_CalledRule> lstCalledRuleDelete)
        {
            
            foreach (DB_Talk.Model.m_CalledRule item in lstCalledRuleDelete)
            {
                if (!lstCalledRuleAdd.Contains(item))
                {
                    if (Tools.MBoxOperate.DeleteCalledRuleByNum(item))  //删除旧的规则
                    {
                        new DB_Talk.BLL.m_CalledRule().Delete(
                          string.Format(" i_Flag=0 and vc_CalledNumber='{0}' and BoxID='{1}'",
                          item.vc_CalledNumber, Global.Params.BoxID));
                    }
                    else
                        return false;
                }
            }
            return true;

        }
       
        //入局规则
        public bool CreateCall_InRule(List<DB_Talk.Model.m_CalledRule> lstCalledRuleAdd,out string mes)  
        {
            //创建被叫规则
            mes = "";
            foreach (DB_Talk.Model.m_CalledRule model in lstCalledRuleAdd)
            {
                if (CreateCalledRule(model))
                {
                    new DB_Talk.BLL.m_CalledRule().Add(model);
                }
                else
                {
                    mes = model.vc_CalledNumber.ToString();
                    return false;
                       
                }
            }

            //Delete_Rule(lstCalledRuleAdd, lstCalledRuleDelete);

            return true;
        }

        //入局规则
        public bool CreateCall_InRule1(List<DB_Talk.Model.m_CalledRule> lstCalledRule, List<DB_Talk.Model.m_CalledRule> NewlstCalledRule, out string mes)
        {
            bool b = true;
            StringBuilder sb = new StringBuilder();
            StringBuilder sbExit = new StringBuilder();
            mes = "";
            //b = CreateCalinglSourceRule();
            //创建被叫规则
            List<DB_Talk.Model.m_CalledRule> lst = lstCalledRule;// new List<DB_Talk.Model.m_CalledRule>();
            //QueryCalledRule(out lst);

            foreach (DB_Talk.Model.m_CalledRule model in NewlstCalledRule)
            {
                DB_Talk.Model.m_CalledRule modelTemp = lst.Find(item => item.vc_CalledNumber == model.vc_CalledNumber);
                if (modelTemp != null)
                {
                    if (model.Equals(modelTemp))  //存在完全相同的被叫规则，则什么也不做
                    {
                    }
                    else  //被叫号码相同，但是其他属性不同
                    {
                        sbExit.Append("," + model.vc_CalledNumber.ToString());
                        break;
                    }
                }
                else  //不存在以此号码开头的被叫规则
                {
                    if (CreateCalledRule(model))
                    {
                        new DB_Talk.BLL.m_CalledRule().Add(model);
                    }
                    else
                    {
                        b = false;
                        sb.Append("," + model.vc_CalledNumber.ToString());  //添加失败的
                        break;
                    }
                }

                //if (!lst.Contains(model))
                //{
                //    bool IsSuc= CreateCalledRule(model);
                //    b = b & IsSuc;
                //    if (!IsSuc)
                //    {
                //        sb.Append("," + model.vc_CalledNumber.ToString());  //添加失败的
                //        break;
                //    }
                //}
            }

            if (sb.Length > 0)
            {
                sb.Remove(0, 1);
                mes = sb.ToString();      //添加失败的
            }
            if (sbExit.Length > 0)
            {
                sbExit.Remove(0, 1);
                mes += ";" + sbExit.ToString();  //已经存在的
            }
            return b;
        } 
     
        //出局规则
        public static bool CreateCall_OutRule( DB_Talk.Model.m_CalledRule newmodel)
        {
            if (CreateCalledRule(newmodel))
                if (new DB_Talk.BLL.m_CalledRule().Add(newmodel) > 0)
                    return true;
            return false;
        }
        //出局规则
        public static bool CreateCall_OutRule(DB_Talk.Model.m_CalledRule newmodel, DB_Talk.Model.m_CalledRule oldmodel)
        {
            if (oldmodel == null)   //新增 
            {
                if (CreateCalledRule(newmodel))
                    if ( new DB_Talk.BLL.m_CalledRule().Add(newmodel) > 0)
                        return true;
            }
            else  //修改  先新建后删除
            {
                if (CreateCalledRule(newmodel))
                {
                    new DB_Talk.BLL.m_CalledRule().Add(newmodel);
                    if (DeleteCalledRuleByNum(oldmodel) && new DB_Talk.BLL.m_CalledRule().Delete(oldmodel.ID))
                        return true;
                }
            }
            return false;
        }

        public bool IsExitCalledRule(DB_Talk.Model.m_CalledRule model,out string mes)
        {
            //不能添加被叫号码相同的被叫规则

            bool b = false;
            mes = "";
            DB_Talk.Model.m_CalledRule IsExit = new DB_Talk.BLL.m_CalledRule().GetModel(
              string.Format(" i_Flag=0 and vc_CalledNumber='{0}' and BoxID='{1}'", model.vc_CalledNumber, Global.Params.BoxID));
            if (IsExit!=null)
            {
                if (IsExit.Equals(model))  //存在完全相同的被叫规则，则什么也不做
                {
                    return true;
                }
                else   //被叫号码相同，但是其他属性不同
                {
                    mes = (model.vc_CalledNumber.ToString());
                    return true;
                }
            }
            else       //不存在以此号码开头的被叫规则
            {
                return false;
            }
            
           
        }

        public static string GetCalledNumbers(MBoxSDK.ConfigSDK.CALLED_RULE_TYPE type, string strSIP_PRI_ID)
        {
            StringBuilder sb = new StringBuilder();
            string strW = string.Format("i_Flag=0 and BoxID={0} and i_CalledType='{1}'",
                             Global.Params.BoxID, type.GetHashCode());
            strW += strSIP_PRI_ID;

            List<DB_Talk.Model.m_CalledRule> lstCR = new DB_Talk.BLL.m_CalledRule().GetModelList(strW);
            foreach (DB_Talk.Model.m_CalledRule item in lstCR)
            {
                sb.Append("," + item.vc_CalledNumber);
            }
            if (sb.Length > 0) sb.Remove(0, 1);
            return sb.ToString();

        }
     

        #endregion

        #region 同步数据
        //同步数据库数据
        public static void UpdateDBCalinglSourceRule()
        {
            try
            {
                //同步呼叫源
                List<DB_Talk.Model.m_CallingSource> lstCS = new List<DB_Talk.Model.m_CallingSource>();
                QueryCallSource(out lstCS);
                new DB_Talk.BLL.m_CallingSource().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
                foreach (DB_Talk.Model.m_CallingSource m in lstCS)
                {
                    new DB_Talk.BLL.m_CallingSource().Add(m);
                }

                //同步呼叫源规则
                List<DB_Talk.Model.m_CalinglSourceRule> lstCSR = new List<DB_Talk.Model.m_CalinglSourceRule>();
                QueryCallSourceRule(out lstCSR);
                new DB_Talk.BLL.m_CalinglSourceRule().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
                foreach (DB_Talk.Model.m_CalinglSourceRule m in lstCSR)
                {
                    new DB_Talk.BLL.m_CalinglSourceRule().Add(m);
                }
                //同步路由规则
                List<DB_Talk.Model.m_RouteRule> lstRR = new List<DB_Talk.Model.m_RouteRule>();
                QueryRoutingRule(out lstRR);
                new DB_Talk.BLL.m_RouteRule().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
                foreach (DB_Talk.Model.m_RouteRule m in lstRR)
                {
                    new DB_Talk.BLL.m_RouteRule().Add(m);
                }
                UpdateDB_CallRule();
            }
            catch(Exception ex)
            {
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
            }

        }
        //同步被叫规则
        public static void UpdateDB_CallRule()
        {
            List<DB_Talk.Model.m_CalledRule> lstCR = new List<DB_Talk.Model.m_CalledRule>();
            QueryCalledRule(out lstCR);
            if (lstCR.Count == 0) new DB_Talk.BLL.m_CalledRule().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
            StringBuilder sb = new StringBuilder();
            foreach (DB_Talk.Model.m_CalledRule m in lstCR)
            {
                //if(m.vc_CalledNumber=="*000") continue;
                sb.Append(",'" + m.vc_CalledNumber + "'");
                DB_Talk.Model.m_CalledRule callm = new DB_Talk.BLL.m_CalledRule().GetModel(
                             string.Format("i_Flag=0 and BoxID={0} and vc_CalledNumber='{1}'", Global.Params.BoxID, m.vc_CalledNumber));
                if (callm != null)
                {
                    m.i_SIPID = callm.i_SIPID;
                    m.i_PRIID = callm.i_PRIID;
                    new DB_Talk.BLL.m_CalledRule().Delete(string.Format("i_Flag=0 and BoxID={0} and vc_CalledNumber='{1}'", Global.Params.BoxID, m.vc_CalledNumber));

                    new DB_Talk.BLL.m_CalledRule().Add(m);
                }
                else
                    DeleteCalledRuleByNum(m);  //删除box中 数据库中不存在的呼叫规则
            }
            //删除数据库中多余的
            if (sb.Length > 0)
            {
                sb.Remove(0, 1);
                new DB_Talk.BLL.m_CalledRule().Delete(
                    string.Format("i_Flag=0 and BoxID={0} and vc_CalledNumber not in({1})",
                    Global.Params.BoxID, sb.ToString()));
            }
        }
        //同步数据库数据 PRI SIP中继
        public static void UpdateDBSIPPRI()
        {
            try
            {
                //CommControl.Tools.WriteLog.AppendLog("同步SipPri ，boxID：" + Global.Params.BoxID.ToString());
                //同步路由组信息
                List<DB_Talk.Model.m_RouteGroup> lstRGroup = new List<DB_Talk.Model.m_RouteGroup>();
                QueryRouteGroup(out lstRGroup);
                new DB_Talk.BLL.m_RouteGroup().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
                foreach (DB_Talk.Model.m_RouteGroup m in lstRGroup)
                {
                    new DB_Talk.BLL.m_RouteGroup().Add(m);
                }
                //同步路由
                List<DB_Talk.Model.m_Route> lstRoute = new List<DB_Talk.Model.m_Route>();
                QueryRoute(out lstRoute);
                new DB_Talk.BLL.m_Route().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
                foreach (DB_Talk.Model.m_Route m in lstRoute)
                {
                    new DB_Talk.BLL.m_Route().Add(m);
                }

                //同步SAP接入点
                List<DB_Talk.Model.m_SAPPoint> lstSAPPoint = new List<DB_Talk.Model.m_SAPPoint>();
                GetSipSap(out lstSAPPoint);
                new DB_Talk.BLL.m_SAPPoint().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
                foreach (DB_Talk.Model.m_SAPPoint m in lstSAPPoint)
                {
                    new DB_Talk.BLL.m_SAPPoint().Add(m);
                }

                //同步被叫规则
                UpdateDB_CallRule();

                //同步SIP中继
                List<DB_Talk.Model.m_SIPInterface> lstSIPInterface = new List<DB_Talk.Model.m_SIPInterface>();
                GetSipTrunk(out lstSIPInterface);
                if (lstSIPInterface.Count == 0)
                    new DB_Talk.BLL.m_SIPInterface().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));


                foreach (DB_Talk.Model.m_SIPInterface m in lstSIPInterface)
                {
                    //m.vc_OutNumber = getCalledNumbers(MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.出局, " and i_SIPID='" + m.SIPID + "'");
                    DB_Talk.Model.m_SIPInterface sip = new DB_Talk.BLL.m_SIPInterface().GetModel(
                                  string.Format("i_Flag=0 and BoxID={0} and SIPID='{1}'", Global.Params.BoxID, m.SIPID));
                    if (sip != null)
                    {
                        m.vc_OutNumber = sip.vc_OutNumber;
                        m.vc_OutNumberLocal = sip.vc_OutNumberLocal;
                        m.i_Port = sip.i_Port;
                      //  m.i_OperateState = sip.i_OperateState;
                     //   m.i_State = sip.i_State;

                        new DB_Talk.BLL.m_SIPInterface().Delete(string.Format("i_Flag=0 and BoxID={0} and SIPID='{1}'", Global.Params.BoxID, m.SIPID));
                        new DB_Talk.BLL.m_SIPInterface().Add(m);
                    }
                    else
                        DeleteSIP(m);
                }
                /*
                //同步承载信道
                List<DB_Talk.Model.m_PRIChannel> lstPRIChannel = new List<DB_Talk.Model.m_PRIChannel>();
                GetT1Channels(out lstPRIChannel);
                new DB_Talk.BLL.m_SAPPoint().Delete("");
                foreach (DB_Talk.Model.m_PRIChannel m in lstPRIChannel)
                {
                    new DB_Talk.BLL.m_PRIChannel().Add(m);
                }

                //同步信令信道
                List<DB_Talk.Model.m_PRISigLink> lstPRISigLink = new List<DB_Talk.Model.m_PRISigLink>();
                GetSigChannel(out lstPRISigLink);
                new DB_Talk.BLL.m_PRISigLink().Delete("");
                foreach (DB_Talk.Model.m_PRISigLink m in lstPRISigLink)
                {
                    new DB_Talk.BLL.m_PRISigLink().Add(m);
                }
                */
                //同步PRI中继
                List<DB_Talk.Model.m_PRIInterface> lstPRIInterface = new List<DB_Talk.Model.m_PRIInterface>();
                GetPriTrunk(out lstPRIInterface);
                if (lstPRIInterface.Count == 0)
                    new DB_Talk.BLL.m_PRIInterface().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
                foreach (DB_Talk.Model.m_PRIInterface m in lstPRIInterface)
                {
                    //m.vc_OutNumber = getCalledNumbers(MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.出局, " and i_SIPID='" + m.SIPID + "'");
                    DB_Talk.Model.m_PRIInterface pri = new DB_Talk.BLL.m_PRIInterface().GetModel(
                                  string.Format("i_Flag=0 and BoxID={0} and PRIID='{1}'", Global.Params.BoxID, m.PRIID));
                    if (pri != null)
                    {
                        m.vc_OutNumber = pri.vc_OutNumber;
                        m.vc_OutNumberLocal = pri.vc_OutNumberLocal;
                        m.i_E1Port = pri.i_E1Port;
                        m.i_LinkID = pri.i_LinkID;
                        m.i_UNIType = pri.i_UNIType;
                      //  m.i_Operate = pri.i_Operate;
                      //  m.i_State = pri.i_State;
                        new DB_Talk.BLL.m_PRIInterface().Delete(string.Format("i_Flag=0 and BoxID={0} and PRIID='{1}'", Global.Params.BoxID, m.PRIID));
                        new DB_Talk.BLL.m_PRIInterface().Add(m);
                    }
                    else
                        DeletePRI(m);
                }

            }
            catch (Exception ex)
            {
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
            }
            

        }
        #endregion

        #region SIP中继接口

        //增加SAP接入点
        private static bool CreateSipSap(DB_Talk.Model.m_SAPPoint model)
        {
            bool b = false;
            if (IsBoxExitSAP(model)) return true;
            MBoxSDK.ConfigSDK.tagSipSap SipSap = new MBoxSDK.ConfigSDK.tagSipSap();
            SipSap.sipSapID = model.SAPID;
            SipSap.sipSapPort = model.i_Port;                 //默认5061
            SipSap.netProtocal = model.i_Type;                //udp:1,tcp:2
            b = MBoxSDK.ConfigSDK.MBOX_CreateSipSap(Global.Params.BoxHandle, SipSap);
            //if(model.i_Port==5060) 
            Global.Params.IsRestart=true;
            return b;
           
        }
        //删除SAP接入点
        private static bool DeleteSipSap(DB_Talk.Model.m_SAPPoint model)
        {
            if (!IsBoxExitSAP(model)) return true;
            MBoxSDK.ConfigSDK.tagSipSap SipSap = new MBoxSDK.ConfigSDK.tagSipSap();
            SipSap.sipSapID = model.SAPID;
            SipSap.sipSapPort = model.i_Port;                 //默认5061
            SipSap.netProtocal = model.i_Type;                //udp:1,tcp:2
            bool b = MBoxSDK.ConfigSDK.MBOX_DeleteSipSap(Global.Params.BoxHandle, SipSap);
            return b;
        }
        //获取SAP接入点
        private static bool GetSipSap(out List<DB_Talk.Model.m_SAPPoint> lst)
        {
            byte[] byteArray = new byte[ArraySizeBig];
            int len = 0;
            bool b = MBoxSDK.ConfigSDK.MBOX_GetSipSap(Global.Params.BoxHandle, byteArray, (uint)byteArray.Length, ref len);
            lst = new List<DB_Talk.Model.m_SAPPoint>();
            if (b)
            {
                string str = System.Text.Encoding.Default.GetString(byteArray);
                str = str.Replace("\0", "");
                string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    DB_Talk.Model.m_SAPPoint m = new DB_Talk.Model.m_SAPPoint();
                    string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    m.SAPID = int.Parse(strArray2[0]);
                    m.i_Port = int.Parse(strArray2[1]);
                    m.i_Type = int.Parse(strArray2[2]);
                    m.BoxID = Global.Params.BoxID;
                    lst.Add(m);
                }
            }
            return b;  
        }

        private static bool IsBoxExitSAP(DB_Talk.Model.m_SAPPoint model)
        {
            List<DB_Talk.Model.m_SAPPoint> lst = new List<DB_Talk.Model.m_SAPPoint>();
            GetSipSap(out lst);
            if (lst != null && lst.Count > 0)
            {
                DB_Talk.Model.m_SAPPoint temp = lst.Find(item => item.SAPID == model.SAPID);
                if (temp != null && temp.i_Port != model.i_Port) //存在所有相同的但是port不同的SAP接入点
                {
                    if (!DeleteSipSap(temp))
                    {
                        return true;
                    }
                }
                else if (temp != null && temp.i_Port == model.i_Port)
                {
                    return true;  //存在的不再添加
                }
            }
            return false;
        }

        //增加SIP中继接口
        private static bool CreateSipTrunk(DB_Talk.Model.m_SIPInterface model)
        {
            bool b = false;
            if (IsBoxExitSIP(model)) return true;  //存在不再添加
            MBoxSDK.ConfigSDK.tagSipTrunk SipTrunk = new MBoxSDK.ConfigSDK.tagSipTrunk();
            SipTrunk.trunkID = model.SIPID;
            SipTrunk.trunkInterfaceType = model.i_Type;         //接口类型,内部(1),外部(2)，默认外部
            SipTrunk.trunkRoutingID = model.RouteID;             //路由ID
            SipTrunk.trunkPriority = model.i_Level;              //优先级,主(1),从(2)，默认主
            SipTrunk.trunkSipSapID = model.SAPID;              //SIP接入点ID
            SipTrunk.trunkMaxChannel = model.i_MaxChannel;            //最大通道(1~128)
            SipTrunk.trunkPlayTone = model.i_PlaySound;              //是否放音,是(1),否(2),默认1
            SipTrunk.peerIpAddress = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_OppositeIP).CopyTo(SipTrunk.peerIpAddress, 0);  //对端IP地址       
            SipTrunk.peerPort = model.i_OppositePort;                  //对端端口号
            //SipTrunk.configureStatus = 0;           //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
            //SipTrunk.operationStatus = 1;           //up(2) down(1)
            //SipTrunk.heartBeatSupport = 1;          //yes(1) no(0)
            b = MBoxSDK.ConfigSDK.MBOX_CreateSipTrunk(Global.Params.BoxHandle, ref SipTrunk);
            return b;

        }
        //删除SIP中继接口
        private static bool DeleteSipTrunk(DB_Talk.Model.m_SIPInterface model)
        {
            //if (!IsBoxExitSIP(model)) return true;  //不存在是不再删除
            MBoxSDK.ConfigSDK.tagSipTrunk SipTrunk = new MBoxSDK.ConfigSDK.tagSipTrunk();
            SipTrunk.trunkID = model.SIPID;
            SipTrunk.trunkInterfaceType = model.i_Type;         //接口类型,内部(1),外部(2)，默认外部
            SipTrunk.trunkRoutingID = model.RouteID;             //路由ID
            SipTrunk.trunkPriority = model.i_Level;              //优先级,主(1),从(2)，默认主
            SipTrunk.trunkSipSapID = model.SAPID;              //SIP接入点ID
            SipTrunk.trunkMaxChannel = model.i_MaxChannel;            //最大通道(1~128)
            SipTrunk.trunkPlayTone = model.i_PlaySound;              //是否放音,是(1),否(2),默认1
            SipTrunk.peerIpAddress = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_OppositeIP).CopyTo(SipTrunk.peerIpAddress, 0);  //对端IP地址       
            SipTrunk.peerPort = model.i_OppositePort;                  //对端端口号
            //SipTrunk.configureStatus = 0;           //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
            //SipTrunk.operationStatus = 1;           //up(2) down(1)
            //SipTrunk.heartBeatSupport = 0;          //yes(1) no(0)
            bool b = MBoxSDK.ConfigSDK.MBOX_DeleteSipTrunk(Global.Params.BoxHandle, SipTrunk);
            return b;
        }

        //删除SIP中继接口
        private static bool DeleteSipTrunkByID(DB_Talk.Model.m_SIPInterface model)
        {
            List<DB_Talk.Model.m_SIPInterface> lst = new List<DB_Talk.Model.m_SIPInterface>();
            GetSipTrunk(out lst);
            if (lst != null && lst.Count > 0)
            {
                lst = lst.Where(w => w.SIPID == model.SIPID).ToList();
                foreach (DB_Talk.Model.m_SIPInterface m in lst)
                {
                    bool b = DeleteSipTrunk(m);
                    if (!b)
                        return false;
                }
            }
            return true;

        }

        //获取SIP中继接口
        public static bool GetSipTrunk(out List<DB_Talk.Model.m_SIPInterface> lst)
        {
            byte[] byteArray = new byte[ArraySizeBig];
            int len = 0;
            bool b = MBoxSDK.ConfigSDK.MBOX_GetSipTrunk(Global.Params.BoxHandle, byteArray, (uint)byteArray.Length, ref len);
            lst = new List<DB_Talk.Model.m_SIPInterface>();
            if (b)
            {
                //List<DB_Talk.Model.m_SAPPoint> lstSAPPoint = new List<DB_Talk.Model.m_SAPPoint>();
                //GetSipSap(out lstSAPPoint);

                string str = System.Text.Encoding.Default.GetString(byteArray);
                str = str.Replace("\0", "");
                string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    DB_Talk.Model.m_SIPInterface m = new DB_Talk.Model.m_SIPInterface();
                    string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    m.SIPID = int.Parse(strArray2[0]);
                    m.i_Type = int.Parse(strArray2[1]);
                    m.RouteID = int.Parse(strArray2[2]);
                    m.i_Level = int.Parse(strArray2[3]);
                    m.i_MaxChannel = int.Parse(strArray2[4]);
                    m.SAPID = int.Parse(strArray2[5]);
                    m.i_PlaySound = int.Parse(strArray2[6]);
                    m.i_OppositePort = int.Parse(strArray2[7]);
                    m.i_State = int.Parse(strArray2[8]);
                    m.i_OperateState = int.Parse(strArray2[9]);
                    m.vc_OppositeIP =(strArray2[10]);
                    m.BoxID = Global.Params.BoxID;
                   
                    //DB_Talk.Model.m_SIPInterface sip = new DB_Talk.BLL.m_SIPInterface().GetModel(
                    //              string.Format("i_Flag=0 and BoxID={0} and SIPID='{1}'", Global.Params.BoxID, m.SIPID));
                    //if (sip != null)
                    //{
                    //    m.vc_OutNumber = sip.vc_OutNumber;
                    //    m.i_Port = sip.i_Port;
                    //    lst.Add(m);
                    //}
                    //else
                    //    DeleteSIP(m);
                    lst.Add(m);
                }
            }
            return b;
        }

        private static bool IsBoxExitSIP(DB_Talk.Model.m_SIPInterface model)
        {
            List<DB_Talk.Model.m_SIPInterface> lst = new List<DB_Talk.Model.m_SIPInterface>();
            GetSipTrunk(out lst);
            if (lst != null && lst.Count > 0)
            {
                if (lst.Contains(model))
                {
                    return true;  //存在的不再
                }
            }
            return false;
        }
        //激活SIP中继接口
        private static bool SetSipTrunkActive(DB_Talk.Model.m_SIPInterface model)
        {
           bool b = false;
           List<DB_Talk.Model.m_SIPInterface> lst = new List<DB_Talk.Model.m_SIPInterface>();
           GetSipTrunk(out lst);
           if (lst != null && lst.Count > 0)
           {
               DB_Talk.Model.m_SIPInterface temp = lst.Find(item => item.SIPID == model.SIPID);
               if (temp != null) //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
               {
                   if (temp.i_State == 2) //2激活状态
                   {
                       return true;//已经激活的不再激活
                   }
               }
               b = MBoxSDK.ConfigSDK.MBOX_SetSipTrunkAction(Global.Params.BoxHandle, model.SIPID, 1); //表示激活(1)或去激活(2)
           }
           else
               return true;
            //b = MBoxSDK.ConfigSDK.MBOX_SetSipTrunkAction(Global.Params.BoxHandle, model.SIPID, 1); //表示激活(1)或去激活(2)
            return b;
        }
        //去激活SIP中继接口
        private static bool SetSipTrunkDective(DB_Talk.Model.m_SIPInterface model)
        {
            bool b = false;
            List<DB_Talk.Model.m_SIPInterface> lst = new List<DB_Talk.Model.m_SIPInterface>();
            GetSipTrunk(out lst);
            if (lst != null && lst.Count > 0)
            {
                DB_Talk.Model.m_SIPInterface temp = lst.Find(item => item.SIPID == model.SIPID);
                if (temp != null) //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
                {
                    if (temp.i_State != 2)
                    {
                        return true;//已经去激活的不再去激活
                    }
                }
                else
                    return true;
                b = MBoxSDK.ConfigSDK.MBOX_SetSipTrunkAction(Global.Params.BoxHandle, model.SIPID, 2); //表示激活(1)或去激活(2)
            }
            else
                return true;
            //b = MBoxSDK.ConfigSDK.MBOX_SetSipTrunkAction(Global.Params.BoxHandle, model.SIPID, 2); //表示激活(1)或去激活(2)
            return b;
        }

        public static bool CreateSIP(DB_Talk.Model.m_SIPInterface newmodel, DB_Talk.Model.m_SIPInterface oldmodel, List<DB_Talk.Model.m_CalledRule> lstRuleAdd, List<DB_Talk.Model.m_CalledRule> lstRuleDelete)
        {
            if (oldmodel == null)   //新增 
            {
                if (createSIP(newmodel,lstRuleAdd,lstRuleDelete))
                    if(new DB_Talk.BLL.m_SIPInterface().Add(newmodel)>0) 
                        return true;
            }
            else  //修改
            {
                if (oldmodel.SIPID == newmodel.SIPID)//索引相同的，修改时先删除 再新建
                {
                    if (DeleteSIP(oldmodel, lstRuleAdd, lstRuleDelete) && new DB_Talk.BLL.m_SIPInterface().Delete(oldmodel.ID))
                        if (createSIP(newmodel, lstRuleAdd, lstRuleDelete))
                            if (new DB_Talk.BLL.m_SIPInterface().Add(newmodel) > 0) 
                                return true;
                }
                else
                {
                    if (createSIP(newmodel, lstRuleAdd, lstRuleDelete))//索引不同时，先新建后删除
                      if (new DB_Talk.BLL.m_SIPInterface().Add(newmodel) > 0)
                          if (DeleteSIP(oldmodel, lstRuleAdd, lstRuleDelete) && new DB_Talk.BLL.m_SIPInterface().Delete(oldmodel.ID))
                            return true;
                }
            }
            return false;

        }

        private static bool createSIP(DB_Talk.Model.m_SIPInterface newmodel, List<DB_Talk.Model.m_CalledRule> lstRuleAdd, List<DB_Talk.Model.m_CalledRule> lstRuleDelete)
        {
            //创建路由组
            DB_Talk.Model.m_RouteGroup mRg = new DB_Talk.Model.m_RouteGroup();
            mRg.vc_Name = "SIP" + newmodel.SIPID.ToString();
            int routeGroupID = 0;
            if (!CreateRouteGroup(mRg, out routeGroupID))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("添加路由组失败");
                return false;
            }
            newmodel.RouteID = routeGroupID;
            //创建路由
            DB_Talk.Model.m_Route mR = new DB_Talk.Model.m_Route();
            mR.ID = routeGroupID;
            mR.RouteGroupID = routeGroupID;
            mR.vc_Name = "SIP" + newmodel.SIPID.ToString();
            mR.i_RouteType = MBoxSDK.ConfigSDK.EnumRouteType.btw.GetHashCode();
            if (!CreateRoute(mR))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("添加路由失败");
                return false;
            }

            //创建路由规则0,PRIID,PRIID
            DB_Talk.Model.m_RouteRule modelRRule = new DB_Talk.Model.m_RouteRule();
            modelRRule.OriRouteID = 0;
            modelRRule.DestRouteID = newmodel.RouteID;
            modelRRule.ID = newmodel.RouteID;
            modelRRule.BoxID = Global.Params.BoxID;
            if (!CreateRoutingRule(modelRRule))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("添加路由规则失败");
                return false;
            }
            
            //创建SAP接入点
            DB_Talk.Model.m_SAPPoint msap = new DB_Talk.Model.m_SAPPoint();
            msap.SAPID = newmodel.SIPID +1;
            msap.i_Port = newmodel.i_Port;
            msap.i_Type = 1;   //默认1=udp
            if (!CreateSipSap(msap))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("添加SAP失败");
                return false;
            }
            //创建SIP
            if (!CreateSipTrunk(newmodel))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("添加SIP失败");
                return false;
            }
            //激活SIP
            if (!SetSipTrunkActive(newmodel))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("激活SIP失败");
                return false;
            }

            //添加被叫规则
            foreach (DB_Talk.Model.m_CalledRule d in lstRuleAdd)
            {
                d.DestRouteID = routeGroupID;
                if (!CreateCall_OutRule(d))
                {
                    CommControl.Tools.WriteLog.AppendErrorLog("添加被叫规则失败，被叫号码为：" + d.vc_CalledNumber);
                    DeleteSIP(newmodel);
                    return false;
                }
            }
            if (!Delete_Rule(lstRuleAdd, lstRuleDelete))
                return false;

            return true;

        }
      
        public static bool DeleteSIP(DB_Talk.Model.m_SIPInterface model, List<DB_Talk.Model.m_CalledRule> lstRuleAdd, List<DB_Talk.Model.m_CalledRule> lstRuleDelete)
        {
            if (!DeleteSIP(model))
                return false;
            //删除被叫规则
            if (!Delete_Rule(lstRuleAdd, lstRuleDelete))
                return false;
            return true;
        }
       
        public static bool DeleteSIP(DB_Talk.Model.m_SIPInterface model)
        {
            //去激活SIP
            if (!SetSipTrunkDective(model))
                return false;

            //删除SIP
            if (!DeleteSipTrunkByID(model))
                return false;

            //删除SAP接入点
            DB_Talk.Model.m_SAPPoint msap = new DB_Talk.Model.m_SAPPoint();
            msap.SAPID = model.SIPID + 1;
            msap.i_Port = model.i_Port;
            msap.i_Type = 1;   //默认1=udp
            if (!DeleteSipSap(msap))
                return false;

            //删除路由规则0,PRIID,PRIID
            DB_Talk.Model.m_RouteRule modelRRule = new DB_Talk.Model.m_RouteRule();
            modelRRule.OriRouteID = 0;
            modelRRule.DestRouteID = model.RouteID;
            modelRRule.ID = model.RouteID;
            modelRRule.BoxID = Global.Params.BoxID;
            if (!DeleteRoutingRule(modelRRule))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("删除路由规则失败");
                return false;
            }

            //删除路由
            DB_Talk.Model.m_Route mR = new DB_Talk.Model.m_Route();
            mR.ID = model.RouteID;
            mR.vc_Name = "SIP" + model.SIPID.ToString();
            mR.RouteGroupID = model.RouteID;
            mR.i_RouteType = 1; //1: btw(1)双向（默认）
            if (!DeleteRoute(mR))
                return false;

            //删除路由组
            DB_Talk.Model.m_RouteGroup mRg = new DB_Talk.Model.m_RouteGroup();
            mRg.vc_Name = "SIP" + model.SIPID.ToString();
            mRg.ID = model.RouteID;
            if (!DeleteRouteGroup(mRg))
            {
                return false;
            }

            return true;

        }

     

   #endregion

        #region 短信

        /// <summary>创建SMS</summary>
        /// <returns></returns>
        public static bool CreateSMS(DB_Talk.Model.SMSConfig smsModel)
        {
            bool b = false;
            #region 路由组
            
            
            DB_Talk.Model.m_RouteGroup group = new DB_Talk.Model.m_RouteGroup();
            group.vc_Name = "SMS";
            int groupID = 0;

            if (CreateRouteGroup(group, out groupID) == false) return false ;
            #endregion

            #region 路由
            
            
            DB_Talk.Model.m_Route route = new DB_Talk.Model.m_Route();
            route.RouteGroupID = groupID;
            route.ID = groupID;
            route.i_RouteType = MBoxSDK.ConfigSDK.EnumRouteType.esme.GetHashCode();
            route.vc_Name = "SMS";

            if (CreateRoute(route) == false) return false;

            #endregion

            if (DeleteAllSMSConfig() == false) return false;
            if (CreateSMSEntry(route.ID, smsModel.SystemID, smsModel.Password) == false) return false;
            if (CreateSMSIP(smsModel.IP) == false) return false;
            return true;
        }

        /// <summary>
        /// 清空有关短信的配置
        /// </summary>
        /// <returns></returns>
        private static bool DeleteAllSMSConfig()
        {
            bool b = false;
            List<DB_Talk.Model.SMSConfig> lst = GetSMSEntry();
            foreach (DB_Talk.Model.SMSConfig item in lst)
            {
                MBoxSDK.ConfigSDK.tagShortMessageEntity enty = new MBoxSDK.ConfigSDK.tagShortMessageEntity();
                enty.esmeId = item.EmseID;
                enty.esmeRouteId = item.RouteID;
                enty.esmeSystemId = item.SystemID.ToString();
                enty.esmePassword = item.Password;

                if (MBoxSDK.ConfigSDK.MBOX_DeleteShortMessageEntity(Global.Params.BoxHandle, enty) == false) {
                    return false;
                }
            }

            List<string> lstS = GetSMSIP();
            foreach (string item in lstS)
            {
                if (MBoxSDK.ConfigSDK.MBOX_RemoveEsmeTerminate(Global.Params.BoxHandle, item)==false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>得到短信配置信息</summary>
        /// <returns></returns>
        public static DB_Talk.Model.SMSConfig GetSMSConfig()
        {
            DB_Talk.Model.SMSConfig model = new DB_Talk.Model.SMSConfig();
            List<string> lstS = new List<string>();
            lstS = GetSMSIP();
            if (lstS.Count>0)
            {
                model.IP = lstS[0];    
            }
            
            List<DB_Talk.Model.SMSConfig> lst = GetSMSEntry();
            if (lst.Count > 0)
            {
                model.SystemID = lst[0].SystemID;
                model.Password = lst[0].Password;
            }

            return model;
        }

        /// <summary>创建消息实体</summary>
        /// <param name="model"></param>
        /// <param name="RouteGroupID"></param>
        /// <returns></returns>
        private static bool CreateSMSEntry(int routeID,int systemID,string sytemPass)
        {
            bool b = false;
            //MBoxSDK.ConfigSDK.MBOX_GetShortMessageEntity();

            MBoxSDK.ConfigSDK.tagShortMessageEntity enty=new MBoxSDK.ConfigSDK.tagShortMessageEntity();
            enty.esmeId=1;
            enty.esmeRouteId = routeID;
            enty.esmeSystemId = systemID.ToString();
            enty.esmePassword = sytemPass;
            b= MBoxSDK.ConfigSDK.MBOX_CreateShortMessageEntity(Global.Params.BoxHandle, enty);
            return b;
        }

        /// <summary>创建SMS调度机IP</summary>
        /// <returns></returns>
        private static bool CreateSMSIP(string IP)
        {
            bool b = false;
            b = MBoxSDK.ConfigSDK.MBOX_AddEsmeTerminate(Global.Params.BoxHandle,IP);
            return b;
        }

        /// <summary>
        /// 返回所有消息实体
        /// </summary>
        /// <returns></returns>
        private static List<DB_Talk.Model.SMSConfig> GetSMSEntry()
        {
            List<DB_Talk.Model.SMSConfig> lst = new List<DB_Talk.Model.SMSConfig>();

            byte[] bytearray = new byte[1024];
            uint len =(uint) bytearray.Length;
            int tt = 0;
            bool b = MBoxSDK.ConfigSDK.MBOX_GetShortMessageEntity(Global.Params.BoxHandle, bytearray, len, ref tt);
            string strIP = System.Text.Encoding.Default.GetString(bytearray).Replace("\0", "");

            string[] ss = strIP.Split(';');
            foreach (string item in ss)
            {
                string[] pp = item.Split(',');
                if (pp.Length==4)
                {
                    DB_Talk.Model.SMSConfig model = new DB_Talk.Model.SMSConfig();
                    model.SystemID =int.Parse(pp[0]);
                    model.Password = pp[1];
                    model.EmseID =int.Parse( pp[2]);
                    model.RouteID =int.Parse( pp[3]);
                    lst.Add(model);
                }
            }
            return lst;
        }

        /// <summary>查询短信调度IP</summary>
        /// <returns></returns>
        private static List<string> GetSMSIP()
        {
            List<string> lst = new List<string>();
            byte[] bytearray = new byte[1024];
            int len = bytearray.Length;
            bool b = MBoxSDK.ConfigSDK.MBOX_GetEsmeTerminate(Global.Params.BoxHandle, bytearray, len);
            string strIP = System.Text.Encoding.Default.GetString(bytearray).Replace("\0", "");

            string[] ss = strIP.Split(';');
            foreach (string item in ss)
            {
                if (item.Length>5)
                {
                    lst.Add(item);
                }
            }
            return lst;
        }
        #endregion

        #region  PRI中继接口

        //增加PRI承载信道
        private static bool CreateT1Channel(DB_Talk.Model.m_PRIChannel model)
        {
            bool b = false;
            for (int i = 1; i <= 31; i++)
            {
                if (i == 16) continue;
                MBoxSDK.ConfigSDK.tagT1 tagT1 = new MBoxSDK.ConfigSDK.tagT1();
                tagT1.priID = model.PRIID;                      //中继号
                tagT1.machineID = 1;                  //机身号，必须是1
                tagT1.slotID = 3;                     //槽位号,必须是3
                tagT1.e1Port = model.i_E1Port;                     //E1口,从1开始
                tagT1.linkID = model.i_LinkID;                     //链接ID，如果与对端的E1口的某条link进行通信，需要把linkID设置成和对端同样的ID
                //tagT1.channelType = 1;                //1: bothway(1)	2: outgoing(2) 3: incoming(3)
                //tagT1.configureStatus = 1;
                //tagT1.operationStatus = 1;
                tagT1.E1bundle = i;                   //表示第几个信道，第16个信道不作为承载信道
                b= MBoxSDK.ConfigSDK.MBOX_CreateT1Channel(Global.Params.BoxHandle, tagT1);
                if (!b) return false;
            }
            return true;

        }
        //删除PRI承载信道
        private static bool DeleteT1Channel(int PRIID)
        {
            bool b = false;
            List<DB_Talk.Model.m_PRIChannel> lst = new List<DB_Talk.Model.m_PRIChannel>();
            GetT1Channels(out lst);
            lst = lst.Where(w => w.PRIID == PRIID).ToList();

            if (lst != null && lst.Count > 0)
            {
                foreach (DB_Talk.Model.m_PRIChannel m in lst)
                {
                    MBoxSDK.ConfigSDK.tagT1 tagT1 = new MBoxSDK.ConfigSDK.tagT1();
                    tagT1.priID = m.PRIID;            //中继号
                    tagT1.machineID = 1;                  //机身号，必须是1
                    tagT1.slotID = 3;                     //槽位号,必须是3
                    tagT1.e1Port = m.i_E1Port;        //E1口,从1开始
                    tagT1.linkID = m.i_LinkID;        //链接ID，如果与对端的E1口的某条link进行通信，需要把linkID设置成和对端同样的ID
                    //tagT1.channelType = 1;                //1: bothway(1)	2: outgoing(2) 3: incoming(3)
                    //tagT1.configureStatus = 1;
                    //tagT1.operationStatus = 1;
                    tagT1.E1bundle = m.i_ChannelNumber;                   //表示第几个信道，第16个信道不作为承载信道
                    b = MBoxSDK.ConfigSDK.MBOX_DeleteT1Channel(Global.Params.BoxHandle, tagT1);
                    if (!b) return false;
                }
            }
            return true;
            //for (int i = 1; i <= 31; i++)
            //{
            //    if (i == 16) continue;
            //    MBoxSDK.ConfigSDK.tagT1 tagT1 = new MBoxSDK.ConfigSDK.tagT1();
            //    tagT1.priID = model.PRIID;            //中继号
            //    tagT1.machineID = 1;                  //机身号，必须是1
            //    tagT1.slotID = 3;                     //槽位号,必须是3
            //    tagT1.e1Port = model.i_E1Port;        //E1口,从1开始
            //    tagT1.linkID = model.i_LinkID;        //链接ID，如果与对端的E1口的某条link进行通信，需要把linkID设置成和对端同样的ID
            //    //tagT1.channelType = 1;                //1: bothway(1)	2: outgoing(2) 3: incoming(3)
            //    //tagT1.configureStatus = 1;
            //    //tagT1.operationStatus = 1;
            //    tagT1.E1bundle = i;                   //表示第几个信道，第16个信道不作为承载信道
            //    b = b & MBoxSDK.ConfigSDK.MBOX_DeleteT1Channel(Global.Params.BoxHandle, tagT1);
            //}
            
        }
        //获取PRI承载信道
        private static bool GetT1Channels(out List<DB_Talk.Model.m_PRIChannel> lst)
        {
            //byte[] byteArray = new byte[ArraySizeBig*32];
            byte[] byteArray = new byte[1800 * 32];
            int len = 0;
            bool b = MBoxSDK.ConfigSDK.MBOX_GetT1Channels(Global.Params.BoxHandle, byteArray, (uint)byteArray.Length, ref len);
            lst = new List<DB_Talk.Model.m_PRIChannel>();
            if (b)
            {
                string str = System.Text.Encoding.Default.GetString(byteArray);
                str = str.Replace("\0", "");
                string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    DB_Talk.Model.m_PRIChannel m = new DB_Talk.Model.m_PRIChannel();
                    string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    //"承载信道描述文本1-3-2-1,PRI索引，端口类型,配置状态,操作状态,LINKID;"
                    string[] strArray3 = strArray2[0].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    if (strArray2.Length==6 && strArray3.Length==4)
                    {
                        
                   
                    m.i_MachineID = int.Parse(strArray3[0]);
                    m.i_SoltID = int.Parse(strArray3[1]);
                    m.i_E1Port = int.Parse(strArray3[2]);
                    m.i_ChannelNumber = int.Parse(strArray3[3]);

                    m.PRIID = int.Parse(strArray2[1]);
                    m.i_State = int.Parse(strArray2[2]);
                    m.i_Operate = int.Parse(strArray2[3]);
                    m.i_LinkID = int.Parse(strArray2[4]);
                    m.BoxID = Global.Params.BoxID;
                    lst.Add(m);
                    }
                    Console.WriteLine(i);

                }
            }
            return b;
        }  
       
        //增加PRI信令信道
        private static bool CreateSigChannel(DB_Talk.Model.m_PRISigLink model)
        {
            bool b = false;
            if (IsBoxExitSigChannel(model)) return true;  
            MBoxSDK.ConfigSDK.tagSigLink SigLink = new MBoxSDK.ConfigSDK.tagSigLink();
            SigLink.priID = model.PRIID;
            SigLink.machineID = 1;                  //机身号
            SigLink.slotID = 3;                     //槽位号
            SigLink.e1Port = model.i_E1Port;                     //E1口
            SigLink.linkID = model.i_LinkID;                     //和对端通信的逻辑链接
            SigLink.portType = 1;                   //q931(1) qSIG(2),默认1
            SigLink.theEnd = model.i_UNIType;                     //用户侧：1，网络侧：2，默认1
            SigLink.peerProvideVoicePrompt = 1; //model.i_OppositeVoicePrompt;     //是:1,否:2,默认否
            SigLink.sendVoicePrompt = 1; //model.i_SendVoicePrompt;            //是:1,否:2,默认是 
            SigLink.E1bundle = 16;                   //表示第几个信道，默认为16
            b = MBoxSDK.ConfigSDK.MBOX_CreateSigChannel(Global.Params.BoxHandle, SigLink);
            return b;

        }
        //删除PRI信令信道
        private static bool DeleteSigChannel(DB_Talk.Model.m_PRISigLink model)
        {
            bool b = false;
            //if (!IsBoxExitSigChannel(model)) return true;  
            MBoxSDK.ConfigSDK.tagSigLink SigLink = new MBoxSDK.ConfigSDK.tagSigLink();
            SigLink.priID = model.PRIID;
            SigLink.machineID = 1;                  //机身号
            SigLink.slotID = 3;                     //槽位号
            SigLink.e1Port = model.i_E1Port;                     //E1口
            SigLink.linkID = model.i_LinkID;                     //和对端通信的逻辑链接
            SigLink.portType = 1;                   //q931(1) qSIG(2),默认1
            SigLink.theEnd = model.i_UNIType;                     //用户侧：1，网络侧：2，默认1
            SigLink.peerProvideVoicePrompt = 1; //model.i_OppositeVoicePrompt;     //是:1,否:2,默认否
            SigLink.sendVoicePrompt = 1; //model.i_SendVoicePrompt;            //是:1,否:2,默认是 
            SigLink.E1bundle = 16;                   //表示第几个信道，默认为16
            b = MBoxSDK.ConfigSDK.MBOX_DeleteSigChannel(Global.Params.BoxHandle, SigLink);
            
            return b;
        }

        //删除PRI信令信道
        private static bool DeleteAllSigChannel(int PRIID)
        {
            bool b = false;
            List<DB_Talk.Model.m_PRISigLink> lst = new List<DB_Talk.Model.m_PRISigLink>();
             GetSigChannel(out lst);
             //lst.Select(item => item.PRIID = PRIID).ToList();
            lst=lst.Where(w => w.PRIID == PRIID).ToList();

             if (lst != null && lst.Count > 0)
             {
                 foreach (DB_Talk.Model.m_PRISigLink m in lst)
                 {
                    b= DeleteSigChannel(m);
                    if (!b)
                        return false;
                 }
             }
             return true;
        }

        //获取PRI信令信道
        private static bool GetSigChannel(out List<DB_Talk.Model.m_PRISigLink> lst)
        {
            byte[] byteArray = new byte[ArraySizeBig];
            int len = 0;
            bool b = MBoxSDK.ConfigSDK.MBOX_GetSigChannel(Global.Params.BoxHandle, byteArray, (uint)byteArray.Length, ref len);
            lst = new List<DB_Talk.Model.m_PRISigLink>();
            if (b)
            {
                string str = System.Text.Encoding.Default.GetString(byteArray);
                str = str.Replace("\0", "");
                string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    DB_Talk.Model.m_PRISigLink m = new DB_Talk.Model.m_PRISigLink();
                    string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    //"Sig信道描述文本,端口类型,网络侧(用户侧),对端提供语音提示,发送语音提示,LINKID;"
                    string[] strArray3 = strArray2[0].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    m.i_MachineID = int.Parse(strArray3[0]);
                    m.i_SlotID = int.Parse(strArray3[1]);
                    m.i_E1Port = int.Parse(strArray3[2]);
                    m.i_ChannelNumber = int.Parse(strArray3[3]);


                    m.PRIID = int.Parse(strArray2[1]);
                    m.i_UNIType = int.Parse(strArray2[2]);
                    m.i_OppositeVoicePrompt = int.Parse(strArray2[3]);
                    m.i_SendVoicePrompt = int.Parse(strArray2[4]);
                    m.i_LinkID = int.Parse(strArray2[5]);
                    m.BoxID = Global.Params.BoxID;
                    lst.Add(m);

                }
            }
            return b;
        }
        //判断PRI信令信道是否存在
        private static bool IsBoxExitSigChannel(DB_Talk.Model.m_PRISigLink model)
        {
            List<DB_Talk.Model.m_PRISigLink> lst = new List<DB_Talk.Model.m_PRISigLink>();
            GetSigChannel(out lst);
            if (lst != null && lst.Count > 0)
            {
                if (lst.Contains(model))
                {
                    return true;  //存在的不再删除
                }
            }
            return false;
        }

        //增加PRI中继接口
        private static bool CreatePriTrunk(DB_Talk.Model.m_PRIInterface model)
        {
            bool b = false;
            if (IsBoxExitPRI(model)) return true;  //存在不再添加
            MBoxSDK.ConfigSDK.tagPriTrunk PriTrunk = new MBoxSDK.ConfigSDK.tagPriTrunk();
            PriTrunk.trunkID = model.PRIID;
            PriTrunk.trunkInterfaceType = model.i_Type;         //接口类型,内部(1),外部(2)，默认外部
            PriTrunk.trunkRoutingID = model.RouteID;             //路由ID
            PriTrunk.trunkPriority = model.i_Level;              //优先级,主(1),从(2)，默认主
            //PriTrunk.configureStatus=1;            //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
            //PriTrunk.operationStatus=1;            //up(2) down(1)
            //PriTrunk.linkCount=1;                  //最大通道(0~255)
            PriTrunk.linkType = 1;// model.i_LinkType;                   //链路类型 E1(1),T1(2)
            PriTrunk.PbxType = model.i_SwitchType;                    //交换机类型1: unknown(1) 2: avaya(2)3: nortel(3)4: alcatel(4) 5: siemens(5) 6: oulian(6)7: shenou(7) 8: utstarcom(8) 9: microxel(9)
            b = MBoxSDK.ConfigSDK.MBOX_CreatePriTrunk(Global.Params.BoxHandle, ref PriTrunk);
            return b;

        }
        //删除PRI中继接口
        private static bool DeletePriTrunk(DB_Talk.Model.m_PRIInterface model)
        {
            //if (!IsBoxExitPRI(model)) return true;  //存在不再添加
            MBoxSDK.ConfigSDK.tagPriTrunk PriTrunk = new MBoxSDK.ConfigSDK.tagPriTrunk();
            PriTrunk.trunkID = model.PRIID;
            PriTrunk.trunkInterfaceType = model.i_Type;         //接口类型,内部(1),外部(2)，默认外部
            PriTrunk.trunkRoutingID = model.RouteID;             //路由ID
            PriTrunk.trunkPriority = model.i_Level;              //优先级,主(1),从(2)，默认主
            //PriTrunk.configureStatus=1;            //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
            //PriTrunk.operationStatus=1;            //up(2) down(1)
            //PriTrunk.linkCount=1;                  //最大通道(0~255)
            PriTrunk.linkType = 1;// model.i_LinkType;                   //链路类型 E1(1),T1(2)
            PriTrunk.PbxType = model.i_SwitchType;                    //交换机类型1: unknown(1) 2: avaya(2)3: nortel(3)4: alcatel(4) 5: siemens(5) 6: oulian(6)7: shenou(7) 8: utstarcom(8) 9: microxel(9)
            bool b = MBoxSDK.ConfigSDK.MBOX_DeletePriTrunk(Global.Params.BoxHandle, PriTrunk);
            return b;
        }

        //删除PRI中继接口
        private static bool DeletePriTrunkByID(DB_Talk.Model.m_PRIInterface model)
        {
            List<DB_Talk.Model.m_PRIInterface> lst = new List<DB_Talk.Model.m_PRIInterface>();
            GetPriTrunk(out lst);
            if (lst != null && lst.Count > 0)
            {
                lst = lst.Where(w => w.PRIID == model.PRIID).ToList();
                foreach (DB_Talk.Model.m_PRIInterface m in lst)
                {
                    bool  b = DeletePriTrunk(m);
                    if (!b)
                        return false;
                }
            }
            return true;
            
        }

        //获取PRI中继接口
        public static bool GetPriTrunk(out List<DB_Talk.Model.m_PRIInterface> lst)
        {
            byte[] byteArray = new byte[ArraySizeBig];
            int len = 0;
            bool b = MBoxSDK.ConfigSDK.MBOX_GetPriTrunk(Global.Params.BoxHandle, byteArray, (uint)byteArray.Length, ref len);
            lst = new List<DB_Talk.Model.m_PRIInterface>();
            if (b)
            {
                string str = System.Text.Encoding.Default.GetString(byteArray);
                str = str.Replace("\0", "");
                string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    DB_Talk.Model.m_PRIInterface m = new DB_Talk.Model.m_PRIInterface();
                    string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    m.PRIID = int.Parse(strArray2[0]);
                    m.RouteID = int.Parse(strArray2[1]);
                    m.i_Type = int.Parse(strArray2[2]);
                    m.i_Level = int.Parse(strArray2[3]);
                    m.i_LinkType = int.Parse(strArray2[4]);  //链路类型 E1(1),T1(2)
                    m.i_SwitchType = int.Parse(strArray2[5]);
                    m.i_State = int.Parse(strArray2[6]);
                    m.i_Operate = int.Parse(strArray2[7]);
                    m.i_LinkCount = int.Parse(strArray2[8]);
                    m.BoxID = Global.Params.BoxID;
                    lst.Add(m);
                }
            }
            return b;
        }
        //判断中继接口是否存在
        private static bool IsBoxExitPRI(DB_Talk.Model.m_PRIInterface model)
        {
            List<DB_Talk.Model.m_PRIInterface> lst = new List<DB_Talk.Model.m_PRIInterface>();
            GetPriTrunk(out lst);
            if (lst != null && lst.Count > 0)
            {
                if (lst.Contains(model))
                {
                    return true;  //存在的不再
                }
            }
            return false;
        }

        //激活PRI中继接口
        private static bool SetPRITrunkActive(DB_Talk.Model.m_PRIInterface model)
        {
            bool b = false;
            List<DB_Talk.Model.m_PRIInterface> lst = new List<DB_Talk.Model.m_PRIInterface>();
            GetPriTrunk(out lst);
            if (lst != null && lst.Count > 0)
            {
                DB_Talk.Model.m_PRIInterface temp = lst.Find(item => item.PRIID == model.PRIID);
                if (temp != null) //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
                {
                    if (temp.i_State == 2) //2激活状态
                    {
                        return true;//已经激活的不再激活
                    }
                }
                b = MBoxSDK.ConfigSDK.MBOX_SetPriTrunkAction(Global.Params.BoxHandle, model.PRIID, 1); //表示激活(1)或去激活(2)
            }
            else
                return true;
            return b;
        }
        //去激活PRI中继接口
        private static bool SetPRITrunkDective(DB_Talk.Model.m_PRIInterface model)
        {
            bool b = false;
            List<DB_Talk.Model.m_PRIInterface> lst = new List<DB_Talk.Model.m_PRIInterface>();
            GetPriTrunk(out lst);
            if (lst != null && lst.Count > 0)
            {
                DB_Talk.Model.m_PRIInterface temp = lst.Find(item => item.PRIID == model.PRIID);
                if (temp != null) //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
                {
                    if (temp.i_State != 2)
                    {
                        return true;//已经去激活的不再去激活
                    }
                }
                else
                    return true;
                b = MBoxSDK.ConfigSDK.MBOX_SetPriTrunkAction(Global.Params.BoxHandle, model.PRIID, 2); //表示激活(1)或去激活(2)
            }
            else
                return true;
            return b;
        }
        
        //创建中继
        public static bool createPRI(DB_Talk.Model.m_PRIInterface newmodel, List<DB_Talk.Model.m_CalledRule> lstRuleAdd, List<DB_Talk.Model.m_CalledRule> lstRuleDelete)
        {
            //创建路由组
            DB_Talk.Model.m_RouteGroup mRg = new DB_Talk.Model.m_RouteGroup();
            mRg.vc_Name = "PRI" + newmodel.PRIID.ToString();
            int routeGroupID = 0;
            if (!CreateRouteGroup(mRg, out routeGroupID))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("添加PRI路由组失败");
                return false;
            }
            newmodel.RouteID = routeGroupID;
            //创建路由
            DB_Talk.Model.m_Route mR = new DB_Talk.Model.m_Route();
            mR.ID = routeGroupID;
            mR.RouteGroupID = routeGroupID;
            mR.vc_Name = "PRI" + newmodel.PRIID.ToString();
            mR.i_RouteType = MBoxSDK.ConfigSDK.EnumRouteType.btw.GetHashCode();
            if (!CreateRoute(mR))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("添加PRI路由失败");
                return false;
            }

            //创建路由规则0,PRIID,PRIID
            DB_Talk.Model.m_RouteRule modelRRule = new DB_Talk.Model.m_RouteRule();
            modelRRule.OriRouteID = 0;
            modelRRule.DestRouteID = newmodel.RouteID;
            modelRRule.ID = newmodel.RouteID;
            modelRRule.BoxID = Global.Params.BoxID;
            if (!CreateRoutingRule(modelRRule))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("添加路由规则失败");
                return false;
            }
            

            //创建PRI中继
            if (!CreatePriTrunk(newmodel))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("添加PRI失败");
                return false;
            }
            //创建承载新道
            DB_Talk.Model.m_PRIChannel PRIChannelModel = new DB_Talk.Model.m_PRIChannel();
            PRIChannelModel.i_E1Port = newmodel.i_E1Port;
            PRIChannelModel.i_LinkID = newmodel.i_LinkID;
            PRIChannelModel.PRIID = newmodel.PRIID;
            if (!CreateT1Channel(PRIChannelModel))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("添加承载信道失败");
                return false;
            }

            //创建信令新道

            DB_Talk.Model.m_PRISigLink PRISigLinkModel = new DB_Talk.Model.m_PRISigLink();
            PRISigLinkModel.i_E1Port = newmodel.i_E1Port;
            PRISigLinkModel.i_LinkID = newmodel.i_LinkID;
            PRISigLinkModel.PRIID = newmodel.PRIID;
            PRISigLinkModel.i_UNIType = newmodel.i_UNIType;
            if (!CreateSigChannel(PRISigLinkModel))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("添加信令信道失败");
                return false;
            }

            //激活PRI中继
            if (!SetPRITrunkActive(newmodel))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("激活PRI失败");
                return false;
            }

            //添加被叫规则
            foreach (DB_Talk.Model.m_CalledRule d in lstRuleAdd)
            {
                d.DestRouteID = routeGroupID;
                if (!CreateCall_OutRule(d))
                {
                    CommControl.Tools.WriteLog.AppendErrorLog("添加被叫规则失败，被叫号码为：" + d.vc_CalledNumber);
                    DeletePRI(newmodel);
                    return false;
                }
            }
            if (!Delete_Rule(lstRuleAdd, lstRuleDelete))
                return false;


            return true;

        }

        public static bool CreatePRI(DB_Talk.Model.m_PRIInterface newmodel, DB_Talk.Model.m_PRIInterface oldmodel, List<DB_Talk.Model.m_CalledRule> lstRuleAdd, List<DB_Talk.Model.m_CalledRule> lstRuleDelete)
        {
            if (oldmodel == null)   //新增 
            {
                if (createPRI(newmodel, lstRuleAdd, lstRuleDelete))
                    if (new DB_Talk.BLL.m_PRIInterface().Add(newmodel) > 0)
                        return true;
            }
            else  //修改
            {
                if (oldmodel.PRIID == newmodel.PRIID | oldmodel.i_E1Port==newmodel.i_E1Port)//索引或E1端口相同的，修改时先删除 再新建
                {
                    if (DeletePRI(oldmodel, lstRuleAdd, lstRuleDelete) && new DB_Talk.BLL.m_PRIInterface().Delete(oldmodel.ID))
                        if (createPRI(newmodel, lstRuleAdd, lstRuleDelete))
                            if (new DB_Talk.BLL.m_PRIInterface().Add(newmodel) > 0)
                                return true;
                }
                else
                {
                    if (createPRI(newmodel, lstRuleAdd, lstRuleDelete))//索引不同时，先新建后删除
                        if (new DB_Talk.BLL.m_PRIInterface().Add(newmodel) > 0)
                            if (DeletePRI(oldmodel, lstRuleAdd, lstRuleDelete) && new DB_Talk.BLL.m_PRIInterface().Delete(oldmodel.ID))
                                return true;
                }
            }
            return false;

        }
        
        //删除中继
        public static bool DeletePRI(DB_Talk.Model.m_PRIInterface model)
        {
            //去激活PRI中继
            if (!SetPRITrunkDective(model))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("去激活PRI失败");
                return false;
            }

            //删除信令信道
            DB_Talk.Model.m_PRISigLink PRISigLinkModel = new DB_Talk.Model.m_PRISigLink();
            PRISigLinkModel.PRIID = model.PRIID;
            if (!DeleteAllSigChannel(PRISigLinkModel.PRIID))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("删除信令信道失败");
                return false;
            }


            //删除承载信道
            if (!DeleteT1Channel(model.PRIID))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("删除承载信道失败");
                return false;
            }

            //删除中继
            if (!DeletePriTrunkByID(model))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("删除PRI失败");
                return false;
            }

            //删除路由规则0,PRIID,PRIID
            DB_Talk.Model.m_RouteRule modelRRule = new DB_Talk.Model.m_RouteRule();
            modelRRule.OriRouteID = 0;
            modelRRule.DestRouteID = model.RouteID;
            modelRRule.ID = model.RouteID;
            modelRRule.BoxID = Global.Params.BoxID;
            if (!DeleteRoutingRule(modelRRule))
            {
                CommControl.Tools.WriteLog.AppendErrorLog("删除路由规则失败");
                return false;
            }
           

            //删除路由
            DB_Talk.Model.m_Route mR = new DB_Talk.Model.m_Route();
            mR.ID = model.RouteID;
            mR.vc_Name = "PRI" + model.PRIID.ToString();
            mR.RouteGroupID = model.RouteID;
            mR.i_RouteType = 1; //1: btw(1)双向（默认）
            if (!DeleteRoute(mR))
                return false;

            //删除路由组
            DB_Talk.Model.m_RouteGroup mRg = new DB_Talk.Model.m_RouteGroup();
            mRg.vc_Name = "PRI" + model.PRIID.ToString();
            mRg.ID = model.RouteID;
            if (!DeleteRouteGroup(mRg))
            {
                return false;
            }
          
            //删除呼叫规则

            return true;
        }

        public static bool DeletePRI(DB_Talk.Model.m_PRIInterface model, List<DB_Talk.Model.m_CalledRule> lstRuleAdd, List<DB_Talk.Model.m_CalledRule> lstRuleDelete)
        {
            if (!DeletePRI(model))
                return false;
            //删除被叫规则
            if (!Delete_Rule(lstRuleAdd, lstRuleDelete))
                return false;

            return true;
        }

        #endregion

        #region 设置站点信息


        //查询Dsp
        private static string GetDspAddress()
        {
            byte[] bytearray = new byte[1024];
            int len = bytearray.Length;
            bool b = MBoxSDK.ConfigSDK.MBOX_GetDspAddress(Global.Params.BoxHandle, bytearray, len);
            string strIP = System.Text.Encoding.Default.GetString(bytearray).Replace("\0", "");
            return strIP;
        }

        //设置调度台IP
        public static bool SetDispatcherAddress(List<string> lstIP)
        {
            bool b=true;  //不设置时返回true
            MBoxSDK.ConfigSDK.tagTrapServer TrapServer = new MBoxSDK.ConfigSDK.tagTrapServer();
            if (lstIP.Count >= 1)
            {
                TrapServer.trapServer1 = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
                System.Text.ASCIIEncoding.ASCII.GetBytes(lstIP[0]).CopyTo(TrapServer.trapServer1, 0);  //对端IP地址 
            }
            if (lstIP.Count >= 2)
            {
                TrapServer.trapServer2 = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
                System.Text.ASCIIEncoding.ASCII.GetBytes(lstIP[1]).CopyTo(TrapServer.trapServer2, 0);  //对端IP地址 
    
            }
            if (lstIP.Count >= 3)
            {
                TrapServer.trapServer3 = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
                System.Text.ASCIIEncoding.ASCII.GetBytes(lstIP[2]).CopyTo(TrapServer.trapServer3, 0);  //对端IP地址 
            }
            if (lstIP.Count >= 4)
            {
                TrapServer.trapServer4 = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
                System.Text.ASCIIEncoding.ASCII.GetBytes(lstIP[3]).CopyTo(TrapServer.trapServer4, 0);  //对端IP地址 
            }
            if(lstIP.Count>0)
               b = MBoxSDK.ConfigSDK.MBOX_SetDispatcherAddress(Global.Params.BoxHandle, TrapServer);
            return b;
        }
        //查询调度台IP
        public static bool GetDispatcherAddress(out List<string> lstIP)
        {
            lstIP = new List<string>();
            MBoxSDK.ConfigSDK.tagTrapServer TrapServer = new MBoxSDK.ConfigSDK.tagTrapServer();
            bool b = MBoxSDK.ConfigSDK.MBOX_GetDispatcherAddress(Global.Params.BoxHandle, ref TrapServer);
            string strIP1 = System.Text.Encoding.Default.GetString(TrapServer.trapServer1).Replace("\0", "");
            string strIP2 = System.Text.Encoding.Default.GetString(TrapServer.trapServer2).Replace("\0", "");
            string strIP3 = System.Text.Encoding.Default.GetString(TrapServer.trapServer3).Replace("\0", "");
            string strIP4 = System.Text.Encoding.Default.GetString(TrapServer.trapServer4).Replace("\0", "");
            if (strIP1 != "") lstIP.Add(strIP1);
            if (strIP2 != "") lstIP.Add(strIP2);
            if (strIP3 != "") lstIP.Add(strIP3);
            if (strIP4 != "") lstIP.Add(strIP4);
            return b;
        }

        //设置时间服务器
        public static bool SetTimeServer(string IP)
        {
             bool b=false;
            if(IP!=null && IP!="")
               b= MBoxSDK.ConfigSDK.MBOX_SetNTPAddress(Global.Params.BoxHandle, IP);
            return b;

        }
        //查询时间服务器
        public static bool GetTimerServer(out string strIP)
        {
            byte[] bytearray = new byte[ArraySize];
            int len = bytearray.Length;
            bool b = MBoxSDK.ConfigSDK.MBOX_GetNTPAddress(Global.Params.BoxHandle, bytearray, len);
            strIP = System.Text.Encoding.Default.GetString(bytearray).Replace("\0", "");
            return b;
        }

        //设置录音服务器
        public static bool SetRecordServer(string IP)
        {
            MBoxSDK.ConfigSDK.tagRecordServerConf conf = new MBoxSDK.ConfigSDK.tagRecordServerConf();
            conf.szRecordServerIp = new byte[MBoxSDK.ConfigSDK.MAX_IP4 + 1];
            byte[] byteIP = System.Text.ASCIIEncoding.ASCII.GetBytes(IP);
            byteIP.CopyTo(conf.szRecordServerIp, 0);
            conf.bSupport = true;
            bool b = MBoxSDK.ConfigSDK.MBOX_SetRecordServer(Global.Params.BoxHandle, conf);
            return b;
           
        }
        //查询录音服务器
        public static bool GetRecordServer(out string strIP)
        {
            MBoxSDK.ConfigSDK.tagRecordServerConf conf = new MBoxSDK.ConfigSDK.tagRecordServerConf();
            bool b = MBoxSDK.ConfigSDK.MBOX_GetRecordServer(Global.Params.BoxHandle, ref conf);
            strIP = System.Text.ASCIIEncoding.Default.GetString(conf.szRecordServerIp).Replace("\0", "");
            return b;
        }

        //设置站点信息
        public static void SetNodeInfo(DB_Talk.Model.m_Box model)
        {
            MBoxSDK.ConfigSDK.tagNode node = new MBoxSDK.ConfigSDK().newTagNode();
            byte[] byteIP = System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_IP);      //"192.168.1.208");
            byteIP.CopyTo(node.trafficInterfaceIp, 0);
            byte[] byteIPMask = System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_Mask);  //"255.255.255.0");
            byteIPMask.CopyTo(node.trafficInterfaceMask, 0);
            //byte[] byteDspIP = System.Text.ASCIIEncoding.ASCII.GetBytes("10.20.31.171");   //必须和业务口在一个网段，但是不在此处设置
            //byteIP.CopyTo(node.dspSrcIP, 0);
            byte[] netManegeInterfaceIP = System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_NetIP);// ("11.20.30.1");  //必须和业务口不在一个网段
            netManegeInterfaceIP.CopyTo(node.netManegeInterfaceIP, 0);
            byte[] byteNetIPMask = System.Text.ASCIIEncoding.ASCII.GetBytes("255.255.255.0");
            byteNetIPMask.CopyTo(node.netManegeInterfaceMask, 0);
            MBoxSDK.ConfigSDK.MBOX_SetNodeInfo(Global.Params.BoxHandle, node);  
           
        }
        //获取节点信息
        public static bool GetNodeInfo(int handle,out DB_Talk.Model.m_Box model)
        {
            model = new DB_Talk.Model.m_Box();
            MBoxSDK.ConfigSDK.tagNode node = new MBoxSDK.ConfigSDK.tagNode();//new MBoxSDK.ConfigSDK().newTagNode();
            bool b = MBoxSDK.ConfigSDK.MBOX_GetNodeInfo(handle, ref node);
            model.vc_Name = System.Text.ASCIIEncoding.Default.GetString(node.nodeName).Replace("\0", "");
            model.vc_DspIP = System.Text.ASCIIEncoding.Default.GetString(node.dspSrcIP).Replace("\0", "");
            model.vc_NetIP = System.Text.ASCIIEncoding.Default.GetString(node.netManegeInterfaceIP).Replace("\0", "");
            string strnetIPMask = System.Text.ASCIIEncoding.Default.GetString(node.netManegeInterfaceMask).Replace("\0", "");
            string strSerialNum = System.Text.ASCIIEncoding.Default.GetString(node.serialNumber).Replace("\0", "");
            model.vc_IP = System.Text.ASCIIEncoding.Default.GetString(node.trafficInterfaceIp).Replace("\0", "");
            model.vc_Mask = System.Text.ASCIIEncoding.Default.GetString(node.trafficInterfaceMask).Replace("\0", "");
            string strVerInfo = System.Text.ASCIIEncoding.Default.GetString(node.versionInfo).Replace("\0", "");
            return b;
        }
      
        //查询CDR
        private void GetCdrTrigger()
        {
            int open = 0, openReal = 0;
            bool b = MBoxSDK.ConfigSDK.MBOX_GetCdrTrigger(Global.Params.BoxHandle, ref open, ref openReal);
        }

        //设置SIP注册周期
        public static bool SetSipRegisterCycleAndHeartBeatInterval()
        {
            int RegisSecond = 120, HeartSecond = 180;
            bool b = MBoxSDK.ConfigSDK.MBOX_SetSipRegisterCycleAndHeartBeatInterval(Global.Params.BoxHandle, RegisSecond, HeartSecond);
            return b;
        }
        //获取SIP注册周期
        public static bool GetSipRegisterCycleAndHeartBeatInterval()
        {
            int RegisSecond = 0, HeartSecond = 0;
            bool b = MBoxSDK.ConfigSDK.MBOX_GetSipRegisterCycleAndHeartBeatInterval(Global.Params.BoxHandle, ref RegisSecond, ref HeartSecond);
            return b;
        }

        //设置时钟源

        public static bool SetPriClock(DB_Talk.Model.m_PRIClock model)
        {
            MBoxSDK.ConfigSDK.tagClockSource ClockSource = new MBoxSDK.ConfigSDK.tagClockSource();
            ClockSource.priority = model.i_Level.Value;
            ClockSource.type =model.i_Type; //1：none(-1)  2: internal(-2)  3: external(-3)	4: e1(-4)
            if(model.i_Port!=0)
              ClockSource.port = model.i_Port;
            bool b = MBoxSDK.ConfigSDK.MBOX_SetClockSource(Global.Params.BoxHandle, ClockSource);
            return b;
        }
        //站点基本设置
        public static bool SetBaseBox()
        {
            //因为恢复出厂设置之后dsp地址会恢复默认值，所以此处要检查下
            DB_Talk.Model.m_Box modelbox = new DB_Talk.BLL.m_Box().GetModel(Global.Params.BoxID);
            if (modelbox != null && !string.IsNullOrEmpty(modelbox.vc_DspIP) && GetDspAddress() != modelbox.vc_DspIP)
            {
                MBoxSDK.ConfigSDK.MBOX_SetDspAddress(Global.Params.BoxHandle, modelbox.vc_DspIP);
            }

            //因为恢复出厂设置之后调度IP地址会清空，所以此处要重新设置下
            List<string> lstIP=new List<string>();
            GetDispatcherAddress(out lstIP);
            if (modelbox != null && !string.IsNullOrEmpty(modelbox.vc_DispatchIP1) ) //&& !lstIP.Contains(modelbox.vc_DispatchIP1))
            {
                lstIP[0]=modelbox.vc_DispatchIP1;
            }
            if (modelbox != null && !string.IsNullOrEmpty(modelbox.vc_DispatchIP2) ) //&& !lstIP.Contains(modelbox.vc_DispatchIP2))
            {
                lstIP[1]=modelbox.vc_DispatchIP2;
            }
            SetDispatcherAddress(lstIP);

            //设置CDR服务器
            int open = 1, openReal = 2; //1打开，2关闭
            if (!MBoxSDK.ConfigSDK.MBOX_SetCdrTrigger(Global.Params.BoxHandle, open, openReal))
                return false;

            //SIP管理设置
            if (!SetSipRegisterCycleAndHeartBeatInterval())
                return false;

            //SAP接入点设置
            DB_Talk.Model.m_SAPPoint model = new DB_Talk.Model.m_SAPPoint();
            model.BoxID = Global.Params.BoxID;
            model.SAPID = 1;
            model.i_Port = 5060;
            model.i_Type = 1;
            if(!CreateSipSap(model))
            {
                return false;
            }
        
            //设置默认的呼叫源、路由规则、呼叫源规则
            if (!Tools.MBoxOperate.CreateCalinglSourceRule())
            {
                return false;
            }

          
        

            return true;
        }


        #endregion

        #region 3G

        //设置安全网关
        public static bool SetSecureGatewayAddress(string IP)
        {
            return MBoxSDK.ConfigSDK.MBOX_3G_SetSecureGatewayAddress(Global.Params.BoxHandle, IP);
        }
        //查询安全网关
        public static bool GetSecureGatewayAddress(out string IP)
        {
            byte[] byteArray = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            bool b = MBoxSDK.ConfigSDK.MBOX_3G_GetSecureGatewayAddress(Global.Params.BoxHandle, byteArray);
            IP = System.Text.ASCIIEncoding.ASCII.GetString(byteArray);
            
            return b;
        }
        //获取安全网关的状态
        public static bool GetSecureGatewayStatus(out int state)
        {
            state = 0;
            return MBoxSDK.ConfigSDK.MBOX_3G_GetSecureGatewayStatus(Global.Params.BoxHandle, ref state);

        }


        //设置DNS
        public static bool SetDNSServer(string IP1, string IP2)
        {
            if (IP1.Trim() == "") IP1 = "0.0.0.0";
            if (IP2.Trim() == "") IP2 = "0.0.0.0";
           return  MBoxSDK.ConfigSDK.MBOX_3G_SetDNSServer(Global.Params.BoxHandle, IP1.Trim(),IP2.Trim());

        }
        //查询DNS
        public static bool GetDNSServer(out string IP1,out string IP2)
        {
            byte[] byteArrayDNS1 = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            byte[] byteArrayDNS2 = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            bool b = MBoxSDK.ConfigSDK.MBOX_3G_GetDNSServer(Global.Params.BoxHandle, byteArrayDNS1, byteArrayDNS2);
            IP1 = System.Text.ASCIIEncoding.ASCII.GetString(byteArrayDNS1).Replace("\0","");
            IP2 = System.Text.ASCIIEncoding.ASCII.GetString(byteArrayDNS2).Replace("\0", "");
            return b;
        }


        //添加PDS
        public static bool CreatePDS(DB_Talk.Model.m_PDS model)
        {
            if (model.PdsID == 0 || string.IsNullOrEmpty(model.vc_IP)) return false;
            return  MBoxSDK.ConfigSDK.MBOX_3G_CreatePDS(Global.Params.BoxHandle, model.PdsID, model.vc_IP);
        }

        //删除PDS
        public static bool DeletePDS(DB_Talk.Model.m_PDS model)
        {
            if (model.PdsID == 0) return false;
            return MBoxSDK.ConfigSDK.MBOX_3G_DeletePDS(Global.Params.BoxHandle,model.PdsID);

        }

        //查询PDS
        public static bool GetPDS(out List<DB_Talk.Model.m_PDS> lstModel)
        {
            byte[] byteArray = new byte[ArraySizeBig];
            int count = 0;
            bool b = MBoxSDK.ConfigSDK.MBOX_3G_GetPDS(Global.Params.BoxHandle, byteArray, (UInt32)byteArray.Length, ref count);
            lstModel = new List<DB_Talk.Model.m_PDS>();
            if (b)
            {
                string str = System.Text.Encoding.Default.GetString(byteArray);
                str = str.Replace("\0", "");
                string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    DB_Talk.Model.m_PDS m = new DB_Talk.Model.m_PDS();
                    m.PdsID = int.Parse(strArray2[0]);
                    m.i_ConfState = int.Parse(strArray2[1]);
                    m.vc_IP = strArray2[3];
                    m.i_OperateState = int.Parse(strArray2[2]);
                    m.i_IdleGtpChannelCount = int.Parse(strArray2[4]);
                    m.i_BusyGtpChannelCount = int.Parse(strArray2[5]);
                    m.i_IdleVideoChannelCount = int.Parse(strArray2[6]);
                    m.i_BusyVideoChannelCount = int.Parse(strArray2[7]);
                    m.BoxID = Global.Params.BoxID;
                    lstModel.Add(m);
                }
            }
            return b;


          
        }
        //激活PDS
        public static bool SetPDSActive(DB_Talk.Model.m_PDS model)
        {
            return MBoxSDK.ConfigSDK.MBOX_3G_SetPDSActive(Global.Params.BoxHandle, model.PdsID, 1);

        }
        //去激活PDS
        public static bool SetPDSDctive(DB_Talk.Model.m_PDS model)
        {
            return MBoxSDK.ConfigSDK.MBOX_3G_SetPDSActive(Global.Params.BoxHandle, model.PdsID, 2);

        }

        //添加静态路由
        public static bool CreateStaticRouting(DB_Talk.Model.m_StaticRoute model)
        {
            MBoxSDK.ConfigSDK.tagStaticRoutingInfo StaticRoutingInfo = new MBoxSDK.ConfigSDK.tagStaticRoutingInfo();

            StaticRoutingInfo.szNet = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            StaticRoutingInfo.szMask = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            StaticRoutingInfo.szGateWay = new byte[MBoxSDK.ConfigSDK.MAX_IP4];

            byte[] bnet = System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_NetIP);//"192.168.100.0");
            bnet.CopyTo(StaticRoutingInfo.szNet, 0);

            byte[] bmask = System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_Mask);//"255.255.255.0");
            bmask.CopyTo(StaticRoutingInfo.szMask, 0);

            byte[] bgateway = System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_GateWayIP);//"192.168.1.11");  //安全网关地址
            bgateway.CopyTo(StaticRoutingInfo.szGateWay, 0);

            return  MBoxSDK.ConfigSDK.MBOX_SetStaticRouting(Global.Params.BoxHandle, StaticRoutingInfo);

        }
        //查询静态路由
        public static bool GetStaticRouting(out List<DB_Talk.Model.m_StaticRoute> lst)
        {
            byte[] byteArray = new byte[ArraySizeBig];
            int count = 0;
            bool b = MBoxSDK.ConfigSDK.MBOX_GetStaticRouting(Global.Params.BoxHandle, byteArray, (UInt32)byteArray.Length, ref count);
            lst = new List<DB_Talk.Model.m_StaticRoute>();
            if (b)
            {
                string str = System.Text.Encoding.Default.GetString(byteArray);
                str = str.Replace("\0", "");
                string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    DB_Talk.Model.m_StaticRoute m = new DB_Talk.Model.m_StaticRoute();
                    m.vc_NetIP = strArray2[0];
                    m.vc_Mask = strArray2[1];
                    m.vc_GateWayIP = strArray2[2];
                    m.BoxID = Global.Params.BoxID;
                    lst.Add(m);
                }
            }
            return b;

          
           
        }

        //删除静态路由
        public static bool DeleteStaticRouting(DB_Talk.Model.m_StaticRoute model)
        {
            List<DB_Talk.Model.m_StaticRoute> lst=new List<DB_Talk.Model.m_StaticRoute>();
            GetStaticRouting(out lst);
            if (lst.Count==0)
            {
                return true;
            }
            //是否存在要删除的静态路由
            bool isExits = false;
            foreach (DB_Talk.Model.m_StaticRoute item in lst)
            {
                if (item.vc_GateWayIP==model.vc_GateWayIP && item.vc_Mask==model.vc_Mask && item.vc_NetIP==model.vc_NetIP)
                {
                    isExits = true;
                    break;
                }
            }
            if (isExits==false)
            {
                return true;
            }
            MBoxSDK.ConfigSDK.tagStaticRoutingInfo StaticRoutingInfo = new MBoxSDK.ConfigSDK.tagStaticRoutingInfo();

            StaticRoutingInfo.szNet = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            StaticRoutingInfo.szMask = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            StaticRoutingInfo.szGateWay = new byte[MBoxSDK.ConfigSDK.MAX_IP4];

            byte[] bnet = System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_NetIP);
            bnet.CopyTo(StaticRoutingInfo.szNet, 0);

            byte[] bmask = System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_Mask);
            bmask.CopyTo(StaticRoutingInfo.szMask, 0);

            byte[] bgateway = System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_GateWayIP);  //安全网关地址
            bgateway.CopyTo(StaticRoutingInfo.szGateWay, 0);

            return MBoxSDK.ConfigSDK.MBOX_DeleteStaticRouting(Global.Params.BoxHandle, StaticRoutingInfo);
        }

        //添加3G基站
        public static bool CreateFAP(DB_Talk.Model.m_FAP model)
        {
            #region 检查BOX里有没有
            List<DB_Talk.Model.m_FAP> lst = new List<DB_Talk.Model.m_FAP>();
            bool bb=GetFAP(out lst);
            foreach (DB_Talk.Model.m_FAP item in lst)
            {
                if (item.FapID==model.FapID || item.vc_Identify==model.vc_Identify)
                {
                    DeleteFAP(model);
                }
            }
            #endregion

            MBoxSDK.ConfigSDK.tagFap fap3G = new MBoxSDK.ConfigSDK.tagFap();
            fap3G.fapID = model.FapID; //1-256
            fap3G.fapIdentify = model.vc_Identify;// +"@strongswan.org";  // "463464568980205@strongswan.org";
            fap3G.fapName = model.vc_Name;

            byte[] bs = System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_TempAddress);

            fap3G.fapIpAddress = new byte[MBoxSDK.ConfigSDK.MAX_IP4];
            for (int i = 0; i < bs .Length- 1; i++)
            {
                fap3G.fapIpAddress[i] = bs[i];
            }


            bool b = MBoxSDK.ConfigSDK.MBOX_3G_CreateFAP(Global.Params.BoxHandle, fap3G);
            return b;
        }
        //删除3G基站 
        public static bool DeleteFAP(DB_Talk.Model.m_FAP model)
        {
            MBoxSDK.ConfigSDK.tagFap fap3G = new MBoxSDK.ConfigSDK.tagFap();
            fap3G.fapID = model.FapID;
            fap3G.fapIdentify = model.vc_Identify + "@strongswan.org";// "463464568980205@strongswan.org";
            fap3G.fapName = model.vc_Name;
            bool b = MBoxSDK.ConfigSDK.MBOX_3G_DeleteFAP(Global.Params.BoxHandle, fap3G);
            return b;
        }
        //查询3G基站
        public static bool GetFAP(out List<DB_Talk.Model.m_FAP> lst )
        {
           
            byte[] byteArray = new byte[ArraySizeBig*10];
            int count = 0;
            bool b = MBoxSDK.ConfigSDK.MBOX_3G_GetFAP(Global.Params.BoxHandle, byteArray, (UInt32)byteArray.Length, ref count);
            lst = new List<DB_Talk.Model.m_FAP>();
            if (b)
            {
                string str = System.Text.Encoding.Default.GetString(byteArray);
                str = str.Replace("\0", "");
                string[] strArray = str.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (strArray2.Length == 8)
                    {
                        DB_Talk.Model.m_FAP m = new DB_Talk.Model.m_FAP();
                        m.FapID = int.Parse(strArray2[0]);
                        m.i_RanType = int.Parse(strArray2[1]);
                        m.vc_Identify = strArray2[2];
                        m.vc_Name = strArray2[3];
                        m.i_ConfState = int.Parse(strArray2[4]);
                        m.vc_TempAddress = strArray2[5];
                        m.i_fapSctpPort = int.Parse(strArray2[6]);
                        m.i_SwLinkID = int.Parse(strArray2[7]);
                        m.BoxID = Global.Params.BoxID;
                        lst.Add(m);
                    }
                }
            }
            return b;

        }








        #endregion


    }
}
