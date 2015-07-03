using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VoiceDispatchManage.UI
{
    public partial class frmStaticRouteList : UserControlMid
    {
        public frmStaticRouteList()
        {
            InitializeComponent();
        }

        private void frmStaticRouteList_Load(object sender, EventArgs e)
        {
            this.Text = "静态路由管理";
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);
            UpdateDB();
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmStaticRoute frm = new frmStaticRoute(0);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                DB_Talk.Model.m_StaticRoute typeModel = (DB_Talk.Model.m_StaticRoute)dgvList.CurrentRow.Tag;
                if (typeModel != null)
                {
                    if (CommControl.MessageBoxEx.MessageBoxEx.Show("确认要删除静态路由 【" + typeModel.vc_NetIP + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (Tools.MBoxOperate.DeleteStaticRouting(typeModel) && new DB_Talk.BLL.m_StaticRoute().Delete(typeModel.ID))
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Delete, "删除", "删除了静态路由：" + typeModel.vc_NetIP, "");
                            LoadData();
                        }
                        else
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show("删除失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要删除的静态路由", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            UpdateDB();
            LoadData();
        }


        private string _tableName = "3GStaticRouteList";
        private void btnStyle_Click(object sender, EventArgs e)
        {
            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableName, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);

        }




        #region 私有方法

        private void LoadData()
        {
            dgvList.Rows.Clear();
            List<DB_Talk.Model.m_StaticRoute> lst = new List<DB_Talk.Model.m_StaticRoute>();
            lst = new DB_Talk.BLL.m_StaticRoute().GetModelList(string.Format("i_Flag=0 and BoxID='{0}' ", Global.Params.BoxID));
           
            int i = 0;
            foreach (DB_Talk.Model.m_StaticRoute item in lst)
            {
                i++;
                dgvList.Rows[dgvList.Rows.Add(item.ID,
                        item.vc_NetIP,
                        item.vc_Mask,
                        item.vc_GateWayIP
                        )].Tag = item;
            }

            kryptonHeaderGroup1.ValuesSecondary.Heading = "  共" + dgvList.Rows.Count.ToString() + "条记录";

        }

        private void UpdateDB()
        {
            //同步数据库数据
            List<DB_Talk.Model.m_StaticRoute> lst = new List<DB_Talk.Model.m_StaticRoute>();
            Tools.MBoxOperate.GetStaticRouting(out lst);
            //new DB_Talk.BLL.m_StaticRoute().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
            DB_Talk.BLL.m_StaticRoute bll = new DB_Talk.BLL.m_StaticRoute();
            if (lst!=null && lst.Count==0)
            {
                bll.ExecuteSql(string.Format("delete from m_StaticRoute where BoxID='{0}'", Global.Params.BoxID));
            }
            foreach (DB_Talk.Model.m_StaticRoute m in lst)
            {
                if (!bll.Exists(string.Format("i_Flag=0 and BoxID='{0}' and vc_NetIP='{1}'", Global.Params.BoxID, m.vc_NetIP)))
                    bll.Add(m);
            }
        }

        #endregion

       
    }
}
