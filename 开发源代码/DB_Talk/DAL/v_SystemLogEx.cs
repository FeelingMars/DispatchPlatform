using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DB_Talk.DAL
{
    /// <summary>
    ///数据访问类 v_SystemLog
    /// </summary>	
    public partial class v_SystemLogEx
    {
        public v_SystemLogEx()
        { }

        #region  Method
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select  ID, BoxID, ManagerID, vc_IP, ActionTypeID, vc_Title, vc_Description, i_Result, dt_DateTime, vc_Memo, i_Flag, UserName, BoxName  ");

             strSql.Append("select *,");
             strSql.Append("(case when ActionTypeID=1 then '添加' "+
                                  "when ActionTypeID=2 then '修改'"+
                                  "when ActionTypeID=3 then '删除'" +
                                  "when ActionTypeID=4 then '系统操作' "+
                                  "else '' end) as ActionType");
             strSql.Append(" FROM  v_SystemLog ");
             if (strWhere.Trim() != "")
             {
                 strSql.Append(" where " + strWhere);
             }
             return DB.OleDbHelper.GetDataSet(strSql.ToString());
        }

      

        #endregion
    }
}