using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// Data_SystemLog
	/// </summary>	
	public class Data_SystemLog
	{
	    public Data_SystemLog()
		{}
	    #region Model  
      	private int _id;     
		private int? _boxid;     
		private int? _managerid;     
		private string _vc_ip;     
		private int? _actiontypeid;     
		private string _vc_title;     
		private string _vc_description;     
		private int? _i_result;     
		private DateTime? _dt_datetime;     
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
		/// vc_IP
        /// </summary>		
        public string vc_IP
        {
            get{ return _vc_ip; }
            set{ _vc_ip = value; }
        }        
		/// <summary>
		/// ActionTypeID
        /// </summary>		
        public int? ActionTypeID
        {
            get{ return _actiontypeid; }
            set{ _actiontypeid = value; }
        }        
		/// <summary>
		/// vc_Title
        /// </summary>		
        public string vc_Title
        {
            get{ return _vc_title; }
            set{ _vc_title = value; }
        }        
		/// <summary>
		/// vc_Description
        /// </summary>		
        public string vc_Description
        {
            get{ return _vc_description; }
            set{ _vc_description = value; }
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
		/// dt_DateTime
        /// </summary>		
        public DateTime? dt_DateTime
        {
            get{ return _dt_datetime; }
            set{ _dt_datetime = value; }
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