/**  版本信息模板在安装目录下，可自行修改。
* m_CameraInfo.cs
*
* 功 能： N/A
* 类 名： m_CameraInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/7/8 16:54:36   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using DB_Talk.Model;
namespace DB_Talk.BLL
{
	/// <summary>
	/// m_CameraInfo
	/// </summary>
	public partial class m_CameraInfo
	{
		private readonly DB_Talk.DAL.m_CameraInfo dal=new DB_Talk.DAL.m_CameraInfo();
		public m_CameraInfo()
		{}
		#region  Method


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DB_Talk.Model.m_CameraInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DB_Talk.Model.m_CameraInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DB_Talk.Model.m_CameraInfo GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DB_Talk.Model.m_CameraInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DB_Talk.Model.m_CameraInfo> DataTableToList(DataTable dt)
		{
			List<DB_Talk.Model.m_CameraInfo> modelList = new List<DB_Talk.Model.m_CameraInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DB_Talk.Model.m_CameraInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DB_Talk.Model.m_CameraInfo();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["BoxID"]!=null && dt.Rows[n]["BoxID"].ToString()!="")
					{
						model.BoxID=int.Parse(dt.Rows[n]["BoxID"].ToString());
					}
					if(dt.Rows[n]["vc_Name"]!=null && dt.Rows[n]["vc_Name"].ToString()!="")
					{
					model.vc_Name=dt.Rows[n]["vc_Name"].ToString();
					}
					if(dt.Rows[n]["vc_Memo"]!=null && dt.Rows[n]["vc_Memo"].ToString()!="")
					{
					model.vc_Memo=dt.Rows[n]["vc_Memo"].ToString();
					}
					if(dt.Rows[n]["i_ChanelID"]!=null && dt.Rows[n]["i_ChanelID"].ToString()!="")
					{
						model.i_ChanelID=int.Parse(dt.Rows[n]["i_ChanelID"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

