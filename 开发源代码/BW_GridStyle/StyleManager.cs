using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Reflection;

namespace BW_GridStyle
{
    public class StyleManager
    {
        private string filePath = "config.xml";
        private Dictionary<string, DataGridStyle> dataGridStyles;
        private XmlDocument xmlDoc;
        private DevExpress.XtraGrid.Views.Grid.GridView _gridView;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="filePath"></param>
        public StyleManager()
        {
            Load();
        }

        public StyleManager(string filePath)
        {
            this.filePath = filePath;
            Load();
        }

        /// <summary>
        /// 加载配置文件，默认路径config.xml
        /// </summary>
        private void Load()
        {
            dataGridStyles = new Dictionary<string, DataGridStyle>();
            xmlDoc = new XmlDocument();
            if (File.Exists(filePath))
            {
                xmlDoc.Load(filePath);
                XmlNode node = xmlDoc.SelectSingleNode("Config/DataGridViews");
                XmlNodeList nodeList = node.SelectNodes("DataGridView");
                XmlNodeList columnNodes;
                ColumnStyle columnStyle;
                DataGridStyle dataGridStyle;
                int index;
                foreach (XmlNode _node in nodeList)
                {
                    dataGridStyle = new DataGridStyle();
                    dataGridStyle.TableName = _node.Attributes["tablename"].Value.ToString();
                    columnNodes = _node.ChildNodes;
                    index = 0;
                    foreach (XmlNode columnNode in columnNodes)
                    {
                        columnStyle = new ColumnStyle();
                        columnStyle.Name = columnNode.Attributes["name"].Value;
                        columnStyle.DisplayName = columnNode.Attributes["displayname"].Value;
                        columnStyle.Width = Convert.ToUInt16(columnNode.Attributes["width"].Value);
                        columnStyle.Visible = Convert.ToBoolean(columnNode.Attributes["visible"].Value);
                        columnStyle.Alignment = (DataGridViewContentAlignment)Convert.ToInt32(columnNode.Attributes["alignment"].Value);
                        if (columnNode.Attributes["show"] != null)
                            columnStyle.Show = Convert.ToBoolean(columnNode.Attributes["show"].Value);
                        else
                            columnStyle.Show = true;
                        columnStyle.Index = index;
                        index++;

                        if (!dataGridStyle.ColumnStyles.ContainsKey(columnStyle.Name))
                            dataGridStyle.ColumnStyles.Add(columnStyle.Name, columnStyle);
                        else
                            dataGridStyle.ColumnStyles[columnStyle.Name] = columnStyle;
                    }
                    dataGridStyles.Add(dataGridStyle.TableName, dataGridStyle);
                }
            }
            else
                CreateConfig();
        }

        /// <summary>
        /// 创建配置文件
        /// </summary>
        private void CreateConfig()
        {
            XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            xmlDoc.InsertBefore(xmlDec, xmlDoc.DocumentElement);
            XmlElement configElement = xmlDoc.CreateElement("Config");
            xmlDoc.AppendChild(configElement);
            XmlElement dgvsElement = xmlDoc.CreateElement("DataGridViews");
            configElement.AppendChild(dgvsElement);
            xmlDoc.Save(filePath);
        }

        //private List<StyleItemAttribute> GetAttribute(Type t)
        //{
        //    List<StyleItemAttribute> styleItems = new List<StyleItemAttribute>();
        //    ColumnStyle style = new ColumnStyle();
        //    style.Name = "aa";
        //    style.Width = 1;
        //    style.Visible = true;
        //    style.Alignment = AlignmentEnum.默认;
        //    foreach (PropertyInfo info in t.GetProperties())
        //    {
        //        object obj = info.GetValue(style, null);
        //        object[] objs = info.GetCustomAttributes(false);

        //        foreach (System.Attribute attr in objs)
        //        {
        //            if (attr is StyleItemAttribute)
        //                styleItems.Add(attr as StyleItemAttribute);
        //        }
        //    }

        //    return styleItems;
        //}

