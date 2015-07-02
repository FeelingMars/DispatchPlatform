using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using CommControl;
using DevComponents.DotNetBar;
using DispatchPlatform.Control;

namespace DispatchPlatform
{
    public class MemberManage
    {
        private FormMain _mainForm = null;
        public List<NormalGroupModel> _lstGroup = new List<NormalGroupModel>();
        DevComponents.DotNetBar.Rendering.SuperTabColorTable superTabColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabColorTable();
        DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable2 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
        DevComponents.DotNetBar.Rendering.SuperTabItemColorTable superTabItemColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemColorTable();
        DevComponents.DotNetBar.Rendering.SuperTabColorStates superTabColorStates1 = new DevComponents.DotNetBar.Rendering.SuperTabColorStates();
        DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable superTabItemStateColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabItemStateColorTable();
        DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable superTabLinearGradientColorTable1 = new DevComponents.DotNetBar.Rendering.SuperTabLinearGradientColorTable();
        
        
        public MemberManage(FormMain frm)
        {
            _mainForm = frm;
        }

        public void Init()
        {
            LoadMember();
            LoadGroupMember();
        }

        /// <summary>加载用户</summary>
        /// <param name="frm"></param>
        private void LoadMember()
        {
            //2014-11-11修改i_Dispatch=0,只显示正常号码，调度号和视频调度号不显示
            List<DB_Talk.Model.m_Member> lstMember = new DB_Talk.BLL.m_Member().GetModelList(string.Format("i_Flag=0 and i_IsDispatch=0 and BoxID={0} order by id",Pub.manageModel.BoxID.Value));

            //if (lstMember.Count == 0)
            //{
            //    CommControl.MessageBoxEx.MessageBoxEx.Show("请先到网管软件增加用户","提示");
            //    Application.Exit();
            //}

            PageControl pControl = new PageControl();
            _mainForm.superTabControlPanel5.Controls.Add(pControl);
            
            NormalGroupModel gModel = new NormalGroupModel();
            _lstGroup.Add(gModel);
            foreach (DB_Talk.Model.m_Member item in lstMember)
            {
                SingleUserControl s = new SingleUserControl();
                if (item.vc_Name!=null)
                {
                    s.MemberName = item.vc_Name.ToString();    
                }
                
                s.Number = item.i_Number.Value;
                s.ID = item.ID;
                if (item.LevelID!=null)
                {
                    s.MemberLevel = item.LevelID.Value;    
                }
                if (item.DepartmentID!=null)
                {
                    s.DepartmentID = item.DepartmentID.Value;
                }

                if (item.i_TellType != null )
                {
                    s.TellType = (CommControl.PublicEnums.EnumTelType)item.i_TellType.Value;
                }

                s.BackColor = Color.BlueViolet;
                if (s.Number != Pub.manageModel.LeftDispatchNumber.Value && s.Number != Pub.manageModel.RightDispatchNumber.Value)
                {
                    gModel.lstControl.Add(s);
                    s.Click += new EventHandler(_mainForm.single_Click);
                }
                else
                {

                }
            }

            gModel.PageControl = pControl;
            pControl.Init(gModel.lstControl);
            pControl.Dock = DockStyle.Fill;

            NormalGroupModel dispatchsModel = new NormalGroupModel();
            _lstGroup.Add(dispatchsModel);
            if (Pub.manageModel.LeftDispatchNumber!=null)
            {
                _mainForm.cLeft.Number = Pub.manageModel.LeftDispatchNumber.Value;
                _mainForm.cLeft.UserLineStatus = TalkControl.EnumUserLineStatus.Offline;
            }
            
            //_mainForm.cLeft.Name = "左席";
            _mainForm.cLeft.MemberName = Pub.manageModel.LeftDispatchName;
            _mainForm.cLeft.IsDispatch = true;

            dispatchsModel.lstControl.Add(_mainForm.cLeft);

            if (Pub.manageModel.RightDispatchNumber!=null)
            {
                _mainForm.cRight.Number = Pub.manageModel.RightDispatchNumber.Value;
                _mainForm.cRight.UserLineStatus = TalkControl.EnumUserLineStatus.Offline;
            }
            
            //_mainForm.cRight.Name = "右席";
            _mainForm.cRight.MemberName = Pub.manageModel.RightDispatchName;
            _mainForm.cRight.IsDispatch = true;
            dispatchsModel.lstControl.Add(_mainForm.cRight);
            Pub.SetSupperTabColor(_mainForm.stiAllMember);
        }

