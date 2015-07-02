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
    public partial class frm3GBase : UserControlMid
    {
        public frm3GBase()
        {
            InitializeComponent();
        }

        private void frm3GBase_Load(object sender, EventArgs e)
        {
            this.Text = "基本配置";
            ShowModel();
        }

        private void txtSecureIP_Leave(object sender, EventArgs e)
        {
            Global.Methods.checkIP(this.txtSecureIP,"");
        }

        private void txtDNS1_Leave(object sender, EventArgs e)
        {
            Global.Methods.checkIP(this.txtDNS1,"DNS");
        }

        private void txtDNS2_Leave(object sender, EventArgs e)
        {
            Global.Methods.checkIP(this.txtDNS2,"DNS");
        }

       


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                GetModel();

                if (Tools.MBoxOperate.SetSecureGatewayAddress(txtSecureIP.Text.Trim()) &&
                Tools.MBoxOperate.SetDNSServer(txtDNS1.Text.Trim(), txtDNS2.Text.Trim()))
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("设置成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                     
                }
                else
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("设置失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     
                }
                ShowModel();
            }
            catch (Exception ex)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }


        #region 私有方法

       

        private void ShowModel()
        {
            string ip = "";
            Tools.MBoxOperate.GetSecureGatewayAddress(out ip);
            txtSecureIP.Text = ip=="0.0.0.0"?"":ip;
            string dns1 = "", dns2 = "";
            Tools.MBoxOperate.GetDNSServer(out dns1,out dns2);
            txtDNS1.Text = dns1 == "0.0.0.0" ? "" : dns1;
            txtDNS2.Text = dns2 == "0.0.0.0" ? "" : dns2;

        }

        private void GetModel()
        {
            if (txtSecureIP.Text.Trim() == "")
            {
                throw new Exception("安全网关IP不能为空");
            }

            if (txtDNS1.Text.Trim() == "")
            {
                throw new Exception("首选DNS不能为空");
            }
        }

       #endregion

    }
}
