using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bestway.Windows.Tools.ADODB;

namespace VoiceDispatchManage
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //读本地配置文件
            Global.Params.ConfigModel = (new Config.ConfigBLL()).ReadConfig();  
            //OpenDataBase();

            Bestway.Windows.Forms.ProgressBarDialog procDlg = null;
            Form tempForm = new Form();
            tempForm.FormBorderStyle = FormBorderStyle.None;
            tempForm.Size = new System.Drawing.Size(1, 1);
            tempForm.Show();
            tempForm.Hide();

            try
            {
                //单例模式
                bool bCreatedNew;
                System.Threading.Mutex mutex = new System.Threading.Mutex(false, Application.ProductName, out bCreatedNew);
                if (!bCreatedNew)
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("程序已打开！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //捕获程序级错误
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionEventHandler);

                
                procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
                procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在加载配置文件...");
                //读本地配置文件
                Global.Params.ConfigModel = (new Config.ConfigBLL()).ReadConfig();
                //数据库连接
                procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在连接数据库，请稍等...");
                if ( OpenDataBase() == false)
                {
                    procDlg.Hide();
                    DialogResult dr = new DialogResult();
                    dr = (new Start.frmDatabaseConfig()).ShowDialog();
                    if (dr == DialogResult.Cancel)
                    {
                        procDlg.Dispose();
                        return;
                    }
                }
                DB_Talk.DB.OleDbHelper.StateChanged += new System.Data.StateChangeEventHandler(OleDbHelper_StateChanged);
               
                procDlg.Hide();

                #region 用户登录
                procDlg.Hide();
                NewfrmLogin frmLogin = new NewfrmLogin();
                if (!frmLogin.Login())
                {
                    procDlg.Dispose();
                    return;
                }
                #endregion

                procDlg.Dispose();
                Global.Params.frmMain = new NewFormMain();
                Application.Run(Global.Params.frmMain);

            }
            catch (Exception ex)
            {

                CommControl.Tools.WriteLog.AppendErrorLog("Main:" + ex.Message + ex.StackTrace);
                //MessageBoxEx.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MBoxSDK.ConfigSDK.MBOX_Dispose();
                Global.Params.BoxHandle = 0;
                Environment.Exit(0);
            }
        }


        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string strText, strCaption;
            strCaption = e.Exception.Source;
            strText = string.Format("Application_ThreadException：{0}\n\r方法名称:{1}", e.Exception.ToString(), e.Exception.TargetSite.Name);
            CommControl.Tools.WriteLog.AppendErrorLog(strCaption + "\n\r" + strText);

            CommControl.MessageBoxEx.MessageBoxEx.Show(e.Exception.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void UnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e)
        {
            string strText, strCaption;
            Exception ex = e.ExceptionObject as Exception;
            strCaption = ex.Source;
            strText = string.Format("UnhandledExceptionEventHandler：{0}\n\r方法名称:{1}", ex.ToString(), ex.TargetSite.Name);
            CommControl.Tools.WriteLog.AppendErrorLog(strCaption + "\n\r" + strText);

            CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        /// <summary>连接服务器/数据库</summary>
        public static bool OpenDataBase()
        {
           
            return DB_Talk.DB.OpenDataBase(Global.Params.ConfigModel.DBInfo.HostID, 
                Global.Params.ConfigModel.DBInfo.DatabaseName,
                Global.Params.ConfigModel.DBInfo.UserName, 
                Global.Params.ConfigModel.DBInfo.Password, 
                new ExecuteErrorEventHandler(OleDbHelper_ExecuteError));
         

            //DBInfo dbInfo = new DBInfo();
            //dbInfo.ProviderName = OleDbEnum.SQLSERVER;
            //dbInfo.HostID = Global.Params.ConfigModel.DBInfo.HostID;
            //dbInfo.DatabaseName = Global.Params.ConfigModel.DBInfo.DatabaseName;
            //dbInfo.UserName = Global.Params.ConfigModel.DBInfo.UserName;
            //dbInfo.Password = Global.Params.ConfigModel.DBInfo.Password;

            ////Global.Params.OleDbHelper = new OleDbHelper(dbInfo);
            ////Global.Params.OleDbHelper.ExecuteError += new ExecuteErrorEventHandler(OleDbHelper_ExecuteError);
            //return Global.Params.OleDbHelper.ConnState == System.Data.ConnectionState.Open;

        }

        static Start.frmConnect frmConnect = null;

        static void OleDbHelper_StateChanged(object sender, System.Data.StateChangeEventArgs e)
        {
            try
            {

                if (e.CurrentState == System.Data.ConnectionState.Closed && frmConnect==null)
                {
                    frmConnect = new Start.frmConnect();
                    frmConnect.ShowDialog();
                    frmConnect = null;
                    //Timer tConnect = new Timer();
                    //tConnect.Tick+=new EventHandler(tConnect_Tick);
                    //tConnect.Interval = 5000;
                    //tConnect.Enabled = true;
                    //tConnect_Tick(tConnect,null);
                    //CommControl.MessageBoxEx.MessageBoxEx.Show("数据库断开连接或中断过连接，必须重启软件，请按确定后退出", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Environment.Exit(0);  
                }
            }
            catch
            {
                //if (mes != "")
                CommControl.MessageBoxEx.MessageBoxEx.Show("数据库断开连接或中断过连接，必须重启软件，请按确定后退出", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
       
       

        private static void OleDbHelper_ExecuteError(object sender, ExecuteErrorEventArgs e)
        {
            try
            {
                CommControl.Tools.WriteLog.AppendErrorLog(e.Sql + "\r\n" + e.Exception.Message + e.Exception.StackTrace);
                OleDbHelper ole = (OleDbHelper)sender;
                if (ole.ConnState == System.Data.ConnectionState.Closed && frmConnect==null)
                {
                    frmConnect = new Start.frmConnect();
                    frmConnect.ShowDialog();
                    frmConnect = null;
                    //CommControl.MessageBoxEx.MessageBoxEx.Show("执行数据库操作错误,请重试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
            }
            catch
            {

            }
        }

    }
}
