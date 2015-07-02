using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DB_Talk.DAL
{
	/// <summary>
	/// 数据访问类:SubscriberProfile
	/// </summary>
	public partial class SubscriberProfile
	{
		public SubscriberProfile()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DB_Talk.Model.SubscriberProfile model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.SiteID != null)
			{
				strSql1.Append("SiteID,");
				strSql2.Append(""+model.SiteID+",");
			}
			if (model.SubscriberID != null)
			{
				strSql1.Append("SubscriberID,");
				strSql2.Append(""+model.SubscriberID+",");
			}
			if (model.EmployeeID != null)
			{
				strSql1.Append("EmployeeID,");
				strSql2.Append(""+model.EmployeeID+",");
			}
			if (model.SPMSubIndex != null)
			{
				strSql1.Append("SPMSubIndex,");
				strSql2.Append(""+model.SPMSubIndex+",");
			}
			if (model.SubscriberNumber != null)
			{
				strSql1.Append("SubscriberNumber,");
				strSql2.Append("'"+model.SubscriberNumber+"',");
			}
			if (model.SPMPSNumber != null)
			{
				strSql1.Append("SPMPSNumber,");
				strSql2.Append("'"+model.SPMPSNumber+"',");
			}
			if (model.SPMAuthKey != null)
			{
				strSql1.Append("SPMAuthKey,");
				strSql2.Append("'"+model.SPMAuthKey+"',");
			}
			if (model.SPMSubType != null)
			{
				strSql1.Append("SPMSubType,");
				strSql2.Append(""+model.SPMSubType+",");
			}
			if (model.Record != null)
			{
				strSql1.Append("Record,");
				strSql2.Append(""+model.Record+",");
			}
			if (model.SPMPSIdentification != null)
			{
				strSql1.Append("SPMPSIdentification,");
				strSql2.Append("'"+model.SPMPSIdentification+"',");
			}
			if (model.SPMDIDNumber != null)
			{
				strSql1.Append("SPMDIDNumber,");
				strSql2.Append("'"+model.SPMDIDNumber+"',");
			}
			if (model.SPMSubSuppService != null)
			{
				strSql1.Append("SPMSubSuppService,");
				strSql2.Append(""+model.SPMSubSuppService+",");
			}
			if (model.SPMSubGroup != null)
			{
				strSql1.Append("SPMSubGroup,");
				strSql2.Append("'"+model.SPMSubGroup+"',");
			}
			if (model.SPMSubPriority != null)
			{
				strSql1.Append("SPMSubPriority,");
				strSql2.Append(""+model.SPMSubPriority+",");
			}
			if (model.SPMFXSPort != null)
			{
				strSql1.Append("SPMFXSPort,");
				strSql2.Append("'"+model.SPMFXSPort+"',");
			}
			if (model.SPMSubCfuNumber != null)
			{
				strSql1.Append("SPMSubCfuNumber,");
				strSql2.Append("'"+model.SPMSubCfuNumber+"',");
			}
			if (model.SPMSubCfbNumber != null)
			{
				strSql1.Append("SPMSubCfbNumber,");
				strSql2.Append("'"+model.SPMSubCfbNumber+"',");
			}
			if (model.SPMSubCfnrNumber != null)
			{
				strSql1.Append("SPMSubCfnrNumber,");
				strSql2.Append("'"+model.SPMSubCfnrNumber+"',");
			}
			if (model.SPMSubCfurNumber != null)
			{
				strSql1.Append("SPMSubCfurNumber,");
				strSql2.Append("'"+model.SPMSubCfurNumber+"',");
			}
			if (model.SPMAssociationNumber1 != null)
			{
				strSql1.Append("SPMAssociationNumber1,");
				strSql2.Append("'"+model.SPMAssociationNumber1+"',");
			}
			if (model.SPMAssociationNumber2 != null)
			{
				strSql1.Append("SPMAssociationNumber2,");
				strSql2.Append("'"+model.SPMAssociationNumber2+"',");
			}
			if (model.SPMSubPassword != null)
			{
				strSql1.Append("SPMSubPassword,");
				strSql2.Append("'"+model.SPMSubPassword+"',");
			}
			if (model.SPMSubPasswordLevel != null)
			{
				strSql1.Append("SPMSubPasswordLevel,");
				strSql2.Append(""+model.SPMSubPasswordLevel+",");
			}
			if (model.SPMSubPasswordStatus != null)
			{
				strSql1.Append("SPMSubPasswordStatus,");
				strSql2.Append(""+model.SPMSubPasswordStatus+",");
			}
			if (model.SPMFXOPort != null)
			{
				strSql1.Append("SPMFXOPort,");
				strSql2.Append("'"+model.SPMFXOPort+"',");
			}
			if (model.SPMACTimeHour != null)
			{
				strSql1.Append("SPMACTimeHour,");
				strSql2.Append(""+model.SPMACTimeHour+",");
			}
			if (model.SPMACTimeMinute != null)
			{
				strSql1.Append("SPMACTimeMinute,");
				strSql2.Append(""+model.SPMACTimeMinute+",");
			}
			if (model.SPMSubStatus != null)
			{
				strSql1.Append("SPMSubStatus,");
				strSql2.Append(""+model.SPMSubStatus+",");
			}
			if (model.SPMSubBlockStatus != null)
			{
				strSql1.Append("SPMSubBlockStatus,");
				strSql2.Append(""+model.SPMSubBlockStatus+",");
			}
			if (model.SPMSubInumberServiceStatus != null)
			{
				strSql1.Append("SPMSubInumberServiceStatus,");
				strSql2.Append(""+model.SPMSubInumberServiceStatus+",");
			}
			if (model.DispatchLevel != null)
			{
				strSql1.Append("DispatchLevel,");
				strSql2.Append(""+model.DispatchLevel+",");
			}
			if (model.ChangeTimestamp != null)
			{
				strSql1.Append("ChangeTimestamp,");
				strSql2.Append("'"+model.ChangeTimestamp+"',");
			}
			strSql.Append("insert into SubscriberProfile(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
            
			int rows=DB_Talk.DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
		/// 更新一条数据
		/// </summary>
		public bool Update(DB_Talk.Model.SubscriberProfile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SubscriberProfile set ");
			if (model.SiteID != null)
			{
				strSql.Append("SiteID="+model.SiteID+",");
			}
			if (model.SubscriberID != null)
			{
				strSql.Append("SubscriberID="+model.SubscriberID+",");
			}
			if (model.EmployeeID != null)
			{
				strSql.Append("EmployeeID="+model.EmployeeID+",");
			}
			if (model.SPMSubIndex != null)
			{
				strSql.Append("SPMSubIndex="+model.SPMSubIndex+",");
			}
			if (model.SubscriberNumber != null)
			{
				strSql.Append("SubscriberNumber='"+model.SubscriberNumber+"',");
			}
			if (model.SPMPSNumber != null)
			{
				strSql.Append("SPMPSNumber='"+model.SPMPSNumber+"',");
			}
			if (model.SPMAuthKey != null)
			{
				strSql.Append("SPMAuthKey='"+model.SPMAuthKey+"',");
			}
			if (model.SPMSubType != null)
			{
				strSql.Append("SPMSubType="+model.SPMSubType+",");
			}
			if (model.Record != null)
			{
				strSql.Append("Record="+model.Record+",");
			}
			if (model.SPMPSIdentification != null)
			{
				strSql.Append("SPMPSIdentification='"+model.SPMPSIdentification+"',");
			}
			if (model.SPMDIDNumber != null)
			{
				strSql.Append("SPMDIDNumber='"+model.SPMDIDNumber+"',");
			}
			if (model.SPMSubSuppService != null)
			{
				strSql.Append("SPMSubSuppService="+model.SPMSubSuppService+",");
			}
			if (model.SPMSubGroup != null)
			{
				strSql.Append("SPMSubGroup='"+model.SPMSubGroup+"',");
			}
			if (model.SPMSubPriority != null)
			{
				strSql.Append("SPMSubPriority="+model.SPMSubPriority+",");
			}
			if (model.SPMFXSPort != null)
			{
				strSql.Append("SPMFXSPort='"+model.SPMFXSPort+"',");
			}
			if (model.SPMSubCfuNumber != null)
			{
				strSql.Append("SPMSubCfuNumber='"+model.SPMSubCfuNumber+"',");
			}
			if (model.SPMSubCfbNumber != null)
			{
				strSql.Append("SPMSubCfbNumber='"+model.SPMSubCfbNumber+"',");
			}
			if (model.SPMSubCfnrNumber != null)
			{
				strSql.Append("SPMSubCfnrNumber='"+model.SPMSubCfnrNumber+"',");
			}
			if (model.SPMSubCfurNumber != null)
			{
				strSql.Append("SPMSubCfurNumber='"+model.SPMSubCfurNumber+"',");
			}
			if (model.SPMAssociationNumber1 != null)
			{
				strSql.Append("SPMAssociationNumber1='"+model.SPMAssociationNumber1+"',");
			}
			if (model.SPMAssociationNumber2 != null)
			{
				strSql.Append("SPMAssociationNumber2='"+model.SPMAssociationNumber2+"',");
			}
			if (model.SPMSubPassword != null)
			{
				strSql.Append("SPMSubPassword='"+model.SPMSubPassword+"',");
			}
			if (model.SPMSubPasswordLevel != null)
			{
				strSql.Append("SPMSubPasswordLevel="+model.SPMSubPasswordLevel+",");
			}
			if (model.SPMSubPasswordStatus != null)
			{
				strSql.Append("SPMSubPasswordStatus="+model.SPMSubPasswordStatus+",");
			}
			if (model.SPMFXOPort != null)
			{
				strSql.Append("SPMFXOPort='"+model.SPMFXOPort+"',");
			}
			if (model.SPMACTimeHour != null)
			{
				strSql.Append("SPMACTimeHour="+model.SPMACTimeHour+",");
			}
			if (model.SPMACTimeMinute != null)
			{
				strSql.Append("SPMACTimeMinute="+model.SPMACTimeMinute+",");
			}
			if (model.SPMSubStatus != null)
			{
				strSql.Append("SPMSubStatus="+model.SPMSubStatus+",");
			}
			if (model.SPMSubBlockStatus != null)
			{
				strSql.Append("SPMSubBlockStatus="+model.SPMSubBlockStatus+",");
			}
			if (model.SPMSubInumberServiceStatus != null)
			{
				strSql.Append("SPMSubInumberServiceStatus="+model.SPMSubInumberServiceStatus+",");
			}
			if (model.DispatchLevel != null)
			{
				strSql.Append("DispatchLevel="+model.DispatchLevel+",");
			}
			if (model.ChangeTimestamp != null)
			{
				strSql.Append("ChangeTimestamp='"+model.ChangeTimestamp+"',");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ");
			int rowsAffected=DB_Talk.DB.OleDbHelper.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SubscriberProfile ");
			strSql.Append(" where " );
			int rowsAffected=DB_Talk.DB.OleDbHelper.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
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
		public DB_Talk.Model.SubscriberProfile GetModel()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" SiteID,SubscriberID,EmployeeID,SPMSubIndex,SubscriberNumber,SPMPSNumber,SPMAuthKey,SPMSubType,Record,SPMPSIdentification,SPMDIDNumber,SPMSubSuppService,SPMSubGroup,SPMSubPriority,SPMFXSPort,SPMSubCfuNumber,SPMSubCfbNumber,SPMSubCfnrNumber,SPMSubCfurNumber,SPMAssociationNumber1,SPMAssociationNumber2,SPMSubPassword,SPMSubPasswordLevel,SPMSubPasswordStatus,SPMFXOPort,SPMACTimeHour,SPMACTimeMinute,SPMSubStatus,SPMSubBlockStatus,SPMSubInumberServiceStatus,DispatchLevel,ChangeTimestamp ");
			strSql.Append(" from SubscriberProfile ");
			strSql.Append(" where " );
			DB_Talk.Model.SubscriberProfile model=new DB_Talk.Model.SubscriberProfile();
            
			DataSet ds=DB.OleDbHelper.GetDataSet(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DB_Talk.Model.SubscriberProfile DataRowToModel(DataRow row)
		{
			DB_Talk.Model.SubscriberProfile model=new DB_Talk.Model.SubscriberProfile();
			if (row != null)
			{
				if(row["SiteID"]!=null && row["SiteID"].ToString()!="")
				{
					model.SiteID=int.Parse(row["SiteID"].ToString());
				}
				if(row["SubscriberID"]!=null && row["SubscriberID"].ToString()!="")
				{
					model.SubscriberID=int.Parse(row["SubscriberID"].ToString());
				}
				if(row["EmployeeID"]!=null && row["EmployeeID"].ToString()!="")
				{
					model.EmployeeID=int.Parse(row["EmployeeID"].ToString());
				}
				if(row["SPMSubIndex"]!=null && row["SPMSubIndex"].ToString()!="")
				{
					model.SPMSubIndex=int.Parse(row["SPMSubIndex"].ToString());
				}
				if(row["SubscriberNumber"]!=null)
				{
					model.SubscriberNumber=row["SubscriberNumber"].ToString();
				}
				if(row["SPMPSNumber"]!=null)
				{
					model.SPMPSNumber=row["SPMPSNumber"].ToString();
				}
				if(row["SPMAuthKey"]!=null)
				{
					model.SPMAuthKey=row["SPMAuthKey"].ToString();
				}
				if(row["SPMSubType"]!=null && row["SPMSubType"].ToString()!="")
				{
					model.SPMSubType=int.Parse(row["SPMSubType"].ToString());
				}
				if(row["Record"]!=null && row["Record"].ToString()!="")
				{
					model.Record=int.Parse(row["Record"].ToString());
				}
				if(row["SPMPSIdentification"]!=null)
				{
					model.SPMPSIdentification=row["SPMPSIdentification"].ToString();
				}
				if(row["SPMDIDNumber"]!=null)
				{
					model.SPMDIDNumber=row["SPMDIDNumber"].ToString();
				}
				if(row["SPMSubSuppService"]!=null && row["SPMSubSuppService"].ToString()!="")
				{
					model.SPMSubSuppService=int.Parse(row["SPMSubSuppService"].ToString());
				}
				if(row["SPMSubGroup"]!=null)
				{
					model.SPMSubGroup=row["SPMSubGroup"].ToString();
				}
				if(row["SPMSubPriority"]!=null && row["SPMSubPriority"].ToString()!="")
				{
					model.SPMSubPriority=int.Parse(row["SPMSubPriority"].ToString());
				}
				if(row["SPMFXSPort"]!=null)
				{
					model.SPMFXSPort=row["SPMFXSPort"].ToString();
				}
				if(row["SPMSubCfuNumber"]!=null)
				{
					model.SPMSubCfuNumber=row["SPMSubCfuNumber"].ToString();
				}
				if(row["SPMSubCfbNumber"]!=null)
				{
					model.SPMSubCfbNumber=row["SPMSubCfbNumber"].ToString();
				}
				if(row["SPMSubCfnrNumber"]!=null)
				{
					model.SPMSubCfnrNumber=row["SPMSubCfnrNumber"].ToString();
				}
				if(row["SPMSubCfurNumber"]!=null)
				{
					model.SPMSubCfurNumber=row["SPMSubCfurNumber"].ToString();
				}
				if(row["SPMAssociationNumber1"]!=null)
				{
					model.SPMAssociationNumber1=row["SPMAssociationNumber1"].ToString();
				}
				if(row["SPMAssociationNumber2"]!=null)
				{
					model.SPMAssociationNumber2=row["SPMAssociationNumber2"].ToString();
				}
				if(row["SPMSubPassword"]!=null)
				{
					model.SPMSubPassword=row["SPMSubPassword"].ToString();
				}
				if(row["SPMSubPasswordLevel"]!=null && row["SPMSubPasswordLevel"].ToString()!="")
				{
					model.SPMSubPasswordLevel=int.Parse(row["SPMSubPasswordLevel"].ToString());
				}
				if(row["SPMSubPasswordStatus"]!=null && row["SPMSubPasswordStatus"].ToString()!="")
				{
					model.SPMSubPasswordStatus=int.Parse(row["SPMSubPasswordStatus"].ToString());
				}
				if(row["SPMFXOPort"]!=null)
				{
					model.SPMFXOPort=row["SPMFXOPort"].ToString();
				}
				if(row["SPMACTimeHour"]!=null && row["SPMACTimeHour"].ToString()!="")
				{
					model.SPMACTimeHour=int.Parse(row["SPMACTimeHour"].ToString());
				}
				if(row["SPMACTimeMinute"]!=null && row["SPMACTimeMinute"].ToString()!="")
				{
					model.SPMACTimeMinute=int.Parse(row["SPMACTimeMinute"].ToString());
				}
				if(row["SPMSubStatus"]!=null && row["SPMSubStatus"].ToString()!="")
				{
					model.SPMSubStatus=int.Parse(row["SPMSubStatus"].ToString());
				}
				if(row["SPMSubBlockStatus"]!=null && row["SPMSubBlockStatus"].ToString()!="")
				{
					model.SPMSubBlockStatus=int.Parse(row["SPMSubBlockStatus"].ToString());
				}
				if(row["SPMSubInumberServiceStatus"]!=null && row["SPMSubInumberServiceStatus"].ToString()!="")
				{
					model.SPMSubInumberServiceStatus=int.Parse(row["SPMSubInumberServiceStatus"].ToString());
				}
				if(row["DispatchLevel"]!=null && row["DispatchLevel"].ToString()!="")
				{
					model.DispatchLevel=int.Parse(row["DispatchLevel"].ToString());
				}
				if(row["ChangeTimestamp"]!=null && row["ChangeTimestamp"].ToString()!="")
				{
					model.ChangeTimestamp=DateTime.Parse(row["ChangeTimestamp"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SiteID,SubscriberID,EmployeeID,SPMSubIndex,SubscriberNumber,SPMPSNumber,SPMAuthKey,SPMSubType,Record,SPMPSIdentification,SPMDIDNumber,SPMSubSuppService,SPMSubGroup,SPMSubPriority,SPMFXSPort,SPMSubCfuNumber,SPMSubCfbNumber,SPMSubCfnrNumber,SPMSubCfurNumber,SPMAssociationNumber1,SPMAssociationNumber2,SPMSubPassword,SPMSubPasswordLevel,SPMSubPasswordStatus,SPMFXOPort,SPMACTimeHour,SPMACTimeMinute,SPMSubStatus,SPMSubBlockStatus,SPMSubInumberServiceStatus,DispatchLevel,ChangeTimestamp ");
			strSql.Append(" FROM SubscriberProfile ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DB.OleDbHelper.GetDataSet(strSql.ToString());
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
			strSql.Append(" SiteID,SubscriberID,EmployeeID,SPMSubIndex,SubscriberNumber,SPMPSNumber,SPMAuthKey,SPMSubType,Record,SPMPSIdentification,SPMDIDNumber,SPMSubSuppService,SPMSubGroup,SPMSubPriority,SPMFXSPort,SPMSubCfuNumber,SPMSubCfbNumber,SPMSubCfnrNumber,SPMSubCfurNumber,SPMAssociationNumber1,SPMAssociationNumber2,SPMSubPassword,SPMSubPasswordLevel,SPMSubPasswordStatus,SPMFXOPort,SPMACTimeHour,SPMACTimeMinute,SPMSubStatus,SPMSubBlockStatus,SPMSubInumberServiceStatus,DispatchLevel,ChangeTimestamp ");
			strSql.Append(" FROM SubscriberProfile ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DB.OleDbHelper.GetDataSet(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM SubscriberProfile ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj =DB.OleDbHelper.ExecuteSql(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from SubscriberProfile T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DB.OleDbHelper.GetDataSet(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

