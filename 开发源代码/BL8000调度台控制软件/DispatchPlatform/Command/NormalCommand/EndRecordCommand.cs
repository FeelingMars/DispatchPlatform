using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class EndRecordCommand : BaseCommand
    {
        public override bool Begin()
        {
            DispatchPlatform.Command.DispatchLogBLL.WriteLog(CommControl.PublicEnums.EnumNormalCmd.EndRecord, base.talkControl.CurrentDispatchNumber, Pub.GetDispatchedNumbers(base.MemberControl.Number), "");
            return TalkSDK.MBOX_StopRecordCall(base.talkControl.handle,base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
          
        }
    }
}
