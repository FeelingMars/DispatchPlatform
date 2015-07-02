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
    public partial class frmStaticRoute : frmBase
    {
        private DB_Talk.Model.m_StaticRoute _mModel = new DB_Talk.Model.m_StaticRoute();
        private DB_Talk.Model.m_StaticRoute _mModelOld = new DB_Talk.Model.m_StaticRoute();

        private DB_Talk.BLL.m_StaticRoute _BLL = new DB_Talk.BLL.m_StaticRoute();

        private int _operate = 0;

        public frmStaticRoute(int operate)
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
                
            }
        }

        
            

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
            

                GetModel();
                if (btnOK.Text == "添加")
                {
                    if (_BLL.GetModelList(Global.Methods.FormatStrW(string.Format("  and vc_NetIP in {0} ",Tools.DestIP.GetDestIpStr( _mModel.vc_NetIP,_mModel.vc_Mask)))).Count > 0)
                        //string.Format(" i_flag=0 and  vc_NetIP='{0}'", _mModel.vc_NetIP)).Count > 0)
                    {
                        //CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("静态路由IP【{0}】已存在!", _mModel.vc_NetIP), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        CommControl.MessageBoxEx.MessageBoxEx.Show("请检查输入的网段是否有重复!", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtIP.Focus();
                        return;
                    }
                    if (Tools.MBoxOperate.CreateStaticRouting(_mModel))
                    {
                        _BLL.Add(_mModel);
                        CommControl.MessageBoxEx.MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);
                        CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID,
                            CommControl.SystemLogBLL.EnumLogAction.Add, "添加", "添加了静态路由：" + _mModel.vc_NetIP, "");
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

                    List<DB_Talk.Model.m_StaticRoute> lst =_BLL.GetModelList(Global.Methods.FormatStrW(string.Format("  and vc_NetIP in {0} ",Tools.DestIP.GetDestIpStr( _mModel.vc_NetIP,_mModel.vc_Mask))));
                       // string.Format(" i_flag=0 and  vc_NetIP='{0}'", _mModel.vc_NetIP));
                    if (lst.Count > 0)
                    {
                        if (lst[0].ID != _mModel.ID)
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show("请检查输入的网段是否有重复!", "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                          //  CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("静态路由IP【{0}】已存在！", _mModel.vc_NetIP), "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            txtIP.Focus();
                            return;
                        }
                    }
                   
                    // if (Tools.MBoxOperate.CreatePDS(_mModel) && _BLL.Update(_mModel))  
                    if (_BLL.Update(_mModel))
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID,
                            CommControl.SystemLogBLL.EnumLogAction.Update, "编辑", "编辑了静态路由：" + _mModel.vc_NetIP, "");
                        this.DialogResult = DialogResult.OK;
                        MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);
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
            txtMask.Text = "255.255.255.0";
        }






        #region 私有方法

       

    


        private void GetModel()
        {
            if (txtIP.Text.Trim() == "")
                throw new Exception("静态路由IP不能为空");

            if (txtIP.Text.Trim() != "" && !Global.Methods.checkIP(txtIP.Text.Trim()))
            {
                txtIP.Text = "";
                txtIP.Focus();
                throw new Exception("静态路由IP地址不合法");
            }

            if (txtMask.Text.Trim() == "")
                throw new Exception("静态路由子网掩码不能为空");

            if (txtMask.Text.Trim() != "" && !Global.Methods.checkIP(txtMask.Text.Trim()))
            {
                txtMask.Text = "";
                txtMask.Focus();
                throw new Exception("子网掩码IP地址不合法");
            }

            if (txtGatewayIP.Text.Trim() == "")
                throw new Exception("静态路由网关IP不能为空");

            if (txtGatewayIP.Text.Trim() != "" && !Global.Methods.checkIP(txtGatewayIP.Text.Trim()))
            {
                txtGatewayIP.Text = "";
                txtGatewayIP.Focus();
                throw new Exception("静态路由网关IP地址不合法");
            }


            _mModel.vc_NetIP = txtIP.Text.Trim();
            _mModel.vc_Mask = txtMask.Text.Trim();
            _mModel.vc_GateWayIP = txtGatewayIP.Text.Trim();
            _mModel.BoxID = Global.Params.BoxID;
        }


        #endregion

     
    }
}
