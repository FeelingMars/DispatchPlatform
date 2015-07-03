using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using DevComponents.DotNetBar;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;
using DispatchPlatform.Control;

namespace DispatchPlatform
{
    public class Pub
    {


        /// <summary>
        /// 配置
        /// </summary>
        public static ConfigModel _configModel = new ConfigModel();

        /// <summary>调度控制</summary>
        public static TalkControl _talkControl = new TalkControl();
        /// <summary>
        /// 操作用户信息
        /// </summary>
        public static DB_Talk.Model.m_Manager manageModel = new DB_Talk.Model.m_Manager();

        /// <summary> 成员管理</summary>
        public static MemberManage _memberManage = null;

        /// <summary> 会议管理 </summary>
        public static MeetingManage _meetingManage = null;

        /// <summary> 当前已选择的会议成员个数,已开始的会议成员</summary>
        public static int _currentSelectMeetingMemberCount = 0;

        /// <summary>
        /// 视频调度号码
        /// </summary>
        public static string VideoNumber;

        /// <summary>
        /// 视频调度号码密码
        /// </summary>
        public static string VideoPassword;

        /// <summary>
        /// 最大会议成员数
        /// </summary>
        public static int _maxMeetingMemberCount = 15;

        /// <summary>
        /// 弹出紧急呼叫窗体
        /// </summary>
        public static FormLemcWait _lemcWaitForm = null;

        /// <summary>
        /// 临时会议选人用的控件
        /// </summary>
        public static PageControl _pageControl = null;

        /// <summary>是否销毁控件</summary>
        public static bool CanDestroyControl = false;


        /// <summary>数据库是否在线</summary>
        public  static bool _isDBOnline = true;

        /// <summary>
        /// 调度交换机名称
        /// </summary>
        public static string BoxName = "";

        /// <summary>
        /// 是否可以删除数据库中用户状态信息
        /// </summary>
        public static bool CanDeleteMemberState = false;

        /// <summary>
        /// 是否要以执行排序
        /// </summary>
        public static bool CanSort = false;

