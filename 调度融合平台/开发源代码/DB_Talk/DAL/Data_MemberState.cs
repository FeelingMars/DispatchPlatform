using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 Data_MemberState
	/// </summary>	
	public partial class Data_MemberState
	{ 
		public Data_MemberState()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Data_MemberState  ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}  
			strSql.Append("  having count(1)>0  ");
			DataTable dt=GetDataTable(strSql.ToString()); 
			if (dt!=null && dt.Rows.Count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}	
		}
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DB_Talk.Model.Data_MemberState model,bool IsReturnID)   
		{
		    int Result=0;
		    StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();	
			if(model.i_DispatchNumber!=null)
		    {
			   strSql1.Append("i_DispatchNumber,");	
			   strSql2.Append("'"+ model.i_DispatchNumber +"',");	
			} 
            if(model.i_Number!=null)
		    {
			   strSql1.Append("i_Number,");	
			   strSql2.Append("'"+ model.i_Number +"',");	
			} 
            if(model.i_PeerNumber!=null)
		    {
			   strSql1.Append("i_PeerNumber,");	
			   strSql2.Append("'"+ model.i_PeerNumber +"',");	
			} 
            if(model.i_State!=null)
		    {
			   strSql1.Append("i_State,");	
			   strSql2.Append("'"+ model.i_State +"',");	
			} 
            strSql.Append("insert into Data_MemberState(");	
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));	
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");  
			strSql.Append(";select @@IDENTITY");
			if (IsReturnID)
            {
                DataSet ds=GetDataSet(strSql.ToString());
                if(ds!=null && ds.Tables[0].Rows.Count>0)
                {
                   Result = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
                else
                  Result=-1;
            }
            else  
            {
                Result = ExecuteSql(strSql.ToString());
            }
            return Result; 
		}
				
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DB_Talk.Model.Data_MemberState model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Data_MemberState set ");
			if(model.i_DispatchNumber!=null)
		    {
			   strSql.Append("i_DispatchNumber='"+ model.i_DispatchNumber +"',");	
			} 
			if(model.i_Number!=null)
		    {
			   strSql.Append("i_Number='"+ model.i_Number +"',");	
			} 
			if(model.i_PeerNumber!=null)
		    {
			   strSql.Append("i_PeerNumber='"+ model.i_PeerNumber +"',");	
			} 
			if(model.i_State!=null)
		    {
			   strSql.Append("i_State='"+ model.i_State +"',");	
			} 
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			else
			    strSql.Append(" where ID=" + model.ID +"");	         
            int rows=ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
				
		/// <summary>
		/// 根据ID删除一条数据 
        /// </summary>
		public bool Delete(int ID,bool IsTrueDelete)
		{	
			StringBuilder strSql=new StringBuilder();
			if(IsTrueDelete)
			    strSql.Append("delete from Data_MemberState ");	
			else
				strSql.Append("update Data_MemberState  set i_Flag=1 ");	 
		    strSql.Append(" where ");
		    strSql.Append("ID=" + ID +"");	  
			int rows=ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}	
		}
			

        /// <summary>
		/// 根据条件删除数据 
        /// </summary>
		public bool Delete(bool IsTrueDelete,string strWhere)
		{	
			StringBuilder strSql=new StringBuilder();
			if(IsTrueDelete)
			    strSql.Append("delete from Data_MemberState ");	
			else
				strSql.Append("update Data_MemberState  set i_Flag=1 ");	 
			if(strWhere.Trim()!="")
				strSql.Append(" where "+strWhere);
			int rows=ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}	
		}
			

		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string IDlist,bool IsTrueDelete)
		{
			StringBuilder strSql=new StringBuilder();
			if(IsTrueDelete)
			    strSql.Append("delete from Data_MemberState ");	
			else
				strSql.Append("update Data_MemberState  set i_Flag=1 ");	 
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
				
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DB_Talk.Model.Data_MemberState GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, i_DispatchNumber, i_Number, i_PeerNumber, i_State  ");			
			strSql.Append("  from Data_MemberState ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_Talk.Model.Data_MemberState model=new DB_Talk.Model.Data_MemberState();
			DataSet ds=GetDataSet(strSql.ToString());
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
	            model=DataTableToList(ds)[0];						
				return model;
			}
			else
			{
				return null;
			}
		} 
        
		/// <summary>
		/// 根据条件得到一个对象实体
		/// </summary>
		public DB_Talk.Model.Data_MemberState GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, i_DispatchNumber, i_Number, i_PeerNumber, i_State  ");			
			strSql.Append("  from Data_MemberState ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.Data_MemberState model=new DB_Talk.Model.Data_MemberState();
			DataSet ds=GetDataSet(strSql.ToString());
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
                model=DataTableToList(ds)[0];						
				return model;
			}
			else
			{
				return null;
			}
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
		    strSql.Append("  ID, i_DispatchNumber, i_Number, i_PeerNumber, i_State  ");			
			strSql.Append(" FROM Data_MemberState ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			if(filedOrder.Trim()!="")
			{
		    	strSql.Append(" order by " + filedOrder);
			}
			return GetDataSet(strSql.ToString());
		}
		
        /// <summary>
		/// 执行sql语句
		/// </summary>
        public int ExecuteSql(string strSql)
        {
            return DB.OleDbHelper.ExecuteSql(strSql);
        }
        
        /// <summary>
		/// 执行sql语句,获得数据列表
		/// </summary>
        public DataTable GetDataTable(string strSql)
        {
            return DB.OleDbHelper.GetDataTable(strSql);
        }
        
        /// <summary>
		/// 执行sql语句，获得数据列表
		/// </summary>
        public DataSet GetDataSet(string strSql)
        {
            return DB.OleDbHelper.GetDataSet(strSql);
        }
        
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DB_Talk.Model.Data_MemberState> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.Data_MemberState> modelList = new List<DB_Talk.Model.Data_MemberState>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.Data_MemberState model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.Data_MemberState();	
                  if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
				  {
				      model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				  }
				  if(dt.Rows[n]["i_DispatchNumber"]!=null && dt.Rows[n]["i_DispatchNumber"].ToString()!="")
				  {
				      model.i_DispatchNumber=int.Parse(dt.Rows[n]["i_DispatchNumber"].ToString());
				  }
				  if(dt.Rows[n]["i_Number"]!=null && dt.Rows[n]["i_Number"].ToString()!="")
				  {
				      model.i_Number=int.Parse(dt.Rows[n]["i_Number"].ToString());
				  }
				  if(dt.Rows[n]["i_PeerNumber"]!=null && dt.Rows[n]["i_PeerNumber"].ToString()!="")
				  {
				      model.i_PeerNumber=int.Parse(dt.Rows[n]["i_PeerNumber"].ToString());
				  }
				  if(dt.Rows[n]["i_State"]!=null && dt.Rows[n]["i_State"].ToString()!="")
				  {
				      model.i_State=int.Parse(dt.Rows[n]["i_State"].ToString());
				  }
				   modelList.Add(model);
				
				}
			}
			return modelList;
		}
		
        #endregion
	}
}