
using System;
namespace DB_Talk.Model
{
	/// <summary>
	/// m_SmsLog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class m_SmsLog
	{
		public m_SmsLog()
		{}
		#region Model
		private int _id;
		private string _number;
		private string _departments;
		private DateTime _sendtimer;
		private int? _stats;
		private string _i_flag;
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Departments
		{
			set{ _departments=value;}
			get{return _departments;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime SendTimer
		{
			set{ _sendtimer=value;}
			get{return _sendtimer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Stats
		{
			set{ _stats=value;}
			get{return _stats;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string i_Flag
		{
			set{ _i_flag=value;}
			get{return _i_flag;}
		}
		#endregion Model

	}
}

