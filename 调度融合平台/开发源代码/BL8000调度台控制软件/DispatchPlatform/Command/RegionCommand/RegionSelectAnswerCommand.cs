using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MBoxSDK;

namespace DispatchPlatform.Command
{
    class RegionSelectAnswerCommand
    {
        private string m_OraNumber = "";
        private string m_DestNumber = "";
        private int m_Handle = 0;

        public RegionSelectAnswerCommand(int handle, string oraNumber, string destNumber)
        {
            m_Handle = handle;
            m_OraNumber = oraNumber;
            m_DestNumber = destNumber;
        }

        public  bool Begin()
        {
            return TalkSDK.MBOX_SelectAnswer(m_Handle, Convert.ToInt64(m_OraNumber), Convert.ToInt64(m_DestNumber));
        }
    }
}
