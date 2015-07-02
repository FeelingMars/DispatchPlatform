using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl;
using System.Data.OleDb;

namespace VoiceDispatchManage.UI
{
    public partial class frmExportMember : frmBase
    {
        public frmExportMember()
        {
            InitializeComponent();
            dgvList.AutoGenerateColumns = true;

            cmbSheets.DataSource = null;
            cmbSheets.Items.Add(" ");
           // tabControl1.SelectedIndex = 1;
        }
        private void frmExportMember_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn!=null && conn.State == ConnectionState.Open)
            conn.Close();
        }
        //连接串  
        string strConn = "";
        OleDbConnection conn;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (codeboolisExcelInstalled())
            {
                string path = GetFilePath();
                if (path != "")
                {
                    txtPath.Text = path;
                    GetDataFromExcelWithAppointSheetName(path);
                }
            }
            else
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("本机没有安装Excel文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }


        private void btnRead_Click(object sender, EventArgs e)
        {
            if (strConn == "" || cmbSheets.Text.Trim()=="") return;
            OleDbDataAdapter myCommand = null;
            DataTable dt = new DataTable();
            //从指定的表明查询数据,可先把所有表明列出来供用户选择  
            string strExcel = "select * from [" + cmbSheets.Text + "]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            dt = new DataTable();
            myCommand.Fill(dt);
            //绑定到界面
            dgvList.DataSource = dt; 
            //LoadData(dt);
            tslState.Text = "  共" + dgvList.Rows.Count.ToString() + "条记录";

            //List<DB_Talk.Model.m_Member> list = DataTableToModelList(dt);
            //dgvListOk.DataSource =;
            //toolStripStatusLabel1.Text = "  共" + dgvListOk.Rows.Count.ToString() + "条记录";
        }

        //CommControl.MessageBoxEx.MessageBoxEx messagebox;
        private void btnOK_Click(object sender, EventArgs e)
        {
            DB_Talk.BLL.m_Member _BLL = new DB_Talk.BLL.m_Member();
            List<DB_Talk.Model.m_Member> listCount = new List<DB_Talk.Model.m_Member>();
            listCount = _BLL.GetModelList(string.Format(" i_flag=0 and BoxID='{0}'", Global.Params.BoxID));
            if (listCount.Count >= Global.Params.MaxBoxMemberCount)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("不能导入，号码已经达到最大限制，【{0}】个!", Global.Params.MaxBoxMemberCount), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Bestway.Windows.Forms.ProgressBarDialog procDlg = null;
            procDlg = new Bestway.Windows.Forms.ProgressBarDialog();
            try
            {
                procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      正在导入用户，请稍等...");
                DataTable dt = new DataTable();
                dt = (DataTable)dgvList.DataSource;
                if (dt == null)
                {
                    throw new Exception("没有数据！");
                    
                }
                DB_Talk.BLL.m_Member bll = new DB_Talk.BLL.m_Member();
                StringBuilder sbAdd = new StringBuilder();
                List<DB_Talk.Model.m_Member> listAdd = new List<DB_Talk.Model.m_Member>();

                StringBuilder sbNotAdd = new StringBuilder();
                StringBuilder sbAdded = new StringBuilder();     //box中已经存在的
                StringBuilder sbBoxMaxNotAdded = new StringBuilder();  //box到达最大值未添加的
                //List<DB_Talk.Model.m_Member> list = (List < DB_Talk.Model.m_Member >)dgvListOk.DataSource;
                List<DB_Talk.Model.m_Member> list = DataTableToModelList(dt);

                int iAdd=0,iAdded = 0;  //添加成功数，已经存在的数
                int iRepeatIP=0;  //IP已经存在的
                int iNotAdd = 0;     //添加失败数
                int iBoxMaxNotAdded = 0;    //到达最大后的用户
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("没有数据可以导入！");
                }
                if (list.Count == 0)
                {
                    throw new Exception("没有合法的数据可以导入！");
                }

                foreach (DB_Talk.Model.m_Member item in list)
                {
                    if (listCount.Count + iAdded >= Global.Params.MaxBoxMemberCount)  //到达最大值
                    {
                        iBoxMaxNotAdded++;
                        sbBoxMaxNotAdded.Append("," + item.i_Number);

                    }
                    else
                    {
                        string strW = " i_Flag=0 and BoxID='" + Global.Params.BoxID + "'";
                        //strW += " and vc_Name='" + item.vc_Name + "'";
                        strW += " and i_Number='" + item.i_Number + "'";

                       

                        bool IsExist = MBoxSDK.ConfigSDK.MBOX_IsSubscriberExist(Global.Params.BoxHandle,(item.i_Number.Value));
                        CommControl.Tools.WriteLog.AppendLog("box添加号码", "boxHandle：" + Global.Params.BoxHandle + ", 号码：" + Convert.ToInt32(item.i_Number.ToString()) + ", 是否存在：" + IsExist);
          
                        if (bll.Exists(strW) || IsExist)
                            //MBoxSDK.ConfigSDK.MBOX_IsSubscriberExist(Global.Params.BoxHandle, Convert.ToInt32(item.i_Number.ToString())))
                        {
                            iAdded++;
                            sbAdded.Append("," + item.i_Number);//.vc_Name);
                        }
                        else if (item.i_TellType.Value == PublicEnums.EnumTelType.广播.GetHashCode() &&
                          _BLL.GetModelList(string.Format(" i_flag=0 and  vc_IP='{0}' and BoxID='{1}'", item.vc_IP, item.BoxID)).Count > 0)
                        {
                           //(string.Format("数据库中IP【{0}】已存在!", item.i_Number)
                            iRepeatIP++;
                        }
                        else
                        {
                            item.i_supplementSerive = (int)(MBoxSDK.ConfigSDK.SPM_MISS_CALL |
                                                            MBoxSDK.ConfigSDK.SPM_MISS_CALL_ON_BUSY |
                                                            MBoxSDK.ConfigSDK.SPM_SMS |
                                                            MBoxSDK.ConfigSDK.SPM_THREE_PARTY |
                                                            MBoxSDK.ConfigSDK.SPM_CALL_WAITING |
                                                            MBoxSDK.ConfigSDK.SPM_CALL_TRANSFER); // |
                                                           // MBoxSDK.ConfigSDK.SPM_CALL_PICKUP);
                            bool create= new frmMember(null, 0).AddBase(item);
                            //bool create =  MBoxSDK.ConfigSDK.MBOX_CreateSubscriber(Global.Params.BoxHandle,ref subscriberBase);
                            if (create)
                            //MBoxSDK.ConfigSDK.MBOX_CreateSubscriber(Global.Params.BoxHandle, Convert.ToInt32(item.i_Number.ToString())))
                            {
                                listAdd.Add(item);
                                //bll.Add(item);
                                //CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Add, "导入", "导入了人员：" + item.vc_Name, "");
                                sbAdd.Append("," + item.i_Number);

                                iAdd++;
                                procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      用户【" + item.vc_Name + "】正在写入硬件，请稍等...");
                            }
                            else
                            {
                                sbNotAdd.Append("," + item.i_Number); //.vc_Name);
                                iNotAdd++;

                            }
                        }
                    }
                }
                string mes = "";
                bool bSave = false;
                if (iAdd > 0)
                {
                    TimeSpan sp = new TimeSpan(0);
                    DateTime dtstart = System.DateTime.Now;
                    bSave = MBoxSDK.ConfigSDK.MBOX_SaveHaveDoneCfg(Global.Params.BoxHandle); //保存更改
                    DateTime dtEnd = System.DateTime.Now;
                    if (bSave)
                    {
                        sp = dtEnd - dtstart;
                        //CommControl.MessageBoxEx.MessageBoxEx.Show(sp.TotalMilliseconds.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //sbAdd.Remove(0, 1);
                }
                if (bSave)
                {
                    foreach (DB_Talk.Model.m_Member item in listAdd)
                    {
                        procDlg.Show(Bestway.Windows.Forms.EnumDisplayType.LoadData, "      用户【" + item.vc_Name + "】加入数据库，请稍等...");
                     
                        bll.Add(item);
                        CommControl.SystemLogBLL.WriteLog(Global.Params.UserID, Global.Params.BoxID, CommControl.SystemLogBLL.EnumLogAction.Add, "导入", "导入了人员：" + item.vc_Name, "");
                    }
                           
                    if (iAdd > 10)
                    {
                        mes = "共导入【" + iAdd + "】个用户！\r\n";
                    }
                    else if (iAdd > 0 && iAdd <= 10)
                    {
                        sbAdd.Remove(0, 1);
                        mes = "号码【" + sbAdd.ToString() + "】导入成功！\r\n";
                    }

                }
                else if (iAdd!=0)
                {
                    mes = "保存硬件配置失败！\r\n";
                }

                if (iNotAdd > 10)
                {
                    mes += "【" + iNotAdd + "】个号码写入硬件失败！\r\n";
                }
                else if (iNotAdd > 0 && iNotAdd <= 10)
                {
                    sbNotAdd.Remove(0, 1);
                    mes += "号码【" + sbNotAdd.ToString() + "】写入硬件失败！\r\n";
                }

                if (iAdded > 10)
                {
                    mes += "【" + iAdded + "】个号码已经存在，不再导入！\r\n";
                }
                else if (iAdded > 0 && iAdded <= 10)
                {
                    sbAdded.Remove(0, 1);
                    mes += "号码【" + sbAdded.ToString() + "】已经存在，不再导入！\r\n";
                }
                if(iBoxMaxNotAdded>5)
                {
                    mes += "设备中号码已经达到最大值，【" + iBoxMaxNotAdded + "】个号码，不再导入！";
                }
                else if (iBoxMaxNotAdded > 0 && iBoxMaxNotAdded <= 5)
                {
                    sbBoxMaxNotAdded.Remove(0, 1);
                    mes += "设备中号码已经达到最大值，号码【" + sbBoxMaxNotAdded + "】，不再导入！";
                }
                if (iRepeatIP>0)
                {
                    mes += "【" + iRepeatIP + "】个重复IP，不再导入！";
                }

                procDlg.Dispose();
                if (mes.Length > 0)
                {
                    CommControl.MessageBoxEx.MessageBoxEx.Show(mes, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                procDlg.Dispose();
                CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
            
           
         }

        void t_Tick(object sender, EventArgs e)
        {
            Timer t = (Timer)sender;
            t.Stop();
            CommControl.MessageBoxEx.MessageBoxEx.HideWin();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string GetFilePath()
        {
            try
            {
                string path = "";
                OpenFileDialog fileopen = new OpenFileDialog();
                //fileopen.Filter = "Execl 2007 (*.xlsx)|*.xlsx|Execl 97-2003 (*.xls)|*.xls";
                fileopen.Filter = "Execl文件(*.xlsx;*.xls)|*.xlsx;*.xls";
                //视频文件(*.avi;*.wmv;*.dat;*.mpg;*.mpeg;*.mov;*.wm;*.wma)|*.
                //(*.jpg;*.jpg;*.jpeg;*.gif;*.png)|*.jpg;*.jpeg;*.gif;*.png
                fileopen.AddExtension = true;
                fileopen.Title = "打开文件";
                if (fileopen.ShowDialog() == DialogResult.OK)
                {
                    path = fileopen.FileName.ToString();
                }
                return path;
            }
            catch
            {
                return "";
            }
           
        }

        /// < summary>    
        /// 根据excel的文件的路径提取其中表的数据   
        /// /// < /summary>   
        /// /// < param name="Path">Excel文件的路径< /param>  
        private void GetDataFromExcelWithAppointSheetName(string Path)
        {
            try
            {
                //strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";

                //备注： "HDR=yes;"是说Excel文件的第一行是列名而不是数据，"HDR=No;"正好与前面的相反。
                //"IMEX=1 "如果列中的数据类型不一致，使用"IMEX=1"可必免数据类型冲突。
                strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + Path + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'"; //此连接可以操作.xls与.xlsx文件 (支持Excel2003 和 Excel2007 的连接字符串)

                conn = new OleDbConnection(strConn);
                conn.Open();
                //返回Excel的架构，包括各个sheet表的名称,类型，创建时间和修改时间等    
                DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                //包含excel中表名的字符串数组  
                string[] strTableNames = new string[dtSheetName.Rows.Count];
                for (int k = 0; k < dtSheetName.Rows.Count; k++)
                {
                    strTableNames[k] = dtSheetName.Rows[k]["TABLE_NAME"].ToString();
                }
                
                cmbSheets.DataSource = null;
                cmbSheets.Items.Clear();
                cmbSheets.DataSource = strTableNames;
                if (strTableNames.Length == 0)
                {
                    cmbSheets.DataSource = null;
                    cmbSheets.Items.Add(" ");
                }
            }
            catch(Exception ex)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
            }

        }

        public List<DB_Talk.Model.m_Member> DataTableToModelList(DataTable dt)
        {
            List<DB_Talk.Model.m_Member> lst = new List<DB_Talk.Model.m_Member>();
            StringBuilder sb = new StringBuilder();
            if (!dt.Columns.Contains("用户姓名"))
            {
                sb.Append(",用户姓名");
            }
            else if (!dt.Columns.Contains("电话号码"))
            {
                sb.Append(",电话号码");
            }
            else if (!dt.Columns.Contains("部门"))
            {
                sb.Append(",部门");
            }
            else if (!dt.Columns.Contains("用户权限"))
            {
                sb.Append(",用户权限");
            }
            else if (!dt.Columns.Contains("电话类型"))
            {
                sb.Append(",电话类型");
            }
            else if (!dt.Columns.Contains("标示码"))
            {
                sb.Append(",标示码");
            }
            else if (!dt.Columns.Contains("广播IP"))
            {
                sb.Append(",广播IP");
            }
            if (sb.Length > 0)
            {
                sb.Remove(0, 1);
                throw new Exception("Excel表单中缺少列【"+sb.ToString()+"】");

            }
            foreach (DataRow row in dt.Rows)
            {
                DB_Talk.Model.m_Member m = DataRowToModel(row);
                if(m!=null) lst.Add(m);
            }
           
            return lst;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DB_Talk.Model.m_Member DataRowToModel(DataRow row)
        {
            DB_Talk.Model.m_Member model = new DB_Talk.Model.m_Member();
            if (row != null)
            {
                try
                {
                    model.BoxID = Global.Params.BoxID;
                    //model.NumberTypeID = 4;// CommControl.PublicEnums.EnumNumberType.SIP.GetHashCode();
                    //姓名
                    string strName = row["用户姓名"].ToString().Replace(" ", "");
                    bool CheckLen = strName.Length <=  Global.Params.ConfigModel.SystemConfig.MaxNameTextLengh;
                    if (Global.Params.ConfigModel.SystemConfig.MaxNameTextLengh == 0)
                        CheckLen = true;

                    if (row["用户姓名"] != null && strName != "" &&
                        CheckLen && 
                        checkFormat(false, ref strName, false))
                    {
                        model.vc_Name = strName;
                    }
                    else
                    {
                        return model=null;
                    }

                    //电话
                    string strTel = row["电话号码"].ToString().Replace(" ","");
                    if (row["电话号码"] != null && strTel != "" &&
                        strTel.Length == Global.Params.NumberLen &&
                        checkFormat(true, ref strTel, false))
                    {
                        string str = strTel.Trim().Substring(0, 1);
                        if (Global.Params.strNumHead.IndexOf(str) < 0)
                        {
                            return model = null;
                        }
                        model.i_Number = int.Parse(strTel);

                    }
                    else
                    {
                        return model = null;
                    }
                    if (model.i_Number > Math.Pow(10, Global.Params.NumberLen) - 1) return model = null;

                    //部门
                    string strDept = row["部门"].ToString().Replace(" ", "");
                    if (row["部门"] != null && strDept != "" && strDept.Length <= 10)
                    {
                       
                        DB_Talk.Model.m_Departments modelDept = new DB_Talk.BLL.m_Departments().GetModel("i_Flag=0 and vc_Name='" + strDept + "'");
                        if (modelDept != null)
                            model.DepartmentID = modelDept.ID;
                        else  //无部门时添加部门
                        {
                            modelDept = new DB_Talk.Model.m_Departments();
                            modelDept.vc_Name = strDept;
                            model.DepartmentID = new DB_Talk.BLL.m_Departments().Add(modelDept, true);
                        }
                    }
                    

                    //用户权限
                    if (row["用户权限"] != null && row["用户权限"].ToString() != "")
                    {
                        string strAuthority = row["用户权限"].ToString().Replace(" ", "");
                        switch (strAuthority)
                        {
                            case "国际长途":
                                model.i_Authority = 0;
                                break;
                            case "国内长途":
                                model.i_Authority = 1;
                                break;
                            case "市话":
                                model.i_Authority = 2;
                                break;
                            case "内部分机":
                                model.i_Authority = 3;
                                break;
                            case "禁止主叫":
                                model.i_Authority = 4;
                                break;

                            default:
                                return model = null;
                        }
                    }
                    else
                    {
                        return model = null;
                    }

                    //号码类型
                    if (row["电话类型"] != null && row["电话类型"].ToString() != "")
                    {
                        string strTellType = row["电话类型"].ToString().Replace(" ", "").ToUpper();
                        switch (strTellType)
                        {
                            case "WIFI手机":
                                model.i_TellType = PublicEnums.EnumTelType.WiFi手机.GetHashCode();
                                model.NumberTypeID = PublicEnums.EnumNumberType.手机Wifi.GetHashCode();
                                model.i_NuPasswordType = PublicEnums.EnumTelPasswordType.增加.GetHashCode();
                                model.i_NuPassword = (uint)model.i_Number;
                                break;
                            case "3G手机":
                                if (Global.Params.BoxType == MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000_3G)  //目前只有800B支持3G)
                                {
                                    model.i_TellType = PublicEnums.EnumTelType.G3G手机.GetHashCode();
                                    model.NumberTypeID = PublicEnums.EnumNumberType.手机3G.GetHashCode();
                                    if (row["标示码"] != null && row["标示码"].ToString() != "")
                                    {
                                        string strUmtsImsi = row["标示码"].ToString().Replace(" ", "");
                                        if (strUmtsImsi.Length == Global.Params.UmtsImsiLen)
                                            model.vc_UmtsImsi = strUmtsImsi;
                                        else
                                            return model = null;
                                    }
                                }
                                else
                                {
                                    return model = null;
                                }
                              
                                break;
                            case "固话":  //wifi和固话 默认密码为增加模式 与号码相同
                                 model.i_TellType = PublicEnums.EnumTelType.固话.GetHashCode();
                                 model.NumberTypeID = PublicEnums.EnumNumberType.固话.GetHashCode();
                                 model.i_NuPasswordType = PublicEnums.EnumTelPasswordType.增加.GetHashCode();
                                 model.i_NuPassword = (uint)model.i_Number;
                                break;
                            case "广播":  //wifi和固话 默认密码为增加模式 与号码相同
                                model.i_TellType = PublicEnums.EnumTelType.广播.GetHashCode();
                                model.NumberTypeID = PublicEnums.EnumNumberType.固话.GetHashCode();  //固话、wifi手机、广播=4
                                model.i_NuPasswordType = PublicEnums.EnumTelPasswordType.增加.GetHashCode();
                                model.i_NuPassword = (uint)model.i_Number;
                                if (row["广播IP"] != null && row["广播IP"].ToString() != "")
                                {
                                    string strIP = row["广播IP"].ToString().Replace(" ", "");
                                    if (Global.Methods.checkIP(strIP))
                                    {
                                        model.vc_IP = strIP;
                                    }
                                    else
                                        return model = null;
                                }
                                break;
                            default:
                                return model = null;
                        }
                    }
                    else
                    {
                        return model = null;
                    }
                    //if (model.i_Number < Math.Pow(10, Global.Params.NumberLen-1) - 1) return model = null;
                }
                catch
                {
                    model = null;
                }
            }
            return model;
        }

        //判断本机是否安装Excel文件方法
        private bool codeboolisExcelInstalled()
        {
            Type type = Type.GetTypeFromProgID("Excel.Application");
            return type != null;
        }

        /// <summary>
        /// 验证字符串是否 匹配数字、字母、汉字
        /// </summary>
        /// <param name="isNumber">是否匹配数字</param>
        /// <param name="str">输入的字符串</param>
        /// <param name="IsReturn">是否需要返回忽略特殊字符的字符串</param>
        /// <returns></returns>
        private bool checkFormat(bool IsNumber, ref string str, bool IsReturn)
        {
            bool result = false;
            string regex = "^[0-9]*$";  //匹配数字 
            if (!IsNumber) regex = @"^[\w ]+$"; //匹配数字、字母、汉字
            var reg = new System.Text.RegularExpressions.Regex(regex);// 
            //var str = this.Text.Replace(" ", "");
            var sb = new StringBuilder();
            if (reg.IsMatch(str))
            {
                result = true;
            }
            else
            {
                if (IsReturn)
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (reg.IsMatch(str[i].ToString()))
                        {
                            sb.Append(str[i].ToString());
                        }
                    }
                    str = sb.ToString();
                }
            }
            return result;
        }
    
    

    }
}
