/**  版本信息模板在安装目录下，可自行修改。
* m_RegionRelation.cs
*
* 功 能： N/A
* 类 名： m_RegionRelation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/7/8 16:54:36   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace DB_Talk.DAL
{
    /// <summary>
    /// 数据访问类:m_RegionRelation
    /// </summary>
    public partial class m_RegionRelation
    {
        public m_RegionRelation()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DB_Talk.Model.m_RegionRelation model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.BoxID != null)
            {
                strSql1.Append("BoxID,");
                strSql2.Append("" + model.BoxID + ",");
            }
            if (model.RegionID != null)
            {
                strSql1.Append("RegionID,");
                strSql2.Append("'" + model.RegionID + "',");
            }
            if (model.i_RelationType != null)
            {
                strSql1.Append("i_RelationType,");
                strSql2.Append("" + model.i_RelationType + ",");
            }
            if (model.RelationID != null)
            {
                strSql1.Append("RelationID,");
                strSql2.Append("" + model.RelationID + ",");
            }
            strSql.Append("insert into m_RegionRelation(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            object obj = DB.OleDbHelper.ExecuteSql(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DB_Talk.Model.m_RegionRelation model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update m_RegionRelation set ");
            if (model.BoxID != null)
            {
                strSql.Append("BoxID=" + model.BoxID + ",");
            }
            else
            {
                strSql.Append("BoxID= null ,");
            }
            if (model.RegionID != null)
            {
                strSql.Append("RegionID='" + model.RegionID + "',");
            }
            else
            {
                strSql.Append("RegionID= null ,");
            }
            if (model.i_RelationType != null)
            {
                strSql.Append("i_RelationType=" + model.i_RelationType + ",");
            }
            else
            {
                strSql.Append("i_RelationType= null ,");
            }
            if (model.RelationID != null)
            {
                strSql.Append("RelationID=" + model.RelationID + ",");
            }
            else
            {
                strSql.Append("RelationID= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where ID=" + model.ID + "");
            int rowsAffected = DB.OleDbHelper.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_RegionRelation ");
            strSql.Append(" where ID=" + ID + "");
            int rowsAffected = DB.OleDbHelper.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }		/// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from m_RegionRelation ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DB.OleDbHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DB_Talk.Model.m_RegionRelation GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" ID,BoxID,RegionID,i_RelationType,RelationID ");
            strSql.Append(" from m_RegionRelation ");
            strSql.Append(" where ID=" + ID + "");
            DB_Talk.Model.m_RegionRelation model = new DB_Talk.Model.m_RegionRelation();
            DataSet ds = DB.OleDbHelper.GetDataSet(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"] != null && ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BoxID"] != null && ds.Tables[0].Rows[0]["BoxID"].ToString() != "")
                {
                    model.BoxID = int.Parse(ds.Tables[0].Rows[0]["BoxID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RegionID"] != null && ds.Tables[0].Rows[0]["RegionID"].ToString() != "")
                {
                    model.RegionID = ds.Tables[0].Rows[0]["RegionID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["i_RelationType"] != null && ds.Tables[0].Rows[0]["i_RelationType"].ToString() != "")
                {
                    model.i_RelationType = int.Parse(ds.Tables[0].Rows[0]["i_RelationType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RelationID"] != null && ds.Tables[0].Rows[0]["RelationID"].ToString() != "")
                {
                    model.RelationID = int.Parse(ds.Tables[0].Rows[0]["RelationID"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,BoxID,RegionID,i_RelationType,RelationID ");
            strSql.Append(" FROM m_RegionRelation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DB.OleDbHelper.GetDataSet(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,BoxID,RegionID,i_RelationType,RelationID ");
            strSql.Append(" FROM m_RegionRelation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DB.OleDbHelper.GetDataSet(strSql.ToString());
        }

        /*
        */

        #endregion  Method

        //ycf add
        public DataSet QueryPhoneMemeberList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" b.ID, b.BoxID, b.i_Number, b.vc_Name,b.vc_IP, b.LevelID,b.FapID, b.NumberTypeID, b.i_TellType,b.i_IsDispatch, b.DepartmentID, b.vc_MAC, b.i_Flag, b.vc_Memo, b.i_supplementSerive, b.i_Authority, b.i_NuPasswordType, b.i_NuPassword, b.i_UnCForwardNu, b.i_NoAnswerForward, b.i_PowerOffForward, b.i_BusyForward, b.i_DirectNum, b.i_IsAssociateActive, i_AssociateNum1, b.i_AssociateNum2, b.vc_UmtsKi, b.vc_UmtsImsi  ");
            strSql.Append(" FROM m_RegionRelation a inner join m_Member b on b.ID = a.RelationID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DB.OleDbHelper.GetDataSet(strSql.ToString());
        }

        //ycf add
        public DataSet QueryCameraMemeberList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" b.ID,b.BoxID,b.vc_Name,b.vc_Memo,b.i_ChanelID");
            strSql.Append(" FROM m_RegionRelation a inner join m_CameraInfo b on b.ID = a.RelationID");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DB.OleDbHelper.GetDataSet(strSql.ToString());
        }
    }
}

