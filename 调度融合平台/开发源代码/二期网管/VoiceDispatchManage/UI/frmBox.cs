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
    public partial class frmBox :frmBase
    {
        private DB_Talk.Model.m_Box _mModel = new DB_Talk.Model.m_Box();
        private DB_Talk.Model.m_Box _mModelOld = new DB_Talk.Model.m_Box();

        private DB_Talk.BLL.m_Box _BLL = new DB_Talk.BLL.m_Box();

        private int _operate = 0;
        public frmBox(DB_Talk.Model.m_Box model, int operate)
         {
            InitializeComponent();

            _operate = operate;
            if (operate == 0)
            {
                _mModelOld = null;
                this.FormTitle = "添加";
                btnOK.Text = "添加";
                this.txtIP.Text = "172.21.0.2";
                //this.txtNetIP.Text= "10.21.0.2";
                //this.txtMask.Text = "255.255.255.0";
               
                this.txtNetIP.Enabled=false;
                this.txtMask.Enabled = false;

                this.txtDispatchIP1.Text = "172.21.0.41";
                this.txtDispatchIP2.Text = "172.21.0.42";
                this.txtRecordServerIP.Text = "172.21.0.21";
                this.txtTimerIP.Text = "";
            }
            else
            {
                btnTest.Visible = false;
                _mModel = model;
                _mModelOld = (DB_Talk.Model.m_Box)model.Clone();
                this.FormTitle = "编辑";
                btnOK.Text = "编辑";
                ShowModel();
            }
            //this.txtName.MaxLength = Global.Params.NameLen;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                GetModel();
             

                if (btnOK.Text == "添加")
                {
                    if (_BLL.GetModelList(string.Format(" i_flag=0 and  vc_Name='{0}'", _mModel.vc_Name)).Count > 0)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("名称【{0}】已存在!", _mModel.vc_Name), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtName.Focus();
                        return;
                    }
                    if (_BLL.GetModelList(string.Format(" i_flag=0 and  vc_IP='{0}'", _mModel.vc_IP)).Count > 0)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("IP【{0}】已存在!", _mModel.vc_IP), "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtIP.Focus();
                        return;
                    }
                   
                    if (SetBox(_mModel.vc_IP))  //setBox基本设置时 需要boxID，所以数据库先增加，如果setbox失败则删除增加的数据
                    {
                        _BLL.Update(_mModel);
                        List<DB_Talk.Model.m_Box> lst = _BLL.GetModelList(string.Format(" i_flag=0 and  vc_Name='{0}'", _mModel.vc_Name));
                        CommControl.MessageBoxEx.MessageBoxEx.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, lst[0].ID, CommControl.SystemLogBLL.EnumLogAction.Add, "添加", "添加了站点：" + _mModel.vc_Name, "");
                        List<DB_Talk.Model.m_Box> lstbox = _BLL.GetModelList(string.Format(" i_flag=0 and  vc_Name='{0}'", _mModel.vc_Name));
                        //增加默认分组
                        if (lstbox.Count > 0) addgroup(lstbox[0]);
                        //DB_Talk.BLL.m_SystemLog.WriteLog(Global.Params.UserID, DB_Talk.Model.m_SystemLog.EnumLogAction.Add, "增加文件等级", "增加了文件等级:" + _mModel.vc_Name);
                        //添加默认时钟源
                        _mModel.ID = lst[0].ID;
                        AddPRIClolck(_mModel);
                        //Global.Params.LstBox.Add(_mModel);

                        Global.Params.LstBox = lstbox;

                        this.DialogResult = DialogResult.OK;

                        this.Close();
                    }
                    else
                    {
                        _BLL.Delete(_mModel.ID);
                        CommControl.MessageBoxEx.MessageBoxEx.Show("添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (btnOK.Text == "编辑")
                {
                    if (CommControl.MessageBoxEx.MessageBoxEx.Show("修改站点信息会导致静态路由丢失，请确认是否要修改？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    List<DB_Talk.Model.m_Box> lst = _BLL.GetModelList(string.Format(" i_flag=0 and  vc_Name='{0}'", _mModel.vc_Name));
                    if (lst.Count > 0)
                    {
                        if (lst[0].ID != _mModel.ID)
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("名称【{0}】已存在！", _mModel.vc_Name), "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            txtName.Focus();
                            return;
                        }
                    }
                    lst = _BLL.GetModelList(string.Format(" i_flag=0 and  vc_IP='{0}'", _mModel.vc_IP));
                    if (lst.Count > 0)
                    {
                        if (lst[0].ID != _mModel.ID)
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("IP【{0}】已存在！", _mModel.vc_IP), "编辑失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            txtIP.Focus();
                            return;
                        }
                    }
                    Global.Params.BoxID = _mModel.ID;
                    if (SetBox(_mModelOld.vc_IP) && _BLL.Update(_mModel))
                    //if (_BLL.Update(_mModel))
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("编辑成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, _mModel.ID, CommControl.SystemLogBLL.EnumLogAction.Update, "编辑", "编辑了站点：" + _mModel.vc_Name, "");

                        int iFind = Global.Params.LstBox.FindIndex(item => item.ID == _mModel.ID);
                        if (iFind >= 0) Global.Params.LstBox[iFind] = _mModel;
                        /*
                        for (int j = 0; j < Global.Params.LstBox.Count; j++)
                        {
                            if (Global.Params.LstBox[j].ID == _mModel.ID)
                            {
                                Global.Params.LstBox[j].vc_IP = _mModel.vc_IP;
                            }
                        }
                        */
                        //DB_Talk.BLL.m_SystemLog.WriteLog(Global.Params.UserID, DB_Talk.Model.m_SystemLog.EnumLogAction.Update, "编辑文件等级", "编辑了文件等级:" + _mModel.vc_Name);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show("编辑失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void AddPRIClolck(DB_Talk.Model.m_Box boxmodel)
        {
            DB_Talk.BLL.m_PRIClock BLL=new DB_Talk.BLL.m_PRIClock();
            for (int i = 0; i < 4; i++)
            {
                List<DB_Talk.Model.m_PRIClock> lst = BLL.GetModelList(
                    string.Format(" i_Flag=0 and BoxID='{0}' and i_Level='{1}'",boxmodel.ID,i));
                if (lst.Count == 0)
                {
                    DB_Talk.Model.m_PRIClock model = new DB_Talk.Model.m_PRIClock();
                    model.BoxID = boxmodel.ID;
                    model.i_Level = i;
                    model.i_Type = MBoxSDK.ConfigSDK.EnumPriClockType.内部.GetHashCode();
                    model.i_Port =0;
                    BLL.Add(model);
                }
            }
        }

        private void addgroup(DB_Talk.Model.m_Box boxmodel)
        {
            Type grouptype = typeof(CommControl.PublicEnums.EnumGroupType);
            foreach (int i in Enum.GetValues(grouptype))
            {
                if (i == 1)  //只有调度才添加常用人员组，2103-5-31修改
                {
                    List<DB_Talk.Model.m_Group> lstmodel = new List<DB_Talk.Model.m_Group>();
                    DB_Talk.BLL.m_Group bll = new DB_Talk.BLL.m_Group();
                    lstmodel = bll.GetModelList(string.Format(" i_flag=0 and  vc_Name='{0}' and BoxID='{1}' and GroupTypeID='{2}'", Global.Params.gruopNormalName, boxmodel.ID, i)); //("i_Flag=0 and vc_Name='" + Global.Params.gruopNormalName + "'");
                    if (lstmodel.Count == 0)
                    {
                        DB_Talk.Model.m_Group model = new DB_Talk.Model.m_Group();
                        model.BoxID = boxmodel.ID.ToString();
                        model.vc_Name = Global.Params.gruopNormalName;
                        model.GroupTypeID = i;
                        bll.Add(model);
                    }
                }
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (txtIP.Text.Trim() != "")
            {
                if (LoadBoxTest(txtIP.Text.Trim()))
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show("登录【" + txtIP.Text.Trim() + "】成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NewFormMain.LoadBox(txtIP.Text.Trim());
                    if (Global.Params.BoxType != MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000_3G)
                    {
                        txtSecureIP.Enabled = false;
                        txtPdsIP.Enabled = false;
                        txtDNS1.Enabled = false;
                        txtDNS2.Enabled = false;
                    }
                }
                else
                    CommControl.MessageBoxEx.MessageBoxEx.Show("登录【" + txtIP.Text.Trim() + "】失败，请确认IP是否正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("IP地址不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void CheckAllIP()
        {
           

          

          

          


          
        
        }


       


        #region  私有方法

        private void GetModel()
        {
            _mModel.vc_Name = txtName.Text.Trim();
            if (_mModel.vc_Name == "")
            {
                txtName.Focus();
                throw new Exception("名称不可以为空");
            }
            if (_mModel.vc_Name.IndexOf("'") >= 0)
            {
                txtName.Focus();
                throw new Exception("名称中不可以有特殊字符");
            }
            _mModel.vc_IP = txtIP.Text.Trim();
            if (_mModel.vc_IP == "")
            {
                txtIP.Focus();
                throw new Exception("IP地址不可以为空");
            }
            if (txtIP.Text.Trim() != "" && !Global.Methods.checkIP(txtIP.Text.Trim()))
            {
                txtIP.Text = "";
                txtIP.Focus();
                throw new Exception("IP地址不合法");
            }
         

            //DspIP为业务口IP+1
            uint iIP = Dot2LongIP(_mModel.vc_IP.Trim());
            iIP++;
            _mModel.vc_DspIP = LongIP2Dot(iIP);

           

            if (_operate != 0)  //新增时不能设置网管口IP，子网掩码
            {
                _mModel.vc_NetIP = txtNetIP.Text.Trim();
               
                if (_mModel.vc_NetIP == "")
                {
                    txtNetIP.Focus();
                    throw new Exception("网管口IP不可以为空");
                }

                if (txtNetIP.Text.Trim() != "" && !Global.Methods.checkIP(txtNetIP.Text.Trim()))
                {
                    txtNetIP.Text = "";
                    txtNetIP.Focus();
                    throw new Exception("网管口IP地址不合法");
                }

             

                _mModel.vc_Mask = txtMask.Text.Trim();

                if (_mModel.vc_Mask == "")
                {
                    txtMask.Focus();
                    throw new Exception("子网掩码不可以为空");
                }

                if (txtMask.Text.Trim() != "" && !Global.Methods.checkIP(txtMask.Text.Trim()))
                {
                    txtMask.Text = "";
                    txtMask.Focus();
                    throw new Exception("子网掩码不合法");
                }

                if (CheckIPInSameNet(_mModel.vc_IP, _mModel.vc_NetIP, _mModel.vc_Mask, "255.255.255.0"))
                {
                    txtNetIP.Focus();  //网管口子网掩码默认255.255.255.0
                    throw new Exception("站点IP与网管口IP不能在同一个网段");
                }
            }

            _mModel.vc_DispatchIP1 = txtDispatchIP1.Text.Trim();
            if (_mModel.vc_DispatchIP1 == "")
            {
                txtDispatchIP1.Focus();
                throw new Exception("调度IP地址不可以为空");
            }

            if (txtDispatchIP1.Text.Trim() != "" && !Global.Methods.checkIP(txtDispatchIP1.Text.Trim()))
            {
                txtDispatchIP1.Text = "";
                txtDispatchIP1.Focus();
                throw new Exception("调度台IP地址不合法");
            }

            _mModel.vc_DispatchIP2 = txtDispatchIP2.Text.Trim();
            //if (_mModel.vc_DispatchIP2 == "")
            //{
            //    txtDispatchIP2.Focus();
            //    throw new Exception("调度调试IP地址不可以为空");
            //}


            if (txtDispatchIP2.Text.Trim() != "" && !Global.Methods.checkIP(txtDispatchIP2.Text.Trim()))
            {
                txtDispatchIP2.Text = "";
                txtDispatchIP2.Focus();
                throw new Exception("调度台调试IP地址不合法");
            }


    


            _mModel.vc_RecordServerIP = txtRecordServerIP.Text.Trim();
            _mModel.vc_TimerServerIP = txtTimerIP.Text.Trim();

            if (txtRecordServerIP.Text.Trim() != "" && !Global.Methods.checkIP(txtRecordServerIP.Text.Trim()))
            {
                txtRecordServerIP.Text = "";
                txtRecordServerIP.Focus();
                throw new Exception("录音服务IP地址不合法");
            }

            if (txtTimerIP.Text.Trim() != "" && !Global.Methods.checkIP(txtTimerIP.Text.Trim()))
            {
                txtTimerIP.Text = "";
                txtTimerIP.Focus();
                throw new Exception("时间服务器IP地址不合法");
            }


            if (Global.Params.BoxType == MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000_3G)
            {
                if (txtSecureIP.Text.Trim() == "")
                {
                    txtSecureIP.Focus();
                    throw new Exception("安全网关IP地址不可以为空");
                }

                if (txtSecureIP.Text.Trim() != "" && !Global.Methods.checkIP(txtSecureIP.Text.Trim()))
                {
                    txtSecureIP.Text = "";
                    txtSecureIP.Focus();
                    throw new Exception("安全网关IP地址不合法");
                }

           


                if (txtPdsIP.Text.Trim() == "")
                {
                    txtPdsIP.Focus();
                    throw new Exception("分组网关IP地址不可以为空");
                }

                if (txtPdsIP.Text.Trim() != "" && !Global.Methods.checkIP(txtPdsIP.Text.Trim()))
                {
                    txtPdsIP.Text = "";
                    txtPdsIP.Focus();
                    throw new Exception("分组网关IP地址不合法");
                }


                if (txtDNS1.Text.Trim() == "")
                {
                    txtDNS1.Focus();
                    throw new Exception("首选DNS服务器不可以为空");
                }


                if (txtDNS1.Text.Trim() != "" && !Global.Methods.checkIP(txtDNS1.Text.Trim()))
                {
                    txtDNS1.Text = "";
                    txtDNS1.Focus();
                    throw new Exception("首选DNS服务IP地址不合法");
                }

                if (txtDNS2.Text.Trim() != "" && !Global.Methods.checkIP(txtDNS2.Text.Trim()))
                {
                    txtDNS2.Text = "";
                    txtDNS2.Focus();
                    throw new Exception("备用DNS服务IP地址不合法");
                }

  
            }

            _mModel.vc_Memo = txtMemo.Text.Trim();

            if (_mModel.vc_Memo.IndexOf("'") >= 0)
            {
                txtMemo.Focus();
                throw new Exception("备注中不可以有特殊字符");
            }
            _mModel.i_MaxMeetingMember = Global.Params.ConfigModel.SystemConfig.MaxGroupMemberCount;


          
        }

        private void ShowModel()
        {
            txtName.Text = _mModel.vc_Name;
            txtMask.Text = _mModel.vc_Mask;
            txtIP.Text = _mModel.vc_IP;
            txtNetIP.Text = _mModel.vc_NetIP;
            txtDispatchIP1.Text = _mModel.vc_DispatchIP1;
            txtDispatchIP2.Text = _mModel.vc_DispatchIP2;
            txtRecordServerIP.Text = _mModel.vc_RecordServerIP;
            txtTimerIP.Text = _mModel.vc_TimerServerIP; //时间服务器

            //txtSN.Text = _mModel.vc_SN;
            txtMemo.Text = _mModel.vc_Memo;

            #region 3G相关信息


            NewFormMain.LoadBox(_mModel.vc_IP);
            Global.Params.BoxType = Global.Methods.GetBoxType(Global.Params.BoxHandle);
            if (Global.Params.BoxType == MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000_3G)
            {
                string ip = "";
                Tools.MBoxOperate.GetSecureGatewayAddress(out ip);
                txtSecureIP.Text = ip == "0.0.0.0" ? "" : ip;
                string dns1 = "", dns2 = "";
                Tools.MBoxOperate.GetDNSServer(out dns1, out dns2);
                txtDNS1.Text = dns1 == "0.0.0.0" ? "" : dns1;
                txtDNS2.Text = dns2 == "0.0.0.0" ? "" : dns2;
                List<DB_Talk.Model.m_PDS> lstPDS = new List<DB_Talk.Model.m_PDS>();
                Tools.MBoxOperate.GetPDS(out lstPDS);
                if (lstPDS != null && lstPDS.Count > 0)
                {
                    txtPdsIP.Text = lstPDS[0].vc_IP;
                }
            }
            else
            {
                txtSecureIP.Enabled = false;
                txtPdsIP.Enabled = false;
                txtDNS1.Enabled = false;
                txtDNS2.Enabled = false;
            }
            #endregion
        }

        private bool Set3GBox()
        {

            #region 3G相关


            Tools.MBoxOperate.SetSecureGatewayAddress(txtSecureIP.Text.Trim());

            Tools.MBoxOperate.SetDNSServer(txtDNS1.Text.Trim(), txtDNS2.Text.Trim());

            #region PDS操作
            
            
            List<DB_Talk.Model.m_PDS> lstPDS = new List<DB_Talk.Model.m_PDS>();
            Tools.MBoxOperate.GetPDS(out lstPDS);

            foreach (DB_Talk.Model.m_PDS item in lstPDS)//先清空所有
            {
                Tools.MBoxOperate.SetPDSDctive(item);
                Tools.MBoxOperate.DeletePDS(item);
            }
            DB_Talk.Model.m_PDS pds = new DB_Talk.Model.m_PDS();
            pds.PdsID = 1;
            pds.    vc_IP = txtPdsIP.Text.Trim();
            bool b = Tools.MBoxOperate.CreatePDS(pds);
            Tools.MBoxOperate.SetPDSActive(pds);
            #endregion
     
            #endregion

            return true;
        }

        


        private bool SetBox(string IP)
        {

            if (LoadBoxTest(IP))  //_mModel.vc_IP))
            {
                if (_operate == 0)
                {
                    int boxID = _BLL.Add(_mModel, true);
                    Global.Params.BoxID = boxID;
                    _mModel.ID = boxID;
                }

                if (_mModelOld == null ||
                    _mModelOld.vc_DispatchIP1 != _mModel.vc_DispatchIP1 ||
                   _mModelOld.vc_DispatchIP2 != _mModel.vc_DispatchIP2)
                {
                    List<string> lstIP = new List<string>();
                    if (_mModel.vc_DispatchIP1!=null && _mModel.vc_DispatchIP1!="") lstIP.Add(_mModel.vc_DispatchIP1);
                    if (_mModel.vc_DispatchIP2!=null && _mModel.vc_DispatchIP2 != "") lstIP.Add(_mModel.vc_DispatchIP2);
                    if (!Tools.MBoxOperate.SetDispatcherAddress(lstIP))
                    {
                        throw new Exception("设置设置调度IP失败");
                    }
                }

                if (_mModelOld == null ||
                    _mModelOld.vc_RecordServerIP != _mModel.vc_RecordServerIP)
                {
                    if (_mModel.vc_RecordServerIP != "" && !Tools.MBoxOperate.SetRecordServer(_mModel.vc_RecordServerIP))
                        throw new Exception("设置录音服务器失败");
                }
                
                //设置时间服务器
                if (_mModelOld == null ||
                   _mModelOld.vc_TimerServerIP != _mModel.vc_TimerServerIP)
                {
                    if (_mModel.vc_TimerServerIP != null && _mModel.vc_TimerServerIP != "" && !Tools.MBoxOperate.SetTimeServer(_mModel.vc_TimerServerIP))
                        throw new Exception("设置时间服务器失败");
                }
                if (_mModelOld == null)  //新增
                {
                    if (!Tools.MBoxOperate.SetBaseBox())
                        return false;
                }

                if (_mModelOld == null ||
                   (_mModelOld.vc_IP != _mModel.vc_IP && _mModel.vc_DspIP!="")) //新增或者修改IP是才设置DspIP
                {
                    MBoxSDK.ConfigSDK.MBOX_SetDspAddress(Global.Params.BoxHandle,_mModel.vc_DspIP);
                }

                //最后设置IP
                if (_mModelOld != null && 
                    _mModelOld.vc_Mask!=null &&                  //新增的box不设置IP，只有修改的才可以设置
                   (_mModelOld.vc_IP != _mModel.vc_IP ||
                   _mModel.vc_IP != _mModel.vc_NetIP ||
                   _mModelOld.vc_Mask != _mModel.vc_Mask))
                 //  _mModelOld.vc_Name != _mModel.vc_Name))
                {
                    Tools.MBoxOperate.SetNodeInfo(_mModel);
                }
                if (Global.Params.BoxType== MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000_3G)
                {
                    Set3GBox();    
                }

                
                //MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle);
                Global.Params.frmMain.ReStartBox(); //重启box
            }
            else
            {
                throw new Exception("登录站点【" + IP + "】失败！不能执行增加修改操作！");
                //return false;
            }
            return true;
        }

        //public void checkIP( TextBox txt)
        //{
        //    if (txt.Text.Trim() != "" && !Global.Methods.checkIP(txt.Text.Trim()))
        //    {
        //        txt.Text = "";
        //        txt.Focus();
        //        CommControl.MessageBoxEx.MessageBoxEx.Show("IP地址不合法", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //判断两个IP在不在一个网段
        private bool CheckIPInSameNet(string strIP1,string strIP2,string strMask1,string strMask2)
        {
            try
            {
                uint iIP1 = 0, iIP2 = 0, iMask1 = 0, iMask2 = 0;
                iIP1 = Dot2LongIP(strIP1);
                iIP2 = Dot2LongIP(strIP2);
                iMask1 = Dot2LongIP(strMask1);
                iMask2 = Dot2LongIP(strMask2);
                if ((iIP1 & iMask1) == (iIP2 & iMask2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        //点分十进制转化为长整形
        public uint LongIPAddress(string strIP)
        {
            try
            {
                //将IP地址转换为字节数组 
                byte[] IPArr = IPAddress.Parse(strIP).GetAddressBytes();
                uint ret = 0;
                foreach (byte b in IPArr)
                {
                    ret <<= 8;
                    ret |= b;
                }
                return ret;
            }
            catch
            {
                return 0;
            }

        }
        //点分十进制转化为长整形
        public uint Dot2LongIP(string dotIP)
        {
            try
            {
                string[] subIP = dotIP.Split('.');
                uint ip = 16777216 * Convert.ToUInt32(subIP[0]) + 65536 * Convert.ToUInt32(subIP[1]) + 256 * Convert.ToUInt32(subIP[2]) + Convert.ToUInt32(subIP[3]);
                return ip;
            }
            catch
            {
                return 0;
            }
        }
        //长整形转化为点分十进制
        public string LongIP2Dot(uint longIP)
        {
            string dotIP = "";
            int subIP = 0;
            long one = longIP / 16777216;
            subIP = Convert.ToInt32(one.ToString("f0")) % 256;
            dotIP = subIP.ToString() + ".";
            long two = longIP / 65536;
            subIP = Convert.ToInt32(two.ToString("f0")) % 256;
            dotIP += subIP.ToString() + ".";
            long three = longIP / 256;
            subIP = Convert.ToInt32(three.ToString("f0")) % 256;
            dotIP += subIP.ToString() + ".";
            long four = longIP % 256;
            subIP = Convert.ToInt32(four.ToString("f0"));
            dotIP += subIP.ToString();
            return dotIP;
        }


        public bool LoadBoxTest(string BoxIP)
        {
            //登录box
            Bestway.Windows.Forms.ProgressBarDialog procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
            bool b = false;
            try
            {
                procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在登录" + Global.Params.BOXNAME + "【" + BoxIP + "】,请稍等...");
                int handle=MBoxSDK.ConfigSDK.MBOX_Login(BoxIP, "", "", "");
                b = handle > 0 ? true : false;
                b = b && MBoxSDK.ConfigSDK.MBOX_IsDeviceOnline(BoxIP);
                if (b)
                {
                    Global.Params.BoxHandle = handle;
                    Global.Params.BoxIP = BoxIP;
                    DB_Talk.Model.m_Box m = new DB_Talk.Model.m_Box();
                    if (_operate==0 && Tools.MBoxOperate.GetNodeInfo(handle, out m))
                    {
                        txtMask.Text = m.vc_Mask;
                        txtNetIP.Text = m.vc_NetIP;
                        _mModel.vc_Mask = txtMask.Text.Trim();
                        _mModel.vc_NetIP = txtNetIP.Text.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
            }
            finally
            {
                procDlg.Dispose();
            }
            return b;
        }

        #endregion



  

    }
}
