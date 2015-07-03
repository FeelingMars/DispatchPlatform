using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommControl;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.Drawing;
using DispatchPlatform.Control;

namespace DispatchPlatform
{
    public class MeetingManage
    {
        private FormMain _mainForm = null;
        private TalkControl _tc = null;
        private List<MeetingGroupModel> _lstGroup = new List<MeetingGroupModel>();

        DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
        DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
        DevComponents.DotNetBar.Rendering.SuperTabItemColorTable superTabItemColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable();
        DevComponents.DotNetBar.Rendering.SuperTabColorStates superTabColorStates1 = new DevComponents.DotNetBar.Rendering.SuperTabColorStates();
        DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable superTabItemStateColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable();
        DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();


        /// <summary>恢复会议的ID</summary>
        private int _huiID = 0;

        public MeetingManage(FormMain frm, TalkControl tc)
        {
            _mainForm = frm;
            _tc = tc;
        }

        public void Init()
        {
            LoadMeetingGroupMember();
        }

        /// <summary>加载会议分组用户</summary>
        private void LoadMeetingGroupMember()
        {
            #region 临时会议操作Tab页
            AddMeetingGroup(MeetingGroupModel.EnumMeetingState.Off, MeetingGroupModel.EnumMeetingType.Lemc, 0, 0, "临时会议", new List<DB_Talk.Model.m_Member>(), 0, true);
            #endregion
            

            #region 加载紧急选选人用的Tab页
            
            
            List<DB_Talk.Model.m_Member> lstLemcMember = new List<DB_Talk.Model.m_Member>();
            foreach (SingleUserControl item in Pub._memberManage._lstGroup[0].lstControl)
            {
                lstLemcMember.Add(new DB_Talk.Model.m_Member()
                {
                    i_Number = item.Number,
                    vc_Name = item.MemberName,
                    i_TellType = item.TellType.GetHashCode(),
                    ID=item.ID
                });
            }
            AddMeetingGroup(MeetingGroupModel.EnumMeetingState.Off, MeetingGroupModel.EnumMeetingType.Lemc, 0, 0, "临时会议选人用", lstLemcMember, 0,false );

            #endregion

            #region 固定分组
            
            
            List<DB_Talk.Model.m_Group> lstGroup = new DB_Talk.BLL.m_Group().GetModelList(string.Format("i_Flag=0 and groupTypeID={0} and BoxID={1}", PublicEnums.EnumGroupType.Meeting.GetHashCode(),Pub.manageModel.BoxID.Value));
            foreach (DB_Talk.Model.m_Group item in lstGroup)
            {
                List<DB_Talk.Model.v_GroupMembers> lstGroupMember = new DB_Talk.BLL.v_GroupMembers().GetModelList("groupid=" + item.ID);

                List<DB_Talk.Model.m_Member> lstMember = new List<DB_Talk.Model.m_Member>();
                foreach (DB_Talk.Model.v_GroupMembers gitem in lstGroupMember)
                {
                    if (gitem.i_Number != Pub.manageModel.LeftDispatchNumber && gitem.i_Number != Pub.manageModel.RightDispatchNumber)
                    {
                        lstMember.Add(new DB_Talk.Model.m_Member()
                        {
                            i_Number = gitem.i_Number,
                            vc_Name = gitem.vc_Name,
                            i_TellType = gitem.i_TellType,
                            ID=gitem.ID
                        });
                    }
                }
                AddMeetingGroup(MeetingGroupModel.EnumMeetingState.Off, MeetingGroupModel.EnumMeetingType.Formal, item.ID, 0, item.vc_Name, lstMember,0,true);
            }
            #endregion

           
        }

        /// <summary>
        /// 得到待选
        /// </summary>
        /// <returns></returns>
        public PageControl GetToSelectPageControl()
        {
            if (_lstGroup.Count <= 1)
            {
               
                return null;
            }
            return _lstGroup[1].pageControl;
        }

