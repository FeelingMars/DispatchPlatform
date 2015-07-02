using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class IsolateMeetingMemberCommand : BaseCommand
    {
        public override bool Begin()
        {
            if (base.MemberControl.UserLineStatus == TalkControl.EnumUserLineStatus.Record)
            {
                RaiseOnMsg("录音中,隔离失败");
                return false;
            }

            return TalkSDK.MBOX_ConfIsolatePart(base.talkControl.handle, base.talkControl.CurrentMeetingID, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
        }
    }
}
