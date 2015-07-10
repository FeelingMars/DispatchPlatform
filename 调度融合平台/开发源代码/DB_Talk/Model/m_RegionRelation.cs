/**  版本信息模板在安装目录下，可自行修改。
* m_RegionRelation.cs
*
* 功 能： N/A
* 类 名： m_RegionRelation
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
namespace DB_Talk.Model
{
	/// <summary>
	/// m_RegionRelation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_RegionRelation
	{
		public m_RegionRelation()
		{}
		#region Model
		private int _id;
		private int? _boxid;
		private string _regionid;
		private int? _i_relationtype;
		private int? _relationid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BoxID
		{
			set{ _boxid=value;}
			get{return _boxid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RegionID
		{
			set{ _regionid=value;}
			get{return _regionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_RelationType
		{
			set{ _i_relationtype=value;}
			get{return _i_relationtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RelationID
		{
			set{ _relationid=value;}
			get{return _relationid;}
		}
		#endregion Model

	}
}