        /// <summary>加载恢复的会议</summary>
        public void LoadTempMeeting()
        {
            List<long> lstM = _tc.GetMeetingList(Pub.manageModel.LeftDispatchNumber.Value);
            
            foreach (int item in lstM)
            {
                _huiID++;
                List<DispatchPlatform.TalkControl.MeetingMemberState> lstMember = _tc.GetMeetingMember(item, Pub.manageModel.LeftDispatchNumber.Value);
                List<DB_Talk.Model.m_Member> lst = new List<DB_Talk.Model.m_Member>();
                foreach (DispatchPlatform.TalkControl.MeetingMemberState gitem in lstMember)
                {
                    lst.Add(new DB_Talk.BLL.m_Member().GetModel("i_number='" + gitem.Number + "'"));//.GetModelByNumber(gitem.Number));
                }
                if (lstMember.Count > 0)
                {
                    AddMeetingGroup(MeetingGroupModel.EnumMeetingState.Running, MeetingGroupModel.EnumMeetingType.Temp, -1, item, "恢复" + _huiID, lst, Pub.manageModel.LeftDispatchNumber.Value,true);
                   // _mainForm.imgBtnMeeting_Click(null, null);
                    foreach (DispatchPlatform.TalkControl.MeetingMemberState gitem in lstMember)
                    {
                        SingleUserControl sc = Pub._memberManage.GetSingleControl(gitem.Number);
                        if (sc!=null)
                        {
                            if (sc.UserRecordStatus == TalkControl.EnumRecordStatus.ON)
                            {
                                UpdateMeetingMemberState(gitem.Number, TalkControl.EnumUserLineStatus.Record);
                                Pub._memberManage.UpdateMemberState(gitem.Number, TalkControl.EnumUserLineStatus.Record);
                            }
                            else
                            {
                                UpdateMeetingMemberState(gitem.Number, gitem.MeetingUserState);
                                Pub._memberManage.UpdateMemberState(gitem.Number, gitem.MeetingUserState);
                            }
                            sc.IsMeeting = true;
                        }

                        Pub._memberManage.SetMemberPeeName(gitem.Number, "恢复" + _huiID,true);
                        Pub._meetingManage.SetMeetingMemberPeeName(gitem.Number, "恢复" + _huiID,true);
                        if (_mainForm.cLeft.UserLineStatus== TalkControl.EnumUserLineStatus.Busy)
                        {
                            _mainForm.cLeft.PeerNumber = "恢复" + _huiID;    
                        }
                    }
                }
            }

            lstM = _tc.GetMeetingList(Pub.manageModel.RightDispatchNumber.Value);
            foreach (int item in lstM)
            {
                _huiID++;
                List<DispatchPlatform.TalkControl.MeetingMemberState> lstMember = _tc.GetMeetingMember(item, Pub.manageModel.RightDispatchNumber.Value);
                List<DB_Talk.Model.m_Member> lst = new List<DB_Talk.Model.m_Member>();
                foreach (DispatchPlatform.TalkControl.MeetingMemberState gitem in lstMember)
                {
                    lst.Add(new DB_Talk.BLL.m_Member().GetModel("i_number='" + gitem.Number + "'"));//.GetModelByNumber(gitem.Number));
                }
                if (lstMember.Count > 0)
                {
                    AddMeetingGroup(MeetingGroupModel.EnumMeetingState.Running, MeetingGroupModel.EnumMeetingType.Temp, -1, item, "恢复" + _huiID, lst, Pub.manageModel.RightDispatchNumber.Value,true);
                   // _mainForm.imgBtnMeeting_Click(null, null);
                    foreach (DispatchPlatform.TalkControl.MeetingMemberState gitem in lstMember)
                    {
                        SingleUserControl sc = Pub._memberManage.GetSingleControl(gitem.Number);
                        if (sc != null)
                        {
                            if (sc.UserRecordStatus == TalkControl.EnumRecordStatus.ON)
                            {
                                UpdateMeetingMemberState(gitem.Number, TalkControl.EnumUserLineStatus.Record);
                                Pub._memberManage.UpdateMemberState(gitem.Number, TalkControl.EnumUserLineStatus.Record);
                            }
                            else
                            {
                                UpdateMeetingMemberState(gitem.Number, gitem.MeetingUserState);
                                Pub._memberManage.UpdateMemberState(gitem.Number, gitem.MeetingUserState);
                            }
                            sc.IsMeeting = true;
                        }

                        UpdateMeetingMemberState(gitem.Number, gitem.MeetingUserState);
                        Pub._memberManage.SetMemberPeeName(gitem.Number, "恢复" + _huiID,true);
                        Pub._meetingManage.SetMeetingMemberPeeName(gitem.Number, "恢复" + _huiID, true);
                        if (_mainForm.cRight.UserLineStatus == TalkControl.EnumUserLineStatus.Busy)
                        {
                            _mainForm.cRight.PeerNumber = "恢复" + _huiID;
                        }
                    }
                }
            }
        }

