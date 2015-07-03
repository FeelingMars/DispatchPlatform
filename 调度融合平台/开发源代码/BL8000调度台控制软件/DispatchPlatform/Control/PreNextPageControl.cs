using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispatchPlatform
{
    /// <summary>单个普通用户</summary>
    [DefaultEvent("Click")]
    public partial class PreNextPageControl : UserControl
    {
        private EnumType _buttonType;
        public EnumType ButtonType
        {
            get { return _buttonType; }
            set
            {
                _buttonType = value;
                switch (_buttonType)
                {
                    case EnumType.Pre:
                        pictureBox1.Image = DispatchPlatform.Properties.Resources.ArrowLeft;
                       // label1.Text = "上一页";
                        break;
                    case EnumType.Next:
                        pictureBox1.Image = DispatchPlatform.Properties.Resources.ArrowRight;
                       // label1.Text = "下一页";
                        break;
                    default:
                        break;
                }
            }
        }


        /// <summary>
        /// 显示当前页和总共多少页(1/3)
        /// </summary>
        public string PageCount
        {
            get { return lblPageCount.Text; }
            set
            {
                lblPageCount.Text = value;
            }
        }

        public PreNextPageControl()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            InitializeComponent();
            this.VisibleChanged += new EventHandler(PreNextPageControl_VisibleChanged);
        }

        void PreNextPageControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false && Pub.CanDestroyControl == true)
            {
              //  DestroyHandle();
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }

        public enum EnumType
        {
            Pre,
            Next
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }

        private void lblPageCount_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
        }
    }
}
