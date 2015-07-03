using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class MakeCallCommand : BaseCommand
    {
        public int Number { get; set; }

        public override bool Begin()
        {
            if (CheckDispatch())
            {

                long n = 0;
                try
                {
                    n = base.MemberControl.Number;
                }
                catch (Exception)
                {
                    n = Number;
                }
                if (base.MemberControl.NumberState == "连接中")
                {
                    RaiseOnMsg("呼叫失败");
                    return false;
                }
                if (Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.Idle 
                    || Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.HookOn
                    || Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.Holding)
                {
                    Pub.CurrentDispatchControl.IsCalling = true;
                    DispatchPlatform.Command.DispatchLogBLL.WriteLog(CommControl.PublicEnums.EnumNormalCmd.Call, base.talkControl.CurrentDispatchNumber, n.ToString(), "");
                }
                else
                {
//                    CommControl.MessageBoxEx.MessageBoxEx.Show("当前手柄不可用，请选择空闲手柄", "拨打失败");
                    RaiseOnMsg("请选择空闲手柄");
                    return false;
                }

               
                return  TalkSDK.MBOX_MakeCall(base.talkControl.handle, base.talkControl.CurrentDispatchNumber,n);
            }

            return false;
        }
    }
}
