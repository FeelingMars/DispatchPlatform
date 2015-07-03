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
    public partial class frmFap : frmBase
    {
        private DB_Talk.Model.m_FAP _mModel = new DB_Talk.Model.m_FAP();
        private DB_Talk.Model.m_FAP _mModelOld = new DB_Talk.Model.m_FAP();

        private DB_Talk.BLL.m_FAP _BLL = new DB_Talk.BLL.m_FAP();

        private int _operate = 0;

         public frmFap(int operate)
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


         private void frmFap_Load(object sender, EventArgs e)
         {

         }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                GetModel();

                if (btnOK.Text == "添加")
                {
                    if (_BLL.GetModelList(Global.Methods.FormatStrW(string.Format("  and FapID='{0}' ", _mModel.FapID))).Count > 0)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("编号【{0}】已存在!", _mModel.FapID), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtCode.Focus();
                        return;
                    }
                    if (_BLL.GetModelList(string.Format(" i_flag=0 and  BoxID='{0}' and vc_Name='{1}'", Global.Params.BoxID,_mModel.vc_Name)).Count > 0)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("名称【{0}】已存在!",  _mModel.vc_Name), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtName.Focus();
                        return;
                    }
                    if (_BLL.GetModelList(string.Format(" i_flag=0 and BoxID='{0}' and vc_Identify='{1}'", Global.Params.BoxID, _mModel.vc_Identify)).Count > 0)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("标示码【{0}】已存在!", _mModel.vc_Identify), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtIdentify.Focus();
                        return;
                    }

                    //判断
                    List<DB_Talk.Model.m_FAP> lstFap = new DB_Talk.BLL.m_FAP().GetModelList(
                        string.Format("i_Flag=0 and boxid={0} and vc_TempAddress='{1}' ", Global.Params.BoxID, txtFapIP.Text.Trim()));
                    if (lstFap != null && lstFap.Count > 0)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("基站IP:【{0}】已存在!", _mModel.vc_TempAddress), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtFapIP.Focus();
                        return;
                    }

                    if (Tools.MBoxOperate.CreateFAP(_mModel))
                    {
                        _BLL.Add(_mModel);
                        CommControl.MessageBoxEx.MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID,
                            CommControl.SystemLogBLL.EnumLogAction.Add, "添加", "添加了3G基站：" + _mModel.vc_Name, "");
                        this.DialogResult = DialogResult.OK;
                        MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);
                        this.Close();
                    }
                    else
                    {

                        CommControl.MessageBoxEx.MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



        #region 私有方法

        private void ShowModel()
        {

        }


        private void GetModel()
        {
            int num = 0;
            if (txtCode.Text.Trim() == "")
            {
                txtCode.Focus();
                throw new Exception("基站编号不能为空");
            }
            else
            {
                if (!int.TryParse(txtCode.Text.Trim(), out num) || num <= 0 || num > 256) //1~256
                {
                    txtCode.Focus();
                    throw new Exception("基站编号必须是1～256之间的数字");
                }
            }

            if (txtName.Text.Trim() == "")
            {
                txtName.Focus();
                throw new Exception("基站名称不能为空");
            }


            UInt64 num1 = 0;
            if (txtIdentify.Text.Trim() == "")
                throw new Exception("基站标识码不能为空");
            else
            {
                if (!UInt64.TryParse(txtIdentify.Text.Trim(), out num1) || num1 <= 0 || num1.ToString().Length != 15)
                {
                    txtIdentify.Focus();
                    throw new Exception("基站标示码必须是15位的数字");
                    //CommControl.MessageBoxEx.MessageBoxEx.Show("基站标示码必须是15位的数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            if (txtFapIP.Text.Trim() == "")
            {
                txtFapIP.Focus();
                throw new Exception("基站IP不能为空");
            }

            
            if (txtFapIP.Text.Trim() != "" && !Global.Methods.checkIP(txtFapIP.Text.Trim()))
            {
                txtFapIP.Text = "";
                txtFapIP.Focus();
                throw new Exception("基站IP地址不合法");
            }

            _mModel.FapID = int.Parse(txtCode.Text.Trim());
            _mModel.vc_Name =txtName.Text.Trim();
            _mModel.vc_Identify = txtIdentify.Text.Trim() +txtV.Text;
            _mModel.BoxID = Global.Params.BoxID;
            _mModel.vc_TempAddress = txtFapIP.Text.Trim();

        }


        #endregion


    }
}
