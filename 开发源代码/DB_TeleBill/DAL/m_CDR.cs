using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_TeleBill.DAL 
{
	/// <summary>
	///数据访问类 m_CDR
	/// </summary>	
	public partial class m_CDR
	{ 
		public m_CDR()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_CDR  ");
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
		public int Add(DB_TeleBill.Model.m_CDR model,bool IsReturnID)   
		{
		    int Result=0;
		    StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();	
			if(model.vc_CallingNum!=null)
		    {
			   strSql1.Append("vc_CallingNum,");	
			   strSql2.Append("'"+ model.vc_CallingNum +"',");	
			} 
            if(model.vc_CalledNum!=null)
		    {
			   strSql1.Append("vc_CalledNum,");	
			   strSql2.Append("'"+ model.vc_CalledNum +"',");	
			} 
            if(model.dt_SetupTime!=null)
		    {
			   strSql1.Append("dt_SetupTime,");	
			   strSql2.Append("'"+ model.dt_SetupTime +"',");	
			} 
            if(model.dt_ConnectTime!=null)
		    {
			   strSql1.Append("dt_ConnectTime,");	
			   strSql2.Append("'"+ model.dt_ConnectTime +"',");	
			} 
            if(model.dt_AnswerTime!=null)
		    {
			   strSql1.Append("dt_AnswerTime,");	
			   strSql2.Append("'"+ model.dt_AnswerTime +"',");	
			} 
            if(model.dt_DisconnectTime!=null)
		    {
			   strSql1.Append("dt_DisconnectTime,");	
			   strSql2.Append("'"+ model.dt_DisconnectTime +"',");	
			} 
            if(model.dt_RemoteDisconnecTime!=null)
		    {
			   strSql1.Append("dt_RemoteDisconnecTime,");	
			   strSql2.Append("'"+ model.dt_RemoteDisconnecTime +"',");	
			} 
            if(model.i_Duration!=null)
		    {
			   strSql1.Append("i_Duration,");	
			   strSql2.Append("'"+ model.i_Duration +"',");	
			} 
            if(model.vc_HostIP!=null)
		    {
			   strSql1.Append("vc_HostIP,");	
			   strSql2.Append("'"+ model.vc_HostIP +"',");	
			} 
            if(model.vc_VisitIP!=null)
		    {
			   strSql1.Append("vc_VisitIP,");	
			   strSql2.Append("'"+ model.vc_VisitIP +"',");	
			} 
            if(model.i_rpc!=null)
		    {
			   strSql1.Append("i_rpc,");	
			   strSql2.Append("'"+ model.i_rpc +"',");	
			} 
            if(model.i_rpno!=null)
		    {
			   strSql1.Append("i_rpno,");	
			   strSql2.Append("'"+ model.i_rpno +"',");	
			} 
            if(model.i_ServiceProvider!=null)
		    {
			   strSql1.Append("i_ServiceProvider,");	
			   strSql2.Append("'"+ model.i_ServiceProvider +"',");	
			} 
            if(model.i_CallType!=null)
		    {
			   strSql1.Append("i_CallType,");	
			   strSql2.Append("'"+ model.i_CallType +"',");	
			} 
            if(model.i_TalkType!=null)
		    {
			   strSql1.Append("i_TalkType,");	
			   strSql2.Append("'"+ model.i_TalkType +"',");	
			} 
            if(model.i_ChargeValue!=null)
		    {
			   strSql1.Append("i_ChargeValue,");	
			   strSql2.Append("'"+ model.i_ChargeValue +"',");	
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
            strSql.Append("insert into m_CDR(");	
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
		public bool Update(DB_TeleBill.Model.m_CDR model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_CDR set ");
			if(model.vc_CallingNum!=null)
		    {
			   strSql.Append("vc_CallingNum='"+ model.vc_CallingNum +"',");	
			} 
			if(model.vc_CalledNum!=null)
		    {
			   strSql.Append("vc_CalledNum='"+ model.vc_CalledNum +"',");	
			} 
			if(model.dt_SetupTime!=null)
		    {
			   strSql.Append("dt_SetupTime='"+ model.dt_SetupTime +"',");	
			} 
			if(model.dt_ConnectTime!=null)
		    {
			   strSql.Append("dt_ConnectTime='"+ model.dt_ConnectTime +"',");	
			} 
			if(model.dt_AnswerTime!=null)
		    {
			   strSql.Append("dt_AnswerTime='"+ model.dt_AnswerTime +"',");	
			} 
			if(model.dt_DisconnectTime!=null)
		    {
			   strSql.Append("dt_DisconnectTime='"+ model.dt_DisconnectTime +"',");	
			} 
			if(model.dt_RemoteDisconnecTime!=null)
		    {
			   strSql.Append("dt_RemoteDisconnecTime='"+ model.dt_RemoteDisconnecTime +"',");	
			} 
			if(model.i_Duration!=null)
		    {
			   strSql.Append("i_Duration='"+ model.i_Duration +"',");	
			} 
			if(model.vc_HostIP!=null)
		    {
			   strSql.Append("vc_HostIP='"+ model.vc_HostIP +"',");	
			} 
			if(model.vc_VisitIP!=null)
		    {
			   strSql.Append("vc_VisitIP='"+ model.vc_VisitIP +"',");	
			} 
			if(model.i_rpc!=null)
		    {
			   strSql.Append("i_rpc='"+ model.i_rpc +"',");	
			} 
			if(model.i_rpno!=null)
		    {
			   strSql.Append("i_rpno='"+ model.i_rpno +"',");	
			} 
			if(model.i_ServiceProvider!=null)
		    {
			   strSql.Append("i_ServiceProvider='"+ model.i_ServiceProvider +"',");	
			} 
			if(model.i_CallType!=null)
		    {
			   strSql.Append("i_CallType='"+ model.i_CallType +"',");	
			} 
			if(model.i_TalkType!=null)
		    {
			   strSql.Append("i_TalkType='"+ model.i_TalkType +"',");	
			} 
			if(model.i_ChargeValue!=null)
		    {
			   strSql.Append("i_ChargeValue='"+ model.i_ChargeValue +"',");	
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
			    strSql.Append("delete from m_CDR ");	
			else
				strSql.Append("update m_CDR  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_CDR ");	
			else
				strSql.Append("update m_CDR  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_CDR ");	
			else
				strSql.Append("update m_CDR  set i_Flag=1 ");	 
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
		public DB_TeleBill.Model.m_CDR GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, vc_CallingNum, vc_CalledNum, dt_SetupTime, dt_ConnectTime, dt_AnswerTime, dt_DisconnectTime, dt_RemoteDisconnecTime, i_Duration, vc_HostIP, vc_VisitIP, i_rpc, i_rpno, i_ServiceProvider, i_CallType, i_TalkType, i_ChargeValue, vc_Memo, i_Flag  ");			
			strSql.Append("  from m_CDR ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_TeleBill.Model.m_CDR model=new DB_TeleBill.Model.m_CDR();
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
		public DB_TeleBill.Model.m_CDR GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, vc_CallingNum, vc_CalledNum, dt_SetupTime, dt_ConnectTime, dt_AnswerTime, dt_DisconnectTime, dt_RemoteDisconnecTime, i_Duration, vc_HostIP, vc_VisitIP, i_rpc, i_rpno, i_ServiceProvider, i_CallType, i_TalkType, i_ChargeValue, vc_Memo, i_Flag  ");			
			strSql.Append("  from m_CDR ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_TeleBill.Model.m_CDR model=new DB_TeleBill.Model.m_CDR();
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
		    strSql.Append("  ID, vc_CallingNum, vc_CalledNum, dt_SetupTime, dt_ConnectTime, dt_AnswerTime, dt_DisconnectTime, dt_RemoteDisconnecTime, i_Duration, vc_HostIP, vc_VisitIP, i_rpc, i_rpno, i_ServiceProvider, i_CallType, i_TalkType, i_ChargeValue, vc_Memo, i_Flag  ");			
			strSql.Append(" FROM m_CDR ");
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
		public List<DB_TeleBill.Model.m_CDR> DataTableToList(DataSet ds)
		{
			List<DB_TeleBill.Model.m_CDR> modelList = new List<DB_TeleBill.Model.m_CDR>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_TeleBill.Model.m_CDR model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_TeleBill.Model.m_CDR();	
                  if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
				  {
				      model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				  }
				  if(dt.Rows[n]["vc_CallingNum"]!=null && dt.Rows[n]["vc_CallingNum"].ToString()!="")
				  {
				     model.vc_CallingNum= dt.Rows[n]["vc_CallingNum"].ToString();
				  }
				  if(dt.Rows[n]["vc_CalledNum"]!=null && dt.Rows[n]["vc_CalledNum"].ToString()!="")
				  {
				     model.vc_CalledNum= dt.Rows[n]["vc_CalledNum"].ToString();
				  }
				  if(dt.Rows[n]["dt_SetupTime"]!=null && dt.Rows[n]["dt_SetupTime"].ToString()!="")
				  {
				      model.dt_SetupTime=DateTime.Parse(dt.Rows[n]["dt_SetupTime"].ToString());
				  }
				  if(dt.Rows[n]["dt_ConnectTime"]!=null && dt.Rows[n]["dt_ConnectTime"].ToString()!="")
				  {
				      model.dt_ConnectTime=DateTime.Parse(dt.Rows[n]["dt_ConnectTime"].ToString());
				  }
				  if(dt.Rows[n]["dt_AnswerTime"]!=null && dt.Rows[n]["dt_AnswerTime"].ToString()!="")
				  {
				      model.dt_AnswerTime=DateTime.Parse(dt.Rows[n]["dt_AnswerTime"].ToString());
				  }
				  if(dt.Rows[n]["dt_DisconnectTime"]!=null && dt.Rows[n]["dt_DisconnectTime"].ToString()!="")
				  {
				      model.dt_DisconnectTime=DateTime.Parse(dt.Rows[n]["dt_DisconnectTime"].ToString());
				  }
				  if(dt.Rows[n]["dt_RemoteDisconnecTime"]!=null && dt.Rows[n]["dt_RemoteDisconnecTime"].ToString()!="")
				  {
				      model.dt_RemoteDisconnecTime=DateTime.Parse(dt.Rows[n]["dt_RemoteDisconnecTime"].ToString());
				  }
				  if(dt.Rows[n]["i_Duration"]!=null && dt.Rows[n]["i_Duration"].ToString()!="")
				  {
				      model.i_Duration=long.Parse(dt.Rows[n]["i_Duration"].ToString());
				  }
				  if(dt.Rows[n]["vc_HostIP"]!=null && dt.Rows[n]["vc_HostIP"].ToString()!="")
				  {
				     model.vc_HostIP= dt.Rows[n]["vc_HostIP"].ToString();
				  }
				  if(dt.Rows[n]["vc_VisitIP"]!=null && dt.Rows[n]["vc_VisitIP"].ToString()!="")
				  {
				     model.vc_VisitIP= dt.Rows[n]["vc_VisitIP"].ToString();
				  }
				  if(dt.Rows[n]["i_rpc"]!=null && dt.Rows[n]["i_rpc"].ToString()!="")
				  {
				      model.i_rpc=int.Parse(dt.Rows[n]["i_rpc"].ToString());
				  }
				  if(dt.Rows[n]["i_rpno"]!=null && dt.Rows[n]["i_rpno"].ToString()!="")
				  {
				      model.i_rpno=int.Parse(dt.Rows[n]["i_rpno"].ToString());
				  }
				  if(dt.Rows[n]["i_ServiceProvider"]!=null && dt.Rows[n]["i_ServiceProvider"].ToString()!="")
				  {
				      model.i_ServiceProvider=int.Parse(dt.Rows[n]["i_ServiceProvider"].ToString());
				  }
				  if(dt.Rows[n]["i_CallType"]!=null && dt.Rows[n]["i_CallType"].ToString()!="")
				  {
				      model.i_CallType=int.Parse(dt.Rows[n]["i_CallType"].ToString());
				  }
				  if(dt.Rows[n]["i_TalkType"]!=null && dt.Rows[n]["i_TalkType"].ToString()!="")
				  {
				      model.i_TalkType=int.Parse(dt.Rows[n]["i_TalkType"].ToString());
				  }
				  if(dt.Rows[n]["i_ChargeValue"]!=null && dt.Rows[n]["i_ChargeValue"].ToString()!="")
				  {
				      model.i_ChargeValue=long.Parse(dt.Rows[n]["i_ChargeValue"].ToString());
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