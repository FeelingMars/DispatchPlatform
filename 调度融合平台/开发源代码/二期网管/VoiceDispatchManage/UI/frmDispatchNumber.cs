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
    public partial class frmDispatchNumber : UserControl
    {
        int _selectIndex = 0;
        int DispatchCount = 2;
        List<DB_Talk.Model.m_Member> lstMember = new List<DB_Talk.Model.m_Member>();
        List<DB_Talk.Model.m_Member> NewlstMember = new List<DB_Talk.Model.m_Member>();

        List<DB_Talk.Model.m_CalledRule> OldlstCalledRule = new List<DB_Talk.Model.m_CalledRule>();
        List<DB_Talk.Model.m_CalledRule> NewlstCalledRule = new List<DB_Talk.Model.m_CalledRule>();

        DB_Talk.BLL.m_Member BLL = new DB_Talk.BLL.m_Member();
        DB_Talk.Model.m_Box PreBoxModel = new DB_Talk.Model.m_Box();
        DB_Talk.Model.m_Box NewBoxModel = new DB_Talk.Model.m_Box();

        DB_Talk.Model.m_Member modelDispatch = null;
        DB_Talk.Model.m_Member preModelDispatch = null;

        #region 私有方法
        public void LoadData()
        {
            string inNumber = Tools.MBoxOperate.GetCalledNumbers(MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.入局, "");
            PreBoxModel.vc_NumberHead = inNumber;
            PreBoxModel = new DB_Talk.BLL.m_Box().GetModel(Global.Params.BoxID);
            //StringBuilder sb = new StringBuilder();
            //if (PreBoxModel.i_DispatchNumber != null) sb.Append(",'" + PreBoxModel.i_DispatchNumber.ToString() + "'");
            //if (PreBoxModel.i_EmergencyNumber != null) sb.Append(",'" + PreBoxModel.i_EmergencyNumber.ToString() + "'");
            //if (PreBoxModel.vc_NumberHead != null) sb.Append(",'" + PreBoxModel.vc_NumberHead.ToString() + "'");
            //string strW = string.Format(" i_Flag=0 and BoxID='{0}' ", Global.Params.BoxID);
            //if (sb.Length > 0)
            //{
            //    sb.Remove(0, 1);
            //    strW = string.Format(" i_Flag=0 and BoxID='{0}' and vc_CalledNumber in ({1})",
            //                         Global.Params.BoxID, sb.ToString());
            //}


            DB_Talk.Model.m_Member m = BLL.GetModel("i_Flag=0 and BoxID='" +
                                          Global.Params.BoxID + "' and i_IsDispatch='2'");
            txtDispatch.Tag = m;
            preModelDispatch = m;
            if (m != null)
            {
                txtDispatch.Text = m.i_Number.ToString();
                txtDispatchPassword.Text = m.i_NuPassword.ToString();
            }


            string strW = string.Format(" i_Flag=0 and BoxID='{0}' and i_CalledType = '{1}'", Global.Params.BoxID,MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.入局.GetHashCode());
            OldlstCalledRule = new DB_Talk.BLL.m_CalledRule().GetModelList(strW);
            string strWhere = string.Format("i_Flag=0 and BoxID='" +Global.Params.BoxID+ "' and i_IsDispatch='1' order by ID");  //i_Number");
            lstMember = BLL.GetModelList(strWhere);
            //dgvList.DataSource = lstModel;
            dgvList.Rows.Clear();

            for (int i = 0; i < DispatchCount; i++)
            {
                DB_Talk.Model.m_Member model = new DB_Talk.Model.m_Member();
                if (lstMember.Count > i)
                {
                    model.ID = lstMember[i].ID;
                    model.vc_Name = lstMember[i].vc_Name;
                    model.i_Number = lstMember[i].i_Number;
                    dgvList.Rows[dgvList.Rows.Add(ID,
                    "调度员" + (i + 1).ToString(),
                    lstMember[i].vc_Name,
                    lstMember[i].i_Number != null && lstMember[i].i_Number.Value > 0 ? lstMember[i].i_Number.ToString() : ""
                    )].Tag = lstMember[i];
                }
                else
                {
                    dgvList.Rows.Add("", "调度员" + (i + 1).ToString(), "", "", "");
                    lstMember.Add(model);
                }
            }

            dgvList.ClearSelection();

            //if (lstModel.Count == DispatchCount)
            //{
            //    int index = 0;
            //    foreach (DB_Talk.Model.m_Member item in lstModel)
            //    {
            //        dgvList.Rows[dgvList.Rows.Add(ID,
            //            "调度员" + index.ToString(),
            //            item.vc_Name,
            //            item.i_Number
            //            )].Tag = item;
            //    }
            //}


        }

        private void GetModel()
        {
            NewBoxModel.ID = PreBoxModel.ID;
            if (txtDispatchCenter.Text.Trim() == "")
                throw new Exception("调度中心号码不能为空");
            else
                NewBoxModel.i_DispatchNumber = int.Parse(txtDispatchCenter.Text.Trim());
            if (TxtEmergencyNumber.Text.Trim() == "")
                throw new Exception("紧急呼叫号码不能为空");
            else
                NewBoxModel.i_EmergencyNumber = int.Parse(TxtEmergencyNumber.Text.Trim());

            if (NewBoxModel.i_DispatchNumber==NewBoxModel.i_EmergencyNumber )
            {
                throw new Exception("调度中心号码不能和紧急呼叫号码相同");
            }
            if (chkNumHead.EditValue.ToString() == "")
                throw new Exception("内部分机首位码不能为空");
            else
                NewBoxModel.vc_NumberHead = chkNumHead.EditValue.ToString().Replace(" ","");
            if (txtNumberLen.Text.Trim() == "")
                throw new Exception("内部分机号码长度不能为空");
            else
                NewBoxModel.i_NumberLen = int.Parse(txtNumberLen.Text.Trim());
            Global.Params.NumberLen = NewBoxModel.i_NumberLen.Value;
            Global.Params.strNumHead = chkNumHead.EditValue.ToString().Replace(" ","");

            //检查调度号码
            NewlstMember = new List<DB_Talk.Model.m_Member>();
            string mes = "";
            for (int i = 0; i < DispatchCount; i++)
            {
                DB_Talk.Model.m_Member model = new DB_Talk.Model.m_Member();
                model.vc_Name = dgvList.Rows[i].Cells["colName"].Value==null?"":dgvList.Rows[i].Cells["colName"].Value.ToString();
                int num = 0;
                if (dgvList.Rows[i].Cells["colNumber"].Value != null && int.TryParse(dgvList.Rows[i].Cells["colNumber"].Value.ToString(), out num))
                    model.i_Number = num;
                if (model.vc_Name != "" && model.i_Number > 0)
                {
                    string str = model.i_Number.ToString().Substring(0, 1);
                    if (model.i_Number.ToString().Length != Global.Params.NumberLen || Global.Params.strNumHead.IndexOf(str) < 0)
                    {
                        mes = Global.Params.strNumHead.Replace(",", "或");
                        throw new Exception("号码长度必须是【" + Global.Params.NumberLen + "】位，且以数字【" + mes + "】开头");
                    }

                    if (model.i_Number==NewBoxModel.i_DispatchNumber)
                    {
                        throw new Exception("手柄号码不能和调度中心号码相同！");
                    }
                    if( model.i_Number==NewBoxModel.i_EmergencyNumber)
                    {
                        throw new Exception("手柄号码不能和紧急呼叫号码相同！");
                    }
                    model.BoxID = Global.Params.BoxID;
                    model.i_IsDispatch = 1;
                    model.NumberTypeID = CommControl.PublicEnums.EnumNumberType.手机Wifi.GetHashCode();
                    model.i_Authority = CommControl.PublicEnums.EnumAuthority.国内长途.GetHashCode();
                    model.i_supplementSerive = MBoxSDK.ConfigSDK.SPM_DISPATCH | MBoxSDK.ConfigSDK.SPM_TELEAGENT | MBoxSDK.ConfigSDK.SPM_AUTO_RECORDING;
                    DB_Talk.Model.m_Member preModel = dgvList.Rows[i].Tag as DB_Talk.Model.m_Member;
                    List<DB_Talk.Model.m_Member> temp = BLL.GetModelList(string.Format(" i_flag=0 and  i_Number='{0}' and BoxID='{1}'", model.i_Number, model.BoxID));
                    if (preModel != null)  //修改
                    {
                        model.ID = preModel.ID;
                        if (temp != null && temp.Count > 0)
                        {
                            if (model.ID != temp[0].ID)
                            {
                                mes = (string.Format("数据库中号码【{0}】已存在!", model.i_Number));
                                throw new Exception(mes);
                            }
                        }
                    }
                    else  //新增
                    {
                        if (temp != null && temp.Count > 0)
                        {
                            mes = (string.Format("数据库中号码【{0}】已存在!", model.i_Number));
                            throw new Exception(mes);
                        }
                    }
                    NewlstMember.Add(model);
                }
                else
                {
                    mes = "【" + dgvList.Rows[i].Cells["colDispatch"].Value + "】名称为空或者号码不合法";
                    throw new Exception(mes);
                }
            }
        }
        private void GetDispatchModel(ref DB_Talk.Model.m_Member model,ref DB_Talk.Model.m_Member preModel)
        {
            model = new DB_Talk.Model.m_Member();
            preModel = txtDispatch.Tag as DB_Talk.Model.m_Member;
            try
            {
                if (txtDispatch.Text.Trim() == "")
                {
                    txtDispatch.Focus();
                    throw new Exception("视频调度号码不能为空");
                }
                else
                {
                    int num = 0;
                    if (int.TryParse(txtDispatch.Text.Trim(), out num))
                    {
                        model.i_Number = num;
                        model.vc_Name = txtDispatch.Text.Trim();
                    }
                    else
                    {
                        txtDispatch.Focus();
                        throw new Exception("视频调度号码只能为数字");
                    }
                    //model.i_Number = Convert.ToInt32(txtDispatch.Text.Trim());
                }

                if (txtDispatchPassword.Text.Trim() == "")
                {
                    txtDispatchPassword.Focus();
                    throw new Exception("视频调度密码不能为空");
                }
                else
                {
                    UInt64 num = 0;
                    if (UInt64.TryParse(txtDispatchPassword.Text.Trim(), out num))
                    {
                        model.i_NuPassword = Convert.ToUInt64(num);
                    }
                    else
                    {
                        txtDispatchPassword.Focus();
                        throw new Exception("视频调度号码只能为数字");
                    }
                }

                string mes = string.Empty;
                if (model.vc_Name != "" && model.i_Number > 0)
                {
                    string str = model.i_Number.ToString().Substring(0, 1);
                    if (model.i_Number.ToString().Length != Global.Params.NumberLen || Global.Params.strNumHead.IndexOf(str) < 0)
                    {
                        mes = Global.Params.strNumHead.Replace(",", "或");
                        throw new Exception("号码长度必须是【" + Global.Params.NumberLen + "】位，且以数字【" + mes + "】开头");
                    }
                    model.BoxID = Global.Params.BoxID;
                    model.i_IsDispatch = 2;
                    model.NumberTypeID = CommControl.PublicEnums.EnumNumberType.手机Wifi.GetHashCode();
                    model.i_Authority = CommControl.PublicEnums.EnumAuthority.国内长途.GetHashCode();
                    model.i_supplementSerive = MBoxSDK.ConfigSDK.SPM_DISPATCH | MBoxSDK.ConfigSDK.SPM_TELEAGENT | MBoxSDK.ConfigSDK.SPM_AUTO_RECORDING;
                    List<DB_Talk.Model.m_Member> temp = BLL.GetModelList(string.Format(" i_flag=0 and  i_Number='{0}' and BoxID='{1}'", model.i_Number, model.BoxID));
                    if (preModel != null)  //修改
                    {
                        model.ID = preModel.ID;
                        if (temp != null && temp.Count > 0)
                        {
                            //判断是否存在重复的号码
                            //if (model.ID != temp[0].ID)
                            //{
                            //    mes = (string.Format("数据库中号码【{0}】已存在!", model.i_Number));
                            //    throw new Exception(mes);
                            //}
                            //不需要修改
                            if (model.ID == temp[0].ID && temp[0].i_Number == model.i_Number
                                          && temp[0].i_NuPassword == model.i_NuPassword)
                            {
                                model = null;
                            }
                        }
                    }
                    else  //新增
                    {
                        if (temp != null && temp.Count > 0)
                        {
                            mes = (string.Format("数据库中号码【{0}】已存在!", model.i_Number));
                            throw new Exception(mes);
                        }
                    }
                    //NewlstMember.Add(model);
                }
                else
                {
                    mes = "【" + txtDispatch.Text.Trim() + "】名称为空或者号码不合法";
                    throw new Exception(mes);
                }
            }
            catch (Exception ex)
            {
                model = null;
                throw new Exception(ex.Message);
            }
            //return model;
        }

        private void ShowModel()
        {
            txtDispatchCenter.Text = PreBoxModel.i_DispatchNumber.ToString() == "0" ? "" : PreBoxModel.i_DispatchNumber.ToString();
            TxtEmergencyNumber.Text = PreBoxModel.i_EmergencyNumber.ToString() == "0" ? "" : PreBoxModel.i_EmergencyNumber.ToString();
            if (PreBoxModel.vc_NumberHead == null) 
                chkNumHead.EditValue = "";
            else
                chkNumHead.EditValue = PreBoxModel.vc_NumberHead.ToString() == "0" ? "" : PreBoxModel.vc_NumberHead.ToString();
            txtNumberLen.Text = PreBoxModel.i_NumberLen.ToString() == "0" ? "" : PreBoxModel.i_NumberLen.ToString();

            List<DB_Talk.Model.v_Member> lst = new List<DB_Talk.Model.v_Member>();
            lst = new DB_Talk.BLL.v_Member().GetModelList("i_Flag=0 and BoxID='" + Global.Params.BoxID + "' and i_IsDispatch=0 ");
            if (lst.Count > 0) //添加了用户号码之后不允许修改引导码和长度限制
            {
                 txtNumberLen.ReadOnly=true;

                 //chkNumHead.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
                 chkNumHead.Properties.ReadOnly=true;
            }
        }

        public List<DB_Talk.Model.m_CalledRule> getLstCalledRule()
        {
            List<DB_Talk.Model.m_CalledRule> lst = new List<DB_Talk.Model.m_CalledRule>();
            DB_Talk.Model.m_CalledRule model = new DB_Talk.Model.m_CalledRule(); //调度呼叫规则
            model.CalledID = 1;
            model.CallingOriID = 1;
            model.vc_CalledNumber = (txtDispatchCenter.Text.Trim());
            model.i_CalledType = MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.SERVICE.GetHashCode();  //service
            model.i_CalledSubType = MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.话务员.GetHashCode();
            model.DestRouteID = 0;
            model.i_CalledChangeType = MBoxSDK.ConfigSDK.CALLED_RULE_TransAct.NONE.GetHashCode();
            model.i_CalledChangePosition = 0;
            model.i_CalledChangeLength = 0;
            model.vc_CalledChangeTarget = "";
            model.BoxID = Global.Params.BoxID;
            string mes = "";
            if (new Tools.MBoxOperate().IsExitCalledRule(model, out mes))
            {
                if (mes != "")
                    throw (new Exception("已经存在被叫号码为【" + mes + "】的呼叫规则！"));
                else
                    OldlstCalledRule.Remove(model);
            }
            else
                lst.Add(model);

            DB_Talk.Model.m_CalledRule mEm = new DB_Talk.Model.m_CalledRule(); //紧急呼叫规则
            mEm.CalledID = 1;
            mEm.CallingOriID = 1;
            mEm.vc_CalledNumber = (TxtEmergencyNumber.Text.Trim());//int.Parse(EmergencyNumber);// 
            mEm.i_CalledType = MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.SERVICE.GetHashCode();  //service
            mEm.i_CalledSubType = MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.紧急呼叫.GetHashCode();
            mEm.DestRouteID = 0;
            mEm.i_CalledChangeType = MBoxSDK.ConfigSDK.CALLED_RULE_TransAct.NONE.GetHashCode();
            mEm.i_CalledChangePosition = 0;
            mEm.i_CalledChangeLength = 0;
            mEm.vc_CalledChangeTarget = "";
            mEm.BoxID = Global.Params.BoxID;
            //if (!new Tools.MBoxOperate().IsExitCalledRule(mEm)) lst.Add(mEm);
            if (new Tools.MBoxOperate().IsExitCalledRule(mEm, out mes) )
            {
                if (mes != "")
                    throw (new Exception("已经存在被叫号码为【" + mes + "】的呼叫规则！"));
                else
                    OldlstCalledRule.Remove(mEm);
            }
            else
                lst.Add(mEm);


            //入局号码被叫规则
            string strNums = chkNumHead.EditValue.ToString().Trim().Replace(" ","");
            string[] strArray = strNums.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArray)  //入局规则
            {
                DB_Talk.Model.m_CalledRule m = new DB_Talk.Model.m_CalledRule();
                m.CalledID = 1;
                m.CallingOriID = 1;
                m.vc_CalledNumber = str.Trim();
                m.i_CalledType = MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.入局.GetHashCode();  //service
                m.i_CalledSubType = MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.SUB.GetHashCode();
                m.DestRouteID = 0;
                m.i_CalledChangeType = MBoxSDK.ConfigSDK.CALLED_RULE_TransAct.NONE.GetHashCode();
                m.i_CalledChangePosition = 0;
                m.i_CalledChangeLength = 0;
                m.vc_CalledChangeTarget = "";
                m.BoxID = Global.Params.BoxID;
                //if (!new Tools.MBoxOperate().IsExitCalledRule(m)) lst.Add(m);
                if (new Tools.MBoxOperate().IsExitCalledRule(m, out mes))
                {
                    if (mes != "")
                        throw (new Exception("已经存在被叫号码为【" + mes + "】的呼叫规则！"));
                    else
                        OldlstCalledRule.Remove(m);
                  
                }
                else
                    lst.Add(m);
            }
            return lst;
        }

        public void IsExit_InRule(List<DB_Talk.Model.m_CalledRule> lstCalledRule)
        {
            bool b = false;
            StringBuilder sb = new StringBuilder();
            StringBuilder sbExit = new StringBuilder();
            string mes = "";
          
            List<DB_Talk.Model.m_CalledRule> lst = new List<DB_Talk.Model.m_CalledRule>();
            //QueryCalledRule(out lst);
            if (lst != null && lst.Count > 0)
            {
                foreach (DB_Talk.Model.m_CalledRule model in lstCalledRule)
                {
                    DB_Talk.Model.m_CalledRule modelTemp = lst.Find(item => item.vc_CalledNumber == model.vc_CalledNumber);
                    if (modelTemp != null)
                    {
                        if (model.Equals(modelTemp))  //存在完全相同的被叫规则，则什么也不做
                        {
                        }
                        else  //被叫号码相同，但是其他属性不同
                        {
                            sbExit.Append("," + model.vc_CalledNumber.ToString());
                            break;
                        }
                    }
                   
                }

            }
        }

        private bool AddTel(DB_Talk.Model.m_Member Premodel, DB_Talk.Model.m_Member model, out string mes, bool isModifyDetail)
        {
            mes = "";
            bool IsExist = MBoxSDK.ConfigSDK.MBOX_IsSubscriberExist(Global.Params.BoxHandle, (model.i_Number.Value));
            if (IsExist)
            {
                mes = "号码已经存在";
                return false;
            }
            if (AddBase(model))  //添加新的
            {
                if (Premodel.i_Number != null && Premodel.i_Number>0)
                {
                    bool b = MBoxSDK.ConfigSDK.MBOX_DeleteSubscriber(Global.Params.BoxHandle, Premodel.i_Number.Value); //删除旧的
                }
            }
            else
            {
                mes = "号码在硬件中添加失败";
                return false;
            }
            if (isModifyDetail && !ModifyDetail(model))
            {
                MBoxSDK.ConfigSDK.MBOX_DeleteSubscriber(Global.Params.BoxHandle, model.i_Number.Value);
                mes = "设置调度功能失败";
                return false;
            }
            //if (!MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle))
            //{
            //    mes = "保存硬件配置失败";
            //    return false;
            //}
            return true;
        }

        private bool AddTel(DB_Talk.Model.m_Member Premodel, DB_Talk.Model.m_Member model, out string mes)
        {
            mes = "";
            bool IsExist = MBoxSDK.ConfigSDK.MBOX_IsSubscriberExist(Global.Params.BoxHandle, (model.i_Number.Value));
            if (IsExist)
            {
                //修改密码的情况
                if (model!=null && Premodel!=null && model.ID == Premodel.ID && Premodel.i_Number == model.i_Number
                                         && Premodel.i_NuPassword != model.i_NuPassword)
                {
                    bool b = MBoxSDK.ConfigSDK.MBOX_DeleteSubscriber(Global.Params.BoxHandle, Premodel.i_Number.Value); //删除旧的                   
                }
                else
                {
                   
                    mes = "号码已经存在";

                    //if (preModelDispatch != null && modelDispatch != null)
                    //{
                    //    preModelDispatch.i_IsDispatch = 0;
                    //    new DB_Talk.BLL.m_Member().Update(preModelDispatch);
                    //    new DB_Talk.BLL.m_Member().Update(modelDispatch);
                    //}
                    return false;
                }
            }
           
            if (AddBase(model))  //添加新的
            {
                //删除旧的，号码相同密码不同时必须先删除后添加
                if (Premodel!=null && Premodel.i_Number != null && Premodel.i_Number > 0)
                {
                    bool b = MBoxSDK.ConfigSDK.MBOX_DeleteSubscriber(Global.Params.BoxHandle, Premodel.i_Number.Value); //删除旧的
                }
                return true;
            }
            else
            {
                mes = "号码在硬件中添加失败";
                return false;
            }
          
        }

        public bool AddBase(DB_Talk.Model.m_Member model)
        {
            MBoxSDK.ConfigSDK.subscriberServiceBase subscriberBase = new MBoxSDK.ConfigSDK().newSubscriberServiceBase(); //new MBoxSDK.ConfigSDK.subscriberServiceBase();
            byte[] bytenumber = System.Text.ASCIIEncoding.ASCII.GetBytes(model.i_Number.ToString());
            subscriberBase.subType = model.NumberTypeID.Value;
            subscriberBase.userPriority = model.i_Authority.Value;
            bytenumber.CopyTo(subscriberBase.userNumber, 0);
            bytenumber.CopyTo(subscriberBase.authKey, 0);
            bytenumber.CopyTo(subscriberBase.sipPassword, 0);
            //调度员可选的增值服务只有调度业务、话务员代理、自动录音，并且在修改时才可以设置，创建时不可以设置
            subscriberBase.supplementSerive = (int)(MBoxSDK.ConfigSDK.SPM_MISS_CALL | MBoxSDK.ConfigSDK.SPM_MISS_CALL_ON_BUSY | MBoxSDK.ConfigSDK.SPM_SMS);
            bool create = MBoxSDK.ConfigSDK.MBOX_CreateSubscriber(Global.Params.BoxHandle, ref subscriberBase);
            return create;
        }

        private bool ModifyDetail(DB_Talk.Model.m_Member model)
        {
            if (model.i_Number == null || model.i_Number.Value == 0) return false;
            bool modify = false;
            MBoxSDK.ConfigSDK.subscriberServiceDetail subService = new MBoxSDK.ConfigSDK().newSubscriberServiceDetail();//new MBoxSDK.ConfigSDK.subscriberServiceDetail();
            bool b = MBoxSDK.ConfigSDK.MBOX_QuerySubscriber(Global.Params.BoxHandle, model.i_Number.Value, ref subService);
            if (b)
            {
                uint PreSupplementSerive = subService.supplementSerive;
                bool isModify = false;
                subService.supplementSerive = model.i_supplementSerive.Value;
                if (PreSupplementSerive != subService.supplementSerive | isModify)  //不同才修改
                    modify = MBoxSDK.ConfigSDK.MBOX_ModifySubscriber(Global.Params.BoxHandle, model.i_Number.Value, ref subService);
                else
                    modify = true;
            }
            return modify;
        }

        private bool SaveTel(out string mes)
        {
            try
            {
                this.dgvList.CurrentCell = null;
                StringBuilder sb = new StringBuilder();
                StringBuilder sbNo = new StringBuilder();
                for (int i = 0; i < DispatchCount; i++)
                {
                    if (lstMember[i].i_Number != NewlstMember[i].i_Number) //不同才添加新的号码，然后删除旧的号码
                    {
                        if (AddTel(lstMember[i], NewlstMember[i], out mes,true))
                            sb.Append("," + NewlstMember[i].vc_Name);
                        else
                            sbNo.Append(",调度号码【" + NewlstMember[i].i_Number + "】添加失败，原因：" + mes + "\r\n");
                    }
                }
                if (sb.Length > 0) sb.Remove(0, 1);
                if (sbNo.Length > 0) sbNo.Remove(0,1);
                mes = sbNo.ToString();
                if (sbNo.Length > 0)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                mes = ex.ToString();
                return false;
                //CommControl.MessageBoxEx.MessageBoxEx.Show("保存失败:" + ex.ToString(), "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //调度中心号码
        private bool SaveDispatchCenter()
        {
            if (NewBoxModel.i_DispatchNumber != PreBoxModel.i_DispatchNumber)
            {
                string centerNum = txtDispatchCenter.Text.Trim();// "1000";
                bool b = MBoxSDK.ConfigSDK.MBOX_SetDispatchCenter(Global.Params.BoxHandle, centerNum);
                return b;
            }
            else
                return true;   //相同无需设置
        }
        //紧急号码
        private bool SavetEmergencyNumber()
        {
            //if (NewBoxModel.i_EmergencyNumber != PreBoxModel.i_EmergencyNumber)
            //{
            //    string Num = TxtEmergencyNumber.Text.Trim();// "1001";
            //    bool b = true;// 暂时未做
            //    return b;
            //}
            //else
                //return true;  //相同无需设置
            return false;

        }

        private void hideTxt()
        {
            //textBox1.Visible = false;
            dgvList.CurrentCell = null;
        }

        private bool SaveToBox()
        {
           CommControl.Tools.WriteLog.AppendLog("保存box设置");
           return  MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);

        }

        private void SaveDB()
        {
            //添加调度号码
            new DB_Talk.BLL.m_Box().Update(NewBoxModel);
            foreach (DB_Talk.Model.m_Member item in NewlstMember)
            {
                item.i_TellType = CommControl.PublicEnums.EnumTelType.调度席话机.GetHashCode();
                if (item.ID >0)
                    BLL.Update(item);
                else
                    BLL.Add(item);
            }
            //添加视频调度号码
            if (preModelDispatch != null && modelDispatch != null)
            {
                modelDispatch.i_TellType = CommControl.PublicEnums.EnumTelType.调度席话机.GetHashCode();
                new DB_Talk.BLL.m_Member().Update(modelDispatch);
            }
            else if (modelDispatch != null)
            {
                if (!BLL.Exists("i_Flag=0 and BoxID='" +
                                        Global.Params.BoxID + "' and i_number='"+modelDispatch.i_Number+"'"))
                {
                    modelDispatch.i_TellType = CommControl.PublicEnums.EnumTelType.调度席话机.GetHashCode();
                    new DB_Talk.BLL.m_Member().Add(modelDispatch);
                } 
        
            }
           
            //foreach (DB_Talk.Model.m_CalledRule item in NewlstCalledRule)
            //{
            //    ////if (item.ID > 0)
            //    //    new DB_Talk.BLL.m_CalledRule().Update(item);
            //    ////else
            //        new DB_Talk.BLL.m_CalledRule().Add(item);
            //}
        }

        #endregion

        public frmDispatchNumber()
        {
            DevExpress.XtraEditors.Controls.Localizer.Active = new DevExpress.LocalizationCHS.DevExpressXtraEditorsLocalizationCHS();
         
            InitializeComponent();
            labMes.Text = "";
            this.Text = "基本配置";
            this.Load += new EventHandler(frmDispatchNumber_Load);
            hideTxt();
            dgvList.ReadOnly = false;
            foreach (DataGridViewColumn c in dgvList.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (c.Name == "colName" || c.Name == "colNumber")
                {
                    c.ReadOnly = false;
                }
                else
                    c.ReadOnly = true;
            }
            dgvList.CellEndEdit += new DataGridViewCellEventHandler(dgvList_CellEndEdit);
            
            dgvList.CellClick += new DataGridViewCellEventHandler(dgvList_CellClick);

            dgvList.Columns[1].CellTemplate.Style.SelectionBackColor = Color.White;

            dgvList.ShowCellToolTips=true;
            //this.dgvList.CellLeave += new DataGridViewCellEventHandler(dgvList_CellLeave);
            //this.dgvList.CurrentCellChanged += new EventHandler(dgvList_CurrentCellChanged);
            //this.textBox1.KeyDown += new KeyEventHandler(textBox1_KeyDown);

            this.labMes.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.txtDispatch.MouseEnter += new EventHandler(txtDispatch_MouseEnter);
            this.txtDispatch.MouseLeave += new EventHandler(txtDispatchCenter_MouseLeave);
            this.txtDispatchPassword.MouseEnter += new EventHandler(txtDispatchPassword_MouseEnter);
            this.txtDispatchPassword.MouseLeave += new EventHandler(txtDispatchCenter_MouseLeave);
            this.txtDispatch.TextChanged += new EventHandler(txtDispatch_TextChanged);

            if (!Global.Params.ConfigModel.SystemConfig.IsShowVideoDispatchNum)
            {
                SetVisible(false);
            }
        }

        void SetVisible(bool IsShow)
        {
            labVideo.Visible = IsShow;
            labVideoPwd.Visible = IsShow;
            txtDispatch.Visible = IsShow;
            txtDispatchPassword.Visible = IsShow;
        }

        void txtDispatch_TextChanged(object sender, EventArgs e)
        {
            //if (txtDispatchPassword.Text!="")
            {
                txtDispatchPassword.Text = txtDispatch.Text;
            }
        }

      

        void frmDispatchNumber_Load(object sender, EventArgs e)
        {
            Tools.MBoxOperate.UpdateDBCalinglSourceRule();

            LoadData();

            ShowModel();

           btnSave.Click+=new EventHandler(btnSave_Click);
           
        }

        void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectIndex = e.RowIndex; 
            }
        }

        void dgvList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewCell cell = dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (_selectIndex >= 0)
            {
                if (cell.Value != null && cell.Value.ToString().IndexOf("'") >= 0)
                {
                    cell.Value = cell.Value.ToString().Replace("'", "");
                    //dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "不能包含特殊字符'";
                    //MessageBox.Show("");
                    
                }
                //else
                //    dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";

                if (cell.Value != null && cell.Value.ToString().Length > 20)
                {
                    cell.Value = cell.Value.ToString().Substring(0, 20);
                    
                }
                if(cell.ColumnIndex==3)
                {
                    if (cell.Value != null )
                    {
                        int num = 0;
                        if (int.TryParse(cell.Value.ToString(), out num) && num > 0)
                        {
                            cell.Value = num;
                        }
                        else
                            cell.Value = "";
                        
                    }
                }
                for (int i = 0; i < DispatchCount; i++)
                {
                    if (i != e.RowIndex)
                    {
                        if (cell.Value != null && cell.Value.ToString() != "" 
                            && dgvList.Rows[i].Cells[e.ColumnIndex].Value!=null 
                            && dgvList.Rows[i].Cells[e.ColumnIndex].Value.ToString()!="" 
                            && cell.Value.ToString() == dgvList.Rows[i].Cells[e.ColumnIndex].Value.ToString())
                        {
                            cell.Value = "";
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (NewFormMain.LoadBox(Global.Params.BoxIP) == false)
            {

                return;
            }
            try
            {
               
                try
                {
                    GetModel();
                    NewlstCalledRule = getLstCalledRule();  //(TxtEmergencyNumber.Text.Trim, chkNumHead.EditValue.ToString().Trim());
                    if (Global.Params.ConfigModel.SystemConfig.IsShowVideoDispatchNum)
                    {
                        GetDispatchModel(ref modelDispatch, ref preModelDispatch);                        
                    }
                }
                
                catch (Exception ex)
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                string mes="";
                if (Global.Params.BoxHandle > 0)
                {
                    if (!SaveDispatchCenter())  //修改调度中心号码
                    {
                        mes = "调度中心号码设置失败！\r\n";
                    }

                    if (!Tools.MBoxOperate.SetBaseBox())
                    {
                        CommControl.Tools.WriteLog.AppendErrorLog("box基本配置失败");
                        mes += "设置基本配置失败！\r\n";
                    }

                    //添加紧急呼叫号码，被叫规则
                    string strCreate = "";
                    if (mes == "" && !new Tools.MBoxOperate().CreateCall_InRule(NewlstCalledRule, out strCreate))
                    {
                        CommControl.Tools.WriteLog.AppendErrorLog("添加被叫规则失败" + strCreate);
                        mes += "设置内部分机首位码失败！\r\n";
                    }
                    else  //如果引导码有改动，删除旧的呼叫规则
                    {
                        Tools.MBoxOperate.Delete_Rule(NewlstCalledRule,OldlstCalledRule);// delete_InRule();
                    }
                    string mesAddTel = "";
                    if (mes=="" && !SaveTel(out mesAddTel))
                    {
                        mes += mesAddTel;// "调度员设置失败！\r\n";
                    }
                    if (Global.Params.ConfigModel.SystemConfig.IsShowVideoDispatchNum && modelDispatch != null)
                    {
                        if (!AddTel(preModelDispatch, modelDispatch, out mes))
                            mes += "设置视频调度号码失败！\r\n";
                    }
                }
                else
                    mes = "未登录！";
               
                if (mes != "")
                    CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    SaveDB();
                    Global.Params.frmMain.ReStartBox(); //重启box
                    //SaveToBox();
                    CommControl.MessageBoxEx.MessageBoxEx.Show("基本配置设置成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadData();
               
             }
            catch (Exception ex)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("保存失败:" + ex.ToString(), "信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
               // 
            }
        }

        private void txtDispatchCenter_TextChanged(object sender, EventArgs e)
        {
             int num = 0;
             if (txtDispatchCenter.Text.Trim() != "" && int.TryParse(txtDispatchCenter.Text.Trim(), out num) && num > 0)
                 txtDispatchCenter.Text = num.ToString();
             else
                 txtDispatchCenter.Text = "";
                
        }

        private void TxtEmergencyNumber_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (TxtEmergencyNumber.Text.Trim() != "" && int.TryParse(TxtEmergencyNumber.Text.Trim(), out num) && num > 0)
                TxtEmergencyNumber.Text = num.ToString();
            else
                TxtEmergencyNumber.Text = "";
        }

        private void txtNumberLen_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            if (txtNumberLen.Text.Trim() != "" && int.TryParse(txtNumberLen.Text.Trim(), out num) && num > 0 && num <= Global.Params.BoxLimitNumberLen)
                txtNumberLen.Text = num.ToString();
            else
                txtNumberLen.Text = "";
        }
       
        private void dgvList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewCell cellObj = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                switch (dgv.Columns[e.ColumnIndex].Name)
                {
                    case "colName": 
                        cellObj.ToolTipText = "点击编辑名称！"; 
                        break;
                    case "colNumber":
                        cellObj.ToolTipText = "点击编辑号码！";
                        break;
                    default: break;
                }
                dgv = null;
                cellObj = null;
            }

        }

        private void chkNumHead_MouseEnter(object sender, EventArgs e)
        {
            if (chkNumHead.Properties.ReadOnly)
               labMes.Text = "已经添加了用户号码，不允许修改，若要修改，请先删除所有用户号码";
            else
                labMes.Text = "以【1-9】开头的内部用户号码";
        }
        private void chkNumHead_MouseLeave(object sender, EventArgs e)
        {
            labMes.Text = "";
        }
        private void txtNumberLen_MouseEnter(object sender, EventArgs e)
        {
             if(txtNumberLen.ReadOnly)
                 labMes.Text = "已经添加了用户号码，不允许修改，若要修改，请先删除所有用户号码";
             else 
                 labMes.Text = "内部用户号码长度限制";
    
        }

        private void txtNumberLen_MouseLeave(object sender, EventArgs e)
        {
            labMes.Text = "";
        }

        private void txtDispatchCenter_MouseEnter(object sender, EventArgs e)
        {
            labMes.Text = "调度中心号码，拨打此号码呼叫调度台";
        }

        private void txtDispatchCenter_MouseLeave(object sender, EventArgs e)
        {
            labMes.Text = "";
        }

        private void TxtEmergencyNumber_MouseEnter(object sender, EventArgs e)
        {
            labMes.Text = "紧急号码，拨打此号码紧急呼救";
        }

        private void TxtEmergencyNumber_MouseLeave(object sender, EventArgs e)
        {
            labMes.Text = "";
        }


       

        void txtDispatchPassword_MouseEnter(object sender, EventArgs e)
        {
            labMes.Text = "视频调度密码，默认与视频调度号码相同";

        }

       

        void txtDispatch_MouseEnter(object sender, EventArgs e)
        {
            labMes.Text = "视频调度号码，用于拨打视频电话";

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }
       
    }
}
