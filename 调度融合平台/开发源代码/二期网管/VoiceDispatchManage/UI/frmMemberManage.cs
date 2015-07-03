using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl;
using BW_GridStyle;

namespace VoiceDispatchManage
{
    public partial class SystemUserManage : UI.UserControlMid
    {
        private string _tableName = "MemberList";
        //VoiceDispatchManage.Tools.DatagridViewCheckBoxHeaderCell cbHeader = new VoiceDispatchManage.Tools.DatagridViewCheckBoxHeaderCell();

        private Bestway.Windows.Controls.InputPromptDialog _NameBox = new Bestway.Windows.Controls.InputPromptDialog();
        private Bestway.Windows.Controls.InputPromptDialog _TelBox = new Bestway.Windows.Controls.InputPromptDialog();
       
        Tools.AcNetUtilsManage AcrManage = new Tools.AcNetUtilsManage();

        public SystemUserManage()
        {
            InitializeComponent();
            this.Text = "用户号码";
            this.dgvList.MultiSelect = true;
            this.txtListName.Visible = false;
            this.txtListTel.Visible = false;
        }
        
        private void SystemUserManage_Load(object sender, EventArgs e)
        {
           
            try
            {
                Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);
                string error = "";
                string file = Global.Params.FILE_PATH_REPORT + "电话用户表.apt";
                if (!AcrManage.Init(file, out error))
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show(error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadData("");
                this.txtListTel.KeyPress += new KeyPressEventHandler(txtListTel_KeyPress);
                this.txtListName.KeyPress += new KeyPressEventHandler(txtListName_KeyPress);

                this.txtListName.Visible = true;
                this.txtListTel.Visible = true;
            }
            catch
            {
                
            }
            /*
            //登录box
            Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
            bool IsDisope = false;
            try
            {
                procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在登录" + Global.Params.BOXNAME + "【" + Global.Params.BoxIP + "】,请稍等...");
                if (Global.Params.BoxHandle > 0)
                {
                    //MBoxSDK.ConfigSDK.MBOX_Logout(Global.Params.BoxHandle);
                    Global.Params.BoxHandle = 0;
                }
                Global.Params.BoxHandle = MBoxSDK.ConfigSDK.MBOX_Login(Global.Params.BoxIP, "", "", "");
                string mes = Global.Params.BoxHandle > 0 ? "成功" : "失败";          
                procDlg.Dispose();
                IsDisope = true;

                //CommControl.MessageBoxEx.MessageBoxEx.Show(Global.Params.BoxHandle.ToString());
                if (Global.Params.BoxHandle > 0)
                {
                    enablebtn(true);
                }
                else
                {
                    enablebtn(false);
                }

               

                Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);
                string error = "";
                string file = Global.Params.FILE_PATH_REPORT + "电话用户表.apt";
                if (!AcrManage.Init(file, out error))
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show(error, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadData("");
                this.txtListTel.KeyPress += new KeyPressEventHandler(txtListTel_KeyPress);
                this.txtListName.KeyPress += new KeyPressEventHandler(txtListName_KeyPress);

                this.txtListName.Visible = true;
                this.txtListTel.Visible = true;
            }
            catch
            {
                if (!IsDisope) procDlg.Dispose();
            }
            */
        }

