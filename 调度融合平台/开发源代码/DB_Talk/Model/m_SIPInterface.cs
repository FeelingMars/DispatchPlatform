using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_SIPInterface
	/// </summary>	
	public class m_SIPInterface
	{
	    public m_SIPInterface()
		{}
	    #region Model  
      	private int _id;     
		private int? _boxid;     
		private string _vc_code;     
		private string _vc_name;     
		private int _sipid;     
		private int _routeid;     
		private int _sapid;     
		private string _vc_outnumber;     
		private string _vc_outnumberlocal;     
		private string _vc_oppositeip;     
		private int _i_port;     
		private int _i_oppositeport;     
		private int _i_state;     
		private int _i_type;     
		private int _i_level;     
		private int _i_maxchannel;     
		private int _i_playsound;     
		private int _i_operatestate;     
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
		/// SIP中继接口索引
        /// </summary>		
        public int SIPID
        {
            get{ return _sipid; }
            set{ _sipid = value; }
        }        
		/// <summary>
		/// RouteID
        /// </summary>		
        public int RouteID
        {
            get{ return _routeid; }
            set{ _routeid = value; }
        }        
		/// <summary>
		/// SAP接入点索引
        /// </summary>		
        public int SAPID
        {
            get{ return _sapid; }
            set{ _sapid = value; }
        }        
		/// <summary>
		/// 长途出局引导码
        /// </summary>		
        public string vc_OutNumber
        {
            get{ return _vc_outnumber; }
            set{ _vc_outnumber = value; }
        }        
		/// <summary>
		/// 市话出局引导码
        /// </summary>		
        public string vc_OutNumberLocal
        {
            get{ return _vc_outnumberlocal; }
            set{ _vc_outnumberlocal = value; }
        }        
		/// <summary>
		/// 对端IP
        /// </summary>		
        public string vc_OppositeIP
        {
            get{ return _vc_oppositeip; }
            set{ _vc_oppositeip = value; }
        }        
		/// <summary>
		/// 本端端口
        /// </summary>		
        public int i_Port
        {
            get{ return _i_port; }
            set{ _i_port = value; }
        }        
		/// <summary>
		/// 对端端口号
        /// </summary>		
        public int i_OppositePort
        {
            get{ return _i_oppositeport; }
            set{ _i_oppositeport = value; }
        }        
		/// <summary>
		/// 配置状态
        /// </summary>		
        public int i_State
        {
            get{ return _i_state; }
            set{ _i_state = value; }
        }        
		/// <summary>
		/// 接口类型（内部，外部）
        /// </summary>		
        public int i_Type
        {
            get{ return _i_type; }
            set{ _i_type = value; }
        }        
		/// <summary>
		/// 级别（主SIP中继，从SIP中继）
        /// </summary>		
        public int i_Level
        {
            get{ return _i_level; }
            set{ _i_level = value; }
        }        
		/// <summary>
		/// 最大通道数，默认128
        /// </summary>		
        public int i_MaxChannel
        {
            get{ return _i_maxchannel; }
            set{ _i_maxchannel = value; }
        }        
		/// <summary>
		/// 是否放音
        /// </summary>		
        public int i_PlaySound
        {
            get{ return _i_playsound; }
            set{ _i_playsound = value; }
        }        
		/// <summary>
		/// 操作状态
        /// </summary>		
        public int i_OperateState
        {
            get{ return _i_operatestate; }
            set{ _i_operatestate = value; }
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
            m_SIPInterface m = obj as m_SIPInterface;
            if (this.SIPID == m.SIPID &&
                this.SAPID == m.SAPID &&
                this.BoxID==m.BoxID &&
                //this.i_Port==m.i_Port &&
                //this.vc_OutNumber==m.vc_OutNumber &&
                this.RouteID == m.RouteID &&
                this.vc_OppositeIP == m.vc_OppositeIP &&
                this.i_PlaySound == m.i_PlaySound &&
                this.i_OppositePort == m.i_OppositePort )
            {
                return true;
            }
            return false;
        }
	}
}