using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    /// <summary>
    /// 解除禁言
    /// </summary>
    public class NoSpeekMeetingMemberCommand : BaseCommand
    {
        public override bool Begin()
        {
            if (base.MemberControl.UserLineStatus!= TalkControl.EnumUserLineStatus.Forbid)
            {
                RaiseOnMsg("解除禁言失败");
                return false;
            }

           

            return TalkSDK.MBOX_ConfUnforbidPart(base.talkControl.handle, base.talkControl.CurrentMeetingID, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
        }
    }
}
