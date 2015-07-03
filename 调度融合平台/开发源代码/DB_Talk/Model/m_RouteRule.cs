using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_RouteRule
	/// </summary>	
	public class m_RouteRule
	{
	    public m_RouteRule()
		{}
	    #region Model  
      	private int _id;     
		private int _boxid;     
		private int _orirouteid;     
		private int _destrouteid;     
		private string _vc_code;     
		private string _vc_name;     
		private string _vc_memo;     
		private int? _i_flag;     
				
		/// <summary>
		/// 路由规则索引
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
		/// 源路由索引
        /// </summary>		
        public int OriRouteID
        {
            get{ return _orirouteid; }
            set{ _orirouteid = value; }
        }        
		/// <summary>
		/// 目的路由索引
        /// </summary>		
        public int DestRouteID
        {
            get{ return _destrouteid; }
            set{ _destrouteid = value; }
        }        
		/// <summary>
		/// vc_Code
        /// </summary>		
        public string vc_Code
        {
            get{ return _vc_code; }
            set{ _vc_code = value; }
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

        public override bool Equals(object obj)
        {
            m_RouteRule m = obj as m_RouteRule;
            if (this.DestRouteID == m.DestRouteID && 
                this.OriRouteID == m.OriRouteID && 
                this.ID == m.ID)
            {
                return true;
            }
            return false;
        }
	}
}