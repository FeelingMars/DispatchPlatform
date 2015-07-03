using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class BeginRecordCommand : BaseCommand
    {
        public override bool Begin()
        {
            if (CheckDispatch())
            {
                if (base.MemberControl.UserLineStatus == TalkControl.EnumUserLineStatus.Isolate)
                {
                    RaiseOnMsg("隔离中,录音失败");
                    return false;
                }

                if (base.MemberControl.UserLineStatus == TalkControl.EnumUserLineStatus.Forbid)
                {
                    RaiseOnMsg("禁言中,录音失败");
                    return false;
                }


                DispatchPlatform.Command.DispatchLogBLL.WriteLog(CommControl.PublicEnums.EnumNormalCmd.BeginRecord, base.talkControl.CurrentDispatchNumber,Pub.GetDispatchedNumbers( base.MemberControl.Number), "");
                return TalkSDK.MBOX_StartRecordCall(base.talkControl.handle, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
            }
            return false;
        }
    }
}
