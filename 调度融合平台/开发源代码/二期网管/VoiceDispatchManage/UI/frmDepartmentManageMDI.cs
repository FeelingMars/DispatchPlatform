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
    public partial class frmDepartmentManageMDI : frmBase
    {
        public frmDepartmentManageMDI()
        {
            InitializeComponent();
            this.FormTitle = "部门管理";
            this.Load += new EventHandler(frmMDI_Load);
        }

        void frmMDI_Load(object sender, EventArgs e)
        {
            frmDepartmentManage frm = new frmDepartmentManage();
            frm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(frm);
          //  tslState.Text = "  共" + frm.dgvList.Rows.Count.ToString() + "个部门";
        }
    }
}
