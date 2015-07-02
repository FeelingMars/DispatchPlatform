using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VoiceDispatchManage.Tools
{
    public class GetStateSipPri
    {
        

            private volatile bool _isStop = false;
            public Thread thread = null;
            public List<DB_Talk.Model.m_SIPInterface> lstPreSip = new List<DB_Talk.Model.m_SIPInterface>();
            public List<DB_Talk.Model.m_PRIInterface> lstPrePri = new List<DB_Talk.Model.m_PRIInterface>();

            public delegate void StateChange(object model);
            //连接状态改变事件
            public event StateChange InterfaceStateChange;

            public GetStateSipPri()
            {
                thread = new Thread(new ThreadStart(TestMain));
                thread.Name = "GetStateSipPri" + this.GetHashCode();
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
            //int PreState = 0;
            //int State = 0;
            public void TestMain()
            {
                while (!_isStop)
                {
                    try
                    {
                        List<DB_Talk.Model.m_SIPInterface> lstSip=new List<DB_Talk.Model.m_SIPInterface>();
                        Tools.MBoxOperate.GetSipTrunk(out lstSip);
                        foreach (DB_Talk.Model.m_SIPInterface m in lstSip)
                        {
                            //if (!lstPreSip.Contains(m)) lstPreSip.Add(m);
                            int index = lstPreSip.FindIndex(item => item.SIPID == m.SIPID);
                            if (index >= 0)
                            {
                                if (m.i_State != lstPreSip[index].i_State ||
                                     m.i_OperateState != lstPreSip[index].i_OperateState)
                                {
                                    lstPreSip[index].i_State = m.i_State;
                                    lstPreSip[index].i_OperateState = m.i_OperateState;
                                    if (InterfaceStateChange != null)
                                    {
                                        InterfaceStateChange(m);
                                    }
                                }
                            }
                           
                        }

                        List<DB_Talk.Model.m_PRIInterface> lstPri = new List<DB_Talk.Model.m_PRIInterface>();
                        Tools.MBoxOperate.GetPriTrunk(out lstPri);
                        foreach (DB_Talk.Model.m_PRIInterface m in lstPri)
                        {
                            //if (!lstPreSip.Contains(m)) lstPreSip.Add(m);
                            int index = lstPrePri.FindIndex(item => item.PRIID == m.PRIID);
                            if (index >= 0)
                            {
                                if (m.i_State != lstPrePri[index].i_State ||
                                     m.i_Operate != lstPrePri[index].i_Operate)
                                {
                                    lstPrePri[index].i_State = m.i_State;
                                    lstPrePri[index].i_Operate = m.i_Operate;
                                    if (InterfaceStateChange != null)
                                    {
                                        InterfaceStateChange(m);
                                    }
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
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
    }
    
}
