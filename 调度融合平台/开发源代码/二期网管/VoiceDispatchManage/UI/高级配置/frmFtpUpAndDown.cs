using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VoiceDispatchManage.Tools;
using System.IO;

namespace VoiceDispatchManage.UI
{
    public partial class frmFtpUpAndDown : UserControlMid
    {
        public frmFtpUpAndDown()
        {
            InitializeComponent();
            this.Text = "备份还原配置";
            this.Load += new EventHandler(frmFtpUpAndDown_Load);
        }

        FtpHelper ftp = null;

        void frmFtpUpAndDown_Load(object sender, EventArgs e)
        {
            string ftpServerIP = Global.Params.BoxIP; //"192.168.1.220";
            string userName = "root";
            string password = "hitotek";
            ftp = new FtpHelper(ftpServerIP, userName, password);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.ProgressBarDialog prog = new Bestway.Windows.Forms.ProgressBarDialog();
            try
            {
                if (NewFormMain.LoadBox(Global.Params.BoxIP))
                {
                    ftp.FindFtpFileList("");
                    int i = 0;
                    foreach (FtpFileInfo info in ftp.lstftpfile)
                    {
                        prog.Show(Bestway.Windows.Forms.EnumDisplayType.Custom, "正在备份文件：" + info.FileName);
                        i++;
                        ftp.Download(info.FileFullName, Global.Params.FILE_PATH_BOXCONFIG); //"F:\\xiazai");
                    }
                    string mes = "硬件配置备份成功\r\n";
                    DbOper dboper = new DbOper();
                    prog.Show(Bestway.Windows.Forms.EnumDisplayType.Custom, "正在备份数据库...");
                    if (dboper.DbBackup(Global.Params.FILE_PATH_BOXCONFIG_DB))
                    {
                        mes += "数据库备份成功";
                    }
                    else
                    {
                        mes += "数据库备份失败！" +dboper.errorMes;
                    }
                    prog.Hide();
                    CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch(Exception ex)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(ex.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                prog.Dispose();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Bestway.Windows.Forms.ProgressBarDialog prog = new Bestway.Windows.Forms.ProgressBarDialog();
            try
            {
                if (NewFormMain.LoadBox(Global.Params.BoxIP))
                {
                    //ftp.FindLocalFile(@"F:\xiazai\tffs0\cfg");
                    //ftp.FindLocalFile(@"F:\xiazai\tffs0\db");
                    if (radioButton1.Checked)
                    {
                        //仅还原配置文件
                        ftp.FindLocalFile(Global.Params.FILE_PATH_BOXCONFIG + @"\tffs0\cfg");
                        ftp.FindLocalFile(Global.Params.FILE_PATH_BOXCONFIG + @"\tffs0\db");
                        ftp.FindLocalFile(Global.Params.FILE_PATH_BOXCONFIG + @"\tffs0\boot");
                        ftp.FindLocalFile(Global.Params.FILE_PATH_BOXCONFIG + @"\tffs0\fw");
                        ftp.FindLocalFile(Global.Params.FILE_PATH_BOXCONFIG + @"\tffs0\lc");
                        //if (!Directory.Exists(Global.Params.FILE_PATH_BOXCONFIG + @"\tffs0\cfg") ||
                        //     !Directory.Exists(Global.Params.FILE_PATH_BOXCONFIG + @"\tffs0\db")) 
                        //{
                        //    throw new Exception("硬件配置文件不存在，无法恢复");
                        //}

                    }
                    else if (radioButton2.Checked)
                    {
                        //全部还原
                        ftp.FindLocalFile(Global.Params.FILE_PATH_BOXCONFIG);
                        //if (!Directory.Exists(Global.Params.FILE_PATH_BOXCONFIG))
                        //{
                        //    throw new Exception("硬件配置文件不存在，无法恢复");
                        //}
                    }

                    if (ftp.lstLocalfile.Count == 0)
                    {
                        throw new Exception("硬件配置文件不存在，无法恢复");
                    }

                    if (!File.Exists(Global.Params.FILE_PATH_BOXCONFIG_DB + "\\" + Global.Params.ConfigModel.DBInfo.DatabaseName + ".bak"))
                    {
                        throw new Exception("数据库文件不存在，无法恢复");
                    }

                    int i = 0;
                    foreach (FtpFileInfo info in ftp.lstLocalfile)
                    {
                        i++;
                        prog.Show(Bestway.Windows.Forms.EnumDisplayType.Custom, "正在恢复文件：" + info.FileName);
                        ftp.UpToFtpFile(info.FileFullName, Global.Params.FILE_PATH_BOXCONFIG);
                    }

                    string mes = "硬件配置恢复成功\r\n";
                    DbOper dboper = new DbOper();
                    prog.Show(Bestway.Windows.Forms.EnumDisplayType.Custom, "正在还原数据库...");
                    //DB_Talk.DB.OleDbHelper.Dispose();
                    if (dboper.DbRestore(Global.Params.FILE_PATH_BOXCONFIG_DB))
                    {
                        mes += "数据库还原成功!";
                    }
                    else
                    {
                        mes += "数据库还原失败!"  + dboper.errorMes;
                    }
                    prog.Hide();
                    if (dboper.errorMes == "")
                    {
                        //重启站点
                        Global.Params.IsRestart = true;
                        Global.Params.frmMain.ReStartBox();
                    }
                    //数据库连接
                    Start.frmConnect frmConnect = new Start.frmConnect();
                    frmConnect.ShowDialog();
                    frmConnect = null;
                    //prog.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在连接数据库，请稍等...");
                    //if (Program.OpenDataBase() == false)
                    //{
                    //    prog.Hide();
                    //    DialogResult dr = new DialogResult();
                    //    dr = (new Start.frmDatabaseConfig()).ShowDialog();
                    //    if (dr == DialogResult.Cancel)
                    //    {

                    //        return;
                    //    }
                    //}
                    CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                prog.Hide();
                CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                prog.Dispose();
            }
        }
    }
}
