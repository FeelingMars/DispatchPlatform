using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl;

namespace VoiceDispatchManage.UI
{
    public partial class frmGroupMember : frmBase
    {
        public int operate=0;
        public StringBuilder sbMemberID = new StringBuilder();
        private int priorCount=0;
        public int groupID = 0;
        public int RecordCount=0;
        public string GroupName = "";
        public CommControl.PublicEnums.EnumGroupType GroupType;
        public frmGroupMember(int _groupID, string _GroupName,StringBuilder _sbMemberID,int _priorCount,CommControl.PublicEnums.EnumGroupType _GroupType)
        {
            InitializeComponent();
            this.FormTitle = "增加";
            groupID = _groupID;
            sbMemberID = _sbMemberID;
            priorCount = _priorCount;
            GroupName = _GroupName;
            GroupType=_GroupType;
            RecordCount= LoadData();
        }

        private void frmGroupMember_Load(object sender, EventArgs e)
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
           
            Global.Params.StyleManager.SetGridStyle(_tableName, this.gridView1);
        }

        void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            tslState.Text = " 共" + gridView1.RowCount.ToString() + "条记录";
        }

  
       

        private string _tableName = "vMemberList";
        private void btnStyle_Click(object sender, EventArgs e)
        {
            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableName, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableName, this.gridView1);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.gridView1.SelectAll();
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            //this.gridView1.fo..ClearSelection();//.FocusedRowHandle = null;
            
            for (int i = 0; i < list.Count ; i++)
            {
                if (gridView1.IsRowSelected(i))
                {
                    this.gridView1.UnselectRow(i);
                }
                else
                {
                    //gridView1.FocusedRowHandle = i;
                    this.gridView1.SelectRow(i);
                }
            }
            //int[] SelectRowHandles = gridView1.GetSelectedRows();
            //foreach (int RowHandle in SelectRowHandles)
            //{
            //    this.gridView1.UnselectRow(RowHandle);
            //}
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DB_Talk.BLL.m_GroupMembers bll=new DB_Talk.BLL.m_GroupMembers();
          
            int[] selectRow = gridView1.GetSelectedRows();
            if (selectRow.Length == 0)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要添加的人员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //if((selectRow.Length + priorCount) < 2)
            //{
            //    CommControl.MessageBoxEx.MessageBoxEx.Show("分组中至少需要两个人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    return;
            //}
            if (GroupType == CommControl.PublicEnums.EnumGroupType.Meeting)
            {
                if ((selectRow.Length + priorCount) > Global.Params.MaxGroupMemberCount)//Global.Params.ConfigModel.SystemConfig.MaxGroupMemberCount)
                {
                    string mes = "";
                    if (priorCount > 0)
                    {
                        mes = "该组已经有【" + priorCount + "】个人员,";
                        mes += "最多可再添加【" + (Global.Params.MaxGroupMemberCount - priorCount) + "】个,请重新选择！";
                    }
                    else
                    {
                        mes = "该组最多只能添加【" + Global.Params.MaxGroupMemberCount + "】个人员,请重新选择！";
                    }
                    CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            foreach(int i in selectRow)
            {
                object obj=gridView1.GetRow(i);
                DB_Talk.Model.v_Member vModel=obj as DB_Talk.Model.v_Member;
                if(vModel!=null)
                {
                    DB_Talk.Model.m_GroupMembers model=new DB_Talk.Model.m_GroupMembers();
                    model.BoxID=Global.Params.BoxID;
                    model.GroupID =groupID;
                    model.MemberID=vModel.ID;
                    if (!bll.Exists("BoxID='" + model.BoxID + "' and GroupID='" + model.GroupID + "' and MemberID='"+model.MemberID+"'"))
                    {
                        bll.Add(model);
                        CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Add, "添加", "会议【" + GroupName + "】中添加了人员：" + vModel.vc_Name, "");
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }

        }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        List<DB_Talk.Model.v_Member> list = new List<DB_Talk.Model.v_Member>();
        private int LoadData()
        {
            string strW = "i_flag=0 and BoxID='" + Global.Params.BoxID + "' and i_IsDispatch=0 "; //and groupID='" + groupID + "'";
            if (sbMemberID.Length > 0)
            {
                strW += "and ID not in (" + sbMemberID.ToString() + ")";
            }
            list = new DB_Talk.BLL.v_Member().GetModelList(strW);
            string level = "";
            foreach (DB_Talk.Model.v_Member item in list)
            {
                if (item.LevelID == null) level = "";
                else level = ((PublicEnums.EnumLevel)item.LevelID).ToString();
                item.LevelName = level;
            }
            if (list != null)
            {
                gridControlEx1.DataSource = null;
                gridControlEx1.DataSource = list;
                gridView1.ClearSelection();
                if (list.Count > 20) gridView1.OptionsView.ShowAutoFilterRow = true;
            }
            tslState.Text = " 共" + list.Count.ToString() + "条记录";
            return list.Count;
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            tsSelect.Text = " 共选中" + gv.SelectedRowsCount.ToString() + "条记录";
        }

    }
}
