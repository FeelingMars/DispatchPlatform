using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DispatchPlatform.Control;

namespace DispatchPlatform
{
    public partial class FormLemcWait : Form
    {
        private List<LemcMemberControl> _lstButton = new List<LemcMemberControl>();

        public class SelectEventArgs : EventArgs
        {
            public long Number { get; set; }
        }

        public delegate void SelectWaitDelgate(object obj, SelectEventArgs e);
        public event SelectWaitDelgate OnSelect;

        /// <summary>
        /// 等待的数量
        /// </summary>
        public int WaitUserCount { get { return this.panelBox.Controls.Count; }  }

        public FormLemcWait()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            InitializeComponent();
            timer1.Enabled = false;
            timer1.Interval = 1000;
            this.VisibleChanged += new EventHandler(FormLemcWait_VisibleChanged);
        }

        void FormLemcWait_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
            }
        }

        private int GetLevelID(long number)
        {
            SingleUserControl s = Pub._memberManage.GetSingleControl(number);
            int lid = 0;
            if (s != null)
            {
                lid = s.MemberLevel;
            }
            return lid;
        }

        /// <summary>
        /// 删除空闲用户
        /// </summary>
        public void DeleteIdelMember()
        {
            foreach (LemcMemberControl item in _lstButton)
            {
                SingleUserControl sc = Pub._memberManage.GetSingleControl(item.Number);
                if (sc!=null)
                {
                    if (sc.UserLineStatus== TalkControl.EnumUserLineStatus.Busy &&
                        sc.PeerNumber!=Pub.manageModel.LeftDispatchNumber.Value.ToString() &&
                        sc.PeerNumber != Pub.manageModel.RightDispatchNumber.Value.ToString())
                    {
                        DeleteWait(item.Number);
                        break;
                    }
                }
                if (item.MemberState == TalkControl.EnumUserLineStatus.Idle || item.MemberState == TalkControl.EnumUserLineStatus.Offline)
                {
                    DeleteWait(item.Number);
                    break;
                }   
            }
        }

        /// <summary>
        /// 删除号码
        /// </summary>
        /// <param name="number"></param>
        public void DeleteWait(long number)
        {
            LemcMemberControl bb = _lstButton.Find(w => w.Number == number);
            if (bb != null)
            {
                _lstButton.Remove(bb);
                panelBox.Controls.Remove(bb);
                Pub._meetingManage.UpdateMemberAlarmState(number, false );
                Pub._memberManage.UpdateMemberAlarmState(number, false );
            }
            ShowButton();
        }

        /// <summary>
        /// 判断是否可以停止音乐
        /// </summary>
        /// <returns></returns>
        private bool IsCanStopMusic()
        {
            LemcMemberControl bb = _lstButton.Find(w => w.MemberState == TalkControl.EnumUserLineStatus.Busy);
            if (bb != null)
            {
                return true ;
            }
            else
            {
                if (_lstButton.Count==0)//没有号码时关闭
                {
                    return true;
                }
                return false ;
            }
        }

        /// <summary>增加紧急号码</summary>
        /// <param name="number"></param>
        public void AddLemcWait(long number)
        {
            if (_lstButton.Exists(w => w.Number == number) == false)
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

                LemcMemberControl lmc = new LemcMemberControl();
                lmc.Number = number;
                lmc.MemberName = tt;
                lmc.MemberState = TalkControl.EnumUserLineStatus.None;
                lmc.ShowTime = DateTime.Now.ToString("HH:mm:ss");
                lmc.LeveID = GetLevelID(number);
                lmc.Dock = DockStyle.Top;
                
                lmc.Click += new EventHandler(lmc_Click);
                
                _lstButton.Add(lmc);
                panelBox.Controls.Add(lmc);
                lmc.BringToFront();
                axWindowsMediaPlayer1.URL = Pub._configModel.AlarmMusicUrl;
                axWindowsMediaPlayer1.settings.setMode("loop", true);
              //  axWindowsMediaPlayer1.Ctlcontrols.play();

                Pub._meetingManage.UpdateMemberAlarmState(number, true);
                Pub._memberManage.UpdateMemberAlarmState(number, true);
                ShowButton();
                timer1.Enabled = true;
            }
        }

        void lmc_Click(object sender, EventArgs e)
        {
            if (OnSelect != null)
            {
                LemcMemberControl bd = (LemcMemberControl)sender;
                
                OnSelect(sender, new SelectEventArgs()
                {
                    Number = bd.Number,
                });

                
            }
        }

        /// <summary>更新状态</summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public void UpdateMemberState(object obj, TalkControl.UserStateArgs e)
        {
            LemcMemberControl s = _lstButton.Find(p => p.Number == e.UserNumber );//delegate(SingleUserControl p) { return p.Number == e.UserNumber; });
            if (s != null)
            {
                s.MemberState = e.UserLineStatus;
            }
        }
  
        /// <summary>自动触发接通紧急号码事件
        /// 第一次来的时候直接接通，后来的每过30秒接一次
        /// </summary>
        /// <returns></returns>
        private void FindFirstNeedSelectAnswerRaiseEvent()
        {
           // for (int i= _lstButton.Count-1; i>=0; i--)
            for (int i = 0; i < _lstButton.Count; i++)
            {
                if (_lstButton[i].IsCalled == false)
                {
                    lmc_Click(_lstButton[i], null);
                    _lstButton[i].IsCalled = true;
                }
                if (_lstButton[i].IsCalled == true)
                {
                    _lstButton[i].SleepCount++;
                    if (_lstButton[i].SleepCount >= 30)//30秒后再执行一次接听动作
                    {
                        lmc_Click(_lstButton[i], null);
                        _lstButton[i].SleepCount = 0;
                    }
                }

                if (_lstButton[i].MemberName == "外线号码")//因为外线号码不法更新状态，所以直接删除此用户
                {
                   // DeleteWait(_lstButton[i].Number);
                }
            }
        }

        private void ShowButton()
        {
          //  this.panelBox.Controls.Clear();
          ////  _lstButton.Sort(new LevelComparer());
          //  panelBox.Visible = false;
          //  foreach (LemcMemberControl item in _lstButton)
          //  {
          //      this.panelBox.Controls.Add(item);
          //  }
          //  panelBox.Visible = true;
        }

        public class LevelComparer : IComparer<LemcMemberControl>
        {
            //重写int比较器，|x|>|y|返回正数，|x|=|y|返回0，|x|<|y|返回负数   
            public int Compare(LemcMemberControl x, LemcMemberControl y)
            {
                return y.LeveID.CompareTo(x.LeveID);
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (WaitUserCount == 0)
            {
                timer1.Enabled = false;
            }
            DeleteIdelMember();
            FindFirstNeedSelectAnswerRaiseEvent();
            if (IsCanStopMusic())
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            if (_lstButton.Count==0)//没有号码了就关闭窗体
            {
                this.Hide();
            }
        }
        
        private void panel1_Click(object sender, EventArgs e)
        {
           // this.Close();
        }

        /// <summary>
        /// 重新初始每个号码为没有拨打过
        /// </summary>
        public void ResetCallState()
        {
            foreach (LemcMemberControl item in _lstButton)
            {
                item.IsCalled = false;
            }
        }
    }
}
