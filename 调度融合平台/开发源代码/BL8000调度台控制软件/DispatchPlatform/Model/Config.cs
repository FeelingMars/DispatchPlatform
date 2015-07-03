using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bestway.Windows.Tools.XML;
using System.Windows.Forms;
using System.Net;

namespace DispatchPlatform
{
    public class Config
    {
        public static ConfigModel GetModel()
        {
            XMLHelper xml = new XMLHelper(Application.StartupPath+"\\Config.xml");
            ConfigModel model = new ConfigModel();
            //model.ServerIP = xml.GetItem("MBoxIP", "10.20.31.1");
            model.LocalIP = xml.GetItem("LocalIP", "127.0.0.1");
         
            model.Title = xml.GetItem("Title", "调度通讯软件");
            model.DBServer = xml.GetItem("DBServer", ".");
            model.DBName = xml.GetItem("DBName", "BW_VoiceDispatch");
            model.DBUserName = xml.GetItem("DBUserName", "sa");
            model.DBPassword = xml.GetItem("DBPassword", "kj222");
            model.LastUser = xml.GetItem("LastUser", "");
            model.AlarmMusicUrl = xml.GetItem("AlarmMusicUrl", "alarm.wav");
            model.CheckBoxOnLineInterval =int.Parse( xml.GetItem("CheckBoxOnLineInterval", "60"));
            model.VideoSize = int.Parse(xml.GetItem("VideoSize", "1"));

            model.SortByDepartment = bool.Parse(xml.GetItem("SortByDepartment", "false"));
            model.SortByName = bool.Parse(xml.GetItem("SortByName", "false"));
            model.SortByNumber = bool.Parse(xml.GetItem("SortByNumber", "false"));
            model.SortByOnline = bool.Parse(xml.GetItem("SortByOnline", "false"));

            model.SortInterval = int.Parse(xml.GetItem("SortInterval", "10"));
            model.ShowColums = int.Parse(xml.GetItem("ShowColums", "5"));
            model.ShowRows = int.Parse(xml.GetItem("ShowRows", "6"));

            model.IsAutoStartBySystem = bool.Parse(xml.GetItem("IsAutoStartBySystem", "true"));
            model.IsAutoLogin = bool.Parse(xml.GetItem("IsAutoLogin", "true"));
            model.IsDefaultRight = bool.Parse(xml.GetItem("IsDefaultRight", "true"));

            //model.MaxMeetingMember = int.Parse(xml.GetItem("MaxMeetingMember", "15"));

            model.AutoFilterMember = bool.Parse(xml.GetItem("AutoFilterMember", "false"));

            model.TalkLogSearchDays = int.Parse(xml.GetItem("TalkLogSearchDays", "30"));

          //  model.IpBrocastSendInterval = int.Parse(xml.GetItem("IpBrocastSendInterval", "60"));

            model.WriteSDKLog = bool.Parse(xml.GetItem("WriteSDKLog", "false"));
            model.IsVideoCall = bool.Parse(xml.GetItem("IsVideoCall", "false"));
            model.IsIpBrocast = bool.Parse(xml.GetItem("IsIpBrocast", "false"));
            //model.FontSet4 = xml.GetItem("FontSet4", "12,2,2");
            //model.FontSet5 = xml.GetItem("FontSet5", "12,2,2");
            //model.FontSet6 = xml.GetItem("FontSet6", "12,2,2");
            //model.FontSet7 = xml.GetItem("FontSet7", "12,2,2");
            //model.FontSet8 = xml.GetItem("FontSet8", "12,2,2");

            model.OutsideNumberMaxLength = int.Parse(xml.GetItem("TalkLogSearchDays", "6"));
            model.BoxIP = xml.GetItem("BoxIP", "");
            return model;
        }

