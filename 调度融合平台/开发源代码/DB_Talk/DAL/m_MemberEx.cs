using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DB_Talk.DAL
{
    /// <summary>
    ///数据访问类 m_Member
    /// </summary>	
    public partial class m_MemberEx
    {
        public m_MemberEx()
        { }

        #region  Method

        /// <summary>
        /// 删除一批数据，不是真删除
        /// </summary>
        public bool DeleteListEx(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update m_Member  set i_Flag=1 ");
            //strSql.Append(" where ");
            //strSql.Append("ID=" + ID + "");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DB.OleDbHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion
    }
}