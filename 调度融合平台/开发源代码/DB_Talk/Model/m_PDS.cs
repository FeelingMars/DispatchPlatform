using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_PDS
	/// </summary>	
	public class m_PDS
	{
	    public m_PDS()
		{}
	    #region Model  
      	private int _id;     
		private int _pdsid;     
		private int _boxid;     
		private string _vc_ip;     
		private int? _i_confstate;     
		private int? _i_operatestate;     
		private int? _i_idlegtpchannelcount;     
		private int? _i_busygtpchannelcount;     
		private int? _i_idlevideochannelcount;     
		private int? _i_busyvideochannelcount;     
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
		/// PdsID
        /// </summary>		
        public int PdsID
        {
            get{ return _pdsid; }
            set{ _pdsid = value; }
        }        
		/// <summary>
		/// BoxID
        /// </summary>		
        public int BoxID
        {
            get{ return _boxid; }
            set{ _boxid = value; }
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
		/// 1未激活，2激活
        /// </summary>		
        public int? i_ConfState
        {
            get{ return _i_confstate; }
            set{ _i_confstate = value; }
        }        
		/// <summary>
		/// i_OperateState
        /// </summary>		
        public int? i_OperateState
        {
            get{ return _i_operatestate; }
            set{ _i_operatestate = value; }
        }        
		/// <summary>
		/// i_IdleGtpChannelCount
        /// </summary>		
        public int? i_IdleGtpChannelCount
        {
            get{ return _i_idlegtpchannelcount; }
            set{ _i_idlegtpchannelcount = value; }
        }        
		/// <summary>
		/// i_BusyGtpChannelCount
        /// </summary>		
        public int? i_BusyGtpChannelCount
        {
            get{ return _i_busygtpchannelcount; }
            set{ _i_busygtpchannelcount = value; }
        }        
		/// <summary>
		/// i_IdleVideoChannelCount
        /// </summary>		
        public int? i_IdleVideoChannelCount
        {
            get{ return _i_idlevideochannelcount; }
            set{ _i_idlevideochannelcount = value; }
        }        
		/// <summary>
		/// i_BusyVideoChannelCount
        /// </summary>		
        public int? i_BusyVideoChannelCount
        {
            get{ return _i_busyvideochannelcount; }
            set{ _i_busyvideochannelcount = value; }
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