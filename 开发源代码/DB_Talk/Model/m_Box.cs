using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DB_Talk.Model 
{
    [Serializable]

    /// <summary>
	/// m_Box
	/// </summary>	
    public partial class m_Box : ICloneable
	{
	    public m_Box()
		{}
	    #region Model  
      	private int _id;     
		private string _vc_name;     
		private string _vc_ip;     
		private string _vc_sn;     
		private string _vc_memo;     
		private int? _i_flag;     
		private int? _i_maxmeetingmember;     
		private string _vc_mask;     
		private string _vc_netip;     
		private string _vc_dspip;     
		private string _vc_dispatchip1;     
		private string _vc_dispatchip2;     
		private string _vc_recordserverip;     
		private string _vc_timerserverip;     
		private int? _i_recordserverenable;     
		private int? _i_cdropened;     
		private int? _i_rtcdropened;     
		private int? _i_sipregistcycle;     
		private int? _i_sendcycle;     
		private int? _i_relenable;     
		private int? _i_checkuseronline;     
		private int? _i_dispatchnumber;     
		private int? _i_emergencynumber;     
		private string _vc_numberhead;     
		private int? _i_numberlen;     
				
		/// <summary>
		/// ID
        /// </summary>		
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
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
		/// 站点IP，即业务口IP
        /// </summary>		
        public string vc_IP
        {
            get{ return _vc_ip; }
            set{ _vc_ip = value; }
        }        
		/// <summary>
		/// vc_SN
        /// </summary>		
        public string vc_SN
        {
            get{ return _vc_sn; }
            set{ _vc_sn = value; }
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
		/// <summary>
		/// i_MaxMeetingMember
        /// </summary>		
        public int? i_MaxMeetingMember
        {
            get{ return _i_maxmeetingmember; }
            set{ _i_maxmeetingmember = value; }
        }        
		/// <summary>
		/// vc_Mask
        /// </summary>		
        public string vc_Mask
        {
            get{ return _vc_mask; }
            set{ _vc_mask = value; }
        }        
		/// <summary>
		/// vc_NetIP
        /// </summary>		
        public string vc_NetIP
        {
            get{ return _vc_netip; }
            set{ _vc_netip = value; }
        }        
		/// <summary>
		/// vc_DspIP
        /// </summary>		
        public string vc_DspIP
        {
            get{ return _vc_dspip; }
            set{ _vc_dspip = value; }
        }        
		/// <summary>
		/// vc_DispatchIP1
        /// </summary>		
        public string vc_DispatchIP1
        {
            get{ return _vc_dispatchip1; }
            set{ _vc_dispatchip1 = value; }
        }        
		/// <summary>
		/// 调度IP2
        /// </summary>		
        public string vc_DispatchIP2
        {
            get{ return _vc_dispatchip2; }
            set{ _vc_dispatchip2 = value; }
        }        
		/// <summary>
		/// 录音服务器IP
        /// </summary>		
        public string vc_RecordServerIP
        {
            get{ return _vc_recordserverip; }
            set{ _vc_recordserverip = value; }
        }        
		/// <summary>
		/// 时间服务器
        /// </summary>		
        public string vc_TimerServerIP
        {
            get{ return _vc_timerserverip; }
            set{ _vc_timerserverip = value; }
        }        
		/// <summary>
		/// 录音服务器是否启用
        /// </summary>		
        public int? i_RecordServerEnable
        {
            get{ return _i_recordserverenable; }
            set{ _i_recordserverenable = value; }
        }        
		/// <summary>
		/// CDR触发器是否打开
        /// </summary>		
        public int? i_CDROpened
        {
            get{ return _i_cdropened; }
            set{ _i_cdropened = value; }
        }        
		/// <summary>
		/// 实时CDR触发器是否打开
        /// </summary>		
        public int? i_RTCDROpened
        {
            get{ return _i_rtcdropened; }
            set{ _i_rtcdropened = value; }
        }        
		/// <summary>
		/// SIP注册周期，默认120秒
        /// </summary>		
        public int? i_SIPRegistCycle
        {
            get{ return _i_sipregistcycle; }
            set{ _i_sipregistcycle = value; }
        }        
		/// <summary>
		/// SIP心跳周期，默认180秒
        /// </summary>		
        public int? i_SendCycle
        {
            get{ return _i_sendcycle; }
            set{ _i_sendcycle = value; }
        }        
		/// <summary>
		/// 是否支持RFC3262定义的100rel
        /// </summary>		
        public int? i_RelEnable
        {
            get{ return _i_relenable; }
            set{ _i_relenable = value; }
        }        
		/// <summary>
		/// 检测用户在线模式，0不使用，1注册，2心跳
        /// </summary>		
        public int? i_CheckUserOnline
        {
            get{ return _i_checkuseronline; }
            set{ _i_checkuseronline = value; }
        }        
		/// <summary>
		/// 调度中心号码
        /// </summary>		
        public int? i_DispatchNumber
        {
            get{ return _i_dispatchnumber; }
            set{ _i_dispatchnumber = value; }
        }        
		/// <summary>
		/// 紧急号码
        /// </summary>		
        public int? i_EmergencyNumber
        {
            get{ return _i_emergencynumber; }
            set{ _i_emergencynumber = value; }
        }        
		/// <summary>
		/// 内部分机引导码
        /// </summary>		
        public string vc_NumberHead
        {
            get{ return _vc_numberhead; }
            set{ _vc_numberhead = value; }
        }        
		/// <summary>
		/// 号码长度限制
        /// </summary>		
        public int? i_NumberLen
        {
            get{ return _i_numberlen; }
            set{ _i_numberlen = value; }
        }        
		#endregion


        public override bool Equals(object obj)
        {
            m_Box m = obj as m_Box;
            if (this.ID == m.ID)
            {
                return true;
            }
            return false;
        }

        public object Clone()
        {
            //return this;                    //返回同一个对象的引用

            //return this.MemberwiseClone();  //返回一个浅表副本

            //return new CloneClass();        //返回一个深层副本

            {                                 //返回一个内存副本

                MemoryStream stream = new MemoryStream();

                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(stream, this);

                stream.Position = 0;

                return formatter.Deserialize(stream);

            }


        }
    }
}