        /// <summary>
        /// 初始化样式表格
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dataGridView"></param>
        public void InitStyleGrid(string tableName, DataGridView styleGridView)
        {
            //List<StyleItemAttribute> styleItems = GetAttribute(typeof(ColumnStyle));
            styleGridView.AutoGenerateColumns = false;

            if (dataGridStyles.ContainsKey(tableName))
            {
                styleGridView.Columns.Clear();
                AddColumn("列名", typeof(string), false, true, styleGridView);
                AddColumn("列宽", typeof(ushort), false, true, styleGridView);
                AddColumn("可见性", typeof(bool), false, true, styleGridView);
                AddColumn("对齐方式", typeof(string), true, true, styleGridView);
                AddColumn("name", typeof(string), true, false, styleGridView);
                AddColumn("show", typeof(bool), true, false, styleGridView);
                foreach (ColumnStyle column in dataGridStyles[tableName].ColumnStyles.Values)
                {
                    styleGridView.Rows.Add(new object[] { 
                        column.DisplayName, 
                        column.Width, 
                        column.Visible,
                        GetAlignment_C(column.Alignment), 
                        column.Name,
                        column.Show});

                    if (!column.Show)
                        styleGridView.Rows[styleGridView.Rows.Count - 1].Visible = false;
                }
            }
        }

        private void AddColumn(string columnName, Type type,bool readOnly, bool visible, DataGridView styleGridView)
        {
            DataGridViewColumn column1;
            if (type.IsEnum)
            {
                column1 = new DataGridViewComboBoxColumn();
                foreach (Enum _enum in Enum.GetValues(type))
                    (column1 as DataGridViewComboBoxColumn).Items.Add(GetAlignment_C((DataGridViewContentAlignment)_enum));
            }
            else if (string.Compare(type.Name, typeof(bool).Name, true) == 0)
                column1 = new DataGridViewCheckBoxColumn();
            else
                column1 = new DataGridViewTextBoxColumn();
            column1.ValueType = type;
            column1.ReadOnly = readOnly;
            column1.Name = columnName;
            column1.HeaderText = columnName;
            column1.DataPropertyName = columnName;
            column1.SortMode = DataGridViewColumnSortMode.NotSortable;
            column1.Visible = visible;
            styleGridView.Columns.Add(column1);
        }

        public static string GetAlignment_C(DataGridViewContentAlignment alignment)
        {
            switch (alignment)
            { 
                case DataGridViewContentAlignment.NotSet:
                    return "默认";
                case DataGridViewContentAlignment.BottomCenter:
                    return "底部居中";
                case DataGridViewContentAlignment.BottomLeft:
                    return "底部左对齐";
                case DataGridViewContentAlignment.BottomRight:
                    return "底部右对齐";
                case DataGridViewContentAlignment.MiddleCenter:
                    return "居中";
                case DataGridViewContentAlignment.MiddleLeft:
                    return "左对齐";
                case DataGridViewContentAlignment.MiddleRight:
                    return "右对齐";
                case DataGridViewContentAlignment.TopCenter:
                    return "顶部居中";
                case DataGridViewContentAlignment.TopLeft:
                    return "顶部左对齐";
                case DataGridViewContentAlignment.TopRight:
                    return "顶部右对齐";
                default:
                    return "默认";
            }
        }

        private DataGridViewContentAlignment GetAlignment(string alignment)
        {
            switch (alignment)
            {
                case "默认":
                    return DataGridViewContentAlignment.NotSet;
                case "底部居中":
                    return DataGridViewContentAlignment.BottomCenter;
                case "底部左对齐":
                    return DataGridViewContentAlignment.BottomLeft;
                case "底部右对齐":
                    return DataGridViewContentAlignment.BottomRight;
                case "居中":
                    return DataGridViewContentAlignment.MiddleCenter;
                case "左对齐":
                    return DataGridViewContentAlignment.MiddleLeft;
                case "右对齐":
                    return DataGridViewContentAlignment.MiddleRight;
                case "顶部居中":
                    return DataGridViewContentAlignment.TopCenter;
                case "顶部左对齐":
                    return DataGridViewContentAlignment.TopLeft;
                case "顶部右对齐":
                    return DataGridViewContentAlignment.TopRight;
                default:
                    return DataGridViewContentAlignment.NotSet;
            }
        }

