using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 m_CalledRule
	/// </summary>	
	public partial class m_CalledRule
	{ 
		public m_CalledRule()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_CalledRule  ");
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
		public int Add(DB_Talk.Model.m_CalledRule model,bool IsReturnID)   
		{
		    int Result=0;
		    StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();	
			if(model.CalledID!=null)
		    {
			   strSql1.Append("CalledID,");	
			   strSql2.Append("'"+ model.CalledID +"',");	
			} 
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
            if(model.CallingOriID!=null)
		    {
			   strSql1.Append("CallingOriID,");	
			   strSql2.Append("'"+ model.CallingOriID +"',");	
			} 
            if(model.vc_CalledNumber!=null)
		    {
			   strSql1.Append("vc_CalledNumber,");	
			   strSql2.Append("'"+ model.vc_CalledNumber +"',");	
			} 
            if(model.i_CalledType!=null)
		    {
			   strSql1.Append("i_CalledType,");	
			   strSql2.Append("'"+ model.i_CalledType +"',");	
			} 
            if(model.i_CalledSubType!=null)
		    {
			   strSql1.Append("i_CalledSubType,");	
			   strSql2.Append("'"+ model.i_CalledSubType +"',");	
			} 
            if(model.DestRouteID!=null)
		    {
			   strSql1.Append("DestRouteID,");	
			   strSql2.Append("'"+ model.DestRouteID +"',");	
			} 
            if(model.i_CalledChangeType!=null)
		    {
			   strSql1.Append("i_CalledChangeType,");	
			   strSql2.Append("'"+ model.i_CalledChangeType +"',");	
			} 
            if(model.i_CalledChangePosition!=null)
		    {
			   strSql1.Append("i_CalledChangePosition,");	
			   strSql2.Append("'"+ model.i_CalledChangePosition +"',");	
			} 
            if(model.i_CalledChangeLength!=null)
		    {
			   strSql1.Append("i_CalledChangeLength,");	
			   strSql2.Append("'"+ model.i_CalledChangeLength +"',");	
			} 
            if(model.vc_CalledChangeTarget!=null)
		    {
			   strSql1.Append("vc_CalledChangeTarget,");	
			   strSql2.Append("'"+ model.vc_CalledChangeTarget +"',");	
			} 
            if(model.vc_Memo!=null)
		    {
			   strSql1.Append("vc_Memo,");	
			   strSql2.Append("'"+ model.vc_Memo +"',");	
			} 
            if(model.i_SIPID!=null)
		    {
			   strSql1.Append("i_SIPID,");	
			   strSql2.Append("'"+ model.i_SIPID +"',");	
			} 
            if(model.i_PRIID!=null)
		    {
			   strSql1.Append("i_PRIID,");	
			   strSql2.Append("'"+ model.i_PRIID +"',");	
			} 
            if(model.i_Flag!=null)
		    {
			   strSql1.Append("i_Flag,");	
			   strSql2.Append("'"+ model.i_Flag +"',");	
			} 
            strSql.Append("insert into m_CalledRule(");	
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
		public bool Update(DB_Talk.Model.m_CalledRule model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_CalledRule set ");
			if(model.CalledID!=null)
		    {
			   strSql.Append("CalledID='"+ model.CalledID +"',");	
			} 
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
			if(model.CallingOriID!=null)
		    {
			   strSql.Append("CallingOriID='"+ model.CallingOriID +"',");	
			} 
			if(model.vc_CalledNumber!=null)
		    {
			   strSql.Append("vc_CalledNumber='"+ model.vc_CalledNumber +"',");	
			} 
			if(model.i_CalledType!=null)
		    {
			   strSql.Append("i_CalledType='"+ model.i_CalledType +"',");	
			} 
			if(model.i_CalledSubType!=null)
		    {
			   strSql.Append("i_CalledSubType='"+ model.i_CalledSubType +"',");	
			} 
			if(model.DestRouteID!=null)
		    {
			   strSql.Append("DestRouteID='"+ model.DestRouteID +"',");	
			} 
			if(model.i_CalledChangeType!=null)
		    {
			   strSql.Append("i_CalledChangeType='"+ model.i_CalledChangeType +"',");	
			} 
			if(model.i_CalledChangePosition!=null)
		    {
			   strSql.Append("i_CalledChangePosition='"+ model.i_CalledChangePosition +"',");	
			} 
			if(model.i_CalledChangeLength!=null)
		    {
			   strSql.Append("i_CalledChangeLength='"+ model.i_CalledChangeLength +"',");	
			} 
			if(model.vc_CalledChangeTarget!=null)
		    {
			   strSql.Append("vc_CalledChangeTarget='"+ model.vc_CalledChangeTarget +"',");	
			} 
			if(model.vc_Memo!=null)
		    {
			   strSql.Append("vc_Memo='"+ model.vc_Memo +"',");	
			} 
			if(model.i_SIPID!=null)
		    {
			   strSql.Append("i_SIPID='"+ model.i_SIPID +"',");	
			} 
			if(model.i_PRIID!=null)
		    {
			   strSql.Append("i_PRIID='"+ model.i_PRIID +"',");	
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
			    strSql.Append("delete from m_CalledRule ");	
			else
				strSql.Append("update m_CalledRule  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_CalledRule ");	
			else
				strSql.Append("update m_CalledRule  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_CalledRule ");	
			else
				strSql.Append("update m_CalledRule  set i_Flag=1 ");	 
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
		public DB_Talk.Model.m_CalledRule GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, CalledID, BoxID, vc_Code, vc_Name, CallingOriID, vc_CalledNumber, i_CalledType, i_CalledSubType, DestRouteID, i_CalledChangeType, i_CalledChangePosition, i_CalledChangeLength, vc_CalledChangeTarget, vc_Memo, i_SIPID, i_PRIID, i_Flag  ");			
			strSql.Append("  from m_CalledRule ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_Talk.Model.m_CalledRule model=new DB_Talk.Model.m_CalledRule();
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
		public DB_Talk.Model.m_CalledRule GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, CalledID, BoxID, vc_Code, vc_Name, CallingOriID, vc_CalledNumber, i_CalledType, i_CalledSubType, DestRouteID, i_CalledChangeType, i_CalledChangePosition, i_CalledChangeLength, vc_CalledChangeTarget, vc_Memo, i_SIPID, i_PRIID, i_Flag  ");			
			strSql.Append("  from m_CalledRule ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.m_CalledRule model=new DB_Talk.Model.m_CalledRule();
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
		    strSql.Append("  ID, CalledID, BoxID, vc_Code, vc_Name, CallingOriID, vc_CalledNumber, i_CalledType, i_CalledSubType, DestRouteID, i_CalledChangeType, i_CalledChangePosition, i_CalledChangeLength, vc_CalledChangeTarget, vc_Memo, i_SIPID, i_PRIID, i_Flag  ");			
			strSql.Append(" FROM m_CalledRule ");
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
		public List<DB_Talk.Model.m_CalledRule> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.m_CalledRule> modelList = new List<DB_Talk.Model.m_CalledRule>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.m_CalledRule model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.m_CalledRule();	
                  if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
				  {
				      model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				  }
				  if(dt.Rows[n]["CalledID"]!=null && dt.Rows[n]["CalledID"].ToString()!="")
				  {
				      model.CalledID=int.Parse(dt.Rows[n]["CalledID"].ToString());
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
				  if(dt.Rows[n]["CallingOriID"]!=null && dt.Rows[n]["CallingOriID"].ToString()!="")
				  {
				      model.CallingOriID=int.Parse(dt.Rows[n]["CallingOriID"].ToString());
				  }
				  if(dt.Rows[n]["vc_CalledNumber"]!=null && dt.Rows[n]["vc_CalledNumber"].ToString()!="")
				  {
				     model.vc_CalledNumber= dt.Rows[n]["vc_CalledNumber"].ToString();
				  }
				  if(dt.Rows[n]["i_CalledType"]!=null && dt.Rows[n]["i_CalledType"].ToString()!="")
				  {
				      model.i_CalledType=int.Parse(dt.Rows[n]["i_CalledType"].ToString());
				  }
				  if(dt.Rows[n]["i_CalledSubType"]!=null && dt.Rows[n]["i_CalledSubType"].ToString()!="")
				  {
				      model.i_CalledSubType=int.Parse(dt.Rows[n]["i_CalledSubType"].ToString());
				  }
				  if(dt.Rows[n]["DestRouteID"]!=null && dt.Rows[n]["DestRouteID"].ToString()!="")
				  {
				      model.DestRouteID=int.Parse(dt.Rows[n]["DestRouteID"].ToString());
				  }
				  if(dt.Rows[n]["i_CalledChangeType"]!=null && dt.Rows[n]["i_CalledChangeType"].ToString()!="")
				  {
				      model.i_CalledChangeType=int.Parse(dt.Rows[n]["i_CalledChangeType"].ToString());
				  }
				  if(dt.Rows[n]["i_CalledChangePosition"]!=null && dt.Rows[n]["i_CalledChangePosition"].ToString()!="")
				  {
				      model.i_CalledChangePosition=int.Parse(dt.Rows[n]["i_CalledChangePosition"].ToString());
				  }
				  if(dt.Rows[n]["i_CalledChangeLength"]!=null && dt.Rows[n]["i_CalledChangeLength"].ToString()!="")
				  {
				      model.i_CalledChangeLength=int.Parse(dt.Rows[n]["i_CalledChangeLength"].ToString());
				  }
				  if(dt.Rows[n]["vc_CalledChangeTarget"]!=null && dt.Rows[n]["vc_CalledChangeTarget"].ToString()!="")
				  {
				     model.vc_CalledChangeTarget= dt.Rows[n]["vc_CalledChangeTarget"].ToString();
				  }
				  if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
				  {
				     model.vc_Memo= dt.Rows[n]["vc_Memo"].ToString();
				  }
				  if(dt.Rows[n]["i_SIPID"]!=null && dt.Rows[n]["i_SIPID"].ToString()!="")
				  {
				      model.i_SIPID=int.Parse(dt.Rows[n]["i_SIPID"].ToString());
				  }
				  if(dt.Rows[n]["i_PRIID"]!=null && dt.Rows[n]["i_PRIID"].ToString()!="")
				  {
				      model.i_PRIID=int.Parse(dt.Rows[n]["i_PRIID"].ToString());
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