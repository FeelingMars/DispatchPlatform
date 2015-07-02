using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// v_Member
	/// </summary>	
	[Serializable]
	public partial class v_Member
	{
	    public v_Member()
		{}
	    #region Model  
      	private int _id;     
		private int? _boxid;     
		private int? _i_number;     
		private string _vc_name;     
		private int? _levelid;     
		private int? _numbertypeid;     
		private int? _i_telltype;     
		private int? _i_isdispatch;     
		private int? _departmentid;     
		private string _vc_mac;     
		private int? _i_flag;     
		private string _vc_memo;     
		private long? _i_supplementserive;     
		private int? _i_authority;     
		private int? _i_nupassword;     
		private int? _i_nupasswordtype;     
		private int? _i_uncforwardnu;     
		private int? _i_noanswerforward;     
		private int? _i_poweroffforward;     
		private int? _i_busyforward;     
		private int? _i_directnum;     
		private int? _i_isassociateactive;     
		private int? _i_associatenum1;     
		private int? _i_associatenum2;     
		private string _vc_umtski;     
		private string _vc_umtsimsi;     
		private int? _fapid;     
		private string _vc_ip;     
		private string _numberpasswordtype;     
		private string _numbertype;     
		private string _tellauthority;     
		private string _telltype;     
		private string _isdispatch;     
		private string _levelname;     
		private string _deptname;     
		private string _boxname;     
		private string _boxip;     
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
		/// i_IsDispatch
        /// </summary>		
        public int? i_IsDispatch
        {
            get{ return _i_isdispatch; }
            set{ _i_isdispatch = value; }
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
		/// i_Flag
        /// </summary>		
        public int? i_Flag
        {
            get{ return _i_flag; }
            set{ _i_flag = value; }
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
		/// i_supplementSerive
        /// </summary>		
        public long? i_supplementSerive
        {
            get{ return _i_supplementserive; }
            set{ _i_supplementserive = value; }
        }        
		/// <summary>
		/// i_Authority
        /// </summary>		
        public int? i_Authority
        {
            get{ return _i_authority; }
            set{ _i_authority = value; }
        }        
		/// <summary>
		/// i_NuPassword
        /// </summary>		
        public int? i_NuPassword
        {
            get{ return _i_nupassword; }
            set{ _i_nupassword = value; }
        }        
		/// <summary>
		/// i_NuPasswordType
        /// </summary>		
        public int? i_NuPasswordType
        {
            get{ return _i_nupasswordtype; }
            set{ _i_nupasswordtype = value; }
        }        
		/// <summary>
		/// i_UnCForwardNu
        /// </summary>		
        public int? i_UnCForwardNu
        {
            get{ return _i_uncforwardnu; }
            set{ _i_uncforwardnu = value; }
        }        
		/// <summary>
		/// i_NoAnswerForward
        /// </summary>		
        public int? i_NoAnswerForward
        {
            get{ return _i_noanswerforward; }
            set{ _i_noanswerforward = value; }
        }        
		/// <summary>
		/// i_PowerOffForward
        /// </summary>		
        public int? i_PowerOffForward
        {
            get{ return _i_poweroffforward; }
            set{ _i_poweroffforward = value; }
        }        
		/// <summary>
		/// i_BusyForward
        /// </summary>		
        public int? i_BusyForward
        {
            get{ return _i_busyforward; }
            set{ _i_busyforward = value; }
        }        
		/// <summary>
		/// i_DirectNum
        /// </summary>		
        public int? i_DirectNum
        {
            get{ return _i_directnum; }
            set{ _i_directnum = value; }
        }        
		/// <summary>
		/// i_IsAssociateActive
        /// </summary>		
        public int? i_IsAssociateActive
        {
            get{ return _i_isassociateactive; }
            set{ _i_isassociateactive = value; }
        }        
		/// <summary>
		/// i_AssociateNum1
        /// </summary>		
        public int? i_AssociateNum1
        {
            get{ return _i_associatenum1; }
            set{ _i_associatenum1 = value; }
        }        
		/// <summary>
		/// i_AssociateNum2
        /// </summary>		
        public int? i_AssociateNum2
        {
            get{ return _i_associatenum2; }
            set{ _i_associatenum2 = value; }
        }        
		/// <summary>
		/// vc_UmtsKi
        /// </summary>		
        public string vc_UmtsKi
        {
            get{ return _vc_umtski; }
            set{ _vc_umtski = value; }
        }        
		/// <summary>
		/// vc_UmtsImsi
        /// </summary>		
        public string vc_UmtsImsi
        {
            get{ return _vc_umtsimsi; }
            set{ _vc_umtsimsi = value; }
        }        
		/// <summary>
		/// FapID
        /// </summary>		
        public int? FapID
        {
            get{ return _fapid; }
            set{ _fapid = value; }
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
		/// NumberPasswordType
        /// </summary>		
        public string NumberPasswordType
        {
            get{ return _numberpasswordtype; }
            set{ _numberpasswordtype = value; }
        }        
		/// <summary>
		/// NumberType
        /// </summary>		
        public string NumberType
        {
            get{ return _numbertype; }
            set{ _numbertype = value; }
        }        
		/// <summary>
		/// TellAuthority
        /// </summary>		
        public string TellAuthority
        {
            get{ return _tellauthority; }
            set{ _tellauthority = value; }
        }        
		/// <summary>
		/// TellType
        /// </summary>		
        public string TellType
        {
            get{ return _telltype; }
            set{ _telltype = value; }
        }        
		/// <summary>
		/// IsDispatch
        /// </summary>		
        public string IsDispatch
        {
            get{ return _isdispatch; }
            set{ _isdispatch = value; }
        }        
		/// <summary>
		/// LevelName
        /// </summary>		
        public string LevelName
        {
            get{ return _levelname; }
            set{ _levelname = value; }
        }        
		/// <summary>
		/// deptName
        /// </summary>		
        public string deptName
        {
            get{ return _deptname; }
            set{ _deptname = value; }
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
		/// boxIP
        /// </summary>		
        public string boxIP
        {
            get{ return _boxip; }
            set{ _boxip = value; }
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