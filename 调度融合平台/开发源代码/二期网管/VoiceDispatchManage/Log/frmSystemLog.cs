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
    public partial class frmSystemLog :frmBase
    {
        private bool _showMsgbox = false;//第一次打开时不显示找不到的对话框
        private string _tableName = "SystemLog";

        public frmSystemLog()
        {
            InitializeComponent();
           
            
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvLog);
            dtTelStart.Value = DateTime.Now.Date;//默认初始查询时间当天0点
            dtTelEnd.Value = DateTime.Now.Date.AddSeconds(86399);//默认查询终止时间当天23:59:59
            dgvLog.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvLog_DataBindingComplete);
            this.Load += new EventHandler(frmSystemLog_Load);

            //this.dgvLog.AutoGenerateColumns = true;

        }

        void frmSystemLog_Load(object sender, EventArgs e)
        {
            btnQuery_Click(null, null);
        }
        void dgvLog_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            tslState.Text = string.Format("共找到{0}条记录", dgvLog.Rows.Count);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (dtTelStart.Value.ToString("yyyy-M-d") == "0001-1-1" || dtTelEnd.Value.ToString("yyyy-M-d") == "0001-1-1")
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("请选择正确的时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dtTelStart.Value = DateTime.Now.Date;//默认初始查询时间当天0点
                dtTelEnd.Value = DateTime.Now.Date.AddSeconds(86399);//默认查询终止时间当天23:59:59
                _showMsgbox = true;
                return;
            }

            if (dtTelStart.Value > dtTelEnd.Value)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("开始时间不能大于结束时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                _showMsgbox = true;
                return;
            }
            else
            {
                try
                {
                    dgvLog.DataSource = null;
                    string strW="i_Flag=0 and dt_datetime>='" + dtTelStart.Value + "' and  dt_datetime<='" + dtTelEnd.Value + "' order by dt_datetime desc";
                    dgvLog.DataSource = new DB_Talk.BLL.v_SystemLogEx().GetList(strW).Tables[0];;
                        //.GetListEx
                        //("dt_datetime>='" + dtTelStart.Value + "' and  dt_datetime<='" + dtTelEnd.Value + "' order by dt_datetime desc").Tables[0];
                    
                    if (_showMsgbox)
                    {
                        if (dgvLog.Rows.Count <= 0)
                        {
                            CommControl.MessageBoxEx.MessageBoxEx.Show("没有找到记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (_showMsgbox)
                    {
                        CommControl.MessageBoxEx.MessageBoxEx.Show(string.Format("错误源:{0}\r\n,错误描述:{1}", ex.Source, ex.Message),
                             "查询失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            _showMsgbox = true;
        }

        private void tsbRefreash_Click(object sender, EventArgs e)
        {
            btnQuery_Click(null, null);
        }

        private void tsbStyle_Click(object sender, EventArgs e)
        {
            BW_GridStyle.GridStyleForm form = new BW_GridStyle.GridStyleForm(_tableName, Global.Params.StyleManager);
            form.ShowDialog();
            Global.Params.StyleManager.SetGridStyle(_tableName, this.dgvLog);
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
