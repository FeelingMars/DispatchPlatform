using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl;
using System.Net;

namespace VoiceDispatchManage.UI
{
    public partial class frmMember : frmBase
    {

        private DB_Talk.Model.m_Member _mModel = new DB_Talk.Model.m_Member();
        private DB_Talk.Model.m_Member _mPreModel = new DB_Talk.Model.m_Member();

        private DB_Talk.BLL.m_Member _BLL = new DB_Talk.BLL.m_Member();

        private DB_Talk.Model.v_Member _vModel = new DB_Talk.Model.v_Member();
        private DB_Talk.BLL.v_Member _vBLL = new DB_Talk.BLL.v_Member();
        
        private List<DB_Talk.Model.v_Member> _lstvModel = new List<DB_Talk.Model.v_Member>();

        MBoxSDK.ConfigSDK.subscriberServiceDetail subService = new MBoxSDK.ConfigSDK.subscriberServiceDetail();
        int PreDispatch = -1;
        int preSupplementSerive=(int)(MBoxSDK.ConfigSDK.SPM_MISS_CALL | MBoxSDK.ConfigSDK.SPM_MISS_CALL_ON_BUSY | MBoxSDK.ConfigSDK.SPM_SMS);
        int _operate;
        int preNumber = 0;  //记录未修改前的号码
        long addCount = 0;   //批量添加总数
        public frmMember(List<DB_Talk.Model.v_Member> lstvModel, int operate)//DB_Talk.Model.v_Member model, )
        {
            InitializeComponent();
          
            this.cmbNoType.SelectedIndexChanged+=new EventHandler(cmbNoType_SelectedIndexChanged);
            this.Load += new EventHandler(frmMember_Load);
           
            _operate = operate;
            if (operate == 0)
            {
                this.FormTitle = "添加";
                btnOK.Text = "添加";
            }
            else if(operate==1) //修改一个
            {
                _vModel = lstvModel[0];// model;
                _mModel = _BLL.GetModel(_vModel.ID);
                _mPreModel = (DB_Talk.Model.m_Member)_mModel.Clone();
                preNumber =int.Parse(_mModel.i_Number.ToString());
                this.FormTitle = "编辑";
                btnOK.Text = "编辑";
                txtTelEnd.Enabled = false;
                ShowModel();
            }
            else if (operate == 2)
            {
                this.FormTitle = "编辑多个";
                btnOK.Text = "编辑多个";
                txtName.Enabled = false;
                txtTel.Enabled = false;
                txtTelEnd.Enabled = false;
                cmbNoType.Enabled = false;
                txtUmtsImsi.Enabled = false;
                btnG.Enabled = false;
                _lstvModel = lstvModel;
               
            }

            //if (operate != 2)
            //{
                InitCmb();
                if (Global.Params.ConfigModel.SystemConfig.MaxNameTextLengh != 0)
                    this.txtName.MaxLength = Global.Params.ConfigModel.SystemConfig.MaxNameTextLengh;//  Global.Params.NameLen;

                this.txtTel.MaxLength = Global.Params.NumberLen;
                this.txtTelEnd.MaxLength = Global.Params.NumberLen;
            //}

                if (operate == 2)
                {
                    ShowModelMuti();
                }
        }

       

      
        void frmMember_Load(object sender, EventArgs e)
        {
            SetTxtLeng();
            this.Height = 312;
            groupBoxG.Visible = false;
            ClickCount = 0;
            this.panelWorkArea.Paint += new PaintEventHandler(panelWorkArea_Paint);
            this.Top = Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2;
            
        }

