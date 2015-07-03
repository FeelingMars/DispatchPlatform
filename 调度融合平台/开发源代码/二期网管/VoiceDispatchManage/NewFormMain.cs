using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl;
using VoiceDispatchManage.UI;
using System.Runtime.InteropServices;

namespace VoiceDispatchManage
{
    public partial class NewFormMain : Form
    {
        #region 变量
        public delegate void BoxChangeEventHandle();
        public BoxChangeEventHandle boxChangeEvent;
        public delegate void MyEventHandler(int flag, string str);
        Tools.CheckOnLine checkOnline = new Tools.CheckOnLine();
        public Tools.GetStateSipPri getStateSipPri = new Tools.GetStateSipPri();
        public static event MyEventHandler LoadBoxError;
        #endregion

        #region 窗体控制

        public NewFormMain()
        {
            InitializeComponent();
            Global.Params.InitializeBoxFlag = MBoxSDK.ConfigSDK.MBOX_Initialize();
            //int i = MBoxSDK.ConfigSDK.MBOX_Login("10.20.31.1", "", "", "");
            // bool b = MBoxSDK.ConfigSDK.MBOX_CreateSubscriber(i, 8000);
            LoadBoxError += new MyEventHandler(FormMain_LoadBoxError);
            tvTree.DragDropEnabled = false;
        }

