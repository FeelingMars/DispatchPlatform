using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 v_Data_Alarm
	/// </summary>	
	public partial class v_Data_Alarm
	{ 
		public v_Data_Alarm()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from v_Data_Alarm  ");
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
		public DB_Talk.Model.v_Data_Alarm GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, dt_DateTime, AlarmTypeID, vc_Memo, i_AlarmSeriesNumber, i_AlarmInfo, i_AlarmInfoDetail, i_AlarmEntityType, i_AlarmEntityInstance, i_AlarmClass, i_AlarmSeverity, i_AlarmAckFlag, AlarmClass, AlarmSeverity, AlarmAck, AlarmEntityInstance, AlarmInfo, AlarmDetail, AlarmEntityType, BoxName, vc_IP, vc_SN  ");			
			strSql.Append("  from v_Data_Alarm ");
			strSql.Append("  where ID='"+ID+"'");   	  
			DB_Talk.Model.v_Data_Alarm model=new DB_Talk.Model.v_Data_Alarm();
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
		public DB_Talk.Model.v_Data_Alarm GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, dt_DateTime, AlarmTypeID, vc_Memo, i_AlarmSeriesNumber, i_AlarmInfo, i_AlarmInfoDetail, i_AlarmEntityType, i_AlarmEntityInstance, i_AlarmClass, i_AlarmSeverity, i_AlarmAckFlag, AlarmClass, AlarmSeverity, AlarmAck, AlarmEntityInstance, AlarmInfo, AlarmDetail, AlarmEntityType, BoxName, vc_IP, vc_SN  ");			
			strSql.Append("  from v_Data_Alarm ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.v_Data_Alarm model=new DB_Talk.Model.v_Data_Alarm();
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
		    strSql.Append("  ID, BoxID, dt_DateTime, AlarmTypeID, vc_Memo, i_AlarmSeriesNumber, i_AlarmInfo, i_AlarmInfoDetail, i_AlarmEntityType, i_AlarmEntityInstance, i_AlarmClass, i_AlarmSeverity, i_AlarmAckFlag, AlarmClass, AlarmSeverity, AlarmAck, AlarmEntityInstance, AlarmInfo, AlarmDetail, AlarmEntityType, BoxName, vc_IP, vc_SN  ");			
			strSql.Append(" FROM v_Data_Alarm ");
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
		public List<DB_Talk.Model.v_Data_Alarm> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.v_Data_Alarm> modelList = new List<DB_Talk.Model.v_Data_Alarm>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.v_Data_Alarm model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.v_Data_Alarm();	
                  if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
				  {
				      model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				  }
				  if(dt.Rows[n]["BoxID"]!=null && dt.Rows[n]["BoxID"].ToString()!="")
				  {
				      model.BoxID=int.Parse(dt.Rows[n]["BoxID"].ToString());
				  }
				  if(dt.Rows[n]["dt_DateTime"]!=null && dt.Rows[n]["dt_DateTime"].ToString()!="")
				  {
				      model.dt_DateTime=DateTime.Parse(dt.Rows[n]["dt_DateTime"].ToString());
				  }
				  if(dt.Rows[n]["AlarmTypeID"]!=null && dt.Rows[n]["AlarmTypeID"].ToString()!="")
				  {
				      model.AlarmTypeID=int.Parse(dt.Rows[n]["AlarmTypeID"].ToString());
				  }
				  if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
				  {
				     model.vc_Memo= dt.Rows[n]["vc_Memo"].ToString();
				  }
				  if(dt.Rows[n]["i_AlarmSeriesNumber"]!=null && dt.Rows[n]["i_AlarmSeriesNumber"].ToString()!="")
				  {
				      model.i_AlarmSeriesNumber=int.Parse(dt.Rows[n]["i_AlarmSeriesNumber"].ToString());
				  }
				  if(dt.Rows[n]["i_AlarmInfo"]!=null && dt.Rows[n]["i_AlarmInfo"].ToString()!="")
				  {
				      model.i_AlarmInfo=int.Parse(dt.Rows[n]["i_AlarmInfo"].ToString());
				  }
				  if(dt.Rows[n]["i_AlarmInfoDetail"]!=null && dt.Rows[n]["i_AlarmInfoDetail"].ToString()!="")
				  {
				      model.i_AlarmInfoDetail=int.Parse(dt.Rows[n]["i_AlarmInfoDetail"].ToString());
				  }
				  if(dt.Rows[n]["i_AlarmEntityType"]!=null && dt.Rows[n]["i_AlarmEntityType"].ToString()!="")
				  {
				      model.i_AlarmEntityType=int.Parse(dt.Rows[n]["i_AlarmEntityType"].ToString());
				  }
				  if(dt.Rows[n]["i_AlarmEntityInstance"]!=null && dt.Rows[n]["i_AlarmEntityInstance"].ToString()!="")
				  {
				      model.i_AlarmEntityInstance=int.Parse(dt.Rows[n]["i_AlarmEntityInstance"].ToString());
				  }
				  if(dt.Rows[n]["i_AlarmClass"]!=null && dt.Rows[n]["i_AlarmClass"].ToString()!="")
				  {
				      model.i_AlarmClass=int.Parse(dt.Rows[n]["i_AlarmClass"].ToString());
				  }
				  if(dt.Rows[n]["i_AlarmSeverity"]!=null && dt.Rows[n]["i_AlarmSeverity"].ToString()!="")
				  {
				      model.i_AlarmSeverity=int.Parse(dt.Rows[n]["i_AlarmSeverity"].ToString());
				  }
				  if(dt.Rows[n]["i_AlarmAckFlag"]!=null && dt.Rows[n]["i_AlarmAckFlag"].ToString()!="")
				  {
				      model.i_AlarmAckFlag=int.Parse(dt.Rows[n]["i_AlarmAckFlag"].ToString());
				  }
				  if(dt.Rows[n]["AlarmClass"]!=null && dt.Rows[n]["AlarmClass"].ToString()!="")
				  {
				     model.AlarmClass= dt.Rows[n]["AlarmClass"].ToString();
				  }
				  if(dt.Rows[n]["AlarmSeverity"]!=null && dt.Rows[n]["AlarmSeverity"].ToString()!="")
				  {
				     model.AlarmSeverity= dt.Rows[n]["AlarmSeverity"].ToString();
				  }
				  if(dt.Rows[n]["AlarmAck"]!=null && dt.Rows[n]["AlarmAck"].ToString()!="")
				  {
				     model.AlarmAck= dt.Rows[n]["AlarmAck"].ToString();
				  }
				  if(dt.Rows[n]["AlarmEntityInstance"]!=null && dt.Rows[n]["AlarmEntityInstance"].ToString()!="")
				  {
				     model.AlarmEntityInstance= dt.Rows[n]["AlarmEntityInstance"].ToString();
				  }
				  if(dt.Rows[n]["AlarmInfo"]!=null && dt.Rows[n]["AlarmInfo"].ToString()!="")
				  {
				     model.AlarmInfo= dt.Rows[n]["AlarmInfo"].ToString();
				  }
				  if(dt.Rows[n]["AlarmDetail"]!=null && dt.Rows[n]["AlarmDetail"].ToString()!="")
				  {
				     model.AlarmDetail= dt.Rows[n]["AlarmDetail"].ToString();
				  }
				  if(dt.Rows[n]["AlarmEntityType"]!=null && dt.Rows[n]["AlarmEntityType"].ToString()!="")
				  {
				     model.AlarmEntityType= dt.Rows[n]["AlarmEntityType"].ToString();
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