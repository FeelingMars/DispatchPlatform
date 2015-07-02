using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    /// <summary>
    /// 禁言
    /// </summary>
    public class OkSpeekMeetingMemberCommand : BaseCommand
    {
        public override bool Begin()
        {
            if (base.MemberControl.UserLineStatus == TalkControl.EnumUserLineStatus.Record)
            {
                RaiseOnMsg("录音中,禁言失败");
                return false;
            }
            return TalkSDK.MBOX_ConfForbidPart(base.talkControl.handle, base.talkControl.CurrentMeetingID, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
          
        }
    }
}
