using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DispatchPlatform;

namespace DispatchPlatform.Control
{
    public partial class WaitControl : UserControl
    {
        private List<WaitButton> _lstButton = new List<WaitButton>();

        public class SelectEventArgs : EventArgs
        {
            public CommControl.PublicEnums.EnumWaitType Type { get; set; }

            public long Number { get; set; }
        }

        public delegate void SelectWaitDelgate(object obj, SelectEventArgs e);
        public event SelectWaitDelgate OnSelect;
        private bool _showTitle = true;
        public bool ShowTitle
        {
            get { return _showTitle; }
            set
            {
                _showTitle = value;
                //panel2.Visible = _showTitle;
            }
        }

        /// <summary>等待的数量</summary>
        public int WaitUserCount { get { return this.panelBox.Controls.Count; }  }

        public WaitControl()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            InitializeComponent();
            timer1.Enabled = false;
            timer1.Interval = 1000;
        }

        public void AddNormalWait(long number)
        {
            if (_lstButton.Exists(w=> w.Number == number) == false)
            {
                string tt = "";
                SingleUserControl sc = Pub._memberManage.GetSingleControl(number);
                if (sc != null)
                {
                    tt = sc.MemberName;
                }
                else
                {
                    tt = "外线号码";
                }
           
                _lstButton.Add(new WaitButton()
                {
                    Number = number,
                    LeveID = GetLevelID(number) ,//人为加大,
                    buton = CreateButton(number, tt, CommControl.PublicEnums.EnumWaitType.Normal)
                });
                ShowButton();
                timer1.Enabled = true;
            }
        }

        /// <summary>
        /// 查找这个号码在不在
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool NumberIsExits(long number)
        {
            WaitButton bb = _lstButton.Find(w => w.Number == number);
            if (bb != null)
            {
                return true;
            }
            return false;
        }


        private int GetLevelID(long number)
        {
            SingleUserControl s = Pub._memberManage.GetSingleControl(number);
            int lid = 999;//为了在最后面显示
            if (s != null)
            {
                if (s.MemberLevel!=null && s.MemberLevel>0)
                {
                    lid = s.MemberLevel;
                }
            }
            return lid;
        }

