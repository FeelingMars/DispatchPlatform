using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    public class AddMeetingMemberCommand : BaseCommand
    {
        public override bool Begin()
        {
            bool b = false;
            if (3 > 2)
            {
                List<long> lst = new List<long>();
                StringBuilder sb = new StringBuilder();
                foreach (DB_Talk.Model.m_Member item in base.talkControl.NumberList)
                {
                    lst.Add(item.i_Number.Value);
                    sb.Append(item.i_Number.Value + ",");
                }

                if (sb.Length > 0)
                {
                    sb = sb.Remove(sb.Length - 1, 1);
                }
                b = TalkSDK.MBOX_ConfAddPart(base.talkControl.handle, base.talkControl.CurrentMeetingID, base.talkControl.CurrentDispatchNumber, lst.ToArray(), base.talkControl.NumberList.Count);
            }
            else
            {
                //if (base.MemberControl.UserLineStatus != TalkControl.EnumUserLineStatus.Idle)
                //{
                //    RaiseOnMsg("邀请失败,当前用户不为空闲");
                //    return false;
                //}
            }
            
            return b;
        }
    }
}
