using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchPlatform.Data;

namespace DispatchPlatform
{
    class MemberCacheControl
    {
        private static MemberCacheControl m_Instance;
        private static object m_LockObj = new object();
        private Dictionary<string, RegionMemberInfo> m_ControlCache = new Dictionary<string, RegionMemberInfo>();

        private MemberCacheControl()
        {
           
        }

        public MemberCacheControl GetInstance()
        {
            if (m_Instance == null)
            {
                lock (m_LockObj)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new MemberCacheControl();
                    }
                }
            }

            return m_Instance;
        }

        public void RegeditControl(string number)
        {

        }
    }
}
