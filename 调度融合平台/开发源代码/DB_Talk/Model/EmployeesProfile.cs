using System;
namespace DB_Talk.Model
{
	/// <summary>
	/// EmployeesProfile:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EmployeesProfile
	{
		public EmployeesProfile()
		{}
		#region Model
		private string _employeename;
		private string _title;
		private int _employeeid;
		private int _siteid;
		private int _departmentid;
		private int _status;
		private byte[] _picture;
		private string _personalphonenumber1;
		private string _personalphonenumber2;
		private string _emailaddress;
		private DateTime _changetimestamp;
		/// <summary>
		/// 
		/// </summary>
		public string EmployeeName
		{
			set{ _employeename=value;}
			get{return _employeename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int EmployeeID
		{
			set{ _employeeid=value;}
			get{return _employeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SiteID
		{
			set{ _siteid=value;}
			get{return _siteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DepartmentID
		{
			set{ _departmentid=value;}
			get{return _departmentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] Picture
		{
			set{ _picture=value;}
			get{return _picture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PersonalPhoneNumber1
		{
			set{ _personalphonenumber1=value;}
			get{return _personalphonenumber1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PersonalPhoneNumber2
		{
			set{ _personalphonenumber2=value;}
			get{return _personalphonenumber2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmailAddress
		{
			set{ _emailaddress=value;}
			get{return _emailaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ChangeTimestamp
		{
			set{ _changetimestamp=value;}
			get{return _changetimestamp;}
		}
		#endregion Model

	}
}

