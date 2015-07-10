using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchPlatform.Event;

namespace DispatchPlatform.Data
{
    internal abstract class RegionMemberInfo
    {
        internal CommControl.PublicEnums.EnumRegionMemberType MemberType { get; set; }
        internal int ID { get; set; }
        internal string Name { get; set; }
        internal string PrimaryKey { get; set; }
        internal string Number { get; set; }
        internal event EventHandler<PropertyChangedEventArgs> ProrertyChanged;
        protected void OnPropertyChange(int index)
        {
            if (ProrertyChanged != null)
            {
                ProrertyChanged(this, new PropertyChangedEventArgs() { Index = index });
            }
        }
    }

    internal class RegionCallInfo : RegionMemberInfo
    {
        private string m_DestNumber = "";
        private DispatchPlatform.TalkControl.EnumUserLineStatus m_UserLineStatus = TalkControl.EnumUserLineStatus.Offline;
        private bool m_IsCall = true;              //主叫、被叫
        private string m_NumberStatus = "";

        internal string DestNumber
        {
            get { return m_DestNumber; }
            set
            {
                m_DestNumber = value;
                OnPropertyChange(0);
            }
        }

        internal DispatchPlatform.TalkControl.EnumUserLineStatus UserLineStatus
        {
            get { return m_UserLineStatus; }
            set
            {
                m_UserLineStatus = value;
                OnPropertyChange(1);
            }
        }

        internal string NumberStatus
        {
            get { return m_NumberStatus; }
            set
            {
                m_NumberStatus = value;
                OnPropertyChange(2);
            }
        }

        internal bool IsCalling
        {
            get { return m_IsCall; }
            set
            {
                m_IsCall = value;
                OnPropertyChange(3);
            }
        }


    }

    internal class RegionCameraInfo : RegionMemberInfo
    {
        private DispatchPlatform.TalkControl.EnumUserLineStatus m_UserLineStatus = TalkControl.EnumUserLineStatus.Offline;
        internal DispatchPlatform.TalkControl.EnumUserLineStatus UserLineStatus
        {
            get { return m_UserLineStatus; }
            set
            {
                m_UserLineStatus = value;
                OnPropertyChange(1);
            }
        }
        internal int ChannelID { get; set; }
        internal string ChannelIP { get; set; }
    }

    internal class RegionDataInfo
    {
        internal int RegionID { get; set; }
        internal string Name { get; set; }
        internal string Memo { get; set; }
        internal int IncludePersonCount { get; set; }
    }
}
