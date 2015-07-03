using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_PRISigLink
	/// </summary>	
	public class m_PRISigLink
	{
	    public m_PRISigLink()
		{}
	    #region Model  
      	private int _id;     
		private int _boxid;     
		private int _priid;     
		private int _i_machineid;     
		private int _i_slotid;     
		private int _i_e1port;     
		private int _i_channelnumber;     
		private int _i_type;     
		private int _i_linkid;     
		private int _i_unitype;     
		private int _i_oppositevoiceprompt;     
		private int _i_sendvoiceprompt;     
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
		/// PRIID
        /// </summary>		
        public int PRIID
        {
            get{ return _priid; }
            set{ _priid = value; }
        }        
		/// <summary>
		/// 机身号，固定为1
        /// </summary>		
        public int i_MachineID
        {
            get{ return _i_machineid; }
            set{ _i_machineid = value; }
        }        
		/// <summary>
		/// 槽位号，固定为3
        /// </summary>		
        public int i_SlotID
        {
            get{ return _i_slotid; }
            set{ _i_slotid = value; }
        }        
		/// <summary>
		/// E1端口号
        /// </summary>		
        public int i_E1Port
        {
            get{ return _i_e1port; }
            set{ _i_e1port = value; }
        }        
		/// <summary>
		///  //表示第几个信道，默认为16
        /// </summary>		
        public int i_ChannelNumber
        {
            get{ return _i_channelnumber; }
            set{ _i_channelnumber = value; }
        }        
		/// <summary>
		/// 协议类型,//q931(1) qSIG(2),默认1
        /// </summary>		
        public int i_Type
        {
            get{ return _i_type; }
            set{ _i_type = value; }
        }        
		/// <summary>
		/// i_LinkID
        /// </summary>		
        public int i_LinkID
        {
            get{ return _i_linkid; }
            set{ _i_linkid = value; }
        }        
		/// <summary>
		///  //用户侧：1，网络侧：2，默认1
        /// </summary>		
        public int i_UNIType
        {
            get{ return _i_unitype; }
            set{ _i_unitype = value; }
        }        
		/// <summary>
		/// 对端是否提供语音提示,//是:1,否:2,默认否
        /// </summary>		
        public int i_OppositeVoicePrompt
        {
            get{ return _i_oppositevoiceprompt; }
            set{ _i_oppositevoiceprompt = value; }
        }        
		/// <summary>
		/// 是否发送语音提示,//是:1,否:2,默认是 
        /// </summary>		
        public int i_SendVoicePrompt
        {
            get{ return _i_sendvoiceprompt; }
            set{ _i_sendvoiceprompt = value; }
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
            m_PRISigLink m = obj as m_PRISigLink;
            if (this.i_ChannelNumber == m.i_ChannelNumber &&
                this.i_E1Port == m.i_E1Port &&
                this.i_LinkID == m.i_LinkID &&
                this.PRIID == m.PRIID &&
                this.i_UNIType==m.i_UNIType)

            {
                return true;
            }
            return false;
        }
	}
}