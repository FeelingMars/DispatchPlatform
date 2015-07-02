using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// v_DispatchLog
	/// </summary>	
	public class v_DispatchLog
	{
	    public v_DispatchLog()
		{}
	    #region Model  
      	private int _id;     
		private int? _boxid;     
		private int? _managerid;     
		private DateTime? _dt_datetime;     
		private int? _dispatchnumber;     
		private int? _dispatchtypeid;     
		private string _dispatchednumbers;     
		private int? _i_result;     
		private int? _i_state;     
		private string _vc_memo;     
		private string _username;     
		private string _boxname;     
		private string _actiontype;     
		private string _result;     
				
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
		/// ManagerID
        /// </summary>		
        public int? ManagerID
        {
            get{ return _managerid; }
            set{ _managerid = value; }
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
		/// DispatchNumber
        /// </summary>		
        public int? DispatchNumber
        {
            get{ return _dispatchnumber; }
            set{ _dispatchnumber = value; }
        }        
		/// <summary>
		/// DispatchTypeID
        /// </summary>		
        public int? DispatchTypeID
        {
            get{ return _dispatchtypeid; }
            set{ _dispatchtypeid = value; }
        }        
		/// <summary>
		/// DispatchedNumbers
        /// </summary>		
        public string DispatchedNumbers
        {
            get{ return _dispatchednumbers; }
            set{ _dispatchednumbers = value; }
        }        
		/// <summary>
		/// i_Result
        /// </summary>		
        public int? i_Result
        {
            get{ return _i_result; }
            set{ _i_result = value; }
        }        
		/// <summary>
		/// i_State
        /// </summary>		
        public int? i_State
        {
            get{ return _i_state; }
            set{ _i_state = value; }
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
		/// UserName
        /// </summary>		
        public string UserName
        {
            get{ return _username; }
            set{ _username = value; }
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
		/// ActionType
        /// </summary>		
        public string ActionType
        {
            get{ return _actiontype; }
            set{ _actiontype = value; }
        }        
		/// <summary>
		/// Result
        /// </summary>		
        public string Result
        {
            get{ return _result; }
            set{ _result = value; }
        }        
		#endregion
	}
}