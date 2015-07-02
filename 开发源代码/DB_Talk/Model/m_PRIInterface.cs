using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_PRIInterface
	/// </summary>	
	public class m_PRIInterface
	{
	    public m_PRIInterface()
		{}
	    #region Model  
      	private int _id;     
		private int _boxid;     
		private int _priid;     
		private string _vc_outnumber;     
		private string _vc_outnumberlocal;     
		private string _vc_code;     
		private string _vc_name;     
		private int _routeid;     
		private int _i_type;     
		private int _i_level;     
		private int _i_state;     
		private int _i_operate;     
		private int _i_linkid;     
		private int _i_linkcount;     
		private int _i_linktype;     
		private int _i_switchtype;     
		private string _vc_memo;     
		private int _i_e1port;     
		private int _i_unitype;     
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
		/// PRI索引
        /// </summary>		
        public int PRIID
        {
            get{ return _priid; }
            set{ _priid = value; }
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
		/// 路由ID
        /// </summary>		
        public int RouteID
        {
            get{ return _routeid; }
            set{ _routeid = value; }
        }        
		/// <summary>
		/// 接口类型,内部(1),外部(2)，默认外部
        /// </summary>		
        public int i_Type
        {
            get{ return _i_type; }
            set{ _i_type = value; }
        }        
		/// <summary>
		/// 接口级别,优先级,主(1),从(2)，默认主
        /// </summary>		
        public int i_Level
        {
            get{ return _i_level; }
            set{ _i_level = value; }
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
		/// 操作状态
        /// </summary>		
        public int i_Operate
        {
            get{ return _i_operate; }
            set{ _i_operate = value; }
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
		/// 接口链路数目
        /// </summary>		
        public int i_LinkCount
        {
            get{ return _i_linkcount; }
            set{ _i_linkcount = value; }
        }        
		/// <summary>
		/// 链路类型，E1=1，T1=2
        /// </summary>		
        public int i_LinkType
        {
            get{ return _i_linktype; }
            set{ _i_linktype = value; }
        }        
		/// <summary>
		/// 交换机类型1: unknown(1) 2: avaya(2)3: nortel(3)4: alcatel(4) 5: siemens(5) 6: oulian(6)7: shenou(7) 8: utstarcom(8) 9: microxel(9)
        /// </summary>		
        public int i_SwitchType
        {
            get{ return _i_switchtype; }
            set{ _i_switchtype = value; }
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
		/// 使用的E1端口号
        /// </summary>		
        public int i_E1Port
        {
            get{ return _i_e1port; }
            set{ _i_e1port = value; }
        }        
		/// <summary>
		/// 信令信道UNI类型 //用户侧：1，网络侧：2，默认1
        /// </summary>		
        public int i_UNIType
        {
            get{ return _i_unitype; }
            set{ _i_unitype = value; }
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
            m_PRIInterface m = obj as m_PRIInterface;
            if (this.PRIID == m.PRIID &&
                this.RouteID == m.RouteID &&
                //this.i_E1Port == m.i_E1Port &&
                //this.i_LinkID == m.i_LinkID &&
                this.i_SwitchType == m.i_SwitchType)
                //this.i_UNIType == m.i_UNIType)
                //this.i_Type==m.i_Type)
            {
                return true;
            }
            return false;
        }
	}
}