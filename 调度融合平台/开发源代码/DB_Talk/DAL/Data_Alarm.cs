using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 Data_Alarm
	/// </summary>	
	public partial class Data_Alarm
	{ 
		public Data_Alarm()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Data_Alarm  ");
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
		public int Add(DB_Talk.Model.Data_Alarm model,bool IsReturnID)   
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
            if(model.dt_DateTime!=null)
		    {
			   strSql1.Append("dt_DateTime,");	
			   strSql2.Append("'"+ model.dt_DateTime +"',");	
			} 
            if(model.AlarmTypeID!=null)
		    {
			   strSql1.Append("AlarmTypeID,");	
			   strSql2.Append("'"+ model.AlarmTypeID +"',");	
			} 
            if(model.vc_Memo!=null)
		    {
			   strSql1.Append("vc_Memo,");	
			   strSql2.Append("'"+ model.vc_Memo +"',");	
			} 
            if(model.i_AlarmSeriesNumber!=null)
		    {
			   strSql1.Append("i_AlarmSeriesNumber,");	
			   strSql2.Append("'"+ model.i_AlarmSeriesNumber +"',");	
			} 
            if(model.i_AlarmInfo!=null)
		    {
			   strSql1.Append("i_AlarmInfo,");	
			   strSql2.Append("'"+ model.i_AlarmInfo +"',");	
			} 
            if(model.i_AlarmInfoDetail!=null)
		    {
			   strSql1.Append("i_AlarmInfoDetail,");	
			   strSql2.Append("'"+ model.i_AlarmInfoDetail +"',");	
			} 
            if(model.i_AlarmEntityType!=null)
		    {
			   strSql1.Append("i_AlarmEntityType,");	
			   strSql2.Append("'"+ model.i_AlarmEntityType +"',");	
			} 
            if(model.i_AlarmEntityInstance!=null)
		    {
			   strSql1.Append("i_AlarmEntityInstance,");	
			   strSql2.Append("'"+ model.i_AlarmEntityInstance +"',");	
			} 
            if(model.i_AlarmEntityInstanceShelf!=null)
		    {
			   strSql1.Append("i_AlarmEntityInstanceShelf,");	
			   strSql2.Append("'"+ model.i_AlarmEntityInstanceShelf +"',");	
			} 
            if(model.i_AlarmEntityInstanceSlot!=null)
		    {
			   strSql1.Append("i_AlarmEntityInstanceSlot,");	
			   strSql2.Append("'"+ model.i_AlarmEntityInstanceSlot +"',");	
			} 
            if(model.i_AlarmEntityInstancePort!=null)
		    {
			   strSql1.Append("i_AlarmEntityInstancePort,");	
			   strSql2.Append("'"+ model.i_AlarmEntityInstancePort +"',");	
			} 
            if(model.i_AlarmClass!=null)
		    {
			   strSql1.Append("i_AlarmClass,");	
			   strSql2.Append("'"+ model.i_AlarmClass +"',");	
			} 
            if(model.i_AlarmSeverity!=null)
		    {
			   strSql1.Append("i_AlarmSeverity,");	
			   strSql2.Append("'"+ model.i_AlarmSeverity +"',");	
			} 
            if(model.i_AlarmAckFlag!=null)
		    {
			   strSql1.Append("i_AlarmAckFlag,");	
			   strSql2.Append("'"+ model.i_AlarmAckFlag +"',");	
			} 
            strSql.Append("insert into Data_Alarm(");	
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
		public bool Update(DB_Talk.Model.Data_Alarm model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Data_Alarm set ");
			if(model.BoxID!=null)
		    {
			   strSql.Append("BoxID='"+ model.BoxID +"',");	
			} 
			if(model.dt_DateTime!=null)
		    {
			   strSql.Append("dt_DateTime='"+ model.dt_DateTime +"',");	
			} 
			if(model.AlarmTypeID!=null)
		    {
			   strSql.Append("AlarmTypeID='"+ model.AlarmTypeID +"',");	
			} 
			if(model.vc_Memo!=null)
		    {
			   strSql.Append("vc_Memo='"+ model.vc_Memo +"',");	
			} 
			if(model.i_AlarmSeriesNumber!=null)
		    {
			   strSql.Append("i_AlarmSeriesNumber='"+ model.i_AlarmSeriesNumber +"',");	
			} 
			if(model.i_AlarmInfo!=null)
		    {
			   strSql.Append("i_AlarmInfo='"+ model.i_AlarmInfo +"',");	
			} 
			if(model.i_AlarmInfoDetail!=null)
		    {
			   strSql.Append("i_AlarmInfoDetail='"+ model.i_AlarmInfoDetail +"',");	
			} 
			if(model.i_AlarmEntityType!=null)
		    {
			   strSql.Append("i_AlarmEntityType='"+ model.i_AlarmEntityType +"',");	
			} 
			if(model.i_AlarmEntityInstance!=null)
		    {
			   strSql.Append("i_AlarmEntityInstance='"+ model.i_AlarmEntityInstance +"',");	
			} 
			if(model.i_AlarmEntityInstanceShelf!=null)
		    {
			   strSql.Append("i_AlarmEntityInstanceShelf='"+ model.i_AlarmEntityInstanceShelf +"',");	
			} 
			if(model.i_AlarmEntityInstanceSlot!=null)
		    {
			   strSql.Append("i_AlarmEntityInstanceSlot='"+ model.i_AlarmEntityInstanceSlot +"',");	
			} 
			if(model.i_AlarmEntityInstancePort!=null)
		    {
			   strSql.Append("i_AlarmEntityInstancePort='"+ model.i_AlarmEntityInstancePort +"',");	
			} 
			if(model.i_AlarmClass!=null)
		    {
			   strSql.Append("i_AlarmClass='"+ model.i_AlarmClass +"',");	
			} 
			if(model.i_AlarmSeverity!=null)
		    {
			   strSql.Append("i_AlarmSeverity='"+ model.i_AlarmSeverity +"',");	
			} 
			if(model.i_AlarmAckFlag!=null)
		    {
			   strSql.Append("i_AlarmAckFlag='"+ model.i_AlarmAckFlag +"',");	
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
			    strSql.Append("delete from Data_Alarm ");	
			else
				strSql.Append("update Data_Alarm  set i_Flag=1 ");	 
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
			    strSql.Append("delete from Data_Alarm ");	
			else
				strSql.Append("update Data_Alarm  set i_Flag=1 ");	 
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
			    strSql.Append("delete from Data_Alarm ");	
			else
				strSql.Append("update Data_Alarm  set i_Flag=1 ");	 
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
		public DB_Talk.Model.Data_Alarm GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, dt_DateTime, AlarmTypeID, vc_Memo, i_AlarmSeriesNumber, i_AlarmInfo, i_AlarmInfoDetail, i_AlarmEntityType, i_AlarmEntityInstance, i_AlarmEntityInstanceShelf, i_AlarmEntityInstanceSlot, i_AlarmEntityInstancePort, i_AlarmClass, i_AlarmSeverity, i_AlarmAckFlag  ");			
			strSql.Append("  from Data_Alarm ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_Talk.Model.Data_Alarm model=new DB_Talk.Model.Data_Alarm();
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
		public DB_Talk.Model.Data_Alarm GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, dt_DateTime, AlarmTypeID, vc_Memo, i_AlarmSeriesNumber, i_AlarmInfo, i_AlarmInfoDetail, i_AlarmEntityType, i_AlarmEntityInstance, i_AlarmEntityInstanceShelf, i_AlarmEntityInstanceSlot, i_AlarmEntityInstancePort, i_AlarmClass, i_AlarmSeverity, i_AlarmAckFlag  ");			
			strSql.Append("  from Data_Alarm ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.Data_Alarm model=new DB_Talk.Model.Data_Alarm();
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
		    strSql.Append("  ID, BoxID, dt_DateTime, AlarmTypeID, vc_Memo, i_AlarmSeriesNumber, i_AlarmInfo, i_AlarmInfoDetail, i_AlarmEntityType, i_AlarmEntityInstance, i_AlarmEntityInstanceShelf, i_AlarmEntityInstanceSlot, i_AlarmEntityInstancePort, i_AlarmClass, i_AlarmSeverity, i_AlarmAckFlag  ");			
			strSql.Append(" FROM Data_Alarm ");
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
		public List<DB_Talk.Model.Data_Alarm> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.Data_Alarm> modelList = new List<DB_Talk.Model.Data_Alarm>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.Data_Alarm model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.Data_Alarm();	
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
				  if(dt.Rows[n]["i_AlarmEntityInstanceShelf"]!=null && dt.Rows[n]["i_AlarmEntityInstanceShelf"].ToString()!="")
				  {
				      model.i_AlarmEntityInstanceShelf=int.Parse(dt.Rows[n]["i_AlarmEntityInstanceShelf"].ToString());
				  }
				  if(dt.Rows[n]["i_AlarmEntityInstanceSlot"]!=null && dt.Rows[n]["i_AlarmEntityInstanceSlot"].ToString()!="")
				  {
				      model.i_AlarmEntityInstanceSlot=int.Parse(dt.Rows[n]["i_AlarmEntityInstanceSlot"].ToString());
				  }
				  if(dt.Rows[n]["i_AlarmEntityInstancePort"]!=null && dt.Rows[n]["i_AlarmEntityInstancePort"].ToString()!="")
				  {
				      model.i_AlarmEntityInstancePort=int.Parse(dt.Rows[n]["i_AlarmEntityInstancePort"].ToString());
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
				   modelList.Add(model);
				
				}
			}
			return modelList;
		}
		
        #endregion
	}
}