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
    public partial class FrmClearDeviceCfg : UserControlMid
    {
        public FrmClearDeviceCfg()
        {
            InitializeComponent();
            this.Text = "恢复出厂设置";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (NewFormMain.LoadBox(Global.Params.BoxIP))
             {
                string mesQuestion = "确认设备 【" + Global.Params.BoxIP + "】要恢复出厂设置吗?";
                DialogResult dr = CommControl.MessageBoxEx.MessageBoxEx.Show(mesQuestion, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    //LoadControl(null);
                    if (MBoxSDK.ConfigSDK.MBOX_ClearDeviceCfg(Global.Params.BoxHandle))
                    //  && ClearDispatchTell())  //删除两个调度号码
                    {
                        //清空数据库
                        ClearDB();
                        //int iFind = Global.Params.LstBox.FindIndex(item => item.vc_IP == Global.Params.BoxIP);
                        //if(iFind>=0)   Global.Params.LstBox[iFind].i_Flag = 0;
                        //checkOnline_StateChange(Global.Params.BoxIP, false);

                        Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
                        procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "正在恢复出厂设置,请稍等...");
                        System.Threading.Thread.Sleep(5000);
                        procDlg.Dispose();

                        CommControl.MessageBoxEx.MessageBoxEx.Show("设备【" + Global.Params.BoxIP + "】恢复出厂设置成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //重新取BOX信息
                        Global.Params.LstBox = new DB_Talk.BLL.m_Box().GetModelList("i_Flag=0");
                        Global.Params.frmMain.LoadModelList();
                        CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.SystemOperate, "恢复", "恢复出厂设置", "");
                    }
                    else
                        CommControl.MessageBoxEx.MessageBoxEx.Show("设备【" + Global.Params.BoxIP + "】恢复出厂设置失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("未登录设备【" + Global.Params.BoxIP + "】，不能执行此操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //恢复出厂设置时清空数据库
        private void ClearDB()
        {
            //路由
            new DB_Talk.BLL.m_Route().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
            new DB_Talk.BLL.m_RouteGroup().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
            new DB_Talk.BLL.m_RouteRule().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
            //中继
            new DB_Talk.BLL.m_SAPPoint().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
            new DB_Talk.BLL.m_SIPInterface().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));

            new DB_Talk.BLL.m_PRIChannel().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
            new DB_Talk.BLL.m_PRIInterface().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
            new DB_Talk.BLL.m_PRISigLink().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));

            //号码规则
            new DB_Talk.BLL.m_CalinglSourceRule().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
            new DB_Talk.BLL.m_CalledRule().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
            new DB_Talk.BLL.m_CallingSource().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));

            //box
            DB_Talk.Model.m_Box model = new DB_Talk.Model.m_Box();
            model.ID = Global.Params.BoxID;
            model.i_DispatchNumber = 0;
            model.i_EmergencyNumber = 0;
            model.vc_NumberHead = "";
            model.i_NumberLen = 0;
            model.i_Flag = 1;
            new DB_Talk.BLL.m_Box().Update(model);

            //删除所有号码
            new DB_Talk.BLL.m_Member().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
            //new DB_Talk.BLL.m_Member().Delete(" i_Flag=0 and BoxID='" + Global.Params.BoxID + "' and i_IsDispatch=1");
            //删除组成员
            new DB_Talk.BLL.m_GroupMembers().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));

            //删除组,常用人员组不删除
            new DB_Talk.BLL.m_Group().Delete(string.Format(" BoxID='{0}' and vc_Name!='{1}'",
                Global.Params.BoxID, Global.Params.gruopNormalName));

            //删除部门信息，zhj说要删除的，多个站点时删除会有问题
            new DB_Talk.BLL.m_Departments().Delete("");

            //清日志,zhj说要删除的，多个站点时删除会有问题
           // new DB_Talk.BLL.Data_SystemLog().Delete("boxid=" + Global.Params.BoxID);
            new DB_Talk.BLL.Data_Alarm().Delete("boxid=" + Global.Params.BoxID);
            new DB_Talk.BLL.Data_DispatchLog().Delete("boxid=" + Global.Params.BoxID);

            //时钟源恢复为默认值
            DB_Talk.BLL.m_PRIClock BLL = new DB_Talk.BLL.m_PRIClock();
            List<DB_Talk.Model.m_PRIClock> lst = BLL.GetModelList(
                          string.Format(" i_Flag=0 and BoxID='{0}' ", Global.Params.BoxID));
            foreach (DB_Talk.Model.m_PRIClock modelClock in lst)
            {
                modelClock.i_Type = MBoxSDK.ConfigSDK.EnumPriClockType.内部.GetHashCode();
                modelClock.i_Port = 0;
                BLL.Update(modelClock);
            }
        }
    }
}
