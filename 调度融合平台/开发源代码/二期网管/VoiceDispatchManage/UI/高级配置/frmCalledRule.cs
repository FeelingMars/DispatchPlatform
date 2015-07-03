using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl;

namespace VoiceDispatchManage.UI
{
    public partial class frmCalledRule : frmBase
    {
       
        int _operate = 0;
        private DB_Talk.Model.m_CalledRule _mModel = new DB_Talk.Model.m_CalledRule();
        private DB_Talk.BLL.m_CalledRule _BLL = new DB_Talk.BLL.m_CalledRule();
        /// <summary>
        /// 是否可以增加出局
        /// </summary>
        private bool _canAddOutCall = false;
        private Bestway.Windows.Controls.InputPromptDialog _SipBox = new Bestway.Windows.Controls.InputPromptDialog();
        private Bestway.Windows.Controls.InputPromptDialog _PriBox = new Bestway.Windows.Controls.InputPromptDialog();
        
        public frmCalledRule(DB_Talk.Model.m_CalledRule m, int operate)
        {
            InitializeComponent();
           
            _operate = operate;
            if (operate == 0)
            {
                this.FormTitle = "添加";
                btnOK.Text = "添加";
               
            }
            else
            {
                _mModel = m;
                this.FormTitle = "编辑";
                btnOK.Text = "编辑";
               // ShowModel();
            }

            this.Load += new EventHandler(frmCalledRule_Load);
           
            
        }

        void frmCalledRule_Load(object sender, EventArgs e)
        {
            Initcmb();
            int a = InitListSipBox();
            int b = InitListPriBox();
            if (a != 0 || b != 0)
            {
                _canAddOutCall = true;
            }
            else
            {
                _canAddOutCall = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                GetModel();
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
                     Add();
                }
                else if (btnOK.Text == "编辑")
                {
                    //Modify();
                }
            }
            catch(Exception ex)
            {
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {

        }

        private void cmbCallType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _mModel.i_CalledType = int.Parse(cmbCallType.SelectedValue.ToString());
                if (cmbCallType.SelectedValue.ToString() == MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.出局.GetHashCode().ToString())
                {
                    //_mModel.i_CalledSubType = MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途.GetHashCode();
                    if (txtListSip.Enabled == txtListPri.Enabled)
                    {
                        txtListSip.Enabled = true;
                        txtListPri.Enabled = true;
                    }
                    txtDele.Enabled = true ;
                    txtDele.Text = "";
                    if (_canAddOutCall == false)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("出局需要使用中继，请先增加中继配置!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        cmbCallType.SelectedIndex = -1;
                    }
                }
                else
                {
                   // _mModel.i_CalledSubType = MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.SUB.GetHashCode();
                    txtListSip.Text="";
                    txtListPri.Text="";
                    txtListPri.Enabled = false;
                    txtListSip.Enabled = false;
                   // cmbCallSubType.SelectedItem = cmbCallSubType.Items[0];
                    txtDele.Enabled = false;
                    txtDele.Text = "0";
                }

                InitcmbSubType((MBoxSDK.ConfigSDK.CALLED_RULE_TYPE)_mModel.i_CalledType);
               
            }
            catch { }
        }

