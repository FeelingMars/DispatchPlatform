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
    public partial class frmPDSList : UserControlMid
    {
        public frmPDSList()
        {
            InitializeComponent();
        }

        private void frmPDS_Load(object sender, EventArgs e)
        {
            this.Text = "分组网关管理";
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);
            UpdateDB();
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPDS frm = new frmPDS(0);
            frm.Show();
            if (frm.DialogResult == DialogResult.OK)
                LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                DB_Talk.Model.m_PDS typeModel = (DB_Talk.Model.m_PDS)dgvList.CurrentRow.Tag;
                if (typeModel != null)
                {
                    if (CommControl.MessageBoxEx.MessageBoxEx.Show("确认要删除分组网关 【" + typeModel.vc_IP + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (Tools.MBoxOperate.DeletePDS(typeModel) && new DB_Talk.BLL.m_StaticRoute().Delete(typeModel.ID))
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Delete, "删除", "删除了分组网关：" + typeModel.vc_IP, "");
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
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要删除的分组网关", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {

        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private string _tableName = "3GPDSList";
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
            List<DB_Talk.Model.m_PDS> lst = new List<DB_Talk.Model.m_PDS>();
            //lst = new DB_Talk.BLL.m_PDS().GetModelList("i_Flag=0");
            lst = new DB_Talk.BLL.m_PDS().GetModelList(string.Format("i_Flag=0 and BoxID='{0}' ", Global.Params.BoxID));
         
            int i = 0;
            foreach (DB_Talk.Model.m_PDS item in lst)
            {
                i++;
                dgvList.Rows[dgvList.Rows.Add(item.ID,
                        item.PdsID,
                        item.vc_IP
                        )].Tag = item;
            }

            kryptonHeaderGroup1.ValuesSecondary.Heading = "  共" + dgvList.Rows.Count.ToString() + "条记录";
             
        }

        private void UpdateDB()
        {
            //同步数据库数据
            List<DB_Talk.Model.m_PDS> lst = new List<DB_Talk.Model.m_PDS>();
            Tools.MBoxOperate.GetPDS(out lst);
            //new DB_Talk.BLL.m_StaticRoute().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
            DB_Talk.BLL.m_PDS bll = new DB_Talk.BLL.m_PDS();
            foreach (DB_Talk.Model.m_PDS m in lst)
            {
                if (!bll.Exists(string.Format("i_Flag=0 and BoxID='{0}' and PdsID='{1}'", Global.Params.BoxID, m.PdsID)))
                    bll.Add(m);
            }
        }

        #endregion

    }
}
