using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DB_Talk.Model;

namespace DB_Talk.BLL
{
    /// <summary>
    /// v_Member
    /// </summary>	
    public partial class v_MemberEx
    {
        private readonly DB_Talk.DAL.v_MemberEx dal = new DB_Talk.DAL.v_MemberEx();
        public v_MemberEx()
        { }

        #region  Method

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DB_Talk.Model.v_Member> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetListEx(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DB_Talk.Model.v_Member> DataTableToList(DataTable dt)
        {
            List<DB_Talk.Model.v_Member> modelList = new List<DB_Talk.Model.v_Member>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DB_Talk.Model.v_Member model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DB_Talk.Model.v_Member();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    //if (dt.Rows[n]["BoxID"] != null && dt.Rows[n]["BoxID"].ToString() != "")
                    //{
                    //    model.BoxID = int.Parse(dt.Rows[n]["BoxID"].ToString());
                    //}
                    if (dt.Rows[n]["i_Number"] != null && dt.Rows[n]["i_Number"].ToString() != "")
                    {
                        model.i_Number = int.Parse(dt.Rows[n]["i_Number"].ToString());
                    }
                    if (dt.Rows[n]["vc_Name"] != null && dt.Rows[n]["vc_Name"].ToString() != "")
                    {
                        model.vc_Name = dt.Rows[n]["vc_Name"].ToString();
                    }
                    if (dt.Rows[n]["LevelID"] != null && dt.Rows[n]["LevelID"].ToString() != "")
                    {
                        model.LevelID = int.Parse(dt.Rows[n]["LevelID"].ToString());
                    }
                    if (dt.Rows[n]["NumberTypeID"] != null && dt.Rows[n]["NumberTypeID"].ToString() != "")
                    {
                        model.NumberTypeID = int.Parse(dt.Rows[n]["NumberTypeID"].ToString());
                    }
                    if (dt.Rows[n]["DepartmentID"] != null && dt.Rows[n]["DepartmentID"].ToString() != "")
                    {
                        model.DepartmentID = int.Parse(dt.Rows[n]["DepartmentID"].ToString());
                    }
                    if (dt.Rows[n]["vc_MAC"] != null && dt.Rows[n]["vc_MAC"].ToString() != "")
                    {
                        model.vc_MAC = dt.Rows[n]["vc_MAC"].ToString();
                    }
                    if (dt.Rows[n]["i_Flag"] != null && dt.Rows[n]["i_Flag"].ToString() != "")
                    {
                        model.i_Flag = int.Parse(dt.Rows[n]["i_Flag"].ToString());
                    }
                    if (dt.Rows[n]["vc_Memo"] != null && dt.Rows[n]["vc_Memo"].ToString() != "")
                    {
                        model.vc_Memo = dt.Rows[n]["vc_Memo"].ToString();
                    }
                    if (dt.Rows[n]["deptName"] != null && dt.Rows[n]["deptName"].ToString() != "")
                    {
                        model.deptName = dt.Rows[n]["deptName"].ToString();
                    }
                    //if (dt.Rows[n]["BoxName"] != null && dt.Rows[n]["BoxName"].ToString() != "")
                    //{
                    //    model.BoxName = dt.Rows[n]["BoxName"].ToString();
                    //}
                    //if (dt.Rows[n]["vc_IP"] != null && dt.Rows[n]["vc_IP"].ToString() != "")
                    //{
                    //    model.vc_IP = dt.Rows[n]["vc_IP"].ToString();
                    //}
                    //if (dt.Rows[n]["vc_SN"] != null && dt.Rows[n]["vc_SN"].ToString() != "")
                    //{
                    //    model.vc_SN = dt.Rows[n]["vc_SN"].ToString();
                    //}
                    modelList.Add(model);

                }
            }
            return modelList;
        }


        #endregion

    }
}