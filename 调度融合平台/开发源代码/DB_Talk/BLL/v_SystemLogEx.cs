using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DB_Talk.Model;

namespace DB_Talk.BLL
{
    /// <summary>
    /// v_SystemLog
    /// </summary>	
    public partial class v_SystemLogEx
    {
        private readonly DB_Talk.DAL.v_SystemLogEx dal = new DB_Talk.DAL.v_SystemLogEx();
        public v_SystemLogEx()
        { }

        #region  Method

  

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }



        #endregion

    }
}