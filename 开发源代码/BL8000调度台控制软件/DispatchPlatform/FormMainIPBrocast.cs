using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPBroadcastDLL;

namespace DispatchPlatform
{

    //用于IP广播部分
    public partial class FormMain
    {
        private IPBroadcastDLL.IPBroadcastDLL _ipBroadcast = new IPBroadcastDLL.IPBroadcastDLL();
        private Mp3DLL _mp3 = null;
        private RecorderDLL _recorder = null;    // 录音
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        private int _t = 0;

        public void InitBrocast()
        {
            _mp3 = new Mp3DLL();
            this.Text = _ipBroadcast.Init(new IPBroadcastDLL.Model.InitModel()
            {
                //TerminalIP = "192.168.1.100",
                TerminalIPs =Pub._memberManage.GetBroadcastIP(),
                DataCommandPort = 10500,
                GroupIP = "227.0.0.2",//固定的
                LocalIP = Pub._configModel.LocalIP,
                LocalPort = 40001,//固定的
                NormalCommandPort = 40000//固定的
            }).ToString();
            //_ipBroadcast._interval = Pub._configModel.IpBrocastSendInterval;
            _ipBroadcast.ApplyEnterGroup();
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Enabled = false;
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            _t++;
          // lblTime.Text = GetAllTime(_t);
            if (_t>0 && _t% 10 == 0)
            {
                _ipBroadcast.ApplyEnterGroup();
            }
            //if (_t > 0 && _t % 60 * 1 == 0)
            //{
            //    _ipBroadcast.AddHead();
            //}
            Console.WriteLine(DateTime.Now+           "------------------------------");
        }
        

        /// <summary>
        /// 全矿广播
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgBtnBroadcast_Click(object sender, EventArgs e)
        {
          //  imgBtnBroadcast.Enabled = false;
            FormConfirmBroadCast frmConfirm = new FormConfirmBroadCast();
            frmConfirm.ShowDialog();
            if (frmConfirm.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    if (StartBrocast())
                    {
                        bc_OnMsg("全呼成功");
                        FormBroadCasting frming = new FormBroadCasting();
                        frming.ShowDialog();
                        if (frming.DialogResult == System.Windows.Forms.DialogResult.Yes)
                        {
                            StopBrocast();
                            //  System.Threading.Thread.Sleep(1000);
                        }
                      
                    }
                    else
                    {
                        bc_OnMsg("全呼失败");
                    }
                }
                catch (Exception ex)
                {
                    bc_OnMsg("全呼失败");
                    //throw;
                    CommControl.Tools.WriteLog.AppendLog(ex.Message);
                }
            }
           // imgBtnBroadcast.Enabled = true;
        }


        private bool StartBrocast()
        {
            _timer.Tick -= new EventHandler(_timer_Tick);
            InitBrocast();
            //  _recorder = new RecorderDLL();
            _mp3.OnDataReceive += new Mp3DLL.DataReceiveDelegate(_mp3_OnDataReceive);

            //
            // 录音设置
            //
            //  string wavfile = "C:\\test.wav";
            //  _recorder.SetFileName(wavfile);

            //  _recorder.OnDataReceive += new RecorderDLL.DataReceiveDelegate(_recorder_OnDataReceive);
            // _ipBroadcast.AddHead();
            //if (_recorder.RecStart() == true)
            //{
            if (_mp3.Start())
            {
                _ipBroadcast.StartRealPlay();
                _timer.Interval = 1000;
                _timer.Enabled = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        void _mp3_OnDataReceive(byte[] buffer)
        {
            _ipBroadcast.AddSoundData(buffer);
        }

        //void _recorder_OnDataReceive(byte[] buffer)
        //{
         
        //  //  _ipBroadcast.AddSoundData(buffer);
        //}

        private void StopBrocast()
        {
            try
            {
                //_recorder.RecStop();
               // _recorder.Dispose();
                _mp3.OnDataReceive -= new Mp3DLL.DataReceiveDelegate(_mp3_OnDataReceive);
                _mp3.Stop();
                _ipBroadcast.StopRealPlay();

            
            }
            catch (Exception ex)
            {
                CommControl.Tools.WriteLog.AppendLog(ex.Message);
                
            }
            _timer.Enabled = false;
            _t = 0;
        }


    }
}
