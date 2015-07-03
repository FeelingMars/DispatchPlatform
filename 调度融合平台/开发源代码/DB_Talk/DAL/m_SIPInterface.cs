using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 m_SIPInterface
	/// </summary>	
	public partial class m_SIPInterface
	{ 
		public m_SIPInterface()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_SIPInterface  ");
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
		public int Add(DB_Talk.Model.m_SIPInterface model,bool IsReturnID)   
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
            if(model.vc_Code!=null)
		    {
			   strSql1.Append("vc_Code,");	
			   strSql2.Append("'"+ model.vc_Code +"',");	
			} 
            if(model.vc_Name!=null)
		    {
			   strSql1.Append("vc_Name,");	
			   strSql2.Append("'"+ model.vc_Name +"',");	
			} 
            if(model.SIPID!=null)
		    {
			   strSql1.Append("SIPID,");	
			   strSql2.Append("'"+ model.SIPID +"',");	
			} 
            if(model.RouteID!=null)
		    {
			   strSql1.Append("RouteID,");	
			   strSql2.Append("'"+ model.RouteID +"',");	
			} 
            if(model.SAPID!=null)
		    {
			   strSql1.Append("SAPID,");	
			   strSql2.Append("'"+ model.SAPID +"',");	
			} 
            if(model.vc_OutNumber!=null)
		    {
			   strSql1.Append("vc_OutNumber,");	
			   strSql2.Append("'"+ model.vc_OutNumber +"',");	
			} 
            if(model.vc_OutNumberLocal!=null)
		    {
			   strSql1.Append("vc_OutNumberLocal,");	
			   strSql2.Append("'"+ model.vc_OutNumberLocal +"',");	
			} 
            if(model.vc_OppositeIP!=null)
		    {
			   strSql1.Append("vc_OppositeIP,");	
			   strSql2.Append("'"+ model.vc_OppositeIP +"',");	
			} 
            if(model.i_Port!=null)
		    {
			   strSql1.Append("i_Port,");	
			   strSql2.Append("'"+ model.i_Port +"',");	
			} 
            if(model.i_OppositePort!=null)
		    {
			   strSql1.Append("i_OppositePort,");	
			   strSql2.Append("'"+ model.i_OppositePort +"',");	
			} 
            if(model.i_State!=null)
		    {
			   strSql1.Append("i_State,");	
			   strSql2.Append("'"+ model.i_State +"',");	
			} 
            if(model.i_Type!=null)
		    {
			   strSql1.Append("i_Type,");	
			   strSql2.Append("'"+ model.i_Type +"',");	
			} 
            if(model.i_Level!=null)
		    {
			   strSql1.Append("i_Level,");	
			   strSql2.Append("'"+ model.i_Level +"',");	
			} 
            if(model.i_MaxChannel!=null)
		    {
			   strSql1.Append("i_MaxChannel,");	
			   strSql2.Append("'"+ model.i_MaxChannel +"',");	
			} 
            if(model.i_PlaySound!=null)
		    {
			   strSql1.Append("i_PlaySound,");	
			   strSql2.Append("'"+ model.i_PlaySound +"',");	
			} 
            if(model.i_OperateState!=null)
		    {
			   strSql1.Append("i_OperateState,");	
			   strSql2.Append("'"+ model.i_OperateState +"',");	
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
            strSql.Append("insert into m_SIPInterface(");	
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
		public bool Update(DB_Talk.Model.m_SIPInterface model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_SIPInterface set ");
			if(model.BoxID!=null)
		    {
			   strSql.Append("BoxID='"+ model.BoxID +"',");	
			} 
			if(model.vc_Code!=null)
		    {
			   strSql.Append("vc_Code='"+ model.vc_Code +"',");	
			} 
			if(model.vc_Name!=null)
		    {
			   strSql.Append("vc_Name='"+ model.vc_Name +"',");	
			} 
			if(model.SIPID!=null)
		    {
			   strSql.Append("SIPID='"+ model.SIPID +"',");	
			} 
			if(model.RouteID!=null)
		    {
			   strSql.Append("RouteID='"+ model.RouteID +"',");	
			} 
			if(model.SAPID!=null)
		    {
			   strSql.Append("SAPID='"+ model.SAPID +"',");	
			} 
			if(model.vc_OutNumber!=null)
		    {
			   strSql.Append("vc_OutNumber='"+ model.vc_OutNumber +"',");	
			} 
			if(model.vc_OutNumberLocal!=null)
		    {
			   strSql.Append("vc_OutNumberLocal='"+ model.vc_OutNumberLocal +"',");	
			} 
			if(model.vc_OppositeIP!=null)
		    {
			   strSql.Append("vc_OppositeIP='"+ model.vc_OppositeIP +"',");	
			} 
			if(model.i_Port!=null)
		    {
			   strSql.Append("i_Port='"+ model.i_Port +"',");	
			} 
			if(model.i_OppositePort!=null)
		    {
			   strSql.Append("i_OppositePort='"+ model.i_OppositePort +"',");	
			} 
			if(model.i_State!=null)
		    {
			   strSql.Append("i_State='"+ model.i_State +"',");	
			} 
			if(model.i_Type!=null)
		    {
			   strSql.Append("i_Type='"+ model.i_Type +"',");	
			} 
			if(model.i_Level!=null)
		    {
			   strSql.Append("i_Level='"+ model.i_Level +"',");	
			} 
			if(model.i_MaxChannel!=null)
		    {
			   strSql.Append("i_MaxChannel='"+ model.i_MaxChannel +"',");	
			} 
			if(model.i_PlaySound!=null)
		    {
			   strSql.Append("i_PlaySound='"+ model.i_PlaySound +"',");	
			} 
			if(model.i_OperateState!=null)
		    {
			   strSql.Append("i_OperateState='"+ model.i_OperateState +"',");	
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
			    strSql.Append("delete from m_SIPInterface ");	
			else
				strSql.Append("update m_SIPInterface  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_SIPInterface ");	
			else
				strSql.Append("update m_SIPInterface  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_SIPInterface ");	
			else
				strSql.Append("update m_SIPInterface  set i_Flag=1 ");	 
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
		public DB_Talk.Model.m_SIPInterface GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, vc_Code, vc_Name, SIPID, RouteID, SAPID, vc_OutNumber, vc_OutNumberLocal, vc_OppositeIP, i_Port, i_OppositePort, i_State, i_Type, i_Level, i_MaxChannel, i_PlaySound, i_OperateState, vc_Memo, i_Flag  ");			
			strSql.Append("  from m_SIPInterface ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_Talk.Model.m_SIPInterface model=new DB_Talk.Model.m_SIPInterface();
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
		public DB_Talk.Model.m_SIPInterface GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, vc_Code, vc_Name, SIPID, RouteID, SAPID, vc_OutNumber, vc_OutNumberLocal, vc_OppositeIP, i_Port, i_OppositePort, i_State, i_Type, i_Level, i_MaxChannel, i_PlaySound, i_OperateState, vc_Memo, i_Flag  ");			
			strSql.Append("  from m_SIPInterface ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.m_SIPInterface model=new DB_Talk.Model.m_SIPInterface();
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
		    strSql.Append("  ID, BoxID, vc_Code, vc_Name, SIPID, RouteID, SAPID, vc_OutNumber, vc_OutNumberLocal, vc_OppositeIP, i_Port, i_OppositePort, i_State, i_Type, i_Level, i_MaxChannel, i_PlaySound, i_OperateState, vc_Memo, i_Flag  ");			
			strSql.Append(" FROM m_SIPInterface ");
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
		public List<DB_Talk.Model.m_SIPInterface> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.m_SIPInterface> modelList = new List<DB_Talk.Model.m_SIPInterface>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.m_SIPInterface model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.m_SIPInterface();	
                  if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
				  {
				      model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				  }
				  if(dt.Rows[n]["BoxID"]!=null && dt.Rows[n]["BoxID"].ToString()!="")
				  {
				      model.BoxID=int.Parse(dt.Rows[n]["BoxID"].ToString());
				  }
				  if(dt.Rows[n]["vc_Code"]!=null && dt.Rows[n]["vc_Code"].ToString()!="")
				  {
				     model.vc_Code= dt.Rows[n]["vc_Code"].ToString();
				  }
				  if(dt.Rows[n]["vc_Name"]!=null && dt.Rows[n]["vc_Name"].ToString()!="")
				  {
				     model.vc_Name= dt.Rows[n]["vc_Name"].ToString();
				  }
				  if(dt.Rows[n]["SIPID"]!=null && dt.Rows[n]["SIPID"].ToString()!="")
				  {
				      model.SIPID=int.Parse(dt.Rows[n]["SIPID"].ToString());
				  }
				  if(dt.Rows[n]["RouteID"]!=null && dt.Rows[n]["RouteID"].ToString()!="")
				  {
				      model.RouteID=int.Parse(dt.Rows[n]["RouteID"].ToString());
				  }
				  if(dt.Rows[n]["SAPID"]!=null && dt.Rows[n]["SAPID"].ToString()!="")
				  {
				      model.SAPID=int.Parse(dt.Rows[n]["SAPID"].ToString());
				  }
				  if(dt.Rows[n]["vc_OutNumber"]!=null && dt.Rows[n]["vc_OutNumber"].ToString()!="")
				  {
				     model.vc_OutNumber= dt.Rows[n]["vc_OutNumber"].ToString();
				  }
				  if(dt.Rows[n]["vc_OutNumberLocal"]!=null && dt.Rows[n]["vc_OutNumberLocal"].ToString()!="")
				  {
				     model.vc_OutNumberLocal= dt.Rows[n]["vc_OutNumberLocal"].ToString();
				  }
				  if(dt.Rows[n]["vc_OppositeIP"]!=null && dt.Rows[n]["vc_OppositeIP"].ToString()!="")
				  {
				     model.vc_OppositeIP= dt.Rows[n]["vc_OppositeIP"].ToString();
				  }
				  if(dt.Rows[n]["i_Port"]!=null && dt.Rows[n]["i_Port"].ToString()!="")
				  {
				      model.i_Port=int.Parse(dt.Rows[n]["i_Port"].ToString());
				  }
				  if(dt.Rows[n]["i_OppositePort"]!=null && dt.Rows[n]["i_OppositePort"].ToString()!="")
				  {
				      model.i_OppositePort=int.Parse(dt.Rows[n]["i_OppositePort"].ToString());
				  }
				  if(dt.Rows[n]["i_State"]!=null && dt.Rows[n]["i_State"].ToString()!="")
				  {
				      model.i_State=int.Parse(dt.Rows[n]["i_State"].ToString());
				  }
				  if(dt.Rows[n]["i_Type"]!=null && dt.Rows[n]["i_Type"].ToString()!="")
				  {
				      model.i_Type=int.Parse(dt.Rows[n]["i_Type"].ToString());
				  }
				  if(dt.Rows[n]["i_Level"]!=null && dt.Rows[n]["i_Level"].ToString()!="")
				  {
				      model.i_Level=int.Parse(dt.Rows[n]["i_Level"].ToString());
				  }
				  if(dt.Rows[n]["i_MaxChannel"]!=null && dt.Rows[n]["i_MaxChannel"].ToString()!="")
				  {
				      model.i_MaxChannel=int.Parse(dt.Rows[n]["i_MaxChannel"].ToString());
				  }
				  if(dt.Rows[n]["i_PlaySound"]!=null && dt.Rows[n]["i_PlaySound"].ToString()!="")
				  {
				      model.i_PlaySound=int.Parse(dt.Rows[n]["i_PlaySound"].ToString());
				  }
				  if(dt.Rows[n]["i_OperateState"]!=null && dt.Rows[n]["i_OperateState"].ToString()!="")
				  {
				      model.i_OperateState=int.Parse(dt.Rows[n]["i_OperateState"].ToString());
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