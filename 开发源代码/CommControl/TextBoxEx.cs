using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace CommControl
{
        /// <summary>只允许输入数字的文本框</summary>
    public class TextBoxEx : DevComponents.DotNetBar.Controls.TextBoxX
    {
        public bool isNumber = false;

        [DefaultValue(null), Category("输入数字判断"), Description("是否只允许输入数字"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true)]
        public bool IsNumber { get { return isNumber; } set { isNumber = value; } }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            // 只读, 不处理
            if (this.ReadOnly) return;

            // 特殊键(含空格), 不处理
            if ((int)e.KeyChar < 32) return;

            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }

            // 非数字键, 放弃该输入
            if (isNumber && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            // 只读, 不处理
            if (this.ReadOnly) return;

            string regex = @"^[\w ]+$"; //匹配数字、字母、汉字
            if (isNumber) regex = "^[0-9]*$";  //匹配数字 
            var reg = new System.Text.RegularExpressions.Regex(regex);// 
            var str = this.Text.Replace(" ", "");
            var sb = new StringBuilder();
            if (!reg.IsMatch(str))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (reg.IsMatch(str[i].ToString()))
                    {
                        sb.Append(str[i].ToString());
                    }
                }
                this.Text = sb.ToString();
                this.SelectionStart = this.Text.Length;    //定义输入焦点在最后一个字符          
            }
        }
    }
    

}
