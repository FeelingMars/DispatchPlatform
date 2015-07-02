using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DispatchPlatform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           // listBox1.AutoScrollOffset = true;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Console.Write(e.NewValue);
         //   listBox1.SelectedIndex = e.NewValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 20; i++)
            {
                dataGridView1.Rows.Add(i.ToString());
            }
           // listBox1.HorizontalScrollbar = false;
           // listBox1.ScrollAlwaysVisible = false;
            vScrollBar1.Maximum = 40;

        }
    }
}
