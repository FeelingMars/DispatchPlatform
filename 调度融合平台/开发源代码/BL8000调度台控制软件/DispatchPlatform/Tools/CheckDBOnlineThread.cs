using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Collections;

namespace DispatchPlatform.Tools
{
    /// <summary>
    /// 监测数据库在线线程
    /// </summary>
    public class CheckDBOnlineThread
    {
        private volatile bool _isStop = false;
        public Thread thread = null;

        public CheckDBOnlineThread()
        {
            thread = new Thread(new ThreadStart(TestMain));
            thread.Name = "CheckDBOnlineThread" + this.GetHashCode();
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
        DB_Talk.BLL.Data_MemberState ms = new DB_Talk.BLL.Data_MemberState();
        public void TestMain()
        {
            while (!_isStop)
            {
                try
                {
                    ms.GetModel(1);//测试数据库连接用,会触发连接状态改变事件
                    Pub._isDBOnline = true;
                }
                catch (Exception)
                {
                    Pub._isDBOnline = false;
                }
                
                System.Threading.Thread.Sleep(10 * 1000);
            }
        }
    }
}

