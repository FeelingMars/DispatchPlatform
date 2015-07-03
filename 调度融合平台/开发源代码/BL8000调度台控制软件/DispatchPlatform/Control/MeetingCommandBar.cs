using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DispatchPlatform;

namespace DispatchPlatform.Control
{

    public partial class MeetingCommandBar : UserControl
    {
        public delegate void ButtonClick(object sender, CommControl.PublicEnums.EnumNormalCmd cmd);
        public event ButtonClick OnButtonClick;

        public MeetingCommandBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            InitializeComponent();
            InitButton();
            this.OnButtonClick += new ButtonClick(MeetingCommandBar_OnButtonClick);
        }

        void MeetingCommandBar_OnButtonClick(object sender, CommControl.PublicEnums.EnumNormalCmd cmd)
        {
            if (cmd == CommControl.PublicEnums.EnumNormalCmd.MeetingGroupOperate)
            {
                btnMeetingBeginEnd.Checked = false;
            }
        }

        public void ClearSelect()
        {
            btnAddMeetingMember.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnAddMeetingMember.BackgroundImage.Tag = false;
            btnAddMeetingMember.ForeColor = Color.White;


            btnDeleteMeetingMember.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnDeleteMeetingMember.BackgroundImage.Tag = false;
            btnDeleteMeetingMember.ForeColor = Color.White;


            btnBeginRecord.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnBeginRecord.BackgroundImage.Tag = false;
            btnBeginRecord.ForeColor = Color.White;

            btnIsolateMeeting.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnIsolateMeeting.BackgroundImage.Tag = false;
            btnIsolateMeeting.ForeColor = Color.White;


            btnUnIsolateMeeting.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnUnIsolateMeeting.BackgroundImage.Tag = false;
            btnUnIsolateMeeting.ForeColor = Color.White;


            btnOkSpeekMeeting.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnOkSpeekMeeting.BackgroundImage.Tag = false;
            btnOkSpeekMeeting.ForeColor = Color.White;


            btnNoSpeekMeeting.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnNoSpeekMeeting.BackgroundImage.Tag = false;
            btnNoSpeekMeeting.ForeColor = Color.White;


            btnMeetingBeginEnd.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnMeetingBeginEnd.BackgroundImage.Tag = false;
            btnMeetingBeginEnd.ForeColor = Color.White;
        }

        private void InitButton()
        {

            btnAddMeetingMember.Tag = CommControl.PublicEnums.EnumNormalCmd.AddMeetingMember;
            btnAddMeetingMember.BackgroundImage.Tag = false ;
            btnAddMeetingMember.Click += new EventHandler(Button_Click);


            btnDeleteMeetingMember.Tag = CommControl.PublicEnums.EnumNormalCmd.DeleteMeetingMember;
            btnDeleteMeetingMember.BackgroundImage.Tag = false;
            btnDeleteMeetingMember.Click += new EventHandler(Button_Click);


            btnBeginRecord.Tag = CommControl.PublicEnums.EnumNormalCmd.RecordOperate;
            btnBeginRecord.BackgroundImage.Tag = false;
            btnBeginRecord.Click += new EventHandler(Button_Click);

            btnIsolateMeeting.Tag = CommControl.PublicEnums.EnumNormalCmd.IsolateMeeting;
            btnIsolateMeeting.BackgroundImage.Tag = false;
            btnIsolateMeeting.Click += new EventHandler(Button_Click);


            btnUnIsolateMeeting.Tag = CommControl.PublicEnums.EnumNormalCmd.UnIsolateMeeting;
            btnUnIsolateMeeting.BackgroundImage.Tag = false;
            btnUnIsolateMeeting.Click += new EventHandler(Button_Click);


            btnOkSpeekMeeting.Tag = CommControl.PublicEnums.EnumNormalCmd.OkSpeekMeeting;
            btnOkSpeekMeeting.BackgroundImage.Tag = false;
            btnOkSpeekMeeting.Click += new EventHandler(Button_Click);


            btnNoSpeekMeeting.Tag = CommControl.PublicEnums.EnumNormalCmd.NoSpeekMeeting;
            btnNoSpeekMeeting.BackgroundImage.Tag = false;
            btnNoSpeekMeeting.Click += new EventHandler(Button_Click);


            btnMeetingBeginEnd.Tag = CommControl.PublicEnums.EnumNormalCmd.MeetingGroupOperate;
            btnMeetingBeginEnd.BackgroundImage.Tag = false;
            btnMeetingBeginEnd.Click += new EventHandler(Button_Click);
            
        }

        void Button_Click(object sender, EventArgs e)
        {
            
            DevComponents.DotNetBar.ButtonX b = (DevComponents.DotNetBar.ButtonX)sender;

            bool isSelect = (bool)b.BackgroundImage.Tag;
            ClearSelect();
            b.BackgroundImage.Tag = isSelect;
            CommControl.PublicEnums.EnumNormalCmd cmd = (CommControl.PublicEnums.EnumNormalCmd)b.Tag;
            RaiseEvent(sender, cmd);
            if (cmd == CommControl.PublicEnums.EnumNormalCmd.MeetingGroupOperate || cmd == CommControl.PublicEnums.EnumNormalCmd.AddMeetingMember)
            {
                return;
            }
            if ((bool)b.BackgroundImage.Tag == false)
            {
                b.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonSelect;
                b.ForeColor = Color.Black;

                
                b.BackgroundImage.Tag = true;
                //RaiseEvent(sender, cmd); 
            }
            else
            {
                b.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
                b.ForeColor = Color.White;
                b.BackgroundImage.Tag = false;
               // RaiseEvent(sender, CommControl.PublicEnums.EnumNormalCmd.None);
            }
        }

        private void RaiseEvent(object sender, CommControl.PublicEnums.EnumNormalCmd cmd)
        {
            if (OnButtonClick != null)
            {
                OnButtonClick(sender, cmd);
            }
        }

   

        private void buttonX10_Click(object sender, EventArgs e)
        {
            //RaiseEvent(sender, TalkControl.EnumNormalCmd.BeginRecord);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //RaiseEvent(sender, TalkControl.EnumNormalCmd.IsolateMeeting);
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            //RaiseEvent(sender, TalkControl.EnumNormalCmd.UnIsolateMeeting);
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            //RaiseEvent(sender, TalkControl.EnumNormalCmd.NoSpeekMeeting);
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            //RaiseEvent(sender, TalkControl.EnumNormalCmd.OkSpeekMeeting);
        }

        private void btnMeetingBeginEnd_Click(object sender, EventArgs e)
        {
            //RaiseEvent(sender, TalkControl.EnumNormalCmd.MeetingGroup);
        }

        private void btnAddMeetingMember_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteMeetingMember_Click(object sender, EventArgs e)
        {

        }

       
    }
}
