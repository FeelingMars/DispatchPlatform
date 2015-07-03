using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_FAP
	/// </summary>	
	public class m_FAP
	{
	    public m_FAP()
		{}
	    #region Model  
      	private int _id;     
		private int _fapid;     
		private int _boxid;     
		private int? _i_rantype;     
		private string _vc_name;     
		private string _vc_identify;     
		private int? _i_confstate;     
		private int? _i_operatestate;     
		private string _vc_tempaddress;     
		private int? _i_fapsctpport;     
		private int? _i_swlinkid;     
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
		/// FapID
        /// </summary>		
        public int FapID
        {
            get{ return _fapid; }
            set{ _fapid = value; }
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
		/// i_RanType
        /// </summary>		
        public int? i_RanType
        {
            get{ return _i_rantype; }
            set{ _i_rantype = value; }
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
		/// vc_Identify
        /// </summary>		
        public string vc_Identify
        {
            get{ return _vc_identify; }
            set{ _vc_identify = value; }
        }        
		/// <summary>
		/// i_ConfState
        /// </summary>		
        public int? i_ConfState
        {
            get{ return _i_confstate; }
            set{ _i_confstate = value; }
        }        
		/// <summary>
		/// i_OperateState
        /// </summary>		
        public int? i_OperateState
        {
            get{ return _i_operatestate; }
            set{ _i_operatestate = value; }
        }        
		/// <summary>
		/// vc_TempAddress
        /// </summary>		
        public string vc_TempAddress
        {
            get{ return _vc_tempaddress; }
            set{ _vc_tempaddress = value; }
        }        
		/// <summary>
		/// i_fapSctpPort
        /// </summary>		
        public int? i_fapSctpPort
        {
            get{ return _i_fapsctpport; }
            set{ _i_fapsctpport = value; }
        }        
		/// <summary>
		/// i_SwLinkID
        /// </summary>		
        public int? i_SwLinkID
        {
            get{ return _i_swlinkid; }
            set{ _i_swlinkid = value; }
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