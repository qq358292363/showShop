namespace ChangeHope.DataBase
{
    using ChangeHope.Common;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;

    public class DataHelper
    {
        public static string GetContent(string table, string value)
        {
            return GetContent(table, "code", "content", value);
        }

        public static string GetContent(string table, string code, string content, string codevalue)
        {
            return StringHelper.ToString(SQLServerHelper.GetSingle("select " + content + " from " + table + " where " + code + "='" + codevalue + "'"));
        }

        public static DataTable GetDataTable()
        {
            using (SqlConnection connection = SQLServerHelper.Connection)
            {
                return connection.GetSchema("Tables");
            }
        }

        public DataTable GetDataTable(string tablename)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("SELECT A.name AS col, C.name AS type, A.length");
            builder.Append(" FROM syscolumns A LEFT OUTER JOIN  sysobjects B ON A.id = B.id LEFT OUTER JOIN");
            builder.Append(" systypes C ON A.xtype = C.xtype");
            builder.Append(" WHERE (B.name ='" + tablename + "')");
            return SQLServerHelper.Query(builder.ToString()).Tables[0];
        }

        public static DataTable GetDataTable(string sql, params SqlParameter[] values)
        {
            SqlConnection connection = SQLServerHelper.Connection;
            DataSet dataSet = new DataSet();
            SqlCommand selectCommand = new SqlCommand(sql, connection);
            selectCommand.Parameters.AddRange(values);
            new SqlDataAdapter(selectCommand).Fill(dataSet);
            connection.Close();
            connection.Dispose();
            return dataSet.Tables[0];
        }

        public static DataTable GetDataTableBySql(string sql)
        {
            SqlConnection connection = SQLServerHelper.Connection;
            DataSet dataSet = new DataSet();
            SqlCommand selectCommand = new SqlCommand(sql, connection);
            new SqlDataAdapter(selectCommand).Fill(dataSet);
            connection.Close();
            connection.Dispose();
            return dataSet.Tables[0];
        }
    }
}

