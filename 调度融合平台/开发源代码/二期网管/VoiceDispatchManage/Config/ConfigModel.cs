using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VoiceDispatchManage.Config
{
    /// <summary>
    /// 全局配置项
    /// </summary>
    public class ConfigModel
    {

        public ConfigModel()
        {
        }

        /// <summary>
        /// 系统配置
        /// </summary>
        public SystemConfigModel SystemConfig = new SystemConfigModel();

        /// <summary>
        /// 数据库配置
        /// </summary>
        public DatabaseModel DBInfo = new DatabaseModel();

        /// <summary>
        /// 软件信息配置
        /// </summary>
        public SoftInfoModel SoftInfo = new SoftInfoModel();

    }

    /// <summary>
    /// 数据库配置
    /// </summary>
    public class DatabaseModel
    {
        public DatabaseModel()
        {
            this.HostID = ".";
            this.DatabaseName = "BW_VoiceDispatch";
            this.UserName = "sa";
            this.Password = "kj222";
            this.DataVersion = "V1.0.0";
        }
        /// <summary>
        /// 数据服务器
        /// </summary>
        public string HostID { get; set; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 数据版本
        /// </summary>
        public string DataVersion { get; set; }




    }

    /// <summary>
    /// 自定义配置，关键字值
    /// </summary>
    public class CustomModel
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public CustomModel(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
    /// <summary>
    /// 注册时用到
    /// </summary>
    public class SoftInfoModel
    {
        public SoftInfoModel()
        {
            this.Address = "南京江宁经济技术开发区菲尼克斯路99号";
            this.Developer = "南京北路自动化系统有限责任公司";
            this.Email = "njbestway@188.com";
            this.SerialNum = "00000-00000-00000-00000-00000";
            this.SoftID = 1010;
            this.SoftName = "网管软件";
            this.SoftVersion = "V 1.0.0.0";
            this.UserName = "";
            this.WebSite = "http://www.njbestway.com";
        }

        /// <summary>
        /// 开发者，如北路公司
        /// </summary>
        public string Developer { get; set; }

        /// <summary>
        /// 软件ID 如1001
        /// </summary>
        public int SoftID { get; set; }

        /// <summary>
        /// 软件名称  如KTK113 矿山安全数字广播系统
        /// </summary>
        public string SoftName { get; set; }

        /// <summary>
        /// 客户名称 如XXX煤矿公司
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// SN号 如00000-11111-22222-33333-44444
        /// </summary>
        public string SerialNum { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string WebSite { get; set; }

        /// <summary>
        /// 软件版本
        /// </summary>
        public string SoftVersion { get; set; }

    }

    /// <summary>
    /// 系统配置项
    /// </summary>
    public class SystemConfigModel
    {

        public SystemConfigModel()
        {

            this.LastLoginUser = "";
            this.MaxGroupMemberCount = 15;
            this.MaxNameTextLengh = 0;
        }

        /// <summary>
        /// 上次登录用户
        /// </summary>
        public string LastLoginUser { get; set; }

        /// <summary>
        /// 组最大用户数
        /// </summary>
        public int MaxGroupMemberCount { get; set; }

        /// <summary>
        /// 组最大用户数
        /// </summary>
        public int MaxNameTextLengh { get; set; }

        public bool IsShowVideoDispatchNum { get; set; }
    }


}
