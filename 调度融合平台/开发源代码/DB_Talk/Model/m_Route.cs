using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_Route
	/// </summary>	
	public class m_Route
	{
	    public m_Route()
		{}
	    #region Model  
      	private int _id;     
		private int _boxid;     
		private int _routegroupid;     
		private string _vc_code;     
		private string _vc_name;     
		private int _i_routetype;     
		private int? _i_loadbalance;     
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
        public int BoxID
        {
            get{ return _boxid; }
            set{ _boxid = value; }
        }        
		/// <summary>
		/// RouteGroupID
        /// </summary>		
        public int RouteGroupID
        {
            get{ return _routegroupid; }
            set{ _routegroupid = value; }
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
		/// 路由名称
        /// </summary>		
        public string vc_Name
        {
            get{ return _vc_name; }
            set{ _vc_name = value; }
        }        
		/// <summary>
		/// 路由类型，btw(1)双向（默认） 2: ogt(2)往外打 3: ict(3)往内打 4: reg(4) 5: pl(5) 6: esme(6)发信息 7: ecsc-uplk(7) 8: csc-uplk(8)
        /// </summary>		
        public int i_RouteType
        {
            get{ return _i_routetype; }
            set{ _i_routetype = value; }
        }        
		/// <summary>
		/// 负载平衡
        /// </summary>		
        public int? i_LoadBalance
        {
            get{ return _i_loadbalance; }
            set{ _i_loadbalance = value; }
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
            m_Route m = obj as m_Route;
            if (this.ID == m.ID &&
                this.vc_Name == m.vc_Name)// &&
               // this.RouteGroupID == m.RouteGroupID)
            {
                return true;
            }
            return false;
        }
	}
}