        void cbHeader_OnCheckBoxClicked(bool state)
        {
            foreach (DataGridViewRow dr in dgvList.Rows)
            {
                if (state)
                {
                    dr.Cells[0].Value = true;
                }
                else
                {
                    dr.Cells[0].Value = false;
                }

            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!IsSetBoxNumLenAndHead())
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("还未进行基本设置，不能执行添加操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            DB_Talk.BLL.m_Member _BLL = new DB_Talk.BLL.m_Member();
            List<DB_Talk.Model.m_Member> list = new List<DB_Talk.Model.m_Member>();
            list = _BLL.GetModelList(string.Format(" i_flag=0 and BoxID='{0}'", Global.Params.BoxID));
            if (list.Count >= Global.Params.MaxBoxMemberCount)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("不能添加，号码已经达到最大限制，【{0}】个!", Global.Params.MaxBoxMemberCount), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            UI.frmMember frm = new UI.frmMember(null, 0);
            frm.ShowDialog();
            if(frm.DialogResult==DialogResult.OK)
               LoadData("");
        
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            
            if (!IsSetBoxNumLenAndHead())
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("还未进行基本设置，不能执行修改操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();
            /*
            List<DB_Talk.Model.v_Member> list = new List<DB_Talk.Model.v_Member>();
            foreach (DataGridViewRow dr in dgvList.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[0].Value.ToString()) == true)
                {

                    DB_Talk.Model.v_Member Model = (DB_Talk.Model.v_Member)dr.Tag; // dgvList.CurrentRow.Tag;
                    list.Add(Model);
                    sb.Append("," + Model.ID);
                }
            }
            */
            int count = dgvList.SelectedRows.Count;
            int operate = 0;
            List<DB_Talk.Model.v_Member> lstvModel = new List<DB_Talk.Model.v_Member>();
            //上次选中的行数
            int lastIndex = 0;
            if (dgvList.SelectedRows.Count <= 0)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要修改的人员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            lastIndex = dgvList.SelectedRows[0].Index;
            if (count > 1)
            {
                operate = 2; //修改多个
               
                foreach (DataGridViewRow item in dgvList.SelectedRows)
                {
                   
                    DB_Talk.Model.v_Member _mModel = (DB_Talk.Model.v_Member)item.Tag; // dgvList.CurrentRow.Tag;
                    bool b = MBoxSDK.ConfigSDK.MBOX_IsSubscriberExist(Global.Params.BoxHandle, _mModel.i_Number.Value);
                    if (b == false)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(Global.Params.BOXNAME + "【" + Global.Params.BoxIP + "】中已经不存在此用户,不能再进行修改，只能进行删除操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                  
                    lstvModel.Add(_mModel); 
                }
                //CommControl.MessageBoxEx.MessageBoxEx.Show("一次只允许编辑一个人员，请重新选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if(count == 1)
            {
                operate = 1;
                DB_Talk.Model.v_Member Model = (DB_Talk.Model.v_Member)dgvList.CurrentRow.Tag; //list[0];// 
                if (Model != null)
                {
                    bool b = MBoxSDK.ConfigSDK.MBOX_IsSubscriberExist(Global.Params.BoxHandle, Model.i_Number.Value);
                    if (b==false)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(Global.Params.BOXNAME + "【" + Global.Params.BoxIP + "】中已经不存在此用户,不能再进行修改，只能进行删除操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    lstvModel.Add(Model); 
                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要编辑的人员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            UI.frmMember fu = new UI.frmMember(lstvModel, operate);
            fu.ShowDialog();
            if (fu.DialogResult == DialogResult.OK)
                LoadData("");
           // dgvList.CurrentCell = dgvList[lastIndex, 0];
            dgvList.ClearSelection();
            if (lastIndex<dgvList.Rows.Count)
            {
                dgvList.Rows[lastIndex].Selected = true;
                dgvList.CurrentCell = dgvList[1,lastIndex];
            }
            
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            int lastIndex = 0;
            try
            {
                int count = dgvList.SelectedRows.Count;
               
                if (count >= 1)
                {
                    lastIndex = dgvList.SelectedRows[0].Index;
                    Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
                     DialogResult dr = DialogResult.No;
                     string mesQuestion = "";

                     if (dgvList.SelectedRows.Count > 1)
                     {
                         mesQuestion = "确认要删除选中的 【" + dgvList.SelectedRows.Count + "】个用户吗? 如果用户已经被添加到组，组中也会被删除!";
                         dr = CommControl.MessageBoxEx.MessageBoxEx.Show(mesQuestion, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                     }
                     else if (dgvList.SelectedRows.Count == 1)
                     {
                         DB_Talk.Model.v_Member Model = (DB_Talk.Model.v_Member)dgvList.SelectedRows[0].Tag; // dgvList.CurrentRow.Tag;
                        
                         if (new DB_Talk.BLL.m_GroupMembers().Exists("MemberID='" + Model.ID + "'"))
                         {
                             mesQuestion = "用户【" + Model.vc_Name + "】已经被添加到组，如果删除用户，组中也会删除,确认删除吗?";
                         }
                         else
                             mesQuestion = "确认要删除 【" + Model.vc_Name + "】吗?";
                         dr = CommControl.MessageBoxEx.MessageBoxEx.Show(mesQuestion, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                     }

                     if (dr == DialogResult.OK)
                     {
                         StringBuilder mesOK = new StringBuilder();
                         StringBuilder mesMemberID = new StringBuilder();
                         StringBuilder mesNO = new StringBuilder();
                         int OK = 0, NO = 0;
                         DateTime dtstart = System.DateTime.Now;
                         foreach (DataGridViewRow item in dgvList.SelectedRows)
                         {
                             DB_Talk.Model.v_Member _mModel = (DB_Talk.Model.v_Member)item.Tag; // dgvList.CurrentRow.Tag;
                             //2013-6-13 修改，在删除前判断，存在的号码才删除（因为有时候数据库里面有的号码，box里面没有，直接删除会返回false）
                             bool IsExist = MBoxSDK.ConfigSDK.MBOX_IsSubscriberExist(Global.Params.BoxHandle,(_mModel.i_Number.Value));
                             CommControl.Tools.WriteLog.AppendLog("box添加号码", "删除号码操作，boxHandle：" + Global.Params.BoxHandle + ", 号码：" + Convert.ToInt32(_mModel.i_Number.ToString()) + ", 是否存在：" + IsExist);

                             if (IsExist)
                             {
                                 //System.Threading.Thread.Sleep(500);
                                 if (MBoxSDK.ConfigSDK.MBOX_DeleteSubscriber(Global.Params.BoxHandle, (_mModel.i_Number.Value)))
                                 {
                                     RemoveAssociateNum(_mModel);
                                     mesMemberID.Append("," + _mModel.ID);
                                     mesOK.Append("," + _mModel.vc_Name);
                                     OK++;
                                     CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID,CommControl.SystemLogBLL.EnumLogAction.Delete, "删除(box中存在)","删除了人员：" + _mModel.vc_Name, "");
                                     procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在删除用户【" + _mModel.vc_Name + "】，请稍等...");
                                 }
                                 else
                                 {
                                     CommControl.Tools.WriteLog.AppendLog("box中存在，删除人员：" + _mModel.vc_Name + "失败");
                                     CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Delete, "删除失败(box中存在)", "删除了人员：" + _mModel.vc_Name + "失败", "");
                                     mesNO.Append("," + _mModel.vc_Name);
                                     NO++;
                                 }
                             }
                             else
                             {
                                 RemoveAssociateNum(_mModel);
                                 mesMemberID.Append("," + _mModel.ID);
                                 mesOK.Append("," + _mModel.vc_Name);
                                 OK++;
                                 CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Delete, "删除(box中不存在)", "删除了人员：" + _mModel.vc_Name, "");
                             }
                         }
                         string mes = "";
                         bool bSave = false;
                         if (OK > 0)
                         {
                             bSave = MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle); //保存更改
                             mesMemberID.Remove(0, 1);
                             mesOK.Remove(0, 1);
                         }
                         DateTime dtEnd = System.DateTime.Now;
                         TimeSpan sp = dtEnd - dtstart;
                         CommControl.Tools.WriteLog.AppendLog("删除" + dgvList.SelectedRows.Count + "个用户，时间：" + sp.TotalMilliseconds + "ms");
                         if (bSave)
                         {
                             if (new DB_Talk.BLL.m_Member().DeleteList(mesMemberID.ToString()))
                             {
                                      
                                 //CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, 
                                 //    CommControl.SystemLogBLL.EnumLogAction.Delete, "删除", 
                                 //    "删除了人员：" + mesOK.ToString(), "");
                                 if (mesOK.Length > 0 && OK > 0 && OK < 10)
                                 {
                                     mes = "删除【" + mesOK.ToString() + "】成功!";
                                 }
                                 else
                                 {
                                     mes = "删除【" + OK + "】个用户成功!";
                                 }
                                 LoadData("");
                             }
                             else
                                 mes = "数据库删除【" + OK + "】个用户失败!";
                         }
                         else if (OK != 0)
                         {
                              mes = "硬件保存配置失败!";
                         }
                         if (mesNO.Length > 0)
                         {
                             mesNO.Remove(0, 1);
                             mes = "从硬件中删除【" + mesNO.ToString() + "】失败!";
                         }
                         procDlg.Dispose();
                         CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                 }
                 else
                 {
                     CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要删除的人员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                 }
            }
            catch{}
            LoadData("");

            dgvList.ClearSelection();
            if (lastIndex < dgvList.Rows.Count)
            {
                dgvList.Rows[lastIndex].Selected = true;
                dgvList.CurrentCell = dgvList[1, lastIndex];
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!IsSetBoxNumLenAndHead())
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("还未进行基本设置，不能执行添加操作!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           UI.frmExportMember frm = new UI.frmExportMember();
           frm.ShowDialog();
           if (frm.DialogResult == DialogResult.OK)
               LoadData("");

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dr in dgvList.Rows)
            {
                dr.Selected=true;
            }
            /*
            cbHeader._checked = true;
            cbHeader_OnCheckBoxClicked(true);
            this.dgvList.Refresh();
             */
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgvList.Rows)
            {
                dr.Selected = !dr.Selected;
            }

            /*
            bool isSelectAll = true;
            foreach (DataGridViewRow dr in dgvList.Rows)
            {
                dr.Cells[0].Value = !Convert.ToBoolean(dr.Cells[0].Value);
                if (Convert.ToBoolean(dr.Cells[0].Value) == false)
                    isSelectAll = false;

            }
            if (isSelectAll) cbHeader._checked = true;
            else cbHeader._checked = false;
            this.dgvList.Refresh();
             */
        }


        private void btnStyle_Click(object sender, EventArgs e)
        {
            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableName, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);
            AcrManage.AddVariable(dgvList);
            //Tools.AcrReportManage.Current.AddVariable(dgvList);
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            txtListName.Text = "";
            txtListTel.Text = "";

            LoadData("");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string mes = AcrManage.Print();
            if (mes != "")
                CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
            //Tools.AcrReportManage.Current.SetReportFile("电话用户表.apt");
            //Tools.AcrReportManage.Current.Print();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string mes = AcrManage.Preview();
            if (mes != "")
                CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
            //Tools.AcrReportManage.Current.SetReportFile("电话用户表.apt");
            //Tools.AcrReportManage.Current.PreView();
        }

        private void btnDesigner_Click(object sender, EventArgs e)
        {
            string mes = AcrManage.ShowDesigner();
            if (mes != "")
                CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
            //Tools.AcrReportManage.Current.SetReportFile("电话用户表.apt");
            //Tools.AcrReportManage.Current.ShowDesigner();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string strWhere = getStrSearch();
                //if (strWhere != "")
                {
                    LoadData(strWhere);
                }
            }
            catch(Exception ex)
            {
            }
        }


        #region 方法

        private bool IsSetBoxNumLenAndHead()
        {
            DB_Talk.Model.m_Box model = new DB_Talk.BLL.m_Box().GetModel(Global.Params.BoxID);
            Global.Params.strNumHead = model.vc_NumberHead;
            Global.Params.NumberLen = model.i_NumberLen == null ? 0 : model.i_NumberLen.Value;

            if (model != null && !string.IsNullOrEmpty(model.vc_NumberHead) && (model.i_NumberLen > 0))
            {
                return true;
            }
            else
                return false;
        }

        public void LoadData(string strwhere)
        {
           Bestway.Windows.Forms.ProgressBarDialog procDlg = null;
            procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
            try
            {
                procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在加载数据，请稍等...");
                //cbHeader._checked = false;
                dgvList.Rows.Clear();

                List<DB_Talk.Model.v_Member> lst = new List<DB_Talk.Model.v_Member>();
                lst = new DB_Talk.BLL.v_Member().GetModelList("i_Flag=0 and BoxID='" + Global.Params.BoxID + "' and i_IsDispatch=0 " + strwhere);

                int i = 0;
                foreach (DB_Talk.Model.v_Member item in lst)
                {
                    i++;
                    string numberType = "", level, telType = "",strAuthority="";
                    if (item.NumberTypeID != null)
                        numberType = ((CommControl.PublicEnums.EnumNumberType)item.NumberTypeID).ToString().Replace("_", "-");
                    if (item.i_TellType != null)
                        telType = ((CommControl.PublicEnums.EnumTelType)item.i_TellType).ToString().Replace("G3","G"); ;
                    if (item.LevelID == null) 
                        level = "";
                    else 
                        level = ((PublicEnums.EnumLevel)item.LevelID).ToString();

                    string paswType = "";
                    if (item.NumberTypeID != CommControl.PublicEnums.EnumNumberType.手机3G.GetHashCode())
                        paswType = item.i_NuPasswordType == 1 ? "固定" : "增加";
                    dgvList.Rows[dgvList.Rows.Add(item.ID," " + i,
                        item.vc_Name,
                        item.i_Number,
                        item.deptName,
                        paswType,
                        item.i_NuPassword == 0 ? "" : item.i_NuPassword.ToString(),
                        item.TellAuthority,
                        item.TellType,    //telType,          //item.TellType,
                        level,            //item.LevelName,
                        item.vc_UmtsImsi,
                        item.i_UnCForwardNu,
                        item.i_NoAnswerForward,
                        item.i_BusyForward,
                        item.i_PowerOffForward,
                        item.i_AssociateNum1,
                        item.i_AssociateNum2,
                        item.vc_Memo,
                        item.vc_IP

                        )].Tag = item;
                }
                kryptonHeaderGroup1.ValuesSecondary.Heading = "  共" + dgvList.Rows.Count.ToString() + "个人员";
                //Tools.AcrReportManage.Current.RefushDataset();
                //loadReport(strwhere);
                loadReport();
                InitListBoxName();
                InitListBoxTel();
            }
            catch(Exception ex)
            {
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
            }
            finally
            {
                procDlg.Dispose();
            }

           
        }

        private void loadReport()
        {
            AcrManage.AddVariable(this.dgvList);
            AcrManage.FillDataTableToAcFromGridView(this.dgvList);
        }

        private void enablebtn(bool enable)
        {
            btnAdd.Enabled = enable;
            btnDel.Enabled = enable;
            btnExport.Enabled = enable;
            btnModify.Enabled = enable;
        }

        private void InitListBoxName()
        {
            //姓名
            //DataSet ds = (new DB_Talk.BLL.v_Member()).GetModelList(" (vc_telphone!='' or vc_email!='')", _spIDs);
            //DataSet ds = (new DB_Talk.BLL.v_Member()).GetList("i_Flag=0 and BoxID='" + Global.Params.BoxID + "'");
            DataSet ds = (new DB_Talk.BLL.v_Member()).GetListSql("select ID,vc_Name,i_Number from v_Member where i_Flag=0 and BoxID='" + Global.Params.BoxID + "'  and i_IsDispatch=0 ");
            DataTable dt = ds.Tables[0];
            //int[] hideTypeCol = { 1,2,5, 6, 7,8,9,10,11,12,13,14,15,16,17,18,19,20 };
            int[] hideTypeCol = { 1,3 };
          
            // strSql.Append("  ID, BoxID, i_Number, vc_Name, LevelID, NumberTypeID, i_TellType, i_IsDispatch, DepartmentID, vc_MAC, i_Flag, vc_Memo, i_supplementSerive, i_Authority, i_NuPassword, i_UnCForwardNu, i_NoAnswerForward, i_PowerOffForward, i_BusyForward, i_DirectNum, i_AssociateNum1, i_AssociateNum2, vc_UmtsKi, vc_UmtsImsi, NumberType, TellType, IsDispatch, LevelName, deptName, BoxName, vc_IP, vc_SN  ");			
		
            this.txtListName.OnDropDown += new EventHandler(txtListName_OnDropDown);
            if (dt.Rows.Count > 0)
            {
                dt.Columns[1].ColumnName = "姓名";
                dt.Columns[2].ColumnName = "电话";
                //dt.Columns[3].ColumnName = "邮箱";
                _NameBox.Bind(this.txtListName.txtValue, dt, 2, hideTypeCol);
                _NameBox.OnTextChangedEx += new Bestway.Windows.Controls.InputPromptDialog.TextChangedEx(_NameBox_OnTextChangedEx);
                
            }
            else
            {
                _NameBox.ClearBind();
            }
          

        }
        void txtListName_OnDropDown(object sender, EventArgs e)
        {
            _NameBox.ShowDropDown();
        }
        void _NameBox_OnTextChangedEx(object sender, Bestway.Windows.Controls.InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
            }
            else
            {
            }
        }

        private void InitListBoxTel()
        {
            //姓名
            //DataSet ds = (new DB_Talk.BLL.v_Member()).GetModelList(" (vc_telphone!='' or vc_email!='')", _spIDs);
           // DataSet ds = (new DB_Talk.BLL.v_Member()).GetList("i_Flag=0 and BoxID='" + Global.Params.BoxID + "'");
            DataSet ds = (new DB_Talk.BLL.v_Member()).GetListSql("select ID,vc_Name,i_Number from v_Member where i_Flag=0 and BoxID='" + Global.Params.BoxID + "' and i_IsDispatch=0 ");
           
            DataTable dt = ds.Tables[0];
            //int[] hideTypeCol = { 1, 2, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            int[] hideTypeCol = { 1,2};
           
            //strSql.Append("select  ID, BoxID, i_Number, vc_Name, LevelID, NumberTypeID, i_TellType, i_IsDispatch, DepartmentID, vc_MAC, i_Flag, vc_Memo, NumberType, TellType, IsDispatch, LevelName, deptName, BoxName, vc_IP, vc_SN  ");			

            this.txtListTel.OnDropDown += new EventHandler(txtListTel_OnDropDown);

            if (dt.Rows.Count > 0)
            {
                dt.Columns[1].ColumnName = "姓名";
                dt.Columns[2].ColumnName = "电话";
                //dt.Columns[3].ColumnName = "邮箱";
                _TelBox.Bind(this.txtListTel.txtValue, dt, 3, hideTypeCol);
                _TelBox.OnTextChangedEx += new Bestway.Windows.Controls.InputPromptDialog.TextChangedEx(_TelBox_OnTextChangedEx);

            }
            else
            {
                _TelBox.ClearBind();
            }

        }

        void _TelBox_OnTextChangedEx(object sender, Bestway.Windows.Controls.InputPromptDialog.TextChanagedEventArgs e)
        {
           
                if (e.IsFind)
                {
                }
                else
                {
                }
            
        }

        void txtListTel_OnDropDown(object sender, EventArgs e)
        {
            _TelBox.ShowDropDown();
        }

        private void txtListName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 13)
                {
                    btnSearch_Click(null, null);
                }
            }
            catch { }
        }

