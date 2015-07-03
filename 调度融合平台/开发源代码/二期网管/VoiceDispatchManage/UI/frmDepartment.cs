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
    public partial class frmDepartment : frmBase
    {
        private DB_Talk.Model.m_Departments _mModel = new DB_Talk.Model.m_Departments();
        private DB_Talk.BLL.m_Departments _BLL = new DB_Talk.BLL.m_Departments();


        public frmDepartment(DB_Talk.Model.m_Departments model, int operate)
         {
            InitializeComponent();
            if (Global.Params.ConfigModel.SystemConfig.MaxNameTextLengh != 0)
                this.txtName.MaxLength = Global.Params.ConfigModel.SystemConfig.MaxNameTextLengh;// Global.Params.NameLen;

            if (operate == 0)
            {
                this.FormTitle = "添加";
                btnOK.Text = "添加";
            }
            else
            {

                _mModel = model;
                this.FormTitle = "编辑";
                btnOK.Text = "编辑";
                ShowModel();
            }
           
        }

        

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                GetModel();
            }
            catch (Exception ex)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (btnOK.Text == "添加")
            {
                if (_BLL.GetModelList(string.Format(" i_flag=0 and  vc_Name='{0}'", _mModel.vc_Name)).Count > 0)
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("部门名称【{0}】已存在!", _mModel.vc_Name), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtName.Focus();
                    return;
                }
                if (_BLL.Add(_mModel) == 1)
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Add, "添加", "添加了部门：" + _mModel.vc_Name, "");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (btnOK.Text == "编辑")
            {
                List<DB_Talk.Model.m_Departments> lst = _BLL.GetModelList(string.Format(" i_flag=0 and  vc_Name='{0}'", _mModel.vc_Name));
                if (lst.Count > 0)
                {
                    if (lst[0].ID != _mModel.ID)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("部门名称【{0}】已存在！", _mModel.vc_Name), "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtName.Focus();
                        return;
                    }
                }

                if (_BLL.Update(_mModel))
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Update, "编辑", "编辑了部门：" + _mModel.vc_Name, "");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("编辑失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {

        }

        #region  私有方法
        private void GetModel()
        {
            _mModel.vc_Name = txtName.Text.Trim();
            if (_mModel.vc_Name == "")
            {
                txtName.Focus();
                throw new Exception("名称不可以为空");
            }
            if (_mModel.vc_Name.IndexOf("'") >= 0)
            {
                txtName.Focus();
                throw new Exception("名称中不可以有特殊字符");
            }


            _mModel.vc_Memo = txtMemo.Text.Trim();
            if (_mModel.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符");
            }
        }


        private void ShowModel()
        {
            txtName.Text = _mModel.vc_Name;
            txtMemo.Text = _mModel.vc_Memo;

        }
        #endregion
    }
}
