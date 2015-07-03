using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DB_Talk.DAL
{
    /// <summary>
    ///数据访问类 v_Member
    /// </summary>	
    public partial class v_MemberEx
    {
        public v_MemberEx()
        { }

        #region  Method

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListEx(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select  ID, BoxID, i_Number, vc_Name, LevelID, NumberTypeID, DepartmentID, vc_MAC, i_Flag, vc_Memo, deptName, BoxName, vc_IP, vc_SN  ");
            strSql.Append("select  ID, i_Number, vc_Name, LevelID, NumberTypeID, DepartmentID, vc_MAC, i_Flag, vc_Memo, deptName");
            strSql.Append(" FROM v_Member ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DB.OleDbHelper.GetDataSet(strSql.ToString());
        }

       

        #endregion
    }
}