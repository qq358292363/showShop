namespace ChangeHope.WebPage
{
    using ChangeHope.Common;
    using System;
    using System.Text;

    public class Table
    {
        private int colnum = 0;
        private StringBuilder table = new StringBuilder();
        private StringBuilder temp = new StringBuilder();

        public Table()
        {
            FileHelper helper = new FileHelper();
            this.table.AppendLine(helper.ReadFileContent(ServerInfo.GetServerPath() + @"admin\include\table.htm"));
            helper = null;
        }

        public void AddCol(string value)
        {
            this.temp.AppendFormat("     <td >{0}</td>\n", value.Trim().Equals("") ? "&nbsp;" : value);
        }

        public void AddCol(string colspan, string value)
        {
            this.temp.AppendFormat("     <td {1}>{0}</td>\n", value.Trim().Equals("") ? "&nbsp;" : value, "colspan=" + colspan);
        }

        public void AddCol(string format, string[] value)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(format, (object[]) value);
            this.AddCol(builder.ToString());
            builder = null;
        }

        public void AddCol(string style, string width, string value)
        {
            this.temp.AppendFormat("    <td style=\"{0}\" width=\"{1}\">{2}</td>\n", style, width, value.Trim().Equals("") ? "&nbsp;" : value);
        }

        public void AddHead(string headrow)
        {
            string[] strArray = headrow.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                string[] strArray2 = strArray[i].Split(new char[] { '/' });
                this.AddHeadCol(strArray2[1], strArray2[0]);
            }
            this.AddRow();
        }

        public void AddHeadCol(string width, string value)
        {
            this.temp.AppendFormat("     <th width=\"{0}\">{1}</th>\n", width, value);
            this.colnum++;
        }

        public void AddRow()
        {
            this.table.AppendLine("  <tr>");
            this.table.AppendLine(this.temp.ToString());
            this.table.AppendLine("  </tr>");
            this.temp.Remove(0, this.temp.Length);
        }

        public void AddToolBar(string toolBar)
        {
            this.temp.AppendFormat("     <td class=\"toolbar\" colspan=\"{0}\">{1}</td>\n", this.colnum, toolBar);
            this.AddRow();
        }

        public string GetTable()
        {
            this.table.AppendLine("</table>");
            string str = this.table.ToString();
            this.temp = null;
            this.table = null;
            return str;
        }
    }
}

