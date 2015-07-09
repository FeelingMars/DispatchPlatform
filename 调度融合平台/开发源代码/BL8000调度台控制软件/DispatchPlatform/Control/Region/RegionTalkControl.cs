using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchPlatform.Command;
using DispatchPlatform.Data;
using CommControl;

namespace DispatchPlatform.Region
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
            RegionManage.GetInstance().UpdateMemberStatus(e.UserNumber.ToString(), e.UserLineStatus);
            RegionManage.GetInstance().UpdateMemberDestNumber(e.UserNumber.ToString(), e.PeerPartNumber.ToString());
        }

        private void _talkControl_OnDispatchStateChanged(object obj, TalkControl.DispatchArgs e)
        {
            switch (e.DispatchCmdSubType)
            {
                case TalkControl.EnumDispatchCmdType.makeCall:
                    HandleDispatchStateMessageMakeCall(e);
                    break;
                case TalkControl.EnumDispatchCmdType.discCall:
                    HandleDispatchStateDiscCall(e);
                    break;
                case TalkControl.EnumDispatchCmdType.selectAnswer:
                    HandleDispatchStateSelectAnswer(e);
                    break;
                case TalkControl.EnumDispatchCmdType.holdCall:
                    HandleDispatchStateHoldCall(e);
                    break;
                default:
                    break;
            }
        }

        private void HandleDispatchStateMessageMakeCall(TalkControl.DispatchArgs e)
        {
            switch (e.DispatchStatus)
            {
                case TalkControl.EnumDispatchStatus.success:
                    //bc_OnMsg(string.Format("{0}呼叫{1}成功", Pub.GetDispatchNameByNumber(e.FromNumber), e.ToNumber));
                    DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.Call, e.FromNumber, e.ToNumber.ToString(), true);
                    RegionManage.GetInstance().UpdateMemberStatus(e.FromNumber.ToString(), TalkControl.EnumUserLineStatus.Busy);
                    break;
                case TalkControl.EnumDispatchStatus.released:
                case TalkControl.EnumDispatchStatus.failure:
                    //查找FromNumber对应的对方号码
                    DB_Talk.Model.Data_DispatchLog log = DispatchLogBLL.GetDispatchLog(PublicEnums.EnumNormalCmd.Call, e.FromNumber);
                    if (log != null)
                    {
                        RegionManage.GetInstance().UpdateMemberStatus(log.DispatchedNumbers.ToString(), TalkControl.EnumUserLineStatus.Idle);
                    }
                    break;
                case TalkControl.EnumDispatchStatus.userRinging:
                    if (e.ToNumber != 0)
                    {
                        //bc_OnMsg(string.Format("用户{0}振铃", e.ToNumber));
                    }
                    break;
                default:
                    break;
            }
        }

        private void HandleDispatchStateDiscCall(TalkControl.DispatchArgs e)
        {
            switch (e.DispatchStatus)
            {
                case TalkControl.EnumDispatchStatus.success:
                    //bc_OnMsg(string.Format("挂断{0}成功", e.ToNumber));
                    DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.Handup, e.FromNumber, e.ToNumber.ToString(), true);
                    break;
                case TalkControl.EnumDispatchStatus.released:
                    //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                    break;
                case TalkControl.EnumDispatchStatus.failure:
                    // bc_OnMsg(string.Format("挂断失败", e.ToNumber));
                    break;
                case TalkControl.EnumDispatchStatus.userRinging:
                    //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                    break;
                default:
                    break;
            }
        }

        private void HandleDispatchStateSelectAnswer(TalkControl.DispatchArgs e)
        {
            switch (e.DispatchStatus)
            {
                case TalkControl.EnumDispatchStatus.success:
                    break;
                case TalkControl.EnumDispatchStatus.released:
                    //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));
                    break;
                case TalkControl.EnumDispatchStatus.failure:
                    // bc_OnMsg(string.Format("呼叫{0}失败", e.ToNumber));
                    break;
                case TalkControl.EnumDispatchStatus.userRinging:
                    //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                    break;
                default:
                    break;
            }
        }

        private void HandleDispatchStateHoldCall(TalkControl.DispatchArgs e)
        {
            switch (e.DispatchStatus)
            {
                case TalkControl.EnumDispatchStatus.success:
                    //bc_OnMsg(string.Format("{0}保持呼叫成功", e.ToNumber));
                    DispatchLogBLL.UpdateLog(CommControl.PublicEnums.EnumNormalCmd.Keep, e.FromNumber, e.ToNumber.ToString(), true);
                    RegionManage.GetInstance().UpdateMemberStatus(e.FromNumber.ToString(), TalkControl.EnumUserLineStatus.Holding);
                    break;
                case TalkControl.EnumDispatchStatus.released:
                    //   bc_OnMsg(string.Format("呼叫{0}释放", e.ToNumber));

                    break;
                case TalkControl.EnumDispatchStatus.failure:
                    //bc_OnMsg(string.Format("保持呼叫失败"));
                    break;
                case TalkControl.EnumDispatchStatus.userRinging:
                    //  bc_OnMsg(string.Format("用户{0}振铃", e.FromNumber));
                    break;
                default:
                    break;
            }
        }

    }
}
