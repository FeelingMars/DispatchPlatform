using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DispatchPlatform.Region;
using DispatchPlatform.Data;

namespace DispatchPlatform.Region
{
    internal partial class SingleRegionControl : UserControl
    {
        private List<RegionMemberGroupControl> m_RegionMemberGroupControls = new List<RegionMemberGroupControl>();      //区域成员组控件缓存

        private int m_InnerControlSpace = 2;            //组控件间距

        #region 属性

        /// <summary>
        /// 区域数据
        /// </summary>
        internal new RegionDataInfo Tag { get; set; }

        /// <summary>
        /// 是否加载完成
        /// </summary>
        [DefaultValue(false)]
        public bool LoadFinish
        {
            get;
            private set;
        }
        #endregion

        public SingleRegionControl()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            regionMemberPanelControlGW.LoadData(Tag.RegionID, CommControl.PublicEnums.EnumRegionMemberType.TelPhone);
            regionMemberPanelControlPhone.LoadData(Tag.RegionID, CommControl.PublicEnums.EnumRegionMemberType.WiFiPhone);
            regionMemberPanelControlRadio.LoadData(Tag.RegionID, CommControl.PublicEnums.EnumRegionMemberType.Radio);
            regionMemberPanelControlCamera.LoadData(Tag.RegionID, CommControl.PublicEnums.EnumRegionMemberType.Camera);
            m_RegionMemberGroupControls.Add(this.regionMemberPanelControlGW);
            m_RegionMemberGroupControls.Add(this.regionMemberPanelControlRadio);
            m_RegionMemberGroupControls.Add(this.regionMemberPanelControlPhone);
            m_RegionMemberGroupControls.Add(this.regionMemberPanelControlCamera);

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
            if (this.IsHandleCreated && this.Visible)
            {
                this.flowLayoutPanel1.SuspendLayout();
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
                this.flowLayoutPanel1.ResumeLayout();
            }
        }

        private void regionMemberPanelControlPhone_Click(object sender, EventArgs e)
        {

        }
    }
}
