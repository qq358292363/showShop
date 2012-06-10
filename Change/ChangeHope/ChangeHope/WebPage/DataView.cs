namespace ChangeHope.WebPage
{
    using ChangeHope.DataBase;
    using System;

    public class DataView
    {
        private string rowHeah = "";
        private string rowText = "";
        private string sql = "";

        public string GetView()
        {
            DataByPage page = new DataByPage();
            page.Sql = this.sql;
            page.GetRecordSetByPage();
            DataTable table = new DataTable();
            table.RowHead = this.rowHeah;
            table.RowText = this.rowText;
            table.DataReader = page.DataReader;
            string str = table.GetDataTable() + page.PageToolBar;
            page.Dispose();
            page = null;
            table = null;
            return str;
        }

        public string GetView(DataByPage datapage)
        {
            DataTable table = new DataTable();
            table.RowHead = this.rowHeah;
            table.RowText = this.rowText;
            table.DataReader = datapage.DataReader;
            string str = table.GetDataTable() + datapage.PageToolBar;
            datapage.Dispose();
            datapage = null;
            table = null;
            return str;
        }

        public string RowHead
        {
            get
            {
                return this.rowHeah;
            }
            set
            {
                this.rowHeah = value;
            }
        }

        public string RowText
        {
            get
            {
                return this.rowText;
            }
            set
            {
                this.rowText = value;
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

