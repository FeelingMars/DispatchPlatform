using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DispatchPlatform.Control.Region
{
    internal class RegionTalkControl
    {
        private static RegionTalkControl m_Instance;
        private static object m_LockObj = new object();

        private RegionTalkControl()
        {
        }

        public static RegionTalkControl GetInstance()
        {
            if (m_Instance == null)
            {
                lock (m_LockObj)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new RegionTalkControl();
                    }
                }
            }
            return m_Instance;
        }

        public void RegeditTalk()
        {
            Pub._talkControl.OnMemberStateChanged += new TalkControl.MemberStateChanaged(_talkControl_OnMemberStateChanged);
            Pub._talkControl.OnDispatchStateChanged += new TalkControl.DispatchStateChanaged(_talkControl_OnDispatchStateChanged);
        }

        public void UnregeditTalk()
        {
            Pub._talkControl.OnMemberStateChanged -= _talkControl_OnMemberStateChanged;
            Pub._talkControl.OnDispatchStateChanged -= _talkControl_OnDispatchStateChanged;
        }

        private void _talkControl_OnMemberStateChanged(object obj, TalkControl.UserStateArgs e)
        {
            throw new NotImplementedException();
        }
        private void _talkControl_OnDispatchStateChanged(object obj, TalkControl.DispatchArgs e)
        {
            switch (e.DispatchCmdSubType)
            {
                //#region 呼叫
                //case TalkControl.EnumDispatchCmdType.makeCall:
                //    switch (e.DispatchStatus)
                //    {
                //        case TalkControl.EnumDispatchStatus.success:
                //            bc_OnMsg(string.Format("{0}呼叫{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                //            DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.Call, e.FromNumber, e.ToNumber.ToString(), true);
                //            SingleUserControl scc = Pub._memberManage.GetSingleControl(e.FromNumber);
                //            if (scc != null)
                //            {
                //                Pub._memberManage.UpdateMemberState(scc.Number, TalkControl.EnumUserLineStatus.Busy);
                //            }
                //            break;
                //        case TalkControl.EnumDispatchStatus.released:
                //            // bc_OnMsg(string.Format("呼叫释放"));
                //            DB_Talk.Model.Data_DispatchLog log = DispatchLogBLL.GetDispatchLog(PublicEnums.EnumNormalCmd.Call, e.FromNumber);
                //            if (log != null)
                //            {
                //                SingleUserControl sc = Pub._memberManage.GetSingleControl(int.Parse(log.DispatchedNumbers));
                //                if (sc != null)
                //                {
                //                    Pub._memberManage.UpdateMemberState(sc.Number, sc.UserLineStatus);
                //                }
                //            }
                //            break;
                //        case TalkControl.EnumDispatchStatus.failure:
                //            DB_Talk.Model.Data_DispatchLog logF = DispatchLogBLL.GetDispatchLog(PublicEnums.EnumNormalCmd.Call, e.FromNumber);
                //            if (logF != null)
                //            {
                //                SingleUserControl sc = Pub._memberManage.GetSingleControl(int.Parse(logF.DispatchedNumbers));
                //                if (sc != null)
                //                {
                //                    Pub._memberManage.UpdateMemberState(sc.Number, sc.UserLineStatus);
                //                }
                //            }
                //            bc_OnMsg(string.Format("呼叫失败"));
                //            break;
                //        case TalkControl.EnumDispatchStatus.userRinging:
                //            if (e.ToNumber != 0)
                //            {
                //                bc_OnMsg(string.Format("用户{0}振铃", e.ToNumber));
                //            }
                //            break;
                //        default:
                //            break;
                //    }
                //    break;
                //#endregion

                default:
 break;
            }
        }

        private void HandleDispatchStateMessage()
        {
 
        }

    }
}
