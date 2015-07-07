using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DispatchPlatform.Control;

namespace DispatchPlatform
{
    public partial class SingleRegionControl : UserControl
    {
        private List<RegionMemberGroupControl> m_RegionMemberGroupControls = new List<RegionMemberGroupControl>();
        private int m_RegionID = 0;
        /// <summary>
        /// 间距
        /// </summary>
        private int m_InnerControlSpace = 2;

        /// <summary>
        /// 是否加载完成
        /// </summary>
        [DefaultValue(false)]
        public bool LoadFinish
        {
            get;
            private set;
        }

        public SingleRegionControl()
        {
            InitializeComponent();
        }

        public void LoadData(int regionID)
        {
            m_RegionID = regionID;
            regionMemberPanelControlGW.LoadData(regionID, CommControl.PublicEnums.EnumRegionMemberType.TelPhone);
            regionMemberPanelControlPhone.LoadData(regionID, CommControl.PublicEnums.EnumRegionMemberType.WiFiPhone);
            regionMemberPanelControlRadio.LoadData(regionID, CommControl.PublicEnums.EnumRegionMemberType.Radio);
            regionMemberPanelControlCamera.LoadData(regionID, CommControl.PublicEnums.EnumRegionMemberType.Camera);
            m_RegionMemberGroupControls.Add(this.regionMemberPanelControlGW);
            m_RegionMemberGroupControls.Add(this.regionMemberPanelControlRadio);
            m_RegionMemberGroupControls.Add(this.regionMemberPanelControlPhone);
            m_RegionMemberGroupControls.Add(this.regionMemberPanelControlCamera);

            //todo

            LoadFinish = true;
        }

        private void SingleRegionControl_Load(object sender, EventArgs e)
        {
        }

        private void SingleRegionControl_Resize(object sender, EventArgs e)
        {
            ResizeInnerControl();
        }

        private void ResizeInnerControl()
        {
            this.SuspendLayout();
            int wholeWidth = this.Width;
            //单个长度 = （总长度-（控件个数）*间隙）/控件个数
            int singleWidth = m_RegionMemberGroupControls.Count > 0 ? (wholeWidth - 2 * 2 * m_InnerControlSpace) / 2 : wholeWidth;
            int wholeHeigh = this.Height;
            int singleHeigh = m_RegionMemberGroupControls.Count > 0 ? (wholeHeigh - 2 * 2 * m_InnerControlSpace) / 2 : wholeHeigh;
            foreach (var item in m_RegionMemberGroupControls)
            {
                item.Width = singleWidth;
                item.Height = singleHeigh;
                item.Margin = new Padding(m_InnerControlSpace, m_InnerControlSpace, m_InnerControlSpace, m_InnerControlSpace);
            }
            this.ResumeLayout(true);
        }
    }
}
