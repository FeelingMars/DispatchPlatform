using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_Group
	/// </summary>	
	public class m_Group
	{
	    public m_Group()
		{}
	    #region Model  
      	private int _id;     
		private string _boxid;     
		private int? _grouptypeid;     
		private string _vc_name;     
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
        public string BoxID
        {
            get{ return _boxid; }
            set{ _boxid = value; }
        }        
		/// <summary>
		/// 0表示用户，1表示会议，2表示短信
        /// </summary>		
        public int? GroupTypeID
        {
            get{ return _grouptypeid; }
            set{ _grouptypeid = value; }
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