using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 v_Manager
	/// </summary>	
	public partial class v_Manager
	{ 
		public v_Manager()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from v_Manager  ");
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
		public DB_Talk.Model.v_Manager GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, vc_UserName, vc_Password, LeftDispatchNumber, RightDispatchNumber, LeftDispatchName, RightDispatchName, i_Net, i_Operate, i_Dispatch, dt_CreateTime, vc_Memo, i_Flag, i_TellType, i_IsDispatch, vc_BoxID, BoxName, vc_IP, vc_SN  ");			
			strSql.Append("  from v_Manager ");
			strSql.Append("  where ID='"+ID+"'");   	  
			DB_Talk.Model.v_Manager model=new DB_Talk.Model.v_Manager();
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
		public DB_Talk.Model.v_Manager GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, vc_UserName, vc_Password, LeftDispatchNumber, RightDispatchNumber, LeftDispatchName, RightDispatchName, i_Net, i_Operate, i_Dispatch, dt_CreateTime, vc_Memo, i_Flag, i_TellType, i_IsDispatch, vc_BoxID, BoxName, vc_IP, vc_SN  ");			
			strSql.Append("  from v_Manager ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.v_Manager model=new DB_Talk.Model.v_Manager();
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
		    strSql.Append("  ID, BoxID, vc_UserName, vc_Password, LeftDispatchNumber, RightDispatchNumber, LeftDispatchName, RightDispatchName, i_Net, i_Operate, i_Dispatch, dt_CreateTime, vc_Memo, i_Flag, i_TellType, i_IsDispatch, vc_BoxID, BoxName, vc_IP, vc_SN  ");			
			strSql.Append(" FROM v_Manager ");
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
		public List<DB_Talk.Model.v_Manager> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.v_Manager> modelList = new List<DB_Talk.Model.v_Manager>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.v_Manager model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.v_Manager();	
                  if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
				  {
				      model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				  }
				  if(dt.Rows[n]["BoxID"]!=null && dt.Rows[n]["BoxID"].ToString()!="")
				  {
				      model.BoxID=int.Parse(dt.Rows[n]["BoxID"].ToString());
				  }
				  if(dt.Rows[n]["vc_UserName"]!=null && dt.Rows[n]["vc_UserName"].ToString()!="")
				  {
				     model.vc_UserName= dt.Rows[n]["vc_UserName"].ToString();
				  }
				  if(dt.Rows[n]["vc_Password"]!=null && dt.Rows[n]["vc_Password"].ToString()!="")
				  {
				     model.vc_Password= dt.Rows[n]["vc_Password"].ToString();
				  }
				  if(dt.Rows[n]["LeftDispatchNumber"]!=null && dt.Rows[n]["LeftDispatchNumber"].ToString()!="")
				  {
				      model.LeftDispatchNumber=int.Parse(dt.Rows[n]["LeftDispatchNumber"].ToString());
				  }
				  if(dt.Rows[n]["RightDispatchNumber"]!=null && dt.Rows[n]["RightDispatchNumber"].ToString()!="")
				  {
				      model.RightDispatchNumber=int.Parse(dt.Rows[n]["RightDispatchNumber"].ToString());
				  }
				  if(dt.Rows[n]["LeftDispatchName"]!=null && dt.Rows[n]["LeftDispatchName"].ToString()!="")
				  {
				     model.LeftDispatchName= dt.Rows[n]["LeftDispatchName"].ToString();
				  }
				  if(dt.Rows[n]["RightDispatchName"]!=null && dt.Rows[n]["RightDispatchName"].ToString()!="")
				  {
				     model.RightDispatchName= dt.Rows[n]["RightDispatchName"].ToString();
				  }
				  if(dt.Rows[n]["i_Net"]!=null && dt.Rows[n]["i_Net"].ToString()!="")
				  {
				      model.i_Net=int.Parse(dt.Rows[n]["i_Net"].ToString());
				  }
				  if(dt.Rows[n]["i_Operate"]!=null && dt.Rows[n]["i_Operate"].ToString()!="")
				  {
				      model.i_Operate=int.Parse(dt.Rows[n]["i_Operate"].ToString());
				  }
				  if(dt.Rows[n]["i_Dispatch"]!=null && dt.Rows[n]["i_Dispatch"].ToString()!="")
				  {
				      model.i_Dispatch=int.Parse(dt.Rows[n]["i_Dispatch"].ToString());
				  }
				  if(dt.Rows[n]["dt_CreateTime"]!=null && dt.Rows[n]["dt_CreateTime"].ToString()!="")
				  {
				      model.dt_CreateTime=DateTime.Parse(dt.Rows[n]["dt_CreateTime"].ToString());
				  }
				  if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
				  {
				     model.vc_Memo= dt.Rows[n]["vc_Memo"].ToString();
				  }
				  if(dt.Rows[n]["i_Flag"]!=null && dt.Rows[n]["i_Flag"].ToString()!="")
				  {
				      model.i_Flag=int.Parse(dt.Rows[n]["i_Flag"].ToString());
				  }
				  if(dt.Rows[n]["i_TellType"]!=null && dt.Rows[n]["i_TellType"].ToString()!="")
				  {
				      model.i_TellType=int.Parse(dt.Rows[n]["i_TellType"].ToString());
				  }
				  if(dt.Rows[n]["i_IsDispatch"]!=null && dt.Rows[n]["i_IsDispatch"].ToString()!="")
				  {
				      model.i_IsDispatch=int.Parse(dt.Rows[n]["i_IsDispatch"].ToString());
				  }
				  if(dt.Rows[n]["vc_BoxID"]!=null && dt.Rows[n]["vc_BoxID"].ToString()!="")
				  {
				     model.vc_BoxID= dt.Rows[n]["vc_BoxID"].ToString();
				  }
				  if(dt.Rows[n]["BoxName"]!=null && dt.Rows[n]["BoxName"].ToString()!="")
				  {
				     model.BoxName= dt.Rows[n]["BoxName"].ToString();
				  }
				  if(dt.Rows[n]["vc_IP"]!=null && dt.Rows[n]["vc_IP"].ToString()!="")
				  {
				     model.vc_IP= dt.Rows[n]["vc_IP"].ToString();
				  }
				  if(dt.Rows[n]["vc_SN"]!=null && dt.Rows[n]["vc_SN"].ToString()!="")
				  {
				     model.vc_SN= dt.Rows[n]["vc_SN"].ToString();
				  }
				   modelList.Add(model);
				
				}
			}
			return modelList;
		}
		
        #endregion
	}
}