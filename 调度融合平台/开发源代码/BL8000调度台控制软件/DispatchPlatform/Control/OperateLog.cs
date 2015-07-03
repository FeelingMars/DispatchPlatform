using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispatchPlatform.Control
{
    public partial class OperateLog : UserControl
    {
        private bool _isLog = true;
        public bool IsLog
        {
            get { return _isLog; }
            set
            {
                _isLog = value;
                if (_isLog)
                {
                    label5.Text = "操作日志";
                }
                else
                {
                    label5.Text = "调度通话记录";
                }
            }
        }
        private int _maxRow = 3;

        public OperateLog()
        {
            InitializeComponent();
        }

        /// <summary>后面自己动带时间的,操作日志用</summary>
        /// <param name="msg"></param>
        public void AddMsgAutoAddDateTime(string msg)
        {
            //if (lstMsg.Items.Count > 10)
            //{
            //    lstMsg.Items.RemoveAt(0);
            //    lstMsg.Items.RemoveAt(0);
            //}
            //lstMsg.Items.Add(msg);
            //lstMsg.Items.Add(DateTime.Now.ToString());
            //lstMsg.ClearSelected();

            if (lstMsg.Items.Count > _maxRow)
            {
                lstMsg.Items.RemoveAt(_maxRow);
                lstMsg.Items.RemoveAt(_maxRow-1);
            }
            lstMsg.Items.Insert(0, DateTime.Now.ToString());
            lstMsg.Items.Insert(0,msg);
            lstMsg.ClearSelected();
        }

        /// <summary>
        /// 通话日志用
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="dt"></param>
        public void AddMsgNoDateTime(string msg,DateTime dt)
        {
            //if (lstMsg.Items.Count > 10)
            //{
            //    lstMsg.Items.RemoveAt(0);
            //    lstMsg.Items.RemoveAt(0);
            //}
            //lstMsg.Items.Add(msg);
            //lstMsg.Items.Add(dt.ToString());
            //lstMsg.ClearSelected();

            if (lstMsg.Items.Count > _maxRow)
            {
                lstMsg.Items.RemoveAt(_maxRow);
                lstMsg.Items.RemoveAt(_maxRow-1);
            }

            lstMsg.Items.Insert(0,dt.ToString());
            lstMsg.Items.Insert(0,msg);
            
            lstMsg.ClearSelected();
        }

        private void lstMsg_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstMsg.ClearSelected();
        }
    }
}
