using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DispatchPlatform.Control;

namespace DispatchPlatform
{
    public partial class FormSelectMeetingMember : Form
    {
        private FormMain _frmMain;
        private bool _isRunning;

        public FormSelectMeetingMember(FormMain frmMain,bool isMeetingRunning)
        {
            InitializeComponent();
            _frmMain = frmMain;
            _isRunning = isMeetingRunning;
            this.Load += new EventHandler(FormSelectMeetingMember_Load);
        }

        void FormSelectMeetingMember_Load(object sender, EventArgs e)
        {

            Pub._pageControl._rowCount = 5;
            Pub._pageControl._columnCount = 4;
            Pub._pageControl.GetSingleControlSize();
            #region 手动增加空闲的手柄进待选的成员里

            //从原有的里面删除
            SingleUserControl scA = Pub._pageControl._lstBtn.Find(p => p.Number == _frmMain.cLeft.Number);
            if (scA != null)
            {
                Pub._pageControl._lstBtn.Remove(scA);
            }

            SingleUserControl scB = Pub._pageControl._lstBtn.Find(p => p.Number == _frmMain.cRight.Number);
            if (scB != null)
            {
                Pub._pageControl._lstBtn.Remove(scB);
            }

            if (_isRunning == true )
            {
              

                if (_frmMain.cLeft.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                {
                    SingleUserControl sc = new SingleUserControl();
                    sc.CanSelect = true;
                    sc.Number = _frmMain.cLeft.Number;
                    sc.MemberName = _frmMain.cLeft.MemberName;

                    sc.UserLineStatus = TalkControl.EnumUserLineStatus.Idle;
                    sc.TellType = CommControl.PublicEnums.EnumTelType.固话;
                    sc.Click += new EventHandler(_frmMain.single_Click);

                    if (Pub._pageControl._lstBtn.Exists(p => p.Number == sc.Number) == false)
                    {
                        Pub._pageControl._lstBtn.Insert(0, sc);
                        Pub._pageControl.Init(Pub._pageControl._lstBtn);
                        sc.UserLineStatus = TalkControl.EnumUserLineStatus.Idle;
                    }
                }

               

                if (_frmMain.cRight.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                {
                    SingleUserControl sc = new SingleUserControl();
                    sc.CanSelect = true;
                    sc.Number = _frmMain.cRight.Number;
                    sc.MemberName = _frmMain.cRight.MemberName;
                    sc.Click += new EventHandler(_frmMain.single_Click);
                    sc.UserLineStatus = TalkControl.EnumUserLineStatus.Idle;
                    sc.TellType = CommControl.PublicEnums.EnumTelType.固话;
                    if (Pub._pageControl._lstBtn.Exists(p => p.Number == sc.Number) == false)
                    {
                        Pub._pageControl._lstBtn.Insert(0, sc);
                        Pub._pageControl.Init(Pub._pageControl._lstBtn);
                        sc.UserLineStatus = TalkControl.EnumUserLineStatus.Idle;
                    }
                }
            }

            Pub._pageControl.FilterMemberForMeeting(EnumFilterType.CanMakeCall);
            #endregion

            if (Pub._pageControl.GetVisibleTrueCount() <= 0)
            {
                CommControl.MessageBoxEx.MessageBoxEx.Show("没有可选用户", "选择会议成员");
                this.DialogResult = System.Windows.Forms.DialogResult.No;
                this.Close();
            }
        }

        protected override void CreateHandle()
        {
            if (!IsHandleCreated)
            {
                try
                {
                    base.CreateHandle();
                }
                catch { }
                finally
                {
                    if (!IsHandleCreated)
                    {
                        base.RecreateHandle();
                    }
                }
            }
        }  

        public void AddPageControl(PageControl pc)
        {
            this.panelMain.Controls.Add(pc);
            pc.Width = panelMain.Width;
            pc.Height = panelMain.Height;
            pc.Dock = DockStyle.Fill;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

    }
}
