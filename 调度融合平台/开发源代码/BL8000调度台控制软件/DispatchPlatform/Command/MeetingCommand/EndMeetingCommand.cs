using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class EndMeetingCommand : BaseCommand
    {
        public override bool Begin()
        {
            return TalkSDK.MBOX_DelConf(base.talkControl.handle, base.talkControl.CurrentMeetingID, base.talkControl.CurrentDispatchNumber);
        }
    }
}
