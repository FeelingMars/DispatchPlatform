using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bestway.Windows.Tools.ADODB;
using BW_GridStyle;
using System.Windows.Forms;

namespace VoiceDispatchManage
{
    public static class Global
    {
        //全局变量
        public static class Params
        {
            #region 全局常量
            public static string APP_FILE_PATH_EXE = System.Windows.Forms.Application.StartupPath;
            public static string TimeFormat = "yyyy-MM-dd HH:mm:ss";
            public static string APP_FILE_FULLNAME_CONFIG = System.Windows.Forms.Application.StartupPath + "\\Config.xml";
            /// <summary>dataGridView样式</summary>
            public static StyleManager StyleManager = new StyleManager(APP_FILE_PATH_EXE + "\\GridStyle.xml");
            //报表文件目录
            public static string FILE_PATH_REPORT = APP_FILE_PATH_EXE + "\\Reports\\";
            //box配置文件备份目录
            public static string FILE_PATH_BOXCONFIG = APP_FILE_PATH_EXE + "\\BoxConfig";

            //数据库文件备份目录
            public static string FILE_PATH_BOXCONFIG_DB = APP_FILE_PATH_EXE + "\\BoxConfig\\DBData";
            //public static string FILE_PATH_BOXCONFIG_DB = APP_FILE_PATH_EXE + "\\Data";


            public static int MaxGroupMemberCount = 15;

            public static string BOXNAME = "站点";
            public static int NumberLen = 8;  //电话号码长度

            public static int BoxLimitNumberLen = 8;  //box限制电话号码长度最大为8位

            public static string strNumHead="";  //首位引导码

            //public static int NameLen = 4;    //用户，会议，名称长度
            //public static int 
            public static string gruopNormalName = "常用人员组";
            public static int MaxBoxMemberCount = 999;

            public static int UmtsImsiLen = 15;
            #endregion


            #region 全局变量

            //全局配置信息
            public static Config.ConfigModel ConfigModel = null;

            /// <summary>ADO数据操作</summary>
            //public static OleDbHelper OleDbHelper = null;

           /// public static Config.SystemConfigModel SystemConfig = (new Config.ConfigBLL()).ReadConfig(); //读本地配置文件
          
            public static int BoxID = 0;
            public static string BoxIP = "";
            public static int BoxHandle = 0;
            public static MBoxSDK.ConfigSDK.EnumDeviceType BoxType; //= MBoxSDK.ConfigSDK.EnumDeviceType.none;

            public static string UserName = "";
            public static int UserID=-1;
            public static string Password="";

            public static bool InitializeBoxFlag = false;

            public static List<DB_Talk.Model.m_Box> LstBox = new List<DB_Talk.Model.m_Box>();

           
            public static NewFormMain frmMain=null;

            public static bool IsRestart = false;  //标示是否需要重启，再创建5060SAP接入点后要重启
            #endregion
        }

        //全局方法
        public static class Methods
        {
            /// <summary>
            /// 保存配置文件
            /// </summary>
            public static void SaveConfig()
            {
                new Config.ConfigBLL().WriteConfig(Params.ConfigModel);
            }

          

            public static MBoxSDK.ConfigSDK.EnumDeviceType GetBoxType(int handle)
            {
                int boxtype=0;
                MBoxSDK.ConfigSDK.MBOX_GetDeviceType(handle, ref boxtype);
                return (MBoxSDK.ConfigSDK.EnumDeviceType)boxtype;

            }
            public static string FormatStrW(string str)
            {
               return string.Format(" i_flag=0 and  BoxID='{0}' " + str, Global.Params.BoxID);
            }

            public static bool checkIP(string strIP)
            {
                //string regex = @"^(2[0-4]\d | 25[0-5] | [01]?\d?[1-9])\." +
                //                @"(2[0-4]\d | 25[0-5] | [01]?\d?\d)\." +
                //                @"(2[0-4]\d | 25[0-5] | [01]?\d?\d)\." +
                //                @"(2[0-4]\d | 25[0-5] | [01]?\d?\d)$";
                String regex = "^(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|[1-9])\\."
                                + "(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|\\d)\\."
                                + "(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|\\d)\\."
                                + "(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|\\d)$";
                if (System.Text.RegularExpressions.Regex.IsMatch(strIP, regex))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            public static void checkIP(TextBox txt, string mes)
            {
                if (txt.Text.Trim() != "" && !Global.Methods.checkIP(txt.Text.Trim()))
                {
                    txt.Text = "";
                    txt.Focus();
                    if (mes == "")
                        CommControl.MessageBoxEx.MessageBoxEx.Show("IP地址不合法", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        CommControl.MessageBoxEx.MessageBoxEx.Show(mes + "不合法", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            public static bool checkNumber(string strText)
            {
                String regex = "^[1-9]\\d*$"; //匹配数字并且不以0开头
                // String regex = "^[0-9]*$";  //匹配数字 
                if (System.Text.RegularExpressions.Regex.IsMatch(strText, regex))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static bool checkNumOut(string strNum)
            {
                //String regex = @"^[\d,]+$" ; 
                String regex = @"^[\d][\,\d]*$"; //匹配数字，逗号
                if (System.Text.RegularExpressions.Regex.IsMatch(strNum, regex))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static bool checkNumOutIsSame(string strNum)
            {
                string strOut = strNum.Replace(" ","");
                string[] strArray = strOut.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> lst=strArray.ToList();
                IList<string> strlist = lst.Distinct().ToList();  //去重复
                if(lst.Count==strlist.Count) //没有重复
                {
                    return false;
                }
                else
                  return true;    //有重复

                //System.Collections.Generic.HashSet<string> h = new HashSet<string>(lst);
                //lst.Clear();
                //lst.AddRange(h);
                //strNum = lst.ToString();
                
            }

            public static bool checkNumOutIsSame(string strNumLocal, string strNum,out string mes)
            {
                mes = "";
                string strOutLocal = strNumLocal.Replace(" ", "");
                string strOut = strNum.Replace(" ", "");
                string[] strArrayLocal = strOutLocal.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] strArray = strOut.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string strLocal in strArrayLocal)
                {
                    foreach (string str in strArray)
                    {
                        if (strLocal == str)
                        {
                            mes = str;
                            return true;
                           
                        }
                    }
                }
                return false;
                //List<string> lst = strArray.ToList();
                //IList<string> strlist = lst.Distinct().ToList();  //去重复
                //if (lst.Count == strlist.Count) //没有重复
                //{
                //    return false;
                //}
                //else
                //    return true;    //有重复

               

            }

        }

        public enum menuType
        {
            基本配置,
            用户号码,
            出局通话配置,
            基站管理,
            短信配置,
            分组管理,
            高级配置
            //G3G配置
        }
        public enum menuTypeG   //高级菜单
        {
            呼叫规则配置,
            PRI时钟源配置,
            静态路由管理,
            恢复出厂设置,
            备份还原配置,
            重启设备
            
        }

        public enum menuTypeGroup  //分组管理
        {
            调度分组,
            会议分组,
            摄像头分组
        }


        public enum menuType3G  //分组管理
        {
            基本配置,
            分组网关管理,
            静态路由管理,
            基站管理
        }

    }
}
