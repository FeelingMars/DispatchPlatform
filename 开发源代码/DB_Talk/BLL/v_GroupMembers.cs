using System; 
using System.Text;
using System.Data;
using System.Collections.Generic; 
using System.Data;
using DB_Talk.Model;

namespace DB_Talk.BLL 
{
	/// <summary>
	/// v_GroupMembers
	/// </summary>	
	public partial class v_GroupMembers
	{    
		private readonly DB_Talk.DAL.v_GroupMembers dal=new DB_Talk.DAL.v_GroupMembers();
		public v_GroupMembers()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary> 
		public bool Exists(string strWhere)
		{
			return dal.Exists(strWhere);
		}
		
        		
		
        		
		
		
        		
				
				
				
				
		
       		
        	
		
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DB_Talk.Model.v_GroupMembers GetModel(int ID)
		{
			return dal.GetModel(ID);
		}
		
        /// <summary>
		/// 根据条件得到一个对象实体
		/// </summary>
		public DB_Talk.Model.v_GroupMembers GetModel(string strWhere)
		{
			return dal.GetModel(strWhere);
		}
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return GetList(0,strWhere,"");
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DB_Talk.Model.v_GroupMembers> GetModelList(string strWhere)
		{
			DataSet ds = GetList(strWhere);
			return dal.DataTableToList(ds);
		}
		
	    /// <summary>
		/// 执行sql语句，获取数据列表
		/// </summary>
        public DataSet GetListSql(string strSql)
        {
            return dal.GetDataSet(strSql);
        }
        
	    /// <summary>
		/// 执行sql语句，获取实体列表
		/// </summary>
        public List<DB_Talk.Model.v_GroupMembers> GetModelListSql(string strSql)
        {
            DataSet ds = GetListSql(strSql);
            return dal.DataTableToList(ds); 
        }
        
	    /// <summary>
		/// 执行sql语句
		/// </summary>
        public int ExecuteSql(string strSql)
        {
            return dal.ExecuteSql(strSql);
        }
        
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
		
        #endregion
   
	}
}