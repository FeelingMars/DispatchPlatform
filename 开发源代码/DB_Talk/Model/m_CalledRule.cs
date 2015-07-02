using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_CalledRule
	/// </summary>	
	public class m_CalledRule
	{
	    public m_CalledRule()
		{}
	    #region Model  
      	private int _id;     
		private int _calledid;     
		private int _boxid;     
		private string _vc_code;     
		private string _vc_name;     
		private int _callingoriid;     
		private string _vc_callednumber;     
		private int _i_calledtype;     
		private int _i_calledsubtype;     
		private int _destrouteid;     
		private int _i_calledchangetype;     
		private int? _i_calledchangeposition;     
		private int _i_calledchangelength;     
		private string _vc_calledchangetarget;     
		private string _vc_memo;     
		private int _i_sipid;     
		private int _i_priid;     
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
		/// 被叫号码分析规则索引
        /// </summary>		
        public int CalledID
        {
            get{ return _calledid; }
            set{ _calledid = value; }
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
        public int CallingOriID
        {
            get{ return _callingoriid; }
            set{ _callingoriid = value; }
        }        
		/// <summary>
		/// 被叫号码,特殊号码*000，最大4位
        /// </summary>		
        public string vc_CalledNumber
        {
            get{ return _vc_callednumber; }
            set{ _vc_callednumber = value; }
        }        
		/// <summary>
		/// 呼叫类型
        /// </summary>		
        public int i_CalledType
        {
            get{ return _i_calledtype; }
            set{ _i_calledtype = value; }
        }        
		/// <summary>
		/// 呼叫子类型
        /// </summary>		
        public int i_CalledSubType
        {
            get{ return _i_calledsubtype; }
            set{ _i_calledsubtype = value; }
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
		/// 被叫号码变换动作，空值0，插入1，删除2，替换3
        /// </summary>		
        public int i_CalledChangeType
        {
            get{ return _i_calledchangetype; }
            set{ _i_calledchangetype = value; }
        }        
		/// <summary>
		/// 被叫号码变换位置
        /// </summary>		
        public int? i_CalledChangePosition
        {
            get{ return _i_calledchangeposition; }
            set{ _i_calledchangeposition = value; }
        }        
		/// <summary>
		/// 被叫号码变换长度
        /// </summary>		
        public int i_CalledChangeLength
        {
            get{ return _i_calledchangelength; }
            set{ _i_calledchangelength = value; }
        }        
		/// <summary>
		/// 被叫号码变换目标串
        /// </summary>		
        public string vc_CalledChangeTarget
        {
            get{ return _vc_calledchangetarget; }
            set{ _vc_calledchangetarget = value; }
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
		/// SIP中继索引
        /// </summary>		
        public int i_SIPID
        {
            get{ return _i_sipid; }
            set{ _i_sipid = value; }
        }        
		/// <summary>
		/// PRI中继索引
        /// </summary>		
        public int i_PRIID
        {
            get{ return _i_priid; }
            set{ _i_priid = value; }
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
            m_CalledRule m = obj as m_CalledRule;
            if (this.CalledID == m.CalledID &&
                this.CallingOriID == m.CallingOriID &&
                this.vc_CalledNumber == m.vc_CalledNumber &&
                this.i_CalledType == m.i_CalledType &&
                this.i_CalledSubType == m.i_CalledSubType &&
                this.i_SIPID == m.i_SIPID &&
                this.i_PRIID==m.i_PRIID)
                //this.DestRouteID == m.DestRouteID &&
                //this.i_CalledChangeType == m.i_CalledChangeType &&
                //this.i_CalledChangePosition == m.i_CalledChangePosition) // &&
                //this.i_CalledChangeLength == m.i_CalledChangeLength)// &&
                //this.vc_CalledChangeTarget == m.vc_CalledChangeTarget)
            {
                
                return true;
            }
            return false;
        }

       

       
	}
}