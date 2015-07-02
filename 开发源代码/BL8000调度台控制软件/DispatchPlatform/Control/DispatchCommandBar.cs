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
    public partial class DispatchCommandBar : UserControl
    {
        public delegate void ButtonClick(object sender, CommControl.PublicEnums.EnumNormalCmd cmd);
        public event ButtonClick OnButtonClick;

        public DispatchCommandBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            InitializeComponent();
            InitButton();
        }

        /// <summary>清除选中</summary>
        public void ClearSelect()
        {
            btnCall.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnCall.BackgroundImage.Tag = false  ;
            btnCall.ForeColor = Color.White;

            btnHandup.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnHandup.BackgroundImage.Tag = false;
            btnHandup.ForeColor = Color.White;

            btnInsert.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnInsert.BackgroundImage.Tag = false;
            btnInsert.ForeColor = Color.White;

            btnBreak.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnBreak.BackgroundImage.Tag = false;
            btnBreak.ForeColor = Color.White;

            btnAnaser.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnAnaser.BackgroundImage.Tag = false;
            btnAnaser.ForeColor = Color.White;

            btnJJ.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnJJ.BackgroundImage.Tag = false;
            btnJJ.ForeColor = Color.White;

            btnMeeting.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnMeeting.BackgroundImage.Tag = false;
            btnMeeting.ForeColor = Color.White;

            btnKeep.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnKeep.BackgroundImage.Tag = false;
            btnKeep.ForeColor = Color.White;

            btnListen.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnListen.BackgroundImage.Tag = false;
            btnListen.ForeColor = Color.White;

            btnRecord.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnRecord.BackgroundImage.Tag = false;
            btnRecord.ForeColor = Color.White;

            btnVideoCall.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
            btnVideoCall.BackgroundImage.Tag = false;
            btnVideoCall.ForeColor = Color.White;
        }

        private void InitButton()
        {
            btnGroupCall.Tag = CommControl.PublicEnums.EnumNormalCmd.GroupCall;
            btnGroupCall.BackgroundImage.Tag = false;
            btnGroupCall.Click += new EventHandler(Button_Click);

            btnCall.Tag = CommControl.PublicEnums.EnumNormalCmd.Call;
            btnCall.BackgroundImage.Tag = false;
            btnCall.Click += new EventHandler(Button_Click);


            btnHandup.Tag = CommControl.PublicEnums.EnumNormalCmd.Handup;
            btnHandup.BackgroundImage.Tag = false;
            btnHandup.Click += new EventHandler(Button_Click);


            btnInsert.Tag = CommControl.PublicEnums.EnumNormalCmd.Insert;
            btnInsert.BackgroundImage.Tag = false;
            btnInsert.Click += new EventHandler(Button_Click);

            btnBreak.Tag = CommControl.PublicEnums.EnumNormalCmd.SnatchCall;
            btnBreak.BackgroundImage.Tag = false;
            btnBreak.Click += new EventHandler(Button_Click);

            btnAnaser.Tag = CommControl.PublicEnums.EnumNormalCmd.InsteadAnswer;
            btnAnaser.BackgroundImage.Tag = false;
            btnAnaser.Click += new EventHandler(Button_Click);

            btnJJ.Tag = CommControl.PublicEnums.EnumNormalCmd.Transfer;
            btnJJ.BackgroundImage.Tag = false;
            btnJJ.Click += new EventHandler(Button_Click);

            btnMeeting.Tag = CommControl.PublicEnums.EnumNormalCmd.MakeLemcMeeting;
            btnMeeting.BackgroundImage.Tag = false;
            btnMeeting.Click += new EventHandler(Button_Click);


            btnKeep.Tag = CommControl.PublicEnums.EnumNormalCmd.Keep;
            btnKeep.BackgroundImage.Tag = false;
            btnKeep.Click += new EventHandler(Button_Click);

            btnListen.Tag = CommControl.PublicEnums.EnumNormalCmd.Listen;
            btnListen.BackgroundImage.Tag = false;
            btnListen.Click += new EventHandler(Button_Click);

            btnRecord.Tag = CommControl.PublicEnums.EnumNormalCmd.RecordOperate;
            btnRecord.BackgroundImage.Tag = false;
            btnRecord.Click += new EventHandler(Button_Click);


            btnVideoCall.Tag = CommControl.PublicEnums.EnumNormalCmd.VideoCall;
            btnVideoCall.BackgroundImage.Tag = false;
            btnVideoCall.Click += new EventHandler(Button_Click);
        }

        public void Button_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonX b = (DevComponents.DotNetBar.ButtonX)sender;
            bool isSelect = (bool)b.BackgroundImage.Tag;
            ClearSelect();
            b.BackgroundImage.Tag = isSelect;

            //这部分要测试
            CommControl.PublicEnums.EnumNormalCmd cmd = (CommControl.PublicEnums.EnumNormalCmd)b.Tag;
            //
            if (cmd == CommControl.PublicEnums.EnumNormalCmd.GroupCall)
            {
                RaiseEvent(sender, cmd);
                return;
            }


            if ((bool)b.BackgroundImage.Tag == false)
            {
                b.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonSelect;
                b.ForeColor = Color.Black;
                b.BackgroundImage.Tag = true;
                RaiseEvent(sender, (CommControl.PublicEnums.EnumNormalCmd)b.Tag);
            }
            else
            {
                b.BackgroundImage = DispatchPlatform.Properties.Resources.ButtonBack;
                b.ForeColor = Color.White;
                b.BackgroundImage.Tag = false;
                RaiseEvent(sender, CommControl.PublicEnums.EnumNormalCmd.None);//取消
            }
        }

        private void RaiseEvent(object sender, CommControl.PublicEnums.EnumNormalCmd cmd)
        {
            if (OnButtonClick!=null)
            {
                OnButtonClick(sender, cmd);
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {

        }

  
    }
}
