using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommControl;

namespace BW_GridStyle
{
    public partial class GridStyleForm : frmBase
    {
        private string tableName = "";
        private StyleManager styleManager;
        public GridStyleForm(string tableName, StyleManager styleManager)
        {
            this.tableName = tableName;
            this.styleManager = styleManager;
            InitializeComponent();
            this.Icon = BW_GridStyle.Resource1.GridStyle;
        }

        private void GridStyleForm_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "表格格式设置";
            //this.Dock = DockStyle.Fill;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.BackgroundColor = Color.WhiteSmoke;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
	        this.dataGridView1.MultiSelect = false;
            comboBox1.Visible = false;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (Enum _enum in Enum.GetValues(typeof(DataGridViewContentAlignment)))
                comboBox1.Items.Add((object)StyleManager.GetAlignment_C((DataGridViewContentAlignment)_enum));

            styleManager.InitStyleGrid(tableName, this.dataGridView1);
        }

        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSaved(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();
            styleManager.SaveGridStyle(tableName, this.dataGridView1);
            this.Close();
        }

        /// <summary>
        /// 还原
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnReset(object sender, EventArgs e)
        {
            styleManager.InitStyleGrid(tableName, this.dataGridView1);
            comboBox1.Visible = false;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = this.dataGridView1.CurrentCell;
            if (cell != null && this.dataGridView1.Columns.Contains("对齐方式"))
            {
                if (cell.ColumnIndex == this.dataGridView1.Columns["对齐方式"].Index)
                {
                    Rectangle rect = this.dataGridView1.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, false);
                    this.comboBox1.Text = cell.Value.ToString();
                    this.comboBox1.Top = rect.Top + this.dataGridView1.Location.Y + panelWorkArea.Top + 1;
                    this.comboBox1.Left = rect.Left;
                    this.comboBox1.Width = rect.Width;
                    this.comboBox1.Height = rect.Height;
                    this.comboBox1.Visible = true;
                    this.comboBox1.BringToFront();
                }
                else
                {
                    this.comboBox1.Visible = false;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.CurrentCell.Value = comboBox1.Text;
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            this.comboBox1.Visible = false;
        }

        private void TextBoxDec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                e.Control.KeyPress += new KeyPressEventHandler(TextBoxDec_KeyPress);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("您输入的数据不合法，请重新输入！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }

        private void MoveUp_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            int i = this.dataGridView1.SelectedRows[0].Index;
            if (i == 0) return;
            MoveIndex(i, i - 1);
        }

        private void MoveDown_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count <= 0) return;
            int i = this.dataGridView1.SelectedRows[0].Index;
            if (i == this.dataGridView1.Rows.Count - 1) return;
            MoveIndex(i, i + 1);
        }

        private void MoveIndex(int sourceRowIndex, int desRowIndex)
        {
            if (sourceRowIndex == desRowIndex) return;
            if (sourceRowIndex < 0 ||
                sourceRowIndex >= this.dataGridView1.Rows.Count ||
                desRowIndex < 0 ||
                desRowIndex >= this.dataGridView1.Rows.Count) return;

            int index = -1;
            if (this.dataGridView1.CurrentCell != null)
                index = this.dataGridView1.CurrentCell.ColumnIndex;
            //插入
            object[] objs = new object[this.dataGridView1.Columns.Count];
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                objs[i] = this.dataGridView1.Rows[sourceRowIndex].Cells[i].Value;

            //下移
            if (sourceRowIndex < desRowIndex)
            {
                this.dataGridView1.Rows.Insert(desRowIndex + 1, objs);
                this.dataGridView1.Rows.RemoveAt(sourceRowIndex);
            }
            else//上移
            {
                this.dataGridView1.Rows.Insert(desRowIndex, objs);
                this.dataGridView1.Rows.RemoveAt(sourceRowIndex + 1);
            }
            this.dataGridView1.Rows[desRowIndex].Selected = true;

            if (index != -1)
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[desRowIndex].Cells[index];
            this.comboBox1.Visible = false;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null
                    || string.IsNullOrEmpty(this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Column" + (e.RowIndex + 1).ToString();
            }
            else if (e.ColumnIndex == 1)
            {
                if (this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null
                    || string.IsNullOrEmpty(this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            }
        }
    }
}