        public static void KillPrecess(string name)
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process item in ps)
            {
                if (item.ProcessName == name)
                {
                    item.Kill();
                }
            }
        }

        /// <summary>
        /// 号码控件字体大小配置
        /// </summary>
        public static FontSizeConfig LableFontConfig = new FontSizeConfig();

        /// <summary>
        /// 是否设置字体大小
        /// </summary>
        public static bool CanSetFontConfig = false;

        public static Color TabNormalColor =Color.FromArgb(126, 132, 146);

        public static Color TabSelectColor = Color.FromArgb(232, 233, 235);

        /// <summary>
        /// 等待提示信息
        /// </summary>
        public static string waitMsg = "";

        public static SingleUserControl CurrentDispatchControl;
        #region 记录操作状态


        /// <summary>
        /// 写用户状态
        /// </summary>
        /// <param name="number"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public static bool WriteMemberState(long dispatchNumber, long number, long peerNumber, TalkControl.EnumUserLineStatus uState)
        {
            DB_Talk.BLL.Data_MemberState memberBLL = new DB_Talk.BLL.Data_MemberState();

            List<DB_Talk.Model.Data_MemberState> lstMember = new List<DB_Talk.Model.Data_MemberState>();

            lstMember = memberBLL.GetModelList(string.Format("i_Number={0} and i_State={1} and i_dispatchNumber={2}", number, uState.GetHashCode(), dispatchNumber));
            if (lstMember.Count > 0)
            {
                lstMember[0].i_State = uState.GetHashCode();
                lstMember[0].i_PeerNumber = peerNumber;
                lstMember[0].i_DispatchNumber = dispatchNumber;
                return memberBLL.Update(lstMember[0]);
            }
            else
            {
                DB_Talk.Model.Data_MemberState model = new DB_Talk.Model.Data_MemberState();
                model.i_Number = number;
                model.i_State = uState.GetHashCode();
                model.i_PeerNumber = peerNumber;
                model.i_DispatchNumber = dispatchNumber;
                if ((new DB_Talk.BLL.Data_MemberState()).Add(model) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>得到号码状态</summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static DB_Talk.Model.Data_MemberState GetMemberModel(long dispatchNumber, long number, TalkControl.EnumUserLineStatus uState)
        {
            DB_Talk.BLL.Data_MemberState memberBLL = new DB_Talk.BLL.Data_MemberState();

            List<DB_Talk.Model.Data_MemberState> lstMember = new List<DB_Talk.Model.Data_MemberState>();

            lstMember = memberBLL.GetModelList(string.Format("i_Number={0} and i_State={1} and i_dispatchNumber={2}", number, uState.GetHashCode(), dispatchNumber));
            if (lstMember.Count > 0)
            {
                return lstMember[0];
            }
            return null;
        }

        /// <summary>根据自已和对方号码得到号码状态</summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static DB_Talk.Model.Data_MemberState GetMemberModelBySelf(long selfNumber, TalkControl.EnumUserLineStatus uState)
        {
            DB_Talk.BLL.Data_MemberState memberBLL = new DB_Talk.BLL.Data_MemberState();

            List<DB_Talk.Model.Data_MemberState> lstMember = new List<DB_Talk.Model.Data_MemberState>();

            lstMember = memberBLL.GetModelList(string.Format("(i_Number={0} or i_PeerNumber={0}) and i_State={1}", selfNumber, uState.GetHashCode()));
            if (lstMember.Count > 0)
            {
                return lstMember[0];
            }
            return null;
        }

        /// <summary> 删除状态信息 </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool DeleteMemberState(long number)
        {
            DB_Talk.BLL.Data_MemberState memberBLL = new DB_Talk.BLL.Data_MemberState();

            List<DB_Talk.Model.Data_MemberState> lstMember = new List<DB_Talk.Model.Data_MemberState>();

            try
            {
                if (Pub._isDBOnline == true)
                {
                    lstMember = memberBLL.GetModelList("i_Number=" + number);
                    if (lstMember.Count > 0)
                    {
                        return memberBLL.Delete(lstMember[0].ID);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// 根据调度号码显示调度的名称 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string GetDispatchNameByNumber(long number)
        {
            if (number==manageModel.LeftDispatchNumber)
            {
                return manageModel.LeftDispatchName;
            }
            if (number==manageModel.RightDispatchNumber)
            {
                return manageModel.RightDispatchName;
            }
            return number.ToString();
        }
             
        /// <summary>
        /// 根据调度号码删除
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool DeleteMemberStateByDispatchNumber(long dispatchNumber, TalkControl.EnumUserLineStatus uState)
        {
            DB_Talk.BLL.Data_MemberState memberBLL = new DB_Talk.BLL.Data_MemberState();

            List<DB_Talk.Model.Data_MemberState> lstMember = new List<DB_Talk.Model.Data_MemberState>();

            lstMember = memberBLL.GetModelList(string.Format("i_DispatchNumber={0} and i_State={1}", dispatchNumber, uState.GetHashCode()));
            if (lstMember.Count > 0)
            {
                return memberBLL.Delete(lstMember[0].ID);
            }
            return false;
        }

        /// <summary> 删除状态信息 </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool DeleteMemberState(long number,TalkControl.EnumUserLineStatus uState)
        {
            DB_Talk.BLL.Data_MemberState memberBLL = new DB_Talk.BLL.Data_MemberState();

            List<DB_Talk.Model.Data_MemberState> lstMember = new List<DB_Talk.Model.Data_MemberState>();

            lstMember = memberBLL.GetModelList(string.Format("i_Number={0} and i_State={1}", number, uState.GetHashCode()));
            if (lstMember.Count > 0)
            {
                return memberBLL.Delete(lstMember[0].ID);
            }
            return false;
        }

        #endregion

        /// <summary>
        /// 得到对方号码和自身号码
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string GetDispatchedNumbers(long number)
        {
            string ss = number.ToString();
            SingleUserControl sc = Pub._memberManage.GetSingleControl(number);
            if (sc != null)
            {
                if (sc.PeerNumber != "0")
                {
                    ss = ss + "," + sc.PeerNumber;
                }
            }
            return ss;
        }

        /// <summary>
        /// 统一设置Tab颜色
        /// </summary>
        /// <param name="item"></param>
        public static void SetSupperTabColor(SuperTabItem item)
        {
            item.TabFont=new Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            item.SelectedTabFont = new Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            item.TabColor = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable()
            {
                Default = new DevComponents.DotNetBar.Rendering.SuperTabColorStates()
                {
                    Normal = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable()
                    {
                        Background = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
                        {
                            Colors = new System.Drawing.Color[] { Pub.TabNormalColor }
                        },
                        Text = Color.White
                    },
                    Selected = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable()
                    {
                        Background = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
                        {
                            Colors = new System.Drawing.Color[] { Pub.TabSelectColor }
                        },
                        Text = Color.Black
                    },
                    MouseOver = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable()
                    {
                        Background = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable()
                        {
                            Colors = new System.Drawing.Color[] { Color.White, Color.FromArgb(255, 192, 128) }
                        }
                    }

                }
            };
        }

        /// <summary>
        /// 设置开机自动运行
        /// </summary>
        /// <param name="rr"></param>
        public static void SetAutoRun(bool rr)
        {
            //开机启动
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey run = hklm.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            string fileName = System.IO.Path.GetFileName(Application.ExecutablePath);
            try
            {
                if (rr)
                {
                    run.SetValue(fileName, Application.ExecutablePath);
                }
                else
                {
                    run.DeleteValue(fileName);
                }
                hklm.Close();
            }
            catch (Exception my)
            {

            }
        }

        /// <summary>
        /// 基站信息
        /// </summary>
        public static Dictionary<string, int> DicFap = new Dictionary<string, int>();

        /// <summary>
        /// 根据列信息设置字体大小，行间距
        /// </summary>
        /// <param name="col"></param>
        public static void GetFontSizeConfig(int col)
        {
            Screen screen = Screen.PrimaryScreen;
            int width = screen.Bounds.Width;

            if (width == 1280)
            {
                #region 1280
                Pub.CanSetFontConfig = true;

                switch (col)
                {
                    case 4:
                        Pub.LableFontConfig.NumberNameFontSize = 13;
                        // Pub.LableFontConfig.NumberNameLeft = 74;
                        //Pub.LableFontConfig.NumberNameWidth = 200;
                        //Pub.LableFontConfig.NumberNameHeight = 20;
                        break;
                    case 5:
                        Pub.LableFontConfig.NumberNameFontSize = 10;
                        //Pub.LableFontConfig.NumberNameLeft = 35;
                        //Pub.LableFontConfig.NumberNameWidth = 180;
                        //Pub.LableFontConfig.NumberNameHeight = 16;
                        break;
                    case 6:
                        Pub.LableFontConfig.NumberNameFontSize = 9;
                        //Pub.LableFontConfig.NumberNameLeft = 29;
                        //Pub.LableFontConfig.NumberNameWidth = 150;
                        //Pub.LableFontConfig.NumberNameHeight = 13;
                        break;
                    case 7:
                        Pub.LableFontConfig.NumberNameFontSize = 9;
                        // Pub.LableFontConfig.NumberNameLeft = 17;
                        //Pub.LableFontConfig.NumberNameWidth = 140;
                        //Pub.LableFontConfig.NumberNameHeight = 12;
                        break;
                    case 8:
                        Pub.LableFontConfig.NumberNameFontSize = 8.3F;
                        // Pub.LableFontConfig.NumberNameLeft = -5;
                        //Pub.LableFontConfig.NumberNameWidth = 140;
                        //Pub.LableFontConfig.NumberNameHeight = 12;
                        break;
                    default:
                        break;
                }
                #endregion
            }

            if (width == 1440)
            {
                #region 1440

                Pub.CanSetFontConfig = true;
                switch (col)
                {
                    case 4:
                        Pub.LableFontConfig.NumberNameFontSize = 15;
                        Pub.LableFontConfig.NumberNameTop = 10;
                        Pub.LableFontConfig.NumberNameInteval = 10;
                        break;
                    case 5:
                        Pub.LableFontConfig.NumberNameFontSize = 13;
                        //  Pub.LableFontConfig.NumberNameLeft = 50;
                        //Pub.LableFontConfig.NumberNameWidth = 200;
                        //Pub.LableFontConfig.NumberNameHeight = 23;
                        break;
                    case 6:
                        Pub.LableFontConfig.NumberNameFontSize = 11;
                        //  Pub.LableFontConfig.NumberNameLeft = 37;
                        //Pub.LableFontConfig.NumberNameWidth = 170;
                        //Pub.LableFontConfig.NumberNameHeight = 20;
                        break;
                    case 7:
                        Pub.LableFontConfig.NumberNameFontSize = 10;
                        //  Pub.LableFontConfig.NumberNameLeft = 16;
                        //Pub.LableFontConfig.NumberNameWidth = 160;
                        //Pub.LableFontConfig.NumberNameHeight = 18;
                        break;
                    case 8:
                        Pub.LableFontConfig.NumberNameFontSize = 9;
                        //   Pub.LableFontConfig.NumberNameLeft = 11;
                        //Pub.LableFontConfig.NumberNameWidth = 140;
                        //Pub.LableFontConfig.NumberNameHeight = 18;
                        break;
                    default:
                        break;
                }
                #endregion
            }

            if (width == 1920)
            {
                #region 1920
                string[] ss;

                Pub.CanSetFontConfig = true;
                switch (col)
                {
                    case 4:
                        // ss = Pub._configModel.FontSet4.Split(',');
                        Pub.LableFontConfig.NumberNameFontSize = 24;
                        Pub.LableFontConfig.NumberNameTop = 11;
                        Pub.LableFontConfig.NumberNameInteval = 11;
                        break;
                    case 5:
                        //ss = Pub._configModel.FontSet5.Split(',');
                        Pub.LableFontConfig.NumberNameFontSize = 21;
                        Pub.LableFontConfig.NumberNameTop = 9;
                        Pub.LableFontConfig.NumberNameInteval = 9;

                        break;
                    case 6:
                        //ss = Pub._configModel.FontSet6.Split(',');
                        Pub.LableFontConfig.NumberNameFontSize = 18;
                        Pub.LableFontConfig.NumberNameTop = 8;
                        Pub.LableFontConfig.NumberNameInteval = 8;

                        break;
                    case 7:
                        //ss = Pub._configModel.FontSet7.Split(',');
                        Pub.LableFontConfig.NumberNameFontSize = 16;
                        Pub.LableFontConfig.NumberNameTop = 7;
                        Pub.LableFontConfig.NumberNameInteval = 7;

                        break;
                    case 8:
                        //ss = Pub._configModel.FontSet8.Split(',');
                        Pub.LableFontConfig.NumberNameFontSize = 14;
                        Pub.LableFontConfig.NumberNameTop = 6;
                        Pub.LableFontConfig.NumberNameInteval = 6;

                        break;
                    default:
                        break;
                }
                #endregion
            }
        }
        /// <summary>
        /// 更新控件的字体大小，行间距
        /// </summary>
        /// <param name="sc"></param>
        public static void UpdateSingleUserContorlFont(SingleUserControl sc)
        {
            if (Pub.CanSetFontConfig)
            {
                sc.lblSelfName.AutoSize = true;
                sc.lblSelfName.BringToFront();
                sc.Top = Pub.LableFontConfig.NumberNameTop;
                sc.lblSelfName.Font = new System.Drawing.Font("宋体", Pub.LableFontConfig.NumberNameFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));// new Font("宋体", fontSize, FontStyle.Bold);
                if (sc.lblSelfName.Width > sc.Width)
                {
                    sc.lblSelfName.Left = 0;
                }
                else
                {
                    //居中显示 
                    sc.lblSelfName.Left = (sc.Width - sc.lblSelfName.Width) / 2;
                }

                sc.lblSelfNumber.AutoSize = true;
                sc.lblSelfNumber.Font = new System.Drawing.Font("宋体", Pub.LableFontConfig.NumberNameFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));// new Font("宋体", fontSize, FontStyle.Bold);
                sc.lblSelfNumber.Top = sc.lblSelfName.Top + sc.lblSelfName.Height + Pub.LableFontConfig.NumberNameInteval;
                sc.lblSelfNumber.Left = (sc.Width - sc.lblSelfNumber.Width) / 2;

                sc.lblPeerNumber.AutoSize = true;
                // _lstBtn[i].lblPeerNumber.SendToBack();
                sc.lblPeerNumber.Font = new System.Drawing.Font("宋体", Pub.LableFontConfig.NumberNameFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));// new Font("宋体", fontSize, FontStyle.Bold);
                sc.lblPeerNumber.Top = sc.lblSelfNumber.Top + sc.lblSelfNumber.Height + Pub.LableFontConfig.NumberNameInteval;
                sc.lblPeerNumber.Left = (sc.Width - sc.lblPeerNumber.Width) / 2;

                if (sc.IsDispatch)
                {
                    sc.lblSelfName.AutoSize = true;
                    sc.lblSelfName.Font = new System.Drawing.Font("宋体", 15, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));// new Font("宋体", fontSize, FontStyle.Bold);
                    sc.lblSelfName.Left = (sc.Width - sc.lblSelfName.Width) - 6;


                    sc.lblPeerNumber.AutoSize = true;
                    sc.lblPeerNumber.Font = new System.Drawing.Font("宋体", 14, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));// new Font("宋体", fontSize, FontStyle.Bold);
                    sc.lblPeerNumber.Left = (sc.Width - sc.lblPeerNumber.Width) - 6;
                    sc.lblPeerNumber.Top = sc.lblSelfName.Top + sc.lblSelfName.Height + 3;

                    sc.lblPeerNumberName.AutoSize = true;
                    sc.lblPeerNumberName.Font = new System.Drawing.Font("宋体", 14, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));// new Font("宋体", fontSize, FontStyle.Bold);
                    sc.lblPeerNumberName.Left = (sc.Width - sc.lblPeerNumberName.Width) - 6;
                    sc.lblPeerNumberName.Top = sc.lblPeerNumber.Top + sc.lblPeerNumber.Height + 3;
                }
            }
        }

    }
}
