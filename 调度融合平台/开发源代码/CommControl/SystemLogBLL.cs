using System;
using System.Collections.Generic;

using System.Text;

namespace CommControl
{
    public class SystemLogBLL
    {
        public enum EnumLogAction
        {
            /// <summary>添加</summary>
            Add = 1,
            /// <summary>删除</summary>
            Update = 2,
            /// <summary>更新</summary>
            Delete = 3,
            /// <summary>系统操作</summary>
            SystemOperate = 4,
        }

        public static bool WriteLog(int managerID,int boxID,  EnumLogAction action, string title, string description, string memo)
        {
            DB_Talk.Model.Data_SystemLog log = new DB_Talk.Model.Data_SystemLog();
            //string str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            log.dt_DateTime = DateTime.Now;
            log.ManagerID = managerID;
            log.ActionTypeID = action.GetHashCode();
            log.vc_Title = title;
            log.BoxID = boxID;
            log.vc_Description = description;
            log.vc_Memo = memo;
            if ((new DB_Talk.BLL.Data_SystemLog()).Add(log) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
