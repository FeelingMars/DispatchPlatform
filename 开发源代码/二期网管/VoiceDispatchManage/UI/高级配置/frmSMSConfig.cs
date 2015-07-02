using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceDispatchManage.Tools;

namespace VoiceDispatchManage.UI
{
    public partial class frmSMSConfig : UserControlMid
    {
        public frmSMSConfig()
        {
            InitializeComponent();
            this.Text = "短信配置";
            DB_Talk.Model.SMSConfig model = MBoxOperate.GetSMSConfig();
            txtSMSName.Text = model.SystemID.ToString();
            txtPassword.Text = model.Password;
            txtIP.Text = model.IP;
            labelX5.Text = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.txtIP.Text != "")
            {
                if (this.txtIP.Text.Substring(0, 7) != Global.Params.BoxIP.Substring(0, 7))
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("IP地址必须和站点IP在同一网段内！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请输入IP地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (NewFormMain.LoadBox(Global.Params.BoxIP))
            {
                bool b = MBoxOperate.CreateSMS(new DB_Talk.Model.SMSConfig()
                   {
                       IP = txtIP.Text.Trim(),
                       SystemID = int.Parse(txtSMSName.Text),
                       Password = txtPassword.Text
                   });
                if (b)
                {
                    MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);
                    CommControl.MessageBoxEx.MessageBoxEx.Show("设置成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("设置失败,可能是被短信服务占用。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("登录站点[" + Global.Params.BoxIP + "]失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        private void txtIP_Leave(object sender, EventArgs e)
        {
            Global.Methods.checkIP(this.txtIP, "");
         
        }

        private void txtSMSName_MouseHover(object sender, EventArgs e)
        {
            labelX5.Text = "接收短信时显示的来电号码";
        }

        private void txtSMSName_MouseLeave(object sender, EventArgs e)
        {
            labelX5.Text = "";
        }

        private void txtPassword_MouseHover(object sender, EventArgs e)
        {
            labelX5.Text = "短信服务注册时使用的密码";
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            labelX5.Text = "";
        }

        private void txtIP_MouseHover(object sender, EventArgs e)
        {
            labelX5.Text = "短信服务器的IP地址";
        }

        private void txtIP_MouseLeave(object sender, EventArgs e)
        {
            labelX5.Text = "";
        }

     
    }
}
