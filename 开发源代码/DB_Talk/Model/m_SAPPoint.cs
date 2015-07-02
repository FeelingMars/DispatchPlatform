using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_SAPPoint
	/// </summary>	
	public class m_SAPPoint
	{
	    public m_SAPPoint()
		{}
	    #region Model  
      	private int _id;     
		private int? _boxid;     
		private int _sapid;     
		private string _vc_code;     
		private string _vc_name;     
		private int _i_port;     
		private int _i_type;     
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
		/// SAPID
        /// </summary>		
        public int SAPID
        {
            get{ return _sapid; }
            set{ _sapid = value; }
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
		/// i_Port
        /// </summary>		
        public int i_Port
        {
            get{ return _i_port; }
            set{ _i_port = value; }
        }        
		/// <summary>
		/// 协议类型
        /// </summary>		
        public int i_Type
        {
            get{ return _i_type; }
            set{ _i_type = value; }
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
            m_SAPPoint m = obj as m_SAPPoint;
            if (this.SAPID == m.SAPID &&
                this.i_Port == m.i_Port)
            {
                return true;
            }
            return false;
        }
	}
}