using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_Manager
	/// </summary>	
	public class m_Manager
	{
	    public m_Manager()
		{}
	    #region Model  
      	private int _id;     
		private int? _boxid;     
		private string _vc_username;     
		private string _vc_password;     
		private long? _leftdispatchnumber;
        private long? _rightdispatchnumber;     
		private string _leftdispatchname;     
		private string _rightdispatchname;     
		private int? _i_net;     
		private int? _i_operate;     
		private int? _i_dispatch;     
		private DateTime? _dt_createtime;     
		private string _vc_memo;     
		private int? _i_flag;     
		private int? _i_telltype;     
		private int? _i_isdispatch;     
		private string _vc_boxid;     
				
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
		/// vc_UserName
        /// </summary>		
        public string vc_UserName
        {
            get{ return _vc_username; }
            set{ _vc_username = value; }
        }        
		/// <summary>
		/// vc_Password
        /// </summary>		
        public string vc_Password
        {
            get{ return _vc_password; }
            set{ _vc_password = value; }
        }        
		/// <summary>
		/// LeftDispatchNumber
        /// </summary>		
        public long? LeftDispatchNumber
        {
            get{ return _leftdispatchnumber; }
            set{ _leftdispatchnumber = value; }
        }        
		/// <summary>
		/// RightDispatchNumber
        /// </summary>		
        public long? RightDispatchNumber
        {
            get{ return _rightdispatchnumber; }
            set{ _rightdispatchnumber = value; }
        }        
		/// <summary>
		/// LeftDispatchName
        /// </summary>		
        public string LeftDispatchName
        {
            get{ return _leftdispatchname; }
            set{ _leftdispatchname = value; }
        }        
		/// <summary>
		/// RightDispatchName
        /// </summary>		
        public string RightDispatchName
        {
            get{ return _rightdispatchname; }
            set{ _rightdispatchname = value; }
        }        
		/// <summary>
		/// i_Net
        /// </summary>		
        public int? i_Net
        {
            get{ return _i_net; }
            set{ _i_net = value; }
        }        
		/// <summary>
		/// i_Operate
        /// </summary>		
        public int? i_Operate
        {
            get{ return _i_operate; }
            set{ _i_operate = value; }
        }        
		/// <summary>
		/// i_Dispatch
        /// </summary>		
        public int? i_Dispatch
        {
            get{ return _i_dispatch; }
            set{ _i_dispatch = value; }
        }        
		/// <summary>
		/// dt_CreateTime
        /// </summary>		
        public DateTime? dt_CreateTime
        {
            get{ return _dt_createtime; }
            set{ _dt_createtime = value; }
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
		/// <summary>
		/// i_TellType
        /// </summary>		
        public int? i_TellType
        {
            get{ return _i_telltype; }
            set{ _i_telltype = value; }
        }        
		/// <summary>
		/// i_IsDispatch
        /// </summary>		
        public int? i_IsDispatch
        {
            get{ return _i_isdispatch; }
            set{ _i_isdispatch = value; }
        }        
		/// <summary>
		/// 可以操作的BoxID
        /// </summary>		
        public string vc_BoxID
        {
            get{ return _vc_boxid; }
            set{ _vc_boxid = value; }
        }        
		#endregion
	}
}