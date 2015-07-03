using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_TeleBill.Model 
{

    /// <summary>
	/// m_RoleAuthority
	/// </summary>	
	public class m_RoleAuthority
	{
	    public m_RoleAuthority()
		{}
	    #region Model  
      	private int _id;     
		private int _roleid;     
		private string _vc_modulename;     
		private string _vc_memo;     
		private int _i_flag;     
				
		/// <summary>
		/// ID
        /// </summary>		
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// roleID
        /// </summary>		
        public int roleID
        {
            get{ return _roleid; }
            set{ _roleid = value; }
        }        
		/// <summary>
		/// vc_ModuleName
        /// </summary>		
        public string vc_ModuleName
        {
            get{ return _vc_modulename; }
            set{ _vc_modulename = value; }
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
        public int i_Flag
        {
            get{ return _i_flag; }
            set{ _i_flag = value; }
        }        
		#endregion
	}
}