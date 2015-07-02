using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DB_Talk.DAL 
{
	/// <summary>
	///数据访问类 m_Member
	/// </summary>	
	public partial class m_Member
	{ 
		public m_Member()
		{}
		
		#region  Method
		
     	/// <summary>
		/// 是否存在该记录
		/// </summary>  
		public bool Exists(string strWhere)
		{
		    StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from m_Member  ");
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
		public int Add(DB_Talk.Model.m_Member model,bool IsReturnID)   
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
            if(model.i_Number!=null)
		    {
			   strSql1.Append("i_Number,");	
			   strSql2.Append("'"+ model.i_Number +"',");	
			} 
            if(model.vc_Name!=null)
		    {
			   strSql1.Append("vc_Name,");	
			   strSql2.Append("'"+ model.vc_Name +"',");	
			} 
            if(model.LevelID!=null)
		    {
			   strSql1.Append("LevelID,");	
			   strSql2.Append("'"+ model.LevelID +"',");	
			} 
            if(model.NumberTypeID!=null)
		    {
			   strSql1.Append("NumberTypeID,");	
			   strSql2.Append("'"+ model.NumberTypeID +"',");	
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
            if(model.DepartmentID!=null)
		    {
			   strSql1.Append("DepartmentID,");	
			   strSql2.Append("'"+ model.DepartmentID +"',");	
			} 
            if(model.vc_MAC!=null)
		    {
			   strSql1.Append("vc_MAC,");	
			   strSql2.Append("'"+ model.vc_MAC +"',");	
			} 
            if(model.i_Flag!=null)
		    {
			   strSql1.Append("i_Flag,");	
			   strSql2.Append("'"+ model.i_Flag +"',");	
			} 
            if(model.vc_Memo!=null)
		    {
			   strSql1.Append("vc_Memo,");	
			   strSql2.Append("'"+ model.vc_Memo +"',");	
			} 
            if(model.i_supplementSerive!=null)
		    {
			   strSql1.Append("i_supplementSerive,");	
			   strSql2.Append("'"+ model.i_supplementSerive +"',");	
			} 
            if(model.i_Authority!=null)
		    {
			   strSql1.Append("i_Authority,");	
			   strSql2.Append("'"+ model.i_Authority +"',");	
			} 
            if(model.i_NuPasswordType!=null)
		    {
			   strSql1.Append("i_NuPasswordType,");	
			   strSql2.Append("'"+ model.i_NuPasswordType +"',");	
			} 
            if(model.i_NuPassword!=null)
		    {
			   strSql1.Append("i_NuPassword,");	
			   strSql2.Append("'"+ model.i_NuPassword +"',");	
			} 
            if(model.i_UnCForwardNu!=null)
		    {
			   strSql1.Append("i_UnCForwardNu,");	
			   strSql2.Append("'"+ model.i_UnCForwardNu +"',");	
			} 
            if(model.i_NoAnswerForward!=null)
		    {
			   strSql1.Append("i_NoAnswerForward,");	
			   strSql2.Append("'"+ model.i_NoAnswerForward +"',");	
			} 
            if(model.i_PowerOffForward!=null)
		    {
			   strSql1.Append("i_PowerOffForward,");	
			   strSql2.Append("'"+ model.i_PowerOffForward +"',");	
			} 
            if(model.i_BusyForward!=null)
		    {
			   strSql1.Append("i_BusyForward,");	
			   strSql2.Append("'"+ model.i_BusyForward +"',");	
			} 
            if(model.i_DirectNum!=null)
		    {
			   strSql1.Append("i_DirectNum,");	
			   strSql2.Append("'"+ model.i_DirectNum +"',");	
			} 
            if(model.i_IsAssociateActive!=null)
		    {
			   strSql1.Append("i_IsAssociateActive,");	
			   strSql2.Append("'"+ model.i_IsAssociateActive +"',");	
			} 
            if(model.i_AssociateNum1!=null)
		    {
			   strSql1.Append("i_AssociateNum1,");	
			   strSql2.Append("'"+ model.i_AssociateNum1 +"',");	
			} 
            if(model.i_AssociateNum2!=null)
		    {
			   strSql1.Append("i_AssociateNum2,");	
			   strSql2.Append("'"+ model.i_AssociateNum2 +"',");	
			} 
            if(model.vc_UmtsKi!=null)
		    {
			   strSql1.Append("vc_UmtsKi,");	
			   strSql2.Append("'"+ model.vc_UmtsKi +"',");	
			} 
            if(model.vc_UmtsImsi!=null)
		    {
			   strSql1.Append("vc_UmtsImsi,");	
			   strSql2.Append("'"+ model.vc_UmtsImsi +"',");	
			}

            if (model.FapID != null)
            {
                strSql1.Append("FapID,");
                strSql2.Append("'" + model.FapID + "',");
            }

            if (model.vc_IP != null)
            {
                strSql1.Append("vc_IP,");
                strSql2.Append("'" + model.vc_IP + "',");
            }

            strSql.Append("insert into m_Member(");	
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
		public bool Update(DB_Talk.Model.m_Member model,string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_Member set ");
			if(model.BoxID!=null)
		    {
			   strSql.Append("BoxID='"+ model.BoxID +"',");	
			} 
			if(model.i_Number!=null)
		    {
			   strSql.Append("i_Number='"+ model.i_Number +"',");	
			} 
			if(model.vc_Name!=null)
		    {
			   strSql.Append("vc_Name='"+ model.vc_Name +"',");	
			} 
			if(model.LevelID!=null)
		    {
			   strSql.Append("LevelID='"+ model.LevelID +"',");	
			} 
			if(model.NumberTypeID!=null)
		    {
			   strSql.Append("NumberTypeID='"+ model.NumberTypeID +"',");	
			} 
			if(model.i_TellType!=null)
		    {
			   strSql.Append("i_TellType='"+ model.i_TellType +"',");	
			} 
			if(model.i_IsDispatch!=null)
		    {
			   strSql.Append("i_IsDispatch='"+ model.i_IsDispatch +"',");	
			} 
			if(model.DepartmentID!=null)
		    {
			   strSql.Append("DepartmentID='"+ model.DepartmentID +"',");	
			} 
			if(model.vc_MAC!=null)
		    {
			   strSql.Append("vc_MAC='"+ model.vc_MAC +"',");	
			} 
			if(model.i_Flag!=null)
		    {
			   strSql.Append("i_Flag='"+ model.i_Flag +"',");	
			} 
			if(model.vc_Memo!=null)
		    {
			   strSql.Append("vc_Memo='"+ model.vc_Memo +"',");	
			} 
			if(model.i_supplementSerive!=null)
		    {
			   strSql.Append("i_supplementSerive='"+ model.i_supplementSerive +"',");	
			} 
			if(model.i_Authority!=null)
		    {
			   strSql.Append("i_Authority='"+ model.i_Authority +"',");	
			} 
			if(model.i_NuPasswordType!=null)
		    {
			   strSql.Append("i_NuPasswordType='"+ model.i_NuPasswordType +"',");	
			} 
			if(model.i_NuPassword!=null)
		    {
			   strSql.Append("i_NuPassword='"+ model.i_NuPassword +"',");	
			} 
			if(model.i_UnCForwardNu!=null)
		    {
			   strSql.Append("i_UnCForwardNu='"+ model.i_UnCForwardNu +"',");	
			} 
			if(model.i_NoAnswerForward!=null)
		    {
			   strSql.Append("i_NoAnswerForward='"+ model.i_NoAnswerForward +"',");	
			} 
			if(model.i_PowerOffForward!=null)
		    {
			   strSql.Append("i_PowerOffForward='"+ model.i_PowerOffForward +"',");	
			} 
			if(model.i_BusyForward!=null)
		    {
			   strSql.Append("i_BusyForward='"+ model.i_BusyForward +"',");	
			} 
			if(model.i_DirectNum!=null)
		    {
			   strSql.Append("i_DirectNum='"+ model.i_DirectNum +"',");	
			} 
			if(model.i_IsAssociateActive!=null)
		    {
			   strSql.Append("i_IsAssociateActive='"+ model.i_IsAssociateActive +"',");	
			} 
			if(model.i_AssociateNum1!=null)
		    {
			   strSql.Append("i_AssociateNum1='"+ model.i_AssociateNum1 +"',");	
			} 
			if(model.i_AssociateNum2!=null)
		    {
			   strSql.Append("i_AssociateNum2='"+ model.i_AssociateNum2 +"',");	
			} 
			if(model.vc_UmtsKi!=null)
		    {
			   strSql.Append("vc_UmtsKi='"+ model.vc_UmtsKi +"',");	
			} 
			if(model.vc_UmtsImsi!=null)
		    {
			   strSql.Append("vc_UmtsImsi='"+ model.vc_UmtsImsi +"',");	
			}

            if (model.FapID != null)
            {
                strSql.Append("FapID='" + model.FapID + "',");
            }

            if (model.vc_IP != null)
            {
                strSql.Append("vc_IP='" + model.vc_IP + "',");
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
			    strSql.Append("delete from m_Member ");	
			else
				strSql.Append("update m_Member  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_Member ");	
			else
				strSql.Append("update m_Member  set i_Flag=1 ");	 
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
			    strSql.Append("delete from m_Member ");	
			else
				strSql.Append("update m_Member  set i_Flag=1 ");	 
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
		public DB_Talk.Model.m_Member GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
            strSql.Append("  ID, BoxID, i_Number, vc_Name, vc_IP,LevelID,FapID, NumberTypeID, i_TellType, i_IsDispatch, DepartmentID, vc_MAC, i_Flag, vc_Memo, i_supplementSerive, i_Authority, i_NuPasswordType, i_NuPassword, i_UnCForwardNu, i_NoAnswerForward, i_PowerOffForward, i_BusyForward, i_DirectNum, i_IsAssociateActive, i_AssociateNum1, i_AssociateNum2, vc_UmtsKi, vc_UmtsImsi  ");			
			strSql.Append("  from m_Member ");
			 strSql.Append(" where ID= '"+ ID +"'");   	  
			DB_Talk.Model.m_Member model=new DB_Talk.Model.m_Member();
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
		public DB_Talk.Model.m_Member GetModel(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("  select top 1 ");
            strSql.Append("  ID, BoxID, i_Number, vc_Name,vc_IP, LevelID,FapID, NumberTypeID, i_TellType, i_IsDispatch, DepartmentID, vc_MAC, i_Flag, vc_Memo, i_supplementSerive, i_Authority, i_NuPasswordType, i_NuPassword, i_UnCForwardNu, i_NoAnswerForward, i_PowerOffForward, i_BusyForward, i_DirectNum, i_IsAssociateActive, i_AssociateNum1, i_AssociateNum2, vc_UmtsKi, vc_UmtsImsi  ");			
			strSql.Append("  from m_Member ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DB_Talk.Model.m_Member model=new DB_Talk.Model.m_Member();
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
            strSql.Append("  ID, BoxID, i_Number, vc_Name,vc_IP, LevelID,FapID, NumberTypeID, i_TellType, i_IsDispatch, DepartmentID, vc_MAC, i_Flag, vc_Memo, i_supplementSerive, i_Authority, i_NuPasswordType, i_NuPassword, i_UnCForwardNu, i_NoAnswerForward, i_PowerOffForward, i_BusyForward, i_DirectNum, i_IsAssociateActive, i_AssociateNum1, i_AssociateNum2, vc_UmtsKi, vc_UmtsImsi  ");			
			strSql.Append(" FROM m_Member ");
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
		public List<DB_Talk.Model.m_Member> DataTableToList(DataSet ds)
		{
			List<DB_Talk.Model.m_Member> modelList = new List<DB_Talk.Model.m_Member>();
			if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.m_Member model;
				for (int n = 0; n < rowsCount; n++)
				{
				  model = new DB_Talk.Model.m_Member();	
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
				      model.i_supplementSerive=uint.Parse(dt.Rows[n]["i_supplementSerive"].ToString());
				  }
				  if(dt.Rows[n]["i_Authority"]!=null && dt.Rows[n]["i_Authority"].ToString()!="")
				  {
				      model.i_Authority=int.Parse(dt.Rows[n]["i_Authority"].ToString());
				  }
				  if(dt.Rows[n]["i_NuPasswordType"]!=null && dt.Rows[n]["i_NuPasswordType"].ToString()!="")
				  {
				      model.i_NuPasswordType=int.Parse(dt.Rows[n]["i_NuPasswordType"].ToString());
				  }
				  if(dt.Rows[n]["i_NuPassword"]!=null && dt.Rows[n]["i_NuPassword"].ToString()!="")
				  {
                      model.i_NuPassword = UInt64.Parse(dt.Rows[n]["i_NuPassword"].ToString());
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

                  if (dt.Rows[n]["FapID"] != null && dt.Rows[n]["FapID"].ToString() != "")
                  {
                      model.FapID = int.Parse(dt.Rows[n]["FapID"].ToString());
                  }

                  if (dt.Rows[n]["vc_IP"] != null && dt.Rows[n]["vc_IP"].ToString() != "")
                  {
                      model.vc_IP = dt.Rows[n]["vc_IP"].ToString();
                  }

				   modelList.Add(model);
				
				}
			}
			return modelList;
		}
		
        #endregion


        #region MethodEx
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetListEX(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append("  a.ID, BoxID, i_Number, a.vc_Name,vc_IP, LevelID,FapID, NumberTypeID, i_TellType, i_IsDispatch, DepartmentID, vc_MAC, a.i_Flag, a.vc_Memo, i_supplementSerive, i_Authority, i_NuPasswordType, i_NuPassword, i_UnCForwardNu, i_NoAnswerForward, i_PowerOffForward, i_BusyForward, i_DirectNum, i_IsAssociateActive, i_AssociateNum1, i_AssociateNum2, vc_UmtsKi, vc_UmtsImsi,b.vc_Name    ");
            strSql.Append("  FROM m_Member a join  m_departments b on a.departmentid=b.id  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            return GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DB_Talk.Model.m_Member> DataTableToListEX(DataSet ds)
        {
            List<DB_Talk.Model.m_Member> modelList = new List<DB_Talk.Model.m_Member>();
            if (ds == null) return modelList;
            DataTable dt = ds.Tables[0];
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DB_Talk.Model.m_Member model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DB_Talk.Model.m_Member();
                    if (dt.Rows[n]["a.ID"] != null && dt.Rows[n]["a.ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["a.ID"].ToString());
                    }
                    if (dt.Rows[n]["BoxID"] != null && dt.Rows[n]["BoxID"].ToString() != "")
                    {
                        model.BoxID = int.Parse(dt.Rows[n]["BoxID"].ToString());
                    }
                    if (dt.Rows[n]["i_Number"] != null && dt.Rows[n]["i_Number"].ToString() != "")
                    {
                        model.i_Number = int.Parse(dt.Rows[n]["i_Number"].ToString());
                    }
                    if (dt.Rows[n]["a.vc_Name"] != null && dt.Rows[n]["a.vc_Name"].ToString() != "")
                    {
                        model.vc_Name = dt.Rows[n]["a.vc_Name"].ToString();
                    }
                    if (dt.Rows[n]["LevelID"] != null && dt.Rows[n]["LevelID"].ToString() != "")
                    {
                        model.LevelID = int.Parse(dt.Rows[n]["LevelID"].ToString());
                    }
                    if (dt.Rows[n]["NumberTypeID"] != null && dt.Rows[n]["NumberTypeID"].ToString() != "")
                    {
                        model.NumberTypeID = int.Parse(dt.Rows[n]["NumberTypeID"].ToString());
                    }
                    if (dt.Rows[n]["i_TellType"] != null && dt.Rows[n]["i_TellType"].ToString() != "")
                    {
                        model.i_TellType = int.Parse(dt.Rows[n]["i_TellType"].ToString());
                    }
                    if (dt.Rows[n]["i_IsDispatch"] != null && dt.Rows[n]["i_IsDispatch"].ToString() != "")
                    {
                        model.i_IsDispatch = int.Parse(dt.Rows[n]["i_IsDispatch"].ToString());
                    }
                    if (dt.Rows[n]["DepartmentID"] != null && dt.Rows[n]["DepartmentID"].ToString() != "")
                    {
                        model.DepartmentID = int.Parse(dt.Rows[n]["DepartmentID"].ToString());
                    }
                    if (dt.Rows[n]["vc_MAC"] != null && dt.Rows[n]["vc_MAC"].ToString() != "")
                    {
                        model.vc_MAC = dt.Rows[n]["vc_MAC"].ToString();
                    }
                    if (dt.Rows[n]["a.i_Flag"] != null && dt.Rows[n]["a.i_Flag"].ToString() != "")
                    {
                        model.i_Flag = int.Parse(dt.Rows[n]["a.i_Flag"].ToString());
                    }
                    if (dt.Rows[n]["a.vc_Memo"] != null && dt.Rows[n]["a.vc_Memo"].ToString() != "")
                    {
                        model.vc_Memo = dt.Rows[n]["a.vc_Memo"].ToString();
                    }
                    if (dt.Rows[n]["i_supplementSerive"] != null && dt.Rows[n]["i_supplementSerive"].ToString() != "")
                    {
                        model.i_supplementSerive = uint.Parse(dt.Rows[n]["i_supplementSerive"].ToString());
                    }
                    if (dt.Rows[n]["i_Authority"] != null && dt.Rows[n]["i_Authority"].ToString() != "")
                    {
                        model.i_Authority = int.Parse(dt.Rows[n]["i_Authority"].ToString());
                    }
                    if (dt.Rows[n]["i_NuPasswordType"] != null && dt.Rows[n]["i_NuPasswordType"].ToString() != "")
                    {
                        model.i_NuPasswordType = int.Parse(dt.Rows[n]["i_NuPasswordType"].ToString());
                    }
                    if (dt.Rows[n]["i_NuPassword"] != null && dt.Rows[n]["i_NuPassword"].ToString() != "")
                    {
                        model.i_NuPassword = UInt64.Parse(dt.Rows[n]["i_NuPassword"].ToString());
                    }
                    if (dt.Rows[n]["i_UnCForwardNu"] != null && dt.Rows[n]["i_UnCForwardNu"].ToString() != "")
                    {
                        model.i_UnCForwardNu = int.Parse(dt.Rows[n]["i_UnCForwardNu"].ToString());
                    }
                    if (dt.Rows[n]["i_NoAnswerForward"] != null && dt.Rows[n]["i_NoAnswerForward"].ToString() != "")
                    {
                        model.i_NoAnswerForward = int.Parse(dt.Rows[n]["i_NoAnswerForward"].ToString());
                    }
                    if (dt.Rows[n]["i_PowerOffForward"] != null && dt.Rows[n]["i_PowerOffForward"].ToString() != "")
                    {
                        model.i_PowerOffForward = int.Parse(dt.Rows[n]["i_PowerOffForward"].ToString());
                    }
                    if (dt.Rows[n]["i_BusyForward"] != null && dt.Rows[n]["i_BusyForward"].ToString() != "")
                    {
                        model.i_BusyForward = int.Parse(dt.Rows[n]["i_BusyForward"].ToString());
                    }
                    if (dt.Rows[n]["i_DirectNum"] != null && dt.Rows[n]["i_DirectNum"].ToString() != "")
                    {
                        model.i_DirectNum = int.Parse(dt.Rows[n]["i_DirectNum"].ToString());
                    }
                    if (dt.Rows[n]["i_IsAssociateActive"] != null && dt.Rows[n]["i_IsAssociateActive"].ToString() != "")
                    {
                        model.i_IsAssociateActive = int.Parse(dt.Rows[n]["i_IsAssociateActive"].ToString());
                    }
                    if (dt.Rows[n]["i_AssociateNum1"] != null && dt.Rows[n]["i_AssociateNum1"].ToString() != "")
                    {
                        model.i_AssociateNum1 = int.Parse(dt.Rows[n]["i_AssociateNum1"].ToString());
                    }
                    if (dt.Rows[n]["i_AssociateNum2"] != null && dt.Rows[n]["i_AssociateNum2"].ToString() != "")
                    {
                        model.i_AssociateNum2 = int.Parse(dt.Rows[n]["i_AssociateNum2"].ToString());
                    }
                    if (dt.Rows[n]["vc_UmtsKi"] != null && dt.Rows[n]["vc_UmtsKi"].ToString() != "")
                    {
                        model.vc_UmtsKi = dt.Rows[n]["vc_UmtsKi"].ToString();
                    }
                    if (dt.Rows[n]["vc_UmtsImsi"] != null && dt.Rows[n]["vc_UmtsImsi"].ToString() != "")
                    {
                        model.vc_UmtsImsi = dt.Rows[n]["vc_UmtsImsi"].ToString();
                    }

                    if (dt.Rows[n]["FapID"] != null && dt.Rows[n]["FapID"].ToString() != "")
                    {
                        model.FapID = int.Parse(dt.Rows[n]["FapID"].ToString());
                    }
                    if (dt.Rows[n]["b.vc_Name"] != null && dt.Rows[n]["b.vc_Name"].ToString() != "")
                    {
                        model.vc_Name = dt.Rows[n]["b.vc_Name"].ToString();
                    }

                    if (dt.Rows[n]["vc_IP"] != null && dt.Rows[n]["vc_IP"].ToString() != "")
                    {
                        model.vc_IP = dt.Rows[n]["vc_IP"].ToString();
                    }

                    modelList.Add(model);

                }
            }
            return modelList;
        }
		

        #endregion
    }
}