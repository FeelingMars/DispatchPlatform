using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchPlatform.Control;
using DispatchPlatform.Data;

namespace DispatchPlatform
{
    class RegionMemberManage<T> where T : RegionMemberInfo
    {
        private static RegionMemberManage<T> m_Instance;
        private static object m_LockObj = new object();
        private Dictionary<string, RegionMemberControl<T>> m_ControlCache = new Dictionary<string, RegionMemberControl<T>>();


        private RegionMemberManage()
        {
            m_Instance = new RegionMemberManage<T>();
        }

        public static RegionMemberManage<T> GetInstance()
        {
            if (m_Instance == null)
            {
                lock (m_LockObj)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new RegionMemberManage<T>();
                    }
                }
            }

            return m_Instance;
        }

        public void RegeditMemberControl(RegionMemberControl<T> RegionMemberControl)
        {
            m_ControlCache.Add(RegionMemberControl.Tag.PrimaryKey, RegionMemberControl);
        }

        public void Clear()
        {
            m_ControlCache.Clear();
        }

    }
}
