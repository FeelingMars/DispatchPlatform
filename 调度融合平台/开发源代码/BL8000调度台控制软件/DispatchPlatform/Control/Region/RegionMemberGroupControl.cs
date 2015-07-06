using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DispatchPlatform.Data;

namespace DispatchPlatform.Control
{
    internal partial class RegionMemberGroupControl : UserControl
    {
        private IRegionMemberOperate m_CurrentOperate;
        private List<RegionMemberInfo> m_DataCache = new List<RegionMemberInfo>();
        private int m_GroupViewCount = 9;                 //Group内显示的成员数
        private Dictionary<int, RegionMemberControl<RegionMemberInfo>> m_MemeberControlCache = new Dictionary<int, RegionMemberControl<RegionMemberInfo>>();

        public RegionMemberGroupControl()
        {
            InitializeComponent();
        }

        public void LoadData(int regionID, CommControl.PublicEnums.EnumRegionMemberType memberType)
        {
            if (memberType == CommControl.PublicEnums.EnumRegionMemberType.Camera)
            {
                m_CurrentOperate = new RegionMemberCameraOpeate();
            }
            else
            {
                m_CurrentOperate = new RegionMemberPhoneOpeate(memberType);
            }

            RegionMemberInfo[] memberDatas = m_CurrentOperate.LoadData(regionID);
            if (memberDatas == null)
            {
                return;
            }
            foreach (RegionMemberInfo item in memberDatas)
            {
                m_DataCache.Add(item);
            }
        }

        private void InitMemberControl()
        {

        }

        private void flowLayoutPanel_Resize(object sender, EventArgs e)
        {

        }

        private void indexControl_SelectIndexChanged(object sender, Event.SelectIndexChangeEventArgs e)
        {
            int currentIndex = e.Index;
        }
    }

    internal class RegionMemberGroup
    {

    }
}
