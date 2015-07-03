using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 v_SystemLog
	/// </summary>	
	public partial class v_SystemLog
	{ 
		public v_SystemLog()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from v_SystemLog  ");
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
		/// 得到一个对象实体
		/// </summary>
		public DB_Talk.Model.v_SystemLog GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, ManagerID, vc_IP, ActionTypeID, vc_Title, vc_Description, i_Result, dt_DateTime, vc_Memo, i_Flag, UserName, BoxName  ");			
			strSql.Append("  from v_SystemLog ");
			strSql.Append("  where ID='"+ID+"'");   	  
			DB_Talk.Model.v_SystemLog model=new DB_Talk.Model.v_SystemLog();
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
		public DB_Talk.Model.v_SystemLog GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, ManagerID, vc_IP, ActionTypeID, vc_Title, vc_Description, i_Result, dt_DateTime, vc_Memo, i_Flag, UserName, BoxName  ");			
			strSql.Append("  from v_SystemLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.v_SystemLog model=new DB_Talk.Model.v_SystemLog();
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
		    strSql.Append("  ID, BoxID, ManagerID, vc_IP, ActionTypeID, vc_Title, vc_Description, i_Result, dt_DateTime, vc_Memo, i_Flag, UserName, BoxName  ");			
			strSql.Append(" FROM v_SystemLog ");
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
		public List<DB_Talk.Model.v_SystemLog> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.v_SystemLog> modelList = new List<DB_Talk.Model.v_SystemLog>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.v_SystemLog model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.v_SystemLog();	
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
				  if(dt.Rows[n]["vc_IP"]!=null && dt.Rows[n]["vc_IP"].ToString()!="")
				  {
				     model.vc_IP= dt.Rows[n]["vc_IP"].ToString();
				  }
				  if(dt.Rows[n]["ActionTypeID"]!=null && dt.Rows[n]["ActionTypeID"].ToString()!="")
				  {
				      model.ActionTypeID=int.Parse(dt.Rows[n]["ActionTypeID"].ToString());
				  }
				  if(dt.Rows[n]["vc_Title"]!=null && dt.Rows[n]["vc_Title"].ToString()!="")
				  {
				     model.vc_Title= dt.Rows[n]["vc_Title"].ToString();
				  }
				  if(dt.Rows[n]["vc_Description"]!=null && dt.Rows[n]["vc_Description"].ToString()!="")
				  {
				     model.vc_Description= dt.Rows[n]["vc_Description"].ToString();
				  }
				  if(dt.Rows[n]["i_Result"]!=null && dt.Rows[n]["i_Result"].ToString()!="")
				  {
				      model.i_Result=int.Parse(dt.Rows[n]["i_Result"].ToString());
				  }
				  if(dt.Rows[n]["dt_DateTime"]!=null && dt.Rows[n]["dt_DateTime"].ToString()!="")
				  {
				      model.dt_DateTime=DateTime.Parse(dt.Rows[n]["dt_DateTime"].ToString());
				  }
				  if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
				  {
				     model.vc_Memo= dt.Rows[n]["vc_Memo"].ToString();
				  }
				  if(dt.Rows[n]["i_Flag"]!=null && dt.Rows[n]["i_Flag"].ToString()!="")
				  {
				      model.i_Flag=int.Parse(dt.Rows[n]["i_Flag"].ToString());
				  }
				  if(dt.Rows[n]["UserName"]!=null && dt.Rows[n]["UserName"].ToString()!="")
				  {
				     model.UserName= dt.Rows[n]["UserName"].ToString();
				  }
				  if(dt.Rows[n]["BoxName"]!=null && dt.Rows[n]["BoxName"].ToString()!="")
				  {
				     model.BoxName= dt.Rows[n]["BoxName"].ToString();
				  }
				   modelList.Add(model);
				
				}
			}
			return modelList;
		}
		
        #endregion
	}
}