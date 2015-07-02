using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 m_FAP
	/// </summary>	
	public partial class m_FAP
	{ 
		public m_FAP()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_FAP  ");
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
		public int Add(DB_Talk.Model.m_FAP model,bool IsReturnID)   
		{
		    int Result=0;
		    StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();	
			if(model.FapID!=null)
		    {
			   strSql1.Append("FapID,");	
			   strSql2.Append("'"+ model.FapID +"',");	
			} 
            if(model.BoxID!=null)
		    {
			   strSql1.Append("BoxID,");	
			   strSql2.Append("'"+ model.BoxID +"',");	
			} 
            if(model.i_RanType!=null)
		    {
			   strSql1.Append("i_RanType,");	
			   strSql2.Append("'"+ model.i_RanType +"',");	
			} 
            if(model.vc_Name!=null)
		    {
			   strSql1.Append("vc_Name,");	
			   strSql2.Append("'"+ model.vc_Name +"',");	
			} 
            if(model.vc_Identify!=null)
		    {
			   strSql1.Append("vc_Identify,");	
			   strSql2.Append("'"+ model.vc_Identify +"',");	
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
            if(model.vc_TempAddress!=null)
		    {
			   strSql1.Append("vc_TempAddress,");	
			   strSql2.Append("'"+ model.vc_TempAddress +"',");	
			} 
            if(model.i_fapSctpPort!=null)
		    {
			   strSql1.Append("i_fapSctpPort,");	
			   strSql2.Append("'"+ model.i_fapSctpPort +"',");	
			} 
            if(model.i_SwLinkID!=null)
		    {
			   strSql1.Append("i_SwLinkID,");	
			   strSql2.Append("'"+ model.i_SwLinkID +"',");	
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

       


            strSql.Append("insert into m_FAP(");	
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
		public bool Update(DB_Talk.Model.m_FAP model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_FAP set ");
			if(model.FapID!=null)
		    {
			   strSql.Append("FapID='"+ model.FapID +"',");	
			} 
			if(model.BoxID!=null)
		    {
			   strSql.Append("BoxID='"+ model.BoxID +"',");	
			} 
			if(model.i_RanType!=null)
		    {
			   strSql.Append("i_RanType='"+ model.i_RanType +"',");	
			} 
			if(model.vc_Name!=null)
		    {
			   strSql.Append("vc_Name='"+ model.vc_Name +"',");	
			} 
			if(model.vc_Identify!=null)
		    {
			   strSql.Append("vc_Identify='"+ model.vc_Identify +"',");	
			} 
			if(model.i_ConfState!=null)
		    {
			   strSql.Append("i_ConfState='"+ model.i_ConfState +"',");	
			} 
			if(model.i_OperateState!=null)
		    {
			   strSql.Append("i_OperateState='"+ model.i_OperateState +"',");	
			} 
			if(model.vc_TempAddress!=null)
		    {
			   strSql.Append("vc_TempAddress='"+ model.vc_TempAddress +"',");	
			} 
			if(model.i_fapSctpPort!=null)
		    {
			   strSql.Append("i_fapSctpPort='"+ model.i_fapSctpPort +"',");	
			} 
			if(model.i_SwLinkID!=null)
		    {
			   strSql.Append("i_SwLinkID='"+ model.i_SwLinkID +"',");	
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
			    strSql.Append("delete from m_FAP ");	
			else
				strSql.Append("update m_FAP  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_FAP ");	
			else
				strSql.Append("update m_FAP  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_FAP ");	
			else
				strSql.Append("update m_FAP  set i_Flag=1 ");	 
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
		public DB_Talk.Model.m_FAP GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
            strSql.Append("  ID, FapID, BoxID, i_RanType, vc_Name, vc_Identify, i_ConfState, i_OperateState, vc_TempAddress, i_fapSctpPort, i_SwLinkID, vc_Memo, i_Flag  ");			
			strSql.Append("  from m_FAP ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_Talk.Model.m_FAP model=new DB_Talk.Model.m_FAP();
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
		public DB_Talk.Model.m_FAP GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
            strSql.Append("  ID, FapID, BoxID, i_RanType, vc_Name, vc_Identify, i_ConfState, i_OperateState, vc_TempAddress, i_fapSctpPort, i_SwLinkID, vc_Memo, i_Flag  ");			
			strSql.Append("  from m_FAP ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.m_FAP model=new DB_Talk.Model.m_FAP();
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
            strSql.Append("  ID, FapID, BoxID, i_RanType, vc_Name, vc_Identify, i_ConfState, i_OperateState, vc_TempAddress, i_fapSctpPort, i_SwLinkID, vc_Memo, i_Flag  ");			
			strSql.Append(" FROM m_FAP ");
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
		public List<DB_Talk.Model.m_FAP> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.m_FAP> modelList = new List<DB_Talk.Model.m_FAP>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.m_FAP model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.m_FAP();	
                  if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
				  {
				      model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				  }
				  if(dt.Rows[n]["FapID"]!=null && dt.Rows[n]["FapID"].ToString()!="")
				  {
				      model.FapID=int.Parse(dt.Rows[n]["FapID"].ToString());
				  }
				  if(dt.Rows[n]["BoxID"]!=null && dt.Rows[n]["BoxID"].ToString()!="")
				  {
				      model.BoxID=int.Parse(dt.Rows[n]["BoxID"].ToString());
				  }
				  if(dt.Rows[n]["i_RanType"]!=null && dt.Rows[n]["i_RanType"].ToString()!="")
				  {
				      model.i_RanType=int.Parse(dt.Rows[n]["i_RanType"].ToString());
				  }
				  if(dt.Rows[n]["vc_Name"]!=null && dt.Rows[n]["vc_Name"].ToString()!="")
				  {
				     model.vc_Name= dt.Rows[n]["vc_Name"].ToString();
				  }
				  if(dt.Rows[n]["vc_Identify"]!=null && dt.Rows[n]["vc_Identify"].ToString()!="")
				  {
				     model.vc_Identify= dt.Rows[n]["vc_Identify"].ToString();
				  }
				  if(dt.Rows[n]["i_ConfState"]!=null && dt.Rows[n]["i_ConfState"].ToString()!="")
				  {
				      model.i_ConfState=int.Parse(dt.Rows[n]["i_ConfState"].ToString());
				  }
				  if(dt.Rows[n]["i_OperateState"]!=null && dt.Rows[n]["i_OperateState"].ToString()!="")
				  {
				      model.i_OperateState=int.Parse(dt.Rows[n]["i_OperateState"].ToString());
				  }
				  if(dt.Rows[n]["vc_TempAddress"]!=null && dt.Rows[n]["vc_TempAddress"].ToString()!="")
				  {
				     model.vc_TempAddress= dt.Rows[n]["vc_TempAddress"].ToString();
				  }
				  if(dt.Rows[n]["i_fapSctpPort"]!=null && dt.Rows[n]["i_fapSctpPort"].ToString()!="")
				  {
				      model.i_fapSctpPort=int.Parse(dt.Rows[n]["i_fapSctpPort"].ToString());
				  }
				  if(dt.Rows[n]["i_SwLinkID"]!=null && dt.Rows[n]["i_SwLinkID"].ToString()!="")
				  {
				      model.i_SwLinkID=int.Parse(dt.Rows[n]["i_SwLinkID"].ToString());
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