        void panelWorkArea_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(panelWorkArea.Left, 0, 563, 480);
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(r, Color.FromArgb(175, 210, 255), Color.White, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, e.ClipRectangle);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (_operate != 2)  //添加或者修改1个
                    GetModel();
                else  //编辑多个
                {
                    _mModel = _BLL.GetModel(_lstvModel[0].ID);
                    GetModelMuti(ref _mModel );
                }
            }
            catch (Exception ex)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                if (btnOK.Text == "添加")
                {
                    if (addCount > 0)
                        AddMutiTel();
                    else
                    {
                        if (string.IsNullOrEmpty(_mModel.vc_Name)) _mModel.vc_Name=_mModel.i_Number.ToString();
                        Add();
                    }
                }
                else if (btnOK.Text == "编辑")
                {
                    Modify();
                }
                else if (btnOK.Text == "编辑多个")
                {
                    ModifyMuti();
                }
            }
            catch
            {
            }

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int ClickCount = 0;
        private void txtTelEnd_TextChanged(object sender, EventArgs e)
        {
            if (txtTelEnd.Text.Trim() != "")
            {
                txtName.Enabled = false;
                if (txtUmtsImsi.Enabled == true)
                {
                    label10.Text = "起始标示码：";
                    label10.Location = new Point(202, 166);
                }
                //批量不允许高级设置功能
                if (groupBoxG.Visible == true)
                {
                    this.Width = 561;
                    this.Height = 287;
                    groupBoxG.Visible = false;
                    ClickCount = 0;
                }
                btnG.Enabled = false;
            }
            else
            {
                if (_operate != 2)
                {
                    txtName.Enabled = true;
                    if (txtUmtsImsi.Enabled == true)
                    {
                        label10.Text = "标示码：";
                        label10.Location = new Point(224, 164);
                    }
                    btnG.Enabled = true;
                }
            }
          
          
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            if (ClickCount == 0)
            {
                this.Width = 570;
                this.Height = 494;
                groupBoxG.Visible = true;
                ClickCount++;               
            }
            else
            {
                this.Width = 570;
                this.Height = 312;
                groupBoxG.Visible = false;
                ClickCount = 0;
            }
            //this.StartPosition = FormStartPosition.CenterScreen;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2;
                
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 _mModel.DepartmentID = int.Parse(cmbDept.SelectedValue.ToString());
            }
            catch{}
        }
        private void cmbDept_DropDown(object sender, EventArgs e)
        {
            if (cmbDept.DataSource == null)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("系统没有部门，请先添加部门", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void cmbAuthority_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _mModel.i_Authority = int.Parse(cmbAuthority.SelectedValue.ToString());
            }
            catch { }
        }
        private void cmbNumberLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 _mModel.LevelID = int.Parse(cmbNumberLevel.SelectedValue.ToString());
            }
            catch{}
        }
        private void cmbNoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 // _mModel.NumberTypeID = int.Parse(cmbNoType.SelectedValue.ToString());
                _mModel.i_TellType = int.Parse(cmbNoType.SelectedValue.ToString());
                if (_mModel.i_TellType == CommControl.PublicEnums.EnumTelType.G3G手机.GetHashCode())
                {
                    _mModel.NumberTypeID = CommControl.PublicEnums.EnumNumberType.手机3G.GetHashCode();
                    txtUmtsImsi.Enabled = true;
                    txtUmtsImsi.Text = _mPreModel.vc_UmtsImsi;
                    EnablePasw(false);
                }
                else 
                {
                    _mModel.NumberTypeID = CommControl.PublicEnums.EnumNumberType.手机Wifi.GetHashCode();  //与固话值一样
                    txtUmtsImsi.Enabled = false;
                    txtUmtsImsi.Text = "";
                    EnablePasw(true);
                }
                txtIP1.Enabled = false;
                txtIP2.Enabled = false;
                if (_mModel.i_TellType == CommControl.PublicEnums.EnumTelType.固话.GetHashCode())
                {
                    chkDirectNum.Enabled = true;
                }
                else if (_mModel.i_TellType == CommControl.PublicEnums.EnumTelType.广播.GetHashCode())
                {
                    txtIP1.Enabled = true;
                    txtIP2.Enabled = true;
                }
                else
                {
                    chkDirectNum.Enabled = false;
                   
                }
                
            }
            catch { }
        }
        private void cmbPassword_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_mModel.i_NuPasswordType != int.Parse(cmbPassword.SelectedValue.ToString()))
                {
                    _mModel.i_NuPasswordType = int.Parse(cmbPassword.SelectedValue.ToString());
                    if (_mModel.i_NuPasswordType == 1)
                    {
                        txtPassword.Enabled = true;
                        txtPassword.Text = "";
                    }
                    else
                    {
                        txtPassword.Enabled = false;
                        txtPassword.Text = txtTel.Text.Trim();
                    }
                }
            }
            catch { }
        }

        /*
        private void chKIsDispatch_CheckedChanged(object sender, EventArgs e)
        {
            _mModel.i_IsDispatch = chKIsDispatch.Checked == true ? 1 : 0;
            if (_operate == 1 && preSupplementSerive!=-1)
            {
                if (chKIsDispatch.Checked)
                {
                    //调度服务，话务员代理
                    subService.supplementSerive = (int)MBoxSDK.ConfigSDK.SPM_DISPATCH | (int)MBoxSDK.ConfigSDK.SPM_TELEAGENT; 
                    //subService.supplementSerive | (int)MBoxSDK.ConfigSDK.SPM_DISPATCH;
                }
                else
                {
                    subService.supplementSerive = (int)(MBoxSDK.ConfigSDK.SPM_MISS_CALL | MBoxSDK.ConfigSDK.SPM_MISS_CALL_ON_BUSY | MBoxSDK.ConfigSDK.SPM_SMS);
                    //subService.supplementSerive & (~(int)MBoxSDK.ConfigSDK.SPM_DISPATCH);
                }
            }
            //subService.subNumber = _mModel.i_Number.ToString();// BitConverter.GetBytes((int)_mModel.i_Number);
            //subService.subType = CommControl.PublicEnums.EnumNumberType.SIP.GetHashCode();

           
        }
         
        private void radFixedPhone_CheckedChanged(object sender, EventArgs e)
        {
            if (radFixedPhone.Checked)
                _mModel.i_TellType = CommControl.PublicEnums.EnumTelType.固话.GetHashCode();
            else
                _mModel.i_TellType = 0;
        }
        */
     
        private void chkUnCForward_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkUnCForward.Checked)
            {
                txtUnCForward.Enabled = true;

                chkNoAnswerForward.Checked = false;
                chkPowerOffForward.Checked = false;
                chkBusyForward.Checked = false;

                chkNoAnswerForward.Enabled = false;
                chkPowerOffForward.Enabled = false;
                chkBusyForward.Enabled = false;

            }
            else
            {
                txtUnCForward.Text ="";
                txtUnCForward.Enabled = false;

               
                chkNoAnswerForward.Enabled = true;
                chkPowerOffForward.Enabled = true;
                chkBusyForward.Enabled = true;

                if (_operate == 1)
                {
                    chkNoAnswerForward.Checked = _mModel.i_NoAnswerForward > 0 ? true : false;
                    chkPowerOffForward.Checked = _mModel.i_PowerOffForward > 0 ? true : false;
                    chkBusyForward.Checked = _mModel.i_BusyForward > 0 ? true : false;
                    txtNoAnswerForward.Text = _mModel.i_NoAnswerForward.ToString() == "0" ? "" : _mModel.i_NoAnswerForward.ToString();
                    txtPowerOffForward.Text = _mModel.i_PowerOffForward.ToString() == "0" ? "" : _mModel.i_PowerOffForward.ToString();
                    txtBusyForward.Text = _mModel.i_BusyForward.ToString() == "0" ? "" : _mModel.i_BusyForward.ToString();
          
                }
            }

        }




        private void chkNoAnswerForward_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkNoAnswerForward.Checked)
            {
                txtNoAnswerForward.Enabled = true;
            }
            else
            {
                txtNoAnswerForward.Text = "";
                txtNoAnswerForward.Enabled = false;
            }
        }

        private void chkPowerOffForward_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPowerOffForward.Checked)
            {
                txtPowerOffForward.Enabled = true;
            }
            else
            {
                txtPowerOffForward.Text = "";
                txtPowerOffForward.Enabled = false;
            }
        }

        private void chkBusyForward_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkBusyForward.Checked)
            {
                txtBusyForward.Enabled = true;
            }
            else
            {
                txtBusyForward.Text = "";
                txtBusyForward.Enabled = false;
            }
        }

        private void chkDirectNum_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDirectNum.Checked)
            {
                txtDirectNum.Enabled = true;
            }
            else
            {
                txtDirectNum.Text = "";
                txtDirectNum.Enabled = false;
            }
        } 

        private void chkAssociateNum1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAssociateNum1.Checked)
            {
                //txtAssociateNum1.Enabled = true;
                txtAssociateNum1.Text = _mPreModel.i_AssociateNum1>0?_mPreModel.i_AssociateNum1.ToString():"";
                if (txtAssociateNum1.Text == "") txtAssociateNum1.Enabled = true;

                //两个关联号码
                if (_mPreModel.i_AssociateNum2 > 0)
                {
                    chkAssociateNum2.Checked = true;
                }
            }
            else
            {
                txtAssociateNum1.Text = "";
                txtAssociateNum1.Enabled = false;
                //两个关联号码
                if (_mPreModel.i_AssociateNum2 > 0)
                {
                    chkAssociateNum2.Checked = false;
                }
            }
        }

        private void chkAssociateNum2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAssociateNum2.Checked)
            {
                //txtAssociateNum2.Enabled = true;
                txtAssociateNum2.Text = _mPreModel.i_AssociateNum2 > 0 ? _mPreModel.i_AssociateNum2.ToString() : "";
                if (txtAssociateNum2.Text == "") txtAssociateNum2.Enabled = true;

                //两个关联号码
                if (_mPreModel.i_AssociateNum1 > 0)
                {
                    chkAssociateNum1.Checked = true;
                }
            }
            else
            {
                txtAssociateNum2.Text = "";
                txtAssociateNum2.Enabled = false;

                //两个关联号码
                if (_mPreModel.i_AssociateNum1 > 0)
                {
                    chkAssociateNum1.Checked = false;
                }
            }
        }
        private void chkRecord_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void txtUnCForward_Leave(object sender, EventArgs e)
        {
            checkNumber(txtUnCForward);
            //if (txtUnCForward.Text != "") chkUnCForward.Checked = true;
        }

        private void txtNoAnswerForward_Leave(object sender, EventArgs e)
        {
            checkNumber(txtNoAnswerForward);
        }

        private void txtPowerOffForward_Leave(object sender, EventArgs e)
        {
            checkNumber(txtPowerOffForward);
        }

        private void txtBusyForward_Leave(object sender, EventArgs e)
        {
            checkNumber(txtBusyForward);
        }

        private void txtDirectNum_Leave(object sender, EventArgs e)
        {
            checkNumber(txtDirectNum);


        }

        private void txtAssociateNum1_Leave(object sender, EventArgs e)
        {
            checkNumber(txtAssociateNum1);
        }

        private void txtAssociateNum2_Leave(object sender, EventArgs e)
        {
            checkNumber(txtAssociateNum2);
        }

        private void txtTelEnd_Leave(object sender, EventArgs e)
        {
            checkNumber(txtTelEnd);
        }

        private void txtUmtsImsi_Leave(object sender, EventArgs e)
        {
            TextBox txt = txtUmtsImsi;
            int num = 0;
            if (txt.Text.Trim() != "" && int.TryParse(txt.Text.Trim(), out num) && num > 0 && num.ToString().Length != 15)
            {
                txt.Text = "";
                txt.Focus();
                CommControl.MessageBoxEx.MessageBoxEx.Show("标示码必须是15位的数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            //if (txt.Text.Trim() != "" && !Global.Methods.checkNumber(txt.Text.Trim()))
            //{
            // }
        }
       
        private void txtPassword_Leave(object sender, EventArgs e)
        {
           
            //int num = 0;
            //if (txt.Text.Trim() != "" && int.TryParse(txt.Text.Trim(), out num) && num > 0 && num.ToString().Length != 15)
            //{
            //    txt.Text = "";
            //    txt.Focus();
            //    CommControl.MessageBoxEx.MessageBoxEx.Show("标示码必须是15位的数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}

            //UInt64 pasw = 0;

            //if (UInt64.TryParse(txtPassword.Text.Trim(), out pasw))
            //    txtPassword.Text = pasw.ToString();
            //else
            //    txtPassword.Text = "";

            TextBox txt = txtPassword;
            UInt64 pasw = 0;
            if (txtPassword.Text.Trim() != "")
            {
                if (UInt64.TryParse(txtPassword.Text.Trim(), out pasw) && pasw >= 100 && pasw <= 999999999999)
                    txtPassword.Text = pasw.ToString();
                else
                {
                    txt.Text = "";
                    txt.Focus();
                    CommControl.MessageBoxEx.MessageBoxEx.Show("用户密码必须是100～999999999999位之间的数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {
            if (cmbPassword.SelectedIndex == 1 && txtTel.Text.Trim() != "")
                txtPassword.Text = txtTel.Text.Trim();
        }

        void txtIP1_TextChanged(object sender, EventArgs e)
        {
            if (txtIP1.Text.Trim() != "")
                txtIP2.Value = txtIP1.Text.Trim();

        }

        #region  私有方法
        private void InitCmb()
        {
            //部门
            List<DB_Talk.Model.m_Departments> list = new DB_Talk.BLL.m_Departments().GetModelList("i_Flag=0");
            cmbDept.DataSource = list;
            cmbDept.DisplayMember = "vc_Name";
            cmbDept.ValueMember = "ID";
            cmbDept.SelectedIndex = -1;
            if (_operate == 1)
            {
                if (_mModel.DepartmentID != null)
                {
                    foreach (DB_Talk.Model.m_Departments d in cmbDept.Items)
                    {
                        if (d.ID.ToString() == _mModel.DepartmentID.ToString())
                        {
                            cmbDept.SelectedItem = d;
                            break;
                        }
                    }
                }
            }
            if (list.Count == 0)
            {
                cmbDept.DataSource = null;
                cmbDept.Items.Add(" ");
            }


            //密码模式
            System.Data.DataTable dtPasswordType = new DataTable();
            dtPasswordType.Columns.Add("ID");
            dtPasswordType.Columns.Add("vc_Name");

            Type PasswordType = typeof(PublicEnums.EnumTelPasswordType);  //.EnumNumberType);
            foreach (PublicEnums.EnumTelPasswordType t in Enum.GetValues(PasswordType))
            {
                dtPasswordType.Rows.Add(t.GetHashCode(), t.ToString());
            }
            cmbPassword.DataSource = dtPasswordType;
            cmbPassword.DisplayMember = "vc_Name";
            cmbPassword.ValueMember = "ID";
            cmbPassword.SelectedIndex = -1;
            if (_operate == 1)
            {
                if (_mModel.i_NuPasswordType != null)
                {
                    foreach (DataRowView d in cmbPassword.Items)
                    {
                        if (d["ID"].ToString() == _mModel.i_NuPasswordType.ToString())
                        {
                            cmbPassword.SelectedItem = d;
                            break;
                        }
                    }
                    if (cmbPassword.SelectedIndex == 1) txtPassword.Enabled = false;
                }
            }
            else if(_operate==0)
            {
                if (dtPasswordType.Rows.Count > 0)
                {
                    cmbPassword.SelectedIndex = 1;  //默认增加，即和号码相同
                    _mModel.i_NuPasswordType = 2;  //密码模式
                    txtPassword.Enabled = false;
                    
                }
            }
           



            //号码类型
            System.Data.DataTable dtNoType = new DataTable();
            dtNoType.Columns.Add("ID");
            dtNoType.Columns.Add("vc_Name");

            Type noType = typeof(PublicEnums.EnumTelType);  //.EnumNumberType);
            foreach (PublicEnums.EnumTelType t in Enum.GetValues(noType))
            {
                if (t == PublicEnums.EnumTelType.调度席话机) continue;
                else if (t == PublicEnums.EnumTelType.G3G手机)
                {
                    if (Global.Params.BoxType == MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000_3G)  //目前只有800B支持3G
                        dtNoType.Rows.Add(t.GetHashCode(), t.ToString().Substring(1));
                }
                else
                    dtNoType.Rows.Add(t.GetHashCode(), t.ToString());
            }
            cmbNoType.DataSource = dtNoType;
            cmbNoType.DisplayMember = "vc_Name";
            cmbNoType.ValueMember = "ID";
            cmbNoType.SelectedIndex = -1;
            if (_operate == 1)
            {
                if (_mModel.i_TellType != null)
                {
                    foreach (DataRowView d in cmbNoType.Items)
                    {
                        if (d["ID"].ToString() == _mModel.i_TellType.ToString())
                        {
                            cmbNoType.SelectedItem = d;
                            break;
                        }
                    }
                }
                // cmbNoType.Enabled = false;
            }
            else if (_operate == 0)
            {
                if (dtNoType.Rows.Count > 0)
                {
                    cmbNoType.SelectedIndex = 0;  //默认wifi手机
                    _mModel.NumberTypeID = 4;  //用户类型
                    _mModel.i_TellType = 1;    //电话类型
                }
            }
            

            //号码级别，默认为空即最低级别
            System.Data.DataTable dtNoLevel = new DataTable();
            dtNoLevel.Columns.Add("ID");
            dtNoLevel.Columns.Add("vc_Name");

            Type Level = typeof(PublicEnums.EnumLevel);
            foreach (PublicEnums.EnumLevel l in Enum.GetValues(Level))
            {
                if (l == PublicEnums.EnumLevel.none) continue;
                dtNoLevel.Rows.Add(l.GetHashCode(), l.ToString());
            }

            cmbNumberLevel.DataSource = dtNoLevel;
            cmbNumberLevel.DisplayMember = "vc_Name";
            cmbNumberLevel.ValueMember = "ID";
            cmbNumberLevel.SelectedIndex = -1;
            if (_operate == 1)
            {
                if (_mModel.LevelID != null)
                {
                    foreach (DataRowView d in cmbNumberLevel.Items)
                    {
                        if (d["ID"].ToString() == _mModel.LevelID.ToString())
                        {
                            cmbNumberLevel.SelectedItem = d;
                            break;
                        }
                    }
                }
            }


            //用户权限
            System.Data.DataTable dtNoAuthority = new DataTable();
            dtNoAuthority.Columns.Add("ID");
            dtNoAuthority.Columns.Add("vc_Name");

            Type Au = typeof(PublicEnums.EnumAuthority);
            foreach (PublicEnums.EnumAuthority a in Enum.GetValues(Au))
            {
                if (a == PublicEnums.EnumAuthority.none) continue;
                dtNoAuthority.Rows.Add(a.GetHashCode(), a.ToString());
            }

            cmbAuthority.DataSource = dtNoAuthority;
            cmbAuthority.DisplayMember = "vc_Name";
            cmbAuthority.ValueMember = "ID";
            cmbAuthority.SelectedIndex = -1;  //默认内部分机
            if (_operate == 1)
            {
                if (_mModel.i_Authority != null)
                {
                    foreach (DataRowView d in cmbAuthority.Items)
                    {
                        if (d["ID"].ToString() == _mModel.i_Authority.ToString())
                        {
                            cmbAuthority.SelectedItem = d;
                            break;
                        }
                    }
                }
            }
            else if(_operate==0)
            {
                cmbAuthority.SelectedIndex = 3;  //默认内部分机
                _mModel.i_Authority = 3;  //内部分机
            }

        }

        /// <summary>
        /// 根据前缀号码和现有的号码比较，返回是否可以增加
        /// </summary>
        /// <param name="number"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        private bool CheckNumberRule(string number, string rule)
        {
            string[] rs = rule.Split(',');
            int len = number.Length;


            for (int i = 1; i <= len; i++)
            {
                string strS=number.Substring(0,i);
                foreach (string item in rs)
                {
                    if (item.Length == i)
                    {
                        if (item == strS)
                        {
                            return true;
                        }
                    }
                }
            }


            return false;
        }


        private void GetModel()
        {
            _mModel.BoxID = Global.Params.BoxID;
            
            _mModel.vc_Name = txtName.Text.Trim();
            if (txtName.Enabled==true && _mModel.vc_Name == "")
            {
                txtName.Focus();
                throw new Exception("用户名称不可以为空");
            }
            if (_mModel.vc_Name.IndexOf("'") >= 0)
            {
                txtName.Focus();
                throw new Exception("名称中不可以有特殊字符");
            }
            /*
            if (_mModel.DepartmentID == null)
            {
                throw new Exception("请选择部门");
            }
            */
            if (txtTel.Text.Trim() == "" || int.Parse(txtTel.Text.Trim()) == 0 )
            {
                txtTel.Focus();
                throw new Exception("电话号码不可以为空或零");
            }

            string str = txtTel.Text.Trim().Substring(0,1);
            if (txtTel.Text.Trim().Length != Global.Params.NumberLen || CheckNumberRule(txtTel.Text.Trim(), Global.Params.strNumHead)==false)   
            {
                txtTel.Focus();
                string mes = Global.Params.strNumHead.Replace(",", "或");
                throw new Exception("用户号码长度必须是【" + Global.Params.NumberLen + "】位，且以数字【" + mes + "】开头");
                
            }

            DB_Talk.Model.m_Box modelBox = new DB_Talk.BLL.m_Box().GetModel(Global.Params.BoxID);
            if (modelBox != null)
            {
                if (modelBox.i_DispatchNumber == int.Parse(txtTel.Text.Trim()))
                {
                    throw new Exception("用户号码不能和调度号码(" + modelBox.i_DispatchNumber + ")相同！");
                }
                if (modelBox.i_EmergencyNumber == int.Parse(txtTel.Text.Trim()))
                {
                    throw new Exception("用户号码不能和紧急号码(" + modelBox.i_EmergencyNumber+ ")相同！");
                }
            }
            //if (txtTel.Text.Replace(" ", "").Length != Global.Params.NumberLen)
            //{
            //    txtTel.Focus();
            //    throw new Exception("电话号码必须是: "+Global.Params.NumberLen+" 位");
            //}

            _mModel.i_Number = int.Parse(txtTel.Text.Replace(" ", "").Trim());


            if (cmbNoType.SelectedValue.ToString() != CommControl.PublicEnums.EnumTelType.G3G手机.GetHashCode().ToString())
            {
                if (_mModel.i_NuPasswordType == null)
                    throw new Exception("请选择密码模式");
                if (_mModel.i_NuPasswordType == PublicEnums.EnumTelPasswordType.增加.GetHashCode())
                {
                    _mModel.i_NuPassword = (UInt64)_mModel.i_Number;
                }
                else
                {
                    if (txtPassword.Text.Trim() == "")
                    {
                        txtPassword.Focus();
                        throw new Exception("当密码模式为固定时，用户密码不能为空");
                    }
                    _mModel.i_NuPassword = UInt64.Parse(txtPassword.Text.Trim());
                    //UInt64 pasw = 0;
                    //if (UInt64.TryParse(txtPassword.Text.Trim(), out pasw) && pasw > 100 && pasw<=999999999999)
                    //    //pasw.ToString().Length >= 3 && pasw.ToString().Length <= 12)
                    //    _mModel.i_NuPassword = pasw;
                    //else
                    //    throw new Exception("用户密码必须是100～999999999999位之间的数字");
                    //    //throw new Exception("用户密码长度必须在3～12位之间，且大于零");
                }
            }
            else
            {
                _mModel.i_NuPasswordType=0;
                _mModel.i_NuPassword = 0;
            }

            if (_mModel.NumberTypeID == null)
            {
                throw new Exception("请选择号码类别");
            }
          
            _mModel.vc_MAC = txtMAC.Text.Trim();
            //if (_mModel.vc_MAC == "")
            //{
            //    txtMAC.Focus();
            //    throw new Exception("MAC不可以为空");
            //}
            if (_mModel.vc_MAC.IndexOf("'") >= 0)
            {
                txtName.Focus();
                throw new Exception("MAC中不可以有特殊字符");
            }

            if (txtTelEnd.Text.Trim() != "")
            {
                string strEnd = txtTelEnd.Text.Trim().Substring(0, 1);
                if (txtTelEnd.Text.Trim().Length != Global.Params.NumberLen || Global.Params.strNumHead.IndexOf(str) < 0)
                {
                    txtTelEnd.Focus();
                    string mes = Global.Params.strNumHead.Replace(",", "或");
                    throw new Exception("用户号码长度必须是【" + Global.Params.NumberLen + "】位，且以数字【" + mes + "】开头");

                }

                addCount =Int64.Parse(txtTelEnd.Text.Trim()) -_mModel.i_Number.Value;
                if (addCount < 0)
                {
                    txtTelEnd.Focus();
                    throw new Exception("终止号码不可以小于起始号码");
                }
                else 
                {
                    DB_Talk.BLL.m_Member _BLL = new DB_Talk.BLL.m_Member();
                    List<DB_Talk.Model.m_Member> listCount = new List<DB_Talk.Model.m_Member>();
                    listCount = _BLL.GetModelList(string.Format(" i_flag=0 and BoxID='{0}'", Global.Params.BoxID));
                    if (listCount != null && (addCount > Global.Params.MaxBoxMemberCount - listCount.Count))
                    {
                        throw new Exception(string.Format("终止号码过大，最多还能添加【{0}】个号码!", Global.Params.MaxBoxMemberCount-listCount.Count));
                    }
                }

              
               
            }


            if (txtIP1.Enabled)
            {
                if (txtIP1.Text=="" || txtIP2.Text=="")
                {
                    throw new Exception("起始或者终止IP地址不能为空!");
                }

                bool b = IsSameLanNet(IPAddress.Parse(txtIP1.Text.Trim()), IPAddress.Parse(txtIP2.Text.Trim()));
                if (!b)
                {
                     throw new Exception("起始IP与终止IP不在一个网段");
                }

                string[] IP1 = txtIP1.Text.Trim().Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                string[] IP2 = txtIP2.Text.Trim().Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                int addCountIP = int.Parse(IP2[3]) - int.Parse(IP1[3]);
                if (addCountIP < 0)
                {
                    txtIP2.Focus();
                    throw new Exception("终止IP不可以小于起始IP");
                }
                if (addCount==0 && addCountIP>0)
                {
                    throw new Exception("起始IP与终止IP不同时，终止号码不能为空！\n\n且增加号码个数与IP个数必须相同");                    
                }
                else if (addCount!=addCountIP)
                {
                    throw new Exception("增加的号码个数与IP个数不一致");                    
                }
                _mModel.vc_IP = txtIP1.Text.Trim();

            }

            if (_mModel.i_TellType == CommControl.PublicEnums.EnumTelType.G3G手机.GetHashCode()
                && txtUmtsImsi.Text.Trim()=="")
            {
                throw new Exception("3G号码标示码不能为空");
            }
            _mModel.vc_UmtsImsi = txtUmtsImsi.Text.Trim();

            _mModel.vc_Memo = txtMemo.Text.Trim();
            if (_mModel.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符");
            }

            if (groupBoxG.Visible == true)
            {
                if (chkUnCForward.Checked && txtUnCForward.Text == "")
                {
                    txtUnCForward.Focus();
                    throw new Exception("请设置无条件呼叫前转号码");
                }
                else if (txtUnCForward.Text != "")
                {
                    if (txtUnCForward.Text.Trim() == txtTel.Text.Trim())
                    {
                        txtUnCForward.Focus();
                        throw new Exception("无条件呼叫前转号码不能与自身号码相同");
                    }
                    _mModel.i_UnCForwardNu = int.Parse(txtUnCForward.Text);
                }
                else
                {
                    _mModel.i_UnCForwardNu = 0;
                }


                if (chkNoAnswerForward.Checked && txtNoAnswerForward.Text == "")
                {
                    txtNoAnswerForward.Focus();
                    throw new Exception("请设置无应答呼叫前转号码");
                }
                else if (txtNoAnswerForward.Text != "")
                {
                    if (txtNoAnswerForward.Text.Trim() == txtTel.Text.Trim())
                    {
                        txtNoAnswerForward.Focus();
                        throw new Exception("无应答呼叫前转号码不能与自身号码相同");
                    }
                    _mModel.i_NoAnswerForward = int.Parse(txtNoAnswerForward.Text);
                }
                else
                {
                    _mModel.i_NoAnswerForward = 0;
                }


                if (chkBusyForward.Checked && txtBusyForward.Text == "")
                {
                    txtBusyForward.Focus();
                    throw new Exception("请设置遇忙前转号码");
                }
                else if (txtBusyForward.Text != "")
                {
                    if (txtBusyForward.Text.Trim() == txtTel.Text.Trim())
                    {
                        txtBusyForward.Focus();
                        throw new Exception("遇忙转接号码不能与自身号码相同");
                    }
                    _mModel.i_BusyForward = int.Parse(txtBusyForward.Text);
                }
                else
                {
                    _mModel.i_BusyForward = 0;
                }

                if (chkPowerOffForward.Checked && txtPowerOffForward.Text == "")
                {
                    txtPowerOffForward.Focus();
                    throw new Exception("请设置关机前转号码");
                }
                else if (txtPowerOffForward.Text != "")
                {
                    if (txtPowerOffForward.Text.Trim() == txtTel.Text.Trim())
                    {
                        txtPowerOffForward.Focus();
                        throw new Exception("关机前转号码不能与自身号码相同");
                    }
                    _mModel.i_PowerOffForward = int.Parse(txtPowerOffForward.Text);
                }
                else
                {
                    _mModel.i_PowerOffForward = 0;
                }


                if (chkDirectNum.Checked && txtDirectNum.Text == "")
                {
                    txtDirectNum.Focus();
                    throw new Exception("请设置直通号码");
                }
                else if (txtDirectNum.Text != "")
                {
                    if (txtDirectNum.Text.Trim() == txtTel.Text.Trim())
                    {
                        txtDirectNum.Focus();
                        throw new Exception("直播号码不能与自身号码相同");
                    }
                    _mModel.i_DirectNum = int.Parse(txtDirectNum.Text);

                }
                else
                {
                    _mModel.i_DirectNum = 0;
                }


                if (chkAssociateNum1.Checked && txtAssociateNum1.Text == "")
                {
                    txtAssociateNum1.Focus();
                    throw new Exception("请设置关联号码1");
                }
                else if (txtAssociateNum1.Text != "")
                {
                    if (  _mModel.i_AssociateNum1 != int.Parse(txtAssociateNum1.Text))
                    {
                        _mModel.i_AssociateNum1 = int.Parse(txtAssociateNum1.Text);
                        CheckAssociateNum(_mModel.i_AssociateNum1.ToString());
                    }
                }
                else
                {
                    _mModel.i_AssociateNum1 = 0;
                }


                if (chkAssociateNum2.Checked && txtAssociateNum2.Text == "")
                {
                    txtAssociateNum2.Focus();
                    throw new Exception("请设置关联号码2");
                }
                else if (txtAssociateNum2.Text != "")
                {
                    _mModel.i_AssociateNum2 = int.Parse(txtAssociateNum2.Text);
                    CheckAssociateNum(_mModel.i_AssociateNum2.ToString());
                }
                else
                {
                    _mModel.i_AssociateNum2 = 0;
                }

                if (txtAssociateNum1.Text.Trim() != "" && txtAssociateNum2.Text.Trim() != "" && txtAssociateNum1.Text.Trim() == txtAssociateNum2.Text.Trim())
                {
                    txtAssociateNum2.Focus();
                    throw new Exception("两个关联号码不能相同");
                }

            }
        }

        private void ShowModel()
        {
            txtName.Text = _mModel.vc_Name;
            txtTel.Text = _mModel.i_Number.ToString() ;  
            txtUmtsImsi.Text = _mModel.vc_UmtsImsi;  //标示码
            txtMemo.Text = _mModel.vc_Memo;
            txtPassword.Text = _mModel.i_NuPassword>0 ? _mModel.i_NuPassword.ToString() : "";
            txtIP1.Value = _mModel.vc_IP;
            txtIP2.Enabled = false;
            //chKIsDispatch.Checked = _mModel.i_IsDispatch == 1 ? true : false;
            //chkNoAnswerForward.Checked = (_mModel.i_supplementSerive & MBoxSDK.ConfigSDK.SPM_CFW_UNCON) == MBoxSDK.ConfigSDK.SPM_CFW_UNCON ? true : false;
            chkUnCForward.Checked = _mModel.i_UnCForwardNu > 0 ? true : false;
            chkNoAnswerForward.Checked =_mModel.i_NoAnswerForward >0 ? true : false;
            chkPowerOffForward.Checked =_mModel.i_PowerOffForward > 0 ? true : false;
            chkBusyForward.Checked = _mModel.i_BusyForward > 0 ? true : false;
            chkDirectNum.Checked = _mModel.i_DirectNum > 0 ? true : false;
            chkAssociateNum1.Checked = _mModel.i_AssociateNum1 > 0 ? true : false;
            chkAssociateNum2.Checked = _mModel.i_AssociateNum2 > 0 ? true : false;
            chkRecord.Checked = _mModel.i_supplementSerive!=null && ((_mModel.i_supplementSerive & MBoxSDK.ConfigSDK.SPM_AUTO_RECORDING) == MBoxSDK.ConfigSDK.SPM_AUTO_RECORDING) ? true : false;
            
            //带出转接号码
            txtUnCForward.Text = _mModel.i_UnCForwardNu.ToString() == "0" ? "" : _mModel.i_UnCForwardNu.ToString();
            txtNoAnswerForward.Text = _mModel.i_NoAnswerForward.ToString() == "0" ? "" : _mModel.i_NoAnswerForward.ToString();
            txtPowerOffForward.Text = _mModel.i_PowerOffForward.ToString() == "0" ? "" : _mModel.i_PowerOffForward.ToString();
            txtBusyForward.Text = _mModel.i_BusyForward.ToString() == "0" ? "" :_mModel.i_BusyForward.ToString();
            txtDirectNum.Text = _mModel.i_DirectNum.ToString() == "0" ? "" :_mModel.i_DirectNum.ToString();

            if (_mModel.i_AssociateNum1 > 0)
            {
                txtAssociateNum1.Text = _mModel.i_AssociateNum1.ToString();
                txtAssociateNum1.Enabled=false;
                chkAssociateNum2.Enabled = false;

            }
             if (_mModel.i_AssociateNum2 > 0)
            {
                txtAssociateNum2.Text = _mModel.i_AssociateNum2.ToString();
                txtAssociateNum2.Enabled=false;
                chkAssociateNum1.Enabled = false;
            }
             if (_mModel.i_AssociateNum1 > 0 && _mModel.i_AssociateNum2 > 0)
             {
                 chkAssociateNum1.Enabled = true;
                 chkAssociateNum2.Enabled = true;
             }
            //txtAssociateNum1.Text = _mModel.i_AssociateNum1.ToString() == "0" ? "" :_mModel.i_AssociateNum1.ToString();
            //txtAssociateNum2.Text = _mModel.i_AssociateNum2.ToString() == "0" ? "" : _mModel.i_AssociateNum2.ToString();

            //try
            //{
            //    bool b = MBoxSDK.ConfigSDK.MBOX_QuerySubscriber(Global.Params.BoxHandle, (int)_mModel.i_Number, ref subService);
            //    if (b)
            //    {
            //        preSupplementSerive = subService.supplementSerive;
            //        //PreDispatch = subService.supplementSerive & (int)MBoxSDK.ConfigSDK.SPM_DISPATCH;
            //        //if ((subService.supplementSerive & MBoxSDK.ConfigSDK.SPM_DISPATCH) == MBoxSDK.ConfigSDK.SPM_DISPATCH)
            //        if ((subService.supplementSerive) == (MBoxSDK.ConfigSDK.SPM_DISPATCH | MBoxSDK.ConfigSDK.SPM_TELEAGENT))
            //        {
            //            chKIsDispatch.Checked = true;
            //        }
            //        else
            //        {
            //            chKIsDispatch.Checked = false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
          

        }

        private void GetModelMuti(ref DB_Talk.Model.m_Member model)
        {
            //部门
            try
            {
                model.DepartmentID = int.Parse(cmbDept.SelectedValue.ToString());
            }
            catch { }

            //密码
            if (model.i_TellType != CommControl.PublicEnums.EnumTelType.G3G手机.GetHashCode())
            {
                if (cmbPassword.SelectedIndex >= 0)
                {
                    model.i_NuPasswordType = int.Parse(cmbPassword.SelectedValue.ToString());
                    if (model.i_NuPasswordType == PublicEnums.EnumTelPasswordType.增加.GetHashCode())
                    {
                        model.i_NuPassword = (UInt64)_mModel.i_Number;
                    }
                    else
                    {
                        int pasw = 0;
                        if (int.TryParse(txtPassword.Text.Trim(), out pasw) && pasw > 0 && pasw.ToString().Length >= 3 && pasw.ToString().Length <= 12)
                            _mModel.i_NuPassword = (UInt64)pasw;
                        else
                            throw new Exception("用户密码必须是100～999999999999位之间的数字");
                        // throw new Exception("用户密码长度必须在3～12位之间，且大于零");
                    }
                }
            }

            //用户权限
            try
            {
                model.i_Authority = int.Parse(cmbAuthority.SelectedValue.ToString());
            }
            catch { }
            //优先级
            try
            {
                model.LevelID = int.Parse(cmbNumberLevel.SelectedValue.ToString());
            }
            catch { }

            if (txtMemo.Text.Trim() != "")
                model.vc_Memo = txtMemo.Text.Trim();

        }

        private void ShowModelMuti()
        {
            if (_lstvModel.Count <= 0) return;
            //初始化部门
            int? FriDeptID = null;
            if(_lstvModel[0].DepartmentID!=null) FriDeptID=_lstvModel[0].DepartmentID.Value;
            if (_lstvModel.FindIndex(item => item.DepartmentID != FriDeptID) >= 0)  //判断部门是否都一样
            {

            }
            else //都一样
            {
                if (FriDeptID != null)
                {
                    foreach (DB_Talk.Model.m_Departments d in cmbDept.Items)
                    {
                        if (d.ID.ToString() == FriDeptID.ToString())
                        {
                            cmbDept.SelectedItem = d;
                            break;
                        }
                    }
                }

            }


            int? FriPasswordType = null;
            if (_lstvModel[0].i_NuPasswordType != null) FriPasswordType = _lstvModel[0].i_NuPasswordType.Value;
            if (_lstvModel.FindIndex(item => item.i_NuPasswordType != FriPasswordType) >= 0)  //判断密码模式是否都一样
            {

            }
            else
            {
                if (FriPasswordType != null)
                {
                    foreach (DataRowView d in cmbPassword.Items)
                    {
                        if (d["ID"].ToString() == FriPasswordType.ToString())
                        {
                            cmbPassword.SelectedItem = d;
                            break;
                        }
                    }
                    if (cmbPassword.SelectedIndex == 1)
                        txtPassword.Enabled = false;
                    else
                        txtPassword.Text = _lstvModel[0].i_NuPassword == null ? "" : _lstvModel[0].i_NuPassword.ToString();
                }
            }


            List<DB_Talk.Model.v_Member> lstTemp = _lstvModel.Where(w => w.i_TellType == PublicEnums.EnumTelType.G3G手机.GetHashCode()).ToList();
            if (lstTemp.Count == _lstvModel.Count)  //全部为3g手机
            {
                cmbPassword.Enabled = false;
                txtPassword.Enabled = false;
            }
            
           

            //用户权限
            int? FriAuthority = null;
            if (_lstvModel[0].i_Authority != null) FriAuthority = _lstvModel[0].i_Authority.Value;
            if (_lstvModel.FindIndex(item => item.i_Authority != FriAuthority) >= 0)  //判断等级是否都一样
            {

            }
            else
            {
                if (FriAuthority != null)
                {
                    foreach (DataRowView d in cmbAuthority.Items)
                    {
                        if (d["ID"].ToString() == FriAuthority.ToString())
                        {
                            cmbAuthority.SelectedItem = d;
                            break;
                        }
                    }
                }
            }

            //等级
            int? FriLevelID = null;
            if (_lstvModel[0].LevelID != null) FriLevelID = _lstvModel[0].LevelID.Value;
            if (_lstvModel.FindIndex(item => item.LevelID != FriLevelID) >= 0)  //判断等级是否都一样
            {

            }
            else
            {
                if (FriLevelID != null)
                {
                    foreach (DataRowView d in cmbNumberLevel.Items)
                    {
                        if (d["ID"].ToString() == FriLevelID.ToString())
                        {
                            cmbNumberLevel.SelectedItem = d;
                            break;
                        }
                    }
                }
            }
            //备注
            string vcMemo = null;
            if (_lstvModel[0].vc_Memo != null) vcMemo = _lstvModel[0].vc_Memo;
            if (_lstvModel.FindIndex(item => item.vc_Memo != vcMemo) >= 0)  //判断备注是否都一样
            {

            }
            else
            {
               if(vcMemo!=null)  txtMemo.Text = vcMemo;
            }

            txtIP1.Enabled = false;
            txtIP2.Enabled = false;
            
        }
        
        
        private void Add()
        {
            if (_BLL.GetModelList(string.Format(" i_flag=0 and  i_Number='{0}' and BoxID='{1}'", _mModel.i_Number, _mModel.BoxID)).Count > 0)
            {
                txtTel.Focus();
                CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("数据库中电话【{0}】已存在!", _mModel.i_Number), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (_mModel.NumberTypeID.Value == PublicEnums.EnumNumberType.手机3G.GetHashCode() &&
                _BLL.GetModelList(string.Format(" i_flag=0 and  vc_UmtsImsi='{0}' and BoxID='{1}'", _mModel.vc_UmtsImsi, _mModel.BoxID)).Count > 0)
            {
                txtUmtsImsi.Focus();
                CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("标示码【{0}】已存在!", _mModel.vc_UmtsImsi), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (_mModel.i_TellType.Value == PublicEnums.EnumTelType.广播.GetHashCode() &&
               _BLL.GetModelList(string.Format(" i_flag=0 and  vc_IP='{0}' and BoxID='{1}'", _mModel.vc_IP, _mModel.BoxID)).Count > 0)
            {
                txtIP1.Focus();
                CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("数据库中IP【{0}】已存在!", _mModel.i_Number), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (Global.Params.BoxHandle > 0)
            {
                try
                {
                    string mes = "";
                    if (AddTel(out mes))
                    {
                        if (_BLL.Add(_mModel) == 1)
                        {
                            UpdateAssociateNum(_mModel);
                            CommControl.MessageBoxEx.MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Add, "添加", "添加了人员：" + _mModel.vc_Name, "");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            mes = "在数据库中添加失败";
                            CommControl.MessageBoxEx.MessageBoxEx.Show("在数据库中添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MBoxSDK.ConfigSDK.Enum_ErrorCode ecode = MBoxSDK.ConfigSDK.MBOX_GetLastError();
                        CommControl.Tools.WriteLog.AppendErrorLog("添加【" + _mModel.i_Number.ToString() + "】失败，错误代码：" + ecode + "\n\r");
                        CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private bool AddTel(out string mes)
        {
            mes = "";
            bool IsExist = MBoxSDK.ConfigSDK.MBOX_IsSubscriberExist(Global.Params.BoxHandle, (_mModel.i_Number.Value));
            if (IsExist)
            {
                mes = "号码已经存在";
                return false;
            }
            if (!AddBase(_mModel))
            {
                mes = "号码在硬件中添加失败";
                return false;
            }
            if (!ModifyDetail(_mModel.i_Number.Value))
            {
                MBoxSDK.ConfigSDK.MBOX_DeleteSubscriber(Global.Params.BoxHandle, _mModel.i_Number.Value);
                mes = "设置号码高级功能失败";
                return false;
            } 
            if (! MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle))
            {
                mes = "保存硬件配置失败";
                return false;
            }
            return true;
        }

        private void AddMutiTel()
        {
            try
            {
                Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
                               
                DB_Talk.Model.m_Member model = _mModel;
                int sucADD = 0;
                int errorAdd = 0;
                DateTime dtStart = System.DateTime.Now;
                for (int i = 0; i <= addCount; i++)
                {
                    model.vc_Name = _mModel.i_Number.ToString();

                    procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在添加用户【" + model.vc_Name + "】，请稍等...");


                    if (_mModel.i_TellType.Value == PublicEnums.EnumTelType.广播.GetHashCode() &&
                       _BLL.GetModelList(string.Format(" i_flag=0 and  vc_IP='{0}' and BoxID='{1}'", _mModel.vc_IP, _mModel.BoxID)).Count > 0)
                    {
                        CommControl.Tools.WriteLog.AppendLog("添加号码"+_mModel.i_Number+"失败，数据库已经存在IP：" + _mModel.vc_IP );
                        errorAdd++;
                    }
                    else

                    //bool IsExist = MBoxSDK.ConfigSDK.MBOX_IsSubscriberExist(Global.Params.BoxHandle, Convert.ToInt32(_mModel.i_Number.ToString()));
                    //if (!IsExist)
                    {
                        if (AddBase(model))
                        {
                           
                            //System.Threading.Thread.Sleep(500);
                            if (_BLL.Add(_mModel) == 1)
                            {
                                UpdateAssociateNum(_mModel);
                                CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Add, "添加", "添加了人员：" + _mModel.vc_Name, "");
                                sucADD++;
                            }
                            else
                            {
                                CommControl.Tools.WriteLog.AppendLog("数据库中添加人员：" + _mModel.vc_Name + "失败");
                                CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Add, "添加失败", "数据库添加人员：" + _mModel.vc_Name + "失败", "");
                                errorAdd++;
                            }
                        }
                        else
                        {
                            CommControl.Tools.WriteLog.AppendLog("box中添加人员：" + _mModel.vc_Name + "失败");
                            CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Add, "添加失败", "box添加人员：" + _mModel.vc_Name + "失败", "");
                            errorAdd++;
                        }
                    }
                    //else
                    //{
                    //    CommControl.Tools.WriteLog.AppendLog("box中已经存在，添加人员：" + _mModel.vc_Name + "失败");
                    //    CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Add, "添加失败", "box中已经存在，添加人员：" + _mModel.vc_Name + "失败", "");
                    //    errorAdd++;
                    //}
                    model.i_Number = model.i_Number + 1;
                    if (txtIP1.Enabled && !string.IsNullOrEmpty(model.vc_IP))
                    {
                        string[] IP = model.vc_IP.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                        model.vc_IP = string.Format("{0}.{1}.{2}.{3}",IP[0],IP[1],IP[2] ,(int.Parse(IP[3]) + 1));
                    }
                    
                    if (model.i_TellType != CommControl.PublicEnums.EnumTelType.G3G手机.GetHashCode())
                    {
                        if (_mModel.i_NuPasswordType == PublicEnums.EnumTelPasswordType.增加.GetHashCode())
                        {
                            _mModel.i_NuPassword = (UInt64)model.i_Number;
                        }
                    }

                    if (model.vc_UmtsImsi!="")
                          model.vc_UmtsImsi = (Convert.ToUInt64(model.vc_UmtsImsi) + 1).ToString();
                }
                procDlg.Dispose();
                string mes = "";
                if (sucADD > 0) mes = sucADD + "个用户添加成功 \r\n";
                if (errorAdd > 0) mes += errorAdd + "个用户添加失败";
              
                if (mes!="")
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);

                    DateTime dtEnd = System.DateTime.Now;
                    TimeSpan sp = dtEnd - dtStart;
                    CommControl.Tools.WriteLog.AppendLog("添加" + (addCount+1).ToString() + "个用户，时间：" + sp.TotalMilliseconds + "ms");

                    CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("批量添加不成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            catch
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("批量添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool AddBase(DB_Talk.Model.m_Member model)
        {
            MBoxSDK.ConfigSDK.subscriberServiceBase subscriberBase = new MBoxSDK.ConfigSDK().newSubscriberServiceBase(); //new MBoxSDK.ConfigSDK.subscriberServiceBase();
            byte[] bytenumber = System.Text.ASCIIEncoding.ASCII.GetBytes(model.i_Number.ToString());
            subscriberBase.subType = model.NumberTypeID.Value;
            if (model.i_Authority != null)
            {
                subscriberBase.userPriority = model.i_Authority.Value;    
            }
            
            //byte[] bytenumber=BitConverter.GetBytes(_mModel.i_Number.ToString());
            bytenumber.CopyTo(subscriberBase.userNumber, 0);
            bytenumber.CopyTo(subscriberBase.authKey, 0);
            if (subscriberBase.subType == PublicEnums.EnumNumberType.固话.GetHashCode())
            {
                if (model.i_NuPassword == null) //不设置密码时，默认和号码相同
                {
                    bytenumber.CopyTo(subscriberBase.sipPassword, 0);
                }
                else
                {
                    byte[] bytepsw = System.Text.ASCIIEncoding.ASCII.GetBytes(model.i_NuPassword.ToString());
                   // byte[] bytepsw = System.Text.ASCIIEncoding.ASCII.GetBytes(_mModel.i_NuPassword.ToString());
                    bytepsw.CopyTo(subscriberBase.sipPassword, 0);
                }
            }
            if (model.NumberTypeID.Value == PublicEnums.EnumNumberType.手机3G.GetHashCode() && model.vc_UmtsImsi!=null && model.vc_UmtsImsi != "")
            {
                byte[] byte3G = System.Text.ASCIIEncoding.ASCII.GetBytes(model.vc_UmtsImsi);
                byte3G.CopyTo(subscriberBase.p3gUmtsImsi, 0);

                byte[] byteUmtsKi = System.Text.ASCIIEncoding.ASCII.GetBytes("112233445566778899aabbccddeeff00");
                byteUmtsKi.CopyTo(subscriberBase.authKey, 0);
            }
            //subscriberBase.supplementSerive=0;
            //丢话服务，遇忙通知，短消息服务，三方通话，呼叫等待，呼叫转移，呼叫代答
            //subscriberBase.supplementSerive = (int)(MBoxSDK.ConfigSDK.SPM_MISS_CALL | MBoxSDK.ConfigSDK.SPM_MISS_CALL_ON_BUSY | MBoxSDK.ConfigSDK.SPM_SMS);
            //2013-10-18确定取消默认的呼叫代答功能，因为与关联号码冲突
            //2014-2-18确定取消默认的呼叫等待功能
            subscriberBase.supplementSerive = (int)(MBoxSDK.ConfigSDK.SPM_MISS_CALL |
                                                    MBoxSDK.ConfigSDK.SPM_MISS_CALL_ON_BUSY |
                                                    MBoxSDK.ConfigSDK.SPM_SMS |
                                                    MBoxSDK.ConfigSDK.SPM_THREE_PARTY |
                                                    //MBoxSDK.ConfigSDK.SPM_CALL_WAITING |
                                                    MBoxSDK.ConfigSDK.SPM_CALL_TRANSFER);
                                                   // MBoxSDK.ConfigSDK.SPM_CALL_PICKUP);
            bool create = MBoxSDK.ConfigSDK.MBOX_CreateSubscriber(Global.Params.BoxHandle, ref subscriberBase);
          
            return create;
        }

        private void Modify()
        {
            List<DB_Talk.Model.m_Member> lst = _BLL.GetModelList(string.Format(" i_flag=0 and  i_Number='{0}' and BoxID='{1}'", _mModel.i_Number, _mModel.BoxID));
            if (lst.Count > 0)
            {
                if (lst[0].ID != _mModel.ID)
                {
                    txtTel.Focus();
                    CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("数据库中电话【{0}】已存在！", _mModel.i_Number), "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            lst = _BLL.GetModelList(string.Format(" i_flag=0 and  vc_UmtsImsi='{0}' and BoxID='{1}'", _mModel.vc_UmtsImsi, _mModel.BoxID));
            if (_mModel.NumberTypeID.Value == PublicEnums.EnumNumberType.手机3G.GetHashCode() &&
                lst.Count > 0)
            {
                if (lst[0].ID != _mModel.ID)
                {
                    txtUmtsImsi.Focus();
                    CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("标示码【{0}】已存在!", _mModel.vc_UmtsImsi), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            lst = _BLL.GetModelList(string.Format(" i_flag=0 and  vc_IP='{0}' and BoxID='{1}'", _mModel.vc_IP, _mModel.BoxID));
            if (_mModel.i_TellType.Value == PublicEnums.EnumTelType.广播.GetHashCode() &&
                lst.Count > 0)
            {
                if (lst[0].ID != _mModel.ID)
                {
                    txtUmtsImsi.Focus();
                    CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("IP【{0}】已存在!", _mModel.vc_UmtsImsi), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            string mes = "";
            bool bModify = ModifyTel(out mes);
            if (bModify && _BLL.Update(_mModel))
            {
                UpdateAssociateNum(_mModel);
                CommControl.MessageBoxEx.MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Update, "编辑", "编辑了人员：" + _mModel.vc_Name, "");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ModifyTel(out string mes)
        {
            mes = "";
            if (preNumber != _mModel.i_Number || _mPreModel.NumberTypeID!=_mModel.NumberTypeID.Value)  //修改号码或者用户类型，3G到sip
            {
                bool isdelete = false;
                if ((_mModel.NumberTypeID.Value == PublicEnums.EnumNumberType.手机3G.GetHashCode()
                    && _mModel.vc_UmtsImsi==_mPreModel.vc_UmtsImsi) ||
                     _mPreModel.NumberTypeID != _mModel.NumberTypeID.Value )  //修改3G号码，imsi不变 必须先删除旧号码
                {
                    MBoxSDK.ConfigSDK.MBOX_DeleteSubscriber(Global.Params.BoxHandle, preNumber);
                    isdelete = true;
                }
                if (AddTel(out mes))
                {
                    if(!isdelete) MBoxSDK.ConfigSDK.MBOX_DeleteSubscriber(Global.Params.BoxHandle, preNumber);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else   //号码不修改，修改业务
            {
                if (!ModifyDetail(_mModel.i_Number.Value))
                {
                    mes = "修改硬件中号码配置失败！";
                    return false;
                }
            }
            if (!MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle))
            {
                mes = "保存硬件配置失败";
                return false;
            }
            return true;
        }

        private bool ModifyDetail(long telNumber)
        {
            if (telNumber == 0) return false;

            //新增及修改时时设置权限
            if (_mPreModel.i_Authority != _mModel.i_Authority)
            {
                if (!MBoxSDK.ConfigSDK.MBOX_SetSubscriberPriority(Global.Params.BoxHandle, telNumber, _mModel.i_Authority.Value))
                {
                    CommControl.Tools.WriteLog.AppendErrorLog("修改号码【" + telNumber + "】用户权限失败");
                    return false;
                }
            }

            //if(groupBoxG.Visible == false) return true; //无需修改
            bool modify = false;
            MBoxSDK.ConfigSDK.subscriberServiceDetail subService = new MBoxSDK.ConfigSDK().newSubscriberServiceDetail();//new MBoxSDK.ConfigSDK.subscriberServiceDetail();
            bool b = MBoxSDK.ConfigSDK.MBOX_QuerySubscriber(Global.Params.BoxHandle, telNumber, ref subService);
            if (b)
            {
                uint PreSupplementSerive = subService.supplementSerive;
                bool isModify = false;
                #region 修改
                if (_operate != 0)  //修改
                {
                    if (_mModel.i_TellType != PublicEnums.EnumTelType.G3G手机.GetHashCode() &&
                        _mModel.i_NuPassword > 0 &&
                        System.Text.ASCIIEncoding.ASCII.GetString(subService.sIPSubPassword).Replace("\0", "") != _mModel.i_NuPassword.ToString())
                    {
                        subService.sIPSubPassword = new byte[MBoxSDK.ConfigSDK.MAX_SIPPWD_LEN + 1];
                        byte[] bytenumber = System.Text.ASCIIEncoding.ASCII.GetBytes(_mModel.i_Number.ToString());
                        if (_mModel.i_NuPassword == null) //不设置密码时，默认和号码相同
                        {
                            bytenumber.CopyTo(subService.sIPSubPassword, 0);
                        }
                        else
                        {
                            byte[] bytepsw = System.Text.ASCIIEncoding.ASCII.GetBytes(_mModel.i_NuPassword.ToString());
                            bytepsw.CopyTo(subService.sIPSubPassword, 0);
                        }
                        isModify = true;
                    }
                    //if (subService.subType != _mModel.NumberTypeID.Value) //用户类型不能修改 只能删除再增加
                    //{
                    //    subService.subType = _mModel.NumberTypeID.Value;
                    //    isModify = true;
                    //}
                    //if (subService.subPriority != _mModel.i_Authority.Value)  //单独接口设置
                    //{
                    //    subService.subPriority = _mModel.i_Authority.Value;
                    //    isModify = true;
                    //}
                    //if (subService. != _mModel.vc_UmtsImsi)  //不可以修改
                    //{
                    //    subService. = _mModel.vc_UmtsImsi;
                    //    isModify = true;
                    //}
                    //3G用户标示码
                }
                #endregion
                if (groupBoxG.Visible == true)// return true; //无需修改
                {
                    if (chkUnCForward.Checked && txtUnCForward.Text.Trim() != "")
                    {
                        if (txtUnCForward.Text.Trim() != System.Text.ASCIIEncoding.ASCII.GetString(subService.cfuNumber).Replace("\0", "")) isModify = true; ;
                        byte[] bytenumber = System.Text.ASCIIEncoding.ASCII.GetBytes(txtUnCForward.Text.Trim());
                        subService.cfuNumber = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
                        bytenumber.CopyTo(subService.cfuNumber, 0); //无条件转接
                        subService.supplementSerive |= (int)(MBoxSDK.ConfigSDK.SPM_CFW_UNCON);
                    }
                    else
                        subService.supplementSerive &= (uint)(~MBoxSDK.ConfigSDK.SPM_CFW_UNCON);

                    if (chkNoAnswerForward.Checked && txtNoAnswerForward.Text.Trim() != "")
                    {
                        if (txtNoAnswerForward.Text.Trim() != System.Text.ASCIIEncoding.ASCII.GetString(subService.cfnrNumber).Replace("\0", "")) isModify = true; ;

                        byte[] bytenumber = System.Text.ASCIIEncoding.ASCII.GetBytes(txtNoAnswerForward.Text.Trim());
                        subService.cfnrNumber = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
                        bytenumber.CopyTo(subService.cfnrNumber, 0);  //无应答转接
                        subService.supplementSerive |= (int)(MBoxSDK.ConfigSDK.SPM_CFW_NO_REPLY);
                    }
                    else
                        subService.supplementSerive &= (uint)(~MBoxSDK.ConfigSDK.SPM_CFW_NO_REPLY);

                    if (chkBusyForward.Checked && txtBusyForward.Text.Trim() != "")
                    {
                        if (txtBusyForward.Text.Trim() != System.Text.ASCIIEncoding.ASCII.GetString(subService.cfbNumber).Replace("\0", "")) isModify = true; ;

                        byte[] bytenumber = System.Text.ASCIIEncoding.ASCII.GetBytes(txtBusyForward.Text.Trim());
                        subService.cfbNumber = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
                        bytenumber.CopyTo(subService.cfbNumber, 0);  //遇忙转接
                        subService.supplementSerive |= (int)(MBoxSDK.ConfigSDK.SPM_CFW_BUSY);
                    }
                    else
                        subService.supplementSerive &= (uint)(~MBoxSDK.ConfigSDK.SPM_CFW_BUSY);

                    if (chkPowerOffForward.Checked && txtPowerOffForward.Text.Trim() != "")
                    {
                        if (txtPowerOffForward.Text.Trim() != System.Text.ASCIIEncoding.ASCII.GetString(subService.subCfpfNumber).Replace("\0", "")) isModify = true; ;

                        byte[] bytenumber = System.Text.ASCIIEncoding.ASCII.GetBytes(txtPowerOffForward.Text.Trim());
                        subService.subCfpfNumber = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
                        bytenumber.CopyTo(subService.subCfpfNumber, 0);  //关机转接
                        subService.supplementSerive |= (int)(MBoxSDK.ConfigSDK.SPM_CF_POWEROFF);
                    }
                    else
                        subService.supplementSerive &= (uint)(~MBoxSDK.ConfigSDK.SPM_CF_POWEROFF);

                    if (chkDirectNum.Checked && txtDirectNum.Text.Trim() != "")
                    {
                        if (txtDirectNum.Text.Trim() != System.Text.ASCIIEncoding.ASCII.GetString(subService.DIDNumber).Replace("\0", "")) isModify = true; ;

                        byte[] bytenumber = System.Text.ASCIIEncoding.ASCII.GetBytes(txtDirectNum.Text.Trim());
                        subService.DIDNumber = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
                        bytenumber.CopyTo(subService.DIDNumber, 0);       //直通号码
                        subService.supplementSerive |= (int)(MBoxSDK.ConfigSDK.SPM_DDI);
                    }
                    else
                        subService.supplementSerive &= (uint)(~MBoxSDK.ConfigSDK.SPM_DDI);


                    if (chkAssociateNum1.Checked || chkAssociateNum2.Checked)
                    {
                        subService.supplementSerive |= (int)(MBoxSDK.ConfigSDK.SPM_ASSO_NUM);
                    }
                    else  //去关联
                    {
                        subService.supplementSerive &= (uint)(~MBoxSDK.ConfigSDK.SPM_ASSO_NUM);

                        if (_mPreModel.i_IsAssociateActive == 2) //被动关联
                        {
                            RemoveAssociateNum(_mModel);
                        }

                    }

                    if (chkAssociateNum1.Checked && txtAssociateNum1.Text.Trim() != "")
                    {
                        if (txtAssociateNum1.Text.Trim() != System.Text.ASCIIEncoding.ASCII.GetString(subService.associationNum1).Replace("\0", "")) 
                            isModify = true; 
                        byte[] bytenumber = System.Text.ASCIIEncoding.ASCII.GetBytes(txtAssociateNum1.Text.Trim());
                        subService.associationNum1 = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
                        bytenumber.CopyTo(subService.associationNum1, 0);
                    }

                    if (chkAssociateNum2.Checked && txtAssociateNum2.Text.Trim() != "")
                    {
                        if (txtAssociateNum2.Text.Trim() != System.Text.ASCIIEncoding.ASCII.GetString(subService.associationNum2).Replace("\0", "")) isModify = true; ;

                        byte[] bytenumber = System.Text.ASCIIEncoding.ASCII.GetBytes(txtAssociateNum2.Text.Trim());
                        subService.associationNum2 = new byte[MBoxSDK.ConfigSDK.MAX_PHONENUMER_LEN + 1];
                        bytenumber.CopyTo(subService.associationNum2, 0);
                    }


                    if (chkRecord.Checked)
                    {
                        subService.supplementSerive |= (uint)(MBoxSDK.ConfigSDK.SPM_AUTO_RECORDING);
                    }
                    else
                        subService.supplementSerive &= (uint)(~MBoxSDK.ConfigSDK.SPM_AUTO_RECORDING);
                }
                _mModel.i_supplementSerive = subService.supplementSerive;
                //subService.supplementSerive |= (int)(MBoxSDK.ConfigSDK.SPM_CFW_UNCON |
                //                                MBoxSDK.ConfigSDK.SPM_CFW_NO_REPLY |
                //                                MBoxSDK.ConfigSDK.SPM_CFW_BUSY |
                //                                MBoxSDK.ConfigSDK.SPM_CF_POWEROFF |
                //                                MBoxSDK.ConfigSDK.SPM_DDI |
                //                                MBoxSDK.ConfigSDK.SPM_ASSO_NUM);
                if (PreSupplementSerive != subService.supplementSerive | isModify)  //不同才修改
                    modify = MBoxSDK.ConfigSDK.MBOX_ModifySubscriber(Global.Params.BoxHandle, telNumber, ref subService);
                else
                    modify = true;
            }
            return modify;
        }

        private bool ModifyDetailAssociateNum(long telNumber)
        {
            if (telNumber == 0) return false;
            bool modify = false;
            MBoxSDK.ConfigSDK.subscriberServiceDetail subService = new MBoxSDK.ConfigSDK().newSubscriberServiceDetail();//new MBoxSDK.ConfigSDK.subscriberServiceDetail();
            bool b = MBoxSDK.ConfigSDK.MBOX_QuerySubscriber(Global.Params.BoxHandle, telNumber, ref subService);
            if (b)
            {
                //去关联,只需要去掉增值服务 关联号码会自动消失
                subService.supplementSerive &= (uint)(~MBoxSDK.ConfigSDK.SPM_ASSO_NUM);
                _mModel.i_supplementSerive = subService.supplementSerive;
                modify = MBoxSDK.ConfigSDK.MBOX_ModifySubscriber(Global.Params.BoxHandle, telNumber, ref subService);

            }
            return modify;
        }

        private void ModifyMuti()
        {
            List<DB_Talk.Model.m_Member> lst = _BLL.GetModelList(string.Format(" i_flag=0 and  i_Number='{0}' and BoxID='{1}'", _mModel.i_Number, _mModel.BoxID));

            int ModifyOk = 0;
            int ModifyNo = 0;
           
            foreach (DB_Talk.Model.v_Member vmodel in _lstvModel)
            {
                _mModel = _BLL.GetModel(vmodel.ID);
                _mPreModel = (DB_Talk.Model.m_Member)_mModel.Clone();
                preNumber = int.Parse(_mModel.i_Number.ToString());
                GetModelMuti(ref _mModel);
                string mes = "";
                bool bModify = ModifyTel(out mes);
                if (bModify && _BLL.Update(_mModel))
                {
                    UpdateAssociateNum(_mModel);
                    ModifyOk++;
                    //CommControl.MessageBoxEx.MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Update, "编辑", "编辑了人员：" + _mModel.vc_Name, "");
                    //this.DialogResult = DialogResult.OK;
                    //this.Close();
                }
                else
                {
                    ModifyNo++;
                    //CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            string mess = "";
            if (ModifyOk > 0)
            {
                mess = ModifyOk + "个编辑成功！\r\n";
                this.DialogResult = DialogResult.OK;
            }
            else if (ModifyNo>0)
            {
                mess = ModifyOk + "个编辑失败！";
            }
            CommControl.MessageBoxEx.MessageBoxEx.Show(mess, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();

           
        }

        public void checkNumber(TextBox txt)
        {
            if (txt.Text.Trim() != "" && !Global.Methods.checkNumber(txt.Text.Trim()))
            {
                txt.Text = "";
                txt.Focus();
                CommControl.MessageBoxEx.MessageBoxEx.Show("电话号码不合法", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EnablePasw(bool IsEnable)
        {
            if (IsEnable)
            {
                cmbPassword.Enabled = true;
                txtPassword.Enabled = true;
                if (_operate == 1)
                {
                    if (_mPreModel.i_NuPasswordType != null)
                    {
                        foreach (DataRowView d in cmbPassword.Items)
                        {
                            if (d["ID"].ToString() == _mPreModel.i_NuPasswordType.ToString())
                            {
                                cmbPassword.SelectedItem = d;
                                break;
                            }
                        }
                    }
                    txtPassword.Text = _mModel.i_NuPassword.ToString() != null ? _mModel.i_NuPassword.ToString() : "";
                }
                else
                {
                    //cmbPassword.SelectedIndex = 1;  //默认增加，即和号码相同
                    //_mModel.i_NuPasswordType = 2;  //密码模式
                    //txtPassword.Enabled = false;
                }
                if (cmbPassword.SelectedIndex == 1)
                {
                    //_mModel.i_NuPasswordType = null;
                    txtPassword.Enabled = false;
                }

            }
            else
            {
                cmbPassword.Enabled = false;  //3g用户无密码
                txtPassword.Enabled = false;
                cmbPassword.SelectedIndex = -1;
                txtPassword.Text = "";
                _mModel.i_NuPasswordType = null;
            }
        }

        //判断关联号码
        private void CheckAssociateNum(string AssociateNum)
        {
            List<DB_Talk.Model.m_Member> lst = new List<DB_Talk.Model.m_Member>();
            //box要存在
            lst = new DB_Talk.BLL.m_Member().GetModelList(string.Format(" i_flag=0 and i_IsDispatch=0 and BoxID='{0}' " +
                           " and i_Number='{1}'", Global.Params.BoxID, AssociateNum));
            if (lst.Count > 0)
            {
            }
            else
                throw new Exception("关联号码【" + AssociateNum + "】不存在");
            //只能用一次
            lst = new DB_Talk.BLL.m_Member().GetModelList(string.Format(" i_flag=0 and i_IsDispatch=0 and BoxID='{0}' "+
                            " and i_AssociateNum1='{1}' or i_AssociateNum2='{1}'", Global.Params.BoxID, AssociateNum));
            if (lst.Count > 0)
                throw new Exception("号码【" + AssociateNum + "】已经和号码【"+lst[0].i_Number+"】互为关联号码");
           
        }

        //更新被关联的号码
        private void UpdateAssociateNum(DB_Talk.Model.m_Member model)
        {
                DB_Talk.Model.m_Member m = new DB_Talk.BLL.m_Member().GetModel(string.Format(" i_flag=0 and i_IsDispatch=0 and BoxID='{0}' " +
                               " and i_Number='{1}'", Global.Params.BoxID, model.i_Number));
                if (m != null)
                {
                    if (model.i_AssociateNum1 > 0 || model.i_AssociateNum2 > 0)
                    {
                        m.i_IsAssociateActive = 1;   //主动关联
                    }
                    else
                    {
                        m.i_IsAssociateActive = 0;   //取消关联
                    }
                    new DB_Talk.BLL.m_Member().Update(m);
                }



                if (model.i_AssociateNum1 > 0)
                {
                    List<DB_Talk.Model.m_Member> lst = new List<DB_Talk.Model.m_Member>();
                    lst = new DB_Talk.BLL.m_Member().GetModelList(string.Format(" i_flag=0 and i_IsDispatch=0 and BoxID='{0}' " +
                                   " and i_Number='{1}'", Global.Params.BoxID, model.i_AssociateNum1));
                    if (lst.Count > 0)
                    {
                        lst[0].i_AssociateNum1 = model.i_Number;
                        lst[0].i_AssociateNum2 = model.i_AssociateNum2;
                        lst[0].i_IsAssociateActive = 2;  //被动关联
                        lst[0].i_supplementSerive |= (int)(MBoxSDK.ConfigSDK.SPM_ASSO_NUM);  //关联
                        new DB_Talk.BLL.m_Member().Update(lst[0]);
                    }

                }
                else
                {
                    if (_mPreModel.i_AssociateNum1 > 0)
                    {
                        List<DB_Talk.Model.m_Member> lst = new List<DB_Talk.Model.m_Member>();
                        lst = new DB_Talk.BLL.m_Member().GetModelList(string.Format(" i_flag=0 and i_IsDispatch=0 and BoxID='{0}' " +
                                       " and i_Number='{1}'", Global.Params.BoxID, _mPreModel.i_AssociateNum1));
                        if (lst.Count > 0)
                        {
                            lst[0].i_AssociateNum1 = 0;
                            lst[0].i_AssociateNum2 = 0;
                            lst[0].i_IsAssociateActive = 0;  //取消被动关联
                            lst[0].i_supplementSerive &= (uint)(~MBoxSDK.ConfigSDK.SPM_ASSO_NUM);  //去关联
                            new DB_Talk.BLL.m_Member().Update(lst[0]);
                        }
                    }
                }
                if (model.i_AssociateNum2 > 0)
                {
                    List<DB_Talk.Model.m_Member> lst = new List<DB_Talk.Model.m_Member>();
                    lst = new DB_Talk.BLL.m_Member().GetModelList(string.Format(" i_flag=0 and i_IsDispatch=0 and BoxID='{0}' " +
                                   " and i_Number='{1}'", Global.Params.BoxID, model.i_AssociateNum2));
                    if (lst.Count > 0)
                    {
                        lst[0].i_AssociateNum1 = model.i_Number;
                        lst[0].i_AssociateNum2 = model.i_AssociateNum1;
                        lst[0].i_IsAssociateActive = 2;  //被动关联
                        lst[0].i_supplementSerive |= (int)(MBoxSDK.ConfigSDK.SPM_ASSO_NUM);  //关联
                        new DB_Talk.BLL.m_Member().Update(lst[0]);
                    }
                }
                else
                {
                    if (_mPreModel.i_AssociateNum2 > 0)
                    {
                        List<DB_Talk.Model.m_Member> lst = new List<DB_Talk.Model.m_Member>();
                        lst = new DB_Talk.BLL.m_Member().GetModelList(string.Format(" i_flag=0 and i_IsDispatch=0 and BoxID='{0}' " +
                                       " and i_Number='{1}'", Global.Params.BoxID, _mPreModel.i_AssociateNum2));
                        if (lst.Count > 0)
                        {
                            lst[0].i_AssociateNum1 = 0;
                            lst[0].i_AssociateNum2 = 0;
                            lst[0].i_IsAssociateActive = 0;  //取消被动关联
                            lst[0].i_supplementSerive &= (uint)(~MBoxSDK.ConfigSDK.SPM_ASSO_NUM);  //去关联
                            new DB_Talk.BLL.m_Member().Update(lst[0]);
                        }
                    }
                }
        }

        private void RemoveAssociateNum(DB_Talk.Model.m_Member m) //string UnactiveAssociateNum)  //被动关联的号码
        {
            List<DB_Talk.Model.m_Member> lst = new List<DB_Talk.Model.m_Member>();
            string strW = string.Format(" i_flag=0 and i_IsDispatch=0 and BoxID='{0}' and i_IsAssociateActive=1", Global.Params.BoxID);
            if(m.i_AssociateNum1>0)
                strW = strW + string.Format(" and i_Number='{0}'", m.i_AssociateNum1);
            if (m.i_AssociateNum2 > 0)
                strW = strW + string.Format(" or i_Number='{0}'", m.i_AssociateNum2);

            lst = new DB_Talk.BLL.m_Member().GetModelList(strW);
            if (lst.Count > 0)
            {
                if (ModifyDetailAssociateNum(lst[0].i_Number.Value))
                {
                }
                   // UpdateAssociateNum(lst[0]);
                //lst[0].i_AssociateNum1 = model.i_Number;
                //lst[0].i_AssociateNum2 = model.i_AssociateNum2;
                //lst[0].i_IsAssociateActive = 2;  //被动关联
                //new DB_Talk.BLL.m_Member().Update(lst[0]);
            }
        }
        #endregion



        public bool IsSameLanNet(IPAddress ipA, IPAddress ipB)
        {
            long value = 256 * 256 * 256;
            if (ipA.Address % value == ipB.Address % value)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private void SetTxtLeng()
        {
            txtTel.MaxLength = Global.Params.NumberLen;
            txtTelEnd.MaxLength = Global.Params.NumberLen;
            txtPassword.MaxLength = Global.Params.NumberLen;
            txtUnCForward.MaxLength = Global.Params.NumberLen;
            txtNoAnswerForward.MaxLength = Global.Params.NumberLen;
            txtPowerOffForward.MaxLength = Global.Params.NumberLen;
            txtBusyForward.MaxLength = Global.Params.NumberLen;
            txtDirectNum.MaxLength = Global.Params.NumberLen;
            txtAssociateNum1.MaxLength = Global.Params.NumberLen;
            txtAssociateNum2.MaxLength = Global.Params.NumberLen;

        }

    }
}
