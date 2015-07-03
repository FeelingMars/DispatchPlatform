using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class SelectAnswerCommand : BaseCommand
    {
        public override bool Begin()
        {
            DispatchPlatform.Command.DispatchLogBLL.WriteLog(CommControl.PublicEnums.EnumNormalCmd.SelectAnser, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number.ToString(), "");
            base.MemberControl.IsCalling = true;
            Pub.CurrentDispatchControl.IsCalling = false;
            return TalkSDK.MBOX_SelectAnswer(base.talkControl.handle, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
        }
    }
}
