using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 v_GroupMembers
	/// </summary>	
	public partial class v_GroupMembers
	{ 
		public v_GroupMembers()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from v_GroupMembers  ");
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
		public DB_Talk.Model.v_GroupMembers GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, GroupID, MemberID, i_Flag, i_Number, vc_Name, LevelID, NumberTypeID, i_TellType, DepartmentID, vc_MAC, vc_Memo, GroupName, GroupTypeID  ");			
			strSql.Append("  from v_GroupMembers ");
			strSql.Append("  where ID='"+ID+"'");   	  
			DB_Talk.Model.v_GroupMembers model=new DB_Talk.Model.v_GroupMembers();
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
		public DB_Talk.Model.v_GroupMembers GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, GroupID, MemberID, i_Flag, i_Number, vc_Name, LevelID, NumberTypeID, i_TellType, DepartmentID, vc_MAC, vc_Memo, GroupName, GroupTypeID  ");			
			strSql.Append("  from v_GroupMembers ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.v_GroupMembers model=new DB_Talk.Model.v_GroupMembers();
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
		    strSql.Append("  ID, BoxID, GroupID, MemberID, i_Flag, i_Number, vc_Name, LevelID, NumberTypeID, i_TellType, DepartmentID, vc_MAC, vc_Memo, GroupName, GroupTypeID  ");			
			strSql.Append(" FROM v_GroupMembers ");
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
		public List<DB_Talk.Model.v_GroupMembers> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.v_GroupMembers> modelList = new List<DB_Talk.Model.v_GroupMembers>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.v_GroupMembers model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.v_GroupMembers();	
                  if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
				  {
				      model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				  }
				  if(dt.Rows[n]["BoxID"]!=null && dt.Rows[n]["BoxID"].ToString()!="")
				  {
				      model.BoxID=int.Parse(dt.Rows[n]["BoxID"].ToString());
				  }
				  if(dt.Rows[n]["GroupID"]!=null && dt.Rows[n]["GroupID"].ToString()!="")
				  {
				      model.GroupID=int.Parse(dt.Rows[n]["GroupID"].ToString());
				  }
				  if(dt.Rows[n]["MemberID"]!=null && dt.Rows[n]["MemberID"].ToString()!="")
				  {
				      model.MemberID=int.Parse(dt.Rows[n]["MemberID"].ToString());
				  }
				  if(dt.Rows[n]["i_Flag"]!=null && dt.Rows[n]["i_Flag"].ToString()!="")
				  {
				      model.i_Flag=int.Parse(dt.Rows[n]["i_Flag"].ToString());
				  }
				  if(dt.Rows[n]["i_Number"]!=null && dt.Rows[n]["i_Number"].ToString()!="")
				  {
				      model.i_Number=int.Parse(dt.Rows[n]["i_Number"].ToString());
				  }
				  if(dt.Rows[n]["vc_Name"]!=null && dt.Rows[n]["vc_Name"].ToString()!="")
				  {
				     model.vc_Name= dt.Rows[n]["vc_Name"].ToString();
				  }
				  if(dt.Rows[n]["LevelID"]!=null && dt.Rows[n]["LevelID"].ToString()!="")
				  {
				      model.LevelID=int.Parse(dt.Rows[n]["LevelID"].ToString());
				  }
				  if(dt.Rows[n]["NumberTypeID"]!=null && dt.Rows[n]["NumberTypeID"].ToString()!="")
				  {
				      model.NumberTypeID=int.Parse(dt.Rows[n]["NumberTypeID"].ToString());
				  }
				  if(dt.Rows[n]["i_TellType"]!=null && dt.Rows[n]["i_TellType"].ToString()!="")
				  {
				      model.i_TellType=int.Parse(dt.Rows[n]["i_TellType"].ToString());
				  }
				  if(dt.Rows[n]["DepartmentID"]!=null && dt.Rows[n]["DepartmentID"].ToString()!="")
				  {
				      model.DepartmentID=int.Parse(dt.Rows[n]["DepartmentID"].ToString());
				  }
				  if(dt.Rows[n]["vc_MAC"]!=null && dt.Rows[n]["vc_MAC"].ToString()!="")
				  {
				     model.vc_MAC= dt.Rows[n]["vc_MAC"].ToString();
				  }
				  if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
				  {
				     model.vc_Memo= dt.Rows[n]["vc_Memo"].ToString();
				  }
				  if(dt.Rows[n]["GroupName"]!=null && dt.Rows[n]["GroupName"].ToString()!="")
				  {
				     model.GroupName= dt.Rows[n]["GroupName"].ToString();
				  }
				  if(dt.Rows[n]["GroupTypeID"]!=null && dt.Rows[n]["GroupTypeID"].ToString()!="")
				  {
				      model.GroupTypeID=int.Parse(dt.Rows[n]["GroupTypeID"].ToString());
				  }
				   modelList.Add(model);
				
				}
			}
			return modelList;
		}
		
        #endregion
	}
}