        /// <summary>加载分组用户</summary>
        private void LoadGroupMember()
        {
            List<DB_Talk.Model.m_Group> lstGroup = new DB_Talk.BLL.m_Group().GetModelList(string.Format("i_Flag=0 and groupTypeID={0} and BoxID={1}", PublicEnums.EnumGroupType.Normal.GetHashCode(),Pub.manageModel.BoxID.Value));
            int index = 1;//因为前面已加过两个了
            foreach (DB_Talk.Model.m_Group item in lstGroup)
            {
                index++;
                 NormalGroupModel gModel = new NormalGroupModel();
                 _lstGroup.Add(gModel);
                SuperTabItem a = new SuperTabItem();
                a.Text = item.vc_Name;
                a.SelectedTabFont = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
                superTabLinearGradientColorTable1.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(48))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(113)))), ((int)(((byte)(130)))))};
                superTabItemStateColorTable1.Background = superTabLinearGradientColorTable1;
                superTabColorStates1.Selected = superTabItemStateColorTable1;
                superTabItemColorTable1.Bottom = superTabColorStates1;
                a.TabColor = superTabItemColorTable1;
                a.Tag = index;
                a.Click += new EventHandler(_mainForm.MemberTabItem_Click);

                Pub.SetSupperTabColor(a);

                _mainForm.superTabControlDispatch.Tabs.Add(a);


                SuperTabControlPanel sp = new SuperTabControlPanel();
                _mainForm.superTabControlDispatch.Controls.Add(sp);
                a.AttachedControl = sp;
                

                PageControl fp = new PageControl();
                sp.Controls.Add(fp);
                fp.Dock = DockStyle.Fill;

                gModel.PageControl = fp;
                List<DB_Talk.Model.v_GroupMembers> lstGroupMember = new DB_Talk.BLL.v_GroupMembers().GetModelList("groupid=" + item.ID);
                foreach (DB_Talk.Model.v_GroupMembers gItem in lstGroupMember)
                {
                    if (gItem.i_Number.Value != Pub.manageModel.LeftDispatchNumber.Value && gItem.i_Number.Value != Pub.manageModel.RightDispatchNumber.Value )
                    {
                        SingleUserControl sc = new SingleUserControl();
                        sc.MemberName = gItem.vc_Name;
                        sc.Number = gItem.i_Number.Value;
                        sc.ID = gItem.MemberID.Value;
                        if (gItem.DepartmentID!=null)
                        {
                            sc.DepartmentID = gItem.DepartmentID.Value;    
                        }

                        if (gItem.i_TellType != null)
                        {
                            sc.TellType = (CommControl.PublicEnums.EnumTelType)gItem.i_TellType.Value;
                        }

                        gModel.lstControl.Add(sc);
                        sc.Click += new EventHandler(_mainForm.single_Click);
                    }
                }
                fp.Init(gModel.lstControl);
            }
        }

        /// <summary>
        /// 加载基站信息（3G）
        /// </summary>
        public void LoadFap()
        {
            List<DB_Talk.Model.m_FAP> lstFap = new DB_Talk.BLL.m_FAP().GetModelList("i_Flag=0 and BoxID=" + Pub.manageModel.BoxID.Value);
            foreach (DB_Talk.Model.m_FAP item in lstFap)
            {
                if (Pub.DicFap.ContainsKey(item.vc_TempAddress)==false)
                {
                    Pub.DicFap.Add(item.vc_TempAddress, item.ID);    
                }
            }
        }

        /// <summary>设置单个控件是否为可选中</summary>
        /// <param name="b"></param>
        public void SetControlIsCanSelect(bool b)
        {
            foreach (NormalGroupModel item in _lstGroup)
            {
                foreach (SingleUserControl s in item.lstControl)
                {
                    s.CanSelect = b;
                }
            }
        }

        /// <summary>设置选中状态</summary>
        /// <param name="b"></param>
        public void SetControlChecked(bool b)
        {
            foreach (NormalGroupModel item in _lstGroup)
            {
                foreach (SingleUserControl s in item.lstControl)
                {
                    if (s.IsDispatch==false)
                    {
                        s.Checked = b;    
                    }
                }
            }
        }

        /// <summary>设置用户对放显示名称</summary>
        /// <param name="memberID"></param>
        /// <param name="name"></param>
        public void SetMemberPeeName(long number, string name,bool isMeeting)
        {
            foreach (NormalGroupModel item in _lstGroup)
            {
                SingleUserControl s = item.lstControl.Find(delegate(SingleUserControl p) { return p.Number == number; });
                if (s != null)
                {
                    s.IsMeeting = isMeeting;
                    s.PeerNumber = name;
                    
                  //  break;
                }
            }
        }



        /// <summary>更新单个成员状态</summary>
        public void UpdateMemberState(long number, DispatchPlatform.TalkControl.EnumUserLineStatus state)
        {
            foreach (NormalGroupModel item in _lstGroup)
            {
                SingleUserControl s = item.lstControl.Find(delegate(SingleUserControl p) { return p.Number == number; });
                if (s != null)
                {
                   // s.MeetingMemberState = state;
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

        /// <summary>更新单个成员状态</summary>
        public void SetMemberState(long number, string state)
        {
            foreach (NormalGroupModel item in _lstGroup)
            {
                SingleUserControl s = item.lstControl.Find(delegate(SingleUserControl p) { return p.Number == number; });
                if (s != null)
                {
                    s.NumberState = state;
                }
            }
        }

        /// <summary>
        /// 设置成员告警状态 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="isAlarm"></param>
        public void UpdateMemberAlarmState(long number, bool isAlarm)
        {
            foreach (NormalGroupModel item in _lstGroup)
            {
                SingleUserControl s = item.lstControl.Find(delegate(SingleUserControl p) { return p.Number == number; });
                if (s != null)
                {
                    s.IsAlarm = isAlarm;
                   // break;
                }
            }
        }

        /// <summary>得到用户控件</summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public SingleUserControl GetSingleControl(long number)
        {
            SingleUserControl s = _lstGroup[0].lstControl.Find(delegate(SingleUserControl p) { return p.Number == number; });

            if (s==null)
            {
                s = _lstGroup[1].lstControl.Find(delegate(SingleUserControl p) { return p.Number == number; });
            }
            return s;
        }

        private SingleUserControl _tempSingleControl = null; 
        /// <summary>常规调度Trap消息使用</summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public void UpdateState(object obj, TalkControl.UserStateArgs e)
        {
            foreach (NormalGroupModel item in _lstGroup)
            {
                _tempSingleControl = item.lstControl.Find(delegate(SingleUserControl p) { return p.Number == e.UserNumber; });
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
                    if (_tempSingleControl.IsDispatch)
                    {
                        try
                        {
                            SingleUserControl scu = GetSingleControl(Convert.ToInt32(_tempSingleControl.PeerNumber));
                            if (scu != null)
                            {
                                _tempSingleControl.lblPeerNumberName.Text = scu.MemberName;
                            }
                            else
                            {
                                _tempSingleControl.lblPeerNumberName.Text = "";
                            }

                        }
                        catch (Exception)
                        {

                            //throw;
                        }
                    }
                    else
                    {
                        _tempSingleControl.lblPeerNumberName.Text = "";
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
            foreach (NormalGroupModel item in _lstGroup)
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
            foreach (NormalGroupModel item in _lstGroup)
            {
                if (item.PageControl != null)
                {
                    item.PageControl.Sort(Pub._configModel.SortByID, Pub._configModel.SortByNumber, Pub._configModel.SortByName, Pub._configModel.SortByOnline, Pub._configModel.SortByDepartment);
                }
            }
        }

        /// <summary>
        /// 设置过滤类型
        /// </summary>
        public void SetFilterType(EnumFilterType type)
        {
            if (Pub._configModel.AutoFilterMember==true )
            {
                foreach (NormalGroupModel item in _lstGroup)
                {
                    if (item.PageControl != null)
                    {
                        item.PageControl.FilterType = type;
                    }
                }
                this.Sort();
            }
        }

        /// <summary>
        /// 显示全部用户
        /// </summary>
        public void ShowAllMember()
        {
            if (Pub._configModel.AutoFilterMember == true)
            {
                foreach (NormalGroupModel item in _lstGroup)
                {
                    if (item.PageControl != null)
                    {
                        item.PageControl.ShowAllMember();
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
            foreach (NormalGroupModel item in _lstGroup)
            {
                if (item.PageControl != null)
                {
                    item.PageControl._columnCount = col;
                    item.PageControl._rowCount = row;
                    item.PageControl._currentPageIndex = 0;
                    item.PageControl.GetSingleControlSize();
                    item.PageControl.LoadData();
                }
                foreach (SingleUserControl  ss in item.lstControl)
                {
                    Pub.UpdateSingleUserContorlFont(ss);
                }
            }
            Pub.CanDestroyControl = true;
        }

        /// <summary>
        /// 选中一下每一个
        /// </summary>
        public void ClickTab()
        {
            foreach (SuperTabItem item in _mainForm.superTabControlDispatch.Tabs)
            {
                _mainForm.superTabControlDispatch.SelectedTab = item;
                item.RaiseClick();
            }
            _mainForm.superTabControlDispatch.SelectedTab =(SuperTabItem) _mainForm.superTabControlDispatch.Tabs[0];
        }

        /// <summary>
        /// 从所有用户中获取成员状态
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public TalkControl.EnumUserLineStatus GetMemberState(long number)
        {
            foreach (NormalGroupModel item in _lstGroup)
            {
                //SingleUserControl s = item.lstControl.Find(delegate(SingleUserControl p) { return p.Number == number; });
                SingleUserControl s = item.lstControl.Find(p=>  p.Number == number );
                if (s != null)
                {
                    return s.UserLineStatus;
                } 
                else
                {
                   // return TalkControl.EnumUserLineStatus.Offline;
                }
            }
            return TalkControl.EnumUserLineStatus.Offline;
        }


        /// <summary>根据用户状态信息得到个数</summary>
        /// <returns></returns>
        public int GetMemberCountByLineState(bool isBoxOnline,DispatchPlatform.TalkControl.EnumUserLineStatus state)
        {
            int count = 0;
            if (isBoxOnline==false)
            {
                return 0;
            }
             List<SingleUserControl> lstC = _lstGroup[0].lstControl.FindAll(delegate(SingleUserControl s)
            {
                return s.UserLineStatus == state;
            });
         
          
            if (lstC != null)
            {
                count = lstC.Count;
            }

            lstC = _lstGroup[1].lstControl.FindAll(delegate(SingleUserControl s)
            {
                return s.UserLineStatus == state;
            });

            if (lstC != null)
            {
                count =count+ lstC.Count;
            }
            return count;
        }

        /// <summary>
        /// 所有用户的个数
        /// </summary>
        /// <returns></returns>
        public int GetAllMemberCount()
        {
            return _lstGroup[0].lstControl.Count+2;//2是左右席
        }
        ///// <summary>
        ///// 得到在线的个数
        ///// </summary>
        ///// <returns></returns>
        //public int GetOnLineMember()
        //{
        //    int count = 0;
        //    List<SingleUserControl> lstC = _lstGroup[0].lstControl.FindAll(delegate(SingleUserControl s)
        //    {
        //        return s.UserLineStatus != TalkControl.EnumUserLineStatus.Offline &&
        //            s.UserLineStatus != TalkControl.EnumUserLineStatus.None
        //            ;
        //    });

        //    if (lstC != null)
        //    {
        //        count= lstC.Count;
        //    }
        //    else
        //    {
        //        count= 0;
        //    }

        //    lstC = _lstGroup[1].lstControl.FindAll(delegate(SingleUserControl s)
        //    {
        //        return s.UserLineStatus != TalkControl.EnumUserLineStatus.Offline &&
        //            s.UserLineStatus != TalkControl.EnumUserLineStatus.None
        //            ;
        //    });

        //    if (lstC != null)
        //    {
        //        count = count+lstC.Count;
        //    }
        //    else
        //    {
        //        //count = 0;
        //    }
        //    return count;
        //}

        ///// <summary>
        ///// 得到保持用户的数量
        ///// </summary>
        ///// <returns></returns>
        //public int FindKeepMemberCount()
        //{
        //    int count = 0;
        //    List<SingleUserControl> lstC = _lstGroup[0].lstControl.FindAll(delegate(SingleUserControl s)
        //    {
        //        return s.UserLineStatus == TalkControl.EnumUserLineStatus.Holding;
        //    });
        //    if (lstC!=null)
        //    {
        //        count = lstC.Count;
        //    }
        //    return count;
        //}


        ///// <summary>
        ///// 得到监听用户的数量
        ///// </summary>
        ///// <returns></returns>
        //public int FindListenMemberCount()
        //{
        //    int count = 0;
        //    List<SingleUserControl> lstC = _lstGroup[0].lstControl.FindAll(delegate(SingleUserControl s)
        //    {
        //        return s.UserLineStatus == TalkControl.EnumUserLineStatus.Listen;
        //    });
        //    if (lstC != null)
        //    {
        //        count = lstC.Count;
        //    }
        //    return count;
        //}

        ///// <summary>
        ///// 得到录音用户的数量
        ///// </summary>
        ///// <returns></returns>
        //public int FindRecordMemberCount()
        //{
        //    int count = 0;
        //    List<SingleUserControl> lstC = _lstGroup[0].lstControl.FindAll(delegate(SingleUserControl s)
        //    {
        //        return s.UserLineStatus == TalkControl.EnumUserLineStatus.Record;
        //    });
        //    if (lstC != null)
        //    {
        //        count = lstC.Count;
        //    }
        //    return count;
        //}

        ///// <summary>
        ///// 得到不在线的个数
        ///// </summary>
        ///// <returns></returns>
        //public int GetOffLineMember()
        //{
        //    int count = 0;

        //    List<SingleUserControl> lstC = _lstGroup[0].lstControl.FindAll(delegate(SingleUserControl s)
        //    {
        //        return s.UserLineStatus == TalkControl.EnumUserLineStatus.Offline
        //            || s.UserLineStatus == TalkControl.EnumUserLineStatus.None;
        //    });
        //    if (lstC != null)
        //    {
        //        count= lstC.Count;
        //    }
        //    else
        //    {
        //        count= 0;
        //    }

        //    lstC = _lstGroup[1].lstControl.FindAll(delegate(SingleUserControl s)
        //    {
        //        return s.UserLineStatus == TalkControl.EnumUserLineStatus.Offline
        //            || s.UserLineStatus == TalkControl.EnumUserLineStatus.None;
        //    });
        //    if (lstC != null)
        //    {
        //        count = count+lstC.Count;
        //    }
        //    else
        //    {
        //       // count = 0;
        //    }
        //    return count;
        //}

        /// <summary>
        /// 清除
        /// </summary>
        public void ClearAll()
        {
            _lstGroup.Clear();
            _mainForm.superTabControlDispatch.Tabs.Clear();
        }

        /// <summary>
        ///  取IP广播板的IP地址
        /// </summary>
        /// <returns></returns>
        public List<string> GetBroadcastIP()
        {
            List<DB_Talk.Model.m_Member> lstMember = new DB_Talk.BLL.m_Member().GetModelList(
                string.Format("i_Flag=0 and i_IsDispatch=0 and BoxID={0} and i_TellType={1} order by id", Pub.manageModel.BoxID.Value,CommControl.PublicEnums.EnumTelType.广播.GetHashCode()));

            List<string> lst=lstMember.Select(p => p.vc_IP).ToList();
           //var   lstMember.Select(p => p.vc_IP);
           // foreach (var item in lstMember)
           // {
                
           // }
            return lst;
        }
    }

    /// <summary>
    /// 调度用户分组
    /// </summary>
    public class NormalGroupModel
    {
        public int GroupID { get; set; }

        public List<SingleUserControl> lstControl = new List<SingleUserControl>();

        public PageControl PageControl { get; set; }
    }

}
