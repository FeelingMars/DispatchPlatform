using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class TransferCommand : BaseCommand
    {
        public override bool Begin()
        {
            //if (Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.Idle
            //  || Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.HookOn)
            //{
            //    RaiseOnMsg("请选择正确的手柄");
            //    return false;
            //}

            //用户打调度时显示录音些时无法转接，所以注释2014-6-18
            ////if ( Pub.CurrentDispatchControl.UserLineStatus== TalkControl.EnumUserLineStatus.Record)
            ////{
            ////    RaiseOnMsg("录音中,转接失败");
            ////    return false;
            ////}
            base.MemberControl.IsCalling = false;
            DispatchPlatform.Command.DispatchLogBLL.WriteLog(CommControl.PublicEnums.EnumNormalCmd.Transfer, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number.ToString(), "");
            return TalkSDK.MBOX_DeliverCall(base.talkControl.handle, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
        }
    }
}
