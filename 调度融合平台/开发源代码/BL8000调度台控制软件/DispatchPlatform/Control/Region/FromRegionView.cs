using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DispatchPlatform.Data;
using DispatchPlatform.Region;

namespace DispatchPlatform
{
    public partial class FromRegionView : Form
    {
        private Dictionary<int, SingleRegionControl> m_RegionControlCache = new Dictionary<int, SingleRegionControl>(); //区域控件缓存
        public event EventHandler ApplicationExit;          //程序退出事件

        public FromRegionView()
        {
            InitializeComponent();
        }

        #region 内部事件处理

        private void FromRegionView_Load(object sender, EventArgs e)
        {
            lblTitle.Text = Pub._configModel.Title;     //初始化标题
            RegionTalkControl.GetInstance().RegeditTalk();          //注册talk回调事件处理
            this.superTabControlRegion.Tabs.Clear();

            RegionDataInfo[] regionDatas = new RegionDataInfo[] { 
                new RegionDataInfo(){ RegionID = 1, Name = "test1"}};

            if (regionDatas == null)
                return;

            foreach (RegionDataInfo data in regionDatas)
            {
                CreateRegionControlByData(data);
            }
        }

        private void superTabControlRegion_SelectedTabChanging(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangingEventArgs e)
        {
            DevComponents.DotNetBar.SuperTabItem currentItem = e.NewValue as DevComponents.DotNetBar.SuperTabItem;

            RegionDataInfo regionData = currentItem.Tag as RegionDataInfo;

            if (!m_RegionControlCache[regionData.RegionID].LoadFinish)
            {
                //未加载
                //需要进行数据加载
                LazyLoadSingleRegion(regionData.RegionID);
            }
        }

        private void btnRegionView_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FromRegionView_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegionTalkControl.GetInstance().UnregeditTalk();
            RegionManage.GetInstance().Dispose();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ApplicationExit != null)
            {
                ApplicationExit(this, EventArgs.Empty);
            }
        }

        #endregion

        #region 内部功能函数

        /// <summary>
        /// 根据区域数据创建区域控件
        /// </summary>
        /// <param name="data"></param>
        private void CreateRegionControlByData(RegionDataInfo data)
        {
            SingleRegionControl regionControl = new SingleRegionControl();
            regionControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(48)))));
            regionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            m_RegionControlCache.Add(data.RegionID, regionControl);

            DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel = new DevComponents.DotNetBar.SuperTabControlPanel();
            superTabControlPanel.Controls.Add(regionControl);
            this.superTabControlRegion.Controls.Add(superTabControlPanel);
            DevComponents.DotNetBar.SuperTabItem currentTab = new DevComponents.DotNetBar.SuperTabItem();

            currentTab.SelectedTabFont = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
            superTabLinearGradientColorTable1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(48))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(113)))), ((int)(((byte)(130)))))};
            DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable superTabItemStateColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable();
            superTabItemStateColorTable1.Background = superTabLinearGradientColorTable1;
            DevComponents.DotNetBar.Rendering.SuperTabColorStates superTabColorStates1 = new DevComponents.DotNetBar.Rendering.SuperTabColorStates();
            superTabColorStates1.Selected = superTabItemStateColorTable1;
            DevComponents.DotNetBar.Rendering.SuperTabItemColorTable superTabItemColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable();
            superTabItemColorTable1.Bottom = superTabColorStates1;
            currentTab.TabColor = superTabItemColorTable1;

            currentTab.AttachedControl = superTabControlPanel;
            currentTab.GlobalItem = false;
            currentTab.Text = data.Name;
            currentTab.Tag = data;
            this.superTabControlRegion.Tabs.Add(currentTab);


            currentTab.TabFont = new Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            currentTab.SelectedTabFont = new Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            currentTab.TabColor = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable()
            {
                Default = new DevComponents.DotNetBar.Rendering.SuperTabColorStates()
                {
                    Normal = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable()
                    {
                        Background = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
                        {
                            Colors = new System.Drawing.Color[] { Pub.TabNormalColor }
                        },
                        Text = Color.White
                    },
                    Selected = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable()
                    {
                        Background = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
                        {
                            Colors = new System.Drawing.Color[] { Pub.TabSelectColor }
                        },
                        Text = Color.Black
                    },
                    MouseOver = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable()
                    {
                        Background = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
                        {
                            Colors = new System.Drawing.Color[] { Color.White, Color.FromArgb(255, 192, 128) }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// 延迟加载单个区域控件及内部成员
        /// </summary>
        /// <param name="regionID"></param>
        private void LazyLoadSingleRegion(int regionID)
        {
            m_RegionControlCache[regionID].LoadData(regionID);
        }

        #endregion
    }
}
