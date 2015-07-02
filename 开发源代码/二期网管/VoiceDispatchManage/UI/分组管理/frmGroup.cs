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
    public partial class frmGroup : frmBase
    {
         private DB_Talk.Model.m_Group _mModel = new DB_Talk.Model.m_Group();
        private DB_Talk.BLL.m_Group _BLL = new DB_Talk.BLL.m_Group();
        string GroupType = "会议";

        public frmGroup(DB_Talk.Model.m_Group model, int operate)
         {
            InitializeComponent();
            _mModel = model;
            if (_mModel.GroupTypeID == CommControl.PublicEnums.EnumGroupType.Normal.GetHashCode())
                GroupType = "调度";
            else if((_mModel.GroupTypeID == CommControl.PublicEnums.EnumGroupType.Meeting.GetHashCode()))
                GroupType = "会议";

            if (operate == 0)
            {
                this.FormTitle = "添加";
                btnOK.Text = "添加";
            }
            else
            {
                this.FormTitle = "编辑";
                btnOK.Text = "编辑";
                ShowModel();
            }
            if (Global.Params.ConfigModel.SystemConfig.MaxNameTextLengh != 0)
               this.txtName.MaxLength = Global.Params.ConfigModel.SystemConfig.MaxNameTextLengh;//  Global.Params.NameLen;
            
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
                if (_BLL.GetModelList(string.Format(" i_flag=0 and  vc_Name='{0}' and BoxID='{1}' and GroupTypeID='{2}'", _mModel.vc_Name, Global.Params.BoxID,_mModel.GroupTypeID)).Count > 0)
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format(GroupType + "分组名称【{0}】已存在!", _mModel.vc_Name), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    txtName.Focus();
                    return;
                }
                if (_BLL.Add(_mModel) == 1)
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Add, "添加", "添加了会议：" + _mModel.vc_Name, "");
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
                List<DB_Talk.Model.m_Group> lst = _BLL.GetModelList(string.Format(" i_flag=0 and  vc_Name='{0}' and BoxID='{1}' and GroupTypeID='{2}'", _mModel.vc_Name, Global.Params.BoxID,_mModel.GroupTypeID));
                if (lst.Count > 0)
                {
                    if (lst[0].ID != _mModel.ID)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format(GroupType + "名称【{0}】已存在！", _mModel.vc_Name), "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtName.Focus();
                        return;
                    }
                }

                if (_BLL.Update(_mModel))
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Update, "编辑", "编辑了会议：" + _mModel.vc_Name, "");
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
