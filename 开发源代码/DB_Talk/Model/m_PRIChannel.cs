using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_PRIChannel
	/// </summary>	
	public class m_PRIChannel
	{
	    public m_PRIChannel()
		{}
	    #region Model  
      	private int _id;     
		private int _boxid;     
		private int _priid;     
		private int _i_machineid;     
		private int _i_soltid;     
		private int _i_e1port;     
		private int _i_channelnumber;     
		private int _i_linkid;     
		private int _i_state;     
		private int _i_operate;     
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
        public int i_SoltID
        {
            get{ return _i_soltid; }
            set{ _i_soltid = value; }
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
		/// 表示第几个信道，第16个信道不作为承载信道，1-31
        /// </summary>		
        public int i_ChannelNumber
        {
            get{ return _i_channelnumber; }
            set{ _i_channelnumber = value; }
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
		/// i_State
        /// </summary>		
        public int i_State
        {
            get{ return _i_state; }
            set{ _i_state = value; }
        }        
		/// <summary>
		/// i_Operate
        /// </summary>		
        public int i_Operate
        {
            get{ return _i_operate; }
            set{ _i_operate = value; }
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
            m_PRIChannel m = obj as m_PRIChannel;
            if (this.i_ChannelNumber == m.i_ChannelNumber &&
                this.i_E1Port == m.i_E1Port &&
                this.i_LinkID == m.i_LinkID &&
                this.PRIID==m.PRIID &&
                this.PRIID == m.PRIID)
            {
                return true;
            }
            return false;
        }
	}
}