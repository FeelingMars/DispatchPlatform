using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl;

namespace VoiceDispatchManage.Log
{
    public partial class frmAlarmLog : frmBase
    {
        public frmAlarmLog()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmAlarmLog_Load);
            
        }

        void frmAlarmLog_Load(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraEditorsLocalizationCHS();
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraGridLocalizationCHS();
            gridView1.ColumnFilterChanged += new EventHandler(gridView1_ColumnFilterChanged);
            //gridView1.FilterEditorCreated += new DevExpress.XtraGrid.Views.Base.FilterControlEventHandler(gridView1_FilterEditorCreated);
            gridControlEx1.InitView(this.gridView1);

            gridView1.OptionsView.ShowGroupPanel = false;          // 显示分组panel
            gridView1.OptionsCustomization.AllowGroup = false;     //是否允许分组

            gridControlEx1.AddCountGroup(DevExpress.Data.SummaryItemType.Count, "", "小计：{0:N0} 个");
            //gridControlEx1.SetGroup("AreaName", 1);
           
            LoadData();
            Global.Params.StyleManager.SetGridStyle(_tableName, this.gridView1);

          
        }

        void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            tslState.Text = " 共" + gridView1.RowCount.ToString() + "条记录";
        }

        private string _tableName = "vAlarmLogList";
        private void btnStyle_Click(object sender, EventArgs e)
        {
            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableName, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableName, this.gridView1);
        }

        private void tsStyle_Click(object sender, EventArgs e)
        {
            btnStyle_Click(null,null);
        }

        private int LoadData()
        {
            try
            {
                //string strW = "BoxID='" + Global.Params.BoxID + "'"; //and groupID='" + groupID + "'";
                List<DB_Talk.Model.v_Data_Alarm> list = new DB_Talk.BLL.v_Data_Alarm().GetModelList("");
                //DataTable dt = new DB_Talk.BLL.v_Data_Alarm().GetList("").Tables[0];
                if (list != null)
                {
                    gridControlEx1.DataSource = null;
                    gridControlEx1.DataSource = list;
                    gridView1.Columns["dt_DateTime"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    gridView1.Columns["dt_DateTime"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

                    //foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView1.Columns)
                    //{  
                    //}
                    gridView1.ClearSelection();
                    if (list.Count > 20) gridView1.OptionsView.ShowAutoFilterRow = true;
                }


                tslState.Text = " 共" + list.Count.ToString() + "条记录";
                return list.Count;
            }
            catch
            {
                return 0;
            }
         
        }
    }
}
