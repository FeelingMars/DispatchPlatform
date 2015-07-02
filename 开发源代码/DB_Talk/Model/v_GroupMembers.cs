using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// v_GroupMembers
	/// </summary>	
	public class v_GroupMembers
	{
	    public v_GroupMembers()
		{}
	    #region Model  
      	private int _id;     
		private int _boxid;     
		private int? _groupid;     
		private int? _memberid;     
		private int? _i_flag;     
		private int? _i_number;     
		private string _vc_name;     
		private int? _levelid;     
		private int? _numbertypeid;     
		private int? _i_telltype;     
		private int? _departmentid;     
		private string _vc_mac;     
		private string _vc_memo;     
		private string _groupname;     
		private int? _grouptypeid;     
				
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
        public int BoxID
        {
            get{ return _boxid; }
            set{ _boxid = value; }
        }        
		/// <summary>
		/// GroupID
        /// </summary>		
        public int? GroupID
        {
            get{ return _groupid; }
            set{ _groupid = value; }
        }        
		/// <summary>
		/// MemberID
        /// </summary>		
        public int? MemberID
        {
            get{ return _memberid; }
            set{ _memberid = value; }
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
		/// i_Number
        /// </summary>		
        public int? i_Number
        {
            get{ return _i_number; }
            set{ _i_number = value; }
        }        
		/// <summary>
		/// vc_Name
        /// </summary>		
        public string vc_Name
        {
            get{ return _vc_name; }
            set{ _vc_name = value; }
        }        
		/// <summary>
		/// LevelID
        /// </summary>		
        public int? LevelID
        {
            get{ return _levelid; }
            set{ _levelid = value; }
        }        
		/// <summary>
		/// NumberTypeID
        /// </summary>		
        public int? NumberTypeID
        {
            get{ return _numbertypeid; }
            set{ _numbertypeid = value; }
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
		/// DepartmentID
        /// </summary>		
        public int? DepartmentID
        {
            get{ return _departmentid; }
            set{ _departmentid = value; }
        }        
		/// <summary>
		/// vc_MAC
        /// </summary>		
        public string vc_MAC
        {
            get{ return _vc_mac; }
            set{ _vc_mac = value; }
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
		/// GroupName
        /// </summary>		
        public string GroupName
        {
            get{ return _groupname; }
            set{ _groupname = value; }
        }        
		/// <summary>
		/// 0表示用户，1表示会议，2表示短信
        /// </summary>		
        public int? GroupTypeID
        {
            get{ return _grouptypeid; }
            set{ _grouptypeid = value; }
        }        
		#endregion
	}
}