using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VoiceDispatchManage.Tools
{
    public class CheckOnLine
    {

        public volatile bool _isStop = false;
        public Thread thread = null;

        public delegate void ConnectStateChange(string IP,bool isConnect);
        //连接状态改变事件
        public event ConnectStateChange StateChange;

        public CheckOnLine()
        {
            thread = new Thread(new ThreadStart(TestMain));
            thread.Name = "CheckOnlineThread" + this.GetHashCode();
        }

        public void Run()
        {
            thread.Start();
        }

        public void Stop()
        {
            _isStop = true;
            thread.Abort();
        }
        int PreState = 0;
        int State = 0;
        public void TestMain()
        {
            while (!_isStop)
            {
                try
                {

                    foreach (DB_Talk.Model.m_Box m in Global.Params.LstBox)
                    {
                        //bool b = MBoxSDK.ConfigSDK.MBOX_IsDeviceOnline("192.168.1.220");
                        bool b = MBoxSDK.ConfigSDK.MBOX_IsDeviceOnline(m.vc_IP);
                        //if (m.vc_IP == "192.168.1.239")
                        //    b = false;
                        State = (b == true ? 1 : 0);
                        PreState = m.i_Flag.Value;
                        if (State != PreState)
                        {
                            m.i_Flag = State;
                            if (StateChange != null)
                            {
                                StateChange(m.vc_IP, b);
                                CommControl.Tools.WriteLog.AppendLog("设备" + m.vc_IP + "在线状态为：" + b);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    CommControl.Tools.WriteLog.AppendErrorLog(ex);
                }

                for (int i = 0; i < 100; i++)
                {
                    System.Threading.Thread.Sleep(150);
                }
            }
        }
    }
}
