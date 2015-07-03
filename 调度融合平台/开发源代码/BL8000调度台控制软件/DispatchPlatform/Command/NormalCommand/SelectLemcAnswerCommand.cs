using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class SelectLemcAnswerCommand : BaseCommand
    {
        public override bool Begin()
        {
            DispatchPlatform.Command.DispatchLogBLL.WriteLog(CommControl.PublicEnums.EnumNormalCmd.SelectLemcAnser, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number.ToString(), "");
            
            return TalkSDK.MBOX_LemcSelectAnswer(base.talkControl.handle, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
        }
    }
}
