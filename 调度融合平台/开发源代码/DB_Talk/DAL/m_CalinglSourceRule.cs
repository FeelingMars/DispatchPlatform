using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 m_CalinglSourceRule
	/// </summary>	
	public partial class m_CalinglSourceRule
	{ 
		public m_CalinglSourceRule()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_CalinglSourceRule  ");
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
		public int Add(DB_Talk.Model.m_CalinglSourceRule model,bool IsReturnID)   
		{
		    int Result=0;
		    StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
            //if (model.ID != null)
            //{
            //    strSql1.Append("ID,");
            //    strSql2.Append("'" + model.ID + "',");
            //} 
			if(model.BoxID>0)
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
            if(model.CallingOrigID!=null)
		    {
			   strSql1.Append("CallingOrigID,");	
			   strSql2.Append("'"+ model.CallingOrigID +"',");	
			} 
            if(model.i_ServerType!=null)
		    {
			   strSql1.Append("i_ServerType,");	
			   strSql2.Append("'"+ model.i_ServerType +"',");	
			} 
            if(model.i_MinReLength!=null)
		    {
			   strSql1.Append("i_MinReLength,");	
			   strSql2.Append("'"+ model.i_MinReLength +"',");	
			} 
            if(model.OriRouteID!=null)
		    {
			   strSql1.Append("OriRouteID,");	
			   strSql2.Append("'"+ model.OriRouteID +"',");	
			} 
            if(model.CalledRuleID!=null)
		    {
			   strSql1.Append("CalledRuleID,");	
			   strSql2.Append("'"+ model.CalledRuleID +"',");	
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
            strSql.Append("insert into m_CalinglSourceRule(");	
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
		public bool Update(DB_Talk.Model.m_CalinglSourceRule model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_CalinglSourceRule set ");
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
			if(model.CallingOrigID!=null)
		    {
			   strSql.Append("CallingOrigID='"+ model.CallingOrigID +"',");	
			} 
			if(model.i_ServerType!=null)
		    {
			   strSql.Append("i_ServerType='"+ model.i_ServerType +"',");	
			} 
			if(model.i_MinReLength!=null)
		    {
			   strSql.Append("i_MinReLength='"+ model.i_MinReLength +"',");	
			} 
			if(model.OriRouteID!=null)
		    {
			   strSql.Append("OriRouteID='"+ model.OriRouteID +"',");	
			} 
			if(model.CalledRuleID!=null)
		    {
			   strSql.Append("CalledRuleID='"+ model.CalledRuleID +"',");	
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
			    strSql.Append("delete from m_CalinglSourceRule ");	
			else
				strSql.Append("update m_CalinglSourceRule  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_CalinglSourceRule ");	
			else
				strSql.Append("update m_CalinglSourceRule  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_CalinglSourceRule ");	
			else
				strSql.Append("update m_CalinglSourceRule  set i_Flag=1 ");	 
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
		public DB_Talk.Model.m_CalinglSourceRule GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, vc_Code, vc_Name, CallingOrigID, i_ServerType, i_MinReLength, OriRouteID, CalledRuleID, vc_Memo, i_Flag  ");			
			strSql.Append("  from m_CalinglSourceRule ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_Talk.Model.m_CalinglSourceRule model=new DB_Talk.Model.m_CalinglSourceRule();
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
		public DB_Talk.Model.m_CalinglSourceRule GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, vc_Code, vc_Name, CallingOrigID, i_ServerType, i_MinReLength, OriRouteID, CalledRuleID, vc_Memo, i_Flag  ");			
			strSql.Append("  from m_CalinglSourceRule ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.m_CalinglSourceRule model=new DB_Talk.Model.m_CalinglSourceRule();
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
		    strSql.Append("  ID, BoxID, vc_Code, vc_Name, CallingOrigID, i_ServerType, i_MinReLength, OriRouteID, CalledRuleID, vc_Memo, i_Flag  ");			
			strSql.Append(" FROM m_CalinglSourceRule ");
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
		public List<DB_Talk.Model.m_CalinglSourceRule> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.m_CalinglSourceRule> modelList = new List<DB_Talk.Model.m_CalinglSourceRule>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.m_CalinglSourceRule model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.m_CalinglSourceRule();	
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
				  if(dt.Rows[n]["CallingOrigID"]!=null && dt.Rows[n]["CallingOrigID"].ToString()!="")
				  {
				      model.CallingOrigID=int.Parse(dt.Rows[n]["CallingOrigID"].ToString());
				  }
				  if(dt.Rows[n]["i_ServerType"]!=null && dt.Rows[n]["i_ServerType"].ToString()!="")
				  {
				      model.i_ServerType=int.Parse(dt.Rows[n]["i_ServerType"].ToString());
				  }
				  if(dt.Rows[n]["i_MinReLength"]!=null && dt.Rows[n]["i_MinReLength"].ToString()!="")
				  {
				      model.i_MinReLength=int.Parse(dt.Rows[n]["i_MinReLength"].ToString());
				  }
				  if(dt.Rows[n]["OriRouteID"]!=null && dt.Rows[n]["OriRouteID"].ToString()!="")
				  {
				      model.OriRouteID=int.Parse(dt.Rows[n]["OriRouteID"].ToString());
				  }
				  if(dt.Rows[n]["CalledRuleID"]!=null && dt.Rows[n]["CalledRuleID"].ToString()!="")
				  {
				      model.CalledRuleID=int.Parse(dt.Rows[n]["CalledRuleID"].ToString());
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