        /// <summary>
        /// 保存或更新表格样式
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="styleGridView">样式表格控件</param>
        public void SaveGridStyle(string tableName, DataGridView styleGridView)
        {
            DataGridStyle dataGridStyle = new DataGridStyle();
            dataGridStyle.TableName = tableName;
            ColumnStyle columnStyle;
            int index = 0;
            foreach (DataGridViewRow dr in styleGridView.Rows)
            {
                columnStyle = new ColumnStyle();
                columnStyle.Name = dr.Cells["name"].Value.ToString();
                columnStyle.DisplayName = dr.Cells["列名"].Value.ToString();
                columnStyle.Width = Convert.ToUInt16(dr.Cells["列宽"].Value);
                columnStyle.Visible = Convert.ToBoolean(dr.Cells["可见性"].Value);
                columnStyle.Alignment = GetAlignment(dr.Cells["对齐方式"].Value.ToString());
                columnStyle.Show = dr.Visible;
                columnStyle.Index = index;
                index++;
                dataGridStyle.ColumnStyles.Add(columnStyle.Name, columnStyle);
            }

            SaveGridStyle(dataGridStyle);
        }

        /// <summary>
        /// 保存或更新样式
        /// </summary>
        /// <param name="dataGridStyle">表样式类</param>
        public void SaveGridStyle(DataGridStyle dataGridStyle)
        {
            if (!dataGridStyles.ContainsKey(dataGridStyle.TableName))
                dataGridStyles.Add(dataGridStyle.TableName, dataGridStyle);
            else
                dataGridStyles[dataGridStyle.TableName] = dataGridStyle;

            XmlElement element = GetDataGridViewElement(dataGridStyle);

            XmlNode node = xmlDoc.SelectSingleNode("Config/DataGridViews");
            string tablename;
            bool isReplaced = false;
            foreach (XmlNode _node in node.ChildNodes)
            {
                tablename = _node.Attributes["tablename"].Value;
                if (string.Compare(tablename, dataGridStyle.TableName,true)==0)
                {
                    node.ReplaceChild(element, _node);
                    isReplaced = true;
                    break;
                }
            }
            if (!isReplaced)
                node.AppendChild(element);

            xmlDoc.Save(filePath);
        }

        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="gridView"></param>
        public void SetGridStyle(string tableName, DataGridView gridView)
        {
            if (!dataGridStyles.ContainsKey(tableName))
            {
                SaveNewGridStyle(tableName, gridView);//配置文件中不存在此表格的样式配置，需要保存到文件中
            }
            else
            {
                SortedList<int, ColumnStyle> columnStyleList = new SortedList<int, ColumnStyle>();
                DataGridStyle dataGridStyle = dataGridStyles[tableName];
                DeleteMissColumn(dataGridStyle, gridView);

                ColumnStyle columnStyle;
                int i = 0;
                foreach (DataGridViewColumn column in gridView.Columns)
                {
                    if (dataGridStyle.ColumnStyles.ContainsKey(column.Name))
                    {
                        columnStyle = dataGridStyle.ColumnStyles[column.Name];
                        SetColumnStyle(column, columnStyle);
                        columnStyleList.Add(column.DisplayIndex, columnStyle);
                    }
                    else//此列为新增列时，需要增加到配置文件中
                    {
                        column.DisplayIndex = dataGridStyle.ColumnStyles.Count + i;
                        columnStyle = GetColumnStyle(column);
                        columnStyleList.Add(column.DisplayIndex, columnStyle);
                        i++;
                    }
                }

                dataGridStyle.ColumnStyles.Clear();
                for (int j = 0; j < columnStyleList.Count; j++)
                    dataGridStyle.ColumnStyles.Add(columnStyleList[j].Name, columnStyleList[j]);

                SaveGridStyle(dataGridStyle);
                
            }
        }

       
        public void SetColumnShowEnable(string tableName, string columnName, bool show)
        {
            if (dataGridStyles.ContainsKey(tableName))
            {
                DataGridStyle dgs = dataGridStyles[tableName];
                if (dgs.ColumnStyles.ContainsKey(columnName))
                {
                    dgs.ColumnStyles[columnName].Show = show;
                }
            }
        }

        /// <summary>删除失踪的列</summary>
        private void DeleteMissColumn(DataGridStyle dataGridStyle, DataGridView gridView)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (DataGridViewColumn column in gridView.Columns)
            {
                if (dataGridStyle.ColumnStyles.ContainsKey(column.Name))
                    dict.Add(column.Name, column.Name);
            }

            string[] keys = new string[dataGridStyle.ColumnStyles.Count];
            dataGridStyle.ColumnStyles.Keys.CopyTo(keys, 0);

            for (int i = keys.Length - 1; i >= 0; i--)
            {
                if (!dict.ContainsKey(keys[i]))
                    dataGridStyle.ColumnStyles.Remove(keys[i]);
            }

