using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_TeleBill.Model 
{

    /// <summary>
	/// m_CDR
	/// </summary>	
	public class m_CDR
	{
	    public m_CDR()
		{}
	    #region Model  
      	private int _id;     
		private string _vc_callingnum;     
		private string _vc_callednum;     
		private DateTime? _dt_setuptime;     
		private DateTime? _dt_connecttime;     
		private DateTime? _dt_answertime;     
		private DateTime? _dt_disconnecttime;     
		private DateTime? _dt_remotedisconnectime;     
		private long? _i_duration;     
		private string _vc_hostip;     
		private string _vc_visitip;     
		private int? _i_rpc;     
		private int? _i_rpno;     
		private int? _i_serviceprovider;     
		private int? _i_calltype;     
		private int? _i_talktype;     
		private long? _i_chargevalue;     
		private string _vc_memo;     
		private int? _i_flag;     
				
		/// <summary>
		/// ID
        /// </summary>		
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// 主叫号码
        /// </summary>		
        public string vc_CallingNum
        {
            get{ return _vc_callingnum; }
            set{ _vc_callingnum = value; }
        }        
		/// <summary>
		/// 被叫号码
        /// </summary>		
        public string vc_CalledNum
        {
            get{ return _vc_callednum; }
            set{ _vc_callednum = value; }
        }        
		/// <summary>
		/// dt_SetupTime
        /// </summary>		
        public DateTime? dt_SetupTime
        {
            get{ return _dt_setuptime; }
            set{ _dt_setuptime = value; }
        }        
		/// <summary>
		/// dt_ConnectTime
        /// </summary>		
        public DateTime? dt_ConnectTime
        {
            get{ return _dt_connecttime; }
            set{ _dt_connecttime = value; }
        }        
		/// <summary>
		/// dt_AnswerTime
        /// </summary>		
        public DateTime? dt_AnswerTime
        {
            get{ return _dt_answertime; }
            set{ _dt_answertime = value; }
        }        
		/// <summary>
		/// dt_DisconnectTime
        /// </summary>		
        public DateTime? dt_DisconnectTime
        {
            get{ return _dt_disconnecttime; }
            set{ _dt_disconnecttime = value; }
        }        
		/// <summary>
		/// dt_RemoteDisconnecTime
        /// </summary>		
        public DateTime? dt_RemoteDisconnecTime
        {
            get{ return _dt_remotedisconnectime; }
            set{ _dt_remotedisconnectime = value; }
        }        
		/// <summary>
		/// 呼叫时长
        /// </summary>		
        public long? i_Duration
        {
            get{ return _i_duration; }
            set{ _i_duration = value; }
        }        
		/// <summary>
		/// vc_HostIP
        /// </summary>		
        public string vc_HostIP
        {
            get{ return _vc_hostip; }
            set{ _vc_hostip = value; }
        }        
		/// <summary>
		/// vc_VisitIP
        /// </summary>		
        public string vc_VisitIP
        {
            get{ return _vc_visitip; }
            set{ _vc_visitip = value; }
        }        
		/// <summary>
		/// i_rpc
        /// </summary>		
        public int? i_rpc
        {
            get{ return _i_rpc; }
            set{ _i_rpc = value; }
        }        
		/// <summary>
		/// i_rpno
        /// </summary>		
        public int? i_rpno
        {
            get{ return _i_rpno; }
            set{ _i_rpno = value; }
        }        
		/// <summary>
		/// 运营商，1移动，2联通，3电信
        /// </summary>		
        public int? i_ServiceProvider
        {
            get{ return _i_serviceprovider; }
            set{ _i_serviceprovider = value; }
        }        
		/// <summary>
		/// 呼叫类型，本地主叫0，漫游主叫1，本地被叫2，漫游被叫3，本地数据4，漫游数据5
        /// </summary>		
        public int? i_CallType
        {
            get{ return _i_calltype; }
            set{ _i_calltype = value; }
        }        
		/// <summary>
		/// 通话类型，网内通话，市话，国内长途，国际长途，漫游
        /// </summary>		
        public int? i_TalkType
        {
            get{ return _i_talktype; }
            set{ _i_talktype = value; }
        }        
		/// <summary>
		/// 费用
        /// </summary>		
        public long? i_ChargeValue
        {
            get{ return _i_chargevalue; }
            set{ _i_chargevalue = value; }
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
		/// i_Flag
        /// </summary>		
        public int? i_Flag
        {
            get{ return _i_flag; }
            set{ _i_flag = value; }
        }        
		#endregion
	}
}