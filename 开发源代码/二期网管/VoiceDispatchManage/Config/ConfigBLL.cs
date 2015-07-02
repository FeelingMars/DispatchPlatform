using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace VoiceDispatchManage.Config
{
    public class ConfigBLL
    {
        public bool WriteConfig(ConfigModel configModel)
        {
            return (new ConfigDAL()).WriteConfig(configModel);
        }

        public ConfigModel ReadConfig()
        {
            try
            {
                return (new ConfigDAL()).ReadConfig();
            }
            catch (Exception ex)
            {
                //Bestway.Windows.Controls.MessageBoxEx.Show("读取配置文件失败： " + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //return null;
                throw new Exception("读取配置文件失败： " + ex.Message);
            }
            
        }

   

    }
}
