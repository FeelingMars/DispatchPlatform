using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class UnIsolateMeetingMemberCommand : BaseCommand
    {
        public override bool Begin()
        {
            if (base.MemberControl.UserLineStatus != TalkControl.EnumUserLineStatus.Isolate)
            {
                RaiseOnMsg("解除隔离失败");
                return false;
            }

            return TalkSDK.MBOX_ConfUnisolatePart(base.talkControl.handle, base.talkControl.CurrentMeetingID, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
        }
    }
}
