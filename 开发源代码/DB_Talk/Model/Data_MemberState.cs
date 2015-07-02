using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// Data_MemberState
	/// </summary>	
	public class Data_MemberState
	{
	    public Data_MemberState()
		{}
	    #region Model  
      	private int _id;     
		private long? _i_dispatchnumber;
        private long? _i_number;
        private long _i_peernumber;     
		private int? _i_state;     
				
		/// <summary>
		/// ID
        /// </summary>		
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// i_DispatchNumber
        /// </summary>		
        public long? i_DispatchNumber
        {
            get{ return _i_dispatchnumber; }
            set{ _i_dispatchnumber = value; }
        }        
		/// <summary>
		/// i_Number
        /// </summary>		
        public long? i_Number
        {
            get{ return _i_number; }
            set{ _i_number = value; }
        }        
		/// <summary>
		/// i_PeerNumber
        /// </summary>		
        public long i_PeerNumber
        {
            get{ return _i_peernumber; }
            set{ _i_peernumber = value; }
        }        
		/// <summary>
		/// i_State
        /// </summary>		
        public int? i_State
        {
            get{ return _i_state; }
            set{ _i_state = value; }
        }        
		#endregion
	}
}