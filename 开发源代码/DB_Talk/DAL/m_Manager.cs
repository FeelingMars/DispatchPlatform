using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 m_Manager
	/// </summary>	
	public partial class m_Manager
	{ 
		public m_Manager()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_Manager  ");
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
		public int Add(DB_Talk.Model.m_Manager model,bool IsReturnID)   
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
            if(model.vc_UserName!=null)
		    {
			   strSql1.Append("vc_UserName,");	
			   strSql2.Append("'"+ model.vc_UserName +"',");	
			} 
            if(model.vc_Password!=null)
		    {
			   strSql1.Append("vc_Password,");	
			   strSql2.Append("'"+ model.vc_Password +"',");	
			} 
            if(model.LeftDispatchNumber!=null)
		    {
			   strSql1.Append("LeftDispatchNumber,");	
			   strSql2.Append("'"+ model.LeftDispatchNumber +"',");	
			} 
            if(model.RightDispatchNumber!=null)
		    {
			   strSql1.Append("RightDispatchNumber,");	
			   strSql2.Append("'"+ model.RightDispatchNumber +"',");	
			} 
            if(model.LeftDispatchName!=null)
		    {
			   strSql1.Append("LeftDispatchName,");	
			   strSql2.Append("'"+ model.LeftDispatchName +"',");	
			} 
            if(model.RightDispatchName!=null)
		    {
			   strSql1.Append("RightDispatchName,");	
			   strSql2.Append("'"+ model.RightDispatchName +"',");	
			} 
            if(model.i_Net!=null)
		    {
			   strSql1.Append("i_Net,");	
			   strSql2.Append("'"+ model.i_Net +"',");	
			} 
            if(model.i_Operate!=null)
		    {
			   strSql1.Append("i_Operate,");	
			   strSql2.Append("'"+ model.i_Operate +"',");	
			} 
            if(model.i_Dispatch!=null)
		    {
			   strSql1.Append("i_Dispatch,");	
			   strSql2.Append("'"+ model.i_Dispatch +"',");	
			} 
            if(model.dt_CreateTime!=null)
		    {
			   strSql1.Append("dt_CreateTime,");	
			   strSql2.Append("'"+ model.dt_CreateTime +"',");	
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
            if(model.i_TellType!=null)
		    {
			   strSql1.Append("i_TellType,");	
			   strSql2.Append("'"+ model.i_TellType +"',");	
			} 
            if(model.i_IsDispatch!=null)
		    {
			   strSql1.Append("i_IsDispatch,");	
			   strSql2.Append("'"+ model.i_IsDispatch +"',");	
			} 
            if(model.vc_BoxID!=null)
		    {
			   strSql1.Append("vc_BoxID,");	
			   strSql2.Append("'"+ model.vc_BoxID +"',");	
			} 
            strSql.Append("insert into m_Manager(");	
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
		public bool Update(DB_Talk.Model.m_Manager model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_Manager set ");
			if(model.BoxID!=null)
		    {
			   strSql.Append("BoxID='"+ model.BoxID +"',");	
			} 
			if(model.vc_UserName!=null)
		    {
			   strSql.Append("vc_UserName='"+ model.vc_UserName +"',");	
			} 
			if(model.vc_Password!=null)
		    {
			   strSql.Append("vc_Password='"+ model.vc_Password +"',");	
			} 
			if(model.LeftDispatchNumber!=null)
		    {
			   strSql.Append("LeftDispatchNumber='"+ model.LeftDispatchNumber +"',");	
			} 
			if(model.RightDispatchNumber!=null)
		    {
			   strSql.Append("RightDispatchNumber='"+ model.RightDispatchNumber +"',");	
			} 
			if(model.LeftDispatchName!=null)
		    {
			   strSql.Append("LeftDispatchName='"+ model.LeftDispatchName +"',");	
			} 
			if(model.RightDispatchName!=null)
		    {
			   strSql.Append("RightDispatchName='"+ model.RightDispatchName +"',");	
			} 
			if(model.i_Net!=null)
		    {
			   strSql.Append("i_Net='"+ model.i_Net +"',");	
			} 
			if(model.i_Operate!=null)
		    {
			   strSql.Append("i_Operate='"+ model.i_Operate +"',");	
			} 
			if(model.i_Dispatch!=null)
		    {
			   strSql.Append("i_Dispatch='"+ model.i_Dispatch +"',");	
			} 
			if(model.dt_CreateTime!=null)
		    {
			   strSql.Append("dt_CreateTime='"+ model.dt_CreateTime +"',");	
			} 
			if(model.vc_Memo!=null)
		    {
			   strSql.Append("vc_Memo='"+ model.vc_Memo +"',");	
			} 
			if(model.i_Flag!=null)
		    {
			   strSql.Append("i_Flag='"+ model.i_Flag +"',");	
			} 
			if(model.i_TellType!=null)
		    {
			   strSql.Append("i_TellType='"+ model.i_TellType +"',");	
			} 
			if(model.i_IsDispatch!=null)
		    {
			   strSql.Append("i_IsDispatch='"+ model.i_IsDispatch +"',");	
			} 
			if(model.vc_BoxID!=null)
		    {
			   strSql.Append("vc_BoxID='"+ model.vc_BoxID +"',");	
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
			    strSql.Append("delete from m_Manager ");	
			else
				strSql.Append("update m_Manager  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_Manager ");	
			else
				strSql.Append("update m_Manager  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_Manager ");	
			else
				strSql.Append("update m_Manager  set i_Flag=1 ");	 
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
		public DB_Talk.Model.m_Manager GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, vc_UserName, vc_Password, LeftDispatchNumber, RightDispatchNumber, LeftDispatchName, RightDispatchName, i_Net, i_Operate, i_Dispatch, dt_CreateTime, vc_Memo, i_Flag, i_TellType, i_IsDispatch, vc_BoxID  ");			
			strSql.Append("  from m_Manager ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_Talk.Model.m_Manager model=new DB_Talk.Model.m_Manager();
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
		public DB_Talk.Model.m_Manager GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, vc_UserName, vc_Password, LeftDispatchNumber, RightDispatchNumber, LeftDispatchName, RightDispatchName, i_Net, i_Operate, i_Dispatch, dt_CreateTime, vc_Memo, i_Flag, i_TellType, i_IsDispatch, vc_BoxID  ");			
			strSql.Append("  from m_Manager ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.m_Manager model=new DB_Talk.Model.m_Manager();
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
		    strSql.Append("  ID, BoxID, vc_UserName, vc_Password, LeftDispatchNumber, RightDispatchNumber, LeftDispatchName, RightDispatchName, i_Net, i_Operate, i_Dispatch, dt_CreateTime, vc_Memo, i_Flag, i_TellType, i_IsDispatch, vc_BoxID  ");			
			strSql.Append(" FROM m_Manager ");
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
		public List<DB_Talk.Model.m_Manager> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.m_Manager> modelList = new List<DB_Talk.Model.m_Manager>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.m_Manager model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.m_Manager();	
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
				   modelList.Add(model);
				
				}
			}
			return modelList;
		}
		
        #endregion
	}
}