using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DispatchPlatform
{
    public class HTPhoneSDK
    {
        public const int HTPHONE_MAX_URI_LEN = 64;
        public const int HTPHONE_MAX_USERNAME_LEN = 32;
        public const int HTPHONE_MAX_PASSWORD_LEN = 32;


        /*音频Codec列表*/
        public const int HTPHONE_AUDIO_CODEC_PCMA = 0x00000001;
        public const int HTPHONE_AUDIO_CODEC_PCMU = 0x00000002;
        public const int HTPHONE_AUDIO_CODEC_G729 = 0x00000004;
        public const int HTPHONE_AUDIO_CODEC_AMR = 0x00000008;
        public const int HTPHONE_AUDIO_CODEC_GSM = 0x00000010;

        /*默认音频Codec选项*/
        public const int HTPHONE_AUDIO_CODEC_MAP = (HTPHONE_AUDIO_CODEC_PCMA | HTPHONE_AUDIO_CODEC_PCMU | HTPHONE_AUDIO_CODEC_G729 | HTPHONE_AUDIO_CODEC_AMR);


        // video_codec_map是指客户端支持的视频编解码map，目前支持的codec有：
        public const int HTPHONE_VIDEO_CODEC_H264 = 0x00000001;
        public const int HTPHONE_VIDEO_CODEC_VP8 = 0x00000002;
        //默认的video_codec_map：
        public const int HTPHONE_VIDEO_CODEC_MAP = (HTPHONE_VIDEO_CODEC_H264 | HTPHONE_VIDEO_CODEC_VP8);

        #region 枚举

        /// <summary>注册状态</summary>
        public enum HTphoneRegistrationState
        {
            HTphoneRegistrationNone, /**初始状态*/
            HTphoneRegistrationProgress, /**正在进行注册*/
            HTphoneRegistrationOk, /**注册成功*/
            HTphoneRegistrationCleared, /**注销成功*/
            HTphoneRegistrationFailed /**注册失败*/
        }

        /// <summary>呼叫状态</summary>
        public enum HTphoneCallState
        {
            HTphoneCallIdle, /**初始状态*/
            HTphoneCallIncomingReceived, /**来电：有新来电*/
            HTphoneCallOutgoingInit, /**呼出：呼出的初始状态*/
            HTphoneCallOutgoingProgress, /**呼出：正在呼出*/
            HTphoneCallOutgoingRinging, /**呼出：对方振铃*/
            HTphoneCallOutgoingEarlyMedia, /**呼出：早期媒体*/
            HTphoneCallConnected, /**通话中*/
            HTphoneCallStreamsRunning, /**媒体流建立*/
            HTphoneCallPausing, /**正在暂停呼叫*/
            HTphoneCallPaused, /**呼叫暂停*/
            HTphoneCallResuming, /**正在继续呼叫*/
            HTphoneCallRefered, /**呼叫转移*/
            HTphoneCallError, /**呼叫错误*/
            HTphoneCallEnd, /**呼叫结束*/
            HTphoneCallPausedByRemote, /**对方暂停呼叫*/
            HTphoneCallUpdatedByRemote, /**对方更新呼叫参数*/
            HTphoneCallIncomingEarlyMedia, /**呼入：早期媒体*/
            HTphoneCallUpdating, /**更新呼叫参数*/
            HTphoneCallReleased /**呼叫释放*/
        }

        public enum VideoSizeEnum
        {
            HTPHONE_VIDEO_SIZE_NULL = 0,
            HTPHONE_VIDEO_SIZE_QCIF,	/* 176x144   */
            HTPHONE_VIDEO_SIZE_QVGA,	/* 320x240   */
            HTPHONE_VIDEO_SIZE_CIF,		/* 352x288   */
            HTPHONE_VIDEO_SIZE_VGA,		/* 640x480   */
            HTPHONE_VIDEO_SIZE_4CIF,	/* 704x576   */
            HTPHONE_VIDEO_SIZE_SVGA,	/* 800x600   */
            HTPHONE_VIDEO_SIZE_XGA,		/* 1024x768  */
            HTPHONE_VIDEO_SIZE_720P,	/* 1280x720  */
            HTPHONE_VIDEO_SIZE_1080P,	/* 1920x1080 */
            HTPHONE_VIDEO_MIN_SIZE = HTPHONE_VIDEO_SIZE_QCIF,
            HTPHONE_VIDEO_MAX_SIZE = HTPHONE_VIDEO_SIZE_1080P
        }

        //HTPHONE_PREFFERED_VIDEO_SIZE	HTPHONE_VIDEO_SIZE_CIF  /*默认视频尺寸*/
        #endregion

        #region 结构


        /// <summary>服务器信息结构体</summary>
        public struct htphone_server_config_t
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = HTPHONE_MAX_URI_LEN + 1)]
            public byte[] server_uri;       //调度主机IP   32
        }

        /// <summary>客户端配置结构体</summary>
        public struct htphone_client_config_t
        {
            public int expires; /*SIP终端注册的有效期，即SIP协议里面的expires*/
            public int sip_port; /*客户端SIP端口号*/
            public int audio_port; /*客户端音频RTP流端口号*/
            public int video_port; /*客户端视频RTP流端口号*/
        }

        /// <summary>用户信息</summary>
        public struct htphone_user_config_t
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = HTPHONE_MAX_USERNAME_LEN + 1)]
            public byte[] username;       //用户名

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = HTPHONE_MAX_PASSWORD_LEN + 1)]
            public byte[] password;       //密码/鉴权码*/


        }

        public struct htphone_audio_codec_config_t
        {
            public int audio_codec_map;
        }

        public struct htphone_video_codec_config_t
        {
            public int video_codec_map;
        }

        #endregion

        #region 委托

        /// <summary>注册状态改变回调函数 </summary>
        public delegate void HTphoneRegistrationStateChangedCb(HTphoneRegistrationState cstate, string message);

        /// <summary>呼叫状态改变回调函数</summary>
        /// <param name="cstate"></param>
        /// <param name="from"></param>
        /// <param name="?"></param>
        public delegate void HTphoneCallStateChangedCb(HTphoneCallState cstate, string from, string message);

        #endregion

        #region 原函数


        /// <summary>版本号</summary>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern string htphone_get_sdk_version();

        /// <summary>版本时间</summary>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern string htphone_get_sdk_release_time();

        /// <summary>初始化</summary>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_init(int parent_wnd, int video_wnd, IntPtr p, bool b);

        /// <summary>服务器配置</summary>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static extern int htphone_set_server_config(ref htphone_server_config_t config);

        /// <summary>用户配置</summary>
        /// <param name="config"></param>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static extern int htphone_set_user_config(ref htphone_user_config_t config);

        /// <summary>
        /// 客户端参数
        /// </summary>
        /// <param name="config"></param>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static extern int htphone_set_client_config(ref htphone_client_config_t config);


        /// <summary>注册</summary>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        private static extern int htphone_register(ref htphone_server_config_t new_server_config, ref htphone_user_config_t new_user_config);

        /// <summary>注册回调函数</summary>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern void htphone_set_callback(IntPtr RegistrationStateChangedCb, IntPtr CallStateChangedCb); /*呼叫状态改变回调函数*/

        /// <summary>呼叫</summary>
        /// <param name="called_user"></param>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_call(string called_user);


        /// <summary>
        /// 音频编解码参数配置
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_set_audio_codec_config(ref htphone_audio_codec_config_t config);

        /// <summary>
        /// 3.3.5 视频编解码参数配置
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_set_video_codec_config(ref htphone_video_codec_config_t config);

        /// <summary>
        /// 3.3.6 首选视频尺寸配置
        /// </summary>
        /// <param name="size_type"></param>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_set_preferred_video_size(int size_type);

        /// <summary>
        /// 3.3.7 上行速率（带宽）配置 上行速率（带宽）配置,限制 上行最大速率，单位 上行最大速率，单位 上行最大速率，单位 上行最大速率，单位 上行最大速率，单位 上行最大速率，单位 kbit/s kbit/skbit/skbit/s
        ///有效范围： 有效范围： 0 – 40964096
        ///0 表示不限速 表示不限速 表
        /// </summary>
        /// <param name="bw"></param>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_set_uplink_bandwidth(int bw);

        /// <summary>
        /// 3.3.8 穿防火墙 STUN ServerSTUN ServerSTUN ServerSTUN ServerSTUN ServerSTUN Server STUN Server和 ICE 配置
        /// </summary>
        /// <param name="server"></param>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_set_stun_server(string server);

        /// <summary>
        /// ICE启用
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_set_ice(bool enable);

        /// <summary>
        /// 3.3.9 麦克风静音 和取消
        /// </summary>
        /// <param name="mute"></param>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_set_mute_mic(bool mute);

        /// <summary>
        /// 返回当前使用的摄像头名
        /// </summary>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr htphone_get_video_device();

        /// <summary>
        /// 3.4 销毁
        /// </summary>
        /// <param name="mute"></param>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_destroy();

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_unregister();

        /// <summary>
        /// 接听来电
        /// </summary>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_accept_call();

        /// <summary>
        /// 拒绝来电
        /// </summary>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_reject_call();

        /// <summary>
        /// 挂断
        /// </summary>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int htphone_disconnect();

        /// <summary>
        /// 查询htphone当前是否占线
        /// </summary>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool htphone_is_busy();

        /// <summary>
        /// 查询htphone当前是否注册在线
        /// </summary>
        /// <returns></returns>
        [DllImport(@"HTphoneSDK.dll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool htphone_is_registered();

        #endregion

        #region 二次封装

        /// <summary>服务器配置</summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static bool SetServerConfig(string uri)
        {
            byte[] bytNew = Encoding.Default.GetBytes(uri);
            HTPhoneSDK.htphone_server_config_t t = new HTPhoneSDK.htphone_server_config_t();
            t.server_uri = new byte[HTPHONE_MAX_URI_LEN + 1];
            Array.Copy(bytNew, t.server_uri, bytNew.Length);
            return HTPhoneSDK.htphone_set_server_config(ref t) == 0;
        }

        /// <summary>用户配置</summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static bool SetUserConfig(string userName, string password)
        {
            byte[] bytUserName = Encoding.Default.GetBytes(userName);
            byte[] bytPassowrd = Encoding.Default.GetBytes(password);
            HTPhoneSDK.htphone_user_config_t userConfig = new htphone_user_config_t();

            userConfig.username = new byte[HTPHONE_MAX_USERNAME_LEN + 1];
            userConfig.password = new byte[HTPHONE_MAX_PASSWORD_LEN + 1];

            Array.Copy(bytUserName, userConfig.username, bytUserName.Length);
            Array.Copy(bytPassowrd, userConfig.password, bytPassowrd.Length);

            return htphone_set_user_config(ref userConfig) == 0;
        }

        /// <summary>注册</summary>
        /// <returns></returns>
        public static bool Register(string serverName, string userName, string password)
        {
            byte[] bytNew = Encoding.Default.GetBytes(serverName);
            HTPhoneSDK.htphone_server_config_t t = new HTPhoneSDK.htphone_server_config_t();
            t.server_uri = new byte[HTPHONE_MAX_URI_LEN + 1];
            Array.Copy(bytNew, t.server_uri, bytNew.Length);

            byte[] bytUserName = Encoding.Default.GetBytes(userName);
            byte[] bytPassowrd = Encoding.Default.GetBytes(password);
            HTPhoneSDK.htphone_user_config_t userConfig = new htphone_user_config_t();

            userConfig.username = new byte[HTPHONE_MAX_USERNAME_LEN + 1];
            userConfig.password = new byte[HTPHONE_MAX_PASSWORD_LEN + 1];

            Array.Copy(bytUserName, userConfig.username, bytUserName.Length);
            Array.Copy(bytPassowrd, userConfig.password, bytPassowrd.Length);

            //return htphone_register(null ,null) == 0;
            return htphone_register(ref t, ref userConfig) == 0;
        }

        /// <summary>客户端配置</summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static bool SetClientConfig(htphone_client_config_t config)
        {
            htphone_client_config_t t = new htphone_client_config_t();
            t.audio_port = config.audio_port;
            t.expires = config.expires;
            t.sip_port = config.sip_port;
            t.video_port = config.video_port;
            return htphone_set_client_config(ref t) == 0;
        }

        #endregion
    }
}
