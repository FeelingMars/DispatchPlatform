using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_PRIClock
	/// </summary>	
	public class m_PRIClock
	{
	    public m_PRIClock()
		{}
	    #region Model  
      	private int _id;     
		private int _boxid;     
		private int? _i_level;     
		private int _i_type;     
		private int _i_port;     
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
		/// 时钟源级别，从高到低0-3个级别
        /// </summary>		
        public int? i_Level
        {
            get{ return _i_level; }
            set{ _i_level = value; }
        }        
		/// <summary>
		/// 时钟源类型1：none(-1)  2: internal(-2)  3: external(-3)	4: e1(-4)
        /// </summary>		
        public int i_Type
        {
            get{ return _i_type; }
            set{ _i_type = value; }
        }        
		/// <summary>
		/// 时钟源端口号，只有选择E1时才设置，0代表not used
        /// </summary>		
        public int i_Port
        {
            get{ return _i_port; }
            set{ _i_port = value; }
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