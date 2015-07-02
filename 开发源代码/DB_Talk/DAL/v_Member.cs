using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 v_Member
	/// </summary>	
	public partial class v_Member
	{ 
		public v_Member()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from v_Member  ");
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
		public DB_Talk.Model.v_Member GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, i_Number, vc_Name, LevelID, NumberTypeID, i_TellType, i_IsDispatch, DepartmentID, vc_MAC, i_Flag, vc_Memo, i_supplementSerive, i_Authority, i_NuPassword, i_NuPasswordType, i_UnCForwardNu, i_NoAnswerForward, i_PowerOffForward, i_BusyForward, i_DirectNum, i_IsAssociateActive, i_AssociateNum1, i_AssociateNum2, vc_UmtsKi, vc_UmtsImsi, FapID, vc_IP, NumberPasswordType, NumberType, TellAuthority, TellType, IsDispatch, LevelName, deptName, BoxName, boxIP, vc_SN  ");			
			strSql.Append("  from v_Member ");
			strSql.Append("  where ID='"+ID+"'");   	  
			DB_Talk.Model.v_Member model=new DB_Talk.Model.v_Member();
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
		public DB_Talk.Model.v_Member GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
			strSql.Append("  ID, BoxID, i_Number, vc_Name, LevelID, NumberTypeID, i_TellType, i_IsDispatch, DepartmentID, vc_MAC, i_Flag, vc_Memo, i_supplementSerive, i_Authority, i_NuPassword, i_NuPasswordType, i_UnCForwardNu, i_NoAnswerForward, i_PowerOffForward, i_BusyForward, i_DirectNum, i_IsAssociateActive, i_AssociateNum1, i_AssociateNum2, vc_UmtsKi, vc_UmtsImsi, FapID, vc_IP, NumberPasswordType, NumberType, TellAuthority, TellType, IsDispatch, LevelName, deptName, BoxName, boxIP, vc_SN  ");			
			strSql.Append("  from v_Member ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.v_Member model=new DB_Talk.Model.v_Member();
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
		    strSql.Append("  ID, BoxID, i_Number, vc_Name, LevelID, NumberTypeID, i_TellType, i_IsDispatch, DepartmentID, vc_MAC, i_Flag, vc_Memo, i_supplementSerive, i_Authority, i_NuPassword, i_NuPasswordType, i_UnCForwardNu, i_NoAnswerForward, i_PowerOffForward, i_BusyForward, i_DirectNum, i_IsAssociateActive, i_AssociateNum1, i_AssociateNum2, vc_UmtsKi, vc_UmtsImsi, FapID, vc_IP, NumberPasswordType, NumberType, TellAuthority, TellType, IsDispatch, LevelName, deptName, BoxName, boxIP, vc_SN  ");			
			strSql.Append(" FROM v_Member ");
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
		public List<DB_Talk.Model.v_Member> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.v_Member> modelList = new List<DB_Talk.Model.v_Member>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.v_Member model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.v_Member();	
                  if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
				  {
				      model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
				  }
				  if(dt.Rows[n]["BoxID"]!=null && dt.Rows[n]["BoxID"].ToString()!="")
				  {
				      model.BoxID=int.Parse(dt.Rows[n]["BoxID"].ToString());
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
				  if(dt.Rows[n]["i_IsDispatch"]!=null && dt.Rows[n]["i_IsDispatch"].ToString()!="")
				  {
				      model.i_IsDispatch=int.Parse(dt.Rows[n]["i_IsDispatch"].ToString());
				  }
				  if(dt.Rows[n]["DepartmentID"]!=null && dt.Rows[n]["DepartmentID"].ToString()!="")
				  {
				      model.DepartmentID=int.Parse(dt.Rows[n]["DepartmentID"].ToString());
				  }
				  if(dt.Rows[n]["vc_MAC"]!=null && dt.Rows[n]["vc_MAC"].ToString()!="")
				  {
				     model.vc_MAC= dt.Rows[n]["vc_MAC"].ToString();
				  }
				  if(dt.Rows[n]["i_Flag"]!=null && dt.Rows[n]["i_Flag"].ToString()!="")
				  {
				      model.i_Flag=int.Parse(dt.Rows[n]["i_Flag"].ToString());
				  }
				  if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
				  {
				     model.vc_Memo= dt.Rows[n]["vc_Memo"].ToString();
				  }
				  if(dt.Rows[n]["i_supplementSerive"]!=null && dt.Rows[n]["i_supplementSerive"].ToString()!="")
				  {
				      model.i_supplementSerive=long.Parse(dt.Rows[n]["i_supplementSerive"].ToString());
				  }
				  if(dt.Rows[n]["i_Authority"]!=null && dt.Rows[n]["i_Authority"].ToString()!="")
				  {
				      model.i_Authority=int.Parse(dt.Rows[n]["i_Authority"].ToString());
				  }
				  if(dt.Rows[n]["i_NuPassword"]!=null && dt.Rows[n]["i_NuPassword"].ToString()!="")
				  {
				      model.i_NuPassword=int.Parse(dt.Rows[n]["i_NuPassword"].ToString());
				  }
				  if(dt.Rows[n]["i_NuPasswordType"]!=null && dt.Rows[n]["i_NuPasswordType"].ToString()!="")
				  {
				      model.i_NuPasswordType=int.Parse(dt.Rows[n]["i_NuPasswordType"].ToString());
				  }
				  if(dt.Rows[n]["i_UnCForwardNu"]!=null && dt.Rows[n]["i_UnCForwardNu"].ToString()!="")
				  {
				      model.i_UnCForwardNu=int.Parse(dt.Rows[n]["i_UnCForwardNu"].ToString());
				  }
				  if(dt.Rows[n]["i_NoAnswerForward"]!=null && dt.Rows[n]["i_NoAnswerForward"].ToString()!="")
				  {
				      model.i_NoAnswerForward=int.Parse(dt.Rows[n]["i_NoAnswerForward"].ToString());
				  }
				  if(dt.Rows[n]["i_PowerOffForward"]!=null && dt.Rows[n]["i_PowerOffForward"].ToString()!="")
				  {
				      model.i_PowerOffForward=int.Parse(dt.Rows[n]["i_PowerOffForward"].ToString());
				  }
				  if(dt.Rows[n]["i_BusyForward"]!=null && dt.Rows[n]["i_BusyForward"].ToString()!="")
				  {
				      model.i_BusyForward=int.Parse(dt.Rows[n]["i_BusyForward"].ToString());
				  }
				  if(dt.Rows[n]["i_DirectNum"]!=null && dt.Rows[n]["i_DirectNum"].ToString()!="")
				  {
				      model.i_DirectNum=int.Parse(dt.Rows[n]["i_DirectNum"].ToString());
				  }
				  if(dt.Rows[n]["i_IsAssociateActive"]!=null && dt.Rows[n]["i_IsAssociateActive"].ToString()!="")
				  {
				      model.i_IsAssociateActive=int.Parse(dt.Rows[n]["i_IsAssociateActive"].ToString());
				  }
				  if(dt.Rows[n]["i_AssociateNum1"]!=null && dt.Rows[n]["i_AssociateNum1"].ToString()!="")
				  {
				      model.i_AssociateNum1=int.Parse(dt.Rows[n]["i_AssociateNum1"].ToString());
				  }
				  if(dt.Rows[n]["i_AssociateNum2"]!=null && dt.Rows[n]["i_AssociateNum2"].ToString()!="")
				  {
				      model.i_AssociateNum2=int.Parse(dt.Rows[n]["i_AssociateNum2"].ToString());
				  }
				  if(dt.Rows[n]["vc_UmtsKi"]!=null && dt.Rows[n]["vc_UmtsKi"].ToString()!="")
				  {
				     model.vc_UmtsKi= dt.Rows[n]["vc_UmtsKi"].ToString();
				  }
				  if(dt.Rows[n]["vc_UmtsImsi"]!=null && dt.Rows[n]["vc_UmtsImsi"].ToString()!="")
				  {
				     model.vc_UmtsImsi= dt.Rows[n]["vc_UmtsImsi"].ToString();
				  }
				  if(dt.Rows[n]["FapID"]!=null && dt.Rows[n]["FapID"].ToString()!="")
				  {
				      model.FapID=int.Parse(dt.Rows[n]["FapID"].ToString());
				  }
				  if(dt.Rows[n]["vc_IP"]!=null && dt.Rows[n]["vc_IP"].ToString()!="")
				  {
				     model.vc_IP= dt.Rows[n]["vc_IP"].ToString();
				  }
				  if(dt.Rows[n]["NumberPasswordType"]!=null && dt.Rows[n]["NumberPasswordType"].ToString()!="")
				  {
				     model.NumberPasswordType= dt.Rows[n]["NumberPasswordType"].ToString();
				  }
				  if(dt.Rows[n]["NumberType"]!=null && dt.Rows[n]["NumberType"].ToString()!="")
				  {
				     model.NumberType= dt.Rows[n]["NumberType"].ToString();
				  }
				  if(dt.Rows[n]["TellAuthority"]!=null && dt.Rows[n]["TellAuthority"].ToString()!="")
				  {
				     model.TellAuthority= dt.Rows[n]["TellAuthority"].ToString();
				  }
				  if(dt.Rows[n]["TellType"]!=null && dt.Rows[n]["TellType"].ToString()!="")
				  {
				     model.TellType= dt.Rows[n]["TellType"].ToString();
				  }
				  if(dt.Rows[n]["IsDispatch"]!=null && dt.Rows[n]["IsDispatch"].ToString()!="")
				  {
				     model.IsDispatch= dt.Rows[n]["IsDispatch"].ToString();
				  }
				  if(dt.Rows[n]["LevelName"]!=null && dt.Rows[n]["LevelName"].ToString()!="")
				  {
				     model.LevelName= dt.Rows[n]["LevelName"].ToString();
				  }
				  if(dt.Rows[n]["deptName"]!=null && dt.Rows[n]["deptName"].ToString()!="")
				  {
				     model.deptName= dt.Rows[n]["deptName"].ToString();
				  }
				  if(dt.Rows[n]["BoxName"]!=null && dt.Rows[n]["BoxName"].ToString()!="")
				  {
				     model.BoxName= dt.Rows[n]["BoxName"].ToString();
				  }
				  if(dt.Rows[n]["boxIP"]!=null && dt.Rows[n]["boxIP"].ToString()!="")
				  {
				     model.boxIP= dt.Rows[n]["boxIP"].ToString();
				  }
				  if(dt.Rows[n]["vc_SN"]!=null && dt.Rows[n]["vc_SN"].ToString()!="")
				  {
				     model.vc_SN= dt.Rows[n]["vc_SN"].ToString();
				  }
				   modelList.Add(model);
				
				}
			}
			return modelList;
		}
		
        #endregion
	}
}