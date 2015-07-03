using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 m_Box
	/// </summary>	
	public partial class m_Box
	{ 
		public m_Box()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_Box  ");
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
		public int Add(DB_Talk.Model.m_Box model,bool IsReturnID)   
		{
		    int Result=0;
		    StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();	
			if(model.vc_Name!=null)
		    {
			   strSql1.Append("vc_Name,");	
			   strSql2.Append("'"+ model.vc_Name +"',");	
			} 
            if(model.vc_IP!=null)
		    {
			   strSql1.Append("vc_IP,");	
			   strSql2.Append("'"+ model.vc_IP +"',");	
			} 
            if(model.vc_SN!=null)
		    {
			   strSql1.Append("vc_SN,");	
			   strSql2.Append("'"+ model.vc_SN +"',");	
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
            if(model.i_MaxMeetingMember!=null)
		    {
			   strSql1.Append("i_MaxMeetingMember,");	
			   strSql2.Append("'"+ model.i_MaxMeetingMember +"',");	
			} 
            if(model.vc_Mask!=null)
		    {
			   strSql1.Append("vc_Mask,");	
			   strSql2.Append("'"+ model.vc_Mask +"',");	
			} 
            if(model.vc_NetIP!=null)
		    {
			   strSql1.Append("vc_NetIP,");	
			   strSql2.Append("'"+ model.vc_NetIP +"',");	
			} 
            if(model.vc_DspIP!=null)
		    {
			   strSql1.Append("vc_DspIP,");	
			   strSql2.Append("'"+ model.vc_DspIP +"',");	
			} 
            if(model.vc_DispatchIP1!=null)
		    {
			   strSql1.Append("vc_DispatchIP1,");	
			   strSql2.Append("'"+ model.vc_DispatchIP1 +"',");	
			} 
            if(model.vc_DispatchIP2!=null)
		    {
			   strSql1.Append("vc_DispatchIP2,");	
			   strSql2.Append("'"+ model.vc_DispatchIP2 +"',");	
			} 
            if(model.vc_RecordServerIP!=null)
		    {
			   strSql1.Append("vc_RecordServerIP,");	
			   strSql2.Append("'"+ model.vc_RecordServerIP +"',");	
			} 
            if(model.vc_TimerServerIP!=null)
		    {
			   strSql1.Append("vc_TimerServerIP,");	
			   strSql2.Append("'"+ model.vc_TimerServerIP +"',");	
			} 
            if(model.i_RecordServerEnable!=null)
		    {
			   strSql1.Append("i_RecordServerEnable,");	
			   strSql2.Append("'"+ model.i_RecordServerEnable +"',");	
			} 
            if(model.i_CDROpened!=null)
		    {
			   strSql1.Append("i_CDROpened,");	
			   strSql2.Append("'"+ model.i_CDROpened +"',");	
			} 
            if(model.i_RTCDROpened!=null)
		    {
			   strSql1.Append("i_RTCDROpened,");	
			   strSql2.Append("'"+ model.i_RTCDROpened +"',");	
			} 
            if(model.i_SIPRegistCycle!=null)
		    {
			   strSql1.Append("i_SIPRegistCycle,");	
			   strSql2.Append("'"+ model.i_SIPRegistCycle +"',");	
			} 
            if(model.i_SendCycle!=null)
		    {
			   strSql1.Append("i_SendCycle,");	
			   strSql2.Append("'"+ model.i_SendCycle +"',");	
			} 
            if(model.i_RelEnable!=null)
		    {
			   strSql1.Append("i_RelEnable,");	
			   strSql2.Append("'"+ model.i_RelEnable +"',");	
			} 
            if(model.i_CheckUserOnline!=null)
		    {
			   strSql1.Append("i_CheckUserOnline,");	
			   strSql2.Append("'"+ model.i_CheckUserOnline +"',");	
			} 
            if(model.i_DispatchNumber!=null)
		    {
			   strSql1.Append("i_DispatchNumber,");	
			   strSql2.Append("'"+ model.i_DispatchNumber +"',");	
			} 
            if(model.i_EmergencyNumber!=null)
		    {
			   strSql1.Append("i_EmergencyNumber,");	
			   strSql2.Append("'"+ model.i_EmergencyNumber +"',");	
			} 
            if(model.vc_NumberHead!=null)
		    {
			   strSql1.Append("vc_NumberHead,");	
			   strSql2.Append("'"+ model.vc_NumberHead +"',");	
			} 
            if(model.i_NumberLen!=null)
		    {
			   strSql1.Append("i_NumberLen,");	
			   strSql2.Append("'"+ model.i_NumberLen +"',");	
			} 
            strSql.Append("insert into m_Box(");	
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
		public bool Update(DB_Talk.Model.m_Box model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_Box set ");
			if(model.vc_Name!=null)
		    {
			   strSql.Append("vc_Name='"+ model.vc_Name +"',");	
			} 
			if(model.vc_IP!=null)
		    {
			   strSql.Append("vc_IP='"+ model.vc_IP +"',");	
			} 
			if(model.vc_SN!=null)
		    {
			   strSql.Append("vc_SN='"+ model.vc_SN +"',");	
			} 
			if(model.vc_Memo!=null)
		    {
			   strSql.Append("vc_Memo='"+ model.vc_Memo +"',");	
			} 
			if(model.i_Flag!=null)
		    {
			   strSql.Append("i_Flag='"+ model.i_Flag +"',");	
			} 
			if(model.i_MaxMeetingMember!=null)
		    {
			   strSql.Append("i_MaxMeetingMember='"+ model.i_MaxMeetingMember +"',");	
			} 
			if(model.vc_Mask!=null)
		    {
			   strSql.Append("vc_Mask='"+ model.vc_Mask +"',");	
			} 
			if(model.vc_NetIP!=null)
		    {
			   strSql.Append("vc_NetIP='"+ model.vc_NetIP +"',");	
			} 
			if(model.vc_DspIP!=null)
		    {
			   strSql.Append("vc_DspIP='"+ model.vc_DspIP +"',");	
			} 
			if(model.vc_DispatchIP1!=null)
		    {
			   strSql.Append("vc_DispatchIP1='"+ model.vc_DispatchIP1 +"',");	
			} 
			if(model.vc_DispatchIP2!=null)
		    {
			   strSql.Append("vc_DispatchIP2='"+ model.vc_DispatchIP2 +"',");	
			} 
			if(model.vc_RecordServerIP!=null)
		    {
			   strSql.Append("vc_RecordServerIP='"+ model.vc_RecordServerIP +"',");	
			} 
			if(model.vc_TimerServerIP!=null)
		    {
			   strSql.Append("vc_TimerServerIP='"+ model.vc_TimerServerIP +"',");	
			} 
			if(model.i_RecordServerEnable!=null)
		    {
			   strSql.Append("i_RecordServerEnable='"+ model.i_RecordServerEnable +"',");	
			} 
			if(model.i_CDROpened!=null)
		    {
			   strSql.Append("i_CDROpened='"+ model.i_CDROpened +"',");	
			} 
			if(model.i_RTCDROpened!=null)
		    {
			   strSql.Append("i_RTCDROpened='"+ model.i_RTCDROpened +"',");	
			} 
			if(model.i_SIPRegistCycle!=null)
		    {
			   strSql.Append("i_SIPRegistCycle='"+ model.i_SIPRegistCycle +"',");	
			} 
			if(model.i_SendCycle!=null)
		    {
			   strSql.Append("i_SendCycle='"+ model.i_SendCycle +"',");	
			} 
			if(model.i_RelEnable!=null)
		    {
			   strSql.Append("i_RelEnable='"+ model.i_RelEnable +"',");	
			} 
			if(model.i_CheckUserOnline!=null)
		    {
			   strSql.Append("i_CheckUserOnline='"+ model.i_CheckUserOnline +"',");	
			} 
			if(model.i_DispatchNumber!=null)
		    {
			   strSql.Append("i_DispatchNumber='"+ model.i_DispatchNumber +"',");	
			} 
			if(model.i_EmergencyNumber!=null)
		    {
			   strSql.Append("i_EmergencyNumber='"+ model.i_EmergencyNumber +"',");	
			} 
			if(model.vc_NumberHead!=null)
		    {
			   strSql.Append("vc_NumberHead='"+ model.vc_NumberHead +"',");	
			} 
			if(model.i_NumberLen!=null)
		    {
			   strSql.Append("i_NumberLen='"+ model.i_NumberLen +"',");	
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
			    strSql.Append("delete from m_Box ");	
			else
				strSql.Append("update m_Box  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_Box ");	
			else
				strSql.Append("update m_Box  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_Box ");	
			else
				strSql.Append("update m_Box  set i_Flag=1 ");	 
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
		public DB_Talk.Model.m_Box GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, vc_Name, vc_IP, vc_SN, vc_Memo, i_Flag, i_MaxMeetingMember, vc_Mask, vc_NetIP, vc_DspIP, vc_DispatchIP1, vc_DispatchIP2, vc_RecordServerIP, vc_TimerServerIP, i_RecordServerEnable, i_CDROpened, i_RTCDROpened, i_SIPRegistCycle, i_SendCycle, i_RelEnable, i_CheckUserOnline, i_DispatchNumber, i_EmergencyNumber, vc_NumberHead, i_NumberLen  ");			
			strSql.Append("  from m_Box ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_Talk.Model.m_Box model=new DB_Talk.Model.m_Box();
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
		public DB_Talk.Model.m_Box GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, vc_Name, vc_IP, vc_SN, vc_Memo, i_Flag, i_MaxMeetingMember, vc_Mask, vc_NetIP, vc_DspIP, vc_DispatchIP1, vc_DispatchIP2, vc_RecordServerIP, vc_TimerServerIP, i_RecordServerEnable, i_CDROpened, i_RTCDROpened, i_SIPRegistCycle, i_SendCycle, i_RelEnable, i_CheckUserOnline, i_DispatchNumber, i_EmergencyNumber, vc_NumberHead, i_NumberLen  ");			
			strSql.Append("  from m_Box ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.m_Box model=new DB_Talk.Model.m_Box();
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
		    strSql.Append("  ID, vc_Name, vc_IP, vc_SN, vc_Memo, i_Flag, i_MaxMeetingMember, vc_Mask, vc_NetIP, vc_DspIP, vc_DispatchIP1, vc_DispatchIP2, vc_RecordServerIP, vc_TimerServerIP, i_RecordServerEnable, i_CDROpened, i_RTCDROpened, i_SIPRegistCycle, i_SendCycle, i_RelEnable, i_CheckUserOnline, i_DispatchNumber, i_EmergencyNumber, vc_NumberHead, i_NumberLen  ");			
			strSql.Append(" FROM m_Box ");
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
		public List<DB_Talk.Model.m_Box> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.m_Box> modelList = new List<DB_Talk.Model.m_Box>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.m_Box model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.m_Box();	
                  if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
				  {
				      model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				  }
				  if(dt.Rows[n]["vc_Name"]!=null && dt.Rows[n]["vc_Name"].ToString()!="")
				  {
				     model.vc_Name= dt.Rows[n]["vc_Name"].ToString();
				  }
				  if(dt.Rows[n]["vc_IP"]!=null && dt.Rows[n]["vc_IP"].ToString()!="")
				  {
				     model.vc_IP= dt.Rows[n]["vc_IP"].ToString();
				  }
				  if(dt.Rows[n]["vc_SN"]!=null && dt.Rows[n]["vc_SN"].ToString()!="")
				  {
				     model.vc_SN= dt.Rows[n]["vc_SN"].ToString();
				  }
				  if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
				  {
				     model.vc_Memo= dt.Rows[n]["vc_Memo"].ToString();
				  }
				  if(dt.Rows[n]["i_Flag"]!=null && dt.Rows[n]["i_Flag"].ToString()!="")
				  {
				      model.i_Flag=int.Parse(dt.Rows[n]["i_Flag"].ToString());
				  }
				  if(dt.Rows[n]["i_MaxMeetingMember"]!=null && dt.Rows[n]["i_MaxMeetingMember"].ToString()!="")
				  {
				      model.i_MaxMeetingMember=int.Parse(dt.Rows[n]["i_MaxMeetingMember"].ToString());
				  }
				  if(dt.Rows[n]["vc_Mask"]!=null && dt.Rows[n]["vc_Mask"].ToString()!="")
				  {
				     model.vc_Mask= dt.Rows[n]["vc_Mask"].ToString();
				  }
				  if(dt.Rows[n]["vc_NetIP"]!=null && dt.Rows[n]["vc_NetIP"].ToString()!="")
				  {
				     model.vc_NetIP= dt.Rows[n]["vc_NetIP"].ToString();
				  }
				  if(dt.Rows[n]["vc_DspIP"]!=null && dt.Rows[n]["vc_DspIP"].ToString()!="")
				  {
				     model.vc_DspIP= dt.Rows[n]["vc_DspIP"].ToString();
				  }
				  if(dt.Rows[n]["vc_DispatchIP1"]!=null && dt.Rows[n]["vc_DispatchIP1"].ToString()!="")
				  {
				     model.vc_DispatchIP1= dt.Rows[n]["vc_DispatchIP1"].ToString();
				  }
				  if(dt.Rows[n]["vc_DispatchIP2"]!=null && dt.Rows[n]["vc_DispatchIP2"].ToString()!="")
				  {
				     model.vc_DispatchIP2= dt.Rows[n]["vc_DispatchIP2"].ToString();
				  }
				  if(dt.Rows[n]["vc_RecordServerIP"]!=null && dt.Rows[n]["vc_RecordServerIP"].ToString()!="")
				  {
				     model.vc_RecordServerIP= dt.Rows[n]["vc_RecordServerIP"].ToString();
				  }
				  if(dt.Rows[n]["vc_TimerServerIP"]!=null && dt.Rows[n]["vc_TimerServerIP"].ToString()!="")
				  {
				     model.vc_TimerServerIP= dt.Rows[n]["vc_TimerServerIP"].ToString();
				  }
				  if(dt.Rows[n]["i_RecordServerEnable"]!=null && dt.Rows[n]["i_RecordServerEnable"].ToString()!="")
				  {
				      model.i_RecordServerEnable=int.Parse(dt.Rows[n]["i_RecordServerEnable"].ToString());
				  }
				  if(dt.Rows[n]["i_CDROpened"]!=null && dt.Rows[n]["i_CDROpened"].ToString()!="")
				  {
				      model.i_CDROpened=int.Parse(dt.Rows[n]["i_CDROpened"].ToString());
				  }
				  if(dt.Rows[n]["i_RTCDROpened"]!=null && dt.Rows[n]["i_RTCDROpened"].ToString()!="")
				  {
				      model.i_RTCDROpened=int.Parse(dt.Rows[n]["i_RTCDROpened"].ToString());
				  }
				  if(dt.Rows[n]["i_SIPRegistCycle"]!=null && dt.Rows[n]["i_SIPRegistCycle"].ToString()!="")
				  {
				      model.i_SIPRegistCycle=int.Parse(dt.Rows[n]["i_SIPRegistCycle"].ToString());
				  }
				  if(dt.Rows[n]["i_SendCycle"]!=null && dt.Rows[n]["i_SendCycle"].ToString()!="")
				  {
				      model.i_SendCycle=int.Parse(dt.Rows[n]["i_SendCycle"].ToString());
				  }
				  if(dt.Rows[n]["i_RelEnable"]!=null && dt.Rows[n]["i_RelEnable"].ToString()!="")
				  {
				      model.i_RelEnable=int.Parse(dt.Rows[n]["i_RelEnable"].ToString());
				  }
				  if(dt.Rows[n]["i_CheckUserOnline"]!=null && dt.Rows[n]["i_CheckUserOnline"].ToString()!="")
				  {
				      model.i_CheckUserOnline=int.Parse(dt.Rows[n]["i_CheckUserOnline"].ToString());
				  }
				  if(dt.Rows[n]["i_DispatchNumber"]!=null && dt.Rows[n]["i_DispatchNumber"].ToString()!="")
				  {
				      model.i_DispatchNumber=int.Parse(dt.Rows[n]["i_DispatchNumber"].ToString());
				  }
				  if(dt.Rows[n]["i_EmergencyNumber"]!=null && dt.Rows[n]["i_EmergencyNumber"].ToString()!="")
				  {
				      model.i_EmergencyNumber=int.Parse(dt.Rows[n]["i_EmergencyNumber"].ToString());
				  }
				  if(dt.Rows[n]["vc_NumberHead"]!=null && dt.Rows[n]["vc_NumberHead"].ToString()!="")
				  {
				     model.vc_NumberHead= dt.Rows[n]["vc_NumberHead"].ToString();
				  }
				  if(dt.Rows[n]["i_NumberLen"]!=null && dt.Rows[n]["i_NumberLen"].ToString()!="")
				  {
				      model.i_NumberLen=int.Parse(dt.Rows[n]["i_NumberLen"].ToString());
				  }
				   modelList.Add(model);
				
				}
			}
			return modelList;
		}
		
        #endregion
	}
}