        /// <summary>根据会议名称删除会议</summary>
        /// <param name="meetingName"></param>
        public void DeleteMeeting(string meetingName)
        {
            for (int i = 0; i < _mainForm.superTabControlMeeting.Tabs.Count; i++)
            {
                MeetingGroupModel model = (MeetingGroupModel)_mainForm.superTabControlMeeting.Tabs[i].Tag;

                if (model.GroupName == meetingName && model.MeetingType == MeetingGroupModel.EnumMeetingType.Lemc)
                {
                    for (int j = model.lstControl.Count-1; j >=0 ; j--)
                    {
                        DeleteMeetingMemberByName(meetingName, model.lstControl[j].Number);
                    }
                }

                if (model.GroupName == meetingName && model.MeetingType== MeetingGroupModel.EnumMeetingType.Temp)
                {
                    if (i < _mainForm.superTabControlMeeting.Tabs.Count)
                    {
                        //_mainForm.Invoke(new EventHandler(delegate(object o, EventArgs e)
                        //{
                            //try
                            //{
                                _mainForm.superTabControlMeeting.Tabs.Remove(_mainForm.superTabControlMeeting.Tabs[i]);
                                _lstGroup.Remove(model);
                                if (_mainForm.superTabControlMeeting.SelectedTab != null)
                                {
                                    _mainForm.superTabControlMeeting.SelectedTab.RaiseClick();
                                }
                        //    }
                        //    catch (Exception)
                        //    {


                        //    }
                        //}));
                    }
                }
            }
        }

        /// <summary>删除会议分组</summary>
        /// <param name="meetingDBID"></param>
        /// <param name="meetingID"></param>
        public void DeleteMeeting(int meetingID)
        {
            for (int i = 0; i < _mainForm.superTabControlMeeting.Tabs.Count; i++)
            {
                MeetingGroupModel model = (MeetingGroupModel)_mainForm.superTabControlMeeting.Tabs[i].Tag;
                if (model.MeetingState == MeetingGroupModel.EnumMeetingState.Running
                   && model.MeetingID == meetingID
                   && model.MeetingType == MeetingGroupModel.EnumMeetingType.Lemc)
                {
                    model.MeetingState = MeetingGroupModel.EnumMeetingState.Off;
                }

                if (model.MeetingState == MeetingGroupModel.EnumMeetingState.Running
                    && model.MeetingID == meetingID
                    && model.MeetingType == MeetingGroupModel.EnumMeetingType.Temp)
                {
                    if (i < _mainForm.superTabControlMeeting.Tabs.Count)
                    {
                        if (_mainForm.InvokeRequired)
                        {
                            System.Console.WriteLine("开始：_mainForm.InvokeRequired");
                            _mainForm.Invoke(new EventHandler(delegate(object o, EventArgs e)
                            {
                                try
                                {
                                    _mainForm.superTabControlMeeting.Tabs.Remove(_mainForm.superTabControlMeeting.Tabs[i]);
                                    _lstGroup.Remove(model);
                                    if (_mainForm.superTabControlMeeting.SelectedTab != null)
                                    {
                                        _mainForm.superTabControlMeeting.SelectedTab.RaiseClick();
                                    }
                                }
                                catch (Exception)
                                {


                                }
                            }));
                            System.Console.WriteLine("结束：_mainForm.InvokeRequired");
                        }
                        else
                        {
                            try
                            {
                                _mainForm.superTabControlMeeting.Tabs.Remove(_mainForm.superTabControlMeeting.Tabs[i]);
                                _lstGroup.Remove(model);
                                if (_mainForm.superTabControlMeeting.SelectedTab != null)
                                {
                                    _mainForm.superTabControlMeeting.SelectedTab.RaiseClick();
                                }
                            }
                            catch (Exception)
                            {


                            }
                        }
                    }
                }

                ///删除会议内成员
                if (model.MeetingID==meetingID && model.MeetingState== MeetingGroupModel.EnumMeetingState.Running && model.MeetingType == MeetingGroupModel.EnumMeetingType.Formal)
                {
                    model.MeetingState = MeetingGroupModel.EnumMeetingState.Off;
                    _mainForm.superTabControlMeeting.Tabs[i].RaiseClick();

                    List<DB_Talk.Model.v_GroupMembers> lstGroupMember = new DB_Talk.BLL.v_GroupMembers().GetModelList("groupid=" + model.GroupID);

                    int tempCount = model.lstControl.Count;
                    for (int j = tempCount-1; j >=0; j--)
                    {
                        bool isFind = false;
                        foreach (DB_Talk.Model.v_GroupMembers mem in lstGroupMember)
                        {
                            if (model.lstControl[j].Number == mem.i_Number.Value)
                            {
                                isFind = true;
                                break;
                            }
                        }
                        if (isFind == false)
                        {
                            model.lstControl.Remove(model.lstControl[j]);
                        }
                       // model.lstControl[j].PeerNumber = "0";
                    }
                    Pub.CanDestroyControl = false;
                    model.pageControl.Init(model.lstControl);
                    Pub.CanDestroyControl = true;
                }
            }
        }