            int index = 0;
            foreach (string key in dataGridStyle.ColumnStyles.Keys)
            {
                dataGridStyle.ColumnStyles[key].Index = index;
                index++;
            }
        }

        private XmlElement GetDataGridViewElement(DataGridStyle dataGridStyle)
        {
            XmlElement element = xmlDoc.CreateElement("DataGridView");
            element.SetAttribute("tablename", dataGridStyle.TableName);
            XmlElement child;
            ColumnStyle column;
            foreach (string key in dataGridStyle.ColumnStyles.Keys)
            {
                column = dataGridStyle.ColumnStyles[key];
                child = xmlDoc.CreateElement("ColumnStyle");
                child.SetAttribute("name", column.Name);
                child.SetAttribute("displayname", column.DisplayName);
                child.SetAttribute("width", column.Width.ToString());
                child.SetAttribute("visible", column.Visible.ToString());
                child.SetAttribute("alignment", ((int)column.Alignment).ToString());
                child.SetAttribute("show", column.Show.ToString());

                element.AppendChild(child);
            }

            return element;
        }

        /// <summary>
        /// 保存新的表格样式
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="gridView"></param>
        private void SaveNewGridStyle(string tableName, DataGridView gridView)
        {
            ColumnStyle columnStyle;
            DataGridStyle dataGridStyle = new DataGridStyle();
            dataGridStyle.TableName = tableName;
            foreach (DataGridViewColumn column in gridView.Columns)
            {
                columnStyle = GetColumnStyle(column);
                dataGridStyle.ColumnStyles.Add(columnStyle.Name, columnStyle);
            }

            SaveGridStyle(dataGridStyle);
        }

        /// <summary>
        /// 从表格列中获取样式信息
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private ColumnStyle GetColumnStyle(DataGridViewColumn column)
        {
            ColumnStyle columnstyle = new ColumnStyle();
            columnstyle.Name = column.Name;
            columnstyle.DisplayName = column.HeaderText;
            columnstyle.Width = Convert.ToUInt16(column.Width);
            columnstyle.Visible = column.Visible;
            columnstyle.Alignment = column.DefaultCellStyle.Alignment;
            columnstyle.Show = true;
            columnstyle.Index = column.DisplayIndex;

            return columnstyle;
        }

