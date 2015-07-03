using System;
using System.Collections.Generic;
using System.Text;

namespace BW_GridStyle
{
    public class DataGridStyle
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName = "";

        /// <summary>
        /// 列样式集合
        /// </summary>
        public Dictionary<string, ColumnStyle> ColumnStyles = new Dictionary<string,ColumnStyle>();
    }
}
