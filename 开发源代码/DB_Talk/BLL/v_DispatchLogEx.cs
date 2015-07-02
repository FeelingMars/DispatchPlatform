using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DB_Talk.Model;

namespace DB_Talk.BLL
{
    /// <summary>
    /// v_DispatchLog
    /// </summary>	
    public partial class v_DispatchLogEx
    {
        private readonly DB_Talk.DAL.v_DispatchLogEx dal = new DB_Talk.DAL.v_DispatchLogEx();
        public v_DispatchLogEx()
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