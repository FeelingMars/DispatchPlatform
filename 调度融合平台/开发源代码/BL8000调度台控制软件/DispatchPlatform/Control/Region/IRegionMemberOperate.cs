using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispatchPlatform.Data;
using DispatchPlatform.Region;
using CommControl;
using DispatchPlatform.Command;

namespace DispatchPlatform.Region
{
    interface IRegionMemberOperate
    {
        CommControl.PublicEnums.EnumRegionMemberType MemberType { get; }
        void ClickOpeate(object sender, EventArgs e);
        RegionMemberInfo[] LoadData(int regionID);
    }

    internal class RegionMemberPhoneOpeate<T> : IRegionMemberOperate where T : RegionCallInfo, new()
    {
        public RegionMemberPhoneOpeate(CommControl.PublicEnums.EnumRegionMemberType memberType)
        {
            if (memberType != CommControl.PublicEnums.EnumRegionMemberType.Radio &&
                memberType != CommControl.PublicEnums.EnumRegionMemberType.TelPhone &&
                memberType != CommControl.PublicEnums.EnumRegionMemberType.WiFiPhone)
            {
                throw new ArgumentException("memberType 类型错误。");
            }

            MemberType = memberType;
        }

        /// <summary>
        /// 但是事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickOpeate(object sender, EventArgs e)
        {
            if (!Pub._talkControl.GetBoxIsOnline())
            {
                //bc_OnMsg("连接设备失败");
                return;
            }

            if (RegionManage.GetInstance().GetDispatchNumber() == null)
            {
                //bc_OnMsg("请选择调度号码");
                return;
            }

            RegionMemberControl control = (RegionMemberControl)sender;

            if ((control.Tag as T).UserLineStatus == TalkControl.EnumUserLineStatus.Idle &&
                (control.Tag as T).NumberStatus != "连接中")
            {
                RegionCallCommand _baseCommand = new RegionCallCommand(Pub._talkControl.handle,
                       RegionManage.GetInstance().GetDispatchNumber().Number,
                        control.Tag.Number);

                if (_baseCommand.Begin() == true && Pub.CurrentDispatchControl.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                {
                    RegionManage.GetInstance().UpdateMemberStatus(control.Tag.Name, "连接中");
                }
            }
            else if ((control.Tag as T).UserLineStatus == TalkControl.EnumUserLineStatus.Busy ||
                (control.Tag as T).UserLineStatus == TalkControl.EnumUserLineStatus.Ring ||
                (control.Tag as T).UserLineStatus == TalkControl.EnumUserLineStatus.Paging)
            {
                if (System.Windows.Forms.MessageBox.Show(sender as System.Windows.Forms.Control, "是否挂断？", "提示信息",
                    System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question)
                    == System.Windows.Forms.DialogResult.Yes)
                {
                    //挂断
                    RegionHandupCommand cmd = new RegionHandupCommand(Pub._talkControl.handle,
                            RegionManage.GetInstance().GetDispatchNumber().Number,
                            control.Tag.Number);
                    cmd.Begin();
                }
            }
            else if ((control.Tag as RegionCallInfo).UserLineStatus == TalkControl.EnumUserLineStatus.Holding)//如果当前为保持状态，就执行应答
            {
                //应答
                RegionSelectAnswerCommand cmd = new RegionSelectAnswerCommand(Pub._talkControl.handle,
                       RegionManage.GetInstance().GetDispatchNumber().Number,
                        control.Tag.Number); ;
                if (cmd.Begin())
                {
                    (control.Tag as RegionCallInfo).IsCalling = true;
                }
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="regionID"></param>
        /// <returns></returns>
        public RegionMemberInfo[] LoadData(int regionID)
        {
            //test
            List<T> testData = new List<T>();

            //for (int i = 0; i < 150; i++)
            //{
            //    testData.Add(new RegionBillInfo()
            //    {
            //        ID = i,
            //        MemberType = this.MemberType,
            //        Name = MemberType.ToString() + i,
            //        Number = i.ToString(),
            //        OraNumber = MemberType.ToString() + i,
            //        PrimaryKey = MemberType.ToString() + i
            //    });
            //}
            if (MemberType == CommControl.PublicEnums.EnumRegionMemberType.WiFiPhone)
            {
                testData.Add(new T()
                {
                    ID = 3,
                    MemberType = this.MemberType,
                    Name = "6004",
                    Number = "6004",
                    PrimaryKey = "6004"
                });
                testData.Add(new T()
                {
                    ID = 3,
                    MemberType = this.MemberType,
                    Name = "6002",
                    Number = "6002",
                    PrimaryKey = "6002"
                });
                testData.Add(new T()
                   {
                       ID = 3,
                       MemberType = this.MemberType,
                       Name = "6006",
                       Number = "6006",
                       PrimaryKey = "6006"
                   });
            }

            if (MemberType == PublicEnums.EnumRegionMemberType.Radio)
            {
                testData.Add(new T()
                {
                    ID = 12,
                    MemberType = this.MemberType,
                    Name = "8101",
                    Number = "8101",
                    PrimaryKey = "8101"
                });
                testData.Add(new T()
                {
                    ID = 13,
                    MemberType = this.MemberType,
                    Name = "8102",
                    Number = "8102",
                    PrimaryKey = "8102"
                });
                testData.Add(new T()
                {
                    ID = 14,
                    MemberType = this.MemberType,
                    Name = "8103",
                    Number = "8103",
                    PrimaryKey = "8103"
                });
                testData.Add(new T()
                {
                    ID = 15,
                    MemberType = this.MemberType,
                    Name = "8104",
                    Number = "8104",
                    PrimaryKey = "8104"
                });
                testData.Add(new T()
                {
                    ID = 16,
                    MemberType = this.MemberType,
                    Name = "8105",
                    Number = "8105",
                    PrimaryKey = "8105"
                });
                testData.Add(new T()
                {
                    ID = 17,
                    MemberType = this.MemberType,
                    Name = "8106",
                    Number = "8106",
                    PrimaryKey = "8106"
                });
            }
            return testData.ToArray();
        }

        public CommControl.PublicEnums.EnumRegionMemberType MemberType
        {
            get;
            private set;
        }

        public void GroupCall(List<T> callMembers)
        {
            List<long> groupMemberNumberList = new List<long>();

            foreach (T item in callMembers)
            {
                if (item.UserLineStatus == TalkControl.EnumUserLineStatus.Idle)
                {
                    groupMemberNumberList.Add(Convert.ToInt64(item.Number));
                }
            }
            if (groupMemberNumberList.Count == 0)
            {
                return;
            }
            if (RegionManage.GetInstance().GetDispatchNumber() == null)
            {
                //没有可用的调度号码
                return;
            }
            RegionGroupCallCommand cmd = new RegionGroupCallCommand(Pub._talkControl.handle,
                RegionManage.GetInstance().GetDispatchNumber().Number,
                groupMemberNumberList);
            cmd.Begin();
        }
    }

    internal class RegionMemberCameraOpeate<T> : IRegionMemberOperate where T : RegionCameraInfo, new()
    {
        public RegionMemberCameraOpeate()
        {
            MemberType = CommControl.PublicEnums.EnumRegionMemberType.Camera;
        }

        public void ClickOpeate(object sender, EventArgs e)
        {

        }

        public RegionMemberInfo[] LoadData(int regionID)
        {
            List<T> list = new List<T>();
            list.Add(new T()
            {
                ID = 1,
                Name = "Camera1",
                MemberType = this.MemberType,
                PrimaryKey = "Camera1",
                Number = "camera1",
                ChanelID = 1
            });
            list.Add(new T()
            {
                ID = 2,
                Name = "Camera2",
                MemberType = this.MemberType,
                PrimaryKey = "Camera2",
                Number = "camera2",
                ChanelID = 2
            });
            return list.ToArray();
        }

        public CommControl.PublicEnums.EnumRegionMemberType MemberType
        {
            get;
            private set;
        }
    }
}
