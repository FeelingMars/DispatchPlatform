using System;
namespace DB_Talk.Model
{
	/// <summary>
	/// SubscriberProfile:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SubscriberProfile
	{
		public SubscriberProfile()
		{}
		#region Model
		private int _siteid;
		private int _subscriberid;
		private int _employeeid;
		private int _spmsubindex;
		private string _subscribernumber;
		private string _spmpsnumber;
		private string _spmauthkey;
		private int _spmsubtype;
		private int _record;
		private string _spmpsidentification;
		private string _spmdidnumber;
		private int _spmsubsuppservice;
		private string _spmsubgroup;
		private int _spmsubpriority;
		private string _spmfxsport;
		private string _spmsubcfunumber;
		private string _spmsubcfbnumber;
		private string _spmsubcfnrnumber;
		private string _spmsubcfurnumber;
		private string _spmassociationnumber1;
		private string _spmassociationnumber2;
		private string _spmsubpassword;
		private int _spmsubpasswordlevel;
		private int _spmsubpasswordstatus;
		private string _spmfxoport;
		private int _spmactimehour;
		private int _spmactimeminute;
		private int _spmsubstatus;
		private int _spmsubblockstatus;
		private int _spmsubinumberservicestatus;
		private int _dispatchlevel;
		private DateTime _changetimestamp;
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
		public int SubscriberID
		{
			set{ _subscriberid=value;}
			get{return _subscriberid;}
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
		public int SPMSubIndex
		{
			set{ _spmsubindex=value;}
			get{return _spmsubindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SubscriberNumber
		{
			set{ _subscribernumber=value;}
			get{return _subscribernumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMPSNumber
		{
			set{ _spmpsnumber=value;}
			get{return _spmpsnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMAuthKey
		{
			set{ _spmauthkey=value;}
			get{return _spmauthkey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SPMSubType
		{
			set{ _spmsubtype=value;}
			get{return _spmsubtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Record
		{
			set{ _record=value;}
			get{return _record;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMPSIdentification
		{
			set{ _spmpsidentification=value;}
			get{return _spmpsidentification;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMDIDNumber
		{
			set{ _spmdidnumber=value;}
			get{return _spmdidnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SPMSubSuppService
		{
			set{ _spmsubsuppservice=value;}
			get{return _spmsubsuppservice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMSubGroup
		{
			set{ _spmsubgroup=value;}
			get{return _spmsubgroup;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SPMSubPriority
		{
			set{ _spmsubpriority=value;}
			get{return _spmsubpriority;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMFXSPort
		{
			set{ _spmfxsport=value;}
			get{return _spmfxsport;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMSubCfuNumber
		{
			set{ _spmsubcfunumber=value;}
			get{return _spmsubcfunumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMSubCfbNumber
		{
			set{ _spmsubcfbnumber=value;}
			get{return _spmsubcfbnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMSubCfnrNumber
		{
			set{ _spmsubcfnrnumber=value;}
			get{return _spmsubcfnrnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMSubCfurNumber
		{
			set{ _spmsubcfurnumber=value;}
			get{return _spmsubcfurnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMAssociationNumber1
		{
			set{ _spmassociationnumber1=value;}
			get{return _spmassociationnumber1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMAssociationNumber2
		{
			set{ _spmassociationnumber2=value;}
			get{return _spmassociationnumber2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMSubPassword
		{
			set{ _spmsubpassword=value;}
			get{return _spmsubpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SPMSubPasswordLevel
		{
			set{ _spmsubpasswordlevel=value;}
			get{return _spmsubpasswordlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SPMSubPasswordStatus
		{
			set{ _spmsubpasswordstatus=value;}
			get{return _spmsubpasswordstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SPMFXOPort
		{
			set{ _spmfxoport=value;}
			get{return _spmfxoport;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SPMACTimeHour
		{
			set{ _spmactimehour=value;}
			get{return _spmactimehour;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SPMACTimeMinute
		{
			set{ _spmactimeminute=value;}
			get{return _spmactimeminute;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SPMSubStatus
		{
			set{ _spmsubstatus=value;}
			get{return _spmsubstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SPMSubBlockStatus
		{
			set{ _spmsubblockstatus=value;}
			get{return _spmsubblockstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SPMSubInumberServiceStatus
		{
			set{ _spmsubinumberservicestatus=value;}
			get{return _spmsubinumberservicestatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int DispatchLevel
		{
			set{ _dispatchlevel=value;}
			get{return _dispatchlevel;}
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

