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
    public partial class frmSIPPRI : UserControl
    {
        int E1Max = 2;

        public frmSIPPRI()
        {
            InitializeComponent();
            this.Text = "出局通话配置";

            this.Load += new EventHandler(frmSIPPRI_Load);
            this.dgvPRI.CellEndEdit += new DataGridViewCellEventHandler(dgvPRI_CellEndEdit);
            this.dgvSIP.CellEndEdit += new DataGridViewCellEventHandler(dgvSIP_CellEndEdit);
           

        }

        int Sipcount = 0;
        int Pricount = 0;
        bool IsLoad = false;
        void frmSIPPRI_Load(object sender, EventArgs e)
        {
            this.dgvPRI.Columns["colPriState"].CellTemplate.Style.SelectionBackColor = Color.White;
            this.dgvPRI.Columns["colPriOperateState"].CellTemplate.Style.SelectionBackColor = Color.White;

            this.dgvSIP.Columns["colSipState"].CellTemplate.Style.SelectionBackColor = Color.White;
            this.dgvSIP.Columns["colSipOperateState"].CellTemplate.Style.SelectionBackColor = Color.White;

            IsLoad = true;
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("value", typeof(string));

            //if (Global.Params.BoxType == MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000B) E1Max = 8;
            //
            switch (Global.Params.BoxType)
            {
                case MBoxSDK.ConfigSDK.EnumDeviceType.none:
                    break;
                case MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000B:
                    E1Max = 8;
                    break;
                case MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000C:
                    E1Max = 2;
                    break;
                case MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000D:
                    E1Max = 2;
                    break;
                case MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000E:
                    E1Max = 2;
                    break;
                case MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000_3G:
                    E1Max = 8;
                    break;
                default:
                    break;
            }
            for (int i = 1; i <= E1Max; i++)
            {
                dt.Rows.Add(i, "E1-" + i);
            }
            this.colE1Number.DataSource = dt;
            this.colE1Number.DisplayMember = "value";
            this.colE1Number.ValueMember = "ID";
            //this.colE1Number.AutoComplete = false;// System.Windows.Forms.AutoCompleteMode.SuggestAppend;

            //this.colE1Number.Items.AddRange(new object[] {
            //"用户侧",
            //"网络侧"});

            Tools.MBoxOperate.UpdateDBSIPPRI();
            dgvSIP.ReadOnly = false;
            dgvPRI.ReadOnly = false;
            for (int i = 7; i <= 9; i++)
            {
                dgvSIP.Columns[i].ReadOnly = true;
            }
            
            for (int i = 8; i <= 9; i++)
            {
                dgvPRI.Columns[i].ReadOnly = true;
            }
            //dgvSIP.Columns[7].ReadOnly = false;5

            Loaddata(0);

            Global.Params.frmMain.getStateSipPri.InterfaceStateChange += new Tools.GetStateSipPri.StateChange(getStateSipPri_InterfaceStateChange);

            Global.Params.StyleManager.SetGridStyle(_tableNameSip, this.dgvSIP);
            Global.Params.StyleManager.SetGridStyle(_tableNamePri, this.dgvPRI);
        }

        #region 公共方法

        private void Loaddata(int dgvNum) //0全部加载，1只刷新SIP，2只刷新PRI
        {
            if (dgvNum == 0 || dgvNum == 1)  
            {
                List<DB_Talk.Model.m_SIPInterface> lstSip = new List<DB_Talk.Model.m_SIPInterface>();
                string strWhere = string.Format("i_Flag=0 and BoxID='{0}' order by SIPID", Global.Params.BoxID);
                lstSip = new DB_Talk.BLL.m_SIPInterface().GetModelList(strWhere);
                dgvSIP.Rows.Clear();
                Global.Params.frmMain.getStateSipPri.lstPreSip = lstSip;
                //获取sip状态
                //GetSipState(ref lstSip);
                for (int i = 0; i < lstSip.Count; i++)
                {
                    dgvSIP.Rows[dgvSIP.Rows.Add(lstSip[i].ID,
                                     lstSip[i].SIPID,
                                     lstSip[i].vc_OutNumberLocal,
                                     lstSip[i].vc_OutNumber,
                                     lstSip[i].i_Port,
                                     lstSip[i].vc_OppositeIP,
                                     lstSip[i].i_OppositePort,
                                     lstSip[i].i_PlaySound == 1 ? "是" : "否",  // //是否放音,是(1),否(2),默认1
                                     lstSip[i].i_State == 2 ? "激活" : "未激活",        //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
                                     lstSip[i].i_OperateState == 2 ? "运行" : "停止"  //up(2) down(1)
                                    )].Tag = lstSip[i];
                    dgvSIP.Rows[i].ReadOnly = true;

                }
                dgvSIP.ClearSelection();

            }
            if (dgvNum == 0 || dgvNum == 2)
            {
                List<DB_Talk.Model.m_PRIInterface> lstPri = new List<DB_Talk.Model.m_PRIInterface>();
                string strWherePri = string.Format("i_Flag=0 and BoxID='{0}' order by PRIID", Global.Params.BoxID);
                lstPri = new DB_Talk.BLL.m_PRIInterface().GetModelList(strWherePri);
                dgvPRI.Rows.Clear();
                Global.Params.frmMain.getStateSipPri.lstPrePri = lstPri;
                //获取pri状态
                //GetPriState(ref lstPri);
                for (int i = 0; i < lstPri.Count; i++)
                {

                    dgvPRI.Rows[dgvPRI.Rows.Add(lstPri[i].ID,
                                     lstPri[i].PRIID,
                                     lstPri[i].vc_OutNumberLocal,
                                     lstPri[i].vc_OutNumber,
                                     lstPri[i].i_E1Port,
                                     lstPri[i].i_LinkID,
                                     lstPri[i].i_SwitchType == 9 ? "Hitotek" : "其他",    //交换机类型1: unknown(1) 2: avaya(2)3: nortel(3)4: alcatel(4) 5: siemens(5) 6: oulian(6)7: shenou(7) 8: utstarcom(8) 9: microxel(9)
                                     lstPri[i].i_UNIType == 1 ? "用户侧" : "网络侧",  // 信令信道UNI类型 //用户侧：1，网络侧：2，默认1
                                     lstPri[i].i_State == 2 ? "激活" : "未激活",        //unconfigured(0) 2: deactive(1) 3: active(2) 4: deactivePending(3)
                                     lstPri[i].i_Operate == 2 ? "运行" : "停止"    //up(2)运行 down(1)停止
                                    )].Tag = lstPri[i];
                   
                    dgvPRI.Rows[i].ReadOnly = true;
                }
                dgvPRI.ClearSelection();
            }
        }

        //获取sip中继状态
        private void GetSipState(ref  List<DB_Talk.Model.m_SIPInterface> lstDbSip)
        {
            List<DB_Talk.Model.m_SIPInterface> lstSip = new List<DB_Talk.Model.m_SIPInterface>();
            Tools.MBoxOperate.GetSipTrunk(out lstSip);
            foreach (DB_Talk.Model.m_SIPInterface m in lstSip)
            {
                int index = lstDbSip.FindIndex(item => item.SIPID == m.SIPID);
                if (index >= 0)
                {
                    lstDbSip[index].i_State = m.i_State;
                    lstDbSip[index].i_OperateState = m.i_OperateState;
                }
            }
        }

        //获取Pri中继状态
        private void GetPriState(ref  List<DB_Talk.Model.m_PRIInterface> lstDbPri)
        {
            List<DB_Talk.Model.m_PRIInterface> lstSip = new List<DB_Talk.Model.m_PRIInterface>();
            Tools.MBoxOperate.GetPriTrunk(out lstSip);
            foreach (DB_Talk.Model.m_PRIInterface m in lstSip)
            {
                int index = lstDbPri.FindIndex(item => item.PRIID == m.PRIID);
                if (index >= 0)
                {
                    lstDbPri[index].i_State = m.i_State;
                    lstDbPri[index].i_Operate = m.i_Operate;
                }
            }
        }

        //获取SIP中继
        private Dictionary<DB_Talk.Model.m_SIPInterface, DB_Talk.Model.m_SIPInterface> GetLstSIPInterface()
        {
         
            List<DB_Talk.Model.m_SIPInterface> lst = new List<DB_Talk.Model.m_SIPInterface>();

            Dictionary<DB_Talk.Model.m_SIPInterface, DB_Talk.Model.m_SIPInterface> dic = new Dictionary<DB_Talk.Model.m_SIPInterface, DB_Talk.Model.m_SIPInterface>();

            for (int i = 0; i < this.dgvSIP.Rows.Count; i++)
            {
                DB_Talk.Model.m_SIPInterface model = new DB_Talk.Model.m_SIPInterface();
                DB_Talk.Model.m_SIPInterface modelTag = dgvSIP.Rows[i].Tag as DB_Talk.Model.m_SIPInterface;
                if (modelTag != null)
                    model.ID = modelTag.ID;
                //SIP中继索引
                if (dgvSIP.Rows[i].Cells["colSIPID"].Value == null || dgvSIP.Rows[i].Cells["colSIPID"].Value.ToString() == "")
                    throw new Exception("SIP编号不能为空！");
                int num = 0;
                if (dgvSIP.Rows[i].Cells["colSIPID"].Value != null && int.TryParse(dgvSIP.Rows[i].Cells["colSIPID"].Value.ToString(), out num) && num > 0 && num <= 10)
                    model.SIPID = num;
                else
                    throw new Exception("SIP中继编号取值范围为1～10");  //实际是1-32，但是SAP索引是1-10

                List<DB_Talk.Model.m_SIPInterface> lstTemp = new DB_Talk.BLL.m_SIPInterface().GetModelList(
                    string.Format("i_Flag=0 and BoxID={0} and SIPID={1} ", Global.Params.BoxID, model.SIPID));
                if (lstTemp.Count > 0 && model.ID != lstTemp[0].ID)
                    throw new Exception("SIP中继编号【" + model.SIPID + "】已经存在");

                #region 市话长途判断
                bool sh=!(dgvSIP.Rows[i].Cells["colSIPOutSub"].Value == null || dgvSIP.Rows[i].Cells["colSIPOutSub"].Value.ToString() == "");
                bool ct = !(dgvSIP.Rows[i].Cells["colSIPOut"].Value == null || dgvSIP.Rows[i].Cells["colSIPOut"].Value.ToString() == "");

                if (sh == false && ct == false)
                {
                    throw new Exception("市话出局号码前缀和长途出局号码前缀必须要填写一个！");
                }
                if(sh==true )
                {
                    //市话出局引导码
                    //if (sh == false && ct == true)
                    //    throw new Exception("市话出局号码前缀不能为空！");
                    string strOutLocal = dgvSIP.Rows[i].Cells["colSIPOutSub"].Value.ToString();
                    string[] strArrayLocal = strOutLocal.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string str in strArrayLocal)
                    {
                        num = 0;
                        if (!int.TryParse(str, out num))
                            throw new Exception("市话出局号码前缀格式错误！必须是以英文逗号隔开的数字！");
                    }
                    model.vc_OutNumberLocal = strOutLocal;
                }
                if (ct == true)
                {
                    //长途出局引导码
                    //if (dgvSIP.Rows[i].Cells["colSIPOut"].Value == null || dgvSIP.Rows[i].Cells["colSIPOut"].Value.ToString() == "")
                    //    throw new Exception("长途出局号码前缀不能为空！");
                    string strOut = dgvSIP.Rows[i].Cells["colSIPOut"].Value.ToString();
                    string[] strArray = strOut.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string str in strArray)
                    {
                        num = 0;
                        if (!int.TryParse(str, out num))
                            throw new Exception("长途出局号码前缀格式错误！必须是以英文逗号隔开的数字！");
                    }
                    model.vc_OutNumber = strOut;
                }
           

                #endregion

                
                string mes="";
                if (model.vc_OutNumberLocal != null && model.vc_OutNumber != null)
                {
                    if (Global.Methods.checkNumOutIsSame(model.vc_OutNumberLocal, model.vc_OutNumber, out mes))
                    {
                        throw new Exception("市话与长途出局号码前缀有重复号码【" + mes + "】！");
                    }
                }
                model.i_Type = 2;         //接口类型,内部(1),外部(2)，默认外部
                //model.RouteID = num;      //1～255
                model.i_Level = 1;        //优先级,主(1),从(2)，默认主
                model.SAPID = model.SIPID + 1;    //SAP索引取值范围1-10
                model.i_MaxChannel = 128; //最大通道(1~128)
                
                //本端端口号
                if (dgvSIP.Rows[i].Cells["colSIPPort"].Value == null || dgvSIP.Rows[i].Cells["colSIPPort"].Value.ToString() == "")
                    throw new Exception("本机端口号不能为空！");
                num = 0;
                if (dgvSIP.Rows[i].Cells["colSIPPort"].Value != null && int.TryParse(dgvSIP.Rows[i].Cells["colSIPPort"].Value.ToString(), out num) && num >= 1025 && num <= 9999 && num!=5060)
                    model.i_Port = num;  // 5062;
                else
                    throw new Exception("本端端口号取值范围为1025～9999，并且不能为5060");
               
                //对端IP
                if (dgvSIP.Rows[i].Cells["colSIPIP"].Value == null || dgvSIP.Rows[i].Cells["colSIPIP"].Value.ToString() == "")
                    throw new Exception("对端IP不能为空！");
                model.vc_OppositeIP = dgvSIP.Rows[i].Cells["colSIPIP"].Value.ToString(); // "192.168.1.239";
                if (!Global.Methods.checkIP(model.vc_OppositeIP))
                    throw new Exception("对端IP地址不合法！");

                List<DB_Talk.Model.m_SIPInterface> lstIP = new DB_Talk.BLL.m_SIPInterface().GetModelList(
                  string.Format("i_Flag=0 and BoxID={0} and vc_OppositeIP='{1}' ", Global.Params.BoxID, model.vc_OppositeIP));
                if (lstIP.Count > 0 && model.vc_OppositeIP != lstIP[0].vc_OppositeIP)
                    throw new Exception("对端IP【" + model.vc_OppositeIP + "】已经存在");
                //对端端口号
                if (dgvSIP.Rows[i].Cells["colSIPPort2"].Value == null || dgvSIP.Rows[i].Cells["colSIPPort2"].Value.ToString() == "")
                    throw new Exception("对端端口号不能为空！");
                num = 0;
                if (dgvSIP.Rows[i].Cells["colSIPPort2"].Value != null && int.TryParse(dgvSIP.Rows[i].Cells["colSIPPort2"].Value.ToString(), out num) && num >= 1025 && num <= 9999 )
                    model.i_OppositePort = num;
                else
                    throw new Exception("对端端口号本端端口号取值范围为1025～9999");
                
                //是否放音
                if (dgvSIP.Rows[i].Cells["colSIPIsPlay"].Value.ToString() == "")
                    throw new Exception("未选择是否放音");
                model.i_PlaySound = dgvSIP.Rows[i].Cells["colSIPIsPlay"].Value.ToString() == "是" ? 1 : 2; // 1;  //是否放音,是(1),否(2),默认1
               
                model.i_State = 2;  //激活
                model.i_OperateState = 1; //up(2)运行 down(1)停止

                model.BoxID = Global.Params.BoxID;

                if (modelTag != null &&
                    modelTag.SIPID == model.SIPID &&
                    modelTag.SAPID == model.SAPID &&
                    modelTag.BoxID == model.BoxID &&
                    modelTag.i_Port == model.i_Port &&
                    modelTag.vc_OutNumber == model.vc_OutNumber &&
                    modelTag.vc_OutNumberLocal == model.vc_OutNumberLocal &&
                    //modelTag.RouteID == model.RouteID &&
                    modelTag.vc_OppositeIP == model.vc_OppositeIP &&
                    modelTag.i_PlaySound == model.i_PlaySound &&
                    modelTag.i_OppositePort == model.i_OppositePort)
                {
                    modelTag = null;  //没有变化，则什么都不做
                    continue;
                }
                else
                    model.vc_Memo = "修改";
                lst.Add(model);


                dic.Add(model, modelTag);
            }
            return dic;
        }

        //获取PRI中继
        private Dictionary<DB_Talk.Model.m_PRIInterface, DB_Talk.Model.m_PRIInterface> GetLstPRIInterface()
        {
            Dictionary<DB_Talk.Model.m_PRIInterface, DB_Talk.Model.m_PRIInterface> dic = new Dictionary<DB_Talk.Model.m_PRIInterface, DB_Talk.Model.m_PRIInterface>();
            List<DB_Talk.Model.m_PRIInterface> lst = new List<DB_Talk.Model.m_PRIInterface>();
            for (int i = 0; i < this.dgvPRI.Rows.Count; i++)
            {
                DB_Talk.Model.m_PRIInterface model = new DB_Talk.Model.m_PRIInterface();
                DB_Talk.Model.m_PRIInterface modelTag = dgvPRI.Rows[i].Tag as DB_Talk.Model.m_PRIInterface;
                if (modelTag != null)
                    model.ID = modelTag.ID;
                //PRI索引
                if (dgvPRI.Rows[i].Cells["colPRIID"].Value == null || dgvPRI.Rows[i].Cells["colPRIID"].Value.ToString() == "")
                    throw new Exception("PRI编号不能为空！");
                int num = 0;
                if (dgvPRI.Rows[i].Cells["colPRIID"].Value != null && int.TryParse(dgvPRI.Rows[i].Cells["colPRIID"].Value.ToString(), out num) && num > 0 && num <= 32)
                    model.PRIID = num;
                else
                    throw new Exception("PRI中继编号取值范围为1～32");  //实际是1-32
                List<DB_Talk.Model.m_PRIInterface> lstTemp = new DB_Talk.BLL.m_PRIInterface().GetModelList(
                   string.Format("i_Flag=0 and BoxID={0} and PRIID={1} ", Global.Params.BoxID, model.PRIID));
                if (lstTemp.Count > 0 && model.ID != lstTemp[0].ID)
                    throw new Exception("PRI中继编号【" + model.PRIID + "】已经存在");

                #region 市话长途判断


                bool sh = !(dgvPRI.Rows[i].Cells["colPriOutSub"].Value == null || dgvPRI.Rows[i].Cells["colPriOutSub"].Value.ToString() == "");
                bool ct = !(dgvPRI.Rows[i].Cells["colPriOut"].Value == null || dgvPRI.Rows[i].Cells["colPriOut"].Value.ToString() == "");

                if (sh == false && ct == false)
                {
                    throw new Exception("市话出局号码前缀和长途出局号码前缀必须要填写一个！");
                }
                if (sh == true)
                {
                    ////市话出局引导码
                    //if (dgvPRI.Rows[i].Cells["colPriOutSub"].Value == null || dgvPRI.Rows[i].Cells["colPriOutSub"].Value.ToString() == "")
                    //    throw new Exception("市话出局号码前缀不能为空！");
                    string strOutLocal = dgvPRI.Rows[i].Cells["colPriOutSub"].Value.ToString();
                    string[] strArrayLocal = strOutLocal.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string str in strArrayLocal)
                    {
                        num = 0;
                        if (!int.TryParse(str, out num))
                            throw new Exception("市话出局号码前缀格式错误！必须是以英文逗号隔开的数字！");
                    }
                    model.vc_OutNumberLocal = strOutLocal;
                }
                if ( ct == true)
                {
                    ////长途出局引导码
                    //if (dgvPRI.Rows[i].Cells["colPriOut"].Value == null || dgvPRI.Rows[i].Cells["colPriOut"].Value.ToString() == "")
                    //    throw new Exception("长途出局号码前缀不能为空！");
                    string strOut = dgvPRI.Rows[i].Cells["colPriOut"].Value.ToString();
                    string[] strArray = strOut.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string str in strArray)
                    {
                        num = 0;
                        if (!int.TryParse(str, out num))
                            throw new Exception("长途出局号码前缀格式错误！必须是以英文逗号隔开的数字！");
                    }
                    model.vc_OutNumber = strOut;
                }
                #endregion

                string mes = "";
                if (model.vc_OutNumberLocal != null && model.vc_OutNumber != null)
                {
                    if (Global.Methods.checkNumOutIsSame(model.vc_OutNumberLocal, model.vc_OutNumber, out mes))
                    {
                        throw new Exception("市话与长途出局号码前缀有重复号码【" + mes + "】！");
                    }
                }

                //E1端口号
                if (dgvPRI.Rows[i].Cells["colE1Number"].Value == null || dgvPRI.Rows[i].Cells["colE1Number"].Value.ToString() == "")
                    throw new Exception("E1端口号不能为空！");
                num = 0;
                if (dgvPRI.Rows[i].Cells["colE1Number"].Value != null && int.TryParse(dgvPRI.Rows[i].Cells["colE1Number"].Value.ToString(), out num) && num >= 1 && num <= E1Max)
                    model.i_E1Port = num;  
                else
                    throw new Exception("E1端口号取值范围为1～" + E1Max);
                List<DB_Talk.Model.m_PRIInterface> lstTempE1 = new DB_Talk.BLL.m_PRIInterface().GetModelList(
                  string.Format("i_Flag=0 and BoxID={0} and i_E1Port={1} ", Global.Params.BoxID, model.i_E1Port));
                if (lstTempE1.Count > 0 && model.ID != lstTempE1[0].ID)
                    throw new Exception("E1端口号【" + model.i_E1Port + "】已经存在");
                //LinkID
                if (dgvPRI.Rows[i].Cells["colPriLinkID"].Value == null || dgvPRI.Rows[i].Cells["colPriLinkID"].Value.ToString() == "")
                    throw new Exception("LinkID不能为空！");
                num = 0;
                if (dgvPRI.Rows[i].Cells["colPriLinkID"].Value != null && int.TryParse(dgvPRI.Rows[i].Cells["colPriLinkID"].Value.ToString(), out num) && num >= 1 && num <= 16)
                    model.i_LinkID = num;  
                else
                    throw new Exception("LinkID取值范围为1～16");
                
                //交换机类型1: unknown(1) 2: avaya(2)3: nortel(3)4: alcatel(4) 5: siemens(5) 6: oulian(6)7: shenou(7) 8: utstarcom(8) 9: microxel(9)
                if (dgvPRI.Rows[i].Cells["colSwitchType"].Value.ToString() == "")
                    throw new Exception("交换机类型不能为空");
                model.i_SwitchType = dgvPRI.Rows[i].Cells["colSwitchType"].Value.ToString() == "Hitotek" ? 9 : 1;
                //用户侧：1，网络侧：2，默认1
                if (dgvPRI.Rows[i].Cells["colUNIType"].Value.ToString() == "")
                    throw new Exception("信令信道UNI类型不能为空");
                model.i_UNIType = dgvPRI.Rows[i].Cells["colUNIType"].Value.ToString() == "用户侧" ? 1 : 2; 
                model.i_Type = 2;         //接口类型,内部(1),外部(2)，默认外部
                model.i_Level = 1;        //优先级,主(1),从(2)，默认主
                model.i_LinkType = 1;     //链路类型 E1(1),T1(2)
                model.i_State = 2;  //激活
                model.i_Operate = 1; //up(2)运行 down(1)停止
                model.BoxID = Global.Params.BoxID;

                if (modelTag != null &&
                    modelTag.PRIID == model.PRIID &&
                    modelTag.vc_OutNumber == model.vc_OutNumber &&
                    modelTag.BoxID == model.BoxID &&
                    modelTag.i_E1Port == model.i_E1Port &&
                    modelTag.i_LinkID == model.i_LinkID &&
                    modelTag.i_SwitchType == model.i_SwitchType &&
                    modelTag.i_UNIType == model.i_UNIType)
                {
                    modelTag = null;  //没有变化，则什么都不做
                    continue;
                }
                lst.Add(model);
                dic.Add(model, modelTag);
            }
            return dic;
        }

        //获取呼叫规则
        private void GetCalledRule(int SIPID,int PRIID, string strNewOutNumber, string strOldOutNumber, 
            ref  List<DB_Talk.Model.m_CalledRule> lstAdd, ref  List<DB_Talk.Model.m_CalledRule> lstDelete,MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE CalledSubType)
        {
            //出局号码被叫规则
            string mes = "";
            string[] strArrayAdd = strNewOutNumber.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
             //lstAdd = new List<DB_Talk.Model.m_CalledRule>();
            //lstDelete = new List<DB_Talk.Model.m_CalledRule>();
            foreach (string str in strArrayAdd)  //出局规则
            {
                strOldOutNumber=strOldOutNumber.Replace(str, "");  //从旧的引导码中除去新的引导码
                DB_Talk.Model.m_CalledRule m = new DB_Talk.Model.m_CalledRule();
                m.CalledID = 1;
                m.CallingOriID = 1;
                m.vc_CalledNumber = (str);
                int num = 0;
                if (!int.TryParse(str, out num) || num<0 || num > 99999)
                {
                    throw new Exception("号码前缀必须是0～99999之间的数字");
                }
                m.i_CalledType = MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.出局.GetHashCode();  //service
                m.i_CalledSubType = CalledSubType.GetHashCode();// MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途.GetHashCode();
                m.DestRouteID = 0;
                m.i_CalledChangeType = MBoxSDK.ConfigSDK.CALLED_RULE_TransAct.DELETE.GetHashCode();
                m.i_CalledChangePosition = 0;
                m.i_CalledChangeLength = str.Length;
                m.vc_CalledChangeTarget = "";
                m.i_SIPID = SIPID;
                m.i_PRIID = PRIID;
                m.BoxID = Global.Params.BoxID;
                //if (!new Tools.MBoxOperate().IsExitCalledRule(m)) lst.Add(m);
                //if (new Tools.MBoxOperate().IsExitCalledRule(m, out mes) && mes != "")
                //{
                //    throw (new Exception("已经存在被叫号码为【" + mes + "】的呼叫规则！"));
                //}
                List<DB_Talk.Model.m_CalledRule> lstTemp = new DB_Talk.BLL.m_CalledRule().GetModelList(
                            string.Format(" i_Flag=0 and vc_CalledNumber='{0}' and BoxID='{1}'", 
                            m.vc_CalledNumber, Global.Params.BoxID));
                if (lstTemp.Count > 0)
                { 
                    if(m.Equals(lstTemp[0]))  //完全相同
                    {

                    }
                    else if (m.vc_CalledNumber == lstTemp[0].vc_CalledNumber)  //引导码相同
                    {
                        throw (new Exception("已经存在被叫号码为【" + m.vc_CalledNumber + "】的呼叫规则！"));
                    }
                } 
                else
                    lstAdd.Add(m);
            }

            string[] strArrayDelete = strOldOutNumber.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strArrayDelete)  //出局规则
            {
                DB_Talk.Model.m_CalledRule m = new DB_Talk.Model.m_CalledRule();
                m.CalledID = 1;
                m.CallingOriID = 1;
                m.vc_CalledNumber = (str);
                m.i_CalledType = MBoxSDK.ConfigSDK.CALLED_RULE_TYPE.出局.GetHashCode();  //service
                m.i_CalledSubType = CalledSubType.GetHashCode();// MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途.GetHashCode();
                m.DestRouteID = 0;
                m.i_CalledChangeType = MBoxSDK.ConfigSDK.CALLED_RULE_TransAct.DELETE.GetHashCode();
                m.i_CalledChangePosition = 0;
                m.i_CalledChangeLength = str.Length;
                m.vc_CalledChangeTarget = "";
                m.BoxID = Global.Params.BoxID;

                lstDelete.Add(m);
            }

        }

        #endregion

        //添加SIP
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvSIP.Rows)
            {
                if (item.Tag == null)
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("请先保存然后再增加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            //int sipID = 0;
            //DB_Talk.Model.m_SIPInterface model = new DB_Talk.BLL.m_SIPInterface().GetModel(
            //  string.Format(" i_Flag=0 and  BoxID='{0}' order by SIPID desc", Global.Params.BoxID));
            //if (model != null)
            //{j140
            //    sipID = model.SIPID;
            //}
            //else
            //    sipID = Sipcount+1;

            Sipcount = dgvSIP.Rows.Count;

            if (Sipcount + 1 > 5)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("最多只能添加【5】个SIP中继！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

          int index=  this.dgvSIP.Rows.Add("", Sipcount+1, "","", 5060 + Sipcount+1, "", 5060 + Sipcount+1, "是", "无效值", "无效值");
         // this.dgvSIP.Rows[index].Tag = 0;

            //本机端口号、对端IP、对端端口号 不能重复
            for (int j = 1; j <= 5; j++) //1,3,4,5
            {
                if (j == 2) continue;
                for (int i = 0; i < dgvSIP.Rows.Count - 1; i++)
                {
                    DataGridViewCell cell = dgvSIP.Rows[i].Cells[j];
                    DataGridViewCell cell2 = dgvSIP.Rows[i + 1].Cells[j];
                    if (cell.Value != null && cell.Value.ToString() != "" &&
                        cell2.Value != null && cell2.Value.ToString() != ""
                        && cell.Value.ToString() == cell2.Value.ToString())
                    {
                        cell2.Value = null;
                    }
                }
            }

        
        }
        //删除SIP
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSIP.CurrentRow != null)
            {
                bool delete = false;
                if (!NewFormMain.LoadBox(Global.Params.BoxIP))
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("登录站点【"+Global.Params.BoxIP+"】失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                  Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
                  try
                  {
                      DB_Talk.Model.m_SIPInterface model = dgvSIP.CurrentRow.Tag as DB_Talk.Model.m_SIPInterface;
                      if (model != null)
                      {
                          procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在删除SIP中继【" + model.SIPID + "】,请稍等...");
                  
                          List<DB_Talk.Model.m_CalledRule> lstAdd = new List<DB_Talk.Model.m_CalledRule>();
                          List<DB_Talk.Model.m_CalledRule> lstDelete = new List<DB_Talk.Model.m_CalledRule>();

                          GetCalledRule(model.SIPID, 0, "", model.vc_OutNumberLocal == null ? "" : model.vc_OutNumberLocal,
                                               ref lstAdd, ref lstDelete, MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.市话);
                          GetCalledRule(model.SIPID, 0, "", model.vc_OutNumber == null ? "" : model.vc_OutNumber, 
                                               ref lstAdd, ref lstDelete, MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途);
                     

                          if (Tools.MBoxOperate.DeleteSIP(model, lstAdd, lstDelete) && new DB_Talk.BLL.m_SIPInterface().Delete(model.ID))
                          {
                              MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);
                              delete = true;
                          }
                      }
                      else  //还未添加 直接删除
                          delete = true;


                      if (delete)
                      {
                          procDlg.Hide();
                          dgvSIP.Rows.Remove(dgvSIP.CurrentRow);
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
                      CommControl.Tools.WriteLog.AppendErrorLog(ex);
                  }
                  finally
                  {
                      procDlg.Dispose();
                  }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要删除的SIP中继！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        //保存SIP
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!NewFormMain.LoadBox(Global.Params.BoxIP))
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("登录站点【" + Global.Params.BoxIP + "】失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            System.Collections.Generic.Dictionary<DB_Talk.Model.m_SIPInterface, DB_Talk.Model.m_SIPInterface> lst = new Dictionary<DB_Talk.Model.m_SIPInterface, DB_Talk.Model.m_SIPInterface>();
            try
            {
                lst = GetLstSIPInterface();
                if (lst==null || lst.Count==0)
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string mes="";
            Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
            try
            {
                try
                {
                    foreach (System.Collections.Generic.KeyValuePair<DB_Talk.Model.m_SIPInterface, DB_Talk.Model.m_SIPInterface> d in lst)
                    {
                        procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在保存SIP中继【" + d.Key.SIPID + "】,请稍等...");

                        List<DB_Talk.Model.m_CalledRule> lstAdd = new List<DB_Talk.Model.m_CalledRule>();
                        List<DB_Talk.Model.m_CalledRule> lstDelete = new List<DB_Talk.Model.m_CalledRule>();
                        string outNum = "";  //原有的引导码
                        if (d.Value != null) outNum = d.Value.vc_OutNumber == null ? "" : d.Value.vc_OutNumber;

                        string outNumLocal = "";  //原有的引导码
                        if (d.Value != null) outNumLocal = d.Value.vc_OutNumberLocal == null ? "" : d.Value.vc_OutNumberLocal;

                        if (d.Key.vc_OutNumberLocal!=null)
                        {
                            GetCalledRule(d.Key.SIPID, 0, d.Key.vc_OutNumberLocal, outNumLocal, ref lstAdd, ref lstDelete, MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.市话);    
                        }
                        
                        if (d.Key.vc_OutNumber!=null)
                        {
                            GetCalledRule(d.Key.SIPID, 0, d.Key.vc_OutNumber, outNum, ref lstAdd, ref lstDelete, MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途);    
                        }
                        
                      
                        if (!Tools.MBoxOperate.CreateSIP(d.Key, d.Value, lstAdd, lstDelete))
                        {
                            mes = d.Key.SIPID.ToString();
                            procDlg.Hide();
                            CommControl.MessageBoxEx.MessageBoxEx.Show("保存SIP中继【" + d.Key.SIPID + "】失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    procDlg.Hide();
                    CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Loaddata(1);
                if (mes == "")
                {
                    MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);
                    procDlg.Hide();
                    //CommControl.MessageBoxEx.MessageBoxEx.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DialogResult dr = CommControl.MessageBoxEx.MessageBoxEx.Show("SIP中继保存成功，需要重启后生效，请确认是否要重启，点击【确定】重启，点击【取消】不重启", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        Global.Params.frmMain.ReStartBox();
                    }
                    else
                    {
                        Global.Params.IsRestart = false;
                    }
                }
            }
            catch (Exception ex)
            {
                procDlg.Hide();
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
            }
            finally
            {
                procDlg.Dispose();
            }

        }
        //SIP编辑结束事件
        void dgvSIP_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                DataGridViewCell cell = dgvSIP.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value != null && cell.Value.ToString().IndexOf("'") >= 0)
                {
                    cell.Value = cell.Value.ToString().Replace("'", "");
                    
                    //dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "不能包含特殊字符'";
                }
                //else
                //    dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";
                if (cell.Value != null && cell.Value.ToString().IndexOf(",,") >= 0)
                {
                    cell.Value = "";
                }
              

                //中继编号只能是数字
                if (cell.ColumnIndex == dgvSIP.Columns["colSIPID"].Index )
                {
                    if (cell.Value != null)
                    {
                        int num = 0;
                        if (int.TryParse(cell.Value.ToString(), out num) && num > 0&& num<=9 )
                        {
                            cell.Value = num;
                        }
                        else
                            cell.Value = "";
                    }
                }

                //本端端口,对端端口
                if (                    cell.ColumnIndex == dgvSIP.Columns["colSIPPort"].Index ||   //本端端口
                    cell.ColumnIndex == dgvSIP.Columns["colSIPPort2"].Index)
                {
                    if (cell.Value != null)
                    {
                        int num = 0;
                        if (int.TryParse(cell.Value.ToString(), out num) && num > 1025 && num <= 9999)
                        {
                            cell.Value = num;
                        }
                        else
                            cell.Value = "";
                    }
                }
                //出局码不能重复
                if (cell.ColumnIndex == dgvSIP.Columns["colSIPOut"].Index ||
                    cell.ColumnIndex == dgvSIP.Columns["colSIPOutSub"].Index )
                {
                    if (cell.Value != null)
                    {
                        if (!Global.Methods.checkNumOut(cell.Value.ToString()))  //匹配数字 逗号
                        {
                            cell.Value = "";
                        }
                        else
                        {
                            if (Global.Methods.checkNumOutIsSame(cell.Value.ToString()))  //本单元格逗号隔开的数字有重复
                            {
                                cell.Value = "";
                            }
                            else
                               cell.Value = cell.Value.ToString().Trim(',');
                        }
                    }

                    for (int i = 0; i < dgvSIP.Rows.Count; i++)
                    {
                        if (i != e.RowIndex)
                        {
                            if (cell.Value != null && cell.Value.ToString() != ""
                                && dgvSIP.Rows[i].Cells[e.ColumnIndex].Value != null
                                && dgvSIP.Rows[i].Cells[e.ColumnIndex].Value.ToString() != "")
                            {
                                string strOut = cell.Value.ToString();
                                string[] strArray = strOut.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string str in strArray)
                                {
                                    int num = 0;
                                    if (!int.TryParse(str, out num)) // || num<0 || num > 99999)
                                    {
                                        cell.Value = null;
                                        break;
                                        //throw new Exception("出局引导码格式错误！必须是以英文逗号隔开的数字！");
                                    }
                                    string PrestrOut = dgvSIP.Rows[i].Cells[e.ColumnIndex].Value.ToString();
                                    string[] PreStrArray = PrestrOut.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                    foreach (string strPre in PreStrArray)
                                    {
                                        if (str == strPre)
                                        {
                                            cell.Value = null;
                                            break;
                                        }
                                    }

                                    //if (dgvSIP.Rows[i].Cells[e.ColumnIndex].Value.ToString().IndexOf(num.ToString()) >= 0)
                                    //{
                                    //    cell.Value = null;
                                    //    break;
                                    //}
                                }
                            }
                        }
                    }
                }

                if (cell.ColumnIndex == dgvSIP.Columns["colSIPIP"].Index)
                {
                    if (cell.Value != null)
                    {
                        if (!Global.Methods.checkIP(cell.Value.ToString()))  //匹配数字 逗号
                        {
                            cell.Value = "";
                        }
                    }
                }
                //本机端口号、对端IP、对端端口号 不能重复
                if (cell.ColumnIndex == dgvSIP.Columns["colSIPPort"].Index || 
                    cell.ColumnIndex == dgvSIP.Columns["colSIPIP"].Index ||
                    cell.ColumnIndex == dgvSIP.Columns["colSIPPort2"].Index)
                {
                    for (int i = 0; i < dgvSIP.Rows.Count; i++)
                    {
                        if (i != e.RowIndex)
                        {
                            if (cell.Value != null && cell.Value.ToString() != ""
                                && dgvSIP.Rows[i].Cells[e.ColumnIndex].Value != null
                                && dgvSIP.Rows[i].Cells[e.ColumnIndex].Value.ToString() != ""
                                && cell.Value.ToString() == dgvSIP.Rows[i].Cells[e.ColumnIndex].Value.ToString())
                            {
                                cell.Value = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
            }
        }


        //添加PRI中继
        private void btnAddPRI_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow item in dgvPRI.Rows)
            {
                if (item.Tag == null)
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("请先保存然后再增加！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            Pricount = this.dgvPRI.Rows.Count;

            if (Pricount+1 > E1Max)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("最多只能添加【" + E1Max + "】个PRI中继！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.dgvPRI.Rows.Add("", Pricount + 1, "","", Pricount + 1, 1, "Hitotek", "用户侧", "无效值", "无效值");


            //本机端口号、对端IP、对端端口号 不能重复
            for (int j = 1; j <= 3; j++)
            {
                if (j == 2) continue;
                for (int i = 0; i < dgvPRI.Rows.Count-1; i++)
                {
                    DataGridViewCell cell = dgvPRI.Rows[i].Cells[j];
                    DataGridViewCell cell2 = dgvPRI.Rows[i + 1].Cells[j];
                    if (cell.Value != null && cell.Value.ToString() != "" &&
                        cell2.Value != null && cell2.Value.ToString() != ""
                        && cell.Value.ToString() == cell2.Value.ToString())
                    {
                        cell2.Value = null;
                    }
                }
            }

            //this.dgvPRI.Rows.Add("", "", "", null, 1, "MicroXel", "用户侧", "无效值", "无效值");

            //dgvPRI.Rows[count].Cells["colE1Number"].Value = count + 1;

        }
        //删除PRI中继
        private void btnDeletePRI_Click(object sender, EventArgs e)
        {
            if (dgvPRI.CurrentRow != null)
            {
                if (!NewFormMain.LoadBox(Global.Params.BoxIP))
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("登录站点【" + Global.Params.BoxIP + "】失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                 Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
                 try
                 {
                     
                     bool delete = false;
                     DB_Talk.Model.m_PRIInterface model = dgvPRI.CurrentRow.Tag as DB_Talk.Model.m_PRIInterface;
                     if (model != null)
                     {
                         procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在删除PRI中继【" + model.PRIID + "】,请稍等...");
                  
                         List<DB_Talk.Model.m_CalledRule> lstAdd = new List<DB_Talk.Model.m_CalledRule>();
                         List<DB_Talk.Model.m_CalledRule> lstDelete = new List<DB_Talk.Model.m_CalledRule>();

                         if (model.vc_OutNumberLocal!=null)
                         {
                             GetCalledRule(0, model.PRIID, "", model.vc_OutNumberLocal, ref lstAdd, ref lstDelete, MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.市话);    
                         }
                         
                         if (model.vc_OutNumber!=null)
                         {
                             GetCalledRule(0, model.PRIID, "", model.vc_OutNumber, ref lstAdd, ref lstDelete, MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途);    
                         }
                         
                     
                     

                         if (Tools.MBoxOperate.DeletePRI(model, lstAdd, lstDelete) && new DB_Talk.BLL.m_PRIInterface().Delete(model.ID))
                         {
                             MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);
                             delete = true;
                         }
                     }
                     else  //还未添加 直接删除
                         delete = true;

                     if (delete)
                     {
                         dgvPRI.Rows.Remove(dgvPRI.CurrentRow);
                         procDlg.Hide();
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
                     CommControl.Tools.WriteLog.AppendErrorLog(ex);
                 }
                 finally
                 {
                     procDlg.Dispose();
                 }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择要删除的PRI中继！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        //保存PRI中继
        private void btnSavePRI_Click(object sender, EventArgs e)
        {
            if (!NewFormMain.LoadBox(Global.Params.BoxIP))
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("登录站点【" + Global.Params.BoxIP + "】失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
            try
            {
                System.Collections.Generic.Dictionary<DB_Talk.Model.m_PRIInterface, DB_Talk.Model.m_PRIInterface> Dic = new Dictionary<DB_Talk.Model.m_PRIInterface, DB_Talk.Model.m_PRIInterface>();
                try
                {
                    Dic = GetLstPRIInterface();
                    if (Dic == null || Dic.Count == 0)
                    {
                        return;
                    }
                }
                catch (Exception ex)
                {
                   
                    CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string mes = "";
                //foreach (DB_Talk.Model.m_SIPInterface m in lst)
                try
                {
                    foreach (System.Collections.Generic.KeyValuePair<DB_Talk.Model.m_PRIInterface, DB_Talk.Model.m_PRIInterface> d in Dic)
                    {
                        procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在保存PRI中继【" + d.Key.PRIID + "】,请稍等...");
                        List<DB_Talk.Model.m_CalledRule> lstAdd = new List<DB_Talk.Model.m_CalledRule>();
                        List<DB_Talk.Model.m_CalledRule> lstDelete = new List<DB_Talk.Model.m_CalledRule>();
                        string outNum = "";
                        if (d.Value != null) outNum = d.Value.vc_OutNumber == null ? "" : d.Value.vc_OutNumber;
                        string outNumLocal = "";  //原有的引导码
                        if (d.Value != null) outNumLocal = d.Value.vc_OutNumberLocal == null ? "" : d.Value.vc_OutNumberLocal;
                        if (d.Key.vc_OutNumberLocal!=null)
                        {
                            GetCalledRule(0, d.Key.PRIID, d.Key.vc_OutNumberLocal, outNumLocal, ref lstAdd, ref lstDelete, MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.市话);    
                        }

                        if (d.Key.vc_OutNumber!=null)
                        {
                            GetCalledRule(0, d.Key.PRIID, d.Key.vc_OutNumber, outNum, ref lstAdd, ref lstDelete, MBoxSDK.ConfigSDK.CALLED_SUB_RULE_TYPE.长途);    
                        }
                        
                        
                        if (!Tools.MBoxOperate.CreatePRI(d.Key, d.Value, lstAdd, lstDelete))
                        {
                            mes = d.Key.PRIID.ToString();
                            procDlg.Hide();
                            CommControl.MessageBoxEx.MessageBoxEx.Show("保存PRI中继【" + d.Key.PRIID + "】失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    procDlg.Hide();
                    CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Loaddata(2);
                if (mes == "")
                {
                    MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);
                    procDlg.Hide();
                    CommControl.MessageBoxEx.MessageBoxEx.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                procDlg.Hide();
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
            }
            finally
            {
                procDlg.Dispose();
            }


        }
        //PRI编辑结束事件
        void dgvPRI_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewCell cell = dgvPRI.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value != null && cell.Value.ToString().IndexOf("'") >= 0)
            {
                cell.Value = cell.Value.ToString().Replace("'", "");
               // cell.Value = cell.Value.ToString().Replace(",,", ",");
                //dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "不能包含特殊字符'";
            }
            //else
            //    dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";

            if (cell.Value != null && cell.Value.ToString().IndexOf(",,") >= 0)
            {
                cell.Value = "";
            }
            //中继编号只能是数字
            if (cell.ColumnIndex == dgvPRI.Columns["colPRIID"].Index)
            {
                if (cell.Value != null)
                {
                    int num = 0;
                    if (int.TryParse(cell.Value.ToString(), out num) && num > 0 && num<=9)
                    {
                        cell.Value = num;
                    }
                    else
                        cell.Value = "";
                }
            }
            //出局码不能重复
            if (cell.ColumnIndex == dgvPRI.Columns["colPriOutSub"].Index ||
                cell.ColumnIndex == dgvPRI.Columns["colPriOut"].Index)
            {
                if (cell.Value != null)
                {
                    if (!Global.Methods.checkNumOut(cell.Value.ToString()))  //匹配数字 逗号
                    {
                        cell.Value = "";
                    }
                    else
                    {
                        if (Global.Methods.checkNumOutIsSame(cell.Value.ToString()))  //本单元格逗号隔开的数字有重复
                        {
                            cell.Value = "";
                        }
                        else
                            cell.Value = cell.Value.ToString().Trim(',');
                        
                    }
                }

                for (int i = 0; i < dgvPRI.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        if (cell.Value != null && cell.Value.ToString() != ""
                            && dgvPRI.Rows[i].Cells[e.ColumnIndex].Value != null
                            && dgvPRI.Rows[i].Cells[e.ColumnIndex].Value.ToString() != "")
                        {
                            string strOut = cell.Value.ToString();
                            string[] strArray = strOut.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string str in strArray)
                            {
                                int num = 0;
                                if (!int.TryParse(str, out num))
                                {
                                    cell.Value = null;
                                    break;
                                    //throw new Exception("出局引导码格式错误！必须是以英文逗号隔开的数字！");
                                }
                                string PrestrOut=dgvPRI.Rows[i].Cells[e.ColumnIndex].Value.ToString();
                                string[] PreStrArray = PrestrOut.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (string strPre in PreStrArray)
                                {
                                    if (str == strPre)
                                    {
                                        cell.Value = null;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //中继编号与E1端口号不能重复
            if (cell.ColumnIndex == dgvPRI.Columns["colPRIID"].Index ||
                cell.ColumnIndex == dgvPRI.Columns["colE1Number"].Index)
            {
                for (int i = 0; i < dgvPRI.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        if (cell.Value != null && cell.Value.ToString() != ""
                            && dgvPRI.Rows[i].Cells[e.ColumnIndex].Value != null
                            && dgvPRI.Rows[i].Cells[e.ColumnIndex].Value.ToString() != ""
                            && cell.Value.ToString() == dgvPRI.Rows[i].Cells[e.ColumnIndex].Value.ToString())
                        {
                            cell.Value = null;
                        }
                    }
                }
            }


        }



        //中继操作状态改变事件
        void getStateSipPri_InterfaceStateChange(object model)
        {
            try
            {

                DB_Talk.Model.m_SIPInterface mSip = model as DB_Talk.Model.m_SIPInterface;
                if (mSip != null)
                {
                    foreach (DataGridViewRow item in dgvSIP.Rows)
                    {
                        if (mSip.SIPID == int.Parse(item.Cells["colSIPID"].Value.ToString()))
                        //if (m.ID == int.Parse(item.Cells["SipID"].Value.ToString()))
                        {
                            item.Cells["colSipState"].Value = (mSip.i_State == 2 ? "激活" : "未激活");
                            item.Cells["colSipOperateState"].Value = (mSip.i_OperateState == 2 ? "运行" : "停止");
                        }
                    }
                }

                DB_Talk.Model.m_PRIInterface mPri = model as DB_Talk.Model.m_PRIInterface;
                if (mPri != null)
                {
                    foreach (DataGridViewRow item in dgvPRI.Rows)
                    {
                        if (mSip.SIPID == int.Parse(item.Cells["colPRIID"].Value.ToString()))
                        //if (m.ID == int.Parse(item.Cells["SipID"].Value.ToString()))
                        {
                            item.Cells["colPriState"].Value = (mPri.i_State == 2 ? "激活" : "未激活");
                            item.Cells["colPriOperateState"].Value = (mPri.i_Operate == 2 ? "运行" : "停止");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
            }

        }

        //离开页面时注销事件
        private void frmSIPPRI_ParentChanged(object sender, EventArgs e)
        {
            if (IsLoad)
            {
                Global.Params.frmMain.getStateSipPri.InterfaceStateChange -= new Tools.GetStateSipPri.StateChange(getStateSipPri_InterfaceStateChange);
                Global.Params.frmMain.getStateSipPri.lstPrePri = new List<DB_Talk.Model.m_PRIInterface>();
                Global.Params.frmMain.getStateSipPri.lstPreSip = new List<DB_Talk.Model.m_SIPInterface>();
            }
        }
        string _tableNameSip = "ListSip";
        string _tableNamePri = "ListPri";

        private void tsmSetSipStyle_Click(object sender, EventArgs e)
        {
            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableNameSip, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableNameSip, this.dgvSIP);
            
        }

        private void tsmSetPriStyle_Click(object sender, EventArgs e)
        {
            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableNamePri, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableNamePri, this.dgvPRI);
           
        }
    }


}
