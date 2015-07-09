using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    class RegionGroupCallCommand
    {
        private string m_OraNumber = "";
        List<long> m_GroupMemberNumberList;
        private int m_Handle = 0;

        public RegionGroupCallCommand(int handle, string oraNumber, List<long> groupMemberNumberList)
        {
            m_Handle = handle;
            m_OraNumber = oraNumber;
            m_GroupMemberNumberList = groupMemberNumberList;
        }

        public bool Begin()
        {
            return TalkSDK.MBOX_GroupCall(m_Handle, Convert.ToInt64(m_OraNumber), m_GroupMemberNumberList.ToArray(), m_GroupMemberNumberList.Count);
        }
    }
}
