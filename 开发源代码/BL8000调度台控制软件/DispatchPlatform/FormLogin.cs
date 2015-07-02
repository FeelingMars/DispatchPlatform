using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl;
using DispatchPlatform;
using MBoxSDK;
using CommControl.MessageBoxEx;
using System.Runtime.InteropServices;

namespace DispatchPlatform
{
    public partial class FormLogin : Form
    {
        private int _erroLoingCount = 3;
        private EnumLoginType _type;

        public enum EnumLoginType
        {
            Login = 0,
            Out = 1,
            Lock = 2
        }

        public FormLogin(EnumLoginType type)
        {
            InitializeComponent();
            _type = type;
            this.FormClosing += new FormClosingEventHandler(FormLogin_FormClosing);
            this.Load += new EventHandler(FormLogin_Load);
            switch (type)
            {
                case EnumLoginType.Login:
                    labelX1.Text = "登录";
                    txtUser.Text = Pub._configModel.LastUser;
                   // txtPass.Text = "";
                    this.BackgroundImage = DispatchPlatform.Properties.Resources.page_login_21;
                    break;
                case EnumLoginType.Out:
                    labelX1.Text = "退出";
                    txtUser.Text = Pub._configModel.LastUser;
                   // txtPass.Text = "";
                    this.BackgroundImage = DispatchPlatform.Properties.Resources.page_login_Exit;
                    txtUser.Enabled = false;
                    btnNo.Enabled = true;
                    break;
                case EnumLoginType.Lock:
                    _erroLoingCount = 1000000;
                    labelX1.Text = "锁定";
                    txtUser.Text = Pub._configModel.LastUser;
                   // txtPass.Text = "";
                    this.BackgroundImage = DispatchPlatform.Properties.Resources.page_login_21;
                    btnClose.Enabled = false;
                    txtUser.Enabled = false;
                    btnNo.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        void FormLogin_Load(object sender, EventArgs e)
        {
            txtPass.Text = "";
        }

        void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
            new FormKeyboard(txtUser).ShowDialog();
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            new FormKeyboard(txtPass).ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_erroLoingCount <= 0)
            {
                this.Close();
                return;
            }

            List<DB_Talk.Model.m_Manager> lst=new List<DB_Talk.Model.m_Manager>();
            try
            {
                lst = new DB_Talk.BLL.m_Manager().GetModelList(string.Format("vc_UserName='{0}' and  i_Flag=0 and vc_Password='{1} '", txtUser.Text, txtPass.Text));
            }
            catch (Exception)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                return;
            }
            

            if (lst.Count > 0)
            {
                Pub.manageModel = lst[0];
                if (_type== EnumLoginType.Out && Pub.manageModel.BoxID==null)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                    return;
                }
                
                if (Pub.manageModel.i_Dispatch.Value!=1)
                {
                     MessageBoxEx.Show("当前用户没有调度权限，请联系管理员！", "提示");
                    return;
                }
                //选择Box;
                FormSelectBox fs = new FormSelectBox();
                if (fs.LoadBoxList() == true)
                {
                    fs.ShowDialog();
                }
                        

                if (Pub.manageModel.BoxID == null )
                {
                    MessageBoxEx.Show("请到网管程序修改相应权限！", "提示");
                    return;
                }

                DB_Talk.Model.m_Box boxModel = new DB_Talk.BLL.m_Box().GetModel(Pub.manageModel.BoxID.Value);
                if (boxModel == null)
                {
                    MessageBoxEx.Show("请到网管程序增加MBox设备！", "提示");
                    return;
                }
                #region 添加调度号码，取调度的前两个

               
                ///

                List<DB_Talk.Model.m_Member> lstMember = new List<DB_Talk.Model.m_Member>();

                lstMember = new DB_Talk.BLL.m_Member().GetModelList(string.Format("boxID={0} and i_isdispatch=1 and i_Flag=0", Pub.manageModel.BoxID));
                if (lstMember.Count >= 2)
                {
                    Pub.manageModel.LeftDispatchNumber = lstMember[0].i_Number;
                    Pub.manageModel.LeftDispatchName = lstMember[0].vc_Name;

                    Pub.manageModel.RightDispatchNumber = lstMember[1].i_Number;
                    Pub.manageModel.RightDispatchName= lstMember[1].vc_Name;
                }
                else
                {
                    MessageBoxEx.Show("请到网管程序添加调度号码！", "提示");
                    return;
                }
                #endregion

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Pub._configModel.LastUser = txtUser.Text;
                Config.WriteModel(Pub._configModel);
                
                switch (_type)
                {
                    case EnumLoginType.Login:
                        CommControl.SystemLogBLL.WriteLog(
                            Pub.manageModel.ID, Pub.manageModel.BoxID.Value, SystemLogBLL.EnumLogAction.SystemOperate, "登录", "登录成功", "");
                        break;
                    case EnumLoginType.Out:
                        CommControl.SystemLogBLL.WriteLog(
                            Pub.manageModel.ID, Pub.manageModel.BoxID.Value, SystemLogBLL.EnumLogAction.SystemOperate, "退出", "退出成功", "");
                        break;
                    case EnumLoginType.Lock:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (_type)
                {
                    case EnumLoginType.Login:
                        MessageBoxEx.Show("登录失败", "登录");
                        break;
                    case EnumLoginType.Out:
                        MessageBoxEx.Show("退出失败", "退出");
                        break;
                    case EnumLoginType.Lock:
                        MessageBoxEx.Show("解锁失败", "解锁");
                        break;
                    default:
                        break;
                }
                _erroLoingCount--;
            }
        }

    }
}
