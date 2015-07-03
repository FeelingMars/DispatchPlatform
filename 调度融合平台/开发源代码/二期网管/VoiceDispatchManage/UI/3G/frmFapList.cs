using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl.MessageBoxEx;

namespace VoiceDispatchManage.UI
{
    public partial class frmFapList : UserControlMid
    {
        public frmFapList()
        {
            InitializeComponent();
            dgvList.CellDoubleClick += new DataGridViewCellEventHandler(dgvList_CellDoubleClick);
        }

        void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex>=0 && e.RowIndex>=0)
            {
                if (int.Parse(dgvList.Rows[e.RowIndex].Cells["colPhoneCount"].Value.ToString()) > 0)
                {
                    frmFapMemberList fl = new frmFapMemberList(int.Parse(dgvList.Rows[e.RowIndex].Cells["colID"].Value.ToString()));
                    fl.ShowDialog();
                }
                else
                {
                    MessageBoxEx.Show("当前基站下没有手机!", "提示");
                }
            }
        }

        private void frmFap_Load(object sender, EventArgs e)
        {
            this.Text = "基站管理";
           
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);
            UpdateDB();
            LoadData();
            timer1.Interval = 1000 * 10;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            this.VisibleChanged += new EventHandler(frmFapList_VisibleChanged);
        }

        void frmFapList_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible==false)
            {
                timer1.Enabled = false;    
            }
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow     item in dgvList.Rows)
            //{
            //    DB_Talk.Model.m_FAP model = (DB_Talk.Model.m_FAP)item.Tag;
            //    List<DB_Talk.Model.m_Member> lstMember = new DB_Talk.BLL.m_Member().GetModelList(string.Format("i_Flag=0 and FapID={0} and BoxID={1}", model.ID, Global.Params.BoxID));
            //    if (lstMember != null && lstMember.Count > 0)
            //    {
            //        item.Cells["colPhoneCount"].Value = lstMember.Count;
            //    }
            //}
            UpdateDB();
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmFap frm = new frmFap(0);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                LoadData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                DB_Talk.Model.m_FAP typeModel = (DB_Talk.Model.m_FAP)dgvList.CurrentRow.Tag;
                if (typeModel != null)
                {
                    if (CommControl.MessageBoxEx.MessageBoxEx.Show("确认要删除基站 【" + typeModel.vc_Name + "】 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (Tools.MBoxOperate.DeleteFAP(typeModel) && new DB_Talk.BLL.m_FAP().Delete(typeModel.ID))
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Delete, "删除", "删除了基站：" + typeModel.vc_Name, "");
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
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要删除的基站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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


        private string _tableName = "3GFapList";
        private void btnStyle_Click(object sender, EventArgs e)
        {
            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableName, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);

        }




        #region 私有方法

        /// <summary>
        /// 取基站状态
        /// </summary>
        /// <param name="lst"></param>
        /// <param name="fapID"></param>
        /// <returns></returns>
        private string GetFapState(List<DB_Talk.Model.m_FAP> lst, int fapID)
        {
            DB_Talk.Model.m_FAP model = lst.Find(p => p.FapID == fapID);
            if (model != null)
            {
                if (model.i_ConfState == 0)
                {
                    return "未知";
                }

                if (model.i_ConfState == 1)
                {
                    return "未注册";
                }

                if (model.i_ConfState == 2)
                {
                    return "注册成功";
                }
                if (model.i_ConfState == 3)
                {
                    return "不可用";
                }

            }

            return "未知";

        }


        public void LoadData()
        {
            dgvList.Rows.Clear();
            List<DB_Talk.Model.m_FAP> lst = new List<DB_Talk.Model.m_FAP>();
            lst = new DB_Talk.BLL.m_FAP().GetModelList(string.Format("i_Flag=0 and BoxID='{0}' ", Global.Params.BoxID));
            int i = 0;


            //从BOX中取
            List<DB_Talk.Model.m_FAP> lstBoxFap = new List<DB_Talk.Model.m_FAP>();
            Tools.MBoxOperate.GetFAP(out lstBoxFap);

            foreach (DB_Talk.Model.m_FAP item in lst)
            {
                i++;
                List<DB_Talk.Model.m_Member> lstMember = new DB_Talk.BLL.m_Member().GetModelList(string.Format("i_Flag=0 and FapID={0} and BoxID={1}", item.ID,Global.Params.BoxID));
                int phoneCount = 0;
                if (lstMember!=null && lstMember.Count>0)
                {
                    phoneCount = lstMember.Count;
                }
                string fapState=GetFapState(lstBoxFap,item.FapID);
                if (fapState!="注册成功")
                {
                    phoneCount = 0;
                }
                dgvList.Rows[dgvList.Rows.Add(item.ID,
                        item.FapID,
                        item.vc_TempAddress,
                        fapState,
                        item.vc_Name,
                        item.vc_Identify,
                        phoneCount
                        )].Tag = item;
            }

           
           
            kryptonHeaderGroup1.ValuesSecondary.Heading = "  共" + dgvList.Rows.Count.ToString() + "条记录";
            
        }

        private void UpdateDB()
        {
            //同步数据库数据
            List<DB_Talk.Model.m_FAP> lstBoxFap = new List<DB_Talk.Model.m_FAP>();
            Tools.MBoxOperate.GetFAP(out lstBoxFap);
            //new DB_Talk.BLL.m_StaticRoute().Delete(string.Format(" BoxID='{0}'", Global.Params.BoxID));
            DB_Talk.BLL.m_FAP bll = new DB_Talk.BLL.m_FAP();
            foreach (DB_Talk.Model.m_FAP m in lstBoxFap)
            {
                if (bll.Exists(string.Format("i_Flag=0 and BoxID='{0}' and FapID='{1}'", Global.Params.BoxID, m.FapID)) == false)
                {
                    bll.Add(m);
                }
            }
            List<DB_Talk.Model.m_FAP> lstDBFap = new List<DB_Talk.Model.m_FAP>();
            lstDBFap = new DB_Talk.BLL.m_FAP().GetModelList(string.Format("i_Flag=0 and BoxID='{0}' ", Global.Params.BoxID));

            foreach (DB_Talk.Model.m_FAP m in lstDBFap)
            {
                if (lstBoxFap.Exists(p => p.FapID == m.FapID) == false)
                {
                    bll.Delete(m.ID);
                }
                else
                {
                    m.vc_TempAddress = lstBoxFap.Find(p => p.FapID == m.FapID).vc_TempAddress;
                    bll.Update(m);
                }
            }
         
        }

        #endregion

     
    }
}
