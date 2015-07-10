using System;
using System.Collections.Generic;

using System.Text;

namespace CommControl
{
    public class PublicEnums
    {
        /// <summary>
        /// 分组类型
        /// </summary>
        public enum EnumGroupType
        {
            none = 0,
            Normal = 1,
            /// <summary>
            ///  会议
            /// </summary>
            Meeting = 2,
            /// <summary>
            /// 短信
            /// </summary>
            SMS = 3,
            /// <summary>
            /// 摄像机
            /// </summary>
            Camera = 4,
            /// <summary>
            /// 手机
            /// </summary>
            WifiPhone = 5,
            /// <summary>
            /// 固话
            /// </summary>
            TelPhone = 6,
            /// <summary>
            /// 广播
            /// </summary>
            Redio = 7
        }

        public enum EnumLevel
        {
            none,
            一级 = 1,
            二级 = 2,
            三级 = 3,
            四级 = 4,
            五级 = 5,
            六级 = 6,
            七级 = 7,
            八级 = 8
        }

        //用户权限
        public enum EnumAuthority
        {
            none = -1,
            国际长途 = 0,
            国内长途 = 1,
            市话 = 2,
            内部分机 = 3,
            禁止主叫 = 4,
        }

        //手机类型
        public enum EnumNumberType
        {
            //SIP = 4,
            //SOP_PS = 1,  //小灵通

            //二期网管
            手机Wifi = 4,  //sip
            手机3G = 6,   //3G
            固话 = 4         //sip
        }

        /// <summary>
        /// 电话的类型，用于区分显示用的
        /// </summary>
        public enum EnumTelType
        {
            //手机 = 1,
            //固话 = 2,
            //调度席话机=3

            //二期网管
            WiFi手机 = 1,
            G3G手机 = 2,
            固话 = 3,
            调度席话机 = 4,
            广播 = 5,
            外部电话 = 6,
            摄像机 = 7,
        }

        /// <summary>
        /// 密码模式
        /// </summary>
        public enum EnumTelPasswordType
        {
            固定 = 1,
            增加 = 2
        }

        /// <summary>正常调度命令</summary>
        public enum EnumNormalCmd
        {
            None = 0,

            Call = 1,

            /// <summary>
            /// 紧急会议操作
            /// </summary>
            MakeLemcMeeting = 2,

            /// <summary>
            ///挂断
            /// </summary>
            Handup = 3,
            /// <summary>
            /// 强插
            /// </summary>
            Insert = 4,

            /// <summary>
            /// 代答
            /// </summary>
            InsteadAnswer = 5,

            /// <summary>
            /// 保持
            /// </summary>
            Keep = 6,
            /// <summary>
            /// 应答
            /// </summary>
            SelectAnser = 7,
            /// <summary>
            /// 转接
            /// </summary>
            Transfer = 8,
            /// <summary>
            /// 强拆
            /// </summary>
            SnatchCall = 9,

            /// <summary>
            /// 监听
            /// </summary>
            Listen = 10,

            /// <summary>
            /// 增加会议成员
            /// </summary>
            AddMeetingMember = 11,
            /// <summary>
            /// 会议禁言
            /// </summary>
            NoSpeekMeeting = 12,
            /// <summary>
            /// 解除会议禁言
            /// </summary>
            OkSpeekMeeting = 13,
            /// <summary>
            /// 隔离会议成员
            /// </summary>
            IsolateMeeting = 14,
            /// <summary>
            /// 解除隔离会议成员
            /// </summary>
            UnIsolateMeeting = 15,
            /// <summary>
            /// 踢出会议成员 
            /// </summary>
            DeleteMeetingMember = 16,
            /// <summary>
            /// 结束会议
            /// </summary>
            EndMeeting = 17,
            /// <summary>
            /// 录音 
            /// </summary>
            BeginRecord = 18,
            /// <summary>
            /// 结束录音
            /// </summary>
            EndRecord = 19,

            /// <summary>会议分组操作,开始结束操作</summary>
            MeetingGroupOperate = 20,

            /// <summary>紧急应答</summary>
            SelectLemcAnser = 21,

            /// <summary>录音操作</summary>
            RecordOperate = 22,
            /// <summary>
            /// 组呼
            /// </summary>
            GroupCall = 23,

            /// <summary>
            /// 视频呼叫
            /// </summary>
            VideoCall

        }

        /// <summary>
        /// 等待队列类型
        /// </summary>
        public enum EnumWaitType
        {
            Normal,//正常
            Lemc//紧急
        }

        /// <summary>
        /// 区域成员类型 
        /// </summary>
        public enum EnumRegionMemberType
        {
            WiFiPhone = 1,
            G3GPhone = 2,
            TelPhone = 3,
            Radio = 5,
            Camera = 7,
        }
    }
}