        /// <summary>
        /// 设置表格列的样式
        /// </summary>
        /// <param name="column"></param>
        /// <param name="columnStyle"></param>
        private void SetColumnStyle(DataGridViewColumn column, ColumnStyle columnStyle)
        {
            column.HeaderText = columnStyle.DisplayName;
            if (columnStyle.Width == 0)
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            else
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.Width = columnStyle.Width;
            }
            column.Visible = columnStyle.Visible && columnStyle.Show;
            column.DefaultCellStyle.Alignment = columnStyle.Alignment;
            column.DisplayIndex = columnStyle.Index;
        }



        /// 设置样式devExpress
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="gridView"></param>
        public void SetGridStyle(string tableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            _gridView = gridView;
            if (!dataGridStyles.ContainsKey(tableName))
            {
                SaveNewGridStyle(tableName, gridView);//配置文件中不存在此表格的样式配置，需要保存到文件中
            }
            else
            {
                SortedList<int, ColumnStyle> columnStyleList = new SortedList<int, ColumnStyle>();
                DataGridStyle dataGridStyle = dataGridStyles[tableName];
                DeleteMissColumn(dataGridStyle, gridView);

                ColumnStyle columnStyle;
                int i = 0;
                //_gridView.OptionsView.ColumnAutoWidth = true;
                //是否自动调整列宽
                bool auto = false;
                foreach (System.Collections.Generic.KeyValuePair<string, ColumnStyle> item in dataGridStyle.ColumnStyles)
                {
                    if (_gridView != null)
                    {
                        if (item.Value.Width == 0) auto = true;
                    }
                }
                _gridView.OptionsView.ColumnAutoWidth = auto;


                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns)
                {

                    if (dataGridStyle.ColumnStyles.ContainsKey(column.Name))
                    {
                        columnStyle = dataGridStyle.ColumnStyles[column.Name];
                        //SetColumnStyle(column, columnStyle);
                        columnStyleList.Add(columnStyle.Index, columnStyle);
                    }
                    else//此列为新增列时，需要增加到配置文件中
                    {
                        int index = dataGridStyle.ColumnStyles.Count + i;
                        columnStyle = GetColumnStyle(column);
                        columnStyle.Index = index;
                        columnStyleList.Add(index, columnStyle);
                        //SetColumnStyle(column, columnStyle);
                        //columnStyleList.Add(columnStyle.Index, columnStyle);
                        //columnStyleList.Add(column.VisibleIndex, columnStyle);  //当设置列不可见时VisibleIndex为-1
                        i++;


                    }
                }


                foreach (System.Collections.Generic.KeyValuePair<int, ColumnStyle> item in columnStyleList)
                {
                    foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns)
                    {
                        if (column.Name == item.Value.Name)
                        {
                            SetColumnStyle(column, item.Value);   //设置visbleIndex必须按照显示顺序设置，不然先设置的即使index比较大还是显示在前面
                            break;
                        }
                    }

                }

                dataGridStyle.ColumnStyles.Clear();
                for (int j = 0; j < columnStyleList.Count; j++)
                    dataGridStyle.ColumnStyles.Add(columnStyleList[j].Name, columnStyleList[j]);

                SaveGridStyle(dataGridStyle);

            }
        }

        /// 保存新的表格样式DevExpress
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="gridView"></param>   
        private void SaveNewGridStyle(string tableName, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            ColumnStyle columnStyle;
            DataGridStyle dataGridStyle = new DataGridStyle();
            dataGridStyle.TableName = tableName;
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns)
            {
                columnStyle = GetColumnStyle(column);
                dataGridStyle.ColumnStyles.Add(columnStyle.Name, columnStyle);
            }

            SaveGridStyle(dataGridStyle);
        }

        /// <summary>删除失踪的列DevExpress</summary>
        private void DeleteMissColumn(DataGridStyle dataGridStyle, DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView.Columns)
            {
                if (dataGridStyle.ColumnStyles.ContainsKey(column.Name))
                    dict.Add(column.Name, column.Name);
            }

            string[] keys = new string[dataGridStyle.ColumnStyles.Count];
            dataGridStyle.ColumnStyles.Keys.CopyTo(keys, 0);

            for (int i = keys.Length - 1; i >= 0; i--)
            {
                if (!dict.ContainsKey(keys[i]))
                    dataGridStyle.ColumnStyles.Remove(keys[i]);
            }

            int index = 0;
            foreach (string key in dataGridStyle.ColumnStyles.Keys)
            {
                dataGridStyle.ColumnStyles[key].Index = index;
                index++;
            }
        }

        /// 设置表格列的样式DevExpress
        /// </summary>
        /// <param name="column"></param>
        /// <param name="columnStyle"></param>
        private void SetColumnStyle(DevExpress.XtraGrid.Columns.GridColumn column, ColumnStyle columnStyle)
        {
            column.Caption = columnStyle.DisplayName;
            if (columnStyle.Width != 0)
            {
                column.OptionsColumn.FixedWidth = true;
                column.Width = columnStyle.Width;
            }
            else
            {
                column.OptionsColumn.FixedWidth = false;
                //column.Width=column.GetBestWidth();//.BestFit();
                //column.Resize(column.GetBestWidth());
            }

            DevExpress.Utils.VertAlignment vertAlignment;
            DevExpress.Utils.HorzAlignment horzAlignment;
            getDevGridViewAlignment(columnStyle.Alignment, out vertAlignment, out horzAlignment);

            column.AppearanceCell.TextOptions.VAlignment = vertAlignment;
            column.AppearanceCell.TextOptions.HAlignment = horzAlignment;
            if (columnStyle.Visible)
                column.VisibleIndex = columnStyle.Index;
            else
                column.VisibleIndex = -1;
            //column.VisibleIndex = columnStyle.Index;
            column.Visible = columnStyle.Visible;
        }

        //将DevExpress.XtraGrid列的对齐方式转化为DataGridViewContentAlignment
        private System.Windows.Forms.DataGridViewContentAlignment ConvertToAlignment(DevExpress.XtraGrid.Columns.GridColumn column)
        {

            int v = 0;
            int h = 0;
            switch (column.AppearanceCell.TextOptions.HAlignment)
            {
                case DevExpress.Utils.HorzAlignment.Center:
                    h = 2;
                    break;
                case DevExpress.Utils.HorzAlignment.Default:
                    h = 1;
                    break;
                case DevExpress.Utils.HorzAlignment.Far:
                    h = 3;
                    break;
                case DevExpress.Utils.HorzAlignment.Near:
                    h = 1;
                    break;
                default:
                    break;
            }
            switch (column.AppearanceCell.TextOptions.VAlignment)
            {
                case DevExpress.Utils.VertAlignment.Bottom:
                    v = 256;
                    break;
                case DevExpress.Utils.VertAlignment.Center:
                    v = 16;
                    break;
                case DevExpress.Utils.VertAlignment.Default:
                    v = 0;
                    break;
                case DevExpress.Utils.VertAlignment.Top:
                    v = 1;
                    break;
                default:
                    break;
            }

            System.Windows.Forms.DataGridViewContentAlignment Alignment = (System.Windows.Forms.DataGridViewContentAlignment)(v * 2 ^ (h - 1));
            return Alignment;

        }
        /// 从表格列中获取样式信息DevExpress
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private ColumnStyle GetColumnStyle(DevExpress.XtraGrid.Columns.GridColumn column)
        {
            ColumnStyle columnstyle = new ColumnStyle();
            columnstyle.Name = column.Name;
            if (column.Caption == "")
                columnstyle.DisplayName = column.FieldName;
            else
                columnstyle.DisplayName = column.Caption;
            columnstyle.Width = Convert.ToUInt16(column.Width);
            columnstyle.Visible = column.Visible;
            columnstyle.Alignment = ConvertToAlignment(column);  //将DevExpress.XtraGrid列的对齐方式转化为DataGridViewContentAlignment
            columnstyle.Index = column.VisibleIndex;
            return columnstyle;

        }

        //获取DevExpress.XtraGrid列的对齐方式
        private void getDevGridViewAlignment(System.Windows.Forms.DataGridViewContentAlignment Alignment, out DevExpress.Utils.VertAlignment vertAlignment, out DevExpress.Utils.HorzAlignment horzAlignment)
        {
            switch (Alignment)
            {
                case DataGridViewContentAlignment.BottomCenter:
                    vertAlignment = DevExpress.Utils.VertAlignment.Bottom;
                    horzAlignment = DevExpress.Utils.HorzAlignment.Center;
                    break;
                case DataGridViewContentAlignment.BottomLeft:
                    vertAlignment = DevExpress.Utils.VertAlignment.Bottom;
                    horzAlignment = DevExpress.Utils.HorzAlignment.Near;
                    break;
                case DataGridViewContentAlignment.BottomRight:
                    vertAlignment = DevExpress.Utils.VertAlignment.Bottom;
                    horzAlignment = DevExpress.Utils.HorzAlignment.Far;
                    break;
                case DataGridViewContentAlignment.MiddleCenter:
                    vertAlignment = DevExpress.Utils.VertAlignment.Center;
                    horzAlignment = DevExpress.Utils.HorzAlignment.Center;
                    break;
                case DataGridViewContentAlignment.MiddleLeft:
                    vertAlignment = DevExpress.Utils.VertAlignment.Center;
                    horzAlignment = DevExpress.Utils.HorzAlignment.Near;
                    break;
                case DataGridViewContentAlignment.MiddleRight:
                    vertAlignment = DevExpress.Utils.VertAlignment.Center;
                    horzAlignment = DevExpress.Utils.HorzAlignment.Far;
                    break;
                case DataGridViewContentAlignment.NotSet:
                    vertAlignment = DevExpress.Utils.VertAlignment.Center;
                    horzAlignment = DevExpress.Utils.HorzAlignment.Near;
                    break;
                case DataGridViewContentAlignment.TopCenter:
                    vertAlignment = DevExpress.Utils.VertAlignment.Top;
                    horzAlignment = DevExpress.Utils.HorzAlignment.Center;
                    break;
                case DataGridViewContentAlignment.TopLeft:
                    vertAlignment = DevExpress.Utils.VertAlignment.Top;
                    horzAlignment = DevExpress.Utils.HorzAlignment.Near;
                    break;
                case DataGridViewContentAlignment.TopRight:
                    vertAlignment = DevExpress.Utils.VertAlignment.Top;
                    horzAlignment = DevExpress.Utils.HorzAlignment.Far;
                    break;
                default:
                    vertAlignment = DevExpress.Utils.VertAlignment.Center;
                    horzAlignment = DevExpress.Utils.HorzAlignment.Near;
                    break;
            }
        }
    }
}