using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchPlatform.Control;
using DispatchPlatform.Data;
using DispatchPlatform.Region;

namespace DispatchPlatform
{
    class RegionManage
    {
        private static RegionManage m_Instance;
        private static object m_LockObj = new object();
        private Dictionary<string, RegionMemberControl> m_ControlCache = new Dictionary<string, RegionMemberControl>();


        private RegionManage()
        {
        }

        public static RegionManage GetInstance()
        {
            if (m_Instance == null)
            {
                lock (m_LockObj)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new RegionManage();
                    }
                }
            }

            return m_Instance;
        }

        public RegionMemberControl FindControl(string primaryKey)
        {
            return m_ControlCache[primaryKey];
        }

        public bool ExistMember(string primaryKey)
        {
            return m_ControlCache.ContainsKey(primaryKey);
        }

        public void RegeditMemberControl(RegionMemberControl RegionMemberControl)
        {
            m_ControlCache.Add(RegionMemberControl.Tag.PrimaryKey, RegionMemberControl);
        }

        /// <summary>
        /// 更新成员显示状态
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="status"></param>
        public void UpdateMemberStatus(string primaryKey, TalkControl.EnumUserLineStatus status)
        {
            if (m_ControlCache.ContainsKey(primaryKey))
            {
                m_ControlCache[primaryKey].UserLineStatus = status;
            }

            //Pub.UpdateSingleUserContorlFont(s);
        }

        public void UpdateMemberDestNumber(string primaryKey, string destNumber)
        {
            if (m_ControlCache.ContainsKey(primaryKey))
            {
                m_ControlCache[primaryKey].PeerNumber = destNumber;
            }
            //Pub.UpdateSingleUserContorlFont(_tempSingleControl);
        }

        public void Clear()
        {
            m_ControlCache.Clear();
        }

    }
}
