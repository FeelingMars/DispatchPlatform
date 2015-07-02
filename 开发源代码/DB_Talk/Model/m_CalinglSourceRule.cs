using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_CalinglSourceRule
	/// </summary>	
	public class m_CalinglSourceRule
	{
	    public m_CalinglSourceRule()
		{}
	    #region Model  
      	private int _id;     
		private int _boxid;     
		private string _vc_code;     
		private string _vc_name;     
		private int _callingorigid;     
		private int _i_servertype;     
		private int _i_minrelength;     
		private int? _orirouteid;     
		private int? _calledruleid;     
		private string _vc_memo;     
		private int? _i_flag;     
				
		/// <summary>
		/// 呼叫源规则表
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
		/// vc_Name
        /// </summary>		
        public string vc_Name
        {
            get{ return _vc_name; }
            set{ _vc_name = value; }
        }        
		/// <summary>
		/// 呼叫源索引
        /// </summary>		
        public int CallingOrigID
        {
            get{ return _callingorigid; }
            set{ _callingorigid = value; }
        }        
		/// <summary>
		/// 服务类型
        /// </summary>		
        public int i_ServerType
        {
            get{ return _i_servertype; }
            set{ _i_servertype = value; }
        }        
		/// <summary>
		/// 最小收号长度
        /// </summary>		
        public int i_MinReLength
        {
            get{ return _i_minrelength; }
            set{ _i_minrelength = value; }
        }        
		/// <summary>
		/// 源路由索引
        /// </summary>		
        public int? OriRouteID
        {
            get{ return _orirouteid; }
            set{ _orirouteid = value; }
        }        
		/// <summary>
		/// 被叫分析规则索引
        /// </summary>		
        public int? CalledRuleID
        {
            get{ return _calledruleid; }
            set{ _calledruleid = value; }
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
            m_CalinglSourceRule m = obj as m_CalinglSourceRule;
            if (this.CallingOrigID == m.CallingOrigID &&
                this.i_ServerType==m.i_ServerType &&
                this.i_MinReLength==m.i_MinReLength)
                //this.OriRouteID==m.OriRouteID &&
                //this.CalledRuleID == m.CalledRuleID) 
                //m.CallingOrigID
                //m.i_ServerType 
                //m.i_MinReLength
            {
                return true;
            }
            return false;
        }
	}
}