        void txtListTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //CommControl.Tools.WriteLog.AppendLog("lst",e.KeyChar.ToString());
                if ((int)e.KeyChar == 13)
                {
                    btnSearch_Click(null, null);
                }
            }
            catch { }
        }

        private string getStrSearch()
        {
            string strWhere = "";
           
            if (txtListName.Text != "")
            {
                strWhere += " and vc_name='" + txtListName.Text.Replace("'","") + "' ";
            }
            if (txtListTel.Text != "")
            {
                 int number = 0;
                 if (int.TryParse(txtListTel.Text, out number))
                 {
                     strWhere += " and i_Number='" + txtListTel.Text + "' ";
                 }
                 else
                 {
                     strWhere += " and i_Number='0'";
                 }
              
            }

            return strWhere;
        }


        private void RemoveAssociateNum(DB_Talk.Model.v_Member vmodel)
        {
            List<DB_Talk.Model.m_Member> lst = new List<DB_Talk.Model.m_Member>();
            string strW = string.Format(" i_flag=0 and i_IsDispatch=0 and BoxID='{0}' ", Global.Params.BoxID);
            if (vmodel.i_AssociateNum1 > 0)
                strW = strW + string.Format(" and i_Number='{0}'", vmodel.i_AssociateNum1);
            if (vmodel.i_AssociateNum2 > 0)
                strW = strW + string.Format(" or i_Number='{0}'", vmodel.i_AssociateNum2);
            if (vmodel.i_AssociateNum1 > 0 || vmodel.i_AssociateNum2 > 0)
               lst = new DB_Talk.BLL.m_Member().GetModelList(strW);
            foreach(DB_Talk.Model.m_Member item in lst)
            {
                item.i_AssociateNum1 = 0;
                item.i_AssociateNum2 = 0;
                item.i_IsAssociateActive = 0;  //取消被动关联
                item.i_supplementSerive &= (uint)(~MBoxSDK.ConfigSDK.SPM_ASSO_NUM);  //去关联
                new DB_Talk.BLL.m_Member().Update(item);
            }

        }

        #endregion

        /*

        private void loadReport(string strWhere)
        {
            Tools.AcrReportManage.Current.SetReportFile("电话用户表.apt");
            string strW = ("i_Flag=0 and BoxID='" + Global.Params.BoxID + "'" + strWhere);
            string sql = "select (select count(1)+1 from  v_Member as b where b.id<a.id and " + strW + " )as 序号," +
                     " vc_Name as 用户姓名,NumberType as 用户类别,deptName as 部门,i_Number as 电话, " +
                     " LevelName as 级别,vc_MAC as MAC,vc_Memo as 备注,TellType 电话类型,IsDispatch as 是否调度号码" +
                     " from v_Member" +
                     " as a" +
                     " where " + strW;

            //string sql = "select (select count(1)+1 from  v_Member as b where b.id<a.id and " + strW + " )as 序号," +
            //          " vc_Name as 姓名,deptName as 部门,i_Number as 电话, " +
            //          " (case NumberTypeID when 1 then 'SIP' when 2 then 'SO-PS' end) as 用户类别, " +
            //          " LevelID," +
            //          " vc_MAC as MAC,vc_Memo as 备注 "+
            //          " (case i_IsDispatch when 1 then 'SIP' when 2 then 'SO-PS' end) as 用户类别, " +
            //          " from v_Member" +
            //          " as a" +
            //          " where " + strW;
            //select   (select   count(1)+1   from   v_Member  as  b   where   b.id<a.id   )  as  序号,a.*   from   v_Member as a 

            Tools.AcrReportManage.Current.AddDatasetsToAC(sql, "主表");
            Tools.AcrReportManage.Current.AddVariable(dgvList);
        }

        public override void RefushDataReport()
        {
            //base.RefushDataReport();
            loadReport("");
        }

        */
    }
}
