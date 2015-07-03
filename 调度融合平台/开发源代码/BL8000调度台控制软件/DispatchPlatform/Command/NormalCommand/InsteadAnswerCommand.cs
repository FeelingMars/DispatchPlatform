using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    /// <summary>
    /// 代答
    /// </summary>
    public class InsteadAnswerCommand : BaseCommand
    {
        public override bool Begin()
        {
            if (base.MemberControl.UserLineStatus!= TalkControl.EnumUserLineStatus.Ring)
            {
                RaiseOnMsg("代答失败");
                return false;
            }
            //if (Pub.CurrentDispatchControl.UserLineStatus != TalkControl.EnumUserLineStatus.Idle 
            //    || Pub.CurrentDispatchControl.UserLineStatus != TalkControl.EnumUserLineStatus.HookOn)
            //{
            //    RaiseOnMsg("请选择空闲手柄");
            //    return false;
            //}
            DispatchPlatform.Command.DispatchLogBLL.WriteLog(CommControl.PublicEnums.EnumNormalCmd.InsteadAnswer, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number.ToString(), "");
            return TalkSDK.MBOX_InsteadAnswer(base.talkControl.handle, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
        }
    }
}
