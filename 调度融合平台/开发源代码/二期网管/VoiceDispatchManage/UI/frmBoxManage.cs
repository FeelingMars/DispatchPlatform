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
   

    public partial class frmBoxManage : frmBase
    {
        public frmBoxManage()
        {
            InitializeComponent();
           
            this.Load += new EventHandler(frmBoxManage_Load);
            this.FormTitle = Global.Params.BOXNAME + "管理";
            this.FormClosing += new FormClosingEventHandler(frmBoxManage_FormClosing);
        }

        Tools.AcNetUtilsManage AcrManage = new Tools.AcNetUtilsManage();

        void frmBoxManage_Load(object sender, EventArgs e)
        {
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);
            string error = "";
            string file = Global.Params.FILE_PATH_REPORT + "站点信息表.apt";
            if (!AcrManage.Init(file, out error))
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadData();
        }

        void frmBoxManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = dr;
        }
        DialogResult dr = DialogResult.No;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count >= 1)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("系统只允许添加一个站点！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmBox fu = new frmBox(null, 0);
            fu.ShowDialog();
            if (fu.DialogResult == DialogResult.OK)
            {
                LoadData();
                dr = DialogResult.OK;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                DB_Talk.Model.m_Box typeModel = (DB_Talk.Model.m_Box)dgvList.CurrentRow.Tag;
                if (typeModel != null)
                {
                    if (CommControl.MessageBoxEx.MessageBoxEx.Show("确认要删除 【" + typeModel.vc_Name + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        bool isExit_manager = new DB_Talk.BLL.m_Manager().Exists("BoxId='" + typeModel.ID + "'");
                        bool isExit_member = new DB_Talk.BLL.m_Member().Exists("BoxId='" + typeModel.ID + "'");
                        List<DB_Talk.Model.m_Group> lst = new DB_Talk.BLL.m_Group().GetModelList("i_Flag=0 and BoxId='" + typeModel.ID + "'");
                        bool isExit_group = false;
                      
                        foreach (DB_Talk.Model.m_Group m in lst)
                        {
                            if (m.vc_Name != Global.Params.gruopNormalName)
                            {
                                isExit_group = true;
                                break;
                            }
                        }
                        bool isExit_CalledRule = new DB_Talk.BLL.m_CalledRule().Exists("BoxId='" + typeModel.ID + "' and i_Flag=0 and vc_CalledNumber!='*000'");
                        //bool isExit_group = new DB_Talk.BLL.m_Group().Exists("BoxId='" + typeModel.ID + "'");
                        if (isExit_manager || isExit_member || isExit_group || isExit_CalledRule)
                        //if (isExit_member)
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show(Global.Params.BOXNAME + "已经被引用，不可以删除！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if (new DB_Talk.BLL.m_Box().DeleteEx(typeModel.ID))
                        {
                            new DB_Talk.BLL.m_Group().Delete("i_Flag=0 and BoxId='" + typeModel.ID + "'");
                            CommControl.MessageBoxEx.MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, typeModel.ID, CommControl.SystemLogBLL.EnumLogAction.Delete, "删除", "删除了站点：" + typeModel.vc_Name, "");
                            //.BLL.m_SystemLog.WriteLog(Global.Params.UserID, DB_FileManage.Model.m_SystemLog.EnumLogAction.Delete, "删除文件等级", "删除文件等级:" + typeModel.vc_Name);
                            LoadData();
                            Global.Params.LstBox.Remove(typeModel);
                            dr = DialogResult.OK;
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
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要删除的" +Global.Params.BOXNAME, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                DB_Talk.Model.m_Box Model = (DB_Talk.Model.m_Box)dgvList.CurrentRow.Tag;
                if (Model != null)
                {
                    if (  NewFormMain.LoadBox(Model.vc_IP)==false)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("设备不在线，无法修改!" ,"提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    frmBox fu = new frmBox(Model, 1);
                    fu.ShowDialog();
                    if (fu.DialogResult == DialogResult.OK)
                    {
                        LoadData();
                        dr = DialogResult.OK;
                    }
                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要编辑的" + Global.Params.BOXNAME, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private string _tableName = "BoxtList";
        private void btnStyle_Click(object sender, EventArgs e)
        {
            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableName, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);
            AcrManage.AddVariable(this.dgvList);
            //Tools.AcrReportManage.Current.AddVariable(dgvList);
        }

        public int LoadData()
        {
            dgvList.Rows.Clear();

            List<DB_Talk.Model.m_Box> lst = new List<DB_Talk.Model.m_Box>();
            lst = new DB_Talk.BLL.m_Box().GetModelList("i_Flag=0");

            int i = 0;
            foreach (DB_Talk.Model.m_Box item in lst)
            {
                i++;
                dgvList.Rows[dgvList.Rows.Add(item.ID,
                        item.vc_Name,
                        item.vc_IP,
                        item.vc_Mask,
                        item.vc_NetIP,
                        item.vc_DispatchIP1,
                        item.vc_DispatchIP2,
                        item.vc_RecordServerIP,
                        item.vc_TimerServerIP,
                        item.vc_Memo,
                        item.vc_SN
                        )].Tag = item;
            }
            tslState.Text = "  共" + dgvList.Rows.Count.ToString() + "个" + Global.Params.BOXNAME;
            loadReport();
            //Global.Params.LstBox = new DB_Talk.BLL.m_Box().GetModelList("i_Flag=0");
            /*
            for (int j = 0; j < Global.Params.LstBox.Count; j++)
            {
                Global.Params.LstBox[j].i_Flag = 0;
            }
            */
            return lst.Count;
        }
        private void loadReport()
        {
            try
            {
                AcrManage.AddVariable(this.dgvList);
                AcrManage.FillDataTableToAcFromGridView(this.dgvList);
            }
            catch(Exception ex)
            {
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
           string mes=AcrManage.Print();
           if (mes != "")
               CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string mes = AcrManage.Preview();
            if (mes != "")
                CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
  
        }

        private void btnDesigner_Click(object sender, EventArgs e)
        {
            string mes = AcrManage.ShowDesigner();
            if (mes != "")
                CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
  
        }

    }
}