        /// <summary>
        /// 删除会议成员，根据会议名
        /// </summary>
        /// <param name="meetingName"></param>
        /// <param name="number"></param>
        public void DeleteMeetingMemberByName(string meetingName, long number)
        {
            for (int i = 0; i < _mainForm.superTabControlMeeting.Tabs.Count; i++)
            {
                MeetingGroupModel model = (MeetingGroupModel)_mainForm.superTabControlMeeting.Tabs[i].Tag;
                SuperTabItem sti = (SuperTabItem)_mainForm.superTabControlMeeting.Tabs[i];
                if (model.GroupName==meetingName )
                {
                    if (model.MeetingType == MeetingGroupModel.EnumMeetingType.Formal)
                    {
                        DeleteFormlMeetingMember(sti,model, number);
                    }
                    if (model.MeetingType== MeetingGroupModel.EnumMeetingType.Temp)
                    {
                        DeleteTempMeetingMember(model, 0, number);
                    }
                    if (model.MeetingType == MeetingGroupModel.EnumMeetingType.Lemc)
                    {
                        DeleteFormlMeetingMember(sti, model, number);
                    }
                }
            }
        }

        /// <summary>删除会议成员</summary>
        /// <param name="meetingID"></param>
        /// <param name="number"></param>
        public void DeleteMeetingMember(int meetingID, long number)
        {
            for (int i = 0; i < _mainForm.superTabControlMeeting.Tabs.Count; i++)
            {
                SuperTabItem sti = (SuperTabItem)_mainForm.superTabControlMeeting.Tabs[i];
                MeetingGroupModel model = (MeetingGroupModel)_mainForm.superTabControlMeeting.Tabs[i].Tag;
                if (model.MeetingID == meetingID)
                {
                    if (model.MeetingType == MeetingGroupModel.EnumMeetingType.Formal)
                    {
                        DeleteFormlMeetingMember(sti,model,  number);
                    }
                    if (model.MeetingType == MeetingGroupModel.EnumMeetingType.Temp)
                    {
                        DeleteTempMeetingMember(model, meetingID, number);
                    }
                }
            }
        }

        /// <summary>
        /// 删除正式会议成员
        /// </summary>
        /// <param name="model"></param>
        /// <param name="meetingID"></param>
        /// <param name="number"></param>
        private void DeleteFormlMeetingMember(SuperTabItem sti,MeetingGroupModel model, long number)
        {
            List<DB_Talk.Model.v_GroupMembers> lstGroupMember = new DB_Talk.BLL.v_GroupMembers().GetModelList("groupid=" + model.GroupID);

            DB_Talk.Model.v_GroupMembers member = lstGroupMember.Find(m => m.i_Number == number);

            if (member == null)//说明是邀请过来的
            {
                model.lstControl.Remove(model.lstControl.Find(p => p.Number == number));
            }
            //int tempCount = model.lstControl.Count;
            //for (int j = tempCount - 1; j >= 0; j--)
            //{
            //    bool isFind = false;
            //    foreach (DB_Talk.Model.v_GroupMembers mem in lstGroupMember)
            //    {
            //        if (model.lstControl[j].Number == mem.i_Number.Value)
            //        {
            //            isFind = true;
            //            break;
            //        }
            //    }
            //    if (isFind == false)
            //    {
            //        model.lstControl.Remove(model.lstControl[j]);
            //    }
            //}
            Pub.CanDestroyControl = false;
            model.pageControl.Init(model.lstControl);
            Pub.CanDestroyControl = true;

            List<SingleUserControl> lstControl = model.lstControl.FindAll(p =>
                    p.UserLineStatus == TalkControl.EnumUserLineStatus.Busy
                    || p.UserLineStatus == TalkControl.EnumUserLineStatus.Forbid
                    || p.UserLineStatus == TalkControl.EnumUserLineStatus.Isolate
                    || p.UserLineStatus == TalkControl.EnumUserLineStatus.Ring
                    || p.UserLineStatus == TalkControl.EnumUserLineStatus.Record
                    );

            if (lstControl != null && lstControl.Count > 0)
            {

            }
            else
            {
                model.MeetingState = MeetingGroupModel.EnumMeetingState.Off;
                sti.RaiseClick();
            }

            //bool allIdel = true;//所有都空闲改变会议状态为结束
            ////
            //foreach (SingleUserControl item in model.lstControl)
            //{
            //    if (item.UserLineStatus == TalkControl.EnumUserLineStatus.Busy)
            //    {
            //        allIdel = false;
            //        break;
            //    }
            //}
            //if (allIdel)
            //{
            //    model.MeetingState = MeetingGroupModel.EnumMeetingState.Off;
             //_mainForm.superTabControlMeeting.Tabs[i].RaiseClick();
            //}
        }

