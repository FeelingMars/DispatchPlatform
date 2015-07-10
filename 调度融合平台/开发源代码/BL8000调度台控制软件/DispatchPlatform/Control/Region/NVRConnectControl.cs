using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchPlatform.SDK;

namespace DispatchPlatform.Region
{
    internal class NVRConnectControl
    {
        private static NVRConnectControl m_Instance;
        private static object m_LockObj = new object();

        private bool m_InitSucceed = false;
        private int m_UserID = -1;
        private bool m_LoadSucceed = false;

        private NVRConnectControl()
        {
            m_InitSucceed = CHCNetSDK.NET_DVR_Init();
        }

        public static NVRConnectControl GetInstance()
        {
            if (m_Instance == null)
            {
                lock (m_LockObj)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new NVRConnectControl();
                    }
                }
            }

            return m_Instance;
        }

        public bool Load()
        {
            string DVRIPAddress = Pub._configModel.NVRLoadIP;           //设备IP地址或者域名
            int DVRPortNumber = Pub._configModel.NVRLoadPort;           //设备服务端口号
            string DVRUserName = Pub._configModel.NVRLoadName;          //设备登录用户名
            string DVRPassword = Pub._configModel.NVRLoadPassword;      //设备登录密码

            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

            //登录设备 Login the device
            m_UserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
            if (m_UserID < 0)
            {
                uint errorCode = CHCNetSDK.NET_DVR_GetLastError();
                m_LoadSucceed = true;
                return true;
            }
            else
            {
                m_LoadSucceed = false;
                return false;
            }
        }

        public bool PreviewCamera(IntPtr viewControlHandle, int channelID)
        {
            if (m_InitSucceed || m_LoadSucceed)
            {
                return false;
            }

            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo.hPlayWnd = viewControlHandle;//预览窗口
            lpPreviewInfo.lChannel = channelID;//预te览的设备通道
            lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流}
            IntPtr pUser = new IntPtr();//用户数据

            //打开预览 Start live view 
            int realHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_UserID, ref lpPreviewInfo, null/*RealData*/, pUser);
            if (realHandle < 0)
            {
                uint errorCode = CHCNetSDK.NET_DVR_GetLastError();
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Dispose()
        {
            if (m_UserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(m_UserID);
            }
            if (m_InitSucceed)
            {
                CHCNetSDK.NET_DVR_Cleanup();
            }
            m_Instance = null;
        }
    }
}
