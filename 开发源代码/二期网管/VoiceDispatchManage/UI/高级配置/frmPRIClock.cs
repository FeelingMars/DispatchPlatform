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
    public partial class frmPRIClock : UserControl
    {
        public frmPRIClock()
        {
            InitializeComponent();
            this.Text = "PRI时钟源配置";
            this.Load += new EventHandler(frmPRIClock_Load);
        }
        int E1Max = 2;
        void frmPRIClock_Load(object sender, EventArgs e)
        {
            this.dgvList.Columns[1].CellTemplate.Style.SelectionBackColor = Color.White;
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("value", typeof(string));

            if (Global.Params.BoxType == MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000B
                || Global.Params.BoxType == MBoxSDK.ConfigSDK.EnumDeviceType.T_HT8000_3G
                ) E1Max = 8;

            dt.Rows.Add(0, "Not used");

            for (int i = 1; i <= E1Max; i++)
            {
                dt.Rows.Add(i, "E1-" + i);
            }
            this.colE1Number.DataSource = dt;
            this.colE1Number.DisplayMember = "value";
            this.colE1Number.ValueMember = "ID";



            DataTable dtType = new DataTable();
            dtType.Columns.Add("ID", typeof(int));
            dtType.Columns.Add("value", typeof(string));


            Type t = typeof(MBoxSDK.ConfigSDK.EnumPriClockType);
            int index=0;
            foreach(string str in Enum.GetNames(t))
            {
                index=Enum.Parse(t, str, true).GetHashCode();
                dtType.Rows.Add(index, str);
            }

            DataView dv = dtType.DefaultView;
            dv.Sort = "ID desc"; // "id Asc,name Desc";
            dtType = dv.ToTable();

            this.colType.DataSource = dtType;
            this.colType.DisplayMember = "value";
            this.colType.ValueMember = "ID";
           
            dgvList.ReadOnly = false;
            dgvList.Columns[1].ReadOnly = true;
            LoadData();

        }



        private void LoadData()
        {
            List<DB_Talk.Model.m_PRIClock> lst = new List<DB_Talk.Model.m_PRIClock>();
            string strWhere = string.Format("i_Flag=0 and BoxID='{0}' order by i_Level", Global.Params.BoxID);
            lst = new DB_Talk.BLL.m_PRIClock().GetModelList(strWhere);
            dgvList.Rows.Clear();

            for (int i = 0; i < lst.Count; i++)
            {
                dgvList.Rows[dgvList.Rows.Add(lst[i].ID,
                                 "级别" + lst[i].i_Level,
                                 lst[i].i_Type,
                                 lst[i].i_Port
                                )].Tag = lst[i];

            }
            dgvList.ClearSelection();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool Result = true;
            DB_Talk.BLL.m_PRIClock bll = new DB_Talk.BLL.m_PRIClock();
            List<DB_Talk.Model.m_PRIClock> lst = new List<DB_Talk.Model.m_PRIClock>();

            try
            {
                lst = getModel();
            }
            catch (Exception ex)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                foreach (DB_Talk.Model.m_PRIClock model in lst)
                {
                    if (Tools.MBoxOperate.SetPriClock(model))
                        bll.Update(model);
                    else
                    {
                        Result = false;
                        CommControl.MessageBoxEx.MessageBoxEx.Show("设置时钟源【" + model.i_Level + "】失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                if (Result)
                    CommControl.MessageBoxEx.MessageBoxEx.Show("设置时钟源成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);


                LoadData();
            }
            catch(Exception ex)
            {
                CommControl.Tools.WriteLog.AppendErrorLog(ex);
            }
        }

        private void btnRefush_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private List<DB_Talk.Model.m_PRIClock> getModel()
        {
            List<DB_Talk.Model.m_PRIClock> lst = new List<DB_Talk.Model.m_PRIClock>();
            for (int i = 0; i < this.dgvList.Rows.Count; i++)
            {
                DB_Talk.Model.m_PRIClock model = new DB_Talk.Model.m_PRIClock();
                DB_Talk.Model.m_PRIClock modelTag = dgvList.Rows[i].Tag as DB_Talk.Model.m_PRIClock;
                if (modelTag != null)
                {
                    model.ID = modelTag.ID;
                    model.i_Level = modelTag.i_Level;
                    model.BoxID = modelTag.BoxID;
                }
                //时钟源类型
                model.i_Type = int.Parse(dgvList.Rows[i].Cells["colType"].Value.ToString());
                //时钟源端口
                if (model.i_Type == MBoxSDK.ConfigSDK.EnumPriClockType.E1.GetHashCode())
                    model.i_Port = int.Parse(dgvList.Rows[i].Cells["colE1Number"].Value.ToString());
                if(model.i_Type == MBoxSDK.ConfigSDK.EnumPriClockType.E1.GetHashCode() &&
                   (model.i_Port==0))
                    throw new Exception("级别为【" + model.i_Level + "】的时钟源未选择正确的E1端口！");

                int portNum = int.Parse(dgvList.Rows[i].Cells["colE1Number"].Value.ToString());
                if (portNum>0 &&  model.i_Type!= MBoxSDK.ConfigSDK.EnumPriClockType.E1.GetHashCode())
                    throw new Exception("级别为【" + model.i_Level + "】的时钟源未选择正确的时钟源类型！");
                lst.Add(model);  
            }

            List<DB_Talk.Model.m_PRIClock> lstTemp = new List<DB_Talk.Model.m_PRIClock>();
            lstTemp = lst.Where(w => w.i_Type ==MBoxSDK.ConfigSDK.EnumPriClockType.无.GetHashCode()).ToList();
            if (lstTemp.Count == 4)
                throw new Exception("4个时钟源类型不能同时为无！");
               // CommControl.MessageBoxEx.MessageBoxEx.Show("4个时钟源类型不能同时为无！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return lst;
            //if(lst)
        }

        private void dgvList_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewCell cellObj = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                switch (dgv.Columns[e.ColumnIndex].Name)
                {
                    case "colType":
                        cellObj.ToolTipText = "点击编辑时钟源类型！";
                        break;
                    case "colE1Number":
                        cellObj.ToolTipText = "点击编辑时钟源端口！";
                        break;
                    default: break;
                }
                dgv = null;
                cellObj = null;
            }
        }
    }
}
