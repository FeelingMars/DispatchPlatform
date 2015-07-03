using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl;
using DevComponents.DotNetBar.Controls;

namespace DispatchPlatform
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
            if (Config.WriteModel(Pub._configModel))
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
            txtserver.Text = Pub._configModel.DBServer;
            txtdb.Text = Pub._configModel.DBName;
            txtuserno.Text = Pub._configModel.DBUserName;
            txtdbpwd.Text = Pub._configModel.DBPassword;
        }

        private DispatchPlatform.ConfigModel GetConfigModel()
        {
            Pub._configModel.DBServer = txtserver.Text;
            Pub._configModel.DBName = txtdb.Text;
            Pub._configModel.DBUserName = txtuserno.Text;
            Pub._configModel.DBPassword = txtdbpwd.Text;

            return Pub._configModel;
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

        private void txtserver_Click(object sender, EventArgs e)
        {
            TextBoxX t = (TextBoxX)sender;
            new FormKeyboard(t).ShowDialog();
        }
    }
}