        /// <summary>
        /// 删除临时会议成员
        /// </summary>
        /// <param name="model"></param>
        /// <param name="meetingID"></param>
        /// <param name="number"></param>
        private void DeleteTempMeetingMember(MeetingGroupModel model,int meetingID,long number)
        {
            int tempCount = model.lstControl.Count;
            for (int j = tempCount - 1; j >= 0; j--)
            {
                if (model.lstControl[j].Number == number)
                {
                    model.lstControl.Remove(model.lstControl[j]);
                }
            }
            if (model.lstControl.Count == 0)
            {
                DeleteMeeting(meetingID);
            }
            else
            {
                Pub.CanDestroyControl = false;
                model.pageControl.Init(model.lstControl);
                Pub.CanDestroyControl = true;
            }
        }

        private SingleUserControl _tempSingleControl = null; 

        /// <summary>更新会议成员状态</summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public void UpdateMeeting(object obj, TalkControl.UserStateArgs e)
        {
            for (int i = 0; i < _lstGroup.Count; i++)
            {
                
            //}
            //foreach (MeetingGroupModel item in _lstGroup)
            //{
                _tempSingleControl = _lstGroup[i].lstControl.Find(delegate(SingleUserControl p) { return p.Number == e.UserNumber; });
                if (_tempSingleControl != null)
                {
                    _tempSingleControl.UserLineStatus = e.UserLineStatus;

                    _tempSingleControl.UserRecordStatus = e.RecordStatus;
                    if (_tempSingleControl.UserRecordStatus == TalkControl.EnumRecordStatus.ON && e.PeerPartNumber == 0)//会议中的录音不更新对放名称
                    {
                        //
                    }
                    else
                    {
                        _tempSingleControl.PeerNumber = e.PeerPartNumber.ToString();
                    }
                    Pub.UpdateSingleUserContorlFont(_tempSingleControl);
                }
            }
        }

        /// <summary>
        /// 设置没有完全成功的会议状态，临时为关闭会议用的
        /// </summary>
        /// <param name="dispatchNumber"></param>
        /// <param name="meetingID"></param>
        public void SetTempGroupState(long dispatchNumber, int meetingID)
        {
            foreach (MeetingGroupModel item in _lstGroup)
            {
                if (item.MeetingState == MeetingGroupModel.EnumMeetingState.Ready)
                {
                    item.MeetingID = meetingID;
                }
            }
        }

        /// <summary>
        /// 根据调度号码将会议设置为结束状态
        /// </summary>
        /// <param name="dispatchNumber"></param>
        /// <param name="meetingID"></param>
        public void SetTempGroupStateOff(long dispatchNumber,int meetingID)
        {
            foreach (MeetingGroupModel item in _lstGroup)
            {
                if ((item.MeetingState == MeetingGroupModel.EnumMeetingState.Ready || item.MeetingState== MeetingGroupModel.EnumMeetingState.Running) 
                    && item.DispatchNumber==dispatchNumber
                    && item.MeetingID==meetingID
                    )
                {
                    item.MeetingState = MeetingGroupModel.EnumMeetingState.Off;
                }
            }
        }

