using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class KeepCommand : BaseCommand
    {
        public override bool Begin()
        {
            //if (Pub.CurrentDispatchControl.UserLineStatus== TalkControl.EnumUserLineStatus.Idle
            //    || Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.HookOn)
            //{
            //    RaiseOnMsg("请选择正确的手柄");
            //    return false;
            //}

            DispatchPlatform.Command.DispatchLogBLL.WriteLog(CommControl.PublicEnums.EnumNormalCmd.Keep, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number.ToString(), "");
            return TalkSDK.MBOX_HoldCall(base.talkControl.handle, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
        }
    }
}
