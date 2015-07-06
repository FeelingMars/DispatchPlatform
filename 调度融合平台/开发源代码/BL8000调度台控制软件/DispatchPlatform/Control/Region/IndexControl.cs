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
        public event EventHandler<BeforeSelectIndexChangeEventArgs> BeforeIndexChanged;

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
        }

        private void btnIndexNext_Click(object sender, EventArgs e)
        {
            m_IndexOffset += 1;
            ChangePage();
        }

        private void btnIndexPre_Click(object sender, EventArgs e)
        {
            m_IndexOffset -= 1;
            ChangePage();
        }

        private bool m_CauseCheckedChangedEvent = true;
        private void btnCommon_CheckedChanged(object sender, EventArgs e)
        {
            ButtonX currentControl = (ButtonX)sender;

            int index = Convert.ToInt32(currentControl.Tag);

            m_CauseCheckedChangedEvent = false;

            ChangeBtnCheck(false, currentControl);

            m_CauseCheckedChangedEvent = true;
            m_SelectIndex = index + m_IndexOffset;
            if (SelectIndexChanged != null)
            {
                SelectIndexChanged(this, new SelectIndexChangeEventArgs() { Index = index });
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

        private void btnIndex1_Click(object sender, EventArgs e)
        {
            ButtonX currentControl = (ButtonX)sender;

            if (BeforeIndexChanged != null)
            {
                BeforeSelectIndexChangeEventArgs args = new BeforeSelectIndexChangeEventArgs()
                {
                    BeforeIndex = m_SelectIndex,
                };
                BeforeIndexChanged(this, args);
                if (args.Cancel)
                {
                    return;
                }
            }
            currentControl.Checked = true;
        }

        private void ChangePage()
        {
            this.btnIndex1.Text = (Convert.ToInt32(this.btnIndex1.Tag) + ViewIndexCount * m_IndexOffset).ToString();
            this.btnIndex2.Text = (Convert.ToInt32(this.btnIndex1.Tag) + ViewIndexCount * m_IndexOffset).ToString();
            this.btnIndex3.Text = (Convert.ToInt32(this.btnIndex1.Tag) + ViewIndexCount * m_IndexOffset).ToString();
            this.btnIndex4.Text = (Convert.ToInt32(this.btnIndex1.Tag) + ViewIndexCount * m_IndexOffset).ToString();
            this.btnIndex5.Text = (Convert.ToInt32(this.btnIndex1.Tag) + ViewIndexCount * m_IndexOffset).ToString();

            this.btnIndexPre.Enabled = m_IndexOffset > 0;
            this.btnIndexNext.Enabled = m_IndexOffset * ViewIndexCount <= m_MaxIndex;

        }
    }


}
