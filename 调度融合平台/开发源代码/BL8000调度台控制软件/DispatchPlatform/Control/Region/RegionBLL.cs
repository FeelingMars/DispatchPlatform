using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchPlatform.Data;

namespace DispatchPlatform.Region
{
    internal class RegionBLL
    {
        internal RegionDataInfo[] GetRegionDataInfo(int boxID)
        {
            List<DB_Talk.Model.m_RegionInfo> dataList = new DB_Talk.BLL.m_RegionInfo().GetModelList(string.Format("BoxID = {0}", boxID));

            List<RegionDataInfo> queryDataList = new List<RegionDataInfo>();

            foreach (DB_Talk.Model.m_RegionInfo sqlData in dataList)
            {
                RegionDataInfo data = new RegionDataInfo();
                data.RegionID = sqlData.ID;
                data.Name = sqlData.vc_Name;
                data.Memo = sqlData.vc_Memo;
                data.IncludePersonCount = sqlData.i_IncludePersonCount;
                queryDataList.Add(data);
            }

            return queryDataList.ToArray();
        }

        internal RegionMemberInfo[] GetRegionMemberData(int regionID, CommControl.PublicEnums.EnumRegionMemberType memberType)
        {
            List<RegionMemberInfo> queryDataList = new List<RegionMemberInfo>();

            if (memberType == CommControl.PublicEnums.EnumRegionMemberType.Camera)
            {
                List<DB_Talk.Model.m_CameraInfo> dataList = new DB_Talk.BLL.m_RegionRelation().QueryCameraMemberList(
                    string.Format("RegionID = {0} and i_RelationType = {1}", regionID, (int)memberType));

                foreach (DB_Talk.Model.m_CameraInfo sqlData in dataList)
                {
                    RegionCameraInfo data = new RegionCameraInfo();
                    data.UserLineStatus = TalkControl.EnumUserLineStatus.Offline;
                    data.ID = sqlData.ID;
                    data.Name = sqlData.vc_Name;
                    data.PrimaryKey = sqlData.vc_Name;
                    data.Number = sqlData.vc_Name;
                    data.ChannelID = (int)sqlData.i_ChanelID; 
                    data.MemberType = CommControl.PublicEnums.EnumRegionMemberType.Camera;
                    queryDataList.Add(data);
                }
            }
            else
            {
                List<DB_Talk.Model.m_Member> dataList = new DB_Talk.BLL.m_RegionRelation().QueryPhoneMemeberList(
                    string.Format("RegionID = {0} and i_RelationType = {1}", regionID, (int)memberType));

                foreach (DB_Talk.Model.m_Member sqlData in dataList)
                {
                    RegionCallInfo data = new RegionCallInfo();
                    data.ID = sqlData.ID;
                    data.Name = sqlData.vc_Name;
                    data.MemberType = (CommControl.PublicEnums.EnumRegionMemberType)sqlData.i_TellType;
                    data.PrimaryKey = sqlData.i_Number.ToString();
                    data.Number = sqlData.i_Number.ToString();

                    queryDataList.Add(data);
                }
            }

            return queryDataList.ToArray();
        }
    }
}
