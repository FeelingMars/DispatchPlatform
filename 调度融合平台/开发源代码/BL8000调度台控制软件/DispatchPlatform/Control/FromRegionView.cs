using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DispatchPlatform.Data;

namespace DispatchPlatform
{
    public partial class FromRegionView : Form
    {
        private Dictionary<int, SingleRegionControl> m_RegionControlCache = new Dictionary<int, SingleRegionControl>();

        public FromRegionView()
        {
            InitializeComponent();
            this.Disposed += new EventHandler(FromRegionView_Disposed);
        }

        void FromRegionView_Disposed(object sender, EventArgs e)
        {
            RegionManage.GetInstance().Clear();
        }

        private void FromRegionView_Load(object sender, EventArgs e)
        {
            RegionDataInfo[] regionDatas = new RegionDataInfo[] { 
                new RegionDataInfo(){ RegionID = 1, Name = "test1"}};

            this.superTabControlRegion.Tabs.Clear();
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

        private void LazyLoadSingleRegion(int regionID)
        {
            m_RegionControlCache[regionID].LoadData(regionID);
        }

        private void btnRegionView_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
