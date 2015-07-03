using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Win32;

namespace VoiceDispatchManage.Config
{
    public class ConfigDAL
    {
        public bool WriteConfig(ConfigModel configModel)
        {
            
            ConfigDataSet cds = new ConfigDataSet();

            #region DataBase
            ConfigDataSet.DatabaseRow dataBaseRow = cds.Database.NewDatabaseRow();

            dataBaseRow.HostID = configModel.DBInfo.HostID;
            dataBaseRow.DatabaseName = configModel.DBInfo.DatabaseName;
            dataBaseRow.UserName = configModel.DBInfo.UserName;
            dataBaseRow.PassWord = configModel.DBInfo.Password;
           

            try
            {
                int rows = 1;// DB.DAL.Global.Params.OleDbHelper.ExecuteSql("Update m_Config  Set vc_value='" + configModel.DBInfo.DataVersion + "' where vc_Key='DataVersion'");
                if (rows != 1)
                {
                    throw new Exception("写入数据版本到数据库失败!");
                }
            }
            catch (Exception)
            {
            }



            cds.Database.AddDatabaseRow(dataBaseRow);
            #endregion

            #region SystemConfig
            ConfigDataSet.SystemConfigRow systemConfigRow = cds.SystemConfig.NewSystemConfigRow();
           
            systemConfigRow.LastLoginUser = configModel.SystemConfig.LastLoginUser;
            systemConfigRow.MaxGroupMemberCount = configModel.SystemConfig.MaxGroupMemberCount;
            systemConfigRow.MaxNameTextLengh = configModel.SystemConfig.MaxNameTextLengh;
            systemConfigRow.IsShowVideoDispatchNum = configModel.SystemConfig.IsShowVideoDispatchNum;

            cds.SystemConfig.AddSystemConfigRow(systemConfigRow);
            #endregion

            #region SoftInfo
            ConfigDataSet.SoftInfoRow softInfoRow = cds.SoftInfo.NewSoftInfoRow();
            softInfoRow.Address = configModel.SoftInfo.Address;
            softInfoRow.Developer = configModel.SoftInfo.Developer;
            softInfoRow.Email = configModel.SoftInfo.Email;
            softInfoRow.SerialNum = configModel.SoftInfo.SerialNum;
            softInfoRow.SoftID = configModel.SoftInfo.SoftID;
            softInfoRow.SoftName = configModel.SoftInfo.SoftName;
            softInfoRow.SoftVersion = configModel.SoftInfo.SoftVersion;
            softInfoRow.UserName = configModel.SoftInfo.UserName;
            softInfoRow.WebSite = configModel.SoftInfo.WebSite;
            cds.SoftInfo.AddSoftInfoRow(softInfoRow);
            #endregion

            try
            {
                cds.WriteXml(Global.Params.APP_FILE_FULLNAME_CONFIG);
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public ConfigModel ReadConfig()
        {
            ConfigModel configModel = new ConfigModel();

            if (System.IO.File.Exists(Global.Params.APP_FILE_FULLNAME_CONFIG) == false)
            {
                WriteConfig(configModel);
            }

            ConfigDataSet ds = new ConfigDataSet();
            ds.ReadXml(Global.Params.APP_FILE_FULLNAME_CONFIG);

            #region DBInfo

            if (ds.Database.Rows[0]["HostID"] != null && ds.Database.Rows[0]["HostID"].ToString() != "")
            {
                configModel.DBInfo.HostID = ds.Database.Rows[0]["HostID"].ToString();
            }

            if (ds.Database.Rows[0]["DatabaseName"] != null && ds.Database.Rows[0]["DatabaseName"].ToString() != "")
            {
                configModel.DBInfo.DatabaseName = ds.Database.Rows[0]["DataBaseName"].ToString();
            }

            if (ds.Database.Rows[0]["UserName"] != null && ds.Database.Rows[0]["UserName"].ToString() != "")
            {
                configModel.DBInfo.UserName = ds.Database.Rows[0]["UserName"].ToString();
            }

            if (ds.Database.Rows[0]["Password"] != null && ds.Database.Rows[0]["Password"].ToString() != "")
            {
                configModel.DBInfo.Password = ds.Database.Rows[0]["Password"].ToString();
            }





            try
            {
                //System.Data.DataSet vDS = Global.Params.OleDbHelper.GetDataSet("select vc_value from m_Config where vc_key='DataVersion'");
                //if (vDS.Tables[0].Rows.Count == 1)
                //{
                //    configModel.DBInfo.DataVersion = vDS.Tables[0].Rows[0][0].ToString();
                //}
                //else
                //{
                //    Global.Params.OleDbHelper.ExecuteSql("insert into m_Config (vc_key,vc_value) values ('DataVersion','1.0.0')");
                //}


            }
            catch (Exception)
            {
                configModel.DBInfo.DataVersion = "1.0.0";
            }


            #endregion

            #region SystemConfig

            if (ds.SystemConfig.Rows[0]["LastLoginUser"] != null && ds.SystemConfig.Rows[0]["LastLoginUser"].ToString() != "")
            {
                configModel.SystemConfig.LastLoginUser = ds.SystemConfig.Rows[0]["LastLoginUser"].ToString();
            }
            if (ds.SystemConfig.Rows[0]["MaxGroupMemberCount"] != null && ds.SystemConfig.Rows[0]["MaxGroupMemberCount"].ToString() != "")
            {
                configModel.SystemConfig.MaxGroupMemberCount = int.Parse(ds.SystemConfig.Rows[0]["MaxGroupMemberCount"].ToString());
            }
            if (ds.SystemConfig.Rows[0]["MaxNameTextLengh"] != null && ds.SystemConfig.Rows[0]["MaxNameTextLengh"].ToString() != "")
            {
                configModel.SystemConfig.MaxNameTextLengh = int.Parse(ds.SystemConfig.Rows[0]["MaxNameTextLengh"].ToString());
            }


            if (ds.SystemConfig.Rows[0]["IsShowVideoDispatchNum"] != null && ds.SystemConfig.Rows[0]["IsShowVideoDispatchNum"].ToString() != "")
            {
                configModel.SystemConfig.IsShowVideoDispatchNum = Convert.ToBoolean(ds.SystemConfig.Rows[0]["IsShowVideoDispatchNum"].ToString());
            }

            #endregion

            #region SoftInfo

            if (ds.SoftInfo.Rows[0]["Address"] != null && ds.SoftInfo.Rows[0]["Address"].ToString() != "")
            {
                configModel.SoftInfo.Address = ds.SoftInfo.Rows[0]["Address"].ToString();
            }

            if (ds.SoftInfo.Rows[0]["Developer"] != null && ds.SoftInfo.Rows[0]["Developer"].ToString() != "")
            {
                configModel.SoftInfo.Developer = ds.SoftInfo.Rows[0]["Developer"].ToString();
            }

            if (ds.SoftInfo.Rows[0]["Email"] != null && ds.SoftInfo.Rows[0]["Email"].ToString() != "")
            {
                configModel.SoftInfo.Email = ds.SoftInfo.Rows[0]["Email"].ToString();
            }

            if (ds.SoftInfo.Rows[0]["SerialNum"] != null && ds.SoftInfo.Rows[0]["SerialNum"].ToString() != "")
            {
                configModel.SoftInfo.SerialNum = ds.SoftInfo.Rows[0]["SerialNum"].ToString();
            }

            if (ds.SoftInfo.Rows[0]["SoftID"] != null && ds.SoftInfo.Rows[0]["SoftID"].ToString() != "")
            {
                try
                {
                    configModel.SoftInfo.SoftID = int.Parse(ds.SoftInfo.Rows[0]["SoftID"].ToString());
                }
                catch (Exception)
                {
                }
            }

            if (ds.SoftInfo.Rows[0]["SoftName"] != null && ds.SoftInfo.Rows[0]["SoftName"].ToString() != "")
            {
                configModel.SoftInfo.SoftName = ds.SoftInfo.Rows[0]["SoftName"].ToString();
            }

            if (ds.SoftInfo.Rows[0]["SoftVersion"] != null && ds.SoftInfo.Rows[0]["SoftVersion"].ToString() != "")
            {
                configModel.SoftInfo.SoftVersion = ds.SoftInfo.Rows[0]["SoftVersion"].ToString();
            }

            if (ds.SoftInfo.Rows[0]["UserName"] != null && ds.SoftInfo.Rows[0]["UserName"].ToString() != "")
            {
                configModel.SoftInfo.UserName = ds.SoftInfo.Rows[0]["UserName"].ToString();
            }

            if (ds.SoftInfo.Rows[0]["WebSite"] != null && ds.SoftInfo.Rows[0]["WebSite"].ToString() != "")
            {
                configModel.SoftInfo.WebSite = ds.SoftInfo.Rows[0]["WebSite"].ToString();
            }
           
            #endregion
            WriteConfig(configModel);


            return configModel;
        }

        private bool GetIsServer()
        {
            //开机启动
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey run = hklm.CreateSubKey(@"SOFTWARE\BestWaySoft\1010");
            try
            {
                int i = (int)run.GetValue("IsServer");
                hklm.Close();

                if (i == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception my)
            {
                return false;
            }
        }


   
    }
}
