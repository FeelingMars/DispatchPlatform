using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VoiceDispatchManage.UI
{
    public partial class frmGroupManage : UserControlMid
    {

        CommControl.PublicEnums.EnumGroupType GroupType;
        string strGroupType = "";
        private string _tableName = "GroupList";
        private string _tableNameMember = "GroupMemberList";
        private int _selectLeftListIndex = -1;
        string Reportfile = ""; 

        public frmGroupManage(CommControl.PublicEnums.EnumGroupType _GroupType)
        {
            InitializeComponent();
            this.Text = "分组管理";
            this.Load += new EventHandler(frmGroupManage_Load);
            GroupType = _GroupType;
            switch (GroupType)
            {
                case CommControl.PublicEnums.EnumGroupType.none:
                    break;
                case CommControl.PublicEnums.EnumGroupType.Normal:
                    this.Text = "调度分组";
                    break;
                case CommControl.PublicEnums.EnumGroupType.Meeting:
                    this.Text = "会议分组";
                    break;
                case CommControl.PublicEnums.EnumGroupType.SMS:
                    break;
                case CommControl.PublicEnums.EnumGroupType.Camera:
                    this.Text = "摄像头分组";                    
                    break;
                default:
                    break;
            }
            this.dgvRight.MultiSelect = true;
        }

        Tools.AcNetUtilsManage AcrManage = new Tools.AcNetUtilsManage();

        void frmGroupManage_Load(object sender, EventArgs e)
        {
           
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvLeft);
           
            string error = "";
            string file = ""; 
           
            switch (GroupType)
            {
                case CommControl.PublicEnums.EnumGroupType.none:
                    strGroupType = "";
                    break;
                case CommControl.PublicEnums.EnumGroupType.Normal:
                    strGroupType = "调度分组信息表";
                    file = Global.Params.FILE_PATH_REPORT + "调度分组信息表.apt";
                    //Tools.AcrReportManage.Current.SetReportFile("调度分组信息表.apt");
                    break;
                case CommControl.PublicEnums.EnumGroupType.Meeting:
                    strGroupType = "会议分组信息表";
                    file = Global.Params.FILE_PATH_REPORT + "会议分组信息表.apt";
                    //Tools.AcrReportManage.Current.SetReportFile("会议分组信息表.apt");
                    break;
                case CommControl.PublicEnums.EnumGroupType.SMS:
                    strGroupType = "短信分组信息表";
                    file = Global.Params.FILE_PATH_REPORT + "短信分组信息表.apt";
                    //Tools.AcrReportManage.Current.SetReportFile("短信分组信息表.apt");
                    break;
                case CommControl.PublicEnums.EnumGroupType.Camera:
                    strGroupType = "摄像头分组信息表";
                    file = Global.Params.FILE_PATH_REPORT + "摄像头分组信息表.apt";
                    break;
                default:
                    break;
            }
            Reportfile = strGroupType;
           
            try
            {
                LoadDataLeft();
                AcrManage.Init(file, out error);
                //LoadReport();
            }
            catch
            {
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            DB_Talk.Model.m_Group m = new DB_Talk.Model.m_Group();
            m.BoxID = Global.Params.BoxID.ToString();
            m.GroupTypeID = GroupType.GetHashCode();
            frmGroup fu = new frmGroup(m, 0);
            fu.ShowDialog();
            if (fu.DialogResult == DialogResult.OK)
                LoadDataLeft();
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvLeft.SelectedRows.Count > 0)
            {
                DB_Talk.Model.m_Group typeModel = (DB_Talk.Model.m_Group)dgvLeft.CurrentRow.Tag;
                if (typeModel != null)
                {
                    if (typeModel.vc_Name == Global.Params.gruopNormalName)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("【" + Global.Params.gruopNormalName + "】不可以删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (CommControl.MessageBoxEx.MessageBoxEx.Show("确认要删除 【" + typeModel.vc_Name + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        
                        if (new DB_Talk.BLL.m_Group().DeleteEx(typeModel.ID))
                        {
                            new DB_Talk.BLL.m_GroupMembers().Delete(" BoxID='" + typeModel.BoxID + "' and GroupID='" + typeModel.ID + "'");
                            CommControl.MessageBoxEx.MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Delete, "删除", "删除了会议【" + typeModel.vc_Name + "】以及其组成员", "");
                            
                            LoadDataLeft();
                            LoadDataRight();

                        }
                        else
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要删除的会议", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvLeft.SelectedRows.Count > 0)
            {
                DB_Talk.Model.m_Group Model = (DB_Talk.Model.m_Group)dgvLeft.CurrentRow.Tag;
                if (Model != null)
                {
                    if (Model.vc_Name == Global.Params.gruopNormalName)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("【" + Global.Params.gruopNormalName + "】不可以修改！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    frmGroup fu = new frmGroup(Model, 1);
                    fu.ShowDialog();
                    if (fu.DialogResult == DialogResult.OK)
                        LoadDataLeft();
                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要编辑的会议", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadDataLeft();

        }
        private void btnStyle_Click(object sender, EventArgs e)
        {
            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableName, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvLeft);
            //Tools.AcrReportManage.Current.AddVariable(this.dgvLeft);
            //AcrManage.AddVariable(this.dgvLeft);
     
        }
        private void dgvLeft_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                _selectLeftListIndex = e.RowIndex;
                LoadDataRight();
                btnAddRight.Enabled = true;
            }
        }
        private void dgvLeft_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColumnIndex >= 0)
            {
                _selectLeftListIndex = e.RowIndex;
                LoadDataRight();
                btnAddRight.Enabled = true;
                dgvLeft_SelectionChanged(null, null);
            }
        }
        private void dgvLeft_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgvLeft.SelectedRows.Count >= 1)
            //{
            //    btnAddRight.Enabled = true;
            //    btnDelRight.Enabled = true;
            //    btnClearAll.Enabled = true;

            //}
            //else
            //{
            //    btnAddRight.Enabled = false;
            //    btnDelRight.Enabled = false;
            //    btnClearAll.Enabled = false;
            //}

           
        }
        private void btnAddRight_Click(object sender, EventArgs e)
        {
            if (dgvLeft.Rows.Count == 0)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请先添加组！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (_selectLeftListIndex < 0)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请先选择组！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            int GroupID = int.Parse(dgvLeft.Rows[_selectLeftListIndex].Cells["colID"].Value.ToString());
            string GroupName = dgvLeft.Rows[_selectLeftListIndex].Cells["colName"].Value.ToString();
            if (GroupType == CommControl.PublicEnums.EnumGroupType.Meeting)
            {
                DB_Talk.Model.m_Box model= new DB_Talk.BLL.m_Box().GetModel("i_Flag=0 and ID='" + Global.Params.BoxID + "'");
                if (model.i_MaxMeetingMember != null && model.i_MaxMeetingMember>0) Global.Params.MaxGroupMemberCount = (int)model.i_MaxMeetingMember;
                if (dgvRight.Rows.Count >= Global.Params.MaxGroupMemberCount)
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("该组人员已经到达最大限制【" + Global.Params.MaxGroupMemberCount + "】个，不能再添加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            
            //frm.groupID = int.Parse(GroupID);

            UI.frmGroupMember frm = new frmGroupMember(GroupID, GroupName, sbMemberID, dgvRight.Rows.Count, GroupType);
            if (frm.RecordCount > 0)
            {
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    LoadDataRight();
            }
            else if(frm.RecordCount ==0)
            {
                string mes="";
                if (dgvRight.Rows.Count > 0) mes = "所有人员已经加入组!";
                else mes = "该"+Global.Params.BOXNAME+"下无用户！";
                CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
        private void btnDelRight_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<DB_Talk.Model.v_GroupMembers> list = new List<DB_Talk.Model.v_GroupMembers>();
            foreach (DataGridViewRow dr in dgvRight.SelectedRows)
            {
                DB_Talk.Model.v_GroupMembers Model = (DB_Talk.Model.v_GroupMembers)dr.Tag; // dgvList.CurrentRow.Tag;
                list.Add(Model);
                sb.Append("," + Model.ID);
            }

            if (list.Count > 1)
            {
                if (sb.Length > 0) sb.Remove(0, 1);
                if (CommControl.MessageBoxEx.MessageBoxEx.Show("确认要删除选中的 【" + list.Count + "】个组成员吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (new DB_Talk.BLL.m_GroupMembers().DeleteList(sb.ToString()))
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadDataRight();
                    }
                    else
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (list.Count == 1)
            {
                if (CommControl.MessageBoxEx.MessageBoxEx.Show("确认要删除 【" + list[0].vc_Name + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (new DB_Talk.BLL.m_GroupMembers().Delete(list[0].ID))
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadDataRight();
                    }
                    else
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要删除的组成员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }
    
        private void btnRefushRight_Click(object sender, EventArgs e)
        {
            LoadDataRight();
        }
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            List<DB_Talk.Model.v_GroupMembers> list = new List<DB_Talk.Model.v_GroupMembers>();
            foreach (DataGridViewRow dr in dgvRight.Rows)
            {
                DB_Talk.Model.v_GroupMembers Model = (DB_Talk.Model.v_GroupMembers)dr.Tag; // dgvList.CurrentRow.Tag;
                list.Add(Model);
                sb.Append("," + Model.ID);
            }

            if (list.Count > 0)
            {
                if (sb.Length > 0) sb.Remove(0, 1);
                if (CommControl.MessageBoxEx.MessageBoxEx.Show("确认要清空 【" + list.Count + "】个组成员吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (new DB_Talk.BLL.m_GroupMembers().DeleteList(sb.ToString()))
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        LoadDataRight();
                    }
                    else
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("该组没有成员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnStyleRight_Click(object sender, EventArgs e)
        {

            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableNameMember, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableNameMember, this.dgvRight);
            //AcrManage.AddVariable(this.dgvRight);
            //Tools.AcrReportManage.Current.AddVariable(dgvLeft);
            //Tools.AcrReportManage.Current.AddVariable(dgvRight);
        }

      
        public int LoadDataLeft()
        {
            dgvLeft.Rows.Clear();
            List<DB_Talk.Model.m_Group> lst = new List<DB_Talk.Model.m_Group>();
            lst = new DB_Talk.BLL.m_Group().GetModelList("i_Flag=0 and GroupTypeID='" + 
                                                       GroupType.GetHashCode() + "' and BoxID='"+Global.Params.BoxID+"'" );
           
            int i = 0;
            foreach (DB_Talk.Model.m_Group item in lst)
            {
                i++;
                List<DB_Talk.Model.v_GroupMembers> lstMember = new DB_Talk.BLL.v_GroupMembers().GetModelList(" GroupID='" + item.ID+ 
                                                               "' and BoxID='" + Global.Params.BoxID + "'");
                dgvLeft.Rows[dgvLeft.Rows.Add(i,
                    item.vc_Name,
                    item.vc_Memo,
                    lstMember.Count,
                    item.ID
                    )].Tag = item;
            }
            kryptonHeaderGroup1.ValuesSecondary.Heading = "  共" + dgvLeft.Rows.Count.ToString() + "条记录";
            if (lst.Count == 0) _selectLeftListIndex = -1;
            // Tools.AcrReportManage.Current.RefushDataset(true);
            //loadReport();
            return lst.Count;
        }

 
        StringBuilder sbMemberID = new StringBuilder();
        public int LoadDataRight()
        {
            if (dgvLeft.Rows.Count == 0) dgvRight.Rows.Clear();
            if (_selectLeftListIndex < 0) return 0;
            sbMemberID.Clear();
            dgvRight.Rows.Clear();
            try
            {
                string GroupID = dgvLeft.Rows[_selectLeftListIndex].Cells["colID"].Value.ToString();

                List<DB_Talk.Model.v_GroupMembers> lst = new List<DB_Talk.Model.v_GroupMembers>();
                lst = new DB_Talk.BLL.v_GroupMembers().GetModelList(" GroupID='" + GroupID + "' and BoxID='" + Global.Params.BoxID + "'");
                int i = 0;
                foreach (DB_Talk.Model.v_GroupMembers item in lst)
                {
                    i++;
                    dgvRight.Rows[dgvRight.Rows.Add(i,
                        item.vc_Name,
                        item.i_Number,
                        item.vc_Memo,
                        item.ID
                        )].Tag = item;
                    sbMemberID.Append("," + item.MemberID);
                }
                if (sbMemberID.Length > 0) sbMemberID.Remove(0, 1);
                kryptonHeaderGroup2.ValuesSecondary.Heading = "  共" + dgvRight.Rows.Count.ToString() + "条记录";
                dgvLeft.Rows[_selectLeftListIndex].Cells["colMemberCount"].Value = dgvRight.Rows.Count;
            }
            catch { }
           
            return dgvLeft.Rows.Count;
        }
       
        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (LoadReport())
            {
                string mes = AcrManage.Print();
                if (mes != "")
                    CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //if (loadReport())
            //  Tools.AcrReportManage.Current.Print();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (LoadReport())
            {
                string mes = AcrManage.Preview();
                if (mes != "")
                    CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //if (loadReport())
            //  Tools.AcrReportManage.Current.PreView();
        }

        private void btnDesigner_Click(object sender, EventArgs e)
        {
            if (LoadReport())
            {
                string mes = AcrManage.ShowDesigner();
                if (mes != "")
                    CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             //if(loadReport())
             // Tools.AcrReportManage.Current.ShowDesigner();
             
        }

        private bool LoadReport()
        {
            try
            {
                AcrManage.AddVariable(this.dgvLeft);
                AcrManage.AddVariable(this.dgvRight);
                AcrManage.FillDataTableToAcFromGridView(this.dgvLeft, "m_Group");
                string strW = ("i_Flag=0 and BoxID='" + Global.Params.BoxID + "' and GroupTypeID='" + GroupType.GetHashCode() + "'");
                string sql = "select GroupID, vc_Name as 名称,i_Number as 电话,vc_Memo as 备注" +
                         " from v_GroupMembers where " + strW;
                DataSet ds = new DB_Talk.BLL.v_GroupMembers().GetListSql(sql);
                ds.Tables[0].TableName = "v_GroupMembers";
                AcrManage.CopyDataTableToAC(ds.Tables[0]);
                return true;
            }
            catch
            {
                return false;
            }
           
           
        }

        /*
       private bool loadReport()
       {
           bool result=false;
           try
           {
               Tools.AcrReportManage.Current.Init(Global.Params.ConfigModel.DBInfo.HostID,
                                                      Global.Params.ConfigModel.DBInfo.DatabaseName,
                                                      Global.Params.ConfigModel.DBInfo.Password,
                                                      Global.Params.FILE_PATH_REPORT);
               Tools.AcrReportManage.Current.SetReportFile(Reportfile); //"会议分组信息表.apt");

               string strW = ("i_Flag=0 and BoxID='" + Global.Params.BoxID + "' and GroupTypeID='" + GroupType.GetHashCode() + "'");
               string sql = "select " +
                        "ID, vc_Name as 名称,vc_Memo as 备注" +
                        " from m_Group" + " where " + strW;

               DataSet dsGroup = new DB_Talk.BLL.m_Group().GetList("i_Flag=0 and GroupTypeID='" +
                                                         GroupType.GetHashCode() + "' and BoxID='" + Global.Params.BoxID + "'");
               dsGroup.Tables[0].TableName = "m_Group";

               string strW1 = ("i_Flag=0 and BoxID='" + Global.Params.BoxID + "' and GroupTypeID='" + GroupType.GetHashCode() + "'");
               string sql1 = "select " +
                        "GroupID as ID, vc_Name as 名称,i_Number as 电话,vc_Memo as 备注" +
                        " from v_GroupMembers" +
                        " as a" +
                        " where " + strW1;
               DataSet ds = new DB_Talk.BLL.v_GroupMembers().GetListSql(sql1);
               ds.Tables[0].TableName = "v_GroupMembers";

               //AcNetUtils.AcRecordsetAdapter RecordAdp = new AcNetUtils.AcRecordsetAdapter(dsGroup.Tables["m_Group"]);
               //Tools.AcrReportManage.Current.mac.AddNetAdoData("m_Group", RecordAdp);

               Tools.AcrReportManage.Current.AddDatasetsToAC(sql, "m_Group");
               Tools.AcrReportManage.Current.AddDatasetsDetailToAC(sql1, "v_GroupMembers");

               Tools.AcrReportManage.Current.AddVariable(dgvLeft);
               Tools.AcrReportManage.Current.AddVariable(dgvRight);
               Tools.AcrReportManage.Current.AddVariable("组类型", strGroupType);
               result=true;
           }
           catch
           {
               
           }
           return result;
       }
       */
        
    }
}
