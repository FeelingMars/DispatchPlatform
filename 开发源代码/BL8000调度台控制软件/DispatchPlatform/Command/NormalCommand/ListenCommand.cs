using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class ListenCommand : BaseCommand
    {
        public override bool Begin()
        {
            if (MemberControl.UserLineStatus != TalkControl.EnumUserLineStatus.Busy )
            {
                RaiseOnMsg(string.Format("监听失败"));
                return false;
            }
            if (MemberControl.IsMeeting)
            {
                RaiseOnMsg(string.Format("监听失败"));
                return false;
            }
            //if (Pub.CurrentDispatchControl.UserLineStatus != TalkControl.EnumUserLineStatus.Idle
            //   || Pub.CurrentDispatchControl.UserLineStatus != TalkControl.EnumUserLineStatus.HookOn)
            //{
            //    RaiseOnMsg("请选择空闲手柄");
            //    return false;
            //}

            if (base.MemberControl.PeerNumber=="0"  )
            {
                RaiseOnMsg("监听失败");
                return false;
            }

            if ( base.MemberControl.UserLineStatus== TalkControl.EnumUserLineStatus.Insert           
                )
            {
                RaiseOnMsg("监听失败");
                return false;
            }

            if (Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.Ring)
            {
                RaiseOnMsg("监听失败");
                return false;
            }

            DispatchPlatform.Command.DispatchLogBLL.WriteLog(CommControl.PublicEnums.EnumNormalCmd.Listen, base.talkControl.CurrentDispatchNumber, Pub.GetDispatchedNumbers(base.MemberControl.Number), "");
            return TalkSDK.MBOX_MonitorCall(base.talkControl.handle, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
          
        }
    }
}
