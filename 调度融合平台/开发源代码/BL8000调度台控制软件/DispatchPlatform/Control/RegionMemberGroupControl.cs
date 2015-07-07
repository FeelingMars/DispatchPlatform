using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DispatchPlatform.Data;
using DispatchPlatform.Region;
using System.Diagnostics;

namespace DispatchPlatform.Control
{
    internal partial class RegionMemberGroupControl : UserControl
    {
        private IRegionMemberOperate m_CurrentOperate;
        private List<RegionMemberInfo> m_DataCache = new List<RegionMemberInfo>();
        /// <summary>
        /// 显示列数
        /// </summary>
        private int m_GroupColumnCount = 3;
        /// <summary>
        /// 显示行数
        /// </summary>
        private int m_GroupRowCount = 3;
        /// <summary>
        /// 间距
        /// </summary>
        private int m_InnerControlSpace = 2;

        public RegionMemberGroupControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 最大显示成员数
        /// </summary>
        public int MaxViewMemberCount
        {
            get
            {
                return m_GroupColumnCount * m_GroupRowCount;
            }
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

            int offCount = m_DataCache.Count % MaxViewMemberCount;

            this.indexControl.Init(m_DataCache.Count <= MaxViewMemberCount ?
                0 :
                m_DataCache.Count / MaxViewMemberCount + (offCount > 0 ? 0 : -1));

            LoadMemberControl();
            ResizeControl();
        }

        private void InitMemberControl()
        {

        }

        private void flowLayoutPanel_Resize(object sender, EventArgs e)
        {
            this.ResizeControl();
        }

        private void indexControl_SelectIndexChanged(object sender, Event.SelectIndexChangeEventArgs e)
        {
            this.Cursor = Cursors.Hand;
            int currentIndex = e.Index;
            LoadMemberControl();

            ResizeControl();

            this.Cursor = Cursors.Default;
        }

        private void LoadMemberControl()
        {
            this.flowLayoutPanel.Controls.Clear();
            int index = this.indexControl.SelectIndex;
            //确定展示数量

            int startIndex = MaxViewMemberCount * index;
            int endIndex = m_DataCache.Count - 1 > (startIndex + m_GroupColumnCount * m_GroupRowCount) ?
                m_GroupColumnCount * m_GroupRowCount * (index + 1) :
                m_DataCache.Count - 1;
            for (int i = startIndex; i <= endIndex; i++)
            {
                RegionMemberInfo memberData = m_DataCache[i];
                string primaryKey = memberData.PrimaryKey;
                if (!RegionManage.GetInstance().ExistMember(primaryKey))
                {
                    RegionMemberControl control = CreateMemberControlByData(memberData);
                    RegionManage.GetInstance().RegeditMemberControl(control);
                    this.flowLayoutPanel.Controls.Add(control);
                }
                else
                {
                    RegionMemberControl control = RegionManage.GetInstance().FindControl(primaryKey);
                    this.flowLayoutPanel.Controls.Add(control);
                }
            }
        }

        private RegionMemberControl CreateMemberControlByData(RegionMemberInfo memberData)
        {
            RegionMemberControl control = new RegionMemberControl(memberData);
            control.Appearance = MemberAppearance.Create(memberData.MemberType);
            return control;
        }

        private void LazyLoadRegionMember()
        {

        }

        private void ResizeControl()
        {
            this.SuspendLayout();
            int wholeWidth = this.flowLayoutPanel.Width;
            int singleWidth = (wholeWidth - 2 * m_GroupColumnCount * m_InnerControlSpace) / m_GroupColumnCount;
            int wholeHeigh = this.flowLayoutPanel.Height;
            int singleHeigh = (wholeHeigh - 2 * m_GroupRowCount * m_InnerControlSpace) / m_GroupRowCount;
            foreach (System.Windows.Forms.Control item in this.flowLayoutPanel.Controls)
            {
                item.Width = singleWidth;
                item.Height = singleHeigh;
                item.Margin = new Padding(m_InnerControlSpace, m_InnerControlSpace, m_InnerControlSpace, m_InnerControlSpace);
            }
            this.ResumeLayout(true);
        }

    }

    internal class RegionMemberGroup
    {

    }
}
