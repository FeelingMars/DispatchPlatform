using System; 
using System.Text;
using System.Data;
using System.Collections.Generic; 
using System.Data;
using DB_Talk.Model;

namespace DB_Talk.BLL 
{
	/// <summary>
	/// m_Box
	/// </summary>	
	public partial class m_Box
	{    

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetListEx(string strWhere)
		{
			return dal.GetListEx(0,strWhere,"");
		}
		
		
	}
}