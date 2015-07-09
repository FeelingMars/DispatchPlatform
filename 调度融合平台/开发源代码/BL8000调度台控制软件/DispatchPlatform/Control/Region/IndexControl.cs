using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DispatchPlatform.Event;
using DevComponents.DotNetBar;

namespace DispatchPlatform.Control
{
    internal partial class IndexControl : UserControl
    {
        public event EventHandler<SelectIndexChangeEventArgs> SelectIndexChanged;

        private const int ViewIndexCount = 5;
        private int m_IndexOffset = 0;
        private int m_SelectIndex = 0;
        private int m_MaxIndex = 0;

        public IndexControl()
        {
            InitializeComponent();
        }

        public int SelectIndex
        {
            get { return m_SelectIndex; }
            private set
            {
                if (value > m_MaxIndex)
                {
                    m_SelectIndex = m_MaxIndex;
                }
                else if (value < 0)
                {
                    m_SelectIndex = 0;
                }
                else
                {
                    m_SelectIndex = value;
                }
                m_IndexOffset = m_SelectIndex - ViewIndexCount < 0 ? 0 : m_SelectIndex - ViewIndexCount + 1;
            }
        }

        public void Init(int maxIndex)
        {
            m_MaxIndex = maxIndex;
            this.btnIndex1.Tag = 0;
            this.btnIndex2.Tag = 1;
            this.btnIndex3.Tag = 2;
            this.btnIndex4.Tag = 3;
            this.btnIndex5.Tag = 4;
            UpdateBtnEnable();
        }

        private void UpdateBtnEnable()
        {
            this.btnIndex1.Enabled = Convert.ToInt32(this.btnIndex1.Text) - 1 <= m_MaxIndex;
            this.btnIndex2.Enabled = Convert.ToInt32(this.btnIndex2.Text) - 1 <= m_MaxIndex;
            this.btnIndex3.Enabled = Convert.ToInt32(this.btnIndex3.Text) - 1 <= m_MaxIndex;
            this.btnIndex4.Enabled = Convert.ToInt32(this.btnIndex4.Text) - 1 <= m_MaxIndex;
            this.btnIndex5.Enabled = Convert.ToInt32(this.btnIndex5.Text) - 1 <= m_MaxIndex;
            this.btnIndexPre.Enabled = m_IndexOffset > 0;
            this.btnIndexNext.Enabled = (m_IndexOffset + 1) * ViewIndexCount <= m_MaxIndex;
            m_CauseCheckedChangedEvent = false;
            this.btnIndex1.Checked = Convert.ToInt32(this.btnIndex1.Text) - 1 == m_SelectIndex;
            this.btnIndex2.Checked = Convert.ToInt32(this.btnIndex2.Text) - 1 == m_SelectIndex;
            this.btnIndex3.Checked = Convert.ToInt32(this.btnIndex3.Text) - 1 == m_SelectIndex;
            this.btnIndex4.Checked = Convert.ToInt32(this.btnIndex4.Text) - 1 == m_SelectIndex;
            this.btnIndex5.Checked = Convert.ToInt32(this.btnIndex5.Text) - 1 == m_SelectIndex;
            m_CauseCheckedChangedEvent = true;
        }

        private void btnIndexNext_Click(object sender, EventArgs e)
        {
            m_IndexOffset += 1;
            ChangePage();
            UpdateBtnEnable();
        }

        private void btnIndexPre_Click(object sender, EventArgs e)
        {
            m_IndexOffset -= 1;
            ChangePage();
            UpdateBtnEnable();
        }

        private bool m_CauseCheckedChangedEvent = true;
        private void btnCommon_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_CauseCheckedChangedEvent)
                return;
            ButtonX currentControl = (ButtonX)sender;

            int btnIndex = Convert.ToInt32(currentControl.Tag);

            m_CauseCheckedChangedEvent = false;

            ChangeBtnCheck(false, currentControl);

            m_CauseCheckedChangedEvent = true;
            m_SelectIndex = btnIndex + m_IndexOffset * ViewIndexCount;
            if (SelectIndexChanged != null)
            {
                SelectIndexChanged(this, new SelectIndexChangeEventArgs() { Index = m_SelectIndex });
            }
        }

        private void ChangeBtnCheck(bool check, ButtonX exceptControl)
        {
            if (this.btnIndex1.Enabled && this.btnIndex1 != exceptControl)
            {
                this.btnIndex1.Checked = check;
            }
            if (this.btnIndex2.Enabled && this.btnIndex2 != exceptControl)
            {
                this.btnIndex2.Checked = check;
            }
            if (this.btnIndex3.Enabled && this.btnIndex3 != exceptControl)
            {
                this.btnIndex3.Checked = check;
            }
            if (this.btnIndex4.Enabled && this.btnIndex4 != exceptControl)
            {
                this.btnIndex4.Checked = check;
            }
            if (this.btnIndex5.Enabled && this.btnIndex5 != exceptControl)
            {
                this.btnIndex5.Checked = check;
            }
        }

        private void btnCommon_Click(object sender, EventArgs e)
        {
            ButtonX currentControl = (ButtonX)sender;

            int btnIndex = Convert.ToInt32(currentControl.Tag);
            int currentIndex = btnIndex + m_IndexOffset;
            if (currentIndex == m_SelectIndex)
            {
                return;
            }
            else
            {
                currentControl.Checked = true;
            }
        }

        private void ChangePage()
        {
            this.btnIndex1.Text = (Convert.ToInt32(this.btnIndex1.Tag) + 1 + ViewIndexCount * m_IndexOffset).ToString();
            this.btnIndex2.Text = (Convert.ToInt32(this.btnIndex2.Tag) + 1 + ViewIndexCount * m_IndexOffset).ToString();
            this.btnIndex3.Text = (Convert.ToInt32(this.btnIndex3.Tag) + 1 + ViewIndexCount * m_IndexOffset).ToString();
            this.btnIndex4.Text = (Convert.ToInt32(this.btnIndex4.Tag) + 1 + ViewIndexCount * m_IndexOffset).ToString();
            this.btnIndex5.Text = (Convert.ToInt32(this.btnIndex5.Tag) + 1 + ViewIndexCount * m_IndexOffset).ToString();

            float fontsize = m_IndexOffset > 0 ? 12F : 18F;
            this.btnIndex1.Font = new Font(this.btnIndex1.Font.FontFamily, fontsize);
            this.btnIndex2.Font = new Font(this.btnIndex2.Font.FontFamily, fontsize);
            this.btnIndex3.Font = new Font(this.btnIndex3.Font.FontFamily, fontsize);
            this.btnIndex4.Font = new Font(this.btnIndex4.Font.FontFamily, fontsize);
            this.btnIndex5.Font = new Font(this.btnIndex5.Font.FontFamily, fontsize);
        }
    }
}
