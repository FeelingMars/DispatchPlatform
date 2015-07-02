using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl.MessageBoxEx;

namespace DispatchPlatform
{
    public partial class FormSelectBox : Form
    {
        private Bestway.Windows.Controls.InputPromptDialog _boxBox = new Bestway.Windows.Controls.InputPromptDialog();
        public FormSelectBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载Box列表
        /// </summary>
        public bool LoadBoxList()
        {
            if (Pub._configModel.BoxIP == "")
            {
               // DataSet dsBox = new DB_Talk.BLL.m_Box().GetListEx("id in (" + Pub.manageModel.vc_BoxID + ")");
                DataSet dsBox = new DB_Talk.BLL.m_Box().GetListEx("i_flag=0");
                int[] hideTypeCol = { 1 };
                if (dsBox != null && dsBox.Tables[0].Rows.Count > 0)
                {
                    _boxBox.Bind(this.cboSensorType.txtValue, dsBox.Tables[0], 2, hideTypeCol);
                    this.cboSensorType.OnDropDown += new EventHandler(cboSensorType_OnDropDown);
                    _boxBox.OnTextChangedEx += new Bestway.Windows.Controls.InputPromptDialog.TextChangedEx(_sensorTypeBox_OnTextChangedEx);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                List<DB_Talk.Model.m_Box> lstBox = new DB_Talk.BLL.m_Box().GetModelList("i_Flag=0 and vc_IP='" + Pub._configModel.BoxIP + "'");
                if (lstBox != null && lstBox.Count > 0)
                {
                    Pub.manageModel.BoxID = lstBox[0].ID;
                    return false ;
                }
                else
                {
                    //MessageBoxEx.Show("输入的设备IP不正确(" + Pub._configModel.BoxIP + ")", "提示");
                    //this.Close();
                    Pub._configModel.BoxIP = "";
                    return LoadBoxList();
                }
            }
        }

        void _sensorTypeBox_OnTextChangedEx(object sender, Bestway.Windows.Controls.InputPromptDialog.TextChanagedEventArgs e)
        {
            if (e.IsFind)
            {
                Pub.manageModel.BoxID =int.Parse( e.SelectedRow["ID"].ToString());
                Pub._configModel.BoxIP = e.SelectedRow["IP地址"].ToString();
                Config.WriteModel(Pub._configModel);
            }
        }

        void cboSensorType_OnDropDown(object sender, EventArgs e)
        {
            _boxBox.ShowDropDown();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Pub.manageModel.BoxID != null)
            {
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("请选择调度交换机", "提示");
            }
        }
       
    }
}
