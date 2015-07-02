using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 m_PRIInterface
	/// </summary>	
	public partial class m_PRIInterface
	{ 
		public m_PRIInterface()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_PRIInterface  ");
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
		public int Add(DB_Talk.Model.m_PRIInterface model,bool IsReturnID)   
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
            if(model.PRIID!=null)
		    {
			   strSql1.Append("PRIID,");	
			   strSql2.Append("'"+ model.PRIID +"',");	
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
            if(model.RouteID!=null)
		    {
			   strSql1.Append("RouteID,");	
			   strSql2.Append("'"+ model.RouteID +"',");	
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
            if(model.i_State!=null)
		    {
			   strSql1.Append("i_State,");	
			   strSql2.Append("'"+ model.i_State +"',");	
			} 
            if(model.i_Operate!=null)
		    {
			   strSql1.Append("i_Operate,");	
			   strSql2.Append("'"+ model.i_Operate +"',");	
			} 
            if(model.i_LinkID!=null)
		    {
			   strSql1.Append("i_LinkID,");	
			   strSql2.Append("'"+ model.i_LinkID +"',");	
			} 
            if(model.i_LinkCount!=null)
		    {
			   strSql1.Append("i_LinkCount,");	
			   strSql2.Append("'"+ model.i_LinkCount +"',");	
			} 
            if(model.i_LinkType!=null)
		    {
			   strSql1.Append("i_LinkType,");	
			   strSql2.Append("'"+ model.i_LinkType +"',");	
			} 
            if(model.i_SwitchType!=null)
		    {
			   strSql1.Append("i_SwitchType,");	
			   strSql2.Append("'"+ model.i_SwitchType +"',");	
			} 
            if(model.vc_Memo!=null)
		    {
			   strSql1.Append("vc_Memo,");	
			   strSql2.Append("'"+ model.vc_Memo +"',");	
			} 
            if(model.i_E1Port!=null)
		    {
			   strSql1.Append("i_E1Port,");	
			   strSql2.Append("'"+ model.i_E1Port +"',");	
			} 
            if(model.i_UNIType!=null)
		    {
			   strSql1.Append("i_UNIType,");	
			   strSql2.Append("'"+ model.i_UNIType +"',");	
			} 
            if(model.i_Flag!=null)
		    {
			   strSql1.Append("i_Flag,");	
			   strSql2.Append("'"+ model.i_Flag +"',");	
			} 
            strSql.Append("insert into m_PRIInterface(");	
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
		public bool Update(DB_Talk.Model.m_PRIInterface model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_PRIInterface set ");
			if(model.BoxID!=null)
		    {
			   strSql.Append("BoxID='"+ model.BoxID +"',");	
			} 
			if(model.PRIID!=null)
		    {
			   strSql.Append("PRIID='"+ model.PRIID +"',");	
			} 
			if(model.vc_OutNumber!=null)
		    {
			   strSql.Append("vc_OutNumber='"+ model.vc_OutNumber +"',");	
			} 
			if(model.vc_OutNumberLocal!=null)
		    {
			   strSql.Append("vc_OutNumberLocal='"+ model.vc_OutNumberLocal +"',");	
			} 
			if(model.vc_Code!=null)
		    {
			   strSql.Append("vc_Code='"+ model.vc_Code +"',");	
			} 
			if(model.vc_Name!=null)
		    {
			   strSql.Append("vc_Name='"+ model.vc_Name +"',");	
			} 
			if(model.RouteID!=null)
		    {
			   strSql.Append("RouteID='"+ model.RouteID +"',");	
			} 
			if(model.i_Type!=null)
		    {
			   strSql.Append("i_Type='"+ model.i_Type +"',");	
			} 
			if(model.i_Level!=null)
		    {
			   strSql.Append("i_Level='"+ model.i_Level +"',");	
			} 
			if(model.i_State!=null)
		    {
			   strSql.Append("i_State='"+ model.i_State +"',");	
			} 
			if(model.i_Operate!=null)
		    {
			   strSql.Append("i_Operate='"+ model.i_Operate +"',");	
			} 
			if(model.i_LinkID!=null)
		    {
			   strSql.Append("i_LinkID='"+ model.i_LinkID +"',");	
			} 
			if(model.i_LinkCount!=null)
		    {
			   strSql.Append("i_LinkCount='"+ model.i_LinkCount +"',");	
			} 
			if(model.i_LinkType!=null)
		    {
			   strSql.Append("i_LinkType='"+ model.i_LinkType +"',");	
			} 
			if(model.i_SwitchType!=null)
		    {
			   strSql.Append("i_SwitchType='"+ model.i_SwitchType +"',");	
			} 
			if(model.vc_Memo!=null)
		    {
			   strSql.Append("vc_Memo='"+ model.vc_Memo +"',");	
			} 
			if(model.i_E1Port!=null)
		    {
			   strSql.Append("i_E1Port='"+ model.i_E1Port +"',");	
			} 
			if(model.i_UNIType!=null)
		    {
			   strSql.Append("i_UNIType='"+ model.i_UNIType +"',");	
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
			    strSql.Append("delete from m_PRIInterface ");	
			else
				strSql.Append("update m_PRIInterface  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_PRIInterface ");	
			else
				strSql.Append("update m_PRIInterface  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_PRIInterface ");	
			else
				strSql.Append("update m_PRIInterface  set i_Flag=1 ");	 
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
		public DB_Talk.Model.m_PRIInterface GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, PRIID, vc_OutNumber, vc_OutNumberLocal, vc_Code, vc_Name, RouteID, i_Type, i_Level, i_State, i_Operate, i_LinkID, i_LinkCount, i_LinkType, i_SwitchType, vc_Memo, i_E1Port, i_UNIType, i_Flag  ");			
			strSql.Append("  from m_PRIInterface ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_Talk.Model.m_PRIInterface model=new DB_Talk.Model.m_PRIInterface();
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
		public DB_Talk.Model.m_PRIInterface GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, PRIID, vc_OutNumber, vc_OutNumberLocal, vc_Code, vc_Name, RouteID, i_Type, i_Level, i_State, i_Operate, i_LinkID, i_LinkCount, i_LinkType, i_SwitchType, vc_Memo, i_E1Port, i_UNIType, i_Flag  ");			
			strSql.Append("  from m_PRIInterface ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.m_PRIInterface model=new DB_Talk.Model.m_PRIInterface();
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
		    strSql.Append("  ID, BoxID, PRIID, vc_OutNumber, vc_OutNumberLocal, vc_Code, vc_Name, RouteID, i_Type, i_Level, i_State, i_Operate, i_LinkID, i_LinkCount, i_LinkType, i_SwitchType, vc_Memo, i_E1Port, i_UNIType, i_Flag  ");			
			strSql.Append(" FROM m_PRIInterface ");
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
		public List<DB_Talk.Model.m_PRIInterface> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.m_PRIInterface> modelList = new List<DB_Talk.Model.m_PRIInterface>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.m_PRIInterface model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.m_PRIInterface();	
                  if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
				  {
				      model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				  }
				  if(dt.Rows[n]["BoxID"]!=null && dt.Rows[n]["BoxID"].ToString()!="")
				  {
				      model.BoxID=int.Parse(dt.Rows[n]["BoxID"].ToString());
				  }
				  if(dt.Rows[n]["PRIID"]!=null && dt.Rows[n]["PRIID"].ToString()!="")
				  {
				      model.PRIID=int.Parse(dt.Rows[n]["PRIID"].ToString());
				  }
				  if(dt.Rows[n]["vc_OutNumber"]!=null && dt.Rows[n]["vc_OutNumber"].ToString()!="")
				  {
				     model.vc_OutNumber= dt.Rows[n]["vc_OutNumber"].ToString();
				  }
				  if(dt.Rows[n]["vc_OutNumberLocal"]!=null && dt.Rows[n]["vc_OutNumberLocal"].ToString()!="")
				  {
				     model.vc_OutNumberLocal= dt.Rows[n]["vc_OutNumberLocal"].ToString();
				  }
				  if(dt.Rows[n]["vc_Code"]!=null && dt.Rows[n]["vc_Code"].ToString()!="")
				  {
				     model.vc_Code= dt.Rows[n]["vc_Code"].ToString();
				  }
				  if(dt.Rows[n]["vc_Name"]!=null && dt.Rows[n]["vc_Name"].ToString()!="")
				  {
				     model.vc_Name= dt.Rows[n]["vc_Name"].ToString();
				  }
				  if(dt.Rows[n]["RouteID"]!=null && dt.Rows[n]["RouteID"].ToString()!="")
				  {
				      model.RouteID=int.Parse(dt.Rows[n]["RouteID"].ToString());
				  }
				  if(dt.Rows[n]["i_Type"]!=null && dt.Rows[n]["i_Type"].ToString()!="")
				  {
				      model.i_Type=int.Parse(dt.Rows[n]["i_Type"].ToString());
				  }
				  if(dt.Rows[n]["i_Level"]!=null && dt.Rows[n]["i_Level"].ToString()!="")
				  {
				      model.i_Level=int.Parse(dt.Rows[n]["i_Level"].ToString());
				  }
				  if(dt.Rows[n]["i_State"]!=null && dt.Rows[n]["i_State"].ToString()!="")
				  {
				      model.i_State=int.Parse(dt.Rows[n]["i_State"].ToString());
				  }
				  if(dt.Rows[n]["i_Operate"]!=null && dt.Rows[n]["i_Operate"].ToString()!="")
				  {
				      model.i_Operate=int.Parse(dt.Rows[n]["i_Operate"].ToString());
				  }
				  if(dt.Rows[n]["i_LinkID"]!=null && dt.Rows[n]["i_LinkID"].ToString()!="")
				  {
				      model.i_LinkID=int.Parse(dt.Rows[n]["i_LinkID"].ToString());
				  }
				  if(dt.Rows[n]["i_LinkCount"]!=null && dt.Rows[n]["i_LinkCount"].ToString()!="")
				  {
				      model.i_LinkCount=int.Parse(dt.Rows[n]["i_LinkCount"].ToString());
				  }
				  if(dt.Rows[n]["i_LinkType"]!=null && dt.Rows[n]["i_LinkType"].ToString()!="")
				  {
				      model.i_LinkType=int.Parse(dt.Rows[n]["i_LinkType"].ToString());
				  }
				  if(dt.Rows[n]["i_SwitchType"]!=null && dt.Rows[n]["i_SwitchType"].ToString()!="")
				  {
				      model.i_SwitchType=int.Parse(dt.Rows[n]["i_SwitchType"].ToString());
				  }
				  if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
				  {
				     model.vc_Memo= dt.Rows[n]["vc_Memo"].ToString();
				  }
				  if(dt.Rows[n]["i_E1Port"]!=null && dt.Rows[n]["i_E1Port"].ToString()!="")
				  {
				      model.i_E1Port=int.Parse(dt.Rows[n]["i_E1Port"].ToString());
				  }
				  if(dt.Rows[n]["i_UNIType"]!=null && dt.Rows[n]["i_UNIType"].ToString()!="")
				  {
				      model.i_UNIType=int.Parse(dt.Rows[n]["i_UNIType"].ToString());
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