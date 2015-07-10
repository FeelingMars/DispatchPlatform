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
namespace DB_Talk.Model
{
	/// <summary>
	/// m_CameraInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_CameraInfo
	{
		public m_CameraInfo()
		{}
		#region Model
		private int _id;
		private int? _boxid;
		private string _vc_name;
		private string _vc_memo;
		private int? _i_chanelid;
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
		public string vc_Name
		{
			set{ _vc_name=value;}
			get{return _vc_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string vc_Memo
		{
			set{ _vc_memo=value;}
			get{return _vc_memo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? i_ChanelID
		{
			set{ _i_chanelid=value;}
			get{return _i_chanelid;}
		}
		#endregion Model

	}
}

