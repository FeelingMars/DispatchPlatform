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
    public partial class frmUserManageMDI : frmBase
    {
        
        public frmUserManageMDI()
        {
            InitializeComponent();
        
            this.Load += new EventHandler(frmUserManage1_Load);
            this.FormClosing += new FormClosingEventHandler(frmUserManage1_FormClosing);               
            
        }

        void frmUserManage1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frm.IsUpdateBox == true)
                this.DialogResult = DialogResult.OK;
        }

        frmUserManage frm = new frmUserManage();
        void frmUserManage1_Load(object sender, EventArgs e)
        {
           
            frm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(frm);
           
            tslState.Text = "  共" + frm.dgvList.Rows.Count.ToString() + "个系统用户";
        }
    }
}
