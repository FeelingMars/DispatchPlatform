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
    public partial class frmReStart : UserControlMid
    {
        public frmReStart()
        {
            InitializeComponent();
            this.Text = "重启设备";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (FormMain.LoadBox(Global.Params.BoxIP))
            //{
                if (Global.Params.BoxHandle > 0)
                {
                    string mesQuestion = "确认要重启设备 【" + Global.Params.BoxIP + "】吗?";
                    DialogResult dr = CommControl.MessageBoxEx.MessageBoxEx.Show(mesQuestion, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        //LoadControl(null);
                        MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);
                        MBoxSDK.ConfigSDK.MBOX_Restart(Global.Params.BoxHandle);
                        //int iFind=  Global.Params.LstBox.FindIndex(item => item.vc_IP == Global.Params.BoxIP);
                        //if(iFind>=0) Global.Params.LstBox[iFind].i_Flag = 0;
                        //checkOnline_StateChange(Global.Params.BoxIP, false);

                        Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
                        procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "正在重启设备【" + Global.Params.BoxIP + "】,请稍等...");
                        System.Threading.Thread.Sleep(5000);
                        procDlg.Dispose();

                        CommControl.MessageBoxEx.MessageBoxEx.Show("重启设备【" + Global.Params.BoxIP + "】成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //else
                        //    CommControl.MessageBoxEx.MessageBoxEx.Show("重启设备【" + Global.Params.BoxIP + "】失败", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.SystemOperate, "重启", "重启设备", "");
                    }
                }
                else
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("未登录设备【" + Global.Params.BoxIP + "】，不能执行此操作", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                }
            //}
            //else
            //{
            //    CommControl.MessageBoxEx.MessageBoxEx.Show("登录站点[" + Global.Params.BoxIP + "]失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //}
                    
        }
    }
}
