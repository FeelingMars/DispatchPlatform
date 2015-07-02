using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 m_PDS
	/// </summary>	
	public partial class m_PDS
	{ 
		public m_PDS()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_PDS  ");
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
		public int Add(DB_Talk.Model.m_PDS model,bool IsReturnID)   
		{
		    int Result=0;
		    StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();	
			if(model.PdsID!=null)
		    {
			   strSql1.Append("PdsID,");	
			   strSql2.Append("'"+ model.PdsID +"',");	
			} 
            if(model.BoxID!=null)
		    {
			   strSql1.Append("BoxID,");	
			   strSql2.Append("'"+ model.BoxID +"',");	
			} 
            if(model.vc_IP!=null)
		    {
			   strSql1.Append("vc_IP,");	
			   strSql2.Append("'"+ model.vc_IP +"',");	
			} 
            if(model.i_ConfState!=null)
		    {
			   strSql1.Append("i_ConfState,");	
			   strSql2.Append("'"+ model.i_ConfState +"',");	
			} 
            if(model.i_OperateState!=null)
		    {
			   strSql1.Append("i_OperateState,");	
			   strSql2.Append("'"+ model.i_OperateState +"',");	
			} 
            if(model.i_IdleGtpChannelCount!=null)
		    {
			   strSql1.Append("i_IdleGtpChannelCount,");	
			   strSql2.Append("'"+ model.i_IdleGtpChannelCount +"',");	
			} 
            if(model.i_BusyGtpChannelCount!=null)
		    {
			   strSql1.Append("i_BusyGtpChannelCount,");	
			   strSql2.Append("'"+ model.i_BusyGtpChannelCount +"',");	
			} 
            if(model.i_IdleVideoChannelCount!=null)
		    {
			   strSql1.Append("i_IdleVideoChannelCount,");	
			   strSql2.Append("'"+ model.i_IdleVideoChannelCount +"',");	
			} 
            if(model.i_BusyVideoChannelCount!=null)
		    {
			   strSql1.Append("i_BusyVideoChannelCount,");	
			   strSql2.Append("'"+ model.i_BusyVideoChannelCount +"',");	
			} 
            if(model.vc_Memo!=null)
		    {
			   strSql1.Append("vc_Memo,");	
			   strSql2.Append("'"+ model.vc_Memo +"',");	
			} 
            if(model.i_Flag!=null)
		    {
			   strSql1.Append("i_Flag,");	
			   strSql2.Append("'"+ model.i_Flag +"',");	
			} 
            strSql.Append("insert into m_PDS(");	
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
		public bool Update(DB_Talk.Model.m_PDS model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_PDS set ");
			if(model.PdsID!=null)
		    {
			   strSql.Append("PdsID='"+ model.PdsID +"',");	
			} 
			if(model.BoxID!=null)
		    {
			   strSql.Append("BoxID='"+ model.BoxID +"',");	
			} 
			if(model.vc_IP!=null)
		    {
			   strSql.Append("vc_IP='"+ model.vc_IP +"',");	
			} 
			if(model.i_ConfState!=null)
		    {
			   strSql.Append("i_ConfState='"+ model.i_ConfState +"',");	
			} 
			if(model.i_OperateState!=null)
		    {
			   strSql.Append("i_OperateState='"+ model.i_OperateState +"',");	
			} 
			if(model.i_IdleGtpChannelCount!=null)
		    {
			   strSql.Append("i_IdleGtpChannelCount='"+ model.i_IdleGtpChannelCount +"',");	
			} 
			if(model.i_BusyGtpChannelCount!=null)
		    {
			   strSql.Append("i_BusyGtpChannelCount='"+ model.i_BusyGtpChannelCount +"',");	
			} 
			if(model.i_IdleVideoChannelCount!=null)
		    {
			   strSql.Append("i_IdleVideoChannelCount='"+ model.i_IdleVideoChannelCount +"',");	
			} 
			if(model.i_BusyVideoChannelCount!=null)
		    {
			   strSql.Append("i_BusyVideoChannelCount='"+ model.i_BusyVideoChannelCount +"',");	
			} 
			if(model.vc_Memo!=null)
		    {
			   strSql.Append("vc_Memo='"+ model.vc_Memo +"',");	
			} 
			if(model.i_Flag!=null)
		    {
			   strSql.Append("i_Flag='"+ model.i_Flag +"',");	
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
			    strSql.Append("delete from m_PDS ");	
			else
				strSql.Append("update m_PDS  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_PDS ");	
			else
				strSql.Append("update m_PDS  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_PDS ");	
			else
				strSql.Append("update m_PDS  set i_Flag=1 ");	 
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
		public DB_Talk.Model.m_PDS GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, PdsID, BoxID, vc_IP, i_ConfState, i_OperateState, i_IdleGtpChannelCount, i_BusyGtpChannelCount, i_IdleVideoChannelCount, i_BusyVideoChannelCount, vc_Memo, i_Flag  ");			
			strSql.Append("  from m_PDS ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_Talk.Model.m_PDS model=new DB_Talk.Model.m_PDS();
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
		public DB_Talk.Model.m_PDS GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, PdsID, BoxID, vc_IP, i_ConfState, i_OperateState, i_IdleGtpChannelCount, i_BusyGtpChannelCount, i_IdleVideoChannelCount, i_BusyVideoChannelCount, vc_Memo, i_Flag  ");			
			strSql.Append("  from m_PDS ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.m_PDS model=new DB_Talk.Model.m_PDS();
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
		    strSql.Append("  ID, PdsID, BoxID, vc_IP, i_ConfState, i_OperateState, i_IdleGtpChannelCount, i_BusyGtpChannelCount, i_IdleVideoChannelCount, i_BusyVideoChannelCount, vc_Memo, i_Flag  ");			
			strSql.Append(" FROM m_PDS ");
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
		public List<DB_Talk.Model.m_PDS> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.m_PDS> modelList = new List<DB_Talk.Model.m_PDS>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.m_PDS model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.m_PDS();	
                  if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
				  {
				      model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				  }
				  if(dt.Rows[n]["PdsID"]!=null && dt.Rows[n]["PdsID"].ToString()!="")
				  {
				      model.PdsID=int.Parse(dt.Rows[n]["PdsID"].ToString());
				  }
				  if(dt.Rows[n]["BoxID"]!=null && dt.Rows[n]["BoxID"].ToString()!="")
				  {
				      model.BoxID=int.Parse(dt.Rows[n]["BoxID"].ToString());
				  }
				  if(dt.Rows[n]["vc_IP"]!=null && dt.Rows[n]["vc_IP"].ToString()!="")
				  {
				     model.vc_IP= dt.Rows[n]["vc_IP"].ToString();
				  }
				  if(dt.Rows[n]["i_ConfState"]!=null && dt.Rows[n]["i_ConfState"].ToString()!="")
				  {
				      model.i_ConfState=int.Parse(dt.Rows[n]["i_ConfState"].ToString());
				  }
				  if(dt.Rows[n]["i_OperateState"]!=null && dt.Rows[n]["i_OperateState"].ToString()!="")
				  {
				      model.i_OperateState=int.Parse(dt.Rows[n]["i_OperateState"].ToString());
				  }
				  if(dt.Rows[n]["i_IdleGtpChannelCount"]!=null && dt.Rows[n]["i_IdleGtpChannelCount"].ToString()!="")
				  {
				      model.i_IdleGtpChannelCount=int.Parse(dt.Rows[n]["i_IdleGtpChannelCount"].ToString());
				  }
				  if(dt.Rows[n]["i_BusyGtpChannelCount"]!=null && dt.Rows[n]["i_BusyGtpChannelCount"].ToString()!="")
				  {
				      model.i_BusyGtpChannelCount=int.Parse(dt.Rows[n]["i_BusyGtpChannelCount"].ToString());
				  }
				  if(dt.Rows[n]["i_IdleVideoChannelCount"]!=null && dt.Rows[n]["i_IdleVideoChannelCount"].ToString()!="")
				  {
				      model.i_IdleVideoChannelCount=int.Parse(dt.Rows[n]["i_IdleVideoChannelCount"].ToString());
				  }
				  if(dt.Rows[n]["i_BusyVideoChannelCount"]!=null && dt.Rows[n]["i_BusyVideoChannelCount"].ToString()!="")
				  {
				      model.i_BusyVideoChannelCount=int.Parse(dt.Rows[n]["i_BusyVideoChannelCount"].ToString());
				  }
				  if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
				  {
				     model.vc_Memo= dt.Rows[n]["vc_Memo"].ToString();
				  }
				  if(dt.Rows[n]["i_Flag"]!=null && dt.Rows[n]["i_Flag"].ToString()!="")
				  {
				      model.i_Flag=int.Parse(dt.Rows[n]["i_Flag"].ToString());
				  }
				   modelList.Add(model);
				
				}
			}
			return modelList;
		}
		
        #endregion
	}
}