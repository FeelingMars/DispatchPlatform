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
    public partial class frmFapMemberList : frmBase
    {
        private int _fapID = 0;

        public frmFapMemberList(int fapID)
        {
            InitializeComponent();
            _fapID = fapID;
            this.Load += new EventHandler(frmFapMemberList_Load);
        }

        void frmFapMemberList_Load(object sender, EventArgs e)
        {
            List<DB_Talk.Model.m_Member> lstMemeber = new DB_Talk.BLL.m_Member().GetModelList(string.Format("i_Flag=0 and FapID={0} and BoxID={1}", _fapID, Global.Params.BoxID));
            
            foreach (DB_Talk.Model.m_Member item in lstMemeber)
            {
                dgvList.Rows.Add(item.i_Number, item.vc_Name);
            }
            tsbState.Text =string.Format("共{0}个手机",
                dgvList.Rows.Count.ToString());
        }



      

    }
}
