using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BW_GridStyle
{
    public class ColumnStyle
    {
        private string name;
        private string displayName;
        private ushort width;
        private bool visible;
        private DataGridViewContentAlignment alignment;
        private bool show = true;

        /// <summary>
        /// 列名
        /// </summary>
        //[StyleItem("列名", typeof(string))]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        /// <summary>
        /// 列宽
        /// </summary>
        //[StyleItem("列宽", typeof(int))]
        public ushort Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// 可见性
        /// </summary>
        //[StyleItem("可见性", typeof(bool))]
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        /// <summary>
        /// 对齐方式
        /// </summary>
        //[StyleItem("对齐方式", typeof(string))]
        public DataGridViewContentAlignment Alignment
        {
            get { return alignment; }
            set { alignment = value; }
        }

        /// <summary>
        /// 是否展示在gridview中
        /// </summary>
        public bool Show
        {
            get { return show; }
            set { show = value; }
        }

        /// <summary>
        /// 列索引
        /// </summary>
        public int Index { get; set; }
    }

    ///// <summary>
    ///// 列的样式属性字段描述
    ///// name:属性中文名称
    ///// type:表格中的数值类型,枚举类型属性为string
    ///// </summary>
    //[AttributeUsage(AttributeTargets.Property)]
    //public class StyleItemAttribute : Attribute
    //{
    //    public StyleItemAttribute(string name, Type type)
    //    {
    //        this.Name = name;
    //        this.Type = type;
    //    }

    //    public string Name { get; set; }
    //    public Type Type { get; set; }
    //}
}
