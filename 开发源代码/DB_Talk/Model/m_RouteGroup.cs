using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_RouteGroup
	/// </summary>	
	public class m_RouteGroup
	{
	    public m_RouteGroup()
		{}
	    #region Model  
      	private int _id;     
		private int _boxid;     
		private string _vc_code;     
		private string _vc_name;     
		private string _vc_memo;     
		private int? _i_flag;     
				
		/// <summary>
		/// 路由组索引
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
		/// vc_Code
        /// </summary>		
        public string vc_Code
        {
            get{ return _vc_code; }
            set{ _vc_code = value; }
        }        
		/// <summary>
		/// 路由组名称
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
            m_RouteGroup m = obj as m_RouteGroup;
            if (this.ID == m.ID &&
                this.vc_Name == m.vc_Name)
            {
                return true;
            }
            return false;
        }
	}
}