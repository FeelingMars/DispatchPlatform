using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommControl;

namespace DispatchPlatform
{
    public partial class TalkLog : Form
    {
        public TalkLog()
        {
            InitializeComponent();
            this.Shown += new EventHandler(TalkLog_Shown);
        }

        void TalkLog_Shown(object sender, EventArgs e)
        {
            GetTalkLog();
        }

        /// <summary>得到通话记录</summary>
        private void GetTalkLog()
        {

            DateTime begin = DateTime.Now.AddDays(-Pub._configModel.TalkLogSearchDays);//一个月之前
            DateTime end = DateTime.Now;

            string strSQL = string.Format(
                "boxid={0} and managerID={1} and (DispatchTypeID={2} or DispatchTypeID={3} or DispatchTypeID={4}) and  dt_datetime>='{5}' and  dt_datetime<='{6}'",
                Pub.manageModel.BoxID,
                Pub.manageModel.ID,
                CommControl.PublicEnums.EnumNormalCmd.Call.GetHashCode(),
                CommControl.PublicEnums.EnumNormalCmd.SelectAnser.GetHashCode(),
                 CommControl.PublicEnums.EnumNormalCmd.SelectLemcAnser.GetHashCode(),
                 begin,
                 end
                );
            dgvCalled.Rows.Clear();
            dgvNoDoneCall.Rows.Clear();
            dgvDoneCall.Rows.Clear();
            StringBuilder sb = new StringBuilder();
            List<DB_Talk.Model.Data_DispatchLog> lstLog = new DB_Talk.BLL.Data_DispatchLog().GetModelListByCount(3000, strSQL, "id desc");
            for (int i = lstLog.Count - 1; i >= 0; i--)
            {
                DB_Talk.Model.Data_DispatchLog item = lstLog[i];

             //   sb.Clear();
                
                string dispatchName = Pub.GetDispatchNameByNumber(item.DispatchNumber);
                CommControl.PublicEnums.EnumNormalCmd type = (CommControl.PublicEnums.EnumNormalCmd)item.DispatchTypeID;
                string memerbName = GetMemberName(item.DispatchedNumbers);
                switch (type)
                {
                    case PublicEnums.EnumNormalCmd.None:
                        break;
                    case PublicEnums.EnumNormalCmd.Call:
                        //if (item.i_Result == 1)
                        //{
                        //    sb.Append(string.Format("{0}拨打{1}成功", dispatchName, item.DispatchedNumbers));
                        //}
                        //else
                        //{
                        //    sb.Append(string.Format("{0}拨打{1}失败", dispatchName, item.DispatchedNumbers));
                        //}
                        dgvCalled.Rows.Insert(0,memerbName, item.DispatchedNumbers, item.dt_DateTime);
                        break;
                    case PublicEnums.EnumNormalCmd.SelectAnser:
                        if (item.i_Result == 1)
                        {
                            //sb.Append(string.Format("{0}接听{1}成功", dispatchName, item.DispatchedNumbers));
                            dgvDoneCall.Rows.Insert(0, memerbName, item.DispatchedNumbers, item.dt_DateTime);
                        }
                        else
                        {
                            // sb.Append(string.Format("{0}接听{1}失败", dispatchName, item.DispatchedNumbers));

                            dgvNoDoneCall.Rows.Insert(0, memerbName, item.DispatchedNumbers, item.dt_DateTime);
                        }
                        break;
                    case PublicEnums.EnumNormalCmd.SelectLemcAnser:
                        if (item.i_Result == 1)
                        {
                            dgvDoneCall.Rows.Insert(0, memerbName, item.DispatchedNumbers, item.dt_DateTime);
                            //sb.Append(string.Format("{0}接听紧急{1}成功", dispatchName, item.DispatchedNumbers));
                        }
                        else
                        {
                            // sb.Append(string.Format("{0}接听紧急{1}失败", dispatchName, item.DispatchedNumbers));
                            dgvNoDoneCall.Rows.Insert(0, memerbName, item.DispatchedNumbers, item.dt_DateTime);
                        }
                        break;
                    default:
                        break;
                }
                if (sb.Length > 0)
                {
                    //  logTalk.AddMsgNoDateTime(sb.ToString(), item.dt_DateTime.Value);
                }
            }
            if (dgvCalled.Rows.Count>0)
            {
                dgvCalled.CurrentCell = dgvCalled.Rows[0].Cells[0];    
            }

            if (dgvNoDoneCall.Rows.Count > 0)
            {
                dgvNoDoneCall.CurrentCell = dgvNoDoneCall.Rows[0].Cells[0];
            }

            if (dgvDoneCall.Rows.Count > 0)
            {
                dgvDoneCall.CurrentCell = dgvDoneCall.Rows[0].Cells[0];
            }
            
        }

        private string GetMemberName(string number)
        {
            int n = 0;
            try
            {
                n = int.Parse(number);
            }
            catch (Exception)
            {
                return "外线";
            }
            SingleUserControl sc = Pub._memberManage.GetSingleControl(n);
            if (sc != null)
            {
                return sc.MemberName;
            }
            else
            {
                return "外线";
            }
        }

        private void superTabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataGridView dgv = new DataGridView();



        private void MoveDgv(bool isDown)
        {
            if (dgvCalled.Visible == true)
            {
                dgv = dgvCalled;
            }

            if (dgvDoneCall.Visible == true)
            {
                dgv = dgvDoneCall;
            }

            if (dgvNoDoneCall.Visible == true)
            {
                dgv = dgvNoDoneCall;
            }

            if (isDown)
            {
                if (dgv.CurrentRow!=null && dgv.CurrentRow.Index < dgv.Rows.Count - 1)
                {
                    dgv.CurrentCell = dgv.Rows[dgv.CurrentRow.Index + 1].Cells[0];
                }
            }
            else
            {
                if (dgv.CurrentRow != null && dgv.CurrentRow.Index > 0)
                {
                    dgv.CurrentCell = dgv.Rows[dgv.CurrentRow.Index - 1].Cells[0];
                }
            }

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveDgv(false);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveDgv(true);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetTalkLog();
        }

    }
}
