using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class MakeMeetingCommand:BaseCommand
    {
        public override bool Begin()
        {
            List<long> lst = new List<long>();
            StringBuilder sb = new StringBuilder();
            foreach (DB_Talk.Model.m_Member item in base.talkControl.NumberList)
            {
                lst.Add(item.i_Number.Value);
                sb.Append(item.i_Number.Value + ",");
            }
            if (sb.Length>0)
            {
                sb = sb.Remove(sb.Length - 1, 1);
            }
            if (lst.Count == 0)
            {
                RaiseOnMsg("创建会议失败，会议成员为空");
                return false;
            }

            //if (Pub.CurrentDispatchControl.UserLineStatus== TalkControl.EnumUserLineStatus.HookOn)
            //{
            //    RaiseOnMsg("创建会议失败，创建会议时");
            //    return false ;
            //}
            RaiseOnMsg("正在创建会议");
            //DispatchPlatform.Command.DispatchLogBLL.WriteLog(CommControl.PublicEnums.EnumNormalCmd.MakeLemcMeeting, base.talkControl.CurrentDispatchNumber, sb.ToString(), "");
            return TalkSDK.MBOX_CreateConf(base.talkControl.handle, base.talkControl.CurrentDispatchNumber, lst.ToArray(), base.talkControl.NumberList.Count);
          
        }
    }
}
