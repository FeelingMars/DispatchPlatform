using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_StaticRoute
	/// </summary>	
	public class m_StaticRoute
	{
	    public m_StaticRoute()
		{}
	    #region Model  
      	private int _id;     
		private int? _boxid;     
		private string _vc_netip;     
		private string _vc_mask;     
		private string _vc_gatewayip;     
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
		/// vc_NetIP
        /// </summary>		
        public string vc_NetIP
        {
            get{ return _vc_netip; }
            set{ _vc_netip = value; }
        }        
		/// <summary>
		/// vc_Mask
        /// </summary>		
        public string vc_Mask
        {
            get{ return _vc_mask; }
            set{ _vc_mask = value; }
        }        
		/// <summary>
		/// vc_GateWayIP
        /// </summary>		
        public string vc_GateWayIP
        {
            get{ return _vc_gatewayip; }
            set{ _vc_gatewayip = value; }
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