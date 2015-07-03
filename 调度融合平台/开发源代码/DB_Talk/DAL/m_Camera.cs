﻿/**  版本信息模板在安装目录下，可自行修改。
* m_Camera.cs
*
* 功 能： N/A
* 类 名： m_Camera
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/22 10:26:09   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DB_Talk.DAL
{
	/// <summary>
	/// 数据访问类:m_Camera
	/// </summary>
	public partial class m_Camera
	{
		public m_Camera()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DB_Talk.Model.m_Camera model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.vc_Name != null)
			{
				strSql1.Append("vc_Name,");
				strSql2.Append("'"+model.vc_Name+"',");
			}
			if (model.vc_IP != null)
			{
				strSql1.Append("vc_IP,");
				strSql2.Append("'"+model.vc_IP+"',");
			}
			if (model.vc_Memo != null)
			{
				strSql1.Append("vc_Memo,");
				strSql2.Append("'"+model.vc_Memo+"',");
			}
			if (model.i_Flag != null)
			{
				strSql1.Append("i_Flag,");
				strSql2.Append(""+model.i_Flag+",");
			}
			strSql.Append("insert into m_Camera(");
			strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
			strSql.Append(")");
			strSql.Append(" values (");
			strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
			strSql.Append(")");
			strSql.Append(";select @@IDENTITY");
			object obj = DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
		/// 更新一条数据
		/// </summary>
		public bool Update(DB_Talk.Model.m_Camera model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update m_Camera set ");
			if (model.vc_Name != null)
			{
				strSql.Append("vc_Name='"+model.vc_Name+"',");
			}
			if (model.vc_IP != null)
			{
				strSql.Append("vc_IP='"+model.vc_IP+"',");
			}
			if (model.vc_Memo != null)
			{
				strSql.Append("vc_Memo='"+model.vc_Memo+"',");
			}
			else
			{
				strSql.Append("vc_Memo= null ,");
			}
			if (model.i_Flag != null)
			{
				strSql.Append("i_Flag="+model.i_Flag+",");
			}
			else
			{
				strSql.Append("i_Flag= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where ID="+ model.ID+"");
			int rowsAffected=DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
		public bool Delete(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_Camera ");
			strSql.Append(" where ID="+ID+"" );
			int rowsAffected=DB.OleDbHelper.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from m_Camera ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DB.OleDbHelper.ExecuteSql(strSql.ToString());
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
		public DB_Talk.Model.m_Camera GetModel(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" ID,vc_Name,vc_IP,vc_Memo,i_Flag ");
			strSql.Append(" from m_Camera ");
			strSql.Append(" where ID="+ID+"" );
			DB_Talk.Model.m_Camera model=new DB_Talk.Model.m_Camera();
			DataSet ds=DB.OleDbHelper.GetDataSet(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["vc_Name"]!=null && ds.Tables[0].Rows[0]["vc_Name"].ToString()!="")
				{
					model.vc_Name=ds.Tables[0].Rows[0]["vc_Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vc_IP"]!=null && ds.Tables[0].Rows[0]["vc_IP"].ToString()!="")
				{
					model.vc_IP=ds.Tables[0].Rows[0]["vc_IP"].ToString();
				}
				if(ds.Tables[0].Rows[0]["vc_Memo"]!=null && ds.Tables[0].Rows[0]["vc_Memo"].ToString()!="")
				{
					model.vc_Memo=ds.Tables[0].Rows[0]["vc_Memo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["i_Flag"]!=null && ds.Tables[0].Rows[0]["i_Flag"].ToString()!="")
				{
					model.i_Flag=int.Parse(ds.Tables[0].Rows[0]["i_Flag"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,vc_Name,vc_IP,vc_Memo,i_Flag ");
			strSql.Append(" FROM m_Camera ");
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
			strSql.Append(" ID,vc_Name,vc_IP,vc_Memo,i_Flag ");
			strSql.Append(" FROM m_Camera ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DB.OleDbHelper.GetDataSet(strSql.ToString());
		}

		/*
		*/

		#endregion  Method
	}
}

