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
    public partial class frmUser : frmBase
    {
         private DB_Talk.Model.m_Manager _mModel = new DB_Talk.Model.m_Manager();
         private DB_Talk.BLL.m_Manager _BLL = new DB_Talk.BLL.m_Manager();

         private DB_Talk.Model.v_Manager _vModel = new DB_Talk.Model.v_Manager();
         private DB_Talk.BLL.v_Manager _vBLL = new DB_Talk.BLL.v_Manager();

         public frmUser(DB_Talk.Model.v_Manager model, int operate)
         {
            InitializeComponent();

            if (operate == 0)
            {
                this.FormTitle = "添加";
                btnOK.Text = "添加";
            }
            else
            {

                _vModel = model;
                _mModel = _BLL.GetModel(_vModel.ID); ;

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
                if (_BLL.GetModelList(string.Format(" i_flag=0 and  vc_UserName='{0}'", _mModel.vc_UserName)).Count > 0)
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("登录名称【{0}】已存在!", _mModel.vc_UserName), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtName.Focus();
                    return;
                }

                _mModel.dt_CreateTime = System.DateTime.Now;
                if (_BLL.Add(_mModel) == 1)
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Add, "添加", "添加了系统用户：" + _mModel.vc_UserName, "");
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
                List<DB_Talk.Model.m_Manager> lst = _BLL.GetModelList(string.Format(" i_flag=0 and  vc_UserName='{0}'", _mModel.vc_UserName));
                if (lst.Count > 0)
                {
                    if (lst[0].ID != _mModel.ID)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("登录名称【{0}】已存在！", _mModel.vc_UserName), "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtName.Focus();

                        return;
                    }
                }

                if (_BLL.Update(_mModel))
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Update, "编辑", "编辑了系统用户：" + _mModel.vc_UserName, "");
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


        #region  私有方法
        private void GetModel()
        {
           
            _mModel.vc_UserName = txtName.Text.Trim();
            if (_mModel.vc_UserName == "")
            {
                txtName.Focus();
                throw new Exception("名称不可以为空");
            }
            if (_mModel.vc_UserName.IndexOf("'") >= 0)
            {
                txtName.Focus();
                throw new Exception("名称中不可以有特殊字符");
            }
            if (txtPass.Text.Trim() != txtPass2.Text.Trim())
            {
                txtPass.Text="";
                txtPass2.Text = "";
                txtPass.Focus();
                throw new Exception("两次输入密码不一致");
            }

            if (txtPass.Text.Trim() == "" )
            {
                txtPass.Focus();
                throw new Exception("密码不可以为空");
            }
            if (txtPass2.Text.Trim() == "")
            {
                txtPass2.Focus();
                throw new Exception("校验密码不可以为空");
            }

            if (txtPass.Text.Trim().IndexOf("'") >= 0 )
            {
                txtPass.Focus();
                throw new Exception("密码中不可以有特殊字符");
            }
            if (txtPass2.Text.Trim().IndexOf("'") >= 0)
            {
                txtPass2.Focus();
                throw new Exception("校验密码中不可以有特殊字符");
            }

            _mModel.vc_Password = txtPass.Text.Trim();

            _mModel.vc_Memo = txtMemo.Text.Trim();
            if (_mModel.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符");
            }
        }


        private void ShowModel()
        {
            txtName.Text = _mModel.vc_UserName;
            txtPass.Text = _mModel.vc_Password;
            txtPass2.Text = _mModel.vc_Password;
            txtMemo.Text = _mModel.vc_Memo;


        }
        #endregion

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 特殊键(含空格), 不处理
            if ((int)e.KeyChar <= 32 && Convert.ToInt32(e.KeyChar) != 8)     //不包括退格)
            {
                e.Handled = true;
            }
        }

        private void txtPass2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 特殊键(含空格), 不处理
            if ((int)e.KeyChar <= 32 && Convert.ToInt32(e.KeyChar) != 8)     //不包括退格)
            {
                e.Handled = true;
            }
        }

        
    }
}
