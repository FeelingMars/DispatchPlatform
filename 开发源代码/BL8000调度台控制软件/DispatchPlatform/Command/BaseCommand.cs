using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;


namespace DispatchPlatform.Command
{
    public class BaseCommand
    {
        public SingleUserControl MemberControl = new SingleUserControl();

        public TalkControl talkControl = new TalkControl();

        /// <summary>返回结果</summary>
        public TalkSDK.OPERATE_RESULT t;

        public event MsgDelegate OnMsg;

        public delegate void MsgDelegate(string msg);

        public void RaiseOnMsg(string s)
        {
            if (OnMsg != null)
            {
                OnMsg(s);
            }
        }

        public virtual bool Begin()
        {
            return true;
        }

        /// <summary>
        /// 检查调度号码
        /// </summary>
        /// <returns></returns>
        public bool CheckDispatch()
        {
            if (talkControl.CurrentDispatchNumber == null || talkControl.CurrentDispatchNumber == 0)
            {
                RaiseOnMsg("请先选择调度号码");
                return false;
            }
            return true;
        }
     
    }
}
