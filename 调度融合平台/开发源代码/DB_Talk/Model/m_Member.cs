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
	/// m_Member
	/// </summary>	
    public class m_Member : ICloneable
	{
	    public m_Member()
		{}
	    #region Model  
      	private int _id;     
		private int? _boxid;     
		private long? _i_number;     
		private string _vc_name;     
		private int? _levelid;     
		private int? _numbertypeid;     
		private int? _i_telltype;     
		private int? _i_isdispatch;     
		private int? _departmentid;     
		private string _vc_mac;     
		private int? _i_flag;     
		private string _vc_memo;     
		private uint? _i_supplementserive;     
		private int? _i_authority;     
		private int? _i_nupasswordtype;
        private UInt64? _i_nupassword;     
		private int? _i_uncforwardnu;     
		private int? _i_noanswerforward;     
		private int? _i_poweroffforward;     
		private int? _i_busyforward;     
		private int? _i_directnum;     
		private int? _i_isassociateactive;     
		private long? _i_associatenum1;     
		private long? _i_associatenum2;     
		private string _vc_umtski;     
		private string _vc_umtsimsi;     
				
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
		/// i_Number
        /// </summary>		
        public long? i_Number
        {
            get{ return _i_number; }
            set{ _i_number = value; }
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
		/// LevelID
        /// </summary>		
        public int? LevelID
        {
            get{ return _levelid; }
            set{ _levelid = value; }
        }        
		/// <summary>
		/// NumberTypeID
        /// </summary>		
        public int? NumberTypeID
        {
            get{ return _numbertypeid; }
            set{ _numbertypeid = value; }
        }        
		/// <summary>
		/// i_TellType
        /// </summary>		
        public int? i_TellType
        {
            get{ return _i_telltype; }
            set{ _i_telltype = value; }
        }        
		/// <summary>
		/// i_IsDispatch
        /// </summary>		
        public int? i_IsDispatch
        {
            get{ return _i_isdispatch; }
            set{ _i_isdispatch = value; }
        }        
		/// <summary>
		/// DepartmentID
        /// </summary>		
        public int? DepartmentID
        {
            get{ return _departmentid; }
            set{ _departmentid = value; }
        }        
		/// <summary>
		/// vc_MAC
        /// </summary>		
        public string vc_MAC
        {
            get{ return _vc_mac; }
            set{ _vc_mac = value; }
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
		/// vc_Memo
        /// </summary>		
        public string vc_Memo
        {
            get{ return _vc_memo; }
            set{ _vc_memo = value; }
        }        
		/// <summary>
		/// 增补服务
        /// </summary>		
        public uint? i_supplementSerive
        {
            get{ return _i_supplementserive; }
            set{ _i_supplementserive = value; }
        }        
		/// <summary>
		/// 用户权限
        /// </summary>		
        public int? i_Authority
        {
            get{ return _i_authority; }
            set{ _i_authority = value; }
        }        
		/// <summary>
		/// 用户密码,3G没有密码
        /// </summary>		
        public int? i_NuPasswordType
        {
            get{ return _i_nupasswordtype; }
            set{ _i_nupasswordtype = value; }
        }        
		/// <summary>
		/// i_NuPassword
        /// </summary>		
        public UInt64? i_NuPassword
        {
            get{ return _i_nupassword; }
            set{ _i_nupassword = value; }
        }        
		/// <summary>
		/// 无条件呼叫前传
        /// </summary>		
        public int? i_UnCForwardNu
        {
            get{ return _i_uncforwardnu; }
            set{ _i_uncforwardnu = value; }
        }        
		/// <summary>
		/// 无应答呼叫前传
        /// </summary>		
        public int? i_NoAnswerForward
        {
            get{ return _i_noanswerforward; }
            set{ _i_noanswerforward = value; }
        }        
		/// <summary>
		/// 关机前转号码
        /// </summary>		
        public int? i_PowerOffForward
        {
            get{ return _i_poweroffforward; }
            set{ _i_poweroffforward = value; }
        }        
		/// <summary>
		/// 遇忙前传号码
        /// </summary>		
        public int? i_BusyForward
        {
            get{ return _i_busyforward; }
            set{ _i_busyforward = value; }
        }        
		/// <summary>
		/// 直通号码
        /// </summary>		
        public int? i_DirectNum
        {
            get{ return _i_directnum; }
            set{ _i_directnum = value; }
        }        
		/// <summary>
		/// 是否主动关联别的号码，1主动关联，2被别的号码关联
        /// </summary>		
        public int? i_IsAssociateActive
        {
            get{ return _i_isassociateactive; }
            set{ _i_isassociateactive = value; }
        }        
		/// <summary>
        /// 关联号码1
        /// </summary>		
        public long? i_AssociateNum1
        {
            get{ return _i_associatenum1; }
            set{ _i_associatenum1 = value; }
        }        
		/// <summary>
		/// 关联号码2
        /// </summary>		
        public long? i_AssociateNum2
        {
            get{ return _i_associatenum2; }
            set{ _i_associatenum2 = value; }
        }        
		/// <summary>
		/// 3G用户才有
        /// </summary>		
        public string vc_UmtsKi
        {
            get{ return _vc_umtski; }
            set{ _vc_umtski = value; }
        }        
		/// <summary>
		/// 标示码，3G用户才有
        /// </summary>		
        public string vc_UmtsImsi
        {
            get{ return _vc_umtsimsi; }
            set{ _vc_umtsimsi = value; }
        }        
		#endregion

        public string vc_IP { get; set; }
         /// <summary>
         ///3G基站ID
         /// </summary>
        public int FapID { get; set; }

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