        /// <summary>更新会议组状态,设置会议为执行状态</summary>
        public void SetMeetingGroupState(long dispatchNumber,int meetingID)
        {
            foreach (MeetingGroupModel item in _lstGroup)
            {
                if (item.MeetingState== MeetingGroupModel.EnumMeetingState.Ready)
                {
                    item.MeetingState =  MeetingGroupModel.EnumMeetingState.Running;
                    item.MeetingID = meetingID;
                   // item.GroupName = "会议中";
                    foreach (SingleUserControl tt in item.lstControl)
                    {
                        if (tt.UserLineStatus== TalkControl.EnumUserLineStatus.Busy && tt.PeerNumber == "0")//为0时更新状态，不为0表示当前属于会议
                        {
                            //tt.IsMeeting = true;
                            tt.PeerNumber = item.GroupName;// string.Format("会议:{0}", item.GroupName);
                            Pub._memberManage.SetMemberPeeName(tt.Number, tt.PeerNumber, true);
                            this.SetMeetingMemberPeeName(tt.Number, tt.PeerNumber, true);
                            item.DispatchNumber = dispatchNumber;

                        }
                        Pub.UpdateSingleUserContorlFont(tt);
                    }

                    if (_mainForm.cLeft.UserLineStatus== TalkControl.EnumUserLineStatus.Busy && _mainForm.cLeft.Number==dispatchNumber)
                    {
                        _mainForm.cLeft.PeerNumber = "会议中";// item.GroupName;
                    }
                    if (_mainForm.cRight.UserLineStatus== TalkControl.EnumUserLineStatus.Busy && _mainForm.cRight.Number == dispatchNumber)
                    {
                        _mainForm.cRight.PeerNumber = "会议中";// item.GroupName;
                    }
                }
            }
        }

        /// <summary>
        /// 设置所有用户的可用性
        /// </summary>
        /// <param name="b"></param>
        public void SetAllMemberEnable(bool b)
        {
            foreach (MeetingGroupModel item in _lstGroup)
            {
                foreach (SingleUserControl sc in item.lstControl)
                {
                    sc.ControlEnable = b;
                }
            }
        }

        /// <summary>
        /// 排序
        /// </summary>
        public void Sort()
        {
            for (int i = 0; i < _lstGroup.Count; i++)
            {
                if (_lstGroup[i].pageControl != null)
                {
                    _lstGroup[i].pageControl.Sort(Pub._configModel.SortByID, Pub._configModel.SortByNumber, Pub._configModel.SortByName, Pub._configModel.SortByOnline, Pub._configModel.SortByDepartment);
                }
            }
        }


        /// <summary>更新单个成员状态</summary>
        public void SetMemberState(long number, string state)
        {
            foreach (MeetingGroupModel item in _lstGroup)
            {
                SingleUserControl s = item.lstControl.Find(delegate(SingleUserControl p) { return p.Number == number; });
                if (s != null)
                {
                    // s.MeetingMemberState = state;
                    s.NumberState = state;
                    //  break;
                }
            }
        }

        /// <summary>
        /// 设置过滤类型
        /// </summary>
        public void SetFilterType(EnumFilterType type)
        {
            _lstGroup[0].pageControl.FilterType = type;
            this.Sort();
        }

        ///// <summary>
        ///// 显示全部用户
        ///// </summary>
        //public void ShowAllMember()
        //{
        //    _lstGroup[0].pageControl.ShowAllMember();
        //}

        /// <summary>
        /// 设置成员告警状态 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="isAlarm"></param>
        public void UpdateMemberAlarmState(long number, bool isAlarm)
        {
            foreach (MeetingGroupModel item in _lstGroup)
            {
                SingleUserControl s = item.lstControl.Find(delegate(SingleUserControl p) { return p.Number == number; });
                if (s != null)
                {
                    s.IsAlarm = isAlarm;
                  //  break;
                }
            }
        }

        /// <summary>设置单个控件是否为可选中</summary>
        /// <param name="b"></param>
        public void SetControlIsCanSelect(bool b)
        {
            foreach (MeetingGroupModel item in _lstGroup)
            {
                foreach (SingleUserControl s in item.lstControl)
                {
                    s.CanSelect = b;
                }
            }
        }

        /// <summary>
        /// 设置选中状态
        /// </summary>
        /// <param name="b"></param>
        public void SetControlChecked(bool b)
        {
            foreach (MeetingGroupModel item in _lstGroup)
            {
                foreach (SingleUserControl s in item.lstControl)
                {
                    if (s.IsDispatch == false)
                    {
                        s.Checked = b;
                    }
                }
            }
        }

        /// <summary>
        /// 设置行列
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        public void SetPageSize(int col, int row)
        {
            Pub.CanDestroyControl = false;
            foreach (MeetingGroupModel item in _lstGroup)
            {
                if (item.pageControl != null)
                {
                    item.pageControl._columnCount = col;
                    item.pageControl._rowCount = row;
                    item.pageControl._currentPageIndex = 0;
                    item.pageControl.GetSingleControlSize();
                    item.pageControl.LoadData();
                }
                foreach (SingleUserControl ss in item.lstControl)
                {
                    Pub.UpdateSingleUserContorlFont(ss);
                }
            }
            Pub.CanDestroyControl = true;
        }