        private void cmbCallSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _mModel.i_CalledSubType = int.Parse(cmbCallSubType.SelectedValue.ToString());
            }
            catch { }
        }

        private void cmbCallSubType_Click(object sender, EventArgs e)
        {
            if (cmbCallType.SelectedIndex < 0)
                CommControl.MessageBoxEx.MessageBoxEx.Show("请先选择呼叫类型", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void txtListSip_TextChanged(object sender, EventArgs e)
        {
            if (txtListSip.Text != "")
            {
                txtListPri.Text = "";
                txtListPri.Enabled = false;
            }
            else
            {
                txtListPri.Enabled = true;
            }
        }  

        void _SipBox_OnTextChangedEx(object sender, Bestway.Windows.Controls.InputPromptDialog.TextChanagedEventArgs e)
        {
            try
            {
                if (e.IsFind)
                {
                    _mModel.i_SIPID = int.Parse(e.SelectedRow["SIP编号"].ToString());
                    _mModel.DestRouteID = int.Parse(e.SelectedRow["路由ID"].ToString());
                }
                else
                {
                    _mModel.i_SIPID = 0;
                    _mModel.DestRouteID = 0;
                } 
            }
            catch
            {
            }
        }

        void txtListSip_OnDropDown(object sender, EventArgs e)
        {
            _SipBox.ShowDropDown();
        }

        void txtListPri_TextChanged(object sender, EventArgs e)
        {
            if (txtListPri.Text != "")
            {
                txtListSip.Text = "";
                txtListSip.Enabled = false;
            }
            else
            {
                txtListSip.Enabled = true;
            }
        }

        void _PriBox_OnTextChangedEx(object sender, Bestway.Windows.Controls.InputPromptDialog.TextChanagedEventArgs e)
        {
            try
            {
                if (e.IsFind)
                {
                    _mModel.i_PRIID = int.Parse(e.SelectedRow["PRI编号"].ToString());
                    _mModel.DestRouteID = int.Parse(e.SelectedRow["路由ID"].ToString());
                }
                else
                {
                    _mModel.i_PRIID = 0;
                    _mModel.DestRouteID = 0;
                }

               
            }
            catch
            {

            }
        }

        void txtListPri_OnDropDown(object sender, EventArgs e)
        {
            _PriBox.ShowDropDown();
        }


        #region 公共方法

        private void GetModel()
        {
            int num = 0;
            _mModel.BoxID = Global.Params.BoxID;
            _mModel.CalledID = 1;  //被叫号码分析规则索引固定为1
            _mModel.CallingOriID = 1;  //呼叫源索引固定为1
          //  _mModel.DestRouteID = 0;  //目的路由
            //if (_mModel.i_SIPID>0)
            //{
            //    _mModel.DestRouteID = _mModel.i_SIPID;
            //}
            //if (_mModel.i_PRIID>0)
            //{
            //    _mModel.DestRouteID = _mModel.i_PRIID;
            //}
           
            if (_mModel.i_CalledType <= 0)
            {
                cmbCallType.Focus();
                throw new Exception("呼叫类型不能为空");
            }

            if (_mModel.i_CalledSubType <= 0)
            {
                cmbCallSubType.Focus();
                throw new Exception("呼叫子类型不能为空");
            }


            if (!int.TryParse(txtNumber.Text.Trim(), out num) || num<0 || num>9999)
            {
                txtNumber.Focus();
                throw new Exception("号码前缀必须是0～9999之间的数字");
            }
            _mModel.vc_CalledNumber = num.ToString();

            num = 0;

            if (!int.TryParse(txtDele.Text.Trim(), out num) || num < 0 || num > _mModel.vc_CalledNumber.ToString().Length) //num<=int.MaxValue)
            {
                txtDele.Focus();
                throw new Exception("删除号码位数必须是0～" + _mModel.vc_CalledNumber.ToString().Length + "之间的数字");

            }
           
           

            //if (_mModel.i_CalledType == MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.出局.GetHashCode())
            //{

            //}

            _mModel.i_CalledChangeLength = num;
            if (_mModel.i_CalledChangeLength > 0) _mModel.i_CalledChangeType = MBoxSDK.ConfigSDK.CALLED_RULE_TransAct.DELETE.GetHashCode();
            
         

            //if (_mModel.i_CalledType == MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.入局.GetHashCode())
            //    _mModel.i_CalledSubType = MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.SUB.GetHashCode();
            //else
            //{
            //    _mModel.i_CalledSubType = MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途.GetHashCode();
            //    if (_mModel.i_SIPID == 0 && _mModel.i_PRIID == 0)
            //    {
            //        txtListSip.Focus();
            //        throw new Exception("呼叫类型为出局时，必须选择SIP或PRI中继中的一种");
            //    }
            //}

            if (_mModel.i_CalledType == MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.出局.GetHashCode() &&
                _mModel.i_PRIID == 0 && _mModel.i_SIPID == 0)
            {
                txtListSip.Focus();
                throw new Exception("呼叫类型为出局时，必须选择SIP或PRI中继中的一种");
            }




        }

        private void Initcmb()
        {
            //呼叫类型
            System.Data.DataTable dtType = new DataTable();
            dtType.Columns.Add("ID");
            dtType.Columns.Add("vc_Name");

            Type noType = typeof(MBoxSDK.ConfigSDK.CALLED_RULE_TYPE);  //.EnumNumberType);
            foreach (MBoxSDK.ConfigSDK.CALLED_RULE_TYPE t in Enum.GetValues(noType))
            {
                if (t == MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.SERVICE || t == MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.SERVICE_CODE) continue;
                dtType.Rows.Add(t.GetHashCode(), t.ToString());
            }

            cmbCallType.DataSource = dtType;
            cmbCallType.DisplayMember = "vc_Name";
            cmbCallType.ValueMember = "ID";
            cmbCallType.SelectedIndex = -1;
            if (_operate == 1)
            {
                if (_mModel.i_CalledType > 0)
                {
                    foreach (DataRowView d in cmbCallType.Items)
                    {
                        if (d["ID"].ToString() == _mModel.i_CalledType.ToString())
                        {
                            cmbCallType.SelectedItem = d;
                            break;
                        }
                    }
                }
            }
        }
        private void InitcmbSubType(MBoxSDK.ConfigSDK.CALLED_RULE_TYPE CalledType)
        {
            
            //呼叫子类型
            System.Data.DataTable dtSubType = new DataTable();
            dtSubType.Columns.Add("ID");
            dtSubType.Columns.Add("vc_Name");
            if (CalledType == MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.入局)
            {
                dtSubType.Rows.Add(MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.SUB.GetHashCode(), MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.SUB.ToString());
            }
            else if (CalledType == MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.出局)
            {
                dtSubType.Rows.Add(MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.市话.GetHashCode(), MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.市话.ToString());
                dtSubType.Rows.Add(MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途.GetHashCode(), MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途.ToString());
            }
            cmbCallSubType.DataSource = dtSubType;
            cmbCallSubType.DisplayMember = "vc_Name";
            cmbCallSubType.ValueMember = "ID";
            cmbCallSubType.SelectedIndex = -1;
            cmbCallSubType.SelectedIndex = 0;
            if (_operate == 1)
            {
                if (_mModel.i_CalledSubType > 0)
                {
                    foreach (DataRowView d in cmbCallSubType.Items)
                    {
                        if (d["ID"].ToString() == _mModel.i_CalledSubType.ToString())
                        {
                            cmbCallSubType.SelectedItem = d;
                            break;
                        }
                    }
                }
            }
        }

        private int InitListSipBox()
        {
            //姓名
            DataSet ds = (new DB_Talk.BLL.m_SIPInterface()).GetListSql(
                "select ID,SIPID as SIP编号,vc_OutNumber as 出局前缀号码 ,RouteID as 路由ID from m_SIPInterface where i_Flag=0 and BoxID='" + Global.Params.BoxID + "'");
            DataTable dt = ds.Tables[0];
            int[] hideTypeCol = { 1 };
            this.txtListSip.OnDropDown += new EventHandler(txtListSip_OnDropDown);
            this.txtListSip.TextChanged += new EventHandler(txtListSip_TextChanged);
            _SipBox.OnTextChangedEx += new Bestway.Windows.Controls.InputPromptDialog.TextChangedEx(_SipBox_OnTextChangedEx);

            if (dt.Rows.Count > 0)
            {
                _SipBox.Bind(this.txtListSip.txtValue, dt, 2, hideTypeCol);
            }
            else
            {
                txtListSip.Enabled = false;
            }

            if (_operate == 1)
            {
                txtListSip.Text = _mModel.i_SIPID.ToString();
            }
            return dt.Rows.Count;
        }

        private int InitListPriBox()
        {
            //姓名
            DataSet ds = (new DB_Talk.BLL.m_PRIInterface()).GetListSql(
                "select ID,PRIID as PRI编号,vc_OutNumber as 出局前缀号码 ,RouteID as 路由ID from m_PRIInterface where i_Flag=0 and BoxID='" + Global.Params.BoxID + "'");
            DataTable dt = ds.Tables[0];
            int[] hideTypeCol = { 1 };
            this.txtListPri.OnDropDown += new EventHandler(txtListPri_OnDropDown);
            this.txtListPri.TextChanged += new EventHandler(txtListPri_TextChanged);
            _PriBox.OnTextChangedEx += new Bestway.Windows.Controls.InputPromptDialog.TextChangedEx(_PriBox_OnTextChangedEx);

            if (dt.Rows.Count > 0)
            {
                _PriBox.Bind(this.txtListPri.txtValue, dt, 2, hideTypeCol);
            }
            else
            {
                txtListSip.Enabled = false;
            }
            if (_operate == 1)
            {
                txtListPri.Text = _mModel.i_PRIID.ToString();
            }
            return dt.Rows.Count;
        }


        private void Add()
        {
            if (_BLL.GetModelList(string.Format(" i_flag=0 and  vc_CalledNumber='{0}'", _mModel.vc_CalledNumber)).Count > 0)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("被叫号码【{0}】已存在!", _mModel.vc_CalledNumber), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtNumber.Focus();
                throw new Exception("");
            }

            if (Tools.MBoxOperate.CreateCalledRule(_mModel) && _BLL.Add(_mModel) == 1)
            {
                if (_mModel.i_CalledType == MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.入局.GetHashCode())
                {
                    DB_Talk.Model.m_Box modelBox = new DB_Talk.BLL.m_Box().GetModel(
                               string.Format(" i_Flag=0 and ID='{0}'", Global.Params.BoxID));

                    modelBox.vc_NumberHead = modelBox.vc_NumberHead + "," + _mModel.vc_CalledNumber;
                    modelBox.vc_NumberHead = modelBox.vc_NumberHead.Replace(",,", ",").Trim(',');
                    new DB_Talk.BLL.m_Box().Update(modelBox);
                }
                 
                if (_mModel.i_SIPID > 0)
                {
                    DB_Talk.Model.m_SIPInterface modelSip = new DB_Talk.BLL.m_SIPInterface().GetModel(
                             string.Format(" i_Flag=0 and SIPID='{0}' and BoxID='{1}'", _mModel.i_SIPID, Global.Params.BoxID));
                 
                    if(_mModel.i_CalledSubType==MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.市话.GetHashCode())
                    {
                        modelSip.vc_OutNumberLocal = modelSip.vc_OutNumberLocal + "," + _mModel.vc_CalledNumber;
                        modelSip.vc_OutNumberLocal = modelSip.vc_OutNumberLocal.Replace(",,", ",").Trim(','); 
                    }
                    else if (_mModel.i_CalledSubType == MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途.GetHashCode())
                    {
                        modelSip.vc_OutNumber = modelSip.vc_OutNumber + "," + _mModel.vc_CalledNumber;
                        modelSip.vc_OutNumber = modelSip.vc_OutNumber.Replace(",,", ",").Trim(','); 
                    }
                        
                   
                    new DB_Talk.BLL.m_SIPInterface().Update(modelSip);
                }
                if (_mModel.i_PRIID > 0)
                {
                    DB_Talk.Model.m_PRIInterface modelPri = new DB_Talk.BLL.m_PRIInterface().GetModel(
                                string.Format(" i_Flag=0 and PRIID='{0}' and BoxID='{1}'", _mModel.i_PRIID, Global.Params.BoxID));

                    if (_mModel.i_CalledSubType == MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.市话.GetHashCode())
                    {
                        modelPri.vc_OutNumberLocal = modelPri.vc_OutNumberLocal + "," + _mModel.vc_CalledNumber;
                        modelPri.vc_OutNumberLocal = modelPri.vc_OutNumberLocal.Replace(",,", ",").Trim(','); 
                    }
                    else if (_mModel.i_CalledSubType == MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途.GetHashCode())
                    {
                        modelPri.vc_OutNumber = modelPri.vc_OutNumber + "," + _mModel.vc_CalledNumber;
                        modelPri.vc_OutNumber = modelPri.vc_OutNumber.Replace(",,", ",").Trim(','); 
                    }
                   
                    new DB_Talk.BLL.m_PRIInterface().Update(modelPri);
                }
                CommControl.MessageBoxEx.MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        #endregion

      


    }
}
