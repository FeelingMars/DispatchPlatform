using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Bestway.Windows.Tools.ADODB;
using DispatchPlatform;
using MBoxSDK;
using CommControl;
using CommControl.MessageBoxEx;
using System.Net;


namespace DispatchPlatform
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

           // Application.Run(new Form1());

           // Application.Run(new TalkLog());
            try
            {
               
                //new FormCallKeyborad(null).ShowDialog();
               // new Form1().ShowDialog();
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

                Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog(new FormWelcome());
                Form tempForm = new Form();
                tempForm.FormBorderStyle = FormBorderStyle.None;
                tempForm.Size = new System.Drawing.Size(1, 1);
                tempForm.Show();
                tempForm.Hide();
                //bool b = DB_Talk.DB.OpenDataBase("172.21.2.78\\hc", "MBoxOss", "Tester1", "User@1234", new ExecuteErrorEventHandler(OleDbHelper_ExecuteError));
                Pub._configModel = Config.GetModel();

                if (Pub._configModel.LocalIP == "127.0.0.1")
                {
                    IPHostEntry hostName = Dns.GetHostByName(Dns.GetHostName());
                    if (hostName.AddressList.Length > 0)
                    {
                        Pub._configModel.LocalIP = hostName.AddressList[0].ToString();
                        Config.WriteModel(Pub._configModel);
                    }
                }

                // bool b = DB_Talk.DB.OpenDataBase(Pub._configModel.DBServer, Pub._configModel.DBName, Pub._configModel.DBUserName, Pub._configModel.DBPassword, new ExecuteErrorEventHandler(OleDbHelper_ExecuteError));
                procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "  正在连接数据库，请稍等...");
                if (OpenDataBase() == false)
                {
                    procDlg.Hide();
                    DialogResult dr = new DialogResult();
                    dr = (new frmDatabaseConfig()).ShowDialog();
                    if (dr == DialogResult.Cancel)
                    {
                        procDlg.Dispose();
                        return;
                    }
                }
                procDlg.Hide();

                if (Pub._configModel.IsAutoLogin)
                {
                    List<DB_Talk.Model.m_Manager> lst = new List<DB_Talk.Model.m_Manager>();
                    lst = new DB_Talk.BLL.m_Manager().GetModelList(string.Format("vc_UserName='{0}' and  i_Flag=0  ", "admin"));
                    Pub._configModel.LastUser = "admin";
                    if (lst != null && lst.Count > 0)
                    {
                        Pub.manageModel = lst[0];

                        if (Pub.manageModel.i_Dispatch.Value != 1)
                        {
                            MessageBoxEx.Show("当前用户没有调度权限，请联系管理员！", "提示");
                            return;
                        }

                        Config.WriteModel(Pub._configModel);
                        //选择Box;
                        FormSelectBox fs = new FormSelectBox();
                        if (fs.LoadBoxList() == true)
                        {
                            fs.ShowDialog();
                        }
                        
                        if (Pub.manageModel.BoxID == null)
                        {
                            MessageBoxEx.Show("请先到网管程序配置语音调度交换机", "提示");
                            return;
                        }

                        DB_Talk.Model.m_Box boxModel = new DB_Talk.BLL.m_Box().GetModel(Pub.manageModel.BoxID.Value);
                        if (boxModel == null)
                        {
                            MessageBoxEx.Show("请到网管程序增加MBox设备！", "提示");
                            return;
                        }

                        ///添加调度号码，取调度的前两个

                        List<DB_Talk.Model.m_Member> lstM = new List<DB_Talk.Model.m_Member>();

                        lstM = new DB_Talk.BLL.m_Member().GetModelList(string.Format("boxID={0} and i_isdispatch=1 and i_Flag=0", Pub.manageModel.BoxID));
                        if (lstM.Count >= 2)
                        {
                            Pub.manageModel.LeftDispatchNumber = lstM[0].i_Number;
                            Pub.manageModel.LeftDispatchName = lstM[0].vc_Name;

                            Pub.manageModel.RightDispatchNumber = lstM[1].i_Number;
                            Pub.manageModel.RightDispatchName = lstM[1].vc_Name;
                        }
                        else
                        {
                            MessageBoxEx.Show("请到网管程序添加调度号码！", "提示");
                            return;
                        }

                        lstM = new DB_Talk.BLL.m_Member().GetModelList(string.Format("boxID={0} and i_isdispatch=2 and i_Flag=0", Pub.manageModel.BoxID));
                        if (lstM != null && lstM.Count > 0)
                        {
                            Pub.VideoNumber = lstM[0].i_Number.Value.ToString();
                            Pub.VideoPassword = lstM[0].i_NuPassword.ToString();
                        }
                        else
                        {
                            if (Pub._configModel.IsVideoCall)
                            {
                                MessageBoxEx.Show("请到网管程序添加视频调度号码！", "提示");
                                return;
                            }
                        }

                        if (Pub._configModel.IsVideoCall)
                        {
                            if (Pub._configModel.VideoSize<=0 || Pub._configModel.VideoSize>=10)
                            {
                                 MessageBoxEx.Show("请设置合适的视频大小！", "提示");
                                return;
                            }
                        }
                        if (boxModel.i_MaxMeetingMember != null)
                        {
                            Pub._maxMeetingMemberCount = boxModel.i_MaxMeetingMember.Value;
                        }
                        CommControl.SystemLogBLL.WriteLog(
                            Pub.manageModel.ID, Pub.manageModel.BoxID.Value, SystemLogBLL.EnumLogAction.SystemOperate, "登录", "登录成功", "");
                    }
                    else
                    {
                        MessageBoxEx.Show("请先到网管程序进行配置！", "提示");
                        return;
                    }
                }
                else
                {
                    FormLogin frmLogin = new FormLogin(FormLogin.EnumLoginType.Login);
                    if (frmLogin.ShowDialog() == DialogResult.Cancel)
                    {
                        procDlg.Dispose();
                        return;
                    }
                }
                Pub.CanDestroyControl = false;
                //frmLogin.Dispose();
                List<DB_Talk.Model.m_Member> lstMember = new DB_Talk.BLL.m_Member().GetModelList(string.Format("i_Flag=0 and BoxID={0} order by id", Pub.manageModel.BoxID.Value));

                if (lstMember.Count == 0)
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("请先到网管软件增加用户", "提示");
                    return;
                }
                
                FormMain frmMain = new FormMain();
                //Form1 frmMain = new Form1();
                //frmMain.Width = 1;
                //frmMain.Height = 1;
                procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "  正在初始化程序，请稍等...");

                frmMain.WindowState = FormWindowState.Normal;
                frmMain.Show();//为了让加载主窗体滚动条显示出来
                frmMain.Visible = false;
                Pub._pageControl = Pub._meetingManage.GetToSelectPageControl();
                if (Pub._pageControl == null)
                {
                    procDlg.Hide();
                    MessageBoxEx.Show("请先到网管程序增加电话号码！", "提示");
                    return;
                }
                

                frmMain.ShowLoadOk();
                frmMain.Visible = true;
                int tt = 10000;//当所有用户的信息都上报之后LstMember.cout会等于0，如果意外情况下Box内部没有上报数据库中的号码的话，这里执行10000次自动跳过
                while (FormMain._lstMember.Count>0 && tt>=0)
                {
                    tt--;
                    System.Threading.Thread.Sleep(1);
                    Application.DoEvents();
                }
                
                frmMain.SetDispatchAndLoadState();
                frmMain.WindowState = System.Windows.Forms.FormWindowState.Maximized;

                procDlg.Hide();
                procDlg.Dispose();
                Pub._memberManage.ClickTab();
                frmMain.imgBtnMeeting_Click(null, null);
                Pub._meetingManage.ClickTab();
               
                
                frmMain.imgBtnDispatch_Click(null, null);
                frmMain.SetSortButton();
                Pub.CanDestroyControl = true;
                frmMain.SetDefaultMemberGroupIndex();
                frmMain.SetMenuSelect();
                //new Form1().ShowDialog();
                Application.Run(frmMain);

            }
            catch (Exception ex)
            {
                CommControl.Tools.WriteLog.AppendLog("Main:" + ex.Message + ex.StackTrace);
                //MessageBoxEx.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Environment.Exit(0);
            }
        }

        /// <summary>连接服务器/数据库</summary>
        public static bool OpenDataBase()
        {
            return DB_Talk.DB.OpenDataBase(Pub._configModel.DBServer,
                Pub._configModel.DBName,
                Pub._configModel.DBUserName,
                Pub._configModel.DBPassword,
                new ExecuteErrorEventHandler(OleDbHelper_ExecuteError));
        }


        private static void OleDbHelper_ExecuteError(object sender, ExecuteErrorEventArgs e)
        {
          //  AppendLog(e.Sql + "\r\n" + e.Exception.Message + e.Exception.StackTrace);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string strText, strCaption;
            strCaption = e.Exception.Source;
            strText = string.Format("Application_ThreadException：{0}\n\r方法名称:{1}", e.Exception.ToString(), e.Exception.TargetSite.Name);
            CommControl.Tools.WriteLog.AppendLog(strCaption + "\n\r" + strText);

           // CommControl.MessageBoxEx.MessageBoxEx.Show(e.Exception.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void UnhandledExceptionEventHandler(object sender, UnhandledExceptionEventArgs e)
        {
            string strText, strCaption;
            Exception ex = e.ExceptionObject as Exception;
            strCaption = ex.Source;
            strText = string.Format("UnhandledExceptionEventHandler：{0}\n\r方法名称:{1}", ex.ToString(), ex.TargetSite.Name);
            CommControl.Tools.WriteLog.AppendLog(strCaption + "\n\r" + strText);

         //   CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