        /// <summary>
        /// 设置用户对放显示名称
        /// </summary>
        /// <param name="memberID"></param>
        /// <param name="name"></param>
        public void SetMeetingMemberPeeName(long number, string name,bool isMeeting)
        {
            foreach (MeetingGroupModel item in _lstGroup)
            {
                SingleUserControl s = item.lstControl.Find(delegate(SingleUserControl p) { return p.Number == number; });
                if (s != null)
                {
                    s.IsMeeting = isMeeting;
                    s.PeerNumber = name;
                    
                   // break;
                }
            }
        }

        /// <summary>更新单个会议成员状态</summary>
        public void UpdateMeetingMemberState(long number, DispatchPlatform.TalkControl.EnumUserLineStatus state)
        {
            foreach (MeetingGroupModel item in _lstGroup)
            {
                SingleUserControl s = item.lstControl.Find(delegate(SingleUserControl p) { return p.Number == number; });
                if (s != null)
                {
                    s.UserLineStatus = state;
                    if (state == TalkControl.EnumUserLineStatus.Record)
                    {
                        s.UserRecordStatus = TalkControl.EnumRecordStatus.ON;
                    }
                    else
                    {
                        s.UserRecordStatus = TalkControl.EnumRecordStatus.OFF;
                    }
                    Pub.UpdateSingleUserContorlFont(s);
                  //  break;
                }
            }
        }

        /// <summary>增加会议成员</summary>
        public void AddMeetingMember(int meetingDBID, int meetingID, long memberID,string groupName)
        {
            foreach (SuperTabItem item in _mainForm.superTabControlMeeting.Tabs)
            {
                MeetingGroupModel model = (MeetingGroupModel)item.Tag;
                //if (model.GroupID == meetingDBID || model.MeetingID == meetingID)
                if ( model.MeetingID == meetingID && model.GroupName==groupName)
                {
                    SingleUserControl ss = new SingleUserControl();
                    SingleUserControl sc = Pub._memberManage.GetSingleControl(memberID);
                    if (sc != null)
                    {
                        ss.Number = sc.Number;
                        ss.MemberName = sc.MemberName;
                        ss.TellType = sc.TellType;
                        ss.UserLineStatus = sc.UserLineStatus;
                        
                        if (model.MeetingState== MeetingGroupModel.EnumMeetingState.Running)
                        {
                          //  ss.PeerNumber = groupName;    
                        }
                        ss.DepartmentID = sc.DepartmentID;
                        if (model.lstControl.Exists(delegate(SingleUserControl c) { return c.Number == sc.Number; }) == false)
                        {
                            model.lstControl.Add(ss);
                        }
                        ss.Click += new EventHandler(_mainForm.single_Click);
                        Pub.CanDestroyControl = false;
                        model.pageControl.Init(model.lstControl);
                        Pub.CanDestroyControl = true;
                    }
                    
                    _mainForm.superTabControlMeeting.SelectedTab = item;
                   
                    break;
                }
            }
        }

