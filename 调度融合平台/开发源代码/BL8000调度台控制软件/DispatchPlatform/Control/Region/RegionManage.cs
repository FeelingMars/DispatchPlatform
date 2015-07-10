using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchPlatform.Control;
using DispatchPlatform.Data;
using DispatchPlatform.Region;

namespace DispatchPlatform.Region
{
    class RegionManage
    {
        private static RegionManage m_Instance;
        private static object m_LockObj = new object();
        private Dictionary<string, RegionMemberInfo> m_MemeberDataCache = new Dictionary<string, RegionMemberInfo>();
        private RegionDataControlMapping m_ControlMapping = new RegionDataControlMapping();

        private RegionCallInfo m_LeftDispatchNumber;
        private RegionCallInfo m_RightDispathchNumber;

        private RegionManage()
        {
            List<DB_Talk.Model.m_Member> disPatchNumberList = new DB_Talk.BLL.m_Member().GetModelList(string.Format("boxID={0} and i_isdispatch=1 and i_Flag=0", Pub.manageModel.BoxID));
            if (disPatchNumberList.Count >= 2)
            {
                m_LeftDispatchNumber = new RegionCallInfo();
                m_LeftDispatchNumber.ID = disPatchNumberList[0].ID;
                m_LeftDispatchNumber.MemberType = (CommControl.PublicEnums.EnumRegionMemberType)disPatchNumberList[0].i_TellType;
                m_LeftDispatchNumber.IsCalling = false;
                m_LeftDispatchNumber.Name = disPatchNumberList[0].vc_Name;
                m_LeftDispatchNumber.PrimaryKey = disPatchNumberList[0].i_Number.ToString();
                m_LeftDispatchNumber.Number = disPatchNumberList[0].i_Number.ToString();
                this.RegeditMemberData(m_LeftDispatchNumber);
                //从原始结构中查找状态
                SingleUserControl baseControl = Pub._memberManage.GetSingleControl(Convert.ToInt64(Pub.manageModel.LeftDispatchNumber));
                m_LeftDispatchNumber.Name = baseControl.MemberName;
                m_LeftDispatchNumber.DestNumber = baseControl.PeerNumber;
                m_LeftDispatchNumber.UserLineStatus = baseControl.UserLineStatus;

                m_RightDispathchNumber = new RegionCallInfo();
                m_RightDispathchNumber.ID = disPatchNumberList[1].ID;
                m_RightDispathchNumber.MemberType = (CommControl.PublicEnums.EnumRegionMemberType)disPatchNumberList[1].i_TellType;
                m_RightDispathchNumber.IsCalling = false;
                m_RightDispathchNumber.Name = disPatchNumberList[1].vc_Name;
                m_RightDispathchNumber.PrimaryKey = disPatchNumberList[1].i_Number.ToString();
                m_RightDispathchNumber.Number = disPatchNumberList[1].i_Number.ToString();
                this.RegeditMemberData(m_RightDispathchNumber);
                //从原始结构中查找状态
                SingleUserControl rightControl = Pub._memberManage.GetSingleControl(Convert.ToInt64(Pub.manageModel.RightDispatchNumber));
                m_RightDispathchNumber.Name = baseControl.MemberName;
                m_RightDispathchNumber.DestNumber = baseControl.PeerNumber;
                m_RightDispathchNumber.UserLineStatus = baseControl.UserLineStatus;
            }
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
            return m_ControlMapping[primaryKey];
        }

        public bool ExistMemberControl(RegionMemberInfo memberData)
        {
            if (m_MemeberDataCache.ContainsKey(memberData.PrimaryKey))
            {
                return m_ControlMapping.Exist(memberData.PrimaryKey);
            }
            else
            {
                throw new ArgumentNullException("memberData未注册。");
            }
        }

        public bool ExistMember(string memberKey)
        {
            return m_MemeberDataCache.ContainsKey(memberKey);
        }

        public void RegeditMemberData(RegionMemberInfo memberData)
        {
            if (!m_MemeberDataCache.ContainsKey(memberData.PrimaryKey))
            {
                m_MemeberDataCache.Add(memberData.PrimaryKey, memberData);
            }
            else
            {
                throw new Exception(string.Format("memberData：{0} 已注册。", memberData.PrimaryKey));
            }
        }

        public void RegeditMemberControl(RegionMemberControl regionMemberControl)
        {
            if (!m_MemeberDataCache.ContainsKey(regionMemberControl.Tag.PrimaryKey))
            {
                throw new ArgumentNullException("regionMemberControl对应的数据尚未注册。");
            }
            if (!m_ControlMapping.Exist(regionMemberControl.Tag.PrimaryKey))
            {
                m_ControlMapping.RegeditControl(regionMemberControl);
            }
        }

        public RegionCallInfo GetDispatchNumber()
        {
            if (m_LeftDispatchNumber != null && m_LeftDispatchNumber.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
            {
                return m_LeftDispatchNumber;
            }
            if (m_RightDispathchNumber != null && m_RightDispathchNumber.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
            {
                return m_RightDispathchNumber;
            }

            return null;
        }

        /// <summary>
        /// 更新成员显示状态
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="status"></param>
        public void UpdateMemberStatus(string primaryKey, TalkControl.EnumUserLineStatus status)
        {
            if (m_MemeberDataCache.ContainsKey(primaryKey))
            {
                (m_MemeberDataCache[primaryKey] as RegionCallInfo).UserLineStatus = status;
            }


            //RegionMemberControl control = FindControl(primaryKey);
            //if (control != null)
            //{
            //    (control.Tag as RegionCallInfo).UserLineStatus = status;
            //    control.UpdateControlFont();
            //}
        }

        public void UpdateMemberDestNumber(string primaryKey, string destNumber)
        {
            if (m_MemeberDataCache.ContainsKey(primaryKey))
            {
                (m_MemeberDataCache[primaryKey] as RegionCallInfo).DestNumber = destNumber;
            }
            //RegionMemberControl control = FindControl(primaryKey);
            //if (control != null)
            //{
            //    (control.Tag as RegionCallInfo).DestNumber = destNumber;
            //    control.UpdateControlFont();
            //}
        }

        public void UpdateMemberStatus(string primaryKey, string status)
        {
            if (m_MemeberDataCache.ContainsKey(primaryKey))
            {
                (m_MemeberDataCache[primaryKey] as RegionCallInfo).NumberStatus = status;
            }
            //RegionMemberControl control = FindControl(primaryKey);
            //if (control != null)
            //{
            //    (control.Tag as RegionCallInfo).NumberStatus = status;
            //    control.UpdateControlFont();
            //}
        }

        public void Dispose()
        {
            m_MemeberDataCache.Clear();
            m_ControlMapping.Clear();
            m_Instance = null;
        }

    }

    internal class RegionDataControlMapping
    {
        private Dictionary<string, RegionMemberControl> m_ControlCache = new Dictionary<string, RegionMemberControl>();

        public bool Exist(string key)
        {
            return m_ControlCache.ContainsKey(key);
        }

        public RegionMemberControl this[string key]
        {
            get
            {
                if (m_ControlCache.ContainsKey(key))
                {
                    return m_ControlCache[key];
                }
                else
                {
                    return null;
                }
            }
        }

        public void RegeditControl(RegionMemberControl control)
        {
            m_ControlCache.Add(control.Tag.PrimaryKey, control);
        }

        public void Clear()
        {
            m_ControlCache.Clear();
        }
    }
}
