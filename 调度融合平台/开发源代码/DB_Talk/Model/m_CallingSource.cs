using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;

namespace DB_Talk.Model 
{

    /// <summary>
	/// m_CallingSource
	/// </summary>	
	public class m_CallingSource
	{
	    public m_CallingSource()
		{}
	    #region Model  
      	private int _id;     
		private int _boxid;     
		private string _vc_code;     
		private string _vc_name;     
		private int _i_maintype;     
		private int _i_subtype;     
		private string _vc_memo;     
		private int? _i_flag;     
				
		/// <summary>
		/// 呼叫源索引
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
		/// 呼叫源类型
        /// </summary>		
        public int i_MainType
        {
            get{ return _i_maintype; }
            set{ _i_maintype = value; }
        }        
		/// <summary>
		/// 呼叫源子类型
        /// </summary>		
        public int i_SubType
        {
            get{ return _i_subtype; }
            set{ _i_subtype = value; }
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
            m_CallingSource m = obj as m_CallingSource;
            if (this.ID == m.ID && this.i_MainType==m.i_MainType && this.i_SubType==m.i_SubType)
            {
                return true;
            }
            return false;
        }

	}
}