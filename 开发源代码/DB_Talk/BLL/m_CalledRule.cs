using System; 
using System.Text;
using System.Data;
using System.Collections.Generic; 
using System.Data;
using DB_Talk.Model;

namespace DB_Talk.BLL 
{
	/// <summary>
	/// m_CalledRule
	/// </summary>	
	public partial class m_CalledRule
	{    
		private readonly DB_Talk.DAL.m_CalledRule dal=new DB_Talk.DAL.m_CalledRule();
		public m_CalledRule()
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
		/// 增加一条数据
		/// </summary>
		public int  Add(DB_Talk.Model.m_CalledRule model)
		{
			return Add(model,false);		
		}
				
		/// <summary>
		/// 增加一条数据,并返回ID
		/// </summary>
		public int  Add(DB_Talk.Model.m_CalledRule model,bool IsReturnID)   
		{
			return dal.Add(model,IsReturnID);
						
		}
		
        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DB_Talk.Model.m_CalledRule model)
		{
			return Update(model,"");
		}
				
		
		/// <summary>
		/// 根据条件更新数据
		/// </summary>
		public bool Update(DB_Talk.Model.m_CalledRule model,string strWhere)
		{
			return dal.Update(model,strWhere);
		}
		
        /// <summary>
		/// 根据ID删除一条数据(真删)
		/// </summary>
		public bool Delete(int ID)
		{	
			return Delete(ID,true);
		}
				
		/// <summary>
		/// 根据ID删除一条数据(假删)
		/// </summary>
		public bool DeleteEx(int ID)
		{	
			return Delete(ID,false);
		}
				
		/// <summary>
		/// 根据ID 删除一条数据
		/// </summary>
		public bool Delete(int ID,bool IsTrueDelete)
		{	
			return dal.Delete(ID,IsTrueDelete);
		}
				
		/// <summary>
		/// 根据条件删除一条数据(真删)
		/// </summary>
		public bool Delete(string strWhere)
		{	
			return Delete(true,strWhere);
		}
				
		/// <summary>
		/// 根据条件删除一条数据(假删)
		/// </summary>
		public bool DeleteEx(string strWhere)
		{	
			return Delete(false,strWhere);
		}
				
		/// <summary>
		/// 根据条件删除一条数据
		/// </summary>
		public bool Delete(bool IsTrueDelete,string strWhere)
		{	
			return dal.Delete(IsTrueDelete,strWhere);
		}
		
       /// <summary>
		/// 批量删除一批数据(真删)
		/// </summary>
		public bool DeleteList(string IDlist)
		{
			return DeleteList(IDlist ,true);
		}
				
        /// <summary>
		/// 批量删除一批数据(假删)
		/// </summary>
		public bool DeleteListEx(string IDlist)
		{
			return DeleteList(IDlist ,false);
		}
			
		
		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string IDlist ,bool IsTrueDelete)
		{
			return dal.DeleteList(IDlist ,IsTrueDelete);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DB_Talk.Model.m_CalledRule GetModel(int ID)
		{
			return dal.GetModel(ID);
		}
		
        /// <summary>
		/// 根据条件得到一个对象实体
		/// </summary>
		public DB_Talk.Model.m_CalledRule GetModel(string strWhere)
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
		public List<DB_Talk.Model.m_CalledRule> GetModelList(string strWhere)
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
        public List<DB_Talk.Model.m_CalledRule> GetModelListSql(string strSql)
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