using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

namespace CommControl
{
    [DefaultProperty("Text")]
    public partial class TextBoxListEx : UserControl
    {
        public event EventHandler OnDropDown;
        public event EventHandler TextChanged;
        public event KeyEventHandler KeyDown;
        public event KeyPressEventHandler KeyPress;


        [Description("Text"), Category("QControls"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true)]      
        public override string Text 
        { 
            get { return txtValue.Text; } 
            set { txtValue.Text = value; } 
        }

        public TextBoxListEx()
        {
            InitializeComponent();
            picDropList.MouseUp += new MouseEventHandler(picDropList_MouseUp);
            this.txtValue.KeyDown += new KeyEventHandler(txtValue_KeyDown);
            this.txtValue.KeyPress += new KeyPressEventHandler(txtValue_KeyPress);
            this.txtValue.TextChanged += new EventHandler(txtValue_TextChanged);
        }

        void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (TextChanged != null)
            {
                TextChanged(sender, e);
            }
        }

        void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPress != null)
            {
                KeyPress(sender, e);
            }
        }

        void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyDown != null)
            {
                KeyDown(sender, e);
            }
        }

        void picDropList_MouseUp(object sender, MouseEventArgs e)
        {
            if (OnDropDown != null)
            {
                OnDropDown(sender, e);
            }
        }

        private void picDropList_MouseEnter(object sender, EventArgs e)
        {
            picDropList.Image = CommControl.Properties.Resources.MouseOnDown;
        }

        private void picDropList_MouseLeave(object sender, EventArgs e)
        {
            picDropList.Image = CommControl.Properties.Resources.NormalDown;
        }

 
    }
}
