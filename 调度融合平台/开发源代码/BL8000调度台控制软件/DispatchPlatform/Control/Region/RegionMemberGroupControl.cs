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

namespace DispatchPlatform.Region
{
    internal partial class RegionMemberGroupControl : UserControl
    {
        #region 类内参数

        private IRegionMemberOperate m_CurrentMemberOperate;                    //成员操作接口
        private CommControl.PublicEnums.EnumRegionMemberType m_MemeberType;     //组内成员类型
        private List<RegionMemberInfo> m_DataCache = new List<RegionMemberInfo>();  //组内成员缓存
        private int m_GroupColumnCount = 3;                 //显示列数
        private int m_GroupRowCount = 3;                    //显示行数
        private int m_InnerControlSpace = 2;                //间距

        #endregion

        #region 公共属性

        /// <summary>
        /// 成员类型
        /// </summary>
        public CommControl.PublicEnums.EnumRegionMemberType MemberType
        {
            get { return m_MemeberType; }
        }

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

        #endregion

        #region 公共接口

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="regionID">区域ID</param>
        /// <param name="memberType"></param>
        public void LoadData(int regionID, CommControl.PublicEnums.EnumRegionMemberType memberType)
        {
            m_MemeberType = memberType;
            if (memberType == CommControl.PublicEnums.EnumRegionMemberType.Camera)
            {
                m_CurrentMemberOperate = new RegionMemberCameraOpeate<RegionCameraInfo>();
            }
            else
            {
                m_CurrentMemberOperate = new RegionMemberPhoneOpeate<RegionCallInfo>(memberType);
            }

            RegionMemberInfo[] memberDatas = m_CurrentMemberOperate.LoadData(regionID);
            if (memberDatas == null)
            {
                return;
            }
            foreach (RegionMemberInfo item in memberDatas)
            {
                m_DataCache.Add(item);
                RegionManage.GetInstance().RegeditMemberData(item);
            }

            int offCount = m_DataCache.Count % MaxViewMemberCount;

            this.indexControl.Init(m_DataCache.Count <= MaxViewMemberCount ?
                m_DataCache.Count == 0 ? -1 : 0 :
                m_DataCache.Count / MaxViewMemberCount + (offCount > 0 ? 0 : -1));

            LoadMemberControl();
            ResizeControl();
            InitInnerControl();
        }

        #endregion

        #region 事件处理

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

        private void memberControl_Click(object sender, EventArgs e)
        {
            m_CurrentMemberOperate.ClickOpeate(sender, e);
        }

        private void btnGroupCall_Click(object sender, EventArgs e)
        {
            if (MemberType != CommControl.PublicEnums.EnumRegionMemberType.Camera)
            {
                List<RegionCallInfo> phoneCallData = new List<RegionCallInfo>();
              
                foreach (RegionMemberInfo item in m_DataCache)
                {
                    phoneCallData.Add(item as RegionCallInfo);
                }
                (m_CurrentMemberOperate as RegionMemberPhoneOpeate<RegionCallInfo>).GroupCall(phoneCallData);
            }
        }

        #endregion

        /// <summary>
        /// 初始化内部控件
        /// </summary>
        private void InitInnerControl()
        {
            this.btnGroupCall.Visible = m_MemeberType != CommControl.PublicEnums.EnumRegionMemberType.Camera;
        }

        /// <summary>
        /// 初始化成员控件
        /// </summary>
        private void LoadMemberControl()
        {
            this.flowLayoutPanel.SuspendLayout();
            this.flowLayoutPanel.Controls.Clear();
            int index = this.indexControl.SelectIndex;
            //确定展示数量
            int startIndex = MaxViewMemberCount * index;
            //批量加载
            //int endIndex = m_DataCache.Count - 1 > (startIndex + m_GroupColumnCount * m_GroupRowCount) ?
            //    m_GroupColumnCount * m_GroupRowCount * (index + 1) :
            //    m_DataCache.Count - 1;
            //全部加载
            int endIndex = m_DataCache.Count - 1;
            for (int i = startIndex; i <= endIndex; i++)
            {
                RegionMemberInfo memberData = m_DataCache[i];
                if (!RegionManage.GetInstance().ExistMemberControl(memberData))
                {
                    RegionMemberControl control = CreateMemberControlByData(memberData);

                    RegionManage.GetInstance().RegeditMemberControl(control);
                    this.flowLayoutPanel.Controls.Add(control);
                }
                else
                {
                    RegionMemberControl control = RegionManage.GetInstance().FindControl(memberData.PrimaryKey);
                    this.flowLayoutPanel.Controls.Add(control);
                }
            }
            this.flowLayoutPanel.ResumeLayout();
        }

        /// <summary>
        /// 新建成员控件
        /// </summary>
        /// <param name="memberData"></param>
        /// <returns></returns>
        private RegionMemberControl CreateMemberControlByData(RegionMemberInfo memberData)
        {
            RegionMemberControl control = new RegionMemberControl(memberData);
            control.Click += new EventHandler(memberControl_Click);
            //原代码结构不变，从_memberManage中查找保存的原结构号码信息
            if (memberData.MemberType != CommControl.PublicEnums.EnumRegionMemberType.Camera)
            {
                SingleUserControl baseControl = Pub._memberManage.GetSingleControl(Convert.ToInt64(memberData.PrimaryKey));
                control.Tag.Name = baseControl.MemberName;
                (control.Tag as RegionCallInfo).DestNumber = baseControl.PeerNumber;
                (control.Tag as RegionCallInfo).UserLineStatus = baseControl.UserLineStatus;
            }
            return control;
        }

        private void ResizeControl()
        {
            if (this.IsHandleCreated)
            {
                this.flowLayoutPanel.SuspendLayout();
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
                this.flowLayoutPanel.ResumeLayout();
                this.ResumeLayout();
            }
        }

    }
}
