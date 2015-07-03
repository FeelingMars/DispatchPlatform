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
    public partial class frmPDS : frmBase
    {
        private DB_Talk.Model.m_PDS _mModel = new DB_Talk.Model.m_PDS();
        private DB_Talk.Model.m_PDS _mModelOld = new DB_Talk.Model.m_PDS();

        private DB_Talk.BLL.m_PDS _BLL = new DB_Talk.BLL.m_PDS();

        private int _operate = 0;

        public frmPDS(int operate)
        {
            InitializeComponent();
            _operate = operate;
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

        }

        private void frmPDS_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                GetModel();
                
                if (btnOK.Text == "添加")
                {
                    if (_BLL.GetModelList(string.Format(" i_flag=0 and  PdsID='{0}'", _mModel.PdsID)).Count > 0)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("编号【{0}】已存在!", _mModel.PdsID), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtCode.Focus();
                        return;
                    }
                    if (_BLL.GetModelList(string.Format(" i_flag=0 and  vc_IP='{0}'", _mModel.vc_IP)).Count > 0)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("IP【{0}】已存在!", _mModel.vc_IP), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtIP.Focus();
                        return;
                    }

                    if (Tools.MBoxOperate.CreatePDS(_mModel))  
                    {
                        _BLL.Add(_mModel);
                        CommControl.MessageBoxEx.MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, 
                            CommControl.SystemLogBLL.EnumLogAction.Add, "添加", "添加了PDS分组网关：" + _mModel.vc_IP, "");
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

                    List<DB_Talk.Model.m_PDS> lst = _BLL.GetModelList(string.Format(" i_flag=0 and  PdsID='{0}'", _mModel.PdsID));
                    if (lst.Count > 0)
                    {
                        if (lst[0].ID != _mModel.ID)
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("编号【{0}】已存在！", _mModel.PdsID), "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            txtCode.Focus();
                            return;
                        }
                    }
                    lst = _BLL.GetModelList(string.Format(" i_flag=0 and  vc_IP='{0}'", _mModel.vc_IP));
                    if (lst.Count > 0)
                    {
                        if (lst[0].ID != _mModel.ID)
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("IP【{0}】已存在！", _mModel.vc_IP), "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            txtIP.Focus();
                            return;
                        }
                    }
                    //if (Tools.MBoxOperate.CreatePDS(_mModel) && _BLL.Update(_mModel))  
                    if (_BLL.Update(_mModel))
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID,
                            CommControl.SystemLogBLL.EnumLogAction.Update, "编辑", "编辑了PDS分组网关：" + _mModel.vc_IP, "");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("编辑失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            
                }
            
            }
            catch (Exception ex)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIP_Leave(object sender, EventArgs e)
        {
            TextBox txt = txtIP;
            if (txt.Text.Trim() != "" && !Global.Methods.checkIP(txt.Text.Trim()))
            {
                txt.Text = "";
                txt.Focus();
                CommControl.MessageBoxEx.MessageBoxEx.Show("IP地址不合法", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            TextBox txt = txtCode;
            if (txt.Text.Trim() != "")
            {
                int num = 0;
                if (int.TryParse(txt.Text.Trim(), out num) && num > 0 && num <= 4)
                {
                }
                else
                {
                    txt.Text = "";
                    txt.Focus();
                    CommControl.MessageBoxEx.MessageBoxEx.Show("分组网关编号必须是1～4的数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        #region 私有方法

        private void ShowModel()
        {

        }


        private void GetModel()
        {
            if (txtCode.Text.Trim() == "")
                throw new Exception("分组网关编号不能为空");

            if (txtIP.Text.Trim() == "")
                throw new Exception("分组网关IP不能为空");


            _mModel.vc_IP = txtCode.Text.Trim();
            _mModel.vc_IP = txtIP.Text.Trim();

            _mModel.BoxID = Global.Params.BoxID;
        }


        #endregion

        

    }
}
