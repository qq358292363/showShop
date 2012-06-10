namespace ChangeHope.DataBase
{
    using ChangeHope.Common;
    using ChangeHope.WebPage;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Text;

    public class DataByPage
    {
        private string order;
        private string orderby = "";
        private string orderDesc;
        private int pageCount = 0;
        private int pageIndex = 0;
        private int pageSize = 15;
        private string pageToolBar = "";
        private Hashtable para;
        private string query;
        private string receptionToolBar = "";
        private int recordCount = 0;
        private SqlDataReader recordSet;
        private string sql;
        private string table;
        private string where;

        private void DescOrder()
        {
            this.orderDesc = this.order.Replace("desc", "as_1dec");
            this.orderDesc = this.orderDesc.Replace("asc", "desc");
            this.orderDesc = this.orderDesc.Replace("as_1dec", "asc");
        }

        public void Dispose()
        {
            if (this.recordSet != null)
            {
                this.recordSet.Close();
                this.recordSet.Dispose();
                this.recordSet = null;
            }
            this.pageToolBar = null;
            this.sql = null;
            this.query = null;
            this.table = null;
            this.where = null;
            this.order = null;
            this.orderDesc = null;
            GC.Collect();
        }

        private void GetCount()
        {
            try
            {
                string inputData = SQLServerHelper.GetSingle("select count(*) from " + this.table + " where  " + this.where).ToString();
                if (ValidateHelper.IsNumber(inputData))
                {
                    this.recordCount = int.Parse(inputData);
                }
                else
                {
                    this.recordCount = 0;
                }
            }
            catch
            {
                this.recordCount = 0;
            }
        }

        private void GetPageCount()
        {
            this.pageCount = ((this.recordCount + this.PageSize) - 1) / this.PageSize;
            if (this.pageIndex < 1)
            {
                this.pageIndex = 1;
            }
            if (this.pageIndex > this.pageCount)
            {
                this.pageIndex = this.pageCount;
            }
        }

        private void GetPara()
        {
            if (this.pageIndex < 1)
            {
                this.pageIndex = PageRequest.GetInt("pageindex");
            }
            if (this.pageIndex < 1)
            {
                this.pageIndex = 1;
            }
            this.para = PageRequest.GetPara();
        }

        public void GetRecordFreelabelByPage()
        {
            this.GetPara();
            this.SplitSqlFreelabel();
            this.DescOrder();
            this.GetCount();
            this.GetPageCount();
            this.GetToolBar();
            this.ReceptionGetToolBar();
            this.GetRecordSet();
        }

        private void GetRecordSet()
        {
            this.sql = "";
            if (this.recordCount > 0)
            {
                if ((this.pageCount <= 1) || (this.pageIndex <= 1))
                {
                    this.sql = string.Concat(new object[] { "select top ", this.PageSize, " ", this.query, " from ", this.table, " where ", this.where, " order by ", this.order });
                }
                else if (this.pageCount.Equals(this.pageIndex))
                {
                    this.sql = string.Concat(new object[] { "select top ", this.recordCount - (this.PageSize * (this.pageIndex - 1)), " ", this.query, " from ", this.table, " where ", this.where, " order by ", this.orderDesc });
                    this.sql = " select * from (" + this.sql + ")temptable order by " + this.order;
                }
                else
                {
                    this.sql = string.Concat(new object[] { "select top ", this.PageSize * this.pageIndex, " ", this.query, " from ", this.table, " where ", this.where, " order by ", this.order });
                    if (this.pageIndex > 1)
                    {
                        this.sql = string.Concat(new object[] { "select top ", this.PageSize, " * from (", this.sql, ") temptable order by ", this.orderDesc });
                        this.sql = " select * from (" + this.sql + ")temptable order by " + this.order;
                    }
                }
                this.recordSet = SQLServerHelper.ExecuteReader(this.sql);
            }
        }

        public void GetRecordSetByPage()
        {
            this.GetPara();
            this.SplitSql();
            this.DescOrder();
            this.GetCount();
            this.GetPageCount();
            this.GetToolBar();
            this.ReceptionGetToolBar();
            this.GetRecordSet();
        }

        private void GetToolBar()
        {
            StringBuilder builder = new StringBuilder();
            string str = "";
            if (this.para.Count > 0)
            {
                foreach (DictionaryEntry entry in this.para)
                {
                    str = string.Concat(new object[] { str, "&", entry.Key, "=", entry.Value });
                }
            }
            if (this.pageIndex <= 1)
            {
                builder.AppendLine("   <span class=\"disabled\"><<</span>");
                builder.AppendLine("   <span class=\"disabled\"><</span>");
            }
            else
            {
                builder.AppendLine("   <a href=?pageindex=1" + str + "><<</a>");
                builder.AppendLine(string.Concat(new object[] { "   <a href=?pageindex=", this.pageIndex - 1, str, "><</a>" }));
            }
            for (int i = ((this.pageIndex - 4) > 0) ? (this.pageIndex - 4) : 1; i <= (((this.pageIndex + 4) < this.pageCount) ? (this.pageIndex + 4) : this.pageCount); i++)
            {
                if (i == this.pageIndex)
                {
                    builder.AppendLine("<span class=\"current\">" + i + "</span>");
                }
                else
                {
                    builder.AppendLine(string.Concat(new object[] { "<a href=\"?pageindex=", i, str, "\">", i, "</a>" }));
                }
            }
            if ((this.pageIndex + 5) < this.pageCount)
            {
                builder.AppendLine("...");
                builder.AppendLine(string.Concat(new object[] { "<a href=\"?pageindex=", this.pageCount, str, "\">", this.pageCount, "</a>" }));
            }
            if (this.pageIndex >= this.pageCount)
            {
                builder.AppendLine("   <span class=\"disabled\">></span>");
                builder.AppendLine("   <span class=\"disabled\">>></span>");
            }
            else
            {
                builder.AppendLine(string.Concat(new object[] { "   <a href=?pageindex=", this.pageIndex + 1, str, ">></a>" }));
                builder.AppendLine(string.Concat(new object[] { "   <a href=?pageindex=", this.pageCount, str, ">>></a>" }));
            }
            this.pageToolBar = "\n<div class=\"quotes\">\n" + builder.ToString() + "</div>\n";
        }

        private string GetWhere()
        {
            StringBuilder builder = new StringBuilder();
            int index = 0;
            string str = "";
            string str2 = "";
            foreach (DictionaryEntry entry in this.para)
            {
                str = entry.Key.ToString();
                str2 = StringHelper.Filter(entry.Value.ToString());
                index = str.ToString().IndexOf("w_g_");
                if (index >= 0)
                {
                    builder.Append(" and " + str.Substring(index + 4) + ">='" + str2 + "'");
                }
                else
                {
                    index = str.ToString().IndexOf("w_e_");
                    if (index >= 0)
                    {
                        builder.Append(" and " + str.Substring(index + 4) + "<='" + str2 + "'");
                        continue;
                    }
                    index = str.ToString().IndexOf("w_d_");
                    if (index >= 0)
                    {
                        builder.Append(" and " + str.Substring(index + 4) + "='" + str2 + "'");
                        continue;
                    }
                    index = str.ToString().IndexOf("w_n_");
                    if (index >= 0)
                    {
                        builder.Append(" and " + str.Substring(index + 4) + "<>'" + str2 + "'");
                        continue;
                    }
                    index = str.ToString().IndexOf("w_l_");
                    if (index >= 0)
                    {
                        builder.Append(" and " + str.Substring(index + 4) + " like '%" + str2 + "%'");
                        continue;
                    }
                    index = str.ToString().IndexOf("w_z_");
                    if (index >= 0)
                    {
                        builder.Append(" and " + str.Substring(index + 4) + " like '" + str2 + "%'");
                        continue;
                    }
                    index = str.ToString().IndexOf("w_r_");
                    if (index >= 0)
                    {
                        builder.Append(" and " + str.Substring(index + 4) + " like '%" + str2 + "'");
                        continue;
                    }
                    index = str.ToString().IndexOf("w_s_");
                    if (index >= 0)
                    {
                        builder.Append(" and Substring(" + str.Substring(index + 4) + "," + str2 + ",1)=1");
                        continue;
                    }
                }
            }
            return builder.ToString();
        }

        private void ReceptionGetToolBar()
        {
            StringBuilder builder = new StringBuilder();
            string str = "";
            if (this.para.Count > 0)
            {
                foreach (DictionaryEntry entry in this.para)
                {
                    str = string.Concat(new object[] { str, "&", entry.Key, "=", entry.Value });
                }
            }
            builder.AppendLine(string.Concat(new object[] { "共找到 ", this.recordCount, " 条记录    分 ", this.pageCount, " 页显示" }));
            if (this.pageIndex <= 1)
            {
                builder.AppendLine("   <span class=\"disabled\">首页</span>");
                builder.AppendLine("   <span class=\"disabled\">上一页</span>");
            }
            else
            {
                builder.AppendLine("   <a href=?pageindex=1" + str + ">首页</a>");
                builder.AppendLine(string.Concat(new object[] { "   <a href=?pageindex=", this.pageIndex - 1, str, ">上一页</a>" }));
            }
            for (int i = ((this.pageIndex - 4) > 0) ? (this.pageIndex - 4) : 1; i <= (((this.pageIndex + 4) < this.pageCount) ? (this.pageIndex + 4) : this.pageCount); i++)
            {
                if (i == this.pageIndex)
                {
                    builder.AppendLine("<span class=\"current\">" + i + "</span>");
                }
                else
                {
                    builder.AppendLine(string.Concat(new object[] { "<a href=\"?pageindex=", i, str, "\">", i, "</a>" }));
                }
            }
            if ((this.pageIndex + 5) < this.pageCount)
            {
                builder.AppendLine("...");
                builder.AppendLine(string.Concat(new object[] { "<a href=\"?pageindex=", this.pageCount, str, "\">", this.pageCount, "</a>" }));
            }
            if (this.pageIndex >= this.pageCount)
            {
                builder.AppendLine("   <span class=\"disabled\">下一页</span>");
                builder.AppendLine("   <span class=\"disabled\">尾页</span>");
            }
            else
            {
                builder.AppendLine(string.Concat(new object[] { "   <a href=?pageindex=", this.pageIndex + 1, str, ">下一页</a>" }));
                builder.AppendLine(string.Concat(new object[] { "   <a href=?pageindex=", this.pageCount, str, ">尾页</a>" }));
            }
            this.receptionToolBar = "\n<ul class=\"quotes\">\n" + builder.ToString() + "</ul>\n";
        }

        private void SplitSql()
        {
            if (!this.sql.Equals(""))
            {
                this.sql = this.sql.Replace("[select]", "");
                this.sql = this.sql.Replace("[from]", "|");
                this.sql = this.sql.Replace("[where]", "|");
                this.sql = this.sql.Replace("[order by]", "|");
                string[] strArray = this.sql.Split(new char[] { '|' });
                this.query = strArray[0];
                this.table = strArray[1];
                this.where = strArray[2] + this.GetWhere();
                if (this.orderby.Equals(""))
                {
                    this.order = strArray[3];
                }
                else
                {
                    this.order = this.orderby;
                }
            }
        }

        private void SplitSqlFreelabel()
        {
            if (!this.sql.Equals(""))
            {
                this.sql = this.sql.Replace("select", "");
                this.sql = this.sql.Replace("from", "|");
                this.sql = this.sql.Replace("where", "|");
                this.sql = this.sql.Replace("order by", "|");
                string[] strArray = this.sql.Split(new char[] { '|' });
                this.query = strArray[0];
                this.table = strArray[1];
                this.where = strArray[2] + this.GetWhere();
                if (this.orderby.Equals(""))
                {
                    this.order = strArray[3];
                }
                else
                {
                    this.order = this.orderby;
                }
            }
        }

        public SqlDataReader DataReader
        {
            get
            {
                return this.recordSet;
            }
        }

        public string OrderBy
        {
            get
            {
                return this.orderby;
            }
            set
            {
                this.orderby = value;
            }
        }

        public int PageCount
        {
            get
            {
                return this.pageCount;
            }
            set
            {
                this.pageCount = value;
            }
        }

        public int PageIndex
        {
            get
            {
                return this.pageIndex;
            }
            set
            {
                this.pageIndex = value;
            }
        }

        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                this.pageSize = value;
            }
        }

        public string PageToolBar
        {
            get
            {
                return this.pageToolBar;
            }
            set
            {
                this.pageToolBar = value;
            }
        }

        public string ReceptionToolBar
        {
            get
            {
                return this.receptionToolBar;
            }
            set
            {
                this.receptionToolBar = value;
            }
        }

        public string Sql
        {
            get
            {
                return this.sql;
            }
            set
            {
                this.sql = value;
            }
        }
    }
}

