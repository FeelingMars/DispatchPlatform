using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class DeleteMeetingMemberCommand : BaseCommand
    {
        public override bool Begin()
        {
            return TalkSDK.MBOX_ConfDelPart(base.talkControl.handle, base.talkControl.CurrentMeetingID, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
        
        }
    }
}