        public static bool WriteModel(ConfigModel model)
        {
            XMLHelper xml = new XMLHelper(Application.StartupPath+"\\Config.xml");

            xml.SetItem("LocalIP", model.LocalIP);
            xml.SetItem("DBServer", model.DBServer);
            xml.SetItem("DBName", model.DBName);
            xml.SetItem("DBUserName", model.DBUserName);
            xml.SetItem("DBPassword", model.DBPassword);
            xml.SetItem("LastUser", model.LastUser);
            xml.SetItem("SortByDepartment", model.SortByDepartment.ToString());
            xml.SetItem("SortByName", model.SortByName.ToString());
            xml.SetItem("SortByNumber", model.SortByNumber.ToString());
            xml.SetItem("SortByOnline", model.SortByOnline.ToString());
            xml.SetItem("ShowColums", model.ShowColums.ToString());
            xml.SetItem("ShowRows", model.ShowRows.ToString());
            xml.SetItem("BoxIP", model.BoxIP);
            xml.SetItem("VideoSize", model.VideoSize.ToString());
            return true;
        }

    }

    public class ConfigModel
    {
        /// <summary>
        /// MboxIP
        /// </summary>
        public string ServerIP { get; set; }

        /// <summary>
        /// 本地IP
        /// </summary>
        public string LocalIP { get; set; }

        /// <summary>
        /// 最大会议成员数
        /// </summary>
       // public int MaxMeetingMember { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 外线号码最大长度，为了显示是覆盖用的
        /// </summary>
        public int OutsideNumberMaxLength { get; set; }

        /// <summary>
        /// 是否默认为左席
        /// </summary>
        public bool IsDefaultRight { get; set; }

        public string DBServer { get; set; }

        public string DBName { get; set; }

        public string DBUserName { get; set; }

        public string DBPassword { get; set; }

        /// <summary>
        /// 自动隐藏不需要的用户,自动过滤用的
        /// </summary>
        public bool AutoFilterMember { get; set; }

        /// <summary>
        /// 开机自启动
        /// </summary>
        public bool IsAutoStartBySystem { get; set; }

        /// <summary>
        /// 自动登录，默认为admin用户
        /// </summary>
        public bool IsAutoLogin { get; set; }

        /// <summary>
        /// 是否记录SDK日志
        /// </summary>
        public bool WriteSDKLog { get; set; }

        /// <summary>
        /// 上次登录的用户
        /// </summary>
        public string LastUser { get; set; }

        /// <summary>
        /// 排序间隔
        /// </summary>
        public int SortInterval { get; set; }
        /// <summary>
        /// 告警音乐的目录
        /// </summary>
        public string AlarmMusicUrl { get; set; }

        /// <summary>
        ///检查在线的时间(秒)
        /// </summary>
        public int CheckBoxOnLineInterval { get; set; }

        public bool SortByID = true;

        public  bool SortByOnline = false;

        public  bool SortByNumber = false;

        public  bool SortByName = false;

        public  bool SortByDepartment = false;

        /// <summary>通话记录查询天数</summary>
        public int TalkLogSearchDays { get; set; }

        /// <summary>
        /// IP广播数据发送间隔
        /// </summary>
       // public int IpBrocastSendInterval { get; set; }
        /// <summary>
        /// 显示列数
        /// </summary>
        public int ShowColums { get; set; }

        /// <summary>
        /// 显示行数
        /// </summary>
        public int ShowRows { get; set; }

        /// <summary>
        /// 要使用的BoxIP
        /// </summary>
        public string BoxIP { get; set; }

        /// <summary>
        /// 是否包含视频通话
        /// </summary>
        public bool IsVideoCall { get; set; }

        /// <summary>
        /// 是否包含IP全部广播功能
        /// </summary>
        public bool IsIpBrocast { get; set; }

        /// <summary>
        ///  视频大小0到12
        /// </summary>
        public int VideoSize { get; set; }
        //public string FontSet4 { get; set; }
        //public string FontSet5 { get; set; }
        //public string FontSet6 { get; set; }
        //public string FontSet7 { get; set; }
        //public string FontSet8 { get; set; }
    }
}
