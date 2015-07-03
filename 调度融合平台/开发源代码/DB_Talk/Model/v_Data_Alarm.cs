using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// v_Data_Alarm
	/// </summary>	
	public class v_Data_Alarm
	{
	    public v_Data_Alarm()
		{}
	    #region Model  
      	private int _id;     
		private int? _boxid;     
		private DateTime? _dt_datetime;     
		private int? _alarmtypeid;     
		private string _vc_memo;     
		private int? _i_alarmseriesnumber;     
		private int? _i_alarminfo;     
		private int? _i_alarminfodetail;     
		private int? _i_alarmentitytype;     
		private int? _i_alarmentityinstance;     
		private int? _i_alarmclass;     
		private int? _i_alarmseverity;     
		private int? _i_alarmackflag;     
		private string _alarmclass;     
		private string _alarmseverity;     
		private string _alarmack;     
		private string _alarmentityinstance;     
		private string _alarminfo;     
		private string _alarmdetail;     
		private string _alarmentitytype;     
		private string _boxname;     
		private string _vc_ip;     
		private string _vc_sn;     
				
		/// <summary>
		/// ID
        /// </summary>		
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// BoxID
        /// </summary>		
        public int? BoxID
        {
            get{ return _boxid; }
            set{ _boxid = value; }
        }        
		/// <summary>
		/// dt_DateTime
        /// </summary>		
        public DateTime? dt_DateTime
        {
            get{ return _dt_datetime; }
            set{ _dt_datetime = value; }
        }        
		/// <summary>
		/// AlarmTypeID
        /// </summary>		
        public int? AlarmTypeID
        {
            get{ return _alarmtypeid; }
            set{ _alarmtypeid = value; }
        }        
		/// <summary>
		/// vc_Memo
        /// </summary>		
        public string vc_Memo
        {
            get{ return _vc_memo; }
            set{ _vc_memo = value; }
        }        
		/// <summary>
		/// i_AlarmSeriesNumber
        /// </summary>		
        public int? i_AlarmSeriesNumber
        {
            get{ return _i_alarmseriesnumber; }
            set{ _i_alarmseriesnumber = value; }
        }        
		/// <summary>
		/// i_AlarmInfo
        /// </summary>		
        public int? i_AlarmInfo
        {
            get{ return _i_alarminfo; }
            set{ _i_alarminfo = value; }
        }        
		/// <summary>
		/// i_AlarmInfoDetail
        /// </summary>		
        public int? i_AlarmInfoDetail
        {
            get{ return _i_alarminfodetail; }
            set{ _i_alarminfodetail = value; }
        }        
		/// <summary>
		/// i_AlarmEntityType
        /// </summary>		
        public int? i_AlarmEntityType
        {
            get{ return _i_alarmentitytype; }
            set{ _i_alarmentitytype = value; }
        }        
		/// <summary>
		/// i_AlarmEntityInstance
        /// </summary>		
        public int? i_AlarmEntityInstance
        {
            get{ return _i_alarmentityinstance; }
            set{ _i_alarmentityinstance = value; }
        }        
		/// <summary>
		/// i_AlarmClass
        /// </summary>		
        public int? i_AlarmClass
        {
            get{ return _i_alarmclass; }
            set{ _i_alarmclass = value; }
        }        
		/// <summary>
		/// i_AlarmSeverity
        /// </summary>		
        public int? i_AlarmSeverity
        {
            get{ return _i_alarmseverity; }
            set{ _i_alarmseverity = value; }
        }        
		/// <summary>
		/// i_AlarmAckFlag
        /// </summary>		
        public int? i_AlarmAckFlag
        {
            get{ return _i_alarmackflag; }
            set{ _i_alarmackflag = value; }
        }        
		/// <summary>
		/// AlarmClass
        /// </summary>		
        public string AlarmClass
        {
            get{ return _alarmclass; }
            set{ _alarmclass = value; }
        }        
		/// <summary>
		/// AlarmSeverity
        /// </summary>		
        public string AlarmSeverity
        {
            get{ return _alarmseverity; }
            set{ _alarmseverity = value; }
        }        
		/// <summary>
		/// AlarmAck
        /// </summary>		
        public string AlarmAck
        {
            get{ return _alarmack; }
            set{ _alarmack = value; }
        }        
		/// <summary>
		/// AlarmEntityInstance
        /// </summary>		
        public string AlarmEntityInstance
        {
            get{ return _alarmentityinstance; }
            set{ _alarmentityinstance = value; }
        }        
		/// <summary>
		/// AlarmInfo
        /// </summary>		
        public string AlarmInfo
        {
            get{ return _alarminfo; }
            set{ _alarminfo = value; }
        }        
		/// <summary>
		/// AlarmDetail
        /// </summary>		
        public string AlarmDetail
        {
            get{ return _alarmdetail; }
            set{ _alarmdetail = value; }
        }        
		/// <summary>
		/// AlarmEntityType
        /// </summary>		
        public string AlarmEntityType
        {
            get{ return _alarmentitytype; }
            set{ _alarmentitytype = value; }
        }        
		/// <summary>
		/// BoxName
        /// </summary>		
        public string BoxName
        {
            get{ return _boxname; }
            set{ _boxname = value; }
        }        
		/// <summary>
		/// vc_IP
        /// </summary>		
        public string vc_IP
        {
            get{ return _vc_ip; }
            set{ _vc_ip = value; }
        }        
		/// <summary>
		/// vc_SN
        /// </summary>		
        public string vc_SN
        {
            get{ return _vc_sn; }
            set{ _vc_sn = value; }
        }        
		#endregion
	}
}