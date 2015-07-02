using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VoiceDispatchManage
{
    public partial class NewfrmLogin : Form
    {
        public NewfrmLogin()
        {
            InitializeComponent();
           
            this.txtUserName.Text = Global.Params.ConfigModel.SystemConfig.LastLoginUser;
          //  txtPassword.Text = "admin";
        }

        private bool m_IsOK = false;

        public bool Login()
        {

            this.Text = "登录";
            //List<DB_FileManage.Model.m_Sys_AppInit> m_sys_AppInitList = (new DB_FileManage.BLL.m_Sys_AppInit()).GetModelList(" convert(varchar(50),b_Key)='superuser'");
            //if (m_sys_AppInitList != null && m_sys_AppInitList.Count > 0)
            //    Global.Params.SuperUser = m_sys_AppInitList[0].b_Value;
            //else
            //{
            //    DB_FileManage.Model.m_Sys_AppInit model = new DB_FileManage.Model.m_Sys_AppInit();
            //    model.b_Key = "superuser";
            //    model.b_Value = "admin";
            //    (new DB_FileManage.BLL.m_Sys_AppInit()).Add(model);
            //    Global.Params.SuperUser = "admin";
            //}

            txtUserName.Enabled = true;
            btnCancel.Enabled = true;
           
            this.ShowInTaskbar = true;
            m_IsOK = false;

            this.ShowDialog();
            
            bool isOK = m_IsOK;
            this.Close();
            return isOK;
        }


       
        private int m_ValidateCount = 0;
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
            {
                this.SendToBack();
                CommControl.MessageBoxEx.MessageBoxEx.Show("用户名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return;
            }
            DB_Talk.BLL.m_Manager userBll = new DB_Talk.BLL.m_Manager();
            if (userBll.GetModelList("i_Flag=0 and vc_UserName='admin'").Count==0 && txtPassword.Text.Trim().ToUpper() == "ADMIN" && txtUserName.Text.Trim().ToUpper() == "ADMIN")
            {
                DB_Talk.Model.m_Manager model = new DB_Talk.Model.m_Manager();
                model.vc_UserName = "admin";
                model.vc_Password = "admin";
                model.i_Net = 1;
                model.i_Dispatch = 1;
                model.i_Operate = 1;
                userBll.Add(model);
                Global.Params.UserID = -1;
                Global.Params.UserName = "admin";
                Global.Params.Password = "admin";
                SaveLoginUser(txtUserName.Text.Trim());
                m_IsOK = true;
                this.Hide();
                return;
            }
            else
            {
                //验证次数
                m_ValidateCount++;
                //DB_Talk.BLL.m_Manager userBll = new DB_Talk.BLL.m_Manager();
                List<DB_Talk.Model.m_Manager> userList = userBll.GetModelList(" i_flag = 0 and vc_UserName='" + txtUserName.Text.Replace("'", "''") + "'");
                if (userList != null && userList.Count > 0)
                {
                    Global.Params.UserID = userList[0].ID;
                    Global.Params.UserName = userList[0].vc_UserName;
                   
                    string password = userList[0].vc_Password;
                    if (password == null) password = "";
                    if (password == txtPassword.Text.Trim())
                    {
                        if (Convert.ToBoolean(userList[0].i_Net) == true)
                        {
                            Global.Params.Password = password;
                            SaveLoginUser(txtUserName.Text.Trim());
                            //系统用户控制可以登录的box
                            //string strW = "";
                            //if (userList[0].vc_BoxID != null && userList[0].vc_BoxID != "")
                            //    strW = " i_Flag=0 and ID in(" + userList[0].vc_BoxID + ")";
                            
                            //添加到系统里面的box就可以登录
                            string strW = " i_Flag=0 ";
                            if (strW == "")
                                Global.Params.LstBox = new List<DB_Talk.Model.m_Box>(); //为空时 全部不选
                            else
                                Global.Params.LstBox = new DB_Talk.BLL.m_Box().GetModelList(strW);
                            m_IsOK = true;
                            this.Hide();
                            return;
                        }
                        else
                        {
                            this.SendToBack();
                            CommControl.MessageBoxEx.MessageBoxEx.Show("用户无网络管理权限！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        this.SendToBack();
                        CommControl.MessageBoxEx.MessageBoxEx.Show("密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    this.SendToBack();
                    CommControl.MessageBoxEx.MessageBoxEx.Show("用户名不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
               
            
           
            if (m_ValidateCount >= 3)
            {
                m_IsOK = false;
                this.Hide();
                return;
            }
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_IsOK = false;
            this.Hide();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void SaveLoginUser(string userName)
        {
            Global.Params.ConfigModel.SystemConfig.LastLoginUser = userName;
            Global.Methods.SaveConfig();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 特殊键(含空格), 不处理
            if ((int)e.KeyChar <= 32 && Convert.ToInt32(e.KeyChar) != 8)     //不包括退格)
            {
                e.Handled = true;
            }
        }

        

    }
}