        void FormMain_LoadBoxError(int flag, string str)
        {
            if (flag == 0) //如果登录不成功，加载出错页面
            {
                frmError frm = new frmError();
                LoadControl(frm);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ShowSystemMenu();
            labTitle.Text = "";
            //  this.FormMaxed();
            LoadModelList(tvTree);
            tslState.Text = "登录用户：" + Global.Params.UserName;
            //Global.Params.LstBox = new DB_Talk.BLL.m_Box().GetModelList("i_Flag=0");
            /*
            try
            {
                Tools.AcrReportManage.Current.Init(Global.Params.ConfigModel.DBInfo.HostID,
                                                   Global.Params.ConfigModel.DBInfo.DatabaseName,
                                                   Global.Params.ConfigModel.DBInfo.Password,
                                                   Global.Params.FILE_PATH_REPORT);
            }
            catch
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("初始化打印模块失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
            }
            */


            checkOnline.Run();
            checkOnline.StateChange += new Tools.CheckOnLine.ConnectStateChange(checkOnline_StateChange);
            //getStateSipPri.Run();
            this.Top = 0;
            this.Left = 0;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            btnLogManage.ShowSubItems = true;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (DialogResult.Yes != CommControl.MessageBoxEx.MessageBoxEx.Show("是否退出系统?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                e.Cancel = true;
                return;
            }
            try
            {
                checkOnline._isStop = true;
                checkOnline.Stop();
                //getStateSipPri.Stop();

                Global.Params.LstBox = new List<DB_Talk.Model.m_Box>();
                MBoxSDK.ConfigSDK.MBOX_Logout(Global.Params.BoxHandle);
                MBoxSDK.ConfigSDK.MBOX_Dispose();
                Global.Params.BoxHandle = 0;

                //CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.SystemOperate,
                //                               "登出", "登出站点：" + Global.Params.BoxIP, "");
            }
            catch { }
        }

        #endregion

        #region 设置窗口显示属性
        [DllImport("User32.dll")]
        private static extern IntPtr SetWindowLong(IntPtr hwnd, IntPtr nIndex, IntPtr dwNewLong);
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowLong(IntPtr hwnd, IntPtr nIndex);
        private void ShowSystemMenu()
        {
            // if (_FormStyle == emFormStyle.WindowDefault) return;

            const long GWL_STYLE = (-16);
            const long WS_SYSMENU = 0x80000;    //带系统菜单的窗口
            const long WS_CAPTION = 0xC00000;   //带标题栏的窗口
            const long WS_MINIMIZEBOX = 0x20000;//最小化
            const long WS_MAXIMIZEBOX = 0x10000;//最大化


            //初始化部分
            IntPtr lStyle = GetWindowLong(this.Handle, (IntPtr)GWL_STYLE);
            long l = ((long)lStyle | WS_SYSMENU | WS_MINIMIZEBOX | WS_MAXIMIZEBOX) & ~WS_CAPTION;

            lStyle = (IntPtr)l;
            SetWindowLong(this.Handle, (IntPtr)GWL_STYLE, lStyle);
        }
        #endregion

        #region 菜单模块
        //Box管理
        private void tsBoxManage_Click(object sender, EventArgs e)
        {
            UI.frmBoxManage frm = new UI.frmBoxManage();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                LoadModelList(tvTree);
                panRight.Controls.Clear();
                labTitle.Text = "";
                //FormMain_LoadBoxError(0, "");
                //if (frmUserManage!=null) frmUserManage.loadRight();
            }

            RefushDataReport();
        }
        private void tsDepartmentManage_Click(object sender, EventArgs e)
        {
            new frmDepartmentManageMDI().ShowDialog();
        }
        //系统用户管理
        private void tsUserManage_Click(object sender, EventArgs e)
        {
            UI.frmUserManageMDI frm = new UI.frmUserManageMDI();
            frm.ShowDialog();
            //if (frm.DialogResult == DialogResult.OK)
            //{
            //    LoadModelList(tvTree);
            //    panRight.Controls.Clear();
            //    labTitle.Text = "";

            //}
        }
        private void RefushDataReport()
        {
            //foreach (UI.UserControlMid c in panRight.Controls)
            foreach (UserControl c in panRight.Controls)
            {
                UI.UserControlMid uMdi = c as UI.UserControlMid;
                if (uMdi != null)
                    uMdi.RefushDataReport();
            }

        }

        private void tsModifyPassWord_Click(object sender, EventArgs e)
        {

        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        UI.frmUserManage frmUserManage = new UI.frmUserManage();

        //告警日志
        private void tsAlarmLog_Click(object sender, EventArgs e)
        {
            Log.frmAlarmLog frm = new Log.frmAlarmLog();
            frm.ShowDialog();
        }

        //调度日志
        private void tsDispatchLog_Click_1(object sender, EventArgs e)
        {
            UI.frmDispatchLog frm = new UI.frmDispatchLog();
            frm.ShowDialog();
        }
        //操作日志
        private void tsOperateLog_Click(object sender, EventArgs e)
        {
            UI.frmSystemLog frm = new UI.frmSystemLog();
            frm.ShowDialog();
        }

        //设备在线状态改变事件
        public void checkOnline_StateChange(string IP, bool isConnect)
        {

            SetTreeState(IP, isConnect);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogManage_Click(object sender, EventArgs e)
        {
            btnLogManage.Expanded = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 私有方法

        public void LoadModelList()
        {
            LoadModelList(tvTree);
        }

        //加载菜单
        public void LoadModelList(DevComponents.AdvTree.AdvTree advTree)
        {

            advTree.Nodes.Clear();
            //基本菜单
            List<Global.menuType> listMenu = new List<Global.menuType>();
            foreach (Global.menuType item in Enum.GetValues(typeof(Global.menuType)))
            {
                listMenu.Add(item);
            }


            //高级配置子菜单
            List<Global.menuTypeG> listMenuG = new List<Global.menuTypeG>();
            foreach (Global.menuTypeG item in Enum.GetValues(typeof(Global.menuTypeG)))
            {
                listMenuG.Add(item);
            }

            //分组管理子菜单
            List<Global.menuTypeGroup> listMenuO = new List<Global.menuTypeGroup>();
            foreach (Global.menuTypeGroup item in Enum.GetValues(typeof(Global.menuTypeGroup)))
            {
                listMenuO.Add(item);
            }

            //3G子菜单
            List<Global.menuType3G> listMenu3G = new List<Global.menuType3G>();
            foreach (Global.menuType3G item in Enum.GetValues(typeof(Global.menuType3G)))
            {
                listMenu3G.Add(item);
            }



            List<DB_Talk.Model.m_Box> ListBox = Global.Params.LstBox;//new DB_Talk.BLL.m_Box().GetModelList("i_Flag=0");


            List<DB_Talk.Model.m_Box> lstTemp = Global.Params.LstBox.Where(w => w.i_Flag == 1).ToList();
            Image imageMain = Properties.Resources.red;
            if (lstTemp.Count == 0)
            {
                imageMain = Properties.Resources.red;
            }
            else if (lstTemp.Count == Global.Params.LstBox.Count)
            {
                imageMain = Properties.Resources.green;
            }
            else
            {
                imageMain = Properties.Resources.yellow;
            }

            DevComponents.AdvTree.Node node0;
            DevComponents.AdvTree.Node nodeMenu;
            DevComponents.AdvTree.Node nodeBox;
            node0 = new DevComponents.AdvTree.Node();
            node0.Text = "所有站点";
            node0.Name = "所有站点";
            node0.CheckBoxVisible = false;
            node0.Image = imageMain;
            node0.Expanded = true;

            Image image = Properties.Resources.red;
            bool isLoadBox = false;
            foreach (DB_Talk.Model.m_Box item in ListBox)
            {
                if (item.i_Flag == 1)
                    image = Properties.Resources.green;
                else
                    image = Properties.Resources.red;
                nodeBox = new DevComponents.AdvTree.Node();
                nodeBox.Text = item.vc_Name + "(" + item.vc_IP + ")";
                nodeBox.Name = item.ID.ToString();
                nodeBox.Tag = item.vc_IP;

                nodeBox.Image = image;
                nodeBox.Expanded = true;
                LoadBox(item.vc_IP);

                #region

                foreach (Global.menuType type in listMenu)
                {
                    if (type == Global.menuType.基站管理 && Global.Params.BoxType != MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000_3G)
                    {
                        continue;
                    }
                    nodeMenu = new DevComponents.AdvTree.Node();
                    nodeMenu.Text = type.ToString().Replace("G3G", "3G");
                    nodeMenu.Name = type.ToString();
                    nodeMenu.CheckBoxVisible = false;
                    nodeMenu.Image = image;
                    nodeMenu.Expanded = true;
                    nodeMenu.Tag = type;

                    nodeMenu.NodeClick += new EventHandler(nodeMenu_NodeClick);
                    //node0.Nodes.Add(nodeMenu);
                    nodeBox.Nodes.Add(nodeMenu);


                    if (type.ToString() == Global.menuType.高级配置.ToString())
                    {
                        foreach (Global.menuTypeG str in listMenuG)
                        {
                            if (str == Global.menuTypeG.静态路由管理 && Global.Params.BoxType != MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000_3G)
                            {
                                continue;
                            }
                            DevComponents.AdvTree.Node nodeG = new DevComponents.AdvTree.Node();
                            nodeG.Text = str.ToString();
                            nodeG.Name = str.ToString();
                            nodeG.CheckBoxVisible = false;
                            nodeG.Image = image;
                            nodeG.Expanded = true;
                            nodeG.Tag = str;
                            nodeG.NodeClick += new EventHandler(nodeMenuG_NodeClick);
                            nodeMenu.Nodes.Add(nodeG);
                            nodeMenu.Expanded = false;
                        }

                    }
                    if (type.ToString() == Global.menuType.分组管理.ToString())
                    {
                        foreach (Global.menuTypeGroup str in listMenuO)
                        {
                            DevComponents.AdvTree.Node nodeO = new DevComponents.AdvTree.Node();
                            nodeO.Text = str.ToString();
                            nodeO.Name = str.ToString();
                            nodeO.CheckBoxVisible = false;
                            nodeO.Image = image;
                            nodeO.Expanded = true;
                            nodeO.Tag = str;
                            nodeO.NodeClick += new EventHandler(nodeGroup_NodeClick);
                            nodeMenu.Nodes.Add(nodeO);
                            nodeMenu.Expanded = false;
                        }
                    }



                }
                #endregion

                node0.Nodes.Add(nodeBox);
            }
            advTree.Nodes.Add(node0);


        }

        //3G子节点点击事件
        void node3G_NodeClick(object sender, EventArgs e)
        {

            DevComponents.AdvTree.TreeNodeMouseEventArgs arg = (DevComponents.AdvTree.TreeNodeMouseEventArgs)e;
            Global.Params.BoxID = int.Parse(arg.Node.Parent.Parent.Name.ToString());
            Global.Params.BoxIP = arg.Node.Parent.Parent.Tag.ToString();
            if (LoadBox(Global.Params.BoxIP))
            {
                if (arg.Node.Name.ToString() == Global.menuType3G.基本配置.ToString())
                {
                    frm3GBase frm = new frm3GBase();
                    LoadControl(frm);
                }
                else if (arg.Node.Name.ToString() == Global.menuType3G.分组网关管理.ToString())
                {
                    frmPDSList frm = new frmPDSList();
                    LoadControl(frm);
                }
                else if (arg.Node.Name.ToString() == Global.menuType3G.静态路由管理.ToString())
                {
                    frmStaticRouteList frm = new frmStaticRouteList();
                    LoadControl(frm);
                }
                else if (arg.Node.Name.ToString() == Global.menuType3G.基站管理.ToString())
                {
                    frmFapList frm = new frmFapList();
                    LoadControl(frm);
                }

            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("登录站点[" + Global.Params.BoxIP + "]失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        //节点点击事件
        private void nodeMenu_NodeClick(object sender, EventArgs e)
        {
            try
            {
                DevComponents.AdvTree.TreeNodeMouseEventArgs arg = (DevComponents.AdvTree.TreeNodeMouseEventArgs)e;
                Global.Params.BoxID = int.Parse(arg.Node.Parent.Name.ToString());
                Global.Params.BoxIP = arg.Node.Parent.Tag.ToString();
                if (arg.Node.Name.ToString() == Global.menuType.基本配置.ToString() ||
                    arg.Node.Name.ToString() == Global.menuType.用户号码.ToString() ||
                    arg.Node.Name.ToString() == Global.menuType.出局通话配置.ToString() ||
                     arg.Node.Name.ToString() == Global.menuType.基站管理.ToString() ||
                arg.Node.Name.ToString() == Global.menuType.短信配置.ToString())
                {
                    if (LoadBox(Global.Params.BoxIP))
                    {
                        //Global.Params.BoxID = int.Parse(arg.Node.Name.ToString());
                        //Global.Params.BoxIP = arg.Node.Tag.ToString();
                        if (arg.Node.Name.ToString() == Global.menuType.基本配置.ToString())
                        {
                            UI.frmDispatchNumber frm = new UI.frmDispatchNumber();
                            LoadControl(frm);
                            return;

                        }
                        else if (arg.Node.Name.ToString() == Global.menuType.用户号码.ToString())
                        {
                            SystemUserManage frm = new SystemUserManage();
                            LoadControl(frm);
                            return;
                        }
                        else if (arg.Node.Name.ToString() == Global.menuType.出局通话配置.ToString())
                        {
                            UI.frmSIPPRI frm = new UI.frmSIPPRI();
                            LoadControl(frm);
                            return;
                        }
                        else if (arg.Node.Name.ToString() == Global.menuType3G.基站管理.ToString())
                        {
                            frmFapList frm = new frmFapList();
                            frm.LoadData();
                            LoadControl(frm);
                        }
                        else if (arg.Node.Name.ToString() == Global.menuType.短信配置.ToString())
                        {
                            frmSMSConfig frm = new frmSMSConfig();
                            //frm.LoadData();
                            LoadControl(frm);
                        }

                    }
                    else
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("登录站点[" + Global.Params.BoxIP + "]失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }

            }
            catch (Exception ex)
            {
                CommControl.Tools.WriteLog.AppendErrorLog("Main:" + ex.Message + ex.StackTrace);
            }

        }
        //分组节点点击事件
        private void nodeGroup_NodeClick(object sender, EventArgs e)
        {
            CommControl.PublicEnums.EnumGroupType GroupType = CommControl.PublicEnums.EnumGroupType.none;
            DevComponents.AdvTree.TreeNodeMouseEventArgs arg = (DevComponents.AdvTree.TreeNodeMouseEventArgs)e;
            Global.Params.BoxID = int.Parse(arg.Node.Parent.Parent.Name.ToString());
            Global.Params.BoxIP = arg.Node.Parent.Parent.Tag.ToString();
            if (arg.Node.Name.ToString() == Global.menuTypeGroup.调度分组.ToString())
            {
                GroupType = PublicEnums.EnumGroupType.Normal;
            }
            else if (arg.Node.Name.ToString() == Global.menuTypeGroup.会议分组.ToString())
            {
                GroupType = PublicEnums.EnumGroupType.Meeting;
            }
            else if (arg.Node.Name.ToString() == Global.menuTypeGroup.摄像头分组.ToString())
            {
                GroupType = PublicEnums.EnumGroupType.Camera;
            }
            UI.frmGroupManage frm = new UI.frmGroupManage(GroupType);
            LoadControl(frm);

        }
        //高级菜单节点点击事件
        private void nodeMenuG_NodeClick(object sender, EventArgs e)
        {
            frmUserManage = null;
            DevComponents.AdvTree.TreeNodeMouseEventArgs arg = (DevComponents.AdvTree.TreeNodeMouseEventArgs)e;
            Global.Params.BoxID = int.Parse(arg.Node.Parent.Parent.Name.ToString());
            Global.Params.BoxIP = arg.Node.Parent.Parent.Tag.ToString();
            if (LoadBox(Global.Params.BoxIP))
            {
                if (arg.Node.Name.ToString() == Global.menuTypeG.PRI时钟源配置.ToString())
                {
                    frmPRIClock frm = new frmPRIClock();
                    //frmSIPSet frm = new frmSIPSet();
                    LoadControl(frm);
                }
                else if (arg.Node.Name.ToString() == Global.menuTypeG.呼叫规则配置.ToString())
                {
                    frmCalledRuleList frm = new frmCalledRuleList();
                    LoadControl(frm);
                }
                else if (arg.Node.Name.ToString() == Global.menuType3G.静态路由管理.ToString())
                {
                    frmStaticRouteList frm = new frmStaticRouteList();
                    LoadControl(frm);
                }
                else if (arg.Node.Name.ToString() == Global.menuTypeG.恢复出厂设置.ToString())
                {
                    FrmClearDeviceCfg frm = new FrmClearDeviceCfg();
                    LoadControl(frm);

                    //  LoadModelList(tvTree);
                    /*
                   
                     */
                }
                else if (arg.Node.Name.ToString() == Global.menuTypeG.备份还原配置.ToString())
                {
                    frmFtpUpAndDown frm = new frmFtpUpAndDown();
                    LoadControl(frm);
                }
                else if (arg.Node.Name.ToString() == Global.menuTypeG.重启设备.ToString())
                {
                    frmReStart frm = new frmReStart();
                    LoadControl(frm);

                }

            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("登录站点[" + Global.Params.BoxIP + "]失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }
        //加载组
        private void loadGroup(CommControl.PublicEnums.EnumGroupType GroupType, DevComponents.AdvTree.Node nodeParent)
        {
            List<DB_Talk.Model.m_Group> ListGroup = new DB_Talk.BLL.m_Group().GetModelList("i_Flag=0 and GroupTypeID='" +
                                                    GroupType.GetHashCode() + "'");
            nodeParent.Nodes.Clear();
            DevComponents.AdvTree.Node nodeGroup;
            foreach (DB_Talk.Model.m_Group g in ListGroup)
            {
                nodeGroup = new DevComponents.AdvTree.Node();
                nodeGroup.Text = g.vc_Name.ToString();
                nodeGroup.Name = g.ID.ToString();
                nodeGroup.CheckBoxVisible = false;
                nodeGroup.Image = Properties.Resources.red;
                nodeGroup.Expanded = true;
                nodeGroup.Tag = g.ID;
                nodeParent.Nodes.Add(nodeGroup);
                nodeGroup.NodeClick += new EventHandler(nodeGroup_NodeClick);
            }
        }
        //右边panel加载control
        private void LoadControl(UserControl frm)
        {
            if (frm == null)
            {
                panRight.Controls.Clear();
                labTitle.Text = "当前站点IP:" + Global.Params.BoxIP + "。    ";
            }
            else
            {
                panRight.Controls.Clear();
                frm.Show();
                frm.Dock = DockStyle.Fill;
                panRight.Visible = false;
                panRight.Controls.Add(frm);
                System.Threading.Thread.Sleep(150);
                panRight.Visible = true;
                if (frm.Name == "frmError")
                    labTitle.Text = "当前站点IP:" + Global.Params.BoxIP + "。    ";
                else
                    labTitle.Text = "当前站点IP:" + Global.Params.BoxIP + ",当前模块:" + frm.Text + "。    ";
            }
        }

        private void SetTreeState(string IP, bool isConnect)
        {
            try
            {

                foreach (DevComponents.AdvTree.Node nodeMain in tvTree.Nodes)
                {
                    foreach (DevComponents.AdvTree.Node node in nodeMain.Nodes)
                    {
                        if (node.Tag != null && node.Tag.ToString() == IP)
                        {
                            if (isConnect)
                                node.Image = Properties.Resources.green;
                            else
                                node.Image = Properties.Resources.red;
                            SetTreeViewNode(node.Nodes, isConnect);
                        }
                    }
                }
                List<DB_Talk.Model.m_Box> lstTemp = Global.Params.LstBox.Where(w => w.i_Flag == 1).ToList();
                if (lstTemp.Count == 0)
                {
                    tvTree.Nodes[0].Image = Properties.Resources.red;
                }
                else if (lstTemp.Count == Global.Params.LstBox.Count)
                {
                    tvTree.Nodes[0].Image = Properties.Resources.green;
                }
                else
                {
                    tvTree.Nodes[0].Image = Properties.Resources.yellow;
                }
            }
            catch
            {

            }

        }

        public void SetTreeViewNode(DevComponents.AdvTree.NodeCollection node, bool isConnect)
        {
            foreach (DevComponents.AdvTree.Node n in node)
            {
                if (isConnect)
                    n.Image = Properties.Resources.green;
                else
                    n.Image = Properties.Resources.red;
                SetTreeViewNode(n.Nodes, isConnect);
            }
        }

        //恢复出厂设置时清空数据库
        private bool ClearDispatchTell()
        {
            List<DB_Talk.Model.m_Member> lst = new DB_Talk.BLL.m_Member().GetModelList(" i_Flag=0 and BoxID='" + Global.Params.BoxID + "' and i_IsDispatch=1");
            foreach (DB_Talk.Model.m_Member m in lst)
            {
                //2013-6-13 修改，在删除前判断，存在的号码才删除（因为有时候数据库里面有的号码，box里面没有，直接删除会返回false）
                bool IsExist = MBoxSDK.ConfigSDK.MBOX_IsSubscriberExist(Global.Params.BoxHandle, m.i_Number.Value);
                if (IsExist)
                {
                    if (MBoxSDK.ConfigSDK.MBOX_DeleteSubscriber(Global.Params.BoxHandle, (m.i_Number.Value)))
                    {
                        new DB_Talk.BLL.m_Member().Delete(m.ID);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool LoadBox(string BoxIP)
        {
            // return true;

            //登录box
            Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
            bool b = false;
            try
            {
                procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在登录" + Global.Params.BOXNAME + "【" + BoxIP + "】,请稍等...");
                if (Global.Params.BoxHandle > 0)
                {
                    //MBoxSDK.ConfigSDK.MBOX_Logout(Global.Params.BoxHandle);
                    Global.Params.BoxHandle = 0;
                }
                Global.Params.BoxHandle = MBoxSDK.ConfigSDK.MBOX_Login(BoxIP, "", "", "");

                b = Global.Params.BoxHandle > 0 ? true : false;
                b = b && MBoxSDK.ConfigSDK.MBOX_IsDeviceOnline(BoxIP);

                if (b)
                {
                    Global.Params.BoxType = Global.Methods.GetBoxType(Global.Params.BoxHandle);
                    int iFind = Global.Params.LstBox.FindIndex(item => item.vc_IP == Global.Params.BoxIP);
                    if (iFind >= 0) Global.Params.LstBox[iFind].i_Flag = 1;
                    // Global.Params.LstBox.Find(item => item.vc_IP == Global.Params.BoxIP).i_Flag = 1;
                    //b =Tools.MBoxOperate.CreateCalinglSourceRule();
                }

                Global.Params.frmMain.checkOnline_StateChange(Global.Params.BoxIP, b);
                LoadBoxError(b == true ? 1 : 0, "");
            }
            catch (Exception ex)
            {
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
            }
            finally
            {
                procDlg.Dispose();
            }
            return b;
        }

        public void ReStartBox()
        {
            MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);
            if (Global.Params.IsRestart)
            {
                Global.Params.IsRestart = false;
                Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
                procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "正在重启站点【" + Global.Params.BoxIP + "】,请稍等...");
                MBoxSDK.ConfigSDK.MBOX_Restart(Global.Params.BoxHandle);
                int iFind = Global.Params.LstBox.FindIndex(item => item.vc_IP == Global.Params.BoxIP);
                if (iFind >= 0) Global.Params.LstBox[iFind].i_Flag = 0;
                checkOnline_StateChange(Global.Params.BoxIP, false);
                System.Threading.Thread.Sleep(5000);
                procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "重启站点【" + Global.Params.BoxIP + "】成功...");
                //CommControl.MessageBoxEx.MessageBoxEx.Show("重启设备【" + Global.Params.BoxIP + "】成功", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                System.Threading.Thread.Sleep(500);
                procDlg.Dispose();
            }
        }

        #endregion





















    }
}
