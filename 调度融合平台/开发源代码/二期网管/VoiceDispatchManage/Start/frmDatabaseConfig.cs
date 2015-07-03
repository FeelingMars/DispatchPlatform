using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl;

namespace VoiceDispatchManage.Start
{
    public partial class frmDatabaseConfig : frmBase
    {
        Bestway.Windows.Forms.ProgressBarDialog frmProcess = new Bestway.Windows.Forms.ProgressBarDialog();
        public frmDatabaseConfig()
        {
            InitializeComponent();
                
        }
        private void frmDatabaseConfig_Load(object sender, EventArgs e)
        {
            ShowConfig();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            GetConfigModel();

            frmProcess.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "正在连接数据库...");

            if (Program.OpenDataBase() == false)
            {
                frmProcess.Hide();
                CommControl.MessageBoxEx.MessageBoxEx.Show("数据库连接失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                SaveConfig();
            }
        }

        private void SaveConfig()
        {
            if ((new Config.ConfigBLL()).WriteConfig(Global.Params.ConfigModel))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                frmProcess.Hide();

                CommControl.MessageBoxEx.MessageBoxEx.Show("保存失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowConfig()
        {
            txtserver.Text = Global.Params.ConfigModel.DBInfo.HostID;
            txtdb.Text = Global.Params.ConfigModel.DBInfo.DatabaseName;
            txtuserno.Text = Global.Params.ConfigModel.DBInfo.UserName;
            txtdbpwd.Text = Global.Params.ConfigModel.DBInfo.Password;
        }

        private Config.ConfigModel GetConfigModel()
        {
            Global.Params.ConfigModel.DBInfo.HostID = txtserver.Text;
            Global.Params.ConfigModel.DBInfo.DatabaseName = txtdb.Text;
            Global.Params.ConfigModel.DBInfo.UserName = txtuserno.Text;
            Global.Params.ConfigModel.DBInfo.Password = txtdbpwd.Text;

            return Global.Params.ConfigModel;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }


        private void frmDatabaseConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmProcess.Dispose();
        }

       
    }
}
