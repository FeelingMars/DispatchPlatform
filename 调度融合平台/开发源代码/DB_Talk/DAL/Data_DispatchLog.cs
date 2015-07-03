using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 Data_DispatchLog
	/// </summary>	
	public partial class Data_DispatchLog
	{ 
		public Data_DispatchLog()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Data_DispatchLog  ");
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
		public int Add(DB_Talk.Model.Data_DispatchLog model,bool IsReturnID)   
		{
		    int Result=0;
		    StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();	
			if(model.BoxID!=null)
		    {
			   strSql1.Append("BoxID,");	
			   strSql2.Append("'"+ model.BoxID +"',");	
			} 
            if(model.ManagerID!=null)
		    {
			   strSql1.Append("ManagerID,");	
			   strSql2.Append("'"+ model.ManagerID +"',");	
			} 
            if(model.dt_DateTime!=null)
		    {
			   strSql1.Append("dt_DateTime,");	
			   strSql2.Append("'"+ model.dt_DateTime +"',");	
			} 
            if(model.DispatchNumber!=null)
		    {
			   strSql1.Append("DispatchNumber,");	
			   strSql2.Append("'"+ model.DispatchNumber +"',");	
			} 
            if(model.DispatchTypeID!=null)
		    {
			   strSql1.Append("DispatchTypeID,");	
			   strSql2.Append("'"+ model.DispatchTypeID +"',");	
			} 
            if(model.DispatchedNumbers!=null)
		    {
			   strSql1.Append("DispatchedNumbers,");	
			   strSql2.Append("'"+ model.DispatchedNumbers +"',");	
			} 
            if(model.i_Result!=null)
		    {
			   strSql1.Append("i_Result,");	
			   strSql2.Append("'"+ model.i_Result +"',");	
			} 
            if(model.i_State!=null)
		    {
			   strSql1.Append("i_State,");	
			   strSql2.Append("'"+ model.i_State +"',");	
			} 
            if(model.vc_Memo!=null)
		    {
			   strSql1.Append("vc_Memo,");	
			   strSql2.Append("'"+ model.vc_Memo +"',");	
			} 
            strSql.Append("insert into Data_DispatchLog(");	
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
		public bool Update(DB_Talk.Model.Data_DispatchLog model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Data_DispatchLog set ");
			if(model.BoxID!=null)
		    {
			   strSql.Append("BoxID='"+ model.BoxID +"',");	
			} 
			if(model.ManagerID!=null)
		    {
			   strSql.Append("ManagerID='"+ model.ManagerID +"',");	
			} 
			if(model.dt_DateTime!=null)
		    {
			   strSql.Append("dt_DateTime='"+ model.dt_DateTime +"',");	
			} 
			if(model.DispatchNumber!=null)
		    {
			   strSql.Append("DispatchNumber='"+ model.DispatchNumber +"',");	
			} 
			if(model.DispatchTypeID!=null)
		    {
			   strSql.Append("DispatchTypeID='"+ model.DispatchTypeID +"',");	
			} 
			if(model.DispatchedNumbers!=null)
		    {
			   strSql.Append("DispatchedNumbers='"+ model.DispatchedNumbers +"',");	
			} 
			if(model.i_Result!=null)
		    {
			   strSql.Append("i_Result='"+ model.i_Result +"',");	
			} 
			if(model.i_State!=null)
		    {
			   strSql.Append("i_State='"+ model.i_State +"',");	
			} 
			if(model.vc_Memo!=null)
		    {
			   strSql.Append("vc_Memo='"+ model.vc_Memo +"',");	
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
			    strSql.Append("delete from Data_DispatchLog ");	
			else
				strSql.Append("update Data_DispatchLog  set i_Flag=1 ");	 
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
			    strSql.Append("delete from Data_DispatchLog ");	
			else
				strSql.Append("update Data_DispatchLog  set i_Flag=1 ");	 
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
			    strSql.Append("delete from Data_DispatchLog ");	
			else
				strSql.Append("update Data_DispatchLog  set i_Flag=1 ");	 
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
		public DB_Talk.Model.Data_DispatchLog GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, ManagerID, dt_DateTime, DispatchNumber, DispatchTypeID, DispatchedNumbers, i_Result, i_State, vc_Memo  ");			
			strSql.Append("  from Data_DispatchLog ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_Talk.Model.Data_DispatchLog model=new DB_Talk.Model.Data_DispatchLog();
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
		public DB_Talk.Model.Data_DispatchLog GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, ManagerID, dt_DateTime, DispatchNumber, DispatchTypeID, DispatchedNumbers, i_Result, i_State, vc_Memo  ");			
			strSql.Append("  from Data_DispatchLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.Data_DispatchLog model=new DB_Talk.Model.Data_DispatchLog();
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
		    strSql.Append("  ID, BoxID, ManagerID, dt_DateTime, DispatchNumber, DispatchTypeID, DispatchedNumbers, i_Result, i_State, vc_Memo  ");			
			strSql.Append(" FROM Data_DispatchLog ");
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
		public List<DB_Talk.Model.Data_DispatchLog> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.Data_DispatchLog> modelList = new List<DB_Talk.Model.Data_DispatchLog>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.Data_DispatchLog model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.Data_DispatchLog();	
                  if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
				  {
				      model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				  }
				  if(dt.Rows[n]["BoxID"]!=null && dt.Rows[n]["BoxID"].ToString()!="")
				  {
				      model.BoxID=int.Parse(dt.Rows[n]["BoxID"].ToString());
				  }
				  if(dt.Rows[n]["ManagerID"]!=null && dt.Rows[n]["ManagerID"].ToString()!="")
				  {
				      model.ManagerID=int.Parse(dt.Rows[n]["ManagerID"].ToString());
				  }
				  if(dt.Rows[n]["dt_DateTime"]!=null && dt.Rows[n]["dt_DateTime"].ToString()!="")
				  {
				      model.dt_DateTime=DateTime.Parse(dt.Rows[n]["dt_DateTime"].ToString());
				  }
				  if(dt.Rows[n]["DispatchNumber"]!=null && dt.Rows[n]["DispatchNumber"].ToString()!="")
				  {
				      model.DispatchNumber=int.Parse(dt.Rows[n]["DispatchNumber"].ToString());
				  }
				  if(dt.Rows[n]["DispatchTypeID"]!=null && dt.Rows[n]["DispatchTypeID"].ToString()!="")
				  {
				      model.DispatchTypeID=int.Parse(dt.Rows[n]["DispatchTypeID"].ToString());
				  }
				  if(dt.Rows[n]["DispatchedNumbers"]!=null && dt.Rows[n]["DispatchedNumbers"].ToString()!="")
				  {
				     model.DispatchedNumbers= dt.Rows[n]["DispatchedNumbers"].ToString();
				  }
				  if(dt.Rows[n]["i_Result"]!=null && dt.Rows[n]["i_Result"].ToString()!="")
				  {
				      model.i_Result=int.Parse(dt.Rows[n]["i_Result"].ToString());
				  }
				  if(dt.Rows[n]["i_State"]!=null && dt.Rows[n]["i_State"].ToString()!="")
				  {
				      model.i_State=int.Parse(dt.Rows[n]["i_State"].ToString());
				  }
				  if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
				  {
				     model.vc_Memo= dt.Rows[n]["vc_Memo"].ToString();
				  }
				   modelList.Add(model);
				
				}
			}
			return modelList;
		}
		
        #endregion
	}
}