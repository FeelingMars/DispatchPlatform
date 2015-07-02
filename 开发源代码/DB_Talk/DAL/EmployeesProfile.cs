using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace DB_Talk.DAL
{
	/// <summary>
	/// 数据访问类:EmployeesProfile
	/// </summary>
	public partial class EmployeesProfile
	{
		public EmployeesProfile()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DB_Talk.Model.EmployeesProfile model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.EmployeeName != null)
			{
				strSql1.Append("EmployeeName,");
				strSql2.Append("'"+model.EmployeeName+"',");
			}
			if (model.Title != null)
			{
				strSql1.Append("Title,");
				strSql2.Append("'"+model.Title+"',");
			}
			if (model.EmployeeID != null)
			{
				strSql1.Append("EmployeeID,");
				strSql2.Append(""+model.EmployeeID+",");
			}
			if (model.SiteID != null)
			{
				strSql1.Append("SiteID,");
				strSql2.Append(""+model.SiteID+",");
			}
			if (model.DepartmentID != null)
			{
				strSql1.Append("DepartmentID,");
				strSql2.Append(""+model.DepartmentID+",");
			}
			if (model.Status != null)
			{
				strSql1.Append("Status,");
				strSql2.Append(""+model.Status+",");
			}
			if (model.Picture != null)
			{
				strSql1.Append("Picture,");
				strSql2.Append(""+model.Picture+",");
			}
			if (model.PersonalPhoneNumber1 != null)
			{
				strSql1.Append("PersonalPhoneNumber1,");
				strSql2.Append("'"+model.PersonalPhoneNumber1+"',");
			}
			if (model.PersonalPhoneNumber2 != null)
			{
				strSql1.Append("PersonalPhoneNumber2,");
				strSql2.Append("'"+model.PersonalPhoneNumber2+"',");
			}
			if (model.EmailAddress != null)
			{
				strSql1.Append("EmailAddress,");
				strSql2.Append("'"+model.EmailAddress+"',");
			}
			if (model.ChangeTimestamp != null)
			{
				strSql1.Append("ChangeTimestamp,");
				strSql2.Append("'"+model.ChangeTimestamp+"',");
			}
			strSql.Append("insert into EmployeesProfile(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");

            int rows = DB_Talk.DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
		public bool Update(DB_Talk.Model.EmployeesProfile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update EmployeesProfile set ");
			if (model.EmployeeName != null)
			{
				strSql.Append("EmployeeName='"+model.EmployeeName+"',");
			}
			if (model.Title != null)
			{
				strSql.Append("Title='"+model.Title+"',");
			}
			if (model.EmployeeID != null)
			{
				strSql.Append("EmployeeID="+model.EmployeeID+",");
			}
			if (model.SiteID != null)
			{
				strSql.Append("SiteID="+model.SiteID+",");
			}
			if (model.DepartmentID != null)
			{
				strSql.Append("DepartmentID="+model.DepartmentID+",");
			}
			if (model.Status != null)
			{
				strSql.Append("Status="+model.Status+",");
			}
			if (model.Picture != null)
			{
				strSql.Append("Picture="+model.Picture+",");
			}
			if (model.PersonalPhoneNumber1 != null)
			{
				strSql.Append("PersonalPhoneNumber1='"+model.PersonalPhoneNumber1+"',");
			}
			if (model.PersonalPhoneNumber2 != null)
			{
				strSql.Append("PersonalPhoneNumber2='"+model.PersonalPhoneNumber2+"',");
			}
			if (model.EmailAddress != null)
			{
				strSql.Append("EmailAddress='"+model.EmailAddress+"',");
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
			strSql.Append("delete from EmployeesProfile ");
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
		public DB_Talk.Model.EmployeesProfile GetModel()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" EmployeeName,Title,EmployeeID,SiteID,DepartmentID,Status,Picture,PersonalPhoneNumber1,PersonalPhoneNumber2,EmailAddress,ChangeTimestamp ");
			strSql.Append(" from EmployeesProfile ");
			strSql.Append(" where " );
			DB_Talk.Model.EmployeesProfile model=new DB_Talk.Model.EmployeesProfile();

            DataSet ds = DB_Talk.DB.OleDbHelper.GetDataSet(strSql.ToString());
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
		public DB_Talk.Model.EmployeesProfile DataRowToModel(DataRow row)
		{
			DB_Talk.Model.EmployeesProfile model=new DB_Talk.Model.EmployeesProfile();
			if (row != null)
			{
				if(row["EmployeeName"]!=null)
				{
					model.EmployeeName=row["EmployeeName"].ToString();
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["EmployeeID"]!=null && row["EmployeeID"].ToString()!="")
				{
					model.EmployeeID=int.Parse(row["EmployeeID"].ToString());
				}
				if(row["SiteID"]!=null && row["SiteID"].ToString()!="")
				{
					model.SiteID=int.Parse(row["SiteID"].ToString());
				}
				if(row["DepartmentID"]!=null && row["DepartmentID"].ToString()!="")
				{
					model.DepartmentID=int.Parse(row["DepartmentID"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["Picture"]!=null && row["Picture"].ToString()!="")
				{
					model.Picture=(byte[])row["Picture"];
				}
				if(row["PersonalPhoneNumber1"]!=null)
				{
					model.PersonalPhoneNumber1=row["PersonalPhoneNumber1"].ToString();
				}
				if(row["PersonalPhoneNumber2"]!=null)
				{
					model.PersonalPhoneNumber2=row["PersonalPhoneNumber2"].ToString();
				}
				if(row["EmailAddress"]!=null)
				{
					model.EmailAddress=row["EmailAddress"].ToString();
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
			strSql.Append("select EmployeeName,Title,EmployeeID,SiteID,DepartmentID,Status,Picture,PersonalPhoneNumber1,PersonalPhoneNumber2,EmailAddress,ChangeTimestamp ");
			strSql.Append(" FROM EmployeesProfile ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return DB_Talk.DB.OleDbHelper.GetDataSet(strSql.ToString());
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
			strSql.Append(" EmployeeName,Title,EmployeeID,SiteID,DepartmentID,Status,Picture,PersonalPhoneNumber1,PersonalPhoneNumber2,EmailAddress,ChangeTimestamp ");
			strSql.Append(" FROM EmployeesProfile ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            return DB_Talk.DB.OleDbHelper.GetDataSet(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM EmployeesProfile ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            object obj = DB_Talk.DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
			strSql.Append(")AS Row, T.*  from EmployeesProfile T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DB_Talk.DB.OleDbHelper.GetDataSet(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
		#region  MethodEx

		#endregion  MethodEx
	}
}

