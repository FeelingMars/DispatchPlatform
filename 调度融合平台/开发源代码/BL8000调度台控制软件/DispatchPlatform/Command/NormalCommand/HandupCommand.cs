using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class HandupCommand : BaseCommand
    {
        public override bool Begin()
        {
            bool b = false;
            if (MemberControl.IsMeeting == true)
            {
                RaiseOnMsg(string.Format("无法对会议中成员进行挂断"));
                return false;
            }

            if (MemberControl.NumberState == "连接中" && MemberControl.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
            {
               // Pub._memberManage.SetMemberState(MemberControl.Number, "空闲");
                Pub._memberManage.UpdateMemberState(MemberControl.Number, TalkControl.EnumUserLineStatus.Idle);
                TalkSDK.MBOX_DisconnectCall(base.talkControl.handle, base.talkControl.CurrentDispatchNumber, base.talkControl.CurrentDispatchNumber);
            }
            else
            {
                DispatchPlatform.Command.DispatchLogBLL.WriteLog(CommControl.PublicEnums.EnumNormalCmd.Handup, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number.ToString(), "");
                 b = TalkSDK.MBOX_DisconnectCall(base.talkControl.handle, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
            }
            // Console.WriteLine("end handup");

            return b;

        }
    }
}
