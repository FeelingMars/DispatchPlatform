using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl;
using BW_GridStyle;

namespace VoiceDispatchManage.UI
{
    public partial class frmDepartmentManage : UserControlMid
    {
        public frmDepartmentManage()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDepartmentManage_Load);
           
        }

        Tools.AcNetUtilsManage AcrManage = new Tools.AcNetUtilsManage();

        //public override void RefushDataReport()
        //{
        //    //base.RefushDataReport();
        //    LoadReport();
        //}

        void frmDepartmentManage_Load(object sender, EventArgs e)
        {
            try
            {
                Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);

                string error = "";
                string file = Global.Params.FILE_PATH_REPORT + "部门信息表.apt";
                if (!AcrManage.Init(file, out error))
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show(error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadData();
            }
            catch(Exception ex)
            {
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
            }
           
        }

        private void LoadReport()
        {
            AcrManage.AddVariable(this.dgvList);
            AcrManage.FillDataTableToAcFromGridView(this.dgvList);
            /*
            Tools.AcrReportManage.Current.SetReportFile("部门信息表.apt");
            string strW = ("i_Flag=0 ");
            string sql = "select (select count(1)+1 from  m_Departments as b where b.id<a.id and " + strW + " )as 序号," +
                     " vc_Name as 名称,vc_memo as 备注" +
                     " from m_Departments" +
                     " as a" +
                     " where " + strW;
            Tools.AcrReportManage.Current.AddDatasetsToAC(sql, "主表");
            Tools.AcrReportManage.Current.AddVariable(dgvList);
             */
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDepartment fu = new frmDepartment(null, 0);
            fu.ShowDialog();
            if(fu.DialogResult==DialogResult.OK)
              LoadData();
        }

       
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                DB_Talk.Model.m_Departments typeModel = (DB_Talk.Model.m_Departments)dgvList.CurrentRow.Tag;
                if (typeModel != null)
                {
                    if (CommControl.MessageBoxEx.MessageBoxEx.Show("确认要删除部门 【" + typeModel.vc_Name + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (new DB_Talk.BLL.m_Member().Exists("i_Flag=0 and DepartmentID='" + typeModel.ID + "'"))
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show("部门已经被引用，不允许删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if (new DB_Talk.BLL.m_Departments().DeleteEx(typeModel.ID))
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Delete, "删除", "删除了部门：" + typeModel.vc_Name, "");
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
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要删除的部门", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                DB_Talk.Model.m_Departments Model = (DB_Talk.Model.m_Departments)dgvList.CurrentRow.Tag;
                if (Model != null)
                {
                    frmDepartment fu = new frmDepartment(Model, 1);
                    fu.ShowDialog();
                    if(fu.DialogResult==DialogResult.OK)
                       LoadData();
                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要编辑的部门", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private string _tableName = "DepartmentList";
        private void btnStyle_Click(object sender, EventArgs e)
        {
            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableName, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);
            AcrManage.AddVariable(dgvList);
            //Tools.AcrReportManage.Current.AddVariable(dgvList);
        }

       
       

        public int LoadData()
        {
            dgvList.Rows.Clear();

            List<DB_Talk.Model.m_Departments> lst = new List<DB_Talk.Model.m_Departments>();
            lst = new DB_Talk.BLL.m_Departments().GetModelList("i_Flag=0");

            int i = 0;
            foreach (DB_Talk.Model.m_Departments item in lst)
            {
                i++;
                dgvList.Rows[dgvList.Rows.Add(i,
                    item.vc_Name,
                    item.vc_Memo
                    )].Tag = item;
            }
            kryptonHeaderGroup1.ValuesSecondary.Heading="  共" + dgvList.Rows.Count.ToString() + "个部门";
            kryptonHeaderGroup1.Refresh();
            //Tools.AcrReportManage.Current.RefushDataset();
            LoadReport();
            return lst.Count;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string mes = AcrManage.Print();
            if (mes != "")
                CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
           // Tools.AcrReportManage.Current.Print();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string mes = AcrManage.Preview();
            if (mes != "")
                CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
           // Tools.AcrReportManage.Current.PreView();
        }

        private void btnDesigner_Click(object sender, EventArgs e)
        {
            string mes = AcrManage.ShowDesigner();
            if (mes != "")
                CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
           // Tools.AcrReportManage.Current.ShowDesigner();
        }

       
       
    }
}
