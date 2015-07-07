using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DispatchPlatform.Region
{
    internal abstract class MemberAppearance
    {
        #region 常量
        /// <summary>正常显示的用户姓名颜色</summary>
        internal static int NormalNameOnlineColor = Color.FromArgb(48, 65, 100).ToArgb();

        internal static int OffLineFontColor = Color.FromArgb(98, 98, 98).ToArgb();

        internal static int IdleFontColor = Color.FromArgb(109, 150, 43).ToArgb();

        internal static int BusyFontColor = Color.FromArgb(45, 120, 195).ToArgb();

        internal static int RingFontColor = Color.FromArgb(205, 52, 52).ToArgb();

        internal static int OutCallingFontColor = Color.FromArgb(45, 120, 195).ToArgb();

        internal static int HoldingFontColor = Color.FromArgb(56, 138, 121).ToArgb();

        internal static int ListenFontColor = Color.FromArgb(180, 91, 147).ToArgb();

        internal static int RecordFontColor = Color.FromArgb(219, 133, 49).ToArgb();

        internal static int InsertFontColor = Color.FromArgb(121, 108, 164).ToArgb();

        internal static int IsolateFontColor = Color.FromArgb(188, 91, 58).ToArgb();
        /// <summary>隔离中颜色</summary>
        internal static int ForbidFontColor = Color.FromArgb(69, 91, 144).ToArgb();
        /// <summary>寻呼中颜色</summary>
        internal static int PagingFontColor = Color.FromArgb(45, 120, 195).ToArgb();

        internal static int HookonFontColor = Color.FromArgb(0, 90, 99).ToArgb();

        internal abstract Bitmap GetShowImageByState(DispatchPlatform.TalkControl.EnumUserLineStatus status = TalkControl.EnumUserLineStatus.None);

        #endregion

        internal static MemberAppearance Create(CommControl.PublicEnums.EnumRegionMemberType memberType)
        {
            if (memberType == CommControl.PublicEnums.EnumRegionMemberType.Camera)
            {
                return new CameraMemberAppearance();
            }
            else if (memberType == CommControl.PublicEnums.EnumRegionMemberType.Radio)
            {
                return new RadioMemberAppearance();
            }
            else if (memberType == CommControl.PublicEnums.EnumRegionMemberType.TelPhone)
            {
                return new TelePhoneMemberAppearance();
            }
            else if (memberType == CommControl.PublicEnums.EnumRegionMemberType.WiFiPhone)
            {
                return new WifiPhoneMemberAppearance();
            }
            else
            {
                throw new ArgumentException("memberType不是有效数据。");
            }
        }
    }

    internal class CameraMemberAppearance : MemberAppearance
    {
        internal override Bitmap GetShowImageByState(TalkControl.EnumUserLineStatus status = TalkControl.EnumUserLineStatus.None)
        {
            return DispatchPlatform.Properties.Resources.n_OnLine;
        }
    }

    internal class WifiPhoneMemberAppearance : MemberAppearance
    {
        internal override Bitmap GetShowImageByState(TalkControl.EnumUserLineStatus status = TalkControl.EnumUserLineStatus.None)
        {
            Bitmap tempMap;
            if (status == TalkControl.EnumUserLineStatus.Idle ||
                status == TalkControl.EnumUserLineStatus.Paging ||
                 status == TalkControl.EnumUserLineStatus.Outcalling)
            {
                tempMap = DispatchPlatform.Properties.Resources.n_OnLine;
            }
            else if (status == TalkControl.EnumUserLineStatus.Busy ||
                status == TalkControl.EnumUserLineStatus.HookOn)
            {
                tempMap = DispatchPlatform.Properties.Resources.n_Busy;
            }
            else if (status == TalkControl.EnumUserLineStatus.Offline)
            {
                tempMap = DispatchPlatform.Properties.Resources.n_OffLine;
            }
            else if (status == TalkControl.EnumUserLineStatus.Holding)
            {
                tempMap = DispatchPlatform.Properties.Resources.n_Keep;
            }
            else if (status == TalkControl.EnumUserLineStatus.Ring)
            {
                tempMap = DispatchPlatform.Properties.Resources.n_Ring;
            }
            else
            {
                tempMap = DispatchPlatform.Properties.Resources.n_OffLine;
            }

            return tempMap;
        }
    }

    internal class TelePhoneMemberAppearance : MemberAppearance
    {
        internal override Bitmap GetShowImageByState(TalkControl.EnumUserLineStatus status = TalkControl.EnumUserLineStatus.None)
        {
            Bitmap tempMap;
            if (status == TalkControl.EnumUserLineStatus.Idle ||
                status == TalkControl.EnumUserLineStatus.Paging ||
                 status == TalkControl.EnumUserLineStatus.Outcalling)
            {
                tempMap = DispatchPlatform.Properties.Resources.telephone_n_OnLine;
            }
            else if (status == TalkControl.EnumUserLineStatus.Busy ||
                status == TalkControl.EnumUserLineStatus.HookOn)
            {
                tempMap = DispatchPlatform.Properties.Resources.telephone_n_Busy;
            }
            else if (status == TalkControl.EnumUserLineStatus.Offline)
            {
                tempMap = DispatchPlatform.Properties.Resources.telephone_n_OffLine;
            }
            else if (status == TalkControl.EnumUserLineStatus.Holding)
            {
                tempMap = DispatchPlatform.Properties.Resources.telephone_n_Keep;
            }
            else if (status == TalkControl.EnumUserLineStatus.Ring)
            {
                tempMap = DispatchPlatform.Properties.Resources.telephone_m_Ring;
            }
            else
            {
                tempMap = DispatchPlatform.Properties.Resources.telephone_n_OffLine;
            }

            return tempMap;
        }
    }

    internal class RadioMemberAppearance : MemberAppearance
    {
        internal override Bitmap GetShowImageByState(TalkControl.EnumUserLineStatus status = TalkControl.EnumUserLineStatus.None)
        {
            Bitmap tempMap;
            if (status == TalkControl.EnumUserLineStatus.Idle ||
                status == TalkControl.EnumUserLineStatus.Paging ||
                 status == TalkControl.EnumUserLineStatus.Outcalling)
            {
                tempMap = DispatchPlatform.Properties.Resources.b_n_OnLine;
            }
            else if (status == TalkControl.EnumUserLineStatus.Busy ||
                status == TalkControl.EnumUserLineStatus.HookOn)
            {
                tempMap = DispatchPlatform.Properties.Resources.b_n_Busy;
            }
            else if (status == TalkControl.EnumUserLineStatus.Offline)
            {
                tempMap = DispatchPlatform.Properties.Resources.b_n_OffLine;
            }
            else if (status == TalkControl.EnumUserLineStatus.Holding)
            {
                tempMap = DispatchPlatform.Properties.Resources.b_n_Keep;
            }
            else if (status == TalkControl.EnumUserLineStatus.Ring)
            {
                tempMap = DispatchPlatform.Properties.Resources.b_m_Ring;
            }
            else
            {
                tempMap = DispatchPlatform.Properties.Resources.b_n_OffLine;
            }

            return tempMap;
        }
    }
}
