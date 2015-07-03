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
    public partial class frmCalledRuleList : UserControl
    {
        private string _tableName = "CalledRuleList";

        public frmCalledRuleList()
        {
            InitializeComponent();
            this.Text = "呼叫规则配置";
            this.Load += new EventHandler(frmCalledRuleList_Load);
        }

        void frmCalledRuleList_Load(object sender, EventArgs e)
        {
            Loaddata();
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmCalledRule fu = new frmCalledRule(null, 0);
            fu.ShowDialog();
            if (fu.DialogResult == DialogResult.OK)
            {
                Loaddata();
               
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow != null)
            {
                bool delete = false;
                Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
                try
                {
                    DB_Talk.Model.m_CalledRule model = dgvList.CurrentRow.Tag as DB_Talk.Model.m_CalledRule;
                    if (model != null)
                    {
                        CheckDeleteCondition(model);
                        List<DB_Talk.Model.m_Member> lstMember=new DB_Talk.BLL.m_Member().GetModelList(
                           string.Format(" i_Flag=0 and i_Number like '{0}%' and BoxID='{1}' ", model.vc_CalledNumber, Global.Params.BoxID));
                          // string.Format(" i_Flag=0 and i_Number like '{0}%' and BoxID='{1}' and i_IsDispatch!=1", model.vc_CalledNumber, Global.Params.BoxID));

                        if (lstMember.Count > 0)
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show("用户号码中引用了此呼叫规则，不允许删除,要想删除，请先删除用户号码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在删除被叫规则【" + model.vc_CalledNumber + "】,请稍等...");
                        List<DB_Talk.Model.m_CalledRule> lstAdd = new List<DB_Talk.Model.m_CalledRule>();
                        List<DB_Talk.Model.m_CalledRule> lstDelete = new List<DB_Talk.Model.m_CalledRule>();
                        lstDelete.Add(model);
                        DB_Talk.Model.m_SIPInterface modelSip = null;
                        DB_Talk.Model.m_PRIInterface modelPri = null;

                        if (model.i_SIPID > 0)
                            modelSip = new DB_Talk.BLL.m_SIPInterface().GetModel(
                                 string.Format(" i_Flag=0 and SIPID='{0}' and BoxID='{1}'", model.i_SIPID, Global.Params.BoxID));
                        if (modelSip != null)
                        {
                            List<DB_Talk.Model.m_CalledRule> lstm = new DB_Talk.BLL.m_CalledRule().GetModelList(
                               string.Format(" i_Flag=0 and i_SIPID='{0}' and BoxID='{1}' and ID!='{2}'",
                               model.i_SIPID, Global.Params.BoxID, model.ID));
                            if (lstm.Count > 0)  //只删除呼叫规则（还存在引用此中继的呼叫规则）
                            {
                                if (Tools.MBoxOperate.Delete_Rule(lstAdd, lstDelete))
                                {
                                    delete = true;
                                    if (model.i_CalledSubType == MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.市话.GetHashCode())
                                    {
                                        modelSip.vc_OutNumberLocal = modelSip.vc_OutNumberLocal.Replace(model.vc_CalledNumber, "").Replace(",,",",").Trim(','); ;
                                    }
                                    else if (model.i_CalledSubType == MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途.GetHashCode())
                                    {
                                        modelSip.vc_OutNumber = modelSip.vc_OutNumber.Replace(model.vc_CalledNumber, "").Replace(",,", ",").Trim(','); ;
                                    }
                                     new DB_Talk.BLL.m_SIPInterface().Update(modelSip);
                                }
                            }
                            else  //连中继一起删除
                            {
                                if (Tools.MBoxOperate.DeleteSIP(modelSip, lstAdd, lstDelete) && new DB_Talk.BLL.m_SIPInterface().Delete(modelSip.ID))
                                {
                                    delete = true;
                                }
                            }
                        }

                        if (model.i_PRIID > 0)
                            modelPri = new DB_Talk.BLL.m_PRIInterface().GetModel(
                                 string.Format(" i_Flag=0 and PRIID='{0}' and BoxID='{1}'", model.i_PRIID, Global.Params.BoxID));

                        if (modelPri != null)
                        {
                            List<DB_Talk.Model.m_CalledRule> lstm = new DB_Talk.BLL.m_CalledRule().GetModelList(
                                string.Format(" i_Flag=0 and i_PRIID='{0}' and BoxID='{1}' and ID!='{2}'",
                                model.i_PRIID, Global.Params.BoxID, model.ID));
                            if (lstm.Count > 0 && Tools.MBoxOperate.Delete_Rule(lstAdd, lstDelete))  //只删除呼叫规则
                            {
                                if (model.i_CalledSubType == MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.市话.GetHashCode())
                                {
                                    //modelPri.vc_OutNumberLocal = modelPri.vc_OutNumberLocal.Replace(model.vc_CalledNumber, "").Replace(",,", ",").Trim(',');
                                    modelPri.vc_OutNumberLocal = ReplaceString(modelPri.vc_OutNumberLocal, model.vc_CalledNumber);
                                }
                                else if (model.i_CalledSubType == MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途.GetHashCode())
                                {
                                   // modelPri.vc_OutNumber = modelPri.vc_OutNumber.Replace(model.vc_CalledNumber, "").Replace(",,", ",").Trim(',');
                                    modelPri.vc_OutNumber = ReplaceString(modelPri.vc_OutNumber, model.vc_CalledNumber);
                                }
                                 new DB_Talk.BLL.m_PRIInterface().Update(modelPri);
                                delete = true;
                            }
                            else  //连中继一起删除
                            {
                                if (Tools.MBoxOperate.DeletePRI(modelPri, lstAdd, lstDelete) && new DB_Talk.BLL.m_PRIInterface().Delete(modelPri.ID))
                                {
                                    delete = true;
                                }
                            }
                        }

                        if (modelSip == null && modelPri == null)  //删除的入局规则
                        {

                            if (Tools.MBoxOperate.Delete_Rule(lstAdd, lstDelete))
                            {
                                DB_Talk.Model.m_Box BoxModel = new DB_Talk.BLL.m_Box().GetModel(Global.Params.BoxID);
                                if (BoxModel != null && BoxModel.vc_NumberHead!=null)  
                                {

                                    BoxModel.vc_NumberHead = BoxModel.vc_NumberHead.Replace(lstDelete[0].vc_CalledNumber, "").Replace(",,", ",").Trim(',');
                                    
                                    new DB_Talk.BLL.m_Box().Update(BoxModel);
                                }
                                delete = true;
                            }
                        }
                    }
                    else  //还未添加 直接删除
                        delete = true;


                    if (delete)
                    {
                        MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);
                        procDlg.Hide();
                        Loaddata();
                        //dgvList.Rows.Remove(dgvList.CurrentRow);
                        CommControl.MessageBoxEx.MessageBoxEx.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        procDlg.Hide();
                        CommControl.MessageBoxEx.MessageBoxEx.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                catch (Exception ex)
                {
                    procDlg.Hide();
                    CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //CommControl.Tools.WriteLog.AppendErrorLog(ex);
                }
                finally
                {
                    procDlg.Dispose();
                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要删除的呼叫规则！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        /// <summary>
        /// 替换字符 
        /// </summary>
        /// <param name="strSrc"></param>
        /// <param name="strA"></param>
        /// <returns></returns>
        private string ReplaceString(string strSrc, string strA)
        {
            string[] arrS = strSrc.Split(',');
            List<string> lst = new List<string>();
            foreach (string item in arrS)
            {
                if (item != strA)
                {
                    lst.Add(item + ",");
                }
            }
            if (lst.Count > 0)
            {
                lst[lst.Count - 1] = lst[lst.Count - 1].Replace(",", "");
            }
            string strR = "";
            foreach (string item in lst)
            {
                strR = strR + item;
            }
            return strR;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void btnStyle_Click(object sender, EventArgs e)
        {
            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableName, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvList);
        }


        private void Loaddata()
        {
            List<DB_Talk.Model.m_CalledRule> lst = new List<DB_Talk.Model.m_CalledRule>();
            string strWhere = string.Format("i_Flag=0 and BoxID='{0}' and i_CalledType!='{1}' order by vc_CalledNumber ", 
                Global.Params.BoxID,MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.SERVICE.GetHashCode());
            lst = new DB_Talk.BLL.m_CalledRule().GetModelList(strWhere);
            dgvList.Rows.Clear();

            for (int i = 0; i < lst.Count; i++)
            {
                string CalledType = ((MBoxSDK.ConfigSDK.CALLED_RULE_TYPE)lst[i].i_CalledType).ToString();
                string CalledSubType = ((MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE)lst[i].i_CalledSubType).ToString();

                dgvList.Rows[dgvList.Rows.Add(lst[i].ID,
                                 lst[i].vc_CalledNumber,
                                 CalledType,
                                 CalledSubType,
                                 lst[i].i_SIPID == 0 ? "" : lst[i].i_SIPID.ToString(),
                                 lst[i].i_PRIID == 0 ? "" : lst[i].i_PRIID.ToString(),
                                 lst[i].i_CalledChangeLength
                                )].Tag = lst[i];

            }
            dgvList.ClearSelection();
            kryptonHeaderGroup1.ValuesSecondary.Heading = "  共" + dgvList.Rows.Count.ToString() + "条记录";

        }


        private void CheckDeleteCondition(DB_Talk.Model.m_CalledRule mcall)
        {
            int SipPriID=0;
            string strC="";
            string mes = "";
            if (mcall.i_SIPID > 0)
            {
                strC = "i_SIPID";
                SipPriID = mcall.i_SIPID;
                mes = "SIP";
            }
            else if (mcall.i_PRIID > 0)
            {
                strC = "i_PRIID";
                SipPriID = mcall.i_PRIID;
                mes = "PRI";
            }
            else
                return;
            string subType="";
            if (mcall.i_CalledSubType == MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.市话.GetHashCode())
            {
                subType = "市话出局号码前缀";
            }
            else if (mcall.i_CalledSubType == MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途.GetHashCode())
            {
                subType = "长途出局号码前缀";
            }
            else return;

            List<DB_Talk.Model.m_CalledRule> lst = new List<DB_Talk.Model.m_CalledRule>();
            string strWhere = string.Format("i_Flag=0 and BoxID='{0}' and i_CalledType ='{1}' and i_CalledSubType='{2}' and {3}='{4}'",
                Global.Params.BoxID, MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.出局.GetHashCode(), mcall.i_CalledSubType, strC, SipPriID);
            lst = new DB_Talk.BLL.m_CalledRule().GetModelList(strWhere);
            if (lst.Count <= 1)
                throw new Exception(mes + "中继中" + subType + "只剩下【" + mcall.vc_CalledNumber + "】，不能删除!\r\n如果需要删除，请删除" + mes + "中继【" + SipPriID + "】!");
           

        }

        private void btnDesigner_Click(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

        }
    }
}
