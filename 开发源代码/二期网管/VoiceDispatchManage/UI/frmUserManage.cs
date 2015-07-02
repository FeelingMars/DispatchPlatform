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
    public partial class frmUserManage : UserControlMid
    {
        public frmUserManage()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmUserManage_Load);
           
        }
        Tools.AcNetUtilsManage AcrManage = new Tools.AcNetUtilsManage();
        VoiceDispatchManage.Tools.DatagridViewCheckBoxHeaderCell cbHeader = new VoiceDispatchManage.Tools.DatagridViewCheckBoxHeaderCell();

        public bool IsUpdateBox = false;

        void frmUserManage_Load(object sender, EventArgs e)
        {
            //this.txtLeftName.MaxLength = Global.Params.ConfigModel.SystemConfig.MaxNameTextLengh;// Global.Params.NameLen;
            //this.txtRightName.MaxLength = Global.Params.ConfigModel.SystemConfig.MaxNameTextLengh;//  Global.Params.NameLen;
           
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);

            string error = "";
            string file = Global.Params.FILE_PATH_REPORT + "系统用户信息表.apt";
            if (!AcrManage.Init(file, out error))
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadData();
           
           
            // LoadReport();
            /*
            //this.colIsSelect.HeaderCell = cbHeader;
            cbHeader.OnCheckBoxClicked+=new Tools.CheckBoxClickedHandler(cbHeader_OnCheckBoxClicked);
            DataGridViewCheckBoxColumn colCB = new DataGridViewCheckBoxColumn();
           
            colCB.HeaderCell = cbHeader;
            dgvBox.CellContentClick += new DataGridViewCellEventHandler(dgvBox_CellContentClick);
            dgvBox.Columns.Insert(1,colCB);

            dgvBox.ReadOnly = false;
            for (int i = 0; i < dgvBox.Columns.Count; i++)
            {
                if (i == 1) continue;
                dgvBox.Columns[i].ReadOnly = true;
            }
            */
        }
        /*
        void dgvBox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow dr in dgvBox.Rows)
            {
                if (dr.Index != e.RowIndex)
                    dr.Cells[1].Value = false;
                    //dgvBox.Rows[e.RowIndex].Cells[1].Value = false;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                dgvBox.Rows[e.RowIndex].Cells[1].Value=!Convert.ToBoolean(dgvBox.Rows[e.RowIndex].Cells[1].Value);
            }

        }
        */

        void cbHeader_OnCheckBoxClicked(bool state)
        {
            //foreach (DataGridViewRow dr in dgvBox.Rows)
            //{
            //    if (state)
            //    {
            //        dr.Cells[1].Value = true;
            //    }
            //    else
            //    {
            //        dr.Cells[1].Value = false;
            //    }

            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUser fu = new frmUser(null, 0);
            fu.ShowDialog();
            if(fu.DialogResult==DialogResult.OK)
              LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                DB_Talk.Model.v_Manager typeModel = (DB_Talk.Model.v_Manager)dgvList.CurrentRow.Tag;


                if (typeModel != null)
                {
                    if (typeModel.vc_UserName.ToUpper() == "ADMIN")
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("【" + typeModel.vc_UserName + "】不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (CommControl.MessageBoxEx.MessageBoxEx.Show("确认要删除 【" + typeModel.vc_UserName + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                        if (new DB_Talk.BLL.m_Manager().DeleteEx(typeModel.ID))
                        {
                            if (Global.Params.UserName == typeModel.vc_UserName)
                            {
                                Global.Params.LstBox = new List<DB_Talk.Model.m_Box>();
                                IsUpdateBox = true;
                            }

                            CommControl.MessageBoxEx.MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Delete, "删除", "删除了系统用户：" + typeModel.vc_UserName, "");
                            LoadData();
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
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要删除的登录用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                DB_Talk.Model.v_Manager Model = (DB_Talk.Model.v_Manager)dgvList.CurrentRow.Tag;
                if (Model != null)
                {
                    frmUser fu = new frmUser(Model, 1);
                    fu.ShowDialog();
                    if(fu.DialogResult==DialogResult.OK)
                       LoadData();
                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要编辑的用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                DB_Talk.Model.v_Manager vModel = (DB_Talk.Model.v_Manager)dgvList.CurrentRow.Tag;
                DB_Talk.Model.m_Manager mModel =new DB_Talk.BLL.m_Manager().GetModel(vModel.ID);

                if (vModel != null)
                {
                    try
                    {
                        //checkCondition();
                    }
                    catch (Exception ex)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    DB_Talk.Model.m_Manager m = GetModel(mModel);
                    if (new DB_Talk.BLL.m_Manager().Update(m))
                    {

                        if (Global.Params.UserName == m.vc_UserName && m.vc_BoxID != vModel.vc_BoxID)
                        {
                            /*
                            List<DB_Talk.Model.m_Box> lst = new List<DB_Talk.Model.m_Box>();
                            //string strW = "i_Flag=-1";  //不选择box时，获取0个box
                            if (mModel.vc_BoxID != null && mModel.vc_BoxID != "")
                            {
                                lst = new DB_Talk.BLL.m_Box().GetModelList(" i_Flag=0 and ID in(" + mModel.vc_BoxID + ")");
                            }
                            foreach(DB_Talk.Model.m_Box box in Global.Params.LstBox)
                            {
                                 foreach(DB_Talk.Model.m_Box boxNew in lst)
                                 {
                                     if (box.ID == boxNew.ID)
                                     {
                                         boxNew.i_Flag = box.i_Flag;
                                     }
                                }
                            }
                            Global.Params.LstBox = lst;
                            IsUpdateBox = true;
                            */
                        }
                        CommControl.MessageBoxEx.MessageBoxEx.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //.BLL.m_SystemLog.WriteLog(Global.Params.UserID, DB_FileManage.Model.m_SystemLog.EnumLogAction.Delete, "删除文件等级", "删除文件等级:" + typeModel.vc_Name);
                        LoadData();
                    }
                    else
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("保存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要保存的登录用户", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
       
        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private string _tableName = "UserList";
        private void btnStyle_Click(object sender, EventArgs e)
        {
            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableName, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);
            //Tools.AcrReportManage.Current.AddVariable(dgvList);
            AcrManage.AddVariable(this.dgvList);
        }


        private void dgvList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //dgvList_CellClick(null,null);
            if ((e.RowIndex >= 0 && dgvList.SelectedRows.Count > 0) )
            {
                DB_Talk.Model.v_Manager Model = (DB_Talk.Model.v_Manager)dgvList.Rows[e.RowIndex].Tag;
                if (Model != null)
                {
                    loadRight(Model);
                }
            }
            
        }
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dgvList.SelectedRows.Count > 0))
            {
                DB_Talk.Model.v_Manager Model = (DB_Talk.Model.v_Manager)dgvList.CurrentRow.Tag;
                if (Model != null)
                {
                    loadRight(Model);
                }
            }
        }
       
        public int LoadData()
        {
            dgvList.Rows.Clear();

            List<DB_Talk.Model.v_Manager> lst = new List<DB_Talk.Model.v_Manager>();
            lst = new DB_Talk.BLL.v_Manager().GetModelList("i_Flag=0 ");

            int i = 0;
            
            foreach (DB_Talk.Model.v_Manager item in lst)
            {
                StringBuilder sbOperates = new StringBuilder();
                StringBuilder sbBoxNames = new StringBuilder();

                if(item.i_Net==1) sbOperates.Append(",网络管理" );
                if(item.i_Operate==1) sbOperates.Append(",操作管理" );
                if(item.i_Dispatch==1) sbOperates.Append(",调度操作" );
                if (sbOperates.Length > 0) sbOperates.Remove(0, 1);
                if (item.vc_BoxID != null && item.vc_BoxID != "")
                {
                    List<DB_Talk.Model.m_Box> lstbox = new DB_Talk.BLL.m_Box().GetModelList(" i_Flag=0 and ID in(" + item.vc_BoxID + ") ");
                    foreach (DB_Talk.Model.m_Box box in lstbox)
                    {
                        sbBoxNames.Append("," + box.vc_Name);
                    }
                }
                if (sbBoxNames.Length > 0) sbBoxNames.Remove(0, 1);

                i++;
                string state = item.i_Flag == 0 ? "使用" : "未使用";
                dgvList.Rows[dgvList.Rows.Add(i,
                    item.vc_UserName,
                    state,
                    item.vc_Memo,
                    item.ID,
                    sbOperates.ToString(),
                    sbBoxNames.ToString()
                    )].Tag = item;
            }
           
            dgvList.ClearSelection();
            enableRight(false);

            kryptonHeaderGroup1.ValuesSecondary.Heading = "  共" + dgvList.Rows.Count.ToString() + "个用户";

           
            chkNet.Checked = false;
            chkOperate.Checked =false;
            chkDispatch.Checked = false;
            i = 1;
            loadReport();
            return lst.Count;
        }

        private void loadReport()
        {
            
            //string strW = ("i_Flag=0 ");
            //string sql = "select (select count(1)+1 from  v_Manager as b where b.id<a.id and " + strW + " )as 序号," +
            //         " vc_UserName as 登录名称,vc_memo as 备注," +
            //         " (case  when  i_Flag=0 then '使用' when  i_Flag=1 then '未使用'  else '' end) as 状态," +
            //         " (case  when  i_Net=1 then '网络管理'  else '' end) as 网络管理," +
            //         " (case  when  i_Operate=1 then '操作管理'  else '' end) as 操作管理," +
            //         " (case  when  i_Dispatch=1 then '调度操作'  else '' end) as 调度操作," +
            //         " BoxName as 站点名称,LeftDispatchNumber as 左席号码,RightDispatchNumber 右席号码" +
            //         " from v_Manager" +
            //         " as a" +
            //         " where " + strW;
            //DataSet ds = new DB_Talk.BLL.v_Manager().GetListSql(sql);
            //if (ds != null)
            //{
                
            //    AcrManage.FillDataTableToAC(ds.Tables[0]);
            //}
            //else
            //{
            //    //CommControl.MessageBoxEx.MessageBoxEx.Show("无数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            AcrManage.AddVariable(this.dgvList);
            AcrManage.FillDataTableToAcFromGridView(this.dgvList);
        }

        private void enableRight(bool isEnable)
        {
            chkNet.Enabled = isEnable;
            chkOperate.Enabled = isEnable;
            chkDispatch.Enabled = isEnable;
            //dgvBox.Rows.Clear();
           
        }

        public void loadRight(DB_Talk.Model.v_Manager Model)
        {
            enableRight(true);
            if (Model.vc_UserName.ToUpper() == "ADMIN") chkNet.Enabled = false;

            chkNet.Checked = Convert.ToBoolean(Model.i_Net);
            chkOperate.Checked = Convert.ToBoolean(Model.i_Operate);
            chkDispatch.Checked = Convert.ToBoolean(Model.i_Dispatch);

            /*
            dgvBox.Rows.Clear();
            List<DB_Talk.Model.m_Box> lst = new List<DB_Talk.Model.m_Box>();
            lst = new DB_Talk.BLL.m_Box().GetModelList("i_Flag=0");

          
            foreach (DB_Talk.Model.m_Box item in lst)
            {
                bool IsSelect = false;
                if (Model.vc_BoxID != null && Model.vc_BoxID!="" && Model.vc_BoxID.IndexOf(item.ID.ToString()) >= 0)
                {
                    IsSelect = true;
                }
                dgvBox.Rows[dgvBox.Rows.Add(item.ID,
                        IsSelect,
                        item.vc_Name,
                        item.vc_IP
                        )].Tag = item;
            }
           */
        }

        public void loadRight()
        {
            if ((dgvList.SelectedRows.Count > 0))
            {
                DB_Talk.Model.v_Manager Model = (DB_Talk.Model.v_Manager)dgvList.CurrentRow.Tag;
                if (Model != null)
                {
                    loadRight(Model);
                }
            }
        }
        private DB_Talk.Model.m_Manager GetModel(DB_Talk.Model.m_Manager model)
        {
            model.i_Net = chkNet.Checked == true ? 1 : 0;
            model.i_Operate = chkOperate.Checked == true ? 1 : 0;
            model.i_Dispatch = chkDispatch.Checked == true ? 1 : 0;

           /*
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow dr in dgvBox.Rows)
            {
                if (dr.Cells[1].Value != null && Convert.ToBoolean(dr.Cells[1].Value) == true)
                {
                    sb.Append("," + dr.Cells[0].Value);
                }
            }
            if (sb.Length > 0)
            {
                sb.Remove(0, 1);
                model.vc_BoxID = sb.ToString();
            }
            else
                model.vc_BoxID = "";
            */
            return model;
        }

      

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string mes = AcrManage.Print();
            if (mes != "")
                CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            //Tools.AcrReportManage.Current.Print();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string mes = AcrManage.Preview();
            if (mes != "")
                CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            //Tools.AcrReportManage.Current.PreView();
        }

        private void btnDesigner_Click(object sender, EventArgs e)
        {
            string mes = AcrManage.ShowDesigner();
            if (mes != "")
                CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            //Tools.AcrReportManage.Current.ShowDesigner();
        }



        /*
        public override void RefushDataReport()
        {
            //base.RefushDataReport();
            LoadReport();
        }
        private void LoadReport()
        {
            Tools.AcrReportManage.Current.SetReportFile("系统用户信息表.apt");
            string strW = ("i_Flag=0 ");
            string sql = "select (select count(1)+1 from  v_Manager as b where b.id<a.id and " + strW + " )as 序号," +
                     " vc_UserName as 登录名称,vc_memo as 备注," +
                     " (case  when  i_Flag=0 then '使用' when  i_Flag=1 then '未使用'  else '' end) as 状态," +
                     " (case  when  i_Net=1 then '网络管理'  else '' end) as 网络管理," +
                     " (case  when  i_Operate=1 then '操作管理'  else '' end) as 操作管理," +
                     " (case  when  i_Dispatch=1 then '调度操作'  else '' end) as 调度操作," +
                     " BoxName as 站点名称,LeftDispatchNumber as 左席号码,RightDispatchNumber 右席号码" +
                     " from v_Manager" +
                     " as a" +
                     " where " + strW;
            //"select  ID, BoxID, vc_UserName, vc_Password, LeftDispatchNumber, 
            //RightDispatchNumber, LeftDispatchName, RightDispatchName, 
            //i_Net, i_Operate, i_Dispatch, dt_CreateTime, vc_Memo, i_Flag, BoxName, vc_IP, vc_SN  ");			
            //" FROM v_Manager ");

            Tools.AcrReportManage.Current.AddDatasetsToAC(sql, "主表");
            Tools.AcrReportManage.Current.AddVariable(dgvList);
        }
        */
    }
}
