using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar;

namespace DispatchPlatform
{
    public partial class FormKeyboard : Form
    {
        private TextBoxX _textBox = new TextBoxX();

        public FormKeyboard(TextBoxX txtBox)
        {
            InitializeComponent();
            _textBox = txtBox;
            this.Load += new EventHandler(FormKeyboard_Load);
        }

        void FormKeyboard_Load(object sender, EventArgs e)
        {
            SetDialogLocation();
        }

   
        private void SetDialogLocation()
        {
            Point p = _textBox.PointToScreen(_textBox.Location);

            //this.Left = p.X - _textBox.Left - 2;
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = p.Y - _textBox.Top + _textBox.Height - 2;

            if ((this.Left + this.Width) > Screen.PrimaryScreen.WorkingArea.Width)
            {
                this.Left = this.Left - (this.Width - _textBox.Width);
            }
        }

        private void buttonX18_Click_1(object sender, EventArgs e)
        {
            ButtonX b=(ButtonX)sender;
            _textBox.Text = _textBox.Text + b.Tag.ToString();
        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
            if (_textBox.Text.Length > 0)
            {
                _textBox.Text = _textBox.Text.Substring(0, _textBox.Text.Length - 1);
            }
        }

        private void buttonX28_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
