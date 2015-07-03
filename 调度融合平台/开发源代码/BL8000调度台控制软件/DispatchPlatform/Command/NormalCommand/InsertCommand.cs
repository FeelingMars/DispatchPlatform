using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class InsertCommand : BaseCommand
    {
        public override bool Begin()
        {
            if (MemberControl.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
            {
                RaiseOnMsg(string.Format("{0}为空闲状态，强插失败", MemberControl.Number));
                return false;
            }

            if (MemberControl.IsMeeting==true)
            {
                RaiseOnMsg(string.Format("无法对会议中的成员进行强插"));
                return false;
            }

            //if (MemberControl.UserLineStatus== TalkControl.EnumUserLineStatus.Insert)
            //{
            //    RaiseOnMsg(string.Format("强插失败"));
            //    return false;
            //}

            if (MemberControl.UserLineStatus == TalkControl.EnumUserLineStatus.Record)
            {
                RaiseOnMsg(string.Format("录音中,强插失败"));
                return false;
            }
             
            if (Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.Record              )
            {
                RaiseOnMsg("录音中,强插失败");
                return false;
            }

            if (Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.Ring)
            {
                RaiseOnMsg("强插失败");
                return false;
            }



            //if (Pub.CurrentDispatchControl.UserLineStatus != TalkControl.EnumUserLineStatus.Idle
            //   || Pub.CurrentDispatchControl.UserLineStatus != TalkControl.EnumUserLineStatus.HookOn)
            //{
            //    RaiseOnMsg("请选择空闲手柄");
            //    return false;
            //}

            DispatchPlatform.Command.DispatchLogBLL.WriteLog(CommControl.PublicEnums.EnumNormalCmd.Insert, base.talkControl.CurrentDispatchNumber, Pub.GetDispatchedNumbers(base.MemberControl.Number), "");
            return TalkSDK.MBOX_InsertCall(base.talkControl.handle, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
        }
    }
}
