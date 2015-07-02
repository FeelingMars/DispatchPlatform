using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    /// <summary>
    /// 强拆
    /// </summary>
    public class SnatchCommand : BaseCommand
    {
        public override bool Begin()
        {
            if (MemberControl.UserLineStatus != TalkControl.EnumUserLineStatus.Busy)
            {
                RaiseOnMsg(string.Format("强拆失败"));
                return false;
            }

            //if (Pub.CurrentDispatchControl.UserLineStatus != TalkControl.EnumUserLineStatus.Idle
            //   || Pub.CurrentDispatchControl.UserLineStatus != TalkControl.EnumUserLineStatus.HookOn)
            //{
            //    RaiseOnMsg("请选择空闲手柄");
            //    return false;
            //}
            //base.MemberControl.IsCalling = false;
            //Pub.CurrentDispatchControl.IsCalling = true;//设调度为主叫

          //  base.MemberControl.IsCalling = false;
          //  Pub.CurrentDispatchControl.IsCalling = true;//设调度为主叫

            if (Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.Record)
            {
                RaiseOnMsg("录音中,强拆失败");
                return false;
            }
            DispatchPlatform.Command.DispatchLogBLL.WriteLog(CommControl.PublicEnums.EnumNormalCmd.SnatchCall, base.talkControl.CurrentDispatchNumber, Pub.GetDispatchedNumbers(base.MemberControl.Number), "");
            return TalkSDK.MBOX_SnatchCall(base.talkControl.handle, base.talkControl.CurrentDispatchNumber, base.MemberControl.Number);
        }
    }
}
