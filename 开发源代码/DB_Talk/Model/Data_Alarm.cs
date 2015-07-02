using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// Data_Alarm
	/// </summary>	
	public class Data_Alarm
	{
	    public Data_Alarm()
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
		private int? _i_alarmentityinstanceshelf;     
		private int? _i_alarmentityinstanceslot;     
		private int? _i_alarmentityinstanceport;     
		private int? _i_alarmclass;     
		private int? _i_alarmseverity;     
		private int? _i_alarmackflag;     
				
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
		/// 机框ID，i_AlarmEntityInstance的高16bit的前6bit
        /// </summary>		
        public int? i_AlarmEntityInstanceShelf
        {
            get{ return _i_alarmentityinstanceshelf; }
            set{ _i_alarmentityinstanceshelf = value; }
        }        
		/// <summary>
		/// 插槽ID，i_AlarmEntityInstance的高16bit的前第6-10 bit
        /// </summary>		
        public int? i_AlarmEntityInstanceSlot
        {
            get{ return _i_alarmentityinstanceslot; }
            set{ _i_alarmentityinstanceslot = value; }
        }        
		/// <summary>
		/// 端口ID，i_AlarmEntityInstance的高16bit的低5bit
        /// </summary>		
        public int? i_AlarmEntityInstancePort
        {
            get{ return _i_alarmentityinstanceport; }
            set{ _i_alarmentityinstanceport = value; }
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
		#endregion
	}
}