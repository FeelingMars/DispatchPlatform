using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_GroupMembers
	/// </summary>	
	public class m_GroupMembers
	{
	    public m_GroupMembers()
		{}
	    #region Model  
      	private int _id;     
		private int _boxid;     
		private int? _groupid;     
		private int? _memberid;     
				
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
		#endregion
	}
}