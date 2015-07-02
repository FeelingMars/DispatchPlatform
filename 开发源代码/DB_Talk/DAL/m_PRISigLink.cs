using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 m_PRISigLink
	/// </summary>	
	public partial class m_PRISigLink
	{ 
		public m_PRISigLink()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_PRISigLink  ");
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
		public int Add(DB_Talk.Model.m_PRISigLink model,bool IsReturnID)   
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
            if(model.i_MachineID!=null)
		    {
			   strSql1.Append("i_MachineID,");	
			   strSql2.Append("'"+ model.i_MachineID +"',");	
			} 
            if(model.i_SlotID!=null)
		    {
			   strSql1.Append("i_SlotID,");	
			   strSql2.Append("'"+ model.i_SlotID +"',");	
			} 
            if(model.i_E1Port!=null)
		    {
			   strSql1.Append("i_E1Port,");	
			   strSql2.Append("'"+ model.i_E1Port +"',");	
			} 
            if(model.i_ChannelNumber!=null)
		    {
			   strSql1.Append("i_ChannelNumber,");	
			   strSql2.Append("'"+ model.i_ChannelNumber +"',");	
			} 
            if(model.i_Type!=null)
		    {
			   strSql1.Append("i_Type,");	
			   strSql2.Append("'"+ model.i_Type +"',");	
			} 
            if(model.i_LinkID!=null)
		    {
			   strSql1.Append("i_LinkID,");	
			   strSql2.Append("'"+ model.i_LinkID +"',");	
			} 
            if(model.i_UNIType!=null)
		    {
			   strSql1.Append("i_UNIType,");	
			   strSql2.Append("'"+ model.i_UNIType +"',");	
			} 
            if(model.i_OppositeVoicePrompt!=null)
		    {
			   strSql1.Append("i_OppositeVoicePrompt,");	
			   strSql2.Append("'"+ model.i_OppositeVoicePrompt +"',");	
			} 
            if(model.i_SendVoicePrompt!=null)
		    {
			   strSql1.Append("i_SendVoicePrompt,");	
			   strSql2.Append("'"+ model.i_SendVoicePrompt +"',");	
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
            strSql.Append("insert into m_PRISigLink(");	
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
		public bool Update(DB_Talk.Model.m_PRISigLink model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_PRISigLink set ");
			if(model.BoxID!=null)
		    {
			   strSql.Append("BoxID='"+ model.BoxID +"',");	
			} 
			if(model.PRIID!=null)
		    {
			   strSql.Append("PRIID='"+ model.PRIID +"',");	
			} 
			if(model.i_MachineID!=null)
		    {
			   strSql.Append("i_MachineID='"+ model.i_MachineID +"',");	
			} 
			if(model.i_SlotID!=null)
		    {
			   strSql.Append("i_SlotID='"+ model.i_SlotID +"',");	
			} 
			if(model.i_E1Port!=null)
		    {
			   strSql.Append("i_E1Port='"+ model.i_E1Port +"',");	
			} 
			if(model.i_ChannelNumber!=null)
		    {
			   strSql.Append("i_ChannelNumber='"+ model.i_ChannelNumber +"',");	
			} 
			if(model.i_Type!=null)
		    {
			   strSql.Append("i_Type='"+ model.i_Type +"',");	
			} 
			if(model.i_LinkID!=null)
		    {
			   strSql.Append("i_LinkID='"+ model.i_LinkID +"',");	
			} 
			if(model.i_UNIType!=null)
		    {
			   strSql.Append("i_UNIType='"+ model.i_UNIType +"',");	
			} 
			if(model.i_OppositeVoicePrompt!=null)
		    {
			   strSql.Append("i_OppositeVoicePrompt='"+ model.i_OppositeVoicePrompt +"',");	
			} 
			if(model.i_SendVoicePrompt!=null)
		    {
			   strSql.Append("i_SendVoicePrompt='"+ model.i_SendVoicePrompt +"',");	
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
			    strSql.Append("delete from m_PRISigLink ");	
			else
				strSql.Append("update m_PRISigLink  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_PRISigLink ");	
			else
				strSql.Append("update m_PRISigLink  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_PRISigLink ");	
			else
				strSql.Append("update m_PRISigLink  set i_Flag=1 ");	 
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
		public DB_Talk.Model.m_PRISigLink GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, PRIID, i_MachineID, i_SlotID, i_E1Port, i_ChannelNumber, i_Type, i_LinkID, i_UNIType, i_OppositeVoicePrompt, i_SendVoicePrompt, vc_Memo, i_Flag  ");			
			strSql.Append("  from m_PRISigLink ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_Talk.Model.m_PRISigLink model=new DB_Talk.Model.m_PRISigLink();
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
		public DB_Talk.Model.m_PRISigLink GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, PRIID, i_MachineID, i_SlotID, i_E1Port, i_ChannelNumber, i_Type, i_LinkID, i_UNIType, i_OppositeVoicePrompt, i_SendVoicePrompt, vc_Memo, i_Flag  ");			
			strSql.Append("  from m_PRISigLink ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.m_PRISigLink model=new DB_Talk.Model.m_PRISigLink();
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
		    strSql.Append("  ID, BoxID, PRIID, i_MachineID, i_SlotID, i_E1Port, i_ChannelNumber, i_Type, i_LinkID, i_UNIType, i_OppositeVoicePrompt, i_SendVoicePrompt, vc_Memo, i_Flag  ");			
			strSql.Append(" FROM m_PRISigLink ");
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
		public List<DB_Talk.Model.m_PRISigLink> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.m_PRISigLink> modelList = new List<DB_Talk.Model.m_PRISigLink>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.m_PRISigLink model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.m_PRISigLink();	
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
				  if(dt.Rows[n]["i_MachineID"]!=null && dt.Rows[n]["i_MachineID"].ToString()!="")
				  {
				      model.i_MachineID=int.Parse(dt.Rows[n]["i_MachineID"].ToString());
				  }
				  if(dt.Rows[n]["i_SlotID"]!=null && dt.Rows[n]["i_SlotID"].ToString()!="")
				  {
				      model.i_SlotID=int.Parse(dt.Rows[n]["i_SlotID"].ToString());
				  }
				  if(dt.Rows[n]["i_E1Port"]!=null && dt.Rows[n]["i_E1Port"].ToString()!="")
				  {
				      model.i_E1Port=int.Parse(dt.Rows[n]["i_E1Port"].ToString());
				  }
				  if(dt.Rows[n]["i_ChannelNumber"]!=null && dt.Rows[n]["i_ChannelNumber"].ToString()!="")
				  {
				      model.i_ChannelNumber=int.Parse(dt.Rows[n]["i_ChannelNumber"].ToString());
				  }
				  if(dt.Rows[n]["i_Type"]!=null && dt.Rows[n]["i_Type"].ToString()!="")
				  {
				      model.i_Type=int.Parse(dt.Rows[n]["i_Type"].ToString());
				  }
				  if(dt.Rows[n]["i_LinkID"]!=null && dt.Rows[n]["i_LinkID"].ToString()!="")
				  {
				      model.i_LinkID=int.Parse(dt.Rows[n]["i_LinkID"].ToString());
				  }
				  if(dt.Rows[n]["i_UNIType"]!=null && dt.Rows[n]["i_UNIType"].ToString()!="")
				  {
				      model.i_UNIType=int.Parse(dt.Rows[n]["i_UNIType"].ToString());
				  }
				  if(dt.Rows[n]["i_OppositeVoicePrompt"]!=null && dt.Rows[n]["i_OppositeVoicePrompt"].ToString()!="")
				  {
				      model.i_OppositeVoicePrompt=int.Parse(dt.Rows[n]["i_OppositeVoicePrompt"].ToString());
				  }
				  if(dt.Rows[n]["i_SendVoicePrompt"]!=null && dt.Rows[n]["i_SendVoicePrompt"].ToString()!="")
				  {
				      model.i_SendVoicePrompt=int.Parse(dt.Rows[n]["i_SendVoicePrompt"].ToString());
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