        /// <summary>增加会议分组</summary>
        public void AddMeetingGroup(MeetingGroupModel.EnumMeetingState meetingState, DispatchPlatform.MeetingGroupModel.EnumMeetingType meetingType, int groupID, int meetingID, string meetingGroupName, List<DB_Talk.Model.m_Member> lstMembers, long dispatchNumber, bool tabVisible)
        {
            foreach (SuperTabItem item in _mainForm.superTabControlMeeting.Tabs)
            {
                MeetingGroupModel model = (MeetingGroupModel)item.Tag;
                if (model.GroupName == meetingGroupName || lstMembers.Count==0)
                {
                    return;
                }
            }


            SuperTabItem tabItem = new SuperTabItem();
            
            tabItem.GlobalItem = false;
            tabItem.SelectedTabFont = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold);
            superTabLinearGradientColorTable1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(48))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(113)))), ((int)(((byte)(130)))))};
            superTabItemStateColorTable1.Background = superTabLinearGradientColorTable1;
            superTabColorStates1.Selected = superTabItemStateColorTable1;
            superTabItemColorTable1.Bottom = superTabColorStates1;
            tabItem.TabColor = superTabItemColorTable1;
            
            tabItem.Text = meetingGroupName;


            Pub.SetSupperTabColor(tabItem);

            tabItem.Click += new EventHandler(_mainForm.MeetingTabItem_Click);

            MeetingGroupModel mModel = new MeetingGroupModel();
            
            mModel.MeetingState = meetingState;
            mModel.MeetingID = meetingID;
            mModel.GroupID = groupID;
            mModel.GroupName = meetingGroupName;
            mModel.MeetingType = meetingType;
            mModel.DispatchNumber = dispatchNumber;
            tabItem.Tag = mModel;

            _lstGroup.Add(mModel);

           
            _mainForm.superTabControlMeeting.Tabs.Add(tabItem);

            _mainForm.superTabControlMeeting.SelectedTab = tabItem;
            SuperTabControlPanel sp = new SuperTabControlPanel();

            tabItem.Visible = tabVisible;

            _mainForm.superTabControlMeeting.Controls.Add(sp);
            tabItem.AttachedControl = sp;

            //_lstGroup.Add(mModel);
            PageControl pControl = new PageControl();
            mModel.pageControl = pControl;
            pControl.Dock = DockStyle.Fill;
            sp.Controls.Add(pControl);
            
            foreach (DB_Talk.Model.m_Member item in lstMembers)
            {
                if (item.i_Number != Pub.manageModel.LeftDispatchNumber.Value && item.i_Number != Pub.manageModel.RightDispatchNumber.Value)
                {
                    SingleUserControl sc = new SingleUserControl();

                    sc.Number = item.i_Number.Value;
                    sc.MemberName = item.vc_Name;
                    sc.ID = item.ID;
                    if (item.DepartmentID!=null)
                    {
                        sc.DepartmentID = item.DepartmentID.Value;    
                    }

                    if (item.i_TellType != null)
                    {
                        sc.TellType = (CommControl.PublicEnums.EnumTelType)item.i_TellType.Value;
                        if (item.i_TellType.Value==0)
                        {
                            sc.TellType = PublicEnums.EnumTelType.WiFi手机;
                        }
                    }
                    else
                    {
                        sc.TellType = PublicEnums.EnumTelType.WiFi手机;
                    }

                    if (meetingType == MeetingGroupModel.EnumMeetingType.Temp)
                    {
                        sc.PeerNumber = meetingGroupName;
                        sc.UserLineStatus = Pub._memberManage.GetMemberState(item.i_Number.Value);
                    }

                    mModel.lstControl.Add(sc);
                    sc.Click += new EventHandler(_mainForm.single_Click);
                }
            }
            if (meetingType == MeetingGroupModel.EnumMeetingType.Temp)
            {
                mModel.DispatchNumber = dispatchNumber;
                tabItem.RaiseClick();
            }
            pControl.Init(mModel.lstControl);
        }

        /// <summary>
        /// 清除
        /// </summary>
        public void ClearAll()
        {
            _lstGroup.Clear();
            _mainForm.superTabControlMeeting.Tabs.Clear();
        }

        /// <summary>
        /// 选中一下每一个
        /// </summary>
        public void ClickTab()
        {
            foreach (SuperTabItem item in _mainForm.superTabControlMeeting.Tabs)
            {
                _mainForm.superTabControlMeeting.SelectedTab = item;
                item.RaiseClick();
            }
            _mainForm.superTabControlMeeting.SelectedTab = (SuperTabItem)_mainForm.superTabControlMeeting.Tabs[0];
        }
    
    }


    /// <summary>会议类,与Tab页绑定用</summary>
    public class MeetingGroupModel
    {
        /// <summary>会议ID</summary>
        public int MeetingID { get; set; }

        /// <summary>数据库中的会议分组ID</summary>
        public int GroupID { get; set; }

        /// <summary>数据库中的会议分组名称</summary>
        public string GroupName { get; set; }

        /// <summary>会议成员 </summary>
        public List<SingleUserControl> lstControl = new List<SingleUserControl>();

        /// <summary>会议状态</summary>
        public EnumMeetingState MeetingState { get; set; }

        /// <summary>会议类型</summary>
        public EnumMeetingType MeetingType { get; set; }

        /// <summary>
        /// 调度用户
        /// </summary>
        public SingleUserControl DispatchControl = new SingleUserControl();

        /// <summary>
        /// 发起此会议的调度号码
        /// </summary>
        public long DispatchNumber { get; set; }

        /// <summary>存放控件的容器</summary>
        public PageControl pageControl;

        public enum EnumMeetingState
        {
            /// <summary>创建中</summary>
            Ready=0,
            /// <summary>
            /// 进行中
            /// </summary>
            Running=1,
            /// <summary>
            /// 停止 
            /// </summary>
            Off=2
        }

        public enum EnumMeetingType
        {
            /// <summary>
            /// 正式
            /// </summary>
            Formal=0,
            /// <summary>
            /// 临时
            /// </summary>
            Temp=1,
            /// <summary>
            /// 紧急会议开始选用户的
            /// </summary>
            Lemc
        }
    }


}
