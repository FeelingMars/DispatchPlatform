using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DB_Talk.Model;

namespace DB_Talk.BLL
{
    /// <summary>
    /// m_Member
    /// </summary>	
    public partial class m_MemberEx
    {
        private readonly DB_Talk.DAL.m_MemberEx dal = new DB_Talk.DAL.m_MemberEx();
        public m_MemberEx()
        { }

        #region  Method

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteListEx(IDlist);
        }




        #endregion

    }
}