        public void DeleteWait(long number)
        {
            WaitButton bb = _lstButton.Find(w=> w.Number == number);
            if (bb != null)
            {
                _lstButton.Remove(bb);
                Pub._meetingManage.UpdateMemberAlarmState(number, false );
                Pub._memberManage.UpdateMemberAlarmState(number, false );
                if (IsCanStopMusic())
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();    
                }
            }
            ShowButton();
        }


        public void DeleteAllMember()
        {
            for (int i = _lstButton.Count - 1; i >= 0; i--)
            {
                DeleteWait(_lstButton[i].Number);
            }
        }

        private bool IsCanStopMusic()
        {
            foreach (WaitButton item in _lstButton)
            {
                ButtonData bd = (ButtonData)item.buton.Tag;
                if (bd.WaitType == CommControl.PublicEnums.EnumWaitType.Lemc)
                {
                    return false;                    
                }
            }
            return true;
        }

        //public void AddLemcWait(int number)
        //{
        //    if (_lstButton.Exists(w=> w.Number == number) == false)
        //    {
        //        string tt = "";
        //        SingleUserControl sc = Pub._memberManage.GetSingleControl(number);
        //        if (sc!=null)
        //        {
        //            tt = sc.MemberName;
        //        }
        //        _lstButton.Add(new WaitButton()
        //        {
        //            Number = number,
        //            LeveID = GetLevelID(number),
        //            buton = CreateButton(number, tt, CommControl.PublicEnums.EnumWaitType.Lemc)
        //        });
        //        axWindowsMediaPlayer1.URL = Pub._configModel.AlarmMusicUrl;
        //        axWindowsMediaPlayer1.settings.setMode("loop", true);
        //        axWindowsMediaPlayer1.Ctlcontrols.play();

        //        Pub._meetingManage.UpdateMemberAlarmState(number, true);
        //        Pub._memberManage.UpdateMemberAlarmState(number, true);
        //        ShowButton();
        //        timer1.Enabled = true;
        //    }
        //}

        private ButtonX CreateButton(long number, string name, CommControl.PublicEnums.EnumWaitType type)
        {
            ButtonX b = new ButtonX();
            b.Text = name + " " + number.ToString();
            b.Image = DispatchPlatform.Properties.Resources.NormalWait;
            b.Dock = DockStyle.Top;
            b.BackColor = Color.Transparent;
            b.ColorTable = eButtonColor.Magenta;
            b.HotTrackingStyle = eHotTrackingStyle.None;
            b.FocusCuesEnabled = false;
            ButtonData bd = new ButtonData()
            {
                Number = number,
                WaitType = type
            };
            b.Tag = bd;
            b.BackgroundImage = DispatchPlatform.Properties.Resources.WaitItemBackGound;
            b.Height = 48;
            switch (type)
            {
                case CommControl.PublicEnums.EnumWaitType.Normal:
                    b.Image = DispatchPlatform.Properties.Resources.NormalWait;
                    b.ForeColor = Color.White;
                    break;
                case CommControl.PublicEnums.EnumWaitType.Lemc:
                    b.Image = DispatchPlatform.Properties.Resources.LemcWait;
                    b.ForeColor = Color.FromArgb(255,169,146);
                    break;
                default:
                    break;
            }
            b.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
          
            b.Location = new System.Drawing.Point(201, 214);
           // b.Size = new System.Drawing.Size(75, 23);
            b.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            b.Click += new EventHandler(b_Click);
            return b;
        }

        void b_Click(object sender, EventArgs e)
        {
            if (OnSelect != null)
            {
                ButtonX b = (ButtonX)sender;
                ButtonData bd = (ButtonData)b.Tag;
                OnSelect(sender, new SelectEventArgs()
                {
                    Number = bd.Number,
                    Type = bd.WaitType
                });
            }
        }

        /// <summary>
        /// 自动触发接通紧急号码事件
        /// </summary>
        /// <returns></returns>
        private void FindFirstNeedSelectAnswerRaiseEvent()
        {
            //foreach (WaitButton item in _lstButton)
            //{
            for (int i = _lstButton.Count-1; i>=0 ; i--)
            {
                WaitButton item=_lstButton[i];
            
            if (item.IsCalled == false)
                {
                    b_Click(item.buton, null);
                    item.IsCalled = true;
                }
                if (item.IsCalled == true)
                {
                    item.SleepCount++;
                    if (item.SleepCount >= 30)//30秒后再执行一次接听动作
                    {
                        b_Click(item.buton, null);
                        item.SleepCount = 0;
                    }
                }
            }
        }

        private void ShowButton()
        {
            this.panelBox.Controls.Clear();
            _lstButton.Sort(new LevelComparer());
            foreach (WaitButton item in _lstButton)
            {
                this.panelBox.Controls.Add(item.buton);
            }
        }


        /// <summary>
        /// 重新初始每个号码为没有拨打过
        /// </summary>
        public void ResetCallState()
        {
            foreach (WaitButton item in _lstButton)
            {
                item.IsCalled = false;
            }
        }

        public class WaitButton
        {
            public int LeveID { get; set; }
            public long Number { get; set; }
            public ButtonX buton = new ButtonX();
            /// <summary>
            /// 接听过
            /// </summary>
            public bool IsCalled { get; set; }

            /// <summary>
            /// 等待计时
            /// </summary>
            public int SleepCount { get; set; }
        }


        public class ButtonData
        {
            public long Number { get; set; }

            public CommControl.PublicEnums.EnumWaitType WaitType { get; set; }
        }

        public class LevelComparer : IComparer<WaitButton>
        {
            //重写int比较器，|x|>|y|返回正数，|x|=|y|返回0，|x|<|y|返回负数   
            public int Compare(WaitButton x, WaitButton y)
            {
                return y.LeveID.CompareTo(x.LeveID);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (WaitUserCount==0)
            {
                timer1.Enabled = false;
            }
            FindFirstNeedSelectAnswerRaiseEvent();
        }
    }
}
