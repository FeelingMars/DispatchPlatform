using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DispatchPlatform;

namespace DispatchPlatform.Control
{
    public partial class PageControl : UserControl
    {
        public List<SingleUserControl> _lstBtn = new List<SingleUserControl>();
        public int _pageSize = 60;
        public int _currentPageIndex = 0;
        public int _columnCount = 5;
        public int _rowCount = 5;
        private int _maxCount = 0;
        /// <summary>
        /// 间距
        /// </summary>
        private int _jj = 2;

        /// <summary>
        /// 控件大小
        /// </summary>
        private int _cWidth = 191;
        private int _cHeight = 90;

      

        private Label _showMsgLable = new Label();

        /// <summary>
        /// 有下一页
        /// </summary>
        public bool IsNextPage { get; set; }

        /// <summary>
        /// 要过滤的类型
        /// </summary>
        public EnumFilterType FilterType { get; set; }

        public PageControl()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            InitializeComponent();
            this.Load += new EventHandler(PageControl_Load);
            this.DoubleBuffered = true;
        }

        void PageControl_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Resize += new EventHandler(flowLayoutPanel1_Resize);
           // Console.WriteLine(flowLayoutPanel1.Width + " -" + flowLayoutPanel1.Height);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); //双缓冲

            _columnCount = Pub._configModel.ShowColums;
            _rowCount = Pub._configModel.ShowRows;
            _pageSize = _columnCount * _rowCount;
            GetSingleControlSize();
        }

        void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Width>0)
            {
               // flowLayoutPanel1.Padding = new Padding(24,6,12,10);
                //this._pageSize = 10;
                Console.WriteLine(flowLayoutPanel1.GetHashCode() + " " + flowLayoutPanel1.Width);
                GetSingleControlSize( );
                LoadData();
            }
        }

       // public bool ControlSizeChanaged { get; set; }

        /// <summary>得到单个用户控件的大小</summary>
        public void GetSingleControlSize()
        {
            int offsetV = GetOffsetValue(flowLayoutPanel1.Width, _columnCount);
            flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(offsetV, 0, 0, 0);

            _cWidth = ((flowLayoutPanel1.Width - offsetV) / _columnCount) - _jj;// -((_columnCount) * _jj);
            _cHeight = (flowLayoutPanel1.Height / _rowCount) - _jj;// -((_rowCount) * _jj);

            _pageSize = _columnCount * _rowCount;
        }

        /// <summary>
        /// 根据最大宽度和列数，计算偏移量
        /// </summary>
        /// <param name="maxV"></param>
        /// <param name="sV"></param>
        /// <returns></returns>
        private int GetOffsetValue(int maxV, int sV)
        {
            for (int i = 0; i < 2 * sV + 1; i++)
            {
                if ((maxV - i) % sV == 0)
                {
                    return i;
                }
            }
            return 0;
        }

        public void Init(List<SingleUserControl> lstBtn)
        {
            _lstBtn = lstBtn;
            _maxCount = _lstBtn.Count;
          //  Console.WriteLine(flowLayoutPanel1.Width + " -" + flowLayoutPanel1.Height);
            LoadData();
        }

        PreNextPageControl nextPre = new PreNextPageControl();
        PreNextPageControl nextB = new PreNextPageControl();

        private void ClearControl()
        {
            if(flowLayoutPanel1.Controls.Count>0)
            {
                if (Pub.CanDestroyControl == true)
                {
                    //if (flowLayoutPanel1.Controls.Count >= _maxCount && IsNextPage==true)
                   // if ( IsNextPage == true)
                    {
                        DestroyHandle();
                    }
                }
            }
            foreach (System.Windows.Forms.Control item in flowLayoutPanel1.Controls)
            {
                if (item.Visible==true && Pub.CanDestroyControl==true)
                {
                   // DestroyHandle();   
                }
            }
        }

        // <summary>
        // 计算总共要多少页
        // </summary>
        // <param name="maxCount"></param>
        // <param name="pageSize"></param>
        // <returns></returns>
        //private int Compute2(int maxCount, int pageSize)
        //{
        //    if (maxCount < pageSize) return 1;
        //    if (maxCount == pageSize) return 2;
        //    return (maxCount - 2 - 1) / (pageSize - 2) + 1;
        //}

        private int GetTotalPageCount()
        {
            return Compute(_maxCount, _pageSize);
        }

        public class PageInfo
        {
            public int FromIndex { get; set; }

            public int ToIndex { get; set; }
        }

        List<PageInfo> _lstPageInfo = new List<PageInfo>();

        /// <summary>
        /// 模拟计算分页的数量，并计算每一页的开始结束索引
        /// </summary>
        /// <param name="maxCount"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private int Compute(int maxCount, int pageSize)
        {
            int i = 0;
            int m0 = pageSize - 1;
            int m1 = pageSize - 2;
            bool isBegin = false;
            _lstPageInfo.Clear();
            int fromIndex = 0;
            int toIndex = 0;
            int tmp = 0;

            while (tmp < maxCount)
            {
                i++;
                if (isBegin)
                {
                    if ((maxCount - tmp) == m0)
                    {
                        tmp += m0;
                        fromIndex = tmp - m0;
                        toIndex = fromIndex + m0 ;
                    }
                    else
                    {
                        tmp += m1;
                        fromIndex = tmp - m1;
                        toIndex = fromIndex + m1 ;
                    }
                }
                else
                {
                    isBegin = true;
                    tmp += m0;
                    fromIndex = tmp - m0;
                    toIndex = fromIndex + m0 ;
                }

                if (toIndex > maxCount)
                {
                    toIndex = maxCount ;
                }
                _lstPageInfo.Add(new PageInfo()
                {
                    FromIndex = fromIndex,
                    ToIndex = toIndex
                });
            }

            return i;
        }

        public void LoadData()
        {
         
            ClearControl();
            flowLayoutPanel1.Controls.Clear();
           

            if (nextPre != null)
            {
                nextPre.Dispose();
                nextPre = null;
            }

            if (nextB != null)
            {
                nextB.Dispose();
                nextB = null;
            }
            ////减去分页按钮的数量
            //int subCount = 0;



            //int p = _pageSize;
            string showPageCount = (_currentPageIndex + 1) + "/" + GetTotalPageCount();
            ////254 30 
            ////254 9*28-2

            //bool isLast = false;

            //if (_currentPageIndex == 0 )
            //{
            //    p = _pageSize - 1;
            //}
            //else if (_maxCount == (_currentPageIndex + 1) * (_pageSize - 2) + 2)
            //{
            //    p = _pageSize - 1;
            //    isLast = true;
            //}
            //else
            //{
            //    p = _pageSize - 2;
            //}

            //int _fromIndex = 0;// p* _currentPageIndex;

            //if (_currentPageIndex != 0)
            //{
            //    _fromIndex++;
            //}

            //if (isLast)
            //{
            //    _fromIndex=(p-1)*_currentPageIndex+(
            //}
            //else
            //{

            //}


            //int toIndex = _fromIndex + p;

            //toIndex = toIndex - subCount;
            //toIndex = toIndex >= _maxCount ? _maxCount : toIndex;

            int fromIndex = 0;
            int toIndex = 0;

            if (_lstPageInfo.Count > 0)
            {
                fromIndex = _lstPageInfo[_currentPageIndex].FromIndex;
                toIndex = _lstPageInfo[_currentPageIndex].ToIndex;
            }

            for (int i = fromIndex; i < toIndex; i++)
            {
                if (_lstBtn.Count > 0)
                {
                    flowLayoutPanel1.Controls.Add(_lstBtn[i]);
                    _lstBtn[i].Width = _cWidth;
                    _lstBtn[i].Height = _cHeight;
                    _lstBtn[i].Margin = new Padding(_jj, _jj, 0, 0);

                   Pub. UpdateSingleUserContorlFont(_lstBtn[i]);
                }
            }

            if (_currentPageIndex >= 1)
            {
                nextPre = new PreNextPageControl();
                flowLayoutPanel1.Controls.Add(nextPre);
                nextPre.Margin = new Padding(_jj, _jj, 0, 0);
                nextPre.Width = _cWidth;
                nextPre.Height = _cHeight;
                nextPre.PageCount = showPageCount;
                nextPre.Text = "<<";
                nextPre.ButtonType = PreNextPageControl.EnumType.Pre;
                nextPre.Click += new EventHandler(btnPre_Click);
            }
            //&& flowLayoutPanel1.Controls.Count + 1 > _pageSize
            //if (toIndex < _maxCount && GetVisibleTrueCount() >= _pageSize)
            if (toIndex < _maxCount)
            {
                nextB = new PreNextPageControl();
                flowLayoutPanel1.Controls.Add(nextB);
                nextB.Margin = new Padding(_jj, _jj, 0, 0);
                nextB.Click += new EventHandler(btnNext_Click);
                nextB.ButtonType = PreNextPageControl.EnumType.Next;
                nextB.Width = _cWidth;
                nextB.Height = _cHeight;

                nextB.PageCount = showPageCount;
                nextB.Text = ">>";
                IsNextPage = true;
            }
            else
            {
                IsNextPage = false;
            }

        }




        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _currentPageIndex++;
            LoadData();
            this.Visible = true ;
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _currentPageIndex--;
            LoadData();
            this.Visible = true;
        }

        /// <summary>
        /// 只排序
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="onLine"></param>
        /// <param name="department"></param>
        public void Sort(bool ID,bool number, bool name, bool onLine, bool department)
        {
            Pub.CanDestroyControl = false;
            if (ID) _lstBtn = _lstBtn.OrderBy(p => p.ID).ToList();
            if (number) _lstBtn = _lstBtn.OrderBy(p => p.Number).ToList();
            if (name) _lstBtn = _lstBtn.OrderBy(p => p.MemberName).ToList();
            if (onLine) _lstBtn = _lstBtn.OrderBy(p => -p.IsOnline).ToList();
            if (department) _lstBtn = _lstBtn.OrderBy(p => -p.DepartmentID).ToList();

            //_maxCount = GetVisibleTrueCount();
            //if (_maxCount==0)
            //{
            //    return;
            //}
            _currentPageIndex = 0;
            LoadData();
            Pub.CanDestroyControl = true;
        }

        
        /// <summary>
        ///排序并过滤/// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="name"></param>
        /// <param name="onLine"></param>
        /// <param name="department"></param>
        public void SortAndFilterVisible(bool ID,bool number, bool name, bool onLine, bool department)
        {
            if (Pub._configModel.AutoFilterMember==true)
            {
                if (ID) _lstBtn = _lstBtn.OrderBy(p => p.ID).ToList();
                if (number) _lstBtn = _lstBtn.OrderBy(p => p.Number).ToList();
                if (name) _lstBtn = _lstBtn.OrderBy(p => p.MemberName).ToList();
                if (onLine) _lstBtn = _lstBtn.OrderBy(p => -p.IsOnline).ToList();
                if (department) _lstBtn = _lstBtn.OrderBy(p => -p.DepartmentID).ToList();

                this.Visible = false;
                foreach (SingleUserControl item in _lstBtn)
                {
                    item.Visible = item.GetCanDoByFilterType(this.FilterType);
                }

                _lstBtn = _lstBtn.OrderBy(p => p.Visible == false).ToList();//最后一个
                _maxCount = GetVisibleTrueCount();
                _currentPageIndex = 0;
                LoadData();
                this.Visible = true;
            }
        }

        /// <summary>过滤用户,给会议邀请人用</summary>
        /// <param name="fType"></param>
        public void FilterMemberForMeeting(EnumFilterType fType)
        {
            // this.Visible = false;

            //过滤前先排序
            if (Pub._configModel.SortByID) _lstBtn = _lstBtn.OrderBy(p => p.ID).ToList();
            if (Pub._configModel.SortByNumber) _lstBtn = _lstBtn.OrderBy(p => p.Number).ToList();
            if (Pub._configModel.SortByName) _lstBtn = _lstBtn.OrderBy(p => p.MemberName).ToList();
            if (Pub._configModel.SortByOnline) _lstBtn = _lstBtn.OrderBy(p => -p.IsOnline).ToList();
            if (Pub._configModel.SortByDepartment) _lstBtn = _lstBtn.OrderBy(p => -p.DepartmentID).ToList();

            ///过滤空闲的
            foreach (SingleUserControl item in _lstBtn)
            {
                item.Visible = item.GetCanDoByFilterType(fType);
            }

           // Pub._currentSelectMeetingMemberCount = this._lstBtn.Count;

            //过滤已选的人员
            foreach (DB_Talk.Model.m_Member item in Pub._talkControl.NumberList)
            {
                SingleUserControl sc = Pub._pageControl._lstBtn.Find(p => p.Number == item.i_Number.Value);
                if (sc != null)
                {
                    sc.Visible = false;
                }
            }
            Pub._talkControl.NumberList.Clear();
            _lstBtn = _lstBtn.OrderBy(p => p.Visible == false).ToList();
            _maxCount = GetVisibleTrueCount();
            _currentPageIndex = 0;
            LoadData();
           // this.Visible = true;
        }
  
        /// <summary>
        /// 得到可见的数量
        /// </summary>
        /// <returns></returns>
        public int GetVisibleTrueCount()
        {
            List<SingleUserControl> lstC = _lstBtn.FindAll(p => p.Visible == true);
            if (lstC != null && lstC.Count > 0)
            {
                return lstC.Count;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 将所有用户设置可见
        /// </summary>
        public void ShowAllMember()
        {
            this.FilterType = EnumFilterType.None;

            foreach (SingleUserControl item in _lstBtn)
            {
                item.Visible = true;
            }
            _currentPageIndex = 0;
            _maxCount = _lstBtn.Count;
            LoadData();
        }
    }


  
}
