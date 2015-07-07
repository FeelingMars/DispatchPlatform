using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchPlatform.Data;

namespace DispatchPlatform
{
    interface IRegionMemberOperate
    {
        CommControl.PublicEnums.EnumRegionMemberType MemberType { get; }
        void ClickOpeate();
        RegionMemberInfo[] LoadData(int regionID);
    }

    internal class RegionMemberPhoneOpeate : IRegionMemberOperate
    {
        public RegionMemberPhoneOpeate(CommControl.PublicEnums.EnumRegionMemberType memberType)
        {
            if (memberType != CommControl.PublicEnums.EnumRegionMemberType.Radio &&
                memberType != CommControl.PublicEnums.EnumRegionMemberType.TelPhone &&
                memberType != CommControl.PublicEnums.EnumRegionMemberType.WiFiPhone)
            {
                throw new ArgumentException("memberType 类型错误。");
            }

            MemberType = memberType;
        }
        public void ClickOpeate()
        {
            throw new NotImplementedException();
        }

        public RegionMemberInfo[] LoadData(int regionID)
        {
            //test
            List<RegionBillInfo> testData = new List<RegionBillInfo>();

            for (int i = 0; i < 150; i++)
            {
                testData.Add(new RegionBillInfo()
                {
                    ID = i,
                    MemberType = this.MemberType,
                    Name = MemberType.ToString() + i,
                    OraNumber = MemberType.ToString() + i,
                    PrimaryKey = MemberType.ToString() + i
                });
            }


            return testData.ToArray();
        }

        public CommControl.PublicEnums.EnumRegionMemberType MemberType
        {
            get;
            private set;
        }
    }

    internal class RegionMemberCameraOpeate : IRegionMemberOperate
    {
        public RegionMemberCameraOpeate()
        {
            MemberType = CommControl.PublicEnums.EnumRegionMemberType.Camera;
        }

        public void ClickOpeate()
        {
            throw new NotImplementedException();
        }

        public RegionMemberInfo[] LoadData(int regionID)
        {
            return null;
        }

        public CommControl.PublicEnums.EnumRegionMemberType MemberType
        {
            get;
            private set